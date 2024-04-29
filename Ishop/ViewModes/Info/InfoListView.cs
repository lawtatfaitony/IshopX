using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Ishop.ViewModes.Info
{ 
    public class InfoListView
    { 
        public string InfoID { get; set; }
         
        public string UserTraceID { get; set; }
         
        public string InfoCateID { get; set; }
         
        public string Title { get; set; }
         
        public string InfoItemTemplateIDs { get; set; }
         
        public string TitleThumbNail { get; set; }
        
        public bool ShowTitleThumbNail { get; set; }
         
        public string SubTitle { get; set; }
         
        public string SeoKeyword { get; set; }
         
        public string SeoDescription { get; set; }
         
        public string VideoUrl { get; set; }
         
        public string Author { get; set; }
         
        public bool IsOriginal { get; set; }
         
        public string ShopStaffID { get; set; }
         
        public int Views { get; set; }

        [DefaultValue("zh-HK")]
        public string LanguageCode { get; set; }

        public string ShopID { get; set; }
 
        public string OperatedUserName { get; set; }
         
        public DateTime CreatedDate { get; set; }
         
        public DateTime OperatedDate { get; set; } 
    }
     
}