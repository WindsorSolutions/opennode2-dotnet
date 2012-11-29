using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http.Controllers;
using Windsor.Commons.Core;

namespace Windsor.Commons.AspNet.WebApi.Helpers
{
    public static class HttpAuthorizationHelper
    {
        private const string BasicAuthResponseHeaderValue = "Basic";

        public static bool ParseAuthorizationHeader(this HttpRequestMessage request, out string username, out string password)
        {
            username = password = null;

            AuthenticationHeaderValue authValue = request.Headers.Authorization;
            if ((authValue != null) && !String.IsNullOrWhiteSpace(authValue.Parameter) &&
                string.Equals(authValue.Scheme, BasicAuthResponseHeaderValue, StringComparison.OrdinalIgnoreCase))
            {
                string authValueParameter = Encoding.ASCII.GetString(Convert.FromBase64String(authValue.Parameter));

                List<string> credentials = StringUtils.SplitAndReallyRemoveEmptyEntries(authValueParameter, ':');

                if (credentials.Count == 2)
                {
                    username = credentials[0];
                    password = credentials[1];
                    return true;
                }
            }
            return false;
        }
        public static HttpActionContext CreateUnauthorizedResponse(this HttpActionContext actionContext, string messageFormat = null, params object[] args)
        {
            HttpResponseHelper.CreateErrorResponse(actionContext, HttpStatusCode.Unauthorized, "Authorization required", messageFormat, args);
            actionContext.Response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(BasicAuthResponseHeaderValue));
            return actionContext;
        }
    }
}