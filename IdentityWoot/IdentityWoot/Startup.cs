using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityWoot.Startup))]
namespace IdentityWoot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
