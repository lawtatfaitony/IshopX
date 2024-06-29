using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
namespace WebApi.ModelView
{
    public class MgInfoModelView
    {
        public InfoDetail infoDetail { get; set; }

        public ShopStaff shopStaff { get; set; }

        public Shop shop { get; set; }

        public virtual ICollection<InfoDetail> InfoDetailRalateList { get; set; }
    }
    public class InfoIDs
    {
        public string SourceStatisticsId;
        public string IpStatitics_StartDate_Token;
        public string UserTraceId;
        public string UserId;
        public string InfoId;
        public string InfoCateId;
        public string ShopStaffId;
        public string ShopId;

        public string Title;
        public string InfoItemTemplateIDs;
        public string TitleThumbNail;
        public bool ShowTitleThumbNail;
        public string SubTitle;
        public string SeoKeyword;
        public string SeoDescription;
        public string InfoDescription;
        public string VideoUrl;
        public string Author;
        public bool IsOriginal;
        public int Views;
        public string OperatedUserName;
        public DateTime  CreatedDate;
        public DateTime OperatedDate;
    }
    public class UserTraceInfoIDset
    {
        public DateTime CreatedDate;
        public string InfoId;
        public string ShopId;
        public string UserTraceId;
        public string UserId; 
        public string VerifiedSHA;
    }

}
