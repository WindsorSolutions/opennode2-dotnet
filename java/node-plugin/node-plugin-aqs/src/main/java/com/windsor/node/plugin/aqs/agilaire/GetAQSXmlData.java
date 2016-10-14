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
/*    */ @XmlType(name="", propOrder={"args"})
/*    */ @XmlRootElement(name="GetAQSXmlData")
/*    */ public class GetAQSXmlData
/*    */ {
/*    */   @XmlElementRef(name="args", namespace="http://www.agilairecorp.com/", type=JAXBElement.class, required=false)
/*    */   protected JAXBElement<AQSWebServiceArgument> args;
/*    */   
/*    */   public JAXBElement<AQSWebServiceArgument> getArgs()
/*    */   {
/* 50 */     return this.args;
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   public void setArgs(JAXBElement<AQSWebServiceArgument> value)
/*    */   {
/* 62 */     this.args = value;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\agilaire\GetAQSXmlData.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */