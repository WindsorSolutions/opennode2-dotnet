using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Windsor.Commons.AspNet.WebApi.Filters;
using Windsor.Commons.Core;
using Windsor.Commons.AspNet.WebApi.Helpers;

namespace Windsor.OpenNode2.RestEndpoint.Filters
{
    public class UnhandledExceptionFilterAttribute : OrderableExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            string message = ExceptionUtils.GetDeepExceptionMessage(context.Exception);
            context.ActionContext.CreateBadRequestResponse(message);
        }
    }
}