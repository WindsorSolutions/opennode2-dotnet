/*     */ package com.windsor.node.plugin.common.velocity;
/*     */ 
/*     */ import java.text.ParseException;
/*     */ import java.text.SimpleDateFormat;
/*     */ import java.util.ArrayList;
/*     */ import java.util.Calendar;
/*     */ import java.util.GregorianCalendar;
/*     */ import java.util.TimeZone;
/*     */ import org.apache.commons.beanutils.converters.BooleanConverter;
/*     */ import org.apache.commons.lang3.StringEscapeUtils;
/*     */ import org.apache.commons.lang3.StringUtils;
/*     */ import org.apache.commons.lang3.time.DateUtils;
/*     */ import org.apache.commons.lang3.time.StopWatch;
/*     */ import org.slf4j.Logger;
/*     */ import org.slf4j.LoggerFactory;
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ public class TemplateHelper
/*     */ {
/*     */   public static final String XML_DATE_FORMAT = "yyyy-MM-dd";
/*     */   public static final String DATE_FORMAT_ORACLE_DEFAULT = "dd-MMM-yy";
/*     */   public static final String TIMESTAMP_FORMAT_MINS = "yyyy-MM-dd HH:mm";
/*     */   public static final String TIMESTAMP_FORMAT_SECS = "yyyy-MM-dd HH:mm:ss";
/*     */   public static final String TIMESTAMP_FORMAT_MILLI = "yyyy-MM-dd HH:mm:ss.S";
/*     */   public static final String TIMESTAMP_FORMAT_MILLI2 = "yyyy-MM-dd HH:mm:ss.SS";
/*     */   public static final String TIMESTAMP_FORMAT_MILLI3 = "yyyy-MM-dd HH:mm:ss.SSS";
/*     */   public static final String TIMESTAMP_FORMAT_MILLI4 = "yyyy-MM-dd HH:mm:ss.SSSS";
/*     */   public static final String AM_PM_INPUT_ERROR = "input must be in hh:mm:ss [AM|PM] format";
/*  76 */   public static final String[] DATE_FORMATS = { "yyyy-MM-dd", "dd-MMM-yy", "yyyy-MM-dd HH:mm", "yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd HH:mm:ss.S", "yyyy-MM-dd HH:mm:ss.SS", "yyyy-MM-dd HH:mm:ss.SSS", "yyyy-MM-dd HH:mm:ss.SSSS" };
/*     */   
/*     */ 
/*     */   protected static final int NUM_TIME_PARTS = 3;
/*     */   
/*     */ 
/*     */   protected static final int HOURS_IN_HALF_DAY = 12;
/*     */   
/*  84 */   protected Logger logger = LoggerFactory.getLogger(getClass());
/*     */   
/*  86 */   protected StopWatch watch = new StopWatch();
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   protected BooleanConverter booleanConverter;
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   protected SimpleDateFormat simpleDateFormat;
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void startStopWatch()
/*     */   {
/* 105 */     this.watch.start();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */   public void stopStopWatch()
/*     */   {
/* 112 */     this.watch.stop();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */   public void printElapsedTime()
/*     */   {
/* 119 */     print(this.watch.toString());
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String escapeXml(String val)
/*     */   {
/* 135 */     return StringEscapeUtils.escapeXml(val);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String escapeCsv(String val)
/*     */   {
/* 146 */     return StringEscapeUtils.escapeCsv(val);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String escapeHtml(String val)
/*     */   {
/* 157 */     return StringEscapeUtils.escapeHtml4(val);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String currentTimeAsXmlDate()
/*     */   {
/* 167 */     SimpleDateFormat sdfInput = new SimpleDateFormat("yyyy-MM-dd");
/* 168 */     return sdfInput.format(Calendar.getInstance(TimeZone.getDefault()).getTime());
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String toXmlBoolean(Object val)
/*     */   {
/* 195 */     if (null == this.booleanConverter)
/*     */     {
/* 197 */       this.booleanConverter = new BooleanConverter();
/*     */     }
/* 199 */     return ((Boolean)this.booleanConverter.convert(null, val)).toString();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String toXmlDate(Object val)
/*     */     throws ParseException
/*     */   {
/* 213 */     if (null == this.simpleDateFormat)
/*     */     {
/* 215 */       this.simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd");
/*     */     }
/*     */     
/* 218 */     return this.simpleDateFormat.format(DateUtils.parseDate(val.toString(), DATE_FORMATS));
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String toXmlDateTime(Object val)
/*     */   {
/* 231 */     SimpleDateFormat sdfInput = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss.S");
/*     */     
/* 233 */     return sdfInput.format(val);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String amPmStringToXmlTime(Object val)
/*     */   {
/* 247 */     String input = (String)val;
/* 248 */     this.logger.trace("amPmStringToXmlTime: input = " + input);
/*     */     
/* 250 */     boolean isPm = false;
/*     */     
/* 252 */     String[] timeAndAmPm = StringUtils.split(input);
/*     */     
/* 254 */     if (timeAndAmPm.length == 2)
/*     */     {
/* 256 */       String amPm = timeAndAmPm[1];
/* 257 */       isPm = amPm.equalsIgnoreCase("PM");
/*     */     }
/* 259 */     else if (timeAndAmPm.length > 2)
/*     */     {
/* 261 */       throw new IllegalArgumentException("input must be in hh:mm:ss [AM|PM] format");
/*     */     }
/*     */     
/* 264 */     String[] timeParts = StringUtils.split(timeAndAmPm[0], ":");
/*     */     
/* 266 */     if (timeParts.length != 3) {
/* 267 */       throw new IllegalArgumentException("input must be in hh:mm:ss [AM|PM] format");
/*     */     }
/*     */     
/* 270 */     int hour = Integer.parseInt(timeParts[0]);
/* 271 */     if (isPm) {
/* 272 */       hour += 12;
/*     */     }
/*     */     
/* 275 */     int minute = Integer.parseInt(timeParts[1]);
/* 276 */     int second = Integer.parseInt(timeParts[2]);
/*     */     
/* 278 */     GregorianCalendar cal = new GregorianCalendar();
/* 279 */     cal.set(11, hour);
/* 280 */     cal.set(12, minute);
/* 281 */     cal.set(13, second);
/*     */     
/* 283 */     SimpleDateFormat sdfOutput = new SimpleDateFormat("HH:mm:ss");
/* 284 */     String output = sdfOutput.format(cal.getTime());
/* 285 */     this.logger.trace("amPmStringToXmlTime: output = " + output);
/*     */     
/* 287 */     return output;
/*     */   }
/*     */   
/*     */   public String getCurrentDateTime()
/*     */   {
/* 292 */     return toXmlDateTime(new Long(System.currentTimeMillis()));
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void print(Object val)
/*     */   {
/* 301 */     if (val != null)
/*     */     {
/* 303 */       this.logger.info(val.toString());
/*     */     }
/*     */     else
/*     */     {
/* 307 */       this.logger.info("");
/*     */     }
/*     */   }
/*     */   
/*     */   protected java.sql.Date makeSqlDate(Object val) throws ParseException {
/* 312 */     return new java.sql.Date(DateUtils.parseDate(val.toString(), DATE_FORMATS).getTime());
/*     */   }
/*     */   
/*     */ 
/*     */   protected Object[] trapArrayList(Object arg)
/*     */   {
/* 318 */     Object[] newArgs = null;
/*     */     
/* 320 */     if (null != arg)
/*     */     {
/*     */ 
/* 323 */       if ((arg instanceof ArrayList))
/*     */       {
/* 325 */         this.logger.debug("converting ArrayList to Object[]");
/*     */         
/* 327 */         ArrayList<?> realArgs = (ArrayList)arg;
/*     */         
/* 329 */         newArgs = realArgs.toArray();
/*     */       }
/*     */       else
/*     */       {
/* 333 */         newArgs = new Object[] { arg };
/*     */       }
/*     */     }
/*     */     
/* 337 */     return newArgs;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\velocity\TemplateHelper.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */