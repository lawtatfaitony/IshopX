using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class UserAddress
    {
        public string UserAddressId { get; set; }
        public string UserId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string TelePhoneNumber { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
        public string ShopId { get; set; }
    }
}
