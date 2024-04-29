using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ishop.Models.CampaignMgr;
using Ishop.Models.ProductMgr;
  
namespace Ishop.Areas.Mgr.ModelView
{
    public class ShopStaffView
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        private string Id;
        public string UserName
        {

            get
            {
                var users = db.Users.Find(Id);

                return users.UserName;
            } 
            set
            {
                Id = value;
            }
        }
        public string StaffName { get; set; }

        public bool Assigned { get; set; }
    }
}