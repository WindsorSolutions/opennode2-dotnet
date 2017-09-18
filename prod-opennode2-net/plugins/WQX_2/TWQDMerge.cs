#define REPLACE_PROTOCOL_METHODS
using System;
using System.Data;
using System.Collections.Generic;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;
using System.Text;
using Windsor.Node2008.WNOSPlugin.WQX2XsdOrm;
using Spring.Data;

namespace Windsor.Node2008.WNOSPlugin.WQX2
{
    public class TWQDMerge
    {
        private Dictionary<string, int> _insertCounts;
        private Dictionary<string, int> _updateCounts;
        private SpringBaseDao _dao;
        private DateTime _lastUpdatedDateTime;
        private bool _setLastUpdatedDateTime;
        private bool _submitToEpa;

        private string SQL_CONCAT_STRING = "+";
        private const string WHERE_PARAM_NAME = "whrParam";
        private const string DELETE_PARAM_NAME = "delParam";
        private readonly char[] SPLIT_CHAR = new char[] { ';' };

        public void MergeWQXData(WQXDataType organization, SpringBaseDao dao, bool setLastUpdatedDateTime,
                                 bool submitToEpa,
                                 out Dictionary<string, int> insertCounts, out Dictionary<string, int> updateCounts)
        {
            ExceptionUtils.ThrowIfNull(organization, "organization");
            ExceptionUtils.ThrowIfNull(organization.Organization, "organization.Organization");
            ExceptionUtils.ThrowIfNull(organization.Organization.OrganizationDescription, "organization.Organization.OrganizationDescription");
            ExceptionUtils.ThrowIfEmptyString(organization.Organization.OrganizationDescription.OrganizationIdentifier, "organization.Organization.OrganizationDescription.OrganizationIdentifier");

            const int commandTimeout = 1800;

            _submitToEpa = submitToEpa;
            _insertCounts = new Dictionary<string, int>();
            _updateCounts = new Dictionary<string, int>();

            if (!CollectionUtils.IsNullOrEmpty(organization.Organization.Activity))
            {
                if (CollectionUtils.IsNullOrEmpty(organization.Organization.Project))
                {
                    throw new ArgException("The input WQX data does not contain any projects");
                }

                _dao = dao;
                _dao.AdoTemplate.CommandTimeout = commandTimeout;
                _lastUpdatedDateTime = DateTime.Now;
                _setLastUpdatedDateTime = setLastUpdatedDateTime;

                ValidateOrganizationExists(organization);

                ValidateProjectsExist(organization);

                ValidateMonitoringLocationsExist(organization);

                dao.TransactionTemplate.Execute(delegate(Spring.Transaction.ITransactionStatus status)
                {
                    dao.AdoTemplate.ClassicAdoTemplate.Execute(delegate(IDbCommand dbCommand)
                    {
                        MergeActivities(dbCommand, organization);

                        InsertResults(dbCommand, organization);

                        return null;
                    });

                    return null;
                });
            }

            insertCounts = _insertCounts;
            updateCounts = _updateCounts;
        }
        public static string CreateTableRowCountsString(Dictionary<string, int> insertCounts,
                                                        Dictionary<string, int> updateCounts)
        {
            SortedDictionary<string, KeyValuePair<int, int>> counts = new SortedDictionary<string, KeyValuePair<int, int>>();

            CollectionUtils.ForEach(insertCounts, delegate(KeyValuePair<string, int> pair)
            {
                KeyValuePair<int, int> count;
                if (counts.TryGetValue(pair.Key, out count))
                {
                    counts[pair.Key] = new KeyValuePair<int, int>(pair.Value + count.Key, count.Value);
                }
                else
                {
                    counts[pair.Key] = new KeyValuePair<int, int>(pair.Value, 0);
                }
            });
            CollectionUtils.ForEach(updateCounts, delegate(KeyValuePair<string, int> pair)
            {
                KeyValuePair<int, int> count;
                if (counts.TryGetValue(pair.Key, out count))
                {
                    counts[pair.Key] = new KeyValuePair<int, int>(count.Key, pair.Value + count.Value);
                }
                else
                {
                    counts[pair.Key] = new KeyValuePair<int, int>(0, pair.Value);
                }
            });
            if (counts.Count == 0)
            {
                return "None";
            }
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, KeyValuePair<int, int>> pair in counts)
            {
                if (sb.Length > 0)
                {
                    sb.Append(", ");
                }
                if ((pair.Value.Key > 0) && (pair.Value.Value > 0))
                {
                    sb.AppendFormat("{0} (Insert: {1}, Update: {2})", pair.Key, pair.Value.Key.ToString(),
                                    pair.Value.Value.ToString());
                }
                else if (pair.Value.Key > 0)
                {
                    sb.AppendFormat("{0} (Insert: {1})", pair.Key, pair.Value.Key.ToString());
                }
                else
                {
                    sb.AppendFormat("{0} (Update: {1})", pair.Key, pair.Value.Value.ToString());
                }
            }
            return sb.ToString();
        }

        private void ValidateOrganizationExists(WQXDataType organization)
        {
            int count = (int)_dao.DoJDBCExecuteScalar("SELECT COUNT(*) FROM Organization WHERE UPPER(OrganizationIdentifier) = UPPER(?)",
                                                      organization.Organization.OrganizationDescription.OrganizationIdentifier);

            if (count < 1)
            {
                throw new ArgException("A WQX organization with id \"{0}\" does not exist in the database", organization.Organization.OrganizationDescription.OrganizationIdentifier);
            }
        }

        private void ValidateProjectsExist(WQXDataType organization)
        {
            foreach (ProjectDataType project in organization.Organization.Project)
            {
                int count = (int)_dao.DoJDBCExecuteScalar("SELECT COUNT(*) FROM Project WHERE UPPER(OrganizationIdentifier) = UPPER(?) AND UPPER(ProjectIdentifier) = UPPER(?)",
                                                          organization.Organization.OrganizationDescription.OrganizationIdentifier,
                                                          project.ProjectIdentifier);

                if (count < 1)
                {
                    throw new ArgException("A WQX project with id \"{0}\" does not exist in the database for organization \"{1}\"", project.ProjectIdentifier,
                                           organization.Organization.OrganizationDescription.OrganizationIdentifier);
                }
            }
        }

        private void ValidateMonitoringLocationsExist(WQXDataType organization)
        {
            foreach (MonitoringLocationDataType location in organization.Organization.MonitoringLocation)
            {
                int count = (int)_dao.DoJDBCExecuteScalar("SELECT COUNT(*) FROM MonitoringLocation WHERE UPPER(OrganizationIdentifier) = UPPER(?) AND UPPER(MonitoringLocationIdentifier) = UPPER(?)",
                                                          organization.Organization.OrganizationDescription.OrganizationIdentifier,
                                                          location.MonitoringLocationIdentity.MonitoringLocationIdentifier);

                if (count < 1)
                {
                    throw new ArgException("A WQX monitoring location with id \"{0}\" does not exist in the database for organization \"{1}\"",
                                           location.MonitoringLocationIdentity.MonitoringLocationIdentifier,
                                           organization.Organization.OrganizationDescription.OrganizationIdentifier);
                }
            }
        }

        private void InsertResults(IDbCommand dbCommand, WQXDataType organization)
        {
            const string RSLT_UPDATE_COLUMNS = "ActivityIdentifier;DataLoggerLineName;SampleDateTime;ResultDetectionConditionText;CharacteristicName;ResultSampleFractionText;ResultMeasureValue;" +
                "ResultMeasureUnitCode;ResultStatusIdentifier;StatisticalBaseCode;ResultValueTypeName;ResultWeightBasisText;ResultTimeBasisText;ResultTemperatureBasisText;" +
                "ResultParticleSizeBasisText;ResultCommentText;BiologicalIntentName;BiologicalIndividualIdentifier;SubjectTaxonomicName;UnidentifiedSpeciesIdentifier;" +
                "SampleTissueAnatomyName;RGSCWMeasureValue;RGSCWMeasureUnitCode;ResAMMethodIdentifier;ResAMMethodIdentifierContext;ResAMMethodName;LaboratoryName;" +
                "AnalysisStartDate;AnalysisEndDate;ResultLaboratoryCommentCode;DetectionQuantitationLimitTypeName;RDQLMTMeasureValue;RDQLMTMeasureUnitCode;RLSPRPMethodIdentifier;" +
                "RLSPRPMethodIdentifierContext;RLSPRPMethodName;LastChangeDate;SubmitToEPA;SubmitToNWIFC;Delete";
            const string RSLT_TABLE_NAME = "Result";
            const string CHARACTERISTIC_TABLE_NAME = "Characteristic";
            const string RESULT_STATUS_TABLE_NAME = "ResultStatus";
            if (CollectionUtils.IsNullOrEmpty(organization.Organization.Activity))
            {
                return;
            }

            List<ResultDataType> results = new List<ResultDataType>(128);
            CollectionUtils.ForEach(organization.Organization.Activity, delegate(ActivityDataType activity)
            {
                ExceptionUtils.ThrowIfNull(activity, "activity");

                CollectionUtils.ForEach(activity.Result, delegate(ResultDataType result)
                {
                    result.ParentId = activity.ActivityDescription.ActivityIdentifier;  // Will be used below
                    results.Add(result);
                });
            });

            if (results.Count == 0)
            {
                return;
            }

            int count = (int)_dao.DoJDBCExecuteScalar("SELECT COUNT(*) FROM " + CHARACTERISTIC_TABLE_NAME, null);
            Dictionary<string, string> characteristicNames = new Dictionary<string, string>(count);
            DoSimpleQueryWithRowCallbackDelegate(dbCommand, CHARACTERISTIC_TABLE_NAME, null, null, "CName",
                delegate(IDataReader reader)
                {
                    string cName = reader.GetString(0);
                    characteristicNames.Add(cName, cName);
                });

            count = (int)_dao.DoJDBCExecuteScalar("SELECT COUNT(*) FROM " + RESULT_STATUS_TABLE_NAME, null);
            Dictionary<string, string> resultStatusIds = new Dictionary<string, string>(count);
            DoSimpleQueryWithRowCallbackDelegate(dbCommand, RESULT_STATUS_TABLE_NAME, null, null, "RSName",
                delegate(IDataReader reader)
                {
                    string rsName = reader.GetString(0);
                    resultStatusIds.Add(rsName, rsName);
                });

            int maxColCount = RSLT_UPDATE_COLUMNS.Split(';').Length;
            object[] values = new object[maxColCount];

            try
            {
                DoBulkInsert(dbCommand, RSLT_TABLE_NAME, RSLT_UPDATE_COLUMNS, delegate(int currentInsertIndex)
                {
                    if (currentInsertIndex < results.Count)
                    {
                        ResultDataType result = results[currentInsertIndex];

                        int valueIndex = 0;
                        values[valueIndex++] = result.ParentId;
                        if (result.ResultDescription != null)
                        {
                            values[valueIndex++] = result.ResultDescription.DataLoggerLineName;
                            values[valueIndex++] = null; // SampleDateTime?
                            values[valueIndex++] = result.ResultDescription.ResultDetectionConditionText;
                            if (string.IsNullOrEmpty(result.ResultDescription.CharacteristicName))
                            {
                                throw new ArgException("A result is missing a CharacteristicName for Activity: {0}", result.ParentId);
                            }
                            if (!characteristicNames.ContainsKey(result.ResultDescription.CharacteristicName))
                            {
                                throw new ArgException("A result has an unrecognized CharacteristicName: {0}", result.ResultDescription.CharacteristicName);
                            }
                            values[valueIndex++] = result.ResultDescription.CharacteristicName;
                            values[valueIndex++] = result.ResultDescription.ResultSampleFractionText;
                            if (result.ResultDescription.ResultMeasure != null)
                            {
                                values[valueIndex++] = result.ResultDescription.ResultMeasure.ResultMeasureValue;
                                values[valueIndex++] = result.ResultDescription.ResultMeasure.MeasureUnitCode;
                            }
                            else
                            {
                                values[valueIndex++] = null;
                                values[valueIndex++] = null;
                            }
                            if (string.IsNullOrEmpty(result.ResultDescription.ResultStatusIdentifier))
                            {
                                throw new ArgException("A result is missing a ResultStatusIdentifier for Activity: {0}", result.ParentId);
                            }
                            if (!resultStatusIds.ContainsKey(result.ResultDescription.ResultStatusIdentifier))
                            {
                                throw new ArgException("A result has an unrecognized ResultStatusIdentifier: {0}", result.ResultDescription.ResultStatusIdentifier);
                            }
                            values[valueIndex++] = result.ResultDescription.ResultStatusIdentifier;
                            values[valueIndex++] = result.ResultDescription.StatisticalBaseCode;

                            values[valueIndex++] = result.ResultDescription.ResultValueTypeName;
                            values[valueIndex++] = result.ResultDescription.ResultWeightBasisText;
                            values[valueIndex++] = result.ResultDescription.ResultTimeBasisText;
                            values[valueIndex++] = result.ResultDescription.ResultTemperatureBasisText;
                            values[valueIndex++] = result.ResultDescription.ResultParticleSizeBasisText;
                            values[valueIndex++] = result.ResultDescription.ResultCommentText;
                        }
                        else
                        {
                            throw new ArgException("A result is missing a ResultDescription element");
                        }
                        if (result.BiologicalResultDescription != null)
                        {
                            values[valueIndex++] = result.BiologicalResultDescription.BiologicalIntentName;
                            values[valueIndex++] = result.BiologicalResultDescription.BiologicalIndividualIdentifier;
                            values[valueIndex++] = result.BiologicalResultDescription.SubjectTaxonomicName;
                            values[valueIndex++] = result.BiologicalResultDescription.UnidentifiedSpeciesIdentifier;
                            values[valueIndex++] = result.BiologicalResultDescription.SampleTissueAnatomyName;
                            if (result.BiologicalResultDescription.GroupSummaryCountWeight != null)
                            {
                                values[valueIndex++] = result.BiologicalResultDescription.GroupSummaryCountWeight.MeasureValue;
                                values[valueIndex++] = result.BiologicalResultDescription.GroupSummaryCountWeight.MeasureUnitCode;
                            }
                            else
                            {
                                values[valueIndex++] = null;
                                values[valueIndex++] = null;
                            }
                        }
                        else
                        {
                            values[valueIndex++] = null;
                            values[valueIndex++] = null;
                            values[valueIndex++] = null;
                            values[valueIndex++] = null;
                            values[valueIndex++] = null;
                            values[valueIndex++] = null;
                            values[valueIndex++] = null;
                        }
                        if (result.ResultAnalyticalMethod != null)
                        {
                            values[valueIndex++] = result.ResultAnalyticalMethod.MethodIdentifier;
                            values[valueIndex++] = result.ResultAnalyticalMethod.MethodIdentifierContext;
                            values[valueIndex++] = result.ResultAnalyticalMethod.MethodName;
                        }
                        else
                        {
                            values[valueIndex++] = null;
                            values[valueIndex++] = null;
                            values[valueIndex++] = null;
                        }

                        if (result.ResultLabInformation != null)
                        {
                            values[valueIndex++] = result.ResultLabInformation.LaboratoryName;
                            if (result.ResultLabInformation.AnalysisStartDateSpecified)
                            {
                                values[valueIndex++] = result.ResultLabInformation.AnalysisStartDate;
                            }
                            else
                            {
                                values[valueIndex++] = null;
                            }
                            if (result.ResultLabInformation.AnalysisEndDateSpecified)
                            {
                                values[valueIndex++] = result.ResultLabInformation.AnalysisEndDate;
                            }
                            else
                            {
                                values[valueIndex++] = null;
                            }
                            values[valueIndex++] = result.ResultLabInformation.ResultLaboratoryCommentCode;
                            if (!CollectionUtils.IsNullOrEmpty(result.ResultLabInformation.ResultDetectionQuantitationLimit))
                            {
                                DetectionQuantitationLimitDataType detectionQuantitationLimitDataType = result.ResultLabInformation.ResultDetectionQuantitationLimit[0];
                                values[valueIndex++] = detectionQuantitationLimitDataType.DetectionQuantitationLimitTypeName;
                                if (detectionQuantitationLimitDataType.DetectionQuantitationLimitMeasure != null)
                                {
                                    values[valueIndex++] = detectionQuantitationLimitDataType.DetectionQuantitationLimitMeasure.MeasureValue;
                                    values[valueIndex++] = detectionQuantitationLimitDataType.DetectionQuantitationLimitMeasure.MeasureUnitCode;
                                }
                                else
                                {
                                    values[valueIndex++] = null;
                                    values[valueIndex++] = null;
                                }
                            }
                            else
                            {
                                values[valueIndex++] = null;
                                values[valueIndex++] = null;
                                values[valueIndex++] = null;
                            }
                        }
                        else
                        {
                            values[valueIndex++] = null;
                            values[valueIndex++] = null;
                            values[valueIndex++] = null;
                            values[valueIndex++] = null;
                            values[valueIndex++] = null;
                            values[valueIndex++] = null;
                            values[valueIndex++] = null;
                        }
                        if (!CollectionUtils.IsNullOrEmpty(result.LabSamplePreparation))
                        {
                            LabSamplePreparationDataType labSamplePreparationDataType = result.LabSamplePreparation[0];
                            if (labSamplePreparationDataType.LabSamplePreparationMethod != null)
                            {
                                values[valueIndex++] = labSamplePreparationDataType.LabSamplePreparationMethod.MethodIdentifier;
                                values[valueIndex++] = labSamplePreparationDataType.LabSamplePreparationMethod.MethodIdentifierContext;
                                values[valueIndex++] = labSamplePreparationDataType.LabSamplePreparationMethod.MethodName;
                            }
                            else
                            {
                                values[valueIndex++] = null;
                                values[valueIndex++] = null;
                                values[valueIndex++] = null;
                            }
                        }
                        else
                        {
                            values[valueIndex++] = null;
                            values[valueIndex++] = null;
                            values[valueIndex++] = null;
                        }
                        if (_setLastUpdatedDateTime)
                        {
                            values[valueIndex++] = _lastUpdatedDateTime;
                        }
                        else
                        {
                            values[valueIndex++] = null;
                        }
                        values[valueIndex++] = _submitToEpa ? 1 : 0;
                        values[valueIndex++] = 0;
                        values[valueIndex++] = 0;

                        IncInsertCount(RSLT_TABLE_NAME);

                        return values;
                    }
                    else
                    {
                        return null;
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void MergeActivities(IDbCommand dbCommand, WQXDataType organization)
        {
            const string ACT_PK_COLUMN = "ActivityIdentifier";
            const string ACT_UPDATE_COLUMNS = ACT_PK_COLUMN + ";ActivityTypeCode;ActivityMediaName;OrganizationIdentifier;ActivityStartDate;ActivityStartTime;ActivityStartTimeZoneCode;ActivityEndDate;" +
                "ActivityEndTime;ActivityEndTimeZoneCode;ActivityMeasureValue;ActivityMeasureUnitCode;ProjectIdentifier;MonitoringLocationIdentifier;ActivityCommentText;" +
                "AssemblageSampledName;SaCollMethodIdentifier;SaCollMethodIdentifierContext;SaCollMethodName;SaCollmethodQualifierTypeName;SaCollMethodDescriptionText;" +
                "SaCollEquipmentName;LastChangeDate;SubmitToEPA;SubmitToNWIFC;Delete";
            const string ACT_TABLE_NAME = "Activity";
            if (CollectionUtils.IsNullOrEmpty(organization.Organization.Activity))
            {
                return;
            }
            Dictionary<string, string> addedActivities = new Dictionary<string, string>(organization.Organization.Activity.Length);
            Dictionary<string, string> existingActivities;
            int count = (int)_dao.DoJDBCExecuteScalar("SELECT COUNT(*) FROM " + ACT_TABLE_NAME + " WHERE UPPER(OrganizationIdentifier) = UPPER(?)",
                                                      organization.Organization.OrganizationDescription.OrganizationIdentifier);
            if (count > 0)
            {
                existingActivities = new Dictionary<string, string>(count);

                DoSimpleQueryWithRowCallbackDelegate(dbCommand, ACT_TABLE_NAME, "OrganizationIdentifier", new object[] { organization.Organization.OrganizationDescription.OrganizationIdentifier },
                                                     ACT_PK_COLUMN,
                    delegate(IDataReader reader)
                    {
                        string activityId = reader.GetString(0);
                        existingActivities[activityId] = activityId;
                    });
            }
            else
            {
                existingActivities = new Dictionary<string, string>();
            }

            int maxColCount = ACT_UPDATE_COLUMNS.Split(';').Length;
            object[] values = new object[maxColCount];

            CollectionUtils.ForEach(organization.Organization.Activity, delegate(ActivityDataType activity)
            {
                ExceptionUtils.ThrowIfNull(activity, "activity");
                ExceptionUtils.ThrowIfNull(activity.ActivityDescription, "activity.ActivityDescription");

                if (CollectionUtils.IsNullOrEmpty(activity.ActivityDescription.ProjectIdentifier))
                {
                    throw new ArgException("The activity \"{0}\" does not have an associated project", activity.ActivityDescription.ActivityIdentifier);
                }
                if (string.IsNullOrEmpty(activity.ActivityDescription.MonitoringLocationIdentifier))
                {
                    throw new ArgException("The activity \"{0}\" does not have an associated monitoring location", activity.ActivityDescription.ActivityIdentifier);
                }
                int valueIndex = 0;
                values[valueIndex++] = activity.ActivityDescription.ActivityIdentifier;
                values[valueIndex++] = activity.ActivityDescription.ActivityTypeCode;
                values[valueIndex++] = activity.ActivityDescription.ActivityMediaName;
                values[valueIndex++] = organization.Organization.OrganizationDescription.OrganizationIdentifier;
                values[valueIndex++] = activity.ActivityDescription.ActivityStartDate;
                if (activity.ActivityDescription.ActivityStartTime != null)
                {
                    values[valueIndex++] = activity.ActivityDescription.ActivityStartTime.Time;
                    values[valueIndex++] = activity.ActivityDescription.ActivityStartTime.TimeZoneCode;
                }
                else
                {
                    values[valueIndex++] = null;
                    values[valueIndex++] = null;
                }
                if (activity.ActivityDescription.ActivityEndDateSpecified)
                {
                    values[valueIndex++] = activity.ActivityDescription.ActivityEndDate;
                }
                else
                {
                    values[valueIndex++] = null;
                }
                if (activity.ActivityDescription.ActivityEndTime != null)
                {
                    values[valueIndex++] = activity.ActivityDescription.ActivityEndTime.Time;
                    values[valueIndex++] = activity.ActivityDescription.ActivityEndTime.TimeZoneCode;
                }
                else
                {
                    values[valueIndex++] = null;
                    values[valueIndex++] = null;
                }
                if (activity.ActivityDescription.ActivityDepthHeightMeasure != null)
                {
                    values[valueIndex++] = activity.ActivityDescription.ActivityDepthHeightMeasure.MeasureValue;
                    values[valueIndex++] = activity.ActivityDescription.ActivityDepthHeightMeasure.MeasureUnitCode;
                }
                else
                {
                    values[valueIndex++] = null;
                    values[valueIndex++] = null;
                }
                values[valueIndex++] = activity.ActivityDescription.ProjectIdentifier[0];
                values[valueIndex++] = activity.ActivityDescription.MonitoringLocationIdentifier;
                values[valueIndex++] = activity.ActivityDescription.ActivityCommentText;

                if (activity.BiologicalActivityDescription != null)
                {
                    values[valueIndex++] = activity.BiologicalActivityDescription.AssemblageSampledName;
                }
                else
                {
                    values[valueIndex++] = null;
                }
                if (activity.SampleDescription != null)
                {
                    if (activity.SampleDescription.SampleCollectionMethod != null)
                    {
                        values[valueIndex++] = activity.SampleDescription.SampleCollectionMethod.MethodIdentifier;
                        values[valueIndex++] = activity.SampleDescription.SampleCollectionMethod.MethodIdentifierContext;
                        values[valueIndex++] = activity.SampleDescription.SampleCollectionMethod.MethodName;
                        values[valueIndex++] = activity.SampleDescription.SampleCollectionMethod.MethodQualifierTypeName;
                        values[valueIndex++] = activity.SampleDescription.SampleCollectionMethod.MethodDescriptionText;
                    }
                    else
                    {
                        values[valueIndex++] = null;
                        values[valueIndex++] = null;
                        values[valueIndex++] = null;
                        values[valueIndex++] = null;
                        values[valueIndex++] = null;
                    }
                    values[valueIndex++] = activity.SampleDescription.SampleCollectionEquipmentName;
                }
                else
                {
                    values[valueIndex++] = null;
                    values[valueIndex++] = null;
                    values[valueIndex++] = null;
                    values[valueIndex++] = null;
                    values[valueIndex++] = null;
                    values[valueIndex++] = null;
                }

                if (_setLastUpdatedDateTime)
                {
                    values[valueIndex++] = _lastUpdatedDateTime;
                }
                else
                {
                    values[valueIndex++] = null;
                }
                values[valueIndex++] = _submitToEpa ? 1 : 0;
                values[valueIndex++] = 0;
                values[valueIndex++] = 0;

                //string insertValueString = StringUtils.Join("','", values);

                try
                {
                    if (existingActivities.ContainsKey(activity.ActivityDescription.ActivityIdentifier) ||
                        addedActivities.ContainsKey(activity.ActivityDescription.ActivityIdentifier))
                    {
                        // There is a cascade delete on Results:
                        DoSimpleDelete(dbCommand, ACT_TABLE_NAME, ACT_PK_COLUMN, activity.ActivityDescription.ActivityIdentifier);

                        IncUpdateCount(ACT_TABLE_NAME);
                    }
                    else
                    {
                        IncInsertCount(ACT_TABLE_NAME);
                    }

                    DoInsertWithValues(dbCommand, ACT_TABLE_NAME, ACT_UPDATE_COLUMNS, values);
                }
                catch (Exception)
                {
                    throw;
                }

                addedActivities[activity.ActivityDescription.ActivityIdentifier] = activity.ActivityDescription.ActivityIdentifier;
            });
        }
        private void IncUpdateCount(string tableName)
        {
            IncCounts(tableName, _updateCounts);
        }
        private void IncInsertCount(string tableName)
        {
            IncCounts(tableName, _insertCounts);
        }
        private void IncCounts(string tableName, Dictionary<string, int> counts)
        {
            int curCount;
            counts.TryGetValue(tableName, out curCount);
            ++curCount;
            counts[tableName] = curCount;
        }
        public void DoSimpleUpdateOneWithValues(IDbCommand dbCommand, string tableName, string whereColumn, object whereValue,
                                                string semicolonSeparatedColumnNames, IList<object> values)
        {
            _dao.DoSimpleUpdateOneWithValues(tableName, whereColumn, whereValue, semicolonSeparatedColumnNames, values);
        }
        private void DoInsertWithValues(IDbCommand dbCommand, string tableName, string semicolonSeparatedColumnNames,
                                        IList<object> values)
        {
            _dao.DoInsertWithValues(tableName, semicolonSeparatedColumnNames, values);
        }
        private void DoSimpleDelete(IDbCommand dbCommand, string tableName, string semicolonSeparatedWhereColumnNames,
                                    params object[] whereValues)
        {

            _dao.DoSimpleDelete(tableName, semicolonSeparatedWhereColumnNames, whereValues);
        }
        private void DoSimpleQueryWithRowCallbackDelegate(IDbCommand dbCommand, string semicolonSeparatedTableNames,
                                                          string semicolonSeparatedWhereColumnNames,
                                                          IList<object> whereValues,
                                                          string semicolonSeparatedColumnNames,
                                                          RowCallbackDelegate callback)
        {
            _dao.DoSimpleQueryWithRowCallbackDelegate(semicolonSeparatedTableNames, semicolonSeparatedWhereColumnNames, whereValues,
                                                      semicolonSeparatedColumnNames, callback);
        }
        private string CreateDeleteSqlParamText(string tableName,
                                                  string semicolonSeparatedWhereColumns,
                                                  int maxWhereParamCount)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentException("tableName is empty");
            }
            StringBuilder sb = new StringBuilder("DELETE FROM ");
            sb.Append(tableName);
            AppendWhereString(semicolonSeparatedWhereColumns, maxWhereParamCount, sb);
            return sb.ToString();
        }
        protected void AppendWhereString(string semicolonSeparatedWhereColumns, int maxWhereParamCount,
                                         StringBuilder sb)
        {
            if (!string.IsNullOrEmpty(semicolonSeparatedWhereColumns))
            {
                string[] whereColumnNames = semicolonSeparatedWhereColumns.Split(SPLIT_CHAR, StringSplitOptions.RemoveEmptyEntries);
                sb.Append(" WHERE ");
                for (int i = 1; i <= whereColumnNames.Length; ++i)
                {
                    string whereParamName = WHERE_PARAM_NAME;
                    if (i > 1)
                    {
                        if (!whereColumnNames[i - 1].StartsWith(")") &&
                            !whereColumnNames[i - 1].StartsWith(" OR "))
                        {
                            sb.Append(" AND ");
                        }
                        whereParamName += i.ToString();
                    }
                    if (maxWhereParamCount >= i)
                    {
                        string whereColumnName = whereColumnNames[i - 1].TrimEnd();
                        bool appendParen = whereColumnName.EndsWith(")");
                        if (appendParen)
                        {
                            whereColumnName = whereColumnName.Substring(0, whereColumnName.Length - 1).TrimEnd();
                        }
                        if (whereColumnName.EndsWith("=") ||
                             whereColumnName.EndsWith("<") ||
                             whereColumnName.EndsWith(">"))
                        {
                            sb.AppendFormat("{0} {1}", whereColumnName,
                                                       _dao.ParseParamName(whereParamName));
                        }
                        else if (whereColumnName.EndsWith(" LIKE '%'p'%'", StringComparison.InvariantCultureIgnoreCase))
                        {
                            sb.AppendFormat("{0} LIKE '%' {1} {2} {3} '%'", whereColumnName.Substring(0, whereColumnName.Length - 13),
                                            SQL_CONCAT_STRING, _dao.ParseParamName(whereParamName), SQL_CONCAT_STRING);
                        }
                        else if (whereColumnName.EndsWith(" LIKE p'%'", StringComparison.InvariantCultureIgnoreCase))
                        {
                            sb.AppendFormat("{0} LIKE {1} {2} '%'", whereColumnName.Substring(0, whereColumnName.Length - 10),
                                            _dao.ParseParamName(whereParamName), SQL_CONCAT_STRING);
                        }
                        else if (whereColumnName.EndsWith(" LIKE '%'p", StringComparison.InvariantCultureIgnoreCase))
                        {
                            sb.AppendFormat("{0} LIKE '%' {1} {2}", whereColumnName.Substring(0, whereColumnName.Length - 10),
                                            SQL_CONCAT_STRING, _dao.ParseParamName(whereParamName));
                        }
                        else
                        {
                            //?? TODO: Does this work
                            if (whereColumnName.Contains(" ") ||
                                whereColumnName.StartsWith(")") ||
                                whereColumnName.StartsWith("("))
                            {
                                sb.AppendFormat("{0} = {1}", whereColumnName,
                                                _dao.ParseParamName(whereParamName));
                            }
                            else
                            {
                                sb.AppendFormat("UPPER({0}) = UPPER({1})", whereColumnName,
                                                             _dao.ParseParamName(whereParamName));
                            }
                        }
                        if (appendParen)
                        {
                            sb.Append(")");
                        }
                    }
                    else
                    {
                        sb.Append(whereColumnNames[i - 1]);
                    }
                }
            }
        }
        private void DoBulkInsert(IDbCommand dbCommand, string tableName, string semicolonSeparatedColumnNames,
                                  Windsor.Commons.Spring.SpringBaseDao.GetInsertValuesDelegate del)
        {
            _dao.DoBulkInsert(tableName, semicolonSeparatedColumnNames, del);
        }
    }
}
