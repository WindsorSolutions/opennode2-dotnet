/*    */ package com.windsor.node.plugin.aqs.agilaire;
/*    */ 
/*    */ import java.io.File;
/*    */ import java.io.PrintStream;
/*    */ import java.net.MalformedURLException;
/*    */ import java.net.URI;
/*    */ import java.net.URL;
/*    */ import javax.xml.datatype.XMLGregorianCalendar;
/*    */ import javax.xml.namespace.QName;
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
/*    */ public final class AQSXmlService_BasicHttpBindingAQSXmlService_Client
/*    */ {
/* 30 */   private static final QName SERVICE_NAME = new QName("http://tempuri.org/", "AQSXmlService");
/*    */   
/*    */ 
/*    */   public static void main(String[] args)
/*    */     throws Exception
/*    */   {
/* 36 */     URL wsdlURL = AQSXmlService_Service.WSDL_LOCATION;
/* 37 */     if (args.length > 0) {
/* 38 */       File wsdlFile = new File(args[0]);
/*    */       try {
/* 40 */         if (wsdlFile.exists()) {
/* 41 */           wsdlURL = wsdlFile.toURI().toURL();
/*    */         } else {
/* 43 */           wsdlURL = new URL(args[0]);
/*    */         }
/*    */       } catch (MalformedURLException e) {
/* 46 */         e.printStackTrace();
/*    */       }
/*    */     }
/*    */     
/* 50 */     AQSXmlService_Service ss = new AQSXmlService_Service(wsdlURL, SERVICE_NAME);
/* 51 */     AQSXmlService port = ss.getBasicHttpBindingAQSXmlService();
/*    */     
/*    */ 
/* 54 */     System.out.println("Invoking getAQS3XmlData...");
/* 55 */     AQS3WebServiceArgument _getAQS3XmlData_args = null;
/* 56 */     AQSXmlResultData _getAQS3XmlData__return = port.getAQS3XmlData(_getAQS3XmlData_args);
/* 57 */     System.out.println("getAQS3XmlData.result=" + _getAQS3XmlData__return);
/*    */     
/*    */ 
/*    */ 
/*    */ 
/* 62 */     System.out.println("Invoking getAQSXmlData...");
/* 63 */     AQSWebServiceArgument _getAQSXmlData_args = null;
/* 64 */     AQSXmlResultData _getAQSXmlData__return = port.getAQSXmlData(_getAQSXmlData_args);
/* 65 */     System.out.println("getAQSXmlData.result=" + _getAQSXmlData__return);
/*    */     
/*    */ 
/*    */ 
/*    */ 
/* 70 */     System.out.println("Invoking getAQSXmlDataWeb...");
/* 71 */     XMLGregorianCalendar _getAQSXmlDataWeb_startTime = null;
/* 72 */     XMLGregorianCalendar _getAQSXmlDataWeb_endTime = null;
/* 73 */     String _getAQSXmlDataWeb_aqsXmlSchemaVersion = "";
/* 74 */     Boolean _getAQSXmlDataWeb_sendRdTransactions = null;
/* 75 */     Boolean _getAQSXmlDataWeb_sendRbTransactions = null;
/* 76 */     Boolean _getAQSXmlDataWeb_sendRaTransactions = null;
/* 77 */     Boolean _getAQSXmlDataWeb_sendRpTransactions = null;
/* 78 */     Boolean _getAQSXmlDataWeb_sendOnlyQaData = null;
/* 79 */     AQSXmlResultData _getAQSXmlDataWeb__return = port.getAQSXmlDataWeb(_getAQSXmlDataWeb_startTime, _getAQSXmlDataWeb_endTime, _getAQSXmlDataWeb_aqsXmlSchemaVersion, _getAQSXmlDataWeb_sendRdTransactions, _getAQSXmlDataWeb_sendRbTransactions, _getAQSXmlDataWeb_sendRaTransactions, _getAQSXmlDataWeb_sendRpTransactions, _getAQSXmlDataWeb_sendOnlyQaData);
/* 80 */     System.out.println("getAQSXmlDataWeb.result=" + _getAQSXmlDataWeb__return);
/*    */     
/*    */ 
/*    */ 
/*    */ 
/* 85 */     System.out.println("Invoking getAQSParameters...");
/* 86 */     ArrayOfAQSParameterInformation _getAQSParameters__return = port.getAQSParameters();
/* 87 */     System.out.println("getAQSParameters.result=" + _getAQSParameters__return);
/*    */     
/*    */ 
/*    */ 
/*    */ 
/* 92 */     System.exit(0);
/*    */   }
/*    */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\agilaire\AQSXmlService_BasicHttpBindingAQSXmlService_Client.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */