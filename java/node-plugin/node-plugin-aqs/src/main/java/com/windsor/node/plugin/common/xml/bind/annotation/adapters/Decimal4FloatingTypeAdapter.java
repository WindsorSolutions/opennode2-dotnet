/*    */ package com.windsor.node.plugin.common.xml.bind.annotation.adapters;
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ public class Decimal4FloatingTypeAdapter
/*    */   extends AbstractBigDecimalLengthAdapter
/*    */ {
/*    */   protected int totalNumberOfCharacters()
/*    */   {
/* 11 */     return 4;
/*    */   }
/*    */   
/*    */   protected int maxPrecision()
/*    */   {
/* 16 */     return 2;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\bind\annotation\adapters\Decimal4FloatingTypeAdapter.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */