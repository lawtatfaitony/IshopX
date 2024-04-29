using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Net;
using Ishop.Context;
using Ishop.Areas.Mgr.Models;
using Ishop.Models.Info;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using Ishop.Utilities;
using LanguageResource;
using Ishop.Models.ProductMgr;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Ishop.Models.PubDataModal;
using System.Web;
using Ishop.Controllers;
using Ishop.ViewModes.Info;
using PagedList;
using System.IO;

namespace Ishop.Info.Controllers
{
    public class InfoListController : BaseController
    {
        public InfoListController() : base()
        {
        }
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext(); 
        // GET: Info
        public ActionResult Index(string Id)
        {
            ShopInitialize();
            mvcCommeBase.ChkShpID();
            string ShpID = WebCookie.ShpID;

            //header  TableName   Title  SubTitle KeyWords Description
            ViewBag.Title = Lang.InfoDetail_Title;
            ViewBag.KeyWords = Lang.InfoDetail_InfoList_KeyWords;
            ViewBag.KeyWordDescription = Lang.InfoDetail_InfoList_KeyWordDescription;
             
            // 规则: 获取 主分类 默认顺序的 4个分类  
            string[] arrInfoCateID = GetTop4InfoCates(ShpID); 
            string[] arrInfoCateName = GetTop4InfoCatesName(ShpID);
            //最少 设置4个分类
            if(arrInfoCateID.Length<4)
            {
                ModalDialogView ModalDialogView1 = new ModalDialogView
                {
                    Message = ShpID + "-出错:最少4个资讯分类:1.热点资讯 2.头条资讯 3.特别专题 4. 专业知识",
                    MsgCode = "0"
                };
                return View("ModalDialogView",ModalDialogView1);
            } 
            //top1 热点资讯
            ViewBag.HotTopicName = arrInfoCateName[0].ToString();
            string HotTopic_InfoCateID = arrInfoCateID[0].ToString();  
            ViewBag.HotTopic = db.InfoDetails.Where(s => s.InfoCateID == HotTopic_InfoCateID).OrderByDescending(s=>s.OperatedDate).Take(6).Select(s => new InfoListView
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
            }).ToList();
            ////top2 头条资讯
            ViewBag.HeadLinesName = arrInfoCateName[0].ToString();
            string HeadLines_InfoCateID = arrInfoCateID[1].ToString();
            ViewBag.HeadLines = db.InfoDetails.Where(s => s.InfoCateID == HeadLines_InfoCateID ).Take(6).Select(s => new InfoListView
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
            }).ToList();
            ////top3 特别专题
            ViewBag.SpecialTopicName = arrInfoCateName[0].ToString();
            string SpecialTopic_InfoCateID = arrInfoCateID[2].ToString(); 
            ViewBag.SpecialTopic = db.InfoDetails.Where(s => s.InfoCateID == SpecialTopic_InfoCateID).Take(6).Select(s => new InfoListView
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
            }).ToList();
            //// top4 ProfKnowledge 专业知识
            ViewBag.ProfKnowledgeName = arrInfoCateName[0].ToString();
            string ProfKnowledge_InfoCateID = arrInfoCateID[3].ToString();
            ViewBag.ProfKnowledge = db.InfoDetails.Where(s => s.InfoCateID == ProfKnowledge_InfoCateID).Take(6).Select(s => new InfoListView
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
            }).ToList();

            return View();
        }
        public string[] GetTop4InfoCates(string ShopID)
        {
            // 规则: 获取 主分类 默认顺序的 4个分类 的名称
            IQueryable<InfoCate> infoCates = db.InfoCates.Where(c => c.PrarentsID == "0" && c.ShopID == ShopID).Take<InfoCate>(4);
            string[] arrInfoCateName = new string[4];
            int i = 0;
            foreach (var Item in infoCates)
            {
                if (i > 3)
                {
                    break;
                }
                arrInfoCateName[i] = Item.InfoCateID;
                i++;
            }
            return arrInfoCateName;
        }
        public string[] GetTop4InfoCatesName(string ShopID)
        {
            // 规则: 获取 主分类 默认顺序的 4个分类
            IQueryable<InfoCate> infoCates = db.InfoCates.Where(c => c.PrarentsID == "0" && c.ShopID == ShopID).Take<InfoCate>(4);
            string[] arrInfoCateID = new string[4];
            int i = 0;
            foreach (var Item in infoCates)
            {
                if (i > 3)
                {
                    break;
                }
                arrInfoCateID[i] = Item.InfoCateName;
                i++;
            }
            return arrInfoCateID;
        }
         
        //浏览次数
        public void InfoViewCount(string InfoID, string IpStatitics_StartDate_Token)
        {

            //设置用于计算持续时间的起始时间
            string IpStatitics_StartDate = "";
            string IpStatitics_StartDate_Token_CK = "";
            if (Request.Cookies["IpStatitics_StartDate"] != null)
            {

                IpStatitics_StartDate = Request.Cookies["IpStatitics_StartDate"].Value;
                IpStatitics_StartDate_Token_CK = mvcCommeBase.SHA1_Hash(IpStatitics_StartDate);
            }
            else
            {
                //没有时间校验cookie,否则不统计
                return ;
            }
            //验证传入数据后计数浏览量
            if (IpStatitics_StartDate_Token == IpStatitics_StartDate_Token_CK)
            {
                InfoDetail infoDetail = db.InfoDetails.Find(InfoID);
                //---------------------------------------------------------------------------------------
                string s = mvcCommeBase.GenerateNumberRandom(2);
                int randomNum = 0;
                bool randomNumRet = int.TryParse(s,out randomNum);
                if(randomNumRet)
                {
                    infoDetail.Views += randomNum;
                }
                else
                {
                    infoDetail.Views += 1;
                }
                
                DbEntityEntry<InfoDetail> InfoDetailEntry = db.Entry<InfoDetail>(infoDetail);
                db.InfoDetails.Attach(infoDetail);
                InfoDetailEntry.Property(e => e.Views).IsModified = true;
                try
                {
                    // Write database
                    db.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    //Take a look at the dbEX error message
                    throw dbEx;
                }
            }
            return ;
        }
       
        public ActionResult InfoDetails(string InfoID,string Id)
        {
            ShopInitialize();
            // this.InitLanguageStateViewBag();  //作廢 2024-4-29

            //If the url parameter /InfoList/InfoDetails?InfoID=inf00000001 format is the case: ?Id=inf00000001 then use the following judgment to solve
            if (!string.IsNullOrEmpty(Id))
            {
                InfoID = Id;
            }

            //--------------------------------------------------------------------------------------------------------------------------
            //如果存在实体的内容文件 Infxxxxxxx1.zh-CN.cshtml则返回实体内容文件
            string csHtmlName = $"Infodetails/{InfoID}.{LangUtilities.LanguageCode}";
            string csHtmlFileName = $"{InfoID}.{LangUtilities.LanguageCode}.cshtml";
            string csHtmlPathFile = Path.Combine(Server.MapPath("~/Views/Shared/Infodetails/"), csHtmlFileName);
            if(System.IO.File.Exists(csHtmlPathFile))
            {
                return View(csHtmlName);
            }

            //----------------------------------------------------------------------------------------------------------------------------
            ViewBag.InfoID = InfoID;
            InfoDetail infoDetail = db.InfoDetails.Find(InfoID);
            if (infoDetail == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //IP statitics
            string RecommUserId = db.Shops.Find(infoDetail.ShopID).UserId; //default
            if (!string.IsNullOrEmpty(WebCookie.RecommUserId))
            {
                RecommUserId = WebCookie.RecommUserId;
            }
            this.IpStatitics_Token();
            ViewBag.SourceStatisticsID = this.IPstatiticsAdd(InfoID, infoDetail.Title , RecommUserId, infoDetail.ShopID);
            
            infoDetail.Title = ChineseStringUtility.ToAutoTraditional(infoDetail.Title);
            infoDetail.SubTitle = ChineseStringUtility.ToAutoTraditional(infoDetail.SubTitle);
            infoDetail.Author = ChineseStringUtility.ToAutoTraditional(infoDetail.Author);
            infoDetail.InfoDescription = ChineseStringUtility.ToAutoTraditional(infoDetail.InfoDescription);
            infoDetail.SeoKeyword = ChineseStringUtility.ToAutoTraditional(infoDetail.SeoKeyword);
            infoDetail.SeoDescription = ChineseStringUtility.ToAutoTraditional(infoDetail.SeoDescription);

            ViewBag.Title = infoDetail.Title;
            ViewBag.KeyWords = infoDetail.SeoKeyword;
            ViewBag.Description = infoDetail.SubTitle;
            ViewBag.KeyWordDescription = infoDetail.SeoDescription;
            ViewBag.IsOriginal = infoDetail.IsOriginal;
            //Reading Guide : 
            //ViewBag.Introduction = "<i class=\"glyphicon glyphicon-chevron-right\"></i> " + Lang.InfoList_InfoDetails_DefinitedTag_Introduction + "<br>" + infoDetail.SubTitle;  //<i class=\"fa fa-hand-o-right\">&nbsp;</i>
            ViewBag.Introduction = "<i class=\"glyphicon glyphicon-chevron-right\"></i> " + infoDetail.SubTitle;   
            ViewBag.InfoDescription = infoDetail.InfoDescription;
            ViewBag.ShopStaffID = infoDetail.ShopStaffID;
            ////Relate Info
            //var RelateInfoList = db.InfoDetails.Where(c => c.InfoID != infoDetail.InfoID && c.InfoCateID == infoDetail.InfoCateID).OrderByDescending(s => s.OperatedDate).Take(6).ToList();
            //ViewBag.RelateInfoList = RelateInfoList.Where(c=>c.InfoID != InfoID).ToList();
            //the Most Views（Relate Info）
            //var TopView = db.InfoDetails.Where(c => c.InfoID != infoDetail.InfoID && c.InfoCateID == infoDetail.InfoCateID && c.ShopID == infoDetail.ShopID).OrderByDescending(s => s.Views).Take(8).ToList();
            var TopView = db.InfoDetails.Where(c => c.InfoID != infoDetail.InfoID && c.ShopID == infoDetail.ShopID).OrderByDescending(s => s.Views).Take(6).ToList();
            ViewBag.TopView = TopView.Where(c => c.InfoID != InfoID).Select(s => new InfoListView
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
            }).ToList();

            if(Request.IsAuthenticated)
            {
                Uri uri = Request.Url;
                string hostname = uri.Host;
                int port = uri.Port;
                string scheme = uri.Scheme;

                string userId = User.Identity.GetUserId();
                UserTrace userTrace = this.GetUserTrace(infoDetail.InfoID, userId);
                string userTraceUrl = $"{LangUtilities.LanguageCode}/Home/Trace/{userTrace.UserTraceID}";

                userTraceUrl = $"{scheme}//{hostname}:{port}/{userTraceUrl}";

                ViewBag.UserTraceUrl = userTraceUrl;
            }
            //模板是公共的,不需要店铺查询模板(InfoItemTemplate),也就是 where(c=>c.ShopId.Contain(shpID))不需要,之前是用这个附加条件的.
            //InfoTemp00003 信息明细的专题模板
            string keyOfSubjectTemplate = "InfoTemp00003";
            string keyOfComtainsTemplate = "InfoTemp00004";
            if (!string.IsNullOrEmpty(infoDetail.InfoItemTemplateIDs))
            {
                if (infoDetail.InfoItemTemplateIDs.Contains(keyOfSubjectTemplate))
                {
                    var infoItemTemplate = db.InfoItemTemplates.Find(keyOfSubjectTemplate);
                    return View(infoItemTemplate.Path, infoDetail);
                }

                if (infoDetail.InfoItemTemplateIDs.Contains(keyOfComtainsTemplate))
                {
                    var infoItemTemplate = db.InfoItemTemplates.Find(keyOfComtainsTemplate);
                    return View(infoItemTemplate.Path, infoDetail);
                }
            }
             
            return View(infoDetail);
        }
        public ActionResult ViewIconPortrait(string ShopStaffID)
        {
            ShopInitialize();
            ShopStaff ShopStaff1 = new ShopStaff(); 
            //Editor Introduce
            if (!string.IsNullOrEmpty(ShopStaffID))
            {
                ShopStaff1 = db.ShopStaffs.Find(ShopStaffID);
                 
                if(ShopStaff1 == null)
                { 
                    // case: param is userId value 
                    ShopStaff1 = db.ShopStaffs.Find(ShopStaffID);
                    if (ShopStaff1 == null)
                    {
                        return View(); // return blank 
                    } 
                }
                
                ShopStaff1.ContactTitle = ChineseStringUtility.ToAutoTraditional(ShopStaff1.ContactTitle);
                ShopStaff1.OtherChannelName = ChineseStringUtility.ToAutoTraditional(ShopStaff1.OtherChannelName); 
                ShopStaff1.ChannelID = ChineseStringUtility.ToAutoTraditional(ShopStaff1.ChannelID); 
                ShopStaff1.Introduction = ChineseStringUtility.ToAutoTraditional(ShopStaff1.Introduction);
                ViewBag.vIntroduction = HttpUtility.HtmlDecode(ShopStaff1.Introduction); 
                return View(ShopStaff1);
            }
            else
            { 
                return View();
            }
        }

        [HttpGet]
        public ActionResult Get(string sortOrder, string currentFilter, string searchString, string StartDate, string EndDate, int? page)
        {
            ShopInitialize();
            // this.InitLanguageStateViewBag();  //作廢
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

            var infoDetails = from s in db.InfoDetails.Where(s => s.ShopID == WebCookie.ShpID).OrderByDescending(s => s.OperatedDate)
                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                infoDetails = infoDetails.Where(s => s.InfoID.Contains(searchString) || s.Title.Contains(searchString)
                                                                                     || s.SubTitle.Contains(searchString)
                                                                                     || s.InfoDescription.Contains(searchString)
                                                                                     || s.SeoKeyword.Contains(searchString));
            }
            //DaySpan filter  
            if (StartDate != EndDate)
            {
                ViewBag.CurrentStartDate = StartDate;
                ViewBag.CurrentEndDate = EndDate;

                DateTime pStartDate = DateTime.Parse(StartDate);
                DateTime pEndDate = DateTime.Parse(EndDate);
                infoDetails = infoDetails.Where(s => s.OperatedDate > pStartDate && s.OperatedDate < pEndDate);
            }

            var infoLists = infoDetails.Select(s => new InfoListView
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
            }).ToList();

            int pageSize = 42;
            int pageNumber = (page ?? 1);


            return View(infoLists.ToPagedList(pageNumber, pageSize));
        }
    }
}
