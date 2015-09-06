using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductWithTests.Startup))]
namespace ProductWithTests
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
