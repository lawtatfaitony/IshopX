using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class SendMailInfo
    {
        public string SendMailInfoId { get; set; }
        public string SenderOfCompany { get; set; }
        public bool EnableSsl { get; set; }
        public bool EnableTsl { get; set; }
        public bool EnablePasswordAuthentication { get; set; }
        public string SenderServerHost { get; set; }
        public int SenderServerHostPort { get; set; }
        public string FromMailAddress { get; set; }
        public string SenderUserName { get; set; }
        public string SenderUserPassword { get; set; }
        public string ShopId { get; set; }
    }
}
