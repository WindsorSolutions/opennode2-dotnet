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
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ public class YesNoAdapter
/*    */   extends XmlAdapter<String, String>
/*    */ {
/*    */   private static final String JAVA_TRUE_VALUE = "Y";
/*    */   private static final String XML_TRUE_VALUE = "true";
/*    */   private static final String XML_FALSE_VALUE = "false";
/*    */   
/*    */   public String unmarshal(String s)
/*    */     throws Exception
/*    */   {
/* 28 */     return s;
/*    */   }
/*    */   
/*    */   public String marshal(String value) throws Exception
/*    */   {
/* 33 */     return "Y".equals(value) ? "true" : value == null ? null : "false";
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\bind\annotation\adapters\YesNoAdapter.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */