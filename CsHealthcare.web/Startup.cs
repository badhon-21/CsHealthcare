using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CsHealthcare.web.Startup))]
namespace CsHealthcare.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
