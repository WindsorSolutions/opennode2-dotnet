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
using System.Collections.Generic;
using System.Data;
using System.Text;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;


namespace Windsor.Node2008.WNOSPlugin.NEI_DB
{
    public class Data
    {


        public enum Tables
        {
            SystemRecordCountValues,
            TransmittalSubmissionGroup,
            SiteSubmissionGroup,
            EmissionUnitSubmissionGroup,
            EmissionReleasePointSubmission,
            EmissionProcessSubmission,
            EmissionPeriodSubmissionGroup,
            EmissionSubmissionGroup,
            ControlEquipmentSubmissionGroup
        }
        //Relationships

        public static DataTable GetDataTable(SpringBaseDao baseDao, Tables tableType, int inventoryYear)
        {

            string sql;

            switch (tableType)
            {

                case Tables.TransmittalSubmissionGroup:
                    sql = "SELECT RECORDTYPECODE, COUNTYSTATEFIPSCODE, ORGANIZATIONFORMALNAME, " + "TRANSACTIONTYPECODE, INVENTORYYEAR, INVENTORYTYPECODE, " + "TRANSACTIONCREATIONDATE, SUBMISSIONNUMBER, RELIABILITYINDICATOR, " + "TRANSACTIONCOMMENT, INDIVIDUALFULLNAME, TELEPHONENUMBER,  " + "TELEHPHONENUMBERTYPENAME, ELECTRONICADDRESSTEXT, ELECTRONICADDRESSTYPENAME,  " + "SOURCETYPECODE, AFFILIATIONTYPETEXT, FORMATVERSIONNUMBER, TRIBALCODE " + "FROM NEI_TRANSMITTAL WHERE INVENTORYYEAR = {0} ";
                    break;
                case Tables.SiteSubmissionGroup:
                    sql = "SELECT SI_ID, INVENTORY_YEAR, RECORDTYPECODE,  " + "COUNTYSTATEFIPSCODE, STATEFACILITYIDENTIFIER, FACILITYREGISTRYIDENTIFIER,  " + "FACILITYCATEGORYCODE, ORISFACILITYCODE, SICCODE,  " + "NAICS_CODE, FACILITYSITENAME, FACILITYDESCRIPTION,  " + "LOCATIONADDRESSTEXT, LOCALITYNAME, LOCATIONSTATECODE,  " + "LOCATIONZIPCODE, COUNTRYNAME, FACILITYNTIIDENTIFIER,  " + "ORGANIZATIONDUNSNUMBER, FACILITYTRIIDENTIFIER, TRANSACTIONSUBMITTALCODE,  " + "TRIBALCODE FROM NEI_SITE  WHERE INVENTORY_YEAR = {0} ";
                    break;
                case Tables.EmissionUnitSubmissionGroup:
                    sql = "SELECT EU_ID, SI_ID, RECORDTYPECODE,   " + "COUNTYSTATEFIPSCODE, STATEFACILITYIDENTIFIER, EMISSIONUNITIDENTIFIER,   " + "ORISBOILERIDENTIFIER, SICCODE, NAICSCODE,   " + "DESIGNCAPACITYMEASURE, UNITNUMERATORVALUE, UNITDENOMINATORVALUE,   " + "DESIGNCAPACITYMAXIMUM, EMISSIONUNITDESCRIPTION, TRANSACTIONSUBMITTALCODE,   " + "TRIBALCODE FROM NEI_EMISSIONUNIT WHERE INVENTORY_YEAR = {0}  ";
                    break;
                case Tables.EmissionReleasePointSubmission:
                    sql = "SELECT ER_ID, SI_ID, RECORDTYPECODE,   " + "COUNTYSTATEFIPSCODE, STATEFACILITYIDENTIFIER, RELEASEPOINTIDENTIFIER,   " + "RELEASEPOINTTYPECODE, STACKHEIGHTVALUE, STACKDIAMETERVALUE,   " + "STACKFENCELINEDISTANCEVALUE, EXITGASTEMPERATUREVALUE, EXITGASSTREAMVELOCITYVALUE,   " + "EXITGASFLOWRATE, LONGITUDEMEASURE, LATITUDEMEASURE,   " + "UTMZONECODE, XYCOORDINATETYPECODE, FUGITIVEHORIZONTALAREAVALUE,   " + "FUGITIVERELEASEHEIGHTVALUE, FUGITIVEUNITOFMEASURECODE, RELEASEPOINTDESCRIPTION,   " + "TRANSACTIONSUBMITTALCODE, HORIZONTALCOLLECTIONMETHODCODE, HORIZONTALACCURACYMEASURE,   " + "HORIZONTALREFERENCEDATUMCODE, REFERENCEPOINTCODE, SOURCEMAPSCALENUMBER,   " + "COORDINATEDATASOURCECODE, TRIBALCODE FROM NEI_EMISSIONRELEASEPOINT   WHERE INVENTORY_YEAR = {0}  ";
                    break;
                case Tables.EmissionProcessSubmission:
                    sql = "SELECT EP_ID, EU_ID, SI_ID,   " + "RECORDTYPECODE, COUNTYSTATEFIPSCODE, STATEFACILITYIDENTIFIER,   " + "EMISSIONUNITIDENTIFIER, RELEASEPOINTIDENTIFIER, PROCESSIDENTIFIER,   " + "SOURCECATEGORYCODE, MACTCODE, EMISSIONPROCESSDESCRIPTION,   " + "THROUGHPUTWINTERPERCENT, THROUGHPUTSPRINGPERCENT, THROUGHPUTSUMMERPERCENT,   " + "THROUGHPUTFALLPERCENT, AVERAGEDAILYPERWEEKVALUE, AVERAGEWEEKSPERYEARVALUE,   " + "AVERAGEHOURSPERDAYVALUE, AVERAGEHOURSPERYEARVALUE, FULLHEATCONTENTMEASURE,   " + "FUELSULFURCONTENTMEASURE, FUELASHCONTENTMEASURE, MACTCOMPLIANCESTATUSCODE,   " + "TRANSACTIONSUBMITTALCODE, TRIBALCODE FROM NEI_EMISSIONPROCESS  WHERE INVENTORY_YEAR = {0}  ";
                    break;
                case Tables.EmissionPeriodSubmissionGroup:
                    sql = "SELECT EP_ID, EU_ID, SI_ID,   " + "RECORDTYPECODE, COUNTYSTATEFIPSCODE, STATEFACILITYIDENTIFIER,   " + "EMISSIONUNITIDENTIFIER, PROCESSIDENTIFIER, EMISSIONPERIODSTARTDATE,   " + "EMISSIONPERIODENDDATE, EMISSIONPERIODSTARTTIME, EMISSIONPERIODENDTIME,   " + "THROUGHPUTVALUE, UNITNUMERATORVALUE, MATERIALCODE,   " + "MATERIALINPUTOUTPUTCODE, AVERAGEDAYSPERWEEKVALUE, AVERAGEWEEKSPERPERIODVALUE,   " + "AVERAGEHOURSPERDAYVALUE, AVERAGEHOURSPERPERIODVALUE, TRANSACTIONSUBMITTALCODE,   " + "TRIBALCODE FROM NEI_EMISSIONPERIOD  WHERE INVENTORY_YEAR = {0}  ";
                    break;
                case Tables.EmissionSubmissionGroup:
                    sql = "SELECT EP_ID, EU_ID, SI_ID,  " + "RECORDTYPECODE, COUNTYSTATEFIPSCODE, STATEFACILITYIDENTIFIER,  " + "EMISSIONUNITIDENTIFIER, PROCESSIDENTIFIER, POLLUTANTCODE, " + "RELEASEPOINTIDENTIFIER, EMISSIONPERIODSTARTDATE, EMISSIONPERIODENDDATE,  " + "EMISSIONPERIODSTARTTIME, EMISSIONPERIODENDTIME, EMISSIONVALUE,  " + "EMISSIONUNITNUMERATORVALUE, EMISSIONTYPECODE, RELIABILITYINDICATOR,  " + "EMISSIONFACTORVALUE, UNITNUMERATORVALUE, UNITDENOMINATORVALUE,  " + "MATERIALCODE, MATERIALINPUTOUTPUTCODE, EMISSIONCALCULATIONMETHODCODE,  " + "EMISSIONFACTORRELIABILITY, RULEEFFECTIVENESSMEASURE, RULEEFFECTIVENESSMETHODCODE,  " + "HAPEMISSIONSPERFORMANCELEVEL, CONTROLSTATUSCODE, EMISSIONDATALEVELIDENTIFIER,  " + "TRANSACTIONSUBMITTALCODE, TRIBALCODE FROM NEI_EMISSIONSUBMISSION WHERE INVENTORY_YEAR = {0} ";
                    break;
                case Tables.ControlEquipmentSubmissionGroup:
                    sql = "SELECT EP_ID, EU_ID, SI_ID,  " + "RECORDTYPECODE, COUNTYSTATEFIPSCODE, STATEFACILITYIDENTIFIER,  " + "EMISSIONUNITIDENTIFIER, PROCESSIDENTIFIER, POLLUTANTCODE,  " + "PRIMARYEFFICIENCYPERCENT, CAPTUREEFFICIENCYPERCENT, TOTALCAPTUREEFFICIENCYPERCENT,  " + "DEVICEPRIMARYTYPECODE, DEVICESECONDARYTYPECODE, CONTROLSYSTEMDESCRIPTION,  " + "DEVICETHIRDTYPECODE, DEVICEFOURTHTYPECODE, TRANSACTIONSUBMITTALCODE,  " + "TRIBALCODE FROM NEI_CONTROLEQUIPMENT WHERE INVENTORY_YEAR = {0} ";
                    break;
                default:
                    throw new ApplicationException("Invalid Table Selection.");
            }

            sql = string.Format(sql, inventoryYear.ToString());

            DataTable table = new DataTable();
            return (baseDao.FillTable(table, sql) > 0) ? table : null;
        }
        //GetData

        public static PointSourceSubmissionGroupType GetPoints(SpringBaseDao baseDao, bool doDeletes, int inventoryYear,
                                                               string tranactionTypeCode, IAppendAuditLogEvent appendAuditLogEvent)
        {

            PointSourceSubmissionGroupType point = new PointSourceSubmissionGroupType();
            //local vars
            DataTable dt;

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //ControlEquipmentSubmissionGroup
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //Get data from db
            dt = Data.GetDataTable(baseDao, Data.Tables.ControlEquipmentSubmissionGroup, inventoryYear);

            //Check if there is any data
            if (dt != null)
            {

                List<ControlEquipmentSubmissionGroupType> ar = new List<ControlEquipmentSubmissionGroupType>();
                //Loop
                foreach (DataRow dr in dt.Rows)
                {

                    //Row variables
                    //Dim the array
                    ControlEquipmentSubmissionGroupType cesc = new ControlEquipmentSubmissionGroupType();

                    //CaptureEfficiencyPercent
                    cesc.CaptureEfficiencyPercentSpecified = Util.isValidDecimal(dr["CaptureEfficiencyPercent"]);
                    if (cesc.CaptureEfficiencyPercentSpecified)
                    {
                        cesc.CaptureEfficiencyPercent = Util.ToDecimal(dr["CaptureEfficiencyPercent"]);
                    }

                    //ControlEquipmentRecordTypeCode
                    cesc.ControlEquipmentRecordTypeCode = Util.ToStr(dr["RecordTypeCode"]);

                    //ControlSystemDescription
                    cesc.ControlSystemDescription = Util.ToStr(dr["ControlSystemDescription"]);

                    //CountyStateFIPSCode
                    cesc.CountyStateFIPSCode = Util.ToStr(dr["CountyStateFIPSCode"]);

                    //DeviceFourthTypeCode
                    cesc.DeviceFourthTypeCode = Util.ToStr(dr["DeviceFourthTypeCode"]);

                    //DevicePrimaryTypeCode
                    cesc.DevicePrimaryTypeCode = Util.ToStr(dr["DevicePrimaryTypeCode"]);

                    //DeviceSecondaryTypeCode
                    cesc.DeviceSecondaryTypeCode = Util.ToStr(dr["DeviceSecondaryTypeCode"]);

                    //DeviceThirdTypeCode
                    cesc.DeviceThirdTypeCode = Util.ToStr(dr["DeviceThirdTypeCode"]);

                    //EmissionUnitIdentifier
                    cesc.EmissionUnitIdentifier = Util.ToStr(dr["EmissionUnitIdentifier"]);

                    //PollutantCode
                    cesc.PollutantCode = Util.ToStr(dr["PollutantCode"]);

                    //PrimaryEfficiencyPercent
                    cesc.PrimaryEfficiencyPercentSpecified = Util.isValidDecimal(dr["PrimaryEfficiencyPercent"]);
                    if (cesc.PrimaryEfficiencyPercentSpecified)
                    {
                        cesc.PrimaryEfficiencyPercent = Util.ToDecimal(dr["PrimaryEfficiencyPercent"]);
                    }

                    //ProcessIdentifier
                    cesc.ProcessIdentifier = Util.ToStr(dr["PROCESSIDENTIFIER"]);

                    //TotalCaptureEfficiencyPercent
                    cesc.TotalCaptureEfficiencyPercentSpecified = Util.isValidDecimal(dr["TotalCaptureEfficiencyPercent"]);
                    if (cesc.TotalCaptureEfficiencyPercentSpecified)
                    {
                        cesc.TotalCaptureEfficiencyPercent = Util.ToDecimal(dr["TotalCaptureEfficiencyPercent"]);
                    }

                    //TransactionSubmittalCode
                    cesc.TransactionSubmittalCode = Util.ToStr(dr["TransactionSubmittalCode"]);

                    //TribalCode
                    cesc.TribalCode = Util.ToStr(dr["TribalCode"]);

                    //StateFacilityIdentifier
                    cesc.StateFacilityIdentifier = Util.ToStr(dr["STATEFACILITYIDENTIFIER"]);

                    //Add element to the array
                    ar.Add(cesc);

                }
                point.ControlEquipmentSubmissionGroup = ar.ToArray();
            }



            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //EmissionPeriodSubmissionGroup
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //Get data from db
            dt = Data.GetDataTable(baseDao, Data.Tables.EmissionPeriodSubmissionGroup, inventoryYear);

            //Check if there is any data
            if (dt != null)
            {

                List<EmissionPeriodSubmissionGroupType> ar = new List<EmissionPeriodSubmissionGroupType>();
                //Loop
                foreach (DataRow dr in dt.Rows)
                {

                    //Dim the array
                    EmissionPeriodSubmissionGroupType epsg = new EmissionPeriodSubmissionGroupType();

                    //AverageDaysPerWeekValue
                    epsg.AverageDaysPerWeekValueSpecified = Util.isValidDecimal(dr["AverageDaysPerWeekValue"]);
                    if (epsg.AverageDaysPerWeekValueSpecified)
                    {
                        epsg.AverageDaysPerWeekValue = Util.ToDecimal(dr["AverageDaysPerWeekValue"]);
                    }

                    //AverageHoursPerDayValue
                    epsg.AverageHoursPerDayValueSpecified = Util.isValidDecimal(dr["AverageHoursPerDayValue"]);
                    if (epsg.AverageHoursPerDayValueSpecified)
                    {
                        epsg.AverageHoursPerDayValue = Util.ToDecimal(dr["AverageHoursPerDayValue"]);
                    }

                    //AverageHoursPerPeriodValue
                    epsg.AverageHoursPerPeriodValueSpecified = Util.isValidDecimal(dr["AverageHoursPerPeriodValue"]);
                    if (epsg.AverageHoursPerPeriodValueSpecified)
                    {
                        epsg.AverageHoursPerPeriodValue = Util.ToDecimal(dr["AverageHoursPerPeriodValue"]);
                    }

                    //AverageWeeksPerPeriodValue
                    epsg.AverageWeeksPerPeriodValueSpecified = Util.isValidDecimal(dr["AverageWeeksPerPeriodValue"]);
                    if (epsg.AverageWeeksPerPeriodValueSpecified)
                    {
                        epsg.AverageWeeksPerPeriodValue = Util.ToDecimal(dr["AverageWeeksPerPeriodValue"]);
                    }

                    //CountyStateFIPSCode
                    epsg.CountyStateFIPSCode = Util.ToStr(dr["CountyStateFIPSCode"]);

                    //EmissionPeriodEndDate
                    epsg.EmissionPeriodEndDate = Util.ToStr(dr["EmissionPeriodEndDate"]);

                    //EmissionPeriodEndTime
                    epsg.EmissionPeriodEndTime = Util.ToStr(dr["EmissionPeriodEndTime"]);

                    //RECORDTYPECODE
                    epsg.EmissionPeriodRecordTypeCode = Util.ToStr(dr["RECORDTYPECODE"]);

                    //EmissionPeriodStartDate
                    epsg.EmissionPeriodStartDate = Util.ToStr(dr["EmissionPeriodStartDate"]);

                    //EmissionPeriodStartTime
                    epsg.EmissionPeriodStartTime = Util.ToStr(dr["EmissionPeriodStartTime"]);

                    //EmissionUnitIdentifier
                    epsg.EmissionUnitIdentifier = Util.ToStr(dr["EmissionUnitIdentifier"]);

                    //MaterialCode
                    epsg.MaterialCodeSpecified = Util.isValidDecimal(dr["MaterialCode"]);
                    if (epsg.MaterialCodeSpecified)
                    {
                        epsg.MaterialCode = Util.ToDecimal(dr["MaterialCode"]);
                    }

                    //MaterialInputOutputCode
                    epsg.MaterialInputOutputCode = Util.ToStr(dr["MaterialInputOutputCode"]);

                    //ProcessIdentifier
                    epsg.ProcessIdentifier = Util.ToStr(dr["PROCESSIDENTIFIER"]);

                    //StateFacilityIdentifier
                    epsg.StateFacilityIdentifier = Util.ToStr(dr["StateFacilityIdentifier"]);

                    //ThroughputValue
                    epsg.ThroughputValueSpecified = Util.isValidDecimal(dr["ThroughputValue"]);
                    if (epsg.ThroughputValueSpecified)
                    {
                        epsg.ThroughputValue = Util.ToDecimal(dr["ThroughputValue"], 10);
                    }

                    //TransactionSubmittalCode
                    epsg.TransactionSubmittalCode = Util.ToStr(dr["TransactionSubmittalCode"]);

                    //TribalCode
                    epsg.TribalCode = Util.ToStr(dr["TribalCode"]);

                    //UnitNumeratorValue
                    epsg.UnitNumeratorValue = Util.ToStr(dr["UnitNumeratorValue"]);

                    //Add element to the array
                    ar.Add(epsg);

                }
                point.EmissionPeriodSubmissionGroup = ar.ToArray();
            }






            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //EmissionProcessSubmission
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //Get data from db
            dt = Data.GetDataTable(baseDao, Data.Tables.EmissionProcessSubmission, inventoryYear);

            //Check if there is any data
            if (dt != null)
            {

                List<EmissionProcessSubmissionGroupType> ar = new List<EmissionProcessSubmissionGroupType>();
                //Loop
                foreach (DataRow dr in dt.Rows)
                {

                    //Dim the array
                    EmissionProcessSubmissionGroupType ersg = new EmissionProcessSubmissionGroupType();

                    //AverageDaysPerWeekValue
                    ersg.AverageDaysPerWeekValueSpecified = Util.isValidDecimal(dr["AVERAGEDAILYPERWEEKVALUE"]);
                    if (ersg.AverageDaysPerWeekValueSpecified)
                    {
                        ersg.AverageDaysPerWeekValue = Util.ToDecimal(dr["AVERAGEDAILYPERWEEKVALUE"]);
                    }

                    //AverageHoursPerDayValue
                    ersg.AverageHoursPerDayValueSpecified = Util.isValidDecimal(dr["AVERAGEHOURSPERDAYVALUE"]);
                    if (ersg.AverageHoursPerDayValueSpecified)
                    {
                        ersg.AverageHoursPerDayValue = Util.ToDecimal(dr["AVERAGEHOURSPERDAYVALUE"]);
                    }

                    //AverageHoursPerYearValue
                    ersg.AverageHoursPerYearValueSpecified = Util.isValidDecimal(dr["AverageHoursPerYearValue"]);
                    if (ersg.AverageHoursPerYearValueSpecified)
                    {
                        ersg.AverageHoursPerYearValue = Util.ToDecimal(dr["AverageHoursPerYearValue"]);
                    }

                    //AverageWeeksPerYearValue
                    ersg.AverageWeeksPerYearValueSpecified = Util.isValidDecimal(dr["AVERAGEDAILYPERWEEKVALUE"]);
                    if (ersg.AverageWeeksPerYearValueSpecified)
                    {
                        ersg.AverageWeeksPerYearValue = Util.ToDecimal(dr["AVERAGEDAILYPERWEEKVALUE"]);
                    }

                    //CountyStateFIPSCode
                    ersg.CountyStateFIPSCode = Util.ToStr(dr["CountyStateFIPSCode"]);

                    //EmissionProcessDescription
                    ersg.EmissionProcessDescription = Util.ToStr(dr["EmissionProcessDescription"]);

                    //EmissionProcessRecordTypeCode
                    ersg.EmissionProcessRecordTypeCode = Util.ToStr(dr["RECORDTYPECODE"]);

                    //EmissionUnitIdentifier
                    ersg.EmissionUnitIdentifier = Util.ToStr(dr["EmissionUnitIdentifier"]);

                    //FuelAshContentMeasure
                    ersg.FuelAshContentMeasureSpecified = Util.isValidDecimal(dr["FuelAshContentMeasure"]);
                    if (ersg.FuelAshContentMeasureSpecified)
                    {
                        ersg.FuelAshContentMeasure = Util.ToDecimal(dr["FuelAshContentMeasure"]);
                    }

                    //FuelHeatContentMeasure
                    ersg.FuelHeatContentMeasureSpecified = Util.isValidDecimal(dr["FULLHEATCONTENTMEASURE"]);
                    if (ersg.FuelHeatContentMeasureSpecified)
                    {
                        ersg.FuelHeatContentMeasure = Util.ToDecimal(dr["FULLHEATCONTENTMEASURE"]);
                    }

                    //FuelSulfurContentMeasure
                    ersg.FuelSulfurContentMeasureSpecified = Util.isValidDecimal(dr["FuelSulfurContentMeasure"]);
                    if (ersg.FuelSulfurContentMeasureSpecified)
                    {
                        ersg.FuelSulfurContentMeasure = Util.ToDecimal(dr["FuelSulfurContentMeasure"]);
                    }

                    //MACTCode
                    ersg.MACTCode = Util.ToStr(dr["MACTCode"]);

                    //MACTComplianceStatusCode
                    ersg.MACTComplianceStatusCode = Util.ToStr(dr["MACTComplianceStatusCode"]);

                    //ProcessIdentifier
                    ersg.ProcessIdentifier = Util.ToStr(dr["ProcessIdentifier"]);

                    //ReleasePointIdentifier
                    ersg.ReleasePointIdentifier = Util.ToStr(dr["ReleasePointIdentifier"]);

                    //SourceCategoryCode
                    ersg.SourceCategoryCode = Util.ToStr(dr["SourceCategoryCode"]);

                    //StateFacilityIdentifier
                    ersg.StateFacilityIdentifier = Util.ToStr(dr["StateFacilityIdentifier"]);



                    //TransactionSubmittalCode
                    ersg.TransactionSubmittalCode = Util.ToStr(dr["TransactionSubmittalCode"]);

                    //ThroughputFallPercent
                    ersg.ThroughputFallPercentSpecified = Util.isValidDecimal(dr["ThroughputFallPercent"]);
                    if (ersg.ThroughputFallPercentSpecified)
                    {
                        ersg.ThroughputFallPercent = Util.ToDecimal(dr["ThroughputFallPercent"]);
                    }

                    //ThroughputSpringPercent
                    ersg.ThroughputSpringPercentSpecified = Util.isValidDecimal(dr["ThroughputSpringPercent"]);
                    if (ersg.ThroughputSpringPercentSpecified)
                    {
                        ersg.ThroughputSpringPercent = Util.ToDecimal(dr["ThroughputSpringPercent"]);
                    }

                    //ThroughputSummerPercent
                    ersg.ThroughputSummerPercentSpecified = Util.isValidDecimal(dr["ThroughputSummerPercent"]);
                    if (ersg.ThroughputSummerPercentSpecified)
                    {
                        ersg.ThroughputSummerPercent = Util.ToDecimal(dr["ThroughputSummerPercent"]);
                    }

                    //ThroughputWinterPercent
                    ersg.ThroughputWinterPercentSpecified = Util.isValidDecimal(dr["ThroughputWinterPercent"]);
                    if (ersg.ThroughputWinterPercentSpecified)
                    {
                        ersg.ThroughputWinterPercent = Util.ToDecimal(dr["ThroughputWinterPercent"]);
                    }

                    //TransactionSubmittalCode
                    ersg.TransactionSubmittalCode = Util.ToStr(dr["TransactionSubmittalCode"]);

                    //TribalCode
                    ersg.TribalCode = Util.ToStr(dr["TribalCode"]);

                    //Add element to the array
                    ar.Add(ersg);

                }
                point.EmissionProcessSubmissionGroup = ar.ToArray();
            }




            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //EmissionReleasePointSubmission
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //Get data from db
            dt = Data.GetDataTable(baseDao, Data.Tables.EmissionReleasePointSubmission, inventoryYear);

            //Check if there is any data
            if (dt != null)
            {

                List<EmissionReleasePointSubmissionGroupType> ar = new List<EmissionReleasePointSubmissionGroupType>();
                //Loop
                foreach (DataRow dr in dt.Rows)
                {

                    //Dim the array
                    EmissionReleasePointSubmissionGroupType elsg = new EmissionReleasePointSubmissionGroupType();

                    //CoordinateDataSourceCode
                    elsg.CoordinateDataSourceCode = Util.ToStr(dr["CoordinateDataSourceCode"]);

                    //CountyStateFIPSCode
                    elsg.CountyStateFIPSCode = Util.ToStr(dr["CountyStateFIPSCode"]);

                    //EmissionReleasePointRecordTypeCode
                    elsg.EmissionReleasePointRecordTypeCode = Util.ToStr(dr["RecordTypeCode"]);

                    //ExitGasFlowRate
                    elsg.ExitGasFlowRateSpecified = Util.isValidDecimal(dr["ExitGasFlowRate"]);
                    if (elsg.ExitGasFlowRateSpecified)
                    {
                        elsg.ExitGasFlowRate = Util.ToDecimal(dr["ExitGasFlowRate"]);
                    }

                    //ExitGasStreamVelocityRate
                    elsg.ExitGasStreamVelocityRateSpecified = Util.isValidDecimal(dr["EXITGASSTREAMVELOCITYVALUE"]);
                    if (elsg.ExitGasStreamVelocityRateSpecified)
                    {
                        elsg.ExitGasStreamVelocityRate = Util.ToDecimal(dr["EXITGASSTREAMVELOCITYVALUE"]);
                    }

                    //ExitGasTemperatureValue
                    elsg.ExitGasTemperatureValueSpecified = Util.isValidDecimal(dr["ExitGasTemperatureValue"]);
                    if (elsg.ExitGasTemperatureValueSpecified)
                    {
                        elsg.ExitGasTemperatureValue = Util.ToDecimal(dr["ExitGasTemperatureValue"]);
                    }

                    //FugitiveHorizontalAreaValue
                    elsg.FugitiveHorizontalAreaValueSpecified = Util.isValidDecimal(dr["FugitiveHorizontalAreaValue"]);
                    if (elsg.FugitiveHorizontalAreaValueSpecified)
                    {
                        elsg.FugitiveHorizontalAreaValue = Util.ToDecimal(dr["FugitiveHorizontalAreaValue"]);
                    }

                    //FugitiveReleaseHeightValue
                    elsg.FugitiveReleaseHeightValueSpecified = Util.isValidDecimal(dr["FugitiveReleaseHeightValue"]);
                    if (elsg.FugitiveReleaseHeightValueSpecified)
                    {
                        elsg.FugitiveReleaseHeightValue = Util.ToDecimal(dr["FugitiveReleaseHeightValue"]);
                    }


                    //FugitiveUnitOfMeasureCode
                    elsg.FugitiveUnitOfMeasureCode = Util.ToStr(dr["FugitiveUnitOfMeasureCode"]);

                    //HorizontalAccuracyMeasure
                    elsg.HorizontalAccuracyMeasure = Util.ToStr(dr["HorizontalAccuracyMeasure"]);

                    //HorizontalCollectionMethodCode
                    elsg.HorizontalCollectionMethodCode = Util.ToStr(dr["HorizontalCollectionMethodCode"]);

                    //HorizontalReferenceDatumCode
                    elsg.HorizontalReferenceDatumCode = Util.ToStr(dr["HorizontalReferenceDatumCode"]);

                    //LatitudeMeasure
                    elsg.LatitudeMeasureSpecified = Util.isValidDecimal(dr["LatitudeMeasure"]);
                    if (elsg.LatitudeMeasureSpecified)
                    {
                        elsg.LatitudeMeasure = Util.ToDecimal(dr["LatitudeMeasure"], 10);
                    }

                    //LongitudeMeasure
                    elsg.LongitudeMeasureSpecified = Util.isValidDecimal(dr["LongitudeMeasure"]);
                    if (elsg.LongitudeMeasureSpecified)
                    {
                        elsg.LongitudeMeasure = Util.ToDecimal(dr["LongitudeMeasure"], 11);
                    }

                    //ReferencePointCode
                    elsg.ReferencePointCode = Util.ToStr(dr["ReferencePointCode"]);

                    //ReleasePointDescription
                    elsg.ReleasePointDescription = Util.ToStr(dr["ReleasePointDescription"]);

                    //ReleasePointIdentifier
                    elsg.ReleasePointIdentifier = Util.ToStr(dr["ReleasePointIdentifier"]);

                    //ReleasePointTypeCode
                    elsg.ReleasePointTypeCode = Util.ToStr(dr["RELEASEPOINTTYPECODE"]);

                    //SourceMapScaleNumber
                    elsg.SourceMapScaleNumber = Util.ToStr(dr["SourceMapScaleNumber"]);

                    //StackDiameterValue
                    elsg.StackDiameterValueSpecified = Util.isValidDecimal(dr["StackDiameterValue"]);
                    if (elsg.StackDiameterValueSpecified)
                    {
                        elsg.StackDiameterValue = Util.ToDecimal(dr["StackDiameterValue"]);
                    }

                    //StackFencelineDistanceValue
                    elsg.StackFencelineDistanceValueSpecified = Util.isValidDecimal(dr["StackFencelineDistanceValue"]);
                    if (elsg.StackFencelineDistanceValueSpecified)
                    {
                        elsg.StackFencelineDistanceValue = Util.ToDecimal(dr["StackFencelineDistanceValue"]);
                    }

                    //StackHeightValue
                    elsg.StackHeightValueSpecified = Util.isValidDecimal(dr["StackHeightValue"]);
                    if (elsg.StackHeightValueSpecified)
                    {
                        elsg.StackHeightValue = Util.ToDecimal(dr["StackHeightValue"]);
                    }

                    //StateFacilityIdentifier
                    elsg.StateFacilityIdentifier = Util.ToStr(dr["StateFacilityIdentifier"]);

                    //TransactionSubmittalCode
                    elsg.TransactionSubmittalCode = Util.ToStr(dr["TransactionSubmittalCode"]);

                    //TribalCode
                    elsg.TribalCode = Util.ToStr(dr["TribalCode"]);

                    //UTMZoneCode
                    elsg.UTMZoneCode = Util.ToStr(dr["UTMZoneCode"]);

                    //XYCoordinateTypeCode
                    elsg.XYCoordinateTypeCode = Util.ToStr(dr["XYCoordinateTypeCode"]);

                    //Add element to the array
                    ar.Add(elsg);

                }
                point.EmissionReleasePointSubmissionGroup = ar.ToArray();
            }




            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //EmissionSubmissionGroup
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //Get data from db
            dt = Data.GetDataTable(baseDao, Data.Tables.EmissionSubmissionGroup, inventoryYear);

            //Check if there is any data
            if (dt != null)
            {

                List<EmissionSubmissionGroupType> ar = new List<EmissionSubmissionGroupType>();
                //Loop
                foreach (DataRow dr in dt.Rows)
                {

                    //Dim the array
                    EmissionSubmissionGroupType essg = new EmissionSubmissionGroupType();

                    //ControlStatusCode
                    essg.ControlStatusCode = Util.ToStr(dr["ControlStatusCode"]);

                    //CountyStateFIPSCode
                    essg.CountyStateFIPSCode = Util.ToStr(dr["CountyStateFIPSCode"]);

                    //EmissionCalculationMethodCode
                    essg.EmissionCalculationMethodCode = Util.ToStr(dr["EmissionCalculationMethodCode"]);

                    //EmissionDataLevelIdentifier
                    essg.EmissionDataLevelIdentifier = Util.ToStr(dr["EmissionDataLevelIdentifier"]);

                    //EmissionFactorReliabilityIndicator
                    essg.EmissionFactorReliabilityIndicator = Util.ToStr(dr["EMISSIONFACTORRELIABILITY"]);

                    //EmissionFactorValue
                    essg.EmissionFactorValueSpecified = Util.isValidDecimal(dr["EmissionFactorValue"]);
                    if (essg.EmissionFactorValueSpecified)
                    {
                        essg.EmissionFactorValue = Util.ToDecimal(dr["EmissionFactorValue"], 10);
                    }

                    //EmissionPeriodEndDate
                    essg.EmissionPeriodEndDate = Util.ToStr(dr["EmissionPeriodEndDate"]);

                    //EmissionPeriodEndTime
                    essg.EmissionPeriodEndTime = Util.ToStr(dr["EmissionPeriodEndTime"]);

                    //EmissionPeriodStartDate
                    essg.EmissionPeriodStartDate = Util.ToStr(dr["EmissionPeriodStartDate"]);

                    //EmissionPeriodStartTime
                    essg.EmissionPeriodStartTime = Util.ToStr(dr["EmissionPeriodStartTime"]);

                    //EmissionRecordTypeCode
                    essg.EmissionRecordTypeCode = Util.ToStr(dr["RECORDTYPECODE"]);

                    //ReliabilityIndicator
                    essg.ReliabilityIndicatorSpecified = Util.isValidDecimal(dr["ReliabilityIndicator"]);
                    if (essg.ReliabilityIndicatorSpecified)
                    {
                        essg.ReliabilityIndicator = Util.ToDecimal(dr["ReliabilityIndicator"]);
                    }

                    //RuleEffectivenessMeasure
                    essg.RuleEffectivenessMeasureSpecified = Util.isValidDecimal(dr["RuleEffectivenessMeasure"]);
                    if (essg.RuleEffectivenessMeasureSpecified)
                    {
                        essg.RuleEffectivenessMeasure = Util.ToDecimal(dr["RuleEffectivenessMeasure"]);
                    }

                    //StateFacilityIdentifier
                    essg.StateFacilityIdentifier = Util.ToStr(dr["StateFacilityIdentifier"]);

                    //TransactionSubmittalCode
                    essg.TransactionSubmittalCode = Util.ToStr(dr["TransactionSubmittalCode"]);

                    //TribalCode
                    essg.TribalCode = Util.ToStr(dr["TribalCode"]);

                    //EmissionUnitIdentifier
                    essg.EmissionUnitIdentifier = Util.ToStr(dr["EMISSIONUNITIDENTIFIER"]);

                    //ProcessIdentifier
                    essg.ProcessIdentifier = Util.ToStr(dr["PROCESSIDENTIFIER"]);

                    //PollutantCode
                    essg.PollutantCode = Util.ToStr(dr["POLLUTANTCODE"]);

                    //EmissionUnitNumeratorValue
                    essg.EmissionUnitNumeratorValue = Util.ToStr(dr["EMISSIONUNITNUMERATORVALUE"]);

                    //EmissionTypeCode
                    essg.EmissionTypeCode = Util.ToStr(dr["EMISSIONTYPECODE"]);

                    //FactorUnitNumeratorValue
                    if (essg.EmissionFactorValueSpecified)
                    {
                        essg.FactorUnitNumeratorValue = Util.ToStr(dr["EMISSIONUNITNUMERATORVALUE"]);
                    }

                    essg.HAPEmissionsPerformanceLevelCode = Util.ToStr(dr["HAPEMISSIONSPERFORMANCELEVEL"]);

                    //Add element to the array
                    ar.Add(essg);

                }
                point.EmissionSubmissionGroup = ar.ToArray();
            }




            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //EmissionUnitSubmissionGroup
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //Get data from db
            dt = Data.GetDataTable(baseDao, Data.Tables.EmissionUnitSubmissionGroup, inventoryYear);

            //Check if there is any data
            if (dt != null)
            {

                List<EmissionUnitSubmissionGroupType> ar = new List<EmissionUnitSubmissionGroupType>();
                //Loop
                foreach (DataRow dr in dt.Rows)
                {

                    //Dim the array
                    EmissionUnitSubmissionGroupType eusg = new EmissionUnitSubmissionGroupType();

                    //CountyStateFIPSCode
                    eusg.CountyStateFIPSCode = Util.ToStr(dr["CountyStateFIPSCode"]);

                    //DesignCapacityMaximumNameplateValue
                    eusg.DesignCapacityMaximumNameplateValueSpecified = Util.isValidDecimal(dr["DESIGNCAPACITYMAXIMUM"]);
                    if (eusg.DesignCapacityMaximumNameplateValueSpecified)
                    {
                        eusg.DesignCapacityMaximumNameplateValue = Util.ToDecimal(dr["DESIGNCAPACITYMAXIMUM"]);
                    }

                    //DesignCapacityMeasure
                    eusg.DesignCapacityMeasureSpecified = Util.isValidDecimal(dr["DesignCapacityMeasure"]);
                    if (eusg.DesignCapacityMeasureSpecified)
                    {
                        eusg.DesignCapacityMeasure = Util.ToDecimal(dr["DesignCapacityMeasure"]);
                    }

                    //EmissionUnitDescription
                    eusg.EmissionUnitDescription = Util.ToStr(dr["EmissionUnitDescription"]);

                    //EmissionUnitIdentifier
                    eusg.EmissionUnitIdentifier = Util.ToStr(dr["EmissionUnitIdentifier"]);

                    //EmissionUnitRecordTypeCode
                    eusg.EmissionUnitRecordTypeCode = Util.ToStr(dr["RecordTypeCode"]);

                    //NAICSCode
                    eusg.NAICSCode = Util.ToStr(dr["NAICSCode"]);

                    //ORISBoilerIdentifier
                    eusg.ORISBoilerIdentifier = Util.ToStr(dr["ORISBoilerIdentifier"]);

                    //SICCode
                    eusg.SICCode = Util.ToStr(dr["SICCode"]);

                    //StateFacilityIdentifier
                    eusg.StateFacilityIdentifier = Util.ToStr(dr["StateFacilityIdentifier"]);

                    //TransactionSubmittalCode
                    eusg.TransactionSubmittalCode = Util.ToStr(dr["TransactionSubmittalCode"]);

                    //TribalCode
                    eusg.TribalCode = Util.ToStr(dr["TribalCode"]);

                    //UnitDenominatorValue
                    eusg.UnitDenominatorValue = Util.ToStr(dr["UnitDenominatorValue"]);

                    //UnitNumeratorValue
                    eusg.UnitNumeratorValue = Util.ToStr(dr["UnitNumeratorValue"]);

                    //Add element to the array
                    ar.Add(eusg);

                }
                point.EmissionUnitSubmissionGroup = ar.ToArray();
            }




            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //SiteSubmissionGroup
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //Get data from db
            dt = Data.GetDataTable(baseDao, Data.Tables.SiteSubmissionGroup, inventoryYear);

            //Check if there is any data
            if (dt != null)
            {

                List<SiteSubmissionGroupType> ar = new List<SiteSubmissionGroupType>();
                //Loop
                foreach (DataRow dr in dt.Rows)
                {

                    //Dim the array
                    SiteSubmissionGroupType ebsg = new SiteSubmissionGroupType();

                    //CountryName
                    ebsg.CountryName = Util.ToStr(dr["CountryName"]);

                    //CountyStateFIPSCode
                    ebsg.CountyStateFIPSCode = Util.ToStr(dr["CountyStateFIPSCode"]);

                    //FacilityCategoryCode
                    ebsg.FacilityCategoryCode = Util.ToStr(dr["FacilityCategoryCode"]);

                    //FacilityDescription
                    ebsg.FacilityDescription = Util.ToStr(dr["FacilityDescription"]);

                    //FacilityNTIIdentifier
                    ebsg.FacilityNTIIdentifier = Util.ToStr(dr["FacilityNTIIdentifier"]);

                    //FacilityRegistryIdentifier
                    ebsg.FacilityRegistryIdentifier = Util.ToStr(dr["FacilityRegistryIdentifier"]);

                    //FacilitySiteName
                    ebsg.FacilitySiteName = Util.ToStr(dr["FacilitySiteName"]);

                    //FacilityTRIIdentifier
                    ebsg.FacilityTRIIdentifier = Util.ToStr(dr["FacilityTRIIdentifier"]);

                    //LocalityName
                    ebsg.LocalityName = Util.ToStr(dr["LocalityName"]);

                    //LocationAddressStateAbbrev
                    ebsg.LocationAddressStateAbbrev = Util.ToStr(dr["LOCATIONSTATECODE"]);

                    //LocationAddressText
                    ebsg.LocationAddressText = Util.ToStr(dr["LocationAddressText"]);

                    //LocationZipCode
                    ebsg.LocationZipCode = Util.ToStr(dr["LocationZipCode"]);

                    //NAICSCode
                    ebsg.NAICSCode = Util.ToStr(dr["NAICS_Code"]);

                    //OrganizationDUNSNumber
                    ebsg.OrganizationDUNSNumber = Util.ToStr(dr["OrganizationDUNSNumber"]);

                    //ORISFacilityCode
                    ebsg.ORISFacilityCode = Util.ToStr(dr["ORISFacilityCode"]);

                    //SICCode
                    ebsg.SICCode = Util.ToStr(dr["SICCode"]);

                    //SiteRecordTypeCode
                    ebsg.SiteRecordTypeCode = Util.ToStr(dr["RECORDTYPECODE"]);

                    //StateFacilityIdentifier
                    ebsg.StateFacilityIdentifier = Util.ToStr(dr["StateFacilityIdentifier"]);

                    //TransactionSubmittalCode
                    ebsg.TransactionSubmittalCode = "A";
                    //Util.ToStr(dr["TransactionSubmittalCode"))

                    //TribalCode
                    ebsg.TribalCode = Util.ToStr(dr["TribalCode"]);

                    //Add element to the array
                    ar.Add(ebsg);


                }
                point.SiteSubmissionGroup = ar.ToArray();
            }





            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //TransmittalSubmissionGroup
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //Get data from db
            dt = Data.GetDataTable(baseDao, Data.Tables.TransmittalSubmissionGroup, inventoryYear);

            //Check if there is any data
            if (dt != null)
            {

                List<TransmittalSubmissionGroupType> ar = new List<TransmittalSubmissionGroupType>();
                //Loop
                foreach (DataRow dr in dt.Rows)
                {

                    //Dim the array
                    TransmittalSubmissionGroupType tssg = new TransmittalSubmissionGroupType();

                    //AffiliationTypeText
                    tssg.AffiliationTypeText = Util.ToStr(dr["AffiliationTypeText"]);

                    //CountyStateFIPSCode
                    tssg.CountyStateFIPSCode = Util.ToStr(dr["CountyStateFIPSCode"]);

                    //ElectronicAddressText
                    tssg.ElectronicAddressText = Util.ToStr(dr["ElectronicAddressText"]);

                    //ElectronicAddressTypeName
                    tssg.ElectronicAddressTypeName = Util.ToStr(dr["ElectronicAddressTypeName"]);

                    //FormatVersionNumber
                    tssg.FormatVersionNumber = Util.ToDecimal(dr["FormatVersionNumber"]);

                    //IndividualFullName
                    tssg.IndividualFullName = Util.ToStr(dr["IndividualFullName"]);

                    //InventoryTypeCode
                    tssg.InventoryTypeCode = Util.ToStr(dr["InventoryTypeCode"]);

                    //InventoryYear
                    tssg.InventoryYear = inventoryYear.ToString();

                    //OrganizationFormalName
                    tssg.OrganizationFormalName = Util.ToStr(dr["OrganizationFormalName"]);

                    //ReliabilityIndicator
                    tssg.ReliabilityIndicatorSpecified = Util.isValidDecimal(dr["RELIABILITYINDICATOR"]);
                    if (tssg.ReliabilityIndicatorSpecified)
                    {
                        tssg.ReliabilityIndicator = Util.ToDecimal(dr["RELIABILITYINDICATOR"]);
                    }

                    //SourceTypeCode
                    tssg.SourceTypeCode = Util.ToStr(dr["SourceTypeCode"]);

                    //SubmissionNumber
                    tssg.SubmissionNumberSpecified = Util.isValidDecimal(dr["SubmissionNumber"]);
                    if (tssg.ReliabilityIndicatorSpecified)
                    {
                        tssg.SubmissionNumber = Util.ToDecimal(dr["SubmissionNumber"]);
                    }

                    //TelephoneNumber
                    tssg.TelephoneNumber = Util.ToStr(dr["TelephoneNumber"]);

                    //TelephoneNumberTypeName
                    tssg.TelephoneNumberTypeName = Util.ToStr(dr["TELEHPHONENUMBERTYPENAME"]);

                    //TransactionComment
                    tssg.TransactionComment = Util.ToStr(dr["TRANSACTIONCOMMENT"]);

                    //TransactionCreationDate
                    tssg.TransactionCreationDate = DateTime.Today.ToString("yyyyMMdd");

                    //TransactionTypeCode
                    tssg.TransactionTypeCode = tranactionTypeCode;

                    //TransmittalRecordTypeCode
                    tssg.TransmittalRecordTypeCode = Util.ToStr(dr["RECORDTYPECODE"]);


                    //TribalCode
                    tssg.TribalCode = Util.ToStr(dr["TribalCode"]);

                    //Add element to the array
                    ar.Add(tssg);


                }
                point.TransmittalSubmissionGroup = ar.ToArray();
            }



            if ( CollectionUtils.IsNullOrEmpty(point.ControlEquipmentSubmissionGroup) && 
                 CollectionUtils.IsNullOrEmpty(point.EmissionPeriodSubmissionGroup) && 
                 CollectionUtils.IsNullOrEmpty(point.EmissionProcessSubmissionGroup) && 
                 CollectionUtils.IsNullOrEmpty(point.EmissionReleasePointSubmissionGroup) && 
                 CollectionUtils.IsNullOrEmpty(point.EmissionUnitSubmissionGroup) && 
                 CollectionUtils.IsNullOrEmpty(point.EmissionSubmissionGroup) && 
                 CollectionUtils.IsNullOrEmpty(point.SiteSubmissionGroup) && 
                 CollectionUtils.IsNullOrEmpty(point.TransmittalSubmissionGroup))
            {

                throw new ApplicationException(string.Format("No data found for the provided parameters. (Year: {0} TransactionTypeCode: {1})", inventoryYear, tranactionTypeCode));


            }

            //Control file
            point.SystemRecordCountValues = new SystemRecordCountValuesType();

            if ((point.ControlEquipmentSubmissionGroup != null))
            {
                //SystemRecordCountControlEquipmentValue
                point.SystemRecordCountValues.SystemRecordCountControlEquipmentValue = Util.ToDecimal(point.ControlEquipmentSubmissionGroup.Length);
                appendAuditLogEvent.AppendAuditLogEvent("Found {0} ControlEquipmentSubmissionGroup(s)", point.ControlEquipmentSubmissionGroup.Length.ToString());
            }

            if ((point.EmissionPeriodSubmissionGroup != null))
            {
                //SystemRecordCountEmissionPeriodValue
                point.SystemRecordCountValues.SystemRecordCountEmissionPeriodValue = Util.ToDecimal(point.EmissionPeriodSubmissionGroup.Length);
                appendAuditLogEvent.AppendAuditLogEvent("Found {0} EmissionPeriodSubmissionGroup(s)", point.EmissionPeriodSubmissionGroup.Length.ToString());
            }

            if ((point.EmissionProcessSubmissionGroup != null))
            {
                //SystemRecordCountEmissionProcessValue
                point.SystemRecordCountValues.SystemRecordCountEmissionProcessValue = Util.ToDecimal(point.EmissionProcessSubmissionGroup.Length);
                appendAuditLogEvent.AppendAuditLogEvent("Found {0} EmissionProcessSubmissionGroup(s)", point.EmissionProcessSubmissionGroup.Length.ToString());
            }

            if ((point.EmissionReleasePointSubmissionGroup != null))
            {
                //SystemRecordCountEmissionReleasePointValue
                point.SystemRecordCountValues.SystemRecordCountEmissionReleasePointValue = Util.ToDecimal(point.EmissionReleasePointSubmissionGroup.Length);
                appendAuditLogEvent.AppendAuditLogEvent("Found {0} EmissionReleasePointSubmissionGroup(s)", point.EmissionReleasePointSubmissionGroup.Length.ToString());
            }

            if ((point.EmissionUnitSubmissionGroup != null))
            {
                //SystemRecordCountEmissionUnitValue
                point.SystemRecordCountValues.SystemRecordCountEmissionUnitValue = Util.ToDecimal(point.EmissionUnitSubmissionGroup.Length);
                appendAuditLogEvent.AppendAuditLogEvent("Found {0} EmissionUnitSubmissionGroup(s)", point.EmissionUnitSubmissionGroup.Length.ToString());
            }

            if ((point.EmissionSubmissionGroup != null))
            {
                //SystemRecordCountEmissionValue
                point.SystemRecordCountValues.SystemRecordCountEmissionValue = Util.ToDecimal(point.EmissionSubmissionGroup.Length);
                appendAuditLogEvent.AppendAuditLogEvent("Found {0} EmissionSubmissionGroup(s)", point.EmissionSubmissionGroup.Length.ToString());
            }

            if ((point.SiteSubmissionGroup != null))
            {
                //SystemRecordCountSiteValue
                point.SystemRecordCountValues.SystemRecordCountSiteValue = Util.ToDecimal(point.SiteSubmissionGroup.Length);
                appendAuditLogEvent.AppendAuditLogEvent("Found {0} SiteSubmissionGroup(s)", point.SiteSubmissionGroup.Length.ToString());
            }

            if ((point.TransmittalSubmissionGroup != null))
            {
                //SystemRecordCountTransmittalValue
                point.SystemRecordCountValues.SystemRecordCountTransmittalValue = Util.ToDecimal(point.TransmittalSubmissionGroup.Length);
                appendAuditLogEvent.AppendAuditLogEvent("Found {0} TransmittalSubmissionGroup(s)", point.TransmittalSubmissionGroup.Length.ToString());
            }

            //return populated point
            return point;
        }

    }
}
