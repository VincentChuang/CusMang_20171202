using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CusMang.Startup))]
namespace CusMang
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
