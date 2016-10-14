/*     */ package com.windsor.node.plugin.common;
/*     */ 
/*     */ import com.windsor.node.plugin.common.staging.XmlStaging;
/*     */ import java.io.BufferedReader;
/*     */ import java.io.FileNotFoundException;
/*     */ import java.io.FileReader;
/*     */ import java.io.IOException;
/*     */ import java.util.Iterator;
/*     */ import java.util.List;
/*     */ import java.util.Map;
/*     */ import org.apache.commons.lang3.StringUtils;
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
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ public class XmlFileToClobProcessor
/*     */ {
/*  68 */   protected Logger logger = LoggerFactory.getLogger(getClass());
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   private XmlStaging xmlStaging;
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   private static final String XML_PREAMBLE = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public XmlFileToClobProcessor(XmlStaging xmlStaging)
/*     */   {
/*  88 */     this.xmlStaging = xmlStaging;
/*     */   }
/*     */   
/*     */ 
/*     */   public void processXmlFile(String filename)
/*     */   {
/*  94 */     String listName = null;
/*     */     
/*     */     try
/*     */     {
/*  98 */       FileReader fr = new FileReader(filename);
/*  99 */       BufferedReader br = new BufferedReader(fr);
/*     */       
/* 101 */       StringBuffer xmlBuf = null;
/*     */       
/* 103 */       Iterator listNameIter = this.xmlStaging.getListNames().iterator();
/*     */       
/* 105 */       while (listNameIter.hasNext())
/*     */       {
/* 107 */         xmlBuf = newBufferIfNull(xmlBuf);
/*     */         
/* 109 */         listName = (String)listNameIter.next();
/*     */         
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 116 */         if (this.xmlStaging.getListElementMap().get(listName) == null)
/*     */         {
/* 118 */           copyList(br, listName);
/*     */ 
/*     */ 
/*     */         }
/*     */         else
/*     */         {
/*     */ 
/*     */ 
/* 126 */           copyListWithSizeLimit(br, listName);
/*     */         }
/*     */       }
/*     */     }
/*     */     catch (FileNotFoundException fnfe)
/*     */     {
/* 132 */       String msg = "File " + filename + " not found";
/* 133 */       this.logger.error(msg);
/* 134 */       throw new RuntimeException(msg, fnfe);
/*     */     }
/*     */     catch (IOException ioe)
/*     */     {
/* 138 */       String msg = "Problem reading file " + filename;
/* 139 */       this.logger.error(msg);
/* 140 */       throw new RuntimeException(msg, ioe);
/*     */     }
/*     */   }
/*     */   
/*     */ 
/*     */   private StringBuffer newBufferIfNull(StringBuffer xmlBuf)
/*     */   {
/* 147 */     if (xmlBuf == null)
/*     */     {
/* 149 */       xmlBuf = new StringBuffer();
/*     */       
/* 151 */       this.logger.debug("initialized xmlBuf");
/*     */     }
/*     */     
/* 154 */     return xmlBuf;
/*     */   }
/*     */   
/*     */   private void bufferLine(StringBuffer xmlBuf, String line)
/*     */   {
/* 159 */     this.logger.trace("buffering line: " + line);
/* 160 */     xmlBuf.append(line.trim());
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   private void copyList(BufferedReader br, String listName)
/*     */     throws IOException
/*     */   {
/* 173 */     String line = null;
/* 174 */     String listStart = this.xmlStaging.getStartTag(listName);
/* 175 */     String listEnd = this.xmlStaging.getEndTag(listName);
/*     */     
/* 177 */     this.logger.debug("Copying list " + listName + " verbatim");
/*     */     
/* 179 */     StringBuffer xmlBuf = null;
/*     */     
/* 181 */     boolean continueList = false;
/*     */     
/*     */ 
/* 184 */     while ((line = br.readLine()) != null)
/*     */     {
/* 186 */       xmlBuf = newBufferIfNull(xmlBuf);
/*     */       
/* 188 */       if (StringUtils.contains(line, listStart))
/*     */       {
/* 190 */         this.logger.debug("found list starting tag " + listStart + " in file");
/*     */         
/* 192 */         continueList = true;
/*     */       }
/*     */       
/* 195 */       if (continueList)
/*     */       {
/* 197 */         bufferLine(xmlBuf, line);
/*     */       }
/*     */       
/* 200 */       if (StringUtils.contains(line, listEnd))
/*     */       {
/* 202 */         this.logger.debug("found list ending tag " + listEnd + " in file");
/*     */         
/* 204 */         continueList = false;
/* 205 */         this.xmlStaging.execute(xmlBuf, false);
/* 206 */         xmlBuf = null;
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
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   private void copyListWithSizeLimit(BufferedReader br, String listName)
/*     */     throws IOException
/*     */   {
/* 229 */     String line = null;
/* 230 */     String listStart = this.xmlStaging.getStartTag(listName);
/* 231 */     String listEnd = this.xmlStaging.getEndTag(listName);
/*     */     
/* 233 */     this.logger.debug("Copying list " + listName + " with batchSize = " + this.xmlStaging.getBatchSize());
/*     */     
/*     */ 
/* 236 */     StringBuffer xmlBuf = null;
/*     */     
/* 238 */     List elementsToCount = (List)this.xmlStaging.getListElementMap().get(listName);
/*     */     
/*     */ 
/* 241 */     Iterator elementIter = elementsToCount.iterator();
/*     */     
/* 243 */     while (elementIter.hasNext())
/*     */     {
/* 245 */       String elementName = (String)elementIter.next();
/*     */       
/* 247 */       String elementEnd = this.xmlStaging.getEndTag(elementName);
/*     */       
/* 249 */       int listItemCount = 0;
/*     */       
/* 251 */       boolean continueList = false;
/*     */       
/*     */ 
/* 254 */       while ((line = br.readLine()) != null)
/*     */       {
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 261 */         if ((StringUtils.contains(line, "<?xml version=\"1.0\" encoding=\"UTF-8\"?>")) || (StringUtils.contains(line, this.xmlStaging.getDocumentOpen())))
/*     */         {
/*     */ 
/* 264 */           line = br.readLine();
/*     */         }
/*     */         
/* 267 */         if (xmlBuf == null)
/*     */         {
/* 269 */           xmlBuf = newBufferIfNull(xmlBuf);
/*     */           
/* 271 */           if (!continueList)
/*     */           {
/* 273 */             this.logger.debug("(re)starting list " + listName);
/* 274 */             bufferLine(xmlBuf, listStart);
/* 275 */             continueList = true;
/*     */           }
/*     */         }
/*     */         
/* 279 */         if (StringUtils.contains(line, listStart))
/*     */         {
/* 281 */           this.logger.debug("found list starting tag " + listStart + " in file");
/*     */           
/*     */ 
/* 284 */           continueList = true;
/*     */         } else {
/* 286 */           if (StringUtils.contains(line, listEnd))
/*     */           {
/* 288 */             this.logger.debug("found list ending tag " + listEnd + " in file");
/*     */             
/*     */ 
/*     */ 
/* 292 */             continueList = false;
/* 293 */             listItemCount = 0;
/* 294 */             bufferLine(xmlBuf, line);
/* 295 */             this.xmlStaging.execute(xmlBuf, true);
/* 296 */             xmlBuf = null;
/*     */             
/*     */ 
/* 299 */             break;
/*     */           }
/* 301 */           if (StringUtils.contains(line, elementEnd))
/*     */           {
/* 303 */             listItemCount++;
/* 304 */             boolean isFinal = false;
/*     */             
/*     */ 
/* 307 */             if ((this.xmlStaging.getBatchSize() > 0) && (listItemCount == this.xmlStaging.getBatchSize()))
/*     */             {
/*     */ 
/* 310 */               this.logger.debug("reached batchSize of " + this.xmlStaging.getBatchSize());
/*     */               
/*     */ 
/*     */ 
/* 314 */               continueList = false;
/* 315 */               listItemCount = 0;
/* 316 */               bufferLine(xmlBuf, line);
/* 317 */               bufferLine(xmlBuf, listEnd);
/* 318 */               isFinal = true;
/*     */             }
/*     */             else
/*     */             {
/* 322 */               bufferLine(xmlBuf, line);
/* 323 */               continueList = true;
/*     */             }
/*     */             
/* 326 */             this.xmlStaging.execute(xmlBuf, isFinal);
/*     */             
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/* 332 */             xmlBuf = null;
/*     */           }
/*     */           else
/*     */           {
/* 336 */             bufferLine(xmlBuf, line);
/*     */           }
/*     */         }
/*     */       }
/*     */     }
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\XmlFileToClobProcessor.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */