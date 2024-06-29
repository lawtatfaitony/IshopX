using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class EmailSms
    {
        public string Id { get; set; }
        public string ShopWebsite { get; set; }
        public string CredentialUserName { get; set; }
        public string SentFrom { get; set; }
        public string Pwd { get; set; }
        public string SmtpClient { get; set; }
        public int Port { get; set; }
        public string SignName { get; set; }
        public string AccessKey { get; set; }
        public string Secret { get; set; }
        public string TemplateCode { get; set; }
        public string ShopId { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
    }
}
