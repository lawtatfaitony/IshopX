using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
 
namespace WebApi.MiddleWare
{
    /// <summary>
    /// A middleware that short-circuits the request's pipeline, if a response has already been started.
    /// </summary>
    public class EnsureResponseNotStartedMiddleware
    {
        private readonly RequestDelegate _next;

        public EnsureResponseNotStartedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {
            if (!context.Response.HasStarted)
            {
                return _next(context);
            }

            return Task.CompletedTask;
        }
    }
}
