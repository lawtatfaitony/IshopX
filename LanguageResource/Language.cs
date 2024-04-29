namespace LanguageResource.Modal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /// <summary>
    /// 多语言  zh(中文地区): zh-TW(台湾) zh-CN(大陆) zh-HK(香港) zh-SG(新加波) zh-MO(澳门)
    ///         ja-JP(日语)
    ///         ar(阿拉伯语): ar-SA 沙特阿拉伯 ar-KW 科威特
    ///         en(英语)    : en-GB(英国) en-US(美国) 
    ///         de(德语)    : de-DE(德国) de-CH(德语-瑞士)
    ///         ru(俄语)    : ru-RU(俄语-俄罗斯)
    ///         es(西班牙)  : es-AR(西班牙语-阿根廷) es-PR(西班牙语-波多黎各)
    ///         参考代码:https://msdn.microsoft.com/zh-cn/library/kx54z3k7(VS.80).aspx
    /// </summary>
    [Table("Language")]
    public partial class Language
    {
        [Key]
        [StringLength(256)]
        public string KeyName { get; set; }

        [Required]
        public string KeyType { get; set; }

        public string zh_CN { get; set; }

        public string zh_HK { get; set; }
        
        public string ja { get; set; }

        public string ko { get; set; }
        public string zh { get; set; }

        public string en { get; set; }

        public string fr { get; set; }

        public string de { get; set; }

        public string ru { get; set; } 

        public string ar { get; set; }

        public string es { get; set; } 
        public string Remarks { get; set; }
    }
}
