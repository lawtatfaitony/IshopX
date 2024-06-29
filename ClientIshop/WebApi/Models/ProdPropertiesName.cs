using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class ProdPropertiesName
    {
        public string PropertiesNameId { get; set; }
        public string ProdCateId { get; set; }
        public string ProdCateName { get; set; }
        public string PropertiesName { get; set; }
        public int IsForTrading { get; set; }
        public int ShowPicture { get; set; }
    }
}
