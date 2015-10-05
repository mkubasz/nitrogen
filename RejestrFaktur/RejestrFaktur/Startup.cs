using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RejestrFaktur.Startup))]
namespace RejestrFaktur
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
