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
using System.Threading;
using Ishop.Models;

namespace Ishop.Areas.Mgr.Controllers
{
    public class InfoController : BaseController
    {
        public InfoController() : base()
        {
        }
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Mgr/Info
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpGet]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, string StartDate, string EndDate, int? page)
        {
            ShopInitialize();
            // this.InitLanguageStateViewBag();  //作廢 2024-4-29

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

            var infoDetails = from s in db.InfoDetails
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
            //shop file
            infoDetails = infoDetails.Where(s => s.ShopID == WebCookie.ShopID);

            switch (sortOrder)
            {
                case "Date":
                    infoDetails = infoDetails.OrderBy(s => s.OperatedDate);
                    break;
                case "date_desc":
                    infoDetails = infoDetails.OrderByDescending(s => s.OperatedDate);
                    break;
                default:  // Name ascending 
                    infoDetails = infoDetails.OrderByDescending(s => s.OperatedDate);
                    break;
            } 
            int pageSize = 30;
            int pageNumber = (page ?? 1); 
            return View(infoDetails.ToPagedList(pageNumber, pageSize));
        }

        // GET: Mgr/Info/Details/5
        public ActionResult Details(string InfoID)
        {
            return View(); 
        }
        /// <summary>
        /// Get query details
        /// </summary>
        /// <returns></returns>
        // GET: Mgr/Info/AddUpdateInfo
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpGet]
        public ActionResult AddUpdateInfo(string InfoID,string FromInfoID)
        {
            if (!string.IsNullOrEmpty(InfoID)) // not equal to null
            {
                var infoDetails = db.InfoDetails.Find(InfoID);  
                if (infoDetails == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }else if(infoDetails.ShopID.Contains(WebCookie.ShopID))
                {
                    // Back to Activity Details 
                    ViewBag.CurrentInfoID = InfoID;

                    ViewBag.TempInfoID = InfoID; //For synchronization tables : UploadItem.TargetTalbeKeyID

                    //List related documents
                    ViewBag.UploadItemList = db.UploadItems.Where(s => s.TargetTalbeKeyID.Contains(InfoID)).ToList();

                    ViewBag.vInfoDescription = infoDetails.InfoDescription;
                }
                 
                //InfoCateDropDownList(infoDetails.InfoCateID);

                ShopStaff_StaffName_DropDownList(infoDetails.ShopStaffID); //from  ShopStaff.StaffName

                PopulateAssignedInfoItemTemplateIDs(infoDetails.InfoItemTemplateIDs);

                return View(infoDetails);
            }
            else
            { 
                ViewBag.TempInfoID = "XXXy" + Guid.NewGuid().ToString("N"); //format:e0a953c3ee6040eaa9fae2b667060e09   
                Session["TempInfoID"] = ViewBag.TempInfoID;
                //InfoCateDropDownList(null); // null : not to select 
                ShopStaff_StaffName_DropDownList(); //editor from ShopStaff.StaffName
                PopulateAssignedInfoItemTemplateIDs();

                InfoDetail infoDetail = new InfoDetail();
                infoDetail.LanguageCode = LangEnumCode.NO_SET.ToString().ToUpper();
                if (!string.IsNullOrEmpty(FromInfoID))
                {
                    InfoDetail infoDetailX = CopyInfo(FromInfoID);
                    if (infoDetailX != null)
                    {
                        ViewBag.vInfoDescription = infoDetailX.InfoDescription; 
                        infoDetail = infoDetailX;
                    }
                }

                return View(infoDetail);
            } 
        }
        private InfoDetail CopyInfo(string InfoID)
        {
            if (!string.IsNullOrEmpty(InfoID)) // not equal to null
            {
                var infoDetails = db.InfoDetails.Find(InfoID);
                if(infoDetails!=null)
                {
                    infoDetails.InfoCateID = string.Empty;
                    infoDetails.ShopID = WebCookie.ShopID;
                    infoDetails.OperatedUserName = User.Identity.Name;
                    infoDetails.CreatedDate = DateTime.Now;
                    infoDetails.OperatedDate = DateTime.Now;
                    infoDetails.ShopStaffID = string.Empty;
                    infoDetails.InfoItemTemplateIDs = string.Empty;
                    return infoDetails;

                }
                else
                {
                    return null;
                }
               
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        [Route("Mgr")]
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        public ActionResult InfoEditor(string InfoID)
        {
            var infoDetails = db.InfoDetails.Find(InfoID);
            return View(infoDetails);
        }

        [HttpPost] 
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        public ActionResult UpdateInfoDesc(string InfoID, string InfoDescription)
        { 
            ModalDialogView ModalDialogView1 = new ModalDialogView();
             
            var infodetails = db.InfoDetails.Find(InfoID);
            if(infodetails==null)
            {
                ModalDialogView1.MsgCode = "0";
                ModalDialogView1.Message = Lang.GeneralUI_Fail;
                return Json(ModalDialogView1);
            }

            try
            { 
                infodetails.InfoDescription = HttpUtility.UrlDecode(InfoDescription, Encoding.UTF8);  
                infodetails.OperatedUserName = User.Identity.Name;
                infodetails.OperatedDate = DateTime.Now;
               
                db.Entry(infodetails).State = System.Data.Entity.EntityState.Modified;
                bool result = db.SaveChanges() > 0;
                
                if (result)
                {
                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message = Lang.Views_GeneralUI_Update + Lang.Views_GeneralUI_SavedSuccessfully;
                    return Json(ModalDialogView1);
                }
                else
                {
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message = string.Format("{0}\n\n  DATABASE FAIL", Lang.GeneralUI_Fail);
                    return Json(ModalDialogView1);
                }
            }
            catch (Exception e)
            {
                ModalDialogView1.MsgCode = "0";
                ModalDialogView1.Message = string.Format("{0}\n\n{1}", Lang.GeneralUI_Fail, e.Message);
                return Json(ModalDialogView1);
            }
        }
         

        /// <summary>
        ///Information additions and updates
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: Mgr/Info/AddUpdateInfo
        [HttpPost]
        public ActionResult AddUpdateInfo(string InfoID,
            [Bind(Include = "InfoID,InfoCateID, Title,TitleThumbNail,ShowTitleThumbNail,SubTitle,InfoDescription,SeoKeyword,SeoDescription,VideoUrl,Author,ShopStaffID,IsOriginal,LanguageCode,Views,ShopID,CreatedDate")]InfoDetail infoDetail , string[] selectedInfoItemTemplateIDs)
        {
            AdditionalForUpload AdditionalForUpload1 = new AdditionalForUpload(); 
            ModalDialogView ModalDialogView1 = new ModalDialogView();
             
            if (string.IsNullOrEmpty(InfoID))
            {
                infoDetail.InfoID = db.GetTableIdentityID("Inf", "InfoDetail", 9);
                infoDetail.InfoItemTemplateIDs = UpdateAssignedInfoItemTemplateIDs(selectedInfoItemTemplateIDs);
                //Contains HTML code to be placed after ModelState.IsValid, otherwise validation fails
                infoDetail.InfoDescription = HttpUtility.UrlDecode(infoDetail.InfoDescription, Encoding.UTF8); 
                infoDetail.ShopID = WebCookie.ShopID;
                infoDetail.OperatedUserName = User.Identity.Name;
                infoDetail.CreatedDate = DateTime.Now;
                infoDetail.OperatedDate = DateTime.Now; 
                        try
                        {
                            db.InfoDetails.Add(infoDetail);
                            int result = db.SaveChanges();
                            if(result > 0)
                            {
                                string UserTraceId = infoDetail.ShopID + User.Identity.GetUserId() + infoDetail.InfoID;
                                UserTrace userTrace = new UserTrace
                                {
                                    UserTraceID = UserTraceId,
                                    TableKeyID = infoDetail.InfoID,
                                    ShopID = infoDetail.ShopID,
                                    UserId = User.Identity.GetUserId(),
                                    OperatedUserName = User.Identity.GetUserId(),
                                    OperatedDate = DateTime.Now
                                }; 
                                db.UserTraces.Add(userTrace);
                                db.SaveChanges(); 
                            }
                            ModalDialogView1.MsgCode = "1";
                            ModalDialogView1.Message = Lang.Views_GeneralUI_AddNewOk ;
                            //Finally, synchronize the InfoID to the temporary ID (TargetTalbeKeyID):
                            if (ViewBag.TempInfoID==null )
                            {
                                ViewBag.TempInfoID = Session["TempInfoID"].ToString();
                            }
                            AdditionalForUpload1.AlterTempTargetTalbeKeyID(ViewBag.TempInfoID, infoDetail.InfoID);
                            return Json(ModalDialogView1);
                        }
                        catch(DbEntityValidationException dbEx)
                        { 
                            ModalDialogView1.MsgCode = "0";
                            ModalDialogView1.Message = "DbEntityValidationException:\n" + dbEx.Message +"\n"+ ModelState.Keys.ToList();
                            return Json(ModalDialogView1);
                        } 
            }
            else
            {     
                try
                {
                    infoDetail.InfoID = InfoID;
                    infoDetail.InfoItemTemplateIDs = UpdateAssignedInfoItemTemplateIDs(selectedInfoItemTemplateIDs);
                    infoDetail.InfoDescription = HttpUtility.UrlDecode(infoDetail.InfoDescription, Encoding.UTF8);

                    infoDetail.ShopID = WebCookie.ShopID;
                    infoDetail.OperatedUserName = User.Identity.Name;
                    infoDetail.OperatedDate = DateTime.Now;
                    if (ModelState.IsValid)
                    {
                        db.Entry(infoDetail).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        ModalDialogView1.MsgCode = "1";
                        ModalDialogView1.Message = Lang.Views_GeneralUI_AddNewOk;
                        return Json(ModalDialogView1);
                    }
                    else
                    {
                        ModalDialogView1.MsgCode = "0";
                        ModalDialogView1.Message = string.Format("{0}\n\n Invalid data field", Lang.GeneralUI_Fail);
                        return Json(ModalDialogView1);
                    }
                }
                catch (Exception e)
                {   
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message = string.Format("{0}\n\n{1}", Lang.GeneralUI_Fail, e.Message);
                    return Json(ModalDialogView1);
                }

            } 
        } 

        // GET: Mgr/Info/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mgr/Info/Delete/5
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpPost]
        public ActionResult Delete(string InfoID)
        {
            string msg = string.Format("<br/><h3>{0}</h3><br/>InfoID={1}", Lang.ModalView_AddUpdateInfo_Msg, InfoID);
            ModalDialogView modalDialogView = new ModalDialogView { MsgCode = "1", Message = HttpUtility.UrlDecode(msg, Encoding.UTF8) };

            try
            {
                InfoDetail InfoDetailItem = db.InfoDetails.Find(InfoID);
                db.InfoDetails.Remove(InfoDetailItem);
                db.SaveChanges();
                return Json(modalDialogView);
            }
            catch
            {
                modalDialogView = new ModalDialogView { MsgCode = "0", Message = string.Format("<br/><h3>{0}{1}</h3><br/>",Lang.Info_ClearInvalidData_msgError ,InfoID) };
                return Json(modalDialogView);
            }
        }
        //Information category
        private void InfoCateDropDownList(object selectedInfocateID = null)
        {
            var InfocateQuery = from d in db.InfoCates 
                                select d;
            //Shop filtering
            InfocateQuery = InfocateQuery.Where(c=>c.ShopID == WebCookie.ShopID); 
            ViewBag.InfoCateID = new SelectList(InfocateQuery, "InfoCateID", "InfoCateName", selectedInfocateID);
        }
        //Information template list
        private void PopulateAssignedInfoItemTemplateIDs(string selectedInfoItemTemplateIDs = null )
        {
            var allInfoItemTemplates = db.InfoItemTemplates.OrderBy(s => s.InfoItemTemplateName);

            var viewModel = new List<ViewInfoItemTemplateOption>();
            foreach (var item in allInfoItemTemplates)
            {
                viewModel.Add(new ViewInfoItemTemplateOption
                {
                    InfoItemTemplateID = item.InfoItemTemplateID, 
                    InfoItemTemplateName = item.InfoItemTemplateName,
                    Assigned = string.IsNullOrEmpty(selectedInfoItemTemplateIDs) ? false : selectedInfoItemTemplateIDs.Contains(item.InfoItemTemplateID)
                });
            }
            ViewBag.List_InfoItemTemplateIDs = viewModel;
        }

        public string UpdateAssignedInfoItemTemplateIDs(string[] selectedInfoItemTemplateIDs)
        {
            if (selectedInfoItemTemplateIDs == null)
            {
                return string.Empty;
            }

            var selectedRolesHashSet = new HashSet<string>(selectedInfoItemTemplateIDs);

            string ReturnInfoItemTemplateIDs = "";
            foreach (string InfoItemTemplateID in selectedRolesHashSet)
            {
                ReturnInfoItemTemplateIDs = ReturnInfoItemTemplateIDs + "," + InfoItemTemplateID;
            } 
            ReturnInfoItemTemplateIDs = ReturnInfoItemTemplateIDs.TrimEnd(',');
            ReturnInfoItemTemplateIDs = ReturnInfoItemTemplateIDs.TrimStart(',');
            return ReturnInfoItemTemplateIDs;
        }
        //ShopStaff.StaffName
        private void ShopStaff_StaffName_DropDownList(object selectedShopStaffID = null)
        {
            var ShopStaffQuery = from d in db.ShopStaffs
                                select d;
            //Shop Filter
            ShopStaffQuery = ShopStaffQuery.Where(c => c.ShopID == WebCookie.ShopID);
            ViewBag.ShopStaffID = new SelectList(ShopStaffQuery, "ShopStaffID", "StaffName", selectedShopStaffID);
        }
        //Get information classification tree structure drop-down list
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 3600, VaryByParam = "*")]  ///缓存3600秒(内存)
        public JsonResult GetNodeOfInfoCates(string PrarentsID)  // 所以节点 :  PrarentsID="0"
        { 
            List<InfoCate> infoCates = db.InfoCates.Where(c=>c.ShopID==WebCookie.ShopID).ToList();
            GetTreeJsonByTable(infoCates, PrarentsID);
            string strResult = result.ToString();
            return Json(strResult, "text/json", Encoding.Unicode, JsonRequestBehavior.AllowGet);

        }
        #region
        /// <summary>
        /// Generate a Json tree structure based on the DataTable
        /// </summary>

        StringBuilder result = new StringBuilder();
        StringBuilder sb = new StringBuilder();
        private void GetTreeJsonByTable(List<InfoCate> InfoCates1, string ParentsID)
        {
            TreeView TreeView1 = new TreeView();
            result.Append(sb);
            sb.Clear();
            if (InfoCates1.Count<InfoCate>() > 0)
            {
                sb.Append("\n[");

                var InfoCates2 = InfoCates1.Where(c => c.PrarentsID == ParentsID).OrderByDescending(p => p.OperatedDate);
                if (InfoCates2.Count<InfoCate>() > 0)
                {
                    foreach (var row in InfoCates2)
                    {
                        
                        sb.Append("{\"nodeid\":\"" + row.InfoCateID + "\",\"text\":\"" + row.InfoCateName + "\",\"custom\":\"" + row.PrarentsID  + "\"");
                        
                        var InfoCates3 = db.InfoCates.Where(c => c.PrarentsID == row.InfoCateID);
                        if (InfoCates3.Count<InfoCate>() > 0)
                        {
                            sb.Append(",\"nodes\":");
                            GetTreeJsonByTable(InfoCates3.ToList(), row.InfoCateID);
                            result.Append(sb);
                            sb.Clear();
                        }
                        result.Append(sb);
                        sb.Clear();
                        sb.Append("},");
                    }
                    sb = sb.Remove(sb.Length - 1, 1);
                }
                sb.Append("]");
                result.Append(sb);
                sb.Clear();
            }
        }

        #endregion

        //获取 搜索優化下拉列表 by SeoKeyWord
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 60, VaryByParam = "*")]  ///缓存3600秒(内存)
        public JsonResult GetNodeOfSeoExtands(string SeoKeyWord,string ParentsSeoExtandID)  // 所以节点 :  PrarentsID="0"
        {
            SeoKeyWord = string.IsNullOrEmpty(SeoKeyWord) ? string.Empty :SeoKeyWord.Trim() ; 

            ParentsSeoExtandID = string.IsNullOrEmpty(ParentsSeoExtandID) ? "0" : ParentsSeoExtandID;
            SeoKeyWord = ParentsSeoExtandID == "0" ? string.Empty : SeoKeyWord; //bug 防止在 全部列出的情况下,同时又过滤关键词
            List<SeoExtand> seoExtands = db.SeoExtands.Where(c =>c.SeoKeyWord.Contains(SeoKeyWord) && c.ShopID == WebCookie.ShopID).OrderBy(c=>c.TopRank50).ToList();
             
            GetSeoExtandTreeJsonByTable(seoExtands, ParentsSeoExtandID); //如果入参ParentsSeoExtandID=0,则从根目录起列出
            string strResult = SeoResult.ToString();
            return Json(strResult, "text/json", Encoding.Unicode, JsonRequestBehavior.AllowGet);
        }
        #region
        /// <summary>
        /// Generate a Json tree structure based on - Search Optimization drop-down - Table DataTable
        /// </summary>

        StringBuilder SeoResult = new StringBuilder();
        StringBuilder SeoExtandSb = new StringBuilder();
        private void GetSeoExtandTreeJsonByTable(List<SeoExtand> seoExtands1,string ParentsSeoExtandID)
        {
            TreeView TreeView1 = new TreeView();
            SeoResult.Append(SeoExtandSb);
            SeoExtandSb.Clear();
            if (seoExtands1.Count<SeoExtand>() > 0)
            {
                SeoExtandSb.Append("\n[");

                var seoExtands2 = seoExtands1.Where(c => c.ParentsSeoExtandID==ParentsSeoExtandID); 
                if (seoExtands2.Count<SeoExtand>() > 0)
                {
                    foreach (var row in seoExtands2)
                    {

                        SeoExtandSb.Append("{\"nodeid\":\"" + row.SeoExtandID + "\",\"text\":\"" + row.SeoKeyWord.Replace("\"","") + "\",\"custom\":\"" + row.ParentsSeoExtandID +  "\"");
                         
                        var seoExtands3 = db.SeoExtands.Where(c => c.ParentsSeoExtandID == row.SeoExtandID).ToList();
                        if (seoExtands3.Count<SeoExtand>() > 0)
                        {
                            SeoExtandSb.Append(",\"nodes\":");
                            GetSeoExtandTreeJsonByTable(seoExtands3, row.SeoExtandID);
                            SeoResult.Append(SeoExtandSb);
                            SeoExtandSb.Clear();
                        }
                        SeoResult.Append(SeoExtandSb);
                        SeoExtandSb.Clear();
                        SeoExtandSb.Append("},");
                    }
                    SeoExtandSb = SeoExtandSb.Remove(SeoExtandSb.Length - 1, 1);
                }
                SeoExtandSb.Append("]");
                SeoResult.Append(SeoExtandSb);
                SeoExtandSb.Clear();
            }
        }

        #endregion

        /// <summary>
        /// retrive 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpGet]
        public ActionResult SeoHtmlContextAdd(string SeoExtandID)
        {
            SeoExtand seoExtand = new SeoExtand();
            if (!string.IsNullOrEmpty(SeoExtandID))
            {
                ViewBag.TempSeoExtandID = SeoExtandID;
                ViewBag.SeoExtandID = SeoExtandID;
                seoExtand = db.SeoExtands.Find(SeoExtandID);
                ViewBag.ParentsSeoExtandID = seoExtand.ParentsSeoExtandID;
                ViewBag.SeoKeyWord = Lang.Views_GeneralUI_RootKeyWord;
                ViewBag.SeoHtmlContext = seoExtand.SeoHtmlContext;
                if (seoExtand != null && seoExtand.ParentsSeoExtandID !="0")
                {
                    ViewBag.SeoKeyWord = db.SeoExtands.Find(seoExtand.ParentsSeoExtandID).SeoKeyWord;
                } 
                //list relate file
                ViewBag.UploadItemList = db.UploadItems.Where(s => s.TargetTalbeKeyID.Contains(SeoExtandID)).Count()>0 ? db.UploadItems.Where(s => s.TargetTalbeKeyID.Contains(SeoExtandID)).ToList():null;
            }
            else
            {
                seoExtand.IsSeoHtmlContext = true;
                ViewBag.TempSeoExtandID = "XXXyyy" + Guid.NewGuid().ToString("N"); //格式:e0a953c3ee6040eaa9fae2b667060e09   
                Session["TempSeoExtandID"] = ViewBag.TempSeoExtandID; 
            }
             
            return View(seoExtand); 
        }
         
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpPost]
        public JsonResult SeoHtmlContextAdd(string SeoExtandID ,string SeoKeyWord , string ParentsSeoExtandID,bool IsSeoHtmlContext, string SeoHtmlContext)
        {
            //Thread.Sleep(3000); //test
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            SeoExtand seoExtand = new SeoExtand();
            if (string.IsNullOrEmpty(SeoExtandID))
            { 
                seoExtand.SeoExtandID = db.GetTableIdentityID("SeoEX", "seoExtand", 9);
                seoExtand.SeoKeyWord = SeoKeyWord;
                seoExtand.ParentsSeoExtandID = ParentsSeoExtandID;
                seoExtand.IsSeoHtmlContext = IsSeoHtmlContext;
                seoExtand.SeoHtmlContext = HttpUtility.UrlDecode(SeoHtmlContext, Encoding.UTF8); ;
                //--------------
                seoExtand.ShopID = WebCookie.ShopID;
                seoExtand.UserId = User.Identity.GetUserId();
                seoExtand.OperatedUserName = User.Identity.Name;
                seoExtand.OperatedDate = DateTime.Now;
                try
                {
                    db.SeoExtands.Add(seoExtand);
                    db.SaveChanges();
                    AdditionalForUpload AdditionalForUpload1 = new AdditionalForUpload(); 

                    if (ViewBag.TempSeoExtandID == null)
                    {
                        ViewBag.TempSeoExtandID = Session["TempSeoExtandID"].ToString();
                    }
                    AdditionalForUpload1.AlterTempTargetTalbeKeyID(ViewBag.TempSeoExtandID, seoExtand.SeoExtandID);

                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message =  Lang.Views_GeneralUI_AddNewOk;
                    return Json(ModalDialogView1);
                }
                catch (Exception e)
                {
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message =string.Format( "{0}\n\n{1}" ,Lang.GeneralUI_Fail, e.Message) ;
                    return Json(ModalDialogView1);
                }
            }
            else
            { 
                seoExtand.SeoExtandID = SeoExtandID ;
                seoExtand.SeoKeyWord = SeoKeyWord;
                seoExtand.ParentsSeoExtandID = ParentsSeoExtandID;
                seoExtand.IsSeoHtmlContext = IsSeoHtmlContext;
                seoExtand.SeoHtmlContext = HttpUtility.UrlDecode(SeoHtmlContext, Encoding.UTF8); ;
                //--------------
                seoExtand.ShopID = WebCookie.ShopID;
                seoExtand.UserId = User.Identity.GetUserId();
                seoExtand.OperatedUserName = User.Identity.Name;
                seoExtand.OperatedDate = DateTime.Now;
                try
                {
                    db.Entry(seoExtand).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message = Lang.Info_SeoHtmlContextAdd_Message_UpdateSucc;
                    return Json(ModalDialogView1);
                }
                catch (Exception e)
                {
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message = Lang.Info_SeoHtmlContextAdd_Message_UpdateFail + "\n\n" + e.Message; ;
                    return Json(ModalDialogView1);
                }
            } 
        }

        /// <summary>
        /// delete invalid IP
        /// </summary> 
        /// <returns></returns>
         // POST: Mgr/Info/ClearInvalidData/5
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpPost]
        public ActionResult ClearInvalidData()
        {
            string msg = string.Format("<br/><h3>{0}</h3>",Lang.Info_ClearInvalidData_msg);
            ModalDialogView modalDialogView = new ModalDialogView { MsgCode = "1", Message = HttpUtility.UrlDecode(msg, Encoding.UTF8) };

            var sourceStatistics = from s in db.SourceStatistics
                                   select s; 
                sourceStatistics = sourceStatistics.Where(s => s.Duration < 1);
            List<SourceStatistic> List1 = new List<SourceStatistic>(); 
            try
            {
                sourceStatistics.ToList().ForEach(c => c.Status = SourceStatisticStatus.InValid);
                // ref :https://docs.microsoft.com/zh-tw/ef/ef6/saving/concurrency     
                // Entities may have been modified or deleted since entities were loaded. See http://go.microsoft.com/fwlink/?LinkId=472540
                bool saveFailed;
                do
                {
                    saveFailed = false;

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;

                        // Update the values of the entity that failed to save from the store
                        ex.Entries.Single().Reload();
                    }

                } while (saveFailed);

                foreach (var item in sourceStatistics)
                { 
                    string strSourceStatisticsID = item.SourceStatisticsID.ToString();
                    ////del UserFinanceItem
                    UserFinanceItem userFinanceItem = db.UserFinanceItems.Where(c=>c.TblKeyId.Contains(strSourceStatisticsID)).FirstOrDefault();
                    if(userFinanceItem !=null)
                    {
                        ReverseCalcFinanceItem(userFinanceItem.UserFinanceItemID);
                    } 
                }  
                return Json(modalDialogView);
            }
            catch(Exception e)
            {
                modalDialogView = new ModalDialogView { MsgCode = "0", Message = string.Format("<br/><h3>{0}{1}</h3>", Lang.Info_ClearInvalidData_msgError ,e.Message) } ;
                return Json(modalDialogView);
            }
        } 
        // POST: Mgr/Info/Delete/5
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpPost]
        public ActionResult DeleteUploadItem(string UploadItemId)
        {
            string msg = Lang.Info_DeleteUploadItem_msg1 + UploadItemId;
            ModalDialogView modalDialogView = new ModalDialogView { MsgCode = "1", Message = HttpUtility.UrlDecode(msg, Encoding.UTF8) };

            try
            {
                Ishop.Models.UploadItem.UploadItem uploadItem = new Ishop.Models.UploadItem.UploadItem(); 
                 
                uploadItem = db.UploadItems.Where(s=>s.Url.Contains(UploadItemId) || s.UploadItemId.Contains(UploadItemId)).FirstOrDefault();
                
                db.UploadItems.Remove(uploadItem);
                db.SaveChanges();
                 
                if(System.IO.File.Exists(Server.MapPath(uploadItem.Url)))
                {
                    System.IO.File.Delete(Server.MapPath(uploadItem.Url));
                }
                else
                {
                    modalDialogView.Message += Lang.Info_DeleteUploadItem_msg2;
                }
                //check other Size 
                var ListPictureSize = EnumHelper.GetSelectList<PictureSize>().ToList();
                //delete file
                foreach (var item in ListPictureSize)
                {
                    string paht1 = Server.MapPath(uploadItem.Url + item.Value + uploadItem.FileExt) ;
                    if (System.IO.File.Exists(paht1))
                    {
                        System.IO.File.Delete(paht1);
                    }
                }
                return Json(modalDialogView);
            }
            catch
            {
                modalDialogView = new ModalDialogView { MsgCode = "0", Message = Lang.Info_DeleteUploadItem_msg3 + UploadItemId };
                return Json(modalDialogView);
            }
        }
        //Get keyword rich text HTML5 template
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]  ///缓存3600秒(内存)
        public JsonResult RetriveSeoExtandNodeHtml5(string SeoExtandID)  // 所以节点 :  PrarentsID="0"
        {
            ModalDialogView modalDialogView = new ModalDialogView { MsgCode = "0", Message = Lang.Info_RetriveSeoExtandNodeHtml5_msg };
            if (string.IsNullOrEmpty(SeoExtandID))
            {
                return Json(modalDialogView);
            } 
            SeoExtand seoExtand = db.SeoExtands.Find(SeoExtandID);
            modalDialogView.MsgCode = "1";
            modalDialogView.Message = seoExtand.SeoHtmlContext;
            return Json(modalDialogView, "text/json", Encoding.Unicode, JsonRequestBehavior.AllowGet);
        }

        
        // GET: Mgr/Info
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpGet]
        public ActionResult InfoIPstatitics(string sortOrder, string currentFilter, string searchString, string StartDate, string EndDate, int? page)
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

            var sourceStatistics = from s in db.SourceStatistics
                              select s;

            if (!String.IsNullOrEmpty(searchString))
            { 
                sourceStatistics = sourceStatistics.Where(s => s.TableKeyID.Contains(searchString) 
                                                                                     || s.IP.Contains(searchString)
                                                                                     || s.SourceArea.Contains(searchString)
                                                                                     || s.RecommUserId.Contains(searchString)
                                                                                     || s.OpenID.Contains(searchString)
                                                                                     || s.UserId.Contains(searchString)
                                                                                     || s.Title.Contains(searchString)); 
            }

            //FitlerStatus = 1
            //sourceStatistics = sourceStatistics.Where(s => s.Status == SourceStatisticStatus.IsValid);  //!= SourceStatisticStatus.InValid

            //DaySpan filter 
            if (StartDate != EndDate)
            {
                ViewBag.CurrentStartDate = StartDate;
                ViewBag.CurrentEndDate = EndDate;
                DateTime pStartDate = DateTime.Parse(StartDate);
                DateTime pEndDate = DateTime.Parse(EndDate);
                sourceStatistics = sourceStatistics.Where(s => s.CreatedDate > pStartDate && s.CreatedDate < pEndDate);
            } 
            //Filter IP that LoadTime >0 (as use the Rule of SourceStatisticStatus ,so not to use this conditions to filter)
            //sourceStatistics = sourceStatistics.Where(s => s.LoadTime > 0 ); 

            //Shop Filter
            sourceStatistics = sourceStatistics.Where(s => s.ShopID == WebCookie.ShopID);
             
            switch (sortOrder)
            {
                case "Date":
                    sourceStatistics = sourceStatistics.OrderBy(s => s.LastUpdateDate);
                    break;
                case "date_desc":
                    sourceStatistics = sourceStatistics.OrderByDescending(s => s.LastUpdateDate);
                    break;
                default:  // Name ascending 
                    sourceStatistics = sourceStatistics.OrderByDescending(s => s.CreatedDate);
                    break;
            } 
            int pageSize = 30;
            int pageNumber = (page ?? 1); 
            return View(sourceStatistics.ToPagedList(pageNumber, pageSize));
        }

        [Authorize]
        public ActionResult SourceStatisticByRecomm( string StartDate, string EndDate, int? page)
        { 
            string UserId = User.Identity.GetUserId(); 
            var sourceStatistics = from s in db.SourceStatistics.Where(s => s.RecommUserId == UserId)   
                               select s; 
            ViewBag.UserViewsCount = sourceStatistics.Count(); 
            int pageSize = 100;
            int pageNumber = (page ?? 1); 
            return View(sourceStatistics.ToPagedList(pageNumber, pageSize)); 
        }

        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpPost]
        public JsonResult SeoExtandDelete(string SeoExtandID)
        {
            string msg = string.Format("<br/><h3>{0}</h3>", Lang.Views_GeneralUI_DeleteOK);
            ModalDialogView modalDialogView = new ModalDialogView { MsgCode = "1", Message = HttpUtility.UrlDecode(msg, Encoding.UTF8) };

            SeoExtand seoExtand = db.SeoExtands.Find(SeoExtandID);
                                    
            try
            {
                db.SeoExtands.Remove(seoExtand);
                db.SaveChanges();
                return Json(modalDialogView);
            }
            catch (Exception e)
            {
                modalDialogView = new ModalDialogView { MsgCode = "0", Message = string.Format("<br/><h3>{0}{1}</h3>", Lang.Info_ClearInvalidData_msgError, e.Message) };
                return Json(modalDialogView);
            }
        }
    }
}
