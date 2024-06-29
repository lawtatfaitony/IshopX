using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class TableIdentity
    {
        public string TableName { get; set; }
        public int TableIdentityId { get; set; }
        public DateTime OperatedDate { get; set; }
    }
}
