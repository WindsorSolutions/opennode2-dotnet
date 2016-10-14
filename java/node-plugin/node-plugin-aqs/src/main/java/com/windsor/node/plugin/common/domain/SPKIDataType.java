/*    */ package com.windsor.node.plugin.common.domain;
/*    */ 
/*    */ import java.util.ArrayList;
/*    */ import java.util.List;
/*    */ import javax.xml.bind.JAXBElement;
/*    */ import javax.xml.bind.annotation.XmlAccessType;
/*    */ import javax.xml.bind.annotation.XmlAccessorType;
/*    */ import javax.xml.bind.annotation.XmlAnyElement;
/*    */ import javax.xml.bind.annotation.XmlElementRef;
/*    */ import javax.xml.bind.annotation.XmlType;
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
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ @XmlAccessorType(XmlAccessType.FIELD)
/*    */ @XmlType(name="SPKIDataType", propOrder={"spkiSexpAndAny"})
/*    */ public class SPKIDataType
/*    */ {
/*    */   @XmlElementRef(name="SPKISexp", namespace="http://www.w3.org/2000/09/xmldsig#", type=JAXBElement.class)
/*    */   @XmlAnyElement(lax=true)
/*    */   protected List<Object> spkiSexpAndAny;
/*    */   
/*    */   public List<Object> getSPKISexpAndAny()
/*    */   {
/* 77 */     if (this.spkiSexpAndAny == null) {
/* 78 */       this.spkiSexpAndAny = new ArrayList();
/*    */     }
/* 80 */     return this.spkiSexpAndAny;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\domain\SPKIDataType.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */