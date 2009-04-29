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
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Runtime.Serialization;

namespace Windsor.Node2008.WNOSUtility
{
    /*
    [Serializable]
    public class SortedByValueDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public SortedByValueDictionary() { }
        protected SortedByValueDictionary(SerializationInfo info,
                                          StreamingContext context)
            :
                                                  base(info, context)
        {
        }

    }
    */
    /*
    [Serializable]
    public class SortedByValueDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable where 
                                                        TValue : IComparable<TValue>
    {
        public SortedByValueDictionary() { }
        protected SortedByValueDictionary(SerializationInfo info,
                                          StreamingContext context)
            :
                                                  base(info, context)
        {
        }
        public new IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return GetEnumeratorPriv();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumeratorPriv();
        }
        private IEnumerator<KeyValuePair<TKey, TValue>> GetEnumeratorPriv()
        {
            return SortedList.GetEnumerator();
        }
        private List<KeyValuePair<TKey, TValue>> SortedList
        {
            get
            {
                List<KeyValuePair<TKey, TValue>> sortedList = new List<KeyValuePair<TKey, TValue>>(Count);
                IEnumerator<KeyValuePair<TKey, TValue>> enumerator = base.GetEnumerator();
                while ( enumerator.MoveNext() ) {
                    sortedList.Add(enumerator.Current);
                }
                sortedList.Sort(
                    delegate(KeyValuePair<TKey, TValue> first,
                             KeyValuePair<TKey, TValue> second)
                    {
                        return first.Value.CompareTo(second.Value);
                    }
                );
                return sortedList;
            }
        }
        public static IList<KeyValuePair<K, V>>
            GetSortedList<K, V>(IDictionary<K, V> dictionary) where V : IComparable<V> 
        {
            List<KeyValuePair<K, V>> sortedList =
                new List<KeyValuePair<K, V>>(dictionary);
            sortedList.Sort(
                delegate(KeyValuePair<K, V> first,
                         KeyValuePair<K, V> second)
                {
                    return first.Value.CompareTo(second.Value);
                }
            );
            return sortedList;
        }
    }
    */
}
