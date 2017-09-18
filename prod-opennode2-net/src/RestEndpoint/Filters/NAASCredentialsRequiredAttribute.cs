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
    public class NAASCredentialsRequiredAttribute : OrderableActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            var naasCredentialsRequiredController = actionContext.ControllerContext.Controller as NAASCredentialsRequiredController;

            if (naasCredentialsRequiredController == null)
            {
                actionContext.CreateBadRequestResponse("The NAASCredentialsRequiredAttribute requires a controller of type NAASCredentialsRequiredController");
                return;
            }

            // Check to see if BaseAuthenticationParameters instance parameter was specified to the controller action
            BaseAuthenticationParameters authenticationParameters = FindAuthenticationParameters(actionContext);

            if (authenticationParameters == null)
            {
                actionContext.CreateBadRequestResponse("Base authentication parameters are required and were not found");
                return;
            }

            UseBasicAuthenticationCredentials_Cached = !authenticationParameters.HasUsernameAndPasswordOrToken;

            if (UseBasicAuthenticationCredentials_Cached)
            {
                // The BaseAuthenticationParameters instance parameter did not specify any credentials, next
                // check for http basic authorization
                string username, password;
                if (!actionContext.Request.ParseAuthorizationHeader(out username, out password))
                {
                    actionContext.CreateUnauthorizedResponse();
                    actionContext.CacheFirstAccessedTime();
                    return;
                }
                naasCredentialsRequiredController.HttpBasicAuthorizationParameters = new BaseAuthenticationParameters(username, password);
            }
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            if (actionExecutedContext.Exception != null)
            {
                // NOTE: If there is an authentication exception, an AuthenticationException is thrown from the services
                if ((actionExecutedContext.Exception is AuthenticationException) && UseBasicAuthenticationCredentials_Cached)
                {
                    actionExecutedContext.ActionContext.CreateUnauthorizedResponse("Authorization failed: {0}", ExceptionUtils.GetDeepExceptionMessage(actionExecutedContext.Exception));
                    actionExecutedContext.ActionContext.CacheFirstAccessedTime();
                    return;
                }
            }

            var naasCredentialsRequiredController = actionExecutedContext.ActionContext.ControllerContext.Controller as NAASCredentialsRequiredController;

            if ((naasCredentialsRequiredController != null) && (naasCredentialsRequiredController.HttpBasicAuthorizationParameters != null))
            {
                actionExecutedContext.ActionContext.CacheFirstAccessedTime();
            }
        }
        protected virtual BaseAuthenticationParameters FindAuthenticationParameters(HttpActionContext actionContext)
        {
            BaseAuthenticationParameters authenticationParameters = null;

            CollectionUtils.ForEachBreak(actionContext.ActionArguments.Values, delegate(object obj)
            {
                authenticationParameters = obj as BaseAuthenticationParameters;
                return (authenticationParameters == null);
            });

            return authenticationParameters;
        }
        protected bool UseBasicAuthenticationCredentials_Cached
        {
            get;
            set;
        }
    }
}