using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class ProductCategory
    {
        public string ProductId { get; set; }
        public string CategoryId { get; set; }
        public int Id { get; set; }
    }
}
