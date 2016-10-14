/*     */ package com.windsor.node.plugin.aqs.agilaire;
/*     */ 
/*     */ import javax.xml.bind.JAXBElement;
/*     */ import javax.xml.bind.annotation.XmlAccessType;
/*     */ import javax.xml.bind.annotation.XmlAccessorType;
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
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ @XmlAccessorType(XmlAccessType.FIELD)
/*     */ @XmlType(name="AQSParameterInformation", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", propOrder={"agencyCode", "countyTribalCode", "countyTribalDescription", "parameterCode", "parameterName", "parameterOccurrenceCode", "siteCode", "siteName", "stateAbbreviation", "stateCode", "systemName"})
/*     */ public class AQSParameterInformation
/*     */ {
/*     */   @XmlElementRef(name="AgencyCode", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<String> agencyCode;
/*     */   @XmlElementRef(name="CountyTribalCode", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<String> countyTribalCode;
/*     */   @XmlElementRef(name="CountyTribalDescription", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<String> countyTribalDescription;
/*     */   @XmlElementRef(name="ParameterCode", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<String> parameterCode;
/*     */   @XmlElementRef(name="ParameterName", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<String> parameterName;
/*     */   @XmlElementRef(name="ParameterOccurrenceCode", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<Integer> parameterOccurrenceCode;
/*     */   @XmlElementRef(name="SiteCode", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<String> siteCode;
/*     */   @XmlElementRef(name="SiteName", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<String> siteName;
/*     */   @XmlElementRef(name="StateAbbreviation", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<String> stateAbbreviation;
/*     */   @XmlElementRef(name="StateCode", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<String> stateCode;
/*     */   @XmlElementRef(name="SystemName", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", type=JAXBElement.class, required=false)
/*     */   protected JAXBElement<String> systemName;
/*     */   
/*     */   public JAXBElement<String> getAgencyCode()
/*     */   {
/*  88 */     return this.agencyCode;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setAgencyCode(JAXBElement<String> value)
/*     */   {
/* 100 */     this.agencyCode = value;
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
/* 112 */     return this.countyTribalCode;
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
/* 124 */     this.countyTribalCode = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public JAXBElement<String> getCountyTribalDescription()
/*     */   {
/* 136 */     return this.countyTribalDescription;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setCountyTribalDescription(JAXBElement<String> value)
/*     */   {
/* 148 */     this.countyTribalDescription = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public JAXBElement<String> getParameterCode()
/*     */   {
/* 160 */     return this.parameterCode;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setParameterCode(JAXBElement<String> value)
/*     */   {
/* 172 */     this.parameterCode = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public JAXBElement<String> getParameterName()
/*     */   {
/* 184 */     return this.parameterName;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setParameterName(JAXBElement<String> value)
/*     */   {
/* 196 */     this.parameterName = value;
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
/* 208 */     return this.parameterOccurrenceCode;
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
/* 220 */     this.parameterOccurrenceCode = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public JAXBElement<String> getSiteCode()
/*     */   {
/* 232 */     return this.siteCode;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSiteCode(JAXBElement<String> value)
/*     */   {
/* 244 */     this.siteCode = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public JAXBElement<String> getSiteName()
/*     */   {
/* 256 */     return this.siteName;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSiteName(JAXBElement<String> value)
/*     */   {
/* 268 */     this.siteName = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public JAXBElement<String> getStateAbbreviation()
/*     */   {
/* 280 */     return this.stateAbbreviation;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setStateAbbreviation(JAXBElement<String> value)
/*     */   {
/* 292 */     this.stateAbbreviation = value;
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
/* 304 */     return this.stateCode;
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
/* 316 */     this.stateCode = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public JAXBElement<String> getSystemName()
/*     */   {
/* 328 */     return this.systemName;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSystemName(JAXBElement<String> value)
/*     */   {
/* 340 */     this.systemName = value;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\agilaire\AQSParameterInformation.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */