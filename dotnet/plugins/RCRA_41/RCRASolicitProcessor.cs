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
using System.Reflection;
using Spring.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Logging;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.RCRA_41
{
    [Serializable]
    public class RCRASolicitProcessor : BaseWNOSPlugin, ISolicitProcessor
	{

        public enum ServiceParameterType
        {
            MakeHeader,
            ProvidingOrg,
            Title,
            ContactInfo,
            PayloadOperation,
            Notification,
            RCRAInfoUserID,
            RCRAInfoStateCode,
            SchemaReference
        }

        public enum DataProviderParameterType
        {
            SourceProvider
        }

        #region fields
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private IRequestManager _requestManager;
        private ISerializationHelper _serializationHelper;
        private ICompressionHelper _compressionHelper;
        private IDocumentManager _documentManager;
        private IHeaderDocumentHelper _headerDocumentHelper;
        private ISettingsProvider _settingsProvider;
        protected SpringBaseDao _baseDao;
        #endregion

        public RCRASolicitProcessor()
        {

            //Load Parameters
            foreach (string arg in Enum.GetNames(typeof(ServiceParameterType)))
            {
                ConfigurationArguments.Add(arg, null);
            }

            //Load Data Sources
            foreach (string arg in Enum.GetNames(typeof(DataProviderParameterType)))
            {
                DataProviders.Add(arg, null);
            }

        }

        protected void LazyInit()
        {
            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _headerDocumentHelper);
            GetServiceImplementation(out _settingsProvider);

            _baseDao = ValidateDBProvider(DataProviderParameterType.SourceProvider.ToString(), 
                                          typeof(NamedNullMappingDataReader));
        }
        
        public void ProcessSolicit(string requestId)
		{

            LOG.DebugEnter(MethodBase.GetCurrentMethod(), requestId);

            LazyInit();

            DataRequest request = _requestManager.GetDataRequest(requestId);

            HazardousWasteHandlerSubmissionDataType returnData = GetObjectFromRequest(request);

            string serializedFilePath = null;
            if (IsOn(ServiceParameterType.MakeHeader))
            {
                LOG.Debug("Serializing results and making header...");
                AppendAuditLogEvent("Serializing results and making header...");
                serializedFilePath = MakeHeaderFile(returnData);
            }
            else
            {
                LOG.Debug("Serializing results to file...");
                AppendAuditLogEvent("Serializing results to file...");
                serializedFilePath = _serializationHelper.SerializeToTempFile(returnData);
            }

            LOG.Debug("Serialized file path: " + serializedFilePath);
            AppendAuditLogEvent("Serialized file path: " + serializedFilePath);

            LOG.Debug("Compressing serialized file...");
            AppendAuditLogEvent("Compressing serialized file...");
            string compressedFilePath = _compressionHelper.CompressFile(serializedFilePath);
            LOG.Debug("Compressed file path: " + compressedFilePath);
            AppendAuditLogEvent("Compressed file path: " + compressedFilePath);

            LOG.Debug("Adding document...");
            AppendAuditLogEvent("Adding document...");
            _documentManager.AddDocument(request.TransactionId,
                                         CommonTransactionStatusCode.Processed,
                                         "Request Processed: " + request.ToString(),
                                         compressedFilePath);

            LOG.Debug("OK");
            AppendAuditLogEvent("ProcessQuery: OK");

		}



        private bool IsOn(ServiceParameterType type)
        {
            string doHeader = ValidateNonEmptyConfigParameter(type.ToString()).Trim().ToLower();
            AppendAuditLogEvent("Do header: " + doHeader);
            return (doHeader == "true" || doHeader == "on" || doHeader == "yes" || doHeader == "ya" || doHeader == "da");
        }

        protected string MakeHeaderFile(HazardousWasteHandlerSubmissionDataType list)
        {
            AppendAuditLogEvent("Generating header file from results");

            // Configure the submission header helper
            _headerDocumentHelper.Configure("Windsor Solutions, Inc.",
                                            ValidateNonEmptyConfigParameter(ServiceParameterType.ProvidingOrg.ToString()),
                                            "RCRA", null,
                                            ValidateNonEmptyConfigParameter(ServiceParameterType.ContactInfo.ToString()),
                                            "Unclassified");

            _headerDocumentHelper.AddNotification(
                ValidateNonEmptyConfigParameter(ServiceParameterType.Notification.ToString()));

            _headerDocumentHelper.AddPropery("RCRAInfoStateCode", 
                ValidateNonEmptyConfigParameter(ServiceParameterType.RCRAInfoStateCode.ToString()));

            _headerDocumentHelper.AddPropery("RCRAInfoUserID", 
                ValidateNonEmptyConfigParameter(ServiceParameterType.RCRAInfoUserID.ToString()));

            string tempXmlFilePath = _settingsProvider.NewTempFilePath();
            tempXmlFilePath = Path.ChangeExtension(tempXmlFilePath, ".xml");
            AppendAuditLogEvent("Temp file before header:" + tempXmlFilePath);

            string tempXmlFilePath2 = _settingsProvider.NewTempFilePath();
            tempXmlFilePath2 = Path.ChangeExtension(tempXmlFilePath, ".xml");
            AppendAuditLogEvent("Temp file after header:" + tempXmlFilePath2);

            _serializationHelper.Serialize(list, tempXmlFilePath);
            AppendAuditLogEvent("Temp file serialized");

            if (!File.Exists(tempXmlFilePath))
            {
                throw new IOException("Temp file does not exist: " + tempXmlFilePath);
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(tempXmlFilePath);
            AppendAuditLogEvent("Xml document loaded");

            _headerDocumentHelper.AddPayload(ValidateNonEmptyConfigParameter(ServiceParameterType.PayloadOperation.ToString()),
                                             doc.DocumentElement);

            AppendAuditLogEvent("Header payload added");

            _headerDocumentHelper.Serialize(tempXmlFilePath2);

            AppendAuditLogEvent("Header serialized");

            if (!File.Exists(tempXmlFilePath2))
            {
                throw new IOException("Header file does not exist: " + tempXmlFilePath2);
            }

            return tempXmlFilePath2;

        }


        private HazardousWasteHandlerSubmissionDataType GetObjectFromRequest(DataRequest request)
        {
            LOG.DebugEnter(MethodBase.GetCurrentMethod(), request);

            IObjectsFromDatabase objectsFromDatabase;
            GetServiceImplementation(out objectsFromDatabase);

            List<FacilitySubmissionDataType> dataList = objectsFromDatabase.LoadFromDatabase<FacilitySubmissionDataType>(_baseDao, null);

            if (CollectionUtils.IsNullOrEmpty(dataList))
            {
                throw new InvalidOperationException("The staging database does not contain any RCRA data");
            }
            else
            {
                int handlerCount = 0;
                foreach (FacilitySubmissionDataType submission in dataList)
                {
                    handlerCount += !CollectionUtils.IsNullOrEmpty(submission.Handler) ?
                        submission.Handler.Length : 0;
                }
                AppendAuditLogEvent("Found {0} facility submission(s) and {1} handler(s)", 
                                    dataList.Count, handlerCount);
            }

            HazardousWasteHandlerSubmissionDataType hdRoot = new HazardousWasteHandlerSubmissionDataType();

            hdRoot.FacilitySubmission = dataList.ToArray();

            return hdRoot;
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
