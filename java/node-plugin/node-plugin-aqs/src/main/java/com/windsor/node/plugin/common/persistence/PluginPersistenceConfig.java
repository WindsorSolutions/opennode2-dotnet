/*    */ package com.windsor.node.plugin.common.persistence;
/*    */ 
/*    */ 
/*    */ public class PluginPersistenceConfig
/*    */ {
/*    */   private String rootEntityPackage;
/*    */   
/*    */   private ClassLoader classLoader;
/*    */   private String hibernateDialect;
/* 10 */   private boolean debugSql = Boolean.FALSE.booleanValue();
/*    */   private Integer batchFetchSize;
/*    */   
/*    */   public Integer getBatchFetchSize()
/*    */   {
/* 15 */     return this.batchFetchSize;
/*    */   }
/*    */   
/*    */   public PluginPersistenceConfig setBatchFetchSize(Integer batchFetchSize) {
/* 19 */     this.batchFetchSize = batchFetchSize;
/* 20 */     return this;
/*    */   }
/*    */   
/*    */   public boolean isDebugSql() {
/* 24 */     return this.debugSql;
/*    */   }
/*    */   
/*    */   public String getRootEntityPackage() {
/* 28 */     return this.rootEntityPackage;
/*    */   }
/*    */   
/*    */   public PluginPersistenceConfig rootEntityPackage(String rootEntityPackage) {
/* 32 */     this.rootEntityPackage = rootEntityPackage;
/* 33 */     return this;
/*    */   }
/*    */   
/*    */   public PluginPersistenceConfig hibernateDialect(String hibernateDialect) {
/* 37 */     this.hibernateDialect = hibernateDialect;
/* 38 */     return this;
/*    */   }
/*    */   
/*    */   public PluginPersistenceConfig classLoader(ClassLoader classLoader) {
/* 42 */     this.classLoader = classLoader;
/* 43 */     return this;
/*    */   }
/*    */   
/*    */   public ClassLoader getClassLoader()
/*    */   {
/* 48 */     return this.classLoader;
/*    */   }
/*    */   
/*    */   public PluginPersistenceConfig debugSql(boolean debugSql) {
/* 52 */     this.debugSql = debugSql;
/* 53 */     return this;
/*    */   }
/*    */   
/*    */   public String getHibernateDialect()
/*    */   {
/* 58 */     return this.hibernateDialect;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\persistence\PluginPersistenceConfig.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */