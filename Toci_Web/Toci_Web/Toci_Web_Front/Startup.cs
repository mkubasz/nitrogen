using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Toci_Web_Front.Startup))]
namespace Toci_Web_Front
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
