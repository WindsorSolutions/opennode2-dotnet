/*    */ package com.windsor.node.plugin.common.domain;
/*    */ 
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
/*    */ @XmlAccessorType(XmlAccessType.FIELD)
/*    */ @XmlType(name="RSAKeyValueType", propOrder={"modulus", "exponent"})
/*    */ public class RSAKeyValueType
/*    */ {
/*    */   @XmlElement(name="Modulus", required=true)
/*    */   protected byte[] modulus;
/*    */   @XmlElement(name="Exponent", required=true)
/*    */   protected byte[] exponent;
/*    */   
/*    */   public byte[] getModulus()
/*    */   {
/* 57 */     return this.modulus;
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   public void setModulus(byte[] value)
/*    */   {
/* 68 */     this.modulus = ((byte[])value);
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   public byte[] getExponent()
/*    */   {
/* 79 */     return this.exponent;
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   public void setExponent(byte[] value)
/*    */   {
/* 90 */     this.exponent = ((byte[])value);
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\domain\RSAKeyValueType.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */