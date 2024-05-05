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
using Ishop.DAL;
using LanguageResource;
using Org.BouncyCastle.Asn1.X509;

namespace Ishop.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        // GET: Order
        [HttpGet]
        public ActionResult Index(string list)
        {
            this.ShopInitialize();

            if (!string.IsNullOrEmpty(list))
            {
                Order order = new Order();
                string[] a = list.TrimEnd('|').Split('|');
                var myCart = db.Carts.Where(c => c.CartId == WebCookie.CartId).ToList();
                List<Cart> myCartSelect = new List<Cart>();
                foreach (string j in a)
                {
                    myCartSelect.Add((Cart)myCart.Where(c => c.ProductSkuId.Contains(j)).FirstOrDefault());
                }
                //1.
                string PrefixOrderID = "1" + string.Format("{0:MMdd}", DateTime.Now);
                order.OrderId = int.Parse(db.GetTableIdentityID(PrefixOrderID, "Order", 5));
                order.UserId = User.Identity.GetUserId();
                order.UserName = User.Identity.GetUserName();
                order.TotalRetailPrice = myCartSelect.Sum(c => c.RetailPrice * c.Quantity);

                order.AdjustFee = 0; // reserved
                order.DiscountFee = 0; // reserved
                order.Payment = myCartSelect.Sum(c => c.TradePrice * c.Quantity);
                ViewBag.TradePrice = order.Payment;
                order.CampaignID = string.Empty; // reserved
                order.CampaignName = string.Empty; // reserved
                order.CouponID = string.Empty; // reserved
                order.FaceValue = 0;            // reserved
                order.PaymentNo = string.Empty; // reserved
                order.PayGateName = string.Empty; // reserved
                order.RecommUserId = WebCookie.RecommUserId;
                order.CreatedDate = DateTime.Now;
                order.ShopID = WebCookie.ShpID;  // Notice:Can not Cross over shop to Buy! 
                order.StatusId = "Unpaid";
                order.TotalCommision = 0;
                db.Orders.Add(order);

                int CommissionLogic = 0;
                if (!string.IsNullOrEmpty(order.RecommUserId)) // if no recommend user ,order TotalCommision is zero
                {
                    CommissionLogic = 1;
                }
                //2.
                List<OrderItem> orderItems = new List<OrderItem>();
                int i = 1;
                foreach (Cart item in myCartSelect)
                {
                    OrderItem orderItem = new OrderItem();

                    //1、get ProductDetails
                    string ProductId = db.ProductSkus.Find(item.ProductSkuId).ProductID;
                    Product product = db.Products.Find(ProductId);

                    orderItem.OrderItemId = order.OrderId.ToString() + i.ToString();
                    orderItem.OrderId = order.OrderId;
                    orderItem.CartId = item.CartId;
                    orderItem.ProductSkuId = item.ProductSkuId;
                    orderItem.SkuImageUrl = item.SkuImageUrl;
                    orderItem.ProductName = item.ProductName;
                    orderItem.PropertyDesc = item.PropertyDesc;
                    orderItem.TradePrice = item.TradePrice;
                    orderItem.Quantity = item.Quantity;
                    orderItem.RetailPrice = item.RetailPrice * item.Quantity;
                    orderItem.ItemAmount = item.TradePrice * item.Quantity;
                    //2、get Rate
                    decimal ProductCommissionRate = product.CommisionRate;
                    orderItem.CommisionRate = ProductCommissionRate;
                    orderItem.Commision = orderItem.TradePrice * orderItem.CommisionRate;

                    if (orderItem.Commision > 0)
                    {
                        orderItem.Commision = (orderItem.Commision / 100) * orderItem.Quantity * CommissionLogic;
                    }
                    order.TotalCommision += orderItem.Commision;
                    order.TotalCommision = order.TotalCommision * CommissionLogic;

                    orderItem.CreatedDate = DateTime.Now;
                    db.OrderItems.Add(orderItem);
                    i++;
                }
                int result = db.SaveChanges();

                if (result > 0)
                {
                    db.Carts.RemoveRange(myCartSelect);
                    db.SaveChanges();
                }

                //order
                OrderDetailView orderDetailView =
                    new OrderDetailView
                    {
                        OrderId = order.OrderId
                        ,
                        Payment = order.Payment
                        ,
                        Country = ""
                        ,
                        OrderItems = db.OrderItems.Where(c => c.OrderId == order.OrderId).ToList()
                    };
                ViewBag.CurrentOrderId = order.OrderId;
                ViewBag.OrderItems = orderDetailView.OrderItems;
                return View(orderDetailView);
            }
            else
            {
                var currentOrder = db.Orders.OrderByDescending(c=>c.CreatedDate).FirstOrDefault();
                if (currentOrder!=null)
                {
                    //order
                    OrderDetailView orderDetailView =
                        new OrderDetailView
                        {
                            OrderId = currentOrder.OrderId
                            ,
                            Payment = currentOrder.Payment
                            ,
                            Country = ""
                            ,
                            OrderItems = db.OrderItems.Where(c => c.OrderId == currentOrder.OrderId).ToList()
                        };
                    ViewBag.CurrentOrderId = currentOrder.OrderId;
                    ViewBag.OrderItems = orderDetailView.OrderItems;
                    return View(orderDetailView);
                }
                else
                {
                    return View("MyNoOrderTips");
                }
                
            }

           
        

           
        }
        [HttpPost]
        public ActionResult Index( int CurrentOrderId , [Bind(Include = "OrderID,Payment,Country,State,Recipient,PhoneNumber,Address")]DispatchNote DispatchNote1)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();

            int OrderId = int.Parse(DispatchNote1.OrderID);

            DispatchNote1.DispatchNoteId = db.GetTableIdentityID("D", "DispatchNote", 8);
            DispatchNote1.Quantity = db.OrderItems.Where(c => c.OrderId == OrderId).Sum(s => s.Quantity);
            DispatchNote1.RecommUserId = WebCookie.RecommUserId;
            DispatchNote1.ShopID = WebCookie.ShopID;
            DispatchNote1.CreatedDate = DateTime.Now;
            try
            {
                db.DispatchNotes.Add(DispatchNote1);
                db.SaveChanges();
                ModalDialogView1.MsgCode = "1";
                ModalDialogView1.Message = Lang.Order_Index_ReturnMessage; // "收貨地址成功錄入";
            }
            catch(Exception e )
            {
                throw e;
            } 
            return Json(ModalDialogView1);
        }
        public List<Cart> GetCartItem()
        {
            string CartId = WebCookie.CartId;
            var GetListCartItem = db.Carts.Where(c => c.CartId == CartId).ToList();  
            return GetListCartItem;
        } 
    }
}