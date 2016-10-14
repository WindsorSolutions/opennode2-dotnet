/*    */ package com.windsor.node.plugin.common;
/*    */ 
/*    */ import com.windsor.node.common.domain.DomainStringStyle;
/*    */ import java.text.DecimalFormat;
/*    */ import org.apache.commons.lang3.builder.ReflectionToStringBuilder;
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ public abstract class BaseDomainObject
/*    */ {
/*    */   protected static final String DECIMAL_FORMAT = "#.################";
/*    */   
/*    */   protected String getFormattedDouble(Double d)
/*    */   {
/* 46 */     DecimalFormat f = new DecimalFormat("#.################");
/*    */     
/* 48 */     return f.format(d);
/*    */   }
/*    */   
/*    */   public String toString() {
/* 52 */     ReflectionToStringBuilder rtsb = new ReflectionToStringBuilder(this, new DomainStringStyle());
/*    */     
/* 54 */     rtsb.setAppendStatics(false);
/* 55 */     rtsb.setAppendTransients(false);
/* 56 */     return rtsb.toString();
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\BaseDomainObject.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */