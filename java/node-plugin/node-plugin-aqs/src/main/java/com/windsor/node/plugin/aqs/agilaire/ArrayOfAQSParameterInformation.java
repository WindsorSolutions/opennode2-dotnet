/*    */ package com.windsor.node.plugin.aqs.agilaire;
/*    */ 
/*    */ import java.util.ArrayList;
/*    */ import java.util.List;
/*    */ import javax.xml.bind.annotation.XmlAccessType;
/*    */ import javax.xml.bind.annotation.XmlAccessorType;
/*    */ import javax.xml.bind.annotation.XmlElement;
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
/*    */ @XmlType(name="ArrayOfAQSParameterInformation", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", propOrder={"aqsParameterInformation"})
/*    */ public class ArrayOfAQSParameterInformation
/*    */ {
/*    */   @XmlElement(name="AQSParameterInformation", nillable=true)
/*    */   protected List<AQSParameterInformation> aqsParameterInformation;
/*    */   
/*    */   public List<AQSParameterInformation> getAQSParameterInformation()
/*    */   {
/* 63 */     if (this.aqsParameterInformation == null) {
/* 64 */       this.aqsParameterInformation = new ArrayList();
/*    */     }
/* 66 */     return this.aqsParameterInformation;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\agilaire\ArrayOfAQSParameterInformation.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */