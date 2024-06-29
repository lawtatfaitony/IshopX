using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class InfoDetail
    {
        public string InfoId { get; set; }
        public string InfoCateId { get; set; }
        public string Title { get; set; }
        public string TitleThumbNail { get; set; }
        public bool ShowTitleThumbNail { get; set; }
        public string SubTitle { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoDescription { get; set; }
        public string InfoDescription { get; set; }
        public string VideoUrl { get; set; }
        public string Author { get; set; }
        public int Views { get; set; }
        public string ShopId { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime OperatedDate { get; set; }
        public string ShopStaffId { get; set; }
        public string InfoItemTemplateIds { get; set; }
        public bool IsOriginal { get; set; }
        public string UserTraceId { get; set; }
    }
}
