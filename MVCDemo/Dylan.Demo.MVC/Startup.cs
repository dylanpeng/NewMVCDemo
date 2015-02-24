using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dylan.Demo.MVC.Startup))]
namespace Dylan.Demo.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
