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
using System.Collections;

using Windsor.Commons.Core;

namespace Windsor.Commons.NodeDomain
{
    [Serializable]
    public class ByIndexOrNameDictionary<T> : IList<T>, ICollection
    {
        private bool _isByName;
        private readonly List<KeyValuePair<string, T>> _values;

        public ByIndexOrNameDictionary(EndpointVersionType endpointType) :
            this(endpointType == EndpointVersionType.EN20)
        {
        }
        public ByIndexOrNameDictionary(bool isByName)
        {
            _isByName = isByName;
            _values = new List<KeyValuePair<string, T>>();
        }

        public ByIndexOrNameDictionary(IEnumerable<T> args)
            : this(false)
        {
            foreach (T arg in args)
            {
                Add(arg);
            }
        }

        [ToStringQualifier(Ignore = true)]
        public ICollection<KeyValuePair<string, T>> NameValuePairs
        {
            get
            {
                return _values;
            }
        }
        public bool IsByName
        {
            get
            {
                return _isByName;
            }
        }
        public int Count
        {
            get
            {
                return _values.Count;
            }
        }
        private string IndexString(int index)
        {
            return index.ToString("D5");
        }
        private void UpdateIndexNames(int startIndex)
        {
            if (!IsByName)
            {
                for (int i = startIndex; i < _values.Count; ++i)
                {
                    _values[i] = new KeyValuePair<string, T>(IndexString(i), _values[i].Value);
                }
            }
        }
        public void Add(T value)
        {
            if (IsByName)
            {
                throw new InvalidOperationException("Cannot add by index when IsByName == true");
            }
            _values.Add(new KeyValuePair<string, T>(IndexString(_values.Count), value));
        }
        public void Add(string name, T value)
        {
            if (!IsByName)
            {
                throw new InvalidOperationException("Cannot add by index when IsByName == false");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidOperationException("Name cannot be empty");
            }
            _values.Add(new KeyValuePair<string, T>(name, value));
        }
        public void Insert(int index, T value)
        {
            if (IsByName)
            {
                throw new InvalidOperationException("Cannot add by index when IsByName == true");
            }
            _values.Insert(index, new KeyValuePair<string, T>(IndexString(index), value));
            UpdateIndexNames(index + 1);
        }
        public void Insert(int index, string name, T value)
        {
            if (!IsByName)
            {
                throw new InvalidOperationException("Cannot add by index when IsByName == false");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidOperationException("Name cannot be empty");
            }
            _values.Insert(index, new KeyValuePair<string, T>(name, value));
        }
        public void Clear()
        {
            _values.Clear();
        }
        public bool ContainsKey(string name)
        {
            if (!IsByName)
            {
                throw new InvalidOperationException("Cannot reference by name when IsByName == false");
            }
            for (int i = 0; i < _values.Count; ++i)
            {
                if (string.Equals(_values[i].Key, name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        public bool TryGetValue(string name, out T value)
        {
            if (!IsByName)
            {
                throw new InvalidOperationException("Cannot reference by name when IsByName == false");
            }
            for (int i = 0; i < _values.Count; ++i)
            {
                if (string.Equals(_values[i].Key, name, StringComparison.InvariantCultureIgnoreCase))
                {
                    value = _values[i].Value;
                    return true;
                }
            }
            value = default(T);
            return false;
        }

        public string KeyAtIndex(int index)
        {
            if (IsByName)
            {
                return _values[index].Key;
            }
            else
            {
                throw new InvalidOperationException("Cannot reference Key when IsByName == false");
            }
        }
        // Get returns the value if present, else throws an exception if not present.
        // Set creates a new item if not present, else sets an existing item
        [ToStringQualifier(Ignore = true)]
        public T this[int index]
        {
            get
            {
                return _values[index].Value;
            }
            set
            {
                _values[index] = new KeyValuePair<string, T>(_values[index].Key, value);
            }
        }
        // Get returns the value if present, else throws an exception if not present.
        // Set creates a new item if not present, else sets an existing item
        [ToStringQualifier(Ignore = true)]
        public T this[string name]
        {
            get
            {
                if (!IsByName)
                {
                    throw new InvalidOperationException("Cannot reference by name when IsByName == false");
                }
                for (int i = 0; i < _values.Count; ++i)
                {
                    if (string.Equals(_values[i].Key, name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return _values[i].Value;
                    }
                }
                throw new KeyNotFoundException(name);
            }
            set
            {
                if (!IsByName)
                {
                    throw new InvalidOperationException("Cannot reference by name when IsByName == false");
                }
                KeyValuePair<string, T> pair = new KeyValuePair<string, T>(name, value);
                for (int i = 0; i < _values.Count; ++i)
                {
                    if (string.Equals(_values[i].Key, name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        _values[i] = pair;
                        return;
                    }
                }
                _values.Add(pair);
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumeratorPriv();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumeratorPriv();
        }
        private IEnumerator<T> GetEnumeratorPriv()
        {

            for (int i = 0; i < _values.Count; ++i)
            {
                yield return _values[i].Value;
            }
        }
        public bool Remove(T value)
        {
            throw new InvalidOperationException("Remove() is not supported");
        }
        public void RemoveAt(int index)
        {
            _values.RemoveAt(index);
            UpdateIndexNames(index);
        }
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        public bool Contains(T value)
        {
            return (IndexOf(value) >= 0);
        }
        public int IndexOf(T item)
        {
            for (int i = 0; i < _values.Count; ++i)
            {
                if (object.Equals(item, _values[i].Value))
                {
                    return i;
                }
            }
            return -1;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {

            if (array == null)
                throw new ArgumentNullException("array");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex");
            if ((arrayIndex >= array.Length) || ((arrayIndex + this.Count) > array.Length))
                throw new ArgumentException("arrayIndex");
            foreach (T item in this)
            {
                array[arrayIndex++] = item;
            }
        }
        public void CopyTo(Array array, int arrayIndex)
        {

            if (array == null)
                throw new ArgumentNullException("array");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex");
            if ((arrayIndex >= array.Length) || ((arrayIndex + this.Count) > array.Length))
                throw new ArgumentException("arrayIndex");
            foreach (T item in this)
            {
                array.SetValue(item, arrayIndex++);
            }
        }
        public object SyncRoot
        {
            get
            {
                return this;
            }
        }
        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }
        public virtual string GetKeyValuesString()
        {
            StringBuilder sb = new StringBuilder();
            ICollection<KeyValuePair<string, T>> nameValuePairs = NameValuePairs;

            if (IsByName)
            {
                sb.Append("parameters-by-name: ");
            }
            else
            {
                sb.Append("parameters-by-index: ");
            }
            if (CollectionUtils.IsNullOrEmpty(nameValuePairs))
            {
                sb.Append("None");
            }
            else
            {
                int index = 1;
                foreach (KeyValuePair<string, T> pair in nameValuePairs)
                {
                    string key = IsByName ? pair.Key : index.ToString();
                    ++index;
                    string value = (pair.Value == null) ? string.Empty : pair.Value.ToString();
                    if (index > 2)
                    {
                        sb.Append(", ");
                    }
                    sb.AppendFormat("{0} ({1})", key, value);
                }
            }
            return sb.ToString();
        }
        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
    }
}
