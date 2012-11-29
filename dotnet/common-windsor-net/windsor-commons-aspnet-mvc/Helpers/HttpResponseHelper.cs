using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using Windsor.Commons.Core;

namespace Windsor.Commons.AspNet.WebApi.Helpers
{
    public static class HttpResponseHelper
    {
        public static HttpActionContext CreateBadRequestResponse(HttpActionContext actionContext, string messageFormat = null, params object[] args)
        {
            return CreateErrorResponse(actionContext, HttpStatusCode.BadRequest, "Bad request", messageFormat, args);
        }
        public static HttpActionContext CreateBadRequestResponse(HttpActionContext actionContext, ModelStateDictionary modelState, params object[] args)
        {
            actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, modelState);
            return actionContext;
        }
        public static HttpActionContext CreateErrorResponse(HttpActionContext actionContext, HttpStatusCode code, string defaultMessage,
                                                            string messageFormat = null, params object[] args)
        {
            string message = MakeMessage(defaultMessage, messageFormat, args);
            actionContext.Response = actionContext.Request.CreateErrorResponse(code, message);
            return actionContext;
        }
        private static string MakeMessage(string defaultMessage, string messageFormat, params object[] args)
        {
            if (messageFormat == null)
            {
                messageFormat = defaultMessage;
            }
            return string.Format(messageFormat, args);
        }
    }
}