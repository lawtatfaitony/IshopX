using Ishop.Utilities;
using LanguageResource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ishop.ViewModes.Users
{
    public class AsignToAccountMgrID
    {
        [LocalizedDisplayName("帐户ID", KeyName = "AsignToAccountMgrID_AccountMgrID", KeyType = KeyType.Modal)] 
        public string AccountMgrID { get; set; }

        [LocalizedDisplayName("网站平台", KeyName = "AsignToAccountMgrID_SiteName", KeyType = KeyType.Modal)]
        public string SiteName { get; set; }
         
        [LocalizedDisplayName("帐号登录ID", KeyName = "AsignToAccountMgrID_LoginID", KeyType = KeyType.Modal)]
        public string LoginID { get; set; }

        [LocalizedDisplayName("注册手机", KeyName = "AsignToAccountMgrID_Mobile", KeyType = KeyType.Modal)]
        public string Mobile { get; set; }

        [LocalizedDisplayName("登录EMail", KeyName = "AsignToAccountMgrID_LoginEmail", KeyType = KeyType.Modal)]
        public string LoginEmail { get; set; }

        [Required]
        [LocalizedDisplayName("分配资源数量", KeyName = "AsignToAccountMgrID_Take", KeyType = KeyType.Modal)]
        [DefaultValue(500)]
        [Range(20,30000)]
        public int Take { get; set; }

        [Required]
        [LocalizedDisplayName("资源来源", KeyName = "AsignToAccountMgrID_UserTagID", KeyType = KeyType.Modal)] 
        public string UserTagID { get; set; }

        
        [LocalizedDisplayName("独占资源", KeyName = "AsignToAccountMgrID_IsMonopoly", KeyType = KeyType.Modal)]
        [DefaultValue(true)]
        public bool IsMonopoly { get; set; }

    }
    public class AsignToAccountMgrIDResult
    {
        [LocalizedDisplayName("帐户ID", KeyName = "AsignToAccountMgrIDResult_AccountMgrID", KeyType = KeyType.Modal)]
        public string AccountMgrID { get; set; }

        [LocalizedDisplayName("帐号登录ID", KeyName = "AsignToAccountMgrIDResult_LoginID", KeyType = KeyType.Modal)]
        public string LoginID { get; set; }
         
        [LocalizedDisplayName("分配资源数量", KeyName = "AsignToAccountMgrID_Take", KeyType = KeyType.Modal)] 
        public int Take { get; set; }

        [LocalizedDisplayName("生成资源", KeyName = "AsignToAccountMgrIDResult_GenerateResult", KeyType = KeyType.Modal)]
        public string GenerateResult { get; set; }

        [LocalizedDisplayName("通讯录下载", KeyName = "AsignToAccountMgrIDResult_VcardDownUrl", KeyType = KeyType.Modal)]
        public string VcardDownUrl { get; set; }
    }
   
}