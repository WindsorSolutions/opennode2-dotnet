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
using System.Text;
using System.Data;
using System.Data.Common;
using System.Reflection;
using Spring.Data.Generic;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;
using Common.Logging;
using Spring.Data.Common;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSDomain;

namespace Windsor.Node2008.WNOSPlugin
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class PluginDefaultFlowAttribute : Attribute
    {
        private List<string> _defaultFlowNames;

        public PluginDefaultFlowAttribute(string commaSeparatedListOfFlowNames) {
            _defaultFlowNames = new List<string>(
                commaSeparatedListOfFlowNames.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            int j = 0;
            for (int i = 0; i < _defaultFlowNames.Count; ++i)
            {
                string flowName = _defaultFlowNames[i].Trim();
                if (!string.IsNullOrEmpty(flowName))
                {
                    _defaultFlowNames[j++] = flowName;
                }
            }
            if (j < _defaultFlowNames.Count)
            {
                _defaultFlowNames.RemoveRange(j, _defaultFlowNames.Count - j);
            }
        }

        public IList<string> DefaultFlowNames
        {
            get { return _defaultFlowNames; }
        }
    }
}
