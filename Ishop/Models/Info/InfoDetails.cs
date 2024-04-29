using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Ishop.AppCode.Utilities;
using Ishop.Utilities;
using LanguageResource; 
namespace Ishop.Models.Info
{
    [Authorize(Roles = "StoreBusinessPromotion")]  //规则 : 信息发布模块角色:店铺推广者[StoreBusinessPromotion]
    public class InfoDetail
    { 
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Display(Name = "InfoID")]
        //[LocalizedDisplayName("InfoID",KeyName = "InfoDetail_InfoID", KeyType = KeyType.Modal)] //这里添加一个ID 字段不发生一个或多个字段EntityType验证出错的问题. InfoDetails: EntityType: EntitySet“InfoDetails”基于未定义任何键的类型“InfoDetail”。 //[Display(Name = "InfoID")] //
        [Column("InfoID", Order = 0, TypeName = "nvarchar")]
        [MaxLength(20)]
        [StringLength(20, MinimumLength = 4)]
        public string InfoID { get; set; }

        [LocalizedDisplayName("跟踪ID", KeyName = "InfoDetail_InfoTraceID", KeyType = KeyType.Modal)]
        [StringLength(128)]
        public string UserTraceID { get; set; }

        [LocalizedDisplayName("信息分类", KeyName = "InfoDetail_InfoCateID", KeyType = KeyType.Modal)]
        [Column("InfoCateID", Order = 1, TypeName = "nvarchar")]
        [MaxLength(128)]
        [StringLength(128, ErrorMessage = "For Example : IC001")]
        public string InfoCateID { get; set; }
        
        [Required]
        [MaxLength(256)]
        [LocalizedDisplayName("标题", KeyName = "InfoDetail_Title", KeyType = KeyType.Modal)]
        [Column("Title", Order = 2, TypeName = "nvarchar")]
        [StringLength(256, MinimumLength = 2)]
        public string Title { get; set; }

        [LocalizedDisplayName("适合资讯项模板", KeyName = "InfoDetail_InfoItemTemplateIDs", KeyType = KeyType.Modal)]
        [StringLength(1024)]
        public string InfoItemTemplateIDs { get; set; }

        [LocalizedDisplayName("标题图", KeyName = "InfoDetail_TitleThumbNail", KeyType = KeyType.Modal)]
        [StringLength(256)]
        [Column("TitleThumbNail", Order = 3, TypeName = "nvarchar")]
        public string TitleThumbNail { get; set; }
        //在内容中显示标题图
        [LocalizedDisplayName("标题图显示", KeyName = "InfoDetail_ShowTitleThumbNail", KeyType = KeyType.Modal)]
        [Column("ShowTitleThumbNail", Order = 4, TypeName = "bit")]
        public bool ShowTitleThumbNail { get; set; }
          
        [LocalizedDisplayName("副标题", KeyName = "InfoDetail_SubTitle", KeyType = KeyType.Modal)]
        [Column("SubTitle", Order = 5, TypeName = "nvarchar")]
        [StringLength(512)]
        public string SubTitle { get; set; }
          
        [LocalizedDisplayName("SEO关键词", KeyName = "InfoDetail_SeoKeyword", KeyType = KeyType.Modal)]
        [Column("SeoKeyword", Order = 6, TypeName = "nvarchar")]
        [StringLength(256)]
        public string SeoKeyword { get; set; }
         
        [LocalizedDisplayName("SEO描述", KeyName = "InfoDetail_SeoDescription", KeyType = KeyType.Modal)]
        [Column("SeoDescription", Order = 7, TypeName = "nvarchar")]
        [StringLength(256)]
        public string SeoDescription { get; set; }
         
        [LocalizedDisplayName("描述", KeyName = "InfoDetail_InfoDescription", KeyType = KeyType.Modal)]
        [Column("InfoDescription", Order = 8, TypeName = "nvarchar")]
        public string InfoDescription { get; set; }
         
        [LocalizedDisplayName("视频连接", KeyName = "InfoDetail_VideoUrl", KeyType = KeyType.Modal)]
        [Column("VideoUrl", Order = 9, TypeName = "nvarchar")]
        //[Url] //[RegularExpression(@"^(http://|https://)?((?:[A-Za-z0-9]+-[A-Za-z0-9]+|[A-Za-z0-9]+)\.)+([A-Za-z]+)[/\?\:]?.*$", ErrorMessage = "连接格式错误")]
        [DefaultValue("#")]
        [StringLength(512)]
        public string VideoUrl { get; set; }
          
        [LocalizedDisplayName("作者", KeyName = "InfoDetail_Author", KeyType = KeyType.Modal)]
        [Column("Author", Order = 10, TypeName = "nvarchar")]
        [StringLength(256)]
        public string Author { get; set; }

        [LocalizedDisplayName("原创", KeyName = "InfoDetail_IsOriginal", KeyType = KeyType.Modal)]
        [Column("IsOriginal", Order = 11, TypeName = "bit")]
        [DefaultValue(1)]
        public bool IsOriginal { get; set; }

        [LocalizedDisplayName("语言标识", KeyName = "InfoDetail_LanguageCode", KeyType = KeyType.Modal)]
        [Column("LanguageCode", Order = 12, TypeName = "varchar")]
        [DefaultValue("NO_SET")]
        public string LanguageCode { get; set; }

        [LocalizedDisplayName("员工ID", KeyName = "InfoDetail_ShopStaffID", KeyType = KeyType.Modal)]
        [Column("ShopStaffID", Order = 13, TypeName = "nvarchar")]
        [StringLength(20)]
        public string ShopStaffID { get; set; }

        
        [LocalizedDisplayName("浏览", KeyName = "InfoDetail_Views", KeyType = KeyType.Modal)]
        [DefaultValue(0)]
        [Column("Views", Order = 14, TypeName = "int")]
        public int Views { get; set; }

        [Required] 
        [LocalizedDisplayName("店铺ID", KeyName = "InfoDetail_ShopID", KeyType = KeyType.Modal)]
        [Column("ShopID", Order = 15, TypeName = "nvarchar")]
        [StringLength(20, MinimumLength = 3)]
        public string ShopID { get; set; }
         
        [LocalizedDisplayName("操作用户", KeyName = "InfoDetail_OperatedUserName", KeyType = KeyType.Modal)]
        [Column("OperatedUserName", Order = 16, TypeName = "nvarchar")]
        [StringLength(256)]
        public string OperatedUserName { get; set; }

         
        [LocalizedDisplayName("创建日期", KeyName = "InfoDetail_CreatedDate", KeyType = KeyType.Modal)]
        [Column("CreatedDate", Order = 17, TypeName = "datetime")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", NullDisplayText = "2000-01-01" )]
        public DateTime CreatedDate { get; set; }
         
        [LocalizedDisplayName("操作日期", KeyName = "InfoDetail_OperatedDate", KeyType = KeyType.Modal)]
        [Column("OperatedDate", Order = 18, TypeName = "datetime")] 
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; }
         
    }
    public class InfoCate
    {
        [Key] 
        [LocalizedDisplayName("分类ID", KeyName = "InfoCate_InfoCateID", KeyType = KeyType.Modal)]
        [StringLength(4, MinimumLength = 2, ErrorMessage = "For example: IC0001,9001")]
        public string InfoCateID { get; set; }

        [Required] 
        [LocalizedDisplayName("店铺ID", KeyName = "InfoCate_ShopID", KeyType = KeyType.Modal)]
        [StringLength(20, MinimumLength = 1)]
        public string ShopID { get; set; }

        [Required] 
        [LocalizedDisplayName("父信息类", KeyName = "InfoCate_PrarentsID", KeyType = KeyType.Modal)]
        [StringLength(6)]
        public string PrarentsID { get; set; }
         
        [LocalizedDisplayName("信息分类名", KeyName = "InfoCate_InfoCateName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        public string InfoCateName { get; set; }
         
        [LocalizedDisplayName("分层", KeyName = "InfoCate_Levels", KeyType = KeyType.Modal)]
        public int Levels { get; set; }
         
        [LocalizedDisplayName("操作用户", KeyName = "InfoCate_OperatedUserName", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string OperatedUserName { get; set; }
         
        [LocalizedDisplayName("操作日期", KeyName = "InfoCate_OperatedDate", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; }

        [LocalizedDisplayName("语言代码", KeyName = "InfoCate_LanguageCode", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        public string LanguageCode { get; set; }
    }
    /// <summary>
    /// Changel资讯渠道模型
    /// </summary>
    public class Channel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [LocalizedDisplayName("渠道ID", KeyName = "Changel_ChangelID", KeyType = KeyType.Modal)]
        [MaxLength(50)]  //, ErrorMessage =  Lang.Changel_ChangelID_StringLength_ErrMsg  名称格式例如:CH00000001,CH为前缀
        public string ChannelID { get; set; }

        [Required]
        [LocalizedDisplayName("渠道名称", KeyName = "Changel_ChangelName", KeyType = KeyType.Modal)]
        [MaxLength(50)] //, ErrorMessage = Lang.Changel_ChangelName_StringLength_ErrMsg
        public string ChannelName { get; set; }


        [LocalizedDisplayName("渠道连接", KeyName = "Changel_ChangelUrl", KeyType = KeyType.Modal)]
        [MaxLength(50)]  //, ErrorMessage = Lang.Changel_ChangelUrl_StringLength_ErrMsg)
        [RegularExpression(@"^(http://|https://)?((?:[A-Za-z0-9]+-[A-Za-z0-9]+|[A-Za-z0-9]+)\.)+([A-Za-z]+)[/\?\:]?.*$")]  
        public string ChannelUrl { get; set; }

        [Display(Name = "操作用户")]
        [MaxLength(50)]
        public string OperatedUserName { get; set; }

        [Display(Name = "操作日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; }
    } 
    /// <summary>
    /// [用户资讯渠道]模型
    /// </summary>
    public class UserChannel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [LocalizedDisplayName("用户渠道ID", KeyName = "UserChannel_UserChannelID", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        public string UserChannelID{ get; set; }

        [Required]
        [LocalizedDisplayName("UserId", KeyName = "UserChannel_UserId", KeyType = KeyType.Modal)]
        [MaxLength(120)]
        public string UserId { get; set; }

        [Required]
        [LocalizedDisplayName("渠道ID", KeyName = "UserChannel_ChangelID", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        public string ChannelID { get; set; }
         
        [LocalizedDisplayName("渠道名称", KeyName = "UserChannel_ChannelName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        public string ChannelName { get; set; }

        [LocalizedDisplayName("注册帐号", KeyName = "UserChannel_LoginID", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        public string LoginID { get; set; }

        //二维码url
        [LocalizedDisplayName("渠道二维码", KeyName = "UserChannel_ChannelQRcode", KeyType = KeyType.Modal)]
        [MaxLength(256)]
        public string ChannelQRcode { get; set; }
         
        [LocalizedDisplayName("店铺ID", KeyName = "UserChannel_ShopID", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        public string ShopID { get; set; }

        [LocalizedDisplayName("操作用户", KeyName = "UserChannel_OperatedUserName", KeyType = KeyType.Modal)]
        [MaxLength(256)]
        public string OperatedUserName { get; set; }
         
        [LocalizedDisplayName("操作日期", KeyName = "UserChannel_OperatedDate", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; }
    }

    /// <summary>
    /// 资讯项模板
    /// </summary>
    public class InfoItemTemplate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [LocalizedDisplayName("资讯项模板ID", KeyName = "InfoItemTemplate_InfoItemTemplateID", KeyType = KeyType.Modal)]
        [StringLength(50, MinimumLength = 2)]
        public string InfoItemTemplateID { get; set; }

        [Required]
        [LocalizedDisplayName("资讯项模板名称", KeyName = "InfoItemTemplate_InfoItemTemplateName", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string InfoItemTemplateName { get; set; }
         
        [LocalizedDisplayName("路径", KeyName = "InfoItemTemplate_Path", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string Path { get; set; }
  
        [LocalizedDisplayName("店铺ID", KeyName = "InfoItemTemplate_ShopID", KeyType = KeyType.Modal)]
        [StringLength(20)]
        public string ShopID { get; set; }

        [LocalizedDisplayName("操作用户", KeyName = "InfoItemTemplate_OperatedUserName", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string OperatedUserName { get; set; }

        [LocalizedDisplayName("操作日期", KeyName = "InfoItemTemplate_OperatedDate", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; }


    }

    /// <summary>
    /// User Trace
    /// </summary>
    public class UserTrace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [LocalizedDisplayName("跟踪ID", KeyName = "UserTrace_InfoTraceID", KeyType = KeyType.Modal)]
        [StringLength(128)]
        public string UserTraceID { get; set; }

        [Required]
        [LocalizedDisplayName("TableKeyID", KeyName = "UserTrace_InfoID", KeyType = KeyType.Modal)]
        [MaxLength(256), DataType("nvarchar")] 
        public string TableKeyID { get; set; }

        [LocalizedDisplayName("UserId", KeyName = "UserTrace_UserId", KeyType = KeyType.Modal)]
        [MaxLength(256), DataType("nvarchar")]
        public string UserId { get; set; }

        [LocalizedDisplayName("店铺ID", KeyName = "UserTrace_ShopID", KeyType = KeyType.Modal)]
        [MaxLength(20),DataType("nvarchar")]
        public string ShopID { get; set; }

        [LocalizedDisplayName("操作用户", KeyName = "UserTrace_OperatedUserName", KeyType = KeyType.Modal)]
        [MaxLength(256), DataType("nvarchar")]
        public string OperatedUserName { get; set; }
         
        [LocalizedDisplayName("操作日期", KeyName = "UserTrace_OperatedDate", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; } 

    }
}