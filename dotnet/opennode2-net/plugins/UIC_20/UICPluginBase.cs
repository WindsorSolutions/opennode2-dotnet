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
using System.ComponentModel;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.UIC_20
{
    [Serializable]
    public abstract class UICPluginBase : BaseWNOSPlugin
    {
        protected enum Submission_Type
        {
            [Description("Delete-Insert")]
            DeleteInsert,
        }
        #region fields
        protected const string UIC_FLOW_NAME = "UIC";

        // Config arguments:
        protected const string CONFIG_AUTHOR = "Author";
        protected const string CONFIG_CONTACT_INFO = "Contact Info";

        protected const string SOURCE_PROVIDER_KEY = "Data Source";

        protected const string PARAM_ORGANIZATION_IDENTIFIER_KEY = "OrganizationIdentifier";
        protected const string PARAM_ADD_HEADER = "AddHeader";
        protected const string PARAM_VALIDATE_XML_KEY = "ValidateXml";
        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected IRequestManager _requestManager;
        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;

        protected string _organizationIdentifier;
        protected DataRequest _dataRequest;
        protected SpringBaseDao _baseDao;
        protected bool _addHeader = true;
        protected bool _validateXml;
        protected string _headerAuthor;
        protected string _headerContactInfo;
        #endregion

        public UICPluginBase()
        {
            ConfigurationArguments.Add(CONFIG_AUTHOR, null);
            ConfigurationArguments.Add(CONFIG_CONTACT_INFO, null);

            DataProviders.Add(SOURCE_PROVIDER_KEY, null);
        }

        /// <summary>
        /// ProcessSolicit
        /// </summary>
        public virtual void ProcessSolicitInit(string requestId, bool validatePartnerName)
        {
            LazyInit();

            ValidateRequest(requestId);
        }
        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing UICPluginBase plugin ...");

            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);

            _baseDao = ValidateDBProvider(SOURCE_PROVIDER_KEY, typeof(NamedNullMappingDataReader));
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);

            GetParameter(_dataRequest, PARAM_ORGANIZATION_IDENTIFIER_KEY, 0, out _organizationIdentifier);
            TryGetParameter(_dataRequest, PARAM_ADD_HEADER, 1, ref _addHeader);
            if (_addHeader)
            {
                _headerAuthor = GetConfigParameter(CONFIG_AUTHOR);
                _headerContactInfo = GetConfigParameter(CONFIG_CONTACT_INFO);
            }
            TryGetParameter(_dataRequest, PARAM_VALIDATE_XML_KEY, 2, ref _validateXml);

            AppendAuditLogEvent("Running submission for organization \"{0}\"",
                                      _organizationIdentifier);
        }
        protected string GenerateSubmissionFile(UICDataType data)
        {
            AppendAuditLogEvent(GetSubmissionResultsString(data));

            string tempZipFilePath = _settingsProvider.NewTempFilePath(".zip");
            string tempXmlFilePath = _settingsProvider.NewTempFilePath(".xml");
            try
            {
                //_serializationHelper.Serialize(data, tempXmlFilePath);
                _serializationHelper.SerializeWithLineBreaks(data, tempXmlFilePath);

                if (_validateXml)
                {
                    ValidateXmlFileAndAttachErrorsAndFileToTransaction(tempXmlFilePath, "xml_schema.xml_schema.zip",
                                                                       null, _dataRequest.TransactionId);
                }

                if (_addHeader)
                {
                    AppendAuditLogEvent("Generating submission file (with an exchange header) from results");

                    IHeaderDocumentHelper headerDocumentHelper;
                    GetServiceImplementation(out headerDocumentHelper);
                    // Configure the submission header helper
                    string organization = data.OrgId;
                    if (!string.IsNullOrEmpty(data.OrgName))
                    {
                        organization += " - " + data.OrgName;
                    }
                    headerDocumentHelper.Configure(_headerAuthor, organization, UIC_FLOW_NAME, UIC_FLOW_NAME,
                                                   _headerContactInfo, null);

                    string tempXmlFilePath2 = _settingsProvider.NewTempFilePath(".xml");
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(tempXmlFilePath);

                        headerDocumentHelper.AddPayload(EnumUtils.ToDescription(Submission_Type.DeleteInsert),
                                                        doc.DocumentElement);

                        headerDocumentHelper.SerializeWithLineBreaks(tempXmlFilePath2);

                        _compressionHelper.CompressFile(tempXmlFilePath2, tempZipFilePath);
                    }
                    finally
                    {
                        FileUtils.SafeDeleteFile(tempXmlFilePath2);
                    }
                }
                else
                {
                    AppendAuditLogEvent("Generating submission file (without an exchange header) from results");
                    _compressionHelper.CompressFile(tempXmlFilePath, tempZipFilePath);
                }
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteFile(tempZipFilePath);
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath);
            }
            return tempZipFilePath;
        }
        protected string GenerateSubmissionFileAndAddToTransaction(UICDataType data)
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
        protected string GetSubmissionResultsString(UICDataType data)
        {
            StringBuilder sb = new StringBuilder();
            if (data == null)
            {
                sb.Append("Did not find any UIC submission data.");
            }
            else
            {
                sb.Append("Found the following UIC submission data: ");
                int i = 0;
                AppendCountString("Facilities", data.FacilityList, ++i == 1, sb);
                AppendCountString("Contacts", data.ContactDetail, ++i == 1, sb);
                AppendCountString("Permit Details", data.PermitDetail, ++i == 1, sb);
                AppendCountString("Geology Details", data.GeologyDetail, ++i == 1, sb);
                AppendCountString("Enforcements", data.EnforcementDetail, ++i == 1, sb);
            }
            return sb.ToString();
        }
        protected void AppendCountString(string collectionName, ICollection collection, bool isFirst,
                                         StringBuilder sb)
        {
            if (!isFirst)
            {
                sb.Append(", ");
            }
            int count = CollectionUtils.IsNullOrEmpty(collection) ? 0 : collection.Count;
            sb.AppendFormat("{0} {1}", count.ToString(), collectionName);
        }
    }
}
