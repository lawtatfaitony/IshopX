using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ishop.Startup))]
namespace Ishop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
