using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MIS320_Team7Project_Fall2016.Startup))]
namespace MIS320_Team7Project_Fall2016
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
