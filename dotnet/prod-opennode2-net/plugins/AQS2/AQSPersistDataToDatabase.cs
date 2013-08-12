using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.AQS2
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
                argNames = new System.Text.StringBuilder("FACILITY_SITE_ID;ACTION_CD");
                args.Add(site.SiteIdentifierDetails.FacilitySiteIdentifier.Value);
                args.Add(site.BasicSiteInformation.ActionCode);
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
                        default:
                            continue;//don't pass unused parameters
                    }
                    args.Add(site.BasicSiteInformation.GeographicMonitoringLocation.Items[i]);
                }
                for (int i = site.SiteIdentifierDetails.Items.Length; i-- > 0; )
                {
                    switch (site.SiteIdentifierDetails.ItemsElementName[i])
                    {
                        case ItemsChoiceType.TribalCode:
                            argNames.Append(';').Append("TRIBAL_CD");
                            break;
                        default:
                            continue;
                    }
                    args.Add(site.SiteIdentifierDetails.Items[i]);
                }
                int siteID;
                using (System.Data.DataTable dt = new System.Data.DataTable())
                {
                    _baseDao.FillTableFromStoredProc(dt, "FacilitySiteUpsert", argNames.ToString(), args.ToArray());
                    siteID = (int)dt.Rows[0]["AQS_SITE_ID_PK"];
                }
                foreach (MonitorListType monitor in site.MonitorList)
                {
                    args = new List<object>();
                    args.Add(siteID);
                    args.Add(monitor.BasicMonitoringInformation.ActionCode);
                    args.Add(monitor.MonitorIdentifierDetails.SubstanceIdentifier.Value);
                    args.Add(monitor.MonitorIdentifierDetails.SubstanceOccurrenceCode);

                    int monitorID;
                    using (System.Data.DataTable dt = new System.Data.DataTable())
                    {
                        _baseDao.FillTableFromStoredProc(dt, "MonitorUpsert", "SITE_ID;ACTION_CD;SUBST_ID;SUBST_OCCURENCE_CD", args.ToArray());
                        monitorID = (int)dt.Rows[0]["AQS_MONITOR_ID_PK"];
                    }

                    foreach (RawDataListType datum in monitor.RawDataList)
                    {
                        args = new List<object>();
                        argNames = new System.Text.StringBuilder("MONITOR_ID;MEASURE_UNIT_CD;METHOD_ID_CD");
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
                            _baseDao.FillTableFromStoredProc(dt, "TransactionProtocolInsertIfNotExist", argNames.ToString(), args.ToArray());
                            protocolID = (int)dt.Rows[0]["AQS_TRANS_PROTOCOL_PK"];
                        }
                        foreach (RawResultsType result in datum.Items)
                        {
                            args = new List<object>();
                            argNames = new System.Text.StringBuilder("PROTOCOL_ID;ACTION_CD;SMPL_COLL_START_DATE;SMPL_COLL_START_TIME");
                            args.Add(protocolID);
                            args.Add(result.ActionCode);
                            args.Add(result.SampleCollectionStartDate);
                            args.Add(result.SampleCollectionStartTime);
                            for (int i = result.RawValueDetails.Items.Length; i-- > 0; )
                            {
                                switch (result.RawValueDetails.ItemsElementName[i])
                                {
                                    case ItemsChoiceType3.MeasureValue:
                                        argNames.Append(';').Append("MEASURE_VALUE");
                                        break;
                                    default:
                                        continue;
                                }
                                args.Add(result.RawValueDetails.Items[i]);
                            }
                            _baseDao.DoStoredProcWithArgs("RawResultUpsert", argNames.ToString(), args);
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




