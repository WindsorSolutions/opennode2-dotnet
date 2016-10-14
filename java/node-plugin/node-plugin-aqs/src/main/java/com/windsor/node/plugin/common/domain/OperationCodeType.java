/*    */ package com.windsor.node.plugin.common.domain;
/*    */ 
/*    */ import javax.xml.bind.annotation.XmlEnum;
/*    */ import javax.xml.bind.annotation.XmlEnumValue;
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
/*    */ @XmlType(name="OperationCodeType", namespace="http://www.exchangenetwork.net/schema/header/2")
/*    */ @XmlEnum
/*    */ public enum OperationCodeType
/*    */ {
/* 39 */   NONE("None"), 
/*    */   
/* 41 */   REFRESH("Refresh"), 
/*    */   
/* 43 */   INSERT("Insert"), 
/*    */   
/* 45 */   UPDATE("Update"), 
/*    */   
/* 47 */   DELETE("Delete"), 
/*    */   
/* 49 */   MERGE("Merge");
/*    */   
/*    */   private final String value;
/*    */   
/*    */   private OperationCodeType(String v) {
/* 54 */     this.value = v;
/*    */   }
/*    */   
/*    */   public String value() {
/* 58 */     return this.value;
/*    */   }
/*    */   
/*    */   public static OperationCodeType fromValue(String v) {
/* 62 */     for (OperationCodeType c : OperationCodeType.values()) {
/* 63 */       if (c.value.equals(v)) {
/* 64 */         return c;
/*    */       }
/*    */     }
/* 67 */     throw new IllegalArgumentException(v);
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\domain\OperationCodeType.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */