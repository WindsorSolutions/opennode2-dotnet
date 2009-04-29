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
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using Windsor.Commons.Core;

namespace Windsor.Commons.Core
{
    /// <summary>
    /// Basic functionality for an object implementing IDisposable
    /// </summary>
    public class AppDomainInstanceLoader : DisposableBase
    {
        private AppDomain _appDomain;
        private object _lockObject = new object();

        public static T GetInstance<T>(AppDomain appDomain, string assemblyFilePath, string typeName) where T : class
        {
            return (T)appDomain.CreateInstanceFromAndUnwrap(assemblyFilePath, typeName);
        }
        public AppDomainInstanceLoader()
        {
        }
        public virtual T GetInstance<T>(string assemblyFilePath, string typeName) where T : class
        {
            return GetInstance<T>(AppDomain, assemblyFilePath, typeName);
        }
        public virtual T GetInstance<T>() where T : class
        {
            Type type = typeof(T);
            return GetInstance<T>(type.Assembly.Location, type.FullName);
        }
        protected AppDomain AppDomain
        {
            get {
                if (_appDomain == null)
                {
                    lock (_lockObject)
                    {
                        if (_appDomain == null)
                        {
                            _appDomain = CreateAppDomain();
                        }
                    }
                }
                return _appDomain;
            }
        }
        protected virtual AppDomain CreateAppDomain()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            return AppDomain.CreateDomain(Guid.NewGuid().ToString(), currentDomain.Evidence,
                                          currentDomain.BaseDirectory, currentDomain.RelativeSearchPath,
                                          currentDomain.ShadowCopyFiles);
        }
        protected override void OnDispose(bool inIsDisposing)
        {
            if (inIsDisposing)
            {
                if (_appDomain != null)
                {
                    try
                    {
                        AppDomain.Unload(_appDomain);
                    }
                    catch (Exception)
                    {
                    }
                }
                DisposableBase.SafeDispose(ref _appDomain);
            }
        }
    }
    /// <summary>
    /// MarshalByRefObject subclass that stays alive indefinitely.
    /// </summary>
    public class MarshalByRefObjectIndefinite : MarshalByRefObject
    {
        public override object InitializeLifetimeService() {
			// See: http://www.codeproject.com/csharp/Net_Remoting.asp
			// See: http://www.informit.com/guides/content.asp?g=dotnet&seqNum=395&rl=1
			// See: http://www.codeproject.com/csharp/dynamicpluginmanager.asp
			// This keeps our object alive indefinitely
			return null;
		}
    }
}
