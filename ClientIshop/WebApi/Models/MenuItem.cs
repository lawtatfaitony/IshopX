using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class MenuItem
    {
        public string MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public string ParentsMenuItemId { get; set; }
        public string MenuLink { get; set; }
        public string Target { get; set; }
        public string ForRoleName { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
        public string EngMenuItemName { get; set; }
    }
}
