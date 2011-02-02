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
using System.Data;
using System.Data.Common;
using System.Reflection;
using Spring.Data.Generic;
using Spring.Data.Common;
using Spring.Data;
using Spring.Dao;
using Spring.Data.Support;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;
using Spring.Transaction.Support;
using Common.Logging;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using SpringCore = Spring.Data.Core;

namespace Windsor.Commons.Spring
{
    /// <summary>
    /// Helper data reader for dealing with null db values, and allowing the reader to access
    /// returned values by name (as well as by index).
    /// </summary>
    public class NamedNullMappingDataReader : NullMappingDataReader
    {
        public NamedNullMappingDataReader() : base() { }
        public NamedNullMappingDataReader(IDataReader dataReader) : base(dataReader) { }

        public virtual bool ContainsField(string name)
        {
            if (_nameToOrdinalMap != null)
            {
                return _nameToOrdinalMap.ContainsKey(name);
            }
            return false;
        }
        public override int GetOrdinal(string name)
        {
            if (_nameToOrdinalMap == null)
            {
                Dictionary<string, int> nameToOrdinalMap = new Dictionary<string, int>();
                int fieldCount = dataReader.FieldCount;
                for (int i = 0; i < fieldCount; i++)
                {
                    nameToOrdinalMap.Add(dataReader.GetName(i), i);
                }
                _nameToOrdinalMap = nameToOrdinalMap;
            }
            int index;
            if (!_nameToOrdinalMap.TryGetValue(name, out index))
            {
                throw new ArgumentException(string.Format("The column \"{0}\" was not found in the returned dataset", name));
            }
            return index;
        }
        public new bool NextResult()
        {
            _nameToOrdinalMap = null;
            return base.NextResult();
        }
        public virtual byte[] GetNullBytes(string name)
        {
            int ordinal = GetOrdinal(name);
            return (base.IsDBNull(ordinal) ? null : (byte[]) base.GetValue(ordinal));
        }
        public virtual string GetString(string name)
        {
            return base.GetString(GetOrdinal(name));
        }
        public virtual string GetNullString(string name)
        {
            int ordinal = GetOrdinal(name);
            return (base.IsDBNull(ordinal) ? null : base.GetString(ordinal));
        }
        public virtual DateTime GetDateTime(string name)
        {
            return base.GetDateTime(GetOrdinal(name));
        }
        public virtual bool GetNullDateTime(string name, ref DateTime dateTime)
        {
            int ordinal = GetOrdinal(name);
            if (base.IsDBNull(ordinal))
            {
                return false;
            }
            else
            {
                dateTime = base.GetDateTime(ordinal);
                return true;
            }
        }
        public virtual int GetInt32(string name)
        {
            return base.GetInt32(GetOrdinal(name));
        }
        public virtual bool IsDBNull(string name)
        {
            return base.IsDBNull(GetOrdinal(name));
        }
        private Dictionary<string, int> _nameToOrdinalMap;
    }
}
