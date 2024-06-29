using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class AccountDownLog
    {
        public int Id { get; set; }
        public string UserTagId { get; set; }
        public string TagName { get; set; }
        public string ResourceFile { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime OperatedDate { get; set; }
        public string AccountMgrId { get; set; }
        public int Rank { get; set; }
    }
}
