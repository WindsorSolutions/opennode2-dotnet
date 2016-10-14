/*    */ package com.windsor.node.plugin.common.xml.bind.annotation.adapters;
/*    */ 
/*    */ import javax.xml.bind.annotation.adapters.XmlAdapter;
/*    */ import org.apache.commons.lang3.StringUtils;
/*    */ 
/*    */ public class GYearToIntegerAdapter
/*    */   extends XmlAdapter<String, Integer>
/*    */ {
/*    */   public Integer unmarshal(String v)
/*    */     throws Exception
/*    */   {
/* 12 */     if ((StringUtils.isBlank(v)) || (!StringUtils.isNumeric(v)))
/*    */     {
/* 14 */       return null;
/*    */     }
/* 16 */     return new Integer(v);
/*    */   }
/*    */   
/*    */   public String marshal(Integer v)
/*    */     throws Exception
/*    */   {
/* 22 */     if (v == null)
/*    */     {
/* 24 */       return "";
/*    */     }
/* 26 */     return v.toString();
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\bind\annotation\adapters\GYearToIntegerAdapter.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */