using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DocuWiz.Startup))]
namespace DocuWiz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
