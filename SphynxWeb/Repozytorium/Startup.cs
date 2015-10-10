using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Repozytorium.Startup))]
namespace Repozytorium
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
