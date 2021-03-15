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
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm;
using Windsor.Node2008.WNOSPlugin.WQX2XsdOrm;
using Microsoft.VisualBasic.FileIO;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.WQX3
{
    [Serializable]
    public class WQXTWQDImportSubmissionProcessor : BaseWNOSPlugin, ISubmitProcessor
    {
        #region fields
        protected const string DESTINATION_PROVIDER_KEY = "Data Destination";
        protected const string CONFIG_ORG_ID = "WQX Organization Id";
        private string _organizationId;

        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected ITransactionManager _transactionManager;
        protected SpringBaseDao _baseDao;
        #endregion

        public WQXTWQDImportSubmissionProcessor()
        {
            ConfigurationArguments.Add(CONFIG_ORG_ID, null);

            DataProviders.Add(DESTINATION_PROVIDER_KEY, null);
        }
        protected virtual void LazyInit()
        {
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _transactionManager);

            _baseDao = ValidateDBProvider(DESTINATION_PROVIDER_KEY, typeof(NamedNullMappingDataReader));

            _organizationId = ValidateNonEmptyConfigParameter(CONFIG_ORG_ID);
            
            AppendAuditLogEvent("Config parameters: {0} ({1})", CONFIG_ORG_ID, _organizationId);
        }
        public virtual void ProcessSubmit(string transactionId)
        {
            LazyInit();

            IList<string> documentIds = _documentManager.GetDocumentIds(transactionId);

            if (CollectionUtils.IsNullOrEmpty(documentIds))
            {
                AppendAuditLogEvent("Didn't find any submit documents to process.");
                return;
            }
            AppendAuditLogEvent("Found {0} submit documents to process.", documentIds.Count.ToString());

            foreach (string docId in documentIds)
            {
                ProcessSubmitDocument(transactionId, docId);
            }
        }

        protected virtual void ProcessSubmitDocument(string transactionId, string docId)
        {
            try
            {
                WQXDataType data = GetWQXData(transactionId, docId);

                AppendAuditLogEvent("WQX data contains {0} Projects, {1} Activities, {2} Biological Habitat Indexes, {3} Monitoring Locations, and {4} Activity Groups for Organization Id \"{5}\"",
                                    CollectionUtils.Count(data.Organization.Project).ToString(),
                                    CollectionUtils.Count(data.Organization.Activity).ToString(),
                                    CollectionUtils.Count(data.Organization.BiologicalHabitatIndex).ToString(),
                                    CollectionUtils.Count(data.Organization.MonitoringLocation).ToString(),
                                    CollectionUtils.Count(data.Organization.ActivityGroup).ToString(),
                                    _organizationId);

                AppendAuditLogEvent("Storing WQX data into database");

                TWQDMerge twqdMerge = new WQX3.TWQDMerge();
                Dictionary<string, int> insertCounts = null, updateCounts = null;

                _baseDao.TransactionTemplate.Execute(delegate
                {
                    AppendAuditLogEvent("Storing WQX data for organization \"{0}\" into data store ...", _organizationId);

                    twqdMerge.MergeWQXData(data, _baseDao, true, true, out insertCounts, out updateCounts);

                    AppendAuditLogEvent("Stored WQX data content for organization \"{0}\" into data store with the following table row counts: {1}",
                                        data.Organization.OrganizationDescription.OrganizationIdentifier,
                                        TWQDMerge.CreateTableRowCountsString(insertCounts, updateCounts));
                    return null;
                });
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to process document with id \"{0}.\"  EXCEPTION: {1}",
                                    docId.ToString(), ExceptionUtils.ToShortString(e));
                throw;
            }
        }
        protected virtual WQXDataType GetWQXData(string transactionId, string docId)
        {
            WQXDataType data = null;
            string tempFilePath = _settingsProvider.NewTempFilePath();
            try
            {
                AppendAuditLogEvent("Extracting contents of document with id \"{0}\" to temporary file", docId);

                byte[] content = _documentManager.GetContent(transactionId, docId);

                if (_compressionHelper.IsCompressed(content))
                {
                    _compressionHelper.Uncompress(content, tempFilePath);
                }
                else
                {
                    File.WriteAllBytes(tempFilePath, content);
                }

                AppendAuditLogEvent("Generating WQX data from flat file for Organization Id \"{0}\"", _organizationId);

                data = WQXFlatFileParser.GetWQXDataFromResultsFlatFile(tempFilePath, null, _organizationId, null);
            }
            finally
            {
                FileUtils.SafeDeleteFile(tempFilePath);
            }
            return data;
        }
    }
}