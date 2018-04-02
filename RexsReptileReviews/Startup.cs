using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RexsReptileReviews.Startup))]
namespace RexsReptileReviews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
