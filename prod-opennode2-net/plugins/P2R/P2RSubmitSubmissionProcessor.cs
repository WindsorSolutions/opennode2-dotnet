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

namespace Windsor.Node2008.WNOSPlugin.P2R
{
    [Serializable]
    public class P2RSubmitSubmissionProcessor : P2RPluginBase, ISubmitProcessor
    {
        #region fields

        protected ITransactionManager _transactionManager;
        protected IIdProvider _idProvider;
        #endregion

        public P2RSubmitSubmissionProcessor()
        {
        }
        public void ProcessSubmit(string transactionId)
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
        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _idProvider);
        }
        protected void ProcessSubmitDocument(string transactionId, string docId)
        {
            string tempXmlFilePath = _settingsProvider.NewTempFilePath();
            try
            {
                Document document = _documentManager.GetDocument(transactionId, docId, true);
                if (document.IsZipFile)
                {
                    _compressionHelper.UncompressDeep(document.Content, tempXmlFilePath);
                }
                else
                {
                    File.WriteAllBytes(tempXmlFilePath, document.Content);
                }

                _headerDocumentHelper.Load(tempXmlFilePath);
                _organizationIdentifier = _headerDocumentHelper.GetProperty(ORG_ID_PROP_NAME);
                if (string.IsNullOrEmpty(_organizationIdentifier))
                {
                    throw new ArgumentException(string.Format("Submission document is missing a \"{0}\" property.",
                                                              ORG_ID_PROP_NAME));
                }
                string operation;
                XmlElement xmlPayload = _headerDocumentHelper.GetFirstPayload(out operation);
                if (xmlPayload == null)
                {
                    throw new ArgumentException("Submission document is missing a payload.");
                }
                if (operation != FULL_REPLACE_OPERATION)
                {
                    if (!operation.StartsWith(YEAR_OPERATION) || (operation.Length != (YEAR_OPERATION.Length + 4)) ||
                        !int.TryParse(operation.Substring(YEAR_OPERATION.Length), out _year) || (_year < MIN_YEAR) ||
                        (_year > MAX_YEAR))
                    {
                        throw new ArgumentException(string.Format("Invalid payload operation specified: \"{0}\"", operation));
                    }
                }

                ProgramListType payloadData = _serializationHelper.Deserialize<ProgramListType>(xmlPayload);

                if (_year == 0)
                {
                    ReplaceAll(_organizationIdentifier, payloadData);
                }
                else
                {
                    ReplaceYear(_organizationIdentifier, _year, payloadData);
                }
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to process document with id \"{0}.\"  EXCEPTION: {1}",
                                          docId.ToString(), ExceptionUtils.ToShortString(e));
            }
            finally
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath);
            }
        }
        protected void ReplaceAll(string orgId, ProgramListType payloadData)
        {
            _baseDao.TransactionTemplate.Execute(delegate
            {
                AppendAuditLogEvent("Deleting all entries in database where ORG_ID = \"{0}\"", orgId);
                _baseDao.DoSimpleDelete(Tables.P2R_ORG.ToString(), "ORG_ID", new object[] { orgId });
                AppendAuditLogEvent("Adding new entries in database for ORG_ID = \"{0}\"", orgId);
                _baseDao.DoInsert(Tables.P2R_ORG.ToString(), "ORG_ID", orgId);
                InsertProgramDetails(orgId, payloadData.ProgramDetails);
                AppendAuditLogEvent("Finished updating database for ORG_ID = \"{0}\"", orgId);
                return null;
            });
        }
        protected ProgramDetailsDataType[] FilterProgramDetailsListByYear(int year, ProgramDetailsDataType[] programDetails)
        {
            if (CollectionUtils.IsNullOrEmpty(programDetails))
            {
                return programDetails;
            }
            int numProgramDetailsSetToNull = 0;
            for (int i = 0; i < programDetails.Length; ++i)
            {
                ProgramDetailsDataType programDetail = programDetails[i];
                if (!CollectionUtils.IsNullOrEmpty(programDetail.ProjectDetails))
                {
                    int numProjectDetailsSetToNull = 0;
                    for (int j = 0; j < programDetail.ProjectDetails.Length; ++j)
                    {
                        ProjectDetailsDataType projectDetail = programDetail.ProjectDetails[j];
                        if (projectDetail.ProjectStartDate.Year != year)
                        {
                            programDetail.ProjectDetails[j] = null;
                            numProjectDetailsSetToNull++;
                        }
                    }
                    if (numProjectDetailsSetToNull == programDetail.ProjectDetails.Length)
                    {
                        programDetails[i] = null;
                        numProgramDetailsSetToNull++;
                    }
                    else if (numProjectDetailsSetToNull > 0)
                    {
                        programDetail.ProjectDetails = CollectionUtils.RemoveNullElements(programDetail.ProjectDetails);
                    }
                }
                else
                {
                    programDetails[i] = null;
                    numProgramDetailsSetToNull++;
                }
            }
            if (numProgramDetailsSetToNull == programDetails.Length)
            {
                return null;
            }
            else if (numProgramDetailsSetToNull > 0)
            {
                return CollectionUtils.RemoveNullElements(programDetails);
            }
            else
            {
                return programDetails;
            }
        }
        protected void ReplaceYear(string orgId, int year, ProgramListType payloadData)
        {
            payloadData.ProgramDetails = FilterProgramDetailsListByYear(year, payloadData.ProgramDetails);
            _baseDao.TransactionTemplate.Execute(delegate
            {
                if (_baseDao.RowExistsSimple(Tables.P2R_ORG.ToString(), "ORG_ID", orgId))
                {
                    AppendAuditLogEvent("Deleting all projects in database where ORG_ID = \"{0}\" and year = \"{1}\"", orgId, year);
                    string query =
                        string.Format("PROJECT_DETAILS_ID IN " +
                                      "(SELECT project.PROJECT_DETAILS_ID FROM P2R_PROJECT_DETAILS project, P2R_PROGRAM_DETAILS program WHERE " +
                                      "program.ORG_ID = '{0}' AND project.PROGRAM_DETAILS_ID = program.PROGRAM_DETAILS_ID AND " +
                                      "project.PROJECT_START_DATE >= '{1}' AND project.PROJECT_START_DATE < '{2}')",
                                      orgId, new DateTime(year, 1, 1, 0, 0, 0).ToString(), new DateTime(year + 1, 1, 1, 0, 0, 0).ToString());
                    _baseDao.DoSimpleDelete(Tables.P2R_PROJECT_DETAILS.ToString(), query, null);
                    UpdateProgramDetails(orgId, payloadData.ProgramDetails);
                }
                else
                {
                    // ORG id does not exist, this reverts to a full replace for the org
                    AppendAuditLogEvent("Adding new entries in database for ORG_ID = \"{0}\" and year = \"{1}\"", orgId, year);
                    _baseDao.DoInsert(Tables.P2R_ORG.ToString(), "ORG_ID", orgId);
                    InsertProgramDetails(orgId, payloadData.ProgramDetails);
                }
                AppendAuditLogEvent("Finished updating database for ORG_ID = \"{0}\"", orgId);
                return null;
            });
        }
        protected void UpdateProgramDetails(string orgId, ProgramDetailsDataType[] programDetails)
        {
            if (!CollectionUtils.IsNullOrEmpty(programDetails))
            {
                AppendAuditLogEvent("Updating {0} program details in database", programDetails.Length.ToString());
                List<KeyValuePair<string, ProjectDetailsDataType>> projectDetailsList = null;
                foreach (ProgramDetailsDataType programDetail in programDetails)
                {
                    string id = _baseDao.GetRowPrimaryKey(Tables.P2R_PROGRAM_DETAILS.ToString(), "PROGRAM_DETAILS_ID",
                                                          "ORG_ID;PROGRAM_IDENTIFIER", orgId, programDetail.ProgramIdentifier);
                    if (id != null)
                    {
                        _baseDao.DoSimpleUpdateOne(Tables.P2R_PROGRAM_DETAILS.ToString(), "PROGRAM_DETAILS_ID", id,
                                                   "PROGRAM_NAME;PROGRAM_DESCRIPTION;PROGRAM_ADDRESS;PROGRAM_CITY;PROGRAM_STATE;" +
                                                   "PROGRAM_ZIP_CODE;PROGRAM_PHONE_NUMBER;PROGRAM_CONTACT_PERSON",
                                                   programDetail.ProgramName, programDetail.ProgramDescription,
                                                   programDetail.ProgramAddress, programDetail.ProgramCity,
                                                   programDetail.ProgramState, (programDetail.ProgramZipCode == null) ? null : programDetail.ProgramZipCode,
                                                   programDetail.ProgramPhoneNumber, programDetail.ProgramContactPerson);
                    }
                    else
                    {
                        id = _idProvider.Get();
                        _baseDao.DoInsert(Tables.P2R_PROGRAM_DETAILS.ToString(),
                                          "PROGRAM_DETAILS_ID;ORG_ID;PROGRAM_IDENTIFIER;PROGRAM_NAME;PROGRAM_DESCRIPTION;PROGRAM_ADDRESS;PROGRAM_CITY;" +
                                          "PROGRAM_STATE;PROGRAM_ZIP_CODE;PROGRAM_PHONE_NUMBER;PROGRAM_CONTACT_PERSON",
                                          id, orgId, programDetail.ProgramIdentifier, programDetail.ProgramName, programDetail.ProgramDescription,
                                          programDetail.ProgramAddress, programDetail.ProgramCity, programDetail.ProgramState,
                                          (programDetail.ProgramZipCode == null) ? null : programDetail.ProgramZipCode,
                                          programDetail.ProgramPhoneNumber, programDetail.ProgramContactPerson);
                    }
                    AppendItems(id, programDetail.ProjectDetails, ref projectDetailsList);
                }
                InsertProjectDetails(projectDetailsList);
            }
            else
            {
                AppendAuditLogEvent("No program details specified to update into database");
            }
        }
        protected void InsertProgramDetails(string orgId, ProgramDetailsDataType[] programDetails)
        {
            if (!CollectionUtils.IsNullOrEmpty(programDetails))
            {
                AppendAuditLogEvent("Inserting {0} program details into database", programDetails.Length.ToString());
                List<KeyValuePair<string, ProjectDetailsDataType>> projectDetailsList = null;
                {
                    object[] insertValues = new object[11];
                    _baseDao.DoBulkInsert(Tables.P2R_PROGRAM_DETAILS.ToString(),
                         "PROGRAM_DETAILS_ID;ORG_ID;PROGRAM_IDENTIFIER;PROGRAM_NAME;PROGRAM_DESCRIPTION;PROGRAM_ADDRESS;PROGRAM_CITY;" +
                         "PROGRAM_STATE;PROGRAM_ZIP_CODE;PROGRAM_PHONE_NUMBER;PROGRAM_CONTACT_PERSON",
                         delegate(int currentInsertIndex)
                         {
                             if (currentInsertIndex < programDetails.Length)
                             {
                                 ProgramDetailsDataType programDetail = programDetails[currentInsertIndex];
                                 int index = 0;
                                 string id = _idProvider.Get();
                                 insertValues[index++] = id;
                                 insertValues[index++] = orgId;
                                 insertValues[index++] = programDetail.ProgramIdentifier;
                                 insertValues[index++] = programDetail.ProgramName;
                                 insertValues[index++] = programDetail.ProgramDescription;
                                 insertValues[index++] = programDetail.ProgramAddress;
                                 insertValues[index++] = programDetail.ProgramCity;
                                 insertValues[index++] = programDetail.ProgramState;
                                 insertValues[index++] = (programDetail.ProgramZipCode == null) ? null : programDetail.ProgramZipCode;
                                 insertValues[index++] = programDetail.ProgramPhoneNumber;
                                 insertValues[index++] = programDetail.ProgramContactPerson;
                                 AppendItems(id, programDetail.ProjectDetails, ref projectDetailsList);
                                 return insertValues;
                             }
                             else
                             {
                                 return null;
                             }
                         });
                }
                InsertProjectDetails(projectDetailsList);
            }
            else
            {
                AppendAuditLogEvent("No program details specified to insert into database");
            }
        }
        protected void InsertProjectDetails(List<KeyValuePair<string, ProjectDetailsDataType>> projectDetailsList)
        {
            if (!CollectionUtils.IsNullOrEmpty(projectDetailsList))
            {
                AppendAuditLogEvent("Inserting {0} project details into database", projectDetailsList.Count.ToString());
                List<KeyValuePair<string, ProjectDetailsSectorDataType>> sectorTextList = null;
                List<KeyValuePair<string, InvestmentDataType>> investmentList = null;
                List<KeyValuePair<string, BehavioralChangeDataType>> behavioralChangeList = null;
                List<KeyValuePair<string, OutcomeMeasureDataType>> outcomeMeasureList = null;
                List<KeyValuePair<string, ActivityMeasureDataType>> activityMeasureList = null;
                {
                    object[] insertValues = new object[10];
                    _baseDao.DoBulkInsert(Tables.P2R_PROJECT_DETAILS.ToString(),
                         "PROGRAM_DETAILS_ID;PROJECT_DETAILS_ID;PROJECT_IDENTIFIER;PROJECT_NAME;PROJECT_DESCRIPTION;" +
                         "SCOPE_AREA_TEXT;PROJECT_START_DATE;PROJECT_END_DATE;PROJECT_INPUT_PERSON;PROJECT_DATE_ENTERED",
                         delegate(int currentInsertIndex)
                         {
                             if (currentInsertIndex < projectDetailsList.Count)
                             {
                                 KeyValuePair<string, ProjectDetailsDataType> pair = projectDetailsList[currentInsertIndex];
                                 int index = 0;
                                 string id = _idProvider.Get();
                                 insertValues[index++] = pair.Key;
                                 insertValues[index++] = id;
                                 insertValues[index++] = pair.Value.ProjectIdentifier;
                                 insertValues[index++] = pair.Value.ProjectName;
                                 insertValues[index++] = pair.Value.ProjectDescription;
                                 insertValues[index++] = pair.Value.ScopeAreaTextSpecified ? pair.Value.ScopeAreaText.ToString() : null;
                                 insertValues[index++] = pair.Value.ProjectStartDate;
                                 insertValues[index++] = pair.Value.ProjectEndDateSpecified ? (object)pair.Value.ProjectEndDate : null;
                                 insertValues[index++] = pair.Value.ProjectInputPerson;
                                 insertValues[index++] = pair.Value.ProjectDateEnteredSpecified ? (object)pair.Value.ProjectDateEntered : null;
                                 AppendItems(id, pair.Value.SectorText, ref sectorTextList);
                                 AppendItems(id, pair.Value.Investment, ref investmentList);
                                 AppendItems(id, pair.Value.BehavioralChange, ref behavioralChangeList);
                                 AppendItems(id, pair.Value.OutcomeMeasure, ref outcomeMeasureList);
                                 AppendItems(id, pair.Value.ActivityMeasure, ref activityMeasureList);
                                 return insertValues;
                             }
                             else
                             {
                                 return null;
                             }
                         });
                }
                InsertInvestment(investmentList);
                InsertSectorText(sectorTextList);
                InsertBehavioralChange(behavioralChangeList);
                InsertOutcomeMeasure(outcomeMeasureList);
                InsertActivityMeasure(activityMeasureList);
            }
            else
            {
                AppendAuditLogEvent("No project details specified to insert into database");
            }
        }
        protected void InsertActivityMeasure(List<KeyValuePair<string, ActivityMeasureDataType>> activityMeasureList)
        {
            if (!CollectionUtils.IsNullOrEmpty(activityMeasureList))
            {
                AppendAuditLogEvent("Inserting {0} activity measures into database", activityMeasureList.Count.ToString());
                List<KeyValuePair<string, ActivityMeasureQuantitativeResultDataType>> quantitativeResultList = null;
                {
                    object[] insertValues = new object[5];
                    _baseDao.DoBulkInsert(Tables.P2R_ACTIVITY_MEASURE.ToString(),
                         "ACTIVITY_MEASURE_ID;PROJECT_DETAILS_ID;ACTIVITY_MEASURE_IDENTIFIER;ACTIVITY_MEASURE_NAME;ACTIVITY_MEASURE_DEFINITION",
                         delegate(int currentInsertIndex)
                         {
                             if (currentInsertIndex < activityMeasureList.Count)
                             {
                                 KeyValuePair<string, ActivityMeasureDataType> pair = activityMeasureList[currentInsertIndex];
                                 int index = 0;
                                 string id = _idProvider.Get();
                                 insertValues[index++] = id;
                                 insertValues[index++] = pair.Key;
                                 insertValues[index++] = pair.Value.ActivityMeasureIdentifier;
                                 insertValues[index++] = pair.Value.ActivityMeasureName;
                                 insertValues[index++] = pair.Value.ActivityMeasureDefinition;
                                 AppendItems(id, pair.Value.QuantitativeResult, ref quantitativeResultList);
                                 return insertValues;
                             }
                             else
                             {
                                 return null;
                             }
                         });
                }
                InsertActivityMeasureQuantitativeResult(quantitativeResultList);
            }
            else
            {
                AppendAuditLogEvent("No activity measures specified to insert into database");
            }
        }
        protected void InsertActivityMeasureQuantitativeResult(List<KeyValuePair<string, ActivityMeasureQuantitativeResultDataType>> quantitativeResultList)
        {
            if (!CollectionUtils.IsNullOrEmpty(quantitativeResultList))
            {
                AppendAuditLogEvent("Inserting {0} activity measure quantitative results into database", quantitativeResultList.Count.ToString());
                object[] insertValues = new object[4];
                _baseDao.DoBulkInsert(Tables.P2R_ACTIVITY_MEASURE_QNT_RSLT.ToString(),
                     "ACTIVITY_MEASURE_QNT_RSLT_ID;ACTIVITY_MEASURE_ID;P2R_MEASURE_VALUE;UNIT_OF_MEASURE",
                     delegate(int currentInsertIndex)
                     {
                         if (currentInsertIndex < quantitativeResultList.Count)
                         {
                             KeyValuePair<string, ActivityMeasureQuantitativeResultDataType> pair = quantitativeResultList[currentInsertIndex];
                             int index = 0;
                             string id = _idProvider.Get();
                             insertValues[index++] = id;
                             insertValues[index++] = pair.Key;
                             insertValues[index++] = pair.Value.P2RMeasureValue;
                             insertValues[index++] = pair.Value.UnitOfMeasure.ToString();
                             return insertValues;
                         }
                         else
                         {
                             return null;
                         }
                     });
            }
            else
            {
                AppendAuditLogEvent("No activity measure quantitative results specified to insert into database");
            }
        }
        protected void InsertOutcomeMeasure(List<KeyValuePair<string, OutcomeMeasureDataType>> outcomeMeasureList)
        {
            if (!CollectionUtils.IsNullOrEmpty(outcomeMeasureList))
            {
                AppendAuditLogEvent("Inserting {0} outcome measures into database", outcomeMeasureList.Count.ToString());
                List<KeyValuePair<string, OutcomeMeasureResultDataType>> outcomeMeasureResultList = null;
                {
                    object[] insertValues = new object[8];
                    _baseDao.DoBulkInsert(Tables.P2R_OUTCOME_MEASURE.ToString(),
                         "OUTCOME_MEASURE_ID;PROJECT_DETAILS_ID;OUTCOME_MEASURE_IDENTIFIER;OUTCOME_MEASURE_NAME;OUTCOME_MEASURE_DEFINITION;" +
                         "OUTCOME_MEASURE_SAVING;OUTCOME_MEASURE_INITIAL_COST;OUTCOME_MEASURE_RECURRING_YEAR",
                         delegate(int currentInsertIndex)
                         {
                             if (currentInsertIndex < outcomeMeasureList.Count)
                             {
                                 KeyValuePair<string, OutcomeMeasureDataType> pair = outcomeMeasureList[currentInsertIndex];
                                 int index = 0;
                                 string id = _idProvider.Get();
                                 insertValues[index++] = id;
                                 insertValues[index++] = pair.Key;
                                 insertValues[index++] = pair.Value.OutcomeMeasureIdentifier;
                                 insertValues[index++] = pair.Value.OutcomeMeasureName;
                                 insertValues[index++] = pair.Value.OutcomeMeasureDefinition;
                                 insertValues[index++] = pair.Value.OutcomeMeasureSavingSpecified ? pair.Value.OutcomeMeasureSaving.ToString() : null;
                                 insertValues[index++] = pair.Value.OutcomeMeasureInitialCostSpecified ? pair.Value.OutcomeMeasureInitialCost.ToString() : null;
                                 insertValues[index++] = pair.Value.OutcomeMeasureRecurringYear;
                                 AppendItems(id, pair.Value.OutcomeMeasureResult, ref outcomeMeasureResultList);
                                 return insertValues;
                             }
                             else
                             {
                                 return null;
                             }
                         });
                }
                InsertOutcomeMeasureResult(outcomeMeasureResultList);
            }
            else
            {
                AppendAuditLogEvent("No outcome measures specified to insert into database");
            }
        }
        protected void InsertOutcomeMeasureResult(List<KeyValuePair<string, OutcomeMeasureResultDataType>> outcomeMeasureResultList)
        {
            if (!CollectionUtils.IsNullOrEmpty(outcomeMeasureResultList))
            {
                AppendAuditLogEvent("Inserting {0} outcome measure results into database", outcomeMeasureResultList.Count.ToString());
                object[] insertValues = new object[6];
                _baseDao.DoBulkInsert(Tables.P2R_OUTCOME_MEASURE_RESULT.ToString(),
                     "OUTCOME_MEASURE_RESULT_ID;OUTCOME_MEASURE_ID;MEDIA_TYPE_TEXT;OUTCOME_MEASURE_RESULT_VALUE;UNIT_OF_MEASURE;METRIC_TEXT",
                     delegate(int currentInsertIndex)
                     {
                         if (currentInsertIndex < outcomeMeasureResultList.Count)
                         {
                             KeyValuePair<string, OutcomeMeasureResultDataType> pair = outcomeMeasureResultList[currentInsertIndex];
                             int index = 0;
                             string id = _idProvider.Get();
                             insertValues[index++] = id;
                             insertValues[index++] = pair.Key;
                             insertValues[index++] = pair.Value.MediaTypeText;
                             insertValues[index++] = pair.Value.OutcomeMeasureResultValue.ToString();
                             insertValues[index++] = pair.Value.UnitOfMeasure.ToString();
                             insertValues[index++] = pair.Value.MetricText.ToString();
                             return insertValues;
                         }
                         else
                         {
                             return null;
                         }
                     });
            }
            else
            {
                AppendAuditLogEvent("No outcome measure results specified to insert into database");
            }
        }
        protected void InsertBehavioralChange(List<KeyValuePair<string, BehavioralChangeDataType>> behavioralChangeList)
        {
            if (!CollectionUtils.IsNullOrEmpty(behavioralChangeList))
            {
                AppendAuditLogEvent("Inserting {0} behavioral changes into database", behavioralChangeList.Count.ToString());
                List<KeyValuePair<string, BehavioralChangeQuantitativeResultDataType>> quantitativeResultList = null;
                {
                    object[] insertValues = new object[5];
                    _baseDao.DoBulkInsert(Tables.P2R_BEHAVIORAL_CHANGE.ToString(),
                         "BEHAVIORAL_CHANGE_ID;PROJECT_DETAILS_ID;BEHAVIORAL_CHANGE_IDENTIFIER;BEHAVIORAL_CHANGE_NAME;BEHAVIORAL_CHANGE_DEFINITION",
                         delegate(int currentInsertIndex)
                         {
                             if (currentInsertIndex < behavioralChangeList.Count)
                             {
                                 KeyValuePair<string, BehavioralChangeDataType> pair = behavioralChangeList[currentInsertIndex];
                                 int index = 0;
                                 string id = _idProvider.Get();
                                 insertValues[index++] = id;
                                 insertValues[index++] = pair.Key;
                                 insertValues[index++] = pair.Value.BehavioralChangeIdentifier;
                                 insertValues[index++] = pair.Value.BehavioralChangeName;
                                 insertValues[index++] = pair.Value.BehavioralChangeDefinition;
                                 AppendItems(id, pair.Value.QuantitativeResult, ref quantitativeResultList);
                                 return insertValues;
                             }
                             else
                             {
                                 return null;
                             }
                         });
                }
                InsertBehavioralChangeQuantitativeResult(quantitativeResultList);
            }
            else
            {
                AppendAuditLogEvent("No behavioral changes specified to insert into database");
            }
        }
        protected void InsertBehavioralChangeQuantitativeResult(List<KeyValuePair<string, BehavioralChangeQuantitativeResultDataType>> quantitativeResultList)
        {
            if (!CollectionUtils.IsNullOrEmpty(quantitativeResultList))
            {
                AppendAuditLogEvent("Inserting {0} behavioral change quantitative results into database", quantitativeResultList.Count.ToString());
                object[] insertValues = new object[4];
                _baseDao.DoBulkInsert(Tables.P2R_BEHAVIORAL_CHANGE_QNT_RSLT.ToString(),
                     "BEHAVIORAL_CHANGE_QNT_RSLT_ID;BEHAVIORAL_CHANGE_ID;P2R_MEASURE_VALUE;UNIT_OF_MEASURE",
                     delegate(int currentInsertIndex)
                     {
                         if (currentInsertIndex < quantitativeResultList.Count)
                         {
                             KeyValuePair<string, BehavioralChangeQuantitativeResultDataType> pair = quantitativeResultList[currentInsertIndex];
                             int index = 0;
                             string id = _idProvider.Get();
                             insertValues[index++] = id;
                             insertValues[index++] = pair.Key;
                             insertValues[index++] = pair.Value.P2RMeasureValue;
                             insertValues[index++] = pair.Value.UnitOfMeasure.ToString();
                             return insertValues;
                         }
                         else
                         {
                             return null;
                         }
                     });
            }
            else
            {
                AppendAuditLogEvent("No behavioral change quantitative results specified to insert into database");
            }
        }
        protected void InsertSectorText(List<KeyValuePair<string, ProjectDetailsSectorDataType>> sectorTextList)
        {
            if (!CollectionUtils.IsNullOrEmpty(sectorTextList))
            {
                AppendAuditLogEvent("Inserting {0} project details sector text into database", sectorTextList.Count.ToString());
                object[] insertValues = new object[3];
                _baseDao.DoBulkInsert(Tables.P2R_PROJECT_DETAILS_SECTOR.ToString(),
                     "PROJECT_DETAILS_SECTOR_ID;PROJECT_DETAILS_ID;SECTOR_TEXT",
                     delegate(int currentInsertIndex)
                     {
                         if (currentInsertIndex < sectorTextList.Count)
                         {
                             KeyValuePair<string, ProjectDetailsSectorDataType> pair = sectorTextList[currentInsertIndex];
                             int index = 0;
                             string id = _idProvider.Get();
                             insertValues[index++] = id;
                             insertValues[index++] = pair.Key;
                             insertValues[index++] = pair.Value.SectorText.ToString();
                             return insertValues;
                         }
                         else
                         {
                             return null;
                         }
                     });
            }
            else
            {
                AppendAuditLogEvent("No project details sector text specified to insert into database");
            }
        }
        protected void InsertInvestment(List<KeyValuePair<string, InvestmentDataType>> investmentList)
        {
            if (!CollectionUtils.IsNullOrEmpty(investmentList))
            {
                AppendAuditLogEvent("Inserting {0} investments into database", investmentList.Count.ToString());
                object[] insertValues = new object[7];
                _baseDao.DoBulkInsert(Tables.P2R_INVESTMENT.ToString(),
                     "INVESTMENT_ID;PROJECT_DETAILS_ID;INVESTMENT_IDENTIFIER;INVESTMENT_NAME;INVESTMENT_DEFINITION;UNIT_OF_MEASURE;INVESTMENT_VALUE",
                     delegate(int currentInsertIndex)
                     {
                         if (currentInsertIndex < investmentList.Count)
                         {
                             KeyValuePair<string, InvestmentDataType> pair = investmentList[currentInsertIndex];
                             int index = 0;
                             string id = _idProvider.Get();
                             insertValues[index++] = id;
                             insertValues[index++] = pair.Key;
                             insertValues[index++] = pair.Value.InvestmentIdentifier;
                             insertValues[index++] = pair.Value.InvestmentName;
                             insertValues[index++] = pair.Value.InvestmentDefinition;
                             insertValues[index++] = pair.Value.UnitOfMeasure.ToString();
                             insertValues[index++] = pair.Value.InvestmentValue.ToString();
                             return insertValues;
                         }
                         else
                         {
                             return null;
                         }
                     });
            }
            else
            {
                AppendAuditLogEvent("No investments specified to insert into database");
            }
        }
        protected void AppendItems<T>(string parentPK, T[] itemsToAppend, ref List<KeyValuePair<string, T>> appendList)
        {
            if (!CollectionUtils.IsNullOrEmpty(itemsToAppend))
            {
                if (appendList == null) appendList = new List<KeyValuePair<string, T>>();
                foreach (T item in itemsToAppend)
                {
                    appendList.Add(new KeyValuePair<string, T>(parentPK, item));
                }
            }
        }
    }
}