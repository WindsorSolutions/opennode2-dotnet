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

namespace Windsor.Node2008.WNOSPlugin.WQX2
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
            WQX_ACTIVITYCONDUCTINGORG,
            WQX_PROJECTACTIVITY,
            WQX_ACTIVITYMETRIC,
            WQX_MONITORINGLOCATION,
            WQX_DELETES,
        }
        protected enum Submission_Type
        {
            [Description("Update-Insert")]
            UpdateInsert,
            [Description("Delete")]
            Delete
        }
        protected enum CDX_Processing_Status
        {
            None,
            [Description("Pending")]
            Pending,
            [Description("Failed")]
            Failed,
            [Description("Completed")]
            Completed,
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

        protected const string PARAM_ORGANIZATION_IDENTIFIER_KEY = "OrganizationIdentifier";
        protected const string PARAM_ADD_HEADER_KEY = "AddHeader";
        protected const string PARAM_USE_SUBMISSION_HISTORY_TABLE_KEY = "UseSubmissionHistoryTable";
        protected const string PARAM_WQX_UPDATE_DATE_KEY = "WQXUpdateDate";
        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        // TODO: What are the correct names for these values
        protected const string DELETE_PROJECT_COMP_NAME = "PROJECT";
        protected const string DELETE_ACTIVITY_COMP_NAME = "ACTIVITY";
        protected const string DELETE_MONITORING_LOC_COMP_NAME = "MONITORINGLOCATION";
        protected const string DELETE_ACTIVITY_GROUP_COMP_NAME = "ACTIVITYGROUP";
        protected const string DELETE_BIOLOGICAL_HABITAT_INDEX_COMP_NAME = "BIOLOGICALHABITATINDEX";

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
        protected DataRequest _dataRequest;
        protected PartnerIdentity _epaPartnerNode;
        protected SpringBaseDao _baseDao;
        protected IdProvider _idProvider;
        protected bool _addHeader = true;
        protected bool _useSubmissionHistoryTable = true;

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
        }
        /// <summary>
        /// ProcessSolicit
        /// </summary>
        public virtual void ProcessSolicitInit(string requestId, bool validatePartnerName)
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

            if (validatePartnerName)
            {
                string epaPartnerName = ValidateNonEmptyConfigParameter(CONFIG_EPA_PARTNER_NAME_KEY);
                _epaPartnerNode = _partnerManager.GetByName(epaPartnerName);
                if (_epaPartnerNode == null)
                {
                    throw new ArgumentException(string.Format("The node partner \"{0}\" with the name \"{1}\" specified for this service cannot be found",
                                                              CONFIG_EPA_PARTNER_NAME_KEY, epaPartnerName));
                }
            }

            _baseDao = ValidateDBProvider(SOURCE_PROVIDER_KEY, typeof(NamedNullMappingDataReader));
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);

            if (_dataRequest.Parameters.IsByName)
            {
                GetParameterByName(_dataRequest, PARAM_ORGANIZATION_IDENTIFIER_KEY, out _organizationIdentifier);
                TryGetParameterByName(_dataRequest, PARAM_WQX_UPDATE_DATE_KEY, ref _wqxUpdateDate);
                TryGetParameterByName(_dataRequest, PARAM_ADD_HEADER_KEY, ref _addHeader);
                TryGetParameterByName(_dataRequest, PARAM_USE_SUBMISSION_HISTORY_TABLE_KEY, ref _useSubmissionHistoryTable);
            }
            else
            {
                GetParameterByIndex(_dataRequest, 0, out _organizationIdentifier);
                TryGetParameterByIndex(_dataRequest, 1, ref _wqxUpdateDate);
                TryGetParameterByIndex(_dataRequest, 2, ref _addHeader);
                TryGetParameterByIndex(_dataRequest, 3, ref _useSubmissionHistoryTable);
            }
            AppendAuditLogEvent("Running submission for organization \"{0}\"",
                                      _organizationIdentifier);
        }
        /// <summary>
        /// Return the Query, Solicit, or Execute data service parameters for specified data service.
        /// This method should NOT call GetServiceImplementation().
        /// </summary>
        public override IList<TypedParameter> GetDataServiceParameters(string serviceName, out DataServicePublishFlags publishFlags)
        {
            publishFlags = DataServicePublishFlags.DoNotPublish;
            List<TypedParameter> list = new List<TypedParameter>(2);
            list.Add(new TypedParameter("OrganizationIdentifier", "The indentifier of the organization for which data will be returned", true, typeof(string), true));
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
                    "RECORDID;PARENTID;SCHEDULERUNDATE;WQXUPDATEDATE;SUBMISSIONTYPE;LOCALTRANSACTIONID;CDXPROCESSINGSTATUS",
                    new object[] { recordId, _organizationRecordId, DateTime.Now, _wqxUpdateDate, 
                                   EnumUtils.ToDescription(submissionType), string.Empty,
                                   EnumUtils.ToDescription(CDX_Processing_Status.Pending) }
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
            if (_useSubmissionHistoryTable)
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
        protected virtual WQXDataType GetInsertUpdateData()
        {
            WQXDataType data = new WQXDataType();
            data.Organization = new OrganizationDataType();

            data.Organization.OrganizationDescription = GetOrganizationDescription();

            data.Organization.OrganizationAddress = GetOrganizationAddress();

            data.Organization.ElectronicAddress = GetOrganizationElectronicAddress();

            data.Organization.Telephonic = GetOrganizationTelephonic();

            data.Organization.Project = GetOrganizationProjects();

            data.Organization.Activity = GetOrganizationActivities();

            data.Organization.MonitoringLocation = GetOrganizationMonitoringLocations();

            return data;
        }
        protected virtual WQXDeleteDataType GetDeleteData()
        {
            WQXDeleteDataType data = new WQXDeleteDataType();
            data.OrganizationDelete = new OrganizationDeleteDataType[1];
            data.OrganizationDelete[0] = new OrganizationDeleteDataType();
            // Get _organizationRecordId:
            OrganizationDescriptionDataType desc = GetOrganizationDescription();
            data.OrganizationDelete[0].OrganizationIdentifier = desc.OrganizationIdentifier;

            List<string> projectIds = null;
            List<string> activityIds = null;
            List<string> monitoringLocIds = null;

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
                    if (componentName == DELETE_PROJECT_COMP_NAME)
                    {
                        if (projectIds == null) projectIds = new List<string>();
                        projectIds.Add(componentId);
                    }
                    else if (componentName == DELETE_ACTIVITY_COMP_NAME)
                    {
                        if (activityIds == null) activityIds = new List<string>();
                        activityIds.Add(componentId);
                    }
                    else if (componentName == DELETE_MONITORING_LOC_COMP_NAME)
                    {
                        if (monitoringLocIds == null) monitoringLocIds = new List<string>();
                        monitoringLocIds.Add(componentId);
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
            AppendAuditLogEvent(sb.ToString());
            data.OrganizationDelete[0].ProjectIdentifier = WQXPluginMappers.ToArray(projectIds);
            data.OrganizationDelete[0].ActivityIdentifier = WQXPluginMappers.ToArray(activityIds);
            data.OrganizationDelete[0].MonitoringLocationIdentifier = WQXPluginMappers.ToArray(monitoringLocIds);
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
                throw new ArgumentException(string.Format("The organization \"{0}\" was not found in the staging database",
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
                    organizationDescriptionDataType = WQXPluginMappers.MapOrganizationDescription(readerEx);
                });

            if (organizationDescriptionDataType == null)
            {
                throw new ArgumentException(string.Format("The organization \"{0}\" was not found in the staging database",
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
                    OrganizationAddressDataType address = WQXPluginMappers.MapOrganizationAddress(readerEx);
                    if (addresses == null) addresses = new List<OrganizationAddressDataType>();
                    addresses.Add(address);
                });
            return WQXPluginMappers.ToArray(addresses);
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
                    ElectronicAddressDataType address = WQXPluginMappers.MapElectronicAddress(readerEx);
                    if (electronicAddresses == null) electronicAddresses = new List<ElectronicAddressDataType>();
                    electronicAddresses.Add(address);
                });
            return WQXPluginMappers.ToArray(electronicAddresses);
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
                    TelephonicDataType telephonic = WQXPluginMappers.MapTelephonic(readerEx);
                    if (telephonics == null) telephonics = new List<TelephonicDataType>();
                    telephonics.Add(telephonic);
                });
            return WQXPluginMappers.ToArray(telephonics);
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
                    ProjectDataType project = WQXPluginMappers.MapProject(readerEx);
                    if (projects == null) projects = new List<ProjectDataType>();
                    projects.Add(project);
                });
            if (projects != null)
            {
                AppendAuditLogEvent("Found {0} updated projects to submit",
                                          projects.Count.ToString());
                GetProjectMonitoringLocationWeighting(projectRecordIds, projects);
            }
            else
            {
                AppendAuditLogEvent("Didn't find any updated projects to submit");
            }
            return WQXPluginMappers.ToArray(projects);
        }
        protected virtual void GetProjectMonitoringLocationWeighting(IList<string> projectRecordIds, 
                                                                     IList<ProjectDataType> projects)
        {
            string selectText =
                string.Format("SELECT pml.* FROM WQX_PROJECTMONLOC pml, WQX_PROJECT p WHERE " +
                              "p.PARENTID = '{0}' AND p.WQXUPDATEDATE > '{1}' AND p.RECORDID = pml.PARENTID",
                               _organizationRecordId, WQXPluginMappers.ToDbString(_wqxUpdateDate));
            _baseDao.MapArrayObjects<ProjectMonitoringLocationWeightingDataType>(
                "PARENTID", projectRecordIds, selectText, WQXPluginMappers.MapProjectMonitoringLocationWeighting,
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
                    ActivityDataType activity = WQXPluginMappers.MapActivity(readerEx);
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
                GetActivityResult(activityRecordIds, activities);
            } else {
                AppendAuditLogEvent("Didn't find any updated activities to submit");
            }
            return WQXPluginMappers.ToArray(activities);
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
                    MonitoringLocationDataType location = WQXPluginMappers.MapMonitoringLocation(readerEx);
                    if (locations == null) locations = new List<MonitoringLocationDataType>();
                    locations.Add(location);
                });
            if (locations != null)
            {
                AppendAuditLogEvent("Found {0} updated monitoring locations to submit",
                                          locations.Count.ToString());
                GetAltMonLoc(locationRecordIds, locations);
            }
            else
            {
                AppendAuditLogEvent("Didn't find any updated monitoring locations to submit");
            }
            return WQXPluginMappers.ToArray(locations);
        }
        protected virtual void GetAltMonLoc(IList<string> locationRecordIds,
                                            IList<MonitoringLocationDataType> locations)
        {
            string selectText =
                string.Format("SELECT aml.* FROM WQX_ALTMONLOC aml, WQX_MONITORINGLOCATION ml WHERE " +
                              "ml.PARENTID = '{0}' AND ml.WQXUPDATEDATE > '{1}' AND ml.RECORDID = aml.PARENTID",
                               _organizationRecordId, WQXPluginMappers.ToDbString(_wqxUpdateDate));
            _baseDao.MapArrayObjects<AlternateMonitoringLocationIdentityDataType>(
                "PARENTID", locationRecordIds, selectText, WQXPluginMappers.MapAlternateMonitoringLocationIdentity,
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
                               _organizationRecordId, WQXPluginMappers.ToDbString(_wqxUpdateDate));
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
                               _organizationRecordId, WQXPluginMappers.ToDbString(_wqxUpdateDate));
            _baseDao.MapArrayObjects<string>(
                "ACTIVITYPARENTID", activityRecordIds, selectText, MapActivityProjectIdentifier,
                delegate(string[] array, int listKeyFieldsIndex)
                {
                    activities[listKeyFieldsIndex].ActivityDescription.ProjectIdentifier = array;
                });
        }
        protected virtual void GetActivityActivityMetric(IList<string> activityRecordIds,
                                                         IList<ActivityDataType> activities)
        {
            string selectText =
                string.Format("SELECT am.* FROM WQX_ACTIVITYMETRIC am, WQX_ACTIVITY a WHERE " +
                              "a.PARENTID = '{0}' AND a.WQXUPDATEDATE > '{1}' AND am.PARENTID = a.RECORDID",
                               _organizationRecordId, WQXPluginMappers.ToDbString(_wqxUpdateDate));
            _baseDao.MapArrayObjects<ActivityMetricDataType>(
                "PARENTID", activityRecordIds, selectText, WQXPluginMappers.MapActivityMetric,
                delegate(ActivityMetricDataType[] array, int listKeyFieldsIndex)
                {
                    activities[listKeyFieldsIndex].ActivityMetric = array;
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
                               _organizationRecordId, WQXPluginMappers.ToDbString(_wqxUpdateDate));
            _baseDao.MapArrayObjects<ResultDataType>(
                "PARENTID", activityRecordIds, selectText, WQXPluginMappers.MapResult,
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
            }
        }
        protected virtual void GetResultLabSamplePrep(IList<string> resultRecordIds,
                                                      IList<ResultDataType> results)
        {
            string selectText =
                string.Format("SELECT lsp.* FROM WQX_LABSAMPLEPREP lsp, WQX_RESULT r, WQX_ACTIVITY a WHERE " +
                              "a.PARENTID = '{0}' AND a.WQXUPDATEDATE > '{1}' AND lsp.PARENTID = r.RECORDID AND " +
                              "r.PARENTID = a.RECORDID",
                               _organizationRecordId, WQXPluginMappers.ToDbString(_wqxUpdateDate));
            _baseDao.MapArrayObjects<LabSamplePreparationDataType>(
                "PARENTID", resultRecordIds, selectText, WQXPluginMappers.MapLabSamplePreparation,
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
                               _organizationRecordId, WQXPluginMappers.ToDbString(_wqxUpdateDate));
            _baseDao.MapArrayObjects<DetectionQuantitationLimitDataType>(
                "PARENTID", resultRecordIds, selectText, WQXPluginMappers.MapDetectionQuantitationLimit,
                delegate(DetectionQuantitationLimitDataType[] array, int listKeyFieldsIndex)
                {
                    results[listKeyFieldsIndex].ResultLabInformation.ResultDetectionQuantitationLimit = array;
                });
        }
        protected string GenerateSubmissionFile(Submission_Type submissionType, object data)
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
            }
        }
        protected string GenerateSubmissionFileAndSubmit(WQXDataType data)
        {
            return GenerateSubmissionFileAndSubmit(Submission_Type.UpdateInsert, data);
        }
        protected string GenerateSubmissionFileAndSubmit(WQXDeleteDataType data)
        {
            return GenerateSubmissionFileAndSubmit(Submission_Type.Delete, data);
        }
        protected string GenerateSubmissionFileAndSubmit(Submission_Type submissionType, object data)
        {
            string submitFile = GenerateSubmissionFileAndAddToTransaction(submissionType, data);
            string transactionId;
            try
            {
                AppendAuditLogEvent("Submitting results to endpoint \"{0}\"",
                                          _epaPartnerNode.Name);
                using (INodeEndpointClient endpointClient = _nodeEndpointClientFactory.Make(_epaPartnerNode.Url, _epaPartnerNode.Version))
                {
                    if (endpointClient.Version == EndpointVersionType.EN20)
                    {
                        transactionId =
                            endpointClient.Submit(WQX_FLOW_NAME, "default",
                                                  string.Empty, new string[] { submitFile });
                    }
                    else
                    {
                        transactionId =
                            endpointClient.Submit(WQX_FLOW_NAME, null, new string[] { submitFile });
                    }
                }
                AppendAuditLogEvent("Successfully submitted results to endpoint \"{0}\" with returned transaction id \"{1}\"",
                                          _epaPartnerNode.Name, transactionId);
                _transactionManager.SetNetworkId(_dataRequest.TransactionId, transactionId, _epaPartnerNode.Version, 
                                                 _epaPartnerNode.Url);
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
                    AppendAuditLogEvent("Failed to attach submission document \"{0}\" to transaction \"{1}\" with exception: {1}",
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
                    if ( (statusCode == CommonTransactionStatusCode.Processed) ||
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
    }
}
