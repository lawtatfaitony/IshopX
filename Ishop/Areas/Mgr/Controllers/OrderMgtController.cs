using Ishop.AppCode.Utilities;
using Ishop.Areas.Mgr.Models;
using Ishop.Context;
using Ishop.Controllers;
using Ishop.Models.CampaignMgr;
using Ishop.Models.ProductMgr;
using Ishop.Models.UploadItem;
using Ishop.Utilities;
using Ishop.ViewModes.Order;
using LanguageResource;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Ishop.Areas.Mgr.Controllers
{
   
    public class OrderMgtController : BaseController
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();

        [Authorize(Roles = "Supervisor,Admins,StoreAdmin,StoreProductAdmin,CustomerService,StorePreSales")]
        [HttpGet]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, string StartDate, string EndDate, int? page)
        {
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

            var orders = from s in db.Orders
                           select s;
            

            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s => s.OrderId.ToString().Contains(searchString) 
                                        || s.CampaignName.Contains(searchString) 
                                        || s.UserName.Contains(searchString)
                                        || s.UserId.Contains(searchString)
                                        || s.StatusId.Contains(searchString)
                                        || s.RecommUserId.Contains(searchString)
                                        || s.PaymentNo.Contains(searchString));
            } 

            //DaySpan filter  
            if (StartDate != EndDate)
            {
                ViewBag.CurrentStartDate = StartDate;
                ViewBag.CurrentEndDate = EndDate;

                DateTime pStartDate = DateTime.Parse(StartDate);
                DateTime pEndDate = DateTime.Parse(EndDate);
                orders = orders.Where(s => s.CreatedDate > pStartDate && s.CreatedDate < pEndDate);
            }
            //shop filter
            orders = orders.Where(s => s.ShopID == WebCookie.ShopID);

            switch (sortOrder)
            {
                case "Date":
                    orders = orders.OrderBy(s => s.CreatedDate);
                    break;
                case "date_desc":
                    orders = orders.OrderByDescending(s => s.CreatedDate);
                    break;
                default:  // Name ascending 
                    orders = orders.OrderByDescending(s => s.CreatedDate);
                    break;
            }
            int pageSize = 50;
            int pageNumber = (page ?? 1);
            return View(orders.ToPagedList(pageNumber, pageSize));
        }


        [Authorize(Roles = "Supervisor,Admins,StoreAdmin,StoreProductAdmin,CustomerService,StorePreSales")]
        [HttpGet]
        public ActionResult OrderDetails(string orderId)
        {
            this.BackEndShopInitialize();

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

            int iOrderId = int.Parse(orderId);

            var theOrder = db.Orders.Where(c =>c.OrderId == iOrderId).FirstOrDefault();
 
            if (theOrder != null)
            {
                var orderDispatchNote = db.DispatchNotes.Where(c => c.OrderID.Contains(theOrder.OrderId.ToString())).FirstOrDefault();
                if (orderDispatchNote != null)
                {
                    theLastDispatchNote = orderDispatchNote;
                }
            }
            else
            {
                return View("MyNoOrderTips");  
            }

            Coupon myCoupon = new Coupon();
            if (!string.IsNullOrEmpty(theOrder.CouponID))
            {
                myCoupon = db.Coupons.Where(c => c.CouponID.Contains(theOrder.CouponID)).FirstOrDefault(); 
            }
            Shop shop = db.Shops.Where(c => c.ShopID.Contains(theOrder.ShopID)).FirstOrDefault();
            List<OrderItem> orderItems = db.OrderItems.Where(c => c.OrderId == theOrder.OrderId).ToList();
            //order
            OrderDetails orderDetails = new OrderDetails
            {
                Shop = shop,
                OrderHeader = theOrder,
                Quantity = orderItems.Sum(c => c.Quantity),
                DispatchNote = theLastDispatchNote,
                Coupon = myCoupon,
                OrderItems = orderItems
            };  
            return View(orderDetails);


        }

        [Authorize(Roles = "Supervisor,Admins,StoreAdmin,StoreProductAdmin,CustomerService,StorePreSales")]
        [HttpPost]
        public ActionResult UpdateDispatchNote(FormCollection form)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();

            int CurrentOrderId = 0;

            int quantity = 0;
            bool bQuantity = int.TryParse(form["Quantity"].ToString(), out quantity);
             
            DispatchNote dispatchNote1 = new DispatchNote
            { 
                OrderID = form["OrderHeader.OrderId"], 
                Country = form["DispatchNote.Country"],
                State = form["DispatchNote.State"],
                District = form["DispatchNote.District"],
                Recipient = form["DispatchNote.Recipient"],
                PhoneNumber = form["DispatchNote.PhoneNumber"],
                TelePhoneNumber = form["DispatchNote.TelePhoneNumber"],
                Address = form["DispatchNote.Address"],
                CreatedDate = DateTime.Now,
                DispatchNoteId = form["DispatchNote.DispatchNoteId"],
                DispatchNoteStatus = DispatchNoteStatus.Unpaid,
                PaymentNo = form["DispatchNote.PaymentNo"] ?? string.Empty,
                ShopID = form["OrderHeader.ShopID"],
                Quantity = quantity,
                PostCode = form["DispatchNote.PostCode"],
                StatusName = form["DispatchNote.StatusName"] ?? string.Empty,
                StyleNo = form["DispatchNote.StyleNo"] ?? string.Empty,
                Remarks = form["DispatchNote.Remarks"]??string.Empty,

            };
             

            if (!int.TryParse(dispatchNote1.OrderID, out CurrentOrderId))
            {
                ModalDialogView1 = new ModalDialogView
                {
                    MsgCode = "0",
                    Message = Lang.Order_Return_Wrong_OrderId
                };
                return Json(ModalDialogView1);
            }

            var currentOrder = db.Orders.Where(c => c.OrderId == CurrentOrderId).OrderByDescending(c => c.CreatedDate).FirstOrDefault();
            if (currentOrder == null)
            {
                ModalDialogView1 = new ModalDialogView
                {
                    MsgCode = "0",
                    Message = Lang.Order_Return_Wrong_OrderId
                };
                return Json(ModalDialogView1);
            }
            var existDispatchNote = db.DispatchNotes.Where(c => c.OrderID == currentOrder.OrderId.ToString()).OrderByDescending(c => c.CreatedDate).FirstOrDefault();
           
            if (existDispatchNote == null)
            {  
                dispatchNote1.DispatchNoteId = db.GetTableIdentityID("D", "DispatchNote", 8);
                dispatchNote1.Quantity = db.OrderItems.Where(c => c.OrderId == CurrentOrderId).Sum(s => s.Quantity);
                dispatchNote1.RecommUserId = currentOrder.RecommUserId;
                dispatchNote1.ShopID = currentOrder.ShopID;
                DispatchNoteStatus status;
                if (Enum.TryParse(currentOrder.StatusId, out status))
                {
                    dispatchNote1.DispatchNoteStatus = status;
                }
                else
                {
                    // 處理解析失敗的情況
                    dispatchNote1.DispatchNoteStatus = DispatchNoteStatus.Unpaid;
                }  
                dispatchNote1.CreatedDate = DateTime.Now;
                dispatchNote1.RecommUserId = currentOrder.RecommUserId;
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
                    existDispatchNote.District = dispatchNote1.District;

                    existDispatchNote.Recipient = dispatchNote1.Recipient;
                    existDispatchNote.TelePhoneNumber = dispatchNote1.TelePhoneNumber;
                    existDispatchNote.PhoneNumber = dispatchNote1.PhoneNumber;
                    existDispatchNote.Address = dispatchNote1.Address;

                    DispatchNoteStatus status;
                    if (Enum.TryParse(currentOrder.StatusId, out status))
                    {
                        existDispatchNote.DispatchNoteStatus = status;
                    }
                    else
                    {
                        // 處理解析失敗的情況
                        existDispatchNote.DispatchNoteStatus = DispatchNoteStatus.Unpaid;
                    }
                    existDispatchNote.RecommUserId = currentOrder.RecommUserId;
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
    }
}