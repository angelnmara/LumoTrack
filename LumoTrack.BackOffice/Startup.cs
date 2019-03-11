using LumoTrack.Business.Helpers;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LumoTrack.BackOffice.Startup))]
namespace LumoTrack.BackOffice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            AppBuilderHelper.ConfigureAuth(app);
        }
    }
}
