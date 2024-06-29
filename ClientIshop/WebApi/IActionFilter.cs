using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
 
namespace WebApi
{
    public class CorsActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string referer = context.HttpContext.Request.Headers["Referer"].ToString();
            if (!String.IsNullOrEmpty(referer))
            {
                context.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", Regex.Match(referer, "(https{0,1}://.*?)/").Groups[1].Value);
                context.HttpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");   //这个为true Access-Control-Allow-Origin 不能设置 *
                context.HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "*");  //GET, HEAD, OPTIONS, POST, PUT
                context.HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "*");  //Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers
            }
            else
            {
                context.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "*");
                context.HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "*");
            }
        }
    }
}