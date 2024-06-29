using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class ProductSku
    {
        public string ProductSkuId { get; set; }
        public string PropValueIds { get; set; }
        public string ProductId { get; set; }
        public string StyleNo { get; set; }
        public string ProductName { get; set; }
        public string SkuImage { get; set; }
        public decimal TradePrice { get; set; }
        public int Quantity { get; set; }
        public string PropertyDesc { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
