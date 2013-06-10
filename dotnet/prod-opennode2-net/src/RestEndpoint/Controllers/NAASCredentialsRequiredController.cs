using System.Net;
using System.Net.Http;
using System.Web.Http;
using Windsor.Commons.AspNet.WebApi.Filters;
using Windsor.OpenNode2.RestEndpoint.Filters;
using Windsor.OpenNode2.RestEndpoint.Models;

namespace Windsor.OpenNode2.RestEndpoint.Controllers
{
    [RequireHttpsAttribute(Order = 100)]
    [ValidateModelStateAttribute(Order = 200)]
    [SoapExceptionHandlerAttribute(Order = 300)]
    [NAASCredentialsRequiredAttribute(Order = 400)]
    public abstract class NAASCredentialsRequiredController : ApiController
    {
        public BaseAuthenticationParameters HttpBasicAuthorizationParameters
        {
            get;
            set;
        }
    }
}