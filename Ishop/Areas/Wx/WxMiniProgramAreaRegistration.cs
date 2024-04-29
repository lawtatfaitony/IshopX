using System.Web.Mvc;

namespace Ishop.Areas.WxMiniProgram
{
    public class WxMiniProgramAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WxMiniProgram";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WxMiniProgram_default",
                "Wx/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}