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
/*    */ 
/*    */ @XmlAccessorType(XmlAccessType.FIELD)
/*    */ @XmlType(name="NameValuePair", namespace="http://www.exchangenetwork.net/schema/header/2", propOrder={"propertyName", "propertyValue"})
/*    */ public class NameValuePair
/*    */ {
/*    */   @XmlElement(name="PropertyName", required=true)
/*    */   protected String propertyName;
/*    */   @XmlElement(name="PropertyValue", required=true)
/*    */   protected Object propertyValue;
/*    */   
/*    */   public String getPropertyName()
/*    */   {
/* 58 */     return this.propertyName;
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   public void setPropertyName(String value)
/*    */   {
/* 70 */     this.propertyName = value;
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   public Object getPropertyValue()
/*    */   {
/* 82 */     return this.propertyValue;
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   public void setPropertyValue(Object value)
/*    */   {
/* 94 */     this.propertyValue = value;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\domain\NameValuePair.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */