using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Turtle.Startup))]
namespace Turtle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
