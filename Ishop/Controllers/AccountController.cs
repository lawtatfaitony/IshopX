using System;
using System.Text;
using System.Net;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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
using System.Configuration;

namespace Ishop.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController() : base()
        {
        }
        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <param name="mode">登录模式切换 mode=email则不切换 (登录模式: Email或PhoneNumber)</param>
        /// <returns></returns>
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl,string mode)
        {
            ShopInitialize();

            LoginViewMobileModel modal = new LoginViewMobileModel();

            //取消手机登录模式
            //////如果中国内地则使用 手机登录 (logmode 是过滤条件 ,任意字符串都不跳转) 
            //if (mvcCommeBase.IsChinaArea()&& string.IsNullOrEmpty(mode))
            //{
            //    return RedirectToAction("LoginMobile", new { returnUrl = returnUrl }); // 使用手机登录
            //}
            ViewBag.returnUrl = returnUrl;
            return View();
        }   
        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // 这不会计入到为执行帐户锁定而统计的登录失败次数中
            // 若要在多次输入错误密码的情况下触发帐户锁定，请更改为 shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            
            switch (result)
            {
                case SignInStatus.Success:
                    //判断是不是店铺团队成员，如果是则赋值WebCookie.ShopID 
                    var user = UserManager.FindByEmail(model.Email);
                    var shopStaff = db.ShopStaffs.Where(c => c.UserId == user.Id);
                    if (shopStaff.Count() > 0)
                    {
                        WebCookie.ShopID = shopStaff.SingleOrDefault().ShopID;
                    }
                    var shop = db.Shops.Where(c => c.UserId == user.Id);
                    if (shop.Count<Shop>() > 0)
                    {
                        WebCookie.ShopID = shop.SingleOrDefault().ShopID;
                    }
                    //redirect
                    if (returnUrl == null)
                    {
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        Redirect(returnUrl);
                        return View();
                    }

                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { returnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", Lang.Views_GeneralUI_InvalidLogin); 
                    return View(model);
            }
        }  
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // 要求用户已通过使用用户名/密码或外部登录名登录
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });//传入参数
        }
         
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code prevents the two-factor authentication code from being brute-force attacked.
            // If the user enters the error code a specified number of times, it will
            // The user account is locked for the specified time.
            // You can configure account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("",Lang.Views_GeneralUI_InvalidCode);  
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register(string returnUrl,string logmode)
        {
            //取消手机模式注册
            //if(logmode == null)
            //{
            //    logmode = string.Empty;
            //}
            //if (mvcCommeBase.IsChinaArea() && logmode.ToLower() != "email")   
            //{
            //    return RedirectToAction("RegMobile", new { returnUrl = returnUrl });   
            //}
            ViewBag.returnUrl = returnUrl;
            return View();
        }  

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model,string returnUrl)
        {  
            if (ModelState.IsValid)
            {
                string UserID = db.GetTableIdentityID("62", "AspNetUsers", 4);

                // 使用Email注册 
                var user = new ApplicationUser { Id = UserID, UserName = model.Email.ToLower(), Email = model.Email.ToLower() };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                { 
                    await SignInManager.SignInAsync(user, isPersistent: true, rememberBrowser: true); 
                    // 有关如何启用帐户确认和密码重置的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=320771
                    // 发送包含此链接的电子邮件
                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code });  //要求https:    Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    string confiredYourAccTitle =$"{Lang.Account_Register_confiredYourAccTitle} UserId = {UserID}" ;
                    //string confiredYourAcc = string.Format(Lang.Account_Register_confiredYourAcc, callbackUrl);
                    string bodyContent = this.ReadTxtContent(Server.MapPath("~/MailTemplate/" + string.Format("Register_{0}.html", WebCookie.Language)));
                    bodyContent = bodyContent.Replace("{subject}", confiredYourAccTitle + "User Id : " + user.Id);

                    string schema = Request.Url.Scheme;
                    string hostName = Request.Url.Host.ToLower();
                    int port = Request.Url.Port;
                    callbackUrl = $"{schema}://{hostName}:{port}{callbackUrl}";
                    bodyContent = bodyContent.Replace("{callbackurl}", callbackUrl);

                    //await UserManager.SendEmailAsync(user.Id, confiredYourAccTitle, bodyContent); //系统自带的
                    Task task = Task.Run(() => {

                        EmailService emailService = new EmailService();
                        IdentityMessage identityMessage = new IdentityMessage
                        {
                             Subject = confiredYourAccTitle,
                             Body = bodyContent,
                             Destination = user.Email
                        };

                        //var sentFrom = ConfigurationManager.AppSettings["sentFrom"].ToString();
                        //var pwd = ConfigurationManager.AppSettings["pwd"].ToString();
                        //var host = ConfigurationManager.AppSettings["SmtpClient"].ToString();
                        //int port = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());

                        emailService.SendAsync(identityMessage);

                        string emailRegisterLoggerLine = $"[FUNC::AccountController.Register] [SEND MAIL] [TO : {user.Email}]";
                        Common.CommonBase.OperateDateLoger(emailRegisterLoggerLine,Common.CommonBase.LoggerMode.INFO);
                    });
                   

                    UserManager.ConfirmEmail(user.Id, code); //预设email确认

                    //CreateUserProfile(user.Id); 

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        string ReturnUrl = Request.Params["returnUrl"].ToString();
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            // If we make a mistake somewhere in this step, redisplay the form
            return View(model);
        }

        //================================================================

        #region
        ///<summary>
        ///注册手机作为登录帐号
        ///</summary>
        [AllowAnonymous] 
        public ActionResult RegMobile(string returnUrl,string logmode)
        {
            logmode = string.IsNullOrEmpty(logmode) == true ? string.Empty : logmode.ToLower().Trim();
            //不是中国区则转到Email登录 (logmode 是过滤条件 ,任意字符串都不跳转)
            if (!mvcCommeBase.IsChinaArea() && logmode.ToLower() == "email" )  //不是香港，并且参数等于email模式，才跳转email模式注册
            {
                return RedirectToAction("Register", new { returnUrl = returnUrl }); //使用Email注册
            }
            ViewBag.returnUrl = returnUrl;
            return View();
            
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegMobile(RegisterMobileViewModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            { 
                string UserID = db.GetTableIdentityID("62", "AspNetUsers", 4);

                // 使用Email注册 
                var user = new ApplicationUser { Id = UserID, UserName = model.PhoneNumber, PhoneNumber = model.PhoneNumber };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                { 
                    await SignInManager.SignInAsync(user, isPersistent: true, rememberBrowser: true);

                    CreateUserProfile(); //async to UserProfile

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        string ReturnUrl = Request.Params["returnUrl"].ToString();
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }
        //获取验证码 
        [HttpGet]
        [AllowAnonymous]
        public async Task<JsonResult> SendVerifyCode(string PhoneNumber)
        {
            SmsService SmsService1 = new SmsService(); 
            LoginMobileViewModal model = new Models.LoginMobileViewModal();
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                ModalDialogView1.MsgCode = "0";
                string CheckPhoneNumBer = Lang.Account_SendVerifyCode_CheckPhoneNumBer;//LangUtilities.GetString("请输入手机号码{0}", "Account_SendVerifyCode_CheckPhoneNumBer", KeyType.ActionReturn);
                ModalDialogView1.Message = string.Format(CheckPhoneNumBer, PhoneNumber);
                return Json(ModalDialogView1, "text/json", Encoding.Unicode,JsonRequestBehavior.AllowGet);
            } 

            int CalTiems = 0;
            if (Session["Code"]==null)
            {
                Session["Code"] = model.GenerateNumberRandom(5);
                
                var message = new IdentityMessage
                {
                    Destination = PhoneNumber,
                    Body = Session["Code"].ToString() //"你的安全验证码是: " + Session["Code"].ToString()
                };
                //只输入 5位的Code ,短信模板定义于 短信平台中.
                await SmsService1.SendAsync(message);  //为成为会员前的短信发送
            }
            
            if (Session["CalTiems"] == null)
            {
                CalTiems = 1;
                Session["CalTiems"] = CalTiems.ToString();
            }
            else
            { 
                int Sesion_CalTiems = int.Parse(Session["CalTiems"].ToString()) + 1;
                CalTiems = Sesion_CalTiems;
                Session["CalTiems"] = CalTiems.ToString();
            }

            ModalDialogView1.MsgCode = "1";
            string HasSendCodeMsg = Lang.Account_SendVerifyCode_HasSendCodeMsg;
            ModalDialogView1.Message = string.Format(HasSendCodeMsg, PhoneNumber, CalTiems.ToString()) ; //测试使用 : + Session["Code"].ToString();
            //会话中=1 会话超时=2 

            //已经发送验证码
            return Json(ModalDialogView1, "text/json", Encoding.Unicode, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //===============================================================
        #region
        /// <summary> 
        /// GET: /Account/LoginMobile
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult LoginMobile(string returnUrl, string logmode)
        {
            logmode = string.IsNullOrEmpty(logmode) == true ? string.Empty : logmode.ToLower().Trim();
            //不是中国区则转到Email登录 (logmode 是过滤条件 ,任意字符串都不跳转)
            if (!mvcCommeBase.IsChinaArea() && logmode == string.Empty )  //zh-HK email
            { 
                return RedirectToAction("login", new { returnUrl = returnUrl }); // 使用Email登录
            }
            ViewBag.returnUrl = returnUrl;

            return View();
        }
         
        // POST: /Account/LoginMobile
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginMobile(LoginViewMobileModel model, string returnUrl)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // 这不会计入到为执行帐户锁定而统计的登录失败次数中
            // 若要在多次输入错误密码的情况下触发帐户锁定，请更改为 shouldLockout: true  
            var result = await SignInManager.PasswordSignInAsync(model.PhoneNumber, model.Password, model.RememberMe, shouldLockout: false); 
             
            switch (result)
            {
                case SignInStatus.Success:
                    //判断是不是店铺团队成员，如果是则赋值WebCookie.ShopID
                    var user = UserManager.FindByName(model.PhoneNumber);
                    var shopStaff = db.ShopStaffs.Where(c => c.UserId == user.Id);
                    if (shopStaff.Count<ShopStaff>()> 0)
                    {
                        WebCookie.ShopID = shopStaff.SingleOrDefault().ShopID;
                    }
                    var shop = db.Shops.Where(c => c.UserId == user.Id);
                    if (shop.Count<Shop>() > 0)
                    {
                        WebCookie.ShopID = shop.SingleOrDefault().ShopID;
                    }

                    //---------------------
                    if (returnUrl != null)
                    {
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                case SignInStatus.LockedOut:
                    return View("Lockout");
                //  注册手机时候已经实现手机号码验证
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { returnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", Lang.Views_GeneralUI_InvalidPhoneNumberLogin);//"无效的手机登录尝试。"
                    return View(model);
            }
        }

        /// <summary> 
        /// GET: /Account/MobileRegister
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult MobileRegister(string PhoneNumber)
        {
            ViewBag.PhoneNumber = PhoneNumber;
            return View();
        }
        /// <summary>
        /// 手机注册 action
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MobileRegister(MobileRegisterViewModal modal)
        {
            if (ModelState.IsValid)
            {
                string Code = Session["Code"].ToString();
                if (Code != modal.Code)
                {
                    ViewBag.StatusMessage = Lang.Account_MobileRegister_InvalidMobileVerifiedCode ; //"手机验证码无效，重新输入。";
                    return View();
                }
                var user = new ApplicationUser { UserName = modal.PhoneNumber, PasswordHash = modal.Password, PhoneNumber = modal.PhoneNumber, PhoneNumberConfirmed = true, TwoFactorEnabled = true };
                  
               
                var result = await UserManager.CreateAsync(user, modal.Password);
                if (result.Succeeded)
                {
                    //判断是不是店铺团队成员，如果是则赋值WebCookie.ShopID
                    var shopStaff = db.ShopStaffs.Where(c => c.UserId == UserManager.FindByName(modal.PhoneNumber).Id);
                    if (shopStaff.Count<ShopStaff>() > 0 )
                    {
                        WebCookie.ShopID = shopStaff.SingleOrDefault().ShopID;
                    }
                    var shop = db.Shops.Where(c => c.UserId == UserManager.FindByName(modal.PhoneNumber).Id);
                    if (shop.Count<Shop>() > 0)
                    {
                        WebCookie.ShopID = shop.SingleOrDefault().ShopID;
                    }
                    //==============================================================================
                    await SignInManager.SignInAsync(user, isPersistent: true, rememberBrowser: true);

                    // Email 是必填字段，所以改为格式 modal.PhoneNumber+"@qq.com"，判断 IsEmailComfirmed =false 要求用户重新填入并邮箱验证
                    // 有关如何启用帐户确认和密码重置的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=320771
                    // 发送包含此链接的电子邮件
                    //string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    //await UserManager.SendEmailAsync(user.Id, "确认你的帐户", "请通过单击 <a href=\"" + callbackUrl + "\">這裏</a>来确认你的帐户");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(modal);
        }
        #endregion

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            ShopInitialize();
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            ShopInitialize();
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || (await UserManager.IsEmailConfirmedAsync(user.Id)))
                {  
                    return View("ForgotPasswordConfirmation");
                }
                 
                // 有关如何启用帐户确认和密码重置的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=320771
                // 发送包含此链接的电子邮件
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                //var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);

                string schema = Request.Url.Scheme;
                string hostName = Request.Url.Host.ToLower();
                int port = Request.Url.Port;
                var callbackUrl = $"{schema}://{hostName}:{port}/{LangUtilities.LanguageCode}/Account/ResetPassword?userId={user.Id}&code={code}";

                string SentCodeToEmailSubject = Lang.Account_ForgotByPhone_SentCodeToEmailSubject; // LangUtilities.GetString("重置密码", "Account_ForgotByPhone_SentCodeToEmailContent", KeyType.ActionReturn); 
                string SentCodeToEmailContent = Lang.Account_ForgotByPhone_SentCodeToEmailContent;

                SentCodeToEmailContent = string.Format(SentCodeToEmailContent, callbackUrl);

                //Use folder MailTemplate to Send content
                SentCodeToEmailContent = this.ReadTxtContent(Server.MapPath("~/MailTemplate/" + string.Format("ForgetPassword_{0}.html", LangUtilities.LanguageCode)));
                SentCodeToEmailContent = SentCodeToEmailContent.Replace("{subject}", SentCodeToEmailSubject + "User Id : " + user.Id);
                SentCodeToEmailContent = SentCodeToEmailContent.Replace("{callbackurl}", callbackUrl);
                
                // await UserManager.SendEmailAsync(user.Id, SentCodeToEmailSubject, SentCodeToEmailContent); 为何有这句

                Task task = Task.Run(() => {

                    EmailService emailService = new EmailService();
                    IdentityMessage identityMessage = new IdentityMessage
                    {
                        Subject = SentCodeToEmailSubject,
                        Body = SentCodeToEmailContent,
                        Destination = user.Email
                    };
                     
                    emailService.SendAsync(identityMessage);

                    string emailRegisterLoggerLine = $"[FUNC::AccountController.ForgotPassword] [SEND MAIL] [TO : {user.Email}]";
                    Common.CommonBase.OperateDateLoger(emailRegisterLoggerLine, Common.CommonBase.LoggerMode.INFO);
                });

                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }
            
            // 如果我们进行到这一步时某个地方出错，则重新显示表单 
            return View(model);
        }
        /// <summary>
        ///  通过输入手机和验证码 重置密码
        /// </summary>
        /// <returns></returns>
        // GET: /Account/ForgotByPhone
        [AllowAnonymous]
        public ActionResult ForgotByPhone()
        {   
            //以后需要使用 图形验证码提交验证...待完善
            return View();
        }
        /// <summary>
        /// Post
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotByPhone(ForgotByPhoneViewModel model)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(c => c.PhoneNumber == model.PhoneNumber).FirstOrDefault();
                if (user == null || (await UserManager.IsPhoneNumberConfirmedAsync(user.Id)) == false)
                {
                    //0 = 用户不存在的情况处理
                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message = Lang.Account_ForgotByPhone_UserNotExist;  
                    return Json(ModalDialogView1);
                }
                if (Session["Code"]==null)
                {
                    // 1 = 验证码超时的处理情况 
                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message = Lang.Account_ForgotByPhone_CodeTimeOut; 
                    return Json(ModalDialogView1);
                }
                if (model.Code != Session["Code"].ToString())
                {
                    //2 = 验证码不正确 
                    ModalDialogView1.MsgCode = "1";
                    ModalDialogView1.Message = Lang.Account_ForgotByPhone_CodeWrong; //  "验证码不正确" 
                    return Json(ModalDialogView1);
                }
                // 有关如何启用帐户确认和密码重置的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=320771
                // 验证码被确认后 ,获取重置令牌转向重置密码页面
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);

                Response.Redirect(callbackUrl);
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单 
            return View("ForgotByPhone", "~/Views/Shared/_Layout.cshtml", model);
        }
        
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string userId , string code)
        { 
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByIdAsync(model.userId);
            if (user == null)
            {
                // 请不要显示该用户不存在
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }  
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        } 
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // 请求重定向到外部登录提供程序
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        } 
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        } 
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // 生成令牌并发送该令牌
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        } 
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // If the user already has a login, use this external login provider to log in the user
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // 如果用户没有帐户，则提示该用户创建帐户
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        } 
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                // return RedirectToAction("Index", "Manage");  //改为如下
                Response.Redirect(returnUrl);
            }

            if (ModelState.IsValid)
            {
                // 从外部登录提供程序获取有关用户的信息
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }
        
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            //目標:The provided anti-forgery token was meant for user "", but the current user is "joxxxx@xxx.com".
            if (Request.Cookies["__RequestVerificationToken"] != null)
            {
                var tokenCookie = new HttpCookie("__RequestVerificationToken")
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(tokenCookie);
            }
            //.AspNet.ApplicationCookie
            if (Request.Cookies[".AspNet.ApplicationCookie"] != null)
            {
                var applicationCookie = new HttpCookie(".AspNet.ApplicationCookie")
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(applicationCookie);
            }

            return RedirectToAction("Index", "Home"); 
        }
         
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Supervisor")]
        //[Authorize(Users = "Supervisor,Administrator")] //这里 Administrator 是UserName  可以通过用户制定权限
        public ActionResult UserList(string UserId ,string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var UserList1 = from s in db.Users
                                       select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                UserList1 = UserList1.Where(s => s.UserName.Contains(searchString)
                                       || s.Email.Contains(searchString) || s.PhoneNumber.Contains(searchString) || s.Id.Contains(searchString));
            }
            else
            {
                UserList1.Where(s => s.Id == UserId);
            }
            UserList1 = UserList1.OrderBy(s => s.UserName);

            int pageSize = 24;
            int pageNumber = (page ?? 1);
            return View(UserList1.ToPagedList(pageNumber, pageSize));
            
        } 
        /// <summary>
        /// 用户角色授权
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Supervisor")]
        public ActionResult UserRolesAssignedList(string id,string  UserName)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user =  UserManager.FindById(id); 
            PopulateAssignedRoleData(user);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        private void PopulateAssignedRoleData(ApplicationUser applicationUser)
        {
            var allRoles = db.AspNetRoles.OrderBy(s=>s.Name); 

            var UserRoles = new HashSet<string>(db.Database.SqlQuery<string>("select RoleId from AspNetUserRoles where UserID='" + applicationUser.Id + "'").ToList<string>());
            var viewModel = new List<AssignedRoles>();
            foreach (var item in allRoles)
            {
                viewModel.Add(new AssignedRoles
                {
                    UserId = applicationUser.Id.ToString(),
                    RoleId = item.Id,
                    Name = item.Name,
                    Description = item.Description  ,
                    Assigned = UserRoles.Contains(item.Id)
                });
            }
            ViewBag.UserRoles = viewModel;
        }
        /// <summary>
        /// 用户角色授权更新
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="selectedRoles"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Supervisor")]
        public ActionResult UserRolesAssignedUpdate(string UserId, string[] selectedRoles)
        {
            if (UserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UpdateUserRoles(selectedRoles, UserId);

            db.SaveChanges();
            Ishop.Areas.Mgr.Models.ModalDialogView modalDialogView = new Ishop.Areas.Mgr.Models.ModalDialogView();
            modalDialogView.MsgCode = "1";
            modalDialogView.Message = Lang.Account_UserRolesAssignedUpdate_modalDialogViewMsg;//"更新授权成功";
            return View("ModalDialogView", modalDialogView);
             
        }
        [Authorize(Roles = "StoreAdmin,Supervisor,Admins")]
        public void UpdateUserRoles(string[] selectedRoles, string UserId)
        {
            if (selectedRoles == null)
            { 
                return;
            }

            var selectedRolesHashSet = new HashSet<string>(selectedRoles);
            var UserRoles = new HashSet<string>(db.Database.SqlQuery<string>("select RoleId from AspNetUserRoles where UserID='" + UserId + "'").ToList<string>()); 
            foreach (var Role in db.Roles)
            {
                if (selectedRolesHashSet.Contains(Role.Id.ToString()))
                {
                    if (!UserRoles.Contains(Role.Id.ToString()))
                    {
                        ViewBag.Result = db.AddUserToRole(UserManager, UserId, Role.Name);
                    }
                }
                else
                {
                    if (UserRoles.Contains(Role.Id.ToString()))
                    {
                        db.RemoveFromRole(UserManager, UserId, Role.Name);
                    }
                }
            }
        }
        //When registing account,as sametime to create UserProfile record.
        public void CreateUserProfile()
        {
            Models.ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
            string RecommUserId = WebCookie.RecommUserId;
            UserProfile userProfile = new UserProfile
            {
                UserId = User.Identity.GetUserId()
               ,ParentUserId = RecommUserId??string.Empty
               ,Email = user.Email
               ,NickName = User.Identity.Name 
               ,IsMonopoly = false
               ,IsBlock = false
               ,ShopID = WebCookie.ShpID
               ,CreatedDate = DateTime.Now
               ,OperatedDate = DateTime.Now
               ,QuantizationScore = 0
            };
            db.UserProfiles.Add(userProfile);
            db.SaveChanges();
        }
        public void CreateUserProfile(string userId)
        {
            Models.ApplicationUser user = db.Users.Find(userId);
            string RecommUserId = WebCookie.RecommUserId;
            UserProfile userProfile = new UserProfile
            {
                UserId = user.Id
               ,
                ParentUserId = RecommUserId 
               ,
                Email = user.Email
               ,
                NickName = user.UserName
               ,
                IsMonopoly = false
               ,
                IsBlock = false
               ,
                ShopID = WebCookie.ShpID
               ,
                CreatedDate = DateTime.Now
               ,
                OperatedDate = DateTime.Now
               ,
                QuantizationScore = 0
            };
            db.UserProfiles.Add(userProfile);
            db.SaveChanges();
        }


        #region Dispose资源释放
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }
        #endregion



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
            //这里的 error 要 进行 多言语
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home"); 
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion

     
    }
}