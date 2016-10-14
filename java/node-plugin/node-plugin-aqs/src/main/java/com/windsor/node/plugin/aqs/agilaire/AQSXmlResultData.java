/*     */ package com.windsor.node.plugin.aqs.agilaire;
/*     */ 
/*     */ import javax.xml.bind.JAXBElement;
/*     */ import javax.xml.bind.annotation.XmlAccessType;
/*     */ import javax.xml.bind.annotation.XmlAccessorType;
/*     */ import javax.xml.bind.annotation.XmlElement;
/*     */ import javax.xml.bind.annotation.XmlElementRef;
/*     */ import javax.xml.bind.annotation.XmlType;
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
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
/*     */ @XmlType(name="AQSXmlResultData", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", propOrder={"aqsXmlDocumentText", "documentIsZipped", "generationWarnings", "zipCompressedAQSXmlDocument"})
/*     */ public class AQSXmlResultData
/*     */ {
/*     */   @XmlElementRef(name="AQSXmlDocumentText", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<String> aqsXmlDocumentText;
/*     */   @XmlElement(name="DocumentIsZipped")
/*     */   protected Boolean documentIsZipped;
/*     */   @XmlElementRef(name="GenerationWarnings", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<ArrayOfstring> generationWarnings;
/*     */   @XmlElementRef(name="ZipCompressedAQSXmlDocument", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<byte[]> zipCompressedAQSXmlDocument;
/*     */   
/*     */   public JAXBElement<String> getAQSXmlDocumentText()
/*     */   {
/*  61 */     return this.aqsXmlDocumentText;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setAQSXmlDocumentText(JAXBElement<String> value)
/*     */   {
/*  73 */     this.aqsXmlDocumentText = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public Boolean isDocumentIsZipped()
/*     */   {
/*  85 */     return this.documentIsZipped;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setDocumentIsZipped(Boolean value)
/*     */   {
/*  97 */     this.documentIsZipped = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public JAXBElement<ArrayOfstring> getGenerationWarnings()
/*     */   {
/* 109 */     return this.generationWarnings;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setGenerationWarnings(JAXBElement<ArrayOfstring> value)
/*     */   {
/* 121 */     this.generationWarnings = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public JAXBElement<byte[]> getZipCompressedAQSXmlDocument()
/*     */   {
/* 133 */     return this.zipCompressedAQSXmlDocument;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setZipCompressedAQSXmlDocument(JAXBElement<byte[]> value)
/*     */   {
/* 145 */     this.zipCompressedAQSXmlDocument = value;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\agilaire\AQSXmlResultData.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */