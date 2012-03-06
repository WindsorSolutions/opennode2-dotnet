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

/**
 * 
 */
package com.windsor.node.plugin.aqs;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PaginationIndicator;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.HeaderDocumentHelper;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.service.helper.RemoteFileResourceHelper;

/**
 * @author mchmarny
 * 
 */
public class DrDasProxyService extends BaseWnosPlugin {

    public static final String SRV_MONITOR = "AQDEMonitorData";
    public static final String SRV_RAW = "AQDERawData";

    public static final String ARG_ENDPOINT_URL = "Reporter Url";
    public static final String ARG_HD_SCHEMA_VERSION = "Schema Version";

    public static final PluginServiceParameterDescriptor FILE_GENERATION_PURPOSE_CODE = new PluginServiceParameterDescriptor(
                    "FileGenerationPurposeCode", PluginServiceParameterDescriptor.TYPE_STRING, Boolean.TRUE,
                    "Reason for request. Must be either \"AQS\", \"AIRNOW\", or \"OTHER\".");
    public static final PluginServiceParameterDescriptor BEGIN_DATE = new PluginServiceParameterDescriptor("BeginDate",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.TRUE,
                    "Used to indicate the starting date for which data collection activities should be retrieved. This will be in the YYYYMMDD format.");
    public static final PluginServiceParameterDescriptor BEGIN_TIME = new PluginServiceParameterDescriptor(
                    "BeginTime",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "Used to indicate the starting time (for the supplied Start Date) for which data collection activities should be retrieved. This will be in the HH:MM format. Defaults to midnight (time 00:00, the beginning of the day) if left blank.");
    public static final PluginServiceParameterDescriptor END_DATE = new PluginServiceParameterDescriptor("EndDate",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.TRUE,
                    "Used to indicate the ending date for which data collection activities should be retrieved.  This will be in the YYYYMMDD format.");
    public static final PluginServiceParameterDescriptor END_TIME = new PluginServiceParameterDescriptor(
                    "EndTime",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "Used to indicate the ending time (for the supplied End Date) for which data collection activities should be retrieved. This will be in the HH:MM format. Defaults to the end of the day (time 23:59) if left blank.");
    public static final PluginServiceParameterDescriptor TIME_TYPE = new PluginServiceParameterDescriptor(
                    "TimeType",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "Specifies that both query and return times will be either in \"Local\" (to the monitor) or \"GMT\" time.  Defaults to Local if null.  (This is not included in the AQDE flow)");
    public static final PluginServiceParameterDescriptor SAMPLE_DURATION = new PluginServiceParameterDescriptor("SampleDuration",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE,
                    "Must be either \"HOURLY\" or \"MINUTE\". DEC will provide only 60 minute readings so will always be set to HOURLY.");
    public static final PluginServiceParameterDescriptor SUBSTANCE_NAME = new PluginServiceParameterDescriptor(
                    "SubstanceName",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "Comma separated listing of substances (including air quality or meteorological). If left blank, then requesting all parameters.  This data exchange will use parameter codes that have already been defined by AQS.");
    public static final PluginServiceParameterDescriptor MONITOR_TYPE = new PluginServiceParameterDescriptor(
                    "MonitorType",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "This parameter designates the monitoring network from which to retrieve data.  Examples are SLAMS and NAMS.  (Null returns data from all networks).");
    public static final PluginServiceParameterDescriptor DATA_VALIDITY_CODE = new PluginServiceParameterDescriptor(
                    "DataValidityCode",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "Indicator used to filter out only data that is considered Valid based on the data provider's assessment of the air quality data.  If left blank, return assumes \"A\".  Possible values include: V: returns only valid data, A: Returns all data");
    public static final PluginServiceParameterDescriptor DATA_APPROVAL_INDICATOR = new PluginServiceParameterDescriptor(
                    "DataApprovalIndicator",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "Indicates (Y/N) whether the state has approved this raw data result for regulatory purposes or data analysis, usually as a result of additional quality control review procedures. If left blank, assumes \"N\". Y: Only return data that has been approved by the state to be used for regulatory review, N: Includes both data that has been approved and not approved");
    public static final PluginServiceParameterDescriptor STATE_NAME = new PluginServiceParameterDescriptor(
                    "StateName",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "State code defined by AQS. If SiteIdentifer is provided, State is required (SiteIdentifer is only unique within a county, and CountyCode is only unique within a state).");
    public static final PluginServiceParameterDescriptor COUNTY_NAME = new PluginServiceParameterDescriptor("CountyName",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE,
                    "County code defined by AQS. If SiteIdentifer is provided, CountyCode is required (SiteIdentifer is only unique within a county).");
    public static final PluginServiceParameterDescriptor CITY_NAME = new PluginServiceParameterDescriptor("CityName",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE,
                    "City name.  If included, the array must also include the state.");
    public static final PluginServiceParameterDescriptor TRIBE_NAME = new PluginServiceParameterDescriptor("TribeName",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE, "Tribe Name.");
    public static final PluginServiceParameterDescriptor FACILITY_SITE_IDENTIFIER = new PluginServiceParameterDescriptor(
                    "FacilitySiteIdentifier", PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE,
                    "Comma separated listing of desired Site identifiers, as defined by AQS. If blank, return all for the state.");
    public static final PluginServiceParameterDescriptor MIN_LATITUDE_MEASURE = new PluginServiceParameterDescriptor("MinLatitudeMeasure",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE,
                    "Minimum latitude measure, in decimal degrees, from which to return raw data. If blank, return all for the state");
    public static final PluginServiceParameterDescriptor MAX_LATITUDE_MEASURE = new PluginServiceParameterDescriptor("MaxLatitudeMeasure",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE,
                    "Maximum latitude measure, in decimal degrees, from which to return raw data. If blank, return all for the state");
    public static final PluginServiceParameterDescriptor MIN_LONGITUDE_MEASURE = new PluginServiceParameterDescriptor(
                    "MinLongitudeMeasure",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "Minimum longitude measure (i.e. Western border), in decimal degrees, from which to return raw data. If blank, return all for the state.  The standard will be to include negative values.");
    public static final PluginServiceParameterDescriptor MAX_LONGITUDE_MEASURE = new PluginServiceParameterDescriptor(
                    "MaxLongitudeMeasure",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "Maximum longitude measure (i.e. Eastern border), in decimal degrees, from which to return raw data. If blank, return all for the state.  The standard will be to include negative values.");
    public static final PluginServiceParameterDescriptor LAST_UPDATE_DATE = new PluginServiceParameterDescriptor("LastUpdatedDate",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE,
                    "Returns all data that has been updated since the supplied date. If blank, return all data over the date range supplied above.");
    public static final PluginServiceParameterDescriptor INCLUDE_MONITOR_DETAILS = new PluginServiceParameterDescriptor(
                    "IncludeMonitorDetails",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "If set to \"Y\", the state will be requested to retrieve additional metadata about the site and monitor. If set to \"N\", state should only supply site and monitor ID information. If blank, assume \"Y\"");
    public static final PluginServiceParameterDescriptor INCLUDE_EVENT_DATA = new PluginServiceParameterDescriptor(
                    "IncludeEventData",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "Valid values \"TRUE\" and \"FALSE\".  If TRUE, then the output file will include measurements effected by an \"exceptional event\" such as a volcano or forest fire.  Defaults to FALSE.");
    public static final PluginServiceParameterDescriptor SCHEMA_VERSION = new PluginServiceParameterDescriptor("SchemaVersion",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.TRUE,
                    "The version of the schema to be used to organize the returned data.  Used internally to DEC only and set by the Plug In.");

    public DrDasProxyService() {

        super();

        debug("Setting internal runtime argument list");

        getConfigurationArguments().put(ARG_ENDPOINT_URL, "");
        getConfigurationArguments().put(ARG_HD_SCHEMA_VERSION, "");

        getSupportedPluginTypes().add(ServiceType.QUERY);
        getSupportedPluginTypes().add(ServiceType.SOLICIT);
        getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT);

        debug("Plugin initialized");

    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        List<PluginServiceParameterDescriptor> params = new ArrayList<PluginServiceParameterDescriptor>();
        params.add(FILE_GENERATION_PURPOSE_CODE);
        params.add(BEGIN_DATE);
        params.add(BEGIN_TIME);
        params.add(END_DATE);
        params.add(END_TIME);
        params.add(TIME_TYPE);
        params.add(SAMPLE_DURATION);
        params.add(SUBSTANCE_NAME);
        params.add(MONITOR_TYPE);
        params.add(DATA_VALIDITY_CODE);
        params.add(DATA_APPROVAL_INDICATOR);
        params.add(STATE_NAME);
        params.add(COUNTY_NAME);
        params.add(CITY_NAME);
        params.add(TRIBE_NAME);
        params.add(FACILITY_SITE_IDENTIFIER);
        params.add(MIN_LATITUDE_MEASURE);
        params.add(MAX_LATITUDE_MEASURE);
        params.add(MIN_LONGITUDE_MEASURE);
        params.add(MAX_LONGITUDE_MEASURE);
        params.add(LAST_UPDATE_DATE);
        params.add(INCLUDE_MONITOR_DETAILS);
        params.add(INCLUDE_EVENT_DATA);
        params.add(SCHEMA_VERSION);
        return params;
    }

    /**
     * will be called by the plugin executor after properties are set. an
     * opportunity to validate all settings
     */
    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        debug("Validating runtime args");

        // make sure the run time args are set
        if (getConfigurationArguments() == null) {
            throw new RuntimeException("Data sources not set");
        }

        // make sure the ARG_ENDPOINT_URL arg is set set
        if (!getConfigurationArguments().containsKey(ARG_ENDPOINT_URL)) {
            throw new RuntimeException(ARG_ENDPOINT_URL + " not set");
        }

        debug("Plugin validated");

    }

    /**
     * processlogger.debug
     */
    public ProcessContentResult process(NodeTransaction transaction) {

        debug("Processing transaction...");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);

        try {

            result.getAuditEntries()
                    .add(makeEntry("Validating transaction..."));

            validateTransaction(transaction);

            IdGenerator idGenerator = (IdGenerator) getServiceFactory()
                    .makeService(IdGenerator.class);

            if (idGenerator == null) {
                throw new RuntimeException("Unable to obtain IdGenerator");
            }

            HeaderDocumentHelper headerHelper = (HeaderDocumentHelper) getServiceFactory()
                    .makeService(HeaderDocumentHelper.class);

            if (headerHelper == null) {
                throw new RuntimeException(
                        "Unable to obtain HeaderDocumentHelper");
            }

            RemoteFileResourceHelper webHelper = (RemoteFileResourceHelper) getServiceFactory()
                    .makeService(RemoteFileResourceHelper.class);

            if (webHelper == null) {
                throw new RuntimeException(
                        "Unable to obtain RemoteFileResourceHelper");
            }

            /*
             * 
             * ARGS
             */
            result.getAuditEntries().add(makeEntry("Acquiring arguments..."));

            String reporterServiceUrl = getRequiredConfigValueAsString(ARG_ENDPOINT_URL);
            String reporterSchemaVersion = getRequiredConfigValueAsString(ARG_HD_SCHEMA_VERSION);

            Map<String, Object> properties = new HashMap<String, Object>();
            properties.put("schemaVersion", reporterSchemaVersion);

            result.getAuditEntries().add(
                    makeEntry("Configuring reporter client using: "
                            + reporterServiceUrl));

            DrDasServiceHelper srv = new DrDasServiceHelper(reporterServiceUrl,
                    transaction.getRequest().getParameters(),
                    reporterSchemaVersion);

            result.getAuditEntries().add(
                    makeEntry("Getting requested service name..."));

            String methodName = transaction.getRequest().getService().getName();

            result.getAuditEntries().add(makeEntry("Parsing execution strategy from: " + methodName));

            byte[] resultsBytes = null;

            if (methodName.equalsIgnoreCase(SRV_MONITOR)) {

                result.getAuditEntries().add(
                        makeEntry("Executing Monitor Data service using: "
                                + transaction.getRequest().getParameters()
                                + " and SchemaVersion: "
                                + reporterSchemaVersion));

                resultsBytes = srv.executeMonitorData();

            } else if (methodName.equalsIgnoreCase(SRV_RAW)) {

                result.getAuditEntries().add(
                        makeEntry("Executing Raw Data service using: "
                                + transaction.getRequest().getParameters()
                                + " and SchemaVersion: "
                                + reporterSchemaVersion));

                String resultFile = srv.executeRawData(idGenerator.createId());

                result.getAuditEntries().add(
                        makeEntry("Reading remote result: " + resultFile));

                resultsBytes = webHelper.getBytesFromURL(resultFile);

                String tempXml = new String(resultsBytes);
                resultsBytes = tempXml.getBytes("UTF-8");

            } else {
                throw new RuntimeException(
                        "Invalid parameter: Method Name is not supported ("
                                + methodName + ").");
            }

            result.getAuditEntries().add(
                    makeEntry("Testing for compression: "
                            + transaction.getRequest().getType()));

            Document doc = new Document();
            result.getAuditEntries().add(makeEntry("Creating document..."));

            if (transaction.getRequest().getType() != RequestType.QUERY) {

                result.getAuditEntries().add(
                        makeEntry("Compressing results..."));

                CompressionService compressionService = (CompressionService) getServiceFactory()
                        .makeService(CompressionService.class);

                doc.setType(CommonContentType.ZIP);
                doc.setDocumentName("AQS-" + methodName + ".zip");
                doc.setContent(compressionService.zip(resultsBytes, "AQS-"
                        + methodName + ".xml"));

            } else {
                doc.setType(CommonContentType.XML);
                doc.setDocumentName("AQS-" + methodName + ".xml");
                doc.setContent(resultsBytes);
            }

            result.getAuditEntries().add(makeEntry("Setting result..."));

            result.setPaginatedContentIndicator(new PaginationIndicator(
                    transaction.getRequest().getPaging().getStart(),
                    transaction.getRequest().getPaging().getCount(), true));

            result.getDocuments().add(doc);

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Processed);
            result.getAuditEntries().add(makeEntry("Done: OK"));

        } catch (Throwable ex) {

            error(ex.getMessage(), ex);
            error(ex.getMessage());

            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.Failed);

            result.getAuditEntries().add(
                    makeEntry("Error while executing: "
                            + this.getClass().getName() + " Message: "
                            + ex.getMessage()));

        }

        return result;
    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.plugin.BaseWnosPlugin#getServiceRequestParamSpecs(java
     * .lang.String)
     */
    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName) {

        List<DataServiceRequestParameter> list = new ArrayList<DataServiceRequestParameter>();

        Integer sortIndex = 0;

        if (serviceName.equalsIgnoreCase(SRV_MONITOR)) {

            for (MonitorDataArgType arg : MonitorDataArgType.values()) {

                DataServiceRequestParameter param = new DataServiceRequestParameter();
                param.setName(arg.toString());
                param.setSortIndex(sortIndex);

                list.add(param);

                sortIndex++;
            }

        } else if (serviceName.equalsIgnoreCase(SRV_RAW)) {

            for (RawDataArgType arg : RawDataArgType.values()) {

                DataServiceRequestParameter param = new DataServiceRequestParameter();
                param.setName(arg.toString());
                param.setSortIndex(sortIndex);

                list.add(param);

                sortIndex++;
            }

        } else {

            list = null;
        }

        return list;
    }
}
