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

/*
 * Created on Aug 20, 2004
 *
 */
package com.windsor.node.plugin.nei;

import java.io.BufferedOutputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.SimpleDateFormat;

import javax.sql.DataSource;

import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;
import org.springframework.jdbc.core.support.JdbcDaoSupport;

import com.windsor.node.common.domain.DataRequest;
import com.windsor.node.plugin.nei.identities.ControlEquipmentSubmissionGroup;
import com.windsor.node.plugin.nei.identities.EmissionPeriodSubmissionGroup;
import com.windsor.node.plugin.nei.identities.EmissionProcessSubmissionGroup;
import com.windsor.node.plugin.nei.identities.EmissionReleasePointSubmissionGroup;
import com.windsor.node.plugin.nei.identities.EmissionSubmissionGroup;
import com.windsor.node.plugin.nei.identities.EmissionUnitSubmissionGroup;
import com.windsor.node.plugin.nei.identities.SiteSubmissionGroup;
import com.windsor.node.plugin.nei.identities.SystemRecordCountValues;
import com.windsor.node.plugin.nei.identities.TransmittalSubmissionGroup;

/**
 * NOTE: This class has been upgraded from the legacy Node No effort has been
 * taken to obtimize this class do to it anticipated short lifespan (4 more runs
 * kevin J tells me)
 * 
 * @author mchmarny
 * 
 */
public class Data extends JdbcDaoSupport {

    public final Logger logger = Logger.getLogger(getClass());

    private OutputStreamWriter out = null;

    private boolean replace = false;
    private String submittalCode = null;

    public static class NEI {
        public static class TRANSMITTAL_SUB_GRP {
            // TransmittalSubmissionGroup
            public static final String SQL = "SELECT RECORDTYPECODE, COUNTYSTATEFIPSCODE, ORGANIZATIONFORMALNAME, "
                    + "TRANSACTIONTYPECODE, INVENTORYYEAR, INVENTORYTYPECODE, "
                    + "TRANSACTIONCREATIONDATE, SUBMISSIONNUMBER, RELIABILITYINDICATOR, "
                    + "TRANSACTIONCOMMENT, INDIVIDUALFULLNAME, TELEPHONENUMBER,  "
                    + "TELEHPHONENUMBERTYPENAME, ELECTRONICADDRESSTEXT, ELECTRONICADDRESSTYPENAME,  "
                    + "SOURCETYPECODE, AFFILIATIONTYPETEXT, FORMATVERSIONNUMBER, TRIBALCODE "
                    + "FROM NEI_TRANSMITTAL WHERE INVENTORY_YEAR = ?";

            public static final int RECORDTYPECODE = 1;
            public static final int COUNTYSTATEFIPSCODE = 2;
            public static final int ORGANIZATIONFORMALNAME = 3;
            public static final int TRANSACTIONTYPECODE = 4;
            public static final int INVENTORYYEAR = 5;
            public static final int INVENTORYTYPECODE = 6;
            public static final int TRANSACTIONCREATIONDATE = 7;
            public static final int SUBMISSIONNUMBER = 8;
            public static final int RELIABILITYINDICATOR = 9;
            public static final int TRANSACTIONCOMMENT = 10;
            public static final int INDIVIDUALFULLNAME = 11;
            public static final int TELEPHONENUMBER = 12;
            public static final int TELEHPHONENUMBERTYPENAME = 13;
            public static final int ELECTRONICADDRESSTEXT = 14;
            public static final int ELECTRONICADDRESSTYPENAME = 15;
            public static final int SOURCETYPECODE = 16;
            public static final int AFFILIATIONTYPETEXT = 17;
            public static final int FORMATVERSIONNUMBER = 18;
            public static final int TRIBALCODE = 19;

        }

        public static class SITE_SUB_GRP {
            // SiteSubmissionGroup
            public static final String SQL = "SELECT SI_ID, INVENTORY_YEAR, RECORDTYPECODE,  "
                    + "COUNTYSTATEFIPSCODE, STATEFACILITYIDENTIFIER, FACILITYREGISTRYIDENTIFIER,  "
                    + "FACILITYCATEGORYCODE, ORISFACILITYCODE, SICCODE,  "
                    + "NAICS_CODE, FACILITYSITENAME, FACILITYDESCRIPTION,  "
                    + "LOCATIONADDRESSTEXT, LOCALITYNAME, LOCATIONSTATECODE,  "
                    + "LOCATIONZIPCODE, COUNTRYNAME, FACILITYNTIIDENTIFIER,  "
                    + "ORGANIZATIONDUNSNUMBER, FACILITYTRIIDENTIFIER, TRANSACTIONSUBMITTALCODE,  "
                    + "TRIBALCODE FROM NEI_SITE  WHERE INVENTORY_YEAR = ? ";

            public static final int SI_ID = 1;
            public static final int INVENTORY_YEAR = 2;
            public static final int RECORDTYPECODE = 3;
            public static final int COUNTYSTATEFIPSCODE = 4;
            public static final int STATEFACILITYIDENTIFIER = 5;
            public static final int FACILITYREGISTRYIDENTIFIER = 6;
            public static final int FACILITYCATEGORYCODE = 7;
            public static final int ORISFACILITYCODE = 8;
            public static final int SICCODE = 9;
            public static final int NAICS_CODE = 10;
            public static final int FACILITYSITENAME = 11;
            public static final int FACILITYDESCRIPTION = 12;
            public static final int LOCATIONADDRESSTEXT = 13;
            public static final int LOCALITYNAME = 14;
            public static final int LOCATIONSTATECODE = 15;
            public static final int LOCATIONZIPCODE = 16;
            public static final int COUNTRYNAME = 17;
            public static final int FACILITYNTIIDENTIFIER = 18;
            public static final int ORGANIZATIONDUNSNUMBER = 19;
            public static final int FACILITYTRIIDENTIFIER = 20;
            public static final int TRANSACTIONSUBMITTALCODE = 21;
            public static final int TRIBALCODE = 22;

        }

        public static class EMISSION_UNIT_SUB_GRP {
            // EmissionUnitSubmissionGroup
            public static final String SQL = "SELECT EU_ID, SI_ID, RECORDTYPECODE,   "
                    + "COUNTYSTATEFIPSCODE, STATEFACILITYIDENTIFIER, EMISSIONUNITIDENTIFIER,   "
                    + "ORISBOILERIDENTIFIER, SICCODE, NAICSCODE,   "
                    + "DESIGNCAPACITYMEASURE, UNITNUMERATORVALUE, UNITDENOMINATORVALUE,   "
                    + "DESIGNCAPACITYMAXIMUM, EMISSIONUNITDESCRIPTION, TRANSACTIONSUBMITTALCODE,   "
                    + "TRIBALCODE FROM NEI_EMISSIONUNIT WHERE INVENTORY_YEAR = ?  ";

