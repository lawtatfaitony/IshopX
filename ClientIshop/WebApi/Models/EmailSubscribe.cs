using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class EmailSubscribe
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string SubscriberName { get; set; }
        public string Remarks { get; set; }
        public string ShopId { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
        public string EmailTaskId { get; set; }
        public int Status { get; set; }
    }
}
