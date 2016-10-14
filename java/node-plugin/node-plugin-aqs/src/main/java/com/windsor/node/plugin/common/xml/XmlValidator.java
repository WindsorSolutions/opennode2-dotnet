/*     */ package com.windsor.node.plugin.common.xml;
/*     */ 
/*     */ import java.io.File;
/*     */ import java.io.IOException;
/*     */ import javax.xml.transform.Source;
/*     */ import javax.xml.transform.stream.StreamSource;
/*     */ import javax.xml.validation.Schema;
/*     */ import javax.xml.validation.SchemaFactory;
/*     */ import javax.xml.validation.Validator;
/*     */ import org.apache.commons.lang3.StringUtils;
/*     */ import org.slf4j.Logger;
/*     */ import org.slf4j.LoggerFactory;
/*     */ import org.springframework.beans.factory.InitializingBean;
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
/*     */ @Deprecated
/*     */ public class XmlValidator
/*     */   implements InitializingBean
/*     */ {
/*  60 */   protected static Logger logger = LoggerFactory.getLogger(XmlValidator.class);
/*     */   
/*     */   private String schemaFilename;
/*     */   
/*     */ 
/*     */   public XmlValidator() {}
/*     */   
/*     */   public XmlValidator(String schemaFileName)
/*     */   {
/*  69 */     this.schemaFilename = schemaFileName;
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
/*     */   public boolean validate(String filename)
/*     */   {
/*  83 */     validateLenient(filename);
/*  84 */     return validateHarsh(filename);
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
/*     */   public boolean validateHarsh(String filename)
/*     */   {
/*  98 */     logger.debug("Validating xml file " + filename);
/*     */     
/* 100 */     SchemaFactory factory = SchemaFactory.newInstance("http://www.w3.org/2001/XMLSchema");
/*     */     
/*     */ 
/* 103 */     boolean isValid = false;
/*     */     
/*     */     try
/*     */     {
/* 107 */       File schemaLocation = new File(this.schemaFilename);
/* 108 */       Schema schema = factory.newSchema(schemaLocation);
/*     */       
/* 110 */       Validator validator = schema.newValidator();
/*     */       
/* 112 */       Source source = new StreamSource(filename);
/*     */       
/* 114 */       validator.validate(source);
/*     */       
/* 116 */       isValid = true;
/*     */       
/* 118 */       logger.info(filename + " is valid.");
/*     */     }
/*     */     catch (SAXParseException spe)
/*     */     {
/* 122 */       isValid = false;
/* 123 */       logger.info(filename + " is not valid.");
/*     */     }
/*     */     catch (SAXException ex)
/*     */     {
/* 127 */       logger.error(errMsg(filename) + ex.getMessage());
/*     */       
/* 129 */       throw new RuntimeException(errMsg(filename) + ex.getMessage(), ex);
/*     */     }
/*     */     catch (IOException e)
/*     */     {
/* 133 */       logger.error(e.getMessage());
/*     */       
/* 135 */       throw new RuntimeException(e);
/*     */     }
/*     */     
/* 138 */     return isValid;
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
/*     */   public boolean validateLenient(String filename)
/*     */   {
/* 151 */     logger.debug("Gently validating xml file " + filename);
/*     */     
/* 153 */     SchemaFactory factory = SchemaFactory.newInstance("http://www.w3.org/2001/XMLSchema");
/*     */     
/*     */ 
/* 156 */     boolean isValid = false;
/*     */     
/*     */     try
/*     */     {
/* 160 */       File schemaLocation = new File(this.schemaFilename);
/* 161 */       Schema schema = factory.newSchema(schemaLocation);
/*     */       
/* 163 */       Validator validator = schema.newValidator();
/* 164 */       logger.debug("validator implementation: " + validator.getClass());
/* 165 */       ErrorHandler lenient = new ForgivingErrorHandler();
/* 166 */       validator.setErrorHandler(lenient);
/*     */       
/* 168 */       Source source = new StreamSource(filename);
/*     */       
/* 170 */       validator.validate(source);
/*     */       
/* 172 */       isValid = true;
/*     */       
/* 174 */       logger.info(filename + " may or may not be valid.");
/*     */     }
/*     */     catch (SAXException ex)
/*     */     {
/* 178 */       logger.error(errMsg(filename) + ex.getMessage());
/*     */       
/* 180 */       throw new RuntimeException(errMsg(filename) + ex.getMessage(), ex);
/*     */     }
/*     */     catch (IOException e)
/*     */     {
/* 184 */       logger.error(e.getMessage());
/*     */       
/* 186 */       throw new RuntimeException(e);
/*     */     }
/*     */     
/* 189 */     return isValid;
/*     */   }
/*     */   
/*     */ 
/*     */   private String errMsg(String filename)
/*     */   {
/* 195 */     return filename + " is not valid, message: ";
/*     */   }
/*     */   
/*     */   private String saxParseExceptionMsg(SAXParseException ex)
/*     */   {
/* 200 */     return ex.getMessage() + " at line " + ex.getLineNumber() + ", column " + ex.getColumnNumber();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public String getSchemaFilename()
/*     */   {
/* 208 */     return this.schemaFilename;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSchemaFilename(String schemaFilename)
/*     */   {
/* 216 */     this.schemaFilename = schemaFilename;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */   private class ForgivingErrorHandler
/*     */     implements ErrorHandler
/*     */   {
/*     */     private ForgivingErrorHandler() {}
/*     */     
/*     */ 
/*     */ 
/*     */     public void warning(SAXParseException ex)
/*     */     {
/* 230 */       XmlValidator.logger.warn("Warning: " + XmlValidator.this.saxParseExceptionMsg(ex));
/*     */     }
/*     */     
/*     */     public void error(SAXParseException ex)
/*     */     {
/* 235 */       XmlValidator.logger.error("Error: " + XmlValidator.this.saxParseExceptionMsg(ex));
/*     */     }
/*     */     
/*     */     public void fatalError(SAXParseException ex) throws SAXException
/*     */     {
/* 240 */       XmlValidator.logger.error("Fatal error: " + XmlValidator.this.saxParseExceptionMsg(ex));
/* 241 */       throw ex;
/*     */     }
/*     */   }
/*     */   
/*     */ 
/*     */   public void afterPropertiesSet()
/*     */     throws Exception
/*     */   {
/* 249 */     if (StringUtils.isBlank(this.schemaFilename)) {
/* 250 */       throw new RuntimeException("schemaFilename is null or empty");
/*     */     }
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\XmlValidator.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */