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
using Microsoft.VisualBasic.ApplicationServices;
using System.Data.Entity.Migrations;
using System.Xml.Linq;

namespace Ishop.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        // GET: Order
        [HttpGet]
        public ActionResult Index(string list,string orderId)
        {
            this.ShopInitialize();

            //初始發貨地址
            var theLastDispatchNote = new DispatchNote
            {
                OrderID = "",
                Country = "",
                State = "",
                District = "",
                Recipient = "",
                Address = "",
                PhoneNumber = "", 
                TelePhoneNumber = "" 
            };
            string userId = User.Identity.GetUserId();

            var theLastOrder = db.Orders.Where(c => c.UserId.Contains(userId))
                                        .OrderByDescending(c=>c.CreatedDate).FirstOrDefault();

            //1 獲取上一筆發貨單的地址以用於當前發貨單
            //2 Check 是否有購買過
            if (theLastOrder != null)
            {
                var orderDispatchNote = db.DispatchNotes.Where(c => c.OrderID.Contains(theLastOrder.OrderId.ToString())).FirstOrDefault();
                if (orderDispatchNote != null)
                {
                    theLastDispatchNote = orderDispatchNote;
                }
            }

            //------------------------------------------------------------------
            if (!string.IsNullOrEmpty(list))
            {
                string[] sku_array = list.TrimEnd('|').Split('|');

                Order order = new Order();
               
                var myCart = db.Carts.Where(c => c.CartId == WebCookie.CartId).ToList();

                List<Cart> myCartSelect = new List<Cart>();

                if (myCart.Count() != 0)
                {
                    foreach (string j in sku_array)
                    {
                        myCartSelect.Add((Cart)myCart.Where(c => c.ProductSkuId.Contains(j)).FirstOrDefault());
                    }

                    if (myCartSelect.Count() == 0) //沒有成功添加到所選列表則返回(可能性很少)
                    {
                        return View("MyCartSelectToOrdererrorTips ");  //System Logic Error !!! Handle my cart selection product transfering to order failure!
                    }
                      
                    //訂單以1開頭月日跟隨 作為前綴
                    string PrefixOrderID = string.Format("1{0:MMdd}", DateTime.Now); // "1" + string.Format("{0:MMdd}", DateTime.Now);
                    order.OrderId = int.Parse(db.GetTableIdentityID(PrefixOrderID, "Order", 5));
                    order.UserId = userId;
                    order.UserName = User.Identity.GetUserName();
                    order.TotalRetailPrice = myCartSelect.Sum(c => c.RetailPrice * c.Quantity);
                    order.Payment = myCartSelect.Sum(c => c.TradePrice * c.Quantity);
                    order.AdjustFee = 0; // reserved
                    order.DiscountFee = 0; // reserved 
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
                        ProductSku productSku = db.ProductSkus.Find(item.ProductSkuId);

                        if (productSku == null) //沒有對應的SKU 則提示錯誤
                        {
                            string messageForNoProductIDFormSkuID = $"{Lang.ProductSku_Title} Product SKU ID {item.ProductSkuId} does not have a corresponding product ID";
                            return View("MyCartTransferSkuErrorTips", "_Layout", messageForNoProductIDFormSkuID);  //System Logic Error !!!ProductSkuId does not have a corresponding product ID!
                        }

                        Product product = db.Products.Find(productSku.ProductID);

                        orderItem.OrderItemId = order.OrderId.ToString() + i.ToString();
                        orderItem.OrderId = order.OrderId;
                        orderItem.CartId = item.CartId;
                        orderItem.ProductSkuId = item.ProductSkuId;
                        orderItem.SkuImageUrl = item.SkuImageUrl;
                        orderItem.ProductName = item.ProductName;
                        orderItem.PropertyDesc = item.PropertyDesc;
                        orderItem.TradePrice = item.TradePrice;
                        orderItem.Quantity = item.Quantity;
                        orderItem.RetailPrice = item.RetailPrice;
                        orderItem.ItemAmount = item.TradePrice * item.Quantity;
                        orderItem.SkuImageUrl = productSku.SkuImage ?? string.Empty;
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
                            Country = theLastDispatchNote.Country 
                            ,
                            State = theLastDispatchNote.State
                            ,
                            District = theLastDispatchNote.District
                            ,
                            Recipient = theLastDispatchNote.Recipient 
                            ,
                            Address = theLastDispatchNote.Address
                            ,
                            PhoneNumber = theLastDispatchNote.PhoneNumber 
                            ,
                            TelePhoneNumber = theLastDispatchNote.TelePhoneNumber 
                            ,
                            StatusId = theLastOrder.StatusId
                            ,
                            OrderItems = db.OrderItems.Where(c => c.OrderId == order.OrderId).ToList()
                            ,
                            CreatedDate = theLastOrder.CreatedDate
                        };
                    ViewBag.CurrentOrderId = order.OrderId;
                    ViewBag.OrderItems = orderDetailView.OrderItems;

                    return View(orderDetailView);
                }
                else
                {
                    return View("MyNoOrderTips");  //There are no items in your shopping cart !!!
                }  
            }
            else
            {  
                //如果傳入訂單ID,則查詢指定的訂單ID,並返回對應訂單和物流單的相關信息
                if(!string.IsNullOrEmpty(orderId))
                {
                    int iOrderId;

                    if (int.TryParse(orderId,out iOrderId))
                    {
                        var thisOrder = db.Orders.Where(c => c.OrderId == iOrderId)
                                        .OrderByDescending(c => c.CreatedDate).FirstOrDefault();

                        //並返回對應訂單和物流單的相關信息
                        if (thisOrder != null)
                        {
                            var thisDispatchNote = db.DispatchNotes.Where(c => c.OrderID.Contains(thisOrder.OrderId.ToString())).FirstOrDefault();

                            //確保用戶有填入對應地址才會生成物流單的
                            if(thisDispatchNote != null)
                            {
                                theLastDispatchNote = thisDispatchNote;
                            }
                        } 
                    }
                }
                if (theLastOrder != null)
                {
                    //order
                    OrderDetailView orderDetailView = new OrderDetailView
                        {
                            OrderId = theLastOrder.OrderId
                            ,
                            Payment = theLastOrder.Payment
                            ,
                            Country = theLastDispatchNote.Country
                            ,
                            State = theLastDispatchNote.State
                            ,
                            District = theLastDispatchNote.District
                            ,
                            Recipient = theLastDispatchNote.Recipient 
                            ,
                            Address = theLastDispatchNote.Address 
                            ,
                            PhoneNumber = theLastDispatchNote.PhoneNumber
                            ,
                            TelePhoneNumber = theLastDispatchNote.TelePhoneNumber
                            ,
                            StatusId = theLastOrder.StatusId
                            ,
                            OrderItems = db.OrderItems.Where(c => c.OrderId == theLastOrder.OrderId).ToList()
                            ,
                            CreatedDate = theLastOrder.CreatedDate
                        };
                    ViewBag.CurrentOrderId = theLastOrder.OrderId;
                    ViewBag.OrderItems = orderDetailView.OrderItems;
                    return View(orderDetailView);
                }
                else
                {
                    return View("MyNoOrderTips"); //There are no items in your shopping cart !!!
                }
            }
        }

        /// <summary>
        /// GET: OrderList 訂單列表 最近 100條記錄
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OrderList(int listCount =100)
        {
            this.ShopInitialize();
              
            string userId = User.Identity.GetUserId();
            var orderList = db.Orders.Where(c => c.UserId.Contains(userId)).OrderByDescending(c => c.CreatedDate).Take(listCount).ToList();

            if (orderList.Count() == 0)
            {
                return View("MyOrderListEmpty"); 
            }

            List<OrderDetailView> orderListView = new List<OrderDetailView>();
            
            foreach(var item in orderList)
            {
                var dispatchNote = db.DispatchNotes.Where(c => c.OrderID == item.OrderId.ToString()).OrderByDescending(c => c.CreatedDate).FirstOrDefault();
                //order
                OrderDetailView orderDetailView = new OrderDetailView()
                    {
                        OrderId = item.OrderId,
                        Payment = item.Payment,
                        Country = dispatchNote?.Country ?? string.Empty,
                        StatusId = item.StatusId,
                        Recipient = dispatchNote?.Recipient ?? string.Empty,
                        Address = dispatchNote?.Address ?? string.Empty,
                        PhoneNumber = dispatchNote?.PhoneNumber ?? string.Empty,
                        TelePhoneNumber = dispatchNote?.TelePhoneNumber ?? string.Empty,
                        District = dispatchNote?.District,
                        State = dispatchNote?.State ?? string.Empty,

                        OrderItems = db.OrderItems.Where(c => c.OrderId == item.OrderId).ToList(),

                        CouponID = item.CouponID,
                        //Coupons = item.CouponID
                        PostCode = dispatchNote?.District,
                        
                        CreatedDate = item.CreatedDate
                };
                orderListView.Add(orderDetailView);
            }
            if(orderListView.Count == 0) //no record
            {
                return View("MyOrderListEmpty");
            }

            return View(orderListView);
        }

        /// <summary>
        /// 目標: 錄入購物流程中,填入的收貨地址 或者 更新最近的訂單收貨信息
        /// </summary>
        /// <param name="CurrentOrderId"></param>
        /// <param name="dispatchNote1"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index( int CurrentOrderId , [Bind(Include = "OrderID,Payment,Country,State,Recipient,TelePhoneNumber,PhoneNumber,Address")]DispatchNote dispatchNote1)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
             
            if(!int.TryParse(dispatchNote1.OrderID,out CurrentOrderId))
            {
                ModalDialogView1 = new ModalDialogView
                {
                    MsgCode = "0",
                    Message = Lang.Order_Return_Wrong_OrderId
                };
                return Json(ModalDialogView1);
            }
             
            var currentOrder = db.Orders.Where(c => c.OrderId == CurrentOrderId).OrderByDescending(c => c.CreatedDate).FirstOrDefault();
            if (currentOrder==null)
            {
                ModalDialogView1 = new ModalDialogView
                {
                    MsgCode = "0",
                    Message = Lang.Order_Return_Wrong_OrderId
                };
                return Json(ModalDialogView1);
            }
            var existDispatchNote = db.DispatchNotes.Where(c => c.OrderID == currentOrder.OrderId.ToString()).OrderByDescending(c => c.CreatedDate).FirstOrDefault();
            if(existDispatchNote==null)
            {
                dispatchNote1.DispatchNoteId = db.GetTableIdentityID("D", "DispatchNote", 8);
                dispatchNote1.Quantity = db.OrderItems.Where(c => c.OrderId == CurrentOrderId).Sum(s => s.Quantity);
                dispatchNote1.RecommUserId = currentOrder.RecommUserId;
                dispatchNote1.ShopID = currentOrder.ShopID;
                dispatchNote1.CreatedDate = DateTime.Now;
                try
                {
                    db.DispatchNotes.Add(dispatchNote1);
                    db.SaveChanges();
                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message = Lang.Order_Index_ReturnMessage; // "收貨地址成功錄入";
                }
                catch (Exception e)
                {
                    throw e;
                }
                return Json(ModalDialogView1);
            }
            else
            {
                try
                {
                    existDispatchNote.Country = dispatchNote1.Country;
                    existDispatchNote.State = dispatchNote1.State;
                    existDispatchNote.Recipient = dispatchNote1.Recipient;
                    existDispatchNote.PhoneNumber = dispatchNote1.PhoneNumber;
                    existDispatchNote.Address = dispatchNote1.Address;
                     
                    db.DispatchNotes.AddOrUpdate(existDispatchNote);
                    db.SaveChanges();
                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message = Lang.Order_Index_ReturnMessage; // "收貨地址成功錄入";
                }
                catch (Exception e)
                {
                    throw e;
                }
                return Json(ModalDialogView1);
            } 
        }
        public List<Cart> GetCartItem()
        {
            string CartId = WebCookie.CartId;
            var GetListCartItem = db.Carts.Where(c => c.CartId == CartId).ToList();  
            return GetListCartItem;
        } 
    }
}