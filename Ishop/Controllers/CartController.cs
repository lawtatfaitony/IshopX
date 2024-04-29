using Ishop.Context;
using Ishop.Models.ProductMgr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Ishop.Areas.Mgr.Models;
using System.Data.Entity;
using Ishop.ViewModes.Order;
using LanguageResource;
using System.Threading;

namespace Ishop.Controllers
{
    public class CartController : BaseController
    {
        public CartController() : base()
        {
        }
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 内部函数 加入购物车 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult AddToCart(string Id, int Quantity)
        {
            string ProductSkuId = Id;

            Cart cart = new Cart();
            cart.CartId = WebCookie.CartId;
            IsAuthenticatedChangeCartId();

            if (Quantity < 0)
            {
                return Json("{Result:Quantity Unexpected }");
            }
            else
            {
                cart.Quantity = Quantity;
            }

            Cart CartProductSku1 = db.Carts.Where(c => c.CartId == cart.CartId && c.ProductSkuId == ProductSkuId).FirstOrDefault();

            if (CartProductSku1 != null)
            {
                UpdateModel<Cart>(CartProductSku1);
                CartProductSku1.Quantity = CartProductSku1.Quantity + Quantity;
                db.Entry(CartProductSku1).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                ProductSku ProductSku1 = db.ProductSkus.Find(ProductSkuId);
                cart.ProductSkuId = ProductSku1.ProductSkuId;
                cart.SkuImageUrl = ProductSku1.SkuImage;
                cart.ProductName = ProductSku1.ProductName;
                cart.PropertyDesc = ProductSku1.PropertyDesc;
                cart.TradePrice = ProductSku1.TradePrice;
                cart.OperatedDate = DateTime.Now;
                cart.CreatedDate = DateTime.Now;
                db.Carts.Add(cart);
                db.SaveChanges();
            }
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            ModalDialogView1.MsgCode = "1";
            ModalDialogView1.Message = "OK";
            return Json(ModalDialogView1);
        }
        public JsonResult GetProductSkuIdInStock(string ValsId)
        {
            ProductSku ProductSku1 = new ProductSku();

            ProductSku1 = db.ProductSkus.Where(c => c.PropValueIDs == ValsId).FirstOrDefault(); 
            if(ProductSku1!=null)
            {
                return Json(ProductSku1);
            }
            return Json("{'ProductSkuId': '0'}");
        }

        /// <summary>
        /// Add To Cart
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddToCart(string ProductId)
        {
            ShopInitialize();
            // this.InitLanguageStateViewBag();  //作廢 2024-4-29
            Product product = new Product();
            product = db.Products.Find(ProductId);
            ViewBag.CurrentProductId = ProductId;
            return View(product);
        }

        /// <summary>
        /// 加入购物车 AddToCart 
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="GotoPay">如果 GotoPay = 1 则直接进入支付页面 </param>
        /// <param name="productSkuQry"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddToCart(string ProductId, string GotoPay, [Bind(Include = "txtProductSkuId ,txtQuantity")] ProductSkuQuantity productSkuQuantity)
        {
            //Thread.Sleep(5000); //for test
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            ModalDialogView1.MsgCode = "-1";
            ModalDialogView1.Message = Lang.Views_GeneralUI_NoStock;
            ProductSku productSku = db.ProductSkus.Find(productSkuQuantity.txtProductSkuId.Trim());
            if (productSku == null)
            {
                return Json(ModalDialogView1);
            }

            JsonResult jsonResult = AddToCart(productSkuQuantity.txtProductSkuId, int.Parse(productSkuQuantity.txtQuantity));

            //如果 GotoPay =1 则 进入付款模式  
            if (int.Parse(GotoPay) == 1)
            {
                return RedirectToAction("myShoppingCart", "Cart");
            }
            return jsonResult;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult MyShoppingCart()
        {
            ShopInitialize();
            // this.InitLanguageStateViewBag();  //作廢 2024-4-29

            IsAuthenticatedChangeCartId();

            DateTime dt = DateTime.Now.AddDays(-30);
            ViewBag.CartList = db.Carts.Where(c => c.CartId == WebCookie.CartId && c.OperatedDate > dt).ToList();
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult SubmitCartItem(List<string> selectedSkuIDs)
        {
            string CartId = WebCookie.CartId;
            var ListAllSku = db.Carts.Where(c => c.CartId == CartId).ToList();
            List<Cart> ListSelected = new List<Cart>();
            foreach (string item in selectedSkuIDs)
            {
                Cart cart = ListAllSku.Where(c => c.ProductSkuId == item).FirstOrDefault();
                ListSelected.Add(cart);
            }
            List<Cart> NotSelectedList = new List<Cart>();
            NotSelectedList = ListAllSku;

            foreach (Cart item in ListSelected)
            {
                NotSelectedList.Remove(item);
            }
            return Json(NotSelectedList);
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetCartItem()
        {
            string CartId = WebCookie.CartId;
            var ListAllSku = db.Carts.Where(c => c.CartId == CartId).ToList();
            List<Cart> ListSelected = new List<Cart>();

            foreach (Cart item in ListAllSku)
            {
                ListSelected.Add(item);
            }
            return Json(ListSelected, JsonRequestBehavior.AllowGet);
        }

        public void IsAuthenticatedChangeCartId()
        {
            if (Request.IsAuthenticated)
            {
                string UserId = User.Identity.GetUserId();
                var CartItems = db.Carts.Where(c => c.CartId == WebCookie.CartId);
                foreach (var Cart in CartItems)
                {
                    Cart.CartId = UserId;
                }
                db.SaveChanges();

                WebCookie.CartId = UserId;
            }
        }
         

        /// <summary>
        /// for  JS (ShoppingCart)
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpGet] 
        public JsonResult GetProductAllInfo(string ProductId)
        {
            GetProductAllInfo getProductAllInfo = new GetProductAllInfo();
            getProductAllInfo.product = db.Products.Find(ProductId);
            getProductAllInfo.product.ProdDesc = string.Empty;
            List<ProductSku> skulist = db.ProductSkus.Where(c=>c.ProductID == ProductId ).ToList();
             
            getProductAllInfo.productSkulist = skulist;

            return Json(getProductAllInfo, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// for AddToCart.cshtml
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public List<ProdPropertiesName> GetPropName(string ProductId)
        {
            string ProdCateId = db.Products.Where(c=>c.ProductID == ProductId).First().ProdCateID;
            var ProductPropName = db.ProdPropertiesNames.Where(c => c.ProdCateID == ProdCateId && c.IsForTrading ==1 ).ToList();
            return ProductPropName;
        }
        /// <summary>
        ///  for AddToCart.cshtml
        /// </summary>
        /// <param name="prodPropertiesName"></param>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public List<ProdPropertiesValue> GetPropValue(ProdPropertiesName prodPropertiesName , string ProductId)
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
                    if (productSku1!=null)
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
        
    }
   
}