using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ishop.Areas.Mgr.ModelView
{
    public class DispatchNotePrintView
    {
        public string DefiniteTemplateNoteId { get; set; }

        public string TemplateNotePositionId {get;set;} //for update position 
        
        public string TableName { get; set; }
        public string DataField { get; set; }
        public string DataFieldValue { get; set; }

        public string FontSize { get; set; }
        public string MaxWidth { get; set; }
        
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class DataFieldsCollection
    { 
        public string DataFieldName { get; set; } 
        public bool Assigned { get; set; } 
 
    }
    
}