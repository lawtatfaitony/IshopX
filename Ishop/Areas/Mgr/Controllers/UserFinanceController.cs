using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using Ishop.Utilities;
using Ishop.Context;
using Ishop.AppCode.Utilities;
using Ishop.Areas.Mgr.Models;
using Ishop.Models.Info;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using Ishop.ViewModes.Public;
using Ishop.Models.PubDataModal;
using Microsoft.AspNet.Identity;
using Ishop.ViewModes.Info;
using LanguageResource;
using Ishop.Models.User;
using Ishop.Controllers;
namespace Ishop.Areas.Mgr.Controllers
{
    public class UserFinanceController : BaseController
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        // GET: Mgr/UserFinance
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        [HttpGet]
        public ActionResult UserFinanceItemList(string sortOrder, string currentFilter, string searchString, string StartDate, string EndDate, int? page)
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

            var userFinanceItems = from s in db.UserFinanceItems
                                   select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                userFinanceItems = userFinanceItems.Where(s => s.TblKeyId.Contains(searchString) || s.ShopID.Contains(searchString)
                                                                                     || s.UserId.Contains(searchString)
                                                                                     || s.StatusId.Contains(searchString)
                                                                                     || s.UserFinanceID.Contains(searchString)
                                                                                     || s.UserFinanceItemID.Contains(searchString));
            } 

            //DaySpan filter 
            if (StartDate != EndDate)
            {
                ViewBag.CurrentStartDate = StartDate;
                ViewBag.CurrentEndDate = EndDate;
                DateTime pStartDate = DateTime.Parse(StartDate);
                DateTime pEndDate = DateTime.Parse(EndDate);
                userFinanceItems = userFinanceItems.Where(s => s.CreatedDate > pStartDate && s.CreatedDate < pEndDate);
            }
            //Shop Filter
            userFinanceItems = userFinanceItems.Where(s => s.ShopID == WebCookie.ShopID);

            switch (sortOrder)
            {
                case "Date":
                    userFinanceItems = userFinanceItems.OrderBy(s => s.CreatedDate);
                    break;
                case "date_desc":
                    userFinanceItems = userFinanceItems.OrderByDescending(s => s.CreatedDate);
                    break;
                default:  // Name ascending 
                    userFinanceItems = userFinanceItems.OrderByDescending(s => s.CreatedDate);
                    break;
            }
            int pageSize = 30;
            int pageNumber = (page ?? 1);
            return View(userFinanceItems.ToPagedList(pageNumber, pageSize));
        }

        [Authorize]
        public JsonResult CalcUserFinanceCurrentMonth(int Month,string EnUserId)
        {
            ModalDialogView ReturnMsg = new ModalDialogView();
            string ShpID = WebCookie.ShpID;
            string UserId = EncryptHelper.Decrypt(EnUserId);
            var MonthOfvalidItem = db.UserFinanceItems.Where(c =>c.UserFinanceID == string.Empty && c.CreatedDate.Month == Month && c.UserId == UserId && c.StatusId.ToLower() == "created").ToList();
            decimal validItemCurrentMonth = MonthOfvalidItem.Sum(s => s.ItemAmount);
            DateTime StartDate = DateTime.Now ; //default value
            DateTime EndDate = DateTime.Now; //default value
            if(MonthOfvalidItem.Count == 0 )
            {
                var userFinance = db.UserFinances.Where(c => c.UserId == UserId).FirstOrDefault();
                ReturnMsg.MsgCode = "0";
                ReturnMsg.Message = string.Format(Lang.UserFinance_CalcUserFinanceCurrentMonth_ReturnMsgLastUpd, userFinance.TotalAmount, userFinance.StartDate, userFinance.EndDate, 0);
                return Json(ReturnMsg, JsonRequestBehavior.AllowGet);
            }
            if (MonthOfvalidItem.Count==1)
            {
                StartDate = MonthOfvalidItem.FirstOrDefault().CreatedDate;
                EndDate = MonthOfvalidItem.FirstOrDefault().CreatedDate;
            }
            if (MonthOfvalidItem.Count > 1)
            {
                StartDate = MonthOfvalidItem.OrderBy(c=>c.CreatedDate).FirstOrDefault().CreatedDate;
                EndDate = MonthOfvalidItem.OrderByDescending(c => c.CreatedDate).FirstOrDefault().CreatedDate;
            }
            ReturnMsg.MsgCode = "1";

            if( validItemCurrentMonth < 20 )
            {
                ReturnMsg.Message = string.Format(Lang.UserFinance_CalcUserFinanceCurrentMonth_ReturnMsg1, validItemCurrentMonth);  
            }
            else
            {
                string UserFinanceId = CreateUserFinance(UserId, validItemCurrentMonth, ShpID, StartDate, EndDate, "Submited");
                int Result = 1;
                List<UserFinanceItem> userFinanceItemList = new List<UserFinanceItem>(); 
                foreach(var item in MonthOfvalidItem)
                {
                    DbEntityEntry<UserFinanceItem> userFinanceItemEntry = db.Entry<UserFinanceItem>(item);
                    db.UserFinanceItems.Attach(item);
                    userFinanceItemEntry.Property(e => e.UserFinanceID).IsModified = true;
                    userFinanceItemEntry.Entity.UserFinanceID = UserFinanceId; 
                    Result = db.SaveChanges();
                } 
                ReturnMsg.Message = string.Format(Lang.UserFinance_CalcUserFinanceCurrentMonth_ReturnMsg, validItemCurrentMonth, StartDate, EndDate, Result);  //Successfully submitted billing request (amount: {0})<br/> Time period: {1}-{2} (excluding already submitted)
            }
            return Json(ReturnMsg , JsonRequestBehavior.AllowGet);
        }
        public string CreateUserFinance(string UserId, decimal TotalAmount,string ShpID, DateTime StartDate,DateTime EndDate ,string StatusId )
        {
            string UserFinanceID = db.GetTableIdentityID("UF", "UserFinance", 10);
            DateTime OperatedDate = DateTime.Now;
            DateTime CreatedDate = DateTime.Now; 
            UserFinance userFinance = new UserFinance
            {
                UserFinanceID = UserFinanceID
                ,
                UserId = UserId
                ,
                TotalAmount = TotalAmount
                ,
                ShopID = ShpID
                ,
                StartDate = StartDate
                ,
                EndDate = EndDate
                ,
                StatusId = StatusId
                ,
                OperatedDate = OperatedDate
                ,
                CreatedDate = CreatedDate
            }; 
            db.UserFinances.Add(userFinance);
            db.SaveChanges(); 
            return UserFinanceID;
        }
    }
}