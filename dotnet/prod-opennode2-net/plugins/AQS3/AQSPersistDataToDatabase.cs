using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.AQS3
{
    public class AQSPersistDataToDatabase
    {
        private SpringBaseDao _baseDao;
        private bool _clearMetadataBeforeRun;


        public AQSPersistDataToDatabase(SpringBaseDao baseDao, bool clearMetadataBeforeRun)
        {
            _baseDao = baseDao;
            _clearMetadataBeforeRun = clearMetadataBeforeRun;
        }

        public void UpsertAirQualityData(AirQualitySubmissionType data, IAppendAuditLogEvent appendAuditLogProvider)
        {
            IList<object> args;
            System.Text.StringBuilder argNames;

            foreach (FacilitySiteListType site in data.FacilitySiteList)
            {
                args = new List<object>();
				argNames = new System.Text.StringBuilder();
				if (site.BasicSiteInformation != null)
				{
					argNames.Append("ACTION_CD;AQCR_CD;CENSUS_BLOCK_CD;CENSUS_BLOCK_GRP_CD;CENSUS_TRACT_CD;CITY_CD;CLASS_AREA_CD;CONG_DIST_CODE;DIR_FROM_CITY_CD;DIR_TO_MET_SITE_CODE;DIST_FROM_CITY_MSR;DIST_TO_MET_SITE_MSR;HORIZ_COL_MTHD;HORIZ_REF_DATUM;HORIZONTAL_ACCURACY;HQ_EVAL_DATE;LAND_USE_ID;LOC_ADDR_TEXT;LOC_SETTING_ID;LOCAL_ID;LOCAL_NAME;LOCAL_REGION_CD;MET_SITE_ID;MET_SITE_TYPE_CD;POSTAL_CODE;REG_EVAL_DATE;SITE_EST_DATE;SITE_TERM_DATE;SRC_MAP_SCALE_NBR;SUPPORT_AGENCY_CD;TIME_ZONE_NAME;URBAN_AREA_CD;VERTICAL_ACCR_MSR;VERTICAL_DATUM_ID;VERTICAL_MEASURE;VERTICAL_MTHD_CD;");
					args.Add(site.BasicSiteInformation.ActionCode);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.AQCRCode);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.CensusBlockCode);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.CensusBlockGroupCode);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.CensusTractCode);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.CityCode);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.ClassIAreaCode);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.CongressionalDistrictCode);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.DirectionFromCityCode);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.DirectionToMetSiteCode);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.DistanceFromCityMeasure);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.DistanceToMetSiteMeasure);
					args.Add(site.BasicSiteInformation.GeographicMonitoringLocation.HorizontalCollectionMethodCode);
					args.Add(site.BasicSiteInformation.GeographicMonitoringLocation.HorizontalReferenceDatumName);
					args.Add(site.BasicSiteInformation.GeographicMonitoringLocation.HorizontalAccuracyMeasure);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.HQEvaluationDate);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.LandUseIdentifier);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.LocationAddressText);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.LocationSettingIdentifier);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.LocalIdentifier);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.LocalName);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.LocalRegionCode);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.MetSiteIdentifier);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.MetSiteTypeCode);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.AddressPostalCode.Value);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.RegionalEvaluationDate);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.SiteEstablishedDate);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.SiteTerminatedDate);
					args.Add(site.BasicSiteInformation.GeographicMonitoringLocation.SourceMapScaleNumber);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.SupportAgencyCode);
					args.Add(site.BasicSiteInformation.GeographicMonitoringLocation.TimeZoneName);
					args.Add(site.BasicSiteInformation.FacilitySiteDetails.UrbanAreaCode);
					args.Add(site.BasicSiteInformation.GeographicMonitoringLocation.VerticalAccuracyMeasure);
					args.Add(site.BasicSiteInformation.GeographicMonitoringLocation.VerticalDatumIdentifier);
					args.Add(site.BasicSiteInformation.GeographicMonitoringLocation.VerticalMeasure);
					args.Add(site.BasicSiteInformation.GeographicMonitoringLocation.VerticalMethodCode);

					for (int i = site.BasicSiteInformation.GeographicMonitoringLocation.Items.Length; i-- > 0; )
					{
						switch (site.BasicSiteInformation.GeographicMonitoringLocation.ItemsElementName[i])
						{
							case ItemsChoiceType1.LatitudeMeasure:
								argNames.Append(';').Append("LATITUDE");
								break;
							case ItemsChoiceType1.LongitudeMeasure:
								argNames.Append(';').Append("LONGITUDE");
								break;
							case ItemsChoiceType1.UTMEastingMeasure:
								argNames.Append(';').Append("UTM_EASTING");
								break;
							case ItemsChoiceType1.UTMNorthingMeasure:
								argNames.Append(';').Append("UTM_NORTHING");
								break;
							case ItemsChoiceType1.UTMZoneCode:
								argNames.Append(';').Append("UTM_ZONE_CD");
								break;
							default:
								continue;//don't pass unused parameters
						}
						args.Add(site.BasicSiteInformation.GeographicMonitoringLocation.Items[i]);
					}
				}
				argNames.Append("FACILITY_SITE_ID");
				args.Add(site.SiteIdentifierDetails.FacilitySiteIdentifier.Value);
                for (int i = site.SiteIdentifierDetails.Items.Length; i-- > 0; )
                {
                    switch (site.SiteIdentifierDetails.ItemsElementName[i])
                    {
                        case ItemsChoiceType.TribalCode:
                            argNames.Append(';').Append("TRIBAL_CD");
							break;
						case ItemsChoiceType.StateCode:
							argNames.Append(';').Append("STATE_CD");
							break;
						case ItemsChoiceType.NonStateCode:
							argNames.Append(';').Append("NON_STATE_CD");
							break;
						case ItemsChoiceType.CountyCode:
							argNames.Append(';').Append("COUNTY_CD");
							break;
                        default:
                            continue;
                    }
                    args.Add(site.SiteIdentifierDetails.Items[i]);
                }
                int siteID;
                using (System.Data.DataTable dt = new System.Data.DataTable())
                {
                    _baseDao.FillTableFromStoredProc(dt, "aqs_FacilitySiteUpsert", argNames.ToString(), args.ToArray());
                    siteID = (int)dt.Rows[0]["AQS_SITE_ID_PK"];
                }
                foreach (MonitorListType monitor in site.MonitorList)
                {
					argNames = new System.Text.StringBuilder("AQS_SITE_ID_FK;SUBST_ID;SUBST_OCCURENCE_CD;");
					args = new List<object>();
                    args.Add(siteID);
					args.Add(monitor.MonitorIdentifierDetails.SubstanceIdentifier.Value);
					args.Add(monitor.MonitorIdentifierDetails.SubstanceOccurrenceCode);
					if (monitor.BasicMonitoringInformation != null)
					{
						argNames.Append("ACTION_CD;APPLICABLE_NAAQS_IND;CMNTY_MONITOR_ZONE;DOMINANT_SCR_TXT;HORIZ_DIST_MSR;MEASUREMENT_SCALE_ID;MONITOR_CLOSE_DATE;OPEN_PATH_ID;PROBE_HEIGHT_MSR;PROBE_LOC_CODE;PROJECT_CLASS_CD;SAMPLE_RESID_TIME;SCHED_EXEMPT_IND;SPACIAL_AVG_IND;SURROGATE_IND;UNRESTR_AIR_FLOW_IND;VERT_DIST_MSR;WORST_SITE_TYPE_CD");
						args.Add(monitor.BasicMonitoringInformation.ActionCode);
						args.Add(monitor.BasicMonitoringInformation.ApplicableNAAQSIndicator);
						args.Add(monitor.BasicMonitoringInformation.CommunityMonitoringZoneCode);
						args.Add(monitor.BasicMonitoringInformation.DominantSourceText);
						args.Add(monitor.BasicMonitoringInformation.HorizontalDistanceMeasure);
						args.Add(monitor.BasicMonitoringInformation.MeasurementScaleIdentifier);
						args.Add(monitor.BasicMonitoringInformation.MonitorCloseDate);
						args.Add(monitor.BasicMonitoringInformation.OpenPathIdentifier);
						//args.Add(monitor.BasicMonitoringInformation.PollutantAreaCode);
						args.Add(monitor.BasicMonitoringInformation.ProbeHeightMeasure);
						args.Add(monitor.BasicMonitoringInformation.ProbeLocationCode);
						args.Add(monitor.BasicMonitoringInformation.ProjectClassCode);
						args.Add(monitor.BasicMonitoringInformation.SampleResidenceTime);
						args.Add(monitor.BasicMonitoringInformation.ScheduleExemptionIndicator);
						args.Add(monitor.BasicMonitoringInformation.SpatialAverageIndicator);
						args.Add(monitor.BasicMonitoringInformation.SurrogateIndicator);
						args.Add(monitor.BasicMonitoringInformation.UnrestrictedAirFlowIndicator);
						args.Add(monitor.BasicMonitoringInformation.VerticalDistanceMeasure);
						args.Add(monitor.BasicMonitoringInformation.WorstSiteTypeCode);
					}
                    int monitorID;
                    using (System.Data.DataTable dt = new System.Data.DataTable())
                    {
						_baseDao.FillTableFromStoredProc(dt, "aqs_MonitorUpsert", argNames.ToString(), args.ToArray());
                        monitorID = (int)dt.Rows[0]["AQS_MONITOR_ID_PK"];
                    }

                    foreach (RawDataListType datum in monitor.RawDataList)
                    {
                        args = new List<object>();
						argNames=new System.Text.StringBuilder("ALTERNATE_MDL_VALUE;AQS_MONITOR_ID_FK;MEASURE_UNIT_CD;METHOD_ID_CD");
                        args.Add(datum.TransactionProtocolDetails.AlternateMDLValue);
                        args.Add(monitorID);
                        args.Add(datum.TransactionProtocolDetails.MeasureUnitCode);
                        args.Add(datum.TransactionProtocolDetails.MethodIdentifierCode);
                        for (int i = datum.TransactionProtocolDetails.Items.Length; i-- > 0; )
                        {
                            switch (datum.TransactionProtocolDetails.ItemsElementName[i])
                            {
                                case ItemsChoiceType2.CompositeTypeIdentifier:
                                    argNames.Append(';').Append("COMPOSITE_TYPE_ID");
                                    break;
                                case ItemsChoiceType2.DurationCode:
                                    argNames.Append(';').Append("DURATION_CD");
                                    break;
                                case ItemsChoiceType2.FrequencyCode:
                                    argNames.Append(';').Append("FREQUENCY_CD");
                                    break;
                                default:
                                    continue;
                            }
                            args.Add(datum.TransactionProtocolDetails.Items[i]);
                        }

                        int protocolID;
                        using (System.Data.DataTable dt = new System.Data.DataTable())
                        {
                            _baseDao.FillTableFromStoredProc(dt, "aqs_TransactionProtocolUpsert", argNames.ToString(), args.ToArray());
                            protocolID = (int)dt.Rows[0]["AQS_TRANS_PROTOCOL_PK"];
                        }
                        foreach (object item in datum.Items)
                        {
							var result = item as RawResultsType;
                            if (result != null)
                            {
                                args = new List<object>();
                                argNames = new System.Text.StringBuilder("ACTION_CD;AQS_TRANS_PROTOCOL_FK;DATA_APPROVAL_IND;DATA_VALIDITY_CD;SMPL_COLL_START_DATE;SMPL_COLL_START_TIME");
                                args.Add(result.ActionCode);
                                args.Add(protocolID);
                                args.Add(result.RawValueDetails.DataApprovalIndicator);
                                args.Add(result.RawValueDetails.DataValidityCode);
                                args.Add(result.SampleCollectionStartDate);
                                args.Add(result.SampleCollectionStartTime);
                                for (int i = result.RawValueDetails.Items.Length; i-- > 0; )
                                {
                                    switch (result.RawValueDetails.ItemsElementName[i])
                                    {
                                        case ItemsChoiceType3.MeasureValue:
                                            argNames.Append(';').Append("MEASURE_VALUE");
                                            break;
                                        case ItemsChoiceType3.NullDataCode:
                                            argNames.Append(';').Append("NULL_DATA_CD");
                                            break;
                                        case ItemsChoiceType3.UncertaintyValue:
                                            argNames.Append(';').Append("UNCERTAINTY_VALUE");
                                            break;
                                        default:
                                            continue;
                                    }
                                    args.Add(result.RawValueDetails.Items[i]);
                                }
                                _baseDao.DoStoredProcWithArgs("aqs_RawResultUpsert", argNames.ToString(), args);
                            }
                            else
                            {
                                var blankResult = item as BlankInformationType;
                                if (blankResult != null)
                                {
                                    args = new List<object>();
                                    argNames = new System.Text.StringBuilder("ACTION_CD;AQS_TRANS_PROTOCOL_FK;DATA_APPROVAL_IND;DATA_VALIDITY_CD;SMPL_COLL_START_DATE;SMPL_COLL_START_TIME");
                                    args.Add(blankResult.ActionCode);
                                    args.Add(protocolID);
                                    args.Add(blankResult.RawValueDetails.DataApprovalIndicator);
                                    args.Add(blankResult.RawValueDetails.DataValidityCode);
                                    args.Add(blankResult.SampleCollectionStartDate);
                                    args.Add(blankResult.SampleCollectionStartTime);
                                    for (int i = blankResult.RawValueDetails.Items.Length; i-- > 0; )
                                    {
                                        switch (blankResult.RawValueDetails.ItemsElementName[i])
                                        {
                                            case ItemsChoiceType3.MeasureValue:
                                                argNames.Append(';').Append("MEASURE_VALUE");
                                                break;
                                            case ItemsChoiceType3.NullDataCode:
                                                argNames.Append(';').Append("NULL_DATA_CD");
                                                break;
                                            case ItemsChoiceType3.UncertaintyValue:
                                                argNames.Append(';').Append("UNCERTAINTY_VALUE");
                                                break;
                                            default:
                                                continue;
                                        }
                                        args.Add(blankResult.RawValueDetails.Items[i]);
                                    }
                                    argNames.Append(';').Append("BLANK_TYPE_CD");
                                    args.Add(blankResult.BlankTypeCode);
                                    _baseDao.DoStoredProcWithArgs("aqs_BlankResultUpsert", argNames.ToString(), args);
                                }
                            }
                        }
                    }
                }
            }

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            // ExecuteMetaDataValidation - Executes SP that inserts the metadata
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Data.ExecuteMetaDataValidation(_baseDao, _clearMetadataBeforeRun);
        }
    }
}




