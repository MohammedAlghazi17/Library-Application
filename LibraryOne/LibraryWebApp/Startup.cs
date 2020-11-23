using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryWebApp.Startup))]
namespace LibraryWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
