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
    public class UserProfileRemarks
    { 
        public int UserProfileID { get; set; }

       
        [LocalizedDisplayName("姓名", KeyName = "UserProfile_FullName", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = "-")]
        [MaxLength(128)]
        public string FullName { get; set; }

        [LocalizedDisplayName("昵称", KeyName = "UserProfile_NickName", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = "-")]
        [MaxLength(50)]
        public string NickName { get; set; }

        [LocalizedDisplayName("备注/跟进状态", KeyName = "UserProfile_Remarks", KeyType = KeyType.Modal)]
        [DisplayFormat(NullDisplayText = "-")]
        public string Remarks { get; set; }
    }
}