using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class TableState
    {
        public string Id { get; set; }
        public string TableName { get; set; }
        public string StatusId { get; set; }
        public string StatusName { get; set; }
        public string LanguageCode { get; set; }
    }
}
