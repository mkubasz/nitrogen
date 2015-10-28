using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamOfCode.Startup))]
namespace TeamOfCode
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
