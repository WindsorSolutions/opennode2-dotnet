/*     */ package com.windsor.node.plugin.aqs.wsdl;
/*     */ 
/*     */ import java.net.URL;
/*     */ import java.rmi.RemoteException;
/*     */ import java.util.Enumeration;
/*     */ import java.util.Properties;
/*     */ import javax.xml.namespace.QName;
/*     */ import org.apache.axis.AxisFault;
/*     */ import org.apache.axis.NoEndPointException;
/*     */ import org.apache.axis.client.Call;
/*     */ import org.apache.axis.client.Stub;
/*     */ import org.apache.axis.constants.Style;
/*     */ import org.apache.axis.constants.Use;
/*     */ import org.apache.axis.description.OperationDesc;
/*     */ import org.apache.axis.soap.SOAPConstants;
/*     */ import org.apache.axis.utils.JavaUtils;
/*     */ import org.slf4j.Logger;
/*     */ import org.slf4j.LoggerFactory;
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
/*     */ public class AQDEDataSoapStub
/*     */   extends Stub
/*     */   implements AQDEDataSoap
/*     */ {
/*  50 */   private final Logger logger = LoggerFactory.getLogger(AQDEDataSoapStub.class);
/*     */   
/*     */   static OperationDesc[] _operations;
/*     */   
/*     */ 
/*     */   static
/*     */   {
/*     */     try
/*     */     {
/*  59 */       _operations = new OperationDesc[3];
/*     */       
/*  61 */       OperationDesc oper = new OperationDesc();
/*     */       
/*  63 */       oper.setName("solicitAQSRawData");
/*     */       
/*  65 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "FileGenerationPurposeCode"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*  72 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "BeginDate"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*  78 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "BeginTime"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*  84 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "EndDate"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*  91 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "EndTime"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*  98 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "TimeType"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 104 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "SampleDuration"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 110 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "SubstanceName"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 116 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "MonitorType"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 122 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "DataValidityCode"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 128 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "DataApprovalIndicator"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 134 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "StateName"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 140 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "CountyName"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 146 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "CityName"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 152 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "TribeName"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 158 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "FacilitySiteIdentifier"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 164 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "MinLatitudeMeasure"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 170 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "MaxLatitudeMeasure"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 176 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "MinLongitudeMeasure"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 182 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "MaxLongitudeMeasure"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 188 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "LastUpdatedDate"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 194 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "IncludeMonitorDetails"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 200 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "IncludeEventData"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 206 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "SchemaVersion"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 212 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "RequestId"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 218 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "CompressionEnabled"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 224 */       oper.setReturnType(new QName("http://www.w3.org/2001/XMLSchema", "string"));
/*     */       
/* 226 */       oper.setReturnClass(String.class);
/* 227 */       oper.setReturnQName(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "solicitAQSRawDataResult"));
/*     */       
/*     */ 
/*     */ 
/* 231 */       oper.setStyle(Style.WRAPPED);
/* 232 */       oper.setUse(Use.LITERAL);
/*     */       
/*     */ 
/* 235 */       _operations[0] = oper;
/*     */       
/* 237 */       oper = new OperationDesc();
/* 238 */       oper.setName("queryAQSRawData");
/* 239 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "FileGenerationPurposeCode"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 246 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "BeginDate"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 252 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "BeginTime"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 258 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "EndDate"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 265 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "EndTime"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 272 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "TimeType"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 278 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "SampleDuration"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 284 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "SubstanceName"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 290 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "MonitorType"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 296 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "DataValidityCode"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 302 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "DataApprovalIndicator"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 308 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "StateName"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 314 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "CountyName"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 320 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "CityName"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 326 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "TribeName"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 332 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "FacilitySiteIdentifier"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 338 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "MinLatitudeMeasure"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 344 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "MaxLatitudeMeasure"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 350 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "MinLongitudeMeasure"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 356 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "MaxLongitudeMeasure"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 362 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "LastUpdatedDate"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 368 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "IncludeMonitorDetails"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 374 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "IncludeEventData"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 380 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "SchemaVersion"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 386 */       oper.setReturnType(new QName("http://www.w3.org/2001/XMLSchema", "string"));
/*     */       
/* 388 */       oper.setReturnClass(String.class);
/* 389 */       oper.setReturnQName(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "queryAQSRawDataResult"));
/*     */       
/*     */ 
/*     */ 
/* 393 */       oper.setStyle(Style.WRAPPED);
/* 394 */       oper.setUse(Use.LITERAL);
/*     */       
/*     */ 
/* 397 */       _operations[1] = oper;
/*     */       
/* 399 */       oper = new OperationDesc();
/* 400 */       oper.setName("queryAQSMonitorData");
/* 401 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "FileGenerationPurposeCode"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 408 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "SubstanceName"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 414 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "MonitorType"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 420 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "StateName"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 426 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "CountyName"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 432 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "CityName"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 438 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "TribeName"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 444 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "FacilitySiteIdentifier"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 450 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "MinLatitudeMeasure"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 456 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "MaxLatitudeMeasure"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 462 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "MinLongitudeMeasure"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 468 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "MaxLongitudeMeasure"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 474 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "LastUpdatedDate"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 480 */       oper.addParameter(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "SchemaVersion"), new QName("http://www.w3.org/2001/XMLSchema", "string"), String.class, (byte)1, false, false);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 486 */       oper.setReturnType(new QName("http://www.w3.org/2001/XMLSchema", "string"));
/*     */       
/* 488 */       oper.setReturnClass(String.class);
/* 489 */       oper.setReturnQName(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "queryAQSMonitorDataResult"));
/*     */       
/*     */ 
/*     */ 
/* 493 */       oper.setStyle(Style.WRAPPED);
/* 494 */       oper.setUse(Use.LITERAL);
/*     */       
/*     */ 
/* 497 */       _operations[2] = oper;
/*     */     }
/*     */     catch (Throwable thr) {
/* 500 */       throw new RuntimeException("Error while static initializing AQDEDataSoapStub: " + thr.getMessage(), thr);
/*     */     }
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public AQDEDataSoapStub(URL endpointURL, javax.xml.rpc.Service service)
/*     */   {
/* 510 */     this.logger.debug("new AQDEDataSoapStub");
/*     */     try
/*     */     {
/* 513 */       this.service = new org.apache.axis.client.Service();
/* 514 */       this.cachedEndpoint = endpointURL;
/* 515 */       setTimeout(3600000);
/*     */     } catch (Throwable thr) {
/* 517 */       this.logger.error(thr.getMessage(), thr);
/* 518 */       throw new RuntimeException("Error while new initializing AQDEDataSoapStub: " + thr.getMessage(), thr);
/*     */     }
/*     */   }
/*     */   
/*     */ 
/*     */   private Call createCall()
/*     */     throws RemoteException
/*     */   {
/*     */     try
/*     */     {
/* 528 */       Call _call = (Call)this.service.createCall();
/*     */       
/* 530 */       if (this.maintainSessionSet) {
/* 531 */         _call.setMaintainSession(this.maintainSession);
/*     */       }
/* 533 */       if (this.cachedUsername != null) {
/* 534 */         _call.setUsername(this.cachedUsername);
/*     */       }
/* 536 */       if (this.cachedPassword != null) {
/* 537 */         _call.setPassword(this.cachedPassword);
/*     */       }
/* 539 */       if (this.cachedEndpoint != null) {
/* 540 */         _call.setTargetEndpointAddress(this.cachedEndpoint);
/*     */       }
/* 542 */       if (this.cachedPortName != null) {
/* 543 */         _call.setPortName(this.cachedPortName);
/*     */       }
/* 545 */       Enumeration keys = this.cachedProperties.keys();
/* 546 */       while (keys.hasMoreElements()) {
/* 547 */         String key = (String)keys.nextElement();
/* 548 */         _call.setProperty(key, this.cachedProperties.get(key));
/*     */       }
/*     */       
/* 551 */       _call.setTimeout(new Integer(3600000));
/*     */       
/* 553 */       return _call;
/*     */     } catch (Throwable t) {
/* 555 */       throw new AxisFault("Failure trying to get the Call object", t);
/*     */     }
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
/*     */   public String solicitAQSRawData(String fileGenerationPurposeCode, String beginDate, String beginTime, String endDate, String endTime, String timeType, String sampleDuration, String substanceName, String monitorType, String dataValidityCode, String dataApprovalIndicator, String stateName, String countyName, String cityName, String tribeName, String facilitySiteIdentifier, String minLatitudeMeasure, String maxLatitudeMeasure, String minLongitudeMeasure, String maxLongitudeMeasure, String lastUpdatedDate, String includeMonitorDetails, String includeEventData, String schemaVersion, String requestId, String compressionEnabled)
/*     */     throws RemoteException
/*     */   {
/* 581 */     if (this.cachedEndpoint == null) {
/* 582 */       throw new NoEndPointException();
/*     */     }
/* 584 */     Call _call = createCall();
/* 585 */     _call.setOperation(_operations[0]);
/* 586 */     _call.setUseSOAPAction(true);
/* 587 */     _call.setSOAPActionURI("urn:schemas-drdas-com:reporter.aqde.webservice/solicitAQSRawData");
/*     */     
/* 589 */     _call.setEncodingStyle(null);
/* 590 */     _call.setProperty("sendXsiTypes", Boolean.FALSE);
/*     */     
/* 592 */     _call.setProperty("sendMultiRefs", Boolean.FALSE);
/*     */     
/* 594 */     _call.setSOAPVersion(SOAPConstants.SOAP11_CONSTANTS);
/*     */     
/* 596 */     _call.setOperationName(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "solicitAQSRawData"));
/*     */     
/*     */ 
/*     */ 
/* 600 */     setRequestHeaders(_call);
/* 601 */     setAttachments(_call);
/*     */     
/* 603 */     Object[] argsToSend = { fileGenerationPurposeCode, beginDate, beginTime, endDate, endTime, timeType, sampleDuration, substanceName, monitorType, dataValidityCode, dataApprovalIndicator, stateName, countyName, cityName, tribeName, facilitySiteIdentifier, minLatitudeMeasure, maxLatitudeMeasure, minLongitudeMeasure, maxLongitudeMeasure, lastUpdatedDate, includeMonitorDetails, includeEventData, schemaVersion, requestId, compressionEnabled };
/*     */     
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */     try
/*     */     {
/* 614 */       Object _resp = _call.invoke(argsToSend);
/*     */       
/* 616 */       if ((_resp instanceof RemoteException)) {
/* 617 */         throw ((RemoteException)_resp);
/*     */       }
/*     */       
/* 620 */       return (String)JavaUtils.convert(_resp, String.class);
/*     */     }
/*     */     catch (Exception ex)
/*     */     {
/* 624 */       throw new RuntimeException("Error while executting remote call: " + ex.getMessage() + " Args: " + argsToString(argsToSend));
/*     */     }
/*     */   }
/*     */   
/*     */ 
/*     */   private String argsToString(Object[] args)
/*     */   {
/* 631 */     StringBuffer sb = new StringBuffer();
/* 632 */     sb.append("\n");
/*     */     
/* 634 */     for (int i = 0; i < args.length; i++) {
/* 635 */       sb.append("" + i + " = '" + args[i] + "'\n");
/*     */     }
/*     */     
/* 638 */     return sb.toString();
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
/*     */   public String queryAQSRawData(String fileGenerationPurposeCode, String beginDate, String beginTime, String endDate, String endTime, String timeType, String sampleDuration, String substanceName, String monitorType, String dataValidityCode, String dataApprovalIndicator, String stateName, String countyName, String cityName, String tribeName, String facilitySiteIdentifier, String minLatitudeMeasure, String maxLatitudeMeasure, String minLongitudeMeasure, String maxLongitudeMeasure, String lastUpdatedDate, String includeMonitorDetails, String includeEventData, String schemaVersion)
/*     */     throws RemoteException
/*     */   {
/* 661 */     if (this.cachedEndpoint == null) {
/* 662 */       throw new NoEndPointException();
/*     */     }
/* 664 */     Call _call = createCall();
/* 665 */     _call.setOperation(_operations[1]);
/* 666 */     _call.setUseSOAPAction(true);
/* 667 */     _call.setSOAPActionURI("urn:schemas-drdas-com:reporter.aqde.webservice/queryAQSRawData");
/*     */     
/* 669 */     _call.setEncodingStyle(null);
/* 670 */     _call.setProperty("sendXsiTypes", Boolean.FALSE);
/*     */     
/* 672 */     _call.setProperty("sendMultiRefs", Boolean.FALSE);
/*     */     
/* 674 */     _call.setSOAPVersion(SOAPConstants.SOAP11_CONSTANTS);
/*     */     
/* 676 */     _call.setOperationName(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "queryAQSRawData"));
/*     */     
/*     */ 
/*     */ 
/* 680 */     setRequestHeaders(_call);
/* 681 */     setAttachments(_call);
/*     */     
/* 683 */     Object[] argsToSend = { fileGenerationPurposeCode, beginDate, beginTime, endDate, endTime, timeType, sampleDuration, substanceName, monitorType, dataValidityCode, dataApprovalIndicator, stateName, countyName, cityName, tribeName, facilitySiteIdentifier, minLatitudeMeasure, maxLatitudeMeasure, minLongitudeMeasure, maxLongitudeMeasure, lastUpdatedDate, includeMonitorDetails, includeEventData, schemaVersion };
/*     */     
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */     try
/*     */     {
/* 694 */       Object _resp = _call.invoke(argsToSend);
/*     */       
/* 696 */       if ((_resp instanceof RemoteException)) {
/* 697 */         throw ((RemoteException)_resp);
/*     */       }
/*     */       
/* 700 */       return (String)JavaUtils.convert(_resp, String.class);
/*     */     }
/*     */     catch (Exception ex)
/*     */     {
/* 704 */       throw new RuntimeException("Error while executting remote call: " + ex.getMessage() + " Args: " + argsToString(argsToSend));
/*     */     }
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
/*     */   public String queryAQSMonitorData(String fileGenerationPurposeCode, String substanceName, String monitorType, String stateName, String countyName, String cityName, String tribeName, String facilitySiteIdentifier, String minLatitudeMeasure, String maxLatitudeMeasure, String minLongitudeMeasure, String maxLongitudeMeasure, String lastUpdatedDate, String schemaVersion)
/*     */     throws RemoteException
/*     */   {
/* 721 */     if (this.cachedEndpoint == null) {
/* 722 */       throw new NoEndPointException();
/*     */     }
/* 724 */     Call _call = createCall();
/* 725 */     _call.setOperation(_operations[2]);
/* 726 */     _call.setUseSOAPAction(true);
/* 727 */     _call.setSOAPActionURI("urn:schemas-drdas-com:reporter.aqde.webservice/queryAQSMonitorData");
/*     */     
/* 729 */     _call.setEncodingStyle(null);
/* 730 */     _call.setProperty("sendXsiTypes", Boolean.FALSE);
/*     */     
/* 732 */     _call.setProperty("sendMultiRefs", Boolean.FALSE);
/*     */     
/* 734 */     _call.setSOAPVersion(SOAPConstants.SOAP11_CONSTANTS);
/*     */     
/* 736 */     _call.setOperationName(new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "queryAQSMonitorData"));
/*     */     
/*     */ 
/*     */ 
/* 740 */     setRequestHeaders(_call);
/* 741 */     setAttachments(_call);
/*     */     
/* 743 */     Object[] argsToSend = { fileGenerationPurposeCode, substanceName, monitorType, stateName, countyName, cityName, tribeName, facilitySiteIdentifier, minLatitudeMeasure, maxLatitudeMeasure, minLongitudeMeasure, maxLongitudeMeasure, lastUpdatedDate, schemaVersion };
/*     */     
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */     try
/*     */     {
/* 752 */       Object _resp = _call.invoke(argsToSend);
/*     */       
/* 754 */       if ((_resp instanceof RemoteException)) {
/* 755 */         throw ((RemoteException)_resp);
/*     */       }
/*     */       
/* 758 */       return (String)JavaUtils.convert(_resp, String.class);
/*     */     }
/*     */     catch (Exception ex)
/*     */     {
/* 762 */       throw new RuntimeException("Error while executting remote call: " + ex.getMessage() + " Args: " + argsToString(argsToSend));
/*     */     }
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\wsdl\AQDEDataSoapStub.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */