using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Empleador.Startup))]
namespace Empleador
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
