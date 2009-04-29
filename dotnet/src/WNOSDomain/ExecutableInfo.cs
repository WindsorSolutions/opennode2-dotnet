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

using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOSDomain
{
    /// <summary>
    /// Domain object representing information about an executable class within an assembly.  This domain
    /// object is used to store location information about a specific class within an executable assembly
    /// so that an instance of the class can be loaded dynamically at runtime.
    /// </summary>
    [Serializable]
    public class ExecutableInfo : IComparable<ExecutableInfo>
    {
        private string _assemblyName;
        private string _implementingClassName;

        public ExecutableInfo()
        {
        }
        public ExecutableInfo(string implementorString)
        {
            ImplementerString = implementorString;
		}
        public ExecutableInfo(string assemblyName, string implementingClassName)
        {
            if ( string.IsNullOrEmpty(assemblyName) || string.IsNullOrEmpty(implementingClassName) ) {
                throw new ArgumentException("Invalid assemblyName or implementingClassName");
            }
            _implementingClassName = implementingClassName;
            _assemblyName = assemblyName;
        }

        /// <summary>
        /// The full implementation string for the class + assembly names.
        /// </summary>
        public string ImplementerString
        {
            get
            {
                return _implementingClassName + ", " + _assemblyName;
            }
            set
            {
                string[] values = value.Split(',');
                if (values.Length != 2)
                {
                    throw new ArgumentException("Invalid implementer string format");
                }
                string implementingClassName = values[0].Trim();
                string assemblyName = values[1].Trim();
                if ((implementingClassName.Length == 0) || (assemblyName.Length == 0))
                {
                    throw new ArgumentException("Invalid implementer string format");
                }
                _implementingClassName = implementingClassName;
                _assemblyName = assemblyName;
            }
        }

        /// <summary>
        /// The name of the implementing class.
        /// </summary>
        public string ImplementingClassName
        {
            get { return _implementingClassName; }
            set { _implementingClassName = value; }
        }

        /// <summary>
        /// The name of the assembly that contains the class.
        /// </summary>
        public string AssemblyName
        {
            get { return _assemblyName; }
            set { _assemblyName = value; }
        }
        
        /// <summary>
        /// IComparable contract implementation
        /// </summary>
        public int CompareTo(ExecutableInfo obj)
        {
            return string.Compare(ImplementerString, obj.ImplementerString);
        }

        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
    }
}
