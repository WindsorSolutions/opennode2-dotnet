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
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.P2R
{
    [Serializable]
    public class P2RSolicitQuerySubmissionProcessor : P2RPluginBase, ISolicitProcessor
    {
        #region fields
        protected const string CONFIG_AUTHOR = "Author";
        protected const string CONFIG_ORGANIZATION = "Organization";
        protected const string CONFIG_CONTACT_INFO = "Contact Info";
        protected const string CONFIG_IDENTIFYING_ORGANIZATION = "Identifying Organization";
        protected bool _addHeader = true;

        protected IRequestManager _requestManager;
        protected DataRequest _dataRequest;

        protected const string PARAM_YEAR_KEY = "Year";
        protected const string PARAM_ADD_HEADER_KEY = "AddHeader";
        #endregion

        public P2RSolicitQuerySubmissionProcessor()
        {
            ConfigurationArguments.Add(CONFIG_IDENTIFYING_ORGANIZATION, null);
            ConfigurationArguments.Add(CONFIG_AUTHOR, null);
            ConfigurationArguments.Add(CONFIG_ORGANIZATION, null);
            ConfigurationArguments.Add(CONFIG_CONTACT_INFO, null);
        }
        public void ProcessSolicit(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);

            ValidateOrganization();

            ProgramListType data = GetProgramListData();

            GenerateSubmissionFileAndAddToTransaction(data);
        }
        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _requestManager);

            ValidateNonEmptyConfigParameter(CONFIG_AUTHOR);
            ValidateNonEmptyConfigParameter(CONFIG_ORGANIZATION);
            ValidateNonEmptyConfigParameter(CONFIG_CONTACT_INFO);

            _organizationIdentifier = ValidateNonEmptyConfigParameter(CONFIG_IDENTIFYING_ORGANIZATION);
            if (_organizationIdentifier == null)
            {
                throw new ArgumentException(string.Format("Missing \"{0}\" configuration parameter specified for this service",
                                                          CONFIG_IDENTIFYING_ORGANIZATION));
            }
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            TryGetParameterByName(_dataRequest, PARAM_YEAR_KEY, ref _year);
            TryGetParameterByName(_dataRequest, PARAM_ADD_HEADER_KEY, ref _addHeader);

            if ( (_year != 0) && ((_year < MIN_YEAR) || (_year > MAX_YEAR)))
            {
                throw new ArgumentException(string.Format("Invalid \"{0}\" parameter specified: \"{1}\"",
                                                          PARAM_YEAR_KEY, _year.ToString()));
            }
        }
        protected virtual ProgramDetailsDataType[] GetProgramDetails()
        {
            List<ProgramDetailsDataType> programDetails = null;
            List<string> programDetailsRecordIds = null;
            _baseDao.DoSimpleQueryWithRowCallbackDelegate(
                Tables.P2R_PROGRAM_DETAILS.ToString(),
                "ORG_ID",
                new object[] { _organizationIdentifier },
                delegate(IDataReader reader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)reader;
                    if (programDetailsRecordIds == null) programDetailsRecordIds = new List<string>();
                    programDetailsRecordIds.Add(readerEx.GetString("PROGRAM_DETAILS_ID"));
                    ProgramDetailsDataType programDetail = P2RPluginMappers.MapProgramDetails(readerEx);
                    if (programDetails == null) programDetails = new List<ProgramDetailsDataType>();
                    programDetails.Add(programDetail);
                });
            if (programDetails != null)
            {
                GetProjectDetails(programDetailsRecordIds, programDetails);

                if (_year != 0)
                {
                    // Remove any programs that do not have associated projects
                    for (int i = programDetails.Count - 1; i >= 0; --i)
                    {
                        if (CollectionUtils.IsNullOrEmpty(programDetails[i].ProjectDetails))
                        {
                            programDetails.RemoveAt(i);
                        }
                    }
                }

                if (programDetails.Count == 0)
                {
                    programDetails = null;
                    AppendAuditLogEvent("Didn't find any program details");
                }
                else
                {
                    AppendAuditLogEvent("Found {0} program details",
                                              programDetails.Count.ToString());
                }
            }
            else
            {
                AppendAuditLogEvent("Didn't find any program details");
            }
            return P2RPluginMappers.ToArray(programDetails);
        }
        protected virtual void GenerateSubmissionFileAndAddToTransaction(ProgramListType data)
        {
            string submitFile = GenerateSubmissionFile(_year, data);
            try
            {
                try
                {
                    _documentManager.AddDocument(_dataRequest.TransactionId, CommonTransactionStatusCode.Completed,
                                                 null, submitFile);
                }
                catch (Exception e)
                {
                    AppendAuditLogEvent("Failed to attach submission document \"{0}\" to transaction \"{1}\" with exception: {2}",
                                              submitFile, _dataRequest.TransactionId, ExceptionUtils.ToShortString(e));
                    throw;
                }
            }
            finally
            {
                FileUtils.SafeDeleteFile(submitFile);
            }
        }
        protected virtual string GenerateSubmissionFile(int year, ProgramListType data)
        {
            AppendAuditLogEvent("Generating submission file from results");

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
                    // Configure the submission header helper
                    _headerDocumentHelper.Configure(ValidateNonEmptyConfigParameter(CONFIG_AUTHOR),
                                                    ValidateNonEmptyConfigParameter(CONFIG_ORGANIZATION),
                                                    P2R_FLOW_NAME, null,
                                                    ValidateNonEmptyConfigParameter(CONFIG_CONTACT_INFO),
                                                    null);
                    _headerDocumentHelper.AddPropery(ORG_ID_PROP_NAME, _organizationIdentifier);

                    XmlDocument doc = new XmlDocument();
                    doc.Load(tempXmlFilePath);

                    string operation;
                    if (year == 0)
                    {
                        operation = FULL_REPLACE_OPERATION;
                    }
                    else
                    {
                        operation = YEAR_OPERATION + year.ToString();
                    }
                    _headerDocumentHelper.AddPayload(operation, doc.DocumentElement);

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
        protected virtual void ValidateOrganization()
        {
            bool foundIt = false;
            _baseDao.DoSimpleQueryWithRowCallbackDelegate(
                Tables.P2R_ORG.ToString(),
                "ORG_ID",
                _organizationIdentifier,
                "ORG_ID",
                delegate(IDataReader reader)
                {
                    foundIt = true;
                });

            if (!foundIt)
            {
                throw new ArgumentException(string.Format("The organization \"{0}\" was not found",
                                                          _organizationIdentifier));
            }
            _projectDetailsWhereQuery =
                string.Format("program.ORG_ID = '{0}' AND project.PROGRAM_DETAILS_ID = program.PROGRAM_DETAILS_ID",
                              _organizationIdentifier);
            if (_year != 0)
            {
                _projectDetailsWhereQuery += string.Format(" AND project.PROJECT_START_DATE >= '{0}' AND project.PROJECT_START_DATE < '{1}'",
                                                           new DateTime(_year, 1, 1, 0, 0, 0).ToString(),
                                                           new DateTime(_year + 1, 1, 1, 0, 0, 0).ToString());
            }
        }
        protected virtual ProgramListType GetProgramListData()
        {
            ProgramListType programList = new ProgramListType();

            programList.ProgramDetails = GetProgramDetails();

            return programList;
        }
        protected virtual void GetProjectDetails(IList<string> programDetailsRecordIds,
                                                 IList<ProgramDetailsDataType> programs)
        {
            string selectText =
                string.Format("SELECT project.* FROM P2R_PROJECT_DETAILS project, P2R_PROGRAM_DETAILS program WHERE {0}",
                              _projectDetailsWhereQuery);
            Dictionary<string, ProjectDetailsDataType> idToProjectDetailsMap =
                _baseDao.MapArrayObjects<ProjectDetailsDataType>(
                "PROGRAM_DETAILS_ID", programDetailsRecordIds, selectText,
                P2RPluginMappers.MapProjectDetails, "PROJECT_DETAILS_ID",
                delegate(ProjectDetailsDataType[] array, int listKeyFieldsIndex)
                {
                    programs[listKeyFieldsIndex].ProjectDetails = array;
                });

            FillProjectDetails(idToProjectDetailsMap);
        }
        protected virtual void FillProjectDetails(Dictionary<string, ProjectDetailsDataType> idToProjectDetailsMap)
        {
            if (CollectionUtils.IsNullOrEmpty(idToProjectDetailsMap))
            {
                return;
            }
            string selectText =
                string.Format("SELECT am.* FROM P2R_ACTIVITY_MEASURE am, P2R_PROJECT_DETAILS project, P2R_PROGRAM_DETAILS program WHERE " +
                              "{0} AND am.PROJECT_DETAILS_ID = project.PROJECT_DETAILS_ID",
                              _projectDetailsWhereQuery);

            {
                Dictionary<string, ActivityMeasureDataType> activityMeasureMap =
                    _baseDao.MapArrayObjects<ActivityMeasureDataType>(
                    "PROJECT_DETAILS_ID", idToProjectDetailsMap.Keys, selectText,
                    P2RPluginMappers.MapActivityMeasure, "ACTIVITY_MEASURE_ID",
                    delegate(ActivityMeasureDataType[] array, int listKeyFieldsIndex)
                    {
                        ProjectDetailsDataType projectDetails =
                            idToProjectDetailsMap[CollectionUtils.NthItem(idToProjectDetailsMap.Keys, listKeyFieldsIndex)];
                        projectDetails.ActivityMeasure = array;
                    });

                if (!CollectionUtils.IsNullOrEmpty(activityMeasureMap))
                {
                    selectText =
                        string.Format("SELECT amqr.* FROM P2R_ACTIVITY_MEASURE_QNT_RSLT amqr, P2R_ACTIVITY_MEASURE am, P2R_PROJECT_DETAILS project, P2R_PROGRAM_DETAILS program WHERE " +
                                      "{0} AND am.PROJECT_DETAILS_ID = project.PROJECT_DETAILS_ID AND am.ACTIVITY_MEASURE_ID = amqr.ACTIVITY_MEASURE_ID",
                                      _projectDetailsWhereQuery);
                    _baseDao.MapArrayObjects<ActivityMeasureQuantitativeResultDataType>(
                        "ACTIVITY_MEASURE_ID", activityMeasureMap.Keys, selectText,
                        P2RPluginMappers.MapActivityMeasureQuantitativeResultDataType,
                        delegate(ActivityMeasureQuantitativeResultDataType[] array, int listKeyFieldsIndex)
                        {
                            ActivityMeasureDataType activityMeasure =
                                activityMeasureMap[CollectionUtils.NthItem(activityMeasureMap.Keys, listKeyFieldsIndex)];
                            activityMeasure.QuantitativeResult = array;
                        });
                }
            }

            selectText =
                    string.Format("SELECT pds.* FROM P2R_PROJECT_DETAILS_SECTOR pds, P2R_PROJECT_DETAILS project, P2R_PROGRAM_DETAILS program WHERE " +
                                  "{0} AND pds.PROJECT_DETAILS_ID = project.PROJECT_DETAILS_ID",
                                  _projectDetailsWhereQuery);

            _baseDao.MapArrayObjects<ProjectDetailsSectorDataType>(
                "PROJECT_DETAILS_ID", idToProjectDetailsMap.Keys, selectText,
                P2RPluginMappers.MapSectorText,
                delegate(ProjectDetailsSectorDataType[] array, int listKeyFieldsIndex)
                {
                    ProjectDetailsDataType projectDetails =
                        idToProjectDetailsMap[CollectionUtils.NthItem(idToProjectDetailsMap.Keys, listKeyFieldsIndex)];
                    projectDetails.SectorText = array;
                });

            selectText =
                string.Format("SELECT i.* FROM P2R_INVESTMENT i, P2R_PROJECT_DETAILS project, P2R_PROGRAM_DETAILS program WHERE " +
                              "{0} AND i.PROJECT_DETAILS_ID = project.PROJECT_DETAILS_ID",
                              _projectDetailsWhereQuery);

            _baseDao.MapArrayObjects<InvestmentDataType>(
                "PROJECT_DETAILS_ID", idToProjectDetailsMap.Keys, selectText,
                P2RPluginMappers.MapInvestment,
                delegate(InvestmentDataType[] array, int listKeyFieldsIndex)
                {
                    ProjectDetailsDataType projectDetails =
                        idToProjectDetailsMap[CollectionUtils.NthItem(idToProjectDetailsMap.Keys, listKeyFieldsIndex)];
                    projectDetails.Investment = array;
                });

            selectText =
                string.Format("SELECT bc.* FROM P2R_BEHAVIORAL_CHANGE bc, P2R_PROJECT_DETAILS project, P2R_PROGRAM_DETAILS program WHERE " +
                              "{0} AND bc.PROJECT_DETAILS_ID = project.PROJECT_DETAILS_ID",
                              _projectDetailsWhereQuery);
            {
                Dictionary<string, BehavioralChangeDataType> behavioralChangeMap =
                    _baseDao.MapArrayObjects<BehavioralChangeDataType>(
                            "PROJECT_DETAILS_ID", idToProjectDetailsMap.Keys, selectText,
                            P2RPluginMappers.MapBehavioralChange, "BEHAVIORAL_CHANGE_ID",
                            delegate(BehavioralChangeDataType[] array, int listKeyFieldsIndex)
                            {
                                ProjectDetailsDataType projectDetails =
                                    idToProjectDetailsMap[CollectionUtils.NthItem(idToProjectDetailsMap.Keys, listKeyFieldsIndex)];
                                projectDetails.BehavioralChange = array;
                            });

                if (!CollectionUtils.IsNullOrEmpty(behavioralChangeMap))
                {
                    selectText =
                        string.Format("SELECT bcqr.* FROM P2R_BEHAVIORAL_CHANGE_QNT_RSLT bcqr, P2R_BEHAVIORAL_CHANGE bc, P2R_PROJECT_DETAILS project, P2R_PROGRAM_DETAILS program WHERE " +
                                      "{0} AND bc.PROJECT_DETAILS_ID = project.PROJECT_DETAILS_ID AND bc.BEHAVIORAL_CHANGE_ID = bcqr.BEHAVIORAL_CHANGE_ID",
                                      _projectDetailsWhereQuery);
                    _baseDao.MapArrayObjects<BehavioralChangeQuantitativeResultDataType>(
                        "BEHAVIORAL_CHANGE_ID", behavioralChangeMap.Keys, selectText,
                        P2RPluginMappers.MapBehavioralChangeQuantitativeResultDataType,
                        delegate(BehavioralChangeQuantitativeResultDataType[] array, int listKeyFieldsIndex)
                        {
                            BehavioralChangeDataType behavioralChange =
                                behavioralChangeMap[CollectionUtils.NthItem(behavioralChangeMap.Keys, listKeyFieldsIndex)];
                            behavioralChange.QuantitativeResult = array;
                        });
                }
            }
            selectText =
               string.Format("SELECT om.* FROM P2R_OUTCOME_MEASURE om, P2R_PROJECT_DETAILS project, P2R_PROGRAM_DETAILS program WHERE " +
                             "{0} AND om.PROJECT_DETAILS_ID = project.PROJECT_DETAILS_ID",
                             _projectDetailsWhereQuery);
            {
                Dictionary<string, OutcomeMeasureDataType> outcomeMeasureMap =
                   _baseDao.MapArrayObjects<OutcomeMeasureDataType>(
                        "PROJECT_DETAILS_ID", idToProjectDetailsMap.Keys, selectText,
                        P2RPluginMappers.MapOutcomeMeasure, "OUTCOME_MEASURE_ID",
                        delegate(OutcomeMeasureDataType[] array, int listKeyFieldsIndex)
                        {
                            ProjectDetailsDataType projectDetails =
                                idToProjectDetailsMap[CollectionUtils.NthItem(idToProjectDetailsMap.Keys, listKeyFieldsIndex)];
                            projectDetails.OutcomeMeasure = array;
                        });
                if (!CollectionUtils.IsNullOrEmpty(outcomeMeasureMap))
                {
                    selectText =
                        string.Format("SELECT omr.* FROM P2R_OUTCOME_MEASURE_RESULT omr, P2R_OUTCOME_MEASURE om, P2R_PROJECT_DETAILS project, P2R_PROGRAM_DETAILS program WHERE " +
                                      "{0} AND om.PROJECT_DETAILS_ID = project.PROJECT_DETAILS_ID AND om.OUTCOME_MEASURE_ID = omr.OUTCOME_MEASURE_ID",
                                      _projectDetailsWhereQuery);
                    _baseDao.MapArrayObjects<OutcomeMeasureResultDataType>(
                        "OUTCOME_MEASURE_ID", outcomeMeasureMap.Keys, selectText,
                        P2RPluginMappers.MapOutcomeMeasureResult,
                        delegate(OutcomeMeasureResultDataType[] array, int listKeyFieldsIndex)
                        {
                            OutcomeMeasureDataType outcomeMeasure =
                                outcomeMeasureMap[CollectionUtils.NthItem(outcomeMeasureMap.Keys, listKeyFieldsIndex)];
                            outcomeMeasure.OutcomeMeasureResult = array;
                        });
                }
            }
        }
    }
}