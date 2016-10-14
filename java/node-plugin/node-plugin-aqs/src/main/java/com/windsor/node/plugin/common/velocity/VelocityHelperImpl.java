/*     */ package com.windsor.node.plugin.common.velocity;
/*     */ 
/*     */ import java.io.BufferedOutputStream;
/*     */ import java.io.FileNotFoundException;
/*     */ import java.io.FileOutputStream;
/*     */ import java.io.IOException;
/*     */ import java.io.OutputStreamWriter;
/*     */ import java.io.UnsupportedEncodingException;
/*     */ import java.io.Writer;
/*     */ import java.util.HashMap;
/*     */ import java.util.Iterator;
/*     */ import java.util.Map;
/*     */ import java.util.Map.Entry;
/*     */ import java.util.Properties;
/*     */ import java.util.Set;
/*     */ import javax.sql.DataSource;
/*     */ import org.apache.commons.io.FilenameUtils;
/*     */ import org.apache.commons.lang3.StringUtils;
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
/*     */ 
/*     */ 
/*     */ public class VelocityHelperImpl
/*     */   implements VelocityHelper
/*     */ {
/*     */   public static final String TEXT_ENCODING = "UTF-8";
/*     */   public static final int BUFFER_SIZE = 24576;
/*  74 */   protected Logger logger = LoggerFactory.getLogger(getClass());
/*     */   
/*     */ 
/*     */   protected VelocityContext context;
/*     */   
/*     */ 
/*     */   protected VelocityEngine velocityEngine;
/*     */   
/*     */ 
/*     */   protected TemplateHelper templateHelper;
/*     */   
/*     */ 
/*     */   private int resultingRecordCount;
/*     */   
/*     */ 
/*     */   public void configure(DataSource dataSource, String templateDirectory)
/*     */   {
/*  91 */     configure(templateDirectory);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void configure(String templateDirectory)
/*     */   {
/* 101 */     this.logger.info("Template directory: " + templateDirectory);
/*     */     
/*     */ 
/* 104 */     Properties props = new Properties();
/* 105 */     props.setProperty("resource.loader", "file");
/* 106 */     props.setProperty("file.resource.loader.description", "Velocity File Resource Loader");
/*     */     
/* 108 */     props.setProperty("file.resource.loader.class", "org.apache.velocity.runtime.resource.loader.FileResourceLoader");
/*     */     
/*     */ 
/* 111 */     props.setProperty("file.resource.loader.path", templateDirectory);
/* 112 */     props.setProperty("file.resource.loader.cache", "false");
/* 113 */     props.setProperty("file.resource.loader.modificationCheckInterval", "0");
/*     */     
/*     */ 
/* 116 */     props.setProperty("input.encoding", "UTF-8");
/* 117 */     props.setProperty("output.encoding", "UTF-8");
/*     */     
/* 119 */     props.setProperty("runtime.log.logsystem.class", "org.apache.velocity.runtime.log.Log4JLogChute");
/*     */     
/* 121 */     props.setProperty("runtime.log.logsystem.log4j.logger", "org.apache.velocity");
/*     */     
/*     */ 
/* 124 */     props.setProperty("eventhandler.referenceinsertion.class", "org.apache.velocity.app.event.implement.EscapeXmlReference");
/*     */     
/* 126 */     props.setProperty("eventhandler.escape.html.match", "/.*/");
/* 127 */     props.setProperty("directive.foreach.counter.name", "velocityCount");
/* 128 */     props.setProperty("directive.foreach.counter.initial.value", "1");
/*     */     try
/*     */     {
/* 131 */       this.velocityEngine = new VelocityEngine(props);
/*     */     } catch (Exception e) {
/* 133 */       throw new RuntimeException("Error while creating VelocityEngine:" + e.getMessage(), e);
/*     */     }
/*     */     
/*     */ 
/* 137 */     this.templateHelper = new TemplateHelper();
/* 138 */     this.context = new VelocityContext();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setTemplateArg(String key, Object arg)
/*     */   {
/* 148 */     this.context.put(key, arg);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setTemplateArgs(Map<String, Object> args)
/*     */   {
/* 157 */     Iterator<Map.Entry<String, Object>> it = args.entrySet().iterator();
/* 158 */     while (it.hasNext()) {
/* 159 */       Map.Entry<String, Object> pairs = (Map.Entry)it.next();
/*     */       
/* 161 */       this.context.put(((String)pairs.getKey()).toString(), pairs.getValue());
/*     */     }
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public Map<String, Object> splitTemplateArgs(String helperArgs)
/*     */   {
/* 173 */     Map<String, Object> map = new HashMap();
/*     */     
/* 175 */     String[] argPairs = StringUtils.split(helperArgs, "|");
/*     */     
/*     */ 
/* 178 */     for (int i = 0; i < argPairs.length; i++)
/*     */     {
/* 180 */       this.logger.info(argPairs[i]);
/*     */       
/* 182 */       String[] argPair = StringUtils.split(argPairs[i], "^");
/*     */       
/*     */ 
/* 185 */       if (argPair.length != 2) {
/* 186 */         throw new IllegalArgumentException("Invalid argument, expected key value pair delimited by '^' char");
/*     */       }
/*     */       
/*     */ 
/* 190 */       map.put(argPair[0].trim(), argPair[1].trim());
/*     */     }
/*     */     
/* 193 */     return map;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public int merge(String template, String targetFilePath)
/*     */   {
/* 203 */     return merge(template, targetFilePath, false);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public int merge(String template, String targetFilePath, boolean append)
/*     */   {
/* 213 */     OutputStreamWriter out = null;
/*     */     try
/*     */     {
/* 216 */       out = new OutputStreamWriter(new BufferedOutputStream(new FileOutputStream(targetFilePath, append), 24576), "UTF-8");
/*     */       
/*     */ 
/*     */ 
/* 220 */       return merge(template, out);
/*     */     }
/*     */     catch (FileNotFoundException ex) {
/* 223 */       throw new RuntimeException("Error while merging: file not found." + ex.getMessage(), ex);
/*     */     }
/*     */     catch (UnsupportedEncodingException e) {
/* 226 */       throw new RuntimeException("Error while merging: unsupported encoding" + e.getMessage(), e);
/*     */     }
/*     */     finally
/*     */     {
/* 230 */       if (out != null) {
/*     */         try {
/* 232 */           out.flush();
/* 233 */           out.close();
/*     */         } catch (IOException e) {
/* 235 */           this.logger.error(e.getMessage(), e);
/*     */         }
/*     */       }
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
/*     */   public int merge(String template, Writer writer)
/*     */   {
/* 250 */     if ((this.velocityEngine == null) || (this.templateHelper == null)) {
/* 251 */       throw new RuntimeException("Engine not configured. Call configure(String templateDirectory) first!");
/*     */     }
/*     */     
/*     */ 
/*     */     try
/*     */     {
/* 257 */       Template tmpl = this.velocityEngine.getTemplate(FilenameUtils.getName(template));
/*     */       
/* 259 */       this.logger.info("Template: " + tmpl.getName());
/*     */       
/* 261 */       this.logger.debug("Merging template...");
/* 262 */       tmpl.merge(this.context, writer);
/*     */     }
/*     */     catch (Exception e) {
/* 265 */       this.logger.error("Exception: " + e.getMessage(), e);
/* 266 */       throw new RuntimeException("Template error: " + e.getMessage(), e);
/*     */     }
/*     */     
/* 269 */     return getResultingRecordCount();
/*     */   }
/*     */   
/*     */   public int getResultingRecordCount() {
/* 273 */     return this.resultingRecordCount;
/*     */   }
/*     */   
/*     */   public void setResultingRecordCount(int resultingRecordCount) {
/* 277 */     this.resultingRecordCount = resultingRecordCount;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\velocity\VelocityHelperImpl.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */