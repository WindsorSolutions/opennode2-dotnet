/*     */ package com.windsor.node.plugin.common.xml.stream;
/*     */ 
/*     */ import java.io.OutputStream;
/*     */ import java.io.OutputStreamWriter;
/*     */ import java.io.UnsupportedEncodingException;
/*     */ import java.io.Writer;
/*     */ import java.util.ArrayList;
/*     */ import java.util.List;
/*     */ import javax.xml.bind.JAXBContext;
/*     */ import javax.xml.bind.JAXBElement;
/*     */ import javax.xml.bind.JAXBException;
/*     */ import javax.xml.bind.Marshaller;
/*     */ import javax.xml.stream.FactoryConfigurationError;
/*     */ import javax.xml.stream.XMLOutputFactory;
/*     */ import javax.xml.stream.XMLStreamException;
/*     */ import javax.xml.stream.XMLStreamWriter;
/*     */ import org.apache.commons.lang3.StringUtils;
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ public class ElementStreamWriter
/*     */   implements ElementWriter
/*     */ {
/*     */   private XMLStreamWriter out;
/*     */   private Marshaller marshaller;
/*     */   
/*     */   public ElementStreamWriter(Class<?>... classesToBeBound)
/*     */     throws ElementWriterException
/*     */   {
/*     */     try
/*     */     {
/*  33 */       JAXBContext context = JAXBContext.newInstance(makeContextPath(classesToBeBound), getClass().getClassLoader());
/*  34 */       this.marshaller = context.createMarshaller();
/*  35 */       this.marshaller.setProperty("jaxb.formatted.output", Boolean.valueOf(isFormattedOutput()));
/*  36 */       this.marshaller.setProperty("jaxb.fragment", Boolean.valueOf(isFragment()));
/*     */     } catch (Exception e) {
/*  38 */       throw new ElementWriterException(e);
/*     */     }
/*     */   }
/*     */   
/*     */   private String makeContextPath(Class<?>... classesToBeBound)
/*     */   {
/*  44 */     List<String> packages = new ArrayList();
/*     */     
/*  46 */     for (Class<?> k : classesToBeBound) {
/*  47 */       packages.add(k.getPackage().getName());
/*     */     }
/*     */     
/*  50 */     return StringUtils.join(packages, ":");
/*     */   }
/*     */   
/*     */   protected boolean isFragment() {
/*  54 */     return Boolean.TRUE.booleanValue();
/*     */   }
/*     */   
/*     */   protected boolean isFormattedOutput() {
/*  58 */     return Boolean.TRUE.booleanValue();
/*     */   }
/*     */   
/*     */   public void open(OutputStream outputStream)
/*     */     throws ElementWriterException
/*     */   {
/*     */     try
/*     */     {
/*  66 */       onBeforeOpen();
/*     */       
/*  68 */       Writer writer = new OutputStreamWriter(outputStream, "UTF-8");
/*     */       
/*  70 */       XMLOutputFactory outFactory = XMLOutputFactory.newFactory();
/*     */       
/*  72 */       outFactory.setProperty("javax.xml.stream.isRepairingNamespaces", Boolean.valueOf(true));
/*     */       
/*  74 */       this.out = outFactory.createXMLStreamWriter(writer);
/*     */       
/*  76 */       this.out.writeStartDocument("UTF-8", "1.0");
/*     */       
/*  78 */       onAfterOpen(this.out);
/*     */     }
/*     */     catch (XMLStreamException e) {
/*  81 */       throw new ElementWriterException("Unable to create XML stream writer from outputstream {" + outputStream + "}.", e);
/*     */     } catch (FactoryConfigurationError e) {
/*  83 */       throw new ElementWriterException("Unable to create XML stream writer from outputstream {" + outputStream + "}.", e);
/*     */     } catch (UnsupportedEncodingException e) {
/*  85 */       throw new ElementWriterException(e);
/*     */     }
/*     */   }
/*     */   
/*     */   public void write(JAXBElement<?> element) throws ElementWriterException
/*     */   {
/*     */     try {
/*  92 */       this.marshaller.marshal(element, this.out);
/*     */     } catch (JAXBException e) {
/*  94 */       throw new ElementWriterException("Unable to marshal element {" + element + "} XML stream.", e);
/*     */     }
/*     */   }
/*     */   
/*     */   public void close() throws ElementWriterException
/*     */   {
/*     */     try {
/* 101 */       onBeforeClose(this.out);
/* 102 */       this.out.close();
/* 103 */       onAfterClose();
/*     */     } catch (XMLStreamException e) {
/* 105 */       throw new ElementWriterException("Unable to close XML stream writer {" + this.out + "}.", e);
/*     */     }
/*     */   }
/*     */   
/*     */   protected void onBeforeOpen() throws ElementWriterException
/*     */   {}
/*     */   
/*     */   protected void onAfterOpen(XMLStreamWriter out) throws ElementWriterException
/*     */   {}
/*     */   
/* 115 */   protected void onBeforeClose(XMLStreamWriter out) throws ElementWriterException { try { out.writeEndDocument();
/*     */     } catch (XMLStreamException e) {
/* 117 */       throw new ElementWriterException("Unable to write end of document {" + out + "}.", e);
/*     */     }
/*     */   }
/*     */   
/*     */   protected void onAfterClose() {}
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\stream\ElementStreamWriter.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */