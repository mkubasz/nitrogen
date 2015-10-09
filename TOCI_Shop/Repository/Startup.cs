using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Repository.Startup))]
namespace Repository
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
