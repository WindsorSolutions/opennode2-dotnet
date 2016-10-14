/*     */ package com.windsor.node.plugin.aqs;
/*     */ 
/*     */ import com.windsor.node.common.util.ByIndexOrNameMap;
/*     */ import com.windsor.node.plugin.aqs.wsdl.AQDEDataSoap;
/*     */ import com.windsor.node.plugin.aqs.wsdl.AQDEDataSoapStub;
/*     */ import java.net.MalformedURLException;
/*     */ import java.net.URL;
/*     */ import org.apache.commons.lang3.StringUtils;
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
/*     */ public class DrDasServiceHelper
/*     */ {
/*  54 */   public final Logger logger = LoggerFactory.getLogger(getClass());
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
/*     */   private final AQDEDataSoap stub;
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
/*     */   private final ByIndexOrNameMap args;
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
/*     */   private final String schemaVersion;
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
/*     */   public DrDasServiceHelper(String url, ByIndexOrNameMap args, String schemaVersion)
/*     */   {
/* 105 */     this.logger.info("Service Url: " + url);
/* 106 */     this.logger.info("Args: " + StringUtils.join(args.toValueStringArray(), "|"));
/*     */     
/*     */ 
/* 109 */     this.logger.info("Schema: " + schemaVersion);
/*     */     
/* 111 */     this.args = args;
/* 112 */     this.schemaVersion = schemaVersion;
/*     */     
/* 114 */     URL serviceUrl = null;
/*     */     try {
/* 116 */       serviceUrl = new URL(url);
/*     */     } catch (MalformedURLException mfe) {
/* 118 */       throw new RuntimeException("Invalid Reporter Service Url: " + url, mfe);
/*     */     }
/*     */     
/*     */     try
/*     */     {
/* 123 */       this.stub = new AQDEDataSoapStub(serviceUrl, null);
/*     */     } catch (Throwable aex) {
/* 125 */       throw new RuntimeException("Error while initializing Reporter Service with: " + serviceUrl + " Message: " + aex.getMessage(), aex);
/*     */     }
/*     */   }
/*     */   
/*     */ 
/*     */   private String getAsString(Object val)
/*     */   {
/* 132 */     if (val == null) {
/* 133 */       return null;
/*     */     }
/* 135 */     String valStr = (String)val;
/* 136 */     if (StringUtils.isBlank(valStr)) {
/* 137 */       return null;
/*     */     }
/* 139 */     return StringUtils.trimToEmpty(valStr);
/*     */   }
/*     */   
/*     */ 
/*     */   public byte[] executeMonitorData()
/*     */     throws Exception
/*     */   {
/* 146 */     String resultXml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
/* 147 */     resultXml = resultXml + this.stub.queryAQSMonitorData(getAsString(this.args.get(0)), getAsString(this.args.get(1)), getAsString(this.args.get(2)), getAsString(this.args.get(3)), getAsString(this.args.get(4)), getAsString(this.args.get(5)), getAsString(this.args.get(6)), getAsString(this.args.get(7)), getAsString(this.args.get(8)), getAsString(this.args.get(9)), getAsString(this.args.get(10)), getAsString(this.args.get(11)), getAsString(this.args.get(12)), this.schemaVersion);
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
/* 172 */     this.logger.debug("resultXml: " + resultXml);
/*     */     
/* 174 */     return resultXml.getBytes();
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
/*     */   public String executeRawData(String requestId)
/*     */     throws Exception
/*     */   {
/* 188 */     String resultFilePath = this.stub.solicitAQSRawData(getAsString(this.args.get(0)), getAsString(this.args.get(1)), getAsString(this.args.get(2)), getAsString(this.args.get(3)), getAsString(this.args.get(4)), getAsString(this.args.get(5)), getAsString(this.args.get(6)), getAsString(this.args.get(7)), getAsString(this.args.get(8)), getAsString(this.args.get(9)), getAsString(this.args.get(10)), getAsString(this.args.get(11)), getAsString(this.args.get(12)), getAsString(this.args.get(13)), getAsString(this.args.get(14)), getAsString(this.args.get(15)), getAsString(this.args.get(16)), getAsString(this.args.get(17)), getAsString(this.args.get(18)), getAsString(this.args.get(19)), getAsString(this.args.get(20)), getAsString(this.args.get(21)), getAsString(this.args.get(22)), this.schemaVersion, requestId, "false");
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
/* 228 */     this.logger.info("resultFilePath: " + resultFilePath);
/*     */     
/* 230 */     return resultFilePath;
/*     */   }
/*     */   
/*     */   public class RawDataServiceArgList
/*     */   {
/*     */     public static final int fileGenerationPurposeCode = 0;
/*     */     public static final int beginDate = 1;
/*     */     public static final int beginTime = 2;
/*     */     public static final int endDate = 3;
/*     */     public static final int endTime = 4;
/*     */     public static final int timeType = 5;
/*     */     public static final int sampleDuration = 6;
/*     */     public static final int substanceName = 7;
/*     */     public static final int monitorType = 8;
/*     */     public static final int dataValidityCode = 9;
/*     */     public static final int dataApprovalIndicator = 10;
/*     */     public static final int stateName = 11;
/*     */     public static final int countyName = 12;
/*     */     public static final int cityName = 13;
/*     */     public static final int tribeName = 14;
/*     */     public static final int facilitySiteIdentifier = 15;
/*     */     public static final int minLatitudeMeasure = 16;
/*     */     public static final int maxLatitudeMeasure = 17;
/*     */     public static final int minLongitudeMeasure = 18;
/*     */     public static final int maxLongitudeMeasure = 19;
/*     */     public static final int lastUpdatedDate = 20;
/*     */     public static final int includeMonitorDetails = 21;
/*     */     public static final int includeEventData = 22;
/*     */     
/*     */     public RawDataServiceArgList() {}
/*     */   }
/*     */   
/*     */   public class MonitorServiceArgList
/*     */   {
/*     */     public static final int fileGenerationPurposeCode = 0;
/*     */     public static final int substanceName = 1;
/*     */     public static final int monitorType = 2;
/*     */     public static final int stateName = 3;
/*     */     public static final int countyName = 4;
/*     */     public static final int cityName = 5;
/*     */     public static final int tribeName = 6;
/*     */     public static final int facilitySiteIdentifier = 7;
/*     */     public static final int minLatitudeMeasure = 8;
/*     */     public static final int maxLatitudeMeasure = 9;
/*     */     public static final int minLongitudeMeasure = 10;
/*     */     public static final int maxLongitudeMeasure = 11;
/*     */     public static final int lastUpdatedDate = 12;
/*     */     
/*     */     public MonitorServiceArgList() {}
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\DrDasServiceHelper.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */