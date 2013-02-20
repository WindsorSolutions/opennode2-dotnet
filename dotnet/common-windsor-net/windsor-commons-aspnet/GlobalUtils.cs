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
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;

namespace Windsor.Commons.AspNet
{
    public static class GlobalUtils
    {
        public static string GetPhysicalApplicationPath(string relativePath)
        {
            if (relativePath.StartsWith("~\\") || relativePath.StartsWith("~/"))
            {
                relativePath = (relativePath.Length == 2) ? string.Empty : relativePath.Substring(2);
            }
            string path = Path.Combine(PhysicalApplicationPath, relativePath);
            path = Path.GetFullPath(path);
            return path;
        }
        public static string PhysicalApplicationPath
        {
            //get { return HttpContext.Current.Request.PhysicalApplicationPath; }
            get { return HttpRuntime.AppDomainAppPath; }
        }
        public static string ThemesPhysicalApplicationPath
        {
            get
            {
                return GetPhysicalApplicationPath("~/App_Themes");
            }
        }
        public static void ReloadPage(System.Web.UI.Page page)
        {
            if (page.IsCallback)
            {
            }
            else
            {
                HttpContext.Current.Server.Transfer(HttpContext.Current.Request.Url.PathAndQuery);
            }
        }
        public static void GetPostbackParams(out string eventTarget, out string eventArgument)
        {
            eventTarget = HttpContext.Current.Request.Params.Get("__EVENTTARGET");
            eventArgument = HttpContext.Current.Request.Params.Get("__EVENTARGUMENT");
        }
    }
}
