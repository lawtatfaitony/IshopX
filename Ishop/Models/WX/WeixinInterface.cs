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
namespace Ishop.Models.PubDataModal
{


    public class WeiXin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Required] 
        [StringLength(256)]
        [Display(Name = "AppID")]
        public string AppID { get; set; }
         
        [StringLength(512)]
        [LocalizedDisplayName("密匙", KeyName = "WeiXin_secret", KeyType = KeyType.Modal)]
        public string secret { get; set; }
           
        [StringLength(512)]
        [LocalizedDisplayName("令牌", KeyName = "access_token", KeyType = KeyType.Modal)]
        public string access_token { get; set; }

        [DefaultValue(0)]
        [LocalizedDisplayName("令牌时效", KeyName = "WeiXin_expires_in", KeyType = KeyType.Modal)]
        public int expires_in { get; set; }

        [StringLength(512)]
        [LocalizedDisplayName("票据", KeyName = "WeiXin_ticket", KeyType = KeyType.Modal)]

        public string ticket { get; set; }
        [LocalizedDisplayName("票据时效", KeyName = "WeiXin_ticket_expires_in", KeyType = KeyType.Modal)]

        [DefaultValue(0)]
        public int ticket_expires_in { get; set; }

        [StringLength(256)]
        [LocalizedDisplayName("操作用户", KeyName = "WeiXin_OperatedUserName", KeyType = KeyType.Modal)]
        public string OperatedUserName { get; set; }

        [LocalizedDisplayName("更新日期", KeyName = "WeiXin_lastupdate", KeyType = KeyType.Modal)]
        public DateTime lastupdate { get; set; }

        [Required]
        [LocalizedDisplayName("店铺", KeyName = "WeiXin_ShopID", KeyType = KeyType.Modal)]
        [StringLength(20, MinimumLength = 3)]
        public string ShopID { get; set; }
          

    }

}