using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cytaty.Startup))]
namespace Cytaty
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
