using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class AccountMgr0
    {
        public string AccountMgrId { get; set; }
        public string ShopId { get; set; }
        public string WebSite { get; set; }
        public string SiteName { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public string LoginEmail { get; set; }
        public string ScurityEmail { get; set; }
        public string Mobile { get; set; }
        public string NickName { get; set; }
        public string PrivacyQuestion { get; set; }
        public string PrivacyAnswer { get; set; }
        public string CreatedByUserId { get; set; }
        public string AssignedToUserId { get; set; }
        public string Remarks { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
        public bool IsCer { get; set; }
    }
}
