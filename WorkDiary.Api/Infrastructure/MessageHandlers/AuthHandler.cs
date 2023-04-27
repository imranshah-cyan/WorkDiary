using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ServiceDotNet.Api.Infrastructure.MessageHandlers
{
    public class AuthHandler : DelegatingHandler
    {
        string _userName = "";

        private bool ValidateCredentials(AuthenticationHeaderValue authenticationHeaderVal)
        {
            try
            {
                if (authenticationHeaderVal != null && !String.IsNullOrEmpty(authenticationHeaderVal.Parameter))
                {
                    string[] decodedCredentials = Encoding.ASCII.GetString(Convert.FromBase64String(authenticationHeaderVal.Parameter)).Split(new[] { ':' });

                    if (decodedCredentials[0].Equals("admin") && decodedCredentials[1].Equals("admin"))
                    {
                        _userName = "admin";
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (ValidateCredentials(request.Headers.Authorization))
            {
                IPrincipal principal = new GenericPrincipal(new GenericIdentity("admin"), new string[] { "Admin" });
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;
            }

            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized && !response.Headers.Contains("WwwAuthenticate"))
            {
                response.Headers.Add("WwwAuthenticate", "Basic");
            }

            return response;
        }
    }
}