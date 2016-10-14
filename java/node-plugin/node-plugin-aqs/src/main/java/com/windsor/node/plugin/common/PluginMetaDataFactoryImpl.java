/*    */ package com.windsor.node.plugin.common;
/*    */ 
/*    */ import com.windsor.node.common.PluginMetaDataFactory;
/*    */ import com.windsor.node.common.domain.PluginMetaData;
/*    */ import java.util.Properties;
/*    */ import org.slf4j.Logger;
/*    */ import org.slf4j.LoggerFactory;
/*    */ 
/*    */ public class PluginMetaDataFactoryImpl implements PluginMetaDataFactory
/*    */ {
/* 11 */   protected final Logger logger = LoggerFactory.getLogger(PluginMetaDataFactoryImpl.class);
/*    */   
/*    */ 
/*    */   public PluginMetaData createPluginMetaData()
/*    */   {
/* 16 */     PluginMetaData pluginMetaData = new PluginMetaData();
/* 17 */     Properties props = new Properties();
/*    */     try
/*    */     {
/* 20 */       props.load(PluginMetaDataFactoryImpl.class.getClassLoader().getResourceAsStream("plugin-data.properties"));
/*    */     }
/*    */     catch (Exception e)
/*    */     {
/* 24 */       this.logger.error("Unable to load properties for PluginMetaData due to Exception, recovering but some functionality may be unavailable.", e);
/*    */     }
/* 26 */     pluginMetaData.setName(props.getProperty("name"));
/* 27 */     pluginMetaData.setFullName(props.getProperty("full.name"));
/* 28 */     pluginMetaData.setDescription(props.getProperty("description"));
/* 29 */     pluginMetaData.setVersion(props.getProperty("version"));
/* 30 */     pluginMetaData.setHelpText(props.getProperty("help.text"));
/* 31 */     return pluginMetaData;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\PluginMetaDataFactoryImpl.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */