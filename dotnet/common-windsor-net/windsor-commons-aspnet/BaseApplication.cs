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
    public abstract class BaseApplication<TSessionData, TAppData> : System.Web.HttpApplication where TSessionData : class
                                                                                               where TAppData : class
    {
        public static TSessionData SessionData
        {
            get
            {
                return SessionStateUtils.Get<TSessionData>(SessionDataKey);
            }
            protected set
            {
                SessionStateUtils.Set(SessionDataKey, value);
            }
        }
        public static TAppData AppData
        {
            get
            {
                return ApplicationStateUtils.Get<TAppData>(AppDataKey);
            }
            protected set
            {
                ApplicationStateUtils.Set(AppDataKey, value);
            }
        }

        public static string SessionDataKey
        {
            get { return typeof(TSessionData).FullName; }
        }
        public static string AppDataKey
        {
            get { return typeof(TAppData).FullName; }
        }

        protected virtual void Session_Start(object sender, EventArgs e)
        {
            TSessionData sessionData = InitializeSessionData();

            SessionData = sessionData;
        }
        protected virtual void Application_Start(object sender, EventArgs e)
        {
            TAppData appData = InitializeApplicationData();

            AppData = appData;
        }
        protected abstract TSessionData InitializeSessionData();

        protected abstract TAppData InitializeApplicationData();
    }
}
