using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AzureAdApp.Handlers
{
    public static class AuthenticationHandler
    {
        private static string _resource = "https://<domainname>.onmicrosoft.com/";
        private static string _clientId = "af96b2a3-81c6-4614-b2ff-1de50f6b2d89";
        private static Uri _redirect = new Uri("urn:ietf:wg:oauth:2.0:oob");

        public async static Task<AuthenticationResult> GetAuthorizationHeaderAsync()
        {
            AuthenticationResult result = null;

            AuthenticationContext context = new AuthenticationContext("https://login.windows.net/common"); // tenant agnostic endpooint
            try
            {

                var param = new PlatformParameters(PromptBehavior.Always, false);
                try
                {
                    result = await context.AcquireTokenSilentAsync(_resource, _clientId);
                }
                catch (Exception)
                {
                    var tokenResult = context.AcquireTokenAsync(_resource, _clientId,
                    _redirect, param);

                    await tokenResult.ContinueWith(t => {
                        Debug.WriteLine($"continued.... {t.Result.AccessToken}");

                        result = t.Result;
                    });

                }



                // result.Wait();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            if (result == null)
            {
                throw new InvalidOperationException("Failed to obtain the JWT token");
            }

            return result;
        }
    }
}
