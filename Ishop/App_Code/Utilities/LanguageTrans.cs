using System.Threading;
using System.Collections.Generic;
using System.Web;
using Ishop.Models.PubDataModal;
using Ishop.Context;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using LanguageResource;
using System.Linq;
using System.Data.Entity;
using System;

namespace Ishop.Utilities
{
    public partial class lang
    {
        private static string strLanguage = LangUtilities.LanguageCode;
        public static string Currentlang()
        {
            //zh-CHT
            string oLanguage = HttpContext.Current.Request.UserLanguages[0].ToString();
            return oLanguage;
        }
    }
    /// <summary>
    ///  modal 多语言 的实现 
    ///  [注意::默认语言(简体中文,不能改,为了更快速返回文字.其它可以随时进行翻译管理)]
    /// </summary> 
    public class LocalizedDisplayName : System.ComponentModel.DisplayNameAttribute
    {
        //private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        private string _Language = LangUtilities.LanguageCode;
        private string _defaultName = "";
        public LocalizedDisplayName(string defaultName)
        {
            //使用数据库方式 获取 翻译 版本
            _defaultName = defaultName;
        }
        public string KeyName { get; set; }
        public string KeyType {  get;  set; } 
        public override string DisplayName
        {
            get
            {
                using (Model1 db1 = new Model1())   //using (Context.ApplicationDbContext db1 = new Context.ApplicationDbContext())
                {
                    string returnValue = KeyName;
                    
                    returnValue = LangUtilities.GetString(KeyName);
                    if (returnValue == KeyName)
                    {
                        //如果没有,插入数据库,并且返回原字段名称
                        LanguageResource.Modal.Language Lang = getObjData(_defaultName);
                        LanguageResource.Modal.Language LangExits = db1.Languages.Find(Lang.KeyName);
                        if (LangExits == null)
                        { 
                            try
                            {
                                db1.Languages.Add(Lang);
                                db1.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                returnValue = KeyName;
                                throw ex;
                            }
                        }
                        returnValue = _defaultName;
                    }
                    return returnValue;
                }  
            }
        }

        public string GetLangFieldValue(string LanguageField, LanguageResource.Modal.Language LangDetails)
        {
            LanguageField = GetLanguageField(LanguageField);
            switch (LanguageField)
            {
                case "zh-CN":
                    return LangDetails.zh_CN;
                case "zh-SG":
                    return LangDetails.zh_CN;
                case "zh-HK":
                    return LangDetails.zh_HK;
                case "zh-hant-HK":
                    return LangDetails.zh;
                case "zh-TW":
                    return LangDetails.zh;
                case "zh":
                    return LangDetails.zh;
                case "ja":
                    return LangDetails.ja;
                case "ko":
                    return LangDetails.ko;
                case "en":
                    return LangDetails.en;
                case "fr":
                    return LangDetails.fr;
                case "de":
                    return LangDetails.de;
                case "ru":
                    return LangDetails.ru;
                case "ar":
                    return LangDetails.ar;
                case "es":
                    return LangDetails.es;
                default:
                    return LangDetails.en;
            }
        }
        /// <summary>
        ///  用于 插入一条[键名]记录.
        /// </summary>
        /// <param name="_defaultName"></param>
        /// <returns></returns>
        public LanguageResource.Modal.Language getObjData(string _defaultName)
        {
            _Language = GetLanguageField(_Language);
            string zh_HK = Microsoft.VisualBasic.Strings.StrConv(_defaultName, Microsoft.VisualBasic.VbStrConv.TraditionalChinese, 0);
            string zh = zh_HK;
            var LangData = new LanguageResource.Modal.Language { KeyName = KeyName, zh_CN = _defaultName, zh_HK = zh_HK, zh = zh, en = _defaultName, fr = _defaultName, de = _defaultName, ru = _defaultName, Remarks = string.Empty, KeyType = KeyType };
            return LangData;
        }

        //把 Language 转换为 Language.Field (表格字段)
        public string GetLanguageField(string Language)
        {
            if (Language == "zh-CN" || Language == "zh-HK" || Language == "zh-hant-hk")
            {
                return Language;
            }
            else
            {
                return Language = Language.Substring(0, 2);//只取前面两位语言代码, 例如 : zh:华语, en:泛英 fr:法语区
            }
        }

    }

    public class myRequiredAttributeAdapter : System.Web.Mvc.RequiredAttributeAdapter
    {
        public myRequiredAttributeAdapter(System.Web.Mvc.ModelMetadata metadata, ControllerContext context, RequiredAttribute attribute)
            : base(metadata, context, attribute) { }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            //string a = "Please Input {0}";
            string a = Lang.myRequiredAttributeAdapter_GetClientValidationRules_Input;
            string errorMessage = string.Format(a, Metadata.DisplayName);
            return new[] { new ModelClientValidationRequiredRule(errorMessage) };
        }

    }
 
















}