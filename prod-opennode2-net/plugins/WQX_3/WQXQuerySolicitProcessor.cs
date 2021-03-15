//#define DONT_USE_AUTH_FILE
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
using Windsor.Node2008.WNOSPlugin.WQX2XsdOrm;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.WQX3
{
    [Serializable]
    public class WQXQuerySolicitProcessor : WQXPluginBase, ISolicitProcessor, IQueryProcessor
    {
        #region fields
        protected const string AUTHORIZATION_FILE_PATH_KEY = "Authorization CSV File Path";

        protected Dictionary<string, List<string>> _authorizedWqxUsers;
        protected string _queryUsername;
        #endregion

        #region ISolicitProcessor Interface Implementation

        public WQXQuerySolicitProcessor()
        {
            ConfigurationArguments.Remove(CONFIG_EPA_PARTNER_NAME_KEY);
            ConfigurationArguments.Add(AUTHORIZATION_FILE_PATH_KEY, null);
            _addHeader = false;
            _useSubmissionHistoryTable = false;
        }

        protected override void LazyInit(bool validatePartnerName)
        {
            base.LazyInit(validatePartnerName);

            LoadWQXAuthorizationFile();
        }

        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);

            if (_authorizedWqxUsers != null)
            {
                _queryUsername = _transactionManager.GetTransactionUsername(_dataRequest.TransactionId);
                if (string.IsNullOrEmpty(_queryUsername))
                {
                    throw new ArgumentException("A query username is not associated with the transaction");
                }
                List<string> usernames = null;
                if (_authorizedWqxUsers.TryGetValue(_organizationIdentifier.ToUpper(), out usernames))
                {
                    if (!usernames.Contains("*") && !usernames.Contains(_queryUsername.ToUpper()))
                    {
                        string orgName = _settingsProvider.NodeOrganizationName;
                        throw new UnauthorizedAccessException(string.Format("The User \"{0}\" is not authorized to query data for WQX Organization ID \"{1}.\"  If you feel you have received this message in error, please contact the {2} for further assistance.",
                                                                            _queryUsername, _organizationIdentifier, orgName));
                    }
                }
                else if (_authorizedWqxUsers.TryGetValue("*", out usernames))
                {
                    if (!usernames.Contains("*") && !usernames.Contains(_queryUsername.ToUpper()))
                    {
                        string orgName = _settingsProvider.NodeOrganizationName;
                        throw new UnauthorizedAccessException(string.Format("The User \"{0}\" is not authorized to query data for WQX Organization ID \"{1}.\"  If you feel you have received this message in error, please contact the {2} for further assistance.",
                                                                            _queryUsername, _organizationIdentifier, orgName));
                    }
                }
                else
                {
                    string orgName = _settingsProvider.NodeOrganizationName;
                    throw new UnauthorizedAccessException(string.Format("The User \"{0}\" is not authorized to query data for WQX Organization ID \"{1}.\"  If you feel you have received this message in error, please contact the {2} for further assistance.",
                                                                        _queryUsername, _organizationIdentifier, orgName));
                }
            }
        }

        private void LoadWQXAuthorizationFile()
        {
#if DONT_USE_AUTH_FILE
#else // DONT_USE_AUTH_FILE
            string filePath = null;
            TryGetConfigParameter(AUTHORIZATION_FILE_PATH_KEY, ref filePath);
            _authorizedWqxUsers = WQXBaseAuthorizationPlugin.LoadWQXAuthorizationFile(this, filePath);
#endif // DONT_USE_AUTH_FILE
        }
        
        /// <summary>
        /// ProcessSolicit
        /// </summary>
        /// <param name="requestId"></param>
        public virtual void ProcessSolicit(string requestId)
        {
            ProcessQuerySolicitInit(requestId, false);
            _useSubmissionHistoryTable = false;

            string submitFile = null;
            try
            {
                object data = GetInsertUpdateData();

                submitFile = GenerateSubmissionFileAndAddToTransaction(Submission_Type.UpdateInsert, data);
            }
            finally
            {
                FileUtils.SafeDeleteFile(submitFile);
            }
        }

        /// <summary>
        /// ProcessSolicit
        /// </summary>
        /// <param name="requestId"></param>
        public virtual PaginatedContentResult ProcessQuery(string requestId)
        {
            ProcessQuerySolicitInit(requestId, false);
            _useSubmissionHistoryTable = false;

            string submitFile = null;
            try
            {
                object data = GetInsertUpdateData();

                submitFile = GenerateSubmissionFileAndAddToTransaction(Submission_Type.UpdateInsert, data);

                byte[] bytes = File.ReadAllBytes(submitFile);
                PaginatedContentResult result = new PaginatedContentResult(0, 1, true, CommonContentType.ZIP, bytes);
                return result;
            }
            finally
            {
                FileUtils.SafeDeleteFile(submitFile);
            }
        }
        protected override string GenerateSubmissionFile(Submission_Type submissionType, object data)
        {
            string filePath = base.GenerateSubmissionFile(submissionType, data);

            if ((submissionType == Submission_Type.Delete) || !(data is WQXDataType))
            {
                return filePath;
            }

            var wqxDataType = data as WQXDataType;

            ISettingsProvider settingsProvider;
            GetServiceImplementation(out settingsProvider);

            string attachedBinaryObjectFolder = Path.Combine(settingsProvider.TempFolderPath, Guid.NewGuid().ToString());

            int attachedBinaryFileCount = wqxDataType.WriteBinaryObjectDataToFolder(attachedBinaryObjectFolder);

            if (attachedBinaryFileCount > 0)
            {
                AppendAuditLogEvent("Found {0} attached binary objects (with content) to submit, building zip file for submission ...",
                                    attachedBinaryFileCount.ToString());
                //string tempZipFilePath = settingsProvider.NewTempFilePath(".zip");
                try
                {
                    //_compressionHelper.CompressFile(filePath, tempZipFilePath);
                    _compressionHelper.CompressDirectory(filePath, attachedBinaryObjectFolder);
                }
                catch (Exception)
                {
                    FileUtils.SafeDeleteFile(filePath);
                    throw;
                }
            }
            return filePath;
        }
        protected override object GetInsertUpdateData()
        {
            IObjectsFromDatabase objectsFromDatabase;
            GetServiceImplementation(out objectsFromDatabase);

            Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>();

            selectClauses.Add("WQX_ORGANIZATION",
                new DbAppendSelectWhereClause(_baseDao, "ORGID = ?", _organizationIdentifier));

            if ((_wqxStartDate != DateTime.MinValue) && (_wqxEndDate != DateTime.MinValue))
            {
                if (_wqxStartDate > _wqxEndDate)
                {
                    throw new ArgException("The query start date parameter must be less than or equal to the end date parameter");
                }
                AppendAuditLogEvent("Querying WQX data with OrgId \"{0}\", StartDate \"{1}\", and EndDate \"{1}\" ...",
                                    _organizationIdentifier, _wqxStartDate, _wqxEndDate);

                string activityElementSelect = "(ACTIVITYSTARTDATE >= ?) AND (ACTIVITYSTARTDATE <= ?) AND PARENTID IN (SELECT RECORDID FROM WQX_ORGANIZATION WHERE ORGID = ?)";
                string activityRecordIdsSelect = "SELECT RECORDID FROM WQX_ACTIVITY WHERE " + activityElementSelect;

                string biologicalElementSelect = "(INDEXCALCULATEDDATE >= ?) AND (INDEXCALCULATEDDATE <= ?) AND PARENTID IN (SELECT RECORDID FROM WQX_ORGANIZATION WHERE ORGID = ?)";
                string biologicalRecordIdsSelect = "SELECT RECORDID FROM WQX_BIOLOGICALHABITATINDEX WHERE " + biologicalElementSelect;
                
                string projectElementSelect =
                    string.Format("RECORDID IN (SELECT PROJECTPARENTID FROM WQX_PROJECTACTIVITY WHERE ACTIVITYPARENTID IN ({0}))",
                                  activityRecordIdsSelect);
                string activityGroupElementSelect =
                    string.Format("RECORDID IN (SELECT ACTIVITYGROUPPARENTID FROM WQX_ACTIVITYACTIVITYGROUP WHERE ACTIVITYPARENTID IN ({0}))",
                                  activityRecordIdsSelect);
                string monitoringLocationElementSelect =
                    string.Format("((MONITORINGLOCATIONID IN (SELECT MONLOCID FROM WQX_ACTIVITY WHERE {0})) OR (MONITORINGLOCATIONID IN (SELECT MONLOCID FROM WQX_BIOLOGICALHABITATINDEX WHERE {1})))",
                                  activityElementSelect, biologicalElementSelect);
                string resultElementSelect =
                    string.Format("PARENTID IN ({0})", activityRecordIdsSelect);
                selectClauses.Add("WQX_ACTIVITY",
                    new DbAppendSelectWhereClause(_baseDao, activityElementSelect, _wqxStartDate, _wqxEndDate, _organizationIdentifier));
                selectClauses.Add("WQX_PROJECT",
                    new DbAppendSelectWhereClause(_baseDao, projectElementSelect, _wqxStartDate, _wqxEndDate, _organizationIdentifier));
                selectClauses.Add("WQX_ACTIVITYGROUP",
                    new DbAppendSelectWhereClause(_baseDao, activityGroupElementSelect, _wqxStartDate, _wqxEndDate, _organizationIdentifier));
                selectClauses.Add("WQX_MONITORINGLOCATION",
                    new DbAppendSelectWhereClause(_baseDao, monitoringLocationElementSelect, _wqxStartDate, _wqxEndDate, _organizationIdentifier,
                                                  _wqxStartDate, _wqxEndDate, _organizationIdentifier));
                selectClauses.Add("WQX_BIOLOGICALHABITATINDEX",
                    new DbAppendSelectWhereClause(_baseDao, biologicalElementSelect, _wqxStartDate, _wqxEndDate, _organizationIdentifier));
                selectClauses.Add("WQX_RESULT",
                   new DbAppendSelectWhereClause(_baseDao, resultElementSelect, _wqxStartDate, _wqxEndDate, _organizationIdentifier));
            }
            else if (_activityStartDate == DateTime.MinValue)
            {
                AppendAuditLogEvent("Querying WQX data with OrgId \"{0}\" and WQXUpdateDate \"{1}\" ...", _organizationIdentifier, _wqxUpdateDate);

                string primaryElementSelect = "(WQXUPDATEDATE >= ?) AND PARENTID IN (SELECT RECORDID FROM WQX_ORGANIZATION WHERE ORGID = ?)";
                string activityGroupElementSelect = primaryElementSelect;
                string activityElementSelect =
                    string.Format("({0}) OR (RECORDID IN (SELECT ACTIVITYPARENTID FROM WQX_ACTIVITYACTIVITYGROUP WHERE ACTIVITYGROUPPARENTID IN (SELECT RECORDID FROM WQX_ACTIVITYGROUP WHERE {1})))",
                                  primaryElementSelect, activityGroupElementSelect);
                string resultElementSelect =
                    string.Format("PARENTID IN (SELECT RECORDID FROM WQX_ACTIVITY WHERE {0})",
                                  activityElementSelect);
                string projectElementSelect =
                    string.Format("({0}) OR (RECORDID IN (SELECT PROJECTPARENTID FROM WQX_PROJECTACTIVITY WHERE ACTIVITYPARENTID IN (SELECT RECORDID FROM WQX_ACTIVITY WHERE {1})))",
                                  primaryElementSelect, activityElementSelect);

                selectClauses.Add("WQX_ACTIVITYGROUP",
                    new DbAppendSelectWhereClause(_baseDao, activityGroupElementSelect, _wqxUpdateDate, _organizationIdentifier));
                selectClauses.Add("WQX_ACTIVITY",
                    new DbAppendSelectWhereClause(_baseDao, activityElementSelect, _wqxUpdateDate, _organizationIdentifier,
                                                  _wqxUpdateDate, _organizationIdentifier));
                selectClauses.Add("WQX_PROJECT",
                    new DbAppendSelectWhereClause(_baseDao, projectElementSelect, _wqxUpdateDate, _organizationIdentifier,
                                                  _wqxUpdateDate, _organizationIdentifier, _wqxUpdateDate, _organizationIdentifier));
                selectClauses.Add("WQX_MONITORINGLOCATION",
                    new DbAppendSelectWhereClause(_baseDao, primaryElementSelect, _wqxUpdateDate, _organizationIdentifier));
                selectClauses.Add("WQX_BIOLOGICALHABITATINDEX",
                    new DbAppendSelectWhereClause(_baseDao, primaryElementSelect, _wqxUpdateDate, _organizationIdentifier));
                selectClauses.Add("WQX_RESULT",
                    new DbAppendSelectWhereClause(_baseDao, resultElementSelect, _wqxUpdateDate, _organizationIdentifier,
                                                  _wqxUpdateDate, _organizationIdentifier));
            }
            else
            {
                AppendAuditLogEvent("Querying WQX data with OrgId \"{0}\" and ActivityStartDate \"{1}\" ...", _organizationIdentifier, _activityStartDate);

                string activityElementSelect = "(ACTIVITYSTARTDATE >= ?) AND PARENTID IN (SELECT RECORDID FROM WQX_ORGANIZATION WHERE ORGID = ?)";
                string activityRecordIdsSelect = "SELECT RECORDID FROM WQX_ACTIVITY WHERE " + activityElementSelect;
                string projectElementSelect =
                    string.Format("RECORDID IN (SELECT PROJECTPARENTID FROM WQX_PROJECTACTIVITY WHERE ACTIVITYPARENTID IN ({0}))",
                                  activityRecordIdsSelect);
                string activityGroupElementSelect =
                    string.Format("RECORDID IN (SELECT ACTIVITYGROUPPARENTID FROM WQX_ACTIVITYACTIVITYGROUP WHERE ACTIVITYPARENTID IN ({0}))",
                                  activityRecordIdsSelect);
                string monitoringLocationElementSelect =
                    string.Format("MONITORINGLOCATIONID IN (SELECT MONLOCID FROM WQX_ACTIVITY WHERE {0})",
                                  activityElementSelect);
                string biologicalHabitatElementSelect =
                    string.Format("MONLOCID IN (SELECT MONLOCID FROM WQX_ACTIVITY WHERE {0})",
                                  activityElementSelect);
                string resultElementSelect =
                    string.Format("PARENTID IN ({0})", activityRecordIdsSelect);
                selectClauses.Add("WQX_ACTIVITY", 
                    new DbAppendSelectWhereClause(_baseDao, activityElementSelect, _activityStartDate, _organizationIdentifier));
                selectClauses.Add("WQX_PROJECT",
                    new DbAppendSelectWhereClause(_baseDao, projectElementSelect, _activityStartDate, _organizationIdentifier));
                selectClauses.Add("WQX_ACTIVITYGROUP",
                    new DbAppendSelectWhereClause(_baseDao, activityGroupElementSelect, _activityStartDate, _organizationIdentifier));
                selectClauses.Add("WQX_MONITORINGLOCATION",
                    new DbAppendSelectWhereClause(_baseDao, monitoringLocationElementSelect, _activityStartDate, _organizationIdentifier));
                selectClauses.Add("WQX_BIOLOGICALHABITATINDEX",
                    new DbAppendSelectWhereClause(_baseDao, biologicalHabitatElementSelect, _activityStartDate, _organizationIdentifier));
                selectClauses.Add("WQX_RESULT",
                   new DbAppendSelectWhereClause(_baseDao, resultElementSelect, _activityStartDate, _organizationIdentifier));
            }
            List<WQXDataType> dataList = objectsFromDatabase.LoadFromDatabase<WQXDataType>(_baseDao, selectClauses);

            if (CollectionUtils.IsNullOrEmpty(dataList))
            {
                return new WQXDataType();
            }
            else if (dataList.Count > 1)
            {
                throw new ArgumentException(string.Format("More than one set of data was found for WQX organization '{0}'",
                                                          _organizationIdentifier));
            }
            else
            {
                WQXDataType data = dataList[0];
                AppendAuditLogEvent("Found {0} Projects, {1} Activities, {2} Biological Habitat Indexes, {3} Monitoring Locations, {4} Activity Groups, and {5} Results that matched the query", 
                                    CollectionUtils.Count(data.Organization.Project).ToString(),
                                    CollectionUtils.Count(data.Organization.Activity).ToString(),
                                    CollectionUtils.Count(data.Organization.BiologicalHabitatIndex).ToString(),
                                    CollectionUtils.Count(data.Organization.MonitoringLocation).ToString(),
                                    CollectionUtils.Count(data.Organization.ActivityGroup).ToString(),
                                    TotalResultCount(data).ToString());
                return dataList[0];
            }
        }
        /// <summary>
        /// Return the Query, Solicit, or Execute data service parameters for specified data service.
        /// This method should NOT call GetServiceImplementation().
        /// </summary>
        public override IList<TypedParameter> GetDataServiceParameters(string serviceName, out DataServicePublishFlags publishFlags)
        {
            List<TypedParameter> list = (List<TypedParameter>) base.GetDataServiceParameters(serviceName, out publishFlags);
            publishFlags = DataServicePublishFlags.PublishToEndpointVersion11And20;
            list.Add(new TypedParameter("ActivityStartDate", "Data will be returned where Activity Start Date is equal to or later than this date", false, typeof(DateTime), true));
            return list;
        }
        #endregion
    }
}
