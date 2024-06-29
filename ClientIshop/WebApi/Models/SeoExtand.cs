using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class SeoExtand
    {
        public string SeoExtandId { get; set; }
        public string SeoKeyWord { get; set; }
        public string ParentsSeoExtandId { get; set; }
        public string ShopId { get; set; }
        public string UserId { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
        public string SeoHtmlContext { get; set; }
        public bool IsSeoHtmlContext { get; set; }
        public int TopRank50 { get; set; }
    }
}
