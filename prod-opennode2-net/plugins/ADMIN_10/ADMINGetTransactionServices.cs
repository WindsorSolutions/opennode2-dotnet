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
using Windsor.Node2008.WNOSDomain;
using Windsor.Commons.Core;
using Windsor.Node2008.WNOSDomain.TransactionTracking;

namespace Windsor.Node2008.WNOSPlugin.ADMIN_10
{
    [Serializable]
    public class GetTransactionList : ADMINPluginBase
    {
        public GetTransactionList()
        {
        }
        protected override object GetServiceData()
        {
            TransactionListType1 transactionList =
                _transactionManager.DoTransactionTrackingQuery(_serviceParameters);
            if (CollectionUtils.IsNullOrEmpty(transactionList.Transaction))
            {
                AppendAuditLogEvent("No transactions matched the query");
            }
            else
            {
                AppendAuditLogEvent("Returning {0} transaction(s) that matched the query",
                                    transactionList.Transaction.Length.ToString());
            }
            return transactionList;
        }
        public override IList<TypedParameter> GetDataServiceParameters(string serviceName, out DataServicePublishFlags publishFlags)
        {
            IList<TransactionTrackingQueryParameter> possibleParameters = EnumUtils.GetAllEnumValues<TransactionTrackingQueryParameter>();
            return GetDataServiceParameters(serviceName, possibleParameters, out publishFlags);
        }
    }
    [Serializable]
    public class GetTransactionCount : ADMINPluginBase
    {
        public GetTransactionCount()
        {
        }
        protected override object GetServiceData()
        {
            TransactionCount transactionCount =
                _transactionManager.GetTransactionTrackingQueryCount(_serviceParameters);
            AppendAuditLogEvent("Returning transaction count of {0}", transactionCount.Value.ToString());
            return transactionCount;
        }
        public override IList<TypedParameter> GetDataServiceParameters(string serviceName, out DataServicePublishFlags publishFlags)
        {
            IList<TransactionTrackingQueryParameter> possibleParameters = EnumUtils.GetAllEnumValues<TransactionTrackingQueryParameter>();
            return GetDataServiceParameters(serviceName, possibleParameters, out publishFlags);
        }
    }
    [Serializable]
    public class GetTransactionDetail : ADMINPluginBase
    {
        private string _transactionId;

        public GetTransactionDetail()
        {
        }
        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);

            _transactionId = GetServiceParameterValue(TransactionTrackingQueryParameter.TransactionId) as string;
            if (_transactionId == null)
            {
                throw new ArgumentException(string.Format("A \"{0}\" parameter must be specified when calling GetTransactionDetail",
                                                          TransactionTrackingQueryParameter.TransactionId.ToString()));
            }
        }
        protected override object GetServiceData()
        {
            TransactionDetailType transactionDetail =
                _transactionManager.DoTransactionTrackingDetail(_transactionId);
            AppendAuditLogEvent("Returning details for transaction \"{0}\"", _transactionId);
            return transactionDetail;
        }
        public override IList<TypedParameter> GetDataServiceParameters(string serviceName, out DataServicePublishFlags publishFlags)
        {
            IList<TransactionTrackingQueryParameter> possibleParameters = new TransactionTrackingQueryParameter[] { TransactionTrackingQueryParameter.TransactionId };
            return GetDataServiceParameters(serviceName, possibleParameters, out publishFlags);
        }
    }
}
