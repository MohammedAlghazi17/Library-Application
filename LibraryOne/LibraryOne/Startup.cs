using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryOne.Startup))]
namespace LibraryOne
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
