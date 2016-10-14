/*     */ package com.windsor.node.plugin.common.velocity;
/*     */ 
/*     */ import java.io.File;
/*     */ import javax.naming.ConfigurationException;
/*     */ import javax.sql.DataSource;
/*     */ import org.apache.commons.io.FilenameUtils;
/*     */ import org.apache.commons.lang3.StringUtils;
/*     */ import org.slf4j.Logger;
/*     */ import org.slf4j.LoggerFactory;
/*     */ import org.springframework.beans.factory.InitializingBean;
/*     */ import org.springframework.context.ApplicationContext;
/*     */ import org.springframework.context.support.ClassPathXmlApplicationContext;
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
/*     */ public class ConsoleVelocityHelper
/*     */   implements InitializingBean
/*     */ {
/*  55 */   protected static Logger logger = LoggerFactory.getLogger(ConsoleVelocityHelper.class.getClass());
/*     */   
/*     */   private VelocityHelper velocityHelper;
/*     */   private DataSource dataSource;
/*     */   private String helperArgs;
/*     */   private String outputFile;
/*     */   private String templatePath;
/*     */   
/*     */   public void afterPropertiesSet()
/*     */     throws Exception
/*     */   {
/*  66 */     if (this.velocityHelper == null) {
/*  67 */       throw new ConfigurationException("null velocityHelper");
/*     */     }
/*     */     
/*  70 */     if (this.dataSource == null) {
/*  71 */       throw new ConfigurationException("null dataSource");
/*     */     }
/*     */     
/*  74 */     if (this.outputFile == null) {
/*  75 */       throw new ConfigurationException("null outputFile");
/*     */     }
/*     */     
/*  78 */     if (StringUtils.isBlank(this.templatePath)) {
/*  79 */       throw new ConfigurationException("null templatePath");
/*     */     }
/*     */     
/*  82 */     File templateFile = new File(this.templatePath);
/*  83 */     if (!templateFile.exists()) {
/*  84 */       throw new ConfigurationException("templatePath does not exist:" + templateFile);
/*     */     }
/*     */     
/*     */ 
/*  88 */     if (StringUtils.isBlank(this.helperArgs)) {
/*  89 */       throw new ConfigurationException("null helperArgs");
/*     */     }
/*     */   }
/*     */   
/*     */ 
/*     */   public void run()
/*     */   {
/*     */     try
/*     */     {
/*  98 */       logger.info("Configuring...");
/*     */       
/* 100 */       this.velocityHelper.configure(this.dataSource, FilenameUtils.getFullPath(this.templatePath));
/*     */       
/*     */ 
/* 103 */       this.velocityHelper.setTemplateArgs(this.velocityHelper.splitTemplateArgs(this.helperArgs));
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
/* 125 */       logger.info("Template: " + FilenameUtils.getName(this.templatePath));
/* 126 */       logger.info("Output: " + this.outputFile);
/*     */       
/* 128 */       int recordCount = this.velocityHelper.merge(this.templatePath, this.outputFile);
/*     */       
/* 130 */       logger.info("Merged records: " + recordCount);
/*     */     }
/*     */     catch (Exception ex) {
/* 133 */       logger.error(ex.getMessage(), ex);
/*     */     }
/*     */   }
/*     */   
/*     */   public void setVelocityHelper(VelocityHelper velocityHelper)
/*     */   {
/* 139 */     this.velocityHelper = velocityHelper;
/*     */   }
/*     */   
/*     */   public void setDataSource(DataSource dataSource) {
/* 143 */     this.dataSource = dataSource;
/*     */   }
/*     */   
/*     */   public void setConsoleArgs(String consoleArgs) {
/* 147 */     this.helperArgs = consoleArgs;
/*     */   }
/*     */   
/*     */   public void setOutputFile(String outputFile) {
/* 151 */     this.outputFile = outputFile;
/*     */   }
/*     */   
/*     */   public void setTemplatePath(String templatePath) {
/* 155 */     this.templatePath = templatePath;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public static void main(String[] args)
/*     */   {
/*     */     try
/*     */     {
/* 168 */       logger.debug("Initializing application context...");
/* 169 */       ApplicationContext context = new ClassPathXmlApplicationContext(args);
/*     */       
/*     */ 
/* 172 */       if (!context.containsBean("console")) {
/* 173 */         throw new ConfigurationException("null console");
/*     */       }
/*     */       
/* 176 */       ConsoleVelocityHelper helper = (ConsoleVelocityHelper)context.getBean("console");
/*     */       
/* 178 */       helper.run();
/*     */     }
/*     */     catch (Exception ex) {
/* 181 */       logger.error(ex.getMessage(), ex);
/*     */     }
/*     */     finally {
/* 184 */       logger.debug("Done");
/*     */     }
/*     */   }
/*     */   
/*     */ 
/*     */   public void setHelperArgs(String helperArgs)
/*     */   {
/* 191 */     this.helperArgs = helperArgs;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\velocity\ConsoleVelocityHelper.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */