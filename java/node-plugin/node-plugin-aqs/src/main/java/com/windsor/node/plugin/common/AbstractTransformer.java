/*    */ package com.windsor.node.plugin.common;
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ public abstract class AbstractTransformer<IN, OUT>
/*    */   implements ITransformer<IN, OUT>
/*    */ {
            public abstract OUT typedTransform(IN input);

/*    */   public Object transform(Object input)
/*    */   {
/* 16 */     return (OUT) typedTransform((IN) input);
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */   static class UpperCaseTransformer
/*    */     extends AbstractTransformer<String, String>
/*    */   {
/*    */     public String typedTransform(String in)
/*    */     {
/* 27 */       return in == null ? null : in.toUpperCase();
/*    */     }
/*    */   }
/*    */   
/* 31 */   public static final UpperCaseTransformer UPPER_CASE_TRANSFORMER = new UpperCaseTransformer();
/*    */   
/*    */ 
/*    */   public static class LengthTransformer
/*    */     extends AbstractTransformer<String, String>
/*    */   {
/*    */     private final int maxLength;
/*    */     
/*    */ 
/*    */     public LengthTransformer(int maxLength)
/*    */     {
/* 42 */       this.maxLength = maxLength;
/*    */     }
/*    */     
/*    */     public String typedTransform(String in)
/*    */     {
/* 47 */       return in.length() > this.maxLength ? in.substring(0, this.maxLength) : in == null ? null : in;
/*    */     }
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */   public static class SuffixAppenderTransformer
/*    */     extends AbstractTransformer<String, String>
/*    */   {
/*    */     private final String suffix;
/*    */     
/*    */ 
/*    */ 
/*    */     public SuffixAppenderTransformer(String suffix)
/*    */     {
/* 63 */       this.suffix = suffix;
/*    */     }
/*    */     
/*    */     public String typedTransform(String in)
/*    */     {
/* 68 */       return in + this.suffix;
/*    */     }
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\AbstractTransformer.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */