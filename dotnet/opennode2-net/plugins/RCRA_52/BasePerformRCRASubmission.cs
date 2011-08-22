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

namespace Windsor.Node2008.WNOSPlugin.RCRA_52
{
    [Serializable]
    public abstract class BasePerformRCRASubmission<T> : BaseRCRASubmissionPlugin where T : class
    {
        #region fields

        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected IObjectsFromDatabase _objectsFromDatabase;
        protected IHeaderDocumentHelper _headerDocumentHelper;

        protected bool _addHeader;
        protected string _author;
        protected string _organization;
        protected string _contactInfo;
        protected string _notifications;
        protected string _payloadOperation;
        protected string _title;
        protected string _rcraInfoUserId;
        protected string _rcraInfoStateCode;

        protected const string CONFIG_ADD_HEADER = "Add Header";
        protected const string CONFIG_AUTHOR = "Author";
        protected const string CONFIG_ORGANIZATION = "Organization";
        protected const string CONFIG_CONTACT_INFO = "Contact Info";
        protected const string CONFIG_NOTIFICATIONS = "Notifications";
        protected const string CONFIG_PAYLOAD_OPERATION = "Payload Operation";
        protected const string CONFIG_TITLE = "Title";
        protected const string CONFIG_RCRA_INFO_USER_ID = "RCRAInfoUserID";
        protected const string CONFIG_RCRA_INFO_STATE_CODE = "RCRAInfoStateCode";
        #endregion

        public BasePerformRCRASubmission()
        {
            _useSubmissionHistoryTable = true; // By default
            
            ConfigurationArguments.Add(CONFIG_ADD_HEADER, null);
            ConfigurationArguments.Add(CONFIG_AUTHOR, null);
            ConfigurationArguments.Add(CONFIG_ORGANIZATION, null);
            ConfigurationArguments.Add(CONFIG_CONTACT_INFO, null);
            ConfigurationArguments.Add(CONFIG_NOTIFICATIONS, null);
            ConfigurationArguments.Add(CONFIG_PAYLOAD_OPERATION, null);
            ConfigurationArguments.Add(CONFIG_TITLE, null);
            ConfigurationArguments.Add(CONFIG_RCRA_INFO_USER_ID, null);
            ConfigurationArguments.Add(CONFIG_RCRA_INFO_STATE_CODE, null);
        }

        public override void ProcessTask(string requestId)
        {
            base.ProcessTask(requestId);

            CheckForPendingSubmissions(_baseDao);

            PrepareForSubmission();

            string recordId = SetPendingSubmission(_baseDao, _scheduleRunDate);

            try
            {
                PerformSubmission();

                UpdatePendingSubmissionInfo(_baseDao, recordId, _dataRequest.TransactionId);
            }
            catch (Exception)
            {
                SetSubmissionFailed(_baseDao, recordId);
                throw;
            }
        }
        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _objectsFromDatabase);
            GetServiceImplementation(out _headerDocumentHelper);

            GetConfigParameter(CONFIG_ADD_HEADER, true, out _addHeader);
            _author = ValidateNonEmptyConfigParameter(CONFIG_AUTHOR);
            _organization = ValidateNonEmptyConfigParameter(CONFIG_ORGANIZATION);
            _contactInfo = ValidateNonEmptyConfigParameter(CONFIG_CONTACT_INFO);
            _payloadOperation = ValidateNonEmptyConfigParameter(CONFIG_PAYLOAD_OPERATION);
            _title = ValidateNonEmptyConfigParameter(CONFIG_TITLE);
            TryGetConfigParameter(CONFIG_NOTIFICATIONS, ref _notifications);
            _rcraInfoUserId = ValidateNonEmptyConfigParameter(CONFIG_RCRA_INFO_USER_ID);
            _rcraInfoStateCode = ValidateNonEmptyConfigParameter(CONFIG_RCRA_INFO_STATE_CODE);
        }
        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);

            TryGetParameter(_dataRequest, PARAM_USE_SUBMISSION_HISTORY_TABLE_KEY, 1, ref _useSubmissionHistoryTable);
        }
        protected virtual string GenerateSubmissionFile(T data)
        {
            string serializedFilePath = null;
            try
            {
                if (_addHeader)
                {
                    AppendAuditLogEvent("Serializing results and making header...");
                    serializedFilePath = MakeHeaderFile(data);
                }
                else
                {
                    AppendAuditLogEvent("Serializing results to file...");
                    serializedFilePath = _serializationHelper.SerializeToTempFile(data);
                }
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteFile(serializedFilePath);
                throw;
            }
            return serializedFilePath;
        }
        protected string MakeHeaderFile(T dataObject)
        {
            string tempXmlFilePath = null, tempXmlFilePath2 = null;

            try
            {
                ISettingsProvider settingsProvider;
                GetServiceImplementation(out settingsProvider);

                // Configure the submission header helper
                _headerDocumentHelper.Configure(_author, _organization, _title, null, _contactInfo, null);
                _headerDocumentHelper.AddNotifications(_notifications);
                _headerDocumentHelper.AddPropery("RCRAInfoStateCode", _rcraInfoStateCode);
                _headerDocumentHelper.AddPropery("RCRAInfoUserID", _rcraInfoUserId);

                tempXmlFilePath = settingsProvider.NewTempFilePath(".xml");
                _serializationHelper.Serialize(dataObject, tempXmlFilePath);

                XmlDocument doc = new XmlDocument();
                doc.Load(tempXmlFilePath);

                _headerDocumentHelper.AddPayload(_payloadOperation, doc.DocumentElement);
                tempXmlFilePath2 = settingsProvider.NewTempFilePath(".xml");

                _headerDocumentHelper.Serialize(tempXmlFilePath2);

                return tempXmlFilePath2;
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath2);
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath);
            }
        }
        protected virtual string GenerateSubmissionFileAndAddToTransaction(T data)
        {
            string submitFile = GenerateSubmissionFile(data);
            try
            {
                AppendAuditLogEvent("Attaching submission document to transaction \"{0}\"",
                                    _dataRequest.TransactionId);
                _documentManager.AddDocument(_dataRequest.TransactionId,
                                             CommonTransactionStatusCode.Completed,
                                             null, submitFile);
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to attach submission document \"{0}\" to transaction \"{1}\" with exception: {2}",
                                    submitFile, _dataRequest.TransactionId, ExceptionUtils.ToShortString(e));
                FileUtils.SafeDeleteFile(submitFile);
                throw;
            }
            return submitFile;
        }
        protected virtual void PerformSubmission()
        {
            List<T> dataList = GetSubmissionData();

            if (CollectionUtils.IsNullOrEmpty(dataList))
            {
                throw new InvalidOperationException("The staging database does not contain any RCRA data.");
            }
            else if (dataList.Count > 1)
            {
                throw new InvalidOperationException(string.Format("The staging database contains more that one set of RCRA data ({0} sets).",
                                                                  dataList.Count));
            }
            T data = dataList[0];

            AppendAuditLogCountsString(data);

            string submissionFile = GenerateSubmissionFileAndAddToTransaction(data);

            ProcessSubmissionFile(submissionFile);
        }
        protected abstract List<T> GetSubmissionData();
        protected abstract void AppendAuditLogCountsString(T data);

        protected virtual void PrepareForSubmission()
        {
        }
        protected virtual void ProcessSubmissionFile(string submissionFile)
        {
        }
    }
}
