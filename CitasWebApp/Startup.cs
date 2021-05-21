using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CitasWebApp.Startup))]
namespace CitasWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
