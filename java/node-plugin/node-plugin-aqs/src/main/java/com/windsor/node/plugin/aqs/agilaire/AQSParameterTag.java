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
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ @XmlAccessorType(XmlAccessType.FIELD)
/*     */ @XmlType(name="AQSParameterTag", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", propOrder={"agencyCode", "countyTribalCode", "durationCode", "parameterCode", "parameterOccurrenceCode", "siteCode", "stateCode"})
/*     */ public class AQSParameterTag
/*     */ {
/*     */   @XmlElement(name="AgencyCode", required=true, nillable=true)
/*     */   protected String agencyCode;
/*     */   @XmlElementRef(name="CountyTribalCode", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<String> countyTribalCode;
/*     */   @XmlElementRef(name="DurationCode", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<String> durationCode;
/*     */   @XmlElement(name="ParameterCode", required=true, nillable=true)
/*     */   protected String parameterCode;
/*     */   @XmlElementRef(name="ParameterOccurrenceCode", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<Integer> parameterOccurrenceCode;
/*     */   @XmlElement(name="SiteCode", required=true, nillable=true)
/*     */   protected String siteCode;
/*     */   @XmlElementRef(name="StateCode", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<String> stateCode;
/*     */   
/*     */   public String getAgencyCode()
/*     */   {
/*  73 */     return this.agencyCode;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setAgencyCode(String value)
/*     */   {
/*  85 */     this.agencyCode = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public JAXBElement<String> getCountyTribalCode()
/*     */   {
/*  97 */     return this.countyTribalCode;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setCountyTribalCode(JAXBElement<String> value)
/*     */   {
/* 109 */     this.countyTribalCode = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public JAXBElement<String> getDurationCode()
/*     */   {
/* 121 */     return this.durationCode;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setDurationCode(JAXBElement<String> value)
/*     */   {
/* 133 */     this.durationCode = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String getParameterCode()
/*     */   {
/* 145 */     return this.parameterCode;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setParameterCode(String value)
/*     */   {
/* 157 */     this.parameterCode = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public JAXBElement<Integer> getParameterOccurrenceCode()
/*     */   {
/* 169 */     return this.parameterOccurrenceCode;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setParameterOccurrenceCode(JAXBElement<Integer> value)
/*     */   {
/* 181 */     this.parameterOccurrenceCode = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String getSiteCode()
/*     */   {
/* 193 */     return this.siteCode;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSiteCode(String value)
/*     */   {
/* 205 */     this.siteCode = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public JAXBElement<String> getStateCode()
/*     */   {
/* 217 */     return this.stateCode;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setStateCode(JAXBElement<String> value)
/*     */   {
/* 229 */     this.stateCode = value;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\agilaire\AQSParameterTag.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */