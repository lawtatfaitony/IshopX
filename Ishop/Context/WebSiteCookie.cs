using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Net;
using Ishop.Utilities;
using System.Threading;
using Ishop.Validation;
using Ishop.Models.ProductMgr;
using Microsoft.Owin;
using LanguageResource;
using Common;

namespace Ishop.Context
{
    public class WebCookie 
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();

        private static HttpResponse Response
        {
            get
            {
                return HttpContext.Current.Response;
            }
        }
        private static HttpRequest Request
        {
            get
            {
                return HttpContext.Current.Request;
            }
        }
        //定义一个Cookie集合 
        private static HttpCookie CK
        {
            get
            {
                return Request.Cookies["CK"] as HttpCookie;
            }
            set
            {
                if (Request.Cookies["CK"] != null)
                {
                    Request.Cookies.Remove("CK");
                }
                Response.Cookies.Add(value);
            }
        }
        //New Cookie集合 
        private static HttpCookie newCK
        {
            get
            {
                HttpCookie httpCookie = new HttpCookie("CK");
                httpCookie.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
                httpCookie.Expires = DateTime.Now.AddYears(1);
                return httpCookie;
            }
        }
        //Remove Cookie集合 
        public static void RemoveCK()
        {
            if (CK == null)
                Response.Cookies.Remove("CK");
            else
                Response.Cookies["CK"].Expires = DateTime.Now.AddDays(-1);
        }
        //创建一个Cookie，判断用户登录状态 
        public static bool LoginOk
        {
            get
            {
                return CK == null ? false : bool.Parse(CK.Values["LoginOk"]);
            }
            set
            {
                HttpCookie httpCookie = CK == null ? newCK : CK;
                httpCookie.Values["LoginOk"] = value.ToString();
                CK = httpCookie;
            }
        }
        ////创建ShopID,整站使用 
        //public static string ShopID
        //{
        //    get
        //    {
        //        return CK == null ? string.Empty : CK.Values["ShopID"];
        //    }
        //    set
        //    {
        //        HttpCookie httpCookie = CK == null ? newCK : CK;
        //        httpCookie.Values["ShopID"] = value;
        //        CK = httpCookie;
        //    }
        //}
        //如果还有整站使用的Cookie 集合 可以写在此，可以参考LoginOK或ShopID的写法。 


        ////==独立的cookie==========================================================

        ////创建ShopID后台使用 
        public static string ShopID
        {
            get
            {
                if (Request.Cookies["ShopID"] == null)
                {
                    if (Request.QueryString["ShopID"] != null)
                    {
                        string shopId = Request.QueryString["ShopID"].ToString().Trim();
                        return shopId;
                    }
                    return "-";
                }
                return Request.Cookies["ShopID"].Value.ToLower();
            }
            set
            { 
                HttpCookie ck_ShopID = new HttpCookie("ShopID", value); 
                ck_ShopID.Expires = DateTime.Now.AddYears(3);
                HttpContext.Current.Response.Cookies.Add(ck_ShopID);
                Response.Cookies["ShopID"].Expires = DateTime.Now.AddYears(3); //设置过期方式2 
            }
        }
        //作廢 2024-5-4
        //public static string ShpIdX
        //{
        //    get
        //    {
        //        //string HostName = HttpContext.Current.Request.ServerVariables["HTTP_HOST"];
        //        string HostName = HttpContext.Current.Request.Url.ToString().ToLower().IndexOf("localhost") == -1 ? HttpContext.Current.Request.Url.Host.ToLower() : "localhost";  //Host值，  www.abc.com ; sh0001.abc.com ; abc.com 

