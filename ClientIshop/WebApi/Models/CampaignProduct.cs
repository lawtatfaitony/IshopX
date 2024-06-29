using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class CampaignProduct
    {
        public string ProductId { get; set; }
        public string CampaignId { get; set; }
        public int Discount { get; set; }
        public decimal TradePrice { get; set; }
        public int Quantity { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
    }
}
