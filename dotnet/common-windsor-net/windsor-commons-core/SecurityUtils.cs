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
    /// Basic helper functions for dealing with strings.
    /// </summary>
    public static class SecurityUtils
    {
        public static void EnableAllSecurityProtocols()
        {
            foreach (SecurityProtocolType protocol in SecurityProtocolType.GetValues(typeof(SecurityProtocolType)))
            {
                ServicePointManager.SecurityProtocol |= protocol;
            }
        }
    }
}
