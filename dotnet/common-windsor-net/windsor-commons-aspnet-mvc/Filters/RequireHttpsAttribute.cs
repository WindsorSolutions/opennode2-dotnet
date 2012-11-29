using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using Windsor.Commons.AspNet.WebApi.Filters;
using Windsor.Commons.Core;
using Windsor.Commons.AspNet.WebApi.Helpers;

namespace Windsor.Commons.AspNet.WebApi.Filters
{
    public class RequireHttpsAttribute : OrderableActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (DebugUtils.IsDebugging)
            {
                return;
            }

            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                HttpResponseHelper.CreateBadRequestResponse(actionContext, "HTTPS is required to access this site");
                return;
            }
        }
    }
}