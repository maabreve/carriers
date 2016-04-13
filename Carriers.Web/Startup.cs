using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Carriers.Web.Startup))]
namespace Carriers.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
