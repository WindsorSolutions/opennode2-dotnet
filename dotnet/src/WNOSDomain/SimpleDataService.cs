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
using System.Reflection;
using System.Diagnostics;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOSDomain
{
    [Serializable]
    public class SimpleDataService : IComparable<SimpleDataService>
    {
        private ServiceType _type;
        private ExecutableInfo _pluginInfo;
        private VersionInfo _version;
        private IList<string> _args;
        private IList<string> _dataSources;

        public ServiceType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public ExecutableInfo PluginInfo
        {
            get { return _pluginInfo; }
            set { _pluginInfo = value; }
        }
        public VersionInfo Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public IList<string> Args
        {
            get { return _args; }
            set { _args = value; }
        }
        public string PluginInfoImplementerString
        {
            get { return (_pluginInfo != null) ? _pluginInfo.ImplementerString : string.Empty; }
        }
        public string PluginInfoDisplayString
        {
            get
            {
                if (_pluginInfo == null) return string.Empty;
                return string.Format("{0} (v{1})", _pluginInfo.ImplementingClassName, _version);
            }
        }
        public IList<string> DataSources
        {
            get { return _dataSources; }
            set { _dataSources = value; }
        }
        public int CompareTo(SimpleDataService obj)
        {
            if (PluginInfo != null)
            {
                return (obj.PluginInfo == null) ? 1 :
                    string.Compare(PluginInfo.ImplementerString, obj.PluginInfo.ImplementerString);
            }
            else
            {
                return (obj.PluginInfo == null) ? 0 : -1;
            }
        }
        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
    }
}
