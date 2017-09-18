using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;

namespace ServerUtils.Core
{
    /// <summary>
    /// Basic helper functions for dealing with security.
    /// </summary>
    public static class SecurityUtils
    {
        private static readonly SecurityProtocolType s_AllSecurityProtocols;
        static SecurityUtils()
        {
            SecurityProtocolType setProtocols = SecurityProtocolType.Ssl3;
            foreach (SecurityProtocolType protocol in SecurityProtocolType.GetValues(typeof(SecurityProtocolType)))
            {
                setProtocols |= protocol;
            }
            s_AllSecurityProtocols = setProtocols;
        }
        public static void EnableAllSecurityProtocols()
        {
            ServicePointManager.SecurityProtocol = s_AllSecurityProtocols;
        }
    }
}
