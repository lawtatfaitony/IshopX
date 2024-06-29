using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class DefiniteTemplateNote
    {
        public string DefiniteTemplateNoteId { get; set; }
        public string DefiniteTemplateNoteName { get; set; }
        public string DefiniteTemplatePicture { get; set; }
        public string RecipientColFields { get; set; }
        public string SenderColFields { get; set; }
        public string ShopId { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string SenderUserAddressId { get; set; }
    }
}
