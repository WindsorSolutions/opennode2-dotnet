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
using System.Xml;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.ProviderBase;
using Windsor.Node2008.WNOSPlugin;
using System.Diagnostics;
using System.Reflection;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Spring.Data.Common;
using Spring.Transaction.Support;
using Spring.Data.Core;
using System.Runtime.InteropServices;
using System.ComponentModel;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.NodeDomain;
using Windsor.Commons.NodeClient;

namespace Windsor.Node2008.WNOSPlugin.WQX3
{
    [Serializable]
    public abstract class BaseWQXSubmissionPlugin : BaseWNOSPlugin, ITaskProcessor
    {
        protected enum DataSourceArgs
        {
            None,
            [Description("Data Source")]
            DataSource,
        }
        #region fields

        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected IRequestManager _requestManager;

        protected SpringBaseDao _baseDao;
        protected DataRequest _dataRequest;
        protected DateTime _scheduleRunDate = DateTime.Now;
        protected bool _validateXml;

        protected const string PARAM_USE_SUBMISSION_HISTORY_TABLE_KEY = "UseSubmissionHistoryTable";
        protected const string PARAM_VALIDATE_XML_KEY = "ValidateXml";

        #endregion

        public BaseWQXSubmissionPlugin()
        {
            AppendDataProviders<DataSourceArgs>();
            _useSubmissionHistoryTable = true;
            _submissionHistoryTableName = "WQX_SUBMISSIONHISTORY";
            _submissionHistoryTablePkName = "RECORDID";
            _submissionHistoryTableProcessingStatusName = "CDXPROCESSINGSTATUS";
            _submissionHistoryTableTransactionIdName = "LOCALTRANSACTIONID";
            _submissionHistoryTableRunDateName = "SCHEDULERUNDATE";
        }

        public virtual void ProcessTask(string requestId)
        {
            ProcessTaskInit(requestId);
        }

        public virtual void ProcessTaskInit(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);
        }
        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _requestManager);

            _baseDao = ValidateDBProvider(EnumUtils.ToDescription(DataSourceArgs.DataSource), typeof(NamedNullMappingDataReader));
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);
        }
        /// <summary>
        /// Return the Query, Solicit, or Execute data service parameters for specified data service.
        /// This method should NOT call GetServiceImplementation().
        /// </summary>
        public override IList<TypedParameter> GetDataServiceParameters(string serviceName, out DataServicePublishFlags publishFlags)
        {
            publishFlags = DataServicePublishFlags.PublishToEndpointVersion11And20;
            return null;
        }
    }
}
