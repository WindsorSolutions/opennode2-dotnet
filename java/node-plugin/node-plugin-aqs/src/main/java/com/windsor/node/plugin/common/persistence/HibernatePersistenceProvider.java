/*    */ package com.windsor.node.plugin.common.persistence;
/*    */ 
/*    */ import java.util.Properties;
/*    */ import javax.persistence.EntityManagerFactory;
/*    */ import javax.persistence.spi.PersistenceProvider;
/*    */ import javax.sql.DataSource;
/*    */ import org.apache.commons.lang3.StringUtils;
/*    */ import org.hibernate.ejb.HibernatePersistence;
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ public class HibernatePersistenceProvider
/*    */ {
/* 15 */   private final PersistenceProvider provider = new HibernatePersistence();
/*    */   
/*    */   public EntityManagerFactory createEntityManagerFactory(DataSource dataSource, PluginPersistenceConfig config)
/*    */   {
/* 19 */     Properties jpaProperties = new Properties();
/*    */     
/* 21 */     jpaProperties.put("hibernate.connection.datasource", dataSource);
/*    */     
/* 23 */     if (config.isDebugSql()) {
/* 24 */       jpaProperties.put("hibernate.show_sql", Boolean.TRUE);
/* 25 */       jpaProperties.put("hibernate.format_sql", Boolean.TRUE);
/*    */     }
/*    */     
/* 28 */     if (config.getBatchFetchSize() != null) {
/* 29 */       jpaProperties.put("hibernate.default_batch_fetch_size", config.getBatchFetchSize());
/*    */     }
/*    */     
/* 32 */     if (StringUtils.isNotBlank(config.getHibernateDialect())) {
/* 33 */       jpaProperties.put("hibernate.dialect", config.getHibernateDialect());
/*    */     }
/*    */     
/* 36 */     return this.provider.createContainerEntityManagerFactory(new HibernatePersistenceUnitInfo(jpaProperties, config), jpaProperties);
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\persistence\HibernatePersistenceProvider.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */