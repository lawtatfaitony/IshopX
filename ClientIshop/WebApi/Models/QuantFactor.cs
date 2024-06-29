using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class QuantFactor
    {
        public string QuantFactorId { get; set; }
        public string ParentsId { get; set; }
        public string FactorName { get; set; }
        public int TopRank50 { get; set; }
        public string ShopId { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
        public int Score { get; set; }
    }
}
