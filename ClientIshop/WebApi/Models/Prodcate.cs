using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class Prodcate
    {
        public Prodcate()
        {
            Product = new HashSet<Product>();
        }

        public string ProdCateId { get; set; }
        public int Levels { get; set; }
        public string ParentsProdCateId { get; set; }
        public string ProdCateName { get; set; }
        public int IsLock { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