            public static final int EU_ID = 1;
            public static final int SI_ID = 2;
            public static final int RECORDTYPECODE = 3;
            public static final int COUNTYSTATEFIPSCODE = 4;
            public static final int STATEFACILITYIDENTIFIER = 5;
            public static final int EMISSIONUNITIDENTIFIER = 6;
            public static final int ORISBOILERIDENTIFIER = 7;
            public static final int SICCODE = 8;
            public static final int NAICSCODE = 9;
            public static final int DESIGNCAPACITYMEASURE = 10;
            public static final int UNITNUMERATORVALUE = 11;
            public static final int UNITDENOMINATORVALUE = 12;
            public static final int DESIGNCAPACITYMAXIMUM = 13;
            public static final int EMISSIONUNITDESCRIPTION = 14;
            public static final int TRANSACTIONSUBMITTALCODE = 15;
            public static final int TRIBALCODE = 16;
        }

        public static class EMISSION_RELEASE_POINT {
            // EmissionReleasePointSubmission
            public static final String SQL = "SELECT ER_ID, SI_ID, RECORDTYPECODE,   "
                    + "COUNTYSTATEFIPSCODE, STATEFACILITYIDENTIFIER, RELEASEPOINTIDENTIFIER,   "
                    + "RELEASEPOINTTYPECODE, STACKHEIGHTVALUE, STACKDIAMETERVALUE,   "
                    + "STACKFENCELINEDISTANCEVALUE, EXITGASTEMPERATUREVALUE, EXITGASSTREAMVELOCITYVALUE,   "
                    + "EXITGASFLOWRATE, LONGITUDEMEASURE, LATITUDEMEASURE,   "
                    + "UTMZONECODE, XYCOORDINATETYPECODE, FUGITIVEHORIZONTALAREAVALUE,   "
                    + "FUGITIVERELEASEHEIGHTVALUE, FUGITIVEUNITOFMEASURECODE, RELEASEPOINTDESCRIPTION,   "
                    + "TRANSACTIONSUBMITTALCODE, HORIZONTALCOLLECTIONMETHODCODE, HORIZONTALACCURACYMEASURE,   "
                    + "HORIZONTALREFERENCEDATUMCODE, REFERENCEPOINTCODE, SOURCEMAPSCALENUMBER,   "
                    + "COORDINATEDATASOURCECODE, TRIBALCODE FROM NEI_EMISSIONRELEASEPOINT   WHERE INVENTORY_YEAR = ?  ";

            public static final int ER_ID = 1;
            public static final int SI_ID = 2;
            public static final int RECORDTYPECODE = 3;
            public static final int COUNTYSTATEFIPSCODE = 4;
            public static final int STATEFACILITYIDENTIFIER = 5;
            public static final int RELEASEPOINTIDENTIFIER = 6;
            public static final int RELEASEPOINTTYPECODE = 7;
            public static final int STACKHEIGHTVALUE = 8;
            public static final int STACKDIAMETERVALUE = 9;
            public static final int STACKFENCELINEDISTANCEVALUE = 10;
            public static final int EXITGASTEMPERATUREVALUE = 11;
            public static final int EXITGASSTREAMVELOCITYVALUE = 12;
            public static final int EXITGASFLOWRATE = 13;
            public static final int LONGITUDEMEASURE = 14;
            public static final int LATITUDEMEASURE = 15;
            public static final int UTMZONECODE = 16;
            public static final int XYCOORDINATETYPECODE = 17;
            public static final int FUGITIVEHORIZONTALAREAVALUE = 18;
            public static final int FUGITIVERELEASEHEIGHTVALUE = 19;
            public static final int FUGITIVEUNITOFMEASURECODE = 20;
            public static final int RELEASEPOINTDESCRIPTION = 21;
            public static final int TRANSACTIONSUBMITTALCODE = 22;
            public static final int HORIZONTALCOLLECTIONMETHODCODE = 23;
            public static final int HORIZONTALACCURACYMEASURE = 24;
            public static final int HORIZONTALREFERENCEDATUMCODE = 25;
            public static final int REFERENCEPOINTCODE = 26;
            public static final int SOURCEMAPSCALENUMBER = 27;
            public static final int COORDINATEDATASOURCECODE = 28;
            public static final int TRIBALCODE = 29;

        }

        public static class EMISSION_PROCESS {
            // EmissionProcessSubmission
            public static final String SQL = "SELECT EP_ID, EU_ID, SI_ID,   "
                    + "RECORDTYPECODE, COUNTYSTATEFIPSCODE, STATEFACILITYIDENTIFIER,   "
                    + "EMISSIONUNITIDENTIFIER, RELEASEPOINTIDENTIFIER, PROCESSIDENTIFIER,   "
                    + "SOURCECATEGORYCODE, MACTCODE, EMISSIONPROCESSDESCRIPTION,   "
                    + "THROUGHPUTWINTERPERCENT, THROUGHPUTSPRINGPERCENT, THROUGHPUTSUMMERPERCENT,   "
                    + "THROUGHPUTFALLPERCENT, AVERAGEDAILYPERWEEKVALUE, AVERAGEWEEKSPERYEARVALUE,   "
                    + "AVERAGEHOURSPERDAYVALUE, AVERAGEHOURSPERYEARVALUE, FULLHEATCONTENTMEASURE,   "
                    + "FUELSULFURCONTENTMEASURE, FUELASHCONTENTMEASURE, MACTCOMPLIANCESTATUSCODE,   "
                    + "TRANSACTIONSUBMITTALCODE, TRIBALCODE FROM NEI_EMISSIONPROCESS  WHERE INVENTORY_YEAR = ? ";

            public static final int EP_ID = 1;
            public static final int EU_ID = 2;
            public static final int SI_ID = 3;
            public static final int RECORDTYPECODE = 4;
            public static final int COUNTYSTATEFIPSCODE = 5;
            public static final int STATEFACILITYIDENTIFIER = 6;
            public static final int EMISSIONUNITIDENTIFIER = 7;
            public static final int RELEASEPOINTIDENTIFIER = 8;
            public static final int PROCESSIDENTIFIER = 9;
            public static final int SOURCECATEGORYCODE = 10;
            public static final int MACTCODE = 11;
            public static final int EMISSIONPROCESSDESCRIPTION = 12;
            public static final int THROUGHPUTWINTERPERCENT = 13;
            public static final int THROUGHPUTSPRINGPERCENT = 14;
            public static final int THROUGHPUTSUMMERPERCENT = 15;
            public static final int THROUGHPUTFALLPERCENT = 16;
            public static final int AVERAGEDAILYPERWEEKVALUE = 17;
            public static final int AVERAGEWEEKSPERYEARVALUE = 18;
            public static final int AVERAGEHOURSPERDAYVALUE = 19;
            public static final int AVERAGEHOURSPERYEARVALUE = 20;
            public static final int FULLHEATCONTENTMEASURE = 21;
            public static final int FUELSULFURCONTENTMEASURE = 22;
            public static final int FUELASHCONTENTMEASURE = 23;
            public static final int MACTCOMPLIANCESTATUSCODE = 24;
            public static final int TRANSACTIONSUBMITTALCODE = 25;
            public static final int TRIBALCODE = 26;
        }

        public static class EMISSION_PERIOD_SUB_GRP {
            // EmissionPeriodSubmissionGroup
            public static final String SQL = "SELECT EP_ID, EU_ID, SI_ID,  "
                    + "RECORDTYPECODE, COUNTYSTATEFIPSCODE, STATEFACILITYIDENTIFIER,   "
                    + "EMISSIONUNITIDENTIFIER, PROCESSIDENTIFIER, EMISSIONPERIODSTARTDATE,   "
                    + "EMISSIONPERIODENDDATE, EMISSIONPERIODSTARTTIME, EMISSIONPERIODENDTIME,   "
                    + "THROUGHPUTVALUE, UNITNUMERATORVALUE, MATERIALCODE,   "
                    + "MATERIALINPUTOUTPUTCODE, AVERAGEDAYSPERWEEKVALUE, AVERAGEWEEKSPERPERIODVALUE,   "
                    + "AVERAGEHOURSPERDAYVALUE, AVERAGEHOURSPERPERIODVALUE, TRANSACTIONSUBMITTALCODE,   "
                    + "TRIBALCODE FROM NEI_EMISSIONPERIOD  WHERE INVENTORY_YEAR = ?  ";

            public static final int EP_ID = 1;
            public static final int EU_ID = 2;
            public static final int SI_ID = 3;
            public static final int RECORDTYPECODE = 4;
            public static final int COUNTYSTATEFIPSCODE = 5;
            public static final int STATEFACILITYIDENTIFIER = 6;
            public static final int EMISSIONUNITIDENTIFIER = 7;
            public static final int PROCESSIDENTIFIER = 8;
            public static final int EMISSIONPERIODSTARTDATE = 9;
            public static final int EMISSIONPERIODENDDATE = 10;
            public static final int EMISSIONPERIODSTARTTIME = 11;
            public static final int EMISSIONPERIODENDTIME = 12;
            public static final int THROUGHPUTVALUE = 13;
            public static final int UNITNUMERATORVALUE = 14;
            public static final int MATERIALCODE = 15;
            public static final int MATERIALINPUTOUTPUTCODE = 16;
            public static final int AVERAGEDAYSPERWEEKVALUE = 17;
            public static final int AVERAGEWEEKSPERPERIODVALUE = 18;
            public static final int AVERAGEHOURSPERDAYVALUE = 19;
            public static final int AVERAGEHOURSPERPERIODVALUE = 20;
            public static final int TRANSACTIONSUBMITTALCODE = 21;
            public static final int TRIBALCODE = 22;

        }

        public static class EMISSION_SUB_GRP {
            // EmissionSubmissionGroup
            public static final String SQL = "SELECT EP_ID, EU_ID, SI_ID,  "
                    + "RECORDTYPECODE, COUNTYSTATEFIPSCODE, STATEFACILITYIDENTIFIER,  "
                    + "EMISSIONUNITIDENTIFIER, PROCESSIDENTIFIER, POLLUTANTCODE, "
                    + "RELEASEPOINTIDENTIFIER, EMISSIONPERIODSTARTDATE, EMISSIONPERIODENDDATE,  "
                    + "EMISSIONPERIODSTARTTIME, EMISSIONPERIODENDTIME, EMISSIONVALUE,  "
                    + "EMISSIONUNITNUMERATORVALUE, EMISSIONTYPECODE, RELIABILITYINDICATOR,  "
                    + "EMISSIONFACTORVALUE, UNITNUMERATORVALUE, UNITDENOMINATORVALUE,  "
                    + "MATERIALCODE, MATERIALINPUTOUTPUTCODE, EMISSIONCALCULATIONMETHODCODE,  "
                    + "EMISSIONFACTORRELIABILITY, RULEEFFECTIVENESSMEASURE, RULEEFFECTIVENESSMETHODCODE,  "
                    + "HAPEMISSIONSPERFORMANCELEVEL, CONTROLSTATUSCODE, EMISSIONDATALEVELIDENTIFIER,  "
                    + "TRANSACTIONSUBMITTALCODE, TRIBALCODE FROM NEI_EMISSIONSUBMISSION WHERE INVENTORY_YEAR = ? ";

            public static final int EP_ID = 1;
            public static final int EU_ID = 2;
            public static final int SI_ID = 3;
            public static final int RECORDTYPECODE = 4;
            public static final int COUNTYSTATEFIPSCODE = 5;
            public static final int STATEFACILITYIDENTIFIER = 6;
            public static final int EMISSIONUNITIDENTIFIER = 7;
            public static final int PROCESSIDENTIFIER = 8;
            public static final int POLLUTANTCODE = 9;
            public static final int RELEASEPOINTIDENTIFIER = 10;
            public static final int EMISSIONPERIODSTARTDATE = 11;
            public static final int EMISSIONPERIODENDDATE = 12;
            public static final int EMISSIONPERIODSTARTTIME = 13;
            public static final int EMISSIONPERIODENDTIME = 14;
            public static final int EMISSIONVALUE = 15;
            public static final int EMISSIONUNITNUMERATORVALUE = 16;
            public static final int EMISSIONTYPECODE = 17;
            public static final int RELIABILITYINDICATOR = 18;
            public static final int EMISSIONFACTORVALUE = 19;
            public static final int UNITNUMERATORVALUE = 20;
            public static final int UNITDENOMINATORVALUE = 21;
            public static final int MATERIALCODE = 22;
            public static final int MATERIALINPUTOUTPUTCODE = 23;
            public static final int EMISSIONCALCULATIONMETHODCODE = 24;
            public static final int EMISSIONFACTORRELIABILITY = 25;
            public static final int RULEEFFECTIVENESSMEASURE = 26;
            public static final int RULEEFFECTIVENESSMETHODCODE = 27;
            public static final int HAPEMISSIONSPERFORMANCELEVEL = 28;
            public static final int CONTROLSTATUSCODE = 29;
            public static final int EMISSIONDATALEVELIDENTIFIER = 30;
            public static final int TRANSACTIONSUBMITTALCODE = 31;
            public static final int TRIBALCODE = 32;
        }

        public static class CONTROL_EQUIP_SUB_GRP {
            // ControlEquipmentSubmissionGroup
            public static final String SQL = "SELECT EP_ID, EU_ID, SI_ID,  "
                    + "RECORDTYPECODE, COUNTYSTATEFIPSCODE, STATEFACILITYIDENTIFIER,  "
                    + "EMISSIONUNITIDENTIFIER, PROCESSIDENTIFIER, POLLUTANTCODE,  "
                    + "PRIMARYEFFICIENCYPERCENT, CAPTUREEFFICIENCYPERCENT, TOTALCAPTUREEFFICIENCYPERCENT,  "
                    + "DEVICEPRIMARYTYPECODE, DEVICESECONDARYTYPECODE, CONTROLSYSTEMDESCRIPTION,  "
                    + "DEVICETHIRDTYPECODE, DEVICEFOURTHTYPECODE, TRANSACTIONSUBMITTALCODE,  "
                    + "TRIBALCODE FROM NEI_CONTROLEQUIPMENT WHERE INVENTORY_YEAR = ? ";

            public static final int EP_ID = 1;
            public static final int EU_ID = 2;
            public static final int SI_ID = 3;
            public static final int RECORDTYPECODE = 4;
            public static final int COUNTYSTATEFIPSCODE = 5;
            public static final int STATEFACILITYIDENTIFIER = 6;
            public static final int EMISSIONUNITIDENTIFIER = 7;
            public static final int PROCESSIDENTIFIER = 8;
            public static final int POLLUTANTCODE = 9;
            public static final int PRIMARYEFFICIENCYPERCENT = 10;
            public static final int CAPTUREEFFICIENCYPERCENT = 11;
            public static final int TOTALCAPTUREEFFICIENCYPERCENT = 12;
            public static final int DEVICEPRIMARYTYPECODE = 13;
            public static final int DEVICESECONDARYTYPECODE = 14;
            public static final int CONTROLSYSTEMDESCRIPTION = 15;
            public static final int DEVICETHIRDTYPECODE = 16;
            public static final int DEVICEFOURTHTYPECODE = 17;
            public static final int TRANSACTIONSUBMITTALCODE = 18;
            public static final int TRIBALCODE = 19;

        }
    }

    private PreparedStatement psControlEquipSub;
    private PreparedStatement psEmissionPeriodSub;
    private PreparedStatement psEmissionProcess;
    private PreparedStatement psEmissionReleasePoint;
    private PreparedStatement psEmissionSub;
    private PreparedStatement psEmissionUnit;
    private PreparedStatement psSiteSub;
    private PreparedStatement psTransmittalSub;

    private Connection conn = null;

    public void getList(DataSource dataSource, String targetFilePath,
            DataRequest req, String org, String author, String contact,
            String sensitivity, String geoCoverage, boolean doHeader,
            String docId) {

        try {

            setDataSource(dataSource);

            conn = getDataSource().getConnection();

            psControlEquipSub = conn
                    .prepareStatement(NEI.CONTROL_EQUIP_SUB_GRP.SQL);
            psEmissionPeriodSub = conn
                    .prepareStatement(NEI.EMISSION_PERIOD_SUB_GRP.SQL);
            psEmissionProcess = conn.prepareStatement(NEI.EMISSION_PROCESS.SQL);
            psEmissionReleasePoint = conn
                    .prepareStatement(NEI.EMISSION_RELEASE_POINT.SQL);
            psEmissionSub = conn.prepareStatement(NEI.EMISSION_SUB_GRP.SQL);
            psEmissionUnit = conn
                    .prepareStatement(NEI.EMISSION_UNIT_SUB_GRP.SQL);
            psSiteSub = conn.prepareStatement(NEI.SITE_SUB_GRP.SQL);
            psTransmittalSub = conn
                    .prepareStatement(NEI.TRANSMITTAL_SUB_GRP.SQL);

            out = new OutputStreamWriter(new BufferedOutputStream(
                    new FileOutputStream(targetFilePath), 1024 * 24), "UTF-8");

            String year = req.getParameterValues()[0].trim();

            replace = req.getParameterValues()[1].trim().equalsIgnoreCase(
                    "replace");

            // submittalCode will change in the future, but for now will always
            // be A
            submittalCode = replace ? "A" : "";

            // Xml
            out.write("<?xml version=\"1.0\" ");
            out.write("encoding=\"UTF-8\"?>");

            if (doHeader) {

                // Document
                out
                        .write("<Document xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" ");
                out
                        .write("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ");
                out.write("Id=\"" + docId + "\" ");
                out
                        .write("xmlns=\"http://www.exchangenetwork.net/schema/v1.0/ExchangeNetworkDocument.xsd\">\n");

                // Header
                out.write("<Header xmlns=\"\">");
                out.write("<Author>" + author + "</Author>");
                out.write("<Organization>" + org + "</Organization>");
                out.write("<Title>Point Source</Title>");
                out.write("<CreationTime>" + new java.util.Date()
                        + "</CreationTime>");
                out.write("<ContactInfo>" + contact + "</ContactInfo>");
                out.write("<Notification>" + contact + "</Notification>");
                out.write("<Sensitivity>" + sensitivity + "</Sensitivity>");
                out.write("<Property>");
                out.write("<name>GeographicCoverage</name>");
                out.write("<value>" + geoCoverage + "</value>");
                out.write("</Property>");
                out.write("<Property>");
                out.write("<name>InventoryYear</name>");
                out.write("<value>" + year + "</value>");
                out.write("</Property>");
                out.write("<Property>");
                out.write("<name>PollutantCoverage</name>");
                out.write("<value></value>");
                out.write("</Property>");
                out.write("</Header>\n");

                // Payload
                out.write("<Payload Operation=\"Point|"
                        + req.getParameterValues()[1] + "\" xmlns=\"\">");
            }

            out
                    .write("<PointSourceSubmissionGroup xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" ");
            out
                    .write("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ");
            out
                    .write("xsi:schemaLocation=\"http://www.epa.gov/exchangenetwork ");
            out
                    .write("http://www.exchangenetwork.net/registry/EN_NEI_Point_v3_0.xsd\" ");
            out
                    .write("schemaVersion=\"0\" xmlns=\"http://www.epa.gov/exchangenetwork\">");

            writeSystemRecordCountValues(year);
            writeTransmittalSubmissionGroup(year);
            writeSiteSubmissionGroup(year);
            writeEmissionUnitSubmissionGroup(year);
            writeEmissionReleasePointSubmissionGroup(year);
            writeEmissionProcessSubmissionGroup(year);
            writeEmissionPeriodSubmissionGroup(year);
            writeEmissionSubmissionGroup(year);
            writeControlEquipmentSubmissionGroup(year);

            out.write("</PointSourceSubmissionGroup>");

            if (doHeader) {
                out.write("</Payload></Document>");
            }

            out.close();

        } catch (Exception ex) {
            ex.printStackTrace();
            logger.error(ex);
            throw new RuntimeException("Error while obtaining data: "
                    + ex.getMessage(), ex);

        } finally {

            try {
                if (out != null) {
                    out.close();
                }
            } catch (IOException ioex) {
                logger.error(ioex);
                throw new RuntimeException(ioex);
            }

            try {
                if (conn != null) {
                    conn.close();
                }
            } catch (Exception connEx) {
                logger.error(connEx);
                throw new RuntimeException(connEx);
            }

        }
    }

    /**
     * writeSystemRecordCountValues
     * 
     * @param year
     * @throws Exception
     */
    private void writeSystemRecordCountValues(String year) throws Exception {
        SystemRecordCountValues counts = new SystemRecordCountValues();

        logger.debug("Year (single-quoted for clarity) = '" + year + "'");
        logger.debug("Year(i.e., String).length() = " + year.length());

        if (StringUtils.isBlank(year) || year.length() != 4) {
            throw new RuntimeException("Invalid Year: " + year);
        }

        ResultSet rs = null;

        rs = executeQuery("SELECT COUNT(EP_ID) FROM NEI_CONTROLEQUIPMENT WHERE INVENTORY_YEAR = "
                + fixSql(year));
        if (rs.next()) {
            counts.SystemRecordCountControlEquipmentValue = rs.getString(1);
        }

        rs = executeQuery("SELECT COUNT(EP_ID) FROM NEI_EMISSIONPERIOD WHERE INVENTORY_YEAR = "
                + fixSql(year));
        if (rs.next()) {
            counts.SystemRecordCountEmissionPeriodValue = rs.getString(1);
        }

        rs = executeQuery("SELECT COUNT(EP_ID) FROM NEI_EMISSIONPROCESS WHERE INVENTORY_YEAR = "
                + fixSql(year));
        if (rs.next()) {
            counts.SystemRecordCountEmissionProcessValue = rs.getString(1);
        }

        rs = executeQuery("SELECT COUNT(ER_ID) FROM NEI_EMISSIONRELEASEPOINT WHERE INVENTORY_YEAR = "
                + fixSql(year));
        if (rs.next()) {
            counts.SystemRecordCountEmissionReleasePointValue = rs.getString(1);
        }

        rs = executeQuery("SELECT COUNT(EU_ID) FROM NEI_EMISSIONUNIT WHERE INVENTORY_YEAR = "
                + fixSql(year));
        if (rs.next()) {
            counts.SystemRecordCountEmissionUnitValue = rs.getString(1);
        }

        rs = executeQuery("SELECT COUNT(EP_ID) FROM NEI_EMISSIONSUBMISSION WHERE INVENTORY_YEAR = "
                + fixSql(year));
        if (rs.next()) {
            counts.SystemRecordCountEmissionValue = rs.getString(1);
        }

        rs = executeQuery("SELECT COUNT(SI_ID) FROM NEI_SITE WHERE INVENTORY_YEAR = "
                + fixSql(year));
        if (rs.next()) {
            counts.SystemRecordCountSiteValue = rs.getString(1);
        }

        rs = executeQuery("SELECT COUNT(RECORDTYPECODE) FROM NEI_TRANSMITTAL");
        if (rs.next()) {
            counts.SystemRecordCountTransmittalValue = rs.getString(1);
        }

        out.write(counts.getXml());
    }

    private void writeTransmittalSubmissionGroup(String year) throws Exception {

        psTransmittalSub.setString(1, year);
        ResultSet rs = psTransmittalSub.executeQuery();
        String creationDate = new SimpleDateFormat("yyyyMMdd")
                .format(new java.util.Date());

        while (rs.next()) {

            TransmittalSubmissionGroup trans = new TransmittalSubmissionGroup();

            trans.TransmittalRecordTypeCode = rs
                    .getString(NEI.TRANSMITTAL_SUB_GRP.RECORDTYPECODE);
            trans.CountyStateFIPSCode = rs
                    .getString(NEI.TRANSMITTAL_SUB_GRP.COUNTYSTATEFIPSCODE);
            trans.OrganizationFormalName = rs
                    .getString(NEI.TRANSMITTAL_SUB_GRP.ORGANIZATIONFORMALNAME);
            // trans.TransactionTypeCode =
            // rs.getString(NEI.TRANSMITTAL_SUB_GRP.TRANSACTIONTYPECODE);
            trans.TransactionTypeCode = replace ? "05" : "00";
            trans.InventoryYear = year;
            trans.InventoryTypeCode = rs
                    .getString(NEI.TRANSMITTAL_SUB_GRP.INVENTORYTYPECODE);
            trans.TransactionCreationDate = creationDate;
            trans.SubmissionNumber = rs
                    .getString(NEI.TRANSMITTAL_SUB_GRP.SUBMISSIONNUMBER);
            trans.ReliabilityIndicator = rs
                    .getString(NEI.TRANSMITTAL_SUB_GRP.RELIABILITYINDICATOR);
            trans.TransactionComment = rs
                    .getString(NEI.TRANSMITTAL_SUB_GRP.TRANSACTIONCOMMENT);
            trans.IndividualFullName = rs
                    .getString(NEI.TRANSMITTAL_SUB_GRP.INDIVIDUALFULLNAME);
            trans.TelephoneNumber = rs
                    .getString(NEI.TRANSMITTAL_SUB_GRP.TELEPHONENUMBER);
            trans.TelephoneNumberTypeName = rs
                    .getString(NEI.TRANSMITTAL_SUB_GRP.TELEHPHONENUMBERTYPENAME);
            trans.ElectronicAddressText = rs
                    .getString(NEI.TRANSMITTAL_SUB_GRP.ELECTRONICADDRESSTEXT);
            trans.ElectronicAddressTypeName = rs
                    .getString(NEI.TRANSMITTAL_SUB_GRP.ELECTRONICADDRESSTYPENAME);
            trans.SourceTypeCode = rs
                    .getString(NEI.TRANSMITTAL_SUB_GRP.SOURCETYPECODE);
            trans.AffiliationTypeText = rs
                    .getString(NEI.TRANSMITTAL_SUB_GRP.AFFILIATIONTYPETEXT);
            trans.FormatVersionNumber = rs
                    .getString(NEI.TRANSMITTAL_SUB_GRP.FORMATVERSIONNUMBER);
            trans.TribalCode = rs.getString(NEI.TRANSMITTAL_SUB_GRP.TRIBALCODE);

            this.out.write(trans.getXml());
        }

    }

    private void writeSiteSubmissionGroup(String year) throws Exception {
        psSiteSub.setString(1, year);
        ResultSet rs = psSiteSub.executeQuery();

        while (rs.next()) {
            SiteSubmissionGroup site = new SiteSubmissionGroup();
            site.CountryName = rs.getString(NEI.SITE_SUB_GRP.COUNTRYNAME);
            site.CountyStateFIPSCode = rs
                    .getString(NEI.SITE_SUB_GRP.COUNTYSTATEFIPSCODE);
            site.FacilityCategoryCode = rs
                    .getString(NEI.SITE_SUB_GRP.FACILITYCATEGORYCODE);
            site.FacilityDescription = rs
                    .getString(NEI.SITE_SUB_GRP.FACILITYDESCRIPTION);
            site.FacilityNTIIdentifier = rs
                    .getString(NEI.SITE_SUB_GRP.FACILITYNTIIDENTIFIER);
            site.FacilityRegistryIdentifier = rs
                    .getString(NEI.SITE_SUB_GRP.FACILITYREGISTRYIDENTIFIER);
            site.FacilitySiteName = rs
                    .getString(NEI.SITE_SUB_GRP.FACILITYSITENAME);
            site.FacilityTRIIdentifier = rs
                    .getString(NEI.SITE_SUB_GRP.FACILITYTRIIDENTIFIER);
            site.LocalityName = rs.getString(NEI.SITE_SUB_GRP.LOCALITYNAME);
            site.LocationAddressStateAbbrev = rs
                    .getString(NEI.SITE_SUB_GRP.LOCATIONSTATECODE);
            site.LocationAddressText = rs
                    .getString(NEI.SITE_SUB_GRP.LOCATIONADDRESSTEXT);
            site.LocationZipCode = rs
                    .getString(NEI.SITE_SUB_GRP.LOCATIONZIPCODE);
            site.NAICSCode = rs.getString(NEI.SITE_SUB_GRP.NAICS_CODE);
            site.OrganizationDUNSNumber = rs
                    .getString(NEI.SITE_SUB_GRP.ORGANIZATIONDUNSNUMBER);
            site.ORISFacilityCode = rs
                    .getString(NEI.SITE_SUB_GRP.ORISFACILITYCODE);
            site.SICCode = rs.getString(NEI.SITE_SUB_GRP.SICCODE);
            site.SiteRecordTypeCode = rs
                    .getString(NEI.SITE_SUB_GRP.RECORDTYPECODE);
            site.StateFacilityIdentifier = rs
                    .getString(NEI.SITE_SUB_GRP.STATEFACILITYIDENTIFIER);
            site.TransactionSubmittalCode = submittalCode;
            site.TribalCode = rs.getString(NEI.SITE_SUB_GRP.TRIBALCODE);

            // This will be added and change in the future to allow for deletes,
            // currently deletes not allowed
            /*
             * if (replace) { SiteSubmissionGroup siteD = new
             * SiteSubmissionGroup(); siteD.SiteRecordTypeCode =
             * site.SiteRecordTypeCode; siteD.CountyStateFIPSCode =
             * site.CountyStateFIPSCode; siteD.StateFacilityIdentifier =
             * site.StateFacilityIdentifier; siteD.FacilitySiteName =
             * site.FacilitySiteName; siteD.TribalCode = site.TribalCode;
             * siteD.TransactionSubmittalCode = "D";
             * 
             * if (useXML) { this.out.write(siteD.getXml()); } else {
             * zout.write(siteD.getText(delimiter).getBytes()); } }
             */
            this.out.write(site.getXml());
        }

    }

    private void writeEmissionUnitSubmissionGroup(String year) throws Exception {
        psEmissionUnit.setString(1, year);
        ResultSet rs = psEmissionUnit.executeQuery();

        while (rs.next()) {
            EmissionUnitSubmissionGroup unit = new EmissionUnitSubmissionGroup();
            unit.CountyStateFIPSCode = rs
                    .getString(NEI.EMISSION_UNIT_SUB_GRP.COUNTYSTATEFIPSCODE);
            unit.DesignCapacityMaximumNameplateValue = rs
                    .getString(NEI.EMISSION_UNIT_SUB_GRP.DESIGNCAPACITYMAXIMUM);
            unit.DesignCapacityMeasure = rs
                    .getString(NEI.EMISSION_UNIT_SUB_GRP.DESIGNCAPACITYMEASURE);
            unit.EmissionUnitDescription = rs
                    .getString(NEI.EMISSION_UNIT_SUB_GRP.EMISSIONUNITDESCRIPTION);
            unit.EmissionUnitIdentifier = rs
                    .getString(NEI.EMISSION_UNIT_SUB_GRP.EMISSIONUNITIDENTIFIER);
            unit.EmissionUnitRecordTypeCode = rs
                    .getString(NEI.EMISSION_UNIT_SUB_GRP.RECORDTYPECODE);
            unit.NAICSCode = rs.getString(NEI.EMISSION_UNIT_SUB_GRP.NAICSCODE);
            unit.ORISBoilerIdentifier = rs
                    .getString(NEI.EMISSION_UNIT_SUB_GRP.ORISBOILERIDENTIFIER);
            unit.SICCode = rs.getString(NEI.EMISSION_UNIT_SUB_GRP.SICCODE);
            unit.StateFacilityIdentifier = rs
                    .getString(NEI.EMISSION_UNIT_SUB_GRP.STATEFACILITYIDENTIFIER);
            unit.TransactionSubmittalCode = submittalCode;
            unit.TribalCode = rs
                    .getString(NEI.EMISSION_UNIT_SUB_GRP.TRIBALCODE);
            unit.UnitDenominatorValue = rs
                    .getString(NEI.EMISSION_UNIT_SUB_GRP.UNITDENOMINATORVALUE);
            unit.UnitNumeratorValue = rs
                    .getString(NEI.EMISSION_UNIT_SUB_GRP.UNITNUMERATORVALUE);

            this.out.write(unit.getXml());
        }

    }

    private void writeEmissionReleasePointSubmissionGroup(String year)
            throws Exception {
        psEmissionReleasePoint.setString(1, year);
        ResultSet rs = psEmissionReleasePoint.executeQuery();

        while (rs.next()) {
            EmissionReleasePointSubmissionGroup point = new EmissionReleasePointSubmissionGroup();
            point.CoordinateDataSourceCode = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.COORDINATEDATASOURCECODE);
            point.CountyStateFIPSCode = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.COUNTYSTATEFIPSCODE);
            point.EmissionReleasePointRecordTypeCode = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.RECORDTYPECODE);
            point.ExitGasFlowRate = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.EXITGASFLOWRATE);
            point.ExitGasStreamVelocityRate = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.EXITGASSTREAMVELOCITYVALUE);
            point.ExitGasTemperatureValue = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.EXITGASTEMPERATUREVALUE);
            point.FugitiveHorizontalAreaValue = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.FUGITIVEHORIZONTALAREAVALUE);
            point.FugitiveReleaseHeightValue = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.FUGITIVERELEASEHEIGHTVALUE);
            point.FugitiveUnitOfMeasureCode = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.FUGITIVEUNITOFMEASURECODE);
            point.HorizontalAccuracyMeasure = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.HORIZONTALACCURACYMEASURE);
            point.HorizontalCollectionMethodCode = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.HORIZONTALCOLLECTIONMETHODCODE);
            point.HorizontalReferenceDatumCode = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.HORIZONTALREFERENCEDATUMCODE);
            point.LatitudeMeasure = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.LATITUDEMEASURE);
            point.LongitudeMeasure = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.LONGITUDEMEASURE);
            point.ReferencePointCode = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.REFERENCEPOINTCODE);
            point.ReleasePointDescription = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.RELEASEPOINTDESCRIPTION);
            point.ReleasePointIdentifier = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.RELEASEPOINTIDENTIFIER);
            point.ReleasePointTypeCode = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.RELEASEPOINTTYPECODE);
            point.SourceMapScaleNumber = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.SOURCEMAPSCALENUMBER);
            point.StackDiameterValue = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.STACKDIAMETERVALUE);
            point.StackFencelineDistanceValue = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.STACKFENCELINEDISTANCEVALUE);
            point.StackHeightValue = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.STACKHEIGHTVALUE);
            point.StateFacilityIdentifier = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.STATEFACILITYIDENTIFIER);
            point.TransactionSubmittalCode = submittalCode;
            point.TribalCode = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.TRIBALCODE);
            point.UTMZoneCode = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.UTMZONECODE);
            point.XYCoordinateTypeCode = rs
                    .getString(NEI.EMISSION_RELEASE_POINT.XYCOORDINATETYPECODE);

            this.out.write(point.getXml());
        }

    }

    private void writeEmissionProcessSubmissionGroup(String year)
            throws Exception {
        psEmissionProcess.setString(1, year);
        ResultSet rs = psEmissionProcess.executeQuery();

        while (rs.next()) {
            EmissionProcessSubmissionGroup process = new EmissionProcessSubmissionGroup();
            process.AverageDaysPerWeekValue = rs
                    .getString(NEI.EMISSION_PROCESS.AVERAGEDAILYPERWEEKVALUE);
            process.AverageHoursPerDayValue = rs
                    .getString(NEI.EMISSION_PROCESS.AVERAGEHOURSPERDAYVALUE);
            process.AverageHoursPerYearValue = rs
                    .getString(NEI.EMISSION_PROCESS.AVERAGEHOURSPERYEARVALUE);
            process.AverageWeeksPerYearValue = rs
                    .getString(NEI.EMISSION_PROCESS.AVERAGEWEEKSPERYEARVALUE);
            process.CountyStateFIPSCode = rs
                    .getString(NEI.EMISSION_PROCESS.COUNTYSTATEFIPSCODE);
            process.EmissionProcessDescription = rs
                    .getString(NEI.EMISSION_PROCESS.EMISSIONPROCESSDESCRIPTION);
            process.EmissionProcessRecordTypeCode = rs
                    .getString(NEI.EMISSION_PROCESS.RECORDTYPECODE);
            process.EmissionUnitIdentifier = rs
                    .getString(NEI.EMISSION_PROCESS.EMISSIONUNITIDENTIFIER);
            process.FuelAshContentMeasure = rs
                    .getString(NEI.EMISSION_PROCESS.FUELASHCONTENTMEASURE);
            process.FuelHeatContentMeasure = rs
                    .getString(NEI.EMISSION_PROCESS.FULLHEATCONTENTMEASURE);
            process.FuelSulfurContentMeasure = rs
                    .getString(NEI.EMISSION_PROCESS.FUELSULFURCONTENTMEASURE);
            process.MACTCode = rs.getString(NEI.EMISSION_PROCESS.MACTCODE);
            process.MACTComplianceStatusCode = rs
                    .getString(NEI.EMISSION_PROCESS.MACTCOMPLIANCESTATUSCODE);
            process.ProcessIdentifier = rs
                    .getString(NEI.EMISSION_PROCESS.PROCESSIDENTIFIER);
            process.ReleasePointIdentifier = rs
                    .getString(NEI.EMISSION_PROCESS.RELEASEPOINTIDENTIFIER);
            process.SourceCategoryCode = rs
                    .getString(NEI.EMISSION_PROCESS.SOURCECATEGORYCODE);
            process.StateFacilityIdentifier = rs
                    .getString(NEI.EMISSION_PROCESS.STATEFACILITYIDENTIFIER);
            process.ThroughputFallPercent = rs
                    .getString(NEI.EMISSION_PROCESS.THROUGHPUTFALLPERCENT);
            process.ThroughputSpringPercent = rs
                    .getString(NEI.EMISSION_PROCESS.THROUGHPUTSPRINGPERCENT);
            process.ThroughputSummerPercent = rs
                    .getString(NEI.EMISSION_PROCESS.THROUGHPUTSUMMERPERCENT);
            process.ThroughputWinterPercent = rs
                    .getString(NEI.EMISSION_PROCESS.THROUGHPUTWINTERPERCENT);
            process.TransactionSubmittalCode = submittalCode;
            process.TribalCode = rs.getString(NEI.EMISSION_PROCESS.TRIBALCODE);

            this.out.write(process.getXml());
        }

    }

    private void writeEmissionPeriodSubmissionGroup(String year)
            throws Exception {
        psEmissionPeriodSub.setString(1, year);
        ResultSet rs = psEmissionPeriodSub.executeQuery();

        while (rs.next()) {
            EmissionPeriodSubmissionGroup period = new EmissionPeriodSubmissionGroup();
            period.AverageDaysPerWeekValue = rs
                    .getString(NEI.EMISSION_PERIOD_SUB_GRP.AVERAGEDAYSPERWEEKVALUE);
            period.AverageHoursPerDayValue = rs
                    .getString(NEI.EMISSION_PERIOD_SUB_GRP.AVERAGEHOURSPERDAYVALUE);
            period.AverageHoursPerPeriodValue = rs
                    .getString(NEI.EMISSION_PERIOD_SUB_GRP.AVERAGEHOURSPERPERIODVALUE);
            period.AverageWeeksPerPeriodValue = rs
                    .getString(NEI.EMISSION_PERIOD_SUB_GRP.AVERAGEWEEKSPERPERIODVALUE);
            period.CountyStateFIPSCode = rs
                    .getString(NEI.EMISSION_PERIOD_SUB_GRP.COUNTYSTATEFIPSCODE);
            period.EmissionPeriodEndDate = rs
                    .getString(NEI.EMISSION_PERIOD_SUB_GRP.EMISSIONPERIODENDDATE);
            period.EmissionPeriodEndTime = rs
                    .getString(NEI.EMISSION_PERIOD_SUB_GRP.EMISSIONPERIODENDTIME);
            period.EmissionPeriodRecordTypeCode = rs
                    .getString(NEI.EMISSION_PERIOD_SUB_GRP.RECORDTYPECODE);
            period.EmissionPeriodStartDate = rs
                    .getString(NEI.EMISSION_PERIOD_SUB_GRP.EMISSIONPERIODSTARTDATE);
            period.EmissionPeriodStartTime = rs
                    .getString(NEI.EMISSION_PERIOD_SUB_GRP.EMISSIONPERIODSTARTTIME);
            period.EmissionUnitIdentifier = rs
                    .getString(NEI.EMISSION_PERIOD_SUB_GRP.EMISSIONUNITIDENTIFIER);
            period.MaterialCode = rs
                    .getString(NEI.EMISSION_PERIOD_SUB_GRP.MATERIALCODE);
            period.MaterialInputOutputCode = rs
                    .getString(NEI.EMISSION_PERIOD_SUB_GRP.MATERIALINPUTOUTPUTCODE);
            period.ProcessIdentifier = rs
                    .getString(NEI.EMISSION_PERIOD_SUB_GRP.PROCESSIDENTIFIER);
            period.StateFacilityIdentifier = rs
                    .getString(NEI.EMISSION_PERIOD_SUB_GRP.STATEFACILITYIDENTIFIER);
            period.ThroughputValue = rs
                    .getString(NEI.EMISSION_PERIOD_SUB_GRP.THROUGHPUTVALUE);
            period.TransactionSubmittalCode = submittalCode;
            period.TribalCode = rs
                    .getString(NEI.EMISSION_PERIOD_SUB_GRP.TRIBALCODE);
            period.UnitNumeratorValue = rs
                    .getString(NEI.EMISSION_PERIOD_SUB_GRP.UNITNUMERATORVALUE);

            this.out.write(period.getXml());

        }

    }

    private void writeEmissionSubmissionGroup(String year) throws Exception {
        psEmissionSub.setString(1, year);
        ResultSet rs = psEmissionSub.executeQuery();

        while (rs.next()) {
            EmissionSubmissionGroup emission = new EmissionSubmissionGroup();
            emission.ControlStatusCode = rs
                    .getString(NEI.EMISSION_SUB_GRP.CONTROLSTATUSCODE);
            emission.CountyStateFIPSCode = rs
                    .getString(NEI.EMISSION_SUB_GRP.COUNTYSTATEFIPSCODE);
            emission.EmissionCalculationMethodCode = rs
                    .getString(NEI.EMISSION_SUB_GRP.EMISSIONCALCULATIONMETHODCODE);
            emission.EmissionDataLevelIdentifier = rs
                    .getString(NEI.EMISSION_SUB_GRP.EMISSIONDATALEVELIDENTIFIER);
            emission.EmissionFactorReliabilityIndicator = rs
                    .getString(NEI.EMISSION_SUB_GRP.EMISSIONFACTORRELIABILITY);
            emission.EmissionFactorValue = rs
                    .getString(NEI.EMISSION_SUB_GRP.EMISSIONFACTORVALUE);
            emission.EmissionPeriodEndDate = rs
                    .getString(NEI.EMISSION_SUB_GRP.EMISSIONPERIODENDDATE);
            emission.EmissionPeriodEndTime = rs
                    .getString(NEI.EMISSION_SUB_GRP.EMISSIONPERIODENDTIME);
            emission.EmissionPeriodStartDate = rs
                    .getString(NEI.EMISSION_SUB_GRP.EMISSIONPERIODSTARTDATE);
            emission.EmissionPeriodStartTime = rs
                    .getString(NEI.EMISSION_SUB_GRP.EMISSIONPERIODSTARTTIME);
            emission.EmissionRecordTypeCode = rs
                    .getString(NEI.EMISSION_SUB_GRP.RECORDTYPECODE);
            emission.EmissionTypeCode = rs
                    .getString(NEI.EMISSION_SUB_GRP.EMISSIONTYPECODE);
            emission.EmissionUnitIdentifier = rs
                    .getString(NEI.EMISSION_SUB_GRP.EMISSIONUNITIDENTIFIER);
            emission.EmissionUnitNumeratorValue = rs
                    .getString(NEI.EMISSION_SUB_GRP.EMISSIONUNITNUMERATORVALUE);
            emission.EmissionValue = rs
                    .getString(NEI.EMISSION_SUB_GRP.EMISSIONVALUE);
            emission.FactorUnitDenominatorValue = rs
                    .getString(NEI.EMISSION_SUB_GRP.UNITDENOMINATORVALUE);
            emission.FactorUnitNumeratorValue = rs
                    .getString(NEI.EMISSION_SUB_GRP.UNITNUMERATORVALUE);
            emission.HAPEmissionsPerformanceLevelCode = rs
                    .getString(NEI.EMISSION_SUB_GRP.HAPEMISSIONSPERFORMANCELEVEL);
            emission.MaterialCode = rs
                    .getString(NEI.EMISSION_SUB_GRP.MATERIALCODE);
            emission.MaterialInputOutputCode = rs
                    .getString(NEI.EMISSION_SUB_GRP.MATERIALINPUTOUTPUTCODE);
            emission.PollutantCode = rs
                    .getString(NEI.EMISSION_SUB_GRP.POLLUTANTCODE);
            emission.ProcessIdentifier = rs
                    .getString(NEI.EMISSION_SUB_GRP.PROCESSIDENTIFIER);
            emission.ReleasePointIdentifier = rs
                    .getString(NEI.EMISSION_SUB_GRP.RELEASEPOINTIDENTIFIER);
            emission.ReliabilityIndicator = rs
                    .getString(NEI.EMISSION_SUB_GRP.RELIABILITYINDICATOR);
            emission.RuleEffectivenessMeasure = rs
                    .getString(NEI.EMISSION_SUB_GRP.RULEEFFECTIVENESSMEASURE);
            emission.RuleEffectivenessMethodCode = rs
                    .getString(NEI.EMISSION_SUB_GRP.RULEEFFECTIVENESSMETHODCODE);
            emission.StateFacilityIdentifier = rs
                    .getString(NEI.EMISSION_SUB_GRP.STATEFACILITYIDENTIFIER);
            emission.TransactionSubmittalCode = submittalCode;
            emission.TribalCode = rs.getString(NEI.EMISSION_SUB_GRP.TRIBALCODE);

            this.out.write(emission.getXml());
        }

    }

    private void writeControlEquipmentSubmissionGroup(String year)
            throws Exception {
        psControlEquipSub.setString(1, year);
        ResultSet rs = psControlEquipSub.executeQuery();

        while (rs.next()) {
            ControlEquipmentSubmissionGroup equip = new ControlEquipmentSubmissionGroup();
            equip.CaptureEfficiencyPercent = rs
                    .getString(NEI.CONTROL_EQUIP_SUB_GRP.CAPTUREEFFICIENCYPERCENT);
            equip.ControlEquipmentRecordTypeCode = rs
                    .getString(NEI.CONTROL_EQUIP_SUB_GRP.RECORDTYPECODE);
            equip.ControlSystemDescription = rs
                    .getString(NEI.CONTROL_EQUIP_SUB_GRP.CONTROLSYSTEMDESCRIPTION);
            equip.CountyStateFIPSCode = rs
                    .getString(NEI.CONTROL_EQUIP_SUB_GRP.COUNTYSTATEFIPSCODE);
            equip.DeviceFourthTypeCode = rs
                    .getString(NEI.CONTROL_EQUIP_SUB_GRP.DEVICEFOURTHTYPECODE);
            equip.DevicePrimaryTypeCode = rs
                    .getString(NEI.CONTROL_EQUIP_SUB_GRP.DEVICEPRIMARYTYPECODE);
            equip.DeviceSecondaryTypeCode = rs
                    .getString(NEI.CONTROL_EQUIP_SUB_GRP.DEVICESECONDARYTYPECODE);
            equip.DeviceThirdTypeCode = rs
                    .getString(NEI.CONTROL_EQUIP_SUB_GRP.DEVICETHIRDTYPECODE);
            equip.EmissionUnitIdentifier = rs
                    .getString(NEI.CONTROL_EQUIP_SUB_GRP.EMISSIONUNITIDENTIFIER);
            equip.PollutantCode = rs
                    .getString(NEI.CONTROL_EQUIP_SUB_GRP.POLLUTANTCODE);
            equip.PrimaryEfficiencyPercent = rs
                    .getString(NEI.CONTROL_EQUIP_SUB_GRP.PRIMARYEFFICIENCYPERCENT);
            equip.ProcessIdentifier = rs
                    .getString(NEI.CONTROL_EQUIP_SUB_GRP.PROCESSIDENTIFIER);
            equip.StateFacilityIdentifier = rs
                    .getString(NEI.CONTROL_EQUIP_SUB_GRP.STATEFACILITYIDENTIFIER);
            equip.TotalCaptureEfficiencyPercent = rs
                    .getString(NEI.CONTROL_EQUIP_SUB_GRP.TOTALCAPTUREEFFICIENCYPERCENT);
            equip.TransactionSubmittalCode = submittalCode;
            equip.TribalCode = rs
                    .getString(NEI.CONTROL_EQUIP_SUB_GRP.TRIBALCODE);

            this.out.write(equip.getXml());

        }

    }

    private ResultSet executeQuery(String sql) throws Exception {

        ResultSet rs = null;

        try {
            // System.out.println("NEI: SQL: "+sql);
            Statement stmt = conn.createStatement();
            rs = stmt.executeQuery(sql);
        } catch (SQLException ex) {
            throw new Exception("Code: " + ex.getErrorCode() + "; Message: "
                    + ex.getMessage());
        }

        return rs;
    }

    protected static String fixSql(String input) {
        String output = input;
        output = output.replace('\n', ' ');
        output = output.replace('\t', ' ');
        output = output.replace('\r', ' ');
        return output;
    }

}
