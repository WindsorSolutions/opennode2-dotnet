/*    */ package com.windsor.node.plugin.common.xml.bind.annotation.adapters;
/*    */ 
/*    */ import java.math.BigDecimal;
/*    */ import java.math.BigInteger;
/*    */ import java.math.MathContext;
/*    */ import javax.xml.bind.annotation.adapters.XmlAdapter;
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
/*    */ public abstract class AbstractBigDecimalLengthAdapter
/*    */   extends XmlAdapter<String, BigDecimal>
/*    */ {
/*    */   protected abstract int totalNumberOfCharacters();
/*    */   
/*    */   protected int maxPrecision()
/*    */   {
/* 31 */     return totalNumberOfCharacters() - 1;
/*    */   }
/*    */   
/*    */   public BigDecimal unmarshal(String s) throws Exception
/*    */   {
/* 36 */     return new BigDecimal(s);
/*    */   }
/*    */   
/*    */   public String marshal(BigDecimal value) throws Exception
/*    */   {
/* 41 */     return value == null ? null : toString(value);
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   protected String toString(BigDecimal value)
/*    */   {
/* 53 */     int amtOfPrecision = totalNumberOfCharacters() - value.toBigInteger().toString().length();
/*    */     
/* 55 */     BigDecimal bd = new BigDecimal(value.toString(), new MathContext(amtOfPrecision > maxPrecision() ? maxPrecision() : amtOfPrecision)).stripTrailingZeros();
/*    */     
/*    */ 
/* 58 */     return bd.toPlainString();
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\bind\annotation\adapters\AbstractBigDecimalLengthAdapter.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */