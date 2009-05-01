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
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.NEI_DB
{
    public class DataPump
    {

        private enum PUMP_TABLES
        {

            NEI_TRANSMITTAL,
            NEI_SITE,
            NEI_EMISSIONUNIT,
            NEI_EMISSIONRELEASEPOINT,
            NEI_EMISSIONPROCESS,
            NEI_EMISSIONPERIOD,
            NEI_CONTROLEQUIPMENT,
            NEI_EMISSIONSUBMISSION

        }

        private const string SQL_SELECT_NEI_CHECK = "" + "SELECT COUNT(*) FROM TBLPOINTTR WHERE INTINVENTORYYEAR <> {0}";

        private const string SQL_SELECT_NEI_TRANSMITTAL = "" + "SELECT STRRECORDTYPE, STRSTATECOUNTYFIPS, STRORGANIZATIONNAME, NULL, INTINVENTORYYEAR, STRINVENTORYTYPECODE, " + "NULL, INTINCREMENTALSUBMISSIONNUMBER, SNGRELIABILITYINDICATOR, STRTRANSACTIONCOMMENTS, STRCONTACTPERSONNAME, " + "STRCONTACTPHONENUMBER, STRTELEPHONENUMBERTYPENAME, STRELECTRONICADDRESSTEXT, STRELECTRONICADDRESSTYPENAME, " + "STRSOURCETYPE, STRAFFILIATIONTYPE, SNGFORMATVERSION, STRTRIBALCODE FROM TBLPOINTTR";

        private const string SQL_SELECT_NEI_SITE = "" + "SELECT STRRECORDTYPE, STRSTATECOUNTYFIPS, STRSTATEFACILITYIDENTIFIER, STRFACILITYREGISTRYIDENTIFIER, " + "STRFACILITYCATEGORY, STRORISFACILITYCODE, STRSICPRIMARY, STRNAICSPRIMARY, STRFACILITYNAME, STRSITEDESCRIPTION, " + "STRLOCATIONADDRESS, STRCITY, STRSTATE, STRZIPCODE, STRCOUNTRY, STRNTISITEID, NULL, STRTRIID, 'A', STRTRIBALCODE, " + "STRSTATEFACILITYIDENTIFIER, {0} FROM TBLPOINTSI";

        private const string SQL_SELECT_NEI_EMISSIONUNIT = "" + "SELECT STRRECORDTYPE, STRSTATECOUNTYFIPS, STRSTATEFACILITYIDENTIFIER, STREMISSIONUNITID, STRORISBOILERID, " + "STRSICUNITLEVEL, STRNAICSUNITLEVEL, SNGDESIGNCAPACITY, STRDESIGNCAPACITYUNITNUMERATOR, " + "STRDESIGNCAPACITYUNITDENOMINATOR, SNGMAXNAMEPLATECAPACITY, STREMISSIONUNITDESCRIPTION, 'A', STRTRIBALCODE, " + "STRSTATEFACILITYIDENTIFIER, STREMISSIONUNITID, {0} FROM TBLPOINTEU";

        private const string SQL_SELECT_NEI_EMISSIONRELEASEPOINT = "" + "SELECT STRRECORDTYPE, STRSTATECOUNTYFIPS, STRSTATEFACILITYIDENTIFIER, STREMISSIONRELEASEPOINTID, " + "STREMISSIONRELEASEPOINTTYPE, SNGSTACKHEIGHT, SNGSTACKDIAMETER, SNGSTACKFENCELINEDISTANCE, " + "SNGEXITGASTEMPERATURE, SNGEXITGASVELOCITY, SNGEXITGASFLOWRATE, DBLXCOORDINATE, DBLYCOORDINATE, " + "INTUTMZONE, STRXYCOORDINATETYPE, LNGHORIZONTALAREAFUGITIVE, LNGRELEASEHEIGHTFUGITIVE, " + "STRFUGITIVEDIMENSIONSUNIT, STREMISSIONRELEASEPTDESCRIPTION, 'A', STRHORIZONTALCOLLECTIONMETHODCODE, " + "STRHORIZONTALACCURACYMEASURE, STRHORIZONTALREFERENCEDATUMCODE, STRREFERENCEPOINTCODE, STRSOURCEMAPSCALENUMBER, " + "STRCOORDINATEDATASOURCECODE, STRTRIBALCODE, STRSTATEFACILITYIDENTIFIER, STREMISSIONRELEASEPOINTID, {0} " + "FROM TBLPOINTER";

        private const string SQL_SELECT_NEI_EMISSIONPROCESS = "" + "SELECT STRRECORDTYPE, STRSTATECOUNTYFIPS, STRSTATEFACILITYIDENTIFIER, STREMISSIONUNITID, STREMISSIONRELEASEPOINTID, " + "STRPROCESSID, STRSCC, STRPROCESSMACTCODE, STREMISSIONPROCESSDESCRIPTION, INTWINTERTHROUGHPUTPCT, INTSPRINGTHROUGHPUTPCT, " + "INTSUMMERTHROUGHPUTPCT, INTFALLTHROUGHPUTPCT, INTANNUALAVGDAYSPERWEEK, INTANNUALAVGWEEKSPERYEAR, INTANNUALAVGHOURSPERDAY, " + "INTANNUALAVGHOURSPERYEAR, SNGHEATCONTENT, SNGSULFURCONTENT, SNGASHCONTENT, STRPROCESSMACTCOMPLIANCESTATUS, 'A', " + "STRTRIBALCODE, STRSTATEFACILITYIDENTIFIER, STREMISSIONUNITID, STRPROCESSID, {0} FROM TBLPOINTEP";

        private const string SQL_SELECT_NEI_EMISSIONPERIOD = "" + "SELECT STRRECORDTYPE, STRSTATECOUNTYFIPS, STRSTATEFACILITYIDENTIFIER, STREMISSIONUNITID, STRPROCESSID, LNGSTARTDATE, " + "LNGENDDATE, INTSTARTTIME, INTENDTIME, SNGACTUALTHROUGHPUT, STRTHROUGHPUTUNITNUMERATOR, INTMATERIAL, STRMATERIALIO, " + "INTPERIODDAYSPERWEEK, INTPERIODWEEKSPERPERIOD, INTPERIODHOURSPERDAY, INTPERIODHOURSPERPERIOD, 'A', STRTRIBALCODE, " + "STRSTATEFACILITYIDENTIFIER, STREMISSIONUNITID, STRPROCESSID, {0} FROM TBLPOINTPE";

        private const string SQL_SELECT_NEI_CONTROLEQUIPMENT = "" + "SELECT STRRECORDTYPE, STRSTATECOUNTYFIPS, STRSTATEFACILITYIDENTIFIER, STREMISSIONUNITID, STRPROCESSID, STRPOLLUTANTCODE, " + "SNGPRIMARYPCTCONTROLEFFICIENCY, SNGPCTCAPTUREEFFICIENCY, SNGTOTALCAPTURECONTROLEFFICIENCY, STRPRIMARYDEVICETYPECODE, " + "STRSECONDARYDEVICETYPECODE, STRCONTROLSYSTEMDESCRIPTION, STRTHIRDCONTROLDEVICETYPECODE, STRFOURTHCONTROLDEVICETYPECODE, " + "'A', STRTRIBALCODE, STRSTATEFACILITYIDENTIFIER, STREMISSIONUNITID, STRPROCESSID, {0} FROM TBLPOINTCE";

        private const string SQL_SELECT_NEI_EMISSIONSUBMISSION = "" + "SELECT STRRECORDTYPE, STRSTATECOUNTYFIPS, STRSTATEFACILITYIDENTIFIER, STREMISSIONUNITID, STRPROCESSID, " + "STRPOLLUTANTCODE, STREMISSIONRELEASEPOINTID, LNGSTARTDATE, LNGENDDATE, INTSTARTTIME, INTENDTIME, " + "DBLEMISSIONNUMERICVALUE, STREMISSIONUNITNUMERATOR, STREMISSIONTYPE, SNGEMRELIABILITYINDICATOR, SNGFACTORNUMERICVALUE, " + "STRFACTORUNITNUMERATOR, STRFACTORUNITDENOMINATOR, INTMATERIAL, STRMATERIALIO, STREMISSIONCALCULATIONMETHODCODE, " + "STREFRELIABILITYINDICATOR, SNGRULEEFFECTIVENESS, STRRULEEFFECTIVENESSMETHOD, STRHAPEMISSIONSPERFORMANCELEVEL, " + "STRCONTROLSTATUS, STREMISSIONDATALEVEL, 'A', STRTRIBALCODE, STRSTATEFACILITYIDENTIFIER, " + "STREMISSIONUNITID, STRPROCESSID, {0} FROM TBLPOINTEM";




        private const string SQL_DELETE_NEI_TRANSMITTAL = "" + "DELETE FROM NEI_TRANSMITTAL WHERE INVENTORYYEAR = {0}";

        private const string SQL_DELETE_NEI_SITE = "" + "DELETE FROM NEI_SITE WHERE INVENTORY_YEAR = {0}";

        private const string SQL_DELETE_NEI_EMISSIONUNIT = "" + "DELETE FROM NEI_EMISSIONUNIT WHERE INVENTORY_YEAR = {0}";

        private const string SQL_DELETE_NEI_EMISSIONRELEASEPOINT = "" + "DELETE FROM NEI_EMISSIONRELEASEPOINT WHERE INVENTORY_YEAR = {0}";

        private const string SQL_DELETE_NEI_EMISSIONPROCESS = "" + "DELETE FROM NEI_EMISSIONPROCESS WHERE INVENTORY_YEAR = {0}";

        private const string SQL_DELETE_NEI_EMISSIONPERIOD = "" + "DELETE FROM NEI_EMISSIONPERIOD WHERE INVENTORY_YEAR = {0}";

        private const string SQL_DELETE_NEI_CONTROLEQUIPMENT = "" + "DELETE FROM NEI_CONTROLEQUIPMENT WHERE INVENTORY_YEAR = {0}";

        private const string SQL_DELETE_NEI_EMISSIONSUBMISSION = "" + "DELETE FROM NEI_EMISSIONSUBMISSION WHERE INVENTORY_YEAR = {0}";




        private static void SetData(SpringBaseDao baseDao, DataTable dtSource, PUMP_TABLES tableName, string sqlDelete,
                                    IAppendAuditLogEvent appendAuditLogEvent)
        {

            int rowTest = baseDao.AdoTemplate.ClassicAdoTemplate.ExecuteNonQuery(CommandType.Text, sqlDelete);

            if (dtSource.Rows.Count > 0)
            {
                DataTable targetTable = new DataTable();
                baseDao.FillTable(targetTable, string.Format("SELECT * FROM {0} WHERE 0 = 1", tableName.ToString()));

                string insertColumns = baseDao.GetSemicolonSeparatedColumnNames(targetTable);

                if (string.IsNullOrEmpty(insertColumns))
                {
                    throw new ArgumentException(string.Format("Table \"{0}\" does not contain any columns.", tableName.ToString()));
                }

                object[] insertValues = new object[targetTable.Columns.Count];

                baseDao.DoBulkInsert(tableName.ToString(), insertColumns,
                             delegate(int currentInsertIndex)
                             {
                                 if (currentInsertIndex < dtSource.Rows.Count)
                                 {
                                     for (int i = 0; i < targetTable.Columns.Count; ++i)
                                     {
                                         insertValues[i] = dtSource.Rows[currentInsertIndex][i];
                                     }
                                     return insertValues;
                                 }
                                 else
                                 {
                                     return null;
                                 }
                             });
                appendAuditLogEvent.AppendAuditLogEvent("Inserted {0} row(s) into table \"{1}\"",
                                                               dtSource.Rows.Count.ToString(), tableName.ToString());
            }
            else
            {
                appendAuditLogEvent.AppendAuditLogEvent("No data found to insert into table \"{0}\"",
                                                               tableName.ToString());
            }
        }

        public static void Pump(SpringBaseDao baseDao, string filePath, int inventoryYear, IAppendAuditLogEvent appendAuditLogEvent)
        {
            DataTable dt = GetData(filePath, string.Format(SQL_SELECT_NEI_CHECK, inventoryYear));
            int count = Convert.ToInt32(dt.Rows[0][0]);

            if ((count != 0))
            {
                throw new ApplicationException("Provided file contains data that does not match the provided year parameter.");
            }

            SetData(baseDao, GetData(filePath, SQL_SELECT_NEI_TRANSMITTAL), PUMP_TABLES.NEI_TRANSMITTAL, string.Format(SQL_DELETE_NEI_TRANSMITTAL, inventoryYear), appendAuditLogEvent);


            SetData(baseDao, GetData(filePath, string.Format(SQL_SELECT_NEI_SITE, inventoryYear)), PUMP_TABLES.NEI_SITE, string.Format(SQL_DELETE_NEI_SITE, inventoryYear), appendAuditLogEvent);


            SetData(baseDao, GetData(filePath, string.Format(SQL_SELECT_NEI_EMISSIONUNIT, inventoryYear)), PUMP_TABLES.NEI_EMISSIONUNIT, string.Format(SQL_DELETE_NEI_EMISSIONUNIT, inventoryYear), appendAuditLogEvent);


            SetData(baseDao, GetData(filePath, string.Format(SQL_SELECT_NEI_EMISSIONRELEASEPOINT, inventoryYear)), PUMP_TABLES.NEI_EMISSIONRELEASEPOINT, string.Format(SQL_DELETE_NEI_EMISSIONRELEASEPOINT, inventoryYear), appendAuditLogEvent);


            SetData(baseDao, GetData(filePath, string.Format(SQL_SELECT_NEI_EMISSIONPROCESS, inventoryYear)), PUMP_TABLES.NEI_EMISSIONPROCESS, string.Format(SQL_DELETE_NEI_EMISSIONPROCESS, inventoryYear), appendAuditLogEvent);


            SetData(baseDao, GetData(filePath, string.Format(SQL_SELECT_NEI_EMISSIONPERIOD, inventoryYear)), PUMP_TABLES.NEI_EMISSIONPERIOD, string.Format(SQL_DELETE_NEI_EMISSIONPERIOD, inventoryYear), appendAuditLogEvent);


            SetData(baseDao, GetData(filePath, string.Format(SQL_SELECT_NEI_CONTROLEQUIPMENT, inventoryYear)), PUMP_TABLES.NEI_CONTROLEQUIPMENT, string.Format(SQL_DELETE_NEI_CONTROLEQUIPMENT, inventoryYear), appendAuditLogEvent);


            SetData(baseDao, GetData(filePath, string.Format(SQL_SELECT_NEI_EMISSIONSUBMISSION, inventoryYear)), PUMP_TABLES.NEI_EMISSIONSUBMISSION, string.Format(SQL_DELETE_NEI_EMISSIONSUBMISSION, inventoryYear), appendAuditLogEvent);



        }

        private static DataTable GetData(string filePath, string sql)
        {

            string connectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath;
            DataSet ds = new DataSet();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
                da.Fill(ds);
            }

            return ds.Tables[0];

        }
    }
}
