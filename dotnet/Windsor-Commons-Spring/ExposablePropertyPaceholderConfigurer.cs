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

namespace Windsor.Commons.Spring
{
    /// <summary>
    /// Improves PropertyPlaceholderConfigurer by storing the property values for access at a later time 
    /// (i.e., after they have been assigned during the Spring context initialization process).
    /// </summary>
    public class ExposablePropertyPaceholderConfigurer : PropertyPlaceholderConfigurer
    {
        private IDictionary<string, string> _exposedProperties = new Dictionary<string, string>();
        public ExposablePropertyPaceholderConfigurer()
            : base()
        {
            this.IgnoreResourceNotFound = false;
            this.IgnoreUnresolvablePlaceholders = false;
            this.EnvironmentVariableMode = EnvironmentVariableMode.Fallback;
        }
        protected override void ProcessProperties(IConfigurableListableObjectFactory factory,
                                                  NameValueCollection props) {

            base.ProcessProperties(factory, props);
            for (int i = 0; i < props.Count; ++i) {
                _exposedProperties.Add(props.GetKey(i), props.Get(i));
            }
        }
        public IDictionary<string, string> ExposedProps
        {
            get { return _exposedProperties; }
        }
        public string this[string key]
        {
            get { return _exposedProperties[key]; }
        }
    }
}
