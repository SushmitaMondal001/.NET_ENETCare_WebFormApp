using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ENETCareWebFormApp.Startup))]
namespace ENETCareWebFormApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