        //        string DomainName = ConfigurationManager.AppSettings["DomainName"];
        //        HostName = HostName.Replace(DomainName, "");  //filter : abc.com  
        //        HostName = HostName.Replace(".", "");
        //        if (mvcCommeBase.IsNumber(HostName) || HostName == "localhost")
        //        {
        //            HostName = string.Empty;
        //        }
        //        string _ShpID = HostName;
        //        HostName = "sh0006"; //硬性定义为店铺 "sh0006"  需要多店铺时，去掉，并测试响应业务逻辑。
        //        switch (HostName)
        //        {
        //            case "sh0001":
        //                _ShpID = "sh0001";
        //                break;
        //            case "sh0006":
        //                _ShpID = "sh0006";
        //                break;
        //            case "www":
        //                _ShpID = "sh0001";
        //                break;
        //            case "seo":
        //                _ShpID = "sh0006";
        //                break;
        //            case "wwwxguardtop":
        //                _ShpID = "sh0006";
        //                break;
        //            case "xguardtop":
        //                _ShpID = "sh0006";
        //                break;
        //            case "starbilliantcn":
        //                _ShpID = "sh0006";
        //                break;
        //            default:
        //                _ShpID = "sh0001";
        //                break;
        //        }
        //        HttpCookie ck_ShpID = new HttpCookie("ShpID", _ShpID);
        //        ck_ShpID.Expires.AddYears(3);
        //        try
        //        {
        //            HttpContext.Current.Response.Cookies.Add(ck_ShpID);
        //        }
        //        catch
        //        {
        //            throw;
        //        }
        //        return _ShpID;
        //    }
        //    set
        //    {
        //        HttpCookie ck_ShpID = new HttpCookie("ShpID", value);
        //        ck_ShpID.Expires.AddYears(3);
        //        HttpContext.Current.Response.Cookies.Add(ck_ShpID);
        //        Response.Cookies["ShpID"].Expires = DateTime.Now.AddYears(3);
        //    }
        //}

        //作廢 2024-5-4
        //创建ShpID前端使用 
        public static string ShpID_OLD
        {
            get
            { 
                string HostName = HttpContext.Current.Request.Url.Host.ToLower().IndexOf("localhost")== -1 ?  HttpContext.Current.Request.Url.Host.ToLower() : "localhost" ;  //Host值，  www.abc.com ; sh0001.abc.com ; abc.com 
                string DomainName = ConfigurationManager.AppSettings["DomainName"];
                HostName = HostName.Replace(DomainName, "");  //filter : abc.com  
                HostName = HostName.Replace(".", "");
                string _ShpID = HostName;
                if (mvcCommeBase.IsIP(HostName) || HostName == "localhost") 
                {
                    _ShpID = "sh0006"; //For TEST
                    return _ShpID;
                }

                switch (HostName)
                {
                    case "sh0001":
                        _ShpID = "sh0001";   
                        break;
                    case "sh0006":
                        _ShpID = "sh0006";   
                        break;
                    case "www":
                        _ShpID = "sh0001";
                        break;
                    case "seo":
                        _ShpID = "sh0006";
                        break;
                    case "wwwxguardtop":
                        _ShpID = "sh0006";
                        break;
                    case "xguardtop":
                        _ShpID = "sh0006";
                        break;
                    default:
                        _ShpID = "sh0006";
                        break;
                } 
                HttpCookie ck_ShpID = new HttpCookie("ShpID", _ShpID);
                ck_ShpID.Expires.AddYears(3);
                try
                {
                    HttpContext.Current.Response.Cookies.Add(ck_ShpID);
                }
                catch
                {
                    throw ;
                }
                return _ShpID;
            }
            set
            {
                HttpCookie ck_ShpID = new HttpCookie("ShpID", value);
                ck_ShpID.Expires.AddYears(3);  
                HttpContext.Current.Response.Cookies.Add(ck_ShpID);
                Response.Cookies["ShpID"].Expires = DateTime.Now.AddYears(3);
            }
        }
        //获取请求用户的系统语言界面 
        /// <summary>
        /// 获取当前客户端的请求cookie [转移到 LangUtilities.LanguageCode]]
        /// 如果没有则获取 并写入session中
        /// 规则:  如果Session没有则获取cookie,还是没有,则获取当前客户端的系统请求语言.
        /// </summary>
        public static string Language
        { 
            get
            {
                return  LangUtilities.LanguageCode; 
            }
            set
            {
                HttpCookie ck_Language = new HttpCookie("Language", value);  
                //HttpContext.Current.Session["Language"] = value;  
                HttpContext.Current.Response.Cookies.Add(ck_Language);
                Response.Cookies["Language"].Expires = DateTime.Now.AddYears(3);
            }
        }

