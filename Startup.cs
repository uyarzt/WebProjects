using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppForTesting.Startup))]
namespace WebAppForTesting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
