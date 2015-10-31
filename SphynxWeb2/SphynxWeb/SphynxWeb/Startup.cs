using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SphynxWeb.Startup))]
namespace SphynxWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
