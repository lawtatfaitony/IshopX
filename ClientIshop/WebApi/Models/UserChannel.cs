using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class UserChannel
    {
        public string UserChannelId { get; set; }
        public string ChannelId { get; set; }
        public string LoginId { get; set; }
        public string ChannelQrcode { get; set; }
        public string ShopId { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
        public string UserId { get; set; }
        public string ChannelName { get; set; }
    }
}
