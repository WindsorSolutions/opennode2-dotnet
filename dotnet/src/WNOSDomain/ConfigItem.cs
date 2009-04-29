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

namespace Windsor.Node2008.WNOSDomain
{
    [Flags]
    public enum ConfigurationType
    {
            Undefined = 0x00
        ,   System = 0x01
        ,   Global = 0x02
        ,   All = (System | Global)
    }

    [Serializable]
    public class ConfigItem : AuditableIdentity, IComparable<ConfigItem>
    {
        private string _value;
        private string _description;
        private bool _isEditable;
        public static string GLOBAL_ARG_INDICATOR = "@";

        public ConfigItem(ConfigItem item) : base(item.Id, item.ModifiedById, item.ModifiedOn)
        {
            _value = item.Value;
            _description = item.Description;
            _isEditable = item.IsEditable;
        }
        public ConfigItem() { }
        public ConfigItem(string code, string val, string desc, bool isEditable)
        {
            _value = val;
            Id = code;
            _description = desc;
            _isEditable = isEditable;
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public bool IsEditable
        {
            get { return _isEditable; }
            set { _isEditable = value; }
        }

        #region IComparable<ConfigItem> Members

        public int CompareTo(ConfigItem other)
        {
            return string.Compare(Id, other.Id);
        }

        #endregion
    }
}
