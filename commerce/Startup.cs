using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(commerce.Startup))]
namespace commerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
