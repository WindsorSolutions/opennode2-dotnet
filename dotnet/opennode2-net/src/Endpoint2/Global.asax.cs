#region License
/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.SessionState;
using System.Reflection;
using System.IO;
using Common.Logging;
using Windsor.Commons.Logging;
using Windsor.Commons.Core;
using System.Collections.Specialized;

namespace Windsor.Node2008.Endpoint2
{
    public class Global : System.Web.HttpApplication
    {


        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected void Application_Start(object sender, EventArgs e)
        {

            LOG.Info("Application_Start");
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace('\\', '/');
            LOG.Debug("Assembly Path: " + path);
        }

        protected void Application_End(object sender, EventArgs e)
        {
            LOG.Info("Application_End");
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            LOG.Info("Application_BeginRequest");
            HttpContext context = HttpContext.Current;
            if (!context.Request.ContentType.Contains("action="))
            {
                // Don't ask.  This is a complete hack fix to get WSE to play nice with incoming requests that don't include 
                // an action.  This is the only decent workaround I could come up with after lots of searching.
                context.Request.ContentType = context.Request.ContentType + "; action=\"\"";
            }
            //const string SoapActionName = "SOAPAction";
            //if (context.Request.Headers[SoapActionName] != null)
            //{
            //    // Again, don't ask.  Workaround for clients that include an empty "SOAPAction" header.
            //    ReflectionUtils.SetFieldOrProperty(context.Request.Headers, "IsReadOnly", false);
            //    ReflectionUtils.CallMethodNonVirtual<NameValueCollection>(context.Request.Headers, "Set", SoapActionName, null);
            //    ReflectionUtils.SetFieldOrProperty(context.Request.Headers, "IsReadOnly", true);
            //}
        }
    }
}