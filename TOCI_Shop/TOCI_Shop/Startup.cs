using System.Data.Entity;
using Microsoft.Owin;
using Owin;
using TOCI_Shop.DAL;

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
