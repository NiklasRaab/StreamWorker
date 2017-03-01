using Microsoft.Owin;
using Owin;
using StreamWorker;

[assembly: OwinStartup(typeof(Startup))]

namespace StreamWorker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}