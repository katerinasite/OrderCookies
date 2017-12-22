using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrderCookies.Startup))]
namespace OrderCookies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
