using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Windsor.Commons.Core;
using System.Net.Http.Formatting;

namespace Windsor.Commons.AspNet.WebApi.Helpers
{
    public static class HttpAuthorizationHelper
    {
        private const string BasicAuthResponseHeaderValue = "Basic";
        private const string FirstAccessedTimeCookieName = "first-accessed-time";

        static HttpAuthorizationHelper()
        {
            FirstAccessedTimeout = TimeSpan.FromMinutes(15);
        }

        public static bool ParseAuthorizationHeader(this HttpRequestMessage request, out string username, out string password)
        {
            username = password = null;

            AuthenticationHeaderValue authValue = request.Headers.Authorization;
            if ((authValue != null) && !String.IsNullOrWhiteSpace(authValue.Parameter) &&
                string.Equals(authValue.Scheme, BasicAuthResponseHeaderValue, StringComparison.OrdinalIgnoreCase))
            {
                string authValueParameter = Encoding.ASCII.GetString(Convert.FromBase64String(authValue.Parameter));

                List<string> credentials = StringUtils.SplitAndReallyRemoveEmptyEntries(authValueParameter, ':');

                bool foundCredentials = false;

                if (credentials.Count == 2)
                {
                    // username:password
                    username = credentials[0];
                    password = credentials[1];
                    foundCredentials = true;
                }
                else if (credentials.Count == 3)
                {
                    // username:realm:password
                    username = credentials[0];
                    password = credentials[2];
                    foundCredentials = true;
                }

                if (foundCredentials)
                {
                    // See if we need to timeout (expire) the credentials
                    DateTime? FirstAccessedTime = request.GetFirstAccessedTime();
                    if (FirstAccessedTime.HasValue)
                    {
                        if (HasFirstAccessedTimeExpired(FirstAccessedTime.Value))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
        public static HttpActionContext CreateUnauthorizedResponse(this HttpActionContext actionContext, string messageFormat = null, params object[] args)
        {
            HttpResponseHelper.CreateErrorResponse(actionContext, HttpStatusCode.Unauthorized, "Authorization required", messageFormat, args);

            AuthenticationHeaderValue authenticationHeaderValue = new AuthenticationHeaderValue(BasicAuthResponseHeaderValue);

            actionContext.Response.Headers.WwwAuthenticate.Add(authenticationHeaderValue);

            return actionContext;
        }
        public static HttpActionContext CacheFirstAccessedTime(this HttpActionContext actionContext)
        {
            if ((actionContext.Response != null) && ((actionContext.Response.StatusCode == HttpStatusCode.Unauthorized) || !actionContext.GetFirstAccessedTime().HasValue))
            {
                var cookieValue = Convert.ToBase64String(Encoding.ASCII.GetBytes(DateTime.UtcNow.ToString()));
                var cookie = new CookieHeaderValue(FirstAccessedTimeCookieName, cookieValue);
                cookie.Expires = DateTimeOffset.Now.AddDays(365);
                //cookie.Domain = actionContext.Request.RequestUri.Host;
                //cookie.Path = "/";

                actionContext.Response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            }

            return actionContext;
        }
        public static bool HasFirstAccessedTimeExpired(DateTime FirstAccessedTime)
        {
            TimeSpan timeSpan = DateTime.UtcNow - FirstAccessedTime;
            return timeSpan > FirstAccessedTimeout;
        }
        public static DateTime? GetFirstAccessedTime(this HttpActionContext actionContext)
        {
            return GetFirstAccessedTime(actionContext.Request);
        }
        public static DateTime? GetFirstAccessedTime(this HttpRequestMessage request)
        {
            try
            {
                if (request != null)
                {
                    CookieHeaderValue cookie = request.Headers.GetCookies(FirstAccessedTimeCookieName).FirstOrDefault();
                    if (cookie != null)
                    {
                        CookieState cookieState = cookie[FirstAccessedTimeCookieName];
                        if (cookieState != null)
                        {
                            string FirstAccessedTimeString = Encoding.ASCII.GetString(Convert.FromBase64String(cookieState.Value));
                            DateTime FirstAccessedTime;
                            if (DateTime.TryParse(FirstAccessedTimeString, out FirstAccessedTime))
                            {
                                return FirstAccessedTime;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return null;
        }
        public static TimeSpan FirstAccessedTimeout
        {
            get;
            set;
        }
    }
}