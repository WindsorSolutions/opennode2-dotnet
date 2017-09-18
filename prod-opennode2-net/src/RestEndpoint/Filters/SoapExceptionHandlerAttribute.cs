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
using Windsor.OpenNode2.RestEndpoint.Models;
using Windsor.Commons.AspNet.WebApi.Helpers;
using Windsor.OpenNode2.RestEndpoint.Controllers;
using System.Security.Authentication;

namespace Windsor.OpenNode2.RestEndpoint.Filters
{
    /// <summary>
    /// This attribute requires that the controller action method has a parameter that can be cast to a BaseAuthenticationParameters instance.
    /// Additionally, the controller must be a subclass of NAASCredentialsRequiredController.
    /// </summary>
    public class SoapExceptionHandlerAttribute : OrderableActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            if (actionExecutedContext.Exception != null)
            {
                string exceptionTypeName = actionExecutedContext.Exception.GetType().Name;
                if (exceptionTypeName == "SoapException")
                {
                    string errorCode = actionExecutedContext.Exception.HelpLink;
                    string message = ExceptionUtils.GetDeepExceptionMessageOnly(actionExecutedContext.Exception);
                    if (!string.IsNullOrEmpty(errorCode))
                    {
                        message = errorCode + ": " + message;
                    }
                    actionExecutedContext.ActionContext.CreateBadRequestResponse(message);
                }
            }
        }
    }
}