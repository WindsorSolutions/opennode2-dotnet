/*     */ package com.windsor.node.plugin.common.domain;
/*     */ 
/*     */ import java.util.ArrayList;
/*     */ import java.util.List;
/*     */ import javax.xml.bind.annotation.XmlAccessType;
/*     */ import javax.xml.bind.annotation.XmlAccessorType;
/*     */ import javax.xml.bind.annotation.XmlAnyElement;
/*     */ import javax.xml.bind.annotation.XmlAttribute;
/*     */ import javax.xml.bind.annotation.XmlElementRefs;
/*     */ import javax.xml.bind.annotation.XmlID;
/*     */ import javax.xml.bind.annotation.XmlMixed;
/*     */ import javax.xml.bind.annotation.XmlSchemaType;
/*     */ import javax.xml.bind.annotation.XmlType;
/*     */ import javax.xml.bind.annotation.adapters.CollapsedStringAdapter;
/*     */ import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ @XmlAccessorType(XmlAccessType.FIELD)
/*     */ @XmlType(name="KeyInfoType", propOrder={"content"})
/*     */ public class KeyInfoType
/*     */ {
/*     */   @XmlElementRefs({@javax.xml.bind.annotation.XmlElementRef(name="X509Data", namespace="http://www.w3.org/2000/09/xmldsig#", type=javax.xml.bind.JAXBElement.class), @javax.xml.bind.annotation.XmlElementRef(name="KeyName", namespace="http://www.w3.org/2000/09/xmldsig#", type=javax.xml.bind.JAXBElement.class), @javax.xml.bind.annotation.XmlElementRef(name="MgmtData", namespace="http://www.w3.org/2000/09/xmldsig#", type=javax.xml.bind.JAXBElement.class), @javax.xml.bind.annotation.XmlElementRef(name="KeyValue", namespace="http://www.w3.org/2000/09/xmldsig#", type=javax.xml.bind.JAXBElement.class), @javax.xml.bind.annotation.XmlElementRef(name="SPKIData", namespace="http://www.w3.org/2000/09/xmldsig#", type=javax.xml.bind.JAXBElement.class), @javax.xml.bind.annotation.XmlElementRef(name="PGPData", namespace="http://www.w3.org/2000/09/xmldsig#", type=javax.xml.bind.JAXBElement.class), @javax.xml.bind.annotation.XmlElementRef(name="RetrievalMethod", namespace="http://www.w3.org/2000/09/xmldsig#", type=javax.xml.bind.JAXBElement.class)})
/*     */   @XmlMixed
/*     */   @XmlAnyElement(lax=true)
/*     */   protected List<Object> content;
/*     */   @XmlAttribute(name="Id")
/*     */   @XmlJavaTypeAdapter(CollapsedStringAdapter.class)
/*     */   @XmlID
/*     */   @XmlSchemaType(name="ID")
/*     */   protected String id;
/*     */   
/*     */   public List<Object> getContent()
/*     */   {
/* 112 */     if (this.content == null) {
/* 113 */       this.content = new ArrayList();
/*     */     }
/* 115 */     return this.content;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String getId()
/*     */   {
/* 127 */     return this.id;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setId(String value)
/*     */   {
/* 139 */     this.id = value;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\domain\KeyInfoType.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */