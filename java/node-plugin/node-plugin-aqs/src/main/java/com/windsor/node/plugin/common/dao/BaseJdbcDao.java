/*     */ package com.windsor.node.plugin.common.dao;
/*     */ 
/*     */ import java.sql.ResultSet;
/*     */ import java.sql.ResultSetMetaData;
/*     */ import java.sql.SQLException;
/*     */ import java.util.ArrayList;
/*     */ import java.util.List;
/*     */ import org.apache.commons.lang3.StringEscapeUtils;
/*     */ import org.apache.commons.lang3.StringUtils;
/*     */ import org.slf4j.Logger;
/*     */ import org.slf4j.LoggerFactory;
/*     */ import org.springframework.jdbc.core.support.JdbcDaoSupport;
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
/*     */ public abstract class BaseJdbcDao
/*     */   extends JdbcDaoSupport
/*     */ {
/*     */   public static final String COMMA = ", ";
/*     */   public static final String DOT = ".";
/*     */   public static final String APOS = "'";
/*     */   public static final String WHERE = " WHERE ";
/*     */   public static final String FROM = " FROM  ";
/*     */   public static final String SELECT = " SELECT ";
/*     */   public static final String UPDATE = " UPDATE ";
/*     */   public static final String SET = " SET ";
/*     */   public static final String INSERT = " INSERT INTO ";
/*     */   public static final String AND = " AND ";
/*     */   public static final String OR = " OR ";
/*     */   public static final String SELECT_COUNT_ALL_FROM = " SELECT COUNT(*) FROM ";
/*     */   public static final String ORDER_BY = " ORDER BY ";
/*     */   public static final String SELECT_ALL_FROM = " SELECT * FROM ";
/*     */   public static final String EQUALS = " = ";
/*     */   public static final String IN = " IN ";
/*     */   public static final String R_PAREN = ")";
/*     */   public static final String L_PAREN = "(";
/*     */   public static final String VALUES = " VALUES ";
/*     */   public static final String MAX = " MAX(";
/*     */   public static final String DISTINCT = " DISTINCT ";
/*     */   public static final String PARAM = " ? ";
/*     */   public static final String GT_PARAM = " > ? ";
/*     */   public static final String EQUALS_PARAM = " = ? ";
/*     */   public static final String NOT_EQUALS_PARAM = " != ? ";
/*     */   public static final String ROWNUM_PARAM = "ROWNUM <= ? ";
/*     */   private static final String DATA_SOURCE_CANNOT_BE_NULL = "DataSource cannot be null.";
/*  81 */   protected Logger logger = LoggerFactory.getLogger(getClass());
/*     */   
/*     */   protected void checkDaoConfig() {
/*  84 */     super.checkDaoConfig();
/*     */     
/*  86 */     if (getDataSource() == null) {
/*  87 */       this.logger.error("DataSource cannot be null.");
/*  88 */       throw new RuntimeException("DataSource cannot be null.");
/*     */     }
/*     */   }
/*     */   
/*     */   protected boolean validateStringArg(String arg)
/*     */   {
/*  94 */     if (StringUtils.isBlank(arg))
/*     */     {
/*  96 */       throw new RuntimeException("String arg was blank");
/*     */     }
/*     */     
/*  99 */     return true;
/*     */   }
/*     */   
/*     */   protected static List<String> getColumnNames(ResultSet rs)
/*     */     throws SQLException
/*     */   {
/* 105 */     List<String> columnNames = new ArrayList();
/*     */     
/* 107 */     ResultSetMetaData rsm = rs.getMetaData();
/* 108 */     int columnCount = rsm.getColumnCount();
/*     */     
/* 110 */     for (int i = 1; i <= columnCount; i++)
/*     */     {
/* 112 */       columnNames.add(rsm.getColumnName(i));
/*     */     }
/*     */     
/*     */ 
/* 116 */     return columnNames;
/*     */   }
/*     */   
/*     */   public static boolean containsColumnNamed(ResultSet rs, String columnName)
/*     */     throws SQLException
/*     */   {
/* 122 */     return getColumnNames(rs).contains(columnName);
/*     */   }
/*     */   
/*     */ 
/*     */   protected static String trimToXml(String s)
/*     */   {
/* 128 */     return StringUtils.trimToNull(StringEscapeUtils.escapeXml(s));
/*     */   }
/*     */   
/*     */   public static Integer getInteger(ResultSet rs, String columnName)
/*     */     throws SQLException
/*     */   {
/* 134 */     Integer value = null;
/*     */     
/* 136 */     int i = rs.getInt(columnName);
/*     */     
/* 138 */     if (!rs.wasNull())
/*     */     {
/* 140 */       value = new Integer(i);
/*     */     }
/*     */     
/* 143 */     return value;
/*     */   }
/*     */   
/*     */   public static Long getLong(ResultSet rs, String columnName)
/*     */     throws SQLException
/*     */   {
/* 149 */     Long value = null;
/*     */     
/* 151 */     int i = rs.getInt(columnName);
/*     */     
/* 153 */     if (!rs.wasNull())
/*     */     {
/* 155 */       value = new Long(i);
/*     */     }
/*     */     
/* 158 */     return value;
/*     */   }
/*     */   
/*     */   public static Double getDouble(ResultSet rs, String columnName)
/*     */     throws SQLException
/*     */   {
/* 164 */     Double value = null;
/*     */     
/* 166 */     double d = rs.getDouble(columnName);
/*     */     
/* 168 */     if (!rs.wasNull())
/*     */     {
/* 170 */       value = new Double(d);
/*     */     }
/*     */     
/* 173 */     return value;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\dao\BaseJdbcDao.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */