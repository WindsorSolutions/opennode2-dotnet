/*    */ package com.windsor.node.plugin.common.persistence;
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ public abstract class AbstractCriteriaFactory<DATA, ROOT>
/*    */   implements CriteriaFactory<DATA, ROOT>
/*    */ {
/*    */   private DATA data;
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */   public void setUntypedData(Object data)
/*    */   {
/* 17 */     this.data = (DATA) data;
/*    */   }
/*    */   
/*    */   public void setData(DATA data)
/*    */   {
/* 22 */     this.data = data;
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   protected DATA getData()
/*    */   {
/* 31 */     return (DATA)this.data;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\persistence\AbstractCriteriaFactory.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */