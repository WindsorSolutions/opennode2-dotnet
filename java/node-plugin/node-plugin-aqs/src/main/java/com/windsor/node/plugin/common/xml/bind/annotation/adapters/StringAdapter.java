/*    */ package com.windsor.node.plugin.common.xml.bind.annotation.adapters;
/*    */ 
/*    */ import javax.xml.bind.annotation.adapters.XmlAdapter;
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ public class StringAdapter
/*    */   extends XmlAdapter<String, String>
/*    */ {
/*    */   public String unmarshal(String s)
/*    */     throws Exception
/*    */   {
/* 15 */     return s;
/*    */   }
/*    */   
/*    */   public String marshal(String value) throws Exception
/*    */   {
/* 20 */     return value;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\bind\annotation\adapters\StringAdapter.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */