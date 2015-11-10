using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace ApiAppOne.Controllers
{
    public class ValuesController : ApiController
    {
        [Authorize]
        // GET api/values
        public IEnumerable<string> Get()
        {
            try
            {
                string userId = ClaimsPrincipal.Current.FindFirst(t => t.Type == "emails").Value;
                Debug.WriteLine("User ID GUID: " + userId);
            }
            catch (Exception ex)
            {
            }


            var owner = ClaimsPrincipal.Current;
            var ownerfirst = owner.Claims; // FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/objectidentifier");

            foreach (Claim claim in ownerfirst)
            {
                Debug.WriteLine(Environment.NewLine + "Claim-------------------------------------------:");
                Debug.WriteLine($"{nameof(claim.Issuer)}: {claim.Issuer}");
                Debug.WriteLine($"{nameof(claim.OriginalIssuer)}: {claim.OriginalIssuer}");
                Debug.WriteLine($"{nameof(claim.Value)}: {claim.Value}");
                Debug.WriteLine($"{nameof(claim.ValueType)}: {claim.ValueType}");
                Debug.WriteLine($"{nameof(claim.Type)}: {claim.Type}");
                IDictionary<string,string> properties = claim.Properties;
                Debug.WriteLine(Environment.NewLine + "Properties:");
                foreach(var property in properties)
                {
                    Debug.WriteLine($"{nameof(property.Key)}: {property.Value}");
                }
                Debug.WriteLine(Environment.NewLine + "ClaimsIdentity:");
                ClaimsIdentity subject = claim.Subject;
                Debug.WriteLine($"{nameof(subject.AuthenticationType)}: {subject.AuthenticationType}");
                Debug.WriteLine($"{nameof(subject.BootstrapContext)}: {subject.BootstrapContext}");
                Debug.WriteLine($"{nameof(subject.Name)}: {subject.Name}");
                Debug.WriteLine($"{nameof(subject.RoleClaimType)}: {subject.RoleClaimType}");

            }

            return new string[] { "value1", "value2", "value3" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
