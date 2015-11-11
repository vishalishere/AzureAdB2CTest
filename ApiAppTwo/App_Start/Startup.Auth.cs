using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IdentityModel.Tokens;
using ApiAppTwo.Providers;
using Microsoft.Owin.Security.Jwt;

namespace ApiAppTwo
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
            string formatString = String.Format(aadInstance, tenant, "v2.0", discoverySuffix, commonPolicy);
            Debug.WriteLine("formatstring: " + formatString);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                AccessTokenFormat = new JwtFormat(tvps, new OpenIdConnectCachingSecurityTokenProvider(formatString))
            });
        }
    }
}
