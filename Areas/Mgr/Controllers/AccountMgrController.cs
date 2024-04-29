using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using Ishop.Context;
using Ishop.Areas.Mgr.ModelView;
using Ishop.Models.PubDataModal;
using Ishop.Models.ProductMgr;
using Ishop.Areas.Mgr.Models;
using Ishop.AppCode.Utilities;
using System.Security.Cryptography.X509Certificates;
using Ishop.Utilities;
using LanguageResource;

namespace Ishop.Areas.Mgr.Controllers
{
    [Authorize]
    public class AccountMgrController : Controller
    {
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
        // GET: Mgr/AccountMgr
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
       
        private void AccountWebSiteDropDownList(object selectedWebSite = null)
        {
            var AccountWebSiteQuery = from d in db.AccountWebSites
                                      orderby d.SiteName
                                   select d;
            ViewBag.WebSite = new SelectList(AccountWebSiteQuery, "WebSite", "SiteName", selectedWebSite);
        }
        private void PopulateAssignedToUser(string AssignedToUserID)
        {
            var allShopStaffs = db.ShopStaffs.Where(c => c.ShopID == WebCookie.ShopID);
            var viewModel = new List<ShopStaffView>();

            var assignedToUserIDs = new List<string>();
            if (!string.IsNullOrEmpty(AssignedToUserID))
            {
                assignedToUserIDs = AssignedToUserID.Split(',').ToList(); 
            }

            foreach (var shopStaff in allShopStaffs)
            { 
               
                if (db.Users.Find(shopStaff.UserId) != null)
                { 
                    viewModel.Add(new ShopStaffView
                    {
                        UserName = shopStaff.UserId,
                        StaffName = shopStaff.StaffName,
                        Assigned = assignedToUserIDs.Contains(db.Users.Find(shopStaff.UserId).UserName)
                    });
                }
               
            }
            ViewBag.ShopStaffs = viewModel;
        }
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        [HttpGet]
        public ActionResult AccountMgrAddOrUpd(string AccountMgrID, string CerPassword)
        {
            //检查是否有证书密码会话存在，否则重定向提交 
            if (string.IsNullOrEmpty(CerPassword))  // && mvcCommeBase.ChkCerPassword() == false 不存在会话和Cerpassword则跳转。
            {
                string ReturnCerPassUrl = "/Mgr/AccountMgr/CerPassword?ReturnCerPassUrl=/Mgr/AccountMgr/AccountMgrAddOrUpd?AccountMgrID=" + AccountMgrID;
                Response.Redirect(ReturnCerPassUrl);
            }
            else
            {
                ViewBag.CurrentCerPassword = CerPassword; //important!
                CerPassword = EncryptHelper.Decrypt(CerPassword);
            }
            if (!string.IsNullOrEmpty(AccountMgrID)) // 不等于null
            {
                // 返回 活动明细  
                ViewBag.CurrentAccountMgrID = AccountMgrID;
                 
                var accountMgrs = db.AccountMgrs.Find(AccountMgrID);

                if (accountMgrs == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //具有一下身份才能浏览推广帐号的详细注册资料 
                //1、店长（StoreAdmin） 
                //2、推广帐号创建者
                if ((CheckIsInRole("StoreAdmin") == true || accountMgrs.CreatedByUserID == User.Identity.Name) && accountMgrs.ShopID == WebCookie.ShopID)
                {

                    ViewBag.ViewDeails = true;
                }
                else
                {
                    ViewBag.ViewDeails = false;
                }
                AccountWebSiteDropDownList(accountMgrs.WebSite);
                PopulateAssignedToUser(accountMgrs.AssignedToUserID); //计算选定项

                //数据加密-begin : Password/密码1, Password/密码2 PrivacyQuestion/密码问题 PrivacyAnswer/密码答案 
                if (accountMgrs.IsCer)
                {
                    string cerPath = Server.MapPath(db.Shops.Find(WebCookie.ShopID).cerPath);  //获取店铺证书的位置  
                    //证书加密 
                    accountMgrs.Password = RSAEncryptHelper.RSADecrypt(cerPath, accountMgrs.Password, CerPassword);
                    accountMgrs.Password2 = RSAEncryptHelper.RSADecrypt(cerPath, accountMgrs.Password2, CerPassword);
                    accountMgrs.PrivacyAnswer = RSAEncryptHelper.RSADecrypt(cerPath, accountMgrs.PrivacyAnswer, CerPassword);
                    accountMgrs.PrivacyQuestion = RSAEncryptHelper.RSADecrypt(cerPath, accountMgrs.PrivacyQuestion, CerPassword);
                }
                else
                {
                    accountMgrs.Password = EncryptHelper.Decrypt(accountMgrs.Password);
                    accountMgrs.Password2 = EncryptHelper.Decrypt(accountMgrs.Password2);
                    accountMgrs.PrivacyAnswer = EncryptHelper.Decrypt(accountMgrs.PrivacyAnswer);
                    accountMgrs.PrivacyQuestion = EncryptHelper.Decrypt(accountMgrs.PrivacyQuestion);
                    
                }
                return View(accountMgrs);
            }
            else
            { 
                ViewBag.ViewDeails = true; // 新增情况为展示 明细的 textbox
                AccountWebSiteDropDownList(null); // null : 不选定
                PopulateAssignedToUser(null);  // null : 不选定
                return View();
            }
        }
        [HttpPost]
        [Authorize(Roles = "StoreAdmin,StoreProductAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        public ActionResult AccountMgrAddOrUpd(string AccountMgrID,string CurrentCerPassword, string[] selectedAssignedToUserID, [Bind(Include = "WebSite,SiteName,LoginID,Password,Password2, IsCer,LoginEmail,ScurityEmail,Mobile,NickName,PrivacyQuestion,PrivacyAnswer,Remarks,CreatedByUserID")]AccountMgr accountMgr)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            AccountWebSite AccountWebSite1 = new AccountWebSite();
            if (AccountMgrID == null)
            {
                accountMgr.AccountMgrID = db.GetTableIdentityID("Acc", "AccountMgr",5);
                //数据加密-begin : Password/密码1, Password/密码2 PrivacyQuestion/密码问题 PrivacyAnswer/密码答案 Remarks/备注
                if(accountMgr.IsCer)
                {
                    string cerPath = Server.MapPath(db.Shops.Find(WebCookie.ShopID).cerPath);  //获取店铺证书的位置
                    string CerPassword = EncryptHelper.Decrypt(CurrentCerPassword); 
                    //证书加密 
                    accountMgr.Password = RSAEncryptHelper.RSAEncrypt(cerPath,accountMgr.Password, CerPassword);
                    accountMgr.Password2 = RSAEncryptHelper.RSAEncrypt(cerPath, accountMgr.Password2, CerPassword);
                    accountMgr.PrivacyAnswer = RSAEncryptHelper.RSAEncrypt(cerPath, accountMgr.PrivacyAnswer, CerPassword);
                    accountMgr.PrivacyQuestion = RSAEncryptHelper.RSAEncrypt(cerPath, accountMgr.PrivacyQuestion, CerPassword); 
                }
                else
                {
                    accountMgr.Password = EncryptHelper.Encrypt(accountMgr.Password);
                    accountMgr.Password2 = EncryptHelper.Encrypt(accountMgr.Password2);
                    accountMgr.PrivacyAnswer = EncryptHelper.Encrypt(accountMgr.PrivacyAnswer);
                    accountMgr.PrivacyQuestion = EncryptHelper.Encrypt(accountMgr.PrivacyQuestion);
                }
                //数据加密-end
                //获取 WebSite值  DropDownList的SelectValue = WebSite  ID = "SiteName"
                AccountWebSite1 = db.AccountWebSites.Where(c => c.WebSite == accountMgr.WebSite).FirstOrDefault();
                //处理更新操作 
                accountMgr.WebSite = AccountWebSite1.WebSite;
                accountMgr.SiteName = AccountWebSite1.SiteName;
                //分配使用用户
                accountMgr.AssignedToUserID = UpdateAccountMgrAssignedToUserID(selectedAssignedToUserID);

                accountMgr.ShopID = WebCookie.ShopID;
                accountMgr.CreatedByUserID = User.Identity.Name;
                accountMgr.OperatedUserName = User.Identity.Name;
                accountMgr.OperatedDate = DateTime.Now; 
                try
                { 
                    db.AccountMgrs.Add(accountMgr);
                    db.SaveChanges();
                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message = Lang.Views_GeneralUI_AddNewOk;
                    return Json(ModalDialogView1);
                }
               catch (Exception e)
                {
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message = string.Format("{0}\n\n{1}",Lang.Views_GeneralUI_InvalidDataInput, e.Message); 
                    return Json(ModalDialogView1);
                }
            }
            else
            {
                accountMgr.AccountMgrID = AccountMgrID;
                //获取 WebSite值  DropDownList的SelectValue = WebSite  ID = "SiteName"
                AccountWebSite1 = db.AccountWebSites.Where(c => c.WebSite == accountMgr.WebSite).FirstOrDefault();
                //处理更新操作 
                accountMgr.WebSite = AccountWebSite1.WebSite;
                accountMgr.SiteName = AccountWebSite1.SiteName;
                //分配使用用户
                accountMgr.AssignedToUserID = UpdateAccountMgrAssignedToUserID(selectedAssignedToUserID);

                accountMgr.OperatedUserName = User.Identity.Name;
                accountMgr.OperatedDate = DateTime.Now;
                accountMgr.ShopID = WebCookie.ShopID;
                 
                //数据加密-begin : Password/密码1, Password/密码2 PrivacyQuestion/密码问题 PrivacyAnswer/密码答案 Remarks/备注
                if (accountMgr.IsCer)
                {
                    string cerPath = Server.MapPath(db.Shops.Find(WebCookie.ShopID).cerPath);  //获取店铺证书的位置
                    string CerPassword = EncryptHelper.Decrypt(CurrentCerPassword);
                    //证书加密 
                    accountMgr.Password = RSAEncryptHelper.RSAEncrypt(cerPath, accountMgr.Password, CerPassword);
                    accountMgr.Password2 = RSAEncryptHelper.RSAEncrypt(cerPath, accountMgr.Password2, CerPassword);
                    accountMgr.PrivacyAnswer = RSAEncryptHelper.RSAEncrypt(cerPath, accountMgr.PrivacyAnswer, CerPassword);
                    accountMgr.PrivacyQuestion = RSAEncryptHelper.RSAEncrypt(cerPath, accountMgr.PrivacyQuestion, CerPassword);
                }
                else
                {
                    accountMgr.Password = EncryptHelper.Encrypt(accountMgr.Password);
                    accountMgr.Password2 = EncryptHelper.Encrypt(accountMgr.Password2);
                    accountMgr.PrivacyAnswer = EncryptHelper.Encrypt(accountMgr.PrivacyAnswer);
                    accountMgr.PrivacyQuestion = EncryptHelper.Encrypt(accountMgr.PrivacyQuestion);
                }

                if (ModelState.IsValid)
                {
                    //UpdateModel<AccountMgr>(accountMgr); 使用UpdateModal 表单方式则,不用参数绑定类对象方式 
                    db.Entry(accountMgr).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message = Lang.Views_GeneralUI_UpdateOK;
                    return Json(ModalDialogView1);
                }
                else
                {
                    ModalDialogView1.MsgCode = "0";
                    ModalDialogView1.Message =Lang.Views_GeneralUI_UpdateFail;
                    return Json(ModalDialogView1);
                }

            }
        }
        private string UpdateAccountMgrAssignedToUserID(string[] selectedAssignedToUserID)
        {
            string returnAssignedToUserID = "";
            if (selectedAssignedToUserID == null)
            {   
                return string.Empty;
            }

            var selectedAssignedToUserIDs = new HashSet<string>(selectedAssignedToUserID); 

            foreach (string AssignedToUserName in selectedAssignedToUserIDs)
            {
                returnAssignedToUserID += AssignedToUserName + ",";
            }
            return returnAssignedToUserID.TrimEnd(',');
        }
        [Authorize]
        [HttpGet]
        public ActionResult AccountMgrList(string sortOrder, string currentFilter, string searchString,string WebSite, int? page)
        { 
            AccountWebSiteDropDownList(null); // null : 不选定

            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            //证书位置
            ViewBag.CurrentcerPath = Server.MapPath(db.Shops.Find(WebCookie.ShopID).cerPath);

            var accountMgrs = from s in db.AccountMgrs
                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                accountMgrs = accountMgrs.Where(s => s.SiteName.Contains(searchString)|| s.LoginID.Contains(searchString) || s.AssignedToUserID.Contains(searchString)|| s.NickName.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(WebSite))
            {
                accountMgrs = accountMgrs.Where(s => s.WebSite.Contains(WebSite));
            }
            ////IsInRole 判断是否店长角色(StoreAdmin)，则列出全店的推广帐号，否则 过滤用户，只列出分配用户使用的推广帐号
            //这里要改一下： 加入 if InRole 

            //具有一下身份才能浏览推广帐号的详细注册资料

            //1、店长（StoreAdmin）

            //2、推广帐号创建者

            if (CheckIsInRole("StoreAdmin") == true)
            {
                //如果店长,则列出所有
                accountMgrs = accountMgrs.Where(s => s.ShopID == WebCookie.ShopID);
            }
            else
            {
                //创建时分配给自己(创建者的)
                accountMgrs = accountMgrs.Where(s => s.AssignedToUserID.Contains(User.Identity.Name));
            }
            //店铺过滤
            accountMgrs = accountMgrs.Where(s => s.ShopID == WebCookie.ShopID);

            switch (sortOrder)
            {
                case "Date":
                    accountMgrs = accountMgrs.OrderByDescending(s => s.OperatedDate);
                    break;
                case "date_desc":
                    accountMgrs = accountMgrs.OrderBy(s => s.OperatedDate);
                    break;
                default:  // Name ascending 
                    accountMgrs = accountMgrs.OrderBy(s => s.OperatedDate);
                    break;
            }

            int pageSize = 50;
            int pageNumber = (page ?? 1);

            return View(accountMgrs.ToPagedList(pageNumber, pageSize));
        }
        private bool CheckIsInRole(string roleName)
        {
            string UserId = User.Identity.GetUserId();
            bool A;
            try
            {
                A = UserManager.IsInRole(UserId, roleName);
            }
            catch
            {
                A = false;
            }
            // 如果超级管理员 属于例外情况 
            //if (UserManager.IsInRole(UserId, "Supervisor"))
            //{
            //    A = true;
            //}
            return A;
        }

        /// <summary>
        /// 证书密码重定向
        /// </summary>
        /// <param name="ReturnCerPassUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "StoreAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        public ActionResult CerPassword(string ReturnCerPassUrl)
        {
            CerPasswordModalView CerPasswordModalView1 = new CerPasswordModalView();
            CerPasswordModalView1.ReturnCerPassUrl = ReturnCerPassUrl; 
            return View();
        }
        /// <summary>
        /// 把提交的密码保存在会话中，以用于证书加密和解密-RSAEncryptHelper
        /// </summary>
        /// <param name="ReturnCerPassUrl"></param>
        /// <param name="CerPasswordModalView1"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "StoreAdmin,StoreBusinessPromotion,Supervisor,Admins")]
        public ActionResult CerPassword(string ReturnCerPassUrl,[Bind(Include = "CerPassword,ReturnCerPassUrl")]CerPasswordModalView CerPasswordModalView1)
        {
            string cerPath = Server.MapPath(db.Shops.Find(WebCookie.ShopID).cerPath);
            
            X509Certificate2 c1 = DataCertificate.GetCertificateFromPfxFile(cerPath, CerPasswordModalView1.CerPassword);
            if(c1 != null)
            {
                Response.Redirect(ReturnCerPassUrl + "&CerPassword=" + EncryptHelper.Encrypt(CerPasswordModalView1.CerPassword));
            }
            else
            {
                ViewBag.Message = Lang.Views_GeneralUI_PasswordIswrong;
            } 
            return View(); 
        }

        public string SwitchDescrypt(string Encryper,string CurrentCerPassword,bool IsCer)
        {
            string CerPassword = EncryptHelper.Decrypt(CurrentCerPassword);
            string ReturnText;
            if (IsCer)
            {
                string cerPath = Server.MapPath(db.Shops.Find(WebCookie.ShopID).cerPath);  //获取店铺证书的位置
                ReturnText = RSAEncryptHelper.RSADecrypt(cerPath, Encryper, CerPassword);

                return ReturnText;
            }
            else
            {
                ReturnText = EncryptHelper.Encrypt(Encryper);
                return ReturnText;
            }
        }
    }

}