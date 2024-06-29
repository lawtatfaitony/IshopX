using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class UserProfile
    {
        public string UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int VipLevelId { get; set; }
        public string UserTagId { get; set; }
        public string ResourceFile { get; set; }
        public string Remarks { get; set; }
        public string NickName { get; set; }
        public string FullName { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string RecievedPhoneNumber { get; set; }
        public string ShopId { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime OperatedDate { get; set; }
        public bool IsBlock { get; set; }
        public string AsignAccountMgrIds { get; set; }
        public bool IsMonopoly { get; set; }
        public int UserProfileId { get; set; }
        public string WechatId { get; set; }
        public int QuantizationScore { get; set; }
        public string ParentUserId { get; set; }
        public string UserIcon { get; set; }
        public string FinanceAmount { get; set; }
        public string Score { get; set; }
        public string OpenId { get; set; }
    }
}
