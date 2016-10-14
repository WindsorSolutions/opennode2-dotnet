/*     */ package com.windsor.node.plugin.common.staging;
/*     */ 
/*     */ import com.windsor.node.plugin.common.dao.TextLoader;
/*     */ import java.util.List;
/*     */ import java.util.Map;
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
/*     */ public abstract class BaseXmlStaging
/*     */   implements XmlStaging
/*     */ {
/*  44 */   protected Logger logger = LoggerFactory.getLogger(getClass());
/*     */   
/*     */   protected TextLoader loader;
/*     */   
/*  48 */   protected StringBuffer xmlBuffer = null;
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void execute(StringBuffer xml, boolean isFinal)
/*     */   {
/*  58 */     this.logger.trace("execute xml: " + xml);
/*     */     
/*  60 */     if (null == this.loader)
/*     */     {
/*  62 */       throw new RuntimeException("TextLoader not set");
/*     */     }
/*     */     
/*  65 */     if (this.xmlBuffer == null)
/*     */     {
/*  67 */       this.logger.debug("Starting new document buffer");
/*     */       
/*  69 */       this.xmlBuffer = new StringBuffer();
/*     */       
/*  71 */       this.logger.debug("Buffering " + getDocumentOpen());
/*     */       
/*  73 */       this.xmlBuffer.append(getDocumentOpen());
/*     */     }
/*     */     
/*  76 */     if (null != xml)
/*     */     {
/*  78 */       this.logger.debug("Appending to document buffer");
/*     */       
/*  80 */       this.xmlBuffer.append(xml);
/*     */     }
/*     */     
/*  83 */     if (isFinal)
/*     */     {
/*  85 */       this.logger.debug("Buffering " + getDocumentClose());
/*     */       
/*  87 */       this.xmlBuffer.append(getDocumentClose());
/*     */       
/*  89 */       this.logger.debug("Closing document buffer");
/*     */       
/*     */       try
/*     */       {
/*  93 */         this.loader.loadText(this.xmlBuffer.toString());
/*     */       }
/*     */       catch (Exception e)
/*     */       {
/*  97 */         throw new RuntimeException(e.getMessage(), e);
/*     */       }
/*     */       finally
/*     */       {
/* 101 */         this.xmlBuffer = null;
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
/*     */   public String getStartTag(String tagname)
/*     */   {
/* 115 */     return "<" + tagname + ">";
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String getEndTag(String tagname)
/*     */   {
/* 126 */     return "</" + tagname + ">";
/*     */   }
/*     */   
/*     */   public TextLoader getTextLoader() {
/* 130 */     return this.loader;
/*     */   }
/*     */   
/*     */   public void setTextLoader(TextLoader loader) {
/* 134 */     this.loader = loader;
/*     */   }
/*     */   
/*     */   public abstract String getDocumentClose();
/*     */   
/*     */   public abstract String getDocumentOpen();
/*     */   
/*     */   public abstract Map getListElementMap();
/*     */   
/*     */   public abstract List getListNames();
/*     */   
/*     */   public abstract void setBatchSize(int paramInt);
/*     */   
/*     */   public abstract int getBatchSize();
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\staging\BaseXmlStaging.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */