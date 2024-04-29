using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using DataAnnotationsExtensions;
using Ishop.Utilities;
using LanguageResource;

namespace Ishop.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 6)] // [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)] 
        [DataType(DataType.Password)] 
        [LocalizedDisplayName("新密码", KeyName = "SetPasswordViewModel_NewPassword", KeyType = KeyType.Modal)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)] 
        [LocalizedDisplayName("确认新密码", KeyName = "SetPasswordViewModel_ConfirmPassword", KeyType = KeyType.Modal)]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [LocalizedDisplayName("当前密码", KeyName = "ChangePasswordViewModel_OldPassword", KeyType = KeyType.Modal)]  // [Display(Name = "当前密码")] 
        public string OldPassword { get; set; }

        [Required] 
        [DataType(DataType.Password)] 
        [LocalizedDisplayName("新密码", KeyName = "ChangePasswordViewModel_NewPassword", KeyType = KeyType.Modal)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [LocalizedDisplayName("确认新密码", KeyName = "ChangePasswordViewModel_ConfirmPassword", KeyType = KeyType.Modal)]
        [Compare("NewPassword")]   
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [LocalizedDisplayName("手机号码", KeyName = "AddPhoneNumberViewModel_Number", KeyType = KeyType.Modal)]
        public string Number { get; set; }

        [Required]  
        [LocalizedDisplayName("验证码", KeyName = "AddPhoneNumberViewModel_ImageCode", KeyType = KeyType.Modal)]
        public string ImageCode { get; set; }
        
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "验证码")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [LocalizedDisplayName("手机号码", KeyName = "VerifyPhoneNumberViewModel_PhoneNumber", KeyType = KeyType.Modal)]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
    public class ShopFooterTemplateViewModel
    {
        [Required] 
        [LocalizedDisplayName("店铺ID", KeyName = "Shop_ShopID", KeyType = KeyType.Modal)]
        public string ShopID { get; set; }

        [Required] 
        [LocalizedDisplayName("页脚模板", KeyName = "Shop_FooterTemplate", KeyType = KeyType.Modal)] 
        public string FooterTemplate { get; set; }

    }

    public class ShopViewTemplateModel
    {
        [Required]
        [LocalizedDisplayName("店铺ID", KeyName = "Shop_ShopID", KeyType = KeyType.Modal)]
        public string ShopID { get; set; }

        [Required]
        [LocalizedDisplayName("店铺视图模板", KeyName = "Shop_ViewTemplate", KeyType = KeyType.Modal)]
      
        public string ShopViewTemplate { get; set; }

        [Required]  
        public string LanguageCode { get; set; }

    }
}