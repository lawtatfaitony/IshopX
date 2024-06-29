using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class UserQuantFactor
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public string QuantFactorId { get; set; }
        public int Score { get; set; }
        public string FactorNameRemarks { get; set; }
        public string ShopId { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime OperatedDate { get; set; }
    }
}
