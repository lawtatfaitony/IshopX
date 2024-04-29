using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Ishop.ViewModes.Info
{
    public class ViewInfoItemTemplateOption
    {
        
        public string InfoItemTemplateID { get; set; }
         
        public string InfoItemTemplateName { get; set; }
          
        public bool Assigned { get; set; }
    }

    public class MyOriginTopView
    { 
        public string UserTraceID { get; set; }

        public string UserId { get; set; }

        public string InfoID { get; set; }

        public string Title { get; set; }
         
    }
}