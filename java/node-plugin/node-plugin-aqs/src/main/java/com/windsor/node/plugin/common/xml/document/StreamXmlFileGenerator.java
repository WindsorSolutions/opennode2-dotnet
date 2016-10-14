/*    */ package com.windsor.node.plugin.common.xml.document;
/*    */ 
/*    */ import com.windsor.node.plugin.common.file.FileCreator;
/*    */ import com.windsor.node.plugin.common.xml.stream.ElementWriter;
/*    */ import java.io.File;
/*    */ import java.io.FileOutputStream;
/*    */ import java.io.IOException;
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ public class StreamXmlFileGenerator<T>
/*    */   implements DocumentGenerator
/*    */ {
/*    */   private final FileCreator fileCreator;
/*    */   private final ElementsDataProvider<T> dataProvider;
/*    */   private final ElementWriter writer;
/*    */   private final ElementWriteHandler<T> writeHandler;
/*    */   
/*    */   public StreamXmlFileGenerator(FileCreator fileCreator, ElementsDataProvider<T> dataProvider, ElementWriteHandler<T> writeHandler, ElementWriter writer)
/*    */   {
/* 25 */     this.fileCreator = fileCreator;
/* 26 */     this.dataProvider = dataProvider;
/* 27 */     this.writeHandler = writeHandler;
/* 28 */     this.writer = writer;
/*    */   }
/*    */   
/*    */   public File generate()
/*    */     throws IOException
/*    */   {
/* 34 */     File file = this.fileCreator.createFile();
/*    */     
/* 36 */     FileOutputStream fos = null;
/*    */     
/*    */     try
/*    */     {
/* 40 */       fos = new FileOutputStream(file);
/*    */       
/* 42 */       this.writer.open(fos);
/*    */       
/* 44 */       Iterable<T> it = this.dataProvider.elements();
/*    */       
/* 46 */       for (T t : it) {
/* 47 */         this.writeHandler.handle(this.writer, t);
/*    */       }
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
/* 64 */       return file;
/*    */     }
/*    */     catch (Exception e)
/*    */     {
/* 51 */       throw new IOException(e.getLocalizedMessage(), e);
/*    */     } finally {
/* 53 */       if (this.writer != null) {
/* 54 */         this.writer.close();
/*    */       }
/* 56 */       if (fos != null) {
/*    */         try {
/* 58 */           fos.close();
/*    */         } catch (IOException e) {
/* 60 */           throw e;
/*    */         }
/*    */       }
/*    */     }
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\document\StreamXmlFileGenerator.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */