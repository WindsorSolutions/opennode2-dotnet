/*     */ package com.windsor.node.plugin.aqs;
/*     */ 
/*     */ import com.windsor.node.common.domain.CommonContentType;
/*     */ import com.windsor.node.common.domain.CommonTransactionStatusCode;
/*     */ import com.windsor.node.common.domain.DataRequest;
/*     */ import com.windsor.node.common.domain.DataService;
/*     */ import com.windsor.node.common.domain.DataServiceRequestParameter;
/*     */ import com.windsor.node.common.domain.Document;
/*     */ import com.windsor.node.common.domain.NodeTransaction;
/*     */ import com.windsor.node.common.domain.PaginationIndicator;
/*     */ import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
/*     */ import com.windsor.node.common.domain.ProcessContentResult;
/*     */ import com.windsor.node.common.domain.RequestType;
/*     */ import com.windsor.node.common.domain.ServiceType;
/*     */ import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
/*     */ import com.windsor.node.plugin.BaseWnosPlugin;
/*     */ import com.windsor.node.service.helper.CompressionService;
/*     */ import com.windsor.node.service.helper.HeaderDocumentHelper;
/*     */ import com.windsor.node.service.helper.IdGenerator;
/*     */ import com.windsor.node.service.helper.RemoteFileResourceHelper;
/*     */ import com.windsor.node.service.helper.ServiceFactory;
/*     */ import java.util.ArrayList;
/*     */ import java.util.HashMap;
/*     */ import java.util.List;
/*     */ import java.util.Map;
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ public class DrDasProxyService
/*     */   extends BaseWnosPlugin
/*     */ {
/*     */   public static final String SRV_MONITOR = "AQDEMonitorData";
/*     */   public static final String SRV_RAW = "AQDERawData";
/*     */   public static final String ARG_ENDPOINT_URL = "Reporter Url";
/*     */   public static final String ARG_HD_SCHEMA_VERSION = "Schema Version";
/*  71 */   public static final PluginServiceParameterDescriptor FILE_GENERATION_PURPOSE_CODE = new PluginServiceParameterDescriptor("FileGenerationPurposeCode", "java.lang.String", Boolean.TRUE, "Reason for request. Must be either \"AQS\", \"AIRNOW\", or \"OTHER\".");
/*     */   
/*     */ 
/*  74 */   public static final PluginServiceParameterDescriptor BEGIN_DATE = new PluginServiceParameterDescriptor("BeginDate", "java.lang.String", Boolean.TRUE, "Used to indicate the starting date for which data collection activities should be retrieved. This will be in the YYYYMMDD format.");
/*     */   
/*     */ 
/*  77 */   public static final PluginServiceParameterDescriptor BEGIN_TIME = new PluginServiceParameterDescriptor("BeginTime", "java.lang.String", Boolean.FALSE, "Used to indicate the starting time (for the supplied Start Date) for which data collection activities should be retrieved. This will be in the HH:MM format. Defaults to midnight (time 00:00, the beginning of the day) if left blank.");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*  82 */   public static final PluginServiceParameterDescriptor END_DATE = new PluginServiceParameterDescriptor("EndDate", "java.lang.String", Boolean.TRUE, "Used to indicate the ending date for which data collection activities should be retrieved.  This will be in the YYYYMMDD format.");
/*     */   
/*     */ 
/*  85 */   public static final PluginServiceParameterDescriptor END_TIME = new PluginServiceParameterDescriptor("EndTime", "java.lang.String", Boolean.FALSE, "Used to indicate the ending time (for the supplied End Date) for which data collection activities should be retrieved. This will be in the HH:MM format. Defaults to the end of the day (time 23:59) if left blank.");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*  90 */   public static final PluginServiceParameterDescriptor TIME_TYPE = new PluginServiceParameterDescriptor("TimeType", "java.lang.String", Boolean.FALSE, "Specifies that both query and return times will be either in \"Local\" (to the monitor) or \"GMT\" time.  Defaults to Local if null.  (This is not included in the AQDE flow)");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*  95 */   public static final PluginServiceParameterDescriptor SAMPLE_DURATION = new PluginServiceParameterDescriptor("SampleDuration", "java.lang.String", Boolean.FALSE, "Must be either \"HOURLY\" or \"MINUTE\". DEC will provide only 60 minute readings so will always be set to HOURLY.");
/*     */   
/*     */ 
/*  98 */   public static final PluginServiceParameterDescriptor SUBSTANCE_NAME = new PluginServiceParameterDescriptor("SubstanceName", "java.lang.String", Boolean.FALSE, "Comma separated listing of substances (including air quality or meteorological). If left blank, then requesting all parameters.  This data exchange will use parameter codes that have already been defined by AQS.");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/* 103 */   public static final PluginServiceParameterDescriptor MONITOR_TYPE = new PluginServiceParameterDescriptor("MonitorType", "java.lang.String", Boolean.FALSE, "This parameter designates the monitoring network from which to retrieve data.  Examples are SLAMS and NAMS.  (Null returns data from all networks).");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/* 108 */   public static final PluginServiceParameterDescriptor DATA_VALIDITY_CODE = new PluginServiceParameterDescriptor("DataValidityCode", "java.lang.String", Boolean.FALSE, "Indicator used to filter out only data that is considered Valid based on the data provider's assessment of the air quality data.  If left blank, return assumes \"A\".  Possible values include: V: returns only valid data, A: Returns all data");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/* 113 */   public static final PluginServiceParameterDescriptor DATA_APPROVAL_INDICATOR = new PluginServiceParameterDescriptor("DataApprovalIndicator", "java.lang.String", Boolean.FALSE, "Indicates (Y/N) whether the state has approved this raw data result for regulatory purposes or data analysis, usually as a result of additional quality control review procedures. If left blank, assumes \"N\". Y: Only return data that has been approved by the state to be used for regulatory review, N: Includes both data that has been approved and not approved");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/* 118 */   public static final PluginServiceParameterDescriptor STATE_NAME = new PluginServiceParameterDescriptor("StateName", "java.lang.String", Boolean.FALSE, "State code defined by AQS. If SiteIdentifer is provided, State is required (SiteIdentifer is only unique within a county, and CountyCode is only unique within a state).");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/* 123 */   public static final PluginServiceParameterDescriptor COUNTY_NAME = new PluginServiceParameterDescriptor("CountyName", "java.lang.String", Boolean.FALSE, "County code defined by AQS. If SiteIdentifer is provided, CountyCode is required (SiteIdentifer is only unique within a county).");
/*     */   
/*     */ 
/* 126 */   public static final PluginServiceParameterDescriptor CITY_NAME = new PluginServiceParameterDescriptor("CityName", "java.lang.String", Boolean.FALSE, "City name.  If included, the array must also include the state.");
/*     */   
/*     */ 
/* 129 */   public static final PluginServiceParameterDescriptor TRIBE_NAME = new PluginServiceParameterDescriptor("TribeName", "java.lang.String", Boolean.FALSE, "Tribe Name.");
/*     */   
/* 131 */   public static final PluginServiceParameterDescriptor FACILITY_SITE_IDENTIFIER = new PluginServiceParameterDescriptor("FacilitySiteIdentifier", "java.lang.String", Boolean.FALSE, "Comma separated listing of desired Site identifiers, as defined by AQS. If blank, return all for the state.");
/*     */   
/*     */ 
/* 134 */   public static final PluginServiceParameterDescriptor MIN_LATITUDE_MEASURE = new PluginServiceParameterDescriptor("MinLatitudeMeasure", "java.lang.String", Boolean.FALSE, "Minimum latitude measure, in decimal degrees, from which to return raw data. If blank, return all for the state");
/*     */   
/*     */ 
/* 137 */   public static final PluginServiceParameterDescriptor MAX_LATITUDE_MEASURE = new PluginServiceParameterDescriptor("MaxLatitudeMeasure", "java.lang.String", Boolean.FALSE, "Maximum latitude measure, in decimal degrees, from which to return raw data. If blank, return all for the state");
/*     */   
/*     */ 
/* 140 */   public static final PluginServiceParameterDescriptor MIN_LONGITUDE_MEASURE = new PluginServiceParameterDescriptor("MinLongitudeMeasure", "java.lang.String", Boolean.FALSE, "Minimum longitude measure (i.e. Western border), in decimal degrees, from which to return raw data. If blank, return all for the state.  The standard will be to include negative values.");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/* 145 */   public static final PluginServiceParameterDescriptor MAX_LONGITUDE_MEASURE = new PluginServiceParameterDescriptor("MaxLongitudeMeasure", "java.lang.String", Boolean.FALSE, "Maximum longitude measure (i.e. Eastern border), in decimal degrees, from which to return raw data. If blank, return all for the state.  The standard will be to include negative values.");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/* 150 */   public static final PluginServiceParameterDescriptor LAST_UPDATE_DATE = new PluginServiceParameterDescriptor("LastUpdatedDate", "java.lang.String", Boolean.FALSE, "Returns all data that has been updated since the supplied date. If blank, return all data over the date range supplied above.");
/*     */   
/*     */ 
/* 153 */   public static final PluginServiceParameterDescriptor INCLUDE_MONITOR_DETAILS = new PluginServiceParameterDescriptor("IncludeMonitorDetails", "java.lang.String", Boolean.FALSE, "If set to \"Y\", the state will be requested to retrieve additional metadata about the site and monitor. If set to \"N\", state should only supply site and monitor ID information. If blank, assume \"Y\"");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/* 158 */   public static final PluginServiceParameterDescriptor INCLUDE_EVENT_DATA = new PluginServiceParameterDescriptor("IncludeEventData", "java.lang.String", Boolean.FALSE, "Valid values \"TRUE\" and \"FALSE\".  If TRUE, then the output file will include measurements effected by an \"exceptional event\" such as a volcano or forest fire.  Defaults to FALSE.");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/* 163 */   public static final PluginServiceParameterDescriptor SCHEMA_VERSION = new PluginServiceParameterDescriptor("SchemaVersion", "java.lang.String", Boolean.TRUE, "The version of the schema to be used to organize the returned data.  Used internally to DEC only and set by the Plug In.");
/*     */   
/*     */ 
/*     */ 
/* 167 */   private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();
/*     */   
/*     */   static
/*     */   {
/* 171 */     PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("DrDasProxyService");
/* 172 */     PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("DaDas proxy service, will submit AQS files created by DrDas to CDX.");
/* 173 */     PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(DrDasProxyService.class.getCanonicalName());
/*     */   }
/*     */   
/*     */ 
/*     */   public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
/*     */   {
/* 179 */     return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */   public DrDasProxyService()
/*     */   {
/* 186 */     debug("Setting internal runtime argument list");
/*     */     
/* 188 */     getConfigurationArguments().put("Reporter Url", "");
/* 189 */     getConfigurationArguments().put("Schema Version", "");
/*     */     
/* 191 */     getSupportedPluginTypes().add(ServiceType.QUERY);
/* 192 */     getSupportedPluginTypes().add(ServiceType.SOLICIT);
/* 193 */     getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT);
/*     */     
/* 195 */     debug("Plugin initialized");
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */   public List<PluginServiceParameterDescriptor> getParameters()
/*     */   {
/* 202 */     List<PluginServiceParameterDescriptor> params = new ArrayList();
/* 203 */     params.add(FILE_GENERATION_PURPOSE_CODE);
/* 204 */     params.add(BEGIN_DATE);
/* 205 */     params.add(BEGIN_TIME);
/* 206 */     params.add(END_DATE);
/* 207 */     params.add(END_TIME);
/* 208 */     params.add(TIME_TYPE);
/* 209 */     params.add(SAMPLE_DURATION);
/* 210 */     params.add(SUBSTANCE_NAME);
/* 211 */     params.add(MONITOR_TYPE);
/* 212 */     params.add(DATA_VALIDITY_CODE);
/* 213 */     params.add(DATA_APPROVAL_INDICATOR);
/* 214 */     params.add(STATE_NAME);
/* 215 */     params.add(COUNTY_NAME);
/* 216 */     params.add(CITY_NAME);
/* 217 */     params.add(TRIBE_NAME);
/* 218 */     params.add(FACILITY_SITE_IDENTIFIER);
/* 219 */     params.add(MIN_LATITUDE_MEASURE);
/* 220 */     params.add(MAX_LATITUDE_MEASURE);
/* 221 */     params.add(MIN_LONGITUDE_MEASURE);
/* 222 */     params.add(MAX_LONGITUDE_MEASURE);
/* 223 */     params.add(LAST_UPDATE_DATE);
/* 224 */     params.add(INCLUDE_MONITOR_DETAILS);
/* 225 */     params.add(INCLUDE_EVENT_DATA);
/* 226 */     params.add(SCHEMA_VERSION);
/* 227 */     return params;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public void afterPropertiesSet()
/*     */   {
/* 235 */     super.afterPropertiesSet();
/*     */     
/* 237 */     debug("Validating runtime args");
/*     */     
/*     */ 
/* 240 */     if (getConfigurationArguments() == null) {
/* 241 */       throw new RuntimeException("Data sources not set");
/*     */     }
/*     */     
/*     */ 
/* 245 */     if (!getConfigurationArguments().containsKey("Reporter Url")) {
/* 246 */       throw new RuntimeException("Reporter Url not set");
/*     */     }
/*     */     
/* 249 */     debug("Plugin validated");
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public ProcessContentResult process(NodeTransaction transaction)
/*     */   {
/* 258 */     debug("Processing transaction...");
/*     */     
/* 260 */     ProcessContentResult result = new ProcessContentResult();
/* 261 */     result.setSuccess(false);
/* 262 */     result.setStatus(CommonTransactionStatusCode.Failed);
/*     */     
/*     */     try
/*     */     {
/* 266 */       result.getAuditEntries().add(makeEntry("Validating transaction..."));
/*     */       
/*     */ 
/* 269 */       validateTransaction(transaction);
/*     */       
/* 271 */       IdGenerator idGenerator = (IdGenerator)getServiceFactory().makeService(IdGenerator.class);
/*     */       
/*     */ 
/* 274 */       if (idGenerator == null) {
/* 275 */         throw new RuntimeException("Unable to obtain IdGenerator");
/*     */       }
/*     */       
/* 278 */       HeaderDocumentHelper headerHelper = (HeaderDocumentHelper)getServiceFactory().makeService(HeaderDocumentHelper.class);
/*     */       
/*     */ 
/* 281 */       if (headerHelper == null) {
/* 282 */         throw new RuntimeException("Unable to obtain HeaderDocumentHelper");
/*     */       }
/*     */       
/*     */ 
/* 286 */       RemoteFileResourceHelper webHelper = (RemoteFileResourceHelper)getServiceFactory().makeService(RemoteFileResourceHelper.class);
/*     */       
/*     */ 
/* 289 */       if (webHelper == null) {
/* 290 */         throw new RuntimeException("Unable to obtain RemoteFileResourceHelper");
/*     */       }
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 298 */       result.getAuditEntries().add(makeEntry("Acquiring arguments..."));
/*     */       
/* 300 */       String reporterServiceUrl = getRequiredConfigValueAsString("Reporter Url");
/* 301 */       String reporterSchemaVersion = getRequiredConfigValueAsString("Schema Version");
/*     */       
/* 303 */       Map<String, Object> properties = new HashMap();
/* 304 */       properties.put("schemaVersion", reporterSchemaVersion);
/*     */       
/* 306 */       result.getAuditEntries().add(makeEntry("Configuring reporter client using: " + reporterServiceUrl));
/*     */       
/*     */ 
/*     */ 
/* 310 */       DrDasServiceHelper srv = new DrDasServiceHelper(reporterServiceUrl, transaction.getRequest().getParameters(), reporterSchemaVersion);
/*     */       
/*     */ 
/*     */ 
/* 314 */       result.getAuditEntries().add(makeEntry("Getting requested service name..."));
/*     */       
/*     */ 
/* 317 */       String methodName = transaction.getRequest().getService().getName();
/*     */       
/* 319 */       result.getAuditEntries().add(makeEntry("Parsing execution strategy from: " + methodName));
/*     */       
/* 321 */       byte[] resultsBytes = null;
/*     */       
/* 323 */       if (methodName.equalsIgnoreCase("AQDEMonitorData"))
/*     */       {
/* 325 */         result.getAuditEntries().add(makeEntry("Executing Monitor Data service using: " + transaction.getRequest().getParameters() + " and SchemaVersion: " + reporterSchemaVersion));
/*     */         
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 331 */         resultsBytes = srv.executeMonitorData();
/*     */       }
/* 333 */       else if (methodName.equalsIgnoreCase("AQDERawData"))
/*     */       {
/* 335 */         result.getAuditEntries().add(makeEntry("Executing Raw Data service using: " + transaction.getRequest().getParameters() + " and SchemaVersion: " + reporterSchemaVersion));
/*     */         
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 341 */         String resultFile = srv.executeRawData(idGenerator.createId());
/*     */         
/* 343 */         result.getAuditEntries().add(makeEntry("Reading remote result: " + resultFile));
/*     */         
/*     */ 
/* 346 */         resultsBytes = webHelper.getBytesFromURL(resultFile);
/*     */         
/* 348 */         String tempXml = new String(resultsBytes);
/* 349 */         resultsBytes = tempXml.getBytes("UTF-8");
/*     */       }
/*     */       else {
/* 352 */         throw new RuntimeException("Invalid parameter: Method Name is not supported (" + methodName + ").");
/*     */       }
/*     */       
/*     */ 
/*     */ 
/* 357 */       result.getAuditEntries().add(makeEntry("Testing for compression: " + transaction.getRequest().getType()));
/*     */       
/*     */ 
/*     */ 
/* 361 */       Document doc = new Document();
/* 362 */       result.getAuditEntries().add(makeEntry("Creating document..."));
/*     */       
/* 364 */       if (transaction.getRequest().getType() != RequestType.Query)
/*     */       {
/* 366 */         result.getAuditEntries().add(makeEntry("Compressing results..."));
/*     */         
/*     */ 
/* 369 */         CompressionService compressionService = (CompressionService)getServiceFactory().makeService(CompressionService.class);
/*     */         
/*     */ 
/* 372 */         doc.setType(CommonContentType.ZIP);
/* 373 */         doc.setDocumentName("AQS-" + methodName + ".zip");
/* 374 */         doc.setContent(compressionService.zip(resultsBytes, "AQS-" + methodName + ".xml"));
/*     */       }
/*     */       else
/*     */       {
/* 378 */         doc.setType(CommonContentType.XML);
/* 379 */         doc.setDocumentName("AQS-" + methodName + ".xml");
/* 380 */         doc.setContent(resultsBytes);
/*     */       }
/*     */       
/* 383 */       result.getAuditEntries().add(makeEntry("Setting result..."));
/*     */       
/* 385 */       result.setPaginatedContentIndicator(new PaginationIndicator(transaction.getRequest().getPaging().getStart(), transaction.getRequest().getPaging().getCount(), true));
/*     */       
/*     */ 
/*     */ 
/* 389 */       result.getDocuments().add(doc);
/*     */       
/* 391 */       result.setSuccess(true);
/* 392 */       result.setStatus(CommonTransactionStatusCode.Processed);
/* 393 */       result.getAuditEntries().add(makeEntry("Done: OK"));
/*     */     }
/*     */     catch (Throwable ex)
/*     */     {
/* 397 */       error(ex.getMessage(), ex);
/* 398 */       error(ex.getMessage());
/*     */       
/* 400 */       result.setSuccess(false);
/* 401 */       result.setStatus(CommonTransactionStatusCode.Failed);
/*     */       
/* 403 */       result.getAuditEntries().add(makeEntry("Error while executing: " + getClass().getName() + " Message: " + ex.getMessage()));
/*     */     }
/*     */     
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 410 */     return result;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName)
/*     */   {
/* 424 */     List<DataServiceRequestParameter> list = new ArrayList();
/*     */     
/* 426 */     Integer sortIndex = Integer.valueOf(0);
/*     */     Integer localInteger1;
/* 428 */     Integer localInteger2; if (serviceName.equalsIgnoreCase("AQDEMonitorData"))
/*     */     {
/* 430 */       for (MonitorDataArgType arg : MonitorDataArgType.values())
/*     */       {
/* 432 */         DataServiceRequestParameter param = new DataServiceRequestParameter();
/* 433 */         param.setName(arg.toString());
/* 434 */         param.setSortIndex(sortIndex);
/*     */         
/* 436 */         list.add(param);
/*     */         
/* 438 */         localInteger1 = sortIndex;localInteger2 = sortIndex = Integer.valueOf(sortIndex.intValue() + 1);
/*     */       }
/*     */       
/* 441 */     } else if (serviceName.equalsIgnoreCase("AQDERawData"))
/*     */     {
/* 443 */       for (RawDataArgType arg : RawDataArgType.values())
/*     */       {
/* 445 */         DataServiceRequestParameter param = new DataServiceRequestParameter();
/* 446 */         param.setName(arg.toString());
/* 447 */         param.setSortIndex(sortIndex);
/*     */         
/* 449 */         list.add(param);
/*     */         
/* 451 */         localInteger1 = sortIndex;localInteger2 = sortIndex = Integer.valueOf(sortIndex.intValue() + 1);
/*     */       }
/*     */       
/*     */     }
/*     */     else {
/* 456 */       list = null;
/*     */     }
/*     */     
/* 459 */     return list;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\DrDasProxyService.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */