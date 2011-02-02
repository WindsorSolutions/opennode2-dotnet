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
using System.Xml.Serialization;
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
using Windsor.Node2008.WNOSPlugin.CERS_12;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.EIS_11
{
    [Serializable]
    public abstract class EISPluginBase : BaseWNOSPlugin
    {
        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;

        protected const string PRODUCTION_SUBMISSION_TYPE_NAME = "Production";
        protected const string QA_SUBMISSION_TYPE_NAME = "QA";
        protected const string DATA_CATEGORY_HEADER_KEY = "DataCategory";
        protected const string SUBMISSION_TYPE_HEADER_KEY = "SubmissionType";

        public EISPluginBase()
        {
        }

        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", typeof(EISPluginBase).Name);

            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
        }
        protected string GenerateSubmissionFile(CERSDataType data, string authorName, string organizationName,
                                                string senderContactInfo, bool isProductionSubmission,
                                                string attachmentFolderPath, SpringBaseDao baseDao)
        {
            string tempZipFilePath = _settingsProvider.NewTempFilePath(".zip");
            string tempXmlFilePath = _settingsProvider.NewTempFilePath(".xml");
            // Required for the EIS backend parser:
            //XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //ns.Add("cer", "http://www.exchangenetwork.net/schema/cer/1");
            try
            {
                //_serializationHelper.SerializerNamespaces = ns;
                _serializationHelper.Serialize(data, tempXmlFilePath);

                AppendAuditLogEvent("Generating submission file (with an exchange header) from results");

                IHeaderDocument2Helper headerDocumentHelper;
                GetServiceImplementation(out headerDocumentHelper);

                //headerDocumentHelper.SerializerNamespaces = ns;
                // Configure the submission header helper
                headerDocumentHelper.Configure(authorName, organizationName, "EIS", "EIS_v1_0", string.Empty,
                                               senderContactInfo, null);

                DataCategory submissionDataCategory = (data.DataCategory == DataCategory.OnroadNonroadActivity) ?
                    DataCategory.Nonroad : data.DataCategory;
                headerDocumentHelper.AddPropery(SUBMISSION_TYPE_HEADER_KEY, 
                                                isProductionSubmission ? PRODUCTION_SUBMISSION_TYPE_NAME : QA_SUBMISSION_TYPE_NAME);
                headerDocumentHelper.AddPropery(DATA_CATEGORY_HEADER_KEY, 
                                                EnumUtils.ToDescription(submissionDataCategory));

                if (data.DataCategory == DataCategory.OnroadNonroadActivity)
                {
                    IList<string> attachmentFileNames = data.GetAttachmentFileNames();
                    CollectionUtils.ForEach(attachmentFileNames, delegate(string fileName)
                    {
                        headerDocumentHelper.AddPropery("NCDDataFile", fileName);
                    });
                }

                string tempXmlFilePath2 = _settingsProvider.NewTempFilePath(".xml");
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(tempXmlFilePath);

                    headerDocumentHelper.AddPayload(string.Empty, doc.DocumentElement);

                    headerDocumentHelper.Serialize(tempXmlFilePath2);

                    _compressionHelper.CompressFile(tempXmlFilePath2, tempZipFilePath);
                }
                finally
                {
                    FileUtils.SafeDeleteFile(tempXmlFilePath2);
                }
                data.AddAttachmentsToZipFile(tempZipFilePath, attachmentFolderPath, baseDao,
                                             _compressionHelper);
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
        protected string GenerateSubmissionFileAndAddToTransaction(CERSDataType data, string transactionId,
                                                                   string authorName, string organizationName,
                                                                   string senderContactInfo, bool isProductionSubmission,
                                                                   string attachmentFolderPath, SpringBaseDao baseDao)
        {
            string submitFile = GenerateSubmissionFile(data, authorName, organizationName, senderContactInfo,
                                                       isProductionSubmission, attachmentFolderPath, baseDao);
            try
            {
                AppendAuditLogEvent("Attaching submission document to transaction \"{0}\"",
                                    transactionId);
                _documentManager.AddDocument(transactionId,
                                             CommonTransactionStatusCode.Completed,
                                             null, submitFile);
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to attach submission document \"{0}\" to transaction \"{1}\" with exception: {2}",
                                    submitFile, transactionId, ExceptionUtils.ToShortString(e));
                FileUtils.SafeDeleteFile(submitFile);
                throw;
            }
            return submitFile;
        }
    }
}
