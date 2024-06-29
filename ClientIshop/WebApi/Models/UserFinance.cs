using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class UserFinance
    {
        public string UserFinanceId { get; set; }
        public string UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string ShopId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime OperatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string StatusId { get; set; }
    }
}
