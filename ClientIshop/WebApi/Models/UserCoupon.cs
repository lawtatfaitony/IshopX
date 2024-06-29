using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class UserCoupon
    {
        public string UserCouponId { get; set; }
        public string CouponId { get; set; }
        public string UserName { get; set; }
        public DateTime OperatedDate { get; set; }
    }
}
