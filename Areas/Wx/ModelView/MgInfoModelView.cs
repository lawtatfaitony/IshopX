using Ishop.AppCode.Utilities;
using Ishop.Models.Info;
using Ishop.Models.ProductMgr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ishop.Areas.WxMiniProgram.ModelView
{
    public class MgInfoModelView
    {
        public InfoDetail infoDetail { get; set; }
      
        public ShopStaff shopStaff { get; set; }

        public Shop shop { get; set; }

        public virtual ICollection<InfoDetail> InfoDetailRalateList { get; set; }
    }
}