        //购物车Id (CartId)
        public static string CartId
        {
            get
            {
                string _CartId = DateTime.Now.Ticks.ToString() ;
                HttpCookie ck_CartId = new HttpCookie("CartId", _CartId);

                if (Request.Cookies["CartId"] != null )
                {
                    if (Request.Cookies["CartId"].Value == string.Empty)
                    {  
                        HttpContext.Current.Response.Cookies.Add(ck_CartId);
                        Response.Cookies["CartId"].Expires = DateTime.Now.AddYears(1);
                    }
                    return Request.Cookies["CartId"].Value.ToString();
                }
                 
                HttpContext.Current.Response.Cookies.Add(ck_CartId);
                Response.Cookies["CartId"].Expires = DateTime.Now.AddYears(1);

                return _CartId ; 
            }
            set
            {
                HttpCookie ck_CartId = new HttpCookie("CartId", value);   
                HttpContext.Current.Response.Cookies.Add(ck_CartId);
                Response.Cookies["CartId"].Expires = DateTime.Now.AddYears(1);
            }
        }

        // RecommUserId
        public static string RecommUserId
        {
            get
            {
                string _RecommUserId = string.Empty; 

                if (Request.Cookies["RecommUserId"] != null)
                {
                    if (Request.Cookies["RecommUserId"].Value == string.Empty)
                    {
                        return string.Empty;
                    }
                    _RecommUserId = Request.Cookies["RecommUserId"].Value.ToString();
                    return _RecommUserId;
                } 
                return _RecommUserId;
            }
            set
            {
                HttpCookie ck_RecommUserId = new HttpCookie("RecommUserId", value);
                HttpContext.Current.Response.Cookies.Add(ck_RecommUserId);
                Response.Cookies["RecommUserId"].Expires = DateTime.Now.AddYears(1);
            }
        }


        //创建ShpID前端使用 NEW MODE 2022-1-28
        public static string ShpID
        {
            get
            { 
                //優先使用Cookie, 首次使用 和Shop 表比較獲得ShopId
                if (Request.Cookies["ShpID"] != null)
                {
                    if (Request.Cookies["ShpID"].Value == string.Empty)
                    {
                        string shopID = Request.Cookies["ShpID"].Value.Trim();
                        return shopID;
                    } 
                }

                Uri uri = HttpContext.Current.Request.Url;

                string hostName = uri.Host.ToLower(); //Uri.Host 會返回 www.example.com，而不包括端口號 8080。

                //localhost的情況下返回config設置的默認店鋪ID
                if (hostName == "localhost")
                {
                    string defaultDomainName = ConfigurationManager.AppSettings["DomainName"]; //格式  "www.sunwaylink.com"
                    string defaultShopID = ConfigurationManager.AppSettings["defaultShopID"];
                    return defaultShopID; // "sh0006"; //默認店鋪
                }

                //去掉www.
                if(hostName.StartsWith("www"))
                {
                    hostName = hostName.Remove(0, 3);
                } 

                List<Shop> shopList = GetShopList();

                Shop shop = new Shop();
                
                if(shopList.Count()>0)
                {
                    shop = shopList.Where(c => c.HostName.Contains(hostName)).FirstOrDefault(); //HostName 必須是lower case
                }
                  
                if (shop==null)
                {
                    string defaultDomainName = ConfigurationManager.AppSettings["DomainName"]; //格式  "www.sunwaylink.com"
                    string defaultShopID = ConfigurationManager.AppSettings["defaultShopID"];
                    return defaultShopID; // "sh0006"; //默認店鋪
                }
                else
                {
                    //測試 http://sunwaylink.com:34322/HK/home/index
                    return shop.ShopID;
                }
            }
            set
            {
                HttpCookie ck_ShpID = new HttpCookie("ShpID", value);
                ck_ShpID.Expires.AddYears(3);
                HttpContext.Current.Response.Cookies.Add(ck_ShpID);
                Response.Cookies["ShpID"].Expires = DateTime.Now.AddYears(3);
            }
        }

        public static List<Shop> GetShopList()
        { 
            if (MemoryCacheHelper.Contains("SHOP_LIST"))
            {
                List<Shop> shopList = MemoryCacheHelper.GetCacheItem<List<Shop>>("SHOP_LIST");
                return shopList;
            }
            else
            {
                Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
                var shopList = db.Shops.ToList();
                DateTime dateTimeOffset = DateTime.Now.AddDays(90);
                MemoryCacheHelper.Set("SHOP_LIST", shopList, dateTimeOffset);
                return shopList;
            }
             
        }
    }
}