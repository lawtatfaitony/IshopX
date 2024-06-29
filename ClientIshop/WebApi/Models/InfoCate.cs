using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class InfoCate
    {
        public string InfoCateId { get; set; }
        public string ShopId { get; set; }
        public string PrarentsId { get; set; }
        public string InfoCateName { get; set; }
        public int Levels { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
        public string LanguageCode { get; set; }
    }
}
