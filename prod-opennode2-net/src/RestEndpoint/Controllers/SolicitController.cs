using System.Net;
using System.Net.Http;
using System.Web.Http;
using Windsor.Commons.AspNet.WebApi.Filters;
using Windsor.Commons.AspNet.WebApi.Helpers;
using Windsor.OpenNode2.RestEndpoint.Filters;
using Windsor.OpenNode2.RestEndpoint.Models;

namespace Windsor.OpenNode2.RestEndpoint.Controllers
{
    public class SolicitController : NodeEndpointMethodController
    {
        public virtual HttpResponseMessage Get([FromUri] QueryParameters parameters)
        {
            return Request.CreateBadRequestResponse("The Solicit service is not implemented yet.");
        }
    }
}