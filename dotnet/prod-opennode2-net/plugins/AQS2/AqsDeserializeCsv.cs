using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windsor.Node2008.WNOSPlugin.AQS2
{
    // \\docs\bizdocs\Organizations\P\Port Gamble S'Klallam Tribe\PGST02 - AQS Data Flow\2 - Design

    public delegate string Mapper(Windsor.Commons.Core.CommaSeparatedFileParser data, string dest);

    public interface IAbstractHeader<T> : IDictionary<string, Mapper>
    {
        IAbstractHeader<T> Materialize(IAbstractHeader<T> concrete);
        void ConsumeRow(Windsor.Commons.Core.CommaSeparatedFileParser parser);
        T Resolve();
    }

	public class AqsDeserializeCsv
    {
        public enum AqsFileType
        {
            rawResults
        }

        public enum ActionType
        {
            insert = 0,
            update = 1,
            delete = 2
        }

        public AqsDeserializeCsv(Windsor.Commons.Spring.SpringBaseDao baseDao, ActionType action)
        {
            _baseDao = baseDao;
            _action = action;
        }

        private Windsor.Commons.Spring.SpringBaseDao _baseDao;
        private ActionType _action;

        private class AqsRawResults : Dictionary<string, Mapper>, IAbstractHeader<AirQualitySubmissionType>
        {
            private AirQualitySubmissionType _result = new AirQualitySubmissionType();
            private FacilitySiteListType _currentSite;
            private Windsor.Commons.Spring.SpringBaseDao _baseDao;
            private ActionType _action;
            private string _format;
            private IDictionary<string, MonitorListType> _monitorList = new Dictionary<string, MonitorListType>();
            private IDictionary<string, RawDataListType> _rawDataList = new Dictionary<string, RawDataListType>();
            private IDictionary<string, RawResultsType> _rawDataResultsList = new Dictionary<string, RawResultsType>();

            public AqsRawResults(Windsor.Commons.Spring.SpringBaseDao baseDao, ActionType action, string format)
                : base()
            {
                _baseDao = baseDao;
                _action = action;
                _format = format;
                LoadSites(format);
            }

            public AqsRawResults(IList<string> columns, Windsor.Commons.Spring.SpringBaseDao baseDao, ActionType action, string format)
                : base()
            {
                foreach (string column in columns)
                {
                    if (string.IsNullOrEmpty(column))
                        throw new Exception("Destination columns cannot be empty.");
                    if (System.Text.RegularExpressions.Regex.IsMatch(column, @".*[,:].*"))
                        throw new Exception("Column " + column + " contains invalid characters");
                    Add(column,
						(p, c) => c==column?
									p.HasColumn(c)?//todo: memoize this
										p.GetValue<string>(c)
										:null
									:c);
                }
                _baseDao = baseDao;
                _action = action;
                _format = format;
                LoadSites(format);
            }

            private FacilitySiteListType GetDefaultSite(string format)
            {
                //windsor.commons.spring.springbasedao is a morass of spaghetti that doesn't make a lot of sense to me.
                System.Data.DataTable siteValues = new System.Data.DataTable();
                try
                {
                    _baseDao.FillTableFromStoredProc(siteValues, "getSiteValues", "template", format);
                    var site = siteValues.Rows[0];
					var geographicItems=new List<object>();
					var geographicItemNames=new List<ItemsChoiceType1>();
					if (!site.IsNull("LATITUDE"))
					{
						geographicItems.Add(site["LATITUDE"] as string);
						geographicItemNames.Add(ItemsChoiceType1.LatitudeMeasure);
					}
					if (!site.IsNull("LONGITUDE"))
					{
						geographicItems.Add(site["LONGITUDE"] as string );
						geographicItemNames.Add(ItemsChoiceType1.LongitudeMeasure);
					}
					if (!site.IsNull("UTM_EASTING"))
					{
						geographicItems.Add(site["UTM_EASTING"] as string);
						geographicItemNames.Add(ItemsChoiceType1.UTMEastingMeasure);
					}
					if (!site.IsNull("UTM_NORTHING"))
					{
						geographicItems.Add(site["UTM_NORTHING"] as string);
						geographicItemNames.Add(ItemsChoiceType1.UTMNorthingMeasure);
					}
					if (!site.IsNull("UTM_ZONE_CD"))
					{
						geographicItems.Add(site["UTM_ZONE_CD"] as string);
						geographicItemNames.Add(ItemsChoiceType1.UTMZoneCode);
					}
					var siteIdItems = new List<string>();
					var siteIdItemNames = new List<ItemsChoiceType>();
					if (!site.IsNull("TRIBAL_CD"))
					{
						siteIdItems.Add(site["TRIBAL_CD"] as string);
						siteIdItemNames.Add(ItemsChoiceType.TribalCode);
					}
					if (!site.IsNull("STATE_CD"))
					{
						siteIdItems.Add(site["STATE_CD"] as string);
						siteIdItemNames.Add(ItemsChoiceType.StateCode);
					}
					if (!site.IsNull("NON_STATE_CD"))
					{
						siteIdItems.Add(site["NON_STATE_CD"] as string);
						siteIdItemNames.Add(ItemsChoiceType.NonStateCode);
					}
					if (!site.IsNull("COUNTY_CD"))
					{
						siteIdItems.Add(site["COUNTY_CD"] as string);
						siteIdItemNames.Add(ItemsChoiceType.CountyCode);
					}
					return new FacilitySiteListType()
					{

						BasicSiteInformation=new BasicSiteInformationType()
						{
							FacilitySiteDetails=new FacilitySiteDetailsType()
							{
								AddressPostalCode=new AddressPostalCodeDataType()
								{
									//AddressPostalCodeContext=???
									Value=site["POSTAL_CODE"] as string
								},
								AQCRCode=site["AQCR_CD"] as string,
								CensusBlockCode=site["CENSUS_BLOCK_CD"] as string,
								CensusBlockGroupCode=site["CENSUS_BLOCK_GRP_CD"] as string,
								CensusTractCode=site["CENSUS_TRACT_CD"] as string,
								CityCode=site["CITY_CD"] as string,
								ClassIAreaCode=site["CLASS_AREA_CD"] as string,
								CongressionalDistrictCode=site["CONG_DIST_CODE"] as string,
								DirectionFromCityCode=site["DIR_FROM_CITY_CD"] as string,
								DirectionToMetSiteCode=site["DIR_TO_MET_SITE_CODE"] as string,
								DistanceFromCityMeasure=site["DIST_FROM_CITY_MSR"] as string,
								DistanceToMetSiteMeasure=site["DIST_TO_MET_SITE_MSR"] as string,
								HQEvaluationDate=site["HQ_EVAL_DATE"] as string,
								LandUseIdentifier=site["LAND_USE_ID"] as string,
								LocalIdentifier=site["LOCAL_ID"] as string,
								LocalName=site["LOCAL_NAME"] as string,
								LocalRegionCode=site["LOCAL_REGION_CD"] as string,
								LocationAddressText=site["LOC_ADDR_TEXT"] as string,
								LocationSettingIdentifier=site["LOC_SETTING_ID"] as string,
								MetSiteIdentifier=site["MET_SITE_ID"] as string,
								MetSiteTypeCode=site["MET_SITE_TYPE_CD"] as string,
								RegionalEvaluationDate=site["REG_EVAL_DATE"] as string,
								SiteEstablishedDate=site["SITE_EST_DATE"] as string,
								SiteTerminatedDate=site["SITE_TERM_DATE"] as string,
								SupportAgencyCode=site["SUPPORT_AGENCY_CD"] as string,
								UrbanAreaCode=site["URBAN_AREA_CD"] as string
							},
							GeographicMonitoringLocation=new GeographicMonitoringLocationType()
							{
								Items=geographicItems.ToArray(),
								ItemsElementName=geographicItemNames.ToArray(),
								HorizontalAccuracyMeasure=site["HORIZONTAL_ACCURACY"] as string,
								HorizontalReferenceDatumName=site["HORIZ_REF_DATUM"] as string,
								HorizontalCollectionMethodCode=site["HORIZ_COL_MTHD"] as string,
								SourceMapScaleNumber=site["SRC_MAP_SCALE_NBR"] as string,
								TimeZoneName=site["TIME_ZONE_NAME"] as string,
								VerticalAccuracyMeasure=site["VERTICAL_ACCR_MSR"] as string,
								VerticalDatumIdentifier=site["VERTICAL_DATUM_ID"] as string,
								VerticalMeasure=site["VERTICAL_MEASURE"] as string,
								VerticalMethodCode=site["VERTICAL_MTHD_CD"] as string
							},
							ActionCode="I"
						},
						SiteIdentifierDetails=new SiteIdentifierDetailsType()
						{
							FacilitySiteIdentifier=new FacilitySiteIdentifierDataType()
							{
								Value=site["FACILITY_SITE_ID"] as string
							},
							Items=siteIdItems.ToArray(),
							ItemsElementName=siteIdItemNames.ToArray()
						}
					};
                }
                catch (Exception x)
                {
                    throw new Exception("Unable to load site default values for template.", x);
                }
            }

            private void LoadSites(string format)
            {
                IList<FacilitySiteListType> sites;
                if (_action == ActionType.insert || _action == ActionType.update)
                {
                    AQSGetDataFromDatabase aqsDb = new AQSGetDataFromDatabase(_baseDao, false, new DateTime(1900, 01, 01), DateTime.Now, null, null, "I, U");
                    sites = aqsDb.GetFacilityList();

                    _currentSite = GetDefaultSite(format);//defaults to Insert

                    if (sites.Where(s => s.SiteIdentifierDetails.FacilitySiteIdentifier == _currentSite.SiteIdentifierDetails.FacilitySiteIdentifier).FirstOrDefault() != null)
                    {
                        _currentSite.BasicSiteInformation.ActionCode = "U";
                    }
                }
                _result.FacilitySiteList = new FacilitySiteListType[1] { _currentSite };
            }

            public IAbstractHeader<AirQualitySubmissionType> Materialize(IAbstractHeader<AirQualitySubmissionType> concrete)
            {
                var materializedFormat = new AqsRawResults(_baseDao, _action, _format);
                foreach (string destinationColumn in Keys)
                {
                    if (concrete.ContainsKey(destinationColumn))
                    {
                        materializedFormat.Add(destinationColumn,
                            (p, c) => base[destinationColumn](p, concrete[destinationColumn](p, c))
                                );
                    }
                    else
                    {
                        materializedFormat.Add(destinationColumn, base[destinationColumn]);
                    }

                }
                return materializedFormat;
            }

            public void ConsumeRow(Windsor.Commons.Core.CommaSeparatedFileParser parser)
            {
                Func<string, string> unmap = (c) => base[c](parser, c);
                string substance = unmap("SUBST_ID");
                if (!_monitorList.ContainsKey(substance))
                {
                    MonitorListType monitor = new MonitorListType();
                    monitor.BasicMonitoringInformation = new BasicMonitoringInformationType();
					//Don't delete monitors, since they may have results from other files.
					monitor.BasicMonitoringInformation.ActionCode=_action==ActionType.insert?"I":"U";
					monitor.BasicMonitoringInformation.ApplicableNAAQSIndicator=unmap("APPLICABLE_NAAQS_IND");
					monitor.BasicMonitoringInformation.CommunityMonitoringZoneCode=unmap("CMNTY_MONITOR_ZONE");
					monitor.BasicMonitoringInformation.DominantSourceText=unmap("DOMINANT_SCR_TXT");
					monitor.BasicMonitoringInformation.HorizontalDistanceMeasure=unmap("HORIZ_DIST_MSR");
					monitor.BasicMonitoringInformation.MeasurementScaleIdentifier=unmap("MEASUREMENT_SCALE_ID");
					monitor.BasicMonitoringInformation.MonitorCloseDate=unmap("MONITOR_CLOSE_DATE");
					monitor.BasicMonitoringInformation.OpenPathIdentifier=unmap("OPEN_PATH_ID");
					//monitor.BasicMonitoringInformation.PollutantAreaCode=;
					monitor.BasicMonitoringInformation.ProbeHeightMeasure=unmap("PROBE_HEIGHT_MSR");
					monitor.BasicMonitoringInformation.ProbeLocationCode=unmap("PROBE_LOC_CODE");
					monitor.BasicMonitoringInformation.ProjectClassCode=unmap("PROJECT_CLASS_CD");
					monitor.BasicMonitoringInformation.SampleResidenceTime=unmap("SAMPLE_RESID_TIME");
					monitor.BasicMonitoringInformation.ScheduleExemptionIndicator=unmap("SCHED_EXEMPT_IND");
					monitor.BasicMonitoringInformation.SpatialAverageIndicator=unmap("SPACIAL_AVG_IND");
					monitor.BasicMonitoringInformation.SurrogateIndicator=unmap("SURROGATE_IND");
					monitor.BasicMonitoringInformation.UnrestrictedAirFlowIndicator=unmap("UNRESTR_AIR_FLOW_IND");
					monitor.BasicMonitoringInformation.VerticalDistanceMeasure=unmap("VERT_DIST_MSR");
					monitor.BasicMonitoringInformation.WorstSiteTypeCode=unmap("WORST_SITE_TYPE_CD");
                    monitor.MonitorIdentifierDetails = new MonitorIdentifierDetailsType();
                    monitor.MonitorIdentifierDetails.SubstanceIdentifier = new SubstanceIdentifierDataType();
                    monitor.MonitorIdentifierDetails.SubstanceIdentifier.Value = substance;
                    monitor.MonitorIdentifierDetails.SubstanceOccurrenceCode = unmap("SUBST_OCCURENCE_CD");
                    _monitorList.Add(substance, monitor);
                }
                string unit = unmap("MEASURE_UNIT_CD");
                string datumKey = substance + ",measure:" + unit;
                if (!_rawDataList.ContainsKey(datumKey))
                {
                    RawDataListType datum = new RawDataListType();
                    datum.TransactionProtocolDetails = new TransactionProtocolDetailsType();
                    datum.TransactionProtocolDetails.MeasureUnitCode = unit;
                    datum.TransactionProtocolDetails.MethodIdentifierCode = unmap("METHOD_ID_CD");
					datum.TransactionProtocolDetails.AlternateMDLValue=unmap("ALTERNATE_MDL_VALUE");
					var items = new List<object>();
					var itemNames = new List<ItemsChoiceType2>();
					var item = unmap("COMPOSITE_TYPE_ID");
					if (item != null)
					{
						items.Add(item);
						itemNames.Add(ItemsChoiceType2.CompositeTypeIdentifier);
					}
					item = unmap("DURATION_CD");
					if (item != null)
					{
						items.Add(item);
						itemNames.Add(ItemsChoiceType2.DurationCode);
					}
					item = unmap("FREQUENCY_CD");
					if (item != null)
					{
						items.Add(item);
						itemNames.Add(ItemsChoiceType2.FrequencyCode);
					}
                    datum.TransactionProtocolDetails.Items = items.ToArray();
                    datum.TransactionProtocolDetails.ItemsElementName =itemNames.ToArray();
                    _rawDataList.Add(datumKey, datum);
                }
                string startDate = unmap("SMPL_COLL_START_DATE");
                string startTime = unmap("SMPL_COLL_START_TIME");
                string resultKey = datumKey + ",datetime:" + startDate + startTime;
	
                if (!_rawDataResultsList.ContainsKey(resultKey))
                {
                    RawResultsType result = new RawResultsType();
					result.ActionCode=Enum.GetName(typeof(ActionType), _action).Substring(0, 1).ToUpper();
                    result.SampleCollectionStartDate = startDate;
                    result.SampleCollectionStartTime = startTime;
                    result.RawValueDetails = new RawValueDetailsType();
					result.RawValueDetails.DataApprovalIndicator=unmap("DATA_APPROVAL_IND");
					result.RawValueDetails.DataValidityCode=unmap("DATA_VALIDITY_CD");
					var items = new List<object>();
					var itemNames = new List<ItemsChoiceType3>();
					var item = unmap("MEASURE_VALUE");
					if (item != null)
					{
						items.Add(item);
						itemNames.Add(ItemsChoiceType3.MeasureValue);
					}
					item = unmap("NULL_DATA_CD");
					if (item != null)
					{
						items.Add(item);
						itemNames.Add(ItemsChoiceType3.NullDataCode);
					}
					item = unmap("UNCERTAINTY_VALUE");
					if (item != null)
					{
						items.Add(item);
						itemNames.Add(ItemsChoiceType3.UncertaintyValue);
					}
                    result.RawValueDetails.Items = items.ToArray();
                    result.RawValueDetails.ItemsElementName = itemNames.ToArray();
                    _rawDataResultsList.Add(resultKey, result);
                }

            }

            public AirQualitySubmissionType Resolve()
            {
				foreach (KeyValuePair<string,RawDataListType> datum in _rawDataList)
                {
					datum.Value.Items=_rawDataResultsList
						.Where(kvp => kvp.Key.StartsWith(datum.Key+","))
                        .Select(kvp => kvp.Value)
                        .ToArray();
                }
                foreach (MonitorListType monitor in _monitorList.Values)
                {
                    monitor.RawDataList = _rawDataList
                        .Where(kvp => kvp.Key.StartsWith(monitor.MonitorIdentifierDetails.SubstanceIdentifier.Value + ","))
                        .Select(kvp => kvp.Value)
                        .ToArray();
                }
                _currentSite.MonitorList = _monitorList.Values.ToArray();
                _result.FacilitySiteList = new FacilitySiteListType[1] { _currentSite };
                return _result;
            }
        }

        private AqsRawResults GetAqsHeader(AqsFileType fileType, string format)
        {
            switch (fileType)
            {
                case AqsFileType.rawResults:
                    var columns = new List<string>();
					columns.Add("ALTERNATE_MDL_VALUE");
					columns.Add("APPLICABLE_NAAQS_IND");
					columns.Add("AQCR_CD");
					columns.Add("CENSUS_BLOCK_CD");
					columns.Add("CENSUS_BLOCK_GRP_CD");
					columns.Add("CENSUS_TRACT_CD");
					columns.Add("CITY_CD");
					columns.Add("CLASS_AREA_CD");
					columns.Add("CMNTY_MONITOR_ZONE");
					columns.Add("COMPOSITE_TYPE_ID");
					columns.Add("CONG_DIST_CODE");
					columns.Add("COUNTY_CD");
					columns.Add("DATA_APPROVAL_IND");
					columns.Add("DATA_VALIDITY_CD");
					columns.Add("DIR_FROM_CITY_CD");
					columns.Add("DIR_TO_MET_SITE_CODE");
					columns.Add("DIST_FROM_CITY_MSR");
					columns.Add("DIST_TO_MET_SITE_MSR");
					columns.Add("DOMINANT_SCR_TXT");
					columns.Add("DURATION_CD");
                    columns.Add("FACILITY_SITE_ID");
					columns.Add("FREQUENCY_CD");
					columns.Add("HORIZ_COL_MTHD");
					columns.Add("HORIZ_DIST_MSR");
					columns.Add("HORIZ_REF_DATUM");
					columns.Add("HORIZONTAL_ACCURACY");
					columns.Add("HQ_EVAL_DATE");
					columns.Add("LAND_USE_ID");
                    columns.Add("LATITUDE");
					columns.Add("LOC_ADDR_TEXT");
					columns.Add("LOC_SETTING_ID");
					columns.Add("LOCAL_ID");
					columns.Add("LOCAL_NAME");
					columns.Add("LOCAL_REGION_CD");
                    columns.Add("LONGITUDE");
                    columns.Add("MEASURE_UNIT_CD");
					columns.Add("MEASURE_VALUE");
					columns.Add("MEASUREMENT_SCALE_ID");
					columns.Add("MET_SITE_ID");
					columns.Add("MET_SITE_TYPE_CD");
                    columns.Add("METHOD_ID_CD");
					columns.Add("MONITOR_CLOSE_DATE");
					columns.Add("NON_STATE_CD");
					columns.Add("NULL_DATA_CD");
					columns.Add("OPEN_PATH_ID");
					columns.Add("POSTAL_CODE");
					columns.Add("PROBE_HEIGHT_MSR");
					columns.Add("PROBE_LOC_CODE");
					columns.Add("PROJECT_CLASS_CD");
					columns.Add("REG_EVAL_DATE");
					columns.Add("SAMPLE_RESID_TIME");
					columns.Add("SCHED_EXEMPT_IND");
					columns.Add("SITE_EST_DATE");
					columns.Add("SITE_TERM_DATE");
                    columns.Add("SMPL_COLL_START_DATE");
                    columns.Add("SMPL_COLL_START_TIME");
					columns.Add("SPACIAL_AVG_IND");
					columns.Add("SRC_MAP_SCALE_NBR");
					columns.Add("STATE_CD");
					columns.Add("SUBST_ID");
					columns.Add("SUBST_OCCURENCE_CD");
					columns.Add("SUPPORT_AGENCY_CD");
					columns.Add("SURROGATE_IND");
					columns.Add("TIME_ZONE_NAME");
					columns.Add("TRIBAL_CD");
					columns.Add("UNCERTAINTY_VALUE");
					columns.Add("UNRESTR_AIR_FLOW_IND");
					columns.Add("URBAN_AREA_CD");
					columns.Add("UTM_EASTING");
					columns.Add("UTM_NORTHING");
					columns.Add("UTM_ZONE_CD");
					columns.Add("VERT_DIST_MSR");
					columns.Add("VERTICAL_ACCR_MSR");
					columns.Add("VERTICAL_DATUM_ID");
					columns.Add("VERTICAL_MEASURE");
					columns.Add("VERTICAL_MTHD_CD");
					columns.Add("WORST_SITE_TYPE_CD");
					return new AqsRawResults(columns, _baseDao, _action, format);
				default:
					throw new ArgumentOutOfRangeException("Unknown file type.");
			}
		}

        private AqsRawResults GetColumnMappings(string format)
        {
            //windsor.commons.spring.springbasedao is a morass of spaghetti that doesn't make a lot of sense to me.
            System.Data.DataTable mappingValues = new System.Data.DataTable();
            _baseDao.FillTableFromStoredProc(mappingValues, "getColumnMappings", "template", format);

            var columnMappings = new AqsRawResults(_baseDao, _action, format);

            foreach (System.Data.DataRow row in mappingValues.Rows)
            {
                if (row.IsNull("HARDCODED_VALUE"))
                {
                    columnMappings.Add(row["DESTINATION_COLUMN"].ToString(), (p, c) => p.GetValue<string>(row["SOURCE_COLUMN"].ToString()));
                }
                else
                {
                    columnMappings.Add(row["DESTINATION_COLUMN"].ToString(), (p, c) => row["HARDCODED_VALUE"].ToString());
                }
            }
            return columnMappings;
        }

        private AqsRawResults GetValueMappings(string format)
        {
            //windsor.commons.spring.springbasedao is a morass of spaghetti that doesn't make a lot of sense to me.
            //using stored proc for consistency with getColumnMappings
            System.Data.DataTable mappingValues = new System.Data.DataTable();

            var map = new AqsRawResults(_baseDao, _action, format);
            if (_baseDao.FillTableFromStoredProc(mappingValues, "getValueMappings", "") > 0)
            {
                var valueMap = new Dictionary<string, string>();

                foreach (System.Data.DataRow row in mappingValues.Rows)
                {
                    string mapKey = row["DESTINATION_COLUMN"].ToString();
                    string valueKey = mapKey + "!value:" + row["SOURCE_CODE"].ToString();
                    if (!valueMap.ContainsKey(valueKey))
                        valueMap.Add(valueKey, row["DESTINATION_CODE"].ToString());
                    if (!map.ContainsKey(mapKey))
                        map.Add(mapKey, (p, c) => valueMap.ContainsKey(mapKey + "!value:" + c) ? valueMap[mapKey + "!value:" + c] : c);
                }
            }
            return map;
        }

        public AirQualitySubmissionType GetAirQualityData(string imputPath, AqsFileType fileType, string format, IAppendAuditLogEvent appendAuditLogProvider)
        {
            try
            {
                IAbstractHeader<AirQualitySubmissionType> mappedParser = GetAqsHeader(fileType, format)
                    .Materialize(GetValueMappings(format))
                    .Materialize(GetColumnMappings(format));


                Windsor.Commons.Core.CommaSeparatedFileParser parser = new Windsor.Commons.Core.CommaSeparatedFileParser(imputPath);
                while (parser.NextLine())
                {
                    mappedParser.ConsumeRow(parser);
                }

                return mappedParser.Resolve();
            }
            catch (Exception x)
            {
                appendAuditLogProvider.AppendAuditLogEvent(x.Message);
                throw;
            }
        }
    }
}
