/*    */ package com.windsor.node.plugin.common;
/*    */ 
/*    */ import com.windsor.node.common.domain.ActivityEntry;
/*    */ import com.windsor.node.common.domain.ProcessContentResult;
/*    */ import java.io.BufferedOutputStream;
/*    */ import java.io.FileNotFoundException;
/*    */ import java.io.FileOutputStream;
/*    */ import java.io.OutputStreamWriter;
/*    */ import java.io.UnsupportedEncodingException;
/*    */ import java.util.List;
/*    */ import javax.sql.DataSource;
/*    */ import org.apache.commons.lang3.time.StopWatch;
/*    */ import org.slf4j.Logger;
/*    */ import org.slf4j.LoggerFactory;
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ public abstract class BaseDocumentBuilder
/*    */   implements DocumentBuilder
/*    */ {
/*    */   protected StopWatch stopWatch;
/* 53 */   protected Logger logger = LoggerFactory.getLogger(getClass());
/*    */   
/*    */   protected BaseDocumentBuilder()
/*    */   {
/* 57 */     this.stopWatch = new StopWatch();
/*    */   }
/*    */   
/*    */ 
/*    */   public abstract void buildDocument(DataSource paramDataSource, String paramString, ProcessContentResult paramProcessContentResult);
/*    */   
/*    */   public abstract void buildDocument(DataSource paramDataSource, String paramString, ProcessContentResult paramProcessContentResult, int paramInt);
/*    */   
/*    */   protected void makeEntry(ProcessContentResult result, String message)
/*    */   {
/* 67 */     this.logger.debug(message);
/* 68 */     result.getAuditEntries().add(new ActivityEntry(message));
/*    */   }
/*    */   
/*    */   protected void makeErrorEntry(ProcessContentResult result, String message) {
/* 72 */     this.logger.error(message);
/* 73 */     result.getAuditEntries().add(new ActivityEntry(message));
/*    */   }
/*    */   
/*    */   protected OutputStreamWriter getWriter(String targetFilePath)
/*    */     throws UnsupportedEncodingException, FileNotFoundException
/*    */   {
/* 79 */     OutputStreamWriter out = new OutputStreamWriter(new BufferedOutputStream(new FileOutputStream(targetFilePath), 24576), "UTF-8");
/*    */     
/* 81 */     return out;
/*    */   }
/*    */   
/*    */   protected StopWatch getStopWatch() {
/* 85 */     return this.stopWatch;
/*    */   }
/*    */   
/*    */   protected void setStopWatch(StopWatch stopWatch) {
/* 89 */     this.stopWatch = stopWatch;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\BaseDocumentBuilder.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */