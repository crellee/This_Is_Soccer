using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(This_Is_Soccer.Startup))]
namespace This_Is_Soccer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
