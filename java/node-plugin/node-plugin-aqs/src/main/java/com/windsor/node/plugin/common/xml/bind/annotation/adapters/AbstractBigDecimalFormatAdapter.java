/*    */ package com.windsor.node.plugin.common.xml.bind.annotation.adapters;
/*    */ 
/*    */ import java.math.BigDecimal;
/*    */ import java.text.DecimalFormat;
/*    */ import javax.xml.bind.annotation.adapters.XmlAdapter;
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ public abstract class AbstractBigDecimalFormatAdapter
/*    */   extends XmlAdapter<String, BigDecimal>
/*    */ {
/*    */   protected abstract String getNumberFormatString();
/*    */   
/*    */   public BigDecimal unmarshal(String s)
/*    */     throws Exception
/*    */   {
/* 25 */     return new BigDecimal(s);
/*    */   }
/*    */   
/*    */   public String marshal(BigDecimal value) throws Exception
/*    */   {
/* 30 */     return value == null ? null : new DecimalFormat(getNumberFormatString()).format(value);
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\bind\annotation\adapters\AbstractBigDecimalFormatAdapter.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */