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
using System.Data;
using System.IO;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.AQS2
{
    public class AQSGetDataFromDatabase
    {
        private SpringBaseDao _baseDao;
        private bool _clearMetadataBeforeRun;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _siteId;
        private string _countyCode;
        private string _commaSeparatedActionCodes;

        public AQSGetDataFromDatabase(SpringBaseDao baseDao, bool clearMetadataBeforeRun,
                                      DateTime startDate, DateTime endDate, string siteId,
                                      string countyCode, string commaSeparatedActionCodes)
        {
            _baseDao = baseDao;
            _clearMetadataBeforeRun = clearMetadataBeforeRun;
            _startDate = startDate;
            _endDate = endDate;
            _siteId = siteId;
            _countyCode = countyCode;
            _commaSeparatedActionCodes = commaSeparatedActionCodes;
        }
        public AirQualitySubmissionType GetAirQualityData(IAppendAuditLogEvent appendAuditLogProvider)
        {
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            // ExecuteMetaDataValidation - Executes SP that inserts the metadata
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Data.ExecuteMetaDataValidation(_baseDao, _clearMetadataBeforeRun);

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            // Begin creation of the air quality submission
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            AirQualitySubmissionType rtn = new AirQualitySubmissionType();

            DataTable dtSiteID =
                Data.GetDataTable(_baseDao, Data.Tables.SiteIdentifierDetails, _startDate, _endDate,
                                  _siteId, _countyCode, string.Empty, _commaSeparatedActionCodes);

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            // Build the Site Identification List
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            if ((dtSiteID != null))
            {
                List<FacilitySiteListType> arSiteID = new List<FacilitySiteListType>();

                foreach (DataRow dr in dtSiteID.Rows)
                {

                    FacilitySiteListType fac = new FacilitySiteListType();

                    fac.SiteIdentifierDetails = new SiteIdentifierDetailsType();
                    fac.SiteIdentifierDetails.FacilitySiteIdentifier = new FacilitySiteIdentifierDataType();
                    fac.SiteIdentifierDetails.FacilitySiteIdentifier.Value = Util.ToStr(dr["FACILITY_SITE_ID"]);

                    {
                        List<string> valueList = null;
                        List<ItemsChoiceType> valueQualifierList = null;
                        AddToListsIfNotEmpty(Util.ToStr(dr["STATE_CD"]), ItemsChoiceType.StateCode,
                                             ref valueList, ref valueQualifierList);
                        AddToListsIfNotEmpty(Util.ToStr(dr["COUNTY_CD"]), ItemsChoiceType.CountyCode,
                                             ref valueList, ref valueQualifierList);
                        AddToListsIfNotEmpty(Util.ToStr(dr["NON_STATE_CD"]), ItemsChoiceType.NonStateCode,
                                             ref valueList, ref valueQualifierList);
                        AddToListsIfNotEmpty(Util.ToStr(dr["TRIBAL_CD"]), ItemsChoiceType.TribalCode,
                                             ref valueList, ref valueQualifierList);
                        SetListsIfNotEmpty(valueList, valueQualifierList, ref fac.SiteIdentifierDetails.Items,
                                           ref fac.SiteIdentifierDetails.ItemsElementName);
                    }

                    fac.BasicSiteInformation = new BasicSiteInformationType();
                    if (string.IsNullOrEmpty(_commaSeparatedActionCodes))
                    {
                        // Default hard-coded value for original NV plugin
                        fac.BasicSiteInformation.ActionCode = "I";
                    }
                    else
                    {
                        fac.BasicSiteInformation.ActionCode = Util.ToStr(dr["ACTION_CD"]);
                    }

                    fac.BasicSiteInformation.FacilitySiteDetails = new FacilitySiteDetailsType();
                    fac.BasicSiteInformation.FacilitySiteDetails.SupportAgencyCode = Util.ToStr(dr["SUPPORT_AGENCY_CD"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.LocationAddressText = Util.ToStr(dr["LOC_ADDR_TEXT"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.CityCode = Util.ToStr(dr["CITY_CD"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.AddressPostalCode = new AddressPostalCodeDataType();
                    fac.BasicSiteInformation.FacilitySiteDetails.AddressPostalCode.Value = Util.ToStr(dr["POSTAL_CODE"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.LocalIdentifier = Util.ToStr(dr["LOCAL_ID"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.LocalName = Util.ToStr(dr["LOCAL_NAME"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.LocalRegionCode = Util.ToStr(dr["LOCAL_REGION_CD"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.UrbanAreaCode = Util.ToStr(dr["URBAN_AREA_CD"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.AQCRCode = Util.ToStr(dr["AQCR_CD"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.LandUseIdentifier = Util.ToStr(dr["LAND_USE_ID"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.LocationSettingIdentifier = Util.ToStr(dr["LOC_SETTING_ID"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.SiteEstablishedDate = Util.ToStr(dr["SITE_EST_DATE"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.SiteTerminatedDate = Util.ToStr(dr["SITE_TERM_DATE"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.CongressionalDistrictCode = Util.ToStr(dr["CONG_DIST_CODE"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.CensusBlockCode = Util.ToStr(dr["CENSUS_BLOCK_CD"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.CensusBlockGroupCode = Util.ToStr(dr["CENSUS_BLOCK_GRP_CD"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.CensusTractCode = Util.ToStr(dr["CENSUS_TRACT_CD"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.ClassIAreaCode = Util.ToStr(dr["CLASS_AREA_CD"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.HQEvaluationDate = Util.ToStr(dr["HQ_EVAL_DATE"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.RegionalEvaluationDate = Util.ToStr(dr["REG_EVAL_DATE"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.DirectionFromCityCode = Util.ToStr(dr["DIR_FROM_CITY_CD"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.DistanceFromCityMeasure = Util.ToStr(dr["DIST_FROM_CITY_MSR"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.MetSiteIdentifier = Util.ToStr(dr["MET_SITE_ID"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.MetSiteTypeCode = Util.ToStr(dr["MET_SITE_TYPE_CD"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.DistanceToMetSiteMeasure = Util.ToStr(dr["DIST_TO_MET_SITE_MSR"]);
                    fac.BasicSiteInformation.FacilitySiteDetails.DirectionToMetSiteCode = Util.ToStr(dr["DIR_TO_MET_SITE_CODE"]);

                    if (fac.BasicSiteInformation.FacilitySiteDetails.AddressPostalCode.Value == null)
                    {
                        fac.BasicSiteInformation.FacilitySiteDetails.AddressPostalCode = null;
                    }
                    if ((fac.BasicSiteInformation.FacilitySiteDetails.SupportAgencyCode == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.LocationAddressText == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.CityCode == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.AddressPostalCode == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.LocalIdentifier == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.LocalName == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.LocalRegionCode == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.UrbanAreaCode == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.AQCRCode == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.LandUseIdentifier == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.LocationSettingIdentifier == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.SiteEstablishedDate == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.SiteTerminatedDate == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.CongressionalDistrictCode == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.CensusBlockCode == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.CensusBlockGroupCode == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.CensusTractCode == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.ClassIAreaCode == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.HQEvaluationDate == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.RegionalEvaluationDate == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.DirectionFromCityCode == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.DistanceFromCityMeasure == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.MetSiteIdentifier == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.MetSiteTypeCode == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.DistanceToMetSiteMeasure == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails.DirectionToMetSiteCode == null))
                    {
                        fac.BasicSiteInformation.FacilitySiteDetails = null;
                    }

                    fac.BasicSiteInformation.GeographicMonitoringLocation = new GeographicMonitoringLocationType();
                    {
                        List<object> valueList = null;
                        List<ItemsChoiceType1> valueQualifierList = null;
                        AddToListsIfNotEmpty(Util.ToStr(dr["LATITUDE"]), ItemsChoiceType1.LatitudeMeasure,
                                             ref valueList, ref valueQualifierList);
                        AddToListsIfNotEmpty(Util.ToStr(dr["LONGITUDE"]), ItemsChoiceType1.LongitudeMeasure,
                                             ref valueList, ref valueQualifierList);
                        AddToListsIfNotEmpty(Util.ToStr(dr["UTM_ZONE_CD"]), ItemsChoiceType1.UTMZoneCode,
                                             ref valueList, ref valueQualifierList);
                        AddToListsIfNotEmpty(Util.ToStr(dr["UTM_EASTING"]), ItemsChoiceType1.UTMEastingMeasure,
                                             ref valueList, ref valueQualifierList);
                        AddToListsIfNotEmpty(Util.ToStr(dr["UTM_NORTHING"]), ItemsChoiceType1.UTMNorthingMeasure,
                                             ref valueList, ref valueQualifierList);
                        SetListsIfNotEmpty(valueList, valueQualifierList, ref fac.BasicSiteInformation.GeographicMonitoringLocation.Items,
                                           ref fac.BasicSiteInformation.GeographicMonitoringLocation.ItemsElementName);
                    }
                    fac.BasicSiteInformation.GeographicMonitoringLocation.HorizontalCollectionMethodCode = Util.ToStr(dr["HORIZ_COL_MTHD"]);
                    fac.BasicSiteInformation.GeographicMonitoringLocation.HorizontalReferenceDatumName = Util.ToStr(dr["HORIZ_REF_DATUM"]);
                    fac.BasicSiteInformation.GeographicMonitoringLocation.SourceMapScaleNumber = Util.ToStr(dr["SRC_MAP_SCALE_NBR"]);
                    fac.BasicSiteInformation.GeographicMonitoringLocation.HorizontalAccuracyMeasure = Util.ToStr(dr["HORIZONTAL_ACCURACY"]);
                    fac.BasicSiteInformation.GeographicMonitoringLocation.VerticalMeasure = Util.ToStr(dr["VERTICAL_MEASURE"]);
                    fac.BasicSiteInformation.GeographicMonitoringLocation.VerticalMethodCode = Util.ToStr(dr["VERTICAL_MTHD_CD"]);
                    fac.BasicSiteInformation.GeographicMonitoringLocation.VerticalDatumIdentifier = Util.ToStr(dr["VERTICAL_DATUM_ID"]);
                    fac.BasicSiteInformation.GeographicMonitoringLocation.VerticalAccuracyMeasure = Util.ToStr(dr["VERTICAL_ACCR_MSR"]);
                    fac.BasicSiteInformation.GeographicMonitoringLocation.TimeZoneName = Util.ToStr(dr["TIME_ZONE_NAME"]);

                    if ((fac.BasicSiteInformation.GeographicMonitoringLocation.Items == null) &&
                        (fac.BasicSiteInformation.GeographicMonitoringLocation.HorizontalCollectionMethodCode == null) &&
                        (fac.BasicSiteInformation.GeographicMonitoringLocation.HorizontalReferenceDatumName == null) &&
                        (fac.BasicSiteInformation.GeographicMonitoringLocation.SourceMapScaleNumber == null) &&
                        (fac.BasicSiteInformation.GeographicMonitoringLocation.HorizontalAccuracyMeasure == null) &&
                        (fac.BasicSiteInformation.GeographicMonitoringLocation.VerticalMeasure == null) &&
                        (fac.BasicSiteInformation.GeographicMonitoringLocation.VerticalMethodCode == null) &&
                        (fac.BasicSiteInformation.GeographicMonitoringLocation.VerticalDatumIdentifier == null) &&
                        (fac.BasicSiteInformation.GeographicMonitoringLocation.VerticalAccuracyMeasure == null) &&
                        (fac.BasicSiteInformation.GeographicMonitoringLocation.TimeZoneName == null))
                    {
                        fac.BasicSiteInformation.GeographicMonitoringLocation = null;
                    }

                    if ((fac.BasicSiteInformation.ActionCode == null) &&
                         (fac.BasicSiteInformation.FacilitySiteDetails == null) &&
                         (fac.BasicSiteInformation.GeographicMonitoringLocation == null))
                    {
                        fac.BasicSiteInformation = null;
                    }

                    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    // MonitorIdentifierDetails
                    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    DataTable dtMonitorID =
                        Data.GetDataTable(_baseDao, Data.Tables.MonitorIdentifierDetails, _startDate, _endDate,
                                          _siteId, _countyCode, Util.ToStr(dr["AQS_SITE_ID_PK"]), _commaSeparatedActionCodes);

                    if ((dtMonitorID != null))
                    {
                        List<MonitorListType> arMonitorID = new List<MonitorListType>();
                        foreach (DataRow drMonitorID in dtMonitorID.Rows)
                        {

                            MonitorListType ml = new MonitorListType();
                            ml.MonitorIdentifierDetails = new MonitorIdentifierDetailsType();
                            ml.MonitorIdentifierDetails.SubstanceIdentifier = new SubstanceIdentifierDataType();
                            ml.MonitorIdentifierDetails.SubstanceIdentifier.Value = Util.ToStr(drMonitorID["SUBST_ID"]);
                            ml.MonitorIdentifierDetails.SubstanceOccurrenceCode = Util.ToStr(drMonitorID["SUBST_OCCURENCE_CD"]);

                            ml.BasicMonitoringInformation = new BasicMonitoringInformationType();
                            if (string.IsNullOrEmpty(_commaSeparatedActionCodes))
                            {
                                // Default hard-coded value for original NV plugin
                                ml.BasicMonitoringInformation.ActionCode = "I";
                            }
                            else
                            {
                                ml.BasicMonitoringInformation.ActionCode = Util.ToStr(drMonitorID["ACTION_CD"]);
                            }
                            ml.BasicMonitoringInformation.ProjectClassCode = Util.ToStr(drMonitorID["PROJECT_CLASS_CD"]);
                            ml.BasicMonitoringInformation.DominantSourceText = Util.ToStr(drMonitorID["DOMINANT_SCR_TXT"]);
                            ml.BasicMonitoringInformation.MeasurementScaleIdentifier = Util.ToStr(drMonitorID["MEASUREMENT_SCALE_ID"]);
                            ml.BasicMonitoringInformation.OpenPathIdentifier = Util.ToStr(drMonitorID["OPEN_PATH_ID"]);
                            ml.BasicMonitoringInformation.ProbeLocationCode = Util.ToStr(drMonitorID["PROBE_LOC_CODE"]);
                            ml.BasicMonitoringInformation.ProbeHeightMeasure = Util.ToStr(drMonitorID["PROBE_HEIGHT_MSR"]);
                            ml.BasicMonitoringInformation.HorizontalDistanceMeasure = Util.ToStr(drMonitorID["HORIZ_DIST_MSR"]);
                            ml.BasicMonitoringInformation.VerticalDistanceMeasure = Util.ToStr(drMonitorID["VERT_DIST_MSR"]);
                            ml.BasicMonitoringInformation.SurrogateIndicator = Util.ToStr(drMonitorID["SURROGATE_IND"]);
                            ml.BasicMonitoringInformation.UnrestrictedAirFlowIndicator = Util.ToStr(drMonitorID["UNRESTR_AIR_FLOW_IND"]);
                            ml.BasicMonitoringInformation.SampleResidenceTime = Util.ToStr(drMonitorID["SAMPLE_RESID_TIME"]);
                            ml.BasicMonitoringInformation.WorstSiteTypeCode = Util.ToStr(drMonitorID["WORST_SITE_TYPE_CD"]);
                            ml.BasicMonitoringInformation.ApplicableNAAQSIndicator = Util.ToStr(drMonitorID["APPLICABLE_NAAQS_IND"]);
                            ml.BasicMonitoringInformation.SpatialAverageIndicator = Util.ToStr(drMonitorID["SPACIAL_AVG_IND"]);
                            ml.BasicMonitoringInformation.ScheduleExemptionIndicator = Util.ToStr(drMonitorID["SCHED_EXEMPT_IND"]);
                            ml.BasicMonitoringInformation.CommunityMonitoringZoneCode = Util.ToStr(drMonitorID["CMNTY_MONITOR_ZONE"]);
                            ml.BasicMonitoringInformation.MonitorCloseDate = Util.ToStr(drMonitorID["MONITOR_CLOSE_DATE"]);

                            // TODO ml.BasicMonitoringInformation.PollutantAreaCode

                            if ((ml.BasicMonitoringInformation.ActionCode == null) && (ml.BasicMonitoringInformation.ProjectClassCode == null) &&
                                (ml.BasicMonitoringInformation.DominantSourceText == null) && (ml.BasicMonitoringInformation.MeasurementScaleIdentifier == null) &&

                                (ml.BasicMonitoringInformation.OpenPathIdentifier == null) && (ml.BasicMonitoringInformation.ProbeLocationCode == null) &&
                                (ml.BasicMonitoringInformation.ProbeHeightMeasure == null) && (ml.BasicMonitoringInformation.HorizontalDistanceMeasure == null) &&
                                (ml.BasicMonitoringInformation.VerticalDistanceMeasure == null) && (ml.BasicMonitoringInformation.SurrogateIndicator == null) &&
                                (ml.BasicMonitoringInformation.UnrestrictedAirFlowIndicator == null) && (ml.BasicMonitoringInformation.SampleResidenceTime == null) &&

                                (ml.BasicMonitoringInformation.WorstSiteTypeCode == null) && (ml.BasicMonitoringInformation.ApplicableNAAQSIndicator == null) &&
                                (ml.BasicMonitoringInformation.SpatialAverageIndicator == null) && (ml.BasicMonitoringInformation.ScheduleExemptionIndicator == null) &&
                                (ml.BasicMonitoringInformation.CommunityMonitoringZoneCode == null) && (ml.BasicMonitoringInformation.MonitorCloseDate == null) &&
                                (ml.BasicMonitoringInformation.PollutantAreaCode == null))
                            {
                                ml.BasicMonitoringInformation = null;
                            }

                            DataTable dtSamplingPeriodList = null;
                            dtSamplingPeriodList = Data.GetDataTable(_baseDao, Data.Tables.MonitorSamplingPeriod, _startDate, _endDate,
                                                                     _siteId, _countyCode, Util.ToStr(drMonitorID["AQS_MONITOR_ID_PK"]),
                                                                     _commaSeparatedActionCodes);
                            if ((dtSamplingPeriodList != null))
                            {
                                List<MonitorSamplingPeriodType> sampleDataList = new List<MonitorSamplingPeriodType>();
                                foreach (DataRow drSampleData in dtSamplingPeriodList.Rows)
                                {

                                    MonitorSamplingPeriodType sampleData = new MonitorSamplingPeriodType();
                                    sampleData.SamplingBeginDate = Util.ToStr(drSampleData["SAMPLING_BEGIN_DATE"]);
                                    sampleData.SamplingEndDate = Util.ToStr(drSampleData["SAMPLING_END_DATE"]);
                                    sampleDataList.Add(sampleData);
                                }
                                ml.MonitorSamplingPeriod = sampleDataList.Count > 0 ? sampleDataList.ToArray() : null;
                            }



                            DataTable dtSamplingSchList = null;
                            dtSamplingSchList = Data.GetDataTable(_baseDao, Data.Tables.MonitorSamplingSchedule, _startDate, _endDate,
                                                                     _siteId, _countyCode, Util.ToStr(drMonitorID["AQS_MONITOR_ID_PK"]),
                                                                     _commaSeparatedActionCodes);
                            if ((dtSamplingSchList != null))
                            {
                                List<MonitorSamplingScheduleType> sampleDataList = new List<MonitorSamplingScheduleType>();
                                foreach (DataRow drSampleData in dtSamplingSchList.Rows)
                                {

                                    MonitorSamplingScheduleType sampleData = new MonitorSamplingScheduleType();
                                    if (string.IsNullOrEmpty(_commaSeparatedActionCodes))
                                    {
                                        // Default hard-coded value for original NV plugin
                                        sampleData.ActionCode = "I";
                                    }
                                    else
                                    {
                                        sampleData.ActionCode = Util.ToStr(drSampleData["ACTION_CD"]);
                                    }
                                    sampleData.FrequencyCode = Util.ToStr(drSampleData["FREQUENCY_CD"]);
                                    sampleData.RCFBeginDate = Util.ToStr(drSampleData["RCF_BEGIN_DATE"]);
                                    sampleData.RCFEndDate = Util.ToStr(drSampleData["RCF_END_DATE"]);
                                    sampleData.RCFJanuaryCode = Util.ToStr(drSampleData["RCF_JAN_CD"]);
                                    sampleData.RCFFebruaryCode = Util.ToStr(drSampleData["RCF_FEB_CD"]);
                                    sampleData.RCFMarchCode = Util.ToStr(drSampleData["RCF_MAR_CD"]);
                                    sampleData.RCFAprilCode = Util.ToStr(drSampleData["RCF_APR_CD"]);
                                    sampleData.RCFMayCode = Util.ToStr(drSampleData["RCR_MAY_CD"]);
                                    sampleData.RCFJuneCode = Util.ToStr(drSampleData["RCR_JUN_CD"]);
                                    sampleData.RCFJulyCode = Util.ToStr(drSampleData["RCR_JUL_CD"]);
                                    sampleData.RCFAugustCode = Util.ToStr(drSampleData["RCR_AUG_CD"]);
                                    sampleData.RCFSeptemberCode = Util.ToStr(drSampleData["RCR_SEP_CD"]);
                                    sampleData.RCFOctoberCode = Util.ToStr(drSampleData["RCR_OCT_CD"]);
                                    sampleData.RCFNovemberCode = Util.ToStr(drSampleData["RCR_NOV_CD"]);
                                    sampleData.RCFDecemberCode = Util.ToStr(drSampleData["RCR_DEC_CD"]);
                                    sampleDataList.Add(sampleData);
                                }
                                ml.MonitorSamplingSchedule = sampleDataList.Count > 0 ? sampleDataList.ToArray() : null;
                            }

                            DataTable dtObjectiveInformationList = null;
                            dtObjectiveInformationList =
                                Data.GetDataTable(_baseDao, Data.Tables.MonitorObjectiveInformation, _startDate, _endDate,
                                                  _siteId, _countyCode, Util.ToStr(drMonitorID["AQS_MONITOR_ID_PK"]),
                                                  _commaSeparatedActionCodes);
                            if ((dtObjectiveInformationList != null))
                            {
                                List<MonitorObjectiveInformationType> informationDataList = new List<MonitorObjectiveInformationType>();
                                foreach (DataRow drInformationData in dtObjectiveInformationList.Rows)
                                {

                                    MonitorObjectiveInformationType informationData = new MonitorObjectiveInformationType();
                                    if (string.IsNullOrEmpty(_commaSeparatedActionCodes))
                                    {
                                        // Default hard-coded value for original NV plugin
                                        informationData.ActionCode = "I";
                                    }
                                    else
                                    {
                                        informationData.ActionCode = Util.ToStr(drInformationData["ACTION_CD"]);
                                    }
                                    informationData.MonitorObjectiveIdentifier = Util.ToStr(drInformationData["MONITOR_OBJ_ID"]);
                                    {
                                        List<string> valueList = null;
                                        List<ItemChoiceType> valueQualifierList = null;
                                        AddToListsIfNotEmpty(Util.ToStr(dr["URBAN_AREA_REP_CD"]), ItemChoiceType.UrbanAreaRepresentedCode,
                                                             ref valueList, ref valueQualifierList);
                                        AddToListsIfNotEmpty(Util.ToStr(dr["METRO_SA_REP_CD"]), ItemChoiceType.MSARepresentedCode,
                                                             ref valueList, ref valueQualifierList);
                                        AddToListsIfNotEmpty(Util.ToStr(dr["COVE_BS_REP_CD"]), ItemChoiceType.CBSARepresentedCode,
                                                             ref valueList, ref valueQualifierList);
                                        AddToListsIfNotEmpty(Util.ToStr(dr["COMBINED_SA_REP_CD"]), ItemChoiceType.CSARepresentedCode,
                                                             ref valueList, ref valueQualifierList);
                                        if (valueList == null)
                                        {
                                            throw new ArgumentException(string.Format("No item values specified for table AQS_MONITOR_OBJ_INFO where AQS_MONITOR_OBJ_INFO_PK = '{0}'",
                                                                        Util.ToStr(dr["AQS_MONITOR_OBJ_INFO_PK"])));
                                        }
                                        if (valueList.Count > 1)
                                        {
                                            throw new ArgumentException(string.Format("Too many item values specified for table AQS_MONITOR_OBJ_INFO where AQS_MONITOR_OBJ_INFO_PK = '{0}'",
                                                                        Util.ToStr(dr["AQS_MONITOR_OBJ_INFO_PK"])));
                                        }
                                        informationData.Item = valueList[0];
                                        informationData.ItemElementName = valueQualifierList[0];
                                    }
                                    informationDataList.Add(informationData);
                                }
                                ml.MonitorObjectiveInformation = informationDataList.Count > 0 ? informationDataList.ToArray() : null;
                            }

                            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            //Raw Data List
                            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                            DataTable dtRawDataList = null;
                            dtRawDataList = Data.GetDataTable(_baseDao, Data.Tables.TransactionProtocolDetails, _startDate, _endDate,
                                                              _siteId, _countyCode, Util.ToStr(drMonitorID["AQS_MONITOR_ID_PK"]),
                                                              _commaSeparatedActionCodes);

                            if ((dtRawDataList != null))
                            {

                                //Dim arTranProt As New ArrayList
                                List<RawDataListType> arRawData = new List<RawDataListType>();
                                foreach (DataRow drRawData in dtRawDataList.Rows)
                                {

                                    RawDataListType rawData = new RawDataListType();
                                    rawData.TransactionProtocolDetails = new TransactionProtocolDetailsType();

#if V_2_2
                                    {
                                        List<object> valueList = null;
                                        List<ItemsChoiceType2> valueQualifierList = null;
                                        AddToListsIfNotEmpty(GetCompositeTypeIdentifier(Util.ToStr(drRawData["COMPOSITE_TYPE_ID"])),
                                                             ItemsChoiceType2.CompositeTypeIdentifier,
                                                             ref valueList, ref valueQualifierList);
                                        AddToListsIfNotEmpty(Util.ToStr(drRawData["DURATION_CD"]), ItemsChoiceType2.DurationCode,
                                                             ref valueList, ref valueQualifierList);
                                        AddToListsIfNotEmpty(Util.ToStr(drRawData["FREQUENCY_CD"]), ItemsChoiceType2.FrequencyCode,
                                                             ref valueList, ref valueQualifierList);
                                        SetListsIfNotEmpty(valueList, valueQualifierList, ref rawData.TransactionProtocolDetails.Items,
                                                           ref rawData.TransactionProtocolDetails.ItemsElementName);
                                    }
#else // V_2_2
                                    rawData.TransactionProtocolDetails.CompositeTypeIdentifier = Util.ToStr(drRawData["COMPOSITE_TYPE_ID"]);
                                    rawData.TransactionProtocolDetails.DurationCode = Util.ToStr(drRawData["DURATION_CD"]);
                                    rawData.TransactionProtocolDetails.FrequencyCode = Util.ToStr(drRawData["FREQUENCY_CD"]);
#endif // V_2_2
                                    rawData.TransactionProtocolDetails.MethodIdentifierCode = Util.ToStr(drRawData["METHOD_ID_CD"]);
                                    rawData.TransactionProtocolDetails.MeasureUnitCode = Util.ToStr(drRawData["MEASURE_UNIT_CD"]);

#if V_2_2
                                    rawData.TransactionProtocolDetails.AlternateMDLValue = Util.ToStr(drRawData["ALTERNATE_MDL_VALUE"]);
#else // V_2_2
                                    if (Util.isValidDecimal(drRawData["ALTERNATE_MDL_VALUE"]))
                                    {
                                        rawData.TransactionProtocolDetails.AlternateMDLValue = Util.ToDecimal(drRawData["ALTERNATE_MDL_VALUE"]);
                                        rawData.TransactionProtocolDetails.AlternateMDLValueSpecified = true;
                                    }
                                    else
                                    {
                                        rawData.TransactionProtocolDetails.AlternateMDLValueSpecified = false;
                                    }
#endif // V_2_2

                                    List<object> rawDataItems = new List<object>();
                                    string transProtocolPk = Util.ToStr(drRawData["AQS_TRANS_PROTOCOL_PK"]);

                                    AddRawResults(rawDataItems, transProtocolPk);

                                    AddRawPrecisionInformation(rawDataItems, transProtocolPk);

                                    AddRawCompositeInformation(rawDataItems, transProtocolPk);

                                    AddRawAccuracyInformation(rawDataItems, transProtocolPk);

                                    AddBlankInformation(rawDataItems, transProtocolPk);

                                    AddAnnualSummaryInformation(rawDataItems, transProtocolPk);

                                    rawData.Items = rawDataItems.ToArray();
                                    arRawData.Add(rawData);
                                }

                                // End loop thru Raw Data

                                ml.RawDataList = arRawData.ToArray();
                            }



                            arMonitorID.Add(ml);
                        }

                        // End loop thru MonitorIdentifierDetails

                        fac.MonitorList = arMonitorID.ToArray();
                    }

                    //dtMonitorID is not null

                    arSiteID.Add(fac);
                }

                rtn.FacilitySiteList = arSiteID.ToArray();
            }

            rtn.FileGenerationPurposeCode = FileGenerationPurposeCodeType.AQS;
            rtn.FileGenerationDateTime = DateTime.Now.ToString("s");
            if (CollectionUtils.IsNullOrEmpty(rtn.FacilitySiteList))
            {
                throw new InvalidDataException("No AQS facility sites where found to submit.");
            }
            return rtn;
        }
        private void AddRawResults(List<object> rawDataItems, string transProtocolPk)
        {
            DataTable dtRawResults = null;
            dtRawResults = Data.GetDataTable(_baseDao, Data.Tables.TransactionRawResultDetails, _startDate, _endDate,
                                             _siteId, _countyCode, transProtocolPk, _commaSeparatedActionCodes);

            if ((dtRawResults != null))
            {

                foreach (DataRow drResult in dtRawResults.Rows)
                {
                    RawResultsType rawRslt = new RawResultsType();
                    if (string.IsNullOrEmpty(_commaSeparatedActionCodes))
                    {
                        // Default hard-coded value for original NV plugin
                        rawRslt.ActionCode = "I";
                    }
                    else
                    {
                        rawRslt.ActionCode = Util.ToStr(drResult["ACTION_CD"]);
                    }
                    if (Util.IsValidDateTime(drResult["SMPL_COLL_START_DATE"], DateTime.Parse("1/1/1950")))
                    {
#if V_2_2
                        rawRslt.SampleCollectionStartDate = Util.ToStr(drResult["SMPL_COLL_START_DATE"]);
#else // V_2_2
                        rawRslt.SampleCollectionStartDate = Util.ToDateTime(drResult["SMPL_COLL_START_DATE"]);
#endif // V_2_2
                    }
                    rawRslt.SampleCollectionStartTime = Util.ToStr(drResult["SMPL_COLL_START_TIME"]);

                    rawRslt.RawValueDetails = new RawValueDetailsType();
#if V_2_2
                    {
                        List<object> valueList = null;
                        List<ItemsChoiceType3> valueQualifierList = null;
                        AddToListsIfNotEmpty(Util.ToStr(drResult["MEASURE_VALUE"]), ItemsChoiceType3.MeasureValue,
                                             ref valueList, ref valueQualifierList);
                        AddToListsIfNotEmpty(Util.ToStr(drResult["UNCERTAINTY_VALUE"]), ItemsChoiceType3.UncertaintyValue,
                                             ref valueList, ref valueQualifierList);
                        AddToListsIfNotEmpty(Util.ToStr(drResult["NULL_DATA_CD"]), ItemsChoiceType3.NullDataCode,
                                             ref valueList, ref valueQualifierList);
                        SetListsIfNotEmpty(valueList, valueQualifierList, ref rawRslt.RawValueDetails.Items,
                                           ref rawRslt.RawValueDetails.ItemsElementName);
                    }

#else // V_2_2
                    rawRslt.RawValueDetails.MeasureValue = Util.ToStr(drResult["MEASURE_VALUE"]);
                    rawRslt.RawValueDetails.UncertaintyValue = Util.ToStr(drResult["UNCERTAINTY_VALUE"]);
                    rawRslt.RawValueDetails.NullDataCode = Util.ToStr(drResult["NULL_DATA_CD"]);
#endif // V_2_2
                    rawRslt.RawValueDetails.DataValidityCode = Util.ToStr(drResult["DATA_VALIDITY_CD"]);
                    rawRslt.RawValueDetails.DataApprovalIndicator = Util.ToStr(drResult["DATA_APPROVAL_IND"]);


                    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    //QualifierCode
                    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    DataTable dtQC = null;
                    dtQC = Data.GetDataTable(_baseDao, Data.Tables.QualifierCode, _startDate, _endDate,
                                             _siteId, _countyCode, Util.ToStr(drResult["AQS_RAW_RES_PK"]),
                                             _commaSeparatedActionCodes);

                    if ((dtQC != null))
                    {

                        List<string> arQC = new List<string>();
                        foreach (DataRow drQC in dtQC.Rows)
                        {
                            arQC.Add(Util.ToStr(drQC["RES_QUAL_CD"]));
                        }

                        rawRslt.RawValueDetails.ResultQualifierCode = arQC.ToArray();
                    }

                    if ((rawRslt.RawValueDetails.Items == null) &&
                         (rawRslt.RawValueDetails.DataValidityCode == null) && (rawRslt.RawValueDetails.DataApprovalIndicator == null) &&
                         (rawRslt.RawValueDetails.ResultQualifierCode == null))
                    {
                        rawRslt.RawValueDetails = null;
                    }

                    rawDataItems.Add(rawRslt);
                }
            }
        }
        private void AddRawPrecisionInformation(List<object> rawDataItems, string transProtocolPk)
        {
            DataTable dtRawResults = null;
            dtRawResults = Data.GetDataTable(_baseDao, Data.Tables.TransactionRawPrecisionInformation, _startDate, _endDate,
                                             _siteId, _countyCode, transProtocolPk, _commaSeparatedActionCodes);

            if ((dtRawResults != null))
            {

                foreach (DataRow drResult in dtRawResults.Rows)
                {
                    RawPrecisionInformationType rawRslt = new RawPrecisionInformationType();
                    if (string.IsNullOrEmpty(_commaSeparatedActionCodes))
                    {
                        // Default hard-coded value for original NV plugin
                        rawRslt.ActionCode = "I";
                    }
                    else
                    {
                        rawRslt.ActionCode = Util.ToStr(drResult["ACTION_CD"]);
                    }
                    rawRslt.PrecisionTypeIdentifier = Util.ToStr(drResult["PREC_TYPE_ID"]);
                    rawRslt.PrecisionIDNumber = Util.ToStr(drResult["PREC_ID_NUM"]);
                    rawRslt.ActualMethodCode = Util.ToStr(drResult["ACTUAL_METHOD_CD"]);
#if V_2_2
                    rawRslt.PrecisionCheckDate = Util.ToStr(drResult["PREC_CHECK_DATE"]);
#else // V_2_2
                    rawRslt.PrecisionCheckDate = Util.ToDateTime(drResult["PREC_CHECK_DATE"]);
#endif // V_2_2
                    rawRslt.ActualValue = Util.ToStr(drResult["ACTUAL_VALUE"]);
                    rawRslt.IndicatedMethodCode = Util.ToStr(drResult["INDICATED_METHOD_CD"]);
                    rawRslt.IndicatedValue = Util.ToStr(drResult["INDICATED_VALUE"]);
                    rawRslt.CollocatedPocIDNumber = Util.ToStr(drResult["COL_POC_ID_NUM"]);
                    rawRslt.PrecisionSampleIdentifier = Util.ToStr(drResult["PREC_SMPL_ID"]);
                    rawRslt.AuditAgencyCode = Util.ToStr(drResult["AUDIT_AGENCY_CD"]);

                    rawDataItems.Add(rawRslt);
                }
            }
        }
        private void AddRawCompositeInformation(List<object> rawDataItems, string transProtocolPk)
        {
            DataTable dtRawResults = null;
            dtRawResults = Data.GetDataTable(_baseDao, Data.Tables.TransactionRawCompositeInformation, _startDate, _endDate,
                                             _siteId, _countyCode, transProtocolPk, _commaSeparatedActionCodes);

            if ((dtRawResults != null))
            {

                foreach (DataRow drResult in dtRawResults.Rows)
                {
                    RawCompositeInformationType rawRslt = new RawCompositeInformationType();
                    if (string.IsNullOrEmpty(_commaSeparatedActionCodes))
                    {
                        // Default hard-coded value for original NV plugin
                        rawRslt.ActionCode = "I";
                    }
                    else
                    {
                        rawRslt.ActionCode = Util.ToStr(drResult["ACTION_CD"]);
                    }
                    rawRslt.ObservationYear = Util.ToStr(drResult["OBSERVATION_YEAR"]);
                    rawRslt.CompositePeriodCode = Util.ToStr(drResult["COMP_PERIOD_CD"]);
                    rawRslt.SamplesCount = Util.ToStr(drResult["SAMPLES_COUNT"]);
                    rawRslt.CompositeSampleValue = Util.ToStr(drResult["COMP_SMPL_VALUE"]);
                    rawRslt.UncertaintyValue = Util.ToStr(drResult["UNCERTAINTY_VALUE"]);

                    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    //QualifierCode
                    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    DataTable dtQC = null;
                    dtQC = Data.GetDataTable(_baseDao, Data.Tables.CompositeInformationQualifierCode, _startDate, _endDate,
                                             _siteId, _countyCode, Util.ToStr(drResult["AQS_RAW_COMP_INFO_PK"]),
                                             _commaSeparatedActionCodes);

                    if ((dtQC != null))
                    {

                        List<string> arQC = new List<string>();
                        foreach (DataRow drQC in dtQC.Rows)
                        {
                            arQC.Add(Util.ToStr(drQC["RES_QUAL_CD"]));
                        }

                        rawRslt.ResultQualifierCode = arQC.ToArray();
                    }


                    rawDataItems.Add(rawRslt);
                }
            }
        }
        private void AddRawAccuracyInformation(List<object> rawDataItems, string transProtocolPk)
        {
            DataTable dtRawResults = null;
            dtRawResults = Data.GetDataTable(_baseDao, Data.Tables.TransactionRawAccuracyInformation, _startDate, _endDate,
                                             _siteId, _countyCode, transProtocolPk, _commaSeparatedActionCodes);

            if ((dtRawResults != null))
            {

                foreach (DataRow drResult in dtRawResults.Rows)
                {
                    RawAccuracyInformationType rawRslt = new RawAccuracyInformationType();
                    if (string.IsNullOrEmpty(_commaSeparatedActionCodes))
                    {
                        // Default hard-coded value for original NV plugin
                        rawRslt.ActionCode = "I";
                    }
                    else
                    {
                        rawRslt.ActionCode = Util.ToStr(drResult["ACTION_CD"]);
                    }
                    rawRslt.AccuracyAuditIDNumber = Util.ToStr(drResult["ACCU_AUDIT_ID_NUM"]);
                    rawRslt.AuditYear = Util.ToStr(drResult["AUDIT_YEAR"]);
                    rawRslt.QuarterRepresentedCode = Util.ToStr(drResult["QTR_REP_CD"]);
#if V_2_2
                    rawRslt.AccuracyDate = Util.ToStr(drResult["ACCU_DATE"]);
#else // V_2_2
                    rawRslt.AccuracyDate = Util.ToDateTime(drResult["ACCU_DATE"]);
#endif // V_2_2
                    rawRslt.AuditTypeIdentifier = Util.ToStr(drResult["AUDIT_TYPE_ID"]);
                    rawRslt.LocalStandardIdentifier = Util.ToStr(drResult["LOCAL_STAND_ID"]);
                    rawRslt.AuditClassIdentifier = Util.ToStr(drResult["AUDIT_CLASS_ID"]);
                    rawRslt.AccuracyTypeIdentifier = Util.ToStr(drResult["ACCU_TYPE_ID"]);
                    rawRslt.AuditSampleIdentifier = Util.ToStr(drResult["AUDIT_SMPL_ID"]);
#if V_2_2
                    rawRslt.LocalStandardExpirationDate = Util.ToStr(drResult["LOCAL_STAND_EXP_DATE"]);
                    rawRslt.AuditScheduledDate = Util.ToStr(drResult["AUDIT_SCH_DATE"]);
#else // V_2_2
                    rawRslt.LocalStandardExpirationDate = Util.ToDateTime(drResult["LOCAL_STAND_EXP_DATE"]);
                    rawRslt.LocalStandardExpirationDateSpecified = !drResult.IsNull("LOCAL_STAND_EXP_DATE");
                    rawRslt.AuditScheduledDate = Util.ToDateTime(drResult["AUDIT_SCH_DATE"]);
                    rawRslt.AuditScheduledDateSpecified = !drResult.IsNull("AUDIT_SCH_DATE");
#endif // V_2_2
                    rawRslt.Level1ActualValue = Util.ToStr(drResult["LVL1_ACT_VALUE"]);
                    rawRslt.Level1IndicatedValue = Util.ToStr(drResult["LVL1_IND_VALUE"]);
                    rawRslt.Level2ActualValue = Util.ToStr(drResult["LVL2_ACT_VALUE"]);
                    rawRslt.Level2IndicatedValue = Util.ToStr(drResult["LVL2_IND_VALUE"]);
                    rawRslt.Level3ActualValue = Util.ToStr(drResult["LVL3_ACT_VALUE"]);
                    rawRslt.Level3IndicatedValue = Util.ToStr(drResult["LVL3_IND_VALUE"]);
                    rawRslt.Level4ActualValue = Util.ToStr(drResult["LVL4_ACT_VALUE"]);
                    rawRslt.Level4IndicatedValue = Util.ToStr(drResult["LVL4_IND_VALUE"]);
                    rawRslt.Level5ActualValue = Util.ToStr(drResult["LVL5_ACT_VALUE"]);
                    rawRslt.Level5IndicatedValue = Util.ToStr(drResult["LVL5_IND_VALUE"]);
                    rawRslt.ZeroSpanValue = Util.ToStr(drResult["ZERO_SPAN_VALUE"]);

                    rawDataItems.Add(rawRslt);
                }
            }
        }
        private void AddBlankInformation(List<object> rawDataItems, string transProtocolPk)
        {
            DataTable dtRawResults = null;
            dtRawResults = Data.GetDataTable(_baseDao, Data.Tables.TransactionBlankInformation, _startDate, _endDate,
                                             _siteId, _countyCode, transProtocolPk, _commaSeparatedActionCodes);

            if ((dtRawResults != null))
            {

                foreach (DataRow drResult in dtRawResults.Rows)
                {
                    BlankInformationType rawRslt = new BlankInformationType();
                    if (string.IsNullOrEmpty(_commaSeparatedActionCodes))
                    {
                        // Default hard-coded value for original NV plugin
                        rawRslt.ActionCode = "I";
                    }
                    else
                    {
                        rawRslt.ActionCode = Util.ToStr(drResult["ACTION_CD"]);
                    }
#if V_2_2
                    rawRslt.SampleCollectionStartDate = Util.ToStr(drResult["SMPL_COLL_START_DATE"]);
#else // V_2_2
                    rawRslt.SampleCollectionStartDate = Util.ToDateTime(drResult["SMPL_COLL_START_DATE"]);
#endif // V_2_2
                    rawRslt.SampleCollectionStartTime = Util.ToStr(drResult["SMPL_COLL_START_TIME"]);
                    rawRslt.BlankTypeCode = Util.ToStr(drResult["BLANK_TYPE_CD"]);
                    rawRslt.RawValueDetails = new RawValueDetailsType();
#if V_2_2
                    {
                        List<object> valueList = null;
                        List<ItemsChoiceType3> valueQualifierList = null;
                        AddToListsIfNotEmpty(Util.ToStr(drResult["MEASURE_VALUE"]), ItemsChoiceType3.MeasureValue,
                                             ref valueList, ref valueQualifierList);
                        AddToListsIfNotEmpty(Util.ToStr(drResult["UNCERTAINTY_VALUE"]), ItemsChoiceType3.UncertaintyValue,
                                             ref valueList, ref valueQualifierList);
                        AddToListsIfNotEmpty(Util.ToStr(drResult["NULL_DATA_CD"]), ItemsChoiceType3.NullDataCode,
                                             ref valueList, ref valueQualifierList);
                        SetListsIfNotEmpty(valueList, valueQualifierList, ref rawRslt.RawValueDetails.Items,
                                           ref rawRslt.RawValueDetails.ItemsElementName);
                    }

#else // V_2_2
                    rawRslt.RawValueDetails.MeasureValue = Util.ToStr(drResult["MEASURE_VALUE"]);
                    rawRslt.RawValueDetails.UncertaintyValue = Util.ToStr(drResult["UNCERTAINTY_VALUE"]);
                    rawRslt.RawValueDetails.NullDataCode = Util.ToStr(drResult["NULL_DATA_CD"]);
#endif // V_2_2
                    rawRslt.RawValueDetails.DataValidityCode = Util.ToStr(drResult["DATA_VALIDITY_CD"]);
                    rawRslt.RawValueDetails.DataApprovalIndicator = Util.ToStr(drResult["DATA_APPROVAL_IND"]);

                    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    //QualifierCode
                    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    DataTable dtQC = null;
                    dtQC = Data.GetDataTable(_baseDao, Data.Tables.BlankQualifierCode, _startDate, _endDate,
                                             _siteId, _countyCode, Util.ToStr(drResult["AQS_BLANK_INFO_PK"]),
                                             _commaSeparatedActionCodes);

                    if ((dtQC != null))
                    {

                        List<string> arQC = new List<string>();
                        foreach (DataRow drQC in dtQC.Rows)
                        {
                            arQC.Add(Util.ToStr(drQC["RES_QUAL_CD"]));
                        }

                        rawRslt.RawValueDetails.ResultQualifierCode = arQC.ToArray();
                    }

                    if ((rawRslt.RawValueDetails.Items == null) &&
                         (rawRslt.RawValueDetails.DataValidityCode == null) && (rawRslt.RawValueDetails.DataApprovalIndicator == null) &&
                         (rawRslt.RawValueDetails.ResultQualifierCode == null))
                    {
                        rawRslt.RawValueDetails = null;
                    }

                    rawDataItems.Add(rawRslt);
                }
            }
        }
        private void AddAnnualSummaryInformation(List<object> rawDataItems, string transProtocolPk)
        {
            DataTable dtRawResults = null;
            dtRawResults = Data.GetDataTable(_baseDao, Data.Tables.TransactionAnnualSummaryInformation, _startDate, _endDate,
                                             _siteId, _countyCode, transProtocolPk, _commaSeparatedActionCodes);

            if ((dtRawResults != null))
            {

                foreach (DataRow drResult in dtRawResults.Rows)
                {
                    AnnualSummaryInformationType rawRslt = new AnnualSummaryInformationType();
                    if (string.IsNullOrEmpty(_commaSeparatedActionCodes))
                    {
                        // Default hard-coded value for original NV plugin
                        rawRslt.ActionCode = "I";
                    }
                    else
                    {
                        rawRslt.ActionCode = Util.ToStr(drResult["ACTION_CD"]);
                    }
                    rawRslt.SummaryYear = Util.ToStr(drResult["SUM_YEAR"]);
                    rawRslt.ExceptionalDataTypeCode = Util.ToStr(drResult["EXCEP_DATA_TYPE_CD"]);
                    rawRslt.ObservationsCount = Util.ToStr(drResult["OBSERVATION_COUNT"]);
                    rawRslt.EventsCount = Util.ToStr(drResult["EVENTS_COUNT"]);
                    rawRslt.HighestSampleValue = Util.ToStr(drResult["HIGH_SMPL_VALUE"]);
                    rawRslt.HighestSampleDate = Util.ToStr(drResult["HIGH_SMPL_DATE"]);
                    rawRslt.HighestSampleTime = Util.ToStr(drResult["HIGH_SMPL_TIME"]);
                    rawRslt.SecondHighestSampleValue = Util.ToStr(drResult["SEC_HIGH_SMPL_VALUE"]);
                    rawRslt.SecondHighestSampleDate = Util.ToStr(drResult["SEC_HIGH_SMPL_DATE"]);
                    rawRslt.SecondHighestSampleTime = Util.ToStr(drResult["SEC_HIGH_SMPL_TIME"]);
                    rawRslt.ThirdHighestSampleValue = Util.ToStr(drResult["THIRD_HIGH_SMPL_VALUE"]);
                    rawRslt.FourthHighestSampleValue = Util.ToStr(drResult["FOURTH_HIGH_SMPL_VALUE"]);
                    rawRslt.FifthHighestSampleValue = Util.ToStr(drResult["FIFTH_HIGH_SMPL_VALUE"]);
                    rawRslt.LowestSampleValue = Util.ToStr(drResult["LOW_SMPL_VALUE"]);
                    rawRslt.ArithmeticMeanValue = Util.ToStr(drResult["ARTH_MEAN_VALUE"]);
                    rawRslt.ArithmeticStandardDevValue = Util.ToStr(drResult["ARTH_STD_DEV_VALUE"]);
                    rawRslt.GeometricMeanValue = Util.ToStr(drResult["GEO_MEAN_VALUE"]);
                    rawRslt.GeometricStandardDevValue = Util.ToStr(drResult["GEO_STD_DEV_VALUE"]);
                    rawRslt.TenthPercentileValue = Util.ToStr(drResult["TENTH_PER_VALUE"]);
                    rawRslt.TwentyFifthPercentileValue = Util.ToStr(drResult["TWENTY_FIFTH_PER_VALUE"]);
                    rawRslt.FiftiethPercentileValue = Util.ToStr(drResult["FIFTIETH_PER_VALUE"]);
                    rawRslt.SeventyFifthPercentileValue = Util.ToStr(drResult["SEVENTY_FIFTH_PER_VALUE"]);
                    rawRslt.NinetiethPercentileValue = Util.ToStr(drResult["NINETIETH_PER_VALUE"]);
                    rawRslt.NinetyFifthPercentileValue = Util.ToStr(drResult["NINETY_FIFTH_PER_VALUE"]);
                    rawRslt.NinetyEighthPercentileValue = Util.ToStr(drResult["NINETY_EIGHTH_PER_VALUE"]);
                    rawRslt.NinetyNinthPercentileValue = Util.ToStr(drResult["NINETY_NINTH_PER_VALUE"]);
                    rawRslt.ObservationPercentValue = Util.ToStr(drResult["OBSERVATION_PER_VALUE"]);
                    rawRslt.BelowHalfMDLCount = Util.ToStr(drResult["BELOW_HALF_MDL_COUNT"]);

                    rawDataItems.Add(rawRslt);
                }
            }
        }
        private static void AddToListsIfNotEmpty<T>(string value, T valueQualifier, ref List<string> valueList,
                                             ref List<T> valueQualifierList)
        {
            if (!string.IsNullOrEmpty(value))
            {
                CollectionUtils.Add(value, ref valueList);
                CollectionUtils.Add(valueQualifier, ref valueQualifierList);
            }
        }
        private static void SetListsIfNotEmpty<T>(List<string> valueList, List<T> valueQualifierList,
                                           ref string[] items, ref T[] itemsElementName)
        {
            if (!CollectionUtils.IsNullOrEmpty(valueList))
            {
                items = valueList.ToArray();
                itemsElementName = valueQualifierList.ToArray();
            }
        }
        private static void AddToListsIfNotEmpty<T>(object value, T valueQualifier, ref List<object> valueList,
                                             ref List<T> valueQualifierList)
        {
            if (value != null)
            {
                if ((value is string) && (((string)value).Length == 0))
                {
                    return;
                }
                CollectionUtils.Add(value, ref valueList);
                CollectionUtils.Add(valueQualifier, ref valueQualifierList);
            }
        }
        private static void SetListsIfNotEmpty<T>(List<object> valueList, List<T> valueQualifierList,
                                           ref object[] items, ref T[] itemsElementName)
        {
            if (!CollectionUtils.IsNullOrEmpty(valueList))
            {
                items = valueList.ToArray();
                itemsElementName = valueQualifierList.ToArray();
            }
        }
        private static object GetCompositeTypeIdentifier(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return Enum.Parse(typeof(CompositeTypeIdentifierType), value, true);
            }
            return null;
        }
    }
}




