/*    */ package com.windsor.node.plugin.common;
/*    */ 
/*    */ import java.util.ArrayList;
/*    */ import java.util.Collection;
/*    */ import java.util.Iterator;
/*    */ import org.apache.commons.collections.IteratorUtils;
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
/*    */ public class IterableUtils
/*    */ {
/*    */   public static <IN, OUT> Iterable<OUT> transform(Iterable<IN> it, final ITransformer<IN, OUT> transformer)
/*    */   {
/* 28 */     return new Iterable()
/*    */     {
/*    */       public Iterator<OUT> iterator()
/*    */       {
/* 32 */         return IteratorUtils.transformedIterator(it.iterator(), transformer);
/*    */       }
/*    */     };
/*    */   }
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
/*    */   public static <T> Collection<T> toCollection(Iterable<T> it)
/*    */   {
/* 48 */     Collection<T> col = new ArrayList();
/* 49 */     for (T t : it) {
/* 50 */       col.add(t);
/*    */     }
/* 52 */     return col;
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   public static <T> Iterable<T> toIterable(T t)
/*    */   {
/* 63 */     Collection<T> col = new ArrayList();
/* 64 */     col.add(t);
/* 65 */     return col;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\IterableUtils.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */