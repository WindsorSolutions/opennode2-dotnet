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
using System.Runtime.Serialization;

namespace Windsor.Commons.AspNet
{
    public static class SessionStateUtils
    {
        private const string INIT_PAGE_SESSION_KEY = "___PAGE___SESSION___KEY___";
        private const string INIT_PAGE_KEEPALIVE_KEY = "___PAGE___KEEPALIVE___KEY___";

        public static bool Contains(string key)
        {
            return (HttpContext.Current.Session[key] != null);
        }
        public static void Set(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }
        public static T Get<T>(string key) where T : class
        {
            return HttpContext.Current.Session[key] as T;
        }
        public static T Remove<T>(string key) where T : class
        {
            T value = Get<T>(key);
            Remove(key);
            return value;
        }
        public static void Remove(string key)
        {
            HttpContext.Current.Session[key] = null;
        }
        public static void Abandon()
        {
            HttpContext.Current.Session.Abandon();
        }
        public static void InitPageSessionState()
        {
            Set(INIT_PAGE_SESSION_KEY, DateTime.Now.Ticks);
        }
        public static void ClearPageSessionState()
        {
            HttpContext.Current.Session.Clear();
            Set(INIT_PAGE_SESSION_KEY, DateTime.Now.Ticks);
        }
        public static bool PageSessionStateIsValid
        {
            get { return Contains(INIT_PAGE_SESSION_KEY); }
        }
        public static void ThrowSessionStateExpiredException()
        {
            Windsor.Commons.Core.DebugUtils.CheckDebuggerBreak();
            throw new SessionStateExpiredException("Your web session has expired.  Please reload the web page and try again.");
        }
        public static void PingKeepAlive()
        {
            Set(INIT_PAGE_KEEPALIVE_KEY, DateTime.Now.Ticks);
        }
    }

    [Serializable]
    public class SessionStateExpiredException : ApplicationException
    {
        public SessionStateExpiredException()
        {
        }
        public SessionStateExpiredException(string message) :
            base(message)
        {
        }
        public SessionStateExpiredException(string message, Exception innerException) :
            base(message, innerException)
        {
        }
        protected SessionStateExpiredException(SerializationInfo info,
                                                  StreamingContext context) :
            base(info, context)
        {
        }
    }
}
