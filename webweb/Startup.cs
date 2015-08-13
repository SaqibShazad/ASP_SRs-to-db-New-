using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webweb.Startup))]
namespace webweb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
