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

namespace Windsor.Commons.Core
{
    /// <summary>
    /// Same as a generic Dictionary, except that iterating over keys/values/elements returns
    /// them in the order they were added to the Dictionary, instead of an undefined order.
    /// </summary>

    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    public class CaseInsensitiveDictionary<TValue> : Dictionary<string, TValue>
    {
        public CaseInsensitiveDictionary()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }
        public CaseInsensitiveDictionary(IDictionary<string, TValue> dictionary)
            : base(dictionary, StringComparer.OrdinalIgnoreCase)
        {
        }
        public CaseInsensitiveDictionary(IEnumerable<TValue> values, Func<TValue, string> callback)
            : base(CollectionUtils.Count(values))
        {
            if (values != null)
            {
                foreach (TValue value in values)
                {
                    Add(callback(value), value);
                }
            }
        }
        public CaseInsensitiveDictionary(int capacity)
            : base(capacity, StringComparer.OrdinalIgnoreCase)
        {
        }
    }
    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    public class CaseInsensitiveSortedDictionary<TValue> : SortedDictionary<string, TValue>
    {
        public CaseInsensitiveSortedDictionary()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }
        public CaseInsensitiveSortedDictionary(IDictionary<string, TValue> dictionary)
            : base(dictionary, StringComparer.OrdinalIgnoreCase)
        {
        }
    }
}
