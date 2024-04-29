using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ishop.DAL;
using System.Data.Entity.Infrastructure.Interception;
using System.ComponentModel.DataAnnotations;
using Ishop.Context;
using Ishop.Utilities;
using System.Threading;
using System.Globalization;
using LanguageResource;
using System.Web.Caching;
using System.Collections;
namespace Ishop
{
    public class MvcApplication : System.Web.HttpApplication
    { 
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
             
           // RouteConfig.RegisterRoutes(RouteTable.Routes, LangUtilities.LanguageCode);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //DbInterception.Add(new IshopInterceptorTransientErrors());
            //DbInterception.Add(new IshopInterceptorLogging());

            //System.Data.Entity.Database.SetInitializer<ApplicationDbContext>(new IshopInitializer());  //设置初始化数据库以及种子数据 
            System.Data.Entity.Database.SetInitializer<ApplicationDbContext>(null);  //设置初始化 Database.SetInitializer<ApplicationDbContext>(null); 
            //全局 Modal.Require
            DataAnnotationsModelValidatorProvider.RegisterAdapterFactory(typeof(RequiredAttribute), (m, c, a) => new myRequiredAttributeAdapter(m, c, (RequiredAttribute)a));
             
        }
        //protected void Session_Start(object sender,EventArgs e)
        //{ 
        //    if (HttpContext.Current.Cache["getLanguages"] == null)
        //    {
        //        Model1 model1 = new Model1(); 
        //        List<LanguageResource.Modal.Language> getLanguages = new List<LanguageResource.Modal.Language>(); 
        //        getLanguages = model1.Languages.ToList(); 
        //        //缓存
        //        System.Web.Caching.Cache objCache = HttpRuntime.Cache;
        //        objCache.Insert("getLanguages", getLanguages,null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(600), CacheItemPriority.High, null);
        //    }
        //}
        //protected void Session_End(object sender, EventArgs e)
        //{
        //    if (HttpContext.Current.Cache["getLanguages"] == null)
        //    {
        //        Model1 model1 = new Model1(); 
        //        List<LanguageResource.Modal.Language> getLanguages = new List<LanguageResource.Modal.Language>(); 
        //        getLanguages = model1.Languages.ToList();

        //        //缓存
        //        System.Web.Caching.Cache objCache = HttpRuntime.Cache;
        //        objCache.Insert("getLanguages", getLanguages, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(600), CacheItemPriority.High,null);
        //    }
        //}

        //用于 用户 保存选择语言选项的情况下.重新定义语言本地化 暂不使用
       
        /// <summary>
        /// For 路由设定模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //routeData.Values.TryGetValue("culture", out culture))

            var wrapper = new HttpContextWrapper(HttpContext.Current);
            if (wrapper != null)
            {
                var routeData = RouteTable.Routes.GetRouteData(wrapper);
                if (routeData == null) //如果Application_Start 注册了路由,永远到达不了这里
                { 
                    var firstLang = Request.UserLanguages[0];
                    string languageCode = LangUtilities.StandardLanguageCode(firstLang);
                   
                    RouteConfig.RegisterRoutes(RouteTable.Routes, languageCode);
                } 
            } 
        }
        private static string GetLanguageCode()
        { 
            var wrapper = new HttpContextWrapper(HttpContext.Current);
            var routeData = RouteTable.Routes.GetRouteData(wrapper);

            var Language = routeData.Values["Language"];
            string languageCode;
            if (Language != null)
            {
                languageCode = LangUtilities.StandardLanguageCode(Language.ToString());

            }
            else
            {
                HttpContext currentContext = HttpContext.Current;
                var userLangs = currentContext.Request.Headers["Accept-Language"].ToString();
                var firstLang = userLangs.Split(',').FirstOrDefault(); 
                languageCode = LangUtilities.StandardLanguageCode(firstLang);
            }
            return languageCode;
        }
        private void RegisterRoutes(RouteCollection routes)
        {
            throw new NotImplementedException();
        }
    }
}
