/*    */ package com.windsor.node.plugin.common.domain;
/*    */ 
/*    */ import javax.xml.bind.annotation.XmlAccessType;
/*    */ import javax.xml.bind.annotation.XmlAccessorType;
/*    */ import javax.xml.bind.annotation.XmlAttribute;
/*    */ import javax.xml.bind.annotation.XmlID;
/*    */ import javax.xml.bind.annotation.XmlSchemaType;
/*    */ import javax.xml.bind.annotation.XmlType;
/*    */ import javax.xml.bind.annotation.XmlValue;
/*    */ import javax.xml.bind.annotation.adapters.CollapsedStringAdapter;
/*    */ import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
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
/*    */ @XmlType(name="SignatureValueType", propOrder={"value"})
/*    */ public class SignatureValueType
/*    */ {
/*    */   @XmlValue
/*    */   protected byte[] value;
/*    */   @XmlAttribute(name="Id")
/*    */   @XmlJavaTypeAdapter(CollapsedStringAdapter.class)
/*    */   @XmlID
/*    */   @XmlSchemaType(name="ID")
/*    */   protected String id;
/*    */   
/*    */   public byte[] getValue()
/*    */   {
/* 61 */     return this.value;
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   public void setValue(byte[] value)
/*    */   {
/* 72 */     this.value = ((byte[])value);
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   public String getId()
/*    */   {
/* 84 */     return this.id;
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   public void setId(String value)
/*    */   {
/* 96 */     this.id = value;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\domain\SignatureValueType.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */