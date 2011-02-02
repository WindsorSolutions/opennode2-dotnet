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
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Caching;
using System.Reflection;
using Windsor.Commons.Core;
using System.IO;
using System.Diagnostics;

namespace Windsor.Node2008.Admin
{
    public class Global : System.Web.HttpApplication
    {
        private const string LAST_EXCEPTION_CACHE_NAME = "LastException";
        protected void Application_Start(object sender, EventArgs e)
        {
            string path = Assembly.GetExecutingAssembly().Location;
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                LastApplicationException = Server.GetLastError().GetBaseException();
            }
            catch (Exception)
            {
            }
        }
        public static Exception LastApplicationException
        {
            get
            {
                try
                {
                    System.Web.HttpContext context = System.Web.HttpContext.Current;
                    return context.Cache[Global.LAST_EXCEPTION_CACHE_NAME] as Exception;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            set
            {
                try
                {
                    System.Web.HttpContext context = System.Web.HttpContext.Current;
                    context.Cache.Insert(LAST_EXCEPTION_CACHE_NAME, value, null,
                                         DateTime.UtcNow.AddMinutes(5),
                                         Cache.NoSlidingExpiration);
                }
                catch (Exception)
                {
                }
            }
        }
        public static string GetVersionString()
        {
            string versionString = string.Empty;
            try
            {
                string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Windsor.Node2008.WNOSUtility.dll");
                string path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Windsor.Commons.Core.dll");
                FileVersionInfo versionInfo1 = FileVersionInfo.GetVersionInfo(path1);
                FileVersionInfo versionInfo2 = FileVersionInfo.GetVersionInfo(path2);
                versionString = string.Format("Versions: {0}; {1}", versionInfo1.FileVersion, versionInfo2.FileVersion);
            }
            catch (Exception)
            {
            }
            return versionString;
        }
    }
}