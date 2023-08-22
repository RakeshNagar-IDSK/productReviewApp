using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleAppDemo.Startup))]
namespace SampleAppDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
