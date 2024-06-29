using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class ShopStaff
    {
        public string ShopStaffId { get; set; }
        public string ShopId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string StaffName { get; set; }
        public bool IsConfirmed { get; set; }
        public string Qrcode { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
        public string ContactTitle { get; set; }
        public string Introduction { get; set; }
        public string ChannelId { get; set; }
        public string OtherChannelName { get; set; }
        public string OtherQrcode { get; set; }
        public string IconPortrait { get; set; }
        public string PublicNo { get; set; }
    }
}
