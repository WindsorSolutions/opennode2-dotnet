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
/*     */ 
/*     */ 
/*     */ @XmlAccessorType(XmlAccessType.FIELD)
/*     */ @XmlType(name="AQSWebServiceArgument", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", propOrder={"aqsxmlSchemaVersion", "compressPayload", "endTime", "sendOnlyQAData", "sendRATransactions", "sendRBTransactions", "sendRDTransactions", "sendRPTransactions", "startTime", "tags"})
/*     */ public class AQSWebServiceArgument
/*     */ {
/*     */   @XmlElement(name="AQSXMLSchemaVersion", required=true, nillable=true)
/*     */   protected String aqsxmlSchemaVersion;
/*     */   @XmlElement(name="CompressPayload")
/*     */   protected boolean compressPayload;
/*     */   @XmlElement(name="EndTime", required=true)
/*     */   @XmlSchemaType(name="dateTime")
/*     */   protected XMLGregorianCalendar endTime;
/*     */   @XmlElement(name="SendOnlyQAData")
/*     */   protected boolean sendOnlyQAData;
/*     */   @XmlElement(name="SendRATransactions")
/*     */   protected boolean sendRATransactions;
/*     */   @XmlElement(name="SendRBTransactions")
/*     */   protected boolean sendRBTransactions;
/*     */   @XmlElement(name="SendRDTransactions")
/*     */   protected boolean sendRDTransactions;
/*     */   @XmlElement(name="SendRPTransactions")
/*     */   protected boolean sendRPTransactions;
/*     */   @XmlElement(name="StartTime", required=true)
/*     */   @XmlSchemaType(name="dateTime")
/*     */   protected XMLGregorianCalendar startTime;
/*     */   @XmlElement(name="Tags", required=true, nillable=true)
/*     */   protected ArrayOfAQSParameterTag tags;
/*     */   
/*     */   public String getAQSXMLSchemaVersion()
/*     */   {
/*  87 */     return this.aqsxmlSchemaVersion;
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
/*  99 */     this.aqsxmlSchemaVersion = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public boolean isCompressPayload()
/*     */   {
/* 107 */     return this.compressPayload;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setCompressPayload(boolean value)
/*     */   {
/* 115 */     this.compressPayload = value;
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
/* 127 */     return this.endTime;
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
/* 139 */     this.endTime = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public boolean isSendOnlyQAData()
/*     */   {
/* 147 */     return this.sendOnlyQAData;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSendOnlyQAData(boolean value)
/*     */   {
/* 155 */     this.sendOnlyQAData = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public boolean isSendRATransactions()
/*     */   {
/* 163 */     return this.sendRATransactions;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSendRATransactions(boolean value)
/*     */   {
/* 171 */     this.sendRATransactions = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public boolean isSendRBTransactions()
/*     */   {
/* 179 */     return this.sendRBTransactions;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSendRBTransactions(boolean value)
/*     */   {
/* 187 */     this.sendRBTransactions = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public boolean isSendRDTransactions()
/*     */   {
/* 195 */     return this.sendRDTransactions;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSendRDTransactions(boolean value)
/*     */   {
/* 203 */     this.sendRDTransactions = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public boolean isSendRPTransactions()
/*     */   {
/* 211 */     return this.sendRPTransactions;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSendRPTransactions(boolean value)
/*     */   {
/* 219 */     this.sendRPTransactions = value;
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
/* 231 */     return this.startTime;
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
/* 243 */     this.startTime = value;
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
/* 255 */     return this.tags;
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
/* 267 */     this.tags = value;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\agilaire\AQSWebServiceArgument.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */