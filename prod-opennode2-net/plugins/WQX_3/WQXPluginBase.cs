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
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Node2008.WNOSPlugin.WQX3XsdOrm;
using Windsor.Commons.NodeDomain;
using Windsor.Commons.NodeClient;
using System.Linq;

namespace Windsor.Node2008.WNOSPlugin.WQX3
{
    [Serializable]
    public abstract class WQXPluginBase : BaseWNOSPlugin
    {
        protected enum Tables
        {
            WQX_ORGANIZATION,
            WQX_SUBMISSIONHISTORY,
            WQX_ORGADDRESS,
            WQX_ELECTRONICADDRESS,
            WQX_TELEPHONIC,
            WQX_PROJECT,
            WQX_PROJECTMONLOC,
            WQX_ACTIVITY,
            WQX_ACTIVITYGROUP,
            WQX_ACTIVITYCONDUCTINGORG,
            WQX_PROJECTACTIVITY,
            WQX_ACTIVITYMETRIC,
            WQX_MONITORINGLOCATION,
            WQX_BIOLOGICALHABITATINDEX,
            WQX_DELETES,
        }
        public enum Submission_Type
        {
            [Description("Update-Insert")]
            UpdateInsert,
            [Description("Delete")]
            Delete
        }
        protected class PendingSubmissionInfo
        {
            private string _recordId;
            private string _localTransactionId;
            public PendingSubmissionInfo(string recordId, string localTransactionId)
            {
                _recordId = recordId;
                _localTransactionId = localTransactionId;
            }
            public string LocalTransactionId
            {
                get { return _localTransactionId; }
                set { _localTransactionId = value; }
            }
            public string RecordId
            {
                get { return _recordId; }
                set { _recordId = value; }
            }
        }

        #region fields
        protected const string WQX_FLOW_NAME = "WQX";
        // TODO: What are the submit names
        protected const string WQX_INSERT_UPDATE_OPERATION_NAME = "WQXGetInsertUpdateSubmission";
        protected const string WQX_DELETE_OPERATION_NAME = "WQXGetDeleteSubmission";

        // Config arguments:
        protected const string CONFIG_EPA_PARTNER_NAME_KEY = "Submission Partner Name";
        protected const string CONFIG_AUTHOR = "Author";
        protected const string CONFIG_ORGANIZATION = "Organization";
        protected const string CONFIG_CONTACT_INFO = "Contact Info";

        protected const string SOURCE_PROVIDER_KEY = "Data Source";

        public const string PARAM_ORGANIZATION_IDENTIFIER_KEY = "OrganizationIdentifier";
        protected const string PARAM_ADD_HEADER_KEY = "AddHeader";
        protected const string PARAM_USE_SUBMISSION_HISTORY_TABLE_KEY = "UseSubmissionHistoryTable";
        protected const string PARAM_WQX_UPDATE_DATE_KEY = "WQXUpdateDate";
        protected const string PARAM_ACTIVITY_START_DATE_KEY = "ActivityStartDate";
        protected const string PARAM_VALIDATE_XML_KEY = "ValidateXml";
        protected const string PARAM_WQX_START_DATE_KEY = "StartDate";
        protected const string PARAM_WQX_END_DATE_KEY = "EndDate";

        protected IRequestManager _requestManager;
        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected IPartnerManager _partnerManager;
        protected IHeaderDocumentHelper _headerDocumentHelper;
        protected INodeEndpointClientFactory _nodeEndpointClientFactory;
        protected ITransactionManager _transactionManager;

        protected string _organizationIdentifier;
        protected DateTime _wqxUpdateDate = MIN_VALID_DATE_TIME;
        protected string _wqxUpdateDateDbString;
        protected DateTime _activityStartDate = DateTime.MinValue;
        protected DataRequest _dataRequest;
        protected PartnerIdentity _epaPartnerNode;
        protected SpringBaseDao _baseDao;
        protected IdProvider _idProvider;
        protected bool _addHeader = true;
        protected bool _validateXml;
        protected DateTime _wqxStartDate = DateTime.MinValue;
        protected DateTime _wqxEndDate = DateTime.MinValue;
        internal WQXPluginMapper _wqxPluginMapper;

        // Data stores:
        protected Dictionary<string, ProjectDataType> _projects;

        protected string _organizationRecordId;
        #endregion

        public WQXPluginBase()
        {
            ConfigurationArguments.Add(CONFIG_EPA_PARTNER_NAME_KEY, null);
            ConfigurationArguments.Add(CONFIG_AUTHOR, null);
            ConfigurationArguments.Add(CONFIG_ORGANIZATION, null);
            ConfigurationArguments.Add(CONFIG_CONTACT_INFO, null);

            DataProviders.Add(SOURCE_PROVIDER_KEY, null);

            _useSubmissionHistoryTable = true;
        }
        /// <summary>
        /// ProcessSolicit
        /// </summary>
        public virtual void ProcessQuerySolicitInit(string requestId, bool validatePartnerName)
        {
            LazyInit(validatePartnerName);

            ValidateRequest(requestId);

            ValidateOrganization();
        }
        protected virtual void LazyInit(bool validatePartnerName)
        {
            AppendAuditLogEvent("Initializing WQXPluginBase plugin ...");

            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _partnerManager);
            GetServiceImplementation(out _headerDocumentHelper);
            GetServiceImplementation(out _nodeEndpointClientFactory);
            GetServiceImplementation(out _idProvider);
            GetServiceImplementation(out _transactionManager);

            ValidateNonEmptyConfigParameter(CONFIG_AUTHOR);
            ValidateNonEmptyConfigParameter(CONFIG_ORGANIZATION);
            ValidateNonEmptyConfigParameter(CONFIG_CONTACT_INFO);

            string epaPartnerName = null;
            TryGetConfigParameter(CONFIG_EPA_PARTNER_NAME_KEY, ref epaPartnerName);

            if (validatePartnerName)
            {
                if (string.IsNullOrEmpty(epaPartnerName))
                {
                    throw new ArgumentException(string.Format("The config argument \"{0}\" was not specified.", CONFIG_EPA_PARTNER_NAME_KEY));
                }
            }
            if (!string.IsNullOrEmpty(epaPartnerName))
            {
                _epaPartnerNode = _partnerManager.GetByName(epaPartnerName);
                if (_epaPartnerNode == null)
                {
                    throw new ArgumentException(string.Format("The node partner \"{0}\" with the name \"{1}\" specified for this service cannot be found",
                                                              CONFIG_EPA_PARTNER_NAME_KEY, epaPartnerName));
                }
            }
            else
            {
                _useSubmissionHistoryTable = false;
            }

            _baseDao = ValidateDBProvider(SOURCE_PROVIDER_KEY, typeof(NamedNullMappingDataReader));

            string attachedBinaryObjectsFolder = Path.Combine(_settingsProvider.TempFolderPath, Guid.NewGuid().ToString());
            _wqxPluginMapper = new WQXPluginMapper(attachedBinaryObjectsFolder);
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);

            GetParameter(_dataRequest, PARAM_ORGANIZATION_IDENTIFIER_KEY, 0, out _organizationIdentifier);
            TryGetParameter(_dataRequest, PARAM_WQX_UPDATE_DATE_KEY, 1, ref _wqxUpdateDate);
            TryGetParameter(_dataRequest, PARAM_ACTIVITY_START_DATE_KEY, 2, ref _activityStartDate);
            TryGetParameter(_dataRequest, PARAM_ADD_HEADER_KEY, 3, ref _addHeader);
            TryGetParameter(_dataRequest, PARAM_USE_SUBMISSION_HISTORY_TABLE_KEY, 4, ref _useSubmissionHistoryTable);
            TryGetParameter(_dataRequest, PARAM_VALIDATE_XML_KEY, 5, ref _validateXml);
            TryGetParameter(_dataRequest, PARAM_WQX_START_DATE_KEY, 6, ref _wqxStartDate);
            TryGetParameter(_dataRequest, PARAM_WQX_END_DATE_KEY, 7, ref _wqxEndDate);

            if (_epaPartnerNode == null)
            {
                _useSubmissionHistoryTable = false;
            }
            SpringBaseDao.ValidateAgainstSqlInjection(_organizationIdentifier);
            _wqxUpdateDateDbString = WQXPluginMapper.ToDateString(_baseDao.IsOracleDatabase, _wqxUpdateDate);
            AppendAuditLogEvent("Running submission for organization \"{0}\"", _organizationIdentifier);
        }
        /// <summary>
        /// Return the Query, Solicit, or Execute data service parameters for specified data service.
        /// This method should NOT call GetServiceImplementation().
        /// </summary>
        public override IList<TypedParameter> GetDataServiceParameters(string serviceName, out DataServicePublishFlags publishFlags)
        {
            publishFlags = DataServicePublishFlags.DoNotPublish;
            List<TypedParameter> list = new List<TypedParameter>(2);
            list.Add(new TypedParameter("OrganizationIdentifier", "The identifier of the organization for which data will be returned", true, typeof(string), true));
            list.Add(new TypedParameter("WQXUpdateDate", "Data will be returned that has been updated since this date", false, typeof(DateTime), true));
            list.Add(new TypedParameter("AddHeader", "True to add an exchange header to the returned data, false otherwise", false, typeof(bool), true));
            list.Add(new TypedParameter("UseSubmissionHistoryTable", "True to use the submission history table during processing", false, typeof(bool), false));
            return list;
        }
        protected virtual IList<PendingSubmissionInfo> GetPendingSubmissions()
        {
            List<PendingSubmissionInfo> pendingSubmissions = null;
            if (_useSubmissionHistoryTable)
            {
                _baseDao.DoSimpleQueryWithRowCallbackDelegate(
                    Tables.WQX_SUBMISSIONHISTORY.ToString(),
                    "CDXPROCESSINGSTATUS;PARENTID",
                    new object[] { EnumUtils.ToDescription(CDX_Processing_Status.Pending),
                                   _organizationRecordId },
                    "RECORDID;LOCALTRANSACTIONID",
                    delegate(IDataReader reader)
                    {
                        NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)reader;
                        if (pendingSubmissions == null) pendingSubmissions = new List<PendingSubmissionInfo>();
                        pendingSubmissions.Add(new PendingSubmissionInfo(readerEx.GetString("RECORDID"),
                                                                         readerEx.GetString("LOCALTRANSACTIONID")));
                    });
                if (pendingSubmissions != null)
                {
                    AppendAuditLogEvent("Found {0} pending submissions",
                                              pendingSubmissions.Count.ToString());
                }
                else
                {
                    AppendAuditLogEvent("Didn't find any pending submissions");
                }
            }
            return pendingSubmissions;
        }
        protected virtual void CheckForPendingSubmissions(Submission_Type submissionType)
        {
            if (_useSubmissionHistoryTable)
            {
                AppendAuditLogEvent("Checking for pending submissions");

                List<string> recordIdList = null;
                _baseDao.DoSimpleQueryWithRowCallbackDelegate(
                    Tables.WQX_SUBMISSIONHISTORY.ToString(),
                    "CDXPROCESSINGSTATUS;SUBMISSIONTYPE;PARENTID",
                    new object[] { EnumUtils.ToDescription(CDX_Processing_Status.Pending),
                                   EnumUtils.ToDescription(submissionType),
                                   _organizationRecordId },
                    "RECORDID",
                    delegate(IDataReader reader)
                    {
                        if (recordIdList == null) recordIdList = new List<string>();
                        recordIdList.Add(reader.GetString(0));
                    });
                if (recordIdList != null)
                {
                    throw new InvalidOperationException(string.Format("There are pending \"{0}\" submissions for \"{1}\": {2}",
                                                                      EnumUtils.ToDescription(submissionType),
                                                                      _organizationIdentifier,
                                                                      string.Join(", ", recordIdList.ToArray())));
                }
            }
        }
        protected virtual string SetPendingSubmission(Submission_Type submissionType)
        {
            if (_useSubmissionHistoryTable)
            {
                // Locate the last successful submission
                DateTime? lastRunDate = null;
                _baseDao.DoSimpleQueryWithCancelableRowCallbackDelegate(
                    Tables.WQX_SUBMISSIONHISTORY.ToString(),
                    "CDXPROCESSINGSTATUS;SUBMISSIONTYPE;PARENTID",
                    new object[] { EnumUtils.ToDescription(CDX_Processing_Status.Completed),
                                   EnumUtils.ToDescription(submissionType),
                                   _organizationRecordId },
                    "SCHEDULERUNDATE DESC",
                    "SCHEDULERUNDATE",
                    delegate(IDataReader reader)
                    {
                        lastRunDate = new DateTime?(reader.GetDateTime(0));
                        return false;
                    });

                if (_wqxUpdateDate == MIN_VALID_DATE_TIME)
                {
                    if (lastRunDate != null)
                    {
                        _wqxUpdateDate = lastRunDate.Value;
                    }
                    AppendAuditLogEvent("Determined wqxUpdateDate from submission history table: {0}",
                                              _wqxUpdateDate.ToString());
                }

                AppendAuditLogEvent("Adding pending submission to history table");
                string recordId = _idProvider.Get();
                _baseDao.DoInsert(
                    Tables.WQX_SUBMISSIONHISTORY.ToString(),
                    "RECORDID;PARENTID;SCHEDULERUNDATE;WQXUPDATEDATE;SUBMISSIONTYPE;LOCALTRANSACTIONID;CDXPROCESSINGSTATUS;ORGID",
                    new object[] { recordId, _organizationRecordId, DateTime.Now, _wqxUpdateDate, 
                                   EnumUtils.ToDescription(submissionType), "PENDING",
                                   EnumUtils.ToDescription(CDX_Processing_Status.Pending),
                                   _organizationIdentifier }
                                  );
                return recordId;
            }
            else
            {
                return string.Empty;
            }
        }
        protected virtual void SetSubmissionFailed(string recordId)
        {
            if (_useSubmissionHistoryTable)
            {
                AppendAuditLogEvent("Setting pending submission \"{0}\" to failed in submission history table",
                                          recordId);
                _baseDao.DoSimpleUpdateOne(
                    Tables.WQX_SUBMISSIONHISTORY.ToString(),
                    "RECORDID", new object[] { recordId },
                    "CDXPROCESSINGSTATUS", EnumUtils.ToDescription(CDX_Processing_Status.Failed)
                        );
            }
        }
        protected virtual void UpdatePendingSubmissionInfo(string recordId, string localTransactionId)
        {
            if (_useSubmissionHistoryTable && !string.IsNullOrEmpty(localTransactionId))
            {
                AppendAuditLogEvent("Updating pending submission \"{0}\" in submission history table with LOCALTRANSACTIONID = \"{1}\"",
                                          recordId, localTransactionId);
                _baseDao.DoSimpleUpdateOne(
                    Tables.WQX_SUBMISSIONHISTORY.ToString(),
                    "RECORDID", new object[] { recordId },
                    "LOCALTRANSACTIONID", localTransactionId
                        );
            }
        }
        protected virtual void UpdateSubmissionStatus(string recordId, CDX_Processing_Status status)
        {
            if (_useSubmissionHistoryTable)
            {
                string dbStatus = EnumUtils.ToDescription(status);
                AppendAuditLogEvent("Updating pending submission \"{0}\" in submission history table with status = \"{1}\"",
                                          recordId, dbStatus);
                _baseDao.DoSimpleUpdateOne(
                    Tables.WQX_SUBMISSIONHISTORY.ToString(),
                    "RECORDID", new object[] { recordId },
                    "CDXPROCESSINGSTATUS", dbStatus
                        );
            }
        }
        protected virtual object GetInsertUpdateData()
        {
            WQXDataType data = new WQXDataType();
            data.Organization = new OrganizationDataType();

            data.Organization.OrganizationDescription = GetOrganizationDescription();

            data.Organization.OrganizationAddress = GetOrganizationAddress();

            data.Organization.ElectronicAddress = GetOrganizationElectronicAddress();

            data.Organization.Telephonic = GetOrganizationTelephonic();

            data.Organization.Project = GetOrganizationProjects();

            data.Organization.Activity = GetOrganizationActivities();

            data.Organization.ActivityGroup = GetOrganizationActivityGroups();

            data.Organization.MonitoringLocation = GetOrganizationMonitoringLocations();

            data.Organization.BiologicalHabitatIndex = GetOrganizationBiologicalHabitatIndex();

            if (_wqxPluginMapper.AttachedBinaryFileCount > 0)
            {
                AppendAuditLogEvent("Found {0} attached binary objects to submit",
                                   _wqxPluginMapper.AttachedBinaryFileCount.ToString());
            }

            return data;
        }
        protected virtual WQXDeleteDataType GetDeleteData()
        {
            WQXDeleteDataType data = new WQXDeleteDataType();
            data.OrganizationDelete = new OrganizationDeleteDataType();
            // Get _organizationRecordId:
            OrganizationDescriptionDataType desc = GetOrganizationDescription();
            data.OrganizationDelete.OrganizationIdentifier = desc.OrganizationIdentifier;

            List<string> projectIds = null;
            List<string> activityIds = null;
            List<string> monitoringLocIds = null;
            List<string> activityGroupIds = null;
            List<string> biologicalHabitatIds = null;

            _baseDao.DoSimpleQueryWithRowCallbackDelegate(
                Tables.WQX_DELETES.ToString(),
                "PARENTID;WQXUPDATEDATE >",
                new object[] { _organizationRecordId, _wqxUpdateDate },
                "COMPONENT;IDENTIFIER",
                delegate(IDataReader reader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)reader;
                    string componentName = readerEx.GetString("COMPONENT").ToUpper();
                    string componentId = readerEx.GetString("IDENTIFIER").ToUpper();
                    if (string.IsNullOrEmpty(componentId))
                    {
                        throw new ArgumentException(string.Format("Null or empty IDENTIFIER value found in \"{0}\" table",
                                                    Tables.WQX_DELETES.ToString()));
                    }
                    if (componentName == WQXDeleteDataType.DELETE_PROJECT_COMP_NAME)
                    {
                        if (projectIds == null) projectIds = new List<string>();
                        projectIds.Add(componentId);
                    }
                    else if (componentName == WQXDeleteDataType.DELETE_ACTIVITY_COMP_NAME)
                    {
                        if (activityIds == null) activityIds = new List<string>();
                        activityIds.Add(componentId);
                    }
                    else if (componentName == WQXDeleteDataType.DELETE_MONITORING_LOC_COMP_NAME)
                    {
                        if (monitoringLocIds == null) monitoringLocIds = new List<string>();
                        monitoringLocIds.Add(componentId);
                    }
                    else if (componentName == WQXDeleteDataType.DELETE_ACTIVITY_GROUP_COMP_NAME)
                    {
                        if (activityGroupIds == null) activityGroupIds = new List<string>();
                        activityGroupIds.Add(componentId);
                    }
                    else if (componentName == WQXDeleteDataType.DELETE_BIOLOGICAL_HABITAT_INDEX_COMP_NAME)
                    {
                        if (biologicalHabitatIds == null) biologicalHabitatIds = new List<string>();
                        biologicalHabitatIds.Add(componentId);
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("Unrecognized COMPONENT value \"{0}\" found in \"{1}\" table",
                                                    componentName, Tables.WQX_DELETES.ToString()));
                    }
                });
            StringBuilder sb = new StringBuilder();
            if (!CollectionUtils.IsNullOrEmpty(projectIds))
            {
                sb.AppendFormat("Found {0} deleted projects to submit, ",
                                projectIds.Count.ToString());
            }
            else
            {
                sb.Append("Didn't find any deleted projects to submit, ");
            }
            if (!CollectionUtils.IsNullOrEmpty(activityIds))
            {
                sb.AppendFormat("found {0} deleted activities to submit, ",
                                activityIds.Count.ToString());
            }
            else
            {
                sb.Append("didn't find any deleted activities to submit, ");
            }
            if (!CollectionUtils.IsNullOrEmpty(monitoringLocIds))
            {
                sb.AppendFormat("found {0} deleted monitoring locations to submit",
                                monitoringLocIds.Count.ToString());
            }
            else
            {
                sb.Append("didn't find any deleted monitoring locations to submit");
            }
            if (!CollectionUtils.IsNullOrEmpty(activityGroupIds))
            {
                sb.AppendFormat("found {0} deleted activity groups to submit",
                                activityGroupIds.Count.ToString());
            }
            else
            {
                sb.Append("didn't find any deleted activity groups to submit");
            }
            if (!CollectionUtils.IsNullOrEmpty(biologicalHabitatIds))
            {
                sb.AppendFormat("found {0} deleted biological habitats to submit",
                                biologicalHabitatIds.Count.ToString());
            }
            else
            {
                sb.Append("didn't find any deleted biological habitats to submit");
            }
            AppendAuditLogEvent(sb.ToString());
            data.OrganizationDelete.ProjectIdentifier = WQXPluginMapper.ToArray(projectIds);
            data.OrganizationDelete.ActivityIdentifier = WQXPluginMapper.ToArray(activityIds);
            data.OrganizationDelete.MonitoringLocationIdentifier = WQXPluginMapper.ToArray(monitoringLocIds);
            data.OrganizationDelete.ActivityGroupIdentifier = WQXPluginMapper.ToArray(activityGroupIds);
            data.OrganizationDelete.IndexIdentifier = WQXPluginMapper.ToArray(biologicalHabitatIds);
            return data;
        }
        protected virtual void ValidateOrganization()
        {
            _organizationRecordId = null;
            _baseDao.DoSimpleQueryWithRowCallbackDelegate(
                Tables.WQX_ORGANIZATION.ToString(),
                "ORGID",
                _organizationIdentifier,
                "RECORDID",
                delegate(IDataReader reader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)reader;
                    _organizationRecordId = readerEx.GetString("RECORDID");
                });

            if (_organizationRecordId == null)
            {
                throw new ArgumentException(string.Format("The organization \"{0}\" was not found",
                                                          _organizationIdentifier));
            }
        }
        protected virtual OrganizationDescriptionDataType GetOrganizationDescription()
        {
            OrganizationDescriptionDataType organizationDescriptionDataType = null;
            _baseDao.DoSimpleQueryWithRowCallbackDelegate(
                Tables.WQX_ORGANIZATION.ToString(),
                "ORGID",
                _organizationIdentifier,
                delegate(IDataReader reader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)reader;
                    organizationDescriptionDataType = WQXPluginMapper.MapOrganizationDescription(readerEx);
                });

            if (organizationDescriptionDataType == null)
            {
                throw new ArgumentException(string.Format("The organization \"{0}\" was not found.",
                                                          _organizationIdentifier));
            }
            return organizationDescriptionDataType;
        }
        protected virtual OrganizationAddressDataType[] GetOrganizationAddress()
        {
            List<OrganizationAddressDataType> addresses = null;
            _baseDao.DoSimpleQueryWithRowCallbackDelegate(
                Tables.WQX_ORGADDRESS.ToString(),
                "PARENTID",
                _organizationRecordId,
                delegate(IDataReader reader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)reader;
                    OrganizationAddressDataType address = WQXPluginMapper.MapOrganizationAddress(readerEx);
                    if (addresses == null) addresses = new List<OrganizationAddressDataType>();
                    addresses.Add(address);
                });
            return WQXPluginMapper.ToArray(addresses);
        }
        protected virtual ElectronicAddressDataType[] GetOrganizationElectronicAddress()
        {
            List<ElectronicAddressDataType> electronicAddresses = null;
            _baseDao.DoSimpleQueryWithRowCallbackDelegate(
                Tables.WQX_ELECTRONICADDRESS.ToString(),
                "PARENTID",
                _organizationRecordId,
                delegate(IDataReader reader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)reader;
                    ElectronicAddressDataType address = WQXPluginMapper.MapElectronicAddress(readerEx);
                    if (electronicAddresses == null) electronicAddresses = new List<ElectronicAddressDataType>();
                    electronicAddresses.Add(address);
                });
            return WQXPluginMapper.ToArray(electronicAddresses);
        }
        protected virtual TelephonicDataType[] GetOrganizationTelephonic()
        {
            List<TelephonicDataType> telephonics = null;
            _baseDao.DoSimpleQueryWithRowCallbackDelegate(
                Tables.WQX_TELEPHONIC.ToString(),
                "PARENTID",
                _organizationRecordId,
                delegate(IDataReader reader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)reader;
                    TelephonicDataType telephonic = WQXPluginMapper.MapTelephonic(readerEx);
                    if (telephonics == null) telephonics = new List<TelephonicDataType>();
                    telephonics.Add(telephonic);
                });
            return WQXPluginMapper.ToArray(telephonics);
        }
        protected virtual ProjectDataType[] GetOrganizationProjects()
        {
            List<ProjectDataType> projects = null;
            List<string> projectRecordIds = null;
            _baseDao.DoSimpleQueryWithRowCallbackDelegate(
                Tables.WQX_PROJECT.ToString(),
                "PARENTID;WQXUPDATEDATE >",
                new object[] { _organizationRecordId, _wqxUpdateDate },
                delegate(IDataReader reader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)reader;
                    if (projectRecordIds == null) projectRecordIds = new List<string>();
                    projectRecordIds.Add(readerEx.GetString("RECORDID"));
                    ProjectDataType project = WQXPluginMapper.MapProject(readerEx);
                    if (projects == null) projects = new List<ProjectDataType>();
                    projects.Add(project);
                });
            if (projects != null)
            {
                AppendAuditLogEvent("Found {0} updated projects to submit",
                                          projects.Count.ToString());
                GetProjectMonitoringLocationWeighting(projectRecordIds, projects);
                GetProjectAttachedBinaryObjects(projectRecordIds, projects);
            }
            else
            {
                AppendAuditLogEvent("Didn't find any updated projects to submit");
            }
            return WQXPluginMapper.ToArray(projects);
        }
        protected virtual void GetProjectMonitoringLocationWeighting(IList<string> projectRecordIds,
                                                                     IList<ProjectDataType> projects)
        {
            string selectText =
                string.Format("SELECT pml.* FROM WQX_PROJECTMONLOC pml, WQX_PROJECT p WHERE " +
                              "p.PARENTID = '{0}' AND p.WQXUPDATEDATE > '{1}' AND p.RECORDID = pml.PARENTID",
                               _organizationRecordId, _wqxUpdateDateDbString);
            _baseDao.MapArrayObjects<ProjectMonitoringLocationWeightingDataType>(
                "PARENTID", projectRecordIds, selectText, WQXPluginMapper.MapProjectMonitoringLocationWeighting,
                delegate(ProjectMonitoringLocationWeightingDataType[] array, int listKeyFieldsIndex)
                {
                    projects[listKeyFieldsIndex].ProjectMonitoringLocationWeighting = array;
                });
        }
        protected virtual ActivityDataType[] GetOrganizationActivities()
        {
            List<ActivityDataType> activities = null;
            List<string> activityRecordIds = null;
            _baseDao.DoSimpleQueryWithRowCallbackDelegate(
                Tables.WQX_ACTIVITY.ToString(),
                "PARENTID;WQXUPDATEDATE >",
                new object[] { _organizationRecordId, _wqxUpdateDate },
                delegate(IDataReader reader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)reader;
                    if (activityRecordIds == null) activityRecordIds = new List<string>();
                    activityRecordIds.Add(readerEx.GetString("RECORDID"));
                    ActivityDataType activity = WQXPluginMapper.MapActivity(readerEx);
                    if (activities == null) activities = new List<ActivityDataType>();
                    activities.Add(activity);
                });
            if (activities != null)
            {
                AppendAuditLogEvent("Found {0} updated activities to submit",
                                          activities.Count.ToString());
                GetActivityConductingOrganizationText(activityRecordIds, activities);
                GetActivityProjectIdentifier(activityRecordIds, activities);
                GetActivityActivityMetric(activityRecordIds, activities);
                GetActivityAttachedBinaryObjects(activityRecordIds, activities);
                GetActivityResult(activityRecordIds, activities);
            }
            else
            {
                AppendAuditLogEvent("Didn't find any updated activities to submit");
            }
            return WQXPluginMapper.ToArray(activities);
        }
        protected virtual ActivityGroupDataType[] GetOrganizationActivityGroups()
        {
            List<ActivityGroupDataType> activityGroups = null;
            List<string> activityGroupRecordIds = null;
            _baseDao.DoSimpleQueryWithRowCallbackDelegate(
                Tables.WQX_ACTIVITYGROUP.ToString(),
                "PARENTID;WQXUPDATEDATE >",
                new object[] { _organizationRecordId, _wqxUpdateDate },
                delegate (IDataReader reader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)reader;
                    if (activityGroupRecordIds == null) activityGroupRecordIds = new List<string>();
                    activityGroupRecordIds.Add(readerEx.GetString("RECORDID"));
                    ActivityGroupDataType activityGroup = WQXPluginMapper.MapActivityGroup(readerEx);
                    if (activityGroups == null) activityGroups = new List<ActivityGroupDataType>();
                    activityGroups.Add(activityGroup);
                });
            if (activityGroups != null)
            {
                AppendAuditLogEvent("Found {0} updated activity groups to submit",
                                          activityGroups.Count.ToString());
                GetActivityGroupActivityIdentifier(activityGroupRecordIds, activityGroups);
            }
            else
            {
                AppendAuditLogEvent("Didn't find any updated activity groups to submit");
            }
            return WQXPluginMapper.ToArray(activityGroups);
        }
        protected virtual MonitoringLocationDataType[] GetOrganizationMonitoringLocations()
        {
            List<MonitoringLocationDataType> locations = null;
            List<string> locationRecordIds = null;
            _baseDao.DoSimpleQueryWithRowCallbackDelegate(
                Tables.WQX_MONITORINGLOCATION.ToString(),
                "PARENTID;WQXUPDATEDATE >",
                new object[] { _organizationRecordId, _wqxUpdateDate },
                delegate(IDataReader reader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)reader;
                    if (locationRecordIds == null) locationRecordIds = new List<string>();
                    locationRecordIds.Add(readerEx.GetString("RECORDID"));
                    MonitoringLocationDataType location = WQXPluginMapper.MapMonitoringLocation(readerEx);
                    if (locations == null) locations = new List<MonitoringLocationDataType>();
                    locations.Add(location);
                });
            if (locations != null)
            {
                AppendAuditLogEvent("Found {0} updated monitoring locations to submit",
                                          locations.Count.ToString());
                GetMonLocAttachedBinaryObjects(locationRecordIds, locations);
                GetAltMonLoc(locationRecordIds, locations);
            }
            else
            {
                AppendAuditLogEvent("Didn't find any updated monitoring locations to submit");
            }
            return WQXPluginMapper.ToArray(locations);
        }
        private BiologicalHabitatIndexDataType[] GetOrganizationBiologicalHabitatIndex()
        {
            List<BiologicalHabitatIndexDataType> habitats = null;
            _baseDao.DoSimpleQueryWithRowCallbackDelegate(
                Tables.WQX_BIOLOGICALHABITATINDEX.ToString(),
                "PARENTID;WQXUPDATEDATE >",
                new object[] { _organizationRecordId, _wqxUpdateDate },
                delegate(IDataReader reader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)reader;
                    BiologicalHabitatIndexDataType habitat = WQXPluginMapper.MapBiologicalHabitatIndex(readerEx);
                    if (habitats == null) habitats = new List<BiologicalHabitatIndexDataType>();
                    habitats.Add(habitat);
                });
            return WQXPluginMapper.ToArray(habitats);
        }
        protected virtual void GetAltMonLoc(IList<string> locationRecordIds,
                                            IList<MonitoringLocationDataType> locations)
        {
            string selectText =
                string.Format("SELECT aml.* FROM WQX_ALTMONLOC aml, WQX_MONITORINGLOCATION ml WHERE " +
                              "ml.PARENTID = '{0}' AND ml.WQXUPDATEDATE > '{1}' AND ml.RECORDID = aml.PARENTID",
                               _organizationRecordId, _wqxUpdateDateDbString);
            _baseDao.MapArrayObjects<AlternateMonitoringLocationIdentityDataType>(
                "PARENTID", locationRecordIds, selectText, WQXPluginMapper.MapAlternateMonitoringLocationIdentity,
                delegate(AlternateMonitoringLocationIdentityDataType[] array, int listKeyFieldsIndex)
                {
                    locations[listKeyFieldsIndex].MonitoringLocationIdentity.AlternateMonitoringLocationIdentity = array;
                });
        }
        protected string MapActivityConductingOrganizationText(NamedNullMappingDataReader readerEx)
        {
            return readerEx.GetString("ACTIVITYCONDUCTINGORG");
        }
        protected virtual void GetActivityConductingOrganizationText(IList<string> activityRecordIds,
                                                                     IList<ActivityDataType> activities)
        {
            string selectText =
                string.Format("SELECT aco.ACTIVITYCONDUCTINGORG, aco.PARENTID FROM WQX_ACTIVITYCONDUCTINGORG aco, WQX_ACTIVITY a WHERE " +
                              "a.PARENTID = '{0}' AND a.WQXUPDATEDATE > '{1}' AND aco.PARENTID = a.RECORDID",
                               _organizationRecordId, _wqxUpdateDateDbString);
            _baseDao.MapArrayObjects<string>(
                "PARENTID", activityRecordIds, selectText, MapActivityConductingOrganizationText,
                delegate(string[] array, int listKeyFieldsIndex)
                {
                    activities[listKeyFieldsIndex].ActivityDescription.ActivityConductingOrganizationText = array;
                });
        }
        protected string MapActivityProjectIdentifier(NamedNullMappingDataReader readerEx)
        {
            return readerEx.GetString("PROJECTID");
        }
        protected virtual void GetActivityProjectIdentifier(IList<string> activityRecordIds,
                                                            IList<ActivityDataType> activities)
        {
            string selectText =
                string.Format("SELECT p.PROJECTID, pa.ACTIVITYPARENTID FROM WQX_PROJECTACTIVITY pa, WQX_ACTIVITY a, WQX_PROJECT p WHERE " +
                              "a.PARENTID = '{0}' AND a.WQXUPDATEDATE > '{1}' AND pa.ACTIVITYPARENTID = a.RECORDID AND " +
                              "pa.PROJECTPARENTID = p.RECORDID",
                               _organizationRecordId, _wqxUpdateDateDbString);
            _baseDao.MapArrayObjects<string>(
                "ACTIVITYPARENTID", activityRecordIds, selectText, MapActivityProjectIdentifier,
                delegate(string[] array, int listKeyFieldsIndex)
                {
                    activities[listKeyFieldsIndex].ActivityDescription.ProjectIdentifier = array;
                });
        }
        protected string MapActivityGroupActivityIdentifier(NamedNullMappingDataReader readerEx)
        {
            return readerEx.GetString("ACTIVITYID");
        }
        protected virtual void GetActivityGroupActivityIdentifier(IList<string> activityGroupRecordIds,
                                                                  IList<ActivityGroupDataType> activityGroups)
        {
            string selectText =
                string.Format("SELECT a.ACTIVITYID, aag.ACTIVITYGROUPPARENTID FROM WQX_ACTIVITYACTIVITYGROUP aag, WQX_ACTIVITY a WHERE " +
                              "a.PARENTID = '{0}' AND a.WQXUPDATEDATE > '{1}' AND aag.ACTIVITYPARENTID = a.RECORDID",
                               _organizationRecordId, _wqxUpdateDateDbString);
            _baseDao.MapArrayObjects<string>(
                "ACTIVITYGROUPPARENTID", activityGroupRecordIds, selectText, MapActivityGroupActivityIdentifier,
                delegate (string[] array, int listKeyFieldsIndex)
                {
                    activityGroups[listKeyFieldsIndex].ActivityIdentifier = array;
                });
        }
        protected virtual void GetActivityActivityMetric(IList<string> activityRecordIds,
                                                         IList<ActivityDataType> activities)
        {
            string selectText =
                string.Format("SELECT am.* FROM WQX_ACTIVITYMETRIC am, WQX_ACTIVITY a WHERE " +
                              "a.PARENTID = '{0}' AND a.WQXUPDATEDATE > '{1}' AND am.PARENTID = a.RECORDID",
                               _organizationRecordId, _wqxUpdateDateDbString);
            _baseDao.MapArrayObjects<ActivityMetricDataType>(
                "PARENTID", activityRecordIds, selectText, WQXPluginMapper.MapActivityMetric,
                delegate(ActivityMetricDataType[] array, int listKeyFieldsIndex)
                {
                    activities[listKeyFieldsIndex].ActivityMetric = array;
                });
        }
        protected virtual void GetActivityAttachedBinaryObjects(IList<string> activityRecordIds,
                                                                IList<ActivityDataType> activities)
        {
            string selectText =
                string.Format("SELECT ab.* FROM WQX_ACTATTACHEDBINARYOBJECT ab, WQX_ACTIVITY a WHERE " +
                              "a.PARENTID = '{0}' AND a.WQXUPDATEDATE > '{1}' AND ab.PARENTID = a.RECORDID",
                               _organizationRecordId, _wqxUpdateDateDbString);
            _baseDao.MapArrayObjects<ActivityAttachedBinaryObjectDataType>(
                "PARENTID", activityRecordIds, selectText, _wqxPluginMapper.MapAttachedBinaryObject<ActivityAttachedBinaryObjectDataType>,
                delegate(ActivityAttachedBinaryObjectDataType[] array, int listKeyFieldsIndex)
                {
                    activities[listKeyFieldsIndex].AttachedBinaryObject = array;
                });
        }
        protected virtual void GetProjectAttachedBinaryObjects(IList<string> projectRecordIds,
                                                               IList<ProjectDataType> projects)
        {
            string selectText =
                string.Format("SELECT ab.* FROM WQX_PROJATTACHEDBINARYOBJECT ab, WQX_PROJECT p WHERE " +
                              "p.PARENTID = '{0}' AND p.WQXUPDATEDATE > '{1}' AND p.RECORDID = ab.PARENTID",
                               _organizationRecordId, _wqxUpdateDateDbString);
            _baseDao.MapArrayObjects<ProjectAttachedBinaryObjectDataType>(
                "PARENTID", projectRecordIds, selectText, _wqxPluginMapper.MapAttachedBinaryObject<ProjectAttachedBinaryObjectDataType>,
                delegate(ProjectAttachedBinaryObjectDataType[] array, int listKeyFieldsIndex)
                {
                    projects[listKeyFieldsIndex].AttachedBinaryObject = array;
                });
        }
        protected virtual void GetResultAttachedBinaryObjects(IList<string> resultRecordIds,
                                                              IList<ResultDataType> results)
        {
            string selectText =
                string.Format("SELECT ab.* FROM WQX_RESULTATTACHEDBINARYOBJECT ab, WQX_RESULT r, WQX_ACTIVITY a WHERE " +
                              "a.PARENTID = '{0}' AND a.WQXUPDATEDATE > '{1}' AND ab.PARENTID = r.RECORDID AND " +
                              "r.PARENTID = a.RECORDID",
                               _organizationRecordId, _wqxUpdateDateDbString);
            _baseDao.MapArrayObjects<ResultAttachedBinaryObjectDataType>(
                "PARENTID", resultRecordIds, selectText, _wqxPluginMapper.MapAttachedBinaryObject<ResultAttachedBinaryObjectDataType>,
                delegate(ResultAttachedBinaryObjectDataType[] array, int listKeyFieldsIndex)
                {
                    results[listKeyFieldsIndex].AttachedBinaryObject = array;
                });
        }
        protected virtual void GetMonLocAttachedBinaryObjects(IList<string> locationRecordIds,
                                                              IList<MonitoringLocationDataType> locations)
        {
            string selectText =
                string.Format("SELECT ab.* FROM WQX_MONLOCATTACHEDBINARYOBJECT ab, WQX_MONITORINGLOCATION ml WHERE " +
                              "ml.PARENTID = '{0}' AND ml.WQXUPDATEDATE > '{1}' AND ml.RECORDID = ab.PARENTID",
                               _organizationRecordId, _wqxUpdateDateDbString);
            _baseDao.MapArrayObjects<MonitoringLocationAttachedBinaryObjectDataType>(
                "PARENTID", locationRecordIds, selectText, _wqxPluginMapper.MapAttachedBinaryObject<MonitoringLocationAttachedBinaryObjectDataType>,
                delegate(MonitoringLocationAttachedBinaryObjectDataType[] array, int listKeyFieldsIndex)
                {
                    locations[listKeyFieldsIndex].AttachedBinaryObject = array;
                });
        }
        protected virtual void GetActivityResult(IList<string> activityRecordIds,
                                                 IList<ActivityDataType> activities)
        {
            List<ResultDataType> results = new List<ResultDataType>();
            List<string> resultRecordIds = null;
            string selectText =
                string.Format("SELECT r.* FROM WQX_RESULT r, WQX_ACTIVITY a WHERE " +
                              "a.PARENTID = '{0}' AND a.WQXUPDATEDATE > '{1}' AND r.PARENTID = a.RECORDID",
                               _organizationRecordId, _wqxUpdateDateDbString);
            _baseDao.MapArrayObjects<ResultDataType>(
                "PARENTID", activityRecordIds, selectText, WQXPluginMapper.MapResult,
                delegate(ResultDataType[] array, int listKeyFieldsIndex)
                {
                    activities[listKeyFieldsIndex].Result = array;
                    if (resultRecordIds == null) resultRecordIds = new List<string>();
                    foreach (ResultDataType result in array)
                    {
                        resultRecordIds.Add(result.RecordId);
                    }
                    results.AddRange(array);
                });
            if (results.Count > 0)
            {
                GetResultLabSamplePrep(resultRecordIds, results);
                GetResultDetectionQuantitationLimit(resultRecordIds, results);
                GetResultMeasureQualifier(resultRecordIds, results);
                GetResultAttachedBinaryObjects(resultRecordIds, results);
                foreach (ResultDataType result in results)
                {
                    if (string.IsNullOrEmpty(result.ResultLabInformation.LaboratoryName) && !result.ResultLabInformation.AnalysisStartDateSpecified &&
                         (result.ResultLabInformation.AnalysisStartTime == null) && !result.ResultLabInformation.AnalysisEndDateSpecified &&
                         (result.ResultLabInformation.AnalysisEndTime == null) && string.IsNullOrEmpty(result.ResultLabInformation.LaboratoryCommentText) &&
                         !result.ResultLabInformation.LaboratoryAccreditationIndicatorSpecified &&
                         string.IsNullOrEmpty(result.ResultLabInformation.LaboratoryAccreditationAuthorityName) &&
                         !result.ResultLabInformation.TaxonomistAccreditationIndicatorSpecified &&
                         string.IsNullOrEmpty(result.ResultLabInformation.TaxonomistAccreditationAuthorityName) &&
                         CollectionUtils.IsNullOrEmpty(result.ResultLabInformation.ResultDetectionQuantitationLimit))
                    {
                        result.ResultLabInformation = null;
                    }
                }
            }
        }
        protected virtual void GetResultLabSamplePrep(IList<string> resultRecordIds,
                                                      IList<ResultDataType> results)
        {
            string selectText =
                string.Format("SELECT lsp.* FROM WQX_LABSAMPLEPREP lsp, WQX_RESULT r, WQX_ACTIVITY a WHERE " +
                              "a.PARENTID = '{0}' AND a.WQXUPDATEDATE > '{1}' AND lsp.PARENTID = r.RECORDID AND " +
                              "r.PARENTID = a.RECORDID",
                               _organizationRecordId, _wqxUpdateDateDbString);
            _baseDao.MapArrayObjects<LabSamplePreparationDataType>(
                "PARENTID", resultRecordIds, selectText, WQXPluginMapper.MapLabSamplePreparation,
                delegate(LabSamplePreparationDataType[] array, int listKeyFieldsIndex)
                {
                    results[listKeyFieldsIndex].LabSamplePreparation = array;
                });
        }
        protected virtual void GetResultDetectionQuantitationLimit(IList<string> resultRecordIds,
                                                                   IList<ResultDataType> results)
        {
            string selectText =
                string.Format("SELECT dql.* FROM WQX_RESULTDETECTQUANTLIMIT dql, WQX_RESULT r, WQX_ACTIVITY a WHERE " +
                              "a.PARENTID = '{0}' AND a.WQXUPDATEDATE > '{1}' AND dql.PARENTID = r.RECORDID AND " +
                              "r.PARENTID = a.RECORDID",
                               _organizationRecordId, _wqxUpdateDateDbString);
            _baseDao.MapArrayObjects<DetectionQuantitationLimitDataType>(
                "PARENTID", resultRecordIds, selectText, WQXPluginMapper.MapDetectionQuantitationLimit,
                delegate(DetectionQuantitationLimitDataType[] array, int listKeyFieldsIndex)
                {
                    results[listKeyFieldsIndex].ResultLabInformation.ResultDetectionQuantitationLimit = array;
                });
        }
        protected virtual void GetResultMeasureQualifier(IList<string> resultRecordIds,
                                                         IList<ResultDataType> results)
        {
            string selectText =
                string.Format("SELECT mq.* FROM WQX_RESULTMEASUREQUALIFIER mq, WQX_RESULT r, WQX_ACTIVITY a WHERE " +
                              "a.PARENTID = '{0}' AND a.WQXUPDATEDATE > '{1}' AND mq.PARENTID = r.RECORDID AND " +
                              "r.PARENTID = a.RECORDID",
                               _organizationRecordId, _wqxUpdateDateDbString);
            _baseDao.MapArrayObjects<ResultMeasureQualifierDataType>(
                "PARENTID", resultRecordIds, selectText, WQXPluginMapper.MapMeasureQualifier,
                delegate (ResultMeasureQualifierDataType[] array, int listKeyFieldsIndex)
                {
                    var result = results[listKeyFieldsIndex];
                    if (result.ResultDescription == null)
                    {
                        result.ResultDescription = new ResultDescriptionDataType();
                    }
                    if (result.ResultDescription.ResultMeasure == null)
                    {
                        result.ResultDescription.ResultMeasure = new MeasureDataType();
                    }
                    result.ResultDescription.ResultMeasure.MeasureQualifierCode = array.Select(e => e.MeasureQualifierCode).ToArray();
                });
        }
        protected virtual string GenerateSubmissionFile(Submission_Type submissionType, object data)
        {
            AppendAuditLogEvent("Generating submission file from results");

            // Configure the submission header helper
            _headerDocumentHelper.Configure(ValidateNonEmptyConfigParameter(CONFIG_AUTHOR),
                                            ValidateNonEmptyConfigParameter(CONFIG_ORGANIZATION),
                                            WQX_FLOW_NAME, WQX_FLOW_NAME,
                                            ValidateNonEmptyConfigParameter(CONFIG_CONTACT_INFO),
                                            null);

            string tempXmlFilePath = _settingsProvider.NewTempFilePath();
            tempXmlFilePath = Path.ChangeExtension(tempXmlFilePath, ".xml");
            string tempXmlFilePath2 = _settingsProvider.NewTempFilePath();
            tempXmlFilePath2 = Path.ChangeExtension(tempXmlFilePath, ".xml");

            string tempZipFilePath = _settingsProvider.NewTempFilePath();
            tempZipFilePath = Path.ChangeExtension(tempZipFilePath, ".zip");

            try
            {
                _serializationHelper.Serialize(data, tempXmlFilePath);

                if (_validateXml)
                {
                    ValidateXmlFileAndAttachErrorsAndFileToTransaction(tempXmlFilePath, "xml_schema.xml_schema.zip",
                                                                       null, _dataRequest.TransactionId);
                }

                if (_addHeader)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(tempXmlFilePath);

                    _headerDocumentHelper.AddPayload(EnumUtils.ToDescription(submissionType),
                                                     doc.DocumentElement);

                    _headerDocumentHelper.Serialize(tempXmlFilePath2);

                    _compressionHelper.CompressFile(tempXmlFilePath2, tempZipFilePath);
                }
                else
                {
                    _compressionHelper.CompressFile(tempXmlFilePath, tempZipFilePath);
                }
                if (_wqxPluginMapper.AttachedBinaryFileCount > 0)
                {
                    AppendAuditLogEvent("Found {0} attached binary objects (with content) to submit",
                                        _wqxPluginMapper.AttachedBinaryFileCount.ToString());
                    _compressionHelper.CompressDirectory(tempZipFilePath, _wqxPluginMapper.AttachedBinaryObjectFolder);
                }
                return tempZipFilePath;
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteFile(tempZipFilePath);
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath);
                FileUtils.SafeDeleteFile(tempXmlFilePath2);
                if (_wqxPluginMapper.AttachedBinaryFileCount > 0)
                {
                    FileUtils.SafeDeleteDirectory(_wqxPluginMapper.AttachedBinaryObjectFolder);
                }
            }
        }
        protected string GenerateSubmissionFileAndSubmit(Submission_Type submissionType, object data)
        {
            string submitFile = GenerateSubmissionFileAndAddToTransaction(submissionType, data);
            if (_epaPartnerNode == null)
            {
                return string.Empty;
            }
            string transactionId;
            try
            {
                AppendAuditLogEvent("Submitting results to endpoint \"{0}\"",
                                          _epaPartnerNode.Name);
                string networkFlowName = WQX_FLOW_NAME, networkFlowOperation = null;
                try
                {
                    using (INodeEndpointClient endpointClient = _nodeEndpointClientFactory.Make(_epaPartnerNode.Url, _epaPartnerNode.Version))
                    {
                        if (endpointClient.Version == EndpointVersionType.EN20)
                        {
                            transactionId =
                                endpointClient.Submit(WQX_FLOW_NAME, "default",
                                                      string.Empty, new string[] { submitFile });
                            networkFlowOperation = "default";
                        }
                        else
                        {
                            transactionId =
                                endpointClient.Submit(WQX_FLOW_NAME, null, new string[] { submitFile });
                        }
                    }
                    AppendAuditLogEvent("Successfully submitted results to endpoint \"{0}\" with returned transaction id \"{1}\"",
                                              _epaPartnerNode.Name, transactionId);
                }
                catch (Exception e)
                {
                    AppendAuditLogEvent("Failed to submit results to endpoint \"{0}\": {1}",
                                        _epaPartnerNode.Name, ExceptionUtils.ToShortString(e));
                    throw;
                }
                _transactionManager.SetNetworkId(_dataRequest.TransactionId, transactionId, _epaPartnerNode.Version,
                                                 _epaPartnerNode.Url, networkFlowName, networkFlowOperation);
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to submit results to endpoint \"{0}\" with exception: {1}",
                                          _epaPartnerNode.Name, ExceptionUtils.ToShortString(e));
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(submitFile);
            }
            return transactionId;
        }
        protected string GenerateSubmissionFileAndAddToTransaction(Submission_Type submissionType, object data)
        {
            string submitFile = GenerateSubmissionFile(submissionType, data);
            try
            {
                try
                {
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
        protected bool UpdateTransactionStatus(string recordId, string localTransactionId)
        {
            try
            {
                CommonTransactionStatusCode statusCode = CommonTransactionStatusCode.Unknown;
                CDX_Processing_Status pendingStatus = CDX_Processing_Status.None;
                using (INodeEndpointClient endpointClient = _nodeEndpointClientFactory.Make(_epaPartnerNode.Url, _epaPartnerNode.Version))
                {
                    statusCode = endpointClient.GetStatus(localTransactionId);
                    // TODO: What status indicates success or failure?
                    if ((statusCode == CommonTransactionStatusCode.Processed) ||
                         (statusCode == CommonTransactionStatusCode.Completed))
                    {
                        pendingStatus = CDX_Processing_Status.Completed;
                    }
                    else if (statusCode == CommonTransactionStatusCode.Failed)
                    {
                        pendingStatus = CDX_Processing_Status.Failed;
                    }
                }
                AppendAuditLogEvent("Successfully got status from partner node \"{0}\" for transaction id \"{1}.\"  Status: \"{2}\"",
                                          _epaPartnerNode.Name, localTransactionId, statusCode.ToString());
                if (pendingStatus != CDX_Processing_Status.None)
                {
                    UpdateSubmissionStatus(recordId, pendingStatus);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                string message = string.Format("Failed to get status from partner node \"{0}\" for transaction id \"{1}.\"  Exception: {2}",
                                               _epaPartnerNode.Name, localTransactionId,
                                               ExceptionUtils.ToShortString(e));
                AppendAuditLogEvent(message);
                // Don't throw
                return false;
            }
        }
        public static int TotalResultCount(WQXDataType data)
        {
            int count = 0;
            if ((data != null) && (data.Organization != null) && (data.Organization.Activity != null))
            {
                foreach (Windsor.Node2008.WNOSPlugin.WQX3XsdOrm.ActivityDataType activity in data.Organization.Activity)
                {
                    count += (activity.Result == null) ? 0 : activity.Result.Length;
                }
            }
            return count;
        }
    }
}
