using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class District
    {
        public int DistrictId { get; set; }
        public string PostCode { get; set; }
        public string DistrictName { get; set; }
        public int ParentId { get; set; }
        public string FirstLetter { get; set; }
        public int Levels { get; set; }
    }
}
