using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FleetTracker.Web.Startup))]
namespace FleetTracker.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
