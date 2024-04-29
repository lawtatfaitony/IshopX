using Ishop.Utilities;
using LanguageResource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ishop.Areas.Mgr.ModelView
{ 
    public class UserProfileView
    {  
        [LocalizedDisplayName("手机", KeyName = "UserProfile_PhoneNumber", KeyType = KeyType.Modal)]
        [MaxLength(256)]
        public string PhoneNumber { get; set; } 

        [LocalizedDisplayName("Vip等级ID", KeyName = "UserProfile_VipLevelID", KeyType = KeyType.Modal)]  //最低0级 
        [DefaultValue(0)]
        public int VipLevelID { get; set; }

        [LocalizedDisplayName("自定义标签", KeyName = "UserProfile_UserTagID", KeyType = KeyType.Modal)]
        [DefaultValue("SysRegister")]
        public string UserTagID { get; set; } 
        
        [LocalizedDisplayName("出生日期", KeyName = "UserProfile_Birthday", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "1990-01-01")]
        public DateTime Birthday { get; set; } 

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

        [LocalizedDisplayName("独占资源", KeyName = "UserProfile_IsMonopoly", KeyType = KeyType.Modal)]
        [DefaultValue(false)]
        public bool IsMonopoly { get; set; }
    }
    public enum RenderAmountUnit
    {
        [SelectDisplayName("Random 50")]
        Min = 50 ,
        [SelectDisplayName("Random 100")]
        Mid = 100,
        [SelectDisplayName("Random 200")]  // Lang.ModalView_RenderAmountUnit200
        Max = 200,
        [SelectDisplayName("Random 500")]
        Max1 = 500,
        [SelectDisplayName("Random 1500")]
        Max2 = 1500,
        [SelectDisplayName("Random 2000")]
        Max3 = 2000
    }
    public enum RenderAreaCode
    {
        [SelectDisplayName("中国")]
        CN = 1,
        [SelectDisplayName("香港")]
        HK = 2,
        [SelectDisplayName("新加波")]
        SG = 3,
        [SelectDisplayName("台湾")]
        TW = 4,
        [SelectDisplayName("泰国")]
        TH = 5
    }
    public class RenderPhoneNumber
    {
        [Required]
        [LocalizedDisplayName("区域", KeyName = "RenderPhoneNumber_AreaCode", KeyType = KeyType.ModalView)]
        [DefaultValue(RenderAreaCode.CN)]
        public RenderAreaCode AreaCode { get; set; }

        [LocalizedDisplayName("生成数量", KeyName = "RenderPhoneNumber_RenderAmount", KeyType = KeyType.ModalView)]
        [DefaultValue(RenderAmountUnit.Min)]
        public RenderAmountUnit RenderAmount { get; set; } 

        [LocalizedDisplayName("数据库保存", KeyName = "UserProfile_IsSaveDB", KeyType = KeyType.Modal)]
        [DefaultValue(false)]
        public bool IsSaveDB { get; set; }

        [LocalizedDisplayName("生成结果", KeyName = "RenderPhoneNumber_RenderResult", KeyType = KeyType.Modal)]  
        public string RenderResult { get; set; }
    }
}