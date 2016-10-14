/*     */ package com.windsor.node.plugin.common.velocity.jdbc;
/*     */ 
/*     */ import com.windsor.node.plugin.common.velocity.TemplateHelper;
/*     */ import java.sql.Connection;
/*     */ import java.sql.DatabaseMetaData;
/*     */ import java.sql.Date;
/*     */ import java.sql.PreparedStatement;
/*     */ import java.sql.SQLException;
/*     */ import java.sql.Timestamp;
/*     */ import java.text.ParseException;
/*     */ import java.text.SimpleDateFormat;
/*     */ import java.util.ArrayList;
/*     */ import java.util.Iterator;
/*     */ import javax.sql.DataSource;
/*     */ import org.apache.commons.beanutils.BasicDynaBean;
/*     */ import org.apache.commons.beanutils.BasicDynaClass;
/*     */ import org.apache.commons.beanutils.ConvertUtils;
/*     */ import org.apache.commons.beanutils.DynaBean;
/*     */ import org.apache.commons.beanutils.PropertyUtils;
/*     */ import org.apache.commons.beanutils.ResultSetDynaClass;
/*     */ import org.apache.commons.lang3.StringUtils;
/*     */ import org.slf4j.Logger;
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
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ public class JdbcTemplateHelper
/*     */   extends TemplateHelper
/*     */ {
/*     */   private static final String ORACLE = "oracle";
/*     */   private static final String MS_SQL = "microsoft sql server";
/*     */   private static final String MY_SQL = "mysql";
/*     */   private Connection connection;
/*     */   public JdbcTemplateHelper() {}
/*     */   
/*     */   public static enum DbType
/*     */   {
/*  92 */     Oracle,  MSSQL,  MySQL,  Unrecognized;
/*     */     
/*     */ 
/*     */ 
/*     */     private DbType() {}
/*     */   }
/*     */   
/*     */ 
/* 100 */   private int resultingRecordCount = 0;
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
/*     */   public JdbcTemplateHelper(DataSource dataSource)
/*     */   {
/* 122 */     if (dataSource == null) {
/* 123 */       throw new IllegalArgumentException("null datasource");
/*     */     }
/*     */     try {
/* 126 */       this.connection = dataSource.getConnection();
/*     */     } catch (SQLException e) {
/* 128 */       throw new RuntimeException(e);
/*     */     }
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public DbType getDbType()
/*     */   {
/* 140 */     DbType type = DbType.Unrecognized;
/*     */     
/* 142 */     if (null != this.connection)
/*     */     {
/*     */       String driverName;
/*     */       
/*     */       try
/*     */       {
/* 148 */         driverName = this.connection.getMetaData().getDriverName();
/* 149 */         this.logger.debug("Driver name: " + driverName);
/*     */       }
/*     */       catch (SQLException sqle)
/*     */       {
/* 153 */         throw new RuntimeException("couldn't get jdbc driver name from connection");
/*     */       }
/*     */       
/*     */ 
/* 157 */       if (StringUtils.containsIgnoreCase(driverName, "oracle"))
/*     */       {
/* 159 */         type = DbType.Oracle;
/*     */       }
/* 161 */       else if (StringUtils.containsIgnoreCase(driverName, "microsoft sql server"))
/*     */       {
/* 163 */         type = DbType.MSSQL;
/*     */       }
/* 165 */       else if (StringUtils.containsIgnoreCase(driverName, "mysql"))
/*     */       {
/* 167 */         type = DbType.MySQL;
/*     */       }
/*     */     }
/*     */     
/* 171 */     this.logger.debug("Using database type " + type);
/*     */     
/* 173 */     return type;
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
/**
 * @deprecated
 */
/*     */   public String toDbDateString(String dateString)
/*     */   {
/* 194 */     this.logger.debug("toDbDateString: " + dateString);
/*     */     
/*     */     Date date;
/*     */     
/*     */     try
/*     */     {
/* 200 */       date = makeSqlDate(dateString);
/*     */     }
/*     */     catch (ParseException pe)
/*     */     {
/* 204 */       throw new IllegalArgumentException("Not a recognized date format, root exception: " + pe);
/*     */     }
/*     */     
/*     */     String formatStr;
/* 210 */     if (getDbType().equals(DbType.Oracle))
/*     */     {
/* 212 */       formatStr = "dd-MMM-yy";
/*     */     }
/*     */     else
/*     */     {
/* 216 */       formatStr = "yyyy-MM-dd";
/*     */     }
/*     */     
/* 219 */     SimpleDateFormat sdf = new SimpleDateFormat(formatStr);
/*     */     
/* 221 */     String output = sdf.format(date);
/* 222 */     this.logger.debug("toDbDateString output: " + output);
/*     */     
/* 224 */     return output;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public Date covertToDbDate(String dateString)
/*     */   {
/* 235 */     this.logger.debug("covertToDbDate: " + dateString);
/*     */     Date date;
/*     */     try
/*     */     {
/* 239 */       date = makeSqlDate(dateString);
/*     */     }
/*     */     catch (ParseException pe)
/*     */     {
/* 243 */       throw new IllegalArgumentException("Not a recognized date format, root exception: " + pe);
/*     */     }
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
/* 265 */     SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
/* 266 */     this.logger.debug("covertToDbDate output: " + sdf.format(date));
/* 267 */     return date;
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
/*     */   public Object[] getList(String sql, String propertyName)
/*     */   {
/* 289 */     return getList(sql, null, propertyName, 12);
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
/*     */   public Object[] getList(String sql, Object arg, String propertyName)
/*     */   {
/* 314 */     return getList(sql, trapArrayList(arg), propertyName, 12);
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
/*     */ 
/*     */   public Object[] getList(String sql, Object arg, String propertyName, int type)
/*     */   {
/* 342 */     return getList(sql, trapArrayList(arg), propertyName, type);
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
/*     */   public Object[] getList(String sql, Object[] args, String propertyName, int type)
/*     */   {
/*     */     try
/*     */     {
/* 368 */       PreparedStatement ps = getPreparedStatement(sql, args, type);
/*     */       
/* 370 */       ResultSetDynaClass rsdc = new ResultSetDynaClass(ps.executeQuery());
/*     */       
/* 372 */       ArrayList<Object> results = new ArrayList();
/*     */       
/* 374 */       Iterator<Object> rows = rsdc.iterator();
/* 375 */       while (rows.hasNext()) {
/* 376 */         DynaBean bean = (DynaBean)rows.next();
/* 377 */         results.add(bean.get(propertyName));
/*     */       }
/*     */       
/* 380 */       ps.close();
/*     */       
/* 382 */       return results.toArray();
/*     */     }
/*     */     catch (Exception ex) {
/* 385 */       this.logger.error(ex.getMessage(), ex);
/* 386 */       throw new RuntimeException("Error while getting list: " + ex.getMessage(), ex);
/*     */     }
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
/*     */   public Object getObject(String sql, Object arg)
/*     */   {
/* 408 */     return getObject(sql, trapArrayList(arg));
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
/*     */   public Object getObject(String sql, Object[] args)
/*     */   {
/*     */     try
/*     */     {
/* 430 */       PreparedStatement ps = getPreparedStatement(sql, args, 12);
/*     */       
/*     */ 
/* 433 */       ResultSetDynaClass rsdc = new ResultSetDynaClass(ps.executeQuery());
/*     */       
/* 435 */       BasicDynaClass bdc = new BasicDynaClass("objectCopy", BasicDynaBean.class, rsdc.getDynaProperties());
/*     */       
/*     */ 
/* 438 */       DynaBean newRow = null;
/*     */       
/* 440 */       Iterator<Object> rows = rsdc.iterator();
/* 441 */       if (rows.hasNext()) {
/* 442 */         DynaBean oldRow = (DynaBean)rows.next();
/* 443 */         newRow = bdc.newInstance();
/* 444 */         PropertyUtils.copyProperties(newRow, oldRow);
/*     */       }
/*     */       
/*     */ 
/* 448 */       ps.close();
/*     */       
/* 450 */       return newRow;
/*     */     }
/*     */     catch (Exception ex) {
/* 453 */       this.logger.error(ex.getMessage(), ex);
/* 454 */       throw new RuntimeException("Error in getObject(): " + ex.getMessage(), ex);
/*     */     }
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
/*     */   public Iterator<DynaBean> getData(String sql)
/*     */   {
/* 470 */     return getData(sql, null);
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
/*     */   public Iterator<DynaBean> getData(String sql, Object arg)
/*     */   {
/* 490 */     return getData(sql, trapArrayList(arg));
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
/*     */   public Iterator<DynaBean> getData(String sql, Object[] args)
/*     */   {
/* 511 */     return getData(sql, args, 12);
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
/*     */   public Iterator<DynaBean> getData(String sql, Object[] args, int type)
/*     */   {
/*     */     try
/*     */     {
/* 539 */       PreparedStatement ps = getPreparedStatement(sql, args, type);
/*     */       
/* 541 */       ResultSetDynaClass rsdc = new ResultSetDynaClass(ps.executeQuery());
/*     */       
/* 543 */       ArrayList<DynaBean> results = new ArrayList();
/* 544 */       BasicDynaClass bdc = new BasicDynaClass("objectCopy", BasicDynaBean.class, rsdc.getDynaProperties());
/*     */       
/*     */ 
/*     */ 
/*     */ 
/* 549 */       Iterator<Object> rows = rsdc.iterator();
/* 550 */       while (rows.hasNext()) {
/* 551 */         DynaBean oldRow = (DynaBean)rows.next();
/* 552 */         DynaBean newRow = bdc.newInstance();
/* 553 */         PropertyUtils.copyProperties(newRow, oldRow);
/* 554 */         results.add(newRow);
/*     */       }
/*     */       
/*     */ 
/* 558 */       ps.close();
/*     */       
/* 560 */       this.logger.trace("query returned " + results.size() + " results");
/* 561 */       return results.iterator();
/*     */     }
/*     */     catch (Exception ex) {
/* 564 */       this.logger.error(ex.getMessage(), ex);
/* 565 */       throw new RuntimeException("Error in getData(): " + ex.getMessage(), ex);
/*     */     }
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   private PreparedStatement getPreparedStatement(String sql, Object[] args, int type)
/*     */   {
/* 574 */     checkConnection();
/*     */     
/* 576 */     traceArgs(sql, args, null, type);
/*     */     
/*     */     try
/*     */     {
/* 580 */       PreparedStatement ps = this.connection.prepareStatement(sql);
/*     */       
/* 582 */       if ((args != null) && (args.length > 0))
/*     */       {
/* 584 */         for (int i = 1; i <= args.length; i++)
/*     */         {
/* 586 */           Object argVal = args[(i - 1)];
/*     */           
/* 588 */           if ((type == -5) || (type == 4))
/*     */           {
/* 590 */             this.logger.trace("Converting " + argVal + " to int");
/* 591 */             ps.setInt(i, ((Integer)ConvertUtils.convert(argVal, Integer.TYPE)).intValue());
/*     */ 
/*     */           }
/* 594 */           else if (type == 93)
/*     */           {
/* 596 */             this.logger.trace("Converting " + argVal + " to Timestamp");
/* 597 */             ps.setTimestamp(i, new Timestamp(makeSqlDate(argVal).getTime()));
/*     */ 
/*     */           }
/* 600 */           else if (type == 91)
/*     */           {
/* 602 */             this.logger.trace("Converting " + argVal + " to Sql Date");
/* 603 */             ps.setDate(i, makeSqlDate(argVal));
/*     */           }
/*     */           else
/*     */           {
/* 607 */             ps.setObject(i, argVal);
/*     */           }
/*     */         }
/*     */       }
/*     */       
/* 612 */       return ps;
/*     */     }
/*     */     catch (Exception ex) {
/* 615 */       this.logger.error(ex.getMessage(), ex);
/* 616 */       throw new RuntimeException("Error preparing statement : " + ex.getMessage(), ex);
/*     */     }
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   private void traceArgs(String sql, Object[] args, String propertyName, int type)
/*     */   {
/* 625 */     if (StringUtils.isNotBlank(sql)) {
/* 626 */       this.logger.trace("sql = " + sql);
/*     */     }
/*     */     
/* 629 */     if ((null != args) && (args.length > 0))
/*     */     {
/* 631 */       this.logger.trace("args.length = " + args.length);
/*     */       
/* 633 */       for (int i = 0; i < args.length; i++) {
/* 634 */         this.logger.trace("args[" + i + "] = " + args[i]);
/*     */       }
/*     */     }
/*     */     
/* 638 */     if (StringUtils.isNotBlank(propertyName)) {
/* 639 */       this.logger.trace("propertyName = " + propertyName);
/*     */     }
/* 641 */     this.logger.trace("type = " + type);
/*     */   }
/*     */   
/*     */   private void checkConnection()
/*     */   {
/* 646 */     if (null == this.connection) {
/* 647 */       throw new RuntimeException("Connection is null");
/*     */     }
/*     */     try
/*     */     {
/* 651 */       if (this.connection.isClosed()) {
/* 652 */         throw new RuntimeException("Connection is closed");
/*     */       }
/*     */     } catch (SQLException e) {
/* 655 */       throw new RuntimeException("Problem checking connection status: " + e);
/*     */     }
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public int getResultingRecordCount()
/*     */   {
/* 664 */     return this.resultingRecordCount;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */   public void setResultingRecordCount(int resultingRecordCount)
/*     */   {
/* 671 */     this.resultingRecordCount = resultingRecordCount;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */   public Connection getConnection()
/*     */   {
/* 678 */     return this.connection;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setConnection(Connection connection)
/*     */   {
/* 686 */     this.connection = connection;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\velocity\jdbc\JdbcTemplateHelper.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */