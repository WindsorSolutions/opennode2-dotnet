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
                        (p, c) => c == column ? p.GetValue<string>(c) : c);
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
                    return new FacilitySiteListType()
                    {
                        BasicSiteInformation = new BasicSiteInformationType()
                        {
                            GeographicMonitoringLocation = new GeographicMonitoringLocationType()
                            {
                                Items = new object[2] { site["LATITUDE"].ToString(), site["LONGITUDE"].ToString() },
                                ItemsElementName = new ItemsChoiceType1[2] { ItemsChoiceType1.LatitudeMeasure, ItemsChoiceType1.LongitudeMeasure }
                            },
                            ActionCode = "I"
                        },
                        SiteIdentifierDetails = new SiteIdentifierDetailsType()
                        {
                            FacilitySiteIdentifier = new FacilitySiteIdentifierDataType()
                            {
                                Value = site["FACILITY_SITE_ID"].ToString()
                            },
                            Items = new string[1] { site["TRIBAL_CD"].ToString() },
                            ItemsElementName = new ItemsChoiceType[1] { ItemsChoiceType.TribalCode }
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
                    monitor.BasicMonitoringInformation.ActionCode = _action == ActionType.insert ? "I" : "U";
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
                    datum.TransactionProtocolDetails.Items = new object[3] { unmap("COMPOSITE_TYPE_ID"), unmap("DURATION_CD"), unmap("FREQUENCY_CD") };
                    datum.TransactionProtocolDetails.ItemsElementName = new ItemsChoiceType2[3] { ItemsChoiceType2.CompositeTypeIdentifier, ItemsChoiceType2.DurationCode, ItemsChoiceType2.FrequencyCode };
                    _rawDataList.Add(datumKey, datum);
                }
                string startDate = unmap("SMPL_COLL_START_DATE");
                string startTime = unmap("SMPL_COLL_START_TIME");
                string resultKey = datumKey + ",datetime:" + startDate + startTime;
                if (!_rawDataResultsList.ContainsKey(resultKey))
                {
                    RawResultsType result = new RawResultsType();
                    result.ActionCode = _action == ActionType.insert ? "I" : "U";
                    result.SampleCollectionStartDate = startDate;
                    result.SampleCollectionStartTime = startTime;
                    result.RawValueDetails = new RawValueDetailsType();
                    result.RawValueDetails.Items = new object[1] { unmap("MEASURE_VALUE") };
                    result.RawValueDetails.ItemsElementName = new ItemsChoiceType3[1] { ItemsChoiceType3.MeasureValue };
                    _rawDataResultsList.Add(resultKey, result);
                }

            }

            public AirQualitySubmissionType Resolve()
            {
                foreach (RawDataListType datum in _rawDataList.Values)
                {
                    datum.Items = _rawDataResultsList
                        .Where(kvp => kvp.Key.StartsWith(datum.TransactionProtocolDetails.MeasureUnitCode + ","))
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
                    columns.Add("FACILITY_SITE_ID");
                    columns.Add("LATITUDE");
                    columns.Add("LONGITUDE");
                    columns.Add("TRIBAL_CD");
                    columns.Add("SUBST_ID");
                    columns.Add("SUBST_OCCURENCE_CD");
                    columns.Add("MEASURE_UNIT_CD");
                    columns.Add("COMPOSITE_TYPE_ID");
                    columns.Add("DURATION_CD");
                    columns.Add("FREQUENCY_CD");
                    columns.Add("METHOD_ID_CD");
                    columns.Add("SMPL_COLL_START_DATE");
                    columns.Add("SMPL_COLL_START_TIME");
                    columns.Add("MEASURE_VALUE");
                    columns.Add("ACTION_CD");
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

                //validateFile(imput, formattedHeader); //handled (poorly) by csv parser

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
