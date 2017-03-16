using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoWebForms4._5.Startup))]
namespace DemoWebForms4._5
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
