using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(communityThrive2.Startup))]
namespace communityThrive2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
