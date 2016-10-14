/*    */ package com.windsor.node.plugin.common.xml.bind.annotation.adapters;
/*    */ 
/*    */ import javax.xml.bind.annotation.adapters.XmlAdapter;
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ public class TwoDigitIntegerAdapter
/*    */   extends XmlAdapter<String, Integer>
/*    */ {
/*    */   public Integer unmarshal(String s)
/*    */     throws Exception
/*    */   {
/* 17 */     return Integer.valueOf(Integer.parseInt(s));
/*    */   }
/*    */   
/*    */   public String marshal(Integer value) throws Exception
/*    */   {
/* 22 */     return value == null ? null : String.format("%02d", new Object[] { value });
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\bind\annotation\adapters\TwoDigitIntegerAdapter.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */