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
    public class NodeNotificationDao : BaseDao, INodeNotificationDao
    {
        public const string TABLE_NAME = "NNodeNotification";
        private ISerializationHelper _serializationHelper;

        #region Init

        new public void Init()
        {
            base.Init();
        
            FieldNotInitializedException.ThrowIfNull(this, ref _serializationHelper);
        }

        #endregion

        #region Methods

		/// <summary>
		/// Create a node notification.
		/// </summary>
        public string CreateNotification(string transactionId, ComplexNotification notification)
        {
            string id = IdProvider.Get();
            string notifyData = _serializationHelper.SerializeToBase64String(notification);
            DoInsert(TABLE_NAME,
                     "Id;TransactionId;NotifyData",
                     id, transactionId, notifyData);
            return id;
        }

        /// <summary>
        /// Get a node notification.
        /// </summary>
        public ComplexNotification GetNotification(string id)
        {
            try
            {
                ComplexNotification notification =
                    DoSimpleQueryForObjectDelegate<ComplexNotification>(
                        TABLE_NAME, "Id", id, "NotifyData",
                        delegate(IDataReader reader, int rowNum)
                        {
                            return _serializationHelper.DeserializeFromBase64String<ComplexNotification>(reader.GetString(0), null);
                        });
                return notification;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        /// <summary>
        /// Get a node notification.
        /// </summary>
        public ComplexNotification GetNotificationByTransactionId(string transactionId)
        {
            try
            {
                ComplexNotification notification =
                    DoSimpleQueryForObjectDelegate<ComplexNotification>(
                        TABLE_NAME, "TransactionId", transactionId, "NotifyData",
                        delegate(IDataReader reader, int rowNum)
                        {
                            return _serializationHelper.DeserializeFromBase64String<ComplexNotification>(reader.GetString(0), null);
                        });
                return notification;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }
        #endregion

        #region Properties

        public ISerializationHelper SerializationHelper
        {
            get { return _serializationHelper; }
            set { _serializationHelper = value; }
        }
        #endregion
    }
}
