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
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;
using Spring.Objects.Factory.Config;
using Common.Logging;
using Spring.Aop.Support;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;

namespace Windsor.Commons.Spring
{
	public static class SpringUtils
	{
		private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
		/// <summary>
		/// Fetches interface implementation from the specified context
		/// </summary>
		/// <returns>Instance of the specfied type based on the Spring context defenition</returns>
		public static T GetServiceImplementation<T>(IApplicationContext applicationContext) where T : class
		{
			Type serviceType = typeof(T);
			LOG.Debug("Getting service using specified context: " + applicationContext);
			LOG.Debug("Service type: " + serviceType.FullName);
			IDictionary objects = applicationContext.GetObjectsOfType(serviceType, true, false);
//          string[] objectNames = applicationContext.GetObjectDefinitionNames();
            if (objects != null && objects.Count > 0)
            {
				object rtnObject = null;
				foreach(DictionaryEntry entry in objects) {
					// Return closest match
					if ( entry.Value.GetType() == serviceType ) {
						rtnObject = entry.Value;
						break;
					} else {
						rtnObject = entry.Value;
					}
				}
				if ( rtnObject != null ) {
					return (T) rtnObject;
				}
			}
			throw new ArgumentException("GetServiceImplementation() could not locate object of type: " + serviceType.ToString());
		}
	}
}
