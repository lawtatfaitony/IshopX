using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class TemplateNotePosition
    {
        public string TemplateNotePositionId { get; set; }
        public string TableName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string MaxWidth { get; set; }
        public string FontSize { get; set; }
        public string DataField { get; set; }
    }
}
