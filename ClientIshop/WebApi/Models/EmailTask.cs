using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class EmailTask
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string EmailTemplate { get; set; }
        public string CallBackUrl { get; set; }
        public string SenderAccountArr { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
        public int Status { get; set; }
        public string ShopId { get; set; }
    }
}
