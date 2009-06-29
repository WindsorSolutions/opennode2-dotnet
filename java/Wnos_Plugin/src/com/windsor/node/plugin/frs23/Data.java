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

package com.windsor.node.plugin.frs23;

import java.io.BufferedOutputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

import javax.sql.DataSource;

import org.apache.log4j.Logger;
import org.springframework.jdbc.core.support.JdbcDaoSupport;

import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.DataRequest;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.plugin.frs23.identities.Affiliation;
import com.windsor.node.plugin.frs23.identities.AlternativeNameInfo;
import com.windsor.node.plugin.frs23.identities.EnvironmentalInterestDetails;
import com.windsor.node.plugin.frs23.identities.FacilitySite;
import com.windsor.node.plugin.frs23.identities.GeographicCoordinates;
import com.windsor.node.plugin.frs23.identities.Individual;
import com.windsor.node.plugin.frs23.identities.LocationAddress;
import com.windsor.node.plugin.frs23.identities.MailingAddress;
import com.windsor.node.plugin.frs23.identities.NAICSCodeDetails;
import com.windsor.node.plugin.frs23.identities.Organization;
import com.windsor.node.plugin.frs23.identities.PhoneFaxEmail;
import com.windsor.node.plugin.frs23.identities.SICCodeDetails;
import com.windsor.node.plugin.xml.ElementUtil;

/**
 * @author jreinhold
 * 
 */
public class Data extends JdbcDaoSupport {

    public static final String SERVICE_CHANGEDATE = "GetFacilityByChangeDate";
    public static final String SERVICE_DELETED = "GetDeletedFacilityByChangeDate";
    public static final String SERVICE_NAME = "GetFacilityByName";

    private Logger logger = Logger.getLogger(getClass());

    private OutputStreamWriter out = null;
    private PreparedStatement psEnvInterest = null;
    private PreparedStatement psGeoCoordinate = null;
    private PreparedStatement psIndividual = null;
    private PreparedStatement psNAICS = null;
    private PreparedStatement psOrganization = null;
    private PreparedStatement psSICCode = null;
    private boolean isForEPA;
    private Connection conn;

    private static class FRS {

        public static class DELETEDFACILITIES {
            public static final String STATEFACILITYIDENTIFIER = "STATEFACILITYIDENTIFIER";
            public static final String DELETEDONDATE = "DELETEDONDATE";
        }

        public static class ENVIRONMENTALINTEREST {

            public static final String STATEFACILITYIDENTIFIER = "STATEFACILITYIDENTIFIER";
            public static final String INFORMATIONSYSTEMIDENTIFIER = "INFORMATIONSYSTEMIDENTIFIER";
            public static final String ENVIRONMENTALINTERESTTYPETEXT = "ENVIRONMENTALINTERESTTYPETEXT";
            public static final String INFORMATIONSYSTEMACRONYMNAME = "INFORMATIONSYSTEMACRONYMNAME";
            public static final String FEDERALSTATEINTERESTINDICATOR = "FEDERALSTATEINTERESTINDICATOR";
            public static final String ENVIRONMENTALINTERESTSTARTDATE = "ENVIRONMENTALINTERESTSTARTDATE";
            public static final String INTERESTSTARTDATEQUALIFIERTEXT = "INTERESTSTARTDATEQUALIFIERTEXT";
            public static final String ENVIRONMENTALINTERESTENDDATE = "ENVIRONMENTALINTERESTENDDATE";
            public static final String DATASOURCENAME = "DATASOURCENAME";
            public static final String LASTREPORTEDDATE = "LASTREPORTEDDATE";
            public static final String INTERESTENDDATEQUALIFIERTEXT = "INTERESTENDDATEQUALIFIERTEXT";
            public static final String STATEFACILITYSYSTEMACRONYMNAME = "STATEFACILITYSYSTEMACRONYMNAME";
        }

        public static class FACILITYSITE {
            public static final String STATEFACILITYIDENTIFIER = "STATEFACILITYIDENTIFIER";
            public static final String SOURCEOFDATA = "DATASOURCENAME";
            public static final String LASTREPORTEDDATE = "LASTREPORTEDDATE";
            public static final String STATEFACILITYSYSTEMACRONYMNAME = "STATEFACILITYSYSTEMACRONYMNAME";
            public static final String FACILITYREGISTRYIDENTIFIER = "FACILITYREGISTRYIDENTIFIER";
            public static final String FACILITYSITENAME = "FACILITYSITENAME";
            public static final String FACILITYSITETYPENAME = "FACILITYSITETYPENAME";
            public static final String FEDERALFACILITYINDICATOR = "FEDERALFACILITYINDICATOR";
            public static final String TRIBALLANDINDICATOR = "TRIBALLANDINDICATOR";
            public static final String TRIBALLANDNAME = "TRIBALLANDNAME";
            public static final String CONGRESSIONALDISTRICTNUMBER = "CONGRESSIONALDISTRICTNUMBER";
            public static final String LEGISLATIVEDISTRICTNUMBER = "LEGISLATIVEDISTRICTNUMBER";
            public static final String HUCCODE = "HUCCODE";
            public static final String LOCATIONADDRESSTEXT = "LOCATIONADDRESSTEXT";
            public static final String SUPPLEMENTALLOCATIONTEXT = "SUPPLEMENTALLOCATIONTEXT";
            public static final String LOCALITYNAME = "LOCALITYNAME";
            public static final String COUNTYSTATEFIPSCODE = "COUNTYSTATEFIPSCODE";
            public static final String COUNTYNAME = "COUNTYNAME";
            public static final String STATEUSPSCODE = "STATEUSPSCODE";
            public static final String STATENAME = "STATENAME";
            public static final String COUNTRYNAME = "COUNTRYNAME";
            public static final String LOCATIONZIPCODE = "LOCATIONZIPCODE";
            public static final String LOCATIONDESCRIPTIONTEXT = "LOCATIONDESCRIPTIONTEXT";

            // ALT FAC NAME
            public static final String ALTERNATIVENAME = "ALTERNATIVENAME";
            public static final String ALTERNATIVENAMETYPETEXT = "ALTERNATIVENAMETYPETEXT";

            // MAIL ADDRESS FOR FAC
            public static final String AFFILIATIONTYPETEXT = "AFFILIATIONTYPETEXT";
            public static final String MAILINGADDRESSTEXT = "MAILINGADDRESSTEXT";
            public static final String SUPPLEMENTALADDRESSTEXT = "SUPPLEMENTALADDRESSTEXT";
            public static final String MAILINGADDRESSCITYNAME = "MAILINGADDRESSCITYNAME";
            public static final String MAILINGADDRESSSTATEUSPSCODE = "MAILINGADDRESSSTATEUSPSCODE";
            public static final String MAILINGADDRESSSTATENAME = "MAILINGADDRESSSTATENAME";
            public static final String MAILINGADDRESSCOUNTRYNAME = "MAILINGADDRESSCOUNTRYNAME";
            public static final String MAILINGADDRESSZIPCODE = "MAILINGADDRESSZIPCODE";
            public static final String DATASOURCENAME = "DATASOURCENAME";

        }

        public static class GEOGRAPHICCOORDINATES {
            public static final String STATEFACILITYIDENTIFIER = "STATEFACILITYIDENTIFIER";
            public static final String LATITUDEMEASURE = "LATITUDEMEASURE";
            public static final String LONGITUDEMEASURE = "LONGITUDEMEASURE";
            public static final String HORIZONTALACCURACYMEASURE = "HORIZONTALACCURACYMEASURE";
            public static final String HORIZONTALCOLLECTIONMETHODTEXT = "HORIZONTALCOLLECTIONMETHODTEXT";
            public static final String HORIZONTALREFERENCEDATUMNAME = "HORIZONTALREFERENCEDATUMNAME";
            public static final String SOURCEMAPSCALENUMBER = "SOURCEMAPSCALENUMBER";
            public static final String REFERENCEPOINTTEXT = "REFERENCEPOINTTEXT";
            public static final String DATACOLLECTIONDATE = "DATACOLLECTIONDATE";
            public static final String GEOMETRICTYPENAME = "GEOMETRICTYPENAME";
            public static final String LOCATIONCOMMENTSTEXT = "LOCATIONCOMMENTSTEXT";
            public static final String VERTICALCOLLECTIONMETHODTEXT = "VERTICALCOLLECTIONMETHODTEXT";
            public static final String VERTICALMEASURE = "VERTICALMEASURE";
            public static final String VERTICALACCURACYMEASURE = "VERTICALACCURACYMEASURE";
            public static final String VERTICALREFERENCEDATUMNAME = "VERTICALREFERENCEDATUMNAME";
            public static final String DATASOURCENAME = "DATASOURCENAME";
            public static final String COORDINATEDATASOURCENAME = "COORDINATEDATASOURCENAME";
            public static final String SUBENTITYIDENTIFIER = "SUBENTITYIDENTIFIER";
            public static final String SUBENTITYTYPENAME = "SUBENTITYTYPENAME";
            public static final String STATEFACILITYSYSTEMACRONYMNAME = "STATEFACILITYSYSTEMACRONYMNAME";
        }

        public static class INDIVIDUAL {

            public static final String STATEFACILITYIDENTIFIER = "STATEFACILITYIDENTIFIER";
            public static final String INDIVIDUALFULLNAME = "INDIVIDUALFULLNAME";
            public static final String AFFILIATIONTYPETEXT = "AFFILIATIONTYPETEXT";
            public static final String AFFILIATIONSTARTDATE = "AFFILIATIONSTARTDATE";
            public static final String AFFILIATIONENDDATE = "AFFILIATIONENDDATE";
            public static final String EMAILADDRESSTEXT = "EMAILADDRESSTEXT";
            public static final String TELEPHONENUMBER = "TELEPHONENUMBER";
            public static final String PHONEEXTENSION = "PHONEEXTENSION";
            public static final String FAXNUMBER = "FAXNUMBER";
            public static final String ALTERNATETELEPHONENUMBER = "ALTERNATETELEPHONENUMBER";
            public static final String INDIVIDUALTITLETEXT = "INDIVIDUALTITLETEXT";
            public static final String MAILINGADDRESSTEXT = "MAILINGADDRESSTEXT";
            public static final String SUPPLEMENTALADDRESSTEXT = "SUPPLEMENTALADDRESSTEXT";
            public static final String MAILINGADDRESSCITYNAME = "MAILINGADDRESSCITYNAME";
            public static final String MAILINGADDRESSSTATEUSPSCODE = "MAILINGADDRESSSTATEUSPSCODE";
            public static final String MAILINGADDRESSSTATENAME = "MAILINGADDRESSSTATENAME";
            public static final String MAILINGADDRESSCOUNTRYNAME = "MAILINGADDRESSCOUNTRYNAME";
            public static final String MAILINGADDRESSZIPCODE = "MAILINGADDRESSZIPCODE";
            public static final String INFORMATIONSYSTEMACRONYMNAME = "INFORMATIONSYSTEMACRONYMNAME";
            public static final String INFORMATIONSYSTEMIDENTIFIER = "INFORMATIONSYSTEMIDENTIFIER";
            public static final String ENVIRONMENTALINTERESTTYPETEXT = "ENVIRONMENTALINTERESTTYPETEXT";
            public static final String DATASOURCENAME = "DATASOURCENAME";
            public static final String LASTREPORTEDDATE = "LASTREPORTEDDATE";
            public static final String STATEFACILITYSYSTEMACRONYMNAME = "STATEFACILITYSYSTEMACRONYMNAME";

        }

        public static class NAICSCODE {

            public static final String STATEFACILITYIDENTIFIER = "STATEFACILITYIDENTIFIER";
            public static final String NAICSCODE = "NAICSCODE";
            public static final String NAICSPRIMARYINDICATOR = "NAICSPRIMARYINDICATOR";
            public static final String INFORMATIONSYSTEMACRONYMNAME = "INFORMATIONSYSTEMACRONYMNAME";
            public static final String INFORMATIONSYSTEMIDENTIFIER = "INFORMATIONSYSTEMIDENTIFIER";
            public static final String ENVIRONMENTALINTERESTTYPETEXT = "ENVIRONMENTALINTERESTTYPETEXT";
            public static final String DATASOURCENAME = "DATASOURCENAME";
            public static final String LASTREPORTEDDATE = "LASTREPORTEDDATE";
            public static final String STATEFACILITYSYSTEMACRONYMNAME = "STATEFACILITYSYSTEMACRONYMNAME";
        }

        public static class ORGANIZATION {

            public static final String STATEFACILITYIDENTIFIER = "STATEFACILITYIDENTIFIER";
            public static final String ORGANIZATIONFORMALNAME = "ORGANIZATIONFORMALNAME";
            public static final String AFFILIATIONTYPETEXT = "AFFILIATIONTYPETEXT";
            public static final String AFFILIATIONSTARTDATE = "AFFILIATIONSTARTDATE";
            public static final String AFFILIATIONENDDATE = "AFFILIATIONENDDATE";
            public static final String EMAILADDRESSTEXT = "EMAILADDRESSTEXT";
            public static final String TELEPHONENUMBER = "TELEPHONENUMBER";
            public static final String PHONEEXTENSION = "PHONEEXTENSION";
            public static final String FAXNUMBER = "FAXNUMBER";
            public static final String ALTERNATETELEPHONENUMBER = "ALTERNATETELEPHONENUMBER";
            public static final String ORGANIZATIONDUNSNUMBER = "ORGANIZATIONDUNSNUMBER";
            public static final String ORGANIZATIONTYPETEXT = "ORGANIZATIONTYPETEXT";
            public static final String EMPLOYERIDENTIFIER = "EMPLOYERIDENTIFIER";
            public static final String STATEBUSINESSIDENTIFIER = "STATEBUSINESSIDENTIFIER";
            public static final String ULTIMATEPARENTNAME = "ULTIMATEPARENTNAME";
            public static final String ULTIMATEPARENTDUNSNUMBER = "ULTIMATEPARENTDUNSNUMBER";
            public static final String MAILINGADDRESSTEXT = "MAILINGADDRESSTEXT";
            public static final String SUPPLEMENTALADDRESSTEXT = "SUPPLEMENTALADDRESSTEXT";
            public static final String MAILINGADDRESSCITYNAME = "MAILINGADDRESSCITYNAME";
            public static final String MAILINGADDRESSSTATEUSPSCODE = "MAILINGADDRESSSTATEUSPSCODE";
            public static final String MAILINGADDRESSSTATENAME = "MAILINGADDRESSSTATENAME";
            public static final String MAILINGADDRESSCOUNTRYNAME = "MAILINGADDRESSCOUNTRYNAME";
            public static final String MAILINGADDRESSZIPCODE = "MAILINGADDRESSZIPCODE";
            public static final String INFORMATIONSYSTEMACRONYMNAME = "INFORMATIONSYSTEMACRONYMNAME";
            public static final String INFORMATIONSYSTEMIDENTIFIER = "INFORMATIONSYSTEMIDENTIFIER";
            public static final String ENVIRONMENTALINTERESTTYPETEXT = "ENVIRONMENTALINTERESTTYPETEXT";
            public static final String DATASOURCENAME = "DATASOURCENAME";
            public static final String LASTREPORTEDDATE = "LASTREPORTEDDATE";
            public static final String STATEFACILITYSYSTEMACRONYMNAME = "STATEFACILITYSYSTEMACRONYMNAME";
        }

        public static class SICCODE {
            public static final String STATEFACILITYIDENTIFIER = "STATEFACILITYIDENTIFIER";
            public static final String SICCODE = "SICCODE";
            public static final String SICPRIMARYINDICATOR = "SICPRIMARYINDICATOR";
            public static final String INFORMATIONSYSTEMACRONYMNAME = "INFORMATIONSYSTEMACRONYMNAME";
            public static final String INFORMATIONSYSTEMIDENTIFIER = "INFORMATIONSYSTEMIDENTIFIER";
            public static final String ENVIRONMENTALINTERESTTYPETEXT = "ENVIRONMENTALINTERESTTYPETEXT";
            public static final String DATASOURCENAME = "DATASOURCENAME";
            public static final String LASTREPORTEDDATE = "LASTREPORTEDDATE";
            public static final String STATEFACILITYSYSTEMACRONYMNAME = "STATEFACILITYSYSTEMACRONYMNAME";
        }

        public static final String SQL_DELETED = "SELECT * "
                + "FROM FRS_DELETEDFACILITIES " + "WHERE WHERE_CLAUSE  ";

        public static final String SQL_FACILITY = "SELECT * "
                + " FROM FRS_FACILITYSITE WHERE "
                + FRS.FACILITYSITE.STATEFACILITYIDENTIFIER
                + " IN (WHERE_CLAUSE ) ORDER BY "
                + FRS.FACILITYSITE.FACILITYSITENAME + " ";

        public static final String SQL_ENV_INT_EPA = "SELECT * "
                + " FROM FRS_ENVIRONMENTALINTEREST WHERE FRSINDICATOR = 1 AND "
                + FRS.ENVIRONMENTALINTEREST.STATEFACILITYIDENTIFIER + " = ? ";

        public static final String SQL_ENV_INT_DOH = "SELECT * "
                + " FROM FRS_ENVIRONMENTALINTEREST WHERE DOHINDICATOR = 1 AND "
                + FRS.ENVIRONMENTALINTEREST.STATEFACILITYIDENTIFIER + " = ? ";

        public static final String SQL_GEO_COORD = "SELECT * "
                + " FROM FRS_GEOGRAPHICCOORDINATES WHERE "
                + FRS.GEOGRAPHICCOORDINATES.STATEFACILITYIDENTIFIER + " = ? ";

        public static final String SQL_INDIVIDUAL = "SELECT * "
                + " FROM FRS_INDIVIDUAL " + " WHERE "
                + FRS.INDIVIDUAL.STATEFACILITYIDENTIFIER + " = ? ";

        public static final String SQL_NAICS = "SELECT * "
                + " FROM FRS_NAICSCODE " + " WHERE "
                + FRS.NAICSCODE.STATEFACILITYIDENTIFIER + " = ? ";

        public static final String SQL_ORG = "SELECT * "
                + " FROM FRS_ORGANIZATION " + " WHERE "
                + FRS.ORGANIZATION.STATEFACILITYIDENTIFIER + " = ? ";

        public static final String SQL_SIC = "SELECT * FROM FRS_SICCODE "
                + " WHERE " + FRS.SICCODE.STATEFACILITYIDENTIFIER + " = ? ";

    }

    public Data(boolean isForEPA) {
        this.isForEPA = isForEPA;
    }

    private void makeEntry(ProcessContentResult result, String message) {
        logger.debug(message);
        result.getAuditEntries().add(new ActivityEntry(message));
    }

    public void getList(DataSource dataSource, String targetFilePath,
            DataRequest req, ProcessContentResult result, boolean makingHeader) {

        try {

            setDataSource(dataSource);

            conn = getDataSource().getConnection();

            if (isForEPA) {
                psEnvInterest = conn.prepareStatement(FRS.SQL_ENV_INT_EPA);
            } else {
                psEnvInterest = conn.prepareStatement(FRS.SQL_ENV_INT_DOH);
            }

            psGeoCoordinate = conn.prepareStatement(FRS.SQL_GEO_COORD);
            psIndividual = conn.prepareStatement(FRS.SQL_INDIVIDUAL);
            psNAICS = conn.prepareStatement(FRS.SQL_NAICS);
            psOrganization = conn.prepareStatement(FRS.SQL_ORG);
            psSICCode = conn.prepareStatement(FRS.SQL_SIC);

            makeEntry(result, "Creating file output stream...");
            out = new OutputStreamWriter(new BufferedOutputStream(
                    new FileOutputStream(targetFilePath), 1024 * 24), "UTF-8");

            String sql = FRS.SQL_FACILITY;
            String where = null;
            boolean idsOnly = false;

            makeEntry(result, "Parsing service strategy...");
            String methodName = req.getService().getName();
            logger.debug("service/method name: " + methodName);
            logger.debug("req.getParameters(): " + req.getParameters());
            logger.debug("req.getParameters().get(1): "
                    + req.getParameters().get(1));

            if (methodName.equalsIgnoreCase(SERVICE_CHANGEDATE)) {

                where = "SELECT fac."
                        + FRS.FACILITYSITE.STATEFACILITYIDENTIFIER
                        + " FROM FRS_FACILITYSITE fac JOIN FRS_ENVIRONMENTALINTEREST ei "
                        + " ON fac.STATEFACILITYIDENTIFIER = ei.STATEFACILITYIDENTIFIER "
                        + " WHERE fac." + FRS.FACILITYSITE.LASTREPORTEDDATE
                        + " >= '" + req.getParameters().get(1) + "' AND ";

                if (isForEPA) {
                    where += " ei.FRSINDICATOR = 1 ";
                } else {
                    where += " ei.DOHINDICATOR = 1 ";
                }

            } else if (methodName.equalsIgnoreCase(SERVICE_DELETED)) {
                sql = FRS.SQL_DELETED;
                where = FRS.DELETEDFACILITIES.DELETEDONDATE + " >= '"
                        + req.getParameters().get(1) + "' ";
                idsOnly = true;
            } else if (methodName.equalsIgnoreCase(SERVICE_NAME)) {
                where = "SELECT fac."
                        + FRS.FACILITYSITE.STATEFACILITYIDENTIFIER
                        + " FROM FRS_FACILITYSITE fac WHERE UPPER(fac.			"
                        + FRS.FACILITYSITE.FACILITYSITENAME + ") LIKE '%"
                        + req.getParameters().get(1).toString().toUpperCase()
                        + "%'";
            } else {
                throw new RuntimeException("Invalid service name: "
                        + methodName);
            }

            where = fixSql(where);
            sql = sql.replaceAll("WHERE_CLAUSE", where);

            logger.debug("SQL: " + sql);

            makeEntry(result, "Getting data from database...");
            ResultSet rs = conn.createStatement().executeQuery(sql);

            makeEntry(result, "Processing raw data...");
            int currentRowNum = 0;
            int rowId = req.getPaging().getStart();
            int maxRows = (req.getPaging().getCount() == -1) ? Integer.MAX_VALUE
                    : req.getPaging().getCount(); // All rows

            // Xml
            if (!makingHeader) {
                out.write("<?xml version=\"1.0\" ");
                out.write("encoding=\"UTF-8\"?>\n");
            }

            // Root Elements
            out
                    .write("<FacilitySiteList xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" ");
            out
                    .write("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ");
            out.write("xsi:schemaLocation=\"http://www.epa.gov/xml ");
            out
                    .write("http://www.epa.gov/enviro/html/frs_demo/presentations/version2.3/FACID_FacilitySiteAll_v2.3.xsd\" ");
            out
                    .write("schemaVersion=\"2.3\" xmlns=\"http://www.epa.gov/xml\">\n");

            while (rs.next()) {

                // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                // Paging
                // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                // Check for min row
                if (currentRowNum < rowId) {
                    currentRowNum++; // increment
                    continue; // - go next if it is
                }

                // check for max row - exit loop
                if (currentRowNum >= maxRows) {
                    break; // exit loop if it is
                }

                currentRowNum++;

                // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                // FacilitySiteAllDetails
                // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                // FacilitySiteAllDetails detail = new FacilitySiteAllDetails();
                out.write("<FacilitySiteAllDetails>\n");

                String stateID = rs
                        .getString(FRS.FACILITYSITE.STATEFACILITYIDENTIFIER);
                // logger.debug("ROW: [" + currentRowNum + "] - " + stateID);
                if ((currentRowNum % 1000) == 0)
                    logger.debug("NODE FRS PLUGIN: records processed: "
                            + currentRowNum);

                // if this is deleted query we are done, else some more work
                // to do
                if (!idsOnly) {

                    // +++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    // FacilitySite
                    // +++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    FacilitySite fac = new FacilitySite();
                    fac.FacilityRegistryIdentifier = rs
                            .getString(FRS.FACILITYSITE.FACILITYREGISTRYIDENTIFIER);
                    fac.FacilitySiteName = rs
                            .getString(FRS.FACILITYSITE.FACILITYSITENAME);
                    fac.FacilitySiteTypeName = rs
                            .getString(FRS.FACILITYSITE.FACILITYSITETYPENAME);
                    fac.FederalFacilityIndicator = rs
                            .getString(FRS.FACILITYSITE.FEDERALFACILITYINDICATOR);
                    fac.TribalLandIndicator = rs
                            .getString(FRS.FACILITYSITE.TRIBALLANDINDICATOR);
                    fac.TribalLandName = rs
                            .getString(FRS.FACILITYSITE.TRIBALLANDNAME);
                    fac.CongressionalDistrictNumber = rs
                            .getString(FRS.FACILITYSITE.CONGRESSIONALDISTRICTNUMBER);
                    fac.LegislativeDistrictNumber = rs
                            .getString(FRS.FACILITYSITE.LEGISLATIVEDISTRICTNUMBER);
                    fac.HUCCode = rs.getString(FRS.FACILITYSITE.HUCCODE);
                    out.write(fac.toXml());

                    // +++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    // Location Address
                    // +++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    LocationAddress loc = new LocationAddress();
                    loc.LocationAddressText = rs
                            .getString(FRS.FACILITYSITE.LOCATIONADDRESSTEXT);
                    loc.SupplementalLocationText = rs
                            .getString(FRS.FACILITYSITE.SUPPLEMENTALLOCATIONTEXT);
                    loc.LocalityName = rs
                            .getString(FRS.FACILITYSITE.LOCALITYNAME);
                    loc.CountyStateFIPSCode = rs
                            .getString(FRS.FACILITYSITE.COUNTYSTATEFIPSCODE);
                    loc.CountyName = rs.getString(FRS.FACILITYSITE.COUNTYNAME);
                    loc.StateUSPSCode = rs
                            .getString(FRS.FACILITYSITE.STATEUSPSCODE);
                    loc.StateName = rs.getString(FRS.FACILITYSITE.STATENAME);
                    loc.CountryName = rs
                            .getString(FRS.FACILITYSITE.COUNTRYNAME);
                    loc.LocationZIPCode = rs
                            .getString(FRS.FACILITYSITE.LOCATIONZIPCODE);
                    loc.LocationDescriptionText = rs
                            .getString(FRS.FACILITYSITE.LOCATIONDESCRIPTIONTEXT);
                    out.write(loc.toXml());

                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    // Enviornmental Intrest Details
                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    getEnvironmentalInterestDetails(stateID);

                    // +++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    // Alternative Name
                    // +++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    // Create the MailingAddressDetails
                    AlternativeNameInfo alt = new AlternativeNameInfo();
                    alt.AlternativeName = rs
                            .getString(FRS.FACILITYSITE.ALTERNATIVENAME);
                    alt.AlternativeNameTypeText = rs
                            .getString(FRS.FACILITYSITE.ALTERNATIVENAMETYPETEXT);
                    // add to the list
                    out.write(alt.toXml());

                    // +++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    // Mailing Address
                    // +++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    MailingAddress mail = new MailingAddress();
                    mail.MailingAddressText = rs
                            .getString(FRS.FACILITYSITE.MAILINGADDRESSTEXT);
                    mail.SupplementalAddressText = rs
                            .getString(FRS.FACILITYSITE.SUPPLEMENTALADDRESSTEXT);
                    mail.MailingAddressCityName = rs
                            .getString(FRS.FACILITYSITE.MAILINGADDRESSCITYNAME);
                    mail.MailingAddressStateUSPSCode = rs
                            .getString(FRS.FACILITYSITE.MAILINGADDRESSSTATEUSPSCODE);
                    mail.MailingAddressStateName = rs
                            .getString(FRS.FACILITYSITE.MAILINGADDRESSSTATENAME);
                    mail.MailingAddressCountryName = rs
                            .getString(FRS.FACILITYSITE.MAILINGADDRESSCOUNTRYNAME);
                    mail.MailingAddressZIPCode = rs
                            .getString(FRS.FACILITYSITE.MAILINGADDRESSZIPCODE);
                    // add to the list
                    out.write(mail.toXml());

                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    // SIC Code Details
                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    getSICCodeDetails(stateID);

                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    // NAICS Code Details
                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    getNAICSCodeDetails(stateID);

                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    // Individual Details
                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    getIndividualDetails(stateID);

                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    // Organization Details
                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    getOrganizationDetails(stateID);

                    // +++++++++++++++++++++++++++++++++++++++++++++++++++++++result.getAuditEntries().add(new
                    // ActivityEntry("Closing file..."));+++++++++++++
                    // GeographicCoordinate Details
                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    getGeographicCoordinateDetails(stateID);

                    // Root Elements
                    out.write(ElementUtil.getElement("SourceOfData", "FIS"));
                    out.write(ElementUtil.getElement("LastReportedDate", rs
                            .getString(FRS.FACILITYSITE.LASTREPORTEDDATE)));
                    out
                            .write(ElementUtil
                                    .getElement(
                                            "StateFacilitySystemAcronymName",
                                            rs
                                                    .getString(FRS.FACILITYSITE.STATEFACILITYSYSTEMACRONYMNAME)));
                    out
                            .write(ElementUtil
                                    .getElement(
                                            "StateFacilityIdentifier",
                                            rs
                                                    .getString(FRS.FACILITYSITE.STATEFACILITYIDENTIFIER)));

                } else { // end of deleted check
                    // Root Elements
                    out.write(ElementUtil.getElement("LastReportedDate", rs
                            .getString(FRS.DELETEDFACILITIES.DELETEDONDATE)));
                    out.write(ElementUtil.getElement(
                            "StateFacilitySystemAcronymName", "FIS"));
                    out
                            .write(ElementUtil
                                    .getElement(
                                            "StateFacilityIdentifier",
                                            rs
                                                    .getString(FRS.FACILITYSITE.STATEFACILITYIDENTIFIER)));

                }

                // Add details to the list
                out.write("</FacilitySiteAllDetails>");

            } // end while

            // Closing the root element
            out.write("</FacilitySiteList>");
            out.close();

            makeEntry(result, "Facility count: " + currentRowNum);

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

    private void getGeographicCoordinateDetails(String facID) throws Exception {

        psGeoCoordinate.setString(1, facID);
        ResultSet rs = psGeoCoordinate.executeQuery();

        // For each row in DB
        while (rs.next()) {

            // Create the GeographicCoordinateDataType
            GeographicCoordinates geo = new GeographicCoordinates();

            geo.LatitudeMeasure = rs
                    .getString(FRS.GEOGRAPHICCOORDINATES.LATITUDEMEASURE);
            geo.LongitudeMeasure = rs
                    .getString(FRS.GEOGRAPHICCOORDINATES.LONGITUDEMEASURE);

            geo.HorizontalAccuracyMeasure = rs
                    .getString(FRS.GEOGRAPHICCOORDINATES.HORIZONTALACCURACYMEASURE);
            geo.HorizontalCollectionMethodText = rs
                    .getString(FRS.GEOGRAPHICCOORDINATES.HORIZONTALCOLLECTIONMETHODTEXT);
            geo.HorizontalReferenceDatumName = rs
                    .getString(FRS.GEOGRAPHICCOORDINATES.HORIZONTALREFERENCEDATUMNAME);
            geo.SourceMapScaleNumber = rs
                    .getString(FRS.GEOGRAPHICCOORDINATES.SOURCEMAPSCALENUMBER);
            geo.ReferencePointText = rs
                    .getString(FRS.GEOGRAPHICCOORDINATES.REFERENCEPOINTTEXT);
            geo.DataCollectionDate = rs
                    .getString(FRS.GEOGRAPHICCOORDINATES.DATACOLLECTIONDATE);
            geo.GeometricTypeName = rs
                    .getString(FRS.GEOGRAPHICCOORDINATES.GEOMETRICTYPENAME);
            geo.LocationCommentsText = rs
                    .getString(FRS.GEOGRAPHICCOORDINATES.LOCATIONCOMMENTSTEXT);
            geo.VerticalCollectionMethodText = rs
                    .getString(FRS.GEOGRAPHICCOORDINATES.VERTICALCOLLECTIONMETHODTEXT);
            geo.VerticalMeasure = rs
                    .getString(FRS.GEOGRAPHICCOORDINATES.VERTICALMEASURE);
            geo.VerticalAccuracyMeasure = rs
                    .getString(FRS.GEOGRAPHICCOORDINATES.VERTICALACCURACYMEASURE);
            geo.VerticalReferenceDatumName = rs
                    .getString(FRS.GEOGRAPHICCOORDINATES.VERTICALREFERENCEDATUMNAME);
            geo.DataSourceName = rs
                    .getString(FRS.GEOGRAPHICCOORDINATES.DATASOURCENAME);
            geo.CoordinateDataSourceName = rs
                    .getString(FRS.GEOGRAPHICCOORDINATES.COORDINATEDATASOURCENAME);
            geo.SubEntityIdentifier = rs
                    .getString(FRS.GEOGRAPHICCOORDINATES.SUBENTITYIDENTIFIER);
            geo.SubEntityTypeName = rs
                    .getString(FRS.GEOGRAPHICCOORDINATES.SUBENTITYTYPENAME);
            // Add the GeographicCoordinateDataType to the list
            out.write(geo.toXml());
        }

        // Cleanup
        rs.close();

    }

    private void getOrganizationDetails(String facID) throws Exception {

        psOrganization.setString(1, facID);
        ResultSet rs = psOrganization.executeQuery();

        // For each row in DB
        while (rs.next()) {

            out.write("<OrganizationDetails>");

            // Affiliation
            Affiliation aff = new Affiliation();
            aff.AffiliationTypeText = rs
                    .getString(FRS.ORGANIZATION.AFFILIATIONTYPETEXT);
            aff.AffiliationStartDate = rs
                    .getString(FRS.ORGANIZATION.AFFILIATIONSTARTDATE);
            aff.AffiliationEndDate = rs
                    .getString(FRS.ORGANIZATION.AFFILIATIONENDDATE);
            out.write(aff.toXml());

            // PhoneFaxEmailDataType
            PhoneFaxEmail ph = new PhoneFaxEmail();
            ph.EmailAddressText = rs
                    .getString(FRS.ORGANIZATION.EMAILADDRESSTEXT);
            ph.TelephoneNumber = rs.getString(FRS.ORGANIZATION.TELEPHONENUMBER);
            ph.PhoneExtension = rs.getString(FRS.ORGANIZATION.PHONEEXTENSION);
            ph.FaxNumber = rs.getString(FRS.ORGANIZATION.FAXNUMBER);
            ph.AlternateTelephoneNumber = rs
                    .getString(FRS.ORGANIZATION.ALTERNATETELEPHONENUMBER);
            out.write(ph.toXml());

            // IndividualDataType
            Organization orgdt = new Organization();
            orgdt.OrganizationFormalName = rs
                    .getString(FRS.ORGANIZATION.ORGANIZATIONFORMALNAME);
            orgdt.OrganizationDUNSNumber = rs
                    .getString(FRS.ORGANIZATION.ORGANIZATIONDUNSNUMBER);
            orgdt.OrganizationTypeText = rs
                    .getString(FRS.ORGANIZATION.ORGANIZATIONTYPETEXT);
            orgdt.StateBusinessIdentifier = rs
                    .getString(FRS.ORGANIZATION.STATEBUSINESSIDENTIFIER);
            orgdt.UltimateParentName = rs
                    .getString(FRS.ORGANIZATION.ULTIMATEPARENTNAME);
            orgdt.UltimateParentDUNSNumber = rs
                    .getString(FRS.ORGANIZATION.ULTIMATEPARENTDUNSNUMBER);
            out.write(orgdt.toXml());

            // MailingAddressDataType
            MailingAddress mail = new MailingAddress();
            mail.MailingAddressText = rs
                    .getString(FRS.ORGANIZATION.MAILINGADDRESSTEXT);
            mail.SupplementalAddressText = rs
                    .getString(FRS.ORGANIZATION.SUPPLEMENTALADDRESSTEXT);
            mail.MailingAddressCityName = rs
                    .getString(FRS.ORGANIZATION.MAILINGADDRESSCITYNAME);
            mail.MailingAddressStateUSPSCode = rs
                    .getString(FRS.ORGANIZATION.MAILINGADDRESSSTATEUSPSCODE);
            mail.MailingAddressStateName = rs
                    .getString(FRS.ORGANIZATION.MAILINGADDRESSSTATENAME);
            mail.MailingAddressCountryName = rs
                    .getString(FRS.ORGANIZATION.MAILINGADDRESSCOUNTRYNAME);
            mail.MailingAddressZIPCode = rs
                    .getString(FRS.ORGANIZATION.MAILINGADDRESSZIPCODE);
            out.write(mail.toXml());

            out.write("</OrganizationDetails>");

        }

        // Cleanup
        rs.close();

    }

    private void getIndividualDetails(String facID) throws Exception {

        psIndividual.setString(1, facID);
        ResultSet rs = psIndividual.executeQuery();

        // For each row in DB
        while (rs.next()) {

            out.write("<IndividualDetails>");

            // Affiliation
            Affiliation aff = new Affiliation();
            aff.AffiliationTypeText = rs
                    .getString(FRS.INDIVIDUAL.AFFILIATIONTYPETEXT);
            aff.AffiliationStartDate = rs
                    .getString(FRS.INDIVIDUAL.AFFILIATIONSTARTDATE);
            aff.AffiliationEndDate = rs
                    .getString(FRS.INDIVIDUAL.AFFILIATIONENDDATE);
            out.write(aff.toXml());

            // PhoneFaxEmailDataType
            PhoneFaxEmail ph = new PhoneFaxEmail();
            ph.EmailAddressText = rs.getString(FRS.INDIVIDUAL.EMAILADDRESSTEXT);
            ph.TelephoneNumber = rs.getString(FRS.INDIVIDUAL.TELEPHONENUMBER);
            ph.PhoneExtension = rs.getString(FRS.INDIVIDUAL.PHONEEXTENSION);
            ph.FaxNumber = rs.getString(FRS.INDIVIDUAL.FAXNUMBER);
            ph.AlternateTelephoneNumber = rs
                    .getString(FRS.INDIVIDUAL.ALTERNATETELEPHONENUMBER);
            out.write(ph.toXml());

            // IndividualDataType
            Individual indv = new Individual();
            indv.IndividualFullName = rs
                    .getString(FRS.INDIVIDUAL.INDIVIDUALFULLNAME);
            indv.IndividualTitleText = rs
                    .getString(FRS.INDIVIDUAL.INDIVIDUALTITLETEXT);
            out.write(indv.toXml());

            // MailingAddressDataType
            MailingAddress mail = new MailingAddress();
            mail.MailingAddressText = rs
                    .getString(FRS.INDIVIDUAL.MAILINGADDRESSTEXT);
            mail.SupplementalAddressText = rs
                    .getString(FRS.INDIVIDUAL.SUPPLEMENTALADDRESSTEXT);
            mail.MailingAddressCityName = rs
                    .getString(FRS.INDIVIDUAL.MAILINGADDRESSCITYNAME);
            mail.MailingAddressStateUSPSCode = rs
                    .getString(FRS.INDIVIDUAL.MAILINGADDRESSSTATEUSPSCODE);
            mail.MailingAddressStateName = rs
                    .getString(FRS.INDIVIDUAL.MAILINGADDRESSSTATENAME);
            mail.MailingAddressCountryName = rs
                    .getString(FRS.INDIVIDUAL.MAILINGADDRESSCOUNTRYNAME);
            mail.MailingAddressZIPCode = rs
                    .getString(FRS.INDIVIDUAL.MAILINGADDRESSZIPCODE);
            out.write(mail.toXml());

            out.write("</IndividualDetails>");

        }

        // Cleanup
        rs.close();

    }

    private void getNAICSCodeDetails(String facID) throws Exception {

        psNAICS.setString(1, facID);
        ResultSet rs = psNAICS.executeQuery();

        // For each row in DB
        while (rs.next()) {

            // Create the NAICSCodeDetails
            NAICSCodeDetails naics = new NAICSCodeDetails();
            naics.NAICSCode = rs.getString(FRS.NAICSCODE.NAICSCODE);
            naics.NAICSPrimaryIndicator = rs
                    .getString(FRS.NAICSCODE.NAICSPRIMARYINDICATOR);
            // Add the NAICSCodeDetails to the list
            out.write(naics.toXml());

        }

        // Cleanup
        rs.close();

    }

    private void getSICCodeDetails(String facID) throws Exception {

        psSICCode.setString(1, facID);
        ResultSet rs = psSICCode.executeQuery();

        // For each row in DB
        while (rs.next()) {

            // Create the SICCodeDetails
            SICCodeDetails sic = new SICCodeDetails();
            sic.SICCode = rs.getString(FRS.SICCODE.SICCODE);
            sic.SICPrimaryIndicator = rs
                    .getString(FRS.SICCODE.SICPRIMARYINDICATOR);

            // Add the SICCodeDetails to the list
            out.write(sic.toXml());

        }

        // Cleanup
        rs.close();

    }

    // private EnvironmentalInterestDetails[]
    // getEnvironmentalInterestDetails(String facID)
    private void getEnvironmentalInterestDetails(String facID) throws Exception {

        psEnvInterest.setString(1, facID);
        ResultSet rs = psEnvInterest.executeQuery();

        // For each row in DB
        while (rs.next()) {

            // Create the EnvironmentalInterestDetails
            EnvironmentalInterestDetails ei = new EnvironmentalInterestDetails();

            ei.InformationSystemAcronymName = rs
                    .getString(FRS.ENVIRONMENTALINTEREST.INFORMATIONSYSTEMACRONYMNAME);
            ei.InformationSystemIdentifier = rs
                    .getString(FRS.ENVIRONMENTALINTEREST.INFORMATIONSYSTEMIDENTIFIER);
            ei.EnvironmentalInterestTypeText = rs
                    .getString(FRS.ENVIRONMENTALINTEREST.ENVIRONMENTALINTERESTTYPETEXT);
            ei.FederalStateInterestIndicator = rs
                    .getString(FRS.ENVIRONMENTALINTEREST.FEDERALSTATEINTERESTINDICATOR);
            ei.EnvironmentalInterestStartDate = rs
                    .getString(FRS.ENVIRONMENTALINTEREST.ENVIRONMENTALINTERESTSTARTDATE);
            ei.InterestStartDateQualifierText = rs
                    .getString(FRS.ENVIRONMENTALINTEREST.INTERESTSTARTDATEQUALIFIERTEXT);
            ei.EnvironmentalInterestEndDate = rs
                    .getString(FRS.ENVIRONMENTALINTEREST.ENVIRONMENTALINTERESTENDDATE);
            ei.InterestEndDateQualifierText = rs
                    .getString(FRS.ENVIRONMENTALINTEREST.INTERESTENDDATEQUALIFIERTEXT);

            // Add the EnvironmentalInterestDetails to the list
            out.write(ei.toXml());

        }

        rs.close();
    }

    protected static String fixSql(String input) {
        if (input == null)
            return null;

        String output = input;
        output = output.replace('\n', ' ');
        output = output.replace('\t', ' ');
        output = output.replace('\r', ' ');
        return output;
    }

    public Logger getLogger() {
        return logger;
    }

    public void setLogger(Logger logger) {
        this.logger = logger;
    }

}
