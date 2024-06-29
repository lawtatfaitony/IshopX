using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class WeiXin
    {
        public int Id { get; set; }
        public string AppId { get; set; }
        public string Secret { get; set; }
        public string AccessToken { get; set; }
        public string Ticket { get; set; }
        public int ExpiresIn { get; set; }
        public DateTime Lastupdate { get; set; }
        public string ShopId { get; set; }
        public int TicketExpiresIn { get; set; }
        public string OperatedUserName { get; set; }
    }
}
