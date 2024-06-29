using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class DispatchNote
    {
        public string DispatchNoteId { get; set; }
        public string OrderId { get; set; }
        public string StyleNo { get; set; }
        public string PaymentNo { get; set; }
        public int Quantity { get; set; }
        public string RecommUserId { get; set; }
        public string Recipient { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string TelePhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Remarks { get; set; }
        public string ShopId { get; set; }
        public int DispatchNoteStatus { get; set; }
        public string StatusName { get; set; }
    }
}
