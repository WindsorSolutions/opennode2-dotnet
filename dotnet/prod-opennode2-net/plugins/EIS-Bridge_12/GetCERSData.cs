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
using System.Xml.Serialization;
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
using Windsor.Node2008.WNOSPlugin.CERS_12;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.EIS_Bridge_12
{
    internal static class GetCERSData
    {
        private static int OrphanChildrenCount = 0;

        public static CERSDataType GetData(BaseWNOSPlugin plugin, string databaseFilePath, string dataCategory, out string authorName, out string organizationName,
                                           out bool isProductionSubmission)
        {
            SpringBaseDao dao = GetDao(plugin, databaseFilePath);

            CERSDataType cers = GetCEMSInfo(plugin, dao);

            cers.DataCategory = GetExchangeHeaderInfo(plugin, dao, out authorName, out organizationName, out isProductionSubmission);

            if (dataCategory.ToUpper() == "NONPOINT")
            {
                GetNonPointData(plugin, dao, cers);
            }
            else
            {
                GetFacilityOrPointData(plugin, dao, cers, dataCategory);
            }

            return cers;
        }

        /// <summary>
        /// Builds objects for NonPoint XML
        /// </summary>
        private static void GetNonPointData(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            GetLocation(plugin, dao, cers);
            LogCounts(plugin, "Location");
            GetExcludedLocationParameter(plugin, dao, cers);
            LogCounts(plugin, "ExcludedLocationParameter");
            
            GetLocationEmissionsProcess(plugin, dao, cers);
            LogCounts(plugin, "EmissionsProcess");
            GetLocationEmissionsProcessRegulation(plugin, dao, cers);
            LogCounts(plugin, "Regulation");
            GetLocationEmissionsProcessControlPollutant(plugin, dao, cers);
            LogCounts(plugin, "ControlPollutant");
            GetLocationEmissionsProcessControlMeasure(plugin, dao, cers);
            LogCounts(plugin, "ControlMeasure");
            GetLocationEmissionsProcessReportingPeriod(plugin, dao, cers);
            LogCounts(plugin, "ReportingPeriod");
            GetLocationEmissionsProcessReportingPeriodSuppParams(plugin, dao, cers);
            LogCounts(plugin, "SupplementalParameter");
            GetLocationEmissionsProcessReportingPeriodEmissions(plugin, dao, cers);
            LogCounts(plugin, "Emissions");
        }

        private static void GetLocationEmissionsProcessReportingPeriodEmissions(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM Emissions";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    LocationProcessReportingPeriodEmissionsDataType locationProcessEmissions = new LocationProcessReportingPeriodEmissionsDataType();

                    locationProcessEmissions.PollutantCode = readerEx.GetNullString("PollutantCode");
                    locationProcessEmissions.TotalEmissions = readerEx.GetNullString("TotalEmissions");
                    locationProcessEmissions.EmissionsUnitofMeasureCode = readerEx.GetNullString("EmissionsUnitofMeasureCode");
                    locationProcessEmissions.EmissionFactor = readerEx.GetNullString("EmissionFactor");
                    locationProcessEmissions.EmissionFactorNumeratorUnitofMeasureCode = readerEx.GetNullString("EmissionFactorNumeratorUnitofMeasureCode");
                    locationProcessEmissions.EmissionFactorDenominatorUnitofMeasureCode = readerEx.GetNullString("EmissionFactorDenominatorUnitofMeasureCode");
                    locationProcessEmissions.EmissionFactorText = readerEx.GetNullString("EmissionFactorText");
                    locationProcessEmissions.EmissionCalculationMethodCode = readerEx.GetNullString("EmissionCalculationMethodCode");
                    locationProcessEmissions.EmissionsComment = readerEx.GetNullString("EmissionsComment");

                    bool parentFound = false;
                    foreach (LocationDataType loc in cers.Location)
                    {
                        if (loc.StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            if (loc.LocationEmissionsProcess != null)
                            {
                                foreach (LocationProcessDataType proc in loc.LocationEmissionsProcess)
                                {
                                    if (proc.SourceClassificationCode == readerEx.GetNullString("SourceClassificationCode"))
                                    {
                                        foreach (LocationProcessReportingPeriodDataType period in proc.ReportingPeriod)
                                        {
                                            if (period.ReportingPeriodTypeCode == readerEx.GetNullString("ReportingPeriodTypeCode"))
                                                period.ReportingPeriodEmissions = Windsor.Commons.Core.CollectionUtils.Add(locationProcessEmissions, period.ReportingPeriodEmissions);
                                            parentFound = true;
                                            goto MoveNext;
                                        }
                                    }
                                }
                            }
                        }
                    }
                MoveNext:
                    if (!parentFound) OrphanChildrenCount++;
                });
        }

        private static void GetLocationEmissionsProcessReportingPeriodSuppParams(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM SupplementalParameter";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    LocationProcessReportingPeriodSupplementalCalculationParameterDataType locationProcessSuppParam = new LocationProcessReportingPeriodSupplementalCalculationParameterDataType();

                    locationProcessSuppParam.SupplementalCalculationParameterType = readerEx.GetNullString("SupplementalCalculationParameterType");
                    locationProcessSuppParam.SupplementalCalculationParameterValue = readerEx.GetNullString("SupplementalCalculationParameterValue");
                    locationProcessSuppParam.SupplementalCalculationParameterNumeratorUnitofMeasureCode = readerEx.GetNullString("SupplementalCalculationParameterNumeratorUnitofMeasureCode");
                    locationProcessSuppParam.SupplementalCalculationParameterDenominatorUnitofMeasureCode = readerEx.GetNullString("SupplementalCalculationParameterDenominatorUnitofMeasureCode");
                    locationProcessSuppParam.SupplementalCalculationParameterDataYear = readerEx.GetNullString("SupplementalCalculationParameterDataYear");
                    locationProcessSuppParam.SupplementalCalculationParameterDataSource = readerEx.GetNullString("SupplementalCalculationParameterDataSource");
                    locationProcessSuppParam.SupplementalCalculationParameterComment = readerEx.GetNullString("SupplementalCalculationParameterComment");

                    bool parentFound = false;
                    foreach (LocationDataType loc in cers.Location)
                    {
                        if (loc.StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            if (loc.LocationEmissionsProcess != null)
                            {
                                foreach (LocationProcessDataType proc in loc.LocationEmissionsProcess)
                                {
                                    if (proc.SourceClassificationCode == readerEx.GetNullString("SourceClassificationCode"))
                                    {
                                        foreach (LocationProcessReportingPeriodDataType period in proc.ReportingPeriod)
                                        {
                                            if (period.ReportingPeriodTypeCode == readerEx.GetNullString("ReportingPeriodTypeCode"))
                                                period.SupplementalCalculationParameter = Windsor.Commons.Core.CollectionUtils.Add(locationProcessSuppParam, period.SupplementalCalculationParameter);
                                            parentFound = true;
                                            goto MoveNext;
                                        }
                                    }
                                }
                            }
                        }
                    }
                MoveNext:
                    if (!parentFound) OrphanChildrenCount++;
                });
        }

        private static void GetLocationEmissionsProcessReportingPeriod(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = @"SELECT * FROM ReportingPeriod 
                            LEFT JOIN OperatingDetails ON ReportingPeriod.StateAndCountyFIPSCode = OperatingDetails.StateAndCountyFIPSCode
                            AND ReportingPeriod.SourceClassificationCode = OperatingDetails.SourceClassificationCode
                            AND ReportingPeriod.ReportingPeriodTypeCode = OperatingDetails.ReportingPeriodTypeCode";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    LocationProcessReportingPeriodDataType locationReportingPeriod = new LocationProcessReportingPeriodDataType();

                    locationReportingPeriod.ReportingPeriodTypeCode = readerEx.GetNullString("ReportingPeriod.ReportingPeriodTypeCode");
                    locationReportingPeriod.EmissionOperatingTypeCode = readerEx.GetNullString("EmissionsTypeCode");
                    locationReportingPeriod.CalculationParameterTypeCode = readerEx.GetNullString("CalculationParameterTypeCode");
                    locationReportingPeriod.CalculationParameterValue = readerEx.GetNullString("CalculationParameterValue");
                    locationReportingPeriod.CalculationParameterUnitofMeasure = readerEx.GetNullString("CalculationParameterUnitofMeasure");
                    locationReportingPeriod.CalculationMaterialCode = readerEx.GetNullString("CalculationMaterialCode");
                    locationReportingPeriod.CalculationDataYear = readerEx.GetNullString("CalculationDataYear");
                    locationReportingPeriod.CalculationDataSource = readerEx.GetNullString("CalculationDataSource");
                    locationReportingPeriod.ReportingPeriodComment = readerEx.GetNullString("ReportingPeriodComment");

                    //add operating details if present
                    if (readerEx.GetNullString("OperatingDetails.StateAndCountyFIPSCode") != null)
                    {
                        locationReportingPeriod.OperatingDetails = new OperatingDetailsDataType();

                        locationReportingPeriod.OperatingDetails.PercentWinterActivitySpecified
                        = Decimal.TryParse(readerEx.GetNullString("PercentWinterActivity"), out locationReportingPeriod.OperatingDetails.PercentWinterActivity);

                        locationReportingPeriod.OperatingDetails.PercentSpringActivitySpecified
                        = Decimal.TryParse(readerEx.GetNullString("PercentSpringActivity"), out locationReportingPeriod.OperatingDetails.PercentSpringActivity);

                        locationReportingPeriod.OperatingDetails.PercentSummerActivitySpecified
                        = Decimal.TryParse(readerEx.GetNullString("PercentSummerActivity"), out locationReportingPeriod.OperatingDetails.PercentSummerActivity);

                        locationReportingPeriod.OperatingDetails.PercentFallActivitySpecified
                        = Decimal.TryParse(readerEx.GetNullString("PercentFallActivity"), out locationReportingPeriod.OperatingDetails.PercentFallActivity);
                    }

                    bool parentFound = false;
                    foreach (LocationDataType loc in cers.Location)
                    {
                        if (loc.StateAndCountyFIPSCode == readerEx.GetNullString("ReportingPeriod.StateAndCountyFIPSCode"))
                        {
                            if (loc.LocationEmissionsProcess != null)
                            {
                                foreach (LocationProcessDataType proc in loc.LocationEmissionsProcess)
                                {
                                    if (proc.SourceClassificationCode == readerEx.GetNullString("ReportingPeriod.SourceClassificationCode"))
                                    {
                                        proc.ReportingPeriod = Windsor.Commons.Core.CollectionUtils.Add(locationReportingPeriod, proc.ReportingPeriod);
                                        parentFound = true;
                                        goto MoveNext;
                                    }
                                }
                            }
                        }
                    }
                MoveNext:
                    if (!parentFound) OrphanChildrenCount++;
                });
        }

        private static void GetLocationEmissionsProcessControlMeasure(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM ControlMeasure";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    LocationProcessControlApproachControlMeasureDataType locationControlMeasure = new LocationProcessControlApproachControlMeasureDataType();

                    locationControlMeasure.ControlMeasureCode = readerEx.GetNullString("ControlMeasureCode");

                    bool parentFound = false;
                    foreach (LocationDataType loc in cers.Location)
                    {
                        if (loc.StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            if (loc.LocationEmissionsProcess != null)
                            {
                                foreach (LocationProcessDataType proc in loc.LocationEmissionsProcess)
                                {
                                    if (proc.SourceClassificationCode == readerEx.GetNullString("SourceClassificationCode"))
                                    {
                                        if (proc.ProcessControlApproach != null)
                                        {
                                            proc.ProcessControlApproach.ControlMeasure = Windsor.Commons.Core.CollectionUtils.Add(locationControlMeasure, proc.ProcessControlApproach.ControlMeasure);
                                            parentFound = true;
                                            goto MoveNext;
                                        }
                                    }
                                }
                            }
                        }
                    }
                MoveNext:
                    if (!parentFound) OrphanChildrenCount++;
                });
        }

        private static void GetLocationEmissionsProcessControlPollutant(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM ControlPollutant";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    LocationProcessControlApproachControlPollutantDataType locationControlPollutant = new LocationProcessControlApproachControlPollutantDataType();

                    locationControlPollutant.PollutantCode = readerEx.GetNullString("PollutantCode");
                    locationControlPollutant.PercentControlMeasuresReductionEfficiencySpecified
                        = Decimal.TryParse(readerEx.GetNullString("PercentControlMeasureReductionEfficiency"), out locationControlPollutant.PercentControlMeasuresReductionEfficiency);

                    bool parentFound = false;
                    foreach (LocationDataType loc in cers.Location)
                    {
                        if (loc.StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            if (loc.LocationEmissionsProcess != null)
                            {
                                foreach (LocationProcessDataType proc in loc.LocationEmissionsProcess)
                                {
                                    if (proc.SourceClassificationCode == readerEx.GetNullString("SourceClassificationCode"))
                                    {
                                        if(proc.ProcessControlApproach != null)
                                        {
                                            proc.ProcessControlApproach.ControlPollutant = Windsor.Commons.Core.CollectionUtils.Add(locationControlPollutant, proc.ProcessControlApproach.ControlPollutant);
                                            parentFound = true;
                                            goto MoveNext;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    MoveNext:
                    if (!parentFound) OrphanChildrenCount++;
                });
        }

        private static void GetLocationEmissionsProcessRegulation(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM Regulation";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    LocationProcessRegulationDataType locationProcessRegulation = new LocationProcessRegulationDataType();

                    locationProcessRegulation.RegulatoryCode = readerEx.GetNullString("RegulatoryCode");
                    locationProcessRegulation.AgencyCodeText = readerEx.GetNullString("AgencyCodeText");
                    locationProcessRegulation.RegulationComment = readerEx.GetNullString("RegulationComment");

                    bool parentFound = false;
                    foreach (LocationDataType loc in cers.Location)
                    {
                        if (loc.StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            if (loc.LocationEmissionsProcess != null)
                            {
                                foreach (LocationProcessDataType proc in loc.LocationEmissionsProcess)
                                {
                                    if (proc.SourceClassificationCode == readerEx.GetNullString("SourceClassificationCode"))
                                    {
                                        proc.ProcessRegulation = Windsor.Commons.Core.CollectionUtils.Add(locationProcessRegulation, proc.ProcessRegulation);
                                        parentFound = true;
                                    }
                                }
                            }
                        }
                    }
                    if (!parentFound) OrphanChildrenCount++;
                });
        }

        private static void GetLocationEmissionsProcess(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = @"SELECT * FROM EmissionsProcess 
                LEFT JOIN ControlApproach on EmissionsProcess.StateAndCountyFIPSCode = ControlApproach.StateAndCountyFIPSCode
                AND EmissionsProcess.SourceClassificationCode = ControlApproach.SourceClassificationCode";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    LocationProcessDataType locationProcess = new LocationProcessDataType();

                    locationProcess.SourceClassificationCode = readerEx.GetNullString("EmissionsProcess.SourceClassificationCode");
                    locationProcess.EmissionsTypeCode = readerEx.GetNullString("EmissionsTypeCode");
                    locationProcess.ProcessComment = readerEx.GetNullString("ProcessComment");

                    //add the control approach, if present
                    if (readerEx.GetNullString("ControlApproach.StateAndCountyFIPSCode") != null)
                    {
                        locationProcess.ProcessControlApproach = new LocationProcessControlApproachDataType();
                        locationProcess.ProcessControlApproach.ControlApproachDescription = readerEx.GetNullString("ControlApproachDescription");
                        
                        locationProcess.ProcessControlApproach.PercentControlApproachCaptureEfficiencySpecified =
                            Decimal.TryParse(readerEx.GetNullString("PercentControlApproachCaptureEfficiency"), out locationProcess.ProcessControlApproach.PercentControlApproachCaptureEfficiency);
                        locationProcess.ProcessControlApproach.PercentControlApproachEffectivenessSpecified =
                            Decimal.TryParse(readerEx.GetNullString("PercentControlApproachEffectiveness"), out locationProcess.ProcessControlApproach.PercentControlApproachEffectiveness);
                        locationProcess.ProcessControlApproach.PercentControlApproachPenetrationSpecified =
                            Decimal.TryParse(readerEx.GetNullString("PercentControlApproachPenetration"), out locationProcess.ProcessControlApproach.PercentControlApproachPenetration);

                        locationProcess.ProcessControlApproach.ControlApproachComment = readerEx.GetNullString("ControlApproachComment");
                    }

                    bool parentFound = false;
                    foreach (LocationDataType loc in cers.Location)
                    {
                        if (loc.StateAndCountyFIPSCode == readerEx.GetNullString("EmissionsProcess.StateAndCountyFIPSCode"))
                        {
                            loc.LocationEmissionsProcess = Windsor.Commons.Core.CollectionUtils.Add(locationProcess, loc.LocationEmissionsProcess);
                            parentFound = true;
                        }
                    }
                    if (!parentFound) OrphanChildrenCount++;
                });
        }

        private static void GetExcludedLocationParameter(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM ExcludedLocationParameter";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    ExcludedLocationParameterDataType locationParam = new ExcludedLocationParameterDataType();

                    locationParam.LocationTypeCode = readerEx.GetNullString("LocationTypeCode");
                    locationParam.LocationParameter = readerEx.GetNullString("LocationParameter");
                    locationParam.LocationComment = readerEx.GetNullString("LocationComment");

                    bool parentFound = false;
                    foreach (LocationDataType loc in cers.Location)
                    {
                        if (loc.StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            loc.ExcludedLocationParameter = Windsor.Commons.Core.CollectionUtils.Add(locationParam, loc.ExcludedLocationParameter);
                            parentFound = true;
                        }
                    }
                    if (!parentFound) OrphanChildrenCount++;
                });
        }

        private static void GetLocation(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {            
            string query = "SELECT * FROM Location";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    LocationDataType location = new LocationDataType();

                    location.StateAndCountyFIPSCode = readerEx.GetNullString("StateAndCountyFIPSCode");
                    location.CensusTractIdentifier = readerEx.GetNullString("CensusTractIdentifier");
                    location.ShapeIdentifier = readerEx.GetNullString("ShapeIdentifier");
                    location.LocationComment = readerEx.GetNullString("LocationComment");

                    cers.Location = Windsor.Commons.Core.CollectionUtils.Add(location, cers.Location);
                });            
        }

        /// <summary>
        /// Builds objects for Facility and Point XML
        /// </summary>
        private static void GetFacilityOrPointData(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers, string dataCategory)
        {
            GetFacilitySites(plugin, dao, cers, dataCategory);

            GetEmissionsUnits(plugin, dao, cers, dataCategory);
            LogCounts(plugin, "EmissionUnit");
            GetUnitIdentifications(plugin, dao, cers);
            LogCounts(plugin, "EmissionUnitIdentification");

            if (dataCategory.ToUpper() == "FACILITYINVENTORY")
            {
                GetUnitRegulations(plugin, dao, cers);
                LogCounts(plugin, "UnitRegulation");
                GetUnitControlApproaches(plugin, dao, cers);
                LogCounts(plugin, "UnitControlApproach");
                GetUnitControlApproachMeasures(plugin, dao, cers);
                LogCounts(plugin, "UnitControlApproachMeasure");
                GetUnitControlApproachPollutants(plugin, dao, cers);
                LogCounts(plugin, "UnitControlApproachMeasurePollutant");
            }

            GetUnitProcesses(plugin, dao, cers, dataCategory);
            LogCounts(plugin, "UnitProcess");

            if (dataCategory.ToUpper() == "FACILITYINVENTORY")
            {
                GetUnitProcessRegulations(plugin, dao, cers);
                LogCounts(plugin, "UnitProcessRegulation");
                GetUnitProcessControlApproachList(plugin, dao, cers);
                LogCounts(plugin, "UnitProcessRegulationControl");
                GetUnitProcessControlApproachMeasures(plugin, dao, cers);
                LogCounts(plugin, "UnitProcessControlApproachMeasures");
                GetUnitProcessControlApproachPollutants(plugin, dao, cers);
                LogCounts(plugin, "UnitProcessControlApproachMeasurePollutant");

                GetReleasePoints(plugin, dao, cers);
                LogCounts(plugin, "ReleasePoint");
                GetReleasePointCoordinates(plugin, dao, cers);
                LogCounts(plugin, "ReleasePointCoordinate");
                GetUnitProcessReleasePointApportionment(plugin, dao, cers);
                LogCounts(plugin, "ReleasePointApportionment");
            }

            if (dataCategory.ToUpper() == "POINT")
            {
                GetUnitProcessReportingPeriods(plugin, dao, cers);
                LogCounts(plugin, "UnitProcessReportingPeriod");
                GetUnitProcessReportingPeriodParameters(plugin, dao, cers);
                LogCounts(plugin, "UnitProcessReportingPeriodParameter");
                GetUnitProcessReportingPeriodEmmissions(plugin, dao, cers);
                LogCounts(plugin, "UnitProcessReportingPeriodEmissions");
            }
        }

        private static void LogCounts(BaseWNOSPlugin plugin, string node)
        {
            if (OrphanChildrenCount > 0)
            {
                plugin.AppendAuditLogEvent("{0}: {1} orphan records skipped", node, OrphanChildrenCount);
                OrphanChildrenCount = 0;
            }
        }
        private static void GetReleasePointCoordinates(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM ReleasePointGeographicCoordinates";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    GeographicCoordinatesDataType releasePointCoordinate = new GeographicCoordinatesDataType();

                    releasePointCoordinate.LatitudeMeasure = readerEx.GetNullString("LatitudeMeasure");
                    if (releasePointCoordinate.LatitudeMeasure.Length > 10) releasePointCoordinate.LatitudeMeasure = releasePointCoordinate.LatitudeMeasure.Substring(0, 10); //per schema, maxlength 10

                    releasePointCoordinate.LongitudeMeasure = readerEx.GetNullString("LongitudeMeasure");
                    if (releasePointCoordinate.LongitudeMeasure.Length > 11) releasePointCoordinate.LongitudeMeasure = releasePointCoordinate.LongitudeMeasure.Substring(0, 11); //per schema, maxlength 11
                    
                    releasePointCoordinate.SourceMapScaleNumber = readerEx.GetNullString("SourceMapScaleNumber");
                    releasePointCoordinate.HorizontalAccuracyMeasure = readerEx.GetNullString("HorizontalAccuracyMeasure");
                    releasePointCoordinate.HorizontalAccuracyUnitofMeasure = readerEx.GetNullString("HorizontalAccuracyUnitofMeasure");
                    releasePointCoordinate.HorizontalCollectionMethodCode = readerEx.GetNullString("HorizontalCollectionMethodCode");
                    releasePointCoordinate.HorizontalReferenceDatumCode = readerEx.GetNullString("HorizontalReferenceDatumCode");
                    releasePointCoordinate.GeographicReferencePointCode = readerEx.GetNullString("GeographicReferencePointCode");
                    releasePointCoordinate.DataCollectionDate = CERSDate(readerEx.GetNullString("DataCollectionDate"), out releasePointCoordinate.DataCollectionDateSpecified);
                    releasePointCoordinate.GeographicComment = readerEx.GetNullString("GeographicComment");
                    releasePointCoordinate.VerticalMeasure = readerEx.GetNullString("VerticalMeasure");
                    releasePointCoordinate.VerticalUnitofMeasureCode = readerEx.GetNullString("VerticalUnitofMeasureCode");
                    releasePointCoordinate.VerticalCollectionMethodCode = readerEx.GetNullString("VerticalCollectionMethodCode");
                    releasePointCoordinate.VerticalReferenceDatumCode = readerEx.GetNullString("VerticalReferenceDatumCode");
                    releasePointCoordinate.VerificationMethodCode = readerEx.GetNullString("VerificationMethodCode");
                    releasePointCoordinate.CoordinateDataSourceCode = readerEx.GetNullString("CoordinateDataSourceCode");
                    releasePointCoordinate.GeometricTypeCode = readerEx.GetNullString("GeometricTypeCode");

                    bool parentFound = false;
                    foreach (FacilitySiteDataType fac in cers.FacilitySite)
                    {
                        if (fac.FacilityIdentification[0].FacilitySiteIdentifier == readerEx.GetNullString("FacilitySiteIdentifier")
                            && fac.FacilityIdentification[0].StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            foreach (ReleasePointDataType releasePoint in fac.ReleasePoint)
                            {
                                if (releasePoint.ReleasePointIdentification[0].Identifier == readerEx.GetNullString("ReleasePointIdentifier"))
                                {
                                    releasePoint.ReleasePointGeographicCoordinates = releasePointCoordinate;
                                    parentFound = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (!parentFound) throw new ApplicationException("No parent ReleasePoint found for ReleasePointGeographicCoordinate");
                });

        }

        private static void GetUnitProcessReleasePointApportionment(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM ReleasePointApportionment";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    EmissionsUnitProcessReleasePointApportionmentDataType unitProcessReleasePointApportionment = new EmissionsUnitProcessReleasePointApportionmentDataType();

                    Decimal.TryParse(readerEx.GetNullString("AveragePercentEmissions"), out unitProcessReleasePointApportionment.AveragePercentEmissions);
                    unitProcessReleasePointApportionment.ReleasePointApportionmentComment = readerEx.GetNullString("ReleasePointApportionmentComment");

                    unitProcessReleasePointApportionment.ReleasePointApportionmentIdentification = new EmissionsUnitProcessReleasePointApportionmentIdentificationDataType[] { new EmissionsUnitProcessReleasePointApportionmentIdentificationDataType() };
                    unitProcessReleasePointApportionment.ReleasePointApportionmentIdentification[0] = new EmissionsUnitProcessReleasePointApportionmentIdentificationDataType();
                    unitProcessReleasePointApportionment.ReleasePointApportionmentIdentification[0].Identifier = readerEx.GetNullString("ReleasePointIdentifier");
                    unitProcessReleasePointApportionment.ReleasePointApportionmentIdentification[0].ProgramSystemCode = readerEx.GetNullString("ReleasePointProgramSystemCode");

                    bool parentFound = false;
                    foreach (FacilitySiteDataType fac in cers.FacilitySite)
                    {
                        if (fac.FacilityIdentification[0].FacilitySiteIdentifier == readerEx.GetNullString("FacilitySiteIdentifier")
                            && fac.FacilityIdentification[0].StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            if (fac.EmissionsUnit != null)
                            {
                                foreach (EmissionsUnitDataType emissionUnit in fac.EmissionsUnit)
                                {
                                    if (emissionUnit.UnitIdentification[0].Identifier == readerEx.GetNullString("UnitIdentifier"))
                                    {
                                        if (emissionUnit.UnitEmissionsProcess != null)
                                        {
                                            foreach (EmissionsUnitProcessDataType process in emissionUnit.UnitEmissionsProcess)
                                            {
                                                if (process.ProcessIdentification[0].Identifier == readerEx.GetNullString("EmissionsProcessIdentifier"))
                                                {
                                                    process.ReleasePointApportionment = Windsor.Commons.Core.CollectionUtils.Add(unitProcessReleasePointApportionment, process.ReleasePointApportionment);
                                                    parentFound = true;
                                                    goto MoveNext;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                MoveNext:
                    if (!parentFound) OrphanChildrenCount++;
                });
        }

        private static void GetUnitProcessReportingPeriodEmmissions(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM Emissions WHERE ReportingPeriodTypeCode IS NOT NULL and ReportingPeriodTypeCode <> \"\" and EmissionOperatingTypeCode IS NOT NULL and EmissionOperatingTypeCode <> \"\"";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    EmissionsUnitProcessReportingPeriodEmissionsDataType unitProcessReportingPeriodEmission = new EmissionsUnitProcessReportingPeriodEmissionsDataType();

                    unitProcessReportingPeriodEmission.PollutantCode = readerEx.GetNullString("PollutantCode");
                    unitProcessReportingPeriodEmission.TotalEmissions = readerEx.GetNullString("TotalEmissions");
                    unitProcessReportingPeriodEmission.EmissionsUnitofMeasureCode = readerEx.GetNullString("EmissionsUnitofMeasureCode");
                    unitProcessReportingPeriodEmission.EmissionFactor = readerEx.GetNullString("EmissionFactor");
                    unitProcessReportingPeriodEmission.EmissionFactorNumeratorUnitofMeasureCode = readerEx.GetNullString("EmissionFactorNumeratorUnitofMeasureCode");
                    unitProcessReportingPeriodEmission.EmissionFactorDenominatorUnitofMeasureCode = readerEx.GetNullString("EmissionFactorDenominatorUnitofMeasureCode");
                    unitProcessReportingPeriodEmission.EmissionFactorText = readerEx.GetNullString("EmissionFactorText");
                    unitProcessReportingPeriodEmission.EmissionCalculationMethodCode = readerEx.GetNullString("EmissionCalculationMethodCode");
                    unitProcessReportingPeriodEmission.EmissionsComment = readerEx.GetNullString("EmissionsComment");

                    bool parentFound = false;
                    foreach (FacilitySiteDataType fac in cers.FacilitySite)
                    {
                        if (fac.FacilityIdentification != null && fac.EmissionsUnit != null 
                            && fac.FacilityIdentification[0].FacilitySiteIdentifier == readerEx.GetNullString("FacilitySiteIdentifier")
                            && fac.FacilityIdentification[0].StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            if (fac.EmissionsUnit != null)
                            {
                                foreach (EmissionsUnitDataType emissionUnit in fac.EmissionsUnit)
                                {
                                    if (emissionUnit.UnitIdentification[0].Identifier == readerEx.GetNullString("UnitIdentifier"))
                                    {
                                        if (emissionUnit.UnitEmissionsProcess != null)
                                        {
                                            foreach (EmissionsUnitProcessDataType process in emissionUnit.UnitEmissionsProcess)
                                            {
                                                if (process.ProcessIdentification[0].Identifier == readerEx.GetNullString("EmissionsProcessIdentifier"))
                                                {
                                                    if (process.ReportingPeriod != null)
                                                    {
                                                        foreach (EmissionsUnitProcessReportingPeriodDataType reportingPeriod in process.ReportingPeriod)
                                                        {
                                                            if (reportingPeriod.ReportingPeriodTypeCode == readerEx.GetNullString("ReportingPeriodTypeCode")
                                                                && reportingPeriod.EmissionOperatingTypeCode == readerEx.GetNullString("EmissionOperatingTypeCode"))
                                                            {
                                                                reportingPeriod.ReportingPeriodEmissions = Windsor.Commons.Core.CollectionUtils.Add(unitProcessReportingPeriodEmission, reportingPeriod.ReportingPeriodEmissions);
                                                                parentFound = true;
                                                                goto MoveNext;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    MoveNext:
                    if (!parentFound) OrphanChildrenCount++; //throw new ApplicationException("No parent ReportingPeriod found for SupplementalParameter");
                });
        }

        private static void GetUnitProcessReportingPeriodParameters(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM SupplementalParameter";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    EmissionsUnitProcessReportingPeriodSupplementalCalculationParameterDataType unitProcessReportingPeriodParam = new EmissionsUnitProcessReportingPeriodSupplementalCalculationParameterDataType();
                    unitProcessReportingPeriodParam.SupplementalCalculationParameterType = readerEx.GetNullString("SupplementalCalculationParameterType");
                    unitProcessReportingPeriodParam.SupplementalCalculationParameterValue = readerEx.GetNullString("SupplementalCalculationParameterValue");
                    unitProcessReportingPeriodParam.SupplementalCalculationParameterNumeratorUnitofMeasureCode = readerEx.GetNullString("SupplementalCalculationParameterNumeratorUnitofMeasureCode");
                    unitProcessReportingPeriodParam.SupplementalCalculationParameterDenominatorUnitofMeasureCode = readerEx.GetNullString("SupplementalCalculationParameterDenominatorUnitofMeasureCode");
                    unitProcessReportingPeriodParam.SupplementalCalculationParameterDataYear = readerEx.GetNullString("SupplementalCalculationParameterDataYear");
                    unitProcessReportingPeriodParam.SupplementalCalculationParameterDataSource = readerEx.GetNullString("SupplementalCalculationParameterDataSource");
                    unitProcessReportingPeriodParam.SupplementalCalculationParameterComment = readerEx.GetNullString("SupplementalCalculationParameterComment");

                    bool parentFound = false;
                    foreach (FacilitySiteDataType fac in cers.FacilitySite)
                    {
                        if (fac.FacilityIdentification[0].FacilitySiteIdentifier == readerEx.GetNullString("FacilitySiteIdentifier")
                            && fac.FacilityIdentification[0].StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            if (fac.EmissionsUnit != null)
                            {
                                foreach (EmissionsUnitDataType emissionUnit in fac.EmissionsUnit)
                                {
                                    if (emissionUnit.UnitIdentification[0].Identifier == readerEx.GetNullString("UnitIdentifier"))
                                    {
                                        if (emissionUnit.UnitEmissionsProcess != null)
                                        {
                                            foreach (EmissionsUnitProcessDataType process in emissionUnit.UnitEmissionsProcess)
                                            {
                                                if (process.ProcessIdentification[0].Identifier == readerEx.GetNullString("EmissionsProcessIdentifier"))
                                                {
                                                    foreach (EmissionsUnitProcessReportingPeriodDataType reportingPeriod in process.ReportingPeriod)
                                                    {
                                                        if (reportingPeriod.ReportingPeriodTypeCode == readerEx.GetNullString("ReportingPeriodTypeCode")
                                                            && reportingPeriod.EmissionOperatingTypeCode == readerEx.GetNullString("EmissionOperatingTypeCode"))
                                                        {
                                                            reportingPeriod.SupplementalCalculationParameter = Windsor.Commons.Core.CollectionUtils.Add(unitProcessReportingPeriodParam, reportingPeriod.SupplementalCalculationParameter);
                                                            parentFound = true;
                                                            goto MoveNext;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    MoveNext:
                    if (!parentFound) OrphanChildrenCount++; //throw new ApplicationException("No parent ReportingPeriod found for SupplementalParameter");
                });
        }

        private static void GetUnitProcessReportingPeriods(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            //Assume 1 to 1 between ReportingPeriod and child table of OperatingDetails
            string query = @"SELECT * FROM ReportingPeriod 
                LEFT JOIN OperatingDetails ON ReportingPeriod.FacilitySiteIdentifier = OperatingDetails.FacilitySiteIdentifier
                    AND ReportingPeriod.StateAndCountyFIPSCode = OperatingDetails.StateAndCountyFIPSCode
                    AND ReportingPeriod.UnitIdentifier = OperatingDetails.UnitIdentifier
                    AND ReportingPeriod.EmissionsProcessIdentifier = OperatingDetails.EmissionsProcessIdentifier
                    AND ReportingPeriod.ReportingPeriodTypeCode = OperatingDetails.ReportingPeriodTypeCode
                    AND ReportingPeriod.EmissionOperatingTypeCode = OperatingDetails.EmissionOperatingTypeCode";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    EmissionsUnitProcessReportingPeriodDataType unitProcessReportingPeriod = new EmissionsUnitProcessReportingPeriodDataType();

                    unitProcessReportingPeriod.ReportingPeriodTypeCode = readerEx.GetNullString("ReportingPeriod.ReportingPeriodTypeCode");
                    unitProcessReportingPeriod.StartDate = CERSDate(readerEx.GetNullString("StartDate"), out unitProcessReportingPeriod.StartDateSpecified);
                    unitProcessReportingPeriod.EndDate = CERSDate(readerEx.GetNullString("EndDate"), out unitProcessReportingPeriod.EndDateSpecified);
                    unitProcessReportingPeriod.EmissionOperatingTypeCode = readerEx.GetNullString("ReportingPeriod.EmissionOperatingTypeCode");
                    unitProcessReportingPeriod.CalculationParameterTypeCode = readerEx.GetNullString("CalculationParameterTypeCode");
                    unitProcessReportingPeriod.CalculationParameterValue = readerEx.GetNullString("CalculationParameterValue");
                    unitProcessReportingPeriod.CalculationParameterUnitofMeasure = readerEx.GetNullString("CalculationParameterUnitofMeasure");
                    unitProcessReportingPeriod.CalculationMaterialCode = readerEx.GetNullString("CalculationMaterialCode");
                    unitProcessReportingPeriod.CalculationDataYear = readerEx.GetNullString("CalculationDataYear");
                    unitProcessReportingPeriod.CalculationDataSource = readerEx.GetNullString("CalculationDataSource");
                    unitProcessReportingPeriod.ReportingPeriodComment = readerEx.GetNullString("ReportingPeriodComment");

                    //if there is an OperatingDetails record present, 
                    if (readerEx.GetNullString("OperatingDetails.FacilitySiteIdentifier") != null)
                    {
                        unitProcessReportingPeriod.OperatingDetails = new OperatingDetailsDataType();
                        unitProcessReportingPeriod.OperatingDetails.ActualHoursPerPeriod = readerEx.GetNullString("ActualHoursPerPeriod");
                        unitProcessReportingPeriod.OperatingDetails.AverageDaysPerWeek = readerEx.GetNullString("AverageDaysPerWeek");
                        unitProcessReportingPeriod.OperatingDetails.AverageHoursPerDay = readerEx.GetNullString("AverageHoursPerDay");
                        unitProcessReportingPeriod.OperatingDetails.AverageWeeksPerPeriod = readerEx.GetNullString("AverageWeeksPerPeriod");

                        unitProcessReportingPeriod.OperatingDetails.PercentWinterActivitySpecified
                        = Decimal.TryParse(readerEx.GetNullString("PercentWinterActivity"), out unitProcessReportingPeriod.OperatingDetails.PercentWinterActivity);

                        unitProcessReportingPeriod.OperatingDetails.PercentSpringActivitySpecified
                        = Decimal.TryParse(readerEx.GetNullString("PercentSpringActivity"), out unitProcessReportingPeriod.OperatingDetails.PercentSpringActivity);

                        unitProcessReportingPeriod.OperatingDetails.PercentSummerActivitySpecified
                        = Decimal.TryParse( readerEx.GetNullString("PercentSummerActivity"), out unitProcessReportingPeriod.OperatingDetails.PercentSummerActivity);
                        
                        unitProcessReportingPeriod.OperatingDetails.PercentFallActivitySpecified
                        = Decimal.TryParse(readerEx.GetNullString("PercentFallActivity"), out unitProcessReportingPeriod.OperatingDetails.PercentFallActivity);
                    }

                    bool parentFound = false;
                    foreach (FacilitySiteDataType fac in cers.FacilitySite)
                    {
                        if (fac.FacilityIdentification[0].FacilitySiteIdentifier == readerEx.GetNullString("ReportingPeriod.FacilitySiteIdentifier")
                            && fac.FacilityIdentification[0].StateAndCountyFIPSCode == readerEx.GetNullString("ReportingPeriod.StateAndCountyFIPSCode"))
                        {
                            if (fac.EmissionsUnit != null)
                            {
                                foreach (EmissionsUnitDataType emissionUnit in fac.EmissionsUnit)
                                {
                                    if (emissionUnit.UnitIdentification[0].Identifier == readerEx.GetNullString("ReportingPeriod.UnitIdentifier"))
                                    {
                                        if (emissionUnit.UnitEmissionsProcess != null)
                                        {
                                            foreach (EmissionsUnitProcessDataType process in emissionUnit.UnitEmissionsProcess)
                                            {
                                                if (process.ProcessIdentification[0].Identifier == readerEx.GetNullString("ReportingPeriod.EmissionsProcessIdentifier"))
                                                {
                                                    process.ReportingPeriod = Windsor.Commons.Core.CollectionUtils.Add(unitProcessReportingPeriod, process.ReportingPeriod);
                                                    parentFound = true;
                                                    goto MoveNext;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    MoveNext:
                    if (!parentFound) OrphanChildrenCount++; //throw new ApplicationException("No parent EmissionUnitProcess found for ReportingPeriod");
                });
        }

        private static void GetUnitProcessControlApproachPollutants(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM ControlPollutant WHERE EmissionsProcessIdentifier IS NOT NULL and EmissionsProcessIdentifier <> \"\"";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    EmissionsUnitProcessControlApproachControlPollutantDataType unitProcessControlApproachPollutant = new EmissionsUnitProcessControlApproachControlPollutantDataType();

                    unitProcessControlApproachPollutant.PollutantCode = readerEx.GetNullString("PollutantCode");
                    unitProcessControlApproachPollutant.PercentControlMeasuresReductionEfficiencySpecified
                        = Decimal.TryParse(readerEx.GetNullString("PercentControlMeasureReductionEfficiency"), out unitProcessControlApproachPollutant.PercentControlMeasuresReductionEfficiency);

                    bool parentFound = false;
                    foreach (FacilitySiteDataType fac in cers.FacilitySite)
                    {
                        if (fac.FacilityIdentification[0].FacilitySiteIdentifier == readerEx.GetNullString("FacilitySiteIdentifier")
                            && fac.FacilityIdentification[0].StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            if (fac.EmissionsUnit != null)
                            {
                                foreach (EmissionsUnitDataType emissionUnit in fac.EmissionsUnit)
                                {
                                    if (emissionUnit.UnitIdentification[0].Identifier == readerEx.GetNullString("UnitIdentifier"))
                                    {
                                        if (emissionUnit.UnitEmissionsProcess != null)
                                        {
                                            foreach (EmissionsUnitProcessDataType process in emissionUnit.UnitEmissionsProcess)
                                            {
                                                if (process.ProcessIdentification[0].Identifier == readerEx.GetNullString("EmissionsProcessIdentifier"))
                                                {
                                                    process.ProcessControlApproach.ControlPollutant = Windsor.Commons.Core.CollectionUtils.Add(unitProcessControlApproachPollutant, process.ProcessControlApproach.ControlPollutant);
                                                    parentFound = true;
                                                    goto MoveNext;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    MoveNext:
                    if (!parentFound) OrphanChildrenCount++;
                });
        }

        private static void GetUnitProcessControlApproachMeasures(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM ControlMeasure WHERE EmissionsProcessIdentifier IS NOT NULL and EmissionsProcessIdentifier <> \"\"";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    EmissionsUnitProcessControlApproachControlMeasureDataType unitProcessControlApproachMeasure = new EmissionsUnitProcessControlApproachControlMeasureDataType();

                    unitProcessControlApproachMeasure.ControlMeasureCode = readerEx.GetNullString("ControlMeasureCode");

                    bool parentFound = false;
                    foreach (FacilitySiteDataType fac in cers.FacilitySite)
                    {
                        if (fac.FacilityIdentification[0].FacilitySiteIdentifier == readerEx.GetNullString("FacilitySiteIdentifier")
                            && fac.FacilityIdentification[0].StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            if (fac.EmissionsUnit != null)
                            {
                                foreach (EmissionsUnitDataType emissionUnit in fac.EmissionsUnit)
                                {
                                    if (emissionUnit.UnitIdentification[0].Identifier == readerEx.GetNullString("UnitIdentifier"))
                                    {
                                        if (emissionUnit.UnitEmissionsProcess != null)
                                        {
                                            foreach (EmissionsUnitProcessDataType process in emissionUnit.UnitEmissionsProcess)
                                            {
                                                if (process.ProcessIdentification[0].Identifier == readerEx.GetNullString("EmissionsProcessIdentifier"))
                                                {
                                                    //create a process control approach if one doesn't exist already
                                                    if (process.ProcessControlApproach == null) process.ProcessControlApproach = new EmissionsUnitProcessControlApproachDataType();

                                                    process.ProcessControlApproach.ControlMeasure = Windsor.Commons.Core.CollectionUtils.Add(unitProcessControlApproachMeasure, process.ProcessControlApproach.ControlMeasure);
                                                    parentFound = true;
                                                    goto MoveNext;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    MoveNext:
                    if (!parentFound) OrphanChildrenCount++;
                });

        }

        private static void GetUnitProcessControlApproachList(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM ControlApproach WHERE EmissionsProcessIdentifier IS NOT NULL and EmissionsProcessIdentifier <> \"\"";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    EmissionsUnitProcessControlApproachDataType unitProcessControlApproach = new EmissionsUnitProcessControlApproachDataType();

                    unitProcessControlApproach.ControlApproachDescription = readerEx.GetNullString("ControlApproachDescription");
                    unitProcessControlApproach.PercentControlApproachCaptureEfficiencySpecified =
                        Decimal.TryParse(readerEx.GetNullString("PercentControlApproachCaptureEfficiency"), out unitProcessControlApproach.PercentControlApproachCaptureEfficiency);
                    unitProcessControlApproach.PercentControlApproachEffectivenessSpecified =
                        Decimal.TryParse(readerEx.GetNullString("PercentControlApproachEffectiveness"), out unitProcessControlApproach.PercentControlApproachEffectiveness);
                    unitProcessControlApproach.FirstInventoryYear = readerEx.GetNullString("FirstInventoryYear");
                    unitProcessControlApproach.LastInventoryYear = readerEx.GetNullString("LastInventoryYear");

                    bool parentFound = false;
                    foreach (FacilitySiteDataType fac in cers.FacilitySite)
                    {
                        if (fac.FacilityIdentification[0].FacilitySiteIdentifier == readerEx.GetNullString("FacilitySiteIdentifier")
                            && fac.FacilityIdentification[0].StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            if (fac.EmissionsUnit != null)
                            {
                                foreach (EmissionsUnitDataType emissionUnit in fac.EmissionsUnit)
                                {
                                    if (emissionUnit.UnitIdentification[0].Identifier == readerEx.GetNullString("UnitIdentifier"))
                                    {
                                        if (emissionUnit.UnitEmissionsProcess != null)
                                        {
                                            foreach (EmissionsUnitProcessDataType process in emissionUnit.UnitEmissionsProcess)
                                            {
                                                if (process.ProcessIdentification[0].Identifier == readerEx.GetNullString("EmissionsProcessIdentifier"))
                                                {
                                                    process.ProcessControlApproach = unitProcessControlApproach;
                                                    parentFound = true;
                                                    goto MoveNext;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    MoveNext:
                    if (!parentFound) OrphanChildrenCount++;
                });

        }

        private static void GetUnitProcessRegulations(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM Regulation WHERE EmissionsProcessIdentifier IS NOT NULL AND EmissionsProcessIdentifier <> \"\"";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    EmissionsUnitProcessRegulationDataType unitProcessRegulation = new EmissionsUnitProcessRegulationDataType();

                    unitProcessRegulation.RegulatoryCode = readerEx.GetNullString("RegulatoryCode");
                    unitProcessRegulation.AgencyCodeText = readerEx.GetNullString("AgencyCodeText");
                    unitProcessRegulation.RegulatoryStartYear = readerEx.GetNullString("RegulatoryStartYear");
                    unitProcessRegulation.RegulationComment = readerEx.GetNullString("RegulationComment");

                    bool parentFound = false;
                    foreach (FacilitySiteDataType fac in cers.FacilitySite)
                    {
                        if (fac.FacilityIdentification[0].FacilitySiteIdentifier == readerEx.GetNullString("FacilitySiteIdentifier")
                            && fac.FacilityIdentification[0].StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            if (fac.EmissionsUnit != null)
                            {
                                foreach (EmissionsUnitDataType emissionUnit in fac.EmissionsUnit)
                                {
                                    if (emissionUnit.UnitIdentification[0].Identifier == readerEx.GetNullString("UnitIdentifier"))
                                    {
                                        if (emissionUnit.UnitEmissionsProcess != null)
                                        {
                                            foreach (EmissionsUnitProcessDataType process in emissionUnit.UnitEmissionsProcess)
                                            {
                                                if (process.ProcessIdentification[0].Identifier == readerEx.GetNullString("EmissionsProcessIdentifier"))
                                                {
                                                    process.ProcessRegulation = Windsor.Commons.Core.CollectionUtils.Add(unitProcessRegulation, process.ProcessRegulation);
                                                    parentFound = true;
                                                    goto MoveNext;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    MoveNext:
                    if (!parentFound) OrphanChildrenCount++; 
                });
        }

        private static void GetUnitProcesses(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers, string dataCategory)
        {
            string query = "SELECT * FROM EmissionsProcess";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    EmissionsUnitProcessDataType unitProcess = new EmissionsUnitProcessDataType();

                    if (dataCategory.ToUpper() == "FACILITYINVENTORY")
                    {
                        unitProcess.SourceClassificationCode = readerEx.GetNullString("SourceClassificationCode");
                        unitProcess.AircraftEngineTypeCode = readerEx.GetNullString("AircraftEngineTypeCode");
                        unitProcess.ProcessDescription = readerEx.GetNullString("ProcessDescription");
                        unitProcess.LastEmissionsYear = readerEx.GetNullString("LastEmissionsYear");
                        unitProcess.ProcessComment = readerEx.GetNullString("ProcessComment");
                    }

                    //create a single ProcessIdentification node
                    unitProcess.ProcessIdentification = new EmissionsUnitProcessIdentificationDataType[] { new EmissionsUnitProcessIdentificationDataType() };
                    unitProcess.ProcessIdentification[0].Identifier = readerEx.GetNullString("EmissionsProcessIdentifier");
                    unitProcess.ProcessIdentification[0].ProgramSystemCode = readerEx.GetNullString("ProcessProgramSystemCode");
                    unitProcess.ProcessIdentification[0].EffectiveDate = CERSDate(readerEx.GetNullString("EffectiveDate"), out unitProcess.ProcessIdentification[0].EffectiveDateSpecified);
                    unitProcess.ProcessIdentification[0].EndDate = CERSDate(readerEx.GetNullString("EndDate"), out unitProcess.ProcessIdentification[0].EndDateSpecified);

                    bool parentFound = false;
                    foreach (FacilitySiteDataType fac in cers.FacilitySite)
                    {
                        if (fac.FacilityIdentification[0].FacilitySiteIdentifier == readerEx.GetNullString("FacilitySiteIdentifier")
                            && fac.FacilityIdentification[0].StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            if (fac.EmissionsUnit != null)
                            {
                                foreach (EmissionsUnitDataType emissionUnit in fac.EmissionsUnit)
                                {
                                    if (emissionUnit.UnitIdentification[0].Identifier == readerEx.GetNullString("UnitIdentifier"))
                                    {
                                        emissionUnit.UnitEmissionsProcess = Windsor.Commons.Core.CollectionUtils.Add(unitProcess, emissionUnit.UnitEmissionsProcess);
                                        parentFound = true;
                                        goto MoveNext;
                                    }
                                }
                            }
                        }
                    }
                    MoveNext:
                    if (!parentFound) OrphanChildrenCount++;
                });
        }

        private static void GetUnitControlApproachPollutants(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM ControlPollutant WHERE EmissionsProcessIdentifier IS NULL or EmissionsProcessIdentifier = \"\"";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    EmissionsUnitControlApproachControlPollutantDataType unitControlApproachPollutant = new EmissionsUnitControlApproachControlPollutantDataType();

                    unitControlApproachPollutant.PollutantCode = readerEx.GetNullString("PollutantCode");
                    unitControlApproachPollutant.PercentControlMeasuresReductionEfficiencySpecified
                        = Decimal.TryParse(readerEx.GetNullString("PercentControlMeasureReductionEfficiency"), out unitControlApproachPollutant.PercentControlMeasuresReductionEfficiency);

                    bool parentFound = false;
                    foreach (FacilitySiteDataType fac in cers.FacilitySite)
                    {
                        if (fac.FacilityIdentification[0].FacilitySiteIdentifier == readerEx.GetNullString("FacilitySiteIdentifier")
                            && fac.FacilityIdentification[0].StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            if (fac.EmissionsUnit != null)
                            {
                                foreach (EmissionsUnitDataType emissionUnit in fac.EmissionsUnit)
                                {
                                    if (emissionUnit.UnitIdentification[0].Identifier == readerEx.GetNullString("UnitIdentifier"))
                                    {
                                        emissionUnit.UnitControlApproach.ControlPollutant = Windsor.Commons.Core.CollectionUtils.Add(unitControlApproachPollutant, emissionUnit.UnitControlApproach.ControlPollutant);
                                        parentFound = true;
                                        goto MoveNext;
                                    }
                                }
                            }
                        }
                    }
                    MoveNext:
                    if (!parentFound) OrphanChildrenCount++; 
                });
        }

        private static void GetUnitControlApproachMeasures(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            Dictionary<string, EmissionsUnitControlApproachControlMeasureDataType> unitControlApproachMeasures = new Dictionary<string, EmissionsUnitControlApproachControlMeasureDataType>(100);
            string query = "SELECT * FROM ControlMeasure WHERE EmissionsProcessIdentifier IS NULL or EmissionsProcessIdentifier = \"\"";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    EmissionsUnitControlApproachControlMeasureDataType unitControlApproachMeasure = new EmissionsUnitControlApproachControlMeasureDataType();

                    unitControlApproachMeasure.ControlMeasureCode = readerEx.GetNullString("ControlMeasureCode");

                    bool parentFound = false;
                    foreach (FacilitySiteDataType fac in cers.FacilitySite)
                    {
                        if (fac.FacilityIdentification[0].FacilitySiteIdentifier == readerEx.GetNullString("FacilitySiteIdentifier")
                            && fac.FacilityIdentification[0].StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            if (fac.EmissionsUnit != null)
                            {
                                foreach (EmissionsUnitDataType emissionUnit in fac.EmissionsUnit)
                                {
                                    if (emissionUnit.UnitIdentification[0].Identifier == readerEx.GetNullString("UnitIdentifier"))
                                    {
                                        emissionUnit.UnitControlApproach.ControlMeasure = Windsor.Commons.Core.CollectionUtils.Add(unitControlApproachMeasure, emissionUnit.UnitControlApproach.ControlMeasure);
                                        parentFound = true;
                                        goto MoveNext;
                                    }
                                }
                            }
                        }
                        }
                    MoveNext:
                    if (!parentFound) OrphanChildrenCount++;
                });
        }

        private static void GetUnitControlApproaches(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM ControlApproach WHERE EmissionsProcessIdentifier IS NULL OR EmissionsProcessIdentifier = \"\"";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    EmissionsUnitControlApproachDataType unitControlApproach = new EmissionsUnitControlApproachDataType();

                    unitControlApproach.ControlApproachDescription = readerEx.GetNullString("ControlApproachDescription");
                    unitControlApproach.PercentControlApproachCaptureEfficiencySpecified = 
                        Decimal.TryParse(readerEx.GetNullString("PercentControlApproachCaptureEfficiency"), out unitControlApproach.PercentControlApproachCaptureEfficiency);
                    unitControlApproach.PercentControlApproachEffectivenessSpecified = 
                        Decimal.TryParse(readerEx.GetNullString("PercentControlApproachEffectiveness"), out unitControlApproach.PercentControlApproachEffectiveness);
                    unitControlApproach.FirstInventoryYear = readerEx.GetNullString("FirstInventoryYear");
                    unitControlApproach.LastInventoryYear = readerEx.GetNullString("LastInventoryYear");

                    bool parentFound = false;
                    foreach (FacilitySiteDataType fac in cers.FacilitySite)
                    {
                        if (fac.FacilityIdentification[0].FacilitySiteIdentifier == readerEx.GetNullString("FacilitySiteIdentifier")
                            && fac.FacilityIdentification[0].StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            if (fac.EmissionsUnit != null)
                            {
                                foreach (EmissionsUnitDataType emissionUnit in fac.EmissionsUnit)
                                {
                                    if (emissionUnit.UnitIdentification[0].Identifier == readerEx.GetNullString("UnitIdentifier"))
                                    {
                                        emissionUnit.UnitControlApproach = unitControlApproach;
                                        parentFound = true;
                                        goto MoveNext;
                                    }
                                }
                            }
                        }
                    }
                    MoveNext:
                    if (!parentFound) OrphanChildrenCount++;
                });
        }

        private static void GetUnitRegulations(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM Regulation WHERE EmissionsProcessIdentifier IS NULL OR EmissionsProcessIdentifier = \"\"";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    EmissionsUnitRegulationDataType unitRegulation = new EmissionsUnitRegulationDataType();

                    unitRegulation.RegulatoryCode = readerEx.GetNullString("RegulatoryCode");
                    unitRegulation.AgencyCodeText = readerEx.GetNullString("AgencyCodeText");
                    unitRegulation.RegulatoryStartYear = readerEx.GetNullString("RegulatoryStartYear");
                    unitRegulation.RegulationComment = readerEx.GetNullString("RegulationComment");

                    bool parentFound = false;
                    foreach (FacilitySiteDataType fac in cers.FacilitySite)
                    {
                        if (fac.FacilityIdentification[0].FacilitySiteIdentifier == readerEx.GetNullString("FacilitySiteIdentifier")
                            && fac.FacilityIdentification[0].StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            if (fac.EmissionsUnit != null)
                            {
                                foreach (EmissionsUnitDataType emissionUnit in fac.EmissionsUnit)
                                {
                                    if (emissionUnit.UnitIdentification[0].Identifier == readerEx.GetNullString("UnitIdentifier"))
                                    {
                                        emissionUnit.UnitRegulation = Windsor.Commons.Core.CollectionUtils.Add(unitRegulation, emissionUnit.UnitRegulation);
                                        parentFound = true;
                                        goto MoveNext;
                                    }
                                }
                            }
                        }
                    }
                    MoveNext:
                        if (!parentFound) OrphanChildrenCount++; 
                });
        }

        private static void GetUnitIdentifications(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM AlternativeUnitIdentification";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    EmissionsUnitIdentificationDataType unitIdentification = new EmissionsUnitIdentificationDataType();

                    unitIdentification.Identifier = readerEx.GetNullString("AlternativeUnitIdentifier");
                    unitIdentification.ProgramSystemCode = readerEx.GetNullString("AlternativeUnitProgramSystemCode");
                    unitIdentification.EffectiveDate = CERSDate(readerEx.GetNullString("EffectiveDate"), out unitIdentification.EffectiveDateSpecified);
                    unitIdentification.EndDate = CERSDate(readerEx.GetNullString("EndDate"), out unitIdentification.EndDateSpecified);

                    bool parentFound = false;
                    foreach (FacilitySiteDataType fac in cers.FacilitySite)
                    {
                        if (fac.FacilityIdentification[0].FacilitySiteIdentifier == readerEx.GetNullString("FacilitySiteIdentifier")
                            && fac.FacilityIdentification[0].StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            if (fac.EmissionsUnit != null)
                            {
                                foreach (EmissionsUnitDataType emissionUnit in fac.EmissionsUnit)
                                {
                                    if (emissionUnit.UnitIdentification[0].Identifier == readerEx.GetNullString("UnitIdentifier"))
                                    {
                                        emissionUnit.UnitIdentification = Windsor.Commons.Core.CollectionUtils.Add(unitIdentification, emissionUnit.UnitIdentification);
                                        parentFound = true;
                                        goto MoveNext;
                                    }
                                }
                            }
                        }
                    }
                    MoveNext:
                    if (!parentFound) OrphanChildrenCount++;
                });
        }

        private static void GetFacilitySites(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers, string dataCategory)
        {
            Dictionary<string, FacilitySiteDataType> facilities = new Dictionary<string, FacilitySiteDataType>(100);
            string query =
                string.Format(
                    "SELECT * FROM FacilitySite WHERE FacilitySiteProgramSystemCode = '{0}'",
                    cers.ProgramSystemCode);
            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    FacilitySiteDataType facility = new FacilitySiteDataType();

                    facility.FacilityIdentification = new FacilityIdentificationDataType[] { new FacilityIdentificationDataType() };

                    //Map to FacilityIdentification XML
                    facility.FacilityIdentification[0].FacilitySiteIdentifier = readerEx.GetNullString("FacilitySiteIdentifier");
                    facility.FacilityIdentification[0].ProgramSystemCode = readerEx.GetNullString("FacilitySiteProgramSystemCode");
                    facility.FacilityIdentification[0].StateAndCountyFIPSCode = readerEx.GetNullString("StateAndCountyFIPSCode");
                    facility.FacilityIdentification[0].TribalCode = readerEx.GetNullString("TribalCode");
                    facility.FacilityIdentification[0].StateAndCountryFIPSCode = readerEx.GetNullString("StateAndCountryFIPSCode");
                    facility.FacilityIdentification[0].EffectiveDate =
                        CERSDate(readerEx.GetNullString("EffectiveDate"), out facility.FacilityIdentification[0].EffectiveDateSpecified);
                    facility.FacilityIdentification[0].EndDate =
                        CERSDate(readerEx.GetNullString("EndDate"), out facility.FacilityIdentification[0].EndDateSpecified);

                    if (dataCategory.ToUpper() == "FACILITYINVENTORY")
                    {
                        //Map to FacilitySite XML
                        facility.FacilityCategoryCode = readerEx.GetNullString("FacilityCategoryCode");
                        facility.FacilitySiteName = readerEx.GetNullString("FacilitySiteName");
                        facility.FacilitySiteDescription = readerEx.GetNullString("FacilitySiteDescription");
                        facility.FacilitySiteStatusCode = readerEx.GetNullString("FacilitySiteStatusCode");
                        facility.FacilitySiteStatusCodeYear = readerEx.GetNullString("FacilitySiteStatusCodeYear");
                        facility.FacilitySiteComment = readerEx.GetNullString("FacilitySiteComment");

                        //Map to FacilityNAICS XML
                        facility.FacilityNAICS = new FacilityNAICSDataType[] { new FacilityNAICSDataType() };
                        facility.FacilityNAICS[0].NAICSCode = readerEx.GetNullString("NAICSCode");

                        //Map to FacilitySiteAddress XML
                        facility.FacilitySiteAddress = new FacilitySiteAddressDataType[] { new FacilitySiteAddressDataType() };
                        facility.FacilitySiteAddress[0].LocationAddressText = readerEx.GetNullString("LocationAddressText");
                        facility.FacilitySiteAddress[0].SupplementalLocationText = readerEx.GetNullString("SupplementalLocationText");
                        facility.FacilitySiteAddress[0].LocalityName = readerEx.GetNullString("LocalityName");
                        facility.FacilitySiteAddress[0].LocationAddressStateCode = readerEx.GetNullString("LocationAddressStateCode");
                        facility.FacilitySiteAddress[0].LocationAddressPostalCode = readerEx.GetNullString("LocationAddressPostalCode");
                        facility.FacilitySiteAddress[0].LocationAddressCountryCode = readerEx.GetNullString("LocationAddressCountryCode");
                        facility.FacilitySiteAddress[0].AddressComment = readerEx.GetNullString("AddressComment");

                        //TODO: Map to FacilitySiteGeographicCoordinate XML

                        //TODO: Map to AlternativeFacilityName XML

                        facility.FacilitySiteAffiliation = new AffiliationDataType[] { new AffiliationDataType() };
                        facility.FacilitySiteAffiliation[0].AffiliationOrganization = new AffiliationOrganizationDataType[] { new AffiliationOrganizationDataType() };
                        facility.FacilitySiteAffiliation[0].AffiliationOrganization[0].OrganizationFormalName = readerEx.GetNullString("OrganizationFormalName");

                        //Remove empty nodes
                        if (string.IsNullOrEmpty(facility.FacilitySiteAffiliation[0].AffiliationOrganization[0].OrganizationFormalName))
                        {
                            facility.FacilitySiteAffiliation = null;
                        }
                        if (string.IsNullOrEmpty(facility.FacilityNAICS[0].NAICSCode))
                        {
                            facility.FacilityNAICS = null;
                        }
                        if (string.IsNullOrEmpty(facility.FacilitySiteAddress[0].LocationAddressText) &&
                            string.IsNullOrEmpty(facility.FacilitySiteAddress[0].SupplementalLocationText) &&
                            string.IsNullOrEmpty(facility.FacilitySiteAddress[0].LocalityName) &&
                            string.IsNullOrEmpty(facility.FacilitySiteAddress[0].LocationAddressStateCode) &&
                            string.IsNullOrEmpty(facility.FacilitySiteAddress[0].LocationAddressPostalCode) &&
                            string.IsNullOrEmpty(facility.FacilitySiteAddress[0].LocationAddressCountryCode) &&
                            string.IsNullOrEmpty(facility.FacilitySiteAddress[0].AddressComment))
                        {
                            facility.FacilitySiteAddress = null;
                        }
                    }

                    if (facilities.ContainsKey(facility.FacilityIdentification[0].FacilitySiteIdentifier))
                    {
                        throw new ArgumentException(string.Format("More than one facility with the same FacilitySiteIdentifier was found: {0}",
                                                                  facility.FacilityIdentification[0].FacilitySiteIdentifier));
                    }
                    facilities[facility.FacilityIdentification[0].FacilitySiteIdentifier] = facility;

                });


            if (!CollectionUtils.IsNullOrEmpty(facilities))
            {
                string query2 =
                    string.Format(
                        "SELECT * FROM AlternativeFacilityIdentification WHERE FacilitySiteProgramSystemCode = '{0}'",
                        cers.ProgramSystemCode);
                dao.QueryWithRowCallbackDelegate(CommandType.Text, query2,
                    delegate(IDataReader dataReader)
                    {
                        NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                        string facilitySiteIdentifier = readerEx.GetNullString("FacilitySiteIdentifier");
                        if (facilities.ContainsKey(facilitySiteIdentifier))
                        {
                            FacilityIdentificationDataType facilityIdentification = new FacilityIdentificationDataType();
                            facilityIdentification.StateAndCountyFIPSCode = readerEx.GetNullString("StateAndCountyFIPSCode");
                            facilityIdentification.TribalCode = readerEx.GetNullString("TribalCode");
                            facilityIdentification.StateAndCountryFIPSCode = readerEx.GetNullString("StateAndCountryFIPSCode");
                            facilityIdentification.FacilitySiteIdentifier = readerEx.GetNullString("AlternativeAgencyIdentifier");
                            facilityIdentification.ProgramSystemCode = readerEx.GetNullString("AlternativeFacilitySiteProgramSystemCode");
                            facilityIdentification.EffectiveDate = CERSDate(readerEx.GetNullString("EffectiveDate"), out facilityIdentification.EffectiveDateSpecified);
                            facilityIdentification.EndDate = CERSDate(readerEx.GetNullString("EndDate"), out facilityIdentification.EndDateSpecified);
                            facilities[facilitySiteIdentifier].FacilityIdentification =
                                CollectionUtils.Add(facilityIdentification, facilities[facilitySiteIdentifier].FacilityIdentification);
                        }
                    });

                //AlternativeFacilityNames belong only to FacilityInventory submissions
                if (dataCategory.ToUpper() == "FACILITYINVENTORY")
                {
                    query2 =
                        string.Format(
                            "SELECT * FROM AlternativeFacilityName WHERE FacilitySiteProgramSystemCode = '{0}'",
                            cers.ProgramSystemCode);
                    dao.QueryWithRowCallbackDelegate(CommandType.Text, query2,
                        delegate(IDataReader dataReader)
                        {
                            NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                            string facilitySiteIdentifier = readerEx.GetNullString("FacilitySiteIdentifier");
                            if (facilities.ContainsKey(facilitySiteIdentifier))
                            {
                                AlternativeFacilityNameDataType alternativeFacilityName = new AlternativeFacilityNameDataType();
                                alternativeFacilityName.AlternativeName = readerEx.GetNullString("AlternativeName");
                                alternativeFacilityName.ProgramSystemCode = readerEx.GetNullString("AlternativeNameProgramSystemCode");
                                alternativeFacilityName.AlternativeNameTypeText = readerEx.GetNullString("AlternativeNameTypeText");
                                alternativeFacilityName.EffectiveDate = CERSDate(readerEx.GetNullString("EffectiveDate"), out alternativeFacilityName.EffectiveDateSpecified);
                                facilities[facilitySiteIdentifier].AlternativeFacilityName =
                                    CollectionUtils.Add(alternativeFacilityName, facilities[facilitySiteIdentifier].AlternativeFacilityName);
                            }
                        });
                }


                cers.FacilitySite = CollectionUtils.IsNullOrEmpty(facilities) ? null : CollectionUtils.ToArray(facilities.Values);
            }
        }

        private static void GetReleasePoints(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers)
        {
            string query = "SELECT * FROM ReleasePoint";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    ReleasePointDataType releasePoint = new ReleasePointDataType();

                    releasePoint.ReleasePointTypeCode = readerEx.GetNullString("ReleasePointTypeCode");
                    releasePoint.ReleasePointDescription = readerEx.GetNullString("ReleasePointDescription");
                    releasePoint.ReleasePointStackHeightMeasure = readerEx.GetNullString("ReleasePointStackHeightMeasure");
                    releasePoint.ReleasePointStackHeightUnitofMeasureCode = readerEx.GetNullString("ReleasePointStackHeightUnitofMeasureCode");
                    releasePoint.ReleasePointStackDiameterMeasure = readerEx.GetNullString("ReleasePointStackDiameterMeasure");
                    releasePoint.ReleasePointStackDiameterUnitofMeasureCode = readerEx.GetNullString("ReleasePointStackDiameterUnitofMeasureCode");
                    releasePoint.ReleasePointExitGasVelocityMeasure = readerEx.GetNullString("ReleasePointExitGasVelocityMeasure");
                    releasePoint.ReleasePointExitGasVelocityUnitofMeasureCode = readerEx.GetNullString("ReleasePointExitGasVelocityUnitofMeasureCode");
                    releasePoint.ReleasePointExitGasFlowRateMeasure = readerEx.GetNullString("ReleasePointExitGasFlowRateMeasure");
                    releasePoint.ReleasePointExitGasFlowRateUnitofMeasureCode = readerEx.GetNullString("ReleasePointExitGasFlowRateUnitofMeasureCode");
                    releasePoint.ReleasePointExitGasTemperatureMeasure = readerEx.GetNullString("ReleasePointExitGasTemperatureMeasure");
                    releasePoint.ReleasePointFenceLineDistanceMeasure = readerEx.GetNullString("ReleasePointFenceLineDistanceMeasure");
                    releasePoint.ReleasePointFenceLineDistanceUnitofMeasureCode = readerEx.GetNullString("ReleasePointFenceLineDistanceUnitofMeasureCode");
                    releasePoint.ReleasePointFugitiveHeightMeasure = readerEx.GetNullString("ReleasePointFugitiveHeightMeasure");
                    releasePoint.ReleasePointFugitiveHeightUnitofMeasureCode = readerEx.GetNullString("ReleasePointFugitiveHeightUnitofMeasureCode");
                    releasePoint.ReleasePointFugitiveWidthMeasure = readerEx.GetNullString("ReleasePointFugitiveWidthMeasure");
                    releasePoint.ReleasePointFugitiveWidthUnitofMeasureCode = readerEx.GetNullString("ReleasePointFugitiveWidthUnitofMeasureCode");
                    releasePoint.ReleasePointFugitiveLengthMeasure = readerEx.GetNullString("ReleasePointFugitiveLengthMeasure");
                    releasePoint.ReleasePointFugitiveLengthUnitofMeasureCode = readerEx.GetNullString("ReleasePointFugitiveLengthUnitofMeasureCode");
                    releasePoint.ReleasePointFugitiveAngleMeasure = readerEx.GetNullString("ReleasePointFugitiveAngleMeasure");
                    releasePoint.ReleasePointComment = readerEx.GetNullString("ReleasePointComment");
                    releasePoint.ReleasePointStatusCode = readerEx.GetNullString("ReleasePointStatusCode");
                    releasePoint.ReleasePointStatusCodeYear = readerEx.GetNullString("ReleasePointStatusCodeYear");

                    releasePoint.ReleasePointIdentification = new ReleasePointIdentificationDataType[] { new ReleasePointIdentificationDataType() };
                    releasePoint.ReleasePointIdentification[0] = new ReleasePointIdentificationDataType();
                    releasePoint.ReleasePointIdentification[0].Identifier = readerEx.GetNullString("ReleasePointIdentifier");
                    releasePoint.ReleasePointIdentification[0].ProgramSystemCode = readerEx.GetNullString("ReleasePointProgramSystemCode");

                    bool parentFound = false;
                    foreach (FacilitySiteDataType fac in cers.FacilitySite)
                    {
                        if (fac.FacilityIdentification[0].FacilitySiteIdentifier == readerEx.GetNullString("FacilitySiteIdentifier")
                            && fac.FacilityIdentification[0].StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            fac.ReleasePoint = Windsor.Commons.Core.CollectionUtils.Add(releasePoint, fac.ReleasePoint);
                            parentFound = true;
                            break;
                        }
                    }
                    if (!parentFound) throw new ApplicationException("No parent Facility found for EmissionUnit");

                });
        }

        private static void GetEmissionsUnits(BaseWNOSPlugin plugin, SpringBaseDao dao, CERSDataType cers, string dataCategory)
        {
            string query = "SELECT * FROM EmissionsUnit";

            dao.QueryWithRowCallbackDelegate(CommandType.Text, query,
                delegate(IDataReader dataReader)
                {
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                    EmissionsUnitDataType emissionUnit = new EmissionsUnitDataType();

                    if (dataCategory.ToUpper() == "FACILITYINVENTORY")
                    {
                        emissionUnit.UnitDescription = readerEx.GetNullString("UnitDescription");
                        emissionUnit.UnitTypeCode = readerEx.GetNullString("UnitTypeCode");
                        emissionUnit.UnitDesignCapacity = readerEx.GetNullString("UnitDesignCapacity");
                        emissionUnit.UnitDesignCapacityUnitofMeasureCode = readerEx.GetNullString("UnitDesignCapacityUnitofMeasureCode");
                        emissionUnit.UnitStatusCode = readerEx.GetNullString("UnitStatusCode");
                        emissionUnit.UnitStatusCodeYear = readerEx.GetNullString("UnitStatusCodeYear");
                        emissionUnit.UnitOperationDate = CERSDate(readerEx.GetNullString("UnitOperationDate"), out emissionUnit.UnitOperationDateSpecified);
                        emissionUnit.UnitComment = readerEx.GetNullString("UnitComment");
                    }

                    emissionUnit.UnitIdentification = new EmissionsUnitIdentificationDataType[] { new EmissionsUnitIdentificationDataType() };
                    emissionUnit.UnitIdentification[0].Identifier = readerEx.GetNullString("UnitIdentifier");
                    emissionUnit.UnitIdentification[0].ProgramSystemCode = readerEx.GetNullString("UnitProgramSystemCode");

                    bool parentFound = false;
                    foreach (FacilitySiteDataType fac in cers.FacilitySite)
                    {
                        if (fac.FacilityIdentification[0].FacilitySiteIdentifier == readerEx.GetNullString("FacilitySiteIdentifier")
                            && fac.FacilityIdentification[0].StateAndCountyFIPSCode == readerEx.GetNullString("StateAndCountyFIPSCode"))
                        {
                            fac.EmissionsUnit = Windsor.Commons.Core.CollectionUtils.Add(emissionUnit, fac.EmissionsUnit);
                            parentFound = true;
                            break;
                        }
                    }

                    if (!parentFound) throw new ApplicationException("No parent Facility found for EmissionUnit");
                });
        }
        
        private static CERSDataType GetCEMSInfo(BaseWNOSPlugin plugin, SpringBaseDao dao)
        {
            CERSDataType cers = null;
            dao.DoSimpleQueryWithRowCallbackDelegate("CERS", null, null,
                delegate(IDataReader dataReader)
                {
                    if (cers != null)
                    {
                        throw new ArgumentException(string.Format("More than one row in the CERS table was found in the database"));
                    }
                    NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;

                    cers = new CERSDataType();
                    cers.UserIdentifier = readerEx.GetNullString("UserIdentifier");
                    cers.ProgramSystemCode = readerEx.GetNullString("ProgramSystemCode");
                    cers.EmissionsYear = readerEx.GetNullString("EmissionsYear");
                    cers.Model = readerEx.GetNullString("Model");
                    cers.ModelVersion = readerEx.GetNullString("ModelVersion");
                    cers.EmissionsCreationDate = CERSDate(readerEx.GetNullString("EmissionsCreationDate"), out cers.EmissionsCreationDateSpecified);
                    cers.SubmittalComment = readerEx.GetNullString("SubmittalComment");
                });
            if (cers == null)
            {
                throw new ArgumentException(string.Format("The CERS table is empty"));
            }
            return cers;
        }

        private static DataCategory GetExchangeHeaderInfo(BaseWNOSPlugin plugin, SpringBaseDao dao, out string authorName, out string organizationName,
                                                           out bool isProductionSubmission)
        {
            DataCategory dataCategory = DataCategory.None;

            string authorNamePriv = null, organizationNamePriv = null;
            bool isProductionSubmissionPriv = false;

            dao.DoSimpleQueryWithRowCallbackDelegate("ExchangeHeader", null, null,
            delegate(IDataReader dataReader)
            {
                if (dataCategory != DataCategory.None)
                {
                    throw new ArgumentException(string.Format("More than one Exchange Header was found in the database"));
                }
                NamedNullMappingDataReader readerEx = (NamedNullMappingDataReader)dataReader;
                authorNamePriv = readerEx.GetNullString("AuthorName");
                organizationNamePriv = readerEx.GetNullString("OrganizationName");
                string subType = readerEx.GetNullString("Property-SubmissionType");
                isProductionSubmissionPriv = string.Equals(subType, "Production", StringComparison.OrdinalIgnoreCase);
                string category = readerEx.GetNullString("Property-DataCategory");
                dataCategory = EnumUtils.FromDescription<DataCategory>(category);
            });
            if (dataCategory == DataCategory.None)
            {
                throw new ArgumentException(string.Format("No Exchange Header was found in the database"));
            }
            authorName = authorNamePriv;
            organizationName = organizationNamePriv;
            isProductionSubmission = isProductionSubmissionPriv;
            return dataCategory;
        }

        private static SpringBaseDao GetDao(BaseWNOSPlugin plugin, string databaseFilePath)
        {
            Spring.Data.Common.IDbProvider dbProvider = Spring.Data.Common.DbProviderFactory.GetDbProvider("OleDb-2.0");
            dbProvider.ConnectionString =
                string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""{0}"";User Id=admin;Password=;", databaseFilePath);
            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider, typeof(NamedNullMappingDataReader));

            try
            {
                using (System.Data.IDbConnection connection = dbProvider.CreateConnection())
                {
                    connection.Open();
                }
                plugin.AppendAuditLogEvent("Successfully connected to database \"{0}\"", databaseFilePath);
            }
            catch (Exception e)
            {
                throw new ArgumentException(string.Format("Failed to connect to database \"{0}\" with error: {1}", databaseFilePath,
                                            ExceptionUtils.GetDeepExceptionMessage(e)));
            }
            return springBaseDao;
        }

        /// <summary>
        /// Special method to override Spring bug with certain dates (e.g. 2011-06-01)
        /// </summary>
        /// <param name="testDate"></param>
        /// <param name="isSpecified"></param>
        /// <returns></returns>
        private static DateTime CERSDate(string testDate, out bool isSpecified)
        {
            isSpecified = false;
            DateTime returnDate = DateTime.MinValue;

            if (testDate != null && testDate.Length > 0)
            {
                isSpecified = DateTime.TryParse(testDate, out returnDate);
            }

            return returnDate;
        }
    }
}
