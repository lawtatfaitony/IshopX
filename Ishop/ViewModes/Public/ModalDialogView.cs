using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ishop.Areas.Mgr.Models
{
    public class ModalDialogView
    {
        public string MsgCode { get; set; }    // 1=Success 0=Fail -1=Other 

        public string Message { get; set; }

        public List<Dictionary<string,string>> ListData { get; set; }
    }
    public class ReturnToJson
    {
        public string ListName { get; set; }  
         
        public List<string> ListData { get; set; }
    }
    //提交证书密码
    public class CerPasswordModalView
    { 
        public string CerPassword { get; set; }   

        public string ReturnCerPassUrl { get; set; } 
    }
}