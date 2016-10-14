
package com.agilairecorp;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlElementDecl;
import javax.xml.bind.annotation.XmlRegistry;
import javax.xml.namespace.QName;
import org.datacontract.schemas._2004._07.airvision_common_services_webservices.AQS3WebServiceArgument;
import org.datacontract.schemas._2004._07.airvision_common_services_webservices.AQSWebServiceArgument;
import org.datacontract.schemas._2004._07.airvision_common_services_webservices.AQSXmlResultData;
import org.datacontract.schemas._2004._07.airvision_common_services_webservices.ArrayOfAQSParameterInformation;


/**
 * This object contains factory methods for each 
 * Java content interface and Java element interface 
 * generated in the com.agilairecorp package. 
 * <p>An ObjectFactory allows you to programatically 
 * construct new instances of the Java representation 
 * for XML content. The Java representation of XML 
 * content can consist of schema derived interfaces 
 * and classes representing the binding of schema 
 * type definitions, element declarations and model 
 * groups.  Factory methods for each of these are 
 * provided in this class.
 * 
 */
@XmlRegistry
public class ObjectFactory {

    private final static QName _GetAQSXmlDataResponseGetAQSXmlDataResult_QNAME = new QName("http://www.agilairecorp.com/", "GetAQSXmlDataResult");
    private final static QName _GetAQS3XmlDataResponseGetAQS3XmlDataResult_QNAME = new QName("http://www.agilairecorp.com/", "GetAQS3XmlDataResult");
    private final static QName _GetAQSXmlDataArgs_QNAME = new QName("http://www.agilairecorp.com/", "args");
    private final static QName _GetAQSParametersResponseGetAQSParametersResult_QNAME = new QName("http://www.agilairecorp.com/", "GetAQSParametersResult");
    private final static QName _GetAQSXmlDataWebResponseGetAQSXmlDataWebResult_QNAME = new QName("http://www.agilairecorp.com/", "GetAQSXmlDataWebResult");
    private final static QName _GetAQSXmlDataWebAqsXmlSchemaVersion_QNAME = new QName("http://www.agilairecorp.com/", "aqsXmlSchemaVersion");

    /**
     * Create a new ObjectFactory that can be used to create new instances of schema derived classes for package: com.agilairecorp
     * 
     */
    public ObjectFactory() {
    }

    /**
     * Create an instance of {@link GetAQSParametersResponse }
     * 
     */
    public GetAQSParametersResponse createGetAQSParametersResponse() {
        return new GetAQSParametersResponse();
    }

    /**
     * Create an instance of {@link GetAQSXmlDataWeb }
     * 
     */
    public GetAQSXmlDataWeb createGetAQSXmlDataWeb() {
        return new GetAQSXmlDataWeb();
    }

    /**
     * Create an instance of {@link GetAQSXmlData }
     * 
     */
    public GetAQSXmlData createGetAQSXmlData() {
        return new GetAQSXmlData();
    }

    /**
     * Create an instance of {@link GetAQSParameters }
     * 
     */
    public GetAQSParameters createGetAQSParameters() {
        return new GetAQSParameters();
    }

    /**
     * Create an instance of {@link GetAQSXmlDataResponse }
     * 
     */
    public GetAQSXmlDataResponse createGetAQSXmlDataResponse() {
        return new GetAQSXmlDataResponse();
    }

    /**
     * Create an instance of {@link GetAQSXmlDataWebResponse }
     * 
     */
    public GetAQSXmlDataWebResponse createGetAQSXmlDataWebResponse() {
        return new GetAQSXmlDataWebResponse();
    }

    /**
     * Create an instance of {@link GetAQS3XmlDataResponse }
     * 
     */
    public GetAQS3XmlDataResponse createGetAQS3XmlDataResponse() {
        return new GetAQS3XmlDataResponse();
    }

    /**
     * Create an instance of {@link GetAQS3XmlData }
     * 
     */
    public GetAQS3XmlData createGetAQS3XmlData() {
        return new GetAQS3XmlData();
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link AQSXmlResultData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.agilairecorp.com/", name = "GetAQSXmlDataResult", scope = GetAQSXmlDataResponse.class)
    public JAXBElement<AQSXmlResultData> createGetAQSXmlDataResponseGetAQSXmlDataResult(AQSXmlResultData value) {
        return new JAXBElement<AQSXmlResultData>(_GetAQSXmlDataResponseGetAQSXmlDataResult_QNAME, AQSXmlResultData.class, GetAQSXmlDataResponse.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link AQSXmlResultData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.agilairecorp.com/", name = "GetAQS3XmlDataResult", scope = GetAQS3XmlDataResponse.class)
    public JAXBElement<AQSXmlResultData> createGetAQS3XmlDataResponseGetAQS3XmlDataResult(AQSXmlResultData value) {
        return new JAXBElement<AQSXmlResultData>(_GetAQS3XmlDataResponseGetAQS3XmlDataResult_QNAME, AQSXmlResultData.class, GetAQS3XmlDataResponse.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link AQSWebServiceArgument }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.agilairecorp.com/", name = "args", scope = GetAQSXmlData.class)
    public JAXBElement<AQSWebServiceArgument> createGetAQSXmlDataArgs(AQSWebServiceArgument value) {
        return new JAXBElement<AQSWebServiceArgument>(_GetAQSXmlDataArgs_QNAME, AQSWebServiceArgument.class, GetAQSXmlData.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfAQSParameterInformation }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.agilairecorp.com/", name = "GetAQSParametersResult", scope = GetAQSParametersResponse.class)
    public JAXBElement<ArrayOfAQSParameterInformation> createGetAQSParametersResponseGetAQSParametersResult(ArrayOfAQSParameterInformation value) {
        return new JAXBElement<ArrayOfAQSParameterInformation>(_GetAQSParametersResponseGetAQSParametersResult_QNAME, ArrayOfAQSParameterInformation.class, GetAQSParametersResponse.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link AQSXmlResultData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.agilairecorp.com/", name = "GetAQSXmlDataWebResult", scope = GetAQSXmlDataWebResponse.class)
    public JAXBElement<AQSXmlResultData> createGetAQSXmlDataWebResponseGetAQSXmlDataWebResult(AQSXmlResultData value) {
        return new JAXBElement<AQSXmlResultData>(_GetAQSXmlDataWebResponseGetAQSXmlDataWebResult_QNAME, AQSXmlResultData.class, GetAQSXmlDataWebResponse.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link AQS3WebServiceArgument }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.agilairecorp.com/", name = "args", scope = GetAQS3XmlData.class)
    public JAXBElement<AQS3WebServiceArgument> createGetAQS3XmlDataArgs(AQS3WebServiceArgument value) {
        return new JAXBElement<AQS3WebServiceArgument>(_GetAQSXmlDataArgs_QNAME, AQS3WebServiceArgument.class, GetAQS3XmlData.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.agilairecorp.com/", name = "aqsXmlSchemaVersion", scope = GetAQSXmlDataWeb.class)
    public JAXBElement<String> createGetAQSXmlDataWebAqsXmlSchemaVersion(String value) {
        return new JAXBElement<String>(_GetAQSXmlDataWebAqsXmlSchemaVersion_QNAME, String.class, GetAQSXmlDataWeb.class, value);
    }

}
