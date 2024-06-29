using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class Coupon
    {
        public string CouponId { get; set; }
        public string ShopId { get; set; }
        public string CouponName { get; set; }
        public decimal Conditions { get; set; }
        public decimal FaceValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IssueQuantity { get; set; }
        public int Mode { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
    }
}
