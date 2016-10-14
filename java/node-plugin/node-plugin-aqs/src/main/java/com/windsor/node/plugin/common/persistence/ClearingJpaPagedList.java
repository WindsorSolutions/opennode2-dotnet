/*    */ package com.windsor.node.plugin.common.persistence;
/*    */ 
/*    */ import java.io.Serializable;
/*    */ import javax.persistence.EntityManager;
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
/*    */ public class ClearingJpaPagedList<T extends Serializable>
/*    */   extends JpaPagedList<T>
/*    */ {
/*    */   public ClearingJpaPagedList(Class<T> entityClass, EntityManager em, String dataQuery, String countQuery, int cacheSize)
/*    */   {
/* 34 */     super(entityClass, em, dataQuery, countQuery, cacheSize);
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   protected void beforePageLoaded()
/*    */   {
/* 46 */     getEm().clear();
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\persistence\ClearingJpaPagedList.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */