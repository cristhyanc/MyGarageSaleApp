using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyGarageSale.Web.Startup))]
namespace MyGarageSale.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
