using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class UploadItem
    {
        public string UploadItemId { get; set; }
        public string TargetTalbeKeyId { get; set; }
        public string ShopId { get; set; }
        public string SubPath { get; set; }
        public string Url { get; set; }
        public string RawName { get; set; }
        public string FileExt { get; set; }
        public int RankOrder { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
    }
}
