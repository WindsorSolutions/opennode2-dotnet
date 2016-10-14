/*    */ package com.windsor.node.plugin.common.file;
/*    */ 
/*    */ public class XmlFileCreator
/*    */   extends AbstractFileCreator
/*    */ {
/*    */   private static final String EXT_XML = "xml";
/*    */   private final String directoryAbsolutePath;
/*    */   private final String fileName;
/*    */   
/*    */   public XmlFileCreator(String directoryAbsolutePath, String filename)
/*    */   {
/* 12 */     this.directoryAbsolutePath = directoryAbsolutePath;
/* 13 */     this.fileName = filename;
/*    */   }
/*    */   
/*    */   protected final String getExtension()
/*    */   {
/* 18 */     return "xml";
/*    */   }
/*    */   
/*    */   protected String getDirectoryAbsolutePath()
/*    */   {
/* 23 */     return this.directoryAbsolutePath;
/*    */   }
/*    */   
/*    */   protected String getFileName()
/*    */   {
/* 28 */     return this.fileName;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\file\XmlFileCreator.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */