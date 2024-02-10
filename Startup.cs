using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestaurantAPI_PassionProject.Startup))]
namespace RestaurantAPI_PassionProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
