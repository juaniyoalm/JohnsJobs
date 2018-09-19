using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demandante.Startup))]
namespace Demandante
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
