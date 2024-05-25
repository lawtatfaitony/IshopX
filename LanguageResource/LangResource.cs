using System.Threading;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using LanguageResource.Modal;
using System;
using System.Web.Routing;

namespace LanguageResource
{
    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("IShopDBContext")
        {
        } 
    }

     public  class LangUtilities: IHttpHandler,IRequiresSessionState, IReadOnlySessionState
    {
        private static Model1 db = new Model1();
         
        private static string _Language { get; set; }
        public static string LanguageCode
        {
            get
            {
                _Language = "en-US";
               
                try
                {
                    if(HttpContext.Current != null)
                    {
                        try
                        { 
                            //Priority: Url Parameter=Language 
                            var wrapper = new HttpContextWrapper(HttpContext.Current);
                            if(wrapper!=null)
                            {
                                var routeData = RouteTable.Routes.GetRouteData(wrapper);
                                if (routeData != null)
                                {
                                    //var Language = routeData.Values["Language"];
                                    bool tryGetLanguageRoute = routeData.Values.TryGetValue("Language", out object Language);
                                    if (tryGetLanguageRoute == false || Language == null) //获取路由语言标识失败的情况
                                    {
                                        try
                                        {
                                            HttpRequest Request = HttpContext.Current.Request;
                                            if (Request.Cookies["Language"] == null)
                                            {
                                                var userLangs = Request.Headers["Accept-Language"].ToString();
                                                var firstLang = userLangs.Split(',').FirstOrDefault();
                                                firstLang = firstLang.ToLower();
                                                string languageCode = LangUtilities.StandardLanguageCode(firstLang);
                                                LangUtilities.LanguageCode = languageCode;
                                                return languageCode;
                                            }
                                        }
                                        catch
                                        {
                                            throw;
                                        }
                                    }
                                    if (Language != null) //存在语言标识路由值的情况
                                    {
                                        _Language = StandardLanguageCode(Language.ToString());
                                        return _Language;
                                    }
                                    else
                                    {
                                        //default
                                        _Language = Thread.CurrentThread.CurrentCulture.Name;
                                        _Language = LangUtilities.StandardLanguageCode(_Language);
                                    }
                                }
                                else
                                {
                                    if(HttpContext.Current.Request!=null)
                                    {
                                        try
                                        {
                                            HttpRequest Request = HttpContext.Current.Request;
                                            if (Request.Cookies["Language"] == null)
                                            {
                                                //var userLangs = Request.Headers["Accept-Language"].ToString();
                                                //var firstLang = userLangs.Split(',').FirstOrDefault();
                                                //firstLang = firstLang.ToLower();
                                                string firstLang = Request.UserLanguages[0];
                                                _Language = LangUtilities.StandardLanguageCode(firstLang);
                                                LangUtilities.LanguageCode = _Language;
                                                return _Language;
                                            }else
                                            {
                                                _Language = Request.Cookies["Language"].Value;
                                                return _Language;
                                            }
                                        }
                                        catch
                                        {
                                            throw;
                                        }
                                    }

                                    //default
                                    _Language = Thread.CurrentThread.CurrentCulture.Name;
                                    _Language = LangUtilities.StandardLanguageCode(_Language);
                                    return _Language;
                                }
                            }
                           
                        }catch
                        {
                            _Language = Thread.CurrentThread.CurrentCulture.Name;
                            _Language = StandardLanguageCode(_Language);
                            return _Language;
                        } 
                    } else
                    {
                        _Language = Thread.CurrentThread.CurrentCulture.Name;
                        _Language = StandardLanguageCode(_Language);
                        return _Language;
                    }
                }
                catch
                {
                    _Language = Thread.CurrentThread.CurrentCulture.Name;
                    _Language = StandardLanguageCode(_Language);
                    return _Language;
                } 

                //Localize
                if(_Language == "zh-HK")
                {
                    try
                    {
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-hant-HK");
                        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-hant-HK");
                    }catch{
                         
                    }  
                }
                else
                {
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_Language);
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(_Language);
                }
            
                return _Language;
            }
            set
            {
                _Language = StandardLanguageCode(value);
                HttpCookie ck_Language = new HttpCookie("Language", value);
                HttpContext.Current.Response.Cookies.Add(ck_Language);
            }
        }

        public static string ReturnCurrencyFormat(decimal amount)
        {
            string _language = LanguageCode.ToLower();
            string amount1;
            switch (_language)
            {  
                case "zh-cn":
                    amount1 = string.Format("￥{0:F1}", amount);
                    return amount1;
                case "zh-hk":
                    amount1 = string.Format("${0:F1}", amount);
                    return amount1;
                case "en-us":
                    amount1 = string.Format("${0:F1}", amount);
                    return amount1;
                default:
                    amount1 = string.Format("${0:F1}", amount);
                    return amount1;
            } 
        }
         
        public static string LanguageCodeFromSystem()
        {
            string _language = Thread.CurrentThread.CurrentCulture.Name;

            switch (_language)
            {
                case "zh-Hant-HK":
                    _language = "zh-HK";
                    break;
                case "zh-TW":
                    _language = "zh-HK";
                    break;
                case "en-UK":
                    _language = "en-US";
                    break;
                case "zh-Hant-AO":
                    _language = "zh-HK";
                    break;
                case "zh-CN":
                    _language = "zh-CN";
                    break;
                case "zh-HK":
                    _language = "zh-HK";
                    break;
                default:
                    _language = "zh-HK";
                    break;
            }

            return _language;
        }
         
        public static string GetStringReflectKeyName(string KeyName)
        {
            try
            {
                Lang tmp_Lang = new Lang();
                Type type = tmp_Lang.GetType();
                System.Reflection.PropertyInfo propertyInfo = type.GetProperty(KeyName);
                if (propertyInfo == null)
                {
                    return KeyName;
                }
                string rtn_str;

                object obj = propertyInfo.GetValue(tmp_Lang);
                rtn_str = (string)obj;

                return rtn_str;
            }
            catch
            {
                return KeyName;
            }
        }
       
        public static string StandardLanguageCode(string Language)
        {
            Language = Language.ToLower(); 
            switch (Language)
            {
                case "zh-hk":
                    return  "zh-HK";
                   
                case "zh-cn":
                    return  "zh-CN";
                    
                case "zh-hans-hk":
                    return "zh-HK";
                    
                case "zh-hants-hk":
                    return "zh-HK";
                   
                case "zh-tw":
                    return "zh-HK";
                     
                case "en-us":
                    return "en-US";
                    
                case "en-uk":
                    return "en-US";
                    
                case "zh-hant-ao":
                    return "zh-HK";
                   
                case "zh":
                    return "zh-HK";
                    
                case "cn":
                    return "zh-CN";
                    
                case "en":
                    return "en-US";
                    
                case "hk":
                    return "zh-HK";
                     
                default:
                    return "zh-HK"; 
            } 
        }

        public static string GetString(string keyName, string keyType)
        {
            Language LanguageDetails = new Language();
            var getLanguages = db.Database.SqlQuery<Language>("select * from Language");
            LanguageDetails = getLanguages.Where(c => c.KeyName == keyName).FirstOrDefault<Language>();
            string result;
            if (LanguageDetails == null)
            {
                string remarks = "-";
                db.Database.ExecuteSqlCommand(string.Format("INSERT INTO dbo.Language(KeyName ,KeyType , zh_CN , Remarks)VALUES('{0}','{1}' ,'{2}','{3}')", keyName, keyType, keyName, remarks));
                result = string.Format("{0}-(1)", keyName, keyType);
            }
            else
            {
                result = GetLangFieldValue(LanguageCode, LanguageDetails);
            }
           
            return result;
        }

        public static string GetString(string zhName, string keyName, string keyType)
        {
            Language LanguageDetails = new Language();
             
            var getLanguages = db.Database.SqlQuery<Language>("select * from Language");
            LanguageDetails = getLanguages.Where(c => c.KeyName == keyName).FirstOrDefault<Language>();
             
            string result;
            if (LanguageDetails == null)
            {
                string remarks = "-";
                db.Database.ExecuteSqlCommand(string.Format("INSERT INTO dbo.Language(KeyName ,KeyType , zh_CN , Remarks)VALUES('{0}','{1}' ,'{2}','{3}')", keyName, keyType, zhName, remarks));
                result = string.Format("{0}-(1)", keyName, keyType);
            }
            else
            {
                result = GetLangFieldValue(LanguageCode, LanguageDetails);
            }
            
            return result;
        }
        /// <summary>
        /// Get the current corresponding language domain by KeyName
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns>Exist: Return the corresponding language field Does not exist: return prompt KeyName=Query keyName</returns>

        public static string GetString(string keyName)
        {
            Model1 model1 = new Model1();
            string aa = model1.Database.Connection.ConnectionString;
            if(model1.Database.Exists())
            {
                Console.WriteLine(aa);
            }
            Language LanguageDetails = new Language();
            
            if (HttpContext.Current.Cache != null)
            {
                if (HttpContext.Current.Cache.Get("getLanguages") != null)
                {
                    var getLanguages1 = HttpContext.Current.Cache.Get("getLanguages") as List<Language>;
                    List<Language> QueryLang = getLanguages1.Where(c => c.KeyName == keyName).ToList();
                    if (QueryLang.Count > 0)
                    {
                        LanguageDetails = QueryLang.FirstOrDefault();
                    }
                    else
                    {
                        LanguageDetails = null;
                    }
                }
                else
                {
                    var getLanguages2 = model1.Languages.ToList();
                    LanguageDetails = getLanguages2.Where(c => c.KeyName == keyName).FirstOrDefault<Language>();
                    CacheHelper.SetCache("getLanguages", getLanguages2, System.TimeSpan.FromMinutes(600)); 
                }
            }
            else
            {
                var getLanguages3 = model1.Languages.ToList();
                LanguageDetails = getLanguages3.Where(c => c.KeyName == keyName).FirstOrDefault<Language>();
                CacheHelper.SetCache("getLanguages", getLanguages3, System.TimeSpan.FromMinutes(600));
            }

            string result;
            if (LanguageDetails == null)
            {
                result = keyName;
            }
            else
            {
                result = GetLangFieldValue(LanguageCode, LanguageDetails);
            }
            if (string.IsNullOrEmpty(result))
            {
                return keyName;
            }  
            return result;
        } 
        public static string GetString_FromDB_bak(string keyName)
        {
            Model1 model1 = new Model1();
            Language LanguageDetails = new Language();
            List<Language> getLanguages = new List<Language>();
            getLanguages = model1.Languages.ToList();
            LanguageDetails = getLanguages.Where(c => c.KeyName == keyName).FirstOrDefault<Language>();

            string result;
            if (LanguageDetails == null)
            {
                result = keyName;
            }
            else
            {
                result = GetLangFieldValue(LanguageCode, LanguageDetails);
            }
            if (string.IsNullOrEmpty(result))
            {
                return keyName;
            }
            //model1.Database.Connection.Close();
            //model1.Dispose();
            return result;
        }
        public static string GetString_Backup(string keyName)
        {
            ModelContext db1 = new ModelContext();
            Language LanguageDetails = new Language();
            DbRawSqlQuery<Language> getLanguages ;
            if (HttpContext.Current.Session["getLanguages"] == null)
            {
                getLanguages = db.Database.SqlQuery<Language>("select * from Language");
                HttpContext.Current.Session["getLanguages"] = getLanguages;
                HttpContext.Current.Session.Timeout = 120;
                LanguageDetails = getLanguages.Where(c => c.KeyName == keyName).FirstOrDefault<Language>(); 
            }
            else
            { 
                getLanguages = HttpContext.Current.Session["getLanguages"] as DbRawSqlQuery<Language>;
                LanguageDetails = getLanguages.Where(c => c.KeyName == keyName).FirstOrDefault<Language>();
            }
             
            string result;
            if (LanguageDetails == null)
            {
                result = keyName;
            }
            else
            {
                result = GetLangFieldValue(LanguageCode, LanguageDetails);
            }
            if(string.IsNullOrEmpty(result))
            {
                return keyName;
            }
            db1.Database.Connection.Close();
            db1.Dispose();
            return result;
        }
        /// <summary>
        /// Determine the language identifier and return to LanguageFieldValue
        /// </summary>
        /// <param name="LanguageField"></param>
        /// <param name="LangDetails"></param>
        /// <returns></returns>
        public static string GetLangFieldValue(string LanguageField, Language LangDetails)
        { 
            LanguageField = GetLanguageAbbr(LanguageField);
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
        /// Get multilingual data resources
        /// </summary>
        /// <param name="zhName">简体</param>
        /// <param name="keyName">键名</param>
        /// <param name="keyType">键名类型</param>
        /// <returns></returns>
        public static string GetKeyName(string zhName , string keyName, string keyType)
        {
            Language LanguageDetails = new Language();
            var getLanguages = db.Database.SqlQuery<Language>("select * from Language");
            LanguageDetails = getLanguages.Where(c => c.KeyName == keyName).FirstOrDefault<Language>();
            string result;
            if (LanguageDetails == null)
            {
                string remarks = "-";
                db.Database.ExecuteSqlCommand(string.Format("INSERT INTO dbo.Language(KeyName ,KeyType , zh_CN , Remarks)VALUES('{0}','{1}' ,'{2}','{3}')", keyName, keyType, zhName, remarks));
                result = string.Format("{0}-(1)", keyName, keyType);
            }
            else
            {
                result = GetLangFieldValue(LanguageCode, LanguageDetails);
            } 
            return result;
        }

        /// <summary>
        /// 获取多语言数据资源
        /// </summary>
        /// <param name="zhName">简体</param>
        /// <param name="keyName">键名</param>
        /// <param name="keyType">键名类型</param>
        /// <returns></returns>
        public static string GetKeyName(string keyName)
        {
            Language LanguageDetails = new Language();
            var getLanguages = db.Database.SqlQuery<Language>("select * from Language");
            LanguageDetails = getLanguages.Where(c => c.KeyName == keyName).FirstOrDefault<Language>();
            string result;
            if (LanguageDetails == null)
            { 
                result = string.Format("{0}-(1)", keyName);
            }
            else
            {
                result = GetLangFieldValue(LanguageCode, LanguageDetails);
            }
            return result;
        }
        
        //把 Language 转换为 Language.Field (表格字段)
        public static string GetLanguageAbbr(string LanguageCode)
        {
            if (LanguageCode == "zh-CN" || LanguageCode == "zh-HK")
            {
                return LanguageCode;
            }
            else
            {
                //只取前面两位语言代码, 例如 : zh:华语, en:泛英 fr:法语区
                LanguageCode = LanguageCode.Substring(0,2);
                return LanguageCode;
            }
        }
        /// <summary>
        /// 去除HTML 标签
        /// </summary>
        /// <param name="html"></param>
        /// <param name="length">Length参数可以根据传入值取固定长度的值。用于生成文章摘要比较方便。</param>
        /// <returns></returns>
        public static string ReplaceHtmlTag(string html, int length = 0)
        {
            string strText = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            strText = System.Text.RegularExpressions.Regex.Replace(strText, "&[^;]+;", "");

            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);

            return strText;
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }

        bool IHttpHandler.IsReusable
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
    } 
    /// <summary>
    /// 转到 Language.cs  命名空间 LanguageResource.Modal
    /// 多语言  zh(中文地区): zh-TW(台湾) zh-CN(大陆) zh-HK(香港) zh-SG(新加波) zh-MO(澳门)
    ///         ja-JP(日语)
    ///         ar(阿拉伯语): ar-SA 沙特阿拉伯 ar-KW 科威特
    ///         en(英语)    : en-GB(英国) en-US(美国) 
    ///         de(德语)    : de-DE(德国) de-CH(德语-瑞士)
    ///         ru(俄语)    : ru-RU(俄语-俄罗斯)
    ///         es(西班牙)  : es-AR(西班牙语-阿根廷) es-PR(西班牙语-波多黎各)
    ///         参考代码:https://msdn.microsoft.com/zh-cn/library/kx54z3k7(VS.80).aspx
    /// </summary>
    //public class LanguageView
    //{
    //    [Key]
    //    [Required]
    //    [StringLength(256, MinimumLength = 2, ErrorMessage = "需要对应的Key才能获取相应语言")]
    //    [Display(Name = "键名", Order = 0)]
    //    public string KeyName { get; set; }

    //    [Required]
    //    [Display(Name = "类型", Order = 1)]
    //    public string KeyType { get; set; }

    //    [Display(Name = "简体中文", Order = 2)]
    //    public string zh_CN { get; set; }

    //    [Display(Name = "香港繁体", Order = 3)]
    //    public string zh_HK { get; set; }

    //    [Display(Name = "华语繁体", Order = 4)]
    //    public string zh { get; set; }

    //    [Display(Name = "英语", Order = 5)]
    //    public string en { get; set; }

    //    [Display(Name = "法语", Order = 6)]
    //    public string fr { get; set; }

    //    [Display(Name = "德语", Order = 7)]
    //    public string de { get; set; }

    //    [Display(Name = "俄语", Order = 8)]
    //    public string ru { get; set; }

    //    [Display(Name = "阿拉伯语", Order = 9)]
    //    public string ar { get; set; }

    //    [Display(Name = "西班牙", Order = 10)]
    //    public string es { get; set; }
    //    [Display(Name = "备注", Order = 11)]
    //    public string Remarks { get; set; }
    //}
    /// <summary>
    /// 键名类型
    /// </summary>
    public class KeyType
    {
        /// <summary>
        /// 规则1:Modal.PropertyName  举例: Modal.AspNetUsers.UserName  -Modal(TableName)名称.FieldName(字段名称)
        /// </summary>
        public const string Modal = "Modal_PropertyName";

        /// <summary>
        /// 规则2:ModalView_PropertyName  举例: ModelView_loginViewMobileModel_Password 模型视图的字段名称 -ModalView(视图模型)名称_FieldName(字段名称)
        /// </summary>
        public const string ModalView = "ModalView_PropertyName";

        /// <summary>
        /// 规则3:ControllerName/ClassName_ActionMethod_ActionReturnVar 举例: Controller/ClassName_Infolist_index_Message 需要最少定义4个分类类目 页面类型的消息返回提示 
        /// </summary>
        public const string ActionReturn = "ControllerName_ActionMethod_ActionReturnVar";

        /// <summary>
        ///  规则4:ControllerName_ActionMethod_JsMethod_JsVar  举例: Controller_Account_login_getPhoneNumber_PhoneNumber 视图页面的JS消息提示 
        /// </summary>
        public const string JS = "ControllerName_ActionMethod_JsMethod_JsVar";
       
        /// <summary>
        /// 规则5:ControllerName_Views_DefinitedUI_ID 举例: Account_RegMobile_DefinitedUI_PhoneNumber 手机注册页面,自定义UI,如有ID 则加上ID 
        /// </summary>
        public const string DefinitedUI = "ControllerName_Views_DefinitedUI_ID";

        /// <summary>
        /// 规则6:Ishop_Views_GeneralUI_Name 举例: Views_GeneralUI_Submit 手机注册页面,[通用]UI按钮,Name为属性名,如Submit提交
        /// </summary>
        public const string GeneralUI = "Views_GeneralUI_Name";
        
        /// <summary>
        /// 规则7,ControllerName_Views_DefinitedTag_ID 举例: Account_RegMobileViews_DefinitedUI_DefinitedTag_P1 标签(<p>,<span><a>等等)说明段落,短语,警告语等等_
        /// </summary>
        public const string DefinitedTag = "ControllerName_Views_DefinitedTag_ID";

        /// <summary>
        /// 规则8,ControllerName_Views_Name 举例: Account_ForgotPassword_Title View的header_title
        /// </summary>
        public const string ViewHeader = "ControllerName_Views_Name";

        /// <summary>
        /// 规则9,AttributeExtensions_AttributeClassName 举例: AttributeExtensions_PhoneNumberAttribute [TextBox]验证扩展_例如 email,phonenumber等等
        /// </summary>
        public const string AttributeExtensions = "AttributeExtensions";
    }
}
