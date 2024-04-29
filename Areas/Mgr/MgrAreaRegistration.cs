using System.Web.Mvc;

namespace Ishop.Areas.Mgr
{
    public class MgrAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Mgr";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Mgr_default",
                "Mgr/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Ishop.Areas.Mgr.Controllers", "Ishop.Controllers" }
            );
        }
    }
}