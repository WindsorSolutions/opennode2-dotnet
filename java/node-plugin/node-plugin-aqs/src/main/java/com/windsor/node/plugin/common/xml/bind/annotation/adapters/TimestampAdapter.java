/*    */ package com.windsor.node.plugin.common.xml.bind.annotation.adapters;
/*    */ 
/*    */ import java.sql.Timestamp;
/*    */ import java.util.Calendar;
/*    */ import java.util.Date;
/*    */ import java.util.GregorianCalendar;
/*    */ import javax.xml.bind.DatatypeConverter;
/*    */ import javax.xml.bind.annotation.adapters.XmlAdapter;
/*    */ 
/*    */ 
/*    */ 
/*    */ public class TimestampAdapter
/*    */   extends XmlAdapter<String, Timestamp>
/*    */ {
/*    */   public Timestamp unmarshal(String s)
/*    */     throws Exception
/*    */   {
/* 18 */     return new Timestamp(DatatypeConverter.parseDate(s).getTime().getTime());
/*    */   }
/*    */   
/*    */   public String marshal(Timestamp timestamp) throws Exception
/*    */   {
/* 23 */     Calendar cal = new GregorianCalendar();
/* 24 */     cal.setTime(timestamp);
/* 25 */     return DatatypeConverter.printDate(cal);
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\bind\annotation\adapters\TimestampAdapter.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */