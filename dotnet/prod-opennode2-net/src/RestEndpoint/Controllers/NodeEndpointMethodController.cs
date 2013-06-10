using System;
using System.Collections.Generic;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;
using Windsor.Node2008.WNOSDomain;
using Windsor.OpenNode2.RestEndpoint.Models;

namespace Windsor.OpenNode2.RestEndpoint.Controllers
{
    public abstract class NodeEndpointMethodController : NAASCredentialsRequiredController
    {
        protected virtual NamedOrAuthEndpointVisit GetNamedOrAuthEndpointVisit(BaseAuthenticationParameters baseAuthenticationParameters)
        {
            // NOTE: The NAASCredentialsRequiredAttribute (on base class) ensures that either (in this order):
            // 1) baseAuthenticationParameters.HasUsernameAndPasswordOrToken returns true
            // OR
            // 2) HttpBasicAuthorizationParameters.HasUsernameAndPasswordOrToken returns true
            ExceptionUtils.ThrowIfNull(baseAuthenticationParameters);
            if (!baseAuthenticationParameters.HasUsernameAndPasswordOrToken)
            {
                ExceptionUtils.ThrowIfNull(HttpBasicAuthorizationParameters);
                ExceptionUtils.ThrowIfFalse(HttpBasicAuthorizationParameters.HasUsernameAndPasswordOrToken);
                baseAuthenticationParameters = HttpBasicAuthorizationParameters;
            }
            NamedOrAuthEndpointVisit visit =
                ServiceProvider.VisitProvider.GetVisit(baseAuthenticationParameters.Token, baseAuthenticationParameters.Username,
                                                       baseAuthenticationParameters.Password);
            return visit;
        }
        public virtual void Init()
        {
            if (ServiceProvider == null)
            {
                throw new ArgumentException("ServiceProvider property not set");
            }
        }
        public IENRestServiceProvider ServiceProvider
        {
            get;
            set;
        }
        public int MaxResponseKilobytes
        {
            get;
            set;
        }
    }
}