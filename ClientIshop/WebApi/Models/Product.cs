using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class Product
    {
        public string ProductId { get; set; }
        public string ProdCateId { get; set; }
        public string ProductName { get; set; }
        public string Title { get; set; }
        public string ProductImg { get; set; }
        public string StyleNo { get; set; }
        public string ProdDesc { get; set; }
        public string CategoryIds { get; set; }
        public string ShopId { get; set; }
        public string SupplierId { get; set; }
        public decimal TradePrice { get; set; }
        public decimal RetailPrice { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
        public string SaleStatusId { get; set; }
        public string VideoUrl { get; set; }
        public int CommisionRate { get; set; }
        public int ViewsIp { get; set; }
        public DateTime CreatedDate { get; set; }
        public string StaffId { get; set; }

        public virtual Prodcate ProdCate { get; set; }
    }
}
