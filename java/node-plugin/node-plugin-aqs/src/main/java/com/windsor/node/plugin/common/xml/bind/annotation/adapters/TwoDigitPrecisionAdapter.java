/*    */ package com.windsor.node.plugin.common.xml.bind.annotation.adapters;
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ public class TwoDigitPrecisionAdapter
/*    */   extends AbstractBigDecimalFormatAdapter
/*    */ {
/*    */   private static final String NUMBER_FORMAT = "0.00";
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   protected String getNumberFormatString()
/*    */   {
/* 20 */     return "0.00";
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\bind\annotation\adapters\TwoDigitPrecisionAdapter.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */