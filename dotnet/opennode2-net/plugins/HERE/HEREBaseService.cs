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
using System.Xml;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.ProviderBase;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using System.Diagnostics;

namespace Windsor.Node2008.WNOSPlugin.HERE
{
    /// <summary>
    /// Override this in the ervice to make more specific
    /// </summary>
    public enum HERERunTimeArgs
    {
        EndpointUri, IsFacilitySourceIndicator, SourceSystemName
    }

    /// <summary>
    /// Common
    /// </summary>
    public enum DataSourceParameterType
    {
        SourceDatabaseDataSource, TargetDatabaseDataSource
    }

    [Serializable]
    public abstract class HEREBaseService : BaseWNOSPlugin
    {

        protected DataRequest _dataRequest;
        protected IRequestManager _requestManager;
        protected ITransactionManager _transactionManager;
        protected IFlowManager _flowManager;
        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        private ISettingsProvider _settingsProvider;
        protected string _flowCode;
        protected DateTime _argDate;
        protected int _numOfDays;

        public HEREBaseService()
        {
            //Load Parameters
            foreach (string arg in Enum.GetNames(typeof(HERERunTimeArgs)))
            {
                ConfigurationArguments.Add(arg.ToString(), null);
            }

            //Load Data Sources
            foreach (string arg in Enum.GetNames(typeof(DataSourceParameterType)))
            {
                DataProviders.Add(arg.ToString(), null);
            }
        }

        /// <summary>
        /// ProcessSolicit
        /// </summary>
        public virtual void ProcessSolicit(string requestId)
        {
            ValidateRequest(requestId);
            _numOfDays = 0;
            if (!TryGetParameterByIndex<int>(_dataRequest, 0, ref _numOfDays))
            {
                throw new ApplicationException("Invalid Number of Days argument");
            }
            _argDate = DateTime.Now.AddDays(-_numOfDays);
        }

        /// <summary>
        /// ProcessQuery
        /// </summary>
        public virtual PaginatedContentResult ProcessQuery(string requestId)
        {
            ValidateRequest(requestId);
            _argDate = DateTime.MinValue;
            if (!TryGetParameterByIndex<DateTime>(_dataRequest, 0, ref _argDate))
            {
                throw new ApplicationException("Invalid Change Date argument");
            }
            return null;
        }

        protected abstract string ServiceName { get; }
        
        protected string TargetXmlFilePath
        {
            get
            {
                string targetXmlPath =
                    Path.Combine(_settingsProvider.TempFolderPath,
                                 string.Format("{0}-{1}.xml", ServiceName,
                                 DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")));
                return targetXmlPath;
            }
        }
        protected string CurrentTransaction
        {
            get { return _dataRequest.TransactionId; }
        }
        protected string FlowCode
        {
            get { return _flowCode; }
        }
        protected virtual void ValidateRequest(string requestId)
        {
            LazyInit();

            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            _flowCode = _flowManager.GetDataFlowNameById(_dataRequest.Service.FlowId);
        }
        protected virtual void LazyInit()
        {
            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _flowManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
        }
        protected void SaveResults(int numOfDays)
        {
            HERE10.HEREData data = new HERE10.HEREData(ValidateDBProvider(DataSourceParameterType.TargetDatabaseDataSource.ToString()));

            string endpointUrl = ValidateNonEmptyConfigParameter(HERERunTimeArgs.EndpointUri.ToString());
            string sourceSystemName = ValidateNonEmptyConfigParameter(HERERunTimeArgs.SourceSystemName.ToString());

            bool isFullReplace = (numOfDays > 365);
            bool isFacilitySource = false;

            if (!bool.TryParse(ValidateNonEmptyConfigParameter(HERERunTimeArgs.IsFacilitySourceIndicator.ToString()), 
                               out isFacilitySource))
            {
                throw new ApplicationException(string.Format(
                    "Unable to parse the {0} argument. Must be a valid bool expression.",
                    HERERunTimeArgs.IsFacilitySourceIndicator));
            }

            //Update the results
            data.SetResultData(CurrentTransaction, endpointUrl, FlowCode,
                               isFacilitySource, sourceSystemName, isFullReplace);


        }

    }



}
