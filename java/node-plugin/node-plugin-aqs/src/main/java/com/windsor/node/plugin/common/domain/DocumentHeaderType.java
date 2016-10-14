/*     */ package com.windsor.node.plugin.common.domain;
/*     */ 
/*     */ import java.io.Serializable;
/*     */ import java.util.ArrayList;
/*     */ import java.util.List;
/*     */ import javax.xml.bind.annotation.XmlAccessType;
/*     */ import javax.xml.bind.annotation.XmlAccessorType;
/*     */ import javax.xml.bind.annotation.XmlElement;
/*     */ import javax.xml.bind.annotation.XmlSchemaType;
/*     */ import javax.xml.bind.annotation.XmlType;
/*     */ import javax.xml.datatype.XMLGregorianCalendar;
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
/*     */ @XmlType(name="DocumentHeaderType", namespace="http://www.exchangenetwork.net/schema/header/2", propOrder={"authorName", "organizationName", "documentTitle", "creationDateTime", "keywords", "comment", "dataFlowName", "dataServiceName", "senderContact", "applicationUserIdentifier", "senderAddress", "property", "signature"})
/*     */ public class DocumentHeaderType
/*     */   implements Serializable
/*     */ {
/*     */   private static final long serialVersionUID = 1L;
/*     */   @XmlElement(name="AuthorName", required=true)
/*     */   protected String authorName;
/*     */   @XmlElement(name="OrganizationName", required=true)
/*     */   protected String organizationName;
/*     */   @XmlElement(name="DocumentTitle", required=true)
/*     */   protected String documentTitle;
/*     */   @XmlElement(name="CreationDateTime", required=true)
/*     */   @XmlSchemaType(name="dateTime")
/*     */   protected XMLGregorianCalendar creationDateTime;
/*     */   @XmlElement(name="Keywords")
/*     */   protected String keywords;
/*     */   @XmlElement(name="Comment")
/*     */   protected String comment;
/*     */   @XmlElement(name="DataFlowName")
/*     */   protected String dataFlowName;
/*     */   @XmlElement(name="DataServiceName")
/*     */   protected String dataServiceName;
/*     */   @XmlElement(name="SenderContact")
/*     */   protected String senderContact;
/*     */   @XmlElement(name="ApplicationUserIdentifier")
/*     */   protected String applicationUserIdentifier;
/*     */   @XmlElement(name="SenderAddress")
/*     */   @XmlSchemaType(name="anyURI")
/*     */   protected List<String> senderAddress;
/*     */   @XmlElement(name="Property")
/*     */   protected List<NameValuePair> property;
/*     */   @XmlElement(name="Signature", namespace="http://www.w3.org/2000/09/xmldsig#")
/*     */   protected SignatureType signature;
/*     */   
/*     */   public String getAuthorName()
/*     */   {
/* 112 */     return this.authorName;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setAuthorName(String value)
/*     */   {
/* 124 */     this.authorName = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String getOrganizationName()
/*     */   {
/* 136 */     return this.organizationName;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setOrganizationName(String value)
/*     */   {
/* 148 */     this.organizationName = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String getDocumentTitle()
/*     */   {
/* 160 */     return this.documentTitle;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setDocumentTitle(String value)
/*     */   {
/* 172 */     this.documentTitle = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public XMLGregorianCalendar getCreationDateTime()
/*     */   {
/* 184 */     return this.creationDateTime;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setCreationDateTime(XMLGregorianCalendar value)
/*     */   {
/* 196 */     this.creationDateTime = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String getKeywords()
/*     */   {
/* 208 */     return this.keywords;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setKeywords(String value)
/*     */   {
/* 220 */     this.keywords = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String getComment()
/*     */   {
/* 232 */     return this.comment;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setComment(String value)
/*     */   {
/* 244 */     this.comment = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String getDataFlowName()
/*     */   {
/* 256 */     return this.dataFlowName;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setDataFlowName(String value)
/*     */   {
/* 268 */     this.dataFlowName = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String getDataServiceName()
/*     */   {
/* 280 */     return this.dataServiceName;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setDataServiceName(String value)
/*     */   {
/* 292 */     this.dataServiceName = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String getSenderContact()
/*     */   {
/* 304 */     return this.senderContact;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSenderContact(String value)
/*     */   {
/* 316 */     this.senderContact = value;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public String getApplicationUserIdentifier()
/*     */   {
/* 328 */     return this.applicationUserIdentifier;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setApplicationUserIdentifier(String value)
/*     */   {
/* 340 */     this.applicationUserIdentifier = value;
/*     */   }
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
/*     */   public List<String> getSenderAddress()
/*     */   {
/* 366 */     if (this.senderAddress == null) {
/* 367 */       this.senderAddress = new ArrayList();
/*     */     }
/* 369 */     return this.senderAddress;
/*     */   }
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
/*     */   public List<NameValuePair> getProperty()
/*     */   {
/* 395 */     if (this.property == null) {
/* 396 */       this.property = new ArrayList();
/*     */     }
/* 398 */     return this.property;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public SignatureType getSignature()
/*     */   {
/* 410 */     return this.signature;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSignature(SignatureType value)
/*     */   {
/* 422 */     this.signature = value;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\domain\DocumentHeaderType.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */