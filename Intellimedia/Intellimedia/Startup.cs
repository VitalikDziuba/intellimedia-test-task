using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Intellimedia.Startup))]
namespace Intellimedia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
