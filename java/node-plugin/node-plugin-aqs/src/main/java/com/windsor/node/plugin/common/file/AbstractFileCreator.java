/*    */ package com.windsor.node.plugin.common.file;
/*    */ 
/*    */ import java.io.File;
/*    */ import java.io.IOException;
/*    */ import org.apache.commons.io.FileUtils;
/*    */ import org.apache.commons.lang3.StringUtils;
/*    */ import org.slf4j.Logger;
/*    */ import org.slf4j.LoggerFactory;
/*    */ 
/*    */ 
/*    */ abstract class AbstractFileCreator
/*    */   implements FileCreator
/*    */ {
/*    */   private static final String DEFAULT_EXTENSION = "";
/* 15 */   private static final Logger LOG = LoggerFactory.getLogger(AbstractFileCreator.class);
/*    */   
/*    */   protected abstract String getFileName();
/*    */   
/*    */   protected abstract String getDirectoryAbsolutePath();
/*    */   
/*    */   protected abstract String getExtension();
/*    */   
/*    */   public File createFile() throws IOException
/*    */   {
/* 25 */     return getFile();
/*    */   }
/*    */   
/*    */   private File getFile() throws IOException {
/* 29 */     FileUtils.forceMkdir(new File(directoryAbsolutePath()));
/* 30 */     return new File(documentAbsolutePath());
/*    */   }
/*    */   
/*    */   private String documentAbsolutePath() {
/* 34 */     return directoryAbsolutePath() + File.separator + fileName() + extension();
/*    */   }
/*    */   
/*    */   private String fileName() {
/* 38 */     String f = getFileName();
/* 39 */     return StringUtils.isNotEmpty(f) ? f : "";
/*    */   }
/*    */   
/*    */   private String directoryAbsolutePath() {
/* 43 */     String d = getDirectoryAbsolutePath();
/* 44 */     return StringUtils.isNotEmpty(d) ? d : "";
/*    */   }
/*    */   
/*    */   private String extension() {
/* 48 */     String ext = getExtension();
/* 49 */     return StringUtils.isNotEmpty(ext) ? "." + ext : "";
/*    */   }
/*    */   
/*    */   private void error(Throwable t) {
/* 53 */     LOG.error("", t);
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\file\AbstractFileCreator.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */