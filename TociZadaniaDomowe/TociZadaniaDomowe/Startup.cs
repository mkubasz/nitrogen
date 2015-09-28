using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TociZadaniaDomowe.Startup))]
namespace TociZadaniaDomowe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
