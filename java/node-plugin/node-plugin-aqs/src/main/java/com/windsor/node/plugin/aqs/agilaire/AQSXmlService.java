package com.windsor.node.plugin.aqs.agilaire;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebResult;
import javax.jws.WebService;
import javax.xml.datatype.XMLGregorianCalendar;
import javax.xml.ws.Action;
import javax.xml.ws.RequestWrapper;
import javax.xml.ws.ResponseWrapper;

@WebService(targetNamespace="http://www.agilairecorp.com/", name="AQSXmlService")
public abstract interface AQSXmlService
{
  @WebResult(name="GetAQS3XmlDataResult", targetNamespace="http://www.agilairecorp.com/")
  @Action(input="http://www.agilairecorp.com/AQSXmlService/GetAQS3XmlData", output="http://www.agilairecorp.com/AQSXmlService/GetAQS3XmlDataResponse")
  @RequestWrapper(localName="GetAQS3XmlData", targetNamespace="http://www.agilairecorp.com/", className="com.windsor.node.plugin.aqs.agilaire.GetAQS3XmlData")
  @WebMethod(operationName="GetAQS3XmlData", action="http://www.agilairecorp.com/AQSXmlService/GetAQS3XmlData")
  @ResponseWrapper(localName="GetAQS3XmlDataResponse", targetNamespace="http://www.agilairecorp.com/", className="com.windsor.node.plugin.aqs.agilaire.GetAQS3XmlDataResponse")
  public abstract AQSXmlResultData getAQS3XmlData(@WebParam(name="args", targetNamespace="http://www.agilairecorp.com/") AQS3WebServiceArgument paramAQS3WebServiceArgument);
  
  @WebResult(name="GetAQSXmlDataResult", targetNamespace="http://www.agilairecorp.com/")
  @Action(input="http://www.agilairecorp.com/AQSXmlService/GetAQSXmlData", output="http://www.agilairecorp.com/AQSXmlService/GetAQSXmlDataResponse")
  @RequestWrapper(localName="GetAQSXmlData", targetNamespace="http://www.agilairecorp.com/", className="com.windsor.node.plugin.aqs.agilaire.GetAQSXmlData")
  @WebMethod(operationName="GetAQSXmlData", action="http://www.agilairecorp.com/AQSXmlService/GetAQSXmlData")
  @ResponseWrapper(localName="GetAQSXmlDataResponse", targetNamespace="http://www.agilairecorp.com/", className="com.windsor.node.plugin.aqs.agilaire.GetAQSXmlDataResponse")
  public abstract AQSXmlResultData getAQSXmlData(@WebParam(name="args", targetNamespace="http://www.agilairecorp.com/") AQSWebServiceArgument paramAQSWebServiceArgument);
  
  @WebResult(name="GetAQSXmlDataWebResult", targetNamespace="http://www.agilairecorp.com/")
  @Action(input="http://www.agilairecorp.com/AQSXmlService/GetAQSXmlDataWeb", output="http://www.agilairecorp.com/AQSXmlService/GetAQSXmlDataWebResponse")
  @RequestWrapper(localName="GetAQSXmlDataWeb", targetNamespace="http://www.agilairecorp.com/", className="com.windsor.node.plugin.aqs.agilaire.GetAQSXmlDataWeb")
  @WebMethod(operationName="GetAQSXmlDataWeb", action="http://www.agilairecorp.com/AQSXmlService/GetAQSXmlDataWeb")
  @ResponseWrapper(localName="GetAQSXmlDataWebResponse", targetNamespace="http://www.agilairecorp.com/", className="com.windsor.node.plugin.aqs.agilaire.GetAQSXmlDataWebResponse")
  public abstract AQSXmlResultData getAQSXmlDataWeb(@WebParam(name="startTime", targetNamespace="http://www.agilairecorp.com/") XMLGregorianCalendar paramXMLGregorianCalendar1, @WebParam(name="endTime", targetNamespace="http://www.agilairecorp.com/") XMLGregorianCalendar paramXMLGregorianCalendar2, @WebParam(name="aqsXmlSchemaVersion", targetNamespace="http://www.agilairecorp.com/") String paramString, @WebParam(name="sendRdTransactions", targetNamespace="http://www.agilairecorp.com/") Boolean paramBoolean1, @WebParam(name="sendRbTransactions", targetNamespace="http://www.agilairecorp.com/") Boolean paramBoolean2, @WebParam(name="sendRaTransactions", targetNamespace="http://www.agilairecorp.com/") Boolean paramBoolean3, @WebParam(name="sendRpTransactions", targetNamespace="http://www.agilairecorp.com/") Boolean paramBoolean4, @WebParam(name="sendOnlyQaData", targetNamespace="http://www.agilairecorp.com/") Boolean paramBoolean5);
  
  @WebResult(name="GetAQSParametersResult", targetNamespace="http://www.agilairecorp.com/")
  @Action(input="http://www.agilairecorp.com/AQSXmlService/GetAQSParameters", output="http://www.agilairecorp.com/AQSXmlService/GetAQSParametersResponse")
  @RequestWrapper(localName="GetAQSParameters", targetNamespace="http://www.agilairecorp.com/", className="com.windsor.node.plugin.aqs.agilaire.GetAQSParameters")
  @WebMethod(operationName="GetAQSParameters", action="http://www.agilairecorp.com/AQSXmlService/GetAQSParameters")
  @ResponseWrapper(localName="GetAQSParametersResponse", targetNamespace="http://www.agilairecorp.com/", className="com.windsor.node.plugin.aqs.agilaire.GetAQSParametersResponse")
  public abstract ArrayOfAQSParameterInformation getAQSParameters();
}


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\agilaire\AQSXmlService.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */