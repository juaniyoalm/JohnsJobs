using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppBase.Startup))]
namespace AppBase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
