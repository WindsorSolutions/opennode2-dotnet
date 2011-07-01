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
    public class LinkedDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        private List<KeyValuePair<TKey, TValue>> _list;
        private _KeyCollection _keys;
        private _ValueCollection _values;

        public LinkedDictionary()
        {
            _list = new List<KeyValuePair<TKey, TValue>>();
        }
        public LinkedDictionary(IDictionary<TKey, TValue> dictionary)
            : base(dictionary)
        {
            InitList(dictionary);
        }
        public LinkedDictionary(IEqualityComparer<TKey> comparer)
            : base(comparer)
        {
            _list = new List<KeyValuePair<TKey, TValue>>();
        }
        public LinkedDictionary(int capacity)
            : base(capacity)
        {
            _list = new List<KeyValuePair<TKey, TValue>>(capacity);
        }
        public LinkedDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
            : base(dictionary, comparer)
        {
            InitList(dictionary);
        }
        public LinkedDictionary(int capacity, IEqualityComparer<TKey> comparer)
            : base(capacity, comparer)
        {
            _list = new List<KeyValuePair<TKey, TValue>>(capacity);
        }
        protected LinkedDictionary(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            InitList(this);
        }
        protected void InitList(IDictionary<TKey, TValue> dictionary)
        {
            _list = new List<KeyValuePair<TKey, TValue>>(dictionary.Count);
        }
        public int IndexOfKey(TKey key)
        {
            int index = 0;
            foreach (KeyValuePair<TKey, TValue> pair in _list)
            {
                if (object.Equals(pair.Key, key))
                {
                    return index;
                }
                ++index;
            }

            return -1;
        }
        public new TValue this[TKey key]
        {
            get
            {
                return base[key];
            }
            set
            {
                base[key] = value;
                SetListValue(key, value);
            }
        }
        public TValue this[int index]
        {
            get
            {
                return _list[index].Value;
            }
            set
            {
                TKey key = _list[index].Key;
                base[key] = value;
                KeyValuePair<TKey, TValue> pair = new KeyValuePair<TKey, TValue>(key, value);
                _list[index] = pair;
            }
        }
        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            KeyValuePair<TKey, TValue> pair = new KeyValuePair<TKey, TValue>(key, value);
            _list.Add(pair);
        }
        public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> collection)
        {
            CollectionUtils.ForEach(collection, delegate(KeyValuePair<TKey, TValue> pair)
            {
                Add(pair.Key, pair.Value);
            });
        }
        public void Insert(int index, TKey key, TValue value)
        {
            base.Add(key, value);
            try
            {
                KeyValuePair<TKey, TValue> pair = new KeyValuePair<TKey, TValue>(key, value);
                _list.Insert(index, pair);
            }
            catch (Exception)
            {
                base.Remove(key);
                throw;
            }
        }
        public new void Clear()
        {
            base.Clear();
            _list.Clear();
        }
        public new _KeyCollection Keys
        {
            get
            {
                if (_keys == null)
                {
                    _keys = new _KeyCollection(this);
                }
                return _keys;
            }
        }
        public new _ValueCollection Values
        {
            get
            {
                if (_values == null)
                {
                    _values = new _ValueCollection(this);
                }
                return _values;
            }
        }
        public new IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (KeyValuePair<TKey, TValue> pair in _list)
            {
                yield return pair;
            }
        }
        public new bool Remove(TKey key)
        {
            bool rtnVal = base.Remove(key);
            if (rtnVal)
            {
                int index = GetListKeyIndex(key);
                _list.RemoveAt(index);
            }
            return rtnVal;
        }
        protected void SetListValue(TKey key, TValue value)
        {
            int index = GetListKeyIndex(key);
            KeyValuePair<TKey, TValue> pair = new KeyValuePair<TKey, TValue>(key, value);
            if (index < 0)
            {
                _list.Add(pair);
            }
            else
            {
                _list[index] = pair;
            }
        }
        protected int GetListKeyIndex(TKey key)
        {
            int index = -1, currentIndex = 0;
            foreach (KeyValuePair<TKey, TValue> pair in _list)
            {
                if (Comparer.Equals(pair.Key, key))
                {
                    index = currentIndex;
                    break;
                }
                ++currentIndex;
            }
            return index;
        }
        [Serializable]
        public sealed class _KeyCollection : ICollection<TKey>, IEnumerable<TKey>, ICollection, IEnumerable
        {
            private LinkedDictionary<TKey, TValue> _dictionary;

            public _KeyCollection(LinkedDictionary<TKey, TValue> dictionary)
            {
                if (dictionary == null)
                {
                    throw new ArgumentNullException("dictionary");
                }
                _dictionary = dictionary;
            }

            public void CopyTo(TKey[] array, int index)
            {
                for (int i = 0; i < _dictionary._list.Count; i++)
                {
                    array[index++] = _dictionary._list[i].Key;
                }
            }

            public IEnumerator<TKey> GetEnumerator()
            {
                foreach (KeyValuePair<TKey, TValue> pair in _dictionary._list)
                {
                    yield return pair.Key;
                }
            }

            void ICollection<TKey>.Add(TKey item)
            {
                throw new NotSupportedException("Add()");
            }

            void ICollection<TKey>.Clear()
            {
                throw new NotSupportedException("Clear()");
            }

            bool ICollection<TKey>.Contains(TKey item)
            {
                return _dictionary.ContainsKey(item);
            }

            bool ICollection<TKey>.Remove(TKey item)
            {
                throw new NotSupportedException("Remove()");
            }

            void ICollection.CopyTo(Array array, int index)
            {
                TKey[] localArray = array as TKey[];
                if (localArray != null)
                {
                    this.CopyTo(localArray, index);
                }
                else
                {
                    object[] objArray = array as object[];
                    if (objArray == null)
                    {
                        throw new ArgumentException("Invalid array type");
                    }
                    for (int i = 0; i < _dictionary._list.Count; i++)
                    {
                        objArray[index++] = _dictionary._list[i].Key;
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                foreach (KeyValuePair<TKey, TValue> pair in _dictionary._list)
                {
                    yield return pair.Key;
                }
            }

            // Properties
            public int Count
            {
                get
                {
                    return _dictionary._list.Count;
                }
            }

            bool ICollection<TKey>.IsReadOnly
            {
                get
                {
                    return true;
                }
            }

            bool ICollection.IsSynchronized
            {
                get
                {
                    return false;
                }
            }

            object ICollection.SyncRoot
            {
                get
                {
                    return ((ICollection)_dictionary._list).SyncRoot;
                }
            }
        }
        [Serializable]
        public sealed class _ValueCollection : ICollection<TValue>, IEnumerable<TValue>, ICollection, IEnumerable
        {
            private LinkedDictionary<TKey, TValue> _dictionary;

            public _ValueCollection(LinkedDictionary<TKey, TValue> dictionary)
            {
                if (dictionary == null)
                {
                    throw new ArgumentNullException("dictionary");
                }
                _dictionary = dictionary;
            }

            public void CopyTo(TValue[] array, int index)
            {
                for (int i = 0; i < _dictionary._list.Count; i++)
                {
                    array[index++] = _dictionary._list[i].Value;
                }
            }

            public IEnumerator<TValue> GetEnumerator()
            {
                foreach (KeyValuePair<TKey, TValue> pair in _dictionary._list)
                {
                    yield return pair.Value;
                }
            }

            void ICollection<TValue>.Add(TValue item)
            {
                throw new NotSupportedException("Add()");
            }

            void ICollection<TValue>.Clear()
            {
                throw new NotSupportedException("Clear()");
            }

            bool ICollection<TValue>.Contains(TValue item)
            {
                return _dictionary.ContainsValue(item);
            }

            bool ICollection<TValue>.Remove(TValue item)
            {
                throw new NotSupportedException("Remove()");
            }

            void ICollection.CopyTo(Array array, int index)
            {
                TValue[] localArray = array as TValue[];
                if (localArray != null)
                {
                    this.CopyTo(localArray, index);
                }
                else
                {
                    object[] objArray = array as object[];
                    if (objArray == null)
                    {
                        throw new ArgumentException("Invalid array type");
                    }
                    for (int i = 0; i < _dictionary._list.Count; i++)
                    {
                        objArray[index++] = _dictionary._list[i].Key;
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                foreach (KeyValuePair<TKey, TValue> pair in _dictionary._list)
                {
                    yield return pair.Key;
                }
            }

            // Properties
            public int Count
            {
                get
                {
                    return _dictionary._list.Count;
                }
            }

            bool ICollection<TValue>.IsReadOnly
            {
                get
                {
                    return true;
                }
            }

            bool ICollection.IsSynchronized
            {
                get
                {
                    return false;
                }
            }

            object ICollection.SyncRoot
            {
                get
                {
                    return ((ICollection)_dictionary._list).SyncRoot;
                }
            }
        }
    }
}
