/*     */ package com.windsor.node.plugin.common;
/*     */ 
/*     */ import com.windsor.node.common.domain.DataRequest;
/*     */ import com.windsor.node.common.domain.NodeTransaction;
/*     */ import com.windsor.node.plugin.common.domain.DocumentHeaderType;
/*     */ import com.windsor.node.plugin.common.domain.DocumentPayloadType;
/*     */ import com.windsor.node.plugin.common.domain.ExchangeNetworkDocumentType;
/*     */ import com.windsor.node.plugin.common.domain.ObjectFactory;
/*     */ import com.windsor.node.service.helper.id.UUIDGenerator;
/*     */ import java.io.FileOutputStream;
/*     */ import java.util.GregorianCalendar;
/*     */ import java.util.List;
/*     */ import java.util.Map;
/*     */ import javax.xml.bind.JAXBContext;
/*     */ import javax.xml.bind.JAXBElement;
/*     */ import javax.xml.bind.Marshaller;
/*     */ import javax.xml.datatype.DatatypeConfigurationException;
/*     */ import javax.xml.datatype.DatatypeFactory;
/*     */ import javax.xml.datatype.XMLGregorianCalendar;
/*     */ import org.apache.commons.lang3.StringUtils;
/*     */ import org.slf4j.Logger;
/*     */ import org.slf4j.LoggerFactory;
/*     */ 
/*     */ public abstract class BaseWnosJaxbPlugin extends com.windsor.node.plugin.BaseWnosPlugin
/*     */ {
/*     */   public static final String ARG_HEADER_DOCUMENT_TITLE = "Document Title";
/*     */   public static final String ARG_HEADER_KEYWORDS = "Keywords";
/*  28 */   protected Logger logger = LoggerFactory.getLogger(BaseWnosJaxbPlugin.class);
/*     */   
/*     */   protected JAXBElement<?> processHeaderDirectives(JAXBElement<?> jaxbElement, String docId, String operation, NodeTransaction transaction)
/*     */   {
/*  32 */     return processHeaderDirectives(jaxbElement, docId, operation, transaction, Boolean.FALSE);
/*     */   }
/*     */   
/*     */   protected JAXBElement<?> processHeaderDirectives(JAXBElement<?> jaxbElement, String docId, String operation, NodeTransaction transaction, Boolean forceHeaderUse)
/*     */   {
/*  37 */     String addHeader = getConfigValueAsStringNoFail("Add Header");
/*  38 */     if ((!"true".equalsIgnoreCase(addHeader)) && (!forceHeaderUse.booleanValue()))
/*     */     {
/*  40 */       return jaxbElement;
/*     */     }
/*  42 */     ObjectFactory fact = new ObjectFactory();
/*  43 */     ExchangeNetworkDocumentType exchangeNetworkDocumentType = fact.createExchangeNetworkDocumentType();
/*  44 */     exchangeNetworkDocumentType.setId(UUIDGenerator.makeId());
/*     */     
/*  46 */     DocumentHeaderType documentHeader = fact.createDocumentHeaderType();
/*  47 */     exchangeNetworkDocumentType.setHeader(documentHeader);
/*  48 */     String authorName = getConfigValueAsStringNoFail("Author");
/*  49 */     documentHeader.setAuthorName(StringUtils.isNotBlank(authorName) ? authorName : "");
/*  50 */     String contactInfo = getConfigValueAsStringNoFail("Contact Info");
/*  51 */     documentHeader.setSenderContact(StringUtils.isNotBlank(contactInfo) ? contactInfo : "");
/*  52 */     String orgName = getConfigValueAsStringNoFail("Organization");
/*  53 */     String payloadName = getConfigValueAsStringNoFail("Payload Operation");
/*  54 */     String documentTitle = getConfigValueAsStringNoFail("Document Title");
/*  55 */     String keywords = getConfigValueAsStringNoFail("Keywords");
/*  56 */     documentHeader.setOrganizationName(StringUtils.isNotBlank(orgName) ? orgName : "");
/*  57 */     if (StringUtils.isNotBlank(documentTitle))
/*     */     {
/*  59 */       documentHeader.setDocumentTitle(documentTitle);
/*     */     }
/*     */     else
/*     */     {
/*  63 */       documentHeader.setDocumentTitle(operation + docId);
/*     */     }
/*  65 */     if (StringUtils.isNotBlank(keywords))
/*     */     {
/*  67 */       documentHeader.setKeywords(keywords);
/*     */     }
/*  69 */     documentHeader.setCreationDateTime(getDocumentCreationDateTime());
/*  70 */     documentHeader.setDataFlowName(transaction.getRequest().getFlowName());
/*  71 */     documentHeader.setDataServiceName(transaction.getRequest().getService().getName());
/*     */     
/*  73 */     DocumentPayloadType documentPayloadType = fact.createDocumentPayloadType();
/*  74 */     exchangeNetworkDocumentType.getPayload().add(documentPayloadType);
/*  75 */     documentPayloadType.setId(docId);
/*  76 */     if (StringUtils.isNotBlank(payloadName))
/*     */     {
/*  78 */       documentPayloadType.setOperation(payloadName);
/*     */     }
/*  80 */     documentPayloadType.setAny(jaxbElement);
/*     */     
/*  82 */     return fact.createDocument(exchangeNetworkDocumentType);
/*     */   }
/*     */   
/*     */   protected XMLGregorianCalendar getDocumentCreationDateTime()
/*     */   {
/*  87 */     DatatypeFactory datatypeFactory = null;
/*     */     try
/*     */     {
/*  90 */       datatypeFactory = DatatypeFactory.newInstance();
/*     */     }
/*     */     catch (DatatypeConfigurationException e)
/*     */     {
/*  94 */       this.logger.warn("A serious configuration error occured when trying to create a factory to handle XML date objects, recovering, but no dates can be parsed or included in file.", e.getMessage());
/*     */       
/*  96 */       return null;
/*     */     }
/*  98 */     return datatypeFactory.newXMLGregorianCalendar(new GregorianCalendar());
/*     */   }
/*     */   
/*     */   protected void writeDocument(JAXBElement<?> document, String pathname) throws javax.xml.bind.JAXBException, java.io.IOException
/*     */   {
/* 103 */     Class<?> clazz = document.getValue().getClass();
/* 104 */     StringBuffer packageNames = new StringBuffer(clazz.getPackage().getName());
/*     */     
/* 106 */     if ((document.getValue() instanceof ExchangeNetworkDocumentType))
/*     */     {
/* 108 */       ExchangeNetworkDocumentType doc = (ExchangeNetworkDocumentType)document.getValue();
/* 109 */       for (int i = 0; i < doc.getPayload().size(); i++)
/*     */       {
/*     */ 
/* 112 */         packageNames.insert(0, ":").insert(0, ((JAXBElement)((DocumentPayloadType)doc.getPayload().get(i)).getAny()).getValue().getClass().getPackage().getName());
/*     */       }
/*     */     }
/* 115 */     JAXBContext context = JAXBContext.newInstance(packageNames.toString(), clazz.getClassLoader());
/* 116 */     Marshaller m = context.createMarshaller();
/* 117 */     m.setProperty("jaxb.formatted.output", Boolean.TRUE);
/* 118 */     m.marshal(document, new FileOutputStream(pathname));
/*     */   }
/*     */   
/*     */ 
/*     */   public String getConfigValueAsStringNoFail(String key)
/*     */   {
/* 124 */     if (StringUtils.isBlank(key))
/*     */     {
/* 126 */       return null;
/*     */     }
/* 128 */     this.logger.debug("Looking for: " + key);
/* 129 */     if (!getConfigurationArguments().containsKey(key))
/*     */     {
/* 131 */       return null;
/*     */     }
/*     */     
/* 134 */     String value = (String)getConfigurationArguments().get(key);
/* 135 */     if (StringUtils.isBlank(value))
/*     */     {
/* 137 */       return null;
/*     */     }
/* 139 */     return value;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\BaseWnosJaxbPlugin.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */