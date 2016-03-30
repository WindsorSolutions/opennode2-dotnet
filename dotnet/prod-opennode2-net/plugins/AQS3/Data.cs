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
using System.Collections;
using System.Data;
using System.Text;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;
using System.Collections.Generic;

namespace Windsor.Node2008.WNOSPlugin.AQS2
{
    public class Data
    {

        public const string cDbDateFormatString = "yyyy-MM-dd";
        public enum Tables
        {
            SiteIdentifierDetails,
            MonitorIdentifierDetails,
            TransactionProtocolDetails,
            TransactionRawResultDetails,
            TransactionRawPrecisionInformation,
            TransactionRawCompositeInformation,
            TransactionRawAccuracyInformation,
            TransactionBlankInformation,
            TransactionAnnualSummaryInformation,
            QualifierCode,
            CompositeInformationQualifierCode,
            BlankQualifierCode,
            MonitorSamplingPeriod,
            MonitorSamplingSchedule,
            MonitorObjectiveInformation,
        }

        public static void ExecuteMetaDataValidation(SpringBaseDao baseDao, bool clearMetadataBeforeRun)
        {

            try
            {
                if (clearMetadataBeforeRun)
                {
                    baseDao.DoSimpleDelete("AQS_METADATA", null, null);
                }
                baseDao.DoStoredProc("AQS_CHECK_METADATA");
            }
            catch (Exception ex)
            {
                throw new Exception("Error while executing AQS metadata populate procedure: " + ExceptionUtils.ToLongString(ex));
            }
        }

        public static DataTable GetDataTable(SpringBaseDao baseDao, Tables tableType, DateTime startDate, DateTime endDate,
											 string siteNumber, string countyNumber, string pk, string commaSeparatedActionCodes, bool useImportedDateDate = false)
        {
            string sql = null;

            string actionCodesQuery = GetActionCodesSubQuery(commaSeparatedActionCodes);

            switch (tableType)
            {

                case Tables.SiteIdentifierDetails:

                    sql = "SELECT DISTINCT S.AQS_SITE_ID_PK, S.STATE_CD, S.NON_STATE_CD, S.COUNTY_CD, S.TRIBAL_CD, S.FACILITY_SITE_ID, " +

                        "S.ACTION_CD, S.SUPPORT_AGENCY_CD, S.LOC_ADDR_TEXT, S.CITY_CD, S.POSTAL_CODE, S.LOCAL_ID, S.LOCAL_NAME, S.LOCAL_REGION_CD, " +
                        "S.URBAN_AREA_CD, S.AQCR_CD, S.LAND_USE_ID, S.LOC_SETTING_ID, S.SITE_EST_DATE, S.SITE_TERM_DATE, " +
                        "S.CONG_DIST_CODE, S.CENSUS_BLOCK_CD, S.CENSUS_BLOCK_GRP_CD, S.CENSUS_TRACT_CD, S.CLASS_AREA_CD, S.HQ_EVAL_DATE, " +
                        "S.REG_EVAL_DATE, S.DIR_FROM_CITY_CD, S.DIST_FROM_CITY_MSR, S.MET_SITE_ID, S.MET_SITE_TYPE_CD, S.DIST_TO_MET_SITE_MSR, " +
                        "S.DIR_TO_MET_SITE_CODE, S.LATITUDE, S.LONGITUDE, S.UTM_ZONE_CD, S.UTM_EASTING, S.UTM_NORTHING, " +
                        "S.HORIZ_COL_MTHD, S.HORIZ_REF_DATUM, S.SRC_MAP_SCALE_NBR, S.HORIZONTAL_ACCURACY, S.VERTICAL_MEASURE, S.VERTICAL_MTHD_CD, " +
                        "S.VERTICAL_DATUM_ID, S.VERTICAL_ACCR_MSR, S.TIME_ZONE_NAME " +

                        "FROM AQS_SITE_ID S " +
                        "INNER JOIN AQS_METADATA M ON S.AQS_SITE_ID_PK = M.AQS_SITE_ID_PK " +
                        "WHERE {0} {1} {2} {3} " +
                            actionCodesQuery;
                    break;


                case Tables.MonitorIdentifierDetails:
                    sql = "SELECT DISTINCT O.AQS_MONITOR_ID_PK, O.AQS_SITE_ID_FK, O.SUBST_ID, O.SUBST_OCCURENCE_CD, " +
                        "O.ACTION_CD, O.PROJECT_CLASS_CD, O.DOMINANT_SCR_TXT, O.MEASUREMENT_SCALE_ID, O.OPEN_PATH_ID, " +
                        "O.PROBE_LOC_CODE, O.PROBE_HEIGHT_MSR, O.HORIZ_DIST_MSR, O.VERT_DIST_MSR, " +
                        "O.SURROGATE_IND, O.UNRESTR_AIR_FLOW_IND, O.SAMPLE_RESID_TIME, O.WORST_SITE_TYPE_CD, " +
                        "O.APPLICABLE_NAAQS_IND, O.SPACIAL_AVG_IND, O.SCHED_EXEMPT_IND, O.CMNTY_MONITOR_ZONE, " +
                        "O.MONITOR_CLOSE_DATE, " +
                        "M.FACILITY_SITE_ID " +
                        "FROM AQS_MONITOR_ID O  " +
                        "INNER JOIN AQS_METADATA M ON O.AQS_MONITOR_ID_PK = M.AQS_MONITOR_ID_PK " +
                        "WHERE {0} {1} {2} {3} " +
                            actionCodesQuery + " ";

					if (!string.IsNullOrEmpty(pk))
					{
						sql+="AND O.AQS_SITE_ID_FK = {4}";
					}
					break;


                case Tables.TransactionProtocolDetails:

                    sql = "SELECT DISTINCT T.AQS_TRANS_PROTOCOL_PK, T.COMPOSITE_TYPE_ID, T.DURATION_CD, T.FREQUENCY_CD, " +
                        "T.METHOD_ID_CD, T.MEASURE_UNIT_CD, T.ALTERNATE_MDL_VALUE  " +
                        "FROM AQS_TRANS_PROTOCOL T  " +
                        "INNER JOIN AQS_METADATA M ON T.AQS_TRANS_PROTOCOL_PK = M.AQS_TRANS_PROTOCOL_PK " +
                        "WHERE {0} {1} {2} {3} " +
                            actionCodesQuery + " " +
                            "AND T.AQS_MONITOR_ID_FK = {4}";
                    break;


                case Tables.MonitorSamplingPeriod:

                    sql = "SELECT S.SAMPLING_BEGIN_DATE, S.SAMPLING_END_DATE  " +
                        "FROM AQS_MONITOR_SAMPLE_PRD S  " +
                        "WHERE S.AQS_MONITOR_ID_FK = {4}";
                    break;


                case Tables.MonitorSamplingSchedule:

                    sql = "SELECT S.ACTION_CD, S.FREQUENCY_CD, S.RCF_BEGIN_DATE, S.RCF_END_DATE, S.RCF_JAN_CD, S.RCF_FEB_CD, S.RCF_MAR_CD,  " +
                        "S.RCF_APR_CD, S.RCR_MAY_CD, S.RCR_JUN_CD, S.RCR_JUL_CD, S.RCR_AUG_CD, S.RCR_SEP_CD,  " +
                        "S.RCR_OCT_CD, S.RCR_NOV_CD, S.RCR_DEC_CD  " +
                        "FROM AQS_MONITOR_SAMPLE_SCHD S  " +
                        "WHERE S.AQS_MONITOR_ID_FK = {4}";
                    break;


                case Tables.MonitorObjectiveInformation:

                    sql = "SELECT S.AQS_MONITOR_OBJ_INFO_PK, S.MONITOR_OBJ_ID, S.ACTION_CD, S.URBAN_AREA_REP_CD, S.METRO_SA_REP_CD, " +
                          "S.COVE_BS_REP_CD, S.COMBINED_SA_REP_CD " +
                        "FROM AQS_MONITOR_OBJ_INFO S  " +
                        "WHERE S.AQS_MONITOR_ID_FK = {4}";
                    break;


                case Tables.TransactionRawResultDetails:

                    sql = "SELECT DISTINCT R.AQS_RAW_RES_PK, R.ACTION_CD, R.SMPL_COLL_START_DATE, R.SMPL_COLL_START_TIME, R.MEASURE_VALUE, " +
                        "R.UNCERTAINTY_VALUE, R.NULL_DATA_CD, R.DATA_VALIDITY_CD, R.DATA_APPROVAL_IND " +
                        "FROM AQS_RAW_RES R " +
                        "INNER JOIN AQS_METADATA M ON R.AQS_RAW_RES_PK = M.AQS_RAW_RES_PK " +
                        "WHERE {0} {1} {2} {3} " +
                            actionCodesQuery + " " +
                            "AND R.AQS_TRANS_PROTOCOL_FK = {4}";
                    break;


                case Tables.TransactionRawPrecisionInformation:

                    sql = "SELECT DISTINCT R.AQS_RAW_PREC_INFO_PK, R.ACTION_CD, R.PREC_TYPE_ID, R.PREC_ID_NUM, " +
                        "R.ACTUAL_METHOD_CD, R.PREC_CHECK_DATE, R.ACTUAL_VALUE, R.INDICATED_METHOD_CD, R.INDICATED_VALUE, " +
                        "R.COL_POC_ID_NUM, R.PREC_SMPL_ID, R.AUDIT_AGENCY_CD " +
                        "FROM AQS_RAW_PREC_INFO R " +
                        "INNER JOIN AQS_METADATA M ON R.AQS_RAW_PREC_INFO_PK = M.AQS_RAW_RES_PK " +
                        "WHERE {0} {1} {2} {3} " +
                            actionCodesQuery + " " +
                            "AND R.AQS_TRANS_PROTOCOL_FK = {4}";
                    break;


                case Tables.TransactionRawCompositeInformation:

                    sql = "SELECT DISTINCT R.AQS_RAW_COMP_INFO_PK, R.ACTION_CD, R.OBSERVATION_YEAR, R.COMP_PERIOD_CD, " +
                        "R.SAMPLES_COUNT, R.COMP_SMPL_VALUE, R.UNCERTAINTY_VALUE " +
                        "FROM AQS_RAW_COMP_INFO R " +
                        "INNER JOIN AQS_METADATA M ON R.AQS_RAW_COMP_INFO_PK = M.AQS_RAW_RES_PK " +
                        "WHERE {0} {1} {2} {3} " +
                            actionCodesQuery + " " +
                            "AND R.AQS_TRANS_PROTOCOL_FK = {4}";
                    break;


                case Tables.TransactionRawAccuracyInformation:

                    sql = "SELECT DISTINCT R.AQS_RAW_ACCU_INFO_PK, R.ACTION_CD, R.ACCU_AUDIT_ID_NUM, R.AUDIT_YEAR, " +
                        "R.QTR_REP_CD, R.ACCU_DATE, R.AUDIT_TYPE_ID, R.LOCAL_STAND_ID, R.AUDIT_CLASS_ID, " +
                        "R.ACCU_TYPE_ID, R.AUDIT_SMPL_ID, R.LOCAL_STAND_EXP_DATE, R.AUDIT_SCH_DATE, R.LVL1_ACT_VALUE, " +
                        "R.LVL1_IND_VALUE, R.LVL2_ACT_VALUE, R.LVL2_IND_VALUE, R.LVL3_ACT_VALUE, R.LVL3_IND_VALUE, " +
                        "R.LVL4_ACT_VALUE, R.LVL4_IND_VALUE, R.LVL5_ACT_VALUE, R.LVL5_IND_VALUE, R.ZERO_SPAN_VALUE " +
                        "FROM AQS_RAW_ACCU_INFO R " +
                        "INNER JOIN AQS_METADATA M ON R.AQS_RAW_ACCU_INFO_PK = M.AQS_RAW_RES_PK " +
                        "WHERE {0} {1} {2} {3} " +
                            actionCodesQuery + " " +
                            "AND R.AQS_TRANS_PROTOCOL_FK = {4}";
                    break;


                case Tables.TransactionBlankInformation:

                    sql = "SELECT DISTINCT R.AQS_BLANK_INFO_PK, R.ACTION_CD, R.SMPL_COLL_START_DATE, R.SMPL_COLL_START_TIME, " +
                        "R.BLANK_TYPE_CD, R.UNCERTAINTY_VALUE, R.NULL_DATA_CD, R.DATA_VALIDITY_CD, R.DATA_APPROVAL_IND, " +
                        "R.MEASURE_VALUE " +
                        "FROM AQS_BLANK_INFO R " +
                        "INNER JOIN AQS_METADATA M ON R.AQS_BLANK_INFO_PK = M.AQS_RAW_RES_PK " +
                        "WHERE {0} {1} {2} {3} " +
                            actionCodesQuery + " " +
                            "AND R.AQS_TRANS_PROTOCOL_FK = {4}";
                    break;


                case Tables.TransactionAnnualSummaryInformation:

                    sql = "SELECT DISTINCT R.AQS_ANNUAL_SUM_INFO_PK, R.ACTION_CD, R.SUM_YEAR, R.EXCEP_DATA_TYPE_CD, " +
                        "R.OBSERVATION_COUNT, R.EVENTS_COUNT, R.HIGH_SMPL_VALUE, R.HIGH_SMPL_DATE, R.HIGH_SMPL_TIME, " +
                        "R.SEC_HIGH_SMPL_VALUE, R.SEC_HIGH_SMPL_DATE, R.SEC_HIGH_SMPL_TIME, R.THIRD_HIGH_SMPL_VALUE, " +
                        "R.FOURTH_HIGH_SMPL_VALUE, R.FIFTH_HIGH_SMPL_VALUE, R.LOW_SMPL_VALUE, R.ARTH_MEAN_VALUE, " +
                        "R.ARTH_STD_DEV_VALUE, R.GEO_MEAN_VALUE, R.GEO_STD_DEV_VALUE, R.TENTH_PER_VALUE, " +
                        "R.TWENTY_FIFTH_PER_VALUE, R.FIFTIETH_PER_VALUE, R.SEVENTY_FIFTH_PER_VALUE, R.NINETIETH_PER_VALUE, " +
                        "R.NINETY_FIFTH_PER_VALUE, R.NINETY_EIGHTH_PER_VALUE, R.NINETY_NINTH_PER_VALUE, R.OBSERVATION_PER_VALUE, " +
                        "R.BELOW_HALF_MDL_COUNT " +
                        "FROM AQS_ANNUAL_SUM_INFO R " +
                        "INNER JOIN AQS_METADATA M ON R.AQS_ANNUAL_SUM_INFO_PK = M.AQS_RAW_RES_PK " +
                        "WHERE {0} {1} {2} {3} " +
                            actionCodesQuery + " " +
                            "AND R.AQS_TRANS_PROTOCOL_FK = {4}";
                    break;


                case Tables.QualifierCode:

                    sql = "SELECT DISTINCT AQS_RES_QUAL_CD_PK, RES_QUAL_CD " +
                        "FROM AQS_RES_QUAL_CD  " +
                        "WHERE AQS_RAW_RES_FK = {4}";
                    break;


                case Tables.CompositeInformationQualifierCode:

                    sql = "SELECT DISTINCT AQS_COMP_RES_QUAL_CD_PK, RES_QUAL_CD " +
                        "FROM AQS_COMP_RES_QUAL_CD  " +
                        "WHERE AQS_COMP_INFO_FK = {4}";
                    break;


                case Tables.BlankQualifierCode:

                    sql = "SELECT DISTINCT AQS_BLANK_RES_QUAL_CD_PK, RES_QUAL_CD " +
                        "FROM AQS_BLANK_RES_QUAL_CD  " +
                        "WHERE AQS_BLANK_INFO_FK = {4}";
                    break;


                default:
                    throw new ApplicationException("Invalid Table Selection.");
            }

            string siteIDSql = "";

            if ((((siteNumber != null)) && (siteNumber.Trim().Length > 1)))
            {
                siteIDSql = string.Format("M.FACILITY_SITE_ID = '{0}' AND ", siteNumber);
            }

            string countyIDSql = "";

            if ((((countyNumber != null)) && (countyNumber.Trim().Length > 1)))
            {
                countyIDSql = string.Format("M.COUNTY_CD = '{0}' AND ", countyNumber);
            }

			string startDateSql="";
			string endDateSql = "";

			if (useImportedDateDate)
			{
				startDateSql=string.Format("CAST(M.IMPORTED_DATE AS DATETIME) >= '{0}' AND ", startDate.ToString(cDbDateFormatString));
				endDateSql=string.Format("M.IMPORTED_DATE <= '{0}' AND ", endDate.ToString(cDbDateFormatString));
			}
			else
			{
                startDateSql=string.Format("M.SMPL_COLL_START_DATE >= '{0}' AND ", startDate.ToString(cDbDateFormatString));
                endDateSql=string.Format("M.SMPL_COLL_START_DATE <= '{0}' AND " ,endDate.ToString(cDbDateFormatString));
			}

			sql=string.Format(sql, siteIDSql, countyIDSql, startDateSql, endDateSql, pk);

            return baseDao.FillTable(sql);
        }
        private static string GetActionCodesSubQuery(string commaSeparatedActionCodes)
        {
            if (string.IsNullOrEmpty(commaSeparatedActionCodes))
            {
                return "M.ACTION_CD = 'I'"; // Default hard-coded value for original NV plugin
            }
            else
            {
                // Parse comma-separated string of action codes to build subquery
                string errorMessageFormatStr = "Invalid comma-separated action code string specified: {0}";
                string[] actionCodes = commaSeparatedActionCodes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder sb = new StringBuilder();
                foreach (string actionCode in actionCodes)
                {
                    string trimmedActionCode = actionCode.Trim();
                    if (trimmedActionCode.Length != 1)
                    {
                        throw new ArgumentException(string.Format(errorMessageFormatStr, commaSeparatedActionCodes));
                    }
                    char trimmedActionCodeChar = trimmedActionCode[0];
                    if (!char.IsLetter(trimmedActionCodeChar))
                    {
                        throw new ArgumentException(string.Format(errorMessageFormatStr, commaSeparatedActionCodes));
                    }
                    if (sb.Length == 0)
                    {
                        sb.Append("(");
                    }
                    else
                    {
                        sb.Append(" OR ");
                    }
                    sb.AppendFormat("M.ACTION_CD = '{0}'", trimmedActionCodeChar);
                }
                if (sb.Length == 0)
                {
                    throw new ArgumentException(string.Format(errorMessageFormatStr, commaSeparatedActionCodes));
                }
                sb.Append(")");
                return sb.ToString();
            }
        }
    }
}

