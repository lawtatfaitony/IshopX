﻿using Ishop.Context;
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
using System.Data.Entity.Migrations;

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
            ModalDialogView ModalDialogView1 = new ModalDialogView();
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


                if (ProductSku1 == null) //沒有對應的SKU 則提示錯誤
                {
                    string messageForNoProductIDFormSkuID = $"{Lang.ProductSku_Title} Product SKU ID {ProductSku1.ProductSkuId} does not have a corresponding product ID";
                    ModalDialogView1 = new ModalDialogView();
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message = messageForNoProductIDFormSkuID;
                    return Json(ModalDialogView1);
                    
                }

                Product product = db.Products.Find(ProductSku1.ProductID);

                cart.ProductSkuId = ProductSku1.ProductSkuId;
                cart.SkuImageUrl = ProductSku1.SkuImage;
                cart.ProductName = ProductSku1.ProductName;
                cart.PropertyDesc = ProductSku1.PropertyDesc;
                cart.TradePrice = ProductSku1.TradePrice;
                cart.RetailPrice = product.RetailPrice;
                cart.OperatedDate = DateTime.Now;
                cart.CreatedDate = DateTime.Now;
                db.Carts.Add(cart);
                db.SaveChanges();
            }
           
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

            Product product = new Product();
            product = db.Products.Find(ProductId);
            ViewBag.CurrentProductId = ProductId;
            return View(product);
        }

        /// <summary>
        /// 檢查是否只有一個SKU的情況
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>{"ProductSkuId":"P0000210132","ProductSkuCount":1,"SkuMessage":"Only One SKU"}</returns>
        [AllowAnonymous]
        [HttpGet]
        public JsonResult CheckOnlyOneSkuForCart(string productId)
        { 
            int count = db.Products.Where(s => s.ProductID == productId).Count();
            if (count>0)
            {
                int ProductSkuCount = db.ProductSkus.Where(c => c.ProductID == productId).Count();

                if (ProductSkuCount == 1)
                {
                    var ProductSku = db.ProductSkus.Where(c => c.ProductID == productId).FirstOrDefault();

                    var checkSkuReturn = new { ProductSkuId = ProductSku.ProductSkuId, ProductSkuCount = ProductSkuCount , SkuTradePrice = ProductSku.TradePrice, SkuMessage = "Only One SKU" };
                    return Json(checkSkuReturn, JsonRequestBehavior.AllowGet);
                } 
            }

            var checkSkuReturn2 = new { ProductSkuId = "", ProductSkuCount = 0, SkuMessage = "NO Any SKU, Backend No Setting" };
            return Json(checkSkuReturn2, JsonRequestBehavior.AllowGet);
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
           
            IsAuthenticatedChangeCartId();

            DateTime dt = DateTime.Now.AddDays(-360);
            ViewBag.CartList = db.Carts.Where(c => c.CartId == WebCookie.CartId && c.OperatedDate > dt).ToList();
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult SubmitCartItem(List<string> selectedSkuIDs)
        {
            string CartId = WebCookie.CartId;
            var ListAllSku = db.Carts.Where(c => c.CartId == CartId).ToList();

            //selected Item
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

            //Remove From Cart
            foreach (Cart item in NotSelectedList)
            { 
                db.Carts.Remove(item);
            }
            db.SaveChanges(); 

            return Json(NotSelectedList,JsonRequestBehavior.AllowGet);
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
                    //db.Carts.AddOrUpdate(Cart); 
                }
                int result  = db.SaveChanges();
                if(result > 0)
                {
                    WebCookie.CartId = UserId;
                } 
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