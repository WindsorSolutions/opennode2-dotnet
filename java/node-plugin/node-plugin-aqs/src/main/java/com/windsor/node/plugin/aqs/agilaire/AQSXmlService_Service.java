/*    */ package com.windsor.node.plugin.aqs.agilaire;
/*    */ 
/*    */ import java.net.MalformedURLException;
/*    */ import java.net.URL;
/*    */ import java.util.logging.Level;
/*    */ import java.util.logging.Logger;
/*    */ import javax.xml.namespace.QName;
/*    */ import javax.xml.ws.Service;
/*    */ import javax.xml.ws.WebEndpoint;
/*    */ import javax.xml.ws.WebServiceClient;
/*    */ import javax.xml.ws.WebServiceFeature;
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
/*    */ @WebServiceClient(name="AQSXmlService", wsdlLocation="http://107.6.97.242:9889/AirVision.Services.WebServices.AQSXml/AQSXmlService/?wsdl", targetNamespace="http://tempuri.org/")
/*    */ public class AQSXmlService_Service
/*    */   extends Service
/*    */ {
/*    */   public static final URL WSDL_LOCATION;
/* 31 */   public static final QName SERVICE = new QName("http://tempuri.org/", "AQSXmlService");
/* 32 */   public static final QName BasicHttpBindingAQSXmlService = new QName("http://tempuri.org/", "BasicHttpBinding_AQSXmlService");
/*    */   
/* 34 */   static { URL url = null;
/*    */     try {
/* 36 */       url = new URL("http://107.6.97.242:9889/AirVision.Services.WebServices.AQSXml/AQSXmlService/?wsdl");
/*    */     } catch (MalformedURLException e) {
/* 38 */       Logger.getLogger(AQSXmlService_Service.class.getName()).log(Level.INFO, "Can not initialize the default wsdl from {0}", "http://107.6.97.242:9889/AirVision.Services.WebServices.AQSXml/AQSXmlService/?wsdl");
/*    */     }
/*    */     
/*    */ 
/* 42 */     WSDL_LOCATION = url;
/*    */   }
/*    */   
/*    */   public AQSXmlService_Service(URL wsdlLocation) {
/* 46 */     super(wsdlLocation, SERVICE);
/*    */   }
/*    */   
/*    */   public AQSXmlService_Service(URL wsdlLocation, QName serviceName) {
/* 50 */     super(wsdlLocation, serviceName);
/*    */   }
/*    */   
/*    */   public AQSXmlService_Service() {
/* 54 */     super(WSDL_LOCATION, SERVICE);
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */   public AQSXmlService_Service(WebServiceFeature... features)
/*    */   {
/* 61 */     super(WSDL_LOCATION, SERVICE, features);
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */   public AQSXmlService_Service(URL wsdlLocation, WebServiceFeature... features)
/*    */   {
/* 68 */     super(wsdlLocation, SERVICE, features);
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */   public AQSXmlService_Service(URL wsdlLocation, QName serviceName, WebServiceFeature... features)
/*    */   {
/* 75 */     super(wsdlLocation, serviceName, features);
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   @WebEndpoint(name="BasicHttpBinding_AQSXmlService")
/*    */   public AQSXmlService getBasicHttpBindingAQSXmlService()
/*    */   {
/* 85 */     return (AQSXmlService)super.getPort(BasicHttpBindingAQSXmlService, AQSXmlService.class);
/*    */   }
/*    */   
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */ 
/*    */   @WebEndpoint(name="BasicHttpBinding_AQSXmlService")
/*    */   public AQSXmlService getBasicHttpBindingAQSXmlService(WebServiceFeature... features)
/*    */   {
/* 97 */     return (AQSXmlService)super.getPort(BasicHttpBindingAQSXmlService, AQSXmlService.class, features);
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\agilaire\AQSXmlService_Service.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */