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

namespace Windsor.Node2008.WNOSPlugin.BEACHES_21
{
    [Serializable]
    public class PerformBeachesSubmission : BaseWNOSPlugin, ITaskProcessor
    {
        protected enum BeachesDataSourceParams
        {
            None,
            [Description("Data Source")]
            DataSource,
        }
        protected enum BeachesConfigArgs
        {
            None,
            [Description("Submission Partner Name")]
            SubmissionPartnerName,
        }
        #region fields

        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected IRequestManager _requestManager;
        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected IObjectsFromDatabase _objectsFromDatabase;
        protected IObjectsToDatabase _objectsToDatabase;
        protected ITransactionManager _transactionManager;
        protected INodeEndpointClientFactory _nodeEndpointClientFactory;
        protected IPartnerManager _partnerManager;

        protected SpringBaseDao _baseDao;
        protected PartnerIdentity _epaPartnerNode;
        protected DataRequest _dataRequest;

        protected const string BEACHES_FLOW_NAME = "BEACHES";

        #endregion

        public PerformBeachesSubmission()
        {
            AppendConfigArguments<BeachesConfigArgs>();

            AppendDataProviders<BeachesDataSourceParams>();
        }

        public virtual void ProcessTask(string requestId)
        {
            ProcessTaskInit(requestId);

            PerformSubmission();
        }

        public virtual void ProcessTaskInit(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);
        }
        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing BEACHES plugin ...");

            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _objectsFromDatabase);
            GetServiceImplementation(out _objectsToDatabase);
            GetServiceImplementation(out _nodeEndpointClientFactory);
            GetServiceImplementation(out _partnerManager);

            _baseDao = ValidateDBProvider(EnumUtils.ToDescription(BeachesDataSourceParams.DataSource), typeof(NamedNullMappingDataReader));

            string epaPartnerName = GetConfigParameter(EnumUtils.ToDescription(BeachesConfigArgs.SubmissionPartnerName));
            if (!string.IsNullOrEmpty(epaPartnerName))
            {
                _epaPartnerNode = _partnerManager.GetByName(epaPartnerName);
                if (_epaPartnerNode == null)
                {
                    throw new ArgumentException(string.Format("The node partner \"{0}\" with the name \"{1}\" specified for this service cannot be found",
                                                              EnumUtils.ToDescription(BeachesConfigArgs.SubmissionPartnerName), epaPartnerName));
                }
            }
            else
            {
                AppendAuditLogEvent("WARNING: A {0} was not specified, so the generated BEACHES xml file will NOT be submitted, but it will be added to the transaction.",
                                    EnumUtils.ToDescription(BeachesConfigArgs.SubmissionPartnerName));
            }
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);
        }
        protected void UpdateStatusOfNetworkTransaction(string localTransactionId, string endpointNetworkId, 
                                                        string endpointUrl, EndpointVersionType endpointVersion)
        {
            try
            {
                CommonTransactionStatusCode statusCode;
                using (INodeEndpointClient endpointClient = _nodeEndpointClientFactory.Make(endpointUrl, endpointVersion))
                {
                    statusCode = endpointClient.GetStatus(endpointNetworkId);
                    _transactionManager.SetNetworkIdStatus(localTransactionId, statusCode, null);
                }
                AppendAuditLogEvent("Successfully got status of \"{0}\" from network url \"{1}\" for network transaction id \"{2}.\"",
                                    statusCode.ToString(), endpointUrl, endpointNetworkId);
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to get status from network url \"{0}\" for network transaction id \"{1}.\"  Error: {2}",
                                    endpointUrl, endpointNetworkId, ExceptionUtils.GetDeepExceptionMessage(e));
            }
        }
        protected string GenerateSubmissionFile(BeachDataSubmissionDataType data)
        {
            string tempXmlFilePath = _settingsProvider.NewTempFilePath(".xml");
            try
            {
                AppendAuditLogEvent("Generating submission file from results");
                _serializationHelper.Serialize(data, tempXmlFilePath);
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath);
                throw;
            }
            return tempXmlFilePath;
        }
        protected string GenerateSubmissionFileAndAddToTransaction(BeachDataSubmissionDataType data)
        {
            string submitFile = GenerateSubmissionFile(data);
            try
            {
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
                    throw;
                }
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteFile(submitFile);
                throw;
            }
            return submitFile;
        }
        protected void PerformSubmission()
        {
            const string BEACH_ACTIVITY_SELECT = "SENTTOEPA IS NULL OR SENTTOEPA <> 'Y'";

            Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>();

            selectClauses.Add("NOTIF_BEACHACTIVITY", new DbAppendSelectWhereClause(_baseDao, BEACH_ACTIVITY_SELECT));

            AppendAuditLogEvent("Querying database for BEACHES data ...");
            List<OrganizationDetailDataType> organizationDetails = _objectsFromDatabase.LoadFromDatabase<OrganizationDetailDataType>(_baseDao, null);
            List<BeachDetailDataType> beachDetails = _objectsFromDatabase.LoadFromDatabase<BeachDetailDataType>(_baseDao, selectClauses);
            List<BeachProcedureDetailDataType> beachProcedureDetails = _objectsFromDatabase.LoadFromDatabase<BeachProcedureDetailDataType>(_baseDao, null);
            List<YearCompletionIndicatorDataType> yearCompletionIndicators = _objectsFromDatabase.LoadFromDatabase<YearCompletionIndicatorDataType>(_baseDao, null);

            if (!CollectionUtils.IsNullOrEmpty(yearCompletionIndicators) && (yearCompletionIndicators.Count > 1))
            {
                throw new ArgumentException(string.Format("More than one \"Year Completion Indicator\" was found to submit"));
            }

            BeachDataSubmissionDataType data = new BeachDataSubmissionDataType();
            data.YearCompletionIndicators = CollectionUtils.IsNullOrEmpty(yearCompletionIndicators) ? null : yearCompletionIndicators[0];
            data.BeachDetail = CollectionUtils.IsNullOrEmpty(beachDetails) ? null : beachDetails.ToArray();
            data.BeachProcedureDetail = CollectionUtils.IsNullOrEmpty(beachProcedureDetails) ? null : beachProcedureDetails.ToArray();
            data.OrganizationDetail = CollectionUtils.IsNullOrEmpty(organizationDetails) ? null : organizationDetails.ToArray();

            if ((data.YearCompletionIndicators == null) && (data.BeachDetail == null) &&
                (data.BeachProcedureDetail == null) && (data.OrganizationDetail == null))
            {
                AppendAuditLogEvent("No BEACHES data was found to submit, exiting plugin.");
                return;
            }
            else
            {
                AppendAuditLogEvent(GetSubmissionResultsString(data));
            }
            data.AfterLoadFromDatabase();
            
            string submissionFile = GenerateSubmissionFileAndAddToTransaction(data);

            SubmitDataToEndpoint(submissionFile);

            int rowsSet = _baseDao.AdoTemplate.ExecuteNonQuery(CommandType.Text, "UPDATE NOTIF_BEACHACTIVITY SET SENTTOEPA = 'Y' WHERE " + BEACH_ACTIVITY_SELECT);

            AppendAuditLogEvent("Set {0} NOTIF_BEACHACTIVITY.SENTTOEPA columns to 'Y'", rowsSet.ToString());
        }
        protected string SubmitDataToEndpoint(string filePath)
        {
            if (_epaPartnerNode == null)
            {
                AppendAuditLogEvent("No node partner was specified for submission, so no Submit will be performed.");
                return null;
            }
            string transactionId;
            try
            {
                AppendAuditLogEvent("Submitting BEACHES data to endpoint \"{0}\"", _epaPartnerNode.Name);
                try
                {
                    using (INodeEndpointClient endpointClient = _nodeEndpointClientFactory.Make(_epaPartnerNode.Url, _epaPartnerNode.Version))
                    {
                        if (endpointClient.Version == EndpointVersionType.EN20)
                        {
                            transactionId =
                                endpointClient.Submit(BEACHES_FLOW_NAME, "default",
                                                      string.Empty, new string[] { filePath });
                        }
                        else
                        {
                            transactionId =
                                endpointClient.Submit(BEACHES_FLOW_NAME, null, new string[] { filePath });
                        }
                    }
                    AppendAuditLogEvent("Successfully submitted BEACHES data to endpoint \"{0}\" with returned transaction id \"{1}\"",
                                         _epaPartnerNode.Name, transactionId);

                    UpdateStatusOfNetworkTransaction(_dataRequest.TransactionId, transactionId, 
                                                     _epaPartnerNode.Url, _epaPartnerNode.Version);
                }
                catch (Exception e)
                {
                    AppendAuditLogEvent("Failed to submit BEACHES data to endpoint \"{0}\": {1}",
                                        _epaPartnerNode.Name, ExceptionUtils.ToShortString(e));
                    throw;
                }
                _transactionManager.SetNetworkId(_dataRequest.TransactionId, transactionId, _epaPartnerNode.Version,
                                                 _epaPartnerNode.Url);
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to submit BEACHES data to endpoint \"{0}\" with exception: {1}",
                                    _epaPartnerNode.Name, ExceptionUtils.ToShortString(e));
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(filePath);
            }
            return transactionId;
        }
        protected string GetSubmissionResultsString(BeachDataSubmissionDataType data)
        {
            StringBuilder sb = new StringBuilder();
            if (data == null)
            {
                sb.AppendFormat("Did not find any BEACHES submission data.");
            }
            else
            {
                sb.AppendFormat("Found the following BEACHES submission data: ");
                int i = 0;
                AppendCountString("Organization Details", data.OrganizationDetail, ++i == 1, sb);
                AppendCountString("Beach Details", data.BeachDetail, ++i == 1, sb);
                AppendCountString("Beach Procedure Details", data.BeachProcedureDetail, ++i == 1, sb);
                int beachActivityCount = 0;
                CollectionUtils.ForEach(data.BeachDetail, delegate(BeachDetailDataType beachDetailDataType)
                {
                    if (beachDetailDataType.BeachActivityDetail != null)
                    {
                        beachActivityCount += beachDetailDataType.BeachActivityDetail.Length;
                    }
                });
                sb.AppendFormat(", {0} {1}", beachActivityCount.ToString(), "Beach Activities");
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
