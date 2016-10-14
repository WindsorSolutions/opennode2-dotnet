/*    */ package com.windsor.node.plugin.aqs.agilaire;
/*    */ 
/*    */ import javax.xml.bind.JAXBElement;
/*    */ import javax.xml.bind.annotation.XmlAccessType;
/*    */ import javax.xml.bind.annotation.XmlAccessorType;
/*    */ import javax.xml.bind.annotation.XmlElementRef;
/*    */ import javax.xml.bind.annotation.XmlRootElement;
/*    */ import javax.xml.bind.annotation.XmlType;
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ @XmlAccessorType(XmlAccessType.FIELD)
/*    */ @XmlType(name="", propOrder={"getAQS3XmlDataResult"})
/*    */ @XmlRootElement(name="GetAQS3XmlDataResponse")
/*    */ public class GetAQS3XmlDataResponse
/*    */ {
/*    */   @XmlElementRef(name="GetAQS3XmlDataResult", namespace="http://www.agilairecorp.com/", type=JAXBElement.class, required=false)
/*    */   protected JAXBElement<AQSXmlResultData> getAQS3XmlDataResult;
/*    */   
/*    */   public JAXBElement<AQSXmlResultData> getGetAQS3XmlDataResult()
/*    */   {
/* 50 */     return this.getAQS3XmlDataResult;
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   public void setGetAQS3XmlDataResult(JAXBElement<AQSXmlResultData> value)
/*    */   {
/* 62 */     this.getAQS3XmlDataResult = value;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\agilaire\GetAQS3XmlDataResponse.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */