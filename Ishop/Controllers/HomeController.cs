using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ishop.Context;
using Ishop.Utilities;
using Ishop.Models.ProductMgr;
using Ishop.Models.Info;
using Ishop.Models.PubDataModal;
using System.Data.Entity.Infrastructure;
using Ishop.AppCode.Utilities;
using Ishop.Areas.Mgr.Models;
using LanguageResource;
using System.Text.RegularExpressions;
using System.Configuration;
using Ishop.ViewModes.Info;
using Ishop.Models;
using Microsoft.AspNet.Identity;
using System.Globalization;
using System.Threading;
using Ishop.AppCode.EnumCode;
namespace Ishop.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController() : base()
        {
        }
        private readonly string WebSiteUrl = ConfigurationManager.AppSettings["WebSiteUrl"].ToString();
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();

        /// <summary>
        ///  目前有 IndexA | IndexB | IndexC 三種不同的模版
        /// </summary>
        /// <param name="id">由於收到規則 WebCookie.ShpID 通過HostName判斷店鋪ID,導致 ID傳入主頁有用,其餘都作廢了.</param>
        /// <param name="InfoCateID"></param>
        /// <param name="Index2"></param>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public ActionResult Index(string id,string InfoCateID ,string Index2,string code,string state)
        {
            ShopInitialize();
            //mvcCommeBase.ChkShpID(); //Deprecated 2024-5-6
            string ShpID = WebCookie.ShpID;
            Shop shop = new Shop(); 
            if (!string.IsNullOrEmpty(id))
            {
                ShpID = id;
                shop = db.Shops.Find(ShpID);
                if(shop!=null)
                {
                    WebCookie.ShpID = shop.ShopID;
                }
            }
            else
            {
                shop = db.Shops.Find(ShpID);
            }
            
            ViewBag.Title = shop.ShopName;
            ViewBag.KeyWord = shop.ShopName;
            ViewBag.Description = shop.ShopName;
            ViewBag.ShopLogo = shop.ShopLogo;
            ViewBag.PhoneNumber = shop.PhoneNumber;

            if (!string.IsNullOrEmpty(code))
            {
                Response.Redirect(string.Format("/i/wx/{0}?code={1}", state, code));
            }
            //Jumptron 
            InfoDetail infoDetail_Jumbotron = new InfoDetail();
            infoDetail_Jumbotron = db.InfoDetails.Where(c => c.InfoItemTemplateIDs.Contains("InfoTemp00001") && c.ShopID == ShpID).OrderByDescending(o=>o.OperatedDate).FirstOrDefault();
            ViewBag.infoDetail_Jumbotron = infoDetail_Jumbotron;

            string HELP_FUNCTUON = InfoCateEnumCode.HELP_FUNCTUON.ToString().ToUpper();
            string HELP_FIRST = InfoCateEnumCode.HELP_FIRST.ToString().ToUpper();
            string SOFTWARE_HELPER = InfoCateEnumCode.SOFTWARE_HELPER.ToString().ToUpper();
            var list1 = db.InfoDetails.Where(c => c.ShopID.Contains(ShpID) 
                            && !c.InfoCateID.Contains(SOFTWARE_HELPER)
                            && !c.InfoCateID.Contains(HELP_FIRST)
                            && !c.InfoCateID.Contains(HELP_FUNCTUON)).OrderByDescending(s => s.OperatedDate) //不包含有帮助功能行业资讯
                .Select(s=>new InfoListView{
                    InfoID=s.InfoID,
                    UserTraceID=s.UserTraceID,
                    InfoCateID=s.InfoCateID,
                    Title=s.Title,
                    InfoItemTemplateIDs=s.InfoItemTemplateIDs,
                    TitleThumbNail=s.TitleThumbNail,
                    ShowTitleThumbNail=s.ShowTitleThumbNail,
                    SubTitle=s.SubTitle,
                    SeoKeyword=s.SeoKeyword,
                    SeoDescription= s.SeoDescription,
                    VideoUrl=s.VideoUrl,
                    Author=s.Author,
                    IsOriginal=s.IsOriginal,
                    ShopStaffID=s.ShopStaffID,
                    Views=s.Views,
                    LanguageCode = s.LanguageCode,
                    ShopID=s.ShopID,
                    OperatedUserName=s.OperatedUserName,
                    CreatedDate=s.CreatedDate,
                    OperatedDate=s.OperatedDate
                } )
                .Take(42);


            if (!String.IsNullOrEmpty(InfoCateID))
            {
                list1 = list1.Where(c => c.InfoCateID == InfoCateID);
            }
            ViewBag.InfoList = list1.ToList();

            if(!string.IsNullOrEmpty(Index2))
            {
                Response.Redirect(string.Format("/home/p/{0}", Index2));
            }

           
            var listOfHelpFunction = db.InfoDetails.Where(c => c.ShopID.Contains(ShpID) && c.InfoCateID.Contains(HELP_FUNCTUON)).OrderByDescending(s => s.CreatedDate)
               .Select(s => new InfoListView
               {
                   InfoID = s.InfoID,
                   UserTraceID = s.UserTraceID,
                   InfoCateID = s.InfoCateID,
                   Title = s.Title,
                   InfoItemTemplateIDs = s.InfoItemTemplateIDs,
                   TitleThumbNail = s.TitleThumbNail,
                   ShowTitleThumbNail = s.ShowTitleThumbNail,
                   SubTitle = s.SubTitle,
                   SeoKeyword = s.SeoKeyword,
                   SeoDescription = s.SeoDescription,
                   VideoUrl = s.VideoUrl,
                   Author = s.Author,
                   IsOriginal = s.IsOriginal,
                   ShopStaffID = s.ShopStaffID,
                   Views = s.Views,
                   ShopID = s.ShopID,
                   OperatedUserName = s.OperatedUserName,
                   CreatedDate = s.CreatedDate,
                   OperatedDate = s.OperatedDate
               })
               .Take(36);
            ViewBag.ListOfHelpFunction = listOfHelpFunction.ToList();

            string viewTemplate; //IndexA 资讯模式 IndexB  服务平台推广模式
            if (shop.IsInfoMode== (int)PublicEnumCode.IsInfoMode.SECURITY)
            {
                var productList = db.Products.Where(c => c.ShopID.Contains(ShpID)).OrderByDescending(s => s.OperatedDate) //展示產品 Show Product
                                              .Select(s => new ProductUnit
                                              {
                                                  ProductID = s.ProductID,
                                                  ProdCateID = s.ProductID,
                                                  ProductName = s.ProductName,
                                                  Title = s.Title,
                                                  ProductImg = s.ProductImg,
                                                  StyleNo = s.StyleNo,
                                                  VideoUrl = s.VideoUrl,
                                                  CategoryIDs = s.CategoryIDs,
                                                  ShopID = s.ShopID,
                                                  SupplierID = s.SupplierID,
                                                  TradePrice = s.TradePrice,
                                                  RetailPrice = s.RetailPrice,
                                                  CommisionRate = s.CommisionRate,
                                                  ViewsIP = s.ViewsIP,
                                                  StaffID = s.StaffID,
                                                  OperatedUserName = s.OperatedUserName,
                                                  OperatedDate = s.OperatedDate,
                                                  CreatedDate = s.CreatedDate,
                                                  SaleStatusID = s.SaleStatusID
                                              })
                                              .Take(18);
                ViewBag.ProductList = productList.ToList();
                viewTemplate = "IndexB";
            }else if(shop.IsInfoMode == (int)PublicEnumCode.IsInfoMode.RADIOENGINEER)
            {
                viewTemplate = "IndexC";
            }
            else if(shop.IsInfoMode == (int)PublicEnumCode.IsInfoMode.INSURANCE)
            {
                viewTemplate = "IndexA";
            }
            else //default
            {
                viewTemplate = "IndexA";
            }

            return View(viewTemplate);  
        }

        /// <summary>
        /// 分享链接的的跳转 BaseController已经定义
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult Trace(string Id)
        {
            UserTrace userTrace = db.UserTraces.Find(Id);
            return RedirectToAction("InfoDetails", "InfoList", new { Id = userTrace.TableKeyID });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Title = "About Us....";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page."; 
            return View();
        }
        public ActionResult p(string ID)
        {
            ShopInitialize();
            // this.InitLanguageStateViewBag();  //作廢
            //Retrive ProductId
            UserTrace userTrace1 = this.ReturnUserTrace(ID);
            string ProductID = userTrace1.TableKeyID;
            WebCookie.RecommUserId = userTrace1.UserId;
            ViewBag.ProductId = userTrace1.TableKeyID;
            ViewBag.CurrentProductId = userTrace1.TableKeyID;
             
            //List Data 
            Product Product1 = db.Products.Find(ProductID);
            ViewBag.vProdDesc = Product1.ProdDesc;
            ViewBag.TradePrice = Product1.TradePrice;

            //Relate Info
            string SOFTWARE_HELPER = InfoCateEnumCode.SOFTWARE_HELPER.ToString();
            string HELP_FUNCTUON = InfoCateEnumCode.HELP_FUNCTUON.ToString();
            var infoDetailList = db.InfoDetails.Where(c => c.ShopID.Contains(WebCookie.ShpID) && !c.InfoCateID.Contains(SOFTWARE_HELPER) && !c.InfoCateID.Contains(HELP_FUNCTUON))
                .Select(s => new InfoListView
                {
                    InfoID = s.InfoID,
                    UserTraceID = s.UserTraceID,
                    InfoCateID = s.InfoCateID,
                    Title = s.Title,
                    InfoItemTemplateIDs = s.InfoItemTemplateIDs,
                    TitleThumbNail = s.TitleThumbNail,
                    ShowTitleThumbNail = s.ShowTitleThumbNail,
                    SubTitle = s.SubTitle,
                    SeoKeyword = s.SeoKeyword,
                    SeoDescription = s.SeoDescription,
                    VideoUrl = s.VideoUrl,
                    Author = s.Author,
                    IsOriginal = s.IsOriginal,
                    ShopStaffID = s.ShopStaffID,
                    Views = s.Views,
                    ShopID = s.ShopID,
                    OperatedUserName = s.OperatedUserName,
                    CreatedDate = s.CreatedDate,
                    OperatedDate = s.OperatedDate
                }).OrderByDescending(S => S.OperatedDate).Take(4).ToList();

            Shop shp = db.Shops.Find(WebCookie.ShpID);
            ViewBag.ClientShop = shp;
            ViewBag.IsInfoMode = shp.IsInfoMode;
            ViewBag.TopView = infoDetailList;

            //Wechat Share 
            ViewBag.appId = weixin.appid;
            ViewBag.timestamp = weixin.timestamp;
            ViewBag.nonceStr = weixin.nonceStr;
            ViewBag.signature = weixin.signature(Request.Url.ToString());

            ViewBag.Title = mvcCommeBase.Substr(Product1.ProductName,40);
            ViewBag.KeyWords = Product1.Title;
            ViewBag.Description = mvcCommeBase.Substr(Regex.Replace(Product1.Title, @"[/n/r]", ""), 40);
            ViewBag.imgUrl = PictureSuffix.ReturnSizePicUrl(WebSiteUrl + Product1.ProductImg, PictureSize.s310X310);

            //ShopStaffID ================== if  StaffID has value then prefer to show.
            // Must show the this user portrait,whatever RecommandUserId is.
            string ShopStaffID = db.ShopStaffs.Where(c => c.UserId == userTrace1.UserId).FirstOrDefault().ShopStaffID; //initialize the value
            
            ViewBag.ShopStaffID = string.IsNullOrEmpty(Product1.StaffID) != true ? Product1.StaffID.Trim() : ShopStaffID;
           
            ViewBag.SourceStatisticsID =this.IPstatiticsAdd(ProductID ,Product1.Title, userTrace1.UserId, Product1.ShopID);

            #region Product Slide
            ViewBag.productImageViews = GetListProductImageViews(ProductID); 
            #endregion 
            return View(Product1);
        }
        public ActionResult AddToCart(string ProductId)
        {
            Product product = new Product();
            product = db.Products.Find(ProductId);
            ViewBag.CurrentProductId = ProductId;
            return View("~/Views/Cart/AddToCart.cshtml", product);
        }
        private List<ProductImageView> GetListProductImageViews(string ProductID)
        {
            List<ProductImageView> productImageViews = new List<ProductImageView>(); 
            var ImageList = db.UploadItems.Where(c=>c.TargetTalbeKeyID == ProductID ).ToList();
            foreach (var item in ImageList)
            {
                ProductImageView imageView = new ProductImageView
                {
                    ProductID = ProductID
                    ,
                    UploadItemId = item.UploadItemId
                    ,
                    ProductImg = db.Products.Find(ProductID).ProductImg
                    ,
                    ProductUploadItemImg = item.Url
                    ,
                    s60X60 = item.Url + PictureSize.s60X60.ToString() + item.FileExt
                    ,
                    s100X100 = item.Url + PictureSize.s100X100.ToString() + item.FileExt
                    ,
                    s160X160 = item.Url + PictureSize.s160X160.ToString() + item.FileExt
                    ,
                    s250X250 = item.Url + PictureSize.s250X250.ToString() + item.FileExt
                    ,
                    s310X310 = item.Url + PictureSize.s310X310.ToString() + item.FileExt
                    ,
                    s350X350 = item.Url + PictureSize.s350X350.ToString() + item.FileExt
                    ,
                    s600X600 = item.Url + PictureSize.s600X600.ToString() + item.FileExt
                };
                productImageViews.Add(imageView);
            } // end foreach
            return  productImageViews;
        } 
        
        [Route("Default")]
        [Authorize]
        public ActionResult ProductTraceUpd(string ProductId, string UserId)
        { 
            //查询当前是否存在
            List<UserTrace> UserTraces = db.UserTraces.Where(c => c.TableKeyID.Contains(ProductId) && c.UserId == UserId).ToList();
            UserTrace UserTrace1 = new UserTrace();
            if (UserTraces.Count() == 0)
            {
                string UserTraceID = db.GetTableIdentityID("Tr", "UserTrace", 6);

                UserTrace1 = new UserTrace()
                {
                    UserTraceID = UserTraceID
                    ,
                    TableKeyID = ProductId
                    ,
                    UserId = UserId
                    ,
                    ShopID = WebCookie.ShopID
                    ,
                    OperatedUserName = User.Identity.Name
                    ,
                    OperatedDate = DateTime.Now
                };
                db.UserTraces.Add(UserTrace1);
                db.SaveChanges();
                return RedirectToAction("wx", new { Id = UserTraceID });
            }
            else
            {
                UserTrace1 = db.UserTraces.Where(c => c.TableKeyID.Contains(ProductId) && c.UserId == UserId).FirstOrDefault();
                return RedirectToAction("wx", new { Id = UserTrace1.TableKeyID });
            }

        }

        [HttpPost]
        public ActionResult DispatchNoteView(string ProductId, [Bind(Include = "DispatchNoteId,OrderID,Quantity,RecommUserId,StyleNo,ShopID,CreatedDate,Country,State,Recipient,PhoneNumber,Address,Remarks,ShopID")]DispatchNote DispatchNote1)
        {
            AdditionalForUpload AdditionalForUpload1 = new AdditionalForUpload();
            ModalDialogView ModalDialogView1 = new ModalDialogView
            {
                MsgCode = "1",
                Message = Lang.DispatchNoteView_thankForBuy
            }; 

            DispatchNote1.DispatchNoteId = db.GetTableIdentityID("D", "DispatchNote", 8); 
            DispatchNote1.ShopID = WebCookie.ShopID; 
            db.DispatchNotes.Add(DispatchNote1);
            db.SaveChanges(); 
            return Json(ModalDialogView1); 
        }

        public ActionResult AttIndex()
        { 
            return View();
        }

        public ActionResult ServiceFlow()
        {
            ShopInitialize();
            // this.InitLanguageStateViewBag();  //作廢
            return View();
        }
         
    }
}