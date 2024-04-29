using Ishop.AppCode.Utilities;
using Ishop.Areas.Mgr.Models;
using Ishop.Context;
using Ishop.Controllers;
using Ishop.Models.ProductMgr;
using Ishop.Models.UploadItem;
using Ishop.Utilities;
using LanguageResource;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Ishop.Areas.Mgr.Controllers
{
    public class ProductMgrController : BaseController
    {
        public ProductMgrController() : base()
        {
        }
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();

        [Authorize(Roles = "Supervisor,Admins,StoreAdmin,StoreProductAdmin")]
        [HttpGet]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, string StartDate, string EndDate, int? page)
        {
            ShopInitialize();
            // this.InitLanguageStateViewBag();  //作廢 2024-4-29

            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            ViewBag.CurrentStartDate = string.IsNullOrEmpty(StartDate) ? DateTime.Now.ToString("yyyy-MM-dd HH:mm") : StartDate;
            ViewBag.CurrentEndDate = string.IsNullOrEmpty(EndDate) ? DateTime.Now.ToString("yyyy-MM-dd HH:mm") : EndDate;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var products = from s in db.Products
                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductID.Contains(searchString) || s.Title.Contains(searchString)
                                                                                     || s.Title.Contains(searchString)
                                                                                     || s.ProductName.Contains(searchString)
                                                                                     || s.ProdDesc.Contains(searchString));
            }
            //DaySpan filter  
            if (StartDate != EndDate)
            {
                ViewBag.CurrentStartDate = StartDate;
                ViewBag.CurrentEndDate = EndDate;

                DateTime pStartDate = DateTime.Parse(StartDate);
                DateTime pEndDate = DateTime.Parse(EndDate);
                products = products.Where(s => s.OperatedDate > pStartDate && s.OperatedDate < pEndDate);
            }
            //shop filter
            products = products.Where(s => s.ShopID == WebCookie.ShopID);

            switch (sortOrder)
            {
                case "Date":
                    products = products.OrderBy(s => s.OperatedDate);
                    break;
                case "date_desc":
                    products = products.OrderByDescending(s => s.OperatedDate);
                    break;
                default:  // Name ascending 
                    products = products.OrderByDescending(s => s.OperatedDate);
                    break;
            }
            int pageSize = 30;
            int pageNumber = (page ?? 1);
            return View(products.ToPagedList(pageNumber, pageSize));
        }


        // GET: Mgr/ProductMgr
        [HttpGet]
        [Authorize(Roles = "Supervisor,StoreAdmin,StoreProductAdmin,StoreBusinessPromotion")]
        public ActionResult ProductAddUpd(string ProductID)
        { 
            EnumHelper EnumHelper1 = new Utilities.EnumHelper();
            ViewBag.SupplierIDList = db.Suppliers.ToList();
            SupplierDropDownList(ProductID);
            if (!string.IsNullOrEmpty(ProductID)) // not null
            {
                var productDetail = db.Products.Find(ProductID);

                if (productDetail == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ViewBag.SaleStatusIDList = EnumHelper.GetSelectList<SaleStatusID>();

                ProdCateDropDownList(productDetail.ProdCateID);

                // 返回 活动明细   
                ViewBag.CurrentProductID = ProductID; 
                ViewBag.TempProductID = ProductID; //同于同步表 UploadItem.TargetTalbeKeyID
                 //ViewBag.ProdCateName
                ViewBag.ProdCateName = string.IsNullOrEmpty( productDetail.ProdCateID ) ? string.Empty : db.Prodcates.Find(productDetail.ProdCateID).ProdCateName.Trim();
                //ViewBag.CategoryIDsName  FirstName of Collection
                ViewBag.CategoryIDsName = (string.IsNullOrEmpty(productDetail.CategoryIDs)|| productDetail.CategoryIDs=="0") ? string.Empty : db.Categorys.Find(productDetail.CategoryIDs.Split(',').First()).CategoryName.Trim();   
                //列出相关文件
                ViewBag.UploadItemList = db.UploadItems.Where(s => s.TargetTalbeKeyID.Contains(ProductID)).Count() > 0 ? db.UploadItems.Where(s => s.TargetTalbeKeyID.Contains(ProductID)&& s.SubPath.Contains("ProductMain")).ToList() : null;
                 
                ViewBag.vProdDesc = productDetail.ProdDesc;
                  
                return View(productDetail);
            }
            else
            {
                ViewBag.TempProductID = "TempProductID_" + Guid.NewGuid().ToString("N"); //格式:e0a953c3ee6040eaa9fae2b667060e09   
                ViewBag.SaleStatusIDList = EnumHelper.GetSelectList<SaleStatusID>();
                ProdCateDropDownList(null); // null : 不选定 

                return View();
            } 
        }

        //ShopStaff
        [HttpGet]
        public JsonResult getShopStaffList()
        {
            var ShopStaffQuery = from d in db.ShopStaffs
                                 select new {d.ShopID, d.ShopStaffID, d.StaffName }; 
            //Shop Filter
            ShopStaffQuery = ShopStaffQuery.Where(c => c.ShopID == WebCookie.ShopID);
            return Json(ShopStaffQuery.ToList(),JsonRequestBehavior.AllowGet);
        }
        private void SupplierDropDownList(object selectedSupplierID = null)
        {
            var SupplierQuery = from d in db.Suppliers
                                select d;
            //Shop filtering
            SupplierQuery = SupplierQuery.Where(c => c.ShopID == WebCookie.ShopID);
            ViewBag.SupplierID = new SelectList(SupplierQuery, "SupplierID", "ContactNick", selectedSupplierID);
        }
        //浏览次数
        [AllowAnonymous]
        public void ProductViewCount(string ProductID, string IpStatitics_StartDate_Token)
        { 
            //设置用于计算持续时间的起始时间
            string IpStatitics_StartDate = "";
            string IpStatitics_StartDate_Token_CK = "";
            if (Request.Cookies["IpStatitics_StartDate"] != null)
            {
                IpStatitics_StartDate = Request.Cookies["IpStatitics_StartDate"].Value;
                IpStatitics_StartDate_Token_CK = mvcCommeBase.SHA1_Hash(IpStatitics_StartDate);
            }
            else
            {
                //没有时间校验cookie,否则不统计
                return;
            }
            //验证传入数据后计数浏览量
            if (IpStatitics_StartDate_Token == IpStatitics_StartDate_Token_CK)
            {
                try
                {
                    Product ProductDetail = db.Products.Find(ProductID);
                    ProductDetail.ViewsIP += 1;
                    DbEntityEntry<Product> ProductEntry = db.Entry<Product>(ProductDetail);
                    db.Products.Attach(ProductDetail);
                    ProductEntry.Property(e => e.ViewsIP).IsModified = true;
                    db.SaveChanges();  // 写数据库
                }
                catch (DbEntityValidationException dbEx)
                {
                    //看看dbEX错误信息
                    throw dbEx;
                }
            }
            return;
        }
        [HttpPost]
        [Authorize(Roles = "Supervisor,StoreAdmin,StoreProductAdmin,StoreBusinessPromotion")]
        public ActionResult ProductAddUpd(string ProductID, [Bind(Include = "ProductID,ProdCateID,ProductName,Title,ProductImg,StyleNo ,ProdDesc,VideoUrl,CategoryIDs,ShopID ,SupplierID,TradePrice,RetailPrice,CommisionRate,ViewsIP,CreatedDate,SaleStatusID")]Product Productdetail)
        { 
            AdditionalForUpload AdditionalForUpload1 = new AdditionalForUpload();
            ModalDialogView ModalDialogView1 = new ModalDialogView();

            if (string.IsNullOrEmpty(ProductID))
            {
                Productdetail.ProductID = db.GetTableIdentityID("P", "Product", 5);
                //含有HTML代码 要放在ModelState.IsValid后面,否则验证不通过
                Productdetail.ProdDesc = HttpUtility.UrlDecode(Productdetail.ProdDesc, Encoding.UTF8);
                Productdetail.ShopID = WebCookie.ShopID;
                Productdetail.OperatedUserName = User.Identity.Name;
                Productdetail.CreatedDate = DateTime.Now;
                Productdetail.OperatedDate = DateTime.Now;

                try
                {
                    db.Products.Add(Productdetail);
                    db.SaveChanges();
                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message = "OK";
                    //最后 把 ProductID 同步图片临时ID(TargetTalbeKeyID):
                    if (ViewBag.TempProductID == null)
                    {
                        ViewBag.TempProductID = Session["TempProductID"].ToString();
                    }
                    AdditionalForUpload1.AlterTempTargetTalbeKeyID(ViewBag.TempProductID, Productdetail.ProductID);
                    return Json(ModalDialogView1);
                }
                catch (DbEntityValidationException dbEx)
                {
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message = "个别字段验证失败(DbEntityValidationException):\n" + dbEx.Message + "\n" + ModelState.Keys.ToList();
                    return Json(ModalDialogView1);
                }
            }
            else
            {
                try
                {
                    Productdetail.ProductID = ProductID;
                    Productdetail.ProdDesc = HttpUtility.UrlDecode(Productdetail.ProdDesc, Encoding.UTF8);

                    Productdetail.ShopID = WebCookie.ShopID;
                    Productdetail.OperatedUserName = User.Identity.Name;
                    Productdetail.OperatedDate = DateTime.Now;
                     
                    if (ModelState.IsValid)
                    {
                        db.Entry(Productdetail).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        ModalDialogView1.MsgCode = "1";
                        ModalDialogView1.Message = "Update OK";
                        return Json(ModalDialogView1);
                    }
                    else
                    {
                        ModalDialogView1.MsgCode = "0";
                        ModalDialogView1.Message = "Update Fail ,Invalid field";
                        return Json(ModalDialogView1);
                    }

                }
                catch (Exception e)
                {
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message = "Update Invalid data \n\n" + e.Message; ;
                    return Json(ModalDialogView1);
                } 
            }
        }
        private void ProdCateDropDownList(object selectedProdCateID = null)
        {
            var ProdCateQuery = from d in db.Prodcates
                                select d; 
            ViewBag.ProdCateID = new SelectList(ProdCateQuery, "ProdCateID", "ProdCateName", selectedProdCateID);
        }
        
        public List<ProdPropertiesName> GetPropName(string ProductId)
        {
            string ProdCateId = db.Products.Where(c => c.ProductID == ProductId).First().ProdCateID;
            var ProductPropName = db.ProdPropertiesNames.Where(c => c.ProdCateID == ProdCateId && c.IsForTrading == 1).ToList();
            return ProductPropName;
        }
        public List<ProdPropertiesValue> GetPropValue(ProdPropertiesName prodPropertiesName, string ProductId)
        {
            ProdPropertiesValue PropValue = new ProdPropertiesValue();
            var PropNameValue1 = db.ProdPropertiesValues.Where(c => c.PropertiesNameID == prodPropertiesName.PropertiesNameID).ToList();
            List<ProdPropertiesValue> LstPropNameValue = new List<ProdPropertiesValue>();
            if (prodPropertiesName.ShowPicture == 1)
            {
                foreach (var item in PropNameValue1)
                {
                    ProductSku productSku1 = db.ProductSkus.Where(c => c.PropValueIDs.Contains(item.PropertiesValueID.Trim()) && c.ProductID == ProductId).FirstOrDefault();
                    item.OperatedUserName = string.Empty;   // this column field use for SkuImage
                    if (productSku1 != null)
                    {
                        item.OperatedUserName = productSku1.SkuImage;
                    }
                    LstPropNameValue.Add(item);
                }
                return LstPropNameValue;
            }
            //clear PropNameValue1.OperatedUserName
            PropNameValue1.ForEach(m => m.OperatedUserName = "");
            return PropNameValue1;
        }
        [Authorize(Roles = "Supervisor,StoreAdmin,StoreProductAdmin")]
        [HttpGet]
        public ActionResult createSku(string ProductId)
        {
            Product product = new Product();
            product = db.Products.Find(ProductId);
            ViewBag.CurrentProductId = ProductId.ToUpper();
            ViewBag.TempProductSkuId = string.Format("{1}{0:yyyyMMddHHmmssfff}",DateTime.Now.ToString(), "SKUid");
            return View(product);
        }

        [Authorize(Roles = "Supervisor,StoreAdmin,StoreProductAdmin")]
        [HttpPost]
        public ActionResult createSku(string ProductId,string TempProductSkuId ,[Bind(Include = "txtQuantity,txtProductSkuTradePrice,txtProductSkuId,txtSkuImage,txtPropValueIDs")] ProductSkuAdd productSkuAdd)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            ModalDialogView1.MsgCode = "1";
            ModalDialogView1.Message = "OK";

            Product product = db.Products.Find(ProductId);

            //update uploaditem
            var TempProductSkus = db.UploadItems.Where(x => x.TargetTalbeKeyID == TempProductSkuId).ToList();
            TempProductSkus.ForEach(m => m.TargetTalbeKeyID = productSkuAdd.txtProductSkuId);
            db.SaveChanges(); 

            //get SkuId 
            ProductSku ProductSku1 = new ProductSku();
            ProductSku1 = db.ProductSkus.Find(productSkuAdd.txtProductSkuId);
             
            if (ProductSku1 == null)
            {
                ProductSku ProductSku2 = new ProductSku();
                ProductSku2.ProductID = product.ProductID;
                ProductSku2.ProductSkuId = productSkuAdd.txtProductSkuId;
                ProductSku2.Quantity = int.Parse(productSkuAdd.txtQuantity);
                ProductSku2.TradePrice = decimal.Parse(productSkuAdd.txtProductSkuTradePrice);
                ProductSku2.PropValueIDs = productSkuAdd.txtPropValueIDs.Trim();
                ProductSku2.StyleNo = product.StyleNo;
                ProductSku2.ProductName = product.ProductName;
                ProductSku2.OperatedUserName = User.Identity.Name;
                ProductSku2.OperatedDate = DateTime.Now;
                ProductSku2.SkuImage = productSkuAdd.txtSkuImage;
                ProductSku2.CreatedDate = DateTime.Now;
                db.ProductSkus.Add(ProductSku2);
                int Result = db.SaveChanges();

                if (Result > 0)
                {
                    UpdatePropertyDesc(ProductSku2.ProductSkuId);
                }
                return Json(ModalDialogView1);
            }
            else
            {
                ModalDialogView1.Message = Lang.CreateSku_createSku_ModalDialogView1;
                
                ProductSku1.ProductSkuId = productSkuAdd.txtProductSkuId;
                ProductSku1.Quantity = int.Parse(productSkuAdd.txtQuantity);
                ProductSku1.TradePrice = decimal.Parse(productSkuAdd.txtProductSkuTradePrice);
                ProductSku1.SkuImage = productSkuAdd.txtSkuImage;

                ProductSku1.OperatedUserName = User.Identity.Name;
                ProductSku1.OperatedDate = DateTime.Now;
                 
                db.Entry(ProductSku1).State =EntityState.Modified;
                int Result = db.SaveChanges();
                if (Result > 0)
                {
                    UpdatePropertyDesc(ProductSku1.ProductSkuId);
                }
                return Json(ModalDialogView1);
            }
        }
        /// <summary>
        /// JS： createSku : getProductSkuInfo()
        /// </summary>
        /// <param name="ProductSkuId"></param>
        /// <returns></returns>
        public JsonResult getProductSku(string ProductSkuId)
        {
            ProductSku productSku = new ProductSku(); 
            productSku = db.ProductSkus.Find(ProductSkuId);
            if (productSku == null)
            {
                return Json("{\"ProductSkuId\":\"-\"}");
            }else
            {
                return Json(productSku);
            }
        }

        [Authorize(Roles = "Supervisor,StoreAdmin,StoreProductAdmin")]
        public ActionResult ProductSkuList(string ProductId)
        {
            IQueryable<ProductSku> SkuList = from d in db.ProductSkus
                                   orderby d.ProductSkuId
                          where (d.ProductID == ProductId)
                          select d;
            ViewBag.ProductName = db.Products.Find(ProductId).ProductName;
            return View(SkuList);
        }
        public string UpdatePropertyDesc(string ProductSkuId)
        {
            ProductSku productSku = db.ProductSkus.Find(ProductSkuId);
            string PropValueIDs = productSku.PropValueIDs;
           
            string PropertyDesc = ""; 
            if (PropValueIDs.Contains('_') && PropValueIDs.Length > 0)
            {
                Array arr = PropValueIDs.Split('_');
                foreach (string item in arr)
                {
                    ProdPropertiesValue prodPropertiesValue = db.ProdPropertiesValues.Find(item);
                    string PropertiesValueName = prodPropertiesValue.PropertiesValueName.Trim();
                    string PropertiesNameID = prodPropertiesValue.PropertiesNameID;
                    string PropName = db.ProdPropertiesNames.Find(PropertiesNameID).PropertiesName;
                    PropertyDesc += string.Format("{0} : {1} ; ", PropName, PropertiesValueName);
                }
                PropertyDesc = PropertyDesc.TrimEnd(';');
            }
            else if( PropValueIDs.Length > 0 )
            {
                //PropValueIDs
                ProdPropertiesValue prodPropertiesValue = db.ProdPropertiesValues.Find(PropValueIDs);
                string PropertiesValueName = prodPropertiesValue.PropertiesValueName.Trim();
                string PropertiesNameID = prodPropertiesValue.PropertiesNameID; 
                string PropName = db.ProdPropertiesNames.Find(PropertiesNameID).PropertiesName;
                PropertyDesc += string.Format("{0}:{1}", PropName, PropertiesValueName);
            }
            //update
            productSku.PropertyDesc = PropertyDesc;
            db.Entry(productSku).State = EntityState.Modified;
            db.SaveChanges();
            return PropertyDesc;
        }

        public JsonResult DeleteProductSku(string ProductSkuId)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            ModalDialogView1.MsgCode = "1";
            ModalDialogView1.Message = "OK";

            ProductSku productSku = db.ProductSkus.Find(ProductSkuId);
            db.ProductSkus.Remove(productSku);
            int result = db.SaveChanges();
            if(result > 0)
            {
                //del relate picture
                var uploadItem = db.UploadItems.Where(c => c.TargetTalbeKeyID.Contains(ProductSkuId));
                foreach (var item in uploadItem)
                { 
                   if( System.IO.File.Exists(Server.MapPath(item.Url)))
                    {
                        System.IO.File.Delete(Server.MapPath(item.Url));
                    }
                }
                var IquerableUploadItem = uploadItem.ToList();
                IquerableUploadItem.ForEach(m => m.TargetTalbeKeyID = ProductSkuId.Trim());
                db.SaveChanges();

                return Json(ModalDialogView1);
            }else
            {
                ModalDialogView1.MsgCode = "0";
                ModalDialogView1.Message = "FAILURE";
                return Json(ModalDialogView1);
            }

        }
    }
}