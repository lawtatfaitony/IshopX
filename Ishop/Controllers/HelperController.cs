using Ishop.Context;
using Ishop.Models;
using Ishop.Models.Info;
using Ishop.ViewModes.Info;
using LanguageResource;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Ishop.Controllers
{
    public class HelperController : BaseController
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        public HelperController() : base()
        {
        }
        [HttpGet]
        [Route("Default")]
        public ActionResult Index(string Id, string searchString, int? page)
        {
            ShopInitialize();
            if (!string.IsNullOrEmpty(searchString))
            {
                ViewBag.SearchString = Server.UrlDecode(searchString);
            }
            int pageNumber = (page ?? 1);
            ViewBag.CurrnetPage = pageNumber;

            ShopInitialize();
            // this.InitLanguageStateViewBag();  //作廢 2024-4-29

            InfoDetail infoDetail = new InfoDetail(); 
            //InfoCateEnumCode.HELP_FIRST 默认请求是常量分类第一条 
            if (!string.IsNullOrEmpty(Id))
            {
                infoDetail = db.InfoDetails.Find(Id);
            }else
            {
                string SOFTWARE_HELPER = InfoCateEnumCode.SOFTWARE_HELPER.ToString();
                string HELP_FUNCTUON = InfoCateEnumCode.HELP_FUNCTUON.ToString(); 
                infoDetail = db.InfoDetails.Where(c => c.ShopID.Contains(WebCookie.ShpID) && (c.InfoCateID.Contains(SOFTWARE_HELPER)|| c.InfoCateID.Contains(HELP_FUNCTUON))).OrderByDescending(c=>c.OperatedDate).FirstOrDefault();
            }
            if(infoDetail==null) //还是为null 避免错误，从表中获取任意一条。
            {
                infoDetail = db.InfoDetails.Where(c => c.ShopID.Contains(WebCookie.ShpID)).OrderByDescending(c => c.OperatedDate).FirstOrDefault();
            }
             
            //IP statitics
            string RecommUserId = db.Shops.Find(infoDetail.ShopID).UserId; //default
            if (!string.IsNullOrEmpty(WebCookie.RecommUserId))
            {
                RecommUserId = WebCookie.RecommUserId;
            }
            this.IpStatitics_Token();
            ViewBag.SourceStatisticsID = this.IPstatiticsAdd(infoDetail.InfoID, infoDetail.Title, RecommUserId, infoDetail.ShopID);

            infoDetail.Title = ChineseStringUtility.ToAutoTraditional(infoDetail.Title);
            infoDetail.SubTitle = ChineseStringUtility.ToAutoTraditional(infoDetail.SubTitle);
            infoDetail.Author = ChineseStringUtility.ToAutoTraditional(infoDetail.Author);
            infoDetail.InfoDescription = ChineseStringUtility.ToAutoTraditional(infoDetail.InfoDescription);
            infoDetail.SeoKeyword = ChineseStringUtility.ToAutoTraditional(infoDetail.SeoKeyword);
            infoDetail.SeoDescription = ChineseStringUtility.ToAutoTraditional(infoDetail.SeoDescription);

            if (!string.IsNullOrEmpty(infoDetail.SubTitle))
            {
                infoDetail.SubTitle = "<i class=\"glyphicon glyphicon-chevron-right\"></i> " + infoDetail.SubTitle;
            }
             
            return View(infoDetail);
        }

        [HttpGet]
        [Route("Default")]
        public ActionResult GetInfoDetails(string Id)
        { 
            InfoDetail infoDetail = new InfoDetail();

            infoDetail = db.InfoDetails.Find(Id);
             
            infoDetail.Title = ChineseStringUtility.ToAutoTraditional(infoDetail.Title);
            infoDetail.SubTitle = ChineseStringUtility.ToAutoTraditional(infoDetail.SubTitle);
            infoDetail.Author = ChineseStringUtility.ToAutoTraditional(infoDetail.Author);
            infoDetail.InfoDescription = ChineseStringUtility.ToAutoTraditional(infoDetail.InfoDescription);
            infoDetail.SeoKeyword = ChineseStringUtility.ToAutoTraditional(infoDetail.SeoKeyword);
            infoDetail.SeoDescription = ChineseStringUtility.ToAutoTraditional(infoDetail.SeoDescription);

            if (!string.IsNullOrEmpty(infoDetail.SubTitle))
            {
                infoDetail.SubTitle = "<i class=\"glyphicon glyphicon-chevron-right\"></i> " + infoDetail.SubTitle;
            }

            return Json(infoDetail,JsonRequestBehavior.AllowGet);
        }

        // GET: Mgr/Info
        //[Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpGet]
        public ActionResult HelpList(string searchString, int? page)
        {
            ShopInitialize();
            // this.InitLanguageStateViewBag();  //作廢 2024-4-29

            var infoDetails = from s in db.InfoDetails.Select(s => new InfoListView
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
            }) select s;
             
            string SOFTWARE_HELPER = InfoCateEnumCode.SOFTWARE_HELPER.ToString();
            string HELP_FUNCTUON = InfoCateEnumCode.HELP_FUNCTUON.ToString();
             
            infoDetails = infoDetails.Where(s => s.ShopID == WebCookie.ShpID && (s.InfoCateID.Contains(SOFTWARE_HELPER) || s.InfoCateID.Contains(HELP_FUNCTUON)));
             
            if (!String.IsNullOrEmpty(searchString))
            {
                infoDetails = infoDetails.Where(s => s.InfoID.Contains(searchString) || s.Title.Contains(searchString)
                                                                                     || s.SubTitle.Contains(searchString) 
                                                                                     || s.SeoKeyword.Contains(searchString));
            }
             
            infoDetails = infoDetails.OrderByDescending(s => s.OperatedDate);
             
            int pageSize = 100;
            int pageNumber = (page ?? 1);
            return View(infoDetails.ToPagedList(pageNumber, pageSize));
        }


        [HttpGet] 
        public ActionResult MainFunc()
        {
            ShopInitialize();
            // this.InitLanguageStateViewBag();  //作廢 2024-4-29
            return View();
        }


        //MainFuncAiBox
        [HttpGet]
        public ActionResult MainFuncAiBox()
        {
            ShopInitialize();
            // this.InitLanguageStateViewBag();  //作廢 2024-4-29
            return View();
        }

        [HttpGet]
        public ActionResult DownloadPage()
        {
            ShopInitialize();
            // this.InitLanguageStateViewBag();  //作廢 2024-4-29
            return View();
        }
    }
}