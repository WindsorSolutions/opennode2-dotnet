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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Linq;

namespace Windsor.Commons.Core
{
    /// <summary>
    /// Same as a generic Dictionary, except that iterating over keys/values/elements returns
    /// them in the order they were added to the Dictionary, instead of an undefined order.
    /// </summary>

    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    public class CaseInsensitiveList : List<string>
    {
        public CaseInsensitiveList()
            : base()
        {
        }
        public CaseInsensitiveList(IEnumerable<string> collection)
            : base(collection)
        {
        }
        public CaseInsensitiveList(int capacity)
            : base(capacity)
        {
        }
        public virtual new bool Contains(string item)
        {
            return (this.FirstOrDefault(s => string.Equals(s, item, StringComparison.OrdinalIgnoreCase)) != null);
        }
        public virtual new int BinarySearch(string item)
        {
            return base.BinarySearch(item, StringComparer.OrdinalIgnoreCase);
        }
        public virtual new int IndexOf(string item)
        {
            return IndexOf(item, 0, this.Count);
        }
        public virtual new int IndexOf(string item, int index)
        {
            return IndexOf(item, index, this.Count - index);
        }
        public virtual new int IndexOf(string item, int index, int count)
        {
            if ((count <= 0) || (index < 0) || (index > (this.Count - 1)))
            {
                return -1;
            }
            return this.FindIndex(index, count, s => string.Equals(s, item, StringComparison.OrdinalIgnoreCase));
        }
        public virtual new int LastIndexOf(string item)
        {
            return LastIndexOf(item, this.Count - 1, this.Count);
        }
        public virtual new int LastIndexOf(string item, int index)
        {
            return LastIndexOf(item, index, index + 1);
        }
        public virtual new int LastIndexOf(string item, int index, int count)
        {
            if ((count <= 0) || (index < 0) || (index > (this.Count - 1)))
            {
                return -1;
            }
            return this.FindLastIndex(index, count, s => string.Equals(s, item, StringComparison.OrdinalIgnoreCase));
        }
        public virtual new bool Remove(string item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                base.RemoveAt(index);
                return true;
            }
            return false;
        }
        public virtual new void Sort()
        {
            base.Sort(delegate(string x, string y)
            {
                return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
            });
        }
    }
}
