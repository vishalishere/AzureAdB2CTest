using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Configuration;
using System.IdentityModel.Tokens;
using AzureAd.B2C.Authentication.Providers;
using Microsoft.Owin.Security.Jwt;

namespace ApiAppOne
{
    public partial class Startup
    {
        public static string aadInstance = ConfigurationManager.AppSettings["ida:AadInstance"];
        public static string tenant = ConfigurationManager.AppSettings["ida:Tenant"];
        public static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        public static string commonPolicy = ConfigurationManager.AppSettings["ida:PolicyId"];
        private const string discoverySuffix = ".well-known/openid-configuration";

        public void ConfigureAuth(IAppBuilder app)
        {
            TokenValidationParameters tvps = new TokenValidationParameters
            {
                ValidAudience = clientId,
            };

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                AccessTokenFormat = new JwtFormat(tvps, new OpenIdConnectCachingSecurityTokenProvider(String.Format(aadInstance, tenant, "v2.0", discoverySuffix, commonPolicy)))
            });
        }
    }
}
