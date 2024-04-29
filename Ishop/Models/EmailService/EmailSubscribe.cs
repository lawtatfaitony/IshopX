using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Ishop.Models
{
     
    public class EmailSubscribe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [StringLength(30)]
        public string Id { set; get; }

        [Required]
        [StringLength(256)]
        [EmailAddress]
        public string Email { set; get; }
         
        [StringLength(100)]
        public string SubscriberName { get; set; }
         
        [StringLength(200)] 
        public string Remarks { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string ShopId { get; set; }
         
        [StringLength(256)]
        public string OperatedUserName { get; set; }
        
        public DateTime OperatedDate { get; set; }
         
        [StringLength(30)]
        public string EmailTaskId { get; set; }
         
        [DefaultValue(-1)] // 预设值 = -1 ， 待发送=0 ，已发送完成=1 
        public int Status { get; set; }
    }

    public class EmailTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [StringLength(30)]
        public string Id { set; get; }

        [Required]
        [StringLength(256)]
        public string Name { set; get; }

        [Required]
        [StringLength(256)]
        public string EmailTemplate { set; get; }

        [StringLength(20)]
        public string Subject { set; get; }

        [StringLength(512)]
        public string CallBackUrl { set; get; }

        [Required]
        [StringLength(2000)]
        public string SenderAccountArr { get; set; }
                 
        [StringLength(256)]
        public string OperatedUserName { get; set; }

        public DateTime OperatedDate { get; set; }

        public int Status { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string ShopId { get; set; }
    }

    public class SendMailInfo  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [StringLength(128)]
        public string SendMailInfoId { get; set; }
        [Required]
        public string SenderOfCompany { get; set; }
        [Required]
        public bool EnableSSL { get; set; }
        [Required]
        public bool EnableTSL { get; set; }
        [Required]
        public bool EnablePasswordAuthentication { get; set; }
        [Required]
        public string SenderServerHost { get; set; }
        [Required]
        public int SenderServerHostPort { get; set; }
        [EmailAddress]
        public string FromMailAddress { get; set; } 
        public string SenderUserName { get; set; }
        [Required]
        public string SenderUserPassword { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string ShopId { get; set; }
    }

    public class SendMailInfoSelect
    {

        [JsonProperty("label")]
        public string label { get; set; }


        [JsonProperty("value")]
        public string value { get; set; }

    }

    public class MailTaskJobRequest
    {
        public bool Success { get; set; }
        public SendMailInfo SendMailInfo { get; set; }
        public string[] ToMailArray { get; set; }
        public string Subject { get; set; }
        public string EmailBody { get; set; }
    }
}