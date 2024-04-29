using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ishop.Models.CampaignMgr;
using Ishop.Models.ProductMgr;
namespace Ishop.Areas.Mgr.ModelView
{
    public class ShopCampModelview: Campaign
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        public int CampProductQty 
        {
            get
            {
                var campaignProducts = db.CampaignProducts.Where(c => c.CampaignID.Contains(this.CampaignID));

                return campaignProducts.Count<CampaignProduct>();
            }
           
        }
        public IEnumerable<Product> campaignProducts
        {
            get
            {
                var campaignProducts = db.CampaignProducts.Where(c => c.CampaignID.Contains(this.CampaignID));
                List<Product> list = new List<Product>();
                foreach(var item in campaignProducts)
                {
                    Product product = db.Products.Find(item.ProductID);
                    list.Add(product);
                }
                return list.ToList();
            }
        }
    }
}