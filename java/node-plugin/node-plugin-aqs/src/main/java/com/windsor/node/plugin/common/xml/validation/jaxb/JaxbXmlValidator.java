/*     */ package com.windsor.node.plugin.common.xml.validation.jaxb;
/*     */ 
/*     */ import com.windsor.node.plugin.common.xml.validation.ValidationException;
/*     */ import com.windsor.node.plugin.common.xml.validation.ValidationResult;
/*     */ import java.io.File;
/*     */ import java.io.IOException;
/*     */ import java.io.InputStream;
/*     */ import java.net.MalformedURLException;
/*     */ import java.net.URI;
/*     */ import java.net.URL;
/*     */ import javax.xml.transform.Source;
/*     */ import javax.xml.transform.stream.StreamSource;
/*     */ import javax.xml.validation.Schema;
/*     */ import javax.xml.validation.SchemaFactory;
/*     */ import org.xml.sax.ErrorHandler;
/*     */ import org.xml.sax.SAXException;
/*     */ import org.xml.sax.SAXParseException;
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
/*     */ public class JaxbXmlValidator
/*     */   implements com.windsor.node.plugin.common.xml.validation.Validator
/*     */ {
/*     */   private URL schemaFile;
/*     */   
/*     */   public JaxbXmlValidator(URL schemaFile)
/*     */   {
/*  40 */     setSchemaUrl(schemaFile);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public JaxbXmlValidator(String schemaFilePath)
/*     */   {
/*     */     try
/*     */     {
/*  52 */       setSchemaUrl(new File(schemaFilePath).toURI().toURL());
/*     */     } catch (MalformedURLException e) {
/*  54 */       throw new ValidationException(e.getLocalizedMessage(), e);
/*     */     }
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public ValidationResult validate(InputStream xmlInputStream)
/*     */     throws ValidationException
/*     */   {
/*  64 */     final JaxbValidationResult results = new JaxbValidationResult();
/*     */     
/*     */ 
/*     */ 
/*     */ 
/*     */     try
/*     */     {
/*  71 */       SchemaFactory schemaFactory = SchemaFactory.newInstance("http://www.w3.org/2001/XMLSchema");
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*  76 */       Schema schema = schemaFactory.newSchema(this.schemaFile);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*  81 */       javax.xml.validation.Validator jaxbValidator = schema.newValidator();
/*     */       
/*  83 */       jaxbValidator.setErrorHandler(new ErrorHandler()
/*     */       {
/*     */         public void warning(SAXParseException exception) throws SAXException
/*     */         {}
/*     */         
/*     */         public void fatalError(SAXParseException exception) throws SAXException
/*     */         {
/*  90 */           results.error(exception.getLocalizedMessage());
/*     */         }
/*     */         
/*     */         public void error(SAXParseException exception) throws SAXException
/*     */         {
/*  95 */           results.error(exception.getLocalizedMessage());
/*     */ 
/*     */         }
/*     */         
/*     */ 
/*     */ 
/* 101 */       });
/* 102 */       Source xmlFile = new StreamSource(xmlInputStream);
/*     */       
/*     */ 
/*     */ 
/*     */ 
/*     */       try
/*     */       {
/* 109 */         jaxbValidator.validate(xmlFile);
/*     */       } catch (SAXException e) {
/* 111 */         results.error(e.getLocalizedMessage());
/*     */       }
/*     */       catch (IOException e) {}
/*     */     }
/*     */     catch (SAXException e)
/*     */     {
/* 117 */       throw new ValidationException(e.getLocalizedMessage(), e);
/*     */     }
/*     */     
/* 120 */     return results;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSchemaUrl(URL schemaUrl)
/*     */   {
/* 130 */     this.schemaFile = schemaUrl;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\validation\jaxb\JaxbXmlValidator.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */