using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using Windsor.Commons.AspNet.WebApi.Filters;
using Windsor.Commons.AspNet.WebApi.Helpers;

namespace Windsor.OpenNode2.RestEndpoint.Filters
{
    public class ValidateModelStateAttribute : OrderableActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                HttpResponseHelper.CreateBadRequestResponse(actionContext, actionContext.ModelState);
            }
        }
    }
}