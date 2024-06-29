using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class VipLevel
    {
        public int VipLevelId { get; set; }
        public string VipLevelName { get; set; }
        public string ShopId { get; set; }
    }
}
