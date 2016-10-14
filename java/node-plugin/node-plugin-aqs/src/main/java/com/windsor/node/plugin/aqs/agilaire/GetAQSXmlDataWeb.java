/*     */ package com.windsor.node.plugin.aqs.agilaire;
/*     */ 
/*     */ import javax.xml.bind.JAXBElement;
/*     */ import javax.xml.bind.annotation.XmlAccessType;
/*     */ import javax.xml.bind.annotation.XmlAccessorType;
/*     */ import javax.xml.bind.annotation.XmlElementRef;
/*     */ import javax.xml.bind.annotation.XmlRootElement;
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
/*     */ @XmlAccessorType(XmlAccessType.FIELD)
/*     */ @XmlType(name="", propOrder={"startTime", "endTime", "aqsXmlSchemaVersion", "sendRdTransactions", "sendRbTransactions", "sendRaTransactions", "sendRpTransactions", "sendOnlyQaData"})
/*     */ @XmlRootElement(name="GetAQSXmlDataWeb")
/*     */ public class GetAQSXmlDataWeb
/*     */ {
/*     */   @XmlSchemaType(name="dateTime")
/*     */   protected XMLGregorianCalendar startTime;
/*     */   @XmlSchemaType(name="dateTime")
/*     */   protected XMLGregorianCalendar endTime;
/*     */   @XmlElementRef(name="aqsXmlSchemaVersion", namespace="http://www.agilairecorp.com/", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<String> aqsXmlSchemaVersion;
/*     */   protected Boolean sendRdTransactions;
/*     */   protected Boolean sendRbTransactions;
/*     */   protected Boolean sendRaTransactions;
/*     */   protected Boolean sendRpTransactions;
/*     */   protected Boolean sendOnlyQaData;
/*     */   
/*     */   public XMLGregorianCalendar getStartTime()
/*     */   {
/*  75 */     return this.startTime;
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
/*  87 */     this.startTime = value;
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
/*  99 */     return this.endTime;
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
/* 111 */     this.endTime = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public JAXBElement<String> getAqsXmlSchemaVersion()
/*     */   {
/* 123 */     return this.aqsXmlSchemaVersion;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setAqsXmlSchemaVersion(JAXBElement<String> value)
/*     */   {
/* 135 */     this.aqsXmlSchemaVersion = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public Boolean isSendRdTransactions()
/*     */   {
/* 147 */     return this.sendRdTransactions;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSendRdTransactions(Boolean value)
/*     */   {
/* 159 */     this.sendRdTransactions = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public Boolean isSendRbTransactions()
/*     */   {
/* 171 */     return this.sendRbTransactions;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSendRbTransactions(Boolean value)
/*     */   {
/* 183 */     this.sendRbTransactions = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public Boolean isSendRaTransactions()
/*     */   {
/* 195 */     return this.sendRaTransactions;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSendRaTransactions(Boolean value)
/*     */   {
/* 207 */     this.sendRaTransactions = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public Boolean isSendRpTransactions()
/*     */   {
/* 219 */     return this.sendRpTransactions;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSendRpTransactions(Boolean value)
/*     */   {
/* 231 */     this.sendRpTransactions = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public Boolean isSendOnlyQaData()
/*     */   {
/* 243 */     return this.sendOnlyQaData;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSendOnlyQaData(Boolean value)
/*     */   {
/* 255 */     this.sendOnlyQaData = value;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\agilaire\GetAQSXmlDataWeb.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */