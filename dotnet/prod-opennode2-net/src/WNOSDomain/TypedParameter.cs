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
    /// <summary>
    /// Data service parameter type.
    /// </summary>
    [Serializable]
    public class TypedParameter
    {
        private Type _type;
        private string _name;
        private string _description;
        private bool _isRequired;
        private object _defaultValue;
        private bool _doPublishParam;

        public TypedParameter()
        {
        }
        public TypedParameter(string name)
        {
            _name = name;
            _doPublishParam = true;
        }
        public TypedParameter(string name, bool isRequired, Type type)
        {
            _type = type;
            _name = name;
            _isRequired = isRequired;
            _doPublishParam = true;
        }
        public TypedParameter(string name, string description, bool isRequired,
                              Type type, bool doPublishParam, object value)
        {
            _type = type;
            _name = name;
            _description = description;
            _isRequired = isRequired;
            _doPublishParam = doPublishParam;
            _defaultValue = value;
        }
        public TypedParameter(string name, string description, bool isRequired,
                              Type type, bool doPublishParam)
        {
            _type = type;
            _name = name;
            _description = description;
            _isRequired = isRequired;
            _doPublishParam = doPublishParam;
        }
        public Type Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public bool IsRequired
        {
            get
            {
                return _isRequired;
            }
            set
            {
                _isRequired = value;
            }
        }
        public object DefaultValue
        {
            get
            {
                return _defaultValue;
            }
            set
            {
                _defaultValue = value;
            }
        }
        public IList<object> AcceptableValues
        {
            get;
            set;
        }
        public bool DoPublishParam
        {
            get
            {
                return _doPublishParam;
            }
            set
            {
                _doPublishParam = value;
            }
        }
    }
}
