/*    */ package com.windsor.node.plugin.common.xml.bind.annotation.adapters;
/*    */ 
/*    */ import java.util.Calendar;
/*    */ import java.util.Date;
/*    */ import javax.xml.bind.DatatypeConverter;
/*    */ import javax.xml.bind.annotation.adapters.XmlAdapter;
/*    */ import org.apache.commons.lang3.time.DateFormatUtils;
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ public class DateNoTimeZoneAdapter
/*    */   extends XmlAdapter<String, Date>
/*    */ {
/*    */   private static final String DATE_FORMAT = "yyyy-MM-dd";
/*    */   
/*    */   public Date unmarshal(String s)
/*    */     throws Exception
/*    */   {
/* 23 */     return DatatypeConverter.parseDate(s).getTime();
/*    */   }
/*    */   
/*    */   public String marshal(Date date) throws Exception
/*    */   {
/* 28 */     return DateFormatUtils.format(date, "yyyy-MM-dd");
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\bind\annotation\adapters\DateNoTimeZoneAdapter.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */