/*    */ package com.windsor.node.plugin.common.xml.bind.annotation.adapters;
/*    */ 
/*    */ import java.math.BigDecimal;
/*    */ import javax.xml.bind.annotation.adapters.XmlAdapter;
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ public class DoubleAdapter
/*    */   extends XmlAdapter<String, Double>
/*    */ {
/*    */   public Double unmarshal(String s)
/*    */     throws Exception
/*    */   {
/* 16 */     return Double.valueOf(Double.parseDouble(s));
/*    */   }
/*    */   
/*    */   public String marshal(Double value) throws Exception
/*    */   {
/* 21 */     return value == null ? null : new BigDecimal(value.doubleValue()).toPlainString();
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\bind\annotation\adapters\DoubleAdapter.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */