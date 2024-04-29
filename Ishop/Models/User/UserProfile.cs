using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ishop.Utilities;
using LanguageResource;

namespace Ishop.Models.User
{
    public enum Genders
    {
        Male = 1, Female = 2 , Unkown = 3  // 男;女;未知
    }
    public class UserProfile
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [LocalizedDisplayName("ID", KeyName = "UserProfile_ID", KeyType = KeyType.Modal)]
        public int UserProfileID { get; set; }

        [LocalizedDisplayName("UserId", KeyName = "UserProfile_UserId", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        [DisplayFormat(NullDisplayText = "-")]
        public string UserId { get; set; }

        [LocalizedDisplayName("ParentUserId", KeyName = "UserProfile_ParentUserId", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        public string ParentUserId { get; set; }
        #region Wechat info
        [LocalizedDisplayName("微信ID", KeyName = "UserProfile_WechatID", KeyType = KeyType.Modal)]
        [MaxLength(256)]
        public string WechatID { get; set; }

        [LocalizedDisplayName("OpenID", KeyName = "UserProfile_OpenID", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string OpenID { get; set; }

        [LocalizedDisplayName("UserIcon", KeyName = "UserProfile_UserIcon", KeyType = KeyType.Modal)]
        [MaxLength(512)]
        public string UserIcon { get; set; }

        #endregion

        [LocalizedDisplayName("帳戶金額", KeyName = "UserProfile_FinanceAmount", KeyType = KeyType.Modal)]
        [DefaultValue(0)]
        public string FinanceAmount { get; set; }

        [LocalizedDisplayName("积分", KeyName = "UserProfile_Score", KeyType = KeyType.Modal)]
        [DefaultValue(0)]
        public string Score { get; set; }

        #region 联系资料

        [LocalizedDisplayName("手机", KeyName = "UserProfile_PhoneNumber", KeyType = KeyType.Modal)]
        [MaxLength(256)]
        public string PhoneNumber { get; set; }

       

        [LocalizedDisplayName("Email", KeyName = "UserProfile_Email", KeyType = KeyType.Modal)]
        [MaxLength(256)]
        public string Email { get; set; }

        [LocalizedDisplayName("昵称", KeyName = "UserProfile_NickName", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = "-")]
        [MaxLength(50)]
        public string NickName { get; set; } 

        #endregion

        #region 客户资源分配

        [LocalizedDisplayName("Vip等级ID", KeyName = "UserProfile_VipLevelID", KeyType = KeyType.Modal)]  //最低0级 
        [DefaultValue(0)]
        public int VipLevelID { get; set; }

        [LocalizedDisplayName("自定义标签", KeyName = "UserProfile_UserTagID", KeyType = KeyType.Modal)]
        [DefaultValue("SysRegister")]
        public string UserTagID { get; set; }

        [LocalizedDisplayName("分发帐号", KeyName = "UserProfile_AsignAccountMgrIDs", KeyType = KeyType.Modal)]
        public string AsignAccountMgrIDs { get; set; }

        [LocalizedDisplayName("独占资源", KeyName = "UserProfile_IsMonopoly", KeyType = KeyType.Modal)]
        [DefaultValue(false)]
        public bool IsMonopoly { get; set; }

        [LocalizedDisplayName("来源于资源文件", KeyName = "UserProfile_ResourceFile", KeyType = KeyType.Modal)]
        [MaxLength(512)]
        public string ResourceFile { get; set; }

        #endregion


        #region 用户|客户 量化跟进状态与备注
        [LocalizedDisplayName("量化权重积分", KeyName = "UserProfile_QuantizationScore", KeyType = KeyType.Modal)]
        [DefaultValue(1)]
        [Range(-999, 999)]
        public int QuantizationScore { get; set; }

        [LocalizedDisplayName("备注/跟进状态", KeyName = "UserProfile_Remarks", KeyType = KeyType.Modal)] 
        [DisplayFormat(NullDisplayText = "-")]
        public string Remarks { get; set; }

        #endregion

        #region 用户基因资料

        [LocalizedDisplayName("姓名", KeyName = "UserProfile_FullName", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = "-")]
        [MaxLength(128)]
        public string FullName { get; set; }

        [LocalizedDisplayName("性别", KeyName = "UserProfile_Gender ", KeyType = KeyType.Modal)]
        [DefaultValue(Genders.Unkown)]
        public Genders Gender { get; set; }
         
        [LocalizedDisplayName("出生日期", KeyName = "UserProfile_Birthday", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "1990-01-01")]
        public DateTime Birthday { get; set; }

        [LocalizedDisplayName("国家", KeyName = "UserProfile_Country", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        public string Country { get; set; }

        [LocalizedDisplayName("州/省", KeyName = "UserProfile_State", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        public string State { get; set; }

        [LocalizedDisplayName("城市", KeyName = "UserProfile_City", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        public string City { get; set; }

        [LocalizedDisplayName("县/区", KeyName = "UserProfile_District", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        public string District { get; set; }

        [LocalizedDisplayName("地址", KeyName = "UserProfile_Address", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        public string Address { get; set; }

        [LocalizedDisplayName("收货手机", KeyName = "UserProfile_RecievedPhoneNumber", KeyType = KeyType.Modal)]
        [MaxLength(256)]
        public string RecievedPhoneNumber { get; set; }

        #endregion

        #region 用户系统数据

        [LocalizedDisplayName("店铺ID", KeyName = "UserProfile_ShopID", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [StringLength(20, MinimumLength = 3)]
        public string ShopID { get; set; }

        [LocalizedDisplayName("操作用户", KeyName = "UserProfile_OperatedUserName", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string OperatedUserName { get; set; }

        [LocalizedDisplayName("创建日期", KeyName = "UserProfile_CreatedDate", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", NullDisplayText = "2000-01-01")]
        public DateTime CreatedDate { get; set; }


        [LocalizedDisplayName("操作日期", KeyName = "UserProfile_OperatedDate", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; }

        [LocalizedDisplayName("拉黑", KeyName = "UserProfile_IsBlock", KeyType = KeyType.Modal)]
        [DefaultValue(false)]
        public bool IsBlock { get; set; }

        #endregion
    }

    /// <summary>
    /// 量化因素中间表 
    /// </summary>
    public class UserQuantFactor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        public int ID { get; set; }

        [LocalizedDisplayName("UserProfileID", KeyName = "UserQuantFactor_UserProfileID", KeyType = KeyType.Modal)]
        [Required]
        public int UserProfileID { get; set; }


        [Required]
        [StringLength(20, ErrorMessage = "要求:量化因素ID")]
        [LocalizedDisplayName("量化因素ID", KeyName = "UserQuantFactor_QuantFactorID", KeyType = KeyType.Modal)]
        public string QuantFactorID { get; set; }


        #region 用户|客户 量化跟进状态与备注
        [Required]
        [LocalizedDisplayName("权重分", KeyName = "UserQuantFactor_Score", KeyType = KeyType.Modal)]
        [DefaultValue(0)]
        [Range(-99, 99)]
        public int Score { get; set; }

        [LocalizedDisplayName("备注/跟进状态", KeyName = "UserQuantFactor_FactorNameRemarks", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = "-")]
        public string FactorNameRemarks { get; set; }

        #endregion

        #region 用户系统数据

        [LocalizedDisplayName("店铺ID", KeyName = "UserQuantFactor_ShopID", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [StringLength(20, MinimumLength = 3)]
        public string ShopID { get; set; }

        [LocalizedDisplayName("操作用户", KeyName = "UserQuantFactor_OperatedUserName", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string OperatedUserName { get; set; }

        [LocalizedDisplayName("创建日期", KeyName = "UserQuantFactor_CreatedDate", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", NullDisplayText = "2000-01-01")]
        public DateTime CreatedDate { get; set; }


        [LocalizedDisplayName("操作日期", KeyName = "UserQuantFactor_OperatedDate", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; }

        
        #endregion
    }

    public class VipLevel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [LocalizedDisplayName("Vip等级ID", KeyName = "VipLevel_VipLevelID", KeyType = KeyType.Modal)]  //最低0级  
        public int VipLevelID { get; set; }

        [Required]
        [LocalizedDisplayName("Vip等级名称", KeyName = "VipLevel_VipLevelName", KeyType = KeyType.Modal)]  //最低0级 
        [DefaultValue("0级")]
        public string VipLevelName { get; set; }

        [Required]
        [LocalizedDisplayName("店铺ID", KeyName = "VipLevel_ShopID", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [StringLength(20, MinimumLength = 3)]
        public string ShopID { get; set; }
    }
    public class UserTag
    {
        [Key]
        [MaxLength(128)]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [LocalizedDisplayName("自定义标签ID", KeyName = "UserTag_TagID", KeyType = KeyType.Modal)]
        public string UserTagID { get; set; }

        [LocalizedDisplayName("自定义标签名称", KeyName = "UserTag_TagName", KeyType = KeyType.Modal)]
        [DefaultValue("系统注册")]
        public string TagName { get; set; }

    }

    public class AccountDownLog 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [LocalizedDisplayName("ID", KeyName = "AccountDownLog_AccountDownLogID", KeyType = KeyType.Modal)]
        public int ID { get; set; }
         
        [LocalizedDisplayName("帐户ID", KeyName = "AccountDownLog_AccountMgrID", KeyType = KeyType.Modal)]
        [MaxLength(18)]
        public string AccountMgrID { get; set; }

        [LocalizedDisplayName("资源来源ID", KeyName = "AccountDownLog_UserTagID", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        [DefaultValue("SysRegister")]
        public string UserTagID { get; set; }

        [LocalizedDisplayName("资源来源", KeyName = "AccountDownLog_TagName", KeyType = KeyType.Modal)]
        [StringLength(512)]
        public string TagName { get; set; }

        [LocalizedDisplayName("来源于资源文件", KeyName = "AccountDownLog_ResourceFile", KeyType = KeyType.Modal)]
        [MaxLength(512)]
        public string ResourceFile { get; set; }

        [LocalizedDisplayName("下載用户", KeyName = "AccountDownLog_OperatedUserName", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string OperatedUserName { get; set; }

        [LocalizedDisplayName("创建日期", KeyName = "AccountDownLog_CreatedDate", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", NullDisplayText = "2000-01-01")]
        public DateTime CreatedDate { get; set; }


        [LocalizedDisplayName("操作日期", KeyName = "AccountDownLog_OperatedDate", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; }

        [LocalizedDisplayName("单位序数", KeyName = "AccountDownLog_Rank", KeyType = KeyType.Modal)]
        [DefaultValue(0)]
        public int Rank { get; set; }
        
    }
    public class BlockList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [LocalizedDisplayName("ID", KeyName = "BlockList_BlockListId", KeyType = KeyType.Modal)]
        public int BlockListId { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [LocalizedDisplayName("姓名", KeyName = "BlockList_Name", KeyType = KeyType.Modal)]
        [StringLength(50)]
        public string Name { get; set; } 

        [LocalizedDisplayName("拉黑手机号", KeyName = "BlockList_PhoneNumber", KeyType = KeyType.Modal)]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [LocalizedDisplayName("拉黑EMail", KeyName = "BlockList_EMail", KeyType = KeyType.Modal)]
        [StringLength(50)]
        public string Email { get; set; }

        [LocalizedDisplayName("备注", KeyName = "BlockList_Remarks", KeyType = KeyType.Modal)]
        [StringLength(512)]
        public string Remarks { get; set; }

        [Required]
        [LocalizedDisplayName("ShopID", KeyName = "BlockList_ShopID", KeyType = KeyType.Modal)]
        [StringLength(20)]
        public string ShopID { get; set; }

        [LocalizedDisplayName("操作用户", KeyName = "BlockList_OperatedUserName", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string OperatedUserName { get; set; }
         
        [LocalizedDisplayName("操作日期", KeyName = "BlockList_OperatedDate", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; }
    }
     
    /// <summary>
    /// 客户量化因子（因素）
    /// </summary>
    public class QuantFactor
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [StringLength(20, ErrorMessage = "系统缺少分配ID")] 
        [LocalizedDisplayName("量化因素ID", KeyName = "QuantFactor_QuantFactorID", KeyType = KeyType.Modal)]
        public string QuantFactorID { get; set; }

        [LocalizedDisplayName("父类ID", KeyName = "QuantFactor_ParentsID", KeyType = KeyType.Modal)] 
        public string ParentsID { get; set; }


        [LocalizedDisplayName("因素名称", KeyName = "QuantFactor_FactorName", KeyType = KeyType.Modal)]
        public string FactorName { get; set; }

        [Required(ErrorMessage = "请输入量化因子模拟分值（1-99,建议百分制）。")]
        [Range(-99, 99)]
        [LocalizedDisplayName("因素分值", KeyName = "QuantFactor_Score", KeyType = KeyType.Modal)]
        [DefaultValue(0)]
        public int Score { get; set; }

        [Required]
        [Range(-99, 99)] 
        [LocalizedDisplayName("Top50排序", KeyName = "QuantFactor_Top50", KeyType = KeyType.Modal)]
        [DefaultValue(50)]
        public int TopRank50 { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "没有存在有效店铺")]
        [LocalizedDisplayName("店铺ID", KeyName = "QuantFactor_ShopID", KeyType = KeyType.Modal)]
        public string ShopID { get; set; }

        [StringLength(256)] 
        [LocalizedDisplayName("操作用户", KeyName = "QuantFactor_OperatedUserName", KeyType = KeyType.Modal)]
        public string OperatedUserName { get; set; }
         
        [LocalizedDisplayName("操作日期", KeyName = "QuantFactor_DateTime", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; } 
    }

    public class UserFinance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        [StringLength(20)]
        [LocalizedDisplayName("ID", KeyName = "UserFinance_UserFinanceID", KeyType = KeyType.Modal)]
        public string UserFinanceID { get; set; } 

        [LocalizedDisplayName("UserId", KeyName = "UserFinance_UserId", KeyType = KeyType.Modal)]
        [MaxLength(128)] 
        public string UserId { get; set; }

        [DefaultValue(0)]
        [LocalizedDisplayName("总金额", KeyName = "UserFinance_TotalAmount", KeyType = KeyType.Modal)]
        public decimal TotalAmount { get; set; }
        
        [Required]
        [StringLength(20, MinimumLength = 3)]
        [LocalizedDisplayName("店铺ID", KeyName = "UserFinance_ShopID", KeyType = KeyType.Modal)]
        public string ShopID { get; set; }

        [LocalizedDisplayName("起始日期", KeyName = "UserFinance_StartDate", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "2000-01-01")]
        public DateTime StartDate { get; set; }

        [LocalizedDisplayName("结束日期", KeyName = "UserFinance_EndDate", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "2000-01-01")]
        public DateTime EndDate { get; set; }
         
        [LocalizedDisplayName("操作日期", KeyName = "UserFinance_DateTime", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; }

        [LocalizedDisplayName("创建日期", KeyName = "UserFinance_CreatedDate", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "2000-01-01")]
        public DateTime CreatedDate { get; set; }
 
        [StringLength(20, MinimumLength = 3)]
        [LocalizedDisplayName("状态", KeyName = "UserFinance_StatusId", KeyType = KeyType.Modal)]
        public string StatusId { get; set; }
    }

    public class UserFinanceItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(20)]
        [LocalizedDisplayName("ID", KeyName = "UserFinanceItem_UserFinanceItemID", KeyType = KeyType.Modal)]
        public string UserFinanceItemID { get; set; }
         
        [StringLength(20)]
        [LocalizedDisplayName("UserFinanceID", KeyName = "UserFinanceItem_UserFinanceID", KeyType = KeyType.Modal)]
        public string UserFinanceID { get; set; }

        [LocalizedDisplayName("UserId", KeyName = "UserFinanceItem_UserId", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        public string UserId { get; set; }
  
        [DefaultValue(0)]
        [LocalizedDisplayName("金豬", KeyName = "UserFinanceItem_ItemAmount", KeyType = KeyType.Modal)]
        public decimal ItemAmount { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [LocalizedDisplayName("店铺ID", KeyName = "UserFinanceItem_ShopID", KeyType = KeyType.Modal)]
        public string ShopID { get; set; } 

        [LocalizedDisplayName("创建日期", KeyName = "UserFinanceItem_CreatedDate", KeyType = KeyType.Modal)] 
        public DateTime CreatedDate { get; set; }

        [LocalizedDisplayName("操作日期", KeyName = "UserFinance_DateTime", KeyType = KeyType.Modal)] 
        public DateTime OperatedDate { get; set; }

        [LocalizedDisplayName("状态", KeyName = "UserFinanceItem_StatusId", KeyType = KeyType.Modal)] 
        public string StatusId { get; set; }

        [LocalizedDisplayName("推广销售", KeyName = "UserFinanceItem_promoteAndSalesChannel", KeyType = KeyType.Modal)]
        public PromoteAndSalesChannel promoteAndSalesChannel { get; set; }

        [LocalizedDisplayName("外表ID", KeyName = "UserFinanceItem_TblKeyId", KeyType = KeyType.Modal)]
        public string TblKeyId { get; set; }
    } 
    public enum PromoteAndSalesChannel
    {
        UserRecommendation = 0 ,OrderSale = 1, WeixinShare = 2, WeixinViews = 3, WebSiteViews = 4, BlockChainEstate= 5
    }
}