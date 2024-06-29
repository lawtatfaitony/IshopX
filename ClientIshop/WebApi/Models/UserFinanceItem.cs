using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class UserFinanceItem
    {
        public string UserFinanceItemId { get; set; }
        public string UserFinanceId { get; set; }
        public string UserId { get; set; }
        public decimal ItemAmount { get; set; }
        public string ShopId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime OperatedDate { get; set; }
        public string StatusId { get; set; }
        public int PromoteAndSalesChannel { get; set; }
        public string TblKeyId { get; set; }
    }
}
