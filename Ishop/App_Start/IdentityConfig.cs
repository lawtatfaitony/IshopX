using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Ishop.Models;
using Ishop.Identity.Models;
using Ishop.Context;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Sms.Model.V20160927;
using System.IO;
using System.Configuration;
using System.Net.Mail;
using Ishop.Utilities;
using System.Diagnostics;
using System.Threading;
using System.Net;

namespace Ishop
{
    public class EmailService : IIdentityMessageService
    {
        private MailMessage MailMessage126 = new MailMessage();
        public Task SendAsync(IdentityMessage message)
        {
            //在此处插入电子邮件服务可发送电子邮件。
            //var credentialUserName = ConfigurationManager.AppSettings["credentialUserName"].ToString();
            //var sentFrom = ConfigurationManager.AppSettings["sentFrom"].ToString();
            //var pwd = ConfigurationManager.AppSettings["pwd"].ToString();
            //var host = ConfigurationManager.AppSettings["SmtpClient"].ToString();
            //int port = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
             

            SendEmail126X(message.Destination, message.Subject, message.Body);

            return Task.FromResult(1);
        }
  
        public  void SendEmail126X(string to, string subject, string bodyContent)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var emailAcount = "xguard@126.com";//邮箱号
            var emailPassword = "SAHMIMINZLHDRXSD";//POP3/SMTP/IMAP服务密码 或 邮箱密码

            try
            {
                var reciver = to;//收信邮箱
                //var content = "这个是邮件内容,程序发送邮件测试...";//邮件内容
                var content = bodyContent;//邮件内容
                MailMessage message = new MailMessage();
                //设置发件人,发件人需要与设置的邮件发送服务器的邮箱一致
                MailAddress fromAddr = new MailAddress(emailAcount);
                message.From = fromAddr;
                //设置收件人,可添加多个,添加方法与下面的一样
                message.To.Add(reciver);
                //设置抄送人
#if DEBUG
                message.Bcc.Add("caihaxxxxxxx2@gmail.com");
#endif 
                //设置邮件标题 
                message.Subject = subject;
                //设置邮件内容
                message.Body = content;
                message.IsBodyHtml = true;
                //设置邮件发送服务器,服务器根据你使用的邮箱而不同,可以到相应的 邮箱管理后台查看
                SmtpClient client = new SmtpClient("smtp.126.com", 25);
                //启用ssl,也就是安全发送
                client.EnableSsl = false;
                client.UseDefaultCredentials = false;
                
                //设置发送人的邮箱账号和密码
                client.Credentials = new NetworkCredential(emailAcount, emailPassword);
                //发送邮件
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now:F}] [EXCEPTION] [ {to} ] SEND MAIL FAIL : {subject} {ex.Message}");
                throw ex;
            }
            finally
            {
                string loggerLine = string.Format("[{0:yyyy-MM-dd HH:mm:ss}] [126 MAIL] [TO :{1} FROM : {2}] [SUCCESS {3}Milliseconds]", DateTime.Now, to, emailAcount, sw.Elapsed.Milliseconds);
                Console.WriteLine(loggerLine);

                sw.Stop();
            }


        }
    }

    public class SmsService : IIdentityMessageService
    { 
        public Task SendAsync(IdentityMessage message)
        {
            //把发送短信失败写入log记录（aliyunsms.log）
            string aliyunsms_localPath = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "upload");
            aliyunsms_localPath = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "aliyunsms.log");
            StreamWriter sw = new StreamWriter(aliyunsms_localPath, true);

           
            IClientProfile profile = DefaultProfile.GetProfile("xxx", "vvvv", "vvv"); //如何获得a-c-c-e-s-s-k-e-y  ：https://ak-console.a-l-i-y-u-n.com/#/a-c-c-e-s-s-k-e-y 受github敏感信息,原文需要去除符號: -
            IAcsClient client = new DefaultAcsClient(profile);
            SingleSendSmsRequest request = new SingleSendSmsRequest();
            try
            {
                request.SignName = "信汇";//"管理控制台中配置的短信签名（状态必须是验证通过）"
                request.TemplateCode = "SMS_44715002";//管理控制台中配置的审核通过的短信模板的模板CODE（状态必须是验证通过）"
                request.RecNum = message.Destination; //"13000001111";//"接收号码，多个号码可以逗号分隔"
                request.ParamString = "{code:\"" + message.Body + "\"}"; //"{\"name\":\"123\"}";//短信模板中的变量；数字需要转换为字符串；个人用户每个变量长度必须小于15个字符。"
                SingleSendSmsResponse httpResponse = client.GetAcsResponse(request);
            }
            catch (ServerException e)
            {
                sw.WriteLine(DateTime.Now.ToString() + " ,店铺：" + WebCookie.ShpID + "，目标接收号码：" + message.Destination + " ，错误提示：" + e.ErrorMessage + "\r\n");
            }
            catch (ClientException e)
            {
                sw.WriteLine(DateTime.Now.ToString() + " ,店铺：" + WebCookie.ShpID + "，目标接收号码：" + message.Destination + " ，错误提示：" + e.ErrorMessage + "\r\n");
            }
            sw.WriteLine(DateTime.Now.ToString() + " ,店铺：" + WebCookie.ShpID + "，目标接收号码：" + message.Destination + " ，成功发送。 \r\n");
            sw.Close();
            return Task.FromResult(1);
        }
    }

    // 配置此应用程序中使用的应用程序用户管理器。UserManager 在 ASP.NET Identity 中定义，并由此应用程序使用。
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
       
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>())); 
            
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };
            // 配置用户名的验证逻辑
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };

            // 配置密码的验证逻辑
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 4,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
             // 配置用户锁定默认值
            manager.UserLockoutEnabledByDefault = false;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 10;

            // 注册双重身份验证提供程序。此应用程序使用手机和电子邮件作为接收用于验证用户的代码的一个步骤
            // 你可以编写自己的提供程序并将其插入到此处。
            manager.RegisterTwoFactorProvider("电话代码", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "你的安全代码是 {0}"
            });
            manager.RegisterTwoFactorProvider("电子邮件代码", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "安全代码",
                BodyFormat = "你的安全代码是 {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<ApplicationRole>(context.Get<ApplicationDbContext>()));
        }
    }
    // 配置要在此应用程序中使用的应用程序登录管理器。
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
    
}
