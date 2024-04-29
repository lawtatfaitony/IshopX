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
    public class SourceStatistic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "SourceStatisticsID")]
        public int SourceStatisticsID { get; set; }

        [Required]
        [Display(Name = "TableKeyID")] 
        [MaxLength(128)] 
        public string TableKeyID { get; set; }

        [Display(Name = "OS")]
        [MaxLength(128)]
        public string OSVersion { get; set; }
         
        [LocalizedDisplayName("Title", KeyName = "SourceStatistics_Title", KeyType = KeyType.Modal)] 
        [StringLength(256)]
        public string Title { get; set; }

        [Required]
        [LocalizedDisplayName("UserId", KeyName = "SourceStatistics_UserId", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        [DefaultValue("NickName")]
        [DisplayFormat(NullDisplayText = "NickName")]
        public string UserId { get; set; }
         
        [MaxLength(128)] 
        public string RecommUserId { get; set; }

        [Required]
        [Display(Name = "IP")]
        [MaxLength(128)]
        public string IP { get; set; }
         
        [LocalizedDisplayName("SourceArea", KeyName = "SourceStatistics_SourceArea", KeyType = KeyType.Modal)]
        [MaxLength(256)]
        public string SourceArea { get; set; }

        [LocalizedDisplayName("SourceUrl", KeyName = "SourceStatistics_SourceUrl", KeyType = KeyType.Modal)]
        [MaxLength(512)]
        public string SourceUrl { get; set; }
         
        [Required]
        [LocalizedDisplayName("Duration(Mins)", KeyName = "SourceStatistics_Duration", KeyType = KeyType.Modal)]
        [DefaultValue(0)]
        [Column(TypeName = "decimal")]
        public decimal Duration { get; set; }
         
        [Required]
        [LocalizedDisplayName("LoadTime(ms)", KeyName = "SourceStatistics_loadTime", KeyType = KeyType.Modal)]
        [DefaultValue(0)]
        public int LoadTime { get; set; }
         
        [LocalizedDisplayName("CreatedDate", KeyName = "SourceStatistics_CreatedDate", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", NullDisplayText = "2000-01-01")]
        public DateTime CreatedDate { get; set; }
         
        [LocalizedDisplayName("LastUpdateDate", KeyName = "SourceStatistics_LastUpdateDate", KeyType = KeyType.Modal)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", NullDisplayText = "2000-01-01")]
        public DateTime LastUpdateDate { get; set; }

        [Required] 
        [LocalizedDisplayName("ShopID", KeyName = "SourceStatistics_ShopID", KeyType = KeyType.Modal)]
        [StringLength(20)]
        public string ShopID { get; set; } 

        [LocalizedDisplayName("OpenID", KeyName = "SourceStatistics_OpenID", KeyType = KeyType.Modal)]
        [StringLength(256)]
        public string OpenID { get; set; }

        [LocalizedDisplayName("VisitorIcon", KeyName = "SourceStatistics_SourceUrl", KeyType = KeyType.Modal)]
        [MaxLength(256)]
        public string VisitorIcon { get; set; }

        [LocalizedDisplayName("WxNickName", KeyName = "SourceStatistics_WxNickName", KeyType = KeyType.Modal)]
        [StringLength(50)]
        public string WxNickName { get; set; }

        [LocalizedDisplayName("IsValid", KeyName = "SourceStatistics_Status", KeyType = KeyType.Modal)]
        [DefaultValue(1)] //SourceStatisticStatus.IsValid = 1
        public SourceStatisticStatus Status { get; set; }
    } 
    public enum SourceStatisticStatus
    {
        [SelectDisplayName("InValid")]
        InValid = 0,
        [SelectDisplayName("IsValid")]
        IsValid  = 1 
    }
}