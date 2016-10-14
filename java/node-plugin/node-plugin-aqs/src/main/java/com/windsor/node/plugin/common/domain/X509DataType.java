/*    */ package com.windsor.node.plugin.common.domain;
/*    */ 
/*    */ import java.util.ArrayList;
/*    */ import java.util.List;
/*    */ import javax.xml.bind.annotation.XmlAccessType;
/*    */ import javax.xml.bind.annotation.XmlAccessorType;
/*    */ import javax.xml.bind.annotation.XmlAnyElement;
/*    */ import javax.xml.bind.annotation.XmlElementRefs;
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
/*    */ @XmlType(name="X509DataType", propOrder={"x509IssuerSerialOrX509SKIOrX509SubjectName"})
/*    */ public class X509DataType
/*    */ {
/*    */   @XmlElementRefs({@javax.xml.bind.annotation.XmlElementRef(name="X509IssuerSerial", namespace="http://www.w3.org/2000/09/xmldsig#", type=javax.xml.bind.JAXBElement.class), @javax.xml.bind.annotation.XmlElementRef(name="X509Certificate", namespace="http://www.w3.org/2000/09/xmldsig#", type=javax.xml.bind.JAXBElement.class), @javax.xml.bind.annotation.XmlElementRef(name="X509SKI", namespace="http://www.w3.org/2000/09/xmldsig#", type=javax.xml.bind.JAXBElement.class), @javax.xml.bind.annotation.XmlElementRef(name="X509SubjectName", namespace="http://www.w3.org/2000/09/xmldsig#", type=javax.xml.bind.JAXBElement.class), @javax.xml.bind.annotation.XmlElementRef(name="X509CRL", namespace="http://www.w3.org/2000/09/xmldsig#", type=javax.xml.bind.JAXBElement.class)})
/*    */   @XmlAnyElement(lax=true)
/*    */   protected List<Object> x509IssuerSerialOrX509SKIOrX509SubjectName;
/*    */   
/*    */   public List<Object> getX509IssuerSerialOrX509SKIOrX509SubjectName()
/*    */   {
/* 94 */     if (this.x509IssuerSerialOrX509SKIOrX509SubjectName == null) {
/* 95 */       this.x509IssuerSerialOrX509SKIOrX509SubjectName = new ArrayList();
/*    */     }
/* 97 */     return this.x509IssuerSerialOrX509SKIOrX509SubjectName;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\domain\X509DataType.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */