using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class Shop
    {
        public string ShopId { get; set; }
        public string ShopName { get; set; }
        public string ShopLogo { get; set; }
        public string FooterTemplate { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string ShopCurrency { get; set; }
        public string PhoneNumber { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
        public string WeixinQrcode { get; set; }
        public string WeiboQrcode { get; set; }
        public string ToutiaoQrcode { get; set; }
        public string FbQrcode { get; set; }
        public string CerPath { get; set; }
    }
}
