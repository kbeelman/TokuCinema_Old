using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TokuCinema.Startup))]
namespace TokuCinema
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
