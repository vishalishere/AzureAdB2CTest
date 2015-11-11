using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Experimental.IdentityModel.Clients.ActiveDirectory;

namespace AzureAdApp.Handlers
{
    public static class AuthenticationHandler
    {
        private static string _tenant = "[tenantname].onmicrosoft.com/";
        private static string _clientId = "(ie: df62d34a-d675-4a10-b01c-b22e70035c7e)";
        private static Uri _redirect = new Uri("urn:ietf:wg:oauth:2.0:oob");

        private static string _signInPolicy = "B2C_1_Sign_in_policy";
        private static string _signUpPolicy = "B2C_1_sign_up_policy";

        private static string _aadInstance = "https://login.microsoftonline.com/{0}";

        private static AuthenticationContext authContext = null;
        private static string authority = String.Format(CultureInfo.InvariantCulture, _aadInstance, _tenant);


        public async static Task<AuthenticationResult> CreateAccountAsync()
        {
            authContext = new AuthenticationContext(authority, false);
            AuthenticationResult result = null;
            try
            {
                string[] scope = { _clientId };
                string[] additionalScope = { "" };
                bool useCorporateNetwork = false;
                string extraQueryParams = "";
                UserIdentifier user = UserIdentifier.AnyUser;
                IPlatformParameters platformParameters = new PlatformParameters(PromptBehavior.Always, useCorporateNetwork);
                result = await authContext.AcquireTokenAsync(scope, additionalScope,
                    _clientId, _redirect, platformParameters, user, extraQueryParams, _signUpPolicy);


                return result;
            }
            catch (AdalException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async static Task<AuthenticationResult> GetAuthorizationHeaderAsync()
        {
            authContext = new AuthenticationContext(authority, false);
            AuthenticationResult result = null;
            try
            {
                string[] scope = { _clientId };
                string[] additionalScope = { "" };
                bool useCorporateNetwork = false;
                string extraQueryParams = "";
                UserIdentifier user = UserIdentifier.AnyUser;
                IPlatformParameters platformParameters = new PlatformParameters(PromptBehavior.Always, useCorporateNetwork);
                result = await authContext.AcquireTokenAsync(scope, additionalScope, 
                    _clientId, _redirect,platformParameters,user, extraQueryParams, _signInPolicy);


                return result;
            }
            catch (AdalException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }


    }
}
