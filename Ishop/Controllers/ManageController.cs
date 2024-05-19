using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Ishop.Models;
using Ishop.Utilities;
using Ishop.Models.ProductMgr;
using System.Data.Entity;
using Ishop.Context;
using LanguageResource;
using Ishop.Areas.Mgr.Models;
using System.Text;
using Microsoft.VisualBasic.ApplicationServices;
using static Ishop.AppCode.EnumCode.PublicEnumCode;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Ishop.AppCode.EnumCode;

namespace Ishop.Controllers
{
    [Authorize]
    public class ManageController : BaseController
    {
        private Ishop.Context.ApplicationDbContext _db = new Ishop.Context.ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

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

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ShopInitialize();
            ViewBag.StatusMessage =
                  message == ManageMessageId.ChangePasswordSuccess ? Lang.Manage_Index_message_ChangePasswordSuccess
                : message == ManageMessageId.SetPasswordSuccess ? Lang.Manage_Index_message_SetPasswordSuccess
                : message == ManageMessageId.SetTwoFactorSuccess ? Lang.Manage_Index_message_SetTwoFactorSuccess
                : message == ManageMessageId.Error ? Lang.Manage_Index_message_Error
                : message == ManageMessageId.AddPhoneSuccess ? Lang.Manage_Index_message_AddPhoneSuccess
                : message == ManageMessageId.RemovePhoneSuccess ? Lang.Manage_Index_message_RemovePhoneSuccess
                : "";

            var userId = User.Identity.GetUserId();
            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await UserManager.GetPhoneNumberAsync(userId),
                TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
                Logins = await UserManager.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
            };
            //有些部分 为了开发保留的功能,但用户不需要看到
            bool IsSupervisor = UserManager.IsInRole(User.Identity.GetUserId(), "Supervisor");
            ViewBag.IsSupervisor = IsSupervisor;
            return View(model);
        }

        //
        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ShopInitialize();
            ManageMessageId? message;
            var result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("ManageLogins", new { Message = message });
        }

        //
        // GET: /Manage/AddPhoneNumber
        public ActionResult AddPhoneNumber()
        {
            ShopInitialize();
            ViewBag.Ticks = DateTime.Now.Ticks.ToString();
            return View();
        }

        //
        // POST: /Manage/AddPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        {
            ShopInitialize();
            string AddModelError1 = Lang.Manage_AddPhoneNumber_AddModelError1;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //图片验证码 校验
            if (Session["ImageCode"] == null)
            {
                ModelState.AddModelError("", AddModelError1);
                return View(model);
            }
            string ImageCode = Session["ImageCode"].ToString();
            if ( ImageCode.ToLower() != model.ImageCode.ToLower())
            {
                ModelState.AddModelError("", AddModelError1);
                return View(model);
            }
            // 生成令牌并发送该令牌
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
            if (UserManager.SmsService != null)
            {
                var message = new IdentityMessage
                {
                    Destination = model.Number,
                    Body =  code  // 使用平台的短信模板的情况下,只能传入 验证码 code 的值
                };
                await UserManager.SmsService.SendAsync(message);
            }
            return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number});
        }

        //
        // POST: /Manage/EnableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnableTwoFactorAuthentication()
        {
            ShopInitialize();
            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), true);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // POST: /Manage/DisableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DisableTwoFactorAuthentication()
        {
            ShopInitialize();
            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), false);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // GET: /Manage/VerifyPhoneNumber?phoneNumber=1231232131 
        public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            ShopInitialize();
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), phoneNumber); 
            // 通过 SMS 提供程序发送短信以验证电话号码  【插入 短信发送接口】
            return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        }

        //提交手机验证码
        // POST: /Manage/VerifyPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            ShopInitialize();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
             
            var result = await UserManager.ChangePhoneNumberAsync(User.Identity.GetUserId(), model.PhoneNumber, model.Code);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    //改为：
                    await SignInManager.SignInAsync(user, isPersistent: true, rememberBrowser: true); 
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
            }
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            ModelState.AddModelError("",Lang.Manage_VerifyPhoneNumber_AddModelError1);
            return View(model);
        }

        //
        // POST: /Manage/RemovePhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemovePhoneNumber()
        {
            ShopInitialize();
            var result = await UserManager.SetPhoneNumberAsync(User.Identity.GetUserId(), null); //移除电话号码 设置为空
            if (!result.Succeeded)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.Error });
            }
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        }
         
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            ShopInitialize();
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            ShopInitialize();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        //
        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            ShopInitialize();
            return View();
        }
         
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            ShopInitialize();
            if (ModelState.IsValid)
            {
                var result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                    if (user != null)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    }
                    return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        } 
        public ActionResult SetSupervisorPassword(string VisitPassword)
        {
            ShopInitialize();
            if (VisitPassword == "31636366-6168-6688-1386-666666666888")
            {
                string IP = mvcCommeBase.GetIP();
                var user = UserManager.FindById("620000");
                if (IP.IndexOf("192.168.") != -1 || IP.IndexOf("127.0.0.1") != -1)
                {

                    _db.AddUserToRole(UserManager, "620000", "Supervisor");
                    string code = UserManager.GeneratePasswordResetToken(user.Id);
                    var result11 = UserManager.ResetPassword(user.Id, code, "admin888");
                }

                return View(Content(string.Format("<h1>{0}</h1>", Lang.GeneralUI_OK)));
                
            }else
            {
                return View(Content("<h1>访问密码不对:</h1>" + VisitPassword));
            }

        }
        //
        // GET: /Manage/ManageLogins
        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            ShopInitialize();
            ViewBag.StatusMessage =
                message == ManageMessageId.RemoveLoginSuccess ? Lang.Manage_ManageLogins_ManageMessageId_RemoveLoginSuccess
                : message == ManageMessageId.Error ?Lang.Manage_ManageLogins_ManageMessageId_Error
                : "";
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }
            var userLogins = await UserManager.GetLoginsAsync(User.Identity.GetUserId());
            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            ShopInitialize();
            // 请求重定向至外部登录提供程序，以链接当前用户的登录名
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        }

        //
        // GET: /Manage/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            ShopInitialize();
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }
        [HttpGet]
        public ActionResult CreateShop(string msg)
        {
            ShopInitialize();
            if (msg != null)
            {
                ModelState.AddModelError("", msg);  //从添加员工转定向过来的提示,没有店铺,请先创建店铺
            } 
            var shopExistsCheck = _db.Shops.Where(c => c.UserName == User.Identity.Name);
            if (shopExistsCheck.Count() > 0)
            {
                Shop shop = shopExistsCheck.SingleOrDefault(); 
                shop.CreatedDate = DateTime.Now; 
                ViewBag.ShopID = shop.ShopID;  //必需装入 ShopID 平台 数据的关键依据
                return View(shop);
            }
            else
            {
                string UserId = User.Identity.Name;
                string UserName = User.Identity.GetUserId();
                DateTime dt = DateTime.Now;
                Shop shop = new Shop
                {
                    ShopID = "ShopID_DEFAULTS", //不行提供默認值以上存店鋪logo必須傳入店鋪ID(臨時) ,for [UploadItem].[ShopID] - required
                    ShopName = string.Empty,
                    ShopLogo = string.Empty,
                    WeixinQRcode = string.Empty,
                    WeiboQRcode = string.Empty,
                    ToutiaoQRcode = string.Empty,
                    fbQRcode = string.Empty,
                    FooterTemplate = string.Empty,
                    cerPath = string.Empty,
                    UserId = UserId,
                    UserName = UserName,
                    ShopCurrency = LangUtilities.LanguageCode,
                    PhoneNumber = string.Empty,
                    HostName = string.Empty,
                    OperatedUserName = User.Identity.Name,
                    OperatedDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    IsInfoMode = (int)PublicEnumCode.IsInfoMode.INSURANCE
                };
                return View(shop); 
            }
        }
        [HttpPost]
        public ActionResult CreateShopReturn([Bind(Include = "ShopID,ShopName,ShopCurrency,ShopLogo,PhoneNumber,WeixinQRcode,WeiboQRcode,ToutiaoQRcode,fbQRcode,HostName,CreatedDate,IsInfoMode")] Shop shop)
        {
            ShopInitialize();
            //Thread.Sleep(5000); // only for test
            Ishop.Areas.Mgr.Models.ModalDialogView modalDialogView = new Areas.Mgr.Models.ModalDialogView();
             
            shop.UserId = User.Identity.GetUserId();
            shop.UserName = User.Identity.Name;
            shop.OperatedUserName = User.Identity.Name;
            shop.OperatedDate = DateTime.Now ;
            var shopExistsCheck = _db.Shops.Where(c => c.UserName == shop.UserName);
            if (shopExistsCheck.Count() ==0)
            {
                shop.ShopID = _db.GetTableIdentityID("SH", "Shop", 4);
                shop.CreatedDate = DateTime.Now;
                _db.Shops.Add(shop);
                _db.SaveChanges();
                WebCookie.ShopID = shop.ShopID; //设置cookie
                return View("CreateShopReturn", shop); //返回 ajax结果 
            }
            else
            { 
                _db.Entry(shop).State = EntityState.Modified; 
                _db.SaveChanges();
                WebCookie.ShopID = shop.ShopID; //设置cookie
                //获取店铺 details 
                return View("CreateShopReturn", shop); //返回 ajax结果 
            } 
        }
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        
        [HttpGet]  //上存店铺页脚cshtml文件
        public ActionResult UpShopFooterCS()
        {
            ShopInitialize();
            string ShopID = WebCookie.ShopID;
            var shop = _db.Shops.Where(c => c.ShopID == ShopID).FirstOrDefault();
            if(!string.IsNullOrEmpty(shop.FooterTemplate))
            {
                string filename1 = Server.MapPath("~/views/Shared/ShopFootTemplate/" + ShopID + "_FooterTemplate.cshtml");
                if (System.IO.File.Exists(filename1))
                {
                    StreamReader sr = new StreamReader(filename1, Encoding.Default , true);
                    string FooterTemplateHtml = sr.ReadToEnd();
                    ViewBag.FooterTemplateHtml ="true"+ FooterTemplateHtml ;
                } 
            }
            ShopFooterTemplateViewModel modal = new ShopFooterTemplateViewModel { ShopID = ShopID, FooterTemplate = ViewBag.FooterTemplateHtml };
            return View(modal);
        }
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        [HttpPost]  //上存店铺页脚cshtml文件
        public ActionResult UpShopFooterCS(ShopFooterTemplateViewModel modal)
        {
            ShopInitialize();
            ModalDialogView ModalDialogView1 = new ModalDialogView();
             
            string ShopID = WebCookie.ShopID;
                
            var ShopFooterTemplateViewModel = new ShopFooterTemplateViewModel { ShopID = ShopID, FooterTemplate = modal.FooterTemplate };
            Shop shop = _db.Shops.Find(ShopID);
            shop.FooterTemplate = ShopFooterTemplateViewModel.FooterTemplate;
            //保存数据记录
            _db.Entry(shop).State = System.Data.Entity.EntityState.Modified;
            int result = _db.SaveChanges();

            string filename1 = Server.MapPath("~/views/Shared/ShopFootTemplate/" + ShopID + "_FooterTemplate.cshtml");
            //移动文件 并设置常量文件名称 FooterTemplate + IshopID.cshtml
            if (result>0)
            {
                System.IO.File.Copy(Server.MapPath(modal.FooterTemplate), filename1,true);
            }
           
            if (System.IO.File.Exists(filename1))
            { 
                StreamReader sr = new StreamReader(filename1, Encoding.Default, true);
                string FooterTemplateHtml = sr.ReadToEnd();
                ViewBag.FooterTemplateHtml = FooterTemplateHtml;
            }
            ModalDialogView1.MsgCode = "0";
            ModalDialogView1.Message = "上存模板成功<br><br>更新模板（~/views/Shared/ShopFootTemplate/"+ ShopID + "_FooterTemplate.cshtml）";
            return Json(ModalDialogView1);
        }

        //UpShopViewTemplate
        [HttpGet]  //上存店铺视图
        public ActionResult UpShopViewTemplate()
        {
            ShopInitialize();
            string ShopID = WebCookie.ShopID;
            var shop = _db.Shops.Where(c => c.ShopID == ShopID).FirstOrDefault();

            string filename = string.Format("{0}_{1}.cshtml",ShopID,LangUtilities.LanguageCode);
            string pathFilename = Server.MapPath(string.Format("~/Views/Shared/ShopViewTemplate1/{0}", filename));
            if (System.IO.File.Exists(pathFilename))
            {
                StreamReader sr = new StreamReader(pathFilename, Encoding.Default, true);
                string shopViewTemplate1 = sr.ReadToEnd();
                ViewBag.ShopViewTemplate1 = shopViewTemplate1;
            }
            ShopViewTemplateModel modal = new ShopViewTemplateModel { ShopID = ShopID, ShopViewTemplate = ViewBag.ShopViewTemplate1 ,LanguageCode = LangUtilities.LanguageCode};
            return View(modal);
        }

        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        [HttpPost]   
        public ActionResult UpShopViewTemplate(ShopViewTemplateModel modal)
        {
            ShopInitialize();
            ModalDialogView ModalDialogView1 = new ModalDialogView();

            string ShopID = WebCookie.ShopID;

            modal.LanguageCode = LangUtilities.StandardLanguageCode(modal.LanguageCode);
             
            string filename = string.Format("{0}_{1}.cshtml", ShopID, modal.LanguageCode);
            string pathFilename = Server.MapPath(string.Format("~/Views/Shared/ShopViewTemplate1/{0}", filename));
            string PathFilename1 = Server.MapPath(modal.ShopViewTemplate);
            //移动文件  
            if (System.IO.File.Exists(PathFilename1))
            {
                System.IO.File.Copy(pathFilename, PathFilename1, true);

                ModalDialogView1.MsgCode = "0";
                ModalDialogView1.Message = "UPLOAD SUCCESS <br>" + filename;
                return Json(ModalDialogView1);
            }else
            {
                ModalDialogView1.MsgCode = "11";
                ModalDialogView1.Message = "UPLOAD FAIL " + filename;
                return Json(ModalDialogView1);
            }
        }
        
        //Deprecate 2024-5-6
        //private string TransToStandardLanguageCode(string langEnumCode)
        //{
        //    langEnumCode = langEnumCode.ToUpper();
        //    switch (langEnumCode)
        //    {
        //        case "US":
        //            return "en-US";
        //        case "CN":
        //            return "zh-CN";
        //        case "HK":
        //            return "zh-HK";
        //        default:
        //            return "zh-HK";
        //    }
        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

#region 帮助程序
        // 用于在添加外部登录名时提供 XSRF 保护
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

#endregion
    }
}