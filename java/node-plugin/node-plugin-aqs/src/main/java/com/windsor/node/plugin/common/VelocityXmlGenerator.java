/*     */ package com.windsor.node.plugin.common;
/*     */ 
/*     */ import java.io.StringWriter;
/*     */ import java.util.List;
/*     */ import java.util.Properties;
/*     */ import org.apache.velocity.Template;
/*     */ import org.apache.velocity.VelocityContext;
/*     */ import org.apache.velocity.app.VelocityEngine;
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
/*     */ public abstract class VelocityXmlGenerator
/*     */ {
/*     */   public static final String XML_DECLARATION = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
/*  57 */   public static final String LINE_SEP = System.getProperty("line.separator");
/*  58 */   public static final String FILE_SEP = System.getProperty("line.separator");
/*     */   
/*     */   public static final String TAB = "    ";
/*  61 */   protected Logger logger = LoggerFactory.getLogger(getClass());
/*     */   protected VelocityEngine ve;
/*     */   
/*     */   public VelocityXmlGenerator(String templatePath)
/*     */   {
/*  66 */     this.logger.debug("creating VelocityXmlGenerator, loading templates from the filesystem location: " + templatePath);
/*     */     
/*     */ 
/*     */ 
/*     */ 
/*  71 */     Properties props = new Properties();
/*  72 */     props.setProperty("resource.loader", "file");
/*  73 */     props.setProperty("file.resource.loader.path", templatePath);
/*  74 */     props.setProperty("file.resource.loader.cache", "true");
/*  75 */     props.setProperty("file.resource.loader.class", "org.apache.velocity.runtime.resource.loader.FileResourceLoader");
/*     */     
/*     */ 
/*  78 */     props.setProperty("runtime.log.logsystem.class", "org.apache.velocity.runtime.log.Log4JLogChute");
/*     */     
/*  80 */     props.setProperty("runtime.log.logsystem.log4j.logger", "org.apache.velocity");
/*     */     
/*     */     try
/*     */     {
/*  84 */       this.ve = new VelocityEngine(props);
/*     */     } catch (Exception e) {
/*  86 */       throw new RuntimeException("Problem initializing VelocityEngine", e);
/*     */     }
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */   protected StringWriter genList(String contextKey, String templateName, List templateData)
/*     */   {
/*  94 */     VelocityContext context = new VelocityContext();
/*  95 */     context.put(contextKey, templateData.toArray());
/*  96 */     return merge(templateName, context);
/*     */   }
/*     */   
/*     */ 
/*     */   protected StringWriter genItem(String contextKey, String templateName, Object templateData)
/*     */   {
/* 102 */     VelocityContext context = new VelocityContext();
/* 103 */     context.put(contextKey, templateData);
/* 104 */     return merge(templateName, context);
/*     */   }
/*     */   
/*     */   private StringWriter merge(String templateName, VelocityContext context)
/*     */   {
/* 109 */     Template t = getTemplate(templateName);
/* 110 */     StringWriter sw = new StringWriter();
/*     */     try
/*     */     {
/* 113 */       t.merge(context, sw);
/*     */     } catch (Exception e) {
/* 115 */       this.logger.error("Problem merging template " + templateName + ": " + e.getMessage());
/*     */       
/* 117 */       throw new RuntimeException("Problem merging template " + templateName, e);
/*     */     }
/*     */     
/*     */ 
/* 121 */     this.logger.trace("Output from merging " + templateName + ":\n" + sw.toString());
/*     */     
/* 123 */     return sw;
/*     */   }
/*     */   
/*     */   protected Template getTemplate(String templateName)
/*     */   {
/* 128 */     Template t = null;
/*     */     try
/*     */     {
/* 131 */       t = this.ve.getTemplate(templateName);
/*     */     } catch (Exception e) {
/* 133 */       String msg = "Problem getting Template named " + templateName + ": " + e.getMessage();
/*     */       
/* 135 */       this.logger.error(msg);
/* 136 */       throw new RuntimeException(msg, e);
/*     */     }
/*     */     
/* 139 */     return t;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\VelocityXmlGenerator.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */