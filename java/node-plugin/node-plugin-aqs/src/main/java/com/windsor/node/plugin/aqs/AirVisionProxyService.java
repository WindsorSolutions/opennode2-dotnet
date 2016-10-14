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
/*     */ import com.windsor.node.common.exception.WinNodeException;
/*     */ import com.windsor.node.common.util.ByIndexOrNameMap;
/*     */ import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
/*     */ import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
/*     */ import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;
/*     */ import com.windsor.node.service.helper.CompressionService;
/*     */ import com.windsor.node.service.helper.IdGenerator;
/*     */ import com.windsor.node.service.helper.RemoteFileResourceHelper;
/*     */ import com.windsor.node.service.helper.ServiceFactory;
/*     */ import com.windsor.node.service.helper.settings.SettingServiceProvider;
/*     */ import com.windsor.node.service.helper.zip.ZipCompressionService;
/*     */ import java.io.ByteArrayOutputStream;
/*     */ import java.io.File;
/*     */ import java.io.FileInputStream;
/*     */ import java.io.FileOutputStream;
/*     */ import java.io.IOException;
/*     */ import java.io.InputStream;
/*     */ import java.io.OutputStream;
/*     */ import java.net.URL;
/*     */ import java.util.ArrayList;
/*     */ import java.util.List;
/*     */ import java.util.Map;
/*     */ import javax.net.ssl.HttpsURLConnection;
/*     */ import org.apache.commons.io.FileUtils;
/*     */ import org.apache.commons.io.FilenameUtils;
/*     */ import org.apache.commons.io.IOUtils;
/*     */ import org.apache.commons.lang3.StringUtils;
/*     */ import org.slf4j.Logger;
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
/*     */ public class AirVisionProxyService
/*     */   extends BaseWnosJaxbPlugin
/*     */ {
/*     */   public static final String ARG_SERVICE_DAEMON_SERVICE_URL = "Service Base Url";
/*     */   public static final String ARG_SERVICE_PARTNER_ENDPOINT = "Partner Endpoint";
/*     */   public static final String ARG_HEADER_APPLICATION_IDENTIFIER = "Application Identifier";
/*     */   public static final String ARG_HEADER_AQS_SCREENING_GROUP = "AQS.ScreeningGroup";
/*     */   public static final String ARG_HEADER_AQS_FINAL_PROCESSING_STEP = "AQS.FinalProcessingStep";
/*     */   public static final String ARG_HEADER_AQS_STOP_ON_ERROR = "AQS.StopOnError";
/*     */   private static final String FILE_PREFIX = "AQS_";
/*     */   private static final String FILE_EXTENSION_XML = "xml";
/*  84 */   public static final PluginServiceParameterDescriptor START_TIME = new PluginServiceParameterDescriptor("StartTime", "java.lang.String", Boolean.TRUE, "The earliest date for which to return data in YYYY-MM-DD format.");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*  89 */   public static final PluginServiceParameterDescriptor END_TIME = new PluginServiceParameterDescriptor("EndTime", "java.lang.String", Boolean.TRUE, "The latest date for which to return data in YYYY-MM-DD format.");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*  94 */   public static final PluginServiceParameterDescriptor SEND_RD_TRANSACTIONS = new PluginServiceParameterDescriptor("SendRdTransactions", "java.lang.String", Boolean.FALSE, "Flag indicating whether to include RD transactions in the query result.");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*  99 */   public static final PluginServiceParameterDescriptor SEND_RB_TRANSACTIONS = new PluginServiceParameterDescriptor("SendRbTransactions", "java.lang.String", Boolean.FALSE, "Flag indicating whether to include RB transactions in the query result.");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/* 104 */   public static final PluginServiceParameterDescriptor SEND_MONITORING_ASSURANCE_TRANSACTIONS = new PluginServiceParameterDescriptor("SendMonitoringAssuranceTransactions", "java.lang.String", Boolean.FALSE, "Flag indicating whether to include Mointoring Assurance Transactions in the query result.");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/* 109 */   public static final PluginServiceParameterDescriptor AGENCY_CODE = new PluginServiceParameterDescriptor("AgencyCode", "java.lang.String", Boolean.FALSE, "AirVision Agency Code.");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/* 114 */   public static final PluginServiceParameterDescriptor SITE_CODE = new PluginServiceParameterDescriptor("SiteCode", "java.lang.String", Boolean.FALSE, "AirVision Site Code.");
/*     */   
/*     */ 
/*     */ 
/*     */ 
/* 119 */   public static final PluginServiceParameterDescriptor PARAMETER_CODE = new PluginServiceParameterDescriptor("ParameterCode", "java.lang.String", Boolean.FALSE, "AirVision Parameter Code.");
/*     */   
/*     */ 
/*     */   private JdbcTransactionDao transactionDao;
/*     */   
/*     */   private SettingServiceProvider settingService;
/*     */   
/*     */   private IdGenerator idGenerator;
/*     */   
/*     */   private CompressionService zipService;
/*     */   
/* 130 */   private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();
/*     */   
/*     */   static
/*     */   {
/* 134 */     PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("AirVisionProxyService");
/* 135 */     PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("AirVision proxy service, will submit AQS files created by AirVision to CDX.");
/* 136 */     PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(AirVisionProxyService.class.getCanonicalName());
/*     */   }
/*     */   
/*     */ 
/*     */   public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
/*     */   {
/* 142 */     return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
/*     */   }
/*     */   
/*     */ 
/*     */   public AirVisionProxyService()
/*     */   {
/* 148 */     getConfigurationArguments().put("Service Base Url", "");
/*     */     
/* 150 */     getConfigurationArguments().put("Author", "");
/* 151 */     getConfigurationArguments().put("Contact Info", "");
/* 152 */     getConfigurationArguments().put("Organization", "");
/* 153 */     getConfigurationArguments().put("Document Title", "");
/* 154 */     getConfigurationArguments().put("Application Identifier", "");
/* 155 */     getConfigurationArguments().put("AQS.ScreeningGroup", "");
/* 156 */     getConfigurationArguments().put("AQS.FinalProcessingStep", "");
/* 157 */     getConfigurationArguments().put("AQS.StopOnError", "");
/* 158 */     getSupportedPluginTypes().add(ServiceType.QUERY);
/* 159 */     getSupportedPluginTypes().add(ServiceType.SOLICIT);
/* 160 */     getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT);
/*     */   }
/*     */   
/*     */ 
/*     */   public List<PluginServiceParameterDescriptor> getParameters()
/*     */   {
/* 166 */     List<PluginServiceParameterDescriptor> params = new ArrayList();
/* 167 */     params.add(START_TIME);
/* 168 */     params.add(END_TIME);
/* 169 */     params.add(SEND_RD_TRANSACTIONS);
/* 170 */     params.add(SEND_RB_TRANSACTIONS);
/* 171 */     params.add(SEND_MONITORING_ASSURANCE_TRANSACTIONS);
/* 172 */     params.add(AGENCY_CODE);
/* 173 */     params.add(SITE_CODE);
/* 174 */     params.add(PARAMETER_CODE);
/* 175 */     return params;
/*     */   }
/*     */   
/*     */   public void afterPropertiesSet()
/*     */   {
/* 180 */     super.afterPropertiesSet();
/* 181 */     if (getConfigurationArguments() == null)
/*     */     {
/* 183 */       throw new RuntimeException("ConfigurationArguments were empty.");
/*     */     }
/*     */     
/* 186 */     setTransactionDao((JdbcTransactionDao)getServiceFactory().makeService(JdbcTransactionDao.class));
/* 187 */     if (this.transactionDao == null)
/*     */     {
/* 189 */       throw new RuntimeException("Unable to obtain transactionDao");
/*     */     }
/*     */     
/* 192 */     setSettingService((SettingServiceProvider)getServiceFactory().makeService(SettingServiceProvider.class));
/* 193 */     setIdGenerator((IdGenerator)getServiceFactory().makeService(IdGenerator.class));
/* 194 */     setZipService((CompressionService)getServiceFactory().makeService(ZipCompressionService.class));
/*     */   }
/*     */   
/*     */   public ProcessContentResult process(NodeTransaction transaction)
/*     */   {
/* 199 */     debug("Processing transaction...");
/*     */     
/* 201 */     ProcessContentResult result = new ProcessContentResult();
/* 202 */     result.setSuccess(false);
/* 203 */     result.setStatus(CommonTransactionStatusCode.Failed);
/*     */     
/*     */     try
/*     */     {
/* 207 */       RemoteFileResourceHelper restCaller = (RemoteFileResourceHelper)getServiceFactory().makeService(RemoteFileResourceHelper.class);
/* 208 */       String restUrl = constructAddress(transaction);
/* 209 */       result.getAuditEntries().add(makeEntry("Calling REST Url:  \"" + restUrl + "\""));
/*     */       
/* 211 */       byte[] response = null;
/* 212 */       if (restUrl.startsWith("http:"))
/*     */       {
/* 214 */         response = restCaller.getBytesFromURL(restUrl);
/*     */       }
/* 216 */       else if (restUrl.startsWith("https:"))
/*     */       {
/* 218 */         response = getBytesFromHttpsUrl(restUrl);
/*     */       }
/*     */       else
/*     */       {
/* 222 */         throw new WinNodeException("Not a valid URL scheme, must be http: or https:");
/*     */       }
/*     */       
/*     */ 
/* 226 */       List<String> lines = null;
/* 227 */       String responseString = new String(response, "UTF-8");
/* 228 */       if (responseString.indexOf("ERROR") == -1)
/*     */       {
/* 230 */         File file = new File(responseString);
/* 231 */         result.getAuditEntries().add(makeEntry("Successfully completed call, response file name was:  " + file.getName()));
/* 232 */         FileInputStream in = new FileInputStream(file);
/*     */         
/* 234 */         List<String> fileLines = IOUtils.readLines(in);
/*     */         
/* 236 */         if ((fileLines != null) && (fileLines.size() > 0))
/*     */         {
/* 238 */           if (((String)fileLines.get(0)).startsWith("<?xml"))
/*     */           {
/* 240 */             fileLines.remove(0);
/*     */           }
/*     */         }
/* 243 */         lines = fileLines;
/*     */         
/* 245 */         result.getAuditEntries().add(makeEntry("Loaded response file into memory."));
/*     */       }
/*     */       else
/*     */       {
/* 249 */         result.getAuditEntries().add(makeEntry("REST service call caused remote error:  " + responseString));
/*     */       }
/*     */       
/*     */ 
/* 253 */       result.getAuditEntries().add(makeEntry("Creating document..."));
/*     */       
/*     */ 
/*     */ 
/*     */ 
/* 258 */       if (lines != null)
/*     */       {
/*     */ 
/*     */ 
/* 262 */         String docId = getIdGenerator().createId();
/* 263 */         String tempFilePath = makeTemporaryFilename(docId);
/* 264 */         result.getAuditEntries().add(makeEntry("Adding EN Header."));
/* 265 */         addHeader(lines, docId, transaction);
/* 266 */         result.getAuditEntries().add(makeEntry("EN Header added."));
/* 267 */         OutputStream output = new FileOutputStream(tempFilePath);
/* 268 */         IOUtils.writeLines(lines, null, output, "UTF-8");
/*     */         
/*     */ 
/* 271 */         Document doc = makeDocument(transaction.getRequest().getType(), docId, tempFilePath);
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
/* 292 */         result.getAuditEntries().add(makeEntry("Setting result..."));
/*     */         
/* 294 */         result.setPaginatedContentIndicator(new PaginationIndicator(transaction.getRequest().getPaging().getStart(), transaction.getRequest().getPaging().getCount(), true));
/*     */         
/*     */ 
/* 297 */         result.getDocuments().add(doc);
/*     */         
/* 299 */         result.setSuccess(true);
/* 300 */         result.setStatus(CommonTransactionStatusCode.Processed);
/* 301 */         result.getAuditEntries().add(makeEntry("Done: OK"));
/*     */       }
/*     */       else
/*     */       {
/* 305 */         result.setSuccess(false);
/* 306 */         result.setStatus(CommonTransactionStatusCode.Failed);
/* 307 */         result.getAuditEntries().add(makeEntry("Response file was not loaded into memory for some reason, unknown failure."));
/*     */       }
/* 309 */       getTransactionDao().save(transaction);
/*     */     }
/*     */     catch (Throwable e)
/*     */     {
/* 313 */       error(e.getMessage(), e);
/* 314 */       error(e.getMessage());
/* 315 */       result.setSuccess(false);
/* 316 */       result.setStatus(CommonTransactionStatusCode.Failed);
/* 317 */       result.getAuditEntries().add(makeEntry("Error while executing: " + getClass().getName() + " Message: " + e.getMessage()));
/*     */     }
/* 319 */     return result;
/*     */   }
/*     */   
/*     */   private void addHeader(List<String> lines, String docId, NodeTransaction transaction)
/*     */   {
/* 324 */     String authorName = getConfigValueAsStringNoFail("Author");
/* 325 */     String contactInfo = getConfigValueAsStringNoFail("Contact Info");
/* 326 */     String orgName = getConfigValueAsStringNoFail("Organization");
/*     */     
/* 328 */     String aqsScreeningGroup = getConfigValueAsStringNoFail("AQS.ScreeningGroup");
/* 329 */     String aqsFinalProcessingStep = getConfigValueAsStringNoFail("AQS.FinalProcessingStep");
/* 330 */     String aqsStopOnError = getConfigValueAsStringNoFail("AQS.StopOnError");
/*     */     
/* 332 */     String documentTitle = getConfigValueAsStringNoFail("Document Title");
/* 333 */     String applicationIdentifier = getConfigValueAsStringNoFail("Application Identifier");
/*     */     
/* 335 */     StringBuffer header = new StringBuffer();
/* 336 */     StringBuffer footer = new StringBuffer();
/* 337 */     header.append("<hdr:Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ").append("xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" ").append("xmlns:hdr=\"http://www.exchangenetwork.net/schema/header/2\" ").append(" id=\"").append(docId).append("\">");
/*     */     
/*     */ 
/*     */ 
/* 341 */     header.append("\n").append("<hdr:Header>");
/* 342 */     header.append("\n").append("    ").append("<hdr:AuthorName>").append(authorName).append("</hdr:AuthorName>");
/* 343 */     header.append("\n").append("    ").append("<hdr:OrganizationName>").append(orgName).append("</hdr:OrganizationName>");
/* 344 */     header.append("\n").append("    ").append("<hdr:DocumentTitle>").append(documentTitle).append("</hdr:DocumentTitle>");
/* 345 */     header.append("\n").append("    ").append("<hdr:CreationDateTime>").append(getDocumentCreationDateTime()).append("</hdr:CreationDateTime>");
/* 346 */     header.append("\n").append("    ").append("<hdr:DataFlowName>").append(transaction.getRequest().getFlowName()).append("</hdr:DataFlowName>");
/* 347 */     header.append("\n").append("    ").append("<hdr:DataServiceName>").append(transaction.getRequest().getService().getName()).append("</hdr:DataServiceName>");
/* 348 */     header.append("\n").append("    ").append("<hdr:ApplicationUserIdentifier>").append(applicationIdentifier).append("</hdr:ApplicationUserIdentifier>");
/* 349 */     header.append("\n").append("    ").append("<hdr:SenderAddress>").append(contactInfo).append("</hdr:SenderAddress>");
/* 350 */     header.append("\n").append("    ").append("<hdr:Property>");
/* 351 */     header.append("\n").append("    ").append("    ").append("<hdr:PropertyName>AQS.ScreeningGroup</hdr:PropertyName>");
/*     */     
/* 353 */     header.append("\n").append("    ").append("    ").append("<hdr:PropertyValue xsi:type=\"xsd:string\">").append(aqsScreeningGroup).append("</hdr:PropertyValue>");
/* 354 */     header.append("\n").append("    ").append("</hdr:Property>");
/* 355 */     header.append("\n").append("    ").append("<hdr:Property>");
/* 356 */     header.append("\n").append("    ").append("    ").append("<hdr:PropertyName>AQS.FinalProcessingStep</hdr:PropertyName>");
/*     */     
/* 358 */     header.append("\n").append("    ").append("    ").append("<hdr:PropertyValue xsi:type=\"xsd:string\">").append(aqsFinalProcessingStep).append("</hdr:PropertyValue>");
/* 359 */     header.append("\n").append("    ").append("</hdr:Property>");
/* 360 */     header.append("\n").append("    ").append("<hdr:Property>");
/* 361 */     header.append("\n").append("    ").append("    ").append("<hdr:PropertyName>AQS.StopOnError</hdr:PropertyName>");
/*     */     
/* 363 */     header.append("\n").append("    ").append("    ").append("<hdr:PropertyValue xsi:type=\"xsd:string\">").append(aqsStopOnError).append("</hdr:PropertyValue>");
/* 364 */     header.append("\n").append("    ").append("</hdr:Property>");
/* 365 */     header.append("\n").append("    ").append("<hdr:Property>");
/* 366 */     header.append("\n").append("    ").append("    ").append("<hdr:PropertyName>AQS.SchemaVersion</hdr:PropertyName>");
/* 367 */     header.append("\n").append("    ").append("    ").append("<hdr:PropertyValue xsi:type=\"xsd:string\">2.2</hdr:PropertyValue>");
/* 368 */     header.append("\n").append("    ").append("</hdr:Property>");
/* 369 */     header.append("\n").append("    ").append("<hdr:Property>");
/* 370 */     header.append("\n").append("    ").append("    ").append("<hdr:PropertyName>AQS.PayloadType</hdr:PropertyName>");
/* 371 */     header.append("\n").append("    ").append("    ").append("<hdr:PropertyValue xsi:type=\"xsd:string\">XML</hdr:PropertyValue>");
/* 372 */     header.append("\n").append("    ").append("</hdr:Property>");
/* 373 */     header.append("\n").append("</hdr:Header>");
/*     */     
/* 375 */     header.append("\n").append("    ").append("<hdr:Payload id=\"").append(transaction.getId()).append("\">");
/*     */     
/* 377 */     footer.append("\n").append("    ").append("</hdr:Payload>");
/*     */     
/* 379 */     footer.append("\n").append("</hdr:Document>");
/* 380 */     lines.add(0, header.toString());
/* 381 */     lines.add(footer.toString());
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
/*     */   protected Document makeDocument(RequestType requestType, String documentId, String absolutefilePath)
/*     */     throws IOException
/*     */   {
/* 421 */     Document doc = new Document();
/* 422 */     doc.setDocumentId(documentId);
/* 423 */     doc.setId(documentId);
/*     */     
/* 425 */     if (!RequestType.Query.equals(requestType))
/*     */     {
/* 427 */       String zippedFilePath = getZipService().zip(absolutefilePath);
/* 428 */       doc.setType(CommonContentType.ZIP);
/* 429 */       doc.setDocumentName(FilenameUtils.getName(zippedFilePath));
/* 430 */       doc.setContent(FileUtils.readFileToByteArray(new File(zippedFilePath)));
/*     */     }
/*     */     else
/*     */     {
/* 434 */       doc.setType(CommonContentType.XML);
/* 435 */       doc.setDocumentName(FilenameUtils.getName(absolutefilePath));
/* 436 */       doc.setContent(FileUtils.readFileToByteArray(new File(absolutefilePath)));
/*     */     }
/* 438 */     return doc;
/*     */   }
/*     */   
/*     */   private String makeTemporaryFilename(String docId)
/*     */   {
/* 443 */     return FilenameUtils.concat(getSettingService().getTempDir().getAbsolutePath(), "AQS_" + getClass().getSimpleName() + docId + "." + "xml");
/*     */   }
/*     */   
/*     */ 
/*     */   public byte[] getBytesFromHttpsUrl(String address)
/*     */   {
/*     */     try
/*     */     {
/* 451 */       URL url = new URL(address);
/* 452 */       HttpsURLConnection conn = (HttpsURLConnection)url.openConnection();
/*     */       
/*     */ 
/*     */ 
/*     */ 
/* 457 */       InputStream fis = conn.getInputStream();
/*     */       
/* 459 */       ByteArrayOutputStream byteArrOut = new ByteArrayOutputStream();
/*     */       
/*     */ 
/* 462 */       byte[] buf = new byte['　'];
/* 463 */       int ln; while ((ln = fis.read(buf)) != -1)
/*     */       {
/* 465 */         byteArrOut.write(buf, 0, ln);
/*     */       }
/* 467 */       return byteArrOut.toByteArray();
/*     */     }
/*     */     catch (Exception ex)
/*     */     {
/* 471 */       this.logger.error(ex.getMessage(), ex);
/* 472 */       throw new RuntimeException("Error while getting content from Url: " + address, ex);
/*     */     }
/*     */   }
/*     */   
/*     */   protected String constructAddress(NodeTransaction transaction)
/*     */   {
/* 478 */     ByIndexOrNameMap namedParams = transaction.getRequest().getParameters();
/* 479 */     String startDate = (String)namedParams.get(START_TIME.getName());
/* 480 */     String endDate = (String)namedParams.get(END_TIME.getName());
/*     */     
/* 482 */     String daemonServiceUrl = getConfigValueAsString("Service Base Url", false);
/*     */     
/* 484 */     StringBuffer url = new StringBuffer();
/* 485 */     url.append(daemonServiceUrl).append("/aqs/").append(startDate).append("/").append(endDate);
/*     */     
/* 487 */     String sendRd = (String)namedParams.get(SEND_RD_TRANSACTIONS.getName());
/* 488 */     if (StringUtils.isNotBlank(sendRd))
/*     */     {
/* 490 */       url.append("/").append(sendRd);
/*     */     }
/*     */     else
/*     */     {
/* 494 */       url.append("/").append("false");
/*     */     }
/*     */     
/* 497 */     String sendRb = (String)namedParams.get(SEND_RB_TRANSACTIONS.getName());
/* 498 */     if (StringUtils.isNotBlank(sendRb))
/*     */     {
/* 500 */       url.append("/").append(sendRb);
/*     */     }
/*     */     else
/*     */     {
/* 504 */       url.append("/").append("false");
/*     */     }
/*     */     
/* 507 */     String sendRp = (String)namedParams.get(SEND_MONITORING_ASSURANCE_TRANSACTIONS.getName());
/* 508 */     if (StringUtils.isNotBlank(sendRp))
/*     */     {
/* 510 */       url.append("/").append(sendRp);
/*     */     }
/*     */     else
/*     */     {
/* 514 */       url.append("/").append("false");
/*     */     }
/*     */     
/* 517 */     String agencyCode = (String)namedParams.get(AGENCY_CODE.getName());
/* 518 */     if (StringUtils.isNotBlank(agencyCode))
/*     */     {
/* 520 */       url.append("/").append(agencyCode);
/*     */     }
/*     */     else
/*     */     {
/* 524 */       url.append("/").append("none");
/*     */     }
/*     */     
/* 527 */     String siteCode = (String)namedParams.get(SITE_CODE.getName());
/* 528 */     if (StringUtils.isNotBlank(siteCode))
/*     */     {
/* 530 */       url.append("/").append(siteCode);
/*     */     }
/*     */     else
/*     */     {
/* 534 */       url.append("/").append("none");
/*     */     }
/*     */     
/* 537 */     String parameterCode = (String)namedParams.get(PARAMETER_CODE.getName());
/* 538 */     if (StringUtils.isNotBlank(parameterCode))
/*     */     {
/* 540 */       url.append("/").append(parameterCode);
/*     */     }
/*     */     else
/*     */     {
/* 544 */       url.append("/").append("none");
/*     */     }
/*     */     
/* 547 */     return url.toString();
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
/*     */ 
/*     */ 
/*     */   public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName)
/*     */   {
/* 601 */     return null;
/*     */   }
/*     */   
/*     */   public JdbcTransactionDao getTransactionDao()
/*     */   {
/* 606 */     return this.transactionDao;
/*     */   }
/*     */   
/*     */   public void setTransactionDao(JdbcTransactionDao transactionDao)
/*     */   {
/* 611 */     this.transactionDao = transactionDao;
/*     */   }
/*     */   
/*     */   public IdGenerator getIdGenerator()
/*     */   {
/* 616 */     return this.idGenerator;
/*     */   }
/*     */   
/*     */   public void setIdGenerator(IdGenerator idGenerator)
/*     */   {
/* 621 */     this.idGenerator = idGenerator;
/*     */   }
/*     */   
/*     */   public SettingServiceProvider getSettingService()
/*     */   {
/* 626 */     return this.settingService;
/*     */   }
/*     */   
/*     */   public void setSettingService(SettingServiceProvider settingService)
/*     */   {
/* 631 */     this.settingService = settingService;
/*     */   }
/*     */   
/*     */   public CompressionService getZipService()
/*     */   {
/* 636 */     return this.zipService;
/*     */   }
/*     */   
/*     */   public void setZipService(CompressionService zipService)
/*     */   {
/* 641 */     this.zipService = zipService;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\AirVisionProxyService.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */