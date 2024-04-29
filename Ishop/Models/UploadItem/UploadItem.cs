using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ishop.Models.UploadItem
{
     
    public class UploadItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [StringLength(100)]
        public string UploadItemId { set; get; }
         
        [StringLength(256)]
        public string TargetTalbeKeyID { set; get; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string ShopID { get; set; }
         
        [StringLength(256)]
        public string SubPath { set; get; }

        //Url路径
        [StringLength(256)]
        public string Url { set; get; }
        
        [StringLength(100)]
        public string RawName { get; set; }
         
        [StringLength(20)] 
        public string FileExt { get; set; }
         
        [Required]
        public int RankOrder { get; set; }
         
        [StringLength(256)]
        public string OperatedUserName { get; set; }
         
        [DisplayFormat(NullDisplayText = "2000-01-01")]
        public DateTime OperatedDate { get; set; }
    }
}