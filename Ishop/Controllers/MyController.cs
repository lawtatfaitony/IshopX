using System;
using System.Text;
using System.Net;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PagedList;
using Ishop.Models;
using Ishop.Identity.Models;
using Ishop.Areas.Mgr.Models;
using Ishop.Utilities;
using Ishop.WrapperExtensions;
using LanguageResource;
using Ishop.Context;
using Ishop.Models.ProductMgr;
using Ishop.Models.User;
using System.Web.Mvc;
using Ishop.AppCode.Utilities;
using Ishop.Models.PubDataModal;
using System.Threading;
using Ishop.Models.Info;

namespace Ishop.Controllers
{
    public class MyController : BaseController
    {
        public MyController() : base()
        {   
        }

        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        // GET: My
        [Authorize]
        public ActionResult Index()
        {
            this.ShopInitialize();
            string UserId = User.Identity.GetUserId();
            ApplicationUser applicationUser = db.Users.Find(UserId);
            UserProfile userProfile = db.UserProfiles.Where(c => c.UserId == UserId ).FirstOrDefault();
            ViewBag.applicationUser = applicationUser;
            ViewBag.userProfile = userProfile;
            ViewBag.UserId = UserId;
            ViewBag.EnUserId = EncryptHelper.Encrypt(UserId);
            //List Order
            ViewBag.MyListOrder = db.Orders.Where(c => c.UserId == UserId).OrderByDescending(c=>c.CreatedDate).ToList(); 
            return View();
        }
        public List<OrderItem> getOrderItems(int OrderId)
        {
           return db.OrderItems.Where(c=> c.OrderId == OrderId ).ToList(); 
        }

        // GET: My
        [Authorize]
        public ActionResult UserFinanceList(string sortOrder, string currentFilter, string searchString, string StartDate, string EndDate, int? page,string EnUserId)
        {
            this.ShopInitialize();
            string UserId = User.Identity.GetUserId();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            ViewBag.CurrentStartDate = string.IsNullOrEmpty(StartDate) ? DateTime.Now.ToString("yyyy-MM-dd HH:mm") : StartDate;
            ViewBag.CurrentEndDate = string.IsNullOrEmpty(EndDate) ? DateTime.Now.ToString("yyyy-MM-dd HH:mm") : EndDate;

            if (searchString == null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var userFinances = from s in db.UserFinances
                                   select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                userFinances = userFinances.Where(s => s.UserFinanceID.Contains(searchString) 
                                                                                     || s.StatusId.Contains(searchString)
                                                                                     || s.UserFinanceID.Contains(searchString));
            } 
            //DaySpan filter 
            if (StartDate != EndDate)
            {
                ViewBag.CurrentStartDate = StartDate;
                ViewBag.CurrentEndDate = EndDate;
                DateTime pStartDate = DateTime.Parse(StartDate);
                DateTime pEndDate = DateTime.Parse(EndDate);
                userFinances = userFinances.Where(s => s.StartDate > pStartDate && s.EndDate < pEndDate);
            }
            //Shop Filter
            userFinances = userFinances.Where(s => s.ShopID == WebCookie.ShopID);

            //UserId Filter
            userFinances = userFinances.Where(s => s.UserId == UserId);

            switch (sortOrder)
            {
                case "Date":
                    userFinances = userFinances.OrderBy(s => s.CreatedDate);
                    break;
                case "date_desc":
                    userFinances = userFinances.OrderByDescending(s => s.CreatedDate);
                    break;
                default:  // Name ascending 
                    userFinances = userFinances.OrderByDescending(s => s.CreatedDate);
                    break;
            }
            int pageSize = 30;
            int pageNumber = (page ?? 1);
            return View(userFinances.ToPagedList(pageNumber, pageSize)); 
        }

        // GET: My
        [Authorize]
        public ActionResult UserFinanceItemList(string UserFinanceID ,string sortOrder, int? page, string EnUserId)
        {
            this.ShopInitialize();
            string UserId = User.Identity.GetUserId();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.UserFinanceID = UserFinanceID;
            var userFinanceItems = from s in db.UserFinanceItems
                               select s; 
            // Filter Id
            userFinanceItems = userFinanceItems.Where(s => s.UserFinanceID== UserFinanceID) ;
             
            //Shop Filter
            userFinanceItems = userFinanceItems.Where(s => s.ShopID == WebCookie.ShopID);

            //UserId Filter
            userFinanceItems = userFinanceItems.Where(s => s.UserId == UserId);

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
        public ActionResult SourceStatisticDetails(int? SourceStatisticID)
        {
            //Thread.Sleep(1000); //test
            ViewBag.Title = Lang.SourceStatistics_Title;
            SourceStatistic sourceStatistic = new SourceStatistic();
            sourceStatistic = db.SourceStatistics.Find(SourceStatisticID); 
            return View(sourceStatistic); 
        }

        /// <summary>
        /// 複製店鋪的內容
        /// 包括 InfoDetails / Products
        /// </summary>
        /// <param name="shipId">複製來源店鋪的店鋪ID</param>
        /// <returns></returns>
        [Authorize]
        public ActionResult ShopCopy(string sourceShopId)
        {
            if (string.IsNullOrEmpty(sourceShopId))
            {
                return View("ShopCopyShopNotExit");
            }
            else {
                sourceShopId = sourceShopId.Trim();
            }

            this.ShopInitialize();

            DateTime dt= DateTime.Now;

            string opUserId = User.Identity.GetUserId();
            string opUserName = User.Identity.GetUserName();

            //檢查是否此店鋪Staff
            var staffUser = db.ShopStaffs.Where(c=>c.ShopID == WebCookie.ShpID && c.UserId == opUserId).FirstOrDefault();
            if (staffUser==null)
            {
                return View("ShopCopyShopNotExit");
            }

            //判斷店鋪是否存在
            var shop = db.Shops.Find(sourceShopId);
            if(shop == null)
            {
                return View("ShopCopyShopNotExit");
            }
            //產品複製 --------------------------------------------------------------------
            var products = db.Products.Where(c=>c.ShopID.Contains(sourceShopId)).ToList();

            List<Product> productList = new List<Product>();

            foreach (var product in products)
            {
                if (product != null)
                {
                    //如果 貨號 StyleNo 在本店鋪不存在,則複製
                    var existItem = db.Products.Where(c=>c.StyleNo.Contains(product.StyleNo) && c.ShopID.Contains(WebCookie.ShpID)).FirstOrDefault();
                   if(existItem == null)
                    {
                        product.ShopID = WebCookie.ShpID;
                        product.StaffID = ViewBag.ShopUserId;
                        product.ProductID =  db.GetTableIdentityID("P", "Product", 5);
                        product.OperatedUserName = opUserName; 
                        product.OperatedDate = new DateTime(2000,01,01,01,01,01,01);
                        product.CreatedDate = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 01, 01);
                        productList.Add(product);

                    }else
                    {
                        continue;
                    } 
                }
            }
            db.Products.AddRange(productList);
            int ProductCopyTotal = db.SaveChanges();

            //信息複製 --------------------------------------------------------------------
            var infodetails = db.InfoDetails.Where(c => c.ShopID.Contains(sourceShopId)).ToList();

            List<InfoDetail> infoDetailLists = new List<InfoDetail>();

            foreach (var infoDetail in infoDetailLists)
            {
                if (infoDetail != null)
                {
                    //如果 信息標題 在本店鋪不存在,則複製
                    var existItem = db.InfoDetails.Where(c => c.Title.Contains(infoDetail.Title) && c.ShopID.Contains(WebCookie.ShpID)).FirstOrDefault();
                    if (existItem == null)
                    {
                        infoDetail.InfoID = db.GetTableIdentityID("Inf", "InfoDetail", 9);
                        infoDetail.ShopID = WebCookie.ShpID;
                        infoDetail.Author = ViewBag.ShopUserId;
                        infoDetail.OperatedUserName = opUserName;
                        infoDetail.OperatedDate = new DateTime(2000, 01, 01, 01, 01, 01, 01);
                        infoDetail.CreatedDate = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 01, 01);
                        infoDetailLists.Add(infoDetail);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            db.InfoDetails.AddRange(infoDetailLists);
            int InfCopyTotal = db.SaveChanges();

            ViewBag.ShopCopyMessage = $"Product Copy Total = {ProductCopyTotal} ; InfoDetails Copy Total = {InfCopyTotal}";
            return View("ShopCopySuccess");
        }

    }
}