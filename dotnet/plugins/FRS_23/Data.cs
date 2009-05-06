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
using System.Data;
using System.Data.Common;
using System.Reflection;
using Spring.Data.Generic;
using Common.Logging;
using Spring.Data.Common;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSDomain;
using Windsor.Commons.Logging;

namespace Windsor.Node2008.WNOSPlugin.FRS23
{
    /// <summary>
    /// Summary description for Data.
    /// </summary>
    public class Data
    {

        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private const string SCHEMA = "";
        private const string NOT_SUPPORTED_MSG = "Parameter '{0}' is not currently supported";

        /// <summary>
        /// GetDeletedFacilities
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string[] GetDeletedFacilities(bool isOracle,
            string methodName,
            int rowId,
            int maxRows,
            string[] parameters,
            string connectionString) 
        {
            ArrayList dlt = new ArrayList();
            string where = GetWhere(isOracle, methodName, rowId, maxRows, parameters);
            DataTable dtDeletes = GetData(isOracle, GetSql(QueryElements.Deleted, where), connectionString);
            foreach(DataRow dr in dtDeletes.Rows)
            {
                if (dr["StateFacilityIdentifier"] != DBNull.Value)
                {
                    dlt.Add((string)dr["StateFacilityIdentifier"]);
                }
            }
            return (string[])dlt.ToArray(typeof(string));
        }


        /// <summary>
        /// GetFacilityData
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataSet GetFacilityData(bool isOracle,
            string methodName,
            int rowId,
            int maxRows,
            string[] parameters,
            string connectionString) 
        {

            // Build the WHERE clause
            string where = GetWhere(isOracle, methodName, rowId, maxRows, parameters);
			string tracker = "at init";
            
            try 
            {
                DataSet ds = new DataSet("FRSID");
				tracker = " declared record set ";

				int zed = 0;
                // --------------------------------------------------------------------
                // Get Data Tables
                // --------------------------------------------------------------------
                DataTable dtFacility = GetData(isOracle, GetSql(QueryElements.Facility, where), connectionString);
                if (dtFacility != null)
                {
                    zed = dtFacility.Rows.Count;
                    tracker = " dtFacility ";

                    DataTable dtAltName = GetData(isOracle, GetSql(QueryElements.AltName, where), connectionString);
                    tracker = "dtAltName ";
                    zed = dtAltName.Rows.Count;

                    DataTable dtEnvInt = GetData(isOracle, GetSql(QueryElements.EnvInt, where), connectionString);
                    tracker = " dtEnvInt ";
                    zed = dtEnvInt.Rows.Count;

                    DataTable dtGeoCoor = GetData(isOracle, GetSql(QueryElements.GeoCoor, where), connectionString);
                    tracker = " dtGeoCoor ";
                    zed = dtGeoCoor.Rows.Count;
                    DataTable dtIndividual = GetData(isOracle, GetSql(QueryElements.Individual, where), connectionString);
                    tracker = " dtIndividual ";
                    zed = dtIndividual.Rows.Count;
                    DataTable dtMailingAddress = GetData(isOracle, GetSql(QueryElements.MailingAddress, where), connectionString);
                    tracker = " dtMailingAddress ";
                    zed = dtMailingAddress.Rows.Count;
                    DataTable dtNAICS = GetData(isOracle, GetSql(QueryElements.NAICS, where), connectionString);
                    tracker = " dtNAICS ";
                    zed = dtNAICS.Rows.Count;
                    DataTable dtOrg = GetData(isOracle, GetSql(QueryElements.Org, where), connectionString);
                    tracker = " dtOrg ";
                    zed = dtOrg.Rows.Count;
                    DataTable dtSIC = GetData(isOracle, GetSql(QueryElements.SIC, where), connectionString);
                    tracker = " after dtSIC and starting to add tables ";
                    zed = dtSIC.Rows.Count;

                    // --------------------------------------------------------------------
                    // Merge Data Tables
                    // --------------------------------------------------------------------
                    ds.Tables.Add(dtFacility.Copy());
                    ds.Tables[0].TableName = "Facility";
                    tracker = " after dtFacility ";

                    ds.Tables.Add(dtAltName.Copy());
                    ds.Tables[1].TableName = "AltName";
                    tracker = " after AltName ";

                    ds.Tables.Add(dtEnvInt.Copy());
                    ds.Tables[2].TableName = "EnvInt";
                    tracker = " after EnvInt ";

                    ds.Tables.Add(dtGeoCoor.Copy());
                    ds.Tables[3].TableName = "GeoCoord";
                    tracker = " after GeoCoord ";

                    ds.Tables.Add(dtIndividual.Copy());
                    ds.Tables[4].TableName = "Indiv";
                    tracker = " after Indiv ";

                    ds.Tables.Add(dtMailingAddress.Copy());
                    ds.Tables[5].TableName = "MailAdd";
                    tracker = " after dtMailingAddress ";

                    ds.Tables.Add(dtNAICS.Copy());
                    ds.Tables[6].TableName = "NAICS";
                    tracker = " after dtNAICS ";

                    ds.Tables.Add(dtOrg.Copy());
                    ds.Tables[7].TableName = "Org";
                    tracker = " after dtOrg ";

                    ds.Tables.Add(dtSIC.Copy());
                    ds.Tables[8].TableName = "SIC";
                    tracker = " after dtSIC all tables added next create relationships ";

                    ds.AcceptChanges();


                    // --------------------------------------------------------------------
                    // Load Relationships
                    // --------------------------------------------------------------------


                    //Create relationships
                    ds.Relations.Add(
                        QueryProcessor.TableRelationships.Facility_AltName.ToString(),
                        ds.Tables["Facility"].Columns["STATEFACILITYIDENTIFIER"],
                        ds.Tables["AltName"].Columns["STATEFACILITYIDENTIFIER"]);

                    ds.Relations.Add(
                        QueryProcessor.TableRelationships.Facility_EnvInt.ToString(),
                        ds.Tables["Facility"].Columns["STATEFACILITYIDENTIFIER"],
                        ds.Tables["EnvInt"].Columns["STATEFACILITYIDENTIFIER"]);

                    //EnvInt
                    ds.Relations.Add(
                        QueryProcessor.TableRelationships.EnvInt_Indiv.ToString(),
                        ds.Tables["Facility"].Columns["STATEFACILITYIDENTIFIER"],
                        ds.Tables["Indiv"].Columns["STATEFACILITYIDENTIFIER"]);

                    //EnvInt
                    ds.Relations.Add(
                        QueryProcessor.TableRelationships.EnvInt_Org.ToString(),
                        ds.Tables["Facility"].Columns["STATEFACILITYIDENTIFIER"],
                        ds.Tables["Org"].Columns["STATEFACILITYIDENTIFIER"]);

                    ds.Relations.Add(
                        QueryProcessor.TableRelationships.Facility_GeoCoord.ToString(),
                        ds.Tables["Facility"].Columns["STATEFACILITYIDENTIFIER"],
                        ds.Tables["GeoCoord"].Columns["STATEFACILITYIDENTIFIER"]);

                    ds.Relations.Add(
                        QueryProcessor.TableRelationships.Facility_MailAdd.ToString(),
                        ds.Tables["Facility"].Columns["STATEFACILITYIDENTIFIER"],
                        ds.Tables["MailAdd"].Columns["STATEFACILITYIDENTIFIER"]);

                    ds.Relations.Add(
                        QueryProcessor.TableRelationships.Facility_NAICS.ToString(),
                        ds.Tables["Facility"].Columns["STATEFACILITYIDENTIFIER"],
                        ds.Tables["NAICS"].Columns["STATEFACILITYIDENTIFIER"]);

                    ds.Relations.Add(
                        QueryProcessor.TableRelationships.Facility_SIC.ToString(),
                        ds.Tables["Facility"].Columns["STATEFACILITYIDENTIFIER"],
                        ds.Tables["SIC"].Columns["STATEFACILITYIDENTIFIER"]);

                    ds.AcceptChanges();
                }
                return ds;
            }
            catch (Exception ex) 
            {
                //Capture the excpetions
				string sysErrMsg = "NODE" + "Connection String was " + connectionString + "tracker was set to location of " + tracker;
                System.Diagnostics.EventLog.WriteEntry("NODE",sysErrMsg + ex.Message);
            }
            return null;
        }




        /// <summary>
        /// GetData
        /// </summary>
        /// <param name="whereSql"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static DataTable GetData(bool isOracle,
            string sql,
            string connectionString) 
        {   
            try 
            {
				sql = FixSql(sql);
				LOG.Debug("GetData: " + sql);

                //Populate the dataset with the results of the query

                if (isOracle)
                {
                    return OracleHelper.ExecuteDataset(
                                  connectionString,
                                  CommandType.Text,
                                  sql).Tables[0];

                }
                else
                {
                    return SqlHelper.ExecuteDataset(
                                     connectionString,
                                     CommandType.Text,
                                     sql).Tables[0];
                }
            }
            catch (Exception ex) 
            {
                //Capture the excpetions
                string test = ex.Message;
				//Capture the excpetions
				string sysErrMsg = "NODESQL" + "Connection String was " + connectionString + " sql was " + sql;
				System.Diagnostics.EventLog.WriteEntry("NODE",sysErrMsg + ex.Message);
            }
            return null;
        }

        private static string GetWhere(bool isOracle,
            string methodName,
            int rowId,
            int maxRows,
            string[] parameters)
        {

            string topNum = string.Empty;
			string rowNum = string.Empty;

            //Final Check on Row Nums
            if (maxRows > -1) 
            {
                if (isOracle)
                {
                    topNum = "  ";
                    rowNum = string.Format(" AND (ROWNUM <= {0}) ", maxRows);
                }
                else
                {
                    topNum = string.Format(" TOP {0} ", maxRows);
                    rowNum = " ";
                }
                
            }

            string where = string.Empty;

            switch (methodName.Trim().ToLower())
            {
                case "getfacility":
                    return GetWhere(rowId, maxRows, parameters);

                case "getfacilitybychangedate":
                    where = @"
                        SELECT {0} FAC.STATEFACILITYIDENTIFIER 
                        FROM FRS_FACILITYSITE FAC 
                        WHERE FAC.LASTREPORTEDDATE >= '{1}' AND UPPER(FAC.STATEUSPSCODE) = UPPER('{2}') {3}
	                    ";
                    return string.Format(where, topNum, FixQuotes(parameters[1]), FixQuotes(parameters[0]), rowNum);

                case "getfacilitybyname":
                    where = @"
                        SELECT {0} FAC.STATEFACILITYIDENTIFIER 
                        FROM FRS_FACILITYSITE FAC
                        WHERE UPPER(FAC.FACILITYSITENAME) LIKE UPPER('{1}%') AND UPPER(FAC.STATEUSPSCODE) = UPPER('{2}') {3}
                    ";
                    return string.Format(where, topNum, FixQuotes(parameters[1]), FixQuotes(parameters[0]), rowNum);

                case "getdeletedfacilitybychangedate":
                    where = @"
                        DELETIONDATE >= '{0}'
                    ";
                    return string.Format(where, FixQuotes(parameters[1]));


                default:
                    return string.Empty;
            }


        }





        /// <summary>
        /// GetWhere
        /// </summary>
        /// <param name="rowId"></param>
        /// <param name="maxRows"></param>
        /// <param name="criteria"></param>
        /// <returns></returns>
        private static string GetWhere(
            int rowId,
            int maxRows,
            string [] criteria)
        {
            StringBuilder joins = new StringBuilder(1000);
            StringBuilder where = new StringBuilder(1000);

            bool joinEnvInt = false;
            bool joinSicCode = false;
            bool joinNaicsCode = false;
            bool joinGeoCoord = false;
            bool joinOrganization = false;
            bool joinIndividual = false;

            // Facility Site Name
            if (criteria[CriteriaEnum.FacilityName].Trim().Length > 0)
            {
                where.Append(string.Format("FS.FACILITYSITENAME LIKE '%{0}%' AND ", FixQuotes(criteria[CriteriaEnum.FacilityName])));
            }

            // Facility Registry Identifier
            if (criteria[CriteriaEnum.FRSRegistryId].Trim().Length > 0)
            {
                where.Append(string.Format("FS.FACILITYREGISTRYIDENTIFIER LIKE '%{0}%' AND ", FixQuotes(criteria[CriteriaEnum.FRSRegistryId])));
            }

            // State Facility Identifier
            if (criteria[CriteriaEnum.StateFacilityId].Trim().Length > 0)
            {
                where.Append(string.Format("FS.STATEFACILITYIDENTIFIER = '{0}' AND ", FixQuotes(criteria[CriteriaEnum.StateFacilityId])));
            }

            // Change Date
            if (IsDate(criteria[CriteriaEnum.ChangeDate].Trim()))
            {
                where.Append(string.Format("FS.LASTREPORTEDDATE >= '{0}' AND ", DateTime.Parse(criteria[CriteriaEnum.ChangeDate]).ToShortDateString()));
            }

            // Information System Identifier
            if (criteria[CriteriaEnum.StateSystemId].Trim().Length > 0)
            {
                where.Append(string.Format("EI.INFORMATIONSYSTEMIDENTIFIER = '{0}' AND ", FixQuotes(criteria[CriteriaEnum.StateSystemId])));
                joinEnvInt |= true;
            }

            // Environmental Interest Type Text
            if (criteria[CriteriaEnum.EnvIntTypes].Trim().Length > 0)
            {
                where.Append(string.Format("EI.ENVIRONMENTALINTERESTTYPETEXT IN ({0}) AND ", ParseInClause(criteria[CriteriaEnum.EnvIntTypes])));
                joinEnvInt |= true;
            }

            // Information System Acronym Name
            if (criteria[CriteriaEnum.StateSystemAcronym].Trim().Length > 0)
            {
                where.Append(string.Format("EI.INFORMATIONSYSTEMACRONYMNAME = '{0}' AND ", FixQuotes(criteria[CriteriaEnum.StateSystemAcronym])));
                joinEnvInt |= true;
            }

            // SIC Code
            if (criteria[CriteriaEnum.SICCodes].Trim().Length > 0)
            {
                string [] sics = criteria[CriteriaEnum.SICCodes].Trim().Split("|".ToCharArray());
                string temp = "";
                foreach (string s in sics)
                    temp += string.Format("SC.SICCODE LIKE '%{0}%' OR ", FixQuotes(s));
                temp = temp.Substring(0, temp.Length - 4);
				
                where.Append(string.Format("({0}) AND ", temp));
                joinSicCode |= true;
            }

            // Naics Code
            if (criteria[CriteriaEnum.NaicsCodes].Trim().Length > 0)
            {
                string [] naics = criteria[CriteriaEnum.NaicsCodes].Trim().Split("|".ToCharArray());
                string temp = "";
                foreach (string s in naics)
                    temp += string.Format("NC.NAICSCODE LIKE '%{0}%' OR ", FixQuotes(s));
                temp = temp.Substring(0, temp.Length - 4);
				
                where.Append(string.Format("({0}) AND ", temp));
                joinNaicsCode |= true;
            }

            // Location Address Text
            if (criteria[CriteriaEnum.LocationAddress].Trim().Length > 0)
            {
                where.Append(string.Format("FS.LOCATIONADDRESSTEXT LIKE '%{0}%' AND ", FixQuotes(criteria[CriteriaEnum.LocationAddress])));
            }

            // Locality Name
            if (criteria[CriteriaEnum.CityName].Trim().Length > 0)
            {
                where.Append(string.Format("FS.LOCALITYNAME = '{0}' AND ", FixQuotes(criteria[CriteriaEnum.CityName])));
            }

            // Location Zip Code
            if (criteria[CriteriaEnum.ZipCode].Trim().Length > 0)
            {
                where.Append(string.Format("FS.LOCATIONZIPCODE LIKE '%{0}%' AND ", FixQuotes(criteria[CriteriaEnum.ZipCode])));
            }

            // State USPS Code
            if (criteria[CriteriaEnum.State].Trim().Length > 0)
            {
                where.Append(string.Format("FS.STATEUSPSCODE = '{0}' AND ", FixQuotes(criteria[CriteriaEnum.State])));
            }

            // EPA Region 
            // ***** NOT IMPLEMENTED *****
            if (criteria[CriteriaEnum.EPARegions].Trim().Length > 0)
            {
                throw new ApplicationException(string.Format(NOT_SUPPORTED_MSG, "EPARegion"));
            }

            // HUC Code
            if (criteria[CriteriaEnum.HUCCode].Trim().Length > 0)
            {
                where.Append(string.Format("FS.HUCCODE = '{0}' AND ", FixQuotes(criteria[CriteriaEnum.HUCCode])));
            }

            // County State FIPS Code
            if (criteria[CriteriaEnum.FIPSCodes].Trim().Length > 0)
            {
                where.Append(string.Format("EI.COUNTYSTATEFIPSCODE IN ({0}) AND ", ParseInClause(criteria[CriteriaEnum.FIPSCodes])));
            }

            // County Name
            if (criteria[CriteriaEnum.CountyNames].Trim().Length > 0)
            {
                where.Append(string.Format("FS.COUNTYNAME IN ({0}) AND ", ParseInClause(criteria[CriteriaEnum.CountyNames])));
            }

            // North Bounding Longitude
            if (criteria[CriteriaEnum.NBoundingLong].Trim().Length > 0 && IsDouble(criteria[CriteriaEnum.NBoundingLong].Trim()))
            {
                where.Append(string.Format("GC.LATITUDEMEASURE <= {0} AND ", criteria[CriteriaEnum.NBoundingLong]));
                joinGeoCoord |= true;
            }

            // South Bounding Longitude
            if (criteria[CriteriaEnum.SBoundingLong].Trim().Length > 0 && IsDouble(criteria[CriteriaEnum.SBoundingLong].Trim()))
            {
                where.Append(string.Format("GC.LATITUDEMEASURE >= {0} AND ", criteria[CriteriaEnum.SBoundingLong]));
                joinGeoCoord |= true;
            }

            // East Bounding Latitude
            if (criteria[CriteriaEnum.EBoundingLat].Trim().Length > 0 && IsDouble(criteria[CriteriaEnum.EBoundingLat].Trim()))
            {
                where.Append(string.Format("GC.LONGITUDEMEASURE <= {0} AND ", criteria[CriteriaEnum.EBoundingLat]));
                joinGeoCoord |= true;
            }

            // West Bounding Latitude
            if (criteria[CriteriaEnum.WBoundingLat].Trim().Length > 0 && IsDouble(criteria[CriteriaEnum.WBoundingLat].Trim()))
            {
                where.Append(string.Format("GC.LONGITUDEMEASURE >= {0} AND ", criteria[CriteriaEnum.WBoundingLat]));
                joinGeoCoord |= true;
            }

            // Township/Range/Section/Quarters
            // ***** NOT IMPLEMENTED *****
            if (criteria[CriteriaEnum.TRSQ].Trim().Length > 0)
            {
                throw new ApplicationException(string.Format(NOT_SUPPORTED_MSG, "Township/Range/Section/Quarters"));
            }

            // State Congressional District Number
            // ***** NOT IMPLEMENTED *****
            if (criteria[CriteriaEnum.StateCongressDistNums].Trim().Length > 0)
            {
                throw new ApplicationException(string.Format(NOT_SUPPORTED_MSG, "StateCongressionalDistrictNumber"));
            }

            // State House District Number
            // ***** NOT IMPLEMENTED *****
            if (criteria[CriteriaEnum.StateHouseDistNums].Trim().Length > 0)
            {
                throw new ApplicationException(string.Format(NOT_SUPPORTED_MSG, "StateHouseDistrictNumber"));
            }

            // State Senate District Number
            // ***** NOT IMPLEMENTED *****
            if (criteria[CriteriaEnum.StateSenateDistNums].Trim().Length > 0)
            {
                throw new ApplicationException(string.Format(NOT_SUPPORTED_MSG, "StateSenateDistrictNumber"));
            }

            // Federal Congressional District Number
            // ***** NOT IMPLEMENTED *****
            if (criteria[CriteriaEnum.FedCongressDistNums].Trim().Length > 0)
            {
                throw new ApplicationException(string.Format(NOT_SUPPORTED_MSG, "FederalCongressionalDistrictNumber"));
            }

            // Federal House District Number
            // ***** NOT IMPLEMENTED *****
            if (criteria[CriteriaEnum.FedHouseDistNums].Trim().Length > 0)
            {
                throw new ApplicationException(string.Format(NOT_SUPPORTED_MSG, "FederalHouseDistrictNumber"));
            }

            // Federal Senate District Number
            // ***** NOT IMPLEMENTED *****
            if (criteria[CriteriaEnum.FedSenateDistNums].Trim().Length > 0)
            {
                throw new ApplicationException(string.Format(NOT_SUPPORTED_MSG, "FederalSenateDistrictNumber"));
            }

            // Tribal Land Code
            if (criteria[CriteriaEnum.TribalLandCode].Trim().Length > 0)
            {
                where.Append(string.Format("FS.TRIBALLANDINDICATOR = '{0}' AND ", FixQuotes(criteria[CriteriaEnum.TribalLandCode])));
            }

            // Tribal Land Name
            if (criteria[CriteriaEnum.TribalLandName].Trim().Length > 0)
            {
                where.Append(string.Format("FS.TRIBALLANDNAME = '{0}' AND ", FixQuotes(criteria[CriteriaEnum.TribalLandName])));
            }

            // Federal Facility Indicator
            if (criteria[CriteriaEnum.FederalFacility].Trim().Length > 0)
            {
                where.Append(string.Format("FS.FEDERALFACILITYINDICATOR = '{0}' AND ", FixQuotes(criteria[CriteriaEnum.FederalFacility])));
                joinOrganization |= true;
            }

            // Organization DUNS Number
            if (criteria[CriteriaEnum.OrgDUNSNum].Trim().Length > 0)
            {
                where.Append(string.Format("O.ORGANIZATIONDUNSNUMBER = '{0}' AND ", FixQuotes(criteria[CriteriaEnum.OrgDUNSNum])));
                joinOrganization |= true;
            }

            // Oranization Formal Name
            if (criteria[CriteriaEnum.OrgName].Trim().Length > 0)
            {
                where.Append(string.Format("O.ORGANIZATIONFORMALNAME LIKE '{0}' AND ", FixQuotes(criteria[CriteriaEnum.OrgName])));
                joinOrganization |= true;
            }

            // Individual Full Name
            if (criteria[CriteriaEnum.IndividualName].Trim().Length > 0)
            {
                where.Append(string.Format("I.INDIVIDUALFULLNAME LIKE '{0}' AND ", FixQuotes(criteria[CriteriaEnum.IndividualName])));
                joinIndividual |= true;
            }

            // Remove trailing "AND" from WHERE clause.
            where.Remove(where.Length - 4, 4);

            // Add join clauses.
            if (joinEnvInt)
            {
                joins.Append(string.Format(
                    "INNER JOIN {0}FRS_EnvironmentalInterest EI ON EI.STATEFACILITYIDENTIFIER = FS.STATEFACILITYIDENTIFIER ", SCHEMA));
            }

            if (joinSicCode)
            {
                joins.Append(string.Format(
                    "INNER JOIN {0}FRS_SICCode SC ON SC.STATEFACILITYIDENTIFIER = FS.STATEFACILITYIDENTIFIER ", SCHEMA));
            }

            if (joinNaicsCode)
            {
                joins.Append(string.Format(
                    "INNER JOIN {0}FRS_NAICSCode NC ON NC.STATEFACILITYIDENTIFIER = FS.STATEFACILITYIDENTIFIER ", SCHEMA));
            }

            if (joinGeoCoord)
            {
                joins.Append(string.Format(
                    "INNER JOIN {0}FRS_GeographicCoordinates GC ON GC.STATEFACILITYIDENTIFIER = FS.STATEFACILITYIDENTIFIER ", SCHEMA));
            }

            if (joinOrganization)
            {
                joins.Append(string.Format(
                    "INNER JOIN {0}FRS_Organization O ON O.STATEFACILITYIDENTIFIER = FS.STATEFACILITYIDENTIFIER ", SCHEMA));
            }

            if (joinIndividual)
            {
                joins.Append(string.Format(
                    "INNER JOIN {0}FRS_Individual I ON I.STATEFACILITYIDENTIFIER = FS.STATEFACILITYIDENTIFIER ", SCHEMA));
            }

            string top;
            if (maxRows < 0)
            {
                top = " 100 PERCENT ";
            }
            else
            {
                top = maxRows.ToString();
            }



            string sql = string.Format(
                @"SELECT TOP {3} FS.STATEFACILITYIDENTIFIER
				FROM {0}FRS_FacilitySite FS
				{1}
				WHERE {2} 
                ORDER BY FS.STATEFACILITYIDENTIFIER ", SCHEMA, joins.ToString(), where.ToString(), top );

            LOG.Debug("SQL: {0}", sql);

            return sql;
        }




        /// <summary>
        /// GetSql
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="inSelect"></param>
        /// <returns></returns>
        private static string GetSql(QueryElements elementType, string inSelect)
        {

            string sql = string.Empty;


            switch (elementType)
            {
                case QueryElements.Deleted: 
                    sql = @"
                        SELECT DISTINCT 
                            statefacilityidentifier
                        FROM {0}FRS_Deleted_Facility  
                        WHERE {1} ";
                    break;
                case QueryElements.Facility: 
                    sql = @"
                        SELECT DISTINCT 
                            f.facilityregistryidentifier, 
                            f.facilitysitename,
                            f.facilitysitetypename, 
                            f.federalfacilityindicator,
                            f.triballandindicator, 
                            f.triballandname, 
                            f.congressionaldistrictnumber,
                            f.legislativedistrictnumber, 
                            f.huccode, 
                            f.locationaddresstext,
                            f.supplementallocationtext, 
                            f.localityname, 
                            f.countystatefipscode,
                            f.countyname, 
                            f.stateuspscode, 
                            f.statename, 
                            f.countryname,
                            f.locationzipcode, 
                            f.locationdescriptiontext, 
                            f.datasourcename,
                            f.lastreporteddate, 
                            f.statefacilitysystemacronymname,
                            f.statefacilityidentifier
                        FROM {0}FRS_FACILITYSITE f 
                        WHERE f.statefacilityidentifier IN ({1}) 
                        ORDER BY f.facilitysitename ";
                    break;
                case QueryElements.AltName:
                    sql = @"
                        SELECT DISTINCT 
                            a.alternativename, 
                            a.alternativenametypetext, 
                            a.datasourcename,
                            a.lastreporteddate, 
                            a.statefacilitysystemacronymname,
                            a.statefacilityidentifier
                        FROM {0}FRS_AlternateName a 
                        WHERE a.statefacilityidentifier IN ({1}) 
                        ORDER BY a.alternativename ";
                    break;
                case QueryElements.EnvInt:
                    sql = @"
                        SELECT DISTINCT 
                            e.informationsystemacronymname, 
                            e.informationsystemidentifier,
                            e.environmentalinteresttypetext, 
                            e.federalstateinterestindicator,
                            e.environmentalintereststartdate, 
                            e.intereststartdatequalifiertext,
                            e.environmentalinterestenddate, 
                            e.interestenddatequalifiertext,
                            e.datasourcename, 
                            e.lastreporteddate, 
                            e.statefacilitysystemacronymname,
                            e.statefacilityidentifier
                        FROM {0}FRS_EnvironmentalInterest e 
                        WHERE e.statefacilityidentifier IN ({1}) 
                        ORDER BY e.informationsystemacronymname ";
                    break;
                case QueryElements.GeoCoor:
                    sql = @"
                        SELECT DISTINCT 
                            g.latitudemeasure, 
                            g.longitudemeasure, 
                            g.horizontalaccuracymeasure,
                            g.horizontalcollectionmethodtext, 
                            g.horizontalreferencedatumname,
                            g.sourcemapscalenumber, 
                            g.referencepointtext, 
                            g.datacollectiondate,
                            g.geometrictypename, 
                            g.locationcommentstext,
                            g.verticalcollectionmethodtext, 
                            g.verticalmeasure,
                            g.verticalaccuracymeasure, 
                            g.verticalreferencedatumname,
                            g.datasourcename, 
                            g.coordinatedatasourcename, 
                            g.subentityidentifier,
                            g.subentitytypename, 
                            g.statefacilitysystemacronymname,
                            g.statefacilityidentifier
                        FROM {0}FRS_GeographicCoordinates g 
                        WHERE g.statefacilityidentifier IN ({1}) ";
                    break;
                case QueryElements.Individual:
                    sql = @"
                        SELECT DISTINCT 
                            i.informationsystemacronymname, 
                            i.informationsystemidentifier,
                            i.environmentalinteresttypetext, 
                            i.affiliationtypetext,
                            i.affiliationstartdate, 
                            i.affiliationenddate, 
                            i.emailaddresstext,
                            i.telephonenumber, 
                            i.phoneextension, 
                            i.faxnumber,
                            i.alternatetelephonenumber, 
                            i.individualfullname,
                            i.individualtitletext, 
                            i.mailingaddresstext, 
                            i.supplementaladdresstext,
                            i.mailingaddresscityname, 
                            i.mailingaddressstateuspscode,
                            i.mailingaddressstatename, 
                            i.mailingaddresscountryname,
                            i.mailingaddresszipcode, 
                            i.datasourcename, 
                            i.lastreporteddate,
                            i.statefacilitysystemacronymname, 
                            i.statefacilityidentifier
                        FROM {0}FRS_Individual i 
                        WHERE i.statefacilityidentifier IN ({1})  
                        ORDER BY i.informationsystemacronymname ";
                    break;
                case QueryElements.MailingAddress:
                    sql = @"
                        SELECT DISTINCT 
                            m.affiliationtypetext, 
                            m.mailingaddresstext, 
                            m.supplementaladdresstext,
                            m.mailingaddresscityname, 
                            m.mailingaddressstateuspscode,
                            m.mailingaddressstatename, 
                            m.mailingaddresscountryname,
                            m.mailingaddresszipcode, 
                            m.datasourcename, 
                            m.lastreporteddate,
                            m.statefacilitysystemacronymname, 
                            m.statefacilityidentifier
                        FROM {0}FRS_MailingAddress m  
                        WHERE m.statefacilityidentifier IN ({1}) ";
                    break;
                case QueryElements.NAICS:
                    sql = @"
                        SELECT DISTINCT 
                            n.informationsystemacronymname, 
                            n.informationsystemidentifier,
                            n.environmentalinteresttypetext, 
                            n.naicscode, 
                            n.naicsprimaryindicator,
                            n.datasourcename, 
                            n.lastreporteddate, 
                            n.statefacilitysystemacronymname,
                            n.statefacilityidentifier
                        FROM {0}FRS_NAICSCode n  
                        WHERE n.statefacilityidentifier IN ({1}) 
                        ORDER BY n.informationsystemacronymname ";
                    break;
                case QueryElements.Org:
                    sql = @"
                        SELECT DISTINCT 
                            o.informationsystemacronymname, 
                            o.informationsystemidentifier,
                            o.environmentalinteresttypetext, 
                            o.affiliationtypetext,
                            o.affiliationstartdate, 
                            o.affiliationenddate, 
                            o.emailaddresstext,
                            o.telephonenumber, 
                            o.phoneextension, 
                            o.faxnumber,
                            o.alternatetelephonenumber, 
                            o.organizationformalname,
                            o.organizationdunsnumber, 
                            o.organizationtypetext, 
                            o.employeridentifier,
                            o.statebusinessidentifier, 
                            o.ultimateparentname,
                            o.ultimateparentdunsnumber, 
                            o.mailingaddresstext,
                            o.supplementaladdresstext, 
                            o.mailingaddresscityname,
                            o.mailingaddressstateuspscode, 
                            o.mailingaddressstatename,
                            o.mailingaddresscountryname, 
                            o.mailingaddresszipcode, 
                            o.datasourcename,
                            o.lastreporteddate, 
                            o.statefacilitysystemacronymname,
                            o.statefacilityidentifier
                        FROM {0}FRS_Organization o  
                        WHERE o.statefacilityidentifier IN ({1}) 
                        ORDER BY o.informationsystemacronymname ";
                    break;
                case QueryElements.SIC:
                    sql = @"
                        SELECT DISTINCT  
                            s.informationsystemacronymname, 
                            s.informationsystemidentifier,
                            s.environmentalinteresttypetext, 
                            s.siccode, 
                            s.sicprimaryindicator,
                            s.datasourcename, 
                            s.lastreporteddate, 
                            s.statefacilitysystemacronymname,
                            s.statefacilityidentifier
                        FROM {0}FRS_SICCode s 
                        WHERE s.statefacilityidentifier IN ({1}) 
                        ORDER BY s.informationsystemacronymname ";
                    break;
                default:
                    return string.Empty;
            }


            //Format sql on return
            return string.Format(sql, SCHEMA, inSelect);

        }



        #region Utilities

        private static string FixSql(string input)
        {
            string output = input;
            output = output.Replace("\n", " ");
            output = output.Replace("\t", " ");
            output = output.Replace("\r", " ");
            
            while(output.IndexOf("  ")>-1){
            
            output = output.Replace("  ", " ");
            
            }
            return output;
        }

        private static bool IsDate(string input)
        {
            try
            {
                DateTime d = DateTime.Parse(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsDouble(string input)
        {
            try
            {
                double d = double.Parse(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string FixQuotes(string input)
        {
            string output = input;
            output = output.Replace("'", "''");
            return output.Trim();
        }

        private static string ParseInClause(string input)
        {
            string output = "";
            string [] ss = input.Split("|".ToCharArray());
            foreach (string s in ss)
            {
                output += string.Format("'{0}',", FixQuotes(s));
            }
            return output.Substring(0, output.Length - 1);
        }


        #endregion

        #region Enums

        /// <summary>
        /// QueryElements
        /// </summary>
        private enum QueryElements 
        {
            Facility, 
            AltName,
            EnvInt,
            GeoCoor,
            Individual,
            MailingAddress,
            NAICS,
            Org,
            SIC,
            Deleted
        }

        public class CriteriaEnum
        {
            private CriteriaEnum()
            {}

            static public int FacilityName = 0;
            static public int FRSRegistryId = 1;
            static public int StateFacilityId = 2;
            static public int ChangeDate = 3;
            static public int StateSystemId = 4;
            static public int EnvIntTypes = 5;
            static public int StateSystemAcronym = 6;
            static public int SICCodes = 7;
            static public int NaicsCodes = 8;
            static public int LocationAddress = 9;
            static public int CityName = 10;
            static public int ZipCode = 11;
            static public int State = 12;
            static public int EPARegions = 13;
            static public int HUCCode = 14;
            static public int FIPSCodes = 15;
            static public int CountyNames = 16;
            static public int NBoundingLong = 17;
            static public int SBoundingLong = 18;
            static public int EBoundingLat = 19;
            static public int WBoundingLat = 20;
            static public int TRSQ = 21;
            static public int StateCongressDistNums = 22;
            static public int StateHouseDistNums = 23;
            static public int StateSenateDistNums = 24;
            static public int FedCongressDistNums = 25;
            static public int FedHouseDistNums = 26;
            static public int FedSenateDistNums = 27;
            static public int TribalLandCode = 28;
            static public int TribalLandName = 29;
            static public int FederalFacility = 30;
            static public int OrgDUNSNum = 31;
            static public int OrgName = 32;
            static public int IndividualName = 33;
        }


        #endregion
    }
}
