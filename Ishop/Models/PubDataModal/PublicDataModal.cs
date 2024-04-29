using Ishop.Utilities;
using LanguageResource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ishop.Models.PubDataModal
{
    public enum MenuType
    {
        // TopMenu="顶栏菜单",LeftMenu="左侧菜单" 
        TopMenu = 1, LeftMenu = 2
    }
    public enum MenuTargetMode
    {
        _Blank = 1 , Self = 2
    }
    public class TableIdentity
    {
        [Key]
        [Display(Name = "Table Name")] //表名
        public string TableName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Table IdentityID")] //表格 自增量ID
        public int TableIdentityID { get; set; } //每次新增,自动加1 每次新增调用都加1 ,无论新增成功与否

        [Display(Name = "Operated Date")]  //最近一次自增时间
        public DateTime OperatedDate { get; set; }
    }
    public class District
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        [LocalizedDisplayName("地区ID", KeyName = "District_DistrictID", KeyType = KeyType.Modal)]
        public int DistrictID { get; set; }

        [Required]
        [Display(Name = "邮政编码")]
        [LocalizedDisplayName("邮政编码", KeyName = "District_DistrictID", KeyType = KeyType.Modal)]
        [StringLength(50)]
        public string PostCode { get; set; }

        [Required]
        [LocalizedDisplayName("地区名称", KeyName = "District_DistrictName", KeyType = KeyType.Modal)]
        [StringLength(50)]
        public string DistrictName { get; set; }

        [Required]
        [LocalizedDisplayName("所属地区(ID)", KeyName = "District_Parent_id", KeyType = KeyType.Modal)]
        public int Parent_id { get; set; }

        [Required]
        [LocalizedDisplayName("字母索引", KeyName = "District_FirstLetter", KeyType = KeyType.Modal)]
        [StringLength(1)]
        public string FirstLetter { get; set; }

        [Required]
        [LocalizedDisplayName("层", KeyName = "District_Levels", KeyType = KeyType.Modal)]
        [DefaultValue(0)]
        public int Levels { get; set; }
    }
    public class  MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [LocalizedDisplayName("菜单ID", KeyName = "MenuItem_MenuItemID", KeyType = KeyType.Modal)]
        [StringLength(10, MinimumLength = 2)]
        public string MenuItemID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [LocalizedDisplayName("菜单名称", KeyName = "MenuItem_MenuItemName", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = "-")] //空商品名称显示为：-
        public string MenuItemName { get; set; }
         
        [StringLength(50, MinimumLength = 2)]
        [LocalizedDisplayName("菜单名称", KeyName = "MenuItem_EngMenuItemName", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = "-")] //空商品名称显示为：-
        public string EngMenuItemName { get; set; }
         
        [Required]
        [LocalizedDisplayName("父菜单ID", KeyName = "MenuItem_ParentsMenuItemID", KeyType = KeyType.Modal)]
        [StringLength(10)]
        public string ParentsMenuItemID { get; set; }

        [Required]
        [LocalizedDisplayName("连接", KeyName = "MenuItem_MenuLink", KeyType = KeyType.Modal)]
        [StringLength(300)]
        public string MenuLink { get; set; }
         
        [LocalizedDisplayName("打开方式", KeyName = "MenuItem_Target", KeyType = KeyType.Modal)]
        public string Target { get; set; }
         
        [LocalizedDisplayName("角色授权", KeyName = "MenuItem_ForRoleName", KeyType = KeyType.Modal)]
        public string ForRoleName { get; set; }

        [StringLength(256)]
        [LocalizedDisplayName("操作用户", KeyName = "MenuItem_OperatedUserName", KeyType = KeyType.Modal)]
        public string OperatedUserName { get; set; }
         
        [LocalizedDisplayName("操作日期", KeyName = "MenuItem_OperatedDate", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; }
    }
    public class AccountMgr
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID")]
        [MaxLength(18)]
        public string AccountMgrID { get; set; }
         
        [LocalizedDisplayName("操作日期", KeyName = "AccountMgr_ShopID", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        public string ShopID { get; set; }

        [Required]
        [MaxLength(256)]
        [LocalizedDisplayName("网址", KeyName = "AccountMgr_WebSite", KeyType = KeyType.Modal)]
        public string WebSite { get; set; }

        [Required]
        [LocalizedDisplayName("网站名称", KeyName = "AccountMgr_SiteName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        public string SiteName { get; set; }

        [Required]
        [LocalizedDisplayName("账号ID", KeyName = "AccountMgr_LoginID", KeyType = KeyType.Modal)]
        [MaxLength(1024)]
        public string LoginID { get; set; }

        [Required]
        [LocalizedDisplayName("密碼", KeyName = "AccountMgr_Password", KeyType = KeyType.Modal)]
        [MaxLength(1024)]
        public string Password { get; set; }
         
        [LocalizedDisplayName("密碼2", KeyName = "AccountMgr_Password2", KeyType = KeyType.Modal)]
        [MaxLength(1024)]
        public string Password2 { get; set; }
        
        [LocalizedDisplayName("证书", KeyName = "AccountMgr_IsCer", KeyType = KeyType.Modal)]
        [DefaultValue(false)]
        public bool IsCer { get; set; }

        [LocalizedDisplayName("登录EMail", KeyName = "AccountMgr_LoginEmail", KeyType = KeyType.Modal)]
        [MaxLength(256)]
        public string LoginEmail { get; set; }
         
        [LocalizedDisplayName("安全EMail", KeyName = "AccountMgr_ScurityEmail", KeyType = KeyType.Modal)]
        [MaxLength(256)]
        public string ScurityEmail { get; set; }
         
        [LocalizedDisplayName("註冊手機", KeyName = "AccountMgr_Mobile", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        public string Mobile { get; set; }
         
        [LocalizedDisplayName("暱稱", KeyName = "AccountMgr_NickName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        public string NickName { get; set; }
         
        [LocalizedDisplayName("安全問題", KeyName = "AccountMgr_PrivacyQuestion", KeyType = KeyType.Modal)]
        [MaxLength(256)]
        public string PrivacyQuestion { get; set; }
         
        [LocalizedDisplayName("答案", KeyName = "AccountMgr_PrivacyAnswer", KeyType = KeyType.Modal)]
        [MaxLength(256)]
        public string PrivacyAnswer { get; set; }
         
        [LocalizedDisplayName("创建者", KeyName = "AccountMgr_CreatedByUserID", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        public string CreatedByUserID { get; set; }
         
        [LocalizedDisplayName("授權UserID", KeyName = "AccountMgr_AssignedToUserID", KeyType = KeyType.Modal)]
        [MaxLength(200)]
        public string AssignedToUserID { get; set; }
         
        [LocalizedDisplayName("備註", KeyName = "AccountMgr_Remarks", KeyType = KeyType.Modal)]
        [MaxLength(2000)]
        public string Remarks { get; set; }

        [MaxLength(256)]
        [LocalizedDisplayName("操作用户", KeyName = "AccountMgr_OperatedUserName", KeyType = KeyType.Modal)]
        public string OperatedUserName { get; set; }
         
        [LocalizedDisplayName("操作日期", KeyName = "AccountMgr_OperatedDate", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; }
    }
    public class AccountWebSite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        [StringLength(10, MinimumLength = 2)]
        public string WebSiteID { get; set; }

        [Required]
        [MaxLength(256)]
        [LocalizedDisplayName("网址", KeyName = "AccountWebSite_WebSite", KeyType = KeyType.Modal)]
        public string WebSite { get; set; }

        [Required] 
        [LocalizedDisplayName("网站名称", KeyName = "AccountWebSite_SiteName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        public string SiteName { get; set; }
    }
    /// <summary>
    /// 多语言  zh(中文地区): zh-TW(台湾) zh-CN(大陆) zh-HK(香港) zh-SG(新加波) zh-MO(澳门)
    ///         ja-JP(日语)
    ///         ar(阿拉伯语): ar-SA 沙特阿拉伯 ar-KW 科威特
    ///         en(英语)    : en-GB(英国) en-US(美国) 
    ///         de(德语)    : de-DE(德国) de-CH(德语-瑞士)
    ///         ru(俄语)    : ru-RU(俄语-俄罗斯)
    ///         es(西班牙)  : es-AR(西班牙语-阿根廷) es-PR(西班牙语-波多黎各)
    ///         参考代码:https://msdn.microsoft.com/zh-cn/library/kx54z3k7(VS.80).aspx
    /// </summary>
    public class Language
    { 
        [Key] 
        [Required]
        [StringLength(256)]
        [Display(Name = "Key Name",Order = 0)] 
        public string KeyName { get; set; }

        [Required] 
        [LocalizedDisplayName("类型", KeyName = "Language_KeyType", KeyType = LanguageResource.KeyType.Modal)]
        public string KeyType { get; set; }
         
        [LocalizedDisplayName("简体中文", KeyName = "Language_zh_CN", KeyType = LanguageResource.KeyType.Modal)]
        public string zh_CN { get; set; }
         
        [LocalizedDisplayName("香港英文", KeyName = "Language_zh_HK", KeyType = LanguageResource.KeyType.Modal)]
        public string zh_HK { get; set; } 

        [LocalizedDisplayName("日本語", KeyName = "Language_ja", KeyType = LanguageResource.KeyType.Modal)]
        public string ja { get; set; }

        [LocalizedDisplayName("韓國語", KeyName = "Language_ko", KeyType = LanguageResource.KeyType.Modal)]
        public string ko { get; set; }

        [LocalizedDisplayName("华语繁体", KeyName = "Language_zh", KeyType = LanguageResource.KeyType.Modal)]
        public string zh { get; set; }
         
        [LocalizedDisplayName("英语", KeyName = "Language_en", KeyType = LanguageResource.KeyType.Modal)]
        public string en { get; set; }
         
        [LocalizedDisplayName("法语", KeyName = "Language_fr", KeyType = LanguageResource.KeyType.Modal)]
        public string fr { get; set; }
         
        [LocalizedDisplayName("德语", KeyName = "Language_de", KeyType = LanguageResource.KeyType.Modal)]
        public string de { get; set; }
         
        [LocalizedDisplayName("俄语", KeyName = "Language_ru", KeyType = LanguageResource.KeyType.Modal)]
        public string ru { get; set; }
         
        [LocalizedDisplayName("阿拉伯语", KeyName = "Language_ar", KeyType = LanguageResource.KeyType.Modal)]
        public string ar { get; set; }
         
        [LocalizedDisplayName("西班牙", KeyName = "Language_es", KeyType = LanguageResource.KeyType.Modal)]
        public string es { get; set; }
         
        [LocalizedDisplayName("Remarks", KeyName = "Language_Remarks", KeyType = LanguageResource.KeyType.Modal)]
        public string Remarks { get; set; }
    }

    public class SeoExtand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "SeoId")]
        [LocalizedDisplayName("父级关键词", KeyName = "SeoExtand_SeoExtandID", KeyType = KeyType.Modal)]
        [StringLength(20, MinimumLength = 2)]
        public string SeoExtandID { get; set; }

        [Required]
        [StringLength(512, MinimumLength = 1)] 
        [LocalizedDisplayName("关键词/短语", KeyName = "SeoExtand_SeoKeyWord", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = " ")]  
        public string SeoKeyWord { get; set; }

        //富文本HTML5模板
        [LocalizedDisplayName("是否为富文本HTML5模板", KeyName = "SeoExtand_IsSeoHtmlContext", KeyType = KeyType.Modal)]
        [DefaultValue(false)]
        public bool IsSeoHtmlContext { get; set; }

        //html文法内容
        [LocalizedDisplayName("Html格式内容", KeyName = "SeoExtand_SeoHtmlContext", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = " ")]
        public string SeoHtmlContext { get; set; }

        [Required] 
        [LocalizedDisplayName("父关键词ID", KeyName = "SeoExtand_ParentsSeoExtandID", KeyType = KeyType.Modal)]
        [StringLength(20)]
        [DefaultValue("0")]
        public string ParentsSeoExtandID { get; set; }
         
        [Required]
        [LocalizedDisplayName("店铺ID", KeyName = "SeoExtand_ShopID", KeyType = KeyType.Modal)]
        [StringLength(20, MinimumLength = 3)]
        public string ShopID { get; set; }

        [StringLength(128)] 
        [LocalizedDisplayName("UserId", KeyName = "SeoExtand_UserId", KeyType = KeyType.Modal)]
        public string UserId { get; set; }

        [Required]
        [LocalizedDisplayName("Top50排序", KeyName = "SeoExtand_Top50", KeyType = KeyType.Modal)]
        [DefaultValue(50)]
        public int TopRank50 { get; set; }

        [StringLength(256)] 
        [LocalizedDisplayName("操作用户", KeyName = "SeoExtand_OperatedUserName", KeyType = KeyType.Modal)]
        public string OperatedUserName { get; set; }
         
        [LocalizedDisplayName("操作日期", KeyName = "SeoExtand_OperatedDate", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; }
    }

    public class TableState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Id")] 
        [StringLength(20, MinimumLength = 2)]
        public string Id { get; set; }

        [StringLength(128)]
        [Display(Name = "TableName")]
        public string TableName { get; set; }

        [MaxLength(50)]
        [Display(Name = "StatusId")]
        public string StatusId { get; set; }

        [StringLength(50)]
        [Display(Name = "StatusName")]
        public string StatusName { get; set; }

        [Required]
        [DefaultValue("zh-HK")]
        [Display(Name = "LanguageCode")]
        public string LanguageCode { get; set; }
    }
    public class EmailSms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]  
        public string Id { get; set; }
          
        [LocalizedDisplayName("网址", KeyName = "EmailSms_ShopWebsite", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = "www.abc.com")] // for example:  www.abc.com
        public string ShopWebsite { get; set; }
          
        [LocalizedDisplayName("凭证用户名", KeyName = "EmailSms_credentialUserName", KeyType = KeyType.Modal)]
        public string credentialUserName { get; set; }
         
        [LocalizedDisplayName("Email来自", KeyName = "EmailSms_sentFrom", KeyType = KeyType.Modal)]
        public string sentFrom { get; set; }
         
        [LocalizedDisplayName("发Email的密码", KeyName = "EmailSms_pwd", KeyType = KeyType.Modal)]
        public string pwd { get; set; }
         
        [LocalizedDisplayName("SmtpClient", KeyName = "EmailSms_SmtpClient", KeyType = KeyType.Modal)]
        public string SmtpClient { get; set; }
         
        [LocalizedDisplayName("端口号", KeyName = "EmailSms_Port", KeyType = KeyType.Modal)]
        [DefaultValue(25)]
        public int Port { get; set; }

        //短信 Sms  TemplateCode 
        [LocalizedDisplayName("SignName", KeyName = "EmailSms_SignName", KeyType = KeyType.Modal)]
        public string SignName { get; set; }
         
        [LocalizedDisplayName("Access Key", KeyName = "EmailSms_AccessKey", KeyType = KeyType.Modal)]
        public string AccessKey { get; set; }

        [LocalizedDisplayName("Secret", KeyName = "EmailSms_Secret", KeyType = KeyType.Modal)]
        public string Secret { get; set; }
         
        [LocalizedDisplayName("模板编号", KeyName = "EmailSms_TemplateCode", KeyType = KeyType.Modal)]
        public string TemplateCode { get; set; }
         
        [Required]
        [LocalizedDisplayName("店铺ID", KeyName = "EmailSms_ShopID", KeyType = KeyType.Modal)]
        public string ShopID { get; set; }

        [StringLength(256)] 
        [LocalizedDisplayName("操作用户", KeyName = "EmailSms_OperatedUserName", KeyType = KeyType.Modal)]
        public string OperatedUserName { get; set; } 

        [LocalizedDisplayName("操作时间", KeyName = "EmailSms_OperatedDate", KeyType = KeyType.Modal)]
        public DateTime OperatedDate { get; set; }
    }

    public class TemplateNotePosition
    {
        // TemplateNotePositionId = DefiniteTemplateNoteId_TableName_DataField
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "TemplateNotePositionId")]
        public string TemplateNotePositionId { get; set; }

        [StringLength(50)]
        public string TableName { get; set; }

        [StringLength(50)]
        public string DataField { get; set; }
         
        [StringLength(50)]
        [DefaultValue("14px")]
        public string FontSize { get; set; }

        [StringLength(50)]
        [DefaultValue("2.5cm")]
        public string MaxWidth { get; set; }
        
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class DefiniteTemplateNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(50)]
        [LocalizedDisplayName("模板ID", KeyName = "DefiniteTemplateNote_DefiniteTemplateNoteId", KeyType = KeyType.Modal)]
        public string DefiniteTemplateNoteId { get; set; }
         
        [StringLength(50)]
        [LocalizedDisplayName("打印模板名称", KeyName = "DefiniteTemplateNote_DefiniteTemplateNoteName", KeyType = KeyType.Modal)]
        public string DefiniteTemplateNoteName { get; set; }
         
        [LocalizedDisplayName("发件人地址", KeyName = "DefiniteTemplateNote_SenderUserAddressID", KeyType = KeyType.Modal)]
        [StringLength(20)]
        public string SenderUserAddressID { get; set; }

        [StringLength(500)]
        [LocalizedDisplayName("模板图片", KeyName = "DefiniteTemplateNote_DefiniteTemplatePicture", KeyType = KeyType.Modal)]
        public string DefiniteTemplatePicture { get; set; }

        [StringLength(50)]
        [LocalizedDisplayName("模板宽度", KeyName = "DefiniteTemplateNote_Width", KeyType = KeyType.Modal)]
        public string Width { get; set; }

        [StringLength(50)]
        [LocalizedDisplayName("模板高度度", KeyName = "DefiniteTemplateNote_Height", KeyType = KeyType.Modal)]
        public string Height { get; set; }

        [StringLength(300)]
        [LocalizedDisplayName("收件人字段", KeyName = "DefiniteTemplateNote_RecipientColFields", KeyType = KeyType.Modal)]
        public string RecipientColFields { get; set; }

        [StringLength(300)]
        [LocalizedDisplayName("发件人字段", KeyName = "DefiniteTemplateNote_SenderColFields", KeyType = KeyType.Modal)]
        public string SenderColFields { get; set; }

        [Required]
        [LocalizedDisplayName("店铺ID", KeyName = "DefiniteTemplateNote_ShopID", KeyType = KeyType.Modal)]
        public string ShopID { get; set; }

        [StringLength(256)]
        [LocalizedDisplayName("操作用户", KeyName = "DefiniteTemplateNote_OperatedUserName", KeyType = KeyType.Modal)]
        public string OperatedUserName { get; set; }

        [LocalizedDisplayName("操作时间", KeyName = "DefiniteTemplateNote_OperatedDate", KeyType = KeyType.Modal)]
        public DateTime OperatedDate { get; set; }
    }
}