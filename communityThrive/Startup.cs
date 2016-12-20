using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(communityThrive.Startup))]
namespace communityThrive
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
