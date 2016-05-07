using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcBootcamp.Web.Startup))]
namespace MvcBootcamp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
