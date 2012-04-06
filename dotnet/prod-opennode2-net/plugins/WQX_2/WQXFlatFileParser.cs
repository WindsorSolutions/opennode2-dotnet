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
using System.IO;
using Windsor.Commons.Core;
using Windsor.Node2008.WNOSPlugin.WQX2XsdOrm;

namespace Windsor.Node2008.WNOSPlugin.WQX2
{
    public static class WQXFlatFileParser
    {
        public static WQXDataType GetWQXDataFromResultsFlatFile(string filePath, string lookupValuesFilePath, string orgId, string organizationName)
        {
            Dictionary<string, MonitoringLocationDataType> monitoringLocations = new Dictionary<string, MonitoringLocationDataType>();
            Dictionary<string, ProjectDataType> projects = new Dictionary<string, ProjectDataType>();

            Dictionary<string, LookupValues> resultAnalyticalMethodLookups = null;
            Dictionary<string, LookupValues> sampleCollectionMethodLookups = null;

            if (!string.IsNullOrEmpty(lookupValuesFilePath))
            {
                GetLookups(lookupValuesFilePath, out resultAnalyticalMethodLookups, out sampleCollectionMethodLookups);
            }

            Dictionary<string, ActivityDataType> activities =
                WQXFlatFileParser.ParseResults(filePath, projects, monitoringLocations, resultAnalyticalMethodLookups, 
                                               sampleCollectionMethodLookups, true);

            WQXDataType data = new WQXDataType();
            data.Organization = new OrganizationDataType();
            data.Organization.OrganizationDescription = new OrganizationDescriptionDataType();
            data.Organization.OrganizationDescription.OrganizationIdentifier = orgId;
            data.Organization.OrganizationDescription.OrganizationFormalName = organizationName;

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

            return data;
        }
        public static void GetLookups(string lookupValuesFilePath, out Dictionary<string, LookupValues> resultAnalyticalMethodLookups,
                                      out Dictionary<string, LookupValues> sampleCollectionMethodLookups)
        {
            resultAnalyticalMethodLookups = null;
            sampleCollectionMethodLookups = null;

            if (!File.Exists(lookupValuesFilePath))
            {
                throw new FileNotFoundException(string.Format("The lookup values file \"{0}\" could not be found", lookupValuesFilePath));
            }
            try
            {
                using (CommaSeparatedFileParser parser = new CommaSeparatedFileParser(lookupValuesFilePath))
                {
                    while (parser.NextLine())
                    {
                        string context = parser["CONTEXT"];
                        string type = parser["TYPE"];
                        string id = parser["ID"].ToUpper();
                        string name, description;
                        parser.GetValue("NAME", out name);
                        parser.GetValue("DESCRIPTION", out description);
                        if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(description))
                        {
                            switch (type.ToUpper())
                            {
                                case "SAMPLECOLLECTIONMETHOD":
                                    CollectionUtils.Add(id, new LookupValues(context, name, description),
                                                        ref sampleCollectionMethodLookups);
                                    break;
                                case "RESULTANALYTICALMETHOD":
                                    CollectionUtils.Add(id + context.ToUpper(), new LookupValues(context, name, description),
                                                        ref resultAnalyticalMethodLookups);
                                    break;
                                default:
                                    throw new ArgumentException(string.Format("Invalid TYPE found in lookup values file: {0}",
                                                                              type.ToString()));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new ArgException("Failed to parse the lookup values file \"{0}\" with error: {1}",
                                       lookupValuesFilePath, ExceptionUtils.GetDeepExceptionMessage(e));
            }
        }
        public static Dictionary<string, MonitoringLocationDataType> ParseMonitoringLocations(string filePath)
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
        public static Dictionary<string, ProjectDataType> ParseProjects(string filePath)
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
        public static Dictionary<string, ActivityDataType> ParseResults(string filePath, Dictionary<string, ProjectDataType> projects,
                                                                        Dictionary<string, MonitoringLocationDataType> monitoringLocations,
                                                                        Dictionary<string, LookupValues> resultAnalyticalMethodLookups,
                                                                        Dictionary<string, LookupValues> sampleCollectionMethodLookups,
                                                                        bool addMissingProjectsAndLocations)
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

                if (parser.HasColumn("Data Logger Line"))
                {
                    ParsePhysicalResults(parser, projects, monitoringLocations, activites, activityIdToProjectIdList,
                                         activityIdToResultList, resultAnalyticalMethodLookups, sampleCollectionMethodLookups,
                                         addMissingProjectsAndLocations);
                }
                else if (parser.HasColumn("Assemblage Sampled Name"))
                {
                    ParseBiologicalResults(parser, projects, monitoringLocations, activites, activityIdToProjectIdList,
                                           activityIdToResultList, resultAnalyticalMethodLookups, sampleCollectionMethodLookups,
                                           addMissingProjectsAndLocations);
                }
                else
                {
                    ParseHabitatResults(parser, projects, monitoringLocations, activites, activityIdToProjectIdList,
                                        activityIdToResultList, resultAnalyticalMethodLookups, sampleCollectionMethodLookups,
                                        addMissingProjectsAndLocations);
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
        private static void ParsePhysicalResults(TabSeparatedFileParser parser, Dictionary<string, ProjectDataType> projects,
                                                   Dictionary<string, MonitoringLocationDataType> monitoringLocations,
                                                   Dictionary<string, ActivityDataType> activites,
                                                   Dictionary<string, List<string>> activityIdToProjectIdList,
                                                   Dictionary<string, List<ResultDataType>> activityIdToResultList,
                                                   Dictionary<string, LookupValues> resultAnalyticalMethodLookups,
                                                   Dictionary<string, LookupValues> sampleCollectionMethodLookups,
                                                   bool addMissingProjectsAndLocations)
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
                    if (addMissingProjectsAndLocations)
                    {
                        projects.Add(projectId, new ProjectDataType(projectId));
                    }
                    else
                    {
                        throw new InvalidDataException(string.Format("The {0} flat file contains an activity with id \"{1}\" that references a missing project with id \"{2}\"",
                                                                     cResultTypeName, activityId, projectId));
                    }
                }
                if (!string.IsNullOrEmpty(monitoringId) && !monitoringLocations.ContainsKey(monitoringId))
                {
                    if (addMissingProjectsAndLocations)
                    {
                        monitoringLocations.Add(monitoringId, new MonitoringLocationDataType(monitoringId));
                    }
                    else
                    {
                        throw new InvalidDataException(string.Format("The {0} flat file contains an activity with id \"{1}\" that references a missing monitoring location with id \"{2}\"",
                                                                     cResultTypeName, activityId, projectId));
                    }
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
                                                             "Sample Collection Equipment Comment", sampleCollectionMethodLookups);

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
                result.ResultAnalyticalMethod = GetResultAnalyticalMethod(parser, "Result Analytical Method ID", "Result Analytical Method Context",
                                                                          resultAnalyticalMethodLookups);
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
        private static void ParseBiologicalResults(TabSeparatedFileParser parser, Dictionary<string, ProjectDataType> projects,
                                                     Dictionary<string, MonitoringLocationDataType> monitoringLocations,
                                                     Dictionary<string, ActivityDataType> activites,
                                                     Dictionary<string, List<string>> activityIdToProjectIdList,
                                                     Dictionary<string, List<ResultDataType>> activityIdToResultList,
                                                     Dictionary<string, LookupValues> resultAnalyticalMethodLookups,
                                                     Dictionary<string, LookupValues> sampleCollectionMethodLookups,
                                                     bool addMissingProjectsAndLocations)
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
                    if (addMissingProjectsAndLocations)
                    {
                        projects.Add(projectId, new ProjectDataType(projectId));
                    }
                    else
                    {
                        throw new InvalidDataException(string.Format("The {0} flat file contains an activity with id \"{1}\" that references a missing project with id \"{2}\"",
                                                                     cResultTypeName, activityId, projectId));
                    }
                }
                if (!string.IsNullOrEmpty(monitoringId) && !monitoringLocations.ContainsKey(monitoringId))
                {
                    if (addMissingProjectsAndLocations)
                    {
                        monitoringLocations.Add(monitoringId, new MonitoringLocationDataType(monitoringId));
                    }
                    else
                    {
                        throw new InvalidDataException(string.Format("The {0} flat file contains an activity with id \"{1}\" that references a missing monitoring location with id \"{2}\"",
                                                                     cResultTypeName, activityId, projectId));
                    }
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
                                                             "Sample Collection Equipment Comment", sampleCollectionMethodLookups);

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
                result.BiologicalResultDescription.TaxonomicDetails.HabitName =
                    WQXDataHelper.PipedStringToStrings(GetResultString(parser, "Taxon Habit"));
                result.BiologicalResultDescription.TaxonomicDetails.VoltinismName = GetResultString(parser, "Taxon Voltinism");
                result.BiologicalResultDescription.TaxonomicDetails.TaxonomicPollutionTolerance = GetResultString(parser, "Taxon Pollution Tolerance");
                result.BiologicalResultDescription.TaxonomicDetails.TaxonomicPollutionToleranceScaleText = GetResultString(parser, "Taxon Pollution Tolerance Scale");
                result.BiologicalResultDescription.TaxonomicDetails.TrophicLevelName = GetResultString(parser, "Taxon Trophic Level");
                result.BiologicalResultDescription.TaxonomicDetails.FunctionalFeedingGroupName =
                    WQXDataHelper.PipedStringToStrings(GetResultString(parser, "Taxon Functional Feeding Group"));
                if (string.IsNullOrEmpty(result.BiologicalResultDescription.TaxonomicDetails.CellFormName) &&
                     string.IsNullOrEmpty(result.BiologicalResultDescription.TaxonomicDetails.CellShapeName) &&
                     CollectionUtils.IsNullOrEmpty(result.BiologicalResultDescription.TaxonomicDetails.HabitName) &&
                     string.IsNullOrEmpty(result.BiologicalResultDescription.TaxonomicDetails.VoltinismName) &&

                     string.IsNullOrEmpty(result.BiologicalResultDescription.TaxonomicDetails.TaxonomicPollutionTolerance) &&
                     string.IsNullOrEmpty(result.BiologicalResultDescription.TaxonomicDetails.TaxonomicPollutionToleranceScaleText) &&
                     string.IsNullOrEmpty(result.BiologicalResultDescription.TaxonomicDetails.TrophicLevelName) &&
                     CollectionUtils.IsNullOrEmpty(result.BiologicalResultDescription.TaxonomicDetails.FunctionalFeedingGroupName))
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
                result.ResultAnalyticalMethod = GetResultAnalyticalMethod(parser, "Result Analytical Method ID", "Result Analytical Method Context",
                                                                          resultAnalyticalMethodLookups);
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
        private static void ParseHabitatResults(TabSeparatedFileParser parser, Dictionary<string, ProjectDataType> projects,
                                                  Dictionary<string, MonitoringLocationDataType> monitoringLocations,
                                                  Dictionary<string, ActivityDataType> activites,
                                                  Dictionary<string, List<string>> activityIdToProjectIdList,
                                                  Dictionary<string, List<ResultDataType>> activityIdToResultList,
                                                  Dictionary<string, LookupValues> resultAnalyticalMethodLookups,
                                                  Dictionary<string, LookupValues> sampleCollectionMethodLookups,
                                                  bool addMissingProjectsAndLocations)
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
                    if (addMissingProjectsAndLocations)
                    {
                        projects.Add(projectId, new ProjectDataType(projectId));
                    }
                    else
                    {
                        throw new InvalidDataException(string.Format("The {0} flat file contains an activity with id \"{1}\" that references a missing project with id \"{2}\"",
                                                                     cResultTypeName, activityId, projectId));
                    }
                }
                if (!string.IsNullOrEmpty(monitoringId) && !monitoringLocations.ContainsKey(monitoringId))
                {
                    if (addMissingProjectsAndLocations)
                    {
                        monitoringLocations.Add(monitoringId, new MonitoringLocationDataType(monitoringId));
                    }
                    else
                    {
                        throw new InvalidDataException(string.Format("The {0} flat file contains an activity with id \"{1}\" that references a missing monitoring location with id \"{2}\"",
                                                                     cResultTypeName, activityId, projectId));
                    }
                }
                ActivityDataType activity = new ActivityDataType();
                activity.ActivityDescription = new ActivityDescriptionDataType();
                activity.ActivityDescription.ActivityIdentifier = activityId;
                activity.ActivityDescription.ActivityTypeCode = GetNonEmptyResultString(parser, "Activity Type Code");
                activity.ActivityDescription.ActivityMediaName = GetNonEmptyResultString(parser, "Activity Media Name");
                activity.ActivityDescription.ActivityStartDate = GetResultDate(parser, "Activity Start Date");
                activity.ActivityDescription.ActivityStartTime = GetResultTime(parser, "Activity Start Time", "Activity Start Time Zone Code");
                activity.ActivityDescription.MonitoringLocationIdentifier = monitoringId;

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
                                                             "Sample Collection Equipment Comment Text", sampleCollectionMethodLookups);

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

                result.ResultAnalyticalMethod = GetResultAnalyticalMethod(parser, "Result Analytical Method Identifier", "Result Analytical Method Identifier Context",
                                                                          resultAnalyticalMethodLookups);
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
        private static string ActivitiesAreEqual(ActivityDataType activity1, ActivityDataType activity2)
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
        private static TabSeparatedFileParser GetParser(string filePath)
        {
            return new TabSeparatedFileParser(filePath);
        }
        private static string GetNonEmptyResultString(TabSeparatedFileParser parser, string columnName)
        {
            return GetNonEmptyString(cResultTypeName, parser, columnName);
        }
        private static string GetResultString(TabSeparatedFileParser parser, string columnName)
        {
            return GetString(cResultTypeName, parser, columnName);
        }
        private static DateTime GetResultDate(TabSeparatedFileParser parser, string columnName, out bool isSpecified)
        {
            return GetDate(cResultTypeName, parser, columnName, out isSpecified);
        }
        private static DateTime GetResultDate(TabSeparatedFileParser parser, string columnName)
        {
            return GetDate(cResultTypeName, parser, columnName);
        }
        private static WQXTimeDataType GetResultTime(TabSeparatedFileParser parser, string timeColumnName, string codeColumnName)
        {
            return GetTime(cResultTypeName, parser, timeColumnName, codeColumnName);
        }
        private static MeasureDataType GetResultMeasure(TabSeparatedFileParser parser, string timeColumnName, string codeColumnName)
        {
            return GetMeasure(cResultTypeName, parser, timeColumnName, codeColumnName);
        }
        private static MeasureCompactDataType GetResultMeasureCompact(TabSeparatedFileParser parser, string measureColumnName, string codeColumnName)
        {
            return GetMeasureCompact(cResultTypeName, parser, measureColumnName, codeColumnName);
        }
        private static SampleDescriptionDataType GetResultSample(TabSeparatedFileParser parser, string methodIdColumnName,
                                                                   string equipmentNameColumnName, string equipmentCommentColumnName,
                                                                   Dictionary<string, LookupValues> sampleCollectionMethodLookups)
        {
            return GetSample(cResultTypeName, parser, methodIdColumnName, equipmentNameColumnName, equipmentCommentColumnName,
                             sampleCollectionMethodLookups);
        }
        private static string GetNonEmptyProjectString(TabSeparatedFileParser parser, string columnName)
        {
            return GetNonEmptyString(cProjectTypeName, parser, columnName);
        }
        private static string GetProjectString(TabSeparatedFileParser parser, string columnName)
        {
            return GetString(cProjectTypeName, parser, columnName);
        }
        private static string GetNonEmptyMonitoringString(TabSeparatedFileParser parser, string columnName)
        {
            return GetNonEmptyString(cMonitoringTypeName, parser, columnName);
        }
        private static string GetMonitoringString(TabSeparatedFileParser parser, string columnName)
        {
            return GetString(cMonitoringTypeName, parser, columnName);
        }
        private static bool GetMonitoringBool(TabSeparatedFileParser parser, string columnName, out bool isSpecified)
        {
            return GetBool(cMonitoringTypeName, parser, columnName, out isSpecified);
        }
        private static decimal GetMonitoringDecimal(TabSeparatedFileParser parser, string columnName)
        {
            return GetDecimal(cMonitoringTypeName, parser, columnName);
        }
        private static string GetNonEmptyString(string fileType, TabSeparatedFileParser parser, string columnName)
        {
            string value = parser[columnName];
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidDataException(string.Format("The \"{0}\" value for the {1} at line {2} does not exist",
                                                             columnName, fileType, parser.LineNumber.ToString()));
            }
            return value;
        }
        private static string GetString(string fileType, TabSeparatedFileParser parser, string columnName)
        {
            string value = parser[columnName];
            return string.IsNullOrEmpty(value) ? null : value;
        }
        private static bool GetBool(string fileType, TabSeparatedFileParser parser, string columnName, out bool isSpecified)
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
        private static decimal GetDecimal(string fileType, TabSeparatedFileParser parser, string columnName)
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
        private static decimal GetDecimal(string fileType, TabSeparatedFileParser parser, string columnName, out bool isSpecified)
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
        private static DateTime GetDate(string fileType, TabSeparatedFileParser parser, string columnName)
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
        private static DateTime GetDate(string fileType, TabSeparatedFileParser parser, string columnName, out bool isSpecified)
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
        private static WQXTimeDataType GetNotNullTime(string fileType, TabSeparatedFileParser parser, string timeColumnName,
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
        private static WQXTimeDataType GetTime(string fileType, TabSeparatedFileParser parser, string timeColumnName,
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
        private static MeasureDataType GetMeasure(string fileType, TabSeparatedFileParser parser, string measureColumnName,
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
        private static bool MeasureCompactsAreEqual(MeasureCompactDataType compact1, MeasureCompactDataType compact2)
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
        private static MeasureCompactDataType GetMeasureCompact(string fileType, TabSeparatedFileParser parser, string measureColumnName,
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
        private static SampleDescriptionDataType GetSample(string fileType, TabSeparatedFileParser parser, string methodIdColumnName,
                                                             string equipmentNameColumnName, string equipmentCommentColumnName,
                                                             Dictionary<string, LookupValues> sampleCollectionMethodLookups)
        {
            string methodId = parser[methodIdColumnName];
            if (string.IsNullOrEmpty(methodId))
            {
                return null;
            }
            SampleDescriptionDataType valueRtn = new SampleDescriptionDataType();
            valueRtn.SampleCollectionMethod = new ReferenceMethodDataType();
            valueRtn.SampleCollectionMethod.MethodIdentifier = methodId;

            LookupValues lookupValues = null;
            if ((sampleCollectionMethodLookups != null) &&
                !sampleCollectionMethodLookups.TryGetValue(methodId.ToUpper(), out lookupValues))
            {
                throw new ArgumentException(string.Format("The SampleCollectionMethod.MethodIdentifier \"{0}\" was not found in the lookup values file",
                                                          methodId));
            }
            if (lookupValues != null)
            {
                valueRtn.SampleCollectionMethod.MethodName = lookupValues.Name;
                valueRtn.SampleCollectionMethod.MethodDescriptionText = lookupValues.Description;
                valueRtn.SampleCollectionMethod.MethodIdentifierContext = lookupValues.Context;
            }

            valueRtn.SampleCollectionEquipmentName = GetNonEmptyString(fileType, parser, equipmentNameColumnName);
            valueRtn.SampleCollectionEquipmentCommentText = GetString(fileType, parser, equipmentCommentColumnName);
            return valueRtn;
        }
        private static ResultAnalyticalMethodDataType GetResultAnalyticalMethod(TabSeparatedFileParser parser, string idColumnName,
                                                                                  string contextColumnName,
                                                                                  Dictionary<string, LookupValues> resultAnalyticalMethodLookups)
        {
            string id = parser[idColumnName];
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            ResultAnalyticalMethodDataType valueRtn = new ResultAnalyticalMethodDataType();
            valueRtn.MethodIdentifier = id;
            valueRtn.MethodIdentifierContext = GetNonEmptyString(cResultTypeName, parser, contextColumnName);

            if (resultAnalyticalMethodLookups != null)
            {
                LookupValues lookupValues;
                resultAnalyticalMethodLookups.TryGetValue(id.ToUpper() + valueRtn.MethodIdentifierContext.ToUpper(),
                                                          out lookupValues);
                if (lookupValues != null)
                {
                    valueRtn.MethodDescriptionText = lookupValues.Description;
                    valueRtn.MethodName = lookupValues.Name;
                }
            }
            return valueRtn;
        }
        private static DetectionQuantitationLimitDataType[] GetDetectionQuantitationLimit(TabSeparatedFileParser parser, string typeColumnName,
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

    public class LookupValues
    {
        public LookupValues(string context, string name, string description)
        {
            Context = context;
            Name = name;
            Description = description;
        }
        public string Context;
        public string Name;
        public string Description;
    }
}