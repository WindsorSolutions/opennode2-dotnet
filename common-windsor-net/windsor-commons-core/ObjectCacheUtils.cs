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
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Web.Caching;
using System.Web;

// NOTE: This file requires System.Web, and so is not available in .NET 3.5 client profile

namespace Windsor.Commons.Core
{
    /// <summary>
    /// Basic helper functions for dealing with strings.
    /// </summary>
    public static class ObjectCacheUtils
    {

        public static void Add(string key, object value, TimeSpan cacheDuration)
        {
            Add(key, value, cacheDuration, true);
        }
        public static void Add(string key, object value, string fileOrDirectoryDependency)
        {
            Cache.Add(key, value, new CacheDependency(fileOrDirectoryDependency),
                      Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration,
                      CacheItemPriority.Default, null);
        }
        public static void Add(string key, object value, TimeSpan cacheDuration,
                               bool isSlidingExpiration)
        {
            if (isSlidingExpiration)
            {
                Cache.Add(key, value, null, Cache.NoAbsoluteExpiration, cacheDuration,
                          CacheItemPriority.Default, null);
            }
            else
            {
                Cache.Add(key, value, null, DateTime.Now + cacheDuration, Cache.NoSlidingExpiration,
                          CacheItemPriority.Default, null);
            }
        }
        public static T Get<T>(string key) where T : class
        {
            return Cache[key] as T;
        }
        public static T Remove<T>(string key) where T : class
        {
            return Cache.Remove(key) as T;
        }
        public static void Remove(string key)
        {
            Cache.Remove(key);
        }
        private static Cache Cache
        {
            get { return HttpRuntime.Cache; }
        }
    }
    public class ObjCache<T, U> where U : class
    {
        // Constructors
        public ObjCache()
        {
        }

        public ObjCache(int maxNumerOfCachedObjects)
        {
            m_MaxNumberOfCachedObjects = maxNumerOfCachedObjects;
        }

        public void Clear()
        {
            lock (m_LockObject)
            {
                m_Cache.Clear();
                m_InsertOrderList.Clear();
            }
        }
        // Methods
        public U this[T key]
        {
            get
            {
                U target;
                lock (m_LockObject)
                {
                    if (m_Cache.TryGetValue(key, out target))
                    {
                        return target;
                    }
                }

                return null;
            }
            set
            {
                lock (m_LockObject)
                {
                    if (value == null)
                    {
                        U target;
                        if (m_Cache.TryGetValue(key, out target))
                        {
                            m_Cache.Remove(key);
                            m_InsertOrderList.Remove(target);
                        }
                    }
                    else
                    {
                        m_InsertOrderList.Remove(value);
                        m_InsertOrderList.Add(value); // Put at end of list
                        if (m_InsertOrderList.Count > m_MaxNumberOfCachedObjects)
                        {
                            for (int i = 0; i < m_InsertOrderList.Count - m_MaxNumberOfCachedObjects; ++i)
                            {
                                U target = m_InsertOrderList[i];
                                T removeKey = default(T);
                                bool foundKey = false;
                                foreach (KeyValuePair<T, U> pair in m_Cache)
                                {
                                    if (Object.ReferenceEquals(value, pair.Value))
                                    {
                                        removeKey = pair.Key;
                                        foundKey = true;
                                        break;
                                    }
                                }
                                if (foundKey)
                                {
                                    m_Cache.Remove(removeKey);
                                }
                            }
                            m_InsertOrderList.RemoveRange(0, m_InsertOrderList.Count - m_MaxNumberOfCachedObjects);
                        }
                        m_Cache[key] = value;
                    }
                }
            }
        }

        protected Dictionary<T, U> m_Cache = new Dictionary<T, U>();
        protected List<U> m_InsertOrderList = new List<U>();
        protected object m_LockObject = new object();
        protected int m_MaxNumberOfCachedObjects = int.MaxValue;
    }
    public class StringKeyObjCache<U> : ObjCache<string, U> where U : class
    {
        // Constructors
        public StringKeyObjCache()
        {
        }
        public StringKeyObjCache(int maxNumerOfCachedObjects)
            : base(maxNumerOfCachedObjects)
        {
        }
        public void ClearIfKeyStartsWith(string prefix)
        {
            lock (m_LockObject)
            {
                List<string> removeKeys = new List<string>();
                foreach (KeyValuePair<string, U> pair in m_Cache)
                {
                    if (pair.Key.StartsWith(prefix))
                    {
                        removeKeys.Add(pair.Key);
                    }
                }
                foreach (string removeKey in removeKeys)
                {
                    m_Cache.Remove(removeKey);
                }
            }
        }
    }
    public class PrefixedKeyObjectCache<T> where T : class
    {
        string _keyPrefix;

        public PrefixedKeyObjectCache(string keyPrefix)
        {
            _keyPrefix = keyPrefix;
        }
        public void Add(string key, object value, TimeSpan cacheDuration)
        {
            ObjectCacheUtils.Add(_keyPrefix + key, value, cacheDuration);
        }
        public void Add(string key, object value, string fileOrDirectoryDependency)
        {
            ObjectCacheUtils.Add(_keyPrefix + key, value, fileOrDirectoryDependency);
        }
        public void Add(string key, object value, TimeSpan cacheDuration,
                        bool isSlidingExpiration)
        {
            ObjectCacheUtils.Add(_keyPrefix + key, value, cacheDuration, isSlidingExpiration);
        }
        public T Get(string key)
        {
            return ObjectCacheUtils.Get<T>(_keyPrefix + key);
        }
        public T Remove(string key)
        {
            return ObjectCacheUtils.Remove<T>(_keyPrefix + key);
        }
        public T this[string key]
        {
            get
            {
                return this.Get(key);
            }
        }
    }
}
