/*     */ package com.windsor.node.plugin.common.velocity.jdbc;
/*     */ 
/*     */ import com.windsor.node.plugin.common.velocity.VelocityHelperImpl;
/*     */ import java.io.Writer;
/*     */ import javax.sql.DataSource;
/*     */ import org.apache.commons.io.FilenameUtils;
/*     */ import org.apache.velocity.Template;
/*     */ import org.apache.velocity.VelocityContext;
/*     */ import org.apache.velocity.app.VelocityEngine;
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
/*     */ public class JdbcVelocityHelper
/*     */   extends VelocityHelperImpl
/*     */ {
/*     */   public void configure(DataSource dataSource, String templateDirectory)
/*     */   {
/*  63 */     configure(templateDirectory);
/*     */     
/*  65 */     if (dataSource == null) {
/*  66 */       throw new NullPointerException("Null dataSource");
/*     */     }
/*     */     
/*  69 */     this.templateHelper = new JdbcTemplateHelper(dataSource);
/*  70 */     this.context.put("helper", this.templateHelper);
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
/*     */   public int merge(String template, String targetFilePath)
/*     */   {
/*  89 */     return super.merge(template, targetFilePath);
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
/*     */   public int merge(String template, Writer writer)
/*     */   {
/* 107 */     if ((this.velocityEngine == null) || (this.templateHelper == null)) {
/* 108 */       throw new RuntimeException("Helper not configured. configure(DataSource dataSource, String templateDirectory) first!");
/*     */     }
/*     */     
/*     */ 
/*     */     try
/*     */     {
/* 114 */       Template tmpl = this.velocityEngine.getTemplate(FilenameUtils.getName(template));
/*     */       
/* 116 */       this.logger.info("Template: " + tmpl.getName());
/*     */       
/* 118 */       this.logger.debug("Merging template...");
/* 119 */       tmpl.merge(this.context, writer);
/*     */       
/* 121 */       return ((JdbcTemplateHelper)this.templateHelper).getResultingRecordCount();
/*     */     }
/*     */     catch (Exception e)
/*     */     {
/* 125 */       this.logger.error("Exception: " + e.getMessage(), e);
/* 126 */       throw new RuntimeException("Template error: " + e.getMessage(), e);
/*     */     }
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\velocity\jdbc\JdbcVelocityHelper.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */