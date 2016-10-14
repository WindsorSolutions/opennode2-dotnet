/*    */ package com.windsor.node.plugin.common.domain;
/*    */ 
/*    */ import java.math.BigInteger;
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
/*    */ @XmlAccessorType(XmlAccessType.FIELD)
/*    */ @XmlType(name="X509IssuerSerialType", propOrder={"x509IssuerName", "x509SerialNumber"})
/*    */ public class X509IssuerSerialType
/*    */ {
/*    */   @XmlElement(name="X509IssuerName", required=true)
/*    */   protected String x509IssuerName;
/*    */   @XmlElement(name="X509SerialNumber", required=true)
/*    */   protected BigInteger x509SerialNumber;
/*    */   
/*    */   public String getX509IssuerName()
/*    */   {
/* 59 */     return this.x509IssuerName;
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   public void setX509IssuerName(String value)
/*    */   {
/* 71 */     this.x509IssuerName = value;
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   public BigInteger getX509SerialNumber()
/*    */   {
/* 83 */     return this.x509SerialNumber;
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   public void setX509SerialNumber(BigInteger value)
/*    */   {
/* 95 */     this.x509SerialNumber = value;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\domain\X509IssuerSerialType.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */