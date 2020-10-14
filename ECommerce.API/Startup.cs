using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(ECommerce.API.Startup))]
namespace ECommerce.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.Configuration(app);
        }

        public void COnfigureOAuth(IAppBuilder app)
        {
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new LoginProvider()
            });
        }
    }
}