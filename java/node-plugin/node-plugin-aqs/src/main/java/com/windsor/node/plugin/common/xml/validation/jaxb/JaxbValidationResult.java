/*    */ package com.windsor.node.plugin.common.xml.validation.jaxb;
/*    */ 
/*    */ import com.windsor.node.plugin.common.xml.validation.ValidationResult;
/*    */ import java.util.ArrayList;
/*    */ import java.util.Collection;
/*    */ import java.util.List;
/*    */ import org.apache.commons.collections.CollectionUtils;
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
/*    */ public class JaxbValidationResult
/*    */   implements ValidationResult
/*    */ {
/*    */   private final List<String> errors;
/*    */   
/*    */   public JaxbValidationResult()
/*    */   {
/* 30 */     this.errors = new ArrayList();
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   public void error(String message)
/*    */   {
/* 40 */     this.errors.add(message);
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   public Collection<String> errors()
/*    */   {
/* 49 */     return CollectionUtils.unmodifiableCollection(this.errors);
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */   public boolean hasErrors()
/*    */   {
/* 57 */     return this.errors.size() > 0;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\validation\jaxb\JaxbValidationResult.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */