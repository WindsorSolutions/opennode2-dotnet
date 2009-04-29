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


using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOS.Data
{
    /// <summary>
    /// Should be implementing interface but for now just use the raw object
    /// </summary>
    public class ObjectCacheDao : BaseDao, IObjectCacheDao, IDataCache
    {
        public const string TABLE_NAME = "NObjectCache";
        private ISerializationHelper _serializationHelper;
        private ICompressionHelper _compressionHelper;

        #region Init

        new public void Init()
        {
            base.Init();
            FieldNotInitializedException.ThrowIfNull(this, ref _serializationHelper);
            FieldNotInitializedException.ThrowIfNull(this, ref _compressionHelper);
        }

        #endregion
        #region Mappers
        #endregion // Mappers
		
        #region Methods
        public bool CacheString(string data, string name, TimeSpan cacheDuration)
        {
            return CacheString(data, name, DateTime.Now + cacheDuration);
        }
        public bool CacheString(string data, string name, DateTime expirationTime)
        {
            return CacheData(StringUtils.UTF8.GetBytes(data), name, expirationTime);
        }
        public bool CacheData(byte[] data, string name, TimeSpan cacheDuration)
        {
            return CacheData(data, name, DateTime.Now + cacheDuration);
        }
        public bool CacheData(byte[] data, string name, DateTime expirationTime)
        {
            try
            {
                DateTime now = DateTime.Now;
                if (data == null)
                {
                    throw new ArgumentNullException("data");
                }
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentNullException("name");
                }
                if (expirationTime == DbUtils.DB_MIN_DATE)
                {
                    DoSimpleQueryForObjectDelegate<string>(
                        TABLE_NAME, "Name", name, "Expiration",
                        delegate(IDataReader reader, int rowNum)
                        {
                            expirationTime = reader.GetDateTime(0);
                            return null;
                        });
                }
                TransactionTemplate.Execute(delegate
                {
                    DoSimpleDelete(TABLE_NAME, "Name", name);
                    DoInsert(TABLE_NAME, "Name;Data;ModifiedOn;Expiration",
                             name, data, now, expirationTime);
                    return null;
                });
                return true;
            }
            catch (Exception e)
            {
                LOG.Error("Failed to cache object \"{0}\"", e, name);
                return false;
            }
        }
        public string GetString(string name)
        {
            return GetString(name, false);
        }
        public string GetString(string name, bool returnEvenIfExpired)
        {
            byte[] data = GetData(name, returnEvenIfExpired);
            return (data != null) ? StringUtils.UTF8.GetString(data) : null;
        }
        public byte[] GetData(string name)
        {
            return GetData(name, false);
        }
        public byte[] GetData(string name, bool returnEvenIfExpired)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentNullException("name");
                }
                try
                {
                    string query;
                    object[] queryParams;
                    if (returnEvenIfExpired)
                    {
                        query = "Name";
                        queryParams = new object[] { name };
                    }
                    else
                    {
                        query = "Name;Expiration >";
                        queryParams = new object[] { name, DateTime.Now };
                    }
                    byte[] data = null;
                    bool foundIt =
                        DoSimpleQueryForObjectDelegate<bool>(
                            TABLE_NAME, query, queryParams, "Data",
                            delegate(IDataReader reader, int rowNum)
                            {
                                try
                                {
                                    data = (byte[]) reader.GetValue(0);
                                    return true;
                                }
                                catch (Exception e2)
                                {
                                    LOG.Error("Failed to load cached object \"{0}\"", e2, name);
                                    return false;
                                }
                            });
                    return data;
                }
                catch (Spring.Dao.IncorrectResultSizeDataAccessException)
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                LOG.Error("Failed to load cached object \"{0}\"", e, name);
                return null;
            }
        }
        /// <summary>
        /// CacheObject()
        /// </summary>
        public bool CacheObject<T>(T obj, string name, DateTime expirationTime)
        {
            try
            {
                return CacheData(BinarySerializeAndCompress(obj), name, expirationTime);
            }
            catch (Exception e)
            {
                LOG.Error("Failed to cache object \"{0}\"", e, name);
                return false;
            }
        }

        /// <summary>
        /// CacheObjectNoExpiration()
        /// </summary>
        public bool CacheObjectNoExpiration<T>(T obj, string name)
        {
            return CacheObject<T>(obj, name, DbUtils.DB_MAX_DATE);
        }

        /// <summary>
        /// CacheObjectKeepExpiration()
        /// </summary>
        public bool CacheObjectKeepExpiration<T>(T obj, string name)
        {
            return CacheObject<T>(obj, name, DbUtils.DB_MIN_DATE);
        }

        /// <summary>
        /// CacheObject()
        /// </summary>
        public bool CacheObject<T>(T obj, string name, TimeSpan cacheDuration)
        {
            return CacheObject<T>(obj, name, DateTime.Now + cacheDuration);
        }

        public bool GetObject<T>(string name, out T obj)
        {
            return GetObject<T>(name, false, out obj);
        }

        /// <summary>
        /// GetObject()
        /// </summary>
        public bool GetObject<T>(string name, bool returnEvenIfExpired, out T obj)
        {
            obj = default(T);
            try
            {
                byte[] content = GetData(name, returnEvenIfExpired);
                obj = BinaryDecompressAndDeserialize<T>(content);
                return true;
            }
            catch(Exception e2)
            {
                LOG.Error("Failed to load cached object \"{0}\"", e2, name);
                return false;
            }
        }
        public bool RemoveObject(string name)
        {
            try {
                DoSimpleDelete(TABLE_NAME, "Name", name);
                return true;
            }
            catch (Exception e)
            {
                LOG.Error("Failed to remove cached object \"{0}\"", e, name);
                return false;
            }
        }
        public bool IsExpired(string name)
        {
            try
            {
                bool foundIt =
                    DoSimpleQueryForObjectDelegate<bool>(
                        TABLE_NAME, "Name;Expiration >", new object[] { name, DateTime.Now }, "Name",
                        delegate(IDataReader reader, int rowNum)
                        {
                            return true;
                        });
                return !foundIt;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return true;
            }
        }
        public byte[] BinarySerializeAndCompress<T>(T obj)
        {
            return _compressionHelper.Compress("obj", _serializationHelper.BinarySerialize<T>(obj));
        }
        public T BinaryDecompressAndDeserialize<T>(byte[] bytes)
        {
            return _serializationHelper.BinaryDeserialize<T>(_compressionHelper.Uncompress(bytes));
        }
        #endregion

        #region Properties
        public ISerializationHelper SerializationHelper
        {
            get { return _serializationHelper; }
            set { _serializationHelper = value; }
        }
        public ICompressionHelper CompressionHelper
        {
            get { return _compressionHelper; }
            set { _compressionHelper = value; }
        }
        #endregion
    }
}
