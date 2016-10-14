/*     */ package com.windsor.node.plugin.aqs.agilaire;
/*     */ 
/*     */ import javax.xml.bind.annotation.XmlAccessType;
/*     */ import javax.xml.bind.annotation.XmlAccessorType;
/*     */ import javax.xml.bind.annotation.XmlElement;
/*     */ import javax.xml.bind.annotation.XmlSchemaType;
/*     */ import javax.xml.bind.annotation.XmlType;
/*     */ import javax.xml.datatype.XMLGregorianCalendar;
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
/*     */ @XmlAccessorType(XmlAccessType.FIELD)
/*     */ @XmlType(name="AQS3WebServiceArgument", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", propOrder={"aqsxmlSchemaVersion", "compressPayload", "endTime", "sendMonitorAssuranceTransactions", "sendOnlyQAData", "sendRBTransactions", "sendRDTransactions", "startTime", "tags"})
/*     */ public class AQS3WebServiceArgument
/*     */ {
/*     */   @XmlElement(name="AQSXMLSchemaVersion", required=true, nillable=true)
/*     */   protected String aqsxmlSchemaVersion;
/*     */   @XmlElement(name="CompressPayload")
/*     */   protected boolean compressPayload;
/*     */   @XmlElement(name="EndTime", required=true)
/*     */   @XmlSchemaType(name="dateTime")
/*     */   protected XMLGregorianCalendar endTime;
/*     */   @XmlElement(name="SendMonitorAssuranceTransactions")
/*     */   protected boolean sendMonitorAssuranceTransactions;
/*     */   @XmlElement(name="SendOnlyQAData")
/*     */   protected boolean sendOnlyQAData;
/*     */   @XmlElement(name="SendRBTransactions")
/*     */   protected boolean sendRBTransactions;
/*     */   @XmlElement(name="SendRDTransactions")
/*     */   protected boolean sendRDTransactions;
/*     */   @XmlElement(name="StartTime", required=true)
/*     */   @XmlSchemaType(name="dateTime")
/*     */   protected XMLGregorianCalendar startTime;
/*     */   @XmlElement(name="Tags", required=true, nillable=true)
/*     */   protected ArrayOfAQSParameterTag tags;
/*     */   
/*     */   public String getAQSXMLSchemaVersion()
/*     */   {
/*  83 */     return this.aqsxmlSchemaVersion;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setAQSXMLSchemaVersion(String value)
/*     */   {
/*  95 */     this.aqsxmlSchemaVersion = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public boolean isCompressPayload()
/*     */   {
/* 103 */     return this.compressPayload;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setCompressPayload(boolean value)
/*     */   {
/* 111 */     this.compressPayload = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public XMLGregorianCalendar getEndTime()
/*     */   {
/* 123 */     return this.endTime;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setEndTime(XMLGregorianCalendar value)
/*     */   {
/* 135 */     this.endTime = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public boolean isSendMonitorAssuranceTransactions()
/*     */   {
/* 143 */     return this.sendMonitorAssuranceTransactions;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSendMonitorAssuranceTransactions(boolean value)
/*     */   {
/* 151 */     this.sendMonitorAssuranceTransactions = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public boolean isSendOnlyQAData()
/*     */   {
/* 159 */     return this.sendOnlyQAData;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSendOnlyQAData(boolean value)
/*     */   {
/* 167 */     this.sendOnlyQAData = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public boolean isSendRBTransactions()
/*     */   {
/* 175 */     return this.sendRBTransactions;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSendRBTransactions(boolean value)
/*     */   {
/* 183 */     this.sendRBTransactions = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public boolean isSendRDTransactions()
/*     */   {
/* 191 */     return this.sendRDTransactions;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSendRDTransactions(boolean value)
/*     */   {
/* 199 */     this.sendRDTransactions = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public XMLGregorianCalendar getStartTime()
/*     */   {
/* 211 */     return this.startTime;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setStartTime(XMLGregorianCalendar value)
/*     */   {
/* 223 */     this.startTime = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public ArrayOfAQSParameterTag getTags()
/*     */   {
/* 235 */     return this.tags;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setTags(ArrayOfAQSParameterTag value)
/*     */   {
/* 247 */     this.tags = value;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\agilaire\AQS3WebServiceArgument.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */