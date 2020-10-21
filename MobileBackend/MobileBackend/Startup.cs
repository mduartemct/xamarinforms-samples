using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MobileBackend.Startup))]

namespace MobileBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}