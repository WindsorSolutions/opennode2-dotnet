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
/*    */ @XmlType(name="ArrayOfAQSParameterTag", namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", propOrder={"aqsParameterTag"})
/*    */ public class ArrayOfAQSParameterTag
/*    */ {
/*    */   @XmlElement(name="AQSParameterTag", nillable=true)
/*    */   protected List<AQSParameterTag> aqsParameterTag;
/*    */   
/*    */   public List<AQSParameterTag> getAQSParameterTag()
/*    */   {
/* 63 */     if (this.aqsParameterTag == null) {
/* 64 */       this.aqsParameterTag = new ArrayList();
/*    */     }
/* 66 */     return this.aqsParameterTag;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\agilaire\ArrayOfAQSParameterTag.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */