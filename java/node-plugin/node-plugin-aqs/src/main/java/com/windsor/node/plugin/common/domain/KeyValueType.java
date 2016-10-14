/*    */ package com.windsor.node.plugin.common.domain;
/*    */ 
/*    */ import java.util.ArrayList;
/*    */ import java.util.List;
/*    */ import javax.xml.bind.annotation.XmlAccessType;
/*    */ import javax.xml.bind.annotation.XmlAccessorType;
/*    */ import javax.xml.bind.annotation.XmlAnyElement;
/*    */ import javax.xml.bind.annotation.XmlElementRefs;
/*    */ import javax.xml.bind.annotation.XmlMixed;
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
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ @XmlAccessorType(XmlAccessType.FIELD)
/*    */ @XmlType(name="KeyValueType", propOrder={"content"})
/*    */ public class KeyValueType
/*    */ {
/*    */   @XmlElementRefs({@javax.xml.bind.annotation.XmlElementRef(name="DSAKeyValue", namespace="http://www.w3.org/2000/09/xmldsig#", type=javax.xml.bind.JAXBElement.class), @javax.xml.bind.annotation.XmlElementRef(name="RSAKeyValue", namespace="http://www.w3.org/2000/09/xmldsig#", type=javax.xml.bind.JAXBElement.class)})
/*    */   @XmlMixed
/*    */   @XmlAnyElement(lax=true)
/*    */   protected List<Object> content;
/*    */   
/*    */   public List<Object> getContent()
/*    */   {
/* 86 */     if (this.content == null) {
/* 87 */       this.content = new ArrayList();
/*    */     }
/* 89 */     return this.content;
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\domain\KeyValueType.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */