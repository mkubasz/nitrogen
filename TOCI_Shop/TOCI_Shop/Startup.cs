using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TOCI_Shop.Startup))]
namespace TOCI_Shop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
