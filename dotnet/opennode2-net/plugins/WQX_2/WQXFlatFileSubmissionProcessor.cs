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

namespace Windsor.Node2008.WNOSPlugin.WQX2
{
    [Serializable]
    public class WQXFlatFileSubmissionProcessor : WQXSubmissionProcessor
    {
        #region fields
        protected const string CONFIG_ORG_ID = "WQX Organization Id";
        protected const string CONFIG_ORG_NAME = "WQX Organization Name";
        private string _organizationId;
        private string _organizationName;
        #endregion

        public WQXFlatFileSubmissionProcessor()
        {
            ConfigurationArguments.Add(CONFIG_ORG_ID, null);
            ConfigurationArguments.Add(CONFIG_ORG_NAME, null);
            _deleteExistingDataBeforeInsert = false;
        }
        protected override void LazyInit()
        {
            base.LazyInit();

            _organizationId = ValidateNonEmptyConfigParameter(CONFIG_ORG_ID);
            _organizationName = ValidateNonEmptyConfigParameter(CONFIG_ORG_NAME);
        }
        protected override WQXDataType GetWQXData(string transactionId, string docId,
                                                  out Windsor.Node2008.WNOSPlugin.WQX1XsdOrm.WQXDataType data1)
        {
            WQXDataType data = null;
            data1 = null;
            string tempFolderPath = Path.Combine(_settingsProvider.TempFolderPath, Guid.NewGuid().ToString());
            try
            {
                AppendAuditLogEvent("Extracting contents of document with id \"{0}\" to temporary folder", docId);
                _compressionHelper.UncompressDirectory(_documentManager.GetContent(transactionId, docId), tempFolderPath);

                string projectsFile, monitoringFile, resultsFile;
                GetFlatFiles(tempFolderPath, out projectsFile, out monitoringFile, out resultsFile);

                AppendAuditLogEvent("Generating WQX data from flat files for Organization Id \"{0}\" and Name \"{1}\"",
                                    _organizationId, _organizationName);

                Dictionary<string, MonitoringLocationDataType> monitoringLocations =
                    ParseMonitoringLocations(monitoringFile);
                if (CollectionUtils.IsNullOrEmpty(monitoringLocations))
                {
                    throw new InvalidDataException(string.Format("The document does not contain any monitoring locations inside the flat file"));
                }

                Dictionary<string, ProjectDataType> projects =
                    ParseProjects(projectsFile);
                if (CollectionUtils.IsNullOrEmpty(projects))
                {
                    throw new InvalidDataException(string.Format("The document does not contain any projects inside the flat file"));
                }

                Dictionary<string, ActivityDataType> activities =
                    ParseResults(resultsFile, projects, monitoringLocations);

                data = new WQXDataType();
                data.Organization = new OrganizationDataType();
                data.Organization.OrganizationDescription = new OrganizationDescriptionDataType();
                data.Organization.OrganizationDescription.OrganizationIdentifier = _organizationId;
                data.Organization.OrganizationDescription.OrganizationFormalName = _organizationName;

                if (!CollectionUtils.IsNullOrEmpty(monitoringLocations))
                {
                    data.Organization.MonitoringLocation = new List<MonitoringLocationDataType>(monitoringLocations.Values).ToArray();
                }
                if (!CollectionUtils.IsNullOrEmpty(projects))
                {
                    data.Organization.Project = new List<ProjectDataType>(projects.Values).ToArray();
                }
                if (!CollectionUtils.IsNullOrEmpty(activities))
                {
                    data.Organization.Activity = new List<ActivityDataType>(activities.Values).ToArray();
                }
                SaveDataFileToTransaction(transactionId, data);
            }
            finally
            {
                FileUtils.SafeDeleteDirectory(tempFolderPath);
            }
            return data;
        }
        protected void SaveDataFileToTransaction(string transactionId, WQXDataType data)
        {
            string tempXmlFilePath = _settingsProvider.NewTempFilePath();
            tempXmlFilePath = Path.ChangeExtension(tempXmlFilePath, ".xml");

            try
            {
                AppendAuditLogEvent("Saving generated WQX xml file to transaction ...");
                
                _serializationHelper.Serialize(data, tempXmlFilePath);

                _documentManager.AddDocument(transactionId,
                                             CommonTransactionStatusCode.Completed,
                                             null, tempXmlFilePath);
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to save generated WQX xml file to transaction: {0}",
                                    ExceptionUtils.GetDeepExceptionMessage(e));
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath);
            }
        }
        protected void GetFlatFiles(string folderPath, out string projectsFile, out string monitoringFile, out string resultsFile)
        {
            string[] files = Directory.GetFiles(folderPath);
            if (CollectionUtils.IsNullOrEmpty(files))
            {
                throw new InvalidDataException(string.Format("The document does not contain any files"));
            }
            projectsFile = FindFirstFileStringThatContains(files, "Projects");
            monitoringFile = FindFirstFileStringThatContains(files, "Monitoring");
            resultsFile = FindFirstFileStringThatContains(files, "Results");

            if ((projectsFile == null) && (monitoringFile == null) && (resultsFile == null))
            {
                throw new InvalidDataException(string.Format("The document does not contain any flat files that are named correctly"));
            }
            if (((projectsFile != null) && ((projectsFile == monitoringFile) || (projectsFile == resultsFile))) ||
                ((monitoringFile != null) && ((monitoringFile == projectsFile) || (monitoringFile == resultsFile))) ||
                ((resultsFile != null) && ((resultsFile == monitoringFile) || (resultsFile == projectsFile))))
            {
                throw new InvalidDataException(string.Format("The document contains flat files that are not named correctly"));
            }

            // For now, assume all files MUST be present:
            if (projectsFile == null)
            {
                throw new InvalidDataException(string.Format("The document is missing the Projects flat file"));
            }
            if (monitoringFile == null)
            {
                throw new InvalidDataException(string.Format("The document is missing the Monitoring Locations flat file"));
            }
            if (resultsFile == null)
            {
                throw new InvalidDataException(string.Format("The document is missing the Results flat file"));
            }

            StringBuilder sb = new StringBuilder("Located flat file(s): ");
            bool addedAny = false;
            if (projectsFile != null)
            {
                sb.AppendFormat("Projects ({0})", Path.GetFileName(projectsFile));
                addedAny = true;
            }
            if (monitoringFile != null)
            {
                if (addedAny) sb.Append(", ");
                sb.AppendFormat("Monitoring Locations ({0})", Path.GetFileName(monitoringFile));
                addedAny = true;
            }
            if (resultsFile != null)
            {
                if (addedAny) sb.Append(", ");
                sb.AppendFormat(" Results ({0})", Path.GetFileName(resultsFile));
                addedAny = true;
            }
            AppendAuditLogEvent(sb.ToString());
        }
        protected string FindFirstFileStringThatContains(IEnumerable<string> strings, string contains)
        {
            foreach (string text in strings)
            {
                string testString = Path.GetFileName(text);
                if (testString.IndexOf(contains, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    return text;
                }
            }
            return null;
        }
        protected Dictionary<string, MonitoringLocationDataType> ParseMonitoringLocations(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }
            Dictionary<string, MonitoringLocationDataType> monitoringLocations = null;

            using (TabSeparatedFileParser parser = GetParser(filePath))
            {
                bool isHabitat = parser.HasColumn("Monitoring Location Identifier");
                while (parser.NextLine())
                {
                    MonitoringLocationDataType monitoringLocation = new MonitoringLocationDataType();
                    monitoringLocation.MonitoringLocationIdentity = new MonitoringLocationIdentityDataType();
                    monitoringLocation.MonitoringLocationIdentity.MonitoringLocationIdentifier =
                        GetNonEmptyMonitoringString(parser, isHabitat ? "Monitoring Location Identifier" : "Monitoring Location ID");
                    monitoringLocation.MonitoringLocationIdentity.MonitoringLocationName =
                        GetNonEmptyMonitoringString(parser, "Monitoring Location Name");
                    monitoringLocation.MonitoringLocationIdentity.MonitoringLocationTypeName =
                        GetNonEmptyMonitoringString(parser, isHabitat ? "Monitoring Location Type Name" : "Monitoring Location Type");
                    monitoringLocation.MonitoringLocationIdentity.HUCEightDigitCode =
                        GetMonitoringString(parser, isHabitat ? "HUC Eight Digit Code" : "HUC Eight-Digit Code");
                    monitoringLocation.MonitoringLocationIdentity.TribalLandIndicator =
                        GetMonitoringBool(parser, "Tribal Land Indicator", out monitoringLocation.MonitoringLocationIdentity.TribalLandIndicatorSpecified);
                    monitoringLocation.MonitoringLocationIdentity.TribalLandName =
                        GetMonitoringString(parser, "Tribal Land Name");
                    monitoringLocation.MonitoringLocationGeospatial = new MonitoringLocationGeospatialDataType();
                    monitoringLocation.MonitoringLocationGeospatial.LatitudeMeasure =
                        GetMonitoringDecimal(parser, isHabitat ? "Latitude Measure" : "Monitoring Location Latitude");
                    monitoringLocation.MonitoringLocationGeospatial.LongitudeMeasure =
                        GetMonitoringDecimal(parser, isHabitat ? "Longitude Measure" : "Monitoring Location Longitude");
                    monitoringLocation.MonitoringLocationGeospatial.SourceMapScaleNumeric =
                        GetMonitoringString(parser, isHabitat ? "Source Map Scale Numeric" : "Monitoring Location Source Map Scale");
                    monitoringLocation.MonitoringLocationGeospatial.HorizontalCollectionMethodName =
                        GetNonEmptyMonitoringString(parser, isHabitat ? "Horizontal Collection Method Name" : "Monitoring Location Horizontal Collection Method");
                    monitoringLocation.MonitoringLocationGeospatial.HorizontalCoordinateReferenceSystemDatumName =
                        GetNonEmptyMonitoringString(parser, isHabitat ? "Horizontal Coordinate Reference System Datum Name" : "Monitoring Location Horizontal Coordinate Reference System");
                    monitoringLocation.MonitoringLocationGeospatial.StateCode =
                        GetMonitoringString(parser, "State Code");
                    monitoringLocation.MonitoringLocationGeospatial.CountyCode =
                        GetMonitoringString(parser, "County Code");
                    if (monitoringLocations == null)
                    {
                        monitoringLocations = new Dictionary<string, MonitoringLocationDataType>();
                    }
                    if (monitoringLocations.ContainsKey(monitoringLocation.MonitoringLocationIdentity.MonitoringLocationIdentifier))
                    {
                        throw new InvalidDataException(string.Format("The {0} flat file contains more than one {0} with id \"{1}\"",
                                                                     cMonitoringTypeName, monitoringLocation.MonitoringLocationIdentity.MonitoringLocationIdentifier));
                    }
                    monitoringLocations[monitoringLocation.MonitoringLocationIdentity.MonitoringLocationIdentifier] = monitoringLocation;
                }
            }
            return monitoringLocations;
        }
        protected Dictionary<string, ProjectDataType> ParseProjects(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }
            Dictionary<string, ProjectDataType> projects = null;
            using (TabSeparatedFileParser parser = GetParser(filePath))
            {
                while (parser.NextLine())
                {
                    ProjectDataType project = new ProjectDataType();
                    if (parser.HasColumn("Project ID"))
                    {
                        // Physical
                        project.ProjectIdentifier = GetNonEmptyProjectString(parser, "Project ID");
                        project.ProjectName = GetNonEmptyProjectString(parser, "Project Name");
                        project.ProjectDescriptionText = GetProjectString(parser, "Project Description");
                    }
                    else
                    {
                        // Biological, Habitat
                        project.ProjectIdentifier = GetNonEmptyProjectString(parser, "Project");
                        project.ProjectName = GetNonEmptyProjectString(parser, "Project Name");
                        project.ProjectDescriptionText = GetProjectString(parser, "Project Description Text");
                    }
                    if (projects == null)
                    {
                        projects = new Dictionary<string, ProjectDataType>();
                    }
                    if (projects.ContainsKey(project.ProjectIdentifier))
                    {
                        throw new InvalidDataException(string.Format("The {0} flat file contains more than one {0} with id \"{1}\"",
                                                                     cProjectTypeName, project.ProjectIdentifier));
                    }
                    projects[project.ProjectIdentifier] = project;
                }
            }
            return projects;
        }
        protected Dictionary<string, ActivityDataType> ParseResults(string filePath, Dictionary<string, ProjectDataType> projects,
                                                                    Dictionary<string, MonitoringLocationDataType> monitoringLocations)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }
            Dictionary<string, ActivityDataType> activites = new Dictionary<string, ActivityDataType>();
            Dictionary<string, List<string>> activityIdToProjectIdList = new Dictionary<string, List<string>>();
            Dictionary<string, List<ResultDataType>> activityIdToResultList = new Dictionary<string, List<ResultDataType>>();
            using (TabSeparatedFileParser parser = GetParser(filePath))
            {
                // PHYSICAL COLUMNS:
                // Project ID	Monitoring Location ID	Activity ID	Activity Type 	Activity Media Name	Activity Start Date	Activity Start Time	Activity Start Time Zone 	Activity Depth/Height Measure	Activity Depth/Height Unit	Sample Collection Method ID	Sample Collection Equipment Name	Sample Collection Equipment Comment 	Data Logger Line	Characteristic Name	Method Speciation Name	Result Detection Condition 	Result Measure 	Result Unit 	Result Sample Fraction 	Result Status ID	Statistical Base Code	Result Value Type 	Result Analytical Method ID	Result Analytical Method Context	Analysis Start Date	Result Detection/Quantitation Limit Type 	Result Detection/Quantitation Limit Measure 	Result Detection Quantitation Limit Unit	Result Comment
                // BIOLOGICAL COLUMNS:
                // Project ID	Monitoring Location ID	Activity ID	Activity Type 	Activity Media Name	Activity Start Date	Activity Start Time	Activity Start Time Zone 	Activity Depth/Height Measure	Activity Depth/Height Unit	Assemblage Sampled Name	Collection Duration Measure 	Collection Duration Unit	Sampling Component Name	Sampling Component Place in Series	Reach Length Measure 	Reach Length Measure Unit Code 	Reach Width Measure 	Reach Width Measure Unit Code	Sample Collection Method ID	Sample Collection Equipment Name	Sample Collection Equipment Comment 	Characteristic Name	Result Detection Condition 	Result Measure Value	Result Measure Unit Code 	Result Sample Fraction	Result Status ID	Statistical Base Code	Result Value Type 	Result Weight Basis Text	Result Sampling Point Name	Biological Intent	Biological Individual Identifier	Subject Taxonomic Name	Unidentified Species Identifier	Sample Tissue Anatomy Name	Group Summary Count Weight Measure Value	Group Summary Count Weight Measure Unit Code	Frequency Class Descriptor Code	Frequency Class Descriptor Unit Code	Lower Class Bound Value	Upper Class Bound Value	Taxon Cell Form	Taxon Cell Shape	Taxon Habit	Taxon Voltinism	Taxon Pollution Tolerance	Taxon Pollution Tolerance Scale	Taxon Trophic Level	Taxon Functional Feeding Group	Result Analytical Method ID	Result Analytical Method Context	Analysis Start Date	Result Detection/Quantitation Limit Type 	Result Detection/Quantitation Limit Measure 	Result Detection Quantitation Limit Unit	Laboratory Name	Taxon Citation ID	Result Comment
                // HABITAT COLUMNS:
                // Project Identifier	Monitoring Location Identifier	Activity ID	Activity Type Code	Activity Media Name	Activity Start Date	Activity Start Time	Activity Start Time Zone Code	Sampling Component Name	Sampling Component Place in Series	Reach Length Measure Value	Reach Length Measure Unit Code	Reach Width Measure Value	Reach Width Measure Unit Code	Sample Collection Method Identifier	Sample Collection Equipment Name	Sample Collection Equipment Comment Text	Characteristic Name	Result Detection Condition Text	Result Measure Value	Result Measure Unit Code	Result Sample Fraction Text	Result Status Identifier	Result Statistical Base Code	Result Value Type Name	Result Analytical Method Identifier	Result Analytical Method Identifier Context	Analysis Start Date	Detection Quantitation Limit Type Name	Detection Quantitation Limit Measure Value	Detection Quantitation Limit Measure Unit Code	Result Sampling Point Name	Result Comment Text

                if ( parser.HasColumn("Data Logger Line"))
                {
                    ParsePhysicalResults(parser, projects, monitoringLocations, activites, activityIdToProjectIdList,
                                         activityIdToResultList);
                }
                else if (parser.HasColumn("Assemblage Sampled Name"))
                {
                    ParseBiologicalResults(parser, projects, monitoringLocations, activites, activityIdToProjectIdList,
                                           activityIdToResultList);
                }
                else
                {
                    ParseHabitatResults(parser, projects, monitoringLocations, activites, activityIdToProjectIdList,
                                        activityIdToResultList);
                }
            }
            foreach (ActivityDataType activity in activites.Values)
            {
                List<string> projectIdList;
                if (activityIdToProjectIdList.TryGetValue(activity.ActivityDescription.ActivityIdentifier, out projectIdList))
                {
                    activity.ActivityDescription.ProjectIdentifier = projectIdList.ToArray();
                }
                List<ResultDataType> resultList;
                if (activityIdToResultList.TryGetValue(activity.ActivityDescription.ActivityIdentifier, out resultList))
                {
                    activity.Result = resultList.ToArray();
                }
            }
            return activites;
        }
        protected void ParsePhysicalResults(TabSeparatedFileParser parser, Dictionary<string, ProjectDataType> projects,
                                            Dictionary<string, MonitoringLocationDataType> monitoringLocations,
                                            Dictionary<string, ActivityDataType> activites,
                                            Dictionary<string, List<string>> activityIdToProjectIdList,
                                            Dictionary<string, List<ResultDataType>> activityIdToResultList)
        {
            // PHYSICAL COLUMNS:
            // Project ID	Monitoring Location ID	Activity ID	Activity Type 	Activity Media Name	Activity Start Date	Activity Start Time	Activity Start Time Zone 	Activity Depth/Height Measure	Activity Depth/Height Unit	Sample Collection Method ID	Sample Collection Equipment Name	Sample Collection Equipment Comment 	Data Logger Line	Characteristic Name	Method Speciation Name	Result Detection Condition 	Result Measure 	Result Unit 	Result Sample Fraction 	Result Status ID	Statistical Base Code	Result Value Type 	Result Analytical Method ID	Result Analytical Method Context	Analysis Start Date	Result Detection/Quantitation Limit Type 	Result Detection/Quantitation Limit Measure 	Result Detection Quantitation Limit Unit	Result Comment

            while (parser.NextLine())
            {
                string projectId = GetNonEmptyResultString(parser, "Project ID");
                string monitoringId = GetResultString(parser, "Monitoring Location ID");
                string activityId = GetNonEmptyResultString(parser, "Activity ID");
                if (!projects.ContainsKey(projectId))
                {
                    throw new InvalidDataException(string.Format("The {0} flat file contains an activity with id \"{1}\" that references a missing project with id \"{2}\"",
                                                                 cResultTypeName, activityId, projectId));
                }
                if (!string.IsNullOrEmpty(monitoringId) && !monitoringLocations.ContainsKey(monitoringId))
                {
                    throw new InvalidDataException(string.Format("The {0} flat file contains an activity with id \"{1}\" that references a missing monitoring location with id \"{2}\"",
                                                                 cResultTypeName, activityId, projectId));
                }

                ActivityDataType activity = new ActivityDataType();
                activity.ActivityDescription = new ActivityDescriptionDataType();
                activity.ActivityDescription.ActivityIdentifier = activityId;
                activity.ActivityDescription.ActivityTypeCode = GetNonEmptyResultString(parser, "Activity Type");
                activity.ActivityDescription.ActivityMediaName = GetNonEmptyResultString(parser, "Activity Media Name");
                activity.ActivityDescription.ActivityStartDate = GetResultDate(parser, "Activity Start Date");
                activity.ActivityDescription.ActivityStartTime = GetResultTime(parser, "Activity Start Time", "Activity Start Time Zone");
                activity.ActivityDescription.ActivityDepthHeightMeasure = GetResultMeasureCompact(parser, "Activity Depth/Height Measure", "Activity Depth/Height Unit");
                activity.ActivityDescription.MonitoringLocationIdentifier = monitoringId;
                activity.SampleDescription = GetResultSample(parser, "Sample Collection Method ID", "Sample Collection Equipment Name",
                                                             "Sample Collection Equipment Comment");

                ActivityDataType activity2;
                if (activites.TryGetValue(activityId, out activity2))
                {
                    string notEqualString = ActivitiesAreEqual(activity, activity2);
                    if (notEqualString != null)
                    {
                        throw new InvalidDataException(string.Format("Two activities have the same identifier \"{0},\" but do not have the same value(s): {1} at line {2}",
                                                                     activityId, notEqualString, parser.LineNumber.ToString()));
                    }
                    activity = activity2;
                }
                else
                {
                    activites[activityId] = activity;
                }

                ResultDataType result = new ResultDataType();
                result.ResultDescription = new ResultDescriptionDataType();
                result.ResultDescription.DataLoggerLineName = GetResultString(parser, "Data Logger Line");
                result.ResultDescription.CharacteristicName = GetResultString(parser, "Characteristic Name");
                result.ResultDescription.MethodSpeciationName = GetResultString(parser, "Method Speciation Name");
                result.ResultDescription.ResultDetectionConditionText = GetResultString(parser, "Result Detection Condition");
                result.ResultDescription.ResultMeasure = GetResultMeasure(parser, "Result Measure", "Result Unit");
                result.ResultDescription.ResultSampleFractionText = GetResultString(parser, "Result Sample Fraction");
                result.ResultDescription.ResultStatusIdentifier = GetResultString(parser, "Result Status ID");
                result.ResultDescription.StatisticalBaseCode = GetResultString(parser, "Statistical Base Code");
                result.ResultDescription.ResultValueTypeName = GetResultString(parser, "Result Value Type");
                result.ResultDescription.ResultCommentText = GetResultString(parser, "Result Comment");
                result.ResultAnalyticalMethod = GetResultAnalyticalMethod(parser, "Result Analytical Method ID", "Result Analytical Method Context");
                result.ResultLabInformation = new ResultLabInformationDataType();
                result.ResultLabInformation.AnalysisStartDate = GetResultDate(parser, "Analysis Start Date", out result.ResultLabInformation.AnalysisStartDateSpecified);
                result.ResultLabInformation.ResultDetectionQuantitationLimit = GetDetectionQuantitationLimit(parser, "Result Detection/Quantitation Limit Type",
                                                                                                             "Result Detection/Quantitation Limit Measure",
                                                                                                             "Result Detection Quantitation Limit Unit");
                if (!result.ResultLabInformation.AnalysisStartDateSpecified && (result.ResultLabInformation.ResultDetectionQuantitationLimit == null))
                {
                    result.ResultLabInformation = null;
                }
                if (string.IsNullOrEmpty(result.ResultDescription.DataLoggerLineName) &&
                     string.IsNullOrEmpty(result.ResultDescription.CharacteristicName) &&
                     string.IsNullOrEmpty(result.ResultDescription.MethodSpeciationName) &&
                     string.IsNullOrEmpty(result.ResultDescription.ResultDetectionConditionText) &&
                     (result.ResultDescription.ResultMeasure == null) &&
                     string.IsNullOrEmpty(result.ResultDescription.ResultSampleFractionText) &&
                     string.IsNullOrEmpty(result.ResultDescription.ResultStatusIdentifier) &&
                     string.IsNullOrEmpty(result.ResultDescription.StatisticalBaseCode) &&
                     string.IsNullOrEmpty(result.ResultDescription.ResultValueTypeName) &&
                     string.IsNullOrEmpty(result.ResultDescription.ResultCommentText))
                {
                    result.ResultDescription = null;
                }
                if ((result.ResultDescription == null) && (result.ResultAnalyticalMethod == null) &&
                     (result.ResultLabInformation == null))
                {
                    throw new InvalidDataException(string.Format("An empty result was specified on line {0} for activity \"{1}\"",
                                                                 parser.LineNumber.ToString(), activityId));
                }

                List<ResultDataType> resultList;
                if (!activityIdToResultList.TryGetValue(activityId, out resultList))
                {
                    resultList = new List<ResultDataType>();
                    activityIdToResultList[activityId] = resultList;
                }
                resultList.Add(result);

                List<string> projectIdList;
                if (activityIdToProjectIdList.TryGetValue(activityId, out projectIdList))
                {
                    if (!projectIdList.Contains(projectId))
                    {
                        projectIdList.Add(projectId);
                    }
                }
                else
                {
                    projectIdList = new List<string>();
                    projectIdList.Add(projectId);
                    activityIdToProjectIdList[activityId] = projectIdList;
                }
            }
        }
        protected void ParseBiologicalResults(TabSeparatedFileParser parser, Dictionary<string, ProjectDataType> projects,
                                              Dictionary<string, MonitoringLocationDataType> monitoringLocations,
                                              Dictionary<string, ActivityDataType> activites,
                                              Dictionary<string, List<string>> activityIdToProjectIdList,
                                              Dictionary<string, List<ResultDataType>> activityIdToResultList)
        {
            // BIOLOGICAL COLUMNS:
            // Project ID	Monitoring Location ID	Activity ID	Activity Type 	Activity Media Name	Activity Start Date	Activity Start Time	Activity Start Time Zone 	Activity Depth/Height Measure	Activity Depth/Height Unit	Assemblage Sampled Name	Collection Duration Measure 	Collection Duration Unit	Sampling Component Name	Sampling Component Place in Series	Reach Length Measure 	Reach Length Measure Unit Code 	Reach Width Measure 	Reach Width Measure Unit Code	Sample Collection Method ID	Sample Collection Equipment Name	Sample Collection Equipment Comment 	Characteristic Name	Result Detection Condition 	Result Measure Value	Result Measure Unit Code 	Result Sample Fraction	Result Status ID	Statistical Base Code	Result Value Type 	Result Weight Basis Text	Result Sampling Point Name	Biological Intent	Biological Individual Identifier	Subject Taxonomic Name	Unidentified Species Identifier	Sample Tissue Anatomy Name	Group Summary Count Weight Measure Value	Group Summary Count Weight Measure Unit Code	Frequency Class Descriptor Code	Frequency Class Descriptor Unit Code	Lower Class Bound Value	Upper Class Bound Value	Taxon Cell Form	Taxon Cell Shape	Taxon Habit	Taxon Voltinism	Taxon Pollution Tolerance	Taxon Pollution Tolerance Scale	Taxon Trophic Level	Taxon Functional Feeding Group	Result Analytical Method ID	Result Analytical Method Context	Analysis Start Date	Result Detection/Quantitation Limit Type 	Result Detection/Quantitation Limit Measure 	Result Detection Quantitation Limit Unit	Laboratory Name	Taxon Citation ID	Result Comment

            while (parser.NextLine())
            {
                string projectId = GetNonEmptyResultString(parser, "Project ID");
                string monitoringId = GetResultString(parser, "Monitoring Location ID");
                string activityId = GetNonEmptyResultString(parser, "Activity ID");
                if (!projects.ContainsKey(projectId))
                {
                    throw new InvalidDataException(string.Format("The {0} flat file contains an activity with id \"{1}\" that references a missing project with id \"{2}\"",
                                                                 cResultTypeName, activityId, projectId));
                }
                if (!string.IsNullOrEmpty(monitoringId) && !monitoringLocations.ContainsKey(monitoringId))
                {
                    throw new InvalidDataException(string.Format("The {0} flat file contains an activity with id \"{1}\" that references a missing monitoring location with id \"{2}\"",
                                                                 cResultTypeName, activityId, projectId));
                }
                ActivityDataType activity = new ActivityDataType();
                activity.ActivityDescription = new ActivityDescriptionDataType();
                activity.ActivityDescription.ActivityIdentifier = activityId;
                activity.ActivityDescription.ActivityTypeCode = GetNonEmptyResultString(parser, "Activity Type");
                activity.ActivityDescription.ActivityMediaName = GetNonEmptyResultString(parser, "Activity Media Name");
                activity.ActivityDescription.ActivityStartDate = GetResultDate(parser, "Activity Start Date");
                activity.ActivityDescription.ActivityStartTime = GetResultTime(parser, "Activity Start Time", "Activity Start Time Zone");
                activity.ActivityDescription.ActivityDepthHeightMeasure = GetResultMeasureCompact(parser, "Activity Depth/Height Measure", "Activity Depth/Height Unit");
                activity.ActivityDescription.MonitoringLocationIdentifier = monitoringId;

                activity.BiologicalActivityDescription = new BiologicalActivityDescriptionDataType();
                activity.BiologicalActivityDescription.AssemblageSampledName = GetResultString(parser, "Assemblage Sampled Name");
                
                activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation = new BiologicalHabitatCollectionInformationDataType();
                activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.CollectionDuration =
                    GetResultMeasureCompact(parser, "Collection Duration Measure", "Collection Duration Unit");
                activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.SamplingComponentName = GetResultString(parser, "Sampling Component Name");
                activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.SamplingComponentPlaceInSeriesNumeric = GetResultString(parser, "Sampling Component Place in Series");
                activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.ReachLengthMeasure =
                    GetResultMeasureCompact(parser, "Reach Length Measure", "Reach Length Measure Unit Code");
                activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.ReachWidthMeasure =
                    GetResultMeasureCompact(parser, "Reach Width Measure", "Reach Width Measure Unit Code");

                if (string.IsNullOrEmpty(activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.SamplingComponentName) &&
                     string.IsNullOrEmpty(activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.SamplingComponentPlaceInSeriesNumeric) &&
                     (activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.CollectionDuration == null) &&
                     (activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.ReachLengthMeasure == null) &&
                     (activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.ReachWidthMeasure == null))
                {
                    activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation = null;
                }
                if (string.IsNullOrEmpty(activity.BiologicalActivityDescription.AssemblageSampledName) &&
                    (activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation == null))
                {
                    activity.BiologicalActivityDescription = null;
                }

                activity.SampleDescription = GetResultSample(parser, "Sample Collection Method ID", "Sample Collection Equipment Name",
                                                             "Sample Collection Equipment Comment");

                ActivityDataType activity2;
                if (activites.TryGetValue(activityId, out activity2))
                {
                    string notEqualString = ActivitiesAreEqual(activity, activity2);
                    if (notEqualString != null)
                    {
                        throw new InvalidDataException(string.Format("Two activities have the same identifier \"{0},\" but do not have the same value(s): {1} at line {2}",
                                                                     activityId, notEqualString, parser.LineNumber.ToString()));
                    }
                    activity = activity2;
                }
                else
                {
                    activites[activityId] = activity;
                }

                ResultDataType result = new ResultDataType();
                result.ResultDescription = new ResultDescriptionDataType();
                result.ResultDescription.CharacteristicName = GetResultString(parser, "Characteristic Name");
                result.ResultDescription.ResultDetectionConditionText = GetResultString(parser, "Result Detection Condition");
                result.ResultDescription.ResultMeasure = GetResultMeasure(parser, "Result Measure Value", "Result Measure Unit Code");
                result.ResultDescription.ResultSampleFractionText = GetResultString(parser, "Result Sample Fraction");
                result.ResultDescription.ResultStatusIdentifier = GetResultString(parser, "Result Status ID");
                result.ResultDescription.StatisticalBaseCode = GetResultString(parser, "Statistical Base Code");
                result.ResultDescription.ResultValueTypeName = GetResultString(parser, "Result Value Type");
                result.ResultDescription.ResultWeightBasisText = GetResultString(parser, "Result Weight Basis Text");
                result.ResultDescription.ResultSamplingPointName = GetResultString(parser, "Result Sampling Point Name");
                result.ResultDescription.ResultCommentText = GetResultString(parser, "Result Comment");
                
                if (string.IsNullOrEmpty(result.ResultDescription.CharacteristicName) &&
                     string.IsNullOrEmpty(result.ResultDescription.ResultDetectionConditionText) &&
                     (result.ResultDescription.ResultMeasure == null) &&
                     string.IsNullOrEmpty(result.ResultDescription.ResultSampleFractionText) &&
                     string.IsNullOrEmpty(result.ResultDescription.ResultStatusIdentifier) &&
                     string.IsNullOrEmpty(result.ResultDescription.StatisticalBaseCode) &&
                     string.IsNullOrEmpty(result.ResultDescription.ResultValueTypeName) &&
                     string.IsNullOrEmpty(result.ResultDescription.ResultWeightBasisText) &&
                     string.IsNullOrEmpty(result.ResultDescription.ResultSamplingPointName) &&
                     string.IsNullOrEmpty(result.ResultDescription.ResultCommentText))
                {
                    result.ResultDescription = null;
                }

                result.BiologicalResultDescription = new BiologicalResultDescriptionDataType();
                result.BiologicalResultDescription.BiologicalIntentName = GetResultString(parser, "Biological Intent");
                result.BiologicalResultDescription.BiologicalIndividualIdentifier = GetResultString(parser, "Biological Individual Identifier");
                result.BiologicalResultDescription.SubjectTaxonomicName = GetResultString(parser, "Subject Taxonomic Name");
                result.BiologicalResultDescription.UnidentifiedSpeciesIdentifier = GetResultString(parser, "Unidentified Species Identifier");
                result.BiologicalResultDescription.SampleTissueAnatomyName = GetResultString(parser, "Sample Tissue Anatomy Name");
                result.BiologicalResultDescription.GroupSummaryCountWeight =
                    GetResultMeasureCompact(parser, "Group Summary Count Weight Measure Value", "Group Summary Count Weight Measure Unit Code");
                
                result.BiologicalResultDescription.FrequencyClassInformation = new FrequencyClassInformationDataType();
                result.BiologicalResultDescription.FrequencyClassInformation.FrequencyClassDescriptorCode = GetResultString(parser, "Frequency Class Descriptor Code");
                result.BiologicalResultDescription.FrequencyClassInformation.FrequencyClassDescriptorUnitCode = GetResultString(parser, "Frequency Class Descriptor Unit Code");
                result.BiologicalResultDescription.FrequencyClassInformation.LowerClassBoundValue = GetResultString(parser, "Lower Class Bound Value");
                result.BiologicalResultDescription.FrequencyClassInformation.UpperClassBoundValue = GetResultString(parser, "Upper Class Bound Value");
                if (string.IsNullOrEmpty(result.BiologicalResultDescription.FrequencyClassInformation.FrequencyClassDescriptorCode) &&
                     string.IsNullOrEmpty(result.BiologicalResultDescription.FrequencyClassInformation.FrequencyClassDescriptorUnitCode) &&
                     string.IsNullOrEmpty(result.BiologicalResultDescription.FrequencyClassInformation.LowerClassBoundValue) &&
                     string.IsNullOrEmpty(result.BiologicalResultDescription.FrequencyClassInformation.UpperClassBoundValue))
                {
                    result.BiologicalResultDescription.FrequencyClassInformation = null;
                }
                
                result.BiologicalResultDescription.TaxonomicDetails = new TaxonomicDetailsDataType();
                result.BiologicalResultDescription.TaxonomicDetails.CellFormName = GetResultString(parser, "Taxon Cell Form");
                result.BiologicalResultDescription.TaxonomicDetails.CellShapeName = GetResultString(parser, "Taxon Cell Shape");
                result.BiologicalResultDescription.TaxonomicDetails.HabitName = GetResultString(parser, "Taxon Habit");
                result.BiologicalResultDescription.TaxonomicDetails.VoltinismName = GetResultString(parser, "Taxon Voltinism");
                result.BiologicalResultDescription.TaxonomicDetails.TaxonomicPollutionTolerance = GetResultString(parser, "Taxon Pollution Tolerance");
                result.BiologicalResultDescription.TaxonomicDetails.TaxonomicPollutionToleranceScaleText = GetResultString(parser, "Taxon Pollution Tolerance Scale");
                result.BiologicalResultDescription.TaxonomicDetails.TrophicLevelName = GetResultString(parser, "Taxon Trophic Level");
                result.BiologicalResultDescription.TaxonomicDetails.FunctionalFeedingGroupName = GetResultString(parser, "Taxon Functional Feeding Group");
                if (string.IsNullOrEmpty(result.BiologicalResultDescription.TaxonomicDetails.CellFormName) &&
                     string.IsNullOrEmpty(result.BiologicalResultDescription.TaxonomicDetails.CellShapeName) &&
                     string.IsNullOrEmpty(result.BiologicalResultDescription.TaxonomicDetails.HabitName) &&
                     string.IsNullOrEmpty(result.BiologicalResultDescription.TaxonomicDetails.VoltinismName) &&

                     string.IsNullOrEmpty(result.BiologicalResultDescription.TaxonomicDetails.TaxonomicPollutionTolerance) &&
                     string.IsNullOrEmpty(result.BiologicalResultDescription.TaxonomicDetails.TaxonomicPollutionToleranceScaleText) &&
                     string.IsNullOrEmpty(result.BiologicalResultDescription.TaxonomicDetails.TrophicLevelName) &&
                     string.IsNullOrEmpty(result.BiologicalResultDescription.TaxonomicDetails.FunctionalFeedingGroupName))
                {
                    result.BiologicalResultDescription.TaxonomicDetails = null;
                }
                if (string.IsNullOrEmpty(result.BiologicalResultDescription.BiologicalIntentName) &&
                    string.IsNullOrEmpty(result.BiologicalResultDescription.BiologicalIndividualIdentifier) &&
                    string.IsNullOrEmpty(result.BiologicalResultDescription.SubjectTaxonomicName) &&
                    string.IsNullOrEmpty(result.BiologicalResultDescription.UnidentifiedSpeciesIdentifier) &&
                    string.IsNullOrEmpty(result.BiologicalResultDescription.SampleTissueAnatomyName) &&
                    (result.BiologicalResultDescription.GroupSummaryCountWeight == null) &&
                    (result.BiologicalResultDescription.FrequencyClassInformation == null) &&
                    (result.BiologicalResultDescription.TaxonomicDetails == null))
                {
                    result.BiologicalResultDescription = null;
                }

                // What is this: Taxon Citation ID?
                result.ResultAnalyticalMethod = new ResultAnalyticalMethodDataType();
                result.ResultAnalyticalMethod.MethodIdentifier = GetResultString(parser, "Result Analytical Method ID");
                result.ResultAnalyticalMethod.MethodIdentifierContext = GetResultString(parser, "Result Analytical Method Context");
                if (string.IsNullOrEmpty(result.ResultAnalyticalMethod.MethodIdentifier) &&
                     string.IsNullOrEmpty(result.ResultAnalyticalMethod.MethodIdentifierContext))
                {
                    result.ResultAnalyticalMethod = null;
                }

                result.ResultLabInformation = new ResultLabInformationDataType();
                result.ResultLabInformation.AnalysisStartDate = GetResultDate(parser, "Analysis Start Date", out result.ResultLabInformation.AnalysisStartDateSpecified);
                result.ResultLabInformation.ResultDetectionQuantitationLimit = GetDetectionQuantitationLimit(parser, "Result Detection/Quantitation Limit Type",
                                                                                                             "Result Detection/Quantitation Limit Measure",
                                                                                                             "Result Detection Quantitation Limit Unit");
                result.ResultLabInformation.LaboratoryName = GetResultString(parser, "Laboratory Name");

                if (!result.ResultLabInformation.AnalysisStartDateSpecified && (result.ResultLabInformation.ResultDetectionQuantitationLimit == null) &&
                    string.IsNullOrEmpty(result.ResultLabInformation.LaboratoryName))
                {
                    result.ResultLabInformation = null;
                }
                if ((result.ResultDescription == null) && (result.BiologicalResultDescription == null) &&
                    (result.ResultAnalyticalMethod == null) && (result.ResultLabInformation == null))
                {
                    throw new InvalidDataException(string.Format("An empty result was specified on line {0} for activity \"{1}\"",
                                                                 parser.LineNumber.ToString(), activityId));
                }

                List<ResultDataType> resultList;
                if (!activityIdToResultList.TryGetValue(activityId, out resultList))
                {
                    resultList = new List<ResultDataType>();
                    activityIdToResultList[activityId] = resultList;
                }
                resultList.Add(result);

                List<string> projectIdList;
                if (activityIdToProjectIdList.TryGetValue(activityId, out projectIdList))
                {
                    if (!projectIdList.Contains(projectId))
                    {
                        projectIdList.Add(projectId);
                    }
                }
                else
                {
                    projectIdList = new List<string>();
                    projectIdList.Add(projectId);
                    activityIdToProjectIdList[activityId] = projectIdList;
                }
            }
        }
        protected void ParseHabitatResults(TabSeparatedFileParser parser, Dictionary<string, ProjectDataType> projects,
                                           Dictionary<string, MonitoringLocationDataType> monitoringLocations,
                                           Dictionary<string, ActivityDataType> activites,
                                           Dictionary<string, List<string>> activityIdToProjectIdList,
                                           Dictionary<string, List<ResultDataType>> activityIdToResultList)
        {
            // HABITAT COLUMNS:
            // Project Identifier	Monitoring Location Identifier	Activity ID	Activity Type Code	Activity Media Name	Activity Start Date	Activity Start Time	Activity Start Time Zone Code	Sampling Component Name	Sampling Component Place in Series	Reach Length Measure Value	Reach Length Measure Unit Code	Reach Width Measure Value	Reach Width Measure Unit Code	Sample Collection Method Identifier	Sample Collection Equipment Name	Sample Collection Equipment Comment Text	Characteristic Name	Result Detection Condition Text	Result Measure Value	Result Measure Unit Code	Result Sample Fraction Text	Result Status Identifier	Result Statistical Base Code	Result Value Type Name	Result Analytical Method Identifier	Result Analytical Method Identifier Context	Analysis Start Date	Detection Quantitation Limit Type Name	Detection Quantitation Limit Measure Value	Detection Quantitation Limit Measure Unit Code	Result Sampling Point Name	Result Comment Text

            while (parser.NextLine())
            {
                string projectId = GetNonEmptyResultString(parser, "Project Identifier");
                string monitoringId = GetResultString(parser, "Monitoring Location Identifier");
                string activityId = GetNonEmptyResultString(parser, "Activity ID");
                if (!projects.ContainsKey(projectId))
                {
                    throw new InvalidDataException(string.Format("The {0} flat file contains an activity with id \"{1}\" that references a missing project with id \"{2}\"",
                                                                 cResultTypeName, activityId, projectId));
                }
                if (!string.IsNullOrEmpty(monitoringId) && !monitoringLocations.ContainsKey(monitoringId))
                {
                    throw new InvalidDataException(string.Format("The {0} flat file contains an activity with id \"{1}\" that references a missing monitoring location with id \"{2}\"",
                                                                 cResultTypeName, activityId, projectId));
                }
                ActivityDataType activity = new ActivityDataType();
                activity.ActivityDescription = new ActivityDescriptionDataType();
                activity.ActivityDescription.ActivityIdentifier = activityId;
                activity.ActivityDescription.ActivityTypeCode = GetNonEmptyResultString(parser, "Activity Type Code");
                activity.ActivityDescription.ActivityMediaName = GetNonEmptyResultString(parser, "Activity Media Name");
                activity.ActivityDescription.ActivityStartDate = GetResultDate(parser, "Activity Start Date");
                activity.ActivityDescription.ActivityStartTime = GetResultTime(parser, "Activity Start Time", "Activity Start Time Zone Code");

                activity.BiologicalActivityDescription = new BiologicalActivityDescriptionDataType();
                activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation = new BiologicalHabitatCollectionInformationDataType();
                activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.SamplingComponentName = GetResultString(parser, "Sampling Component Name");
                activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.SamplingComponentPlaceInSeriesNumeric = GetResultString(parser, "Sampling Component Place in Series");
                activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.ReachLengthMeasure =
                    GetResultMeasureCompact(parser, "Reach Length Measure Value", "Reach Length Measure Unit Code");
                activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.ReachWidthMeasure =
                    GetResultMeasureCompact(parser, "Reach Width Measure Value", "Reach Width Measure Unit Code");

                if (string.IsNullOrEmpty(activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.SamplingComponentName) &&
                     string.IsNullOrEmpty(activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.SamplingComponentPlaceInSeriesNumeric) &&
                     (activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.CollectionDuration == null) &&
                     (activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.ReachLengthMeasure == null) &&
                     (activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.ReachWidthMeasure == null))
                {
                    activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation = null;
                }
                if ((activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation == null))
                {
                    activity.BiologicalActivityDescription = null;
                }

                activity.SampleDescription = GetResultSample(parser, "Sample Collection Method Identifier", "Sample Collection Equipment Name",
                                                             "Sample Collection Equipment Comment Text");

                ActivityDataType activity2;
                if (activites.TryGetValue(activityId, out activity2))
                {
                    string notEqualString = ActivitiesAreEqual(activity, activity2);
                    if (notEqualString != null)
                    {
                        throw new InvalidDataException(string.Format("Two activities have the same identifier \"{0},\" but do not have the same value(s): {1} at line {2}",
                                                                     activityId, notEqualString, parser.LineNumber.ToString()));
                    }
                    activity = activity2;
                }
                else
                {
                    activites[activityId] = activity;
                }

                ResultDataType result = new ResultDataType();
                result.ResultDescription = new ResultDescriptionDataType();
                result.ResultDescription.CharacteristicName = GetResultString(parser, "Characteristic Name");
                result.ResultDescription.ResultDetectionConditionText = GetResultString(parser, "Result Detection Condition Text");
                result.ResultDescription.ResultMeasure = GetResultMeasure(parser, "Result Measure Value", "Result Measure Unit Code");
                result.ResultDescription.ResultSampleFractionText = GetResultString(parser, "Result Sample Fraction Text");
                result.ResultDescription.ResultStatusIdentifier = GetResultString(parser, "Result Status Identifier");
                result.ResultDescription.StatisticalBaseCode = GetResultString(parser, "Result Statistical Base Code");
                result.ResultDescription.ResultValueTypeName = GetResultString(parser, "Result Value Type Name");

                result.ResultAnalyticalMethod = new ResultAnalyticalMethodDataType();
                result.ResultAnalyticalMethod.MethodIdentifier = GetResultString(parser, "Result Analytical Method Identifier");
                result.ResultAnalyticalMethod.MethodIdentifierContext = GetResultString(parser, "Result Analytical Method Identifier Context");
                if (string.IsNullOrEmpty(result.ResultAnalyticalMethod.MethodIdentifier) &&
                     string.IsNullOrEmpty(result.ResultAnalyticalMethod.MethodIdentifierContext))
                {
                    result.ResultAnalyticalMethod = null;
                }

                result.ResultLabInformation = new ResultLabInformationDataType();
                result.ResultLabInformation.AnalysisStartDate = GetResultDate(parser, "Analysis Start Date", out result.ResultLabInformation.AnalysisStartDateSpecified);
                result.ResultLabInformation.ResultDetectionQuantitationLimit = GetDetectionQuantitationLimit(parser, "Detection Quantitation Limit Type Name",
                                                                                                             "Detection Quantitation Limit Measure Value",
                                                                                                             "Detection Quantitation Limit Measure Unit Code");
                if (!result.ResultLabInformation.AnalysisStartDateSpecified && (result.ResultLabInformation.ResultDetectionQuantitationLimit == null))
                {
                    result.ResultLabInformation = null;
                }

                result.ResultDescription.ResultSamplingPointName = GetResultString(parser, "Result Sampling Point Name");
                result.ResultDescription.ResultCommentText = GetResultString(parser, "Result Comment Text");

                if (string.IsNullOrEmpty(result.ResultDescription.CharacteristicName) &&
                     string.IsNullOrEmpty(result.ResultDescription.ResultDetectionConditionText) &&
                     (result.ResultDescription.ResultMeasure == null) &&
                     string.IsNullOrEmpty(result.ResultDescription.ResultSampleFractionText) &&
                     string.IsNullOrEmpty(result.ResultDescription.ResultStatusIdentifier) &&
                     string.IsNullOrEmpty(result.ResultDescription.StatisticalBaseCode) &&
                     string.IsNullOrEmpty(result.ResultDescription.ResultValueTypeName) &&
                     string.IsNullOrEmpty(result.ResultDescription.ResultSamplingPointName) &&
                     string.IsNullOrEmpty(result.ResultDescription.ResultCommentText))
                {
                    result.ResultDescription = null;
                }

                if ((result.ResultDescription == null) && (result.ResultLabInformation == null) &&
                    (result.ResultAnalyticalMethod == null))
                {
                    throw new InvalidDataException(string.Format("An empty result was specified on line {0} for activity \"{1}\"",
                                                                 parser.LineNumber.ToString(), activityId));
                }

                List<ResultDataType> resultList;
                if (!activityIdToResultList.TryGetValue(activityId, out resultList))
                {
                    resultList = new List<ResultDataType>();
                    activityIdToResultList[activityId] = resultList;
                }
                resultList.Add(result);

                List<string> projectIdList;
                if (activityIdToProjectIdList.TryGetValue(activityId, out projectIdList))
                {
                    if (!projectIdList.Contains(projectId))
                    {
                        projectIdList.Add(projectId);
                    }
                }
                else
                {
                    projectIdList = new List<string>();
                    projectIdList.Add(projectId);
                    activityIdToProjectIdList[activityId] = projectIdList;
                }
            }
        }
        protected string ActivitiesAreEqual(ActivityDataType activity1, ActivityDataType activity2)
        {
            if (!string.Equals(activity1.ActivityDescription.ActivityTypeCode, activity2.ActivityDescription.ActivityTypeCode))
            {
                return "ActivityTypeCodes are not equal";
            }
            if (!string.Equals(activity1.ActivityDescription.ActivityMediaName, activity2.ActivityDescription.ActivityMediaName))
            {
                return "ActivityMediaNames are not equal";
            }
            if (activity1.ActivityDescription.ActivityStartDate != activity2.ActivityDescription.ActivityStartDate)
            {
                return "ActivityStartDates are not equal";
            }
            if (((activity1.ActivityDescription.ActivityStartTime == null) != (activity2.ActivityDescription.ActivityStartTime == null)))
            {
                return "ActivityStartTimes are not equal";
            }
            if (!string.Equals(activity1.ActivityDescription.MonitoringLocationIdentifier, activity2.ActivityDescription.MonitoringLocationIdentifier))
            {
                return "MonitoringLocationIdentifiers are not equal";
            }
            if (activity1.ActivityDescription.ActivityStartTime != null)
            {
                if (!string.Equals(activity1.ActivityDescription.ActivityStartTime.Time, activity2.ActivityDescription.ActivityStartTime.Time) ||
                    !string.Equals(activity1.ActivityDescription.ActivityStartTime.TimeZoneCode, activity2.ActivityDescription.ActivityStartTime.TimeZoneCode))
                {
                    return "ActivityStartTimes are not equal";
                }
            }
            if (((activity1.ActivityDescription.ActivityDepthHeightMeasure == null) != (activity2.ActivityDescription.ActivityDepthHeightMeasure == null)))
            {
                return "ActivityDepthHeightMeasure are not equal";
            }
            if (activity1.ActivityDescription.ActivityDepthHeightMeasure != null)
            {
                if (!string.Equals(activity1.ActivityDescription.ActivityDepthHeightMeasure.MeasureValue, activity2.ActivityDescription.ActivityDepthHeightMeasure.MeasureValue) ||
                    !string.Equals(activity1.ActivityDescription.ActivityDepthHeightMeasure.MeasureUnitCode, activity2.ActivityDescription.ActivityDepthHeightMeasure.MeasureUnitCode))
                {
                    return "ActivityDepthHeightMeasures are not equal";
                }
            }
            if (((activity1.BiologicalActivityDescription == null) != (activity2.BiologicalActivityDescription == null)))
            {
                return "BiologicalActivityDescriptions are not equal";
            }
            if (activity1.BiologicalActivityDescription != null)
            {
                if (!string.Equals(activity1.BiologicalActivityDescription.AssemblageSampledName, activity2.BiologicalActivityDescription.AssemblageSampledName))
                {
                    return "BiologicalActivityDescriptions are not equal";
                }
                if (((activity1.BiologicalActivityDescription.BiologicalHabitatCollectionInformation == null) != (activity2.BiologicalActivityDescription.BiologicalHabitatCollectionInformation == null)))
                {
                    return "BiologicalActivityDescriptions are not equal";
                }
                if (activity1.BiologicalActivityDescription.BiologicalHabitatCollectionInformation != null)
                {
                    if (!string.Equals(activity1.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.SamplingComponentName,
                                       activity2.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.SamplingComponentName) ||
                        !string.Equals(activity1.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.SamplingComponentPlaceInSeriesNumeric,
                                       activity2.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.SamplingComponentPlaceInSeriesNumeric) ||
                        !MeasureCompactsAreEqual(activity1.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.CollectionDuration, 
                                                 activity2.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.CollectionDuration) ||
                        !MeasureCompactsAreEqual(activity1.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.ReachLengthMeasure,
                                                 activity2.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.ReachLengthMeasure) ||
                        !MeasureCompactsAreEqual(activity1.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.ReachWidthMeasure,
                                                 activity2.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.ReachWidthMeasure))
                    {
                        return "BiologicalActivityDescriptions are not equal";
                    }
                }
            }
            if (((activity1.SampleDescription == null) != (activity2.SampleDescription == null)))
            {
                return "SampleDescriptions are not equal";
            }
            if (activity1.SampleDescription != null)
            {
                if (!string.Equals(activity1.SampleDescription.SampleCollectionMethod.MethodIdentifier, activity2.SampleDescription.SampleCollectionMethod.MethodIdentifier))
                {
                    return "MethodIdentifiers are not equal";
                }
                if (!string.Equals(activity1.SampleDescription.SampleCollectionEquipmentName, activity2.SampleDescription.SampleCollectionEquipmentName))
                {
                    return "SampleCollectionEquipmentNames are not equal";
                }
                if (!string.Equals(activity1.SampleDescription.SampleCollectionEquipmentCommentText, activity2.SampleDescription.SampleCollectionEquipmentCommentText))
                {
                    return "SampleCollectionEquipmentCommentTexts are not equal";
                }
            }
            return null;
        }
        protected TabSeparatedFileParser GetParser(string filePath)
        {
            return new TabSeparatedFileParser(filePath);
        }
        protected static string GetNonEmptyResultString(TabSeparatedFileParser parser, string columnName)
        {
            return GetNonEmptyString(cResultTypeName, parser, columnName);
        }
        protected static string GetResultString(TabSeparatedFileParser parser, string columnName)
        {
            return GetString(cResultTypeName, parser, columnName);
        }
        protected static DateTime GetResultDate(TabSeparatedFileParser parser, string columnName, out bool isSpecified)
        {
            return GetDate(cResultTypeName, parser, columnName, out isSpecified);
        }
        protected static DateTime GetResultDate(TabSeparatedFileParser parser, string columnName)
        {
            return GetDate(cResultTypeName, parser, columnName);
        }
        protected static WQXTimeDataType GetResultTime(TabSeparatedFileParser parser, string timeColumnName, string codeColumnName)
        {
            return GetTime(cResultTypeName, parser, timeColumnName, codeColumnName);
        }
        protected static MeasureDataType GetResultMeasure(TabSeparatedFileParser parser, string timeColumnName, string codeColumnName)
        {
            return GetMeasure(cResultTypeName, parser, timeColumnName, codeColumnName);
        }
        protected static MeasureCompactDataType GetResultMeasureCompact(TabSeparatedFileParser parser, string measureColumnName, string codeColumnName)
        {
            return GetMeasureCompact(cResultTypeName, parser, measureColumnName, codeColumnName);
        }
        protected static SampleDescriptionDataType GetResultSample(TabSeparatedFileParser parser, string methodIdColumnName,
                                                                   string equipmentNameColumnName, string equipmentCommentColumnName)
        {
            return GetSample(cResultTypeName, parser, methodIdColumnName, equipmentNameColumnName, equipmentCommentColumnName);
        }
        protected static string GetNonEmptyProjectString(TabSeparatedFileParser parser, string columnName)
        {
            return GetNonEmptyString(cProjectTypeName, parser, columnName);
        }
        protected static string GetProjectString(TabSeparatedFileParser parser, string columnName)
        {
            return GetString(cProjectTypeName, parser, columnName);
        }
        protected static string GetNonEmptyMonitoringString(TabSeparatedFileParser parser, string columnName)
        {
            return GetNonEmptyString(cMonitoringTypeName, parser, columnName);
        }
        protected static string GetMonitoringString(TabSeparatedFileParser parser, string columnName)
        {
            return GetString(cMonitoringTypeName, parser, columnName);
        }
        protected static bool GetMonitoringBool(TabSeparatedFileParser parser, string columnName, out bool isSpecified)
        {
            return GetBool(cMonitoringTypeName, parser, columnName, out isSpecified);
        }
        protected static decimal GetMonitoringDecimal(TabSeparatedFileParser parser, string columnName)
        {
            return GetDecimal(cMonitoringTypeName, parser, columnName);
        }
        protected static string GetNonEmptyString(string fileType, TabSeparatedFileParser parser, string columnName)
        {
            string value = parser[columnName];
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidDataException(string.Format("The \"{0}\" value for the {1} at line {2} does not exist",
                                                             columnName, fileType, parser.LineNumber.ToString()));
            }
            return value;
        }
        protected static string GetString(string fileType, TabSeparatedFileParser parser, string columnName)
        {
            string value = parser[columnName];
            return string.IsNullOrEmpty(value) ? null : value;
        }
        protected static bool GetBool(string fileType, TabSeparatedFileParser parser, string columnName, out bool isSpecified)
        {
            string value = parser[columnName];
            if (string.IsNullOrEmpty(value))
            {
                isSpecified = false;
                return false;
            }
            isSpecified = true;
            if (string.Equals(value, "No", StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }
            else if (string.Equals(value, "Yes", StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            else
            {
                throw new InvalidDataException(string.Format("The \"{0}\" boolean value for the {1} at line {2} is not valid",
                                                             columnName, fileType, parser.LineNumber.ToString()));
            }
        }
        protected static decimal GetDecimal(string fileType, TabSeparatedFileParser parser, string columnName)
        {
            bool isSpecified;
            decimal value = GetDecimal(fileType, parser, columnName, out isSpecified);
            if (!isSpecified)
            {
                throw new InvalidDataException(string.Format("The \"{0}\" decimal value for the {1} at line {2} does not exist",
                                                             columnName, fileType, parser.LineNumber.ToString()));
            }
            return value;
        }
        protected static decimal GetDecimal(string fileType, TabSeparatedFileParser parser, string columnName, out bool isSpecified)
        {
            string value = parser[columnName];
            if (string.IsNullOrEmpty(value))
            {
                isSpecified = false;
                return 0;
            }
            isSpecified = true;
            decimal valueDecimal;
            if (!decimal.TryParse(value, out valueDecimal))
            {
                throw new InvalidDataException(string.Format("The \"{0}\" decimal value for the {1} at line {2} is not valid",
                                                             columnName, fileType, parser.LineNumber.ToString()));
            }
            return valueDecimal;
        }
        protected static DateTime GetDate(string fileType, TabSeparatedFileParser parser, string columnName)
        {
            bool isSpecified;
            DateTime value = GetDate(fileType, parser, columnName, out isSpecified);
            if (!isSpecified)
            {
                throw new InvalidDataException(string.Format("The \"{0}\" date value for the {1} at line {2} does not exist",
                                                             columnName, fileType, parser.LineNumber.ToString()));
            }
            return value;
        }
        protected static DateTime GetDate(string fileType, TabSeparatedFileParser parser, string columnName, out bool isSpecified)
        {
            string value = parser[columnName];
            if (string.IsNullOrEmpty(value))
            {
                isSpecified = false;
                return DateTime.MinValue;
            }
            isSpecified = true;
            DateTime valueDate;
            if (!DateTime.TryParseExact(value.Trim(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out valueDate))
            {
                throw new InvalidDataException(string.Format("The \"{0}\" date value for the {1} at line {2} is not valid or is not in the YYYY-MM-DD format",
                                                             columnName, fileType, parser.LineNumber.ToString()));
            }
            return valueDate;
        }
        protected static WQXTimeDataType GetNotNullTime(string fileType, TabSeparatedFileParser parser, string timeColumnName,
                                                        string codeColumnName)
        {
            WQXTimeDataType time = GetTime(fileType, parser, timeColumnName, codeColumnName);
            if (time == null)
            {
                throw new InvalidDataException(string.Format("The \"{0}\" value for the {1} at line {2} does not exist",
                                                             timeColumnName, fileType, parser.LineNumber.ToString()));
            }
            return time;
        }
        protected static WQXTimeDataType GetTime(string fileType, TabSeparatedFileParser parser, string timeColumnName,
                                                 string codeColumnName)
        {
            string value = parser[timeColumnName];
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            value = value.Trim();
            TimeSpan valueTime;
            if (!TimeSpan.TryParse(value, out valueTime) || (valueTime.Days != 0))
            {
                throw new InvalidDataException(string.Format("The \"{0}\" time value for the {1} at line {2} is not valid or is not in the HH:MM:SS format",
                                                             timeColumnName, fileType, parser.LineNumber.ToString()));
            }
            WQXTimeDataType valueRtn = new WQXTimeDataType();
            valueRtn.Time = valueTime.ToString();
            valueRtn.TimeZoneCode = GetNonEmptyString(fileType, parser, codeColumnName);
            return valueRtn;
        }
        protected static MeasureDataType GetMeasure(string fileType, TabSeparatedFileParser parser, string measureColumnName,
                                                    string codeColumnName)
        {
            string value = parser[measureColumnName];
            string code = parser[codeColumnName];
            if (string.IsNullOrEmpty(value) && string.IsNullOrEmpty(code))
            {
                return null;
            }
            MeasureDataType valueRtn = new MeasureDataType();
            valueRtn.ResultMeasureValue = value;
            valueRtn.MeasureUnitCode = code;
            return valueRtn;
        }
        protected static bool MeasureCompactsAreEqual(MeasureCompactDataType compact1, MeasureCompactDataType compact2)
        {
            if (((compact1 == null) != (compact2 == null)))
            {
                return false;
            }
            if (compact1 != null)
            {
                if (!string.Equals(compact1.MeasureValue, compact2.MeasureValue) ||
                    !string.Equals(compact1.MeasureUnitCode, compact2.MeasureUnitCode))
                {
                    return false;
                }
            }
            return true;
        }
        protected static MeasureCompactDataType GetMeasureCompact(string fileType, TabSeparatedFileParser parser, string measureColumnName,
                                                                  string codeColumnName)
        {
            string value = parser[measureColumnName];
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            MeasureCompactDataType valueRtn = new MeasureCompactDataType();
            valueRtn.MeasureValue = value;
            valueRtn.MeasureUnitCode = GetNonEmptyString(fileType, parser, codeColumnName);
            return valueRtn;
        }
        protected static SampleDescriptionDataType GetSample(string fileType, TabSeparatedFileParser parser, string methodIdColumnName,
                                                             string equipmentNameColumnName, string equipmentCommentColumnName)
        {
            string methodId = parser[methodIdColumnName];
            if (string.IsNullOrEmpty(methodId))
            {
                return null;
            }
            SampleDescriptionDataType valueRtn = new SampleDescriptionDataType();
            valueRtn.SampleCollectionMethod = new ReferenceMethodDataType();
            valueRtn.SampleCollectionMethod.MethodIdentifier = methodId;
            // The following two fields are NOT specified in the flat file, but they are required by the schema, what
            // should they be set to???
            valueRtn.SampleCollectionMethod.MethodIdentifierContext = methodId;
            valueRtn.SampleCollectionMethod.MethodName = methodId;

            valueRtn.SampleCollectionEquipmentName = GetNonEmptyString(fileType, parser, equipmentNameColumnName);
            valueRtn.SampleCollectionEquipmentCommentText = GetString(fileType, parser, equipmentCommentColumnName);
            return valueRtn;
        }
        protected static ResultAnalyticalMethodDataType GetResultAnalyticalMethod(TabSeparatedFileParser parser, string idColumnName,
                                                                                  string contextColumnName)
        {
            string id = parser[idColumnName];
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            ResultAnalyticalMethodDataType valueRtn = new ResultAnalyticalMethodDataType();
            valueRtn.MethodIdentifier = id;
            valueRtn.MethodIdentifierContext = GetNonEmptyString(cResultTypeName, parser, contextColumnName);
            return valueRtn;
        }
        protected static DetectionQuantitationLimitDataType[] GetDetectionQuantitationLimit(TabSeparatedFileParser parser, string typeColumnName,
                                                                                            string measureColumnName, string codeColumnName)
        {
            string type = parser[typeColumnName];
            if (string.IsNullOrEmpty(type))
            {
                return null;
            }
            DetectionQuantitationLimitDataType valueRtn = new DetectionQuantitationLimitDataType();
            valueRtn.DetectionQuantitationLimitTypeName = type;
            valueRtn.DetectionQuantitationLimitMeasure = GetResultMeasureCompact(parser, measureColumnName, codeColumnName);
            return new DetectionQuantitationLimitDataType[] { valueRtn };
        }
        private const string cMonitoringTypeName = "monitoring location";
        private const string cProjectTypeName = "project";
        private const string cResultTypeName = "result";
    }
}