/*     */ package com.windsor.node.plugin.aqs.wsdl;
/*     */ 
/*     */ import java.net.MalformedURLException;
/*     */ import java.net.URL;
/*     */ import java.rmi.Remote;
/*     */ import java.util.HashSet;
/*     */ import java.util.Iterator;
/*     */ import javax.xml.namespace.QName;
/*     */ import javax.xml.rpc.ServiceException;
/*     */ import org.apache.axis.client.Service;
/*     */ import org.apache.axis.client.Stub;
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
/*     */ public class AQDEDataLocator
/*     */   extends Service
/*     */   implements AQDEData
/*     */ {
/*     */   public static final long serialVersionUID = 1L;
/*  51 */   private final String AQDEDataSoap12_address = "http://134.179.217.247/reporter/AQDEData.asmx";
/*     */   
/*     */   public String getAQDEDataSoap12Address() {
/*  54 */     return "http://134.179.217.247/reporter/AQDEData.asmx";
/*     */   }
/*     */   
/*     */ 
/*  58 */   private String AQDEDataSoap12WSDDServiceName = "AQDEDataSoap12";
/*     */   
/*     */   public String getAQDEDataSoap12WSDDServiceName() {
/*  61 */     return this.AQDEDataSoap12WSDDServiceName;
/*     */   }
/*     */   
/*     */   public void setAQDEDataSoap12WSDDServiceName(String name) {
/*  65 */     this.AQDEDataSoap12WSDDServiceName = name;
/*     */   }
/*     */   
/*     */ 
/*  69 */   private final String AQDEDataSoap_address = "http://134.179.217.247/reporter/AQDEData.asmx";
/*     */   
/*     */   public String getAQDEDataSoapAddress() {
/*  72 */     return "http://134.179.217.247/reporter/AQDEData.asmx";
/*     */   }
/*     */   
/*     */ 
/*  76 */   private String AQDEDataSoapWSDDServiceName = "AQDEDataSoap";
/*     */   
/*     */   public String getAQDEDataSoapWSDDServiceName() {
/*  79 */     return this.AQDEDataSoapWSDDServiceName;
/*     */   }
/*     */   
/*     */   public void setAQDEDataSoapWSDDServiceName(String name) {
/*  83 */     this.AQDEDataSoapWSDDServiceName = name;
/*     */   }
/*     */   
/*     */   public AQDEDataSoap getAQDEDataSoap() throws ServiceException {
/*     */     URL endpoint;
/*     */     try {
/*  89 */       endpoint = new URL("http://134.179.217.247/reporter/AQDEData.asmx");
/*     */     } catch (MalformedURLException e) {
/*  91 */       throw new ServiceException(e);
/*     */     }
/*  93 */     return getAQDEDataSoap(endpoint);
/*     */   }
/*     */   
/*     */   public AQDEDataSoap getAQDEDataSoap(URL portAddress) throws ServiceException
/*     */   {
/*     */     try {
/*  99 */       AQDEDataSoapStub _stub = new AQDEDataSoapStub(portAddress, this);
/* 100 */       _stub.setPortName(getAQDEDataSoapWSDDServiceName());
/* 101 */       return _stub;
/*     */     } catch (Exception e) {}
/* 103 */     return null;
/*     */   }
/*     */   
/*     */   public AQDEDataSoap getAQDEDataSoap12() throws ServiceException
/*     */   {
/* 108 */     throw new RuntimeException("Soap12 Not supported");
/*     */   }
/*     */   
/*     */   public AQDEDataSoap getAQDEDataSoap12(URL portAddress) throws ServiceException
/*     */   {
/* 113 */     throw new RuntimeException("Soap12 Not supported");
/*     */   }
/*     */   
/*     */   public Remote getPort(Class serviceEndpointInterface) throws ServiceException
/*     */   {
/*     */     try
/*     */     {
/* 120 */       AQDEDataSoapStub _stub = new AQDEDataSoapStub(new URL("http://134.179.217.247/reporter/AQDEData.asmx"), this);
/*     */       
/*     */ 
/* 123 */       _stub.setPortName(getAQDEDataSoapWSDDServiceName());
/*     */       
/* 125 */       return _stub;
/*     */     }
/*     */     catch (Throwable t) {
/* 128 */       throw new RuntimeException(t);
/*     */     }
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public Remote getPort(QName portName, Class serviceEndpointInterface)
/*     */     throws ServiceException
/*     */   {
/* 140 */     if (portName == null) {
/* 141 */       return getPort(serviceEndpointInterface);
/*     */     }
/* 143 */     String inputPortName = portName.getLocalPart();
/* 144 */     if ("AQDEDataSoap12".equals(inputPortName))
/* 145 */       return getAQDEDataSoap12();
/* 146 */     if ("AQDEDataSoap".equals(inputPortName)) {
/* 147 */       return getAQDEDataSoap();
/*     */     }
/* 149 */     Remote _stub = getPort(serviceEndpointInterface);
/* 150 */     ((Stub)_stub).setPortName(portName);
/* 151 */     return _stub;
/*     */   }
/*     */   
/*     */   public QName getServiceName()
/*     */   {
/* 156 */     return new QName("urn:schemas-drdas-com:reporter.aqde.webservice", "AQDEData");
/*     */   }
/*     */   
/*     */ 
/* 160 */   private HashSet ports = null;
/*     */   
/*     */   public Iterator getPorts() {
/* 163 */     if (this.ports == null) {
/* 164 */       this.ports = new HashSet();
/* 165 */       this.ports.add(new QName("AQDEDataSoap12"));
/* 166 */       this.ports.add(new QName("AQDEDataSoap"));
/*     */     }
/* 168 */     return this.ports.iterator();
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\wsdl\AQDEDataLocator.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */