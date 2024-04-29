using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ishop.Utilities;
using DataAnnotationsExtensions; 
using LanguageResource;
namespace Ishop.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required] 
        [LocalizedDisplayName("电子邮件", KeyName = "AspNetUsers_Email", KeyType = KeyType.Modal)]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required] 
        [LocalizedDisplayName("验证码", KeyName = "AspNetUsers_Code", KeyType = KeyType.Modal)]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }
         
        [LocalizedDisplayName("记住此浏览器?", KeyName = "AspNetUsers_RememberBrowser", KeyType = KeyType.Modal)]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [LocalizedDisplayName("电子邮件", KeyName = "AspNetUsers_Email", KeyType = KeyType.Modal)]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required] 
        [LocalizedDisplayName("Email", KeyName = "AspNetUsers_Email", KeyType = KeyType.Modal)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [LocalizedDisplayName("密码", KeyName = "AspNetUsers_Password", KeyType = KeyType.Modal)] 
        public string Password { get; set; }
         
        [LocalizedDisplayName("记住我?", KeyName = "AspNetUsers_RememberMe", KeyType = KeyType.Modal)]
        public bool RememberMe { get; set; }
    }
    public class LoginViewMobileModel
    {
        [Required]
        [PhoneNumber] 
        [LocalizedDisplayName("手机号码", KeyName = "AspNetUsers_PhoneNumber", KeyType = KeyType.Modal)] 
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(20)]
        [MinLength(6)]
        [LocalizedDisplayName("密码", KeyName = "AspNetUsers_Password", KeyType = KeyType.Modal)]
        public string Password { get; set; }
        
        [LocalizedDisplayName("记住我?", KeyName = "AspNetUsers_RememberMe", KeyType = KeyType.Modal)]
        public bool RememberMe { get; set; }
    }
    public class RegisterViewModel
    { 
        [Required]
        [LocalizedDisplayName("Email", KeyName = "AspNetUsers_Email", KeyType = KeyType.Modal)]
        [EmailAddress]
        public string Email { get; set; }
  
        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [LocalizedDisplayName("密码", KeyName = "AspNetUsers_Password", KeyType = KeyType.Modal)]
        public string Password { get; set; }
          
        [DataType(DataType.Password)]
        [LocalizedDisplayName("确认密码", KeyName = "AspNetUsers_ConfirmPassword", KeyType = KeyType.Modal)]
        [EqualTo("Password")]
        public string ConfirmPassword { get; set; }

    }
    public class RegisterMobileViewModel
    { 
        [Required]
        [LocalizedDisplayName("手机号码", KeyName = "AspNetUsers_PhoneNumber", KeyType = KeyType.Modal)]
        [PhoneNumber] 
        public string PhoneNumber { get; set; }

        [Required] 
        [LocalizedDisplayName("验证码", KeyName = "AspNetUsers_Code", KeyType = KeyType.Modal)]
        [Digits] 
        public string Code { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        [DataType(DataType.Password)] 
        [LocalizedDisplayName("密码", KeyName = "AspNetUsers_Password", KeyType = KeyType.Modal)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [LocalizedDisplayName("确认密码", KeyName = "AspNetUsers_ConfirmPassword", KeyType = KeyType.Modal)]
        [EqualTo("Password")]
        public string ConfirmPassword { get; set; }

    }
    public class ResetPasswordViewModel
    {
        [Required] 
        [LocalizedDisplayName("UserId", KeyName = "AspNetUsers_UserId", KeyType = KeyType.Modal)]
        public string userId { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        [DataType(DataType.Password)] 
        [LocalizedDisplayName("密码", KeyName = "AspNetUsers_Password", KeyType = KeyType.Modal)]
        public string Password { get; set; }

        [DataType(DataType.Password)] 
        [LocalizedDisplayName("确认密码", KeyName = "AspNetUsers_ConfirmPassword", KeyType = KeyType.Modal)]
        [EqualTo("Password")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    { 
        [Required]
        [LocalizedDisplayName("Email", KeyName = "AspNetUsers_Email", KeyType = KeyType.Modal)] 
        [Email]
        public string Email { get; set; }
    }
    //[MetadataType(typeof(ProductMetadata))] 
    public class ForgotByPhoneViewModel
    { 
        [Required] 
        [PhoneNumber] 
        [LocalizedDisplayName("手机号码", KeyName = "AspNetUsers_PhoneNumber", KeyType = KeyType.Modal)]
        public string PhoneNumber { get; set; }

        [Required]
        [Digits] 
        [LocalizedDisplayName("手机验证码", KeyName = "AspNetUsers_Code", KeyType = KeyType.Modal)]
        public string Code { get; set; }
    }
    //手机登陆 ==》》发送短信验证码
    public class LoginMobileViewModal
    {
        [Required] 
        [PhoneNumber]
        [LocalizedDisplayName("手机号码", KeyName = "AspNetUsers_PhoneNumber", KeyType = KeyType.ModalView)]
        public string PhoneNumber { get; set; }

        private static char[] constantNumber =
          {
               '0','1','2','3','4','5','6','7','8','9'
              };
        //生产随机数字 例如 手机验证码
        public  string GenerateNumberRandom(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(10);
                System.Random rd = new System.Random();
                for (int i = 0; i < Length; i++)
                {
                    newRandom.Append(constantNumber[rd.Next(10)]);
                }

            return newRandom.ToString();
            
        }

    }
    // 手机注册 发送认证码进行验证和
    public class MobileRegisterViewModal
    {
        [PhoneNumber]
        [LocalizedDisplayName("手机号码", KeyName = "AspNetUsers_PhoneNumber", KeyType = KeyType.Modal)] 
        public string PhoneNumber { get; set; }
        [Required]
        [LocalizedDisplayName("手机验证码", KeyName = "AspNetUsers_Code", KeyType = KeyType.Modal)]
        public string Code { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [LocalizedDisplayName("密码", KeyName = "AspNetUsers_Password", KeyType = KeyType.Modal)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [LocalizedDisplayName("确认密码", KeyName = "AspNetUsers_ConfirmPassword", KeyType = KeyType.Modal)]
        [EqualTo("Password")]
        public string ConfirmPassword { get; set; }
    }
}
