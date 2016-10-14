/*    */ package com.windsor.node.plugin.common.xml.bind.annotation.adapters;
/*    */ 
/*    */ import java.util.Calendar;
/*    */ import java.util.Date;
/*    */ import java.util.GregorianCalendar;
/*    */ import javax.xml.bind.DatatypeConverter;
/*    */ import javax.xml.bind.annotation.adapters.XmlAdapter;
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ public class DateTimeAdapter
/*    */   extends XmlAdapter<String, Date>
/*    */ {
/*    */   public Date unmarshal(String s)
/*    */     throws Exception
/*    */   {
/* 18 */     return DatatypeConverter.parseDateTime(s).getTime();
/*    */   }
/*    */   
/*    */   public String marshal(Date date) throws Exception
/*    */   {
/* 23 */     Calendar cal = new GregorianCalendar();
/* 24 */     cal.setTime(date);
/* 25 */     return DatatypeConverter.printDateTime(cal);
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\bind\annotation\adapters\DateTimeAdapter.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */