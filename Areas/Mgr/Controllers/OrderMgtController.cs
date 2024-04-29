using Ishop.AppCode.Utilities;
using Ishop.Areas.Mgr.Models;
using Ishop.Context;
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
   
    public class OrderMgtController : Controller
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


    }
}