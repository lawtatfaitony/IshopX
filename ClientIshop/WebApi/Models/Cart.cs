using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public string CartId { get; set; }
        public string ProductSkuId { get; set; }
        public string SkuImageUrl { get; set; }
        public string ProductName { get; set; }
        public string PropertyDesc { get; set; }
        public decimal TradePrice { get; set; }
        public decimal RetailPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime OperatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
