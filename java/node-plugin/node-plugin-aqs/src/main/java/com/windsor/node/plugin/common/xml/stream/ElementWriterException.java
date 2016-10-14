/*    */ package com.windsor.node.plugin.common.xml.stream;
/*    */ 
/*    */ public class ElementWriterException extends RuntimeException
/*    */ {
/*    */   private static final long serialVersionUID = 1L;
/*    */   
/*    */   public ElementWriterException(Throwable t) {
/*  8 */     super(t.getLocalizedMessage(), t);
/*    */   }
/*    */   
/*    */   public ElementWriterException(String message, Throwable t) {
/* 12 */     super(message, t);
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\stream\ElementWriterException.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */