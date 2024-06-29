using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public decimal AdjustFee { get; set; }
        public decimal DiscountFee { get; set; }
        public decimal Payment { get; set; }
        public decimal TotalRetailPrice { get; set; }
        public string CampaignId { get; set; }
        public string CampaignName { get; set; }
        public string CouponId { get; set; }
        public decimal FaceValue { get; set; }
        public string PaymentNo { get; set; }
        public string PayGateName { get; set; }
        public string RecommUserId { get; set; }
        public decimal TotalCommision { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ShopId { get; set; }
        public string StatusId { get; set; }

        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
