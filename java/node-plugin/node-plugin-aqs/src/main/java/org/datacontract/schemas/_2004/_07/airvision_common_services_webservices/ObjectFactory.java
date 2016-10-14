
package org.datacontract.schemas._2004._07.airvision_common_services_webservices;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlElementDecl;
import javax.xml.bind.annotation.XmlRegistry;
import javax.xml.namespace.QName;
import com.microsoft.schemas._2003._10.serialization.arrays.ArrayOfstring;


/**
 * This object contains factory methods for each 
 * Java content interface and Java element interface 
 * generated in the org.datacontract.schemas._2004._07.airvision_common_services_webservices package. 
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

    private final static QName _ArrayOfAQSParameterTag_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "ArrayOfAQSParameterTag");
    private final static QName _AQSXmlResultData_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "AQSXmlResultData");
    private final static QName _AQSWebServiceArgument_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "AQSWebServiceArgument");
    private final static QName _AQS3WebServiceArgument_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "AQS3WebServiceArgument");
    private final static QName _ArrayOfAQSParameterInformation_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "ArrayOfAQSParameterInformation");
    private final static QName _AQSParameterTag_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "AQSParameterTag");
    private final static QName _AQSParameterInformation_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "AQSParameterInformation");
    private final static QName _AQSParameterInformationParameterOccurrenceCode_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "ParameterOccurrenceCode");
    private final static QName _AQSParameterInformationStateAbbreviation_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "StateAbbreviation");
    private final static QName _AQSParameterInformationCountyTribalCode_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "CountyTribalCode");
    private final static QName _AQSParameterInformationSiteName_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "SiteName");
    private final static QName _AQSParameterInformationSiteCode_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "SiteCode");
    private final static QName _AQSParameterInformationParameterName_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "ParameterName");
    private final static QName _AQSParameterInformationSystemName_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "SystemName");
    private final static QName _AQSParameterInformationStateCode_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "StateCode");
    private final static QName _AQSParameterInformationAgencyCode_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "AgencyCode");
    private final static QName _AQSParameterInformationCountyTribalDescription_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "CountyTribalDescription");
    private final static QName _AQSParameterInformationParameterCode_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "ParameterCode");
    private final static QName _AQSParameterTagDurationCode_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "DurationCode");
    private final static QName _AQSXmlResultDataGenerationWarnings_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "GenerationWarnings");
    private final static QName _AQSXmlResultDataZipCompressedAQSXmlDocument_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "ZipCompressedAQSXmlDocument");
    private final static QName _AQSXmlResultDataAQSXmlDocumentText_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "AQSXmlDocumentText");

    /**
     * Create a new ObjectFactory that can be used to create new instances of schema derived classes for package: org.datacontract.schemas._2004._07.airvision_common_services_webservices
     * 
     */
    public ObjectFactory() {
    }

    /**
     * Create an instance of {@link ArrayOfAQSParameterInformation }
     * 
     */
    public ArrayOfAQSParameterInformation createArrayOfAQSParameterInformation() {
        return new ArrayOfAQSParameterInformation();
    }

    /**
     * Create an instance of {@link AQSWebServiceArgument }
     * 
     */
    public AQSWebServiceArgument createAQSWebServiceArgument() {
        return new AQSWebServiceArgument();
    }

    /**
     * Create an instance of {@link AQSXmlResultData }
     * 
     */
    public AQSXmlResultData createAQSXmlResultData() {
        return new AQSXmlResultData();
    }

    /**
     * Create an instance of {@link AQS3WebServiceArgument }
     * 
     */
    public AQS3WebServiceArgument createAQS3WebServiceArgument() {
        return new AQS3WebServiceArgument();
    }

    /**
     * Create an instance of {@link ArrayOfAQSParameterTag }
     * 
     */
    public ArrayOfAQSParameterTag createArrayOfAQSParameterTag() {
        return new ArrayOfAQSParameterTag();
    }

    /**
     * Create an instance of {@link AQSParameterTag }
     * 
     */
    public AQSParameterTag createAQSParameterTag() {
        return new AQSParameterTag();
    }

    /**
     * Create an instance of {@link AQSParameterInformation }
     * 
     */
    public AQSParameterInformation createAQSParameterInformation() {
        return new AQSParameterInformation();
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfAQSParameterTag }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "ArrayOfAQSParameterTag")
    public JAXBElement<ArrayOfAQSParameterTag> createArrayOfAQSParameterTag(ArrayOfAQSParameterTag value) {
        return new JAXBElement<ArrayOfAQSParameterTag>(_ArrayOfAQSParameterTag_QNAME, ArrayOfAQSParameterTag.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link AQSXmlResultData }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "AQSXmlResultData")
    public JAXBElement<AQSXmlResultData> createAQSXmlResultData(AQSXmlResultData value) {
        return new JAXBElement<AQSXmlResultData>(_AQSXmlResultData_QNAME, AQSXmlResultData.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link AQSWebServiceArgument }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "AQSWebServiceArgument")
    public JAXBElement<AQSWebServiceArgument> createAQSWebServiceArgument(AQSWebServiceArgument value) {
        return new JAXBElement<AQSWebServiceArgument>(_AQSWebServiceArgument_QNAME, AQSWebServiceArgument.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link AQS3WebServiceArgument }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "AQS3WebServiceArgument")
    public JAXBElement<AQS3WebServiceArgument> createAQS3WebServiceArgument(AQS3WebServiceArgument value) {
        return new JAXBElement<AQS3WebServiceArgument>(_AQS3WebServiceArgument_QNAME, AQS3WebServiceArgument.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfAQSParameterInformation }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "ArrayOfAQSParameterInformation")
    public JAXBElement<ArrayOfAQSParameterInformation> createArrayOfAQSParameterInformation(ArrayOfAQSParameterInformation value) {
        return new JAXBElement<ArrayOfAQSParameterInformation>(_ArrayOfAQSParameterInformation_QNAME, ArrayOfAQSParameterInformation.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link AQSParameterTag }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "AQSParameterTag")
    public JAXBElement<AQSParameterTag> createAQSParameterTag(AQSParameterTag value) {
        return new JAXBElement<AQSParameterTag>(_AQSParameterTag_QNAME, AQSParameterTag.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link AQSParameterInformation }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "AQSParameterInformation")
    public JAXBElement<AQSParameterInformation> createAQSParameterInformation(AQSParameterInformation value) {
        return new JAXBElement<AQSParameterInformation>(_AQSParameterInformation_QNAME, AQSParameterInformation.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Integer }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "ParameterOccurrenceCode", scope = AQSParameterInformation.class)
    public JAXBElement<Integer> createAQSParameterInformationParameterOccurrenceCode(Integer value) {
        return new JAXBElement<Integer>(_AQSParameterInformationParameterOccurrenceCode_QNAME, Integer.class, AQSParameterInformation.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "StateAbbreviation", scope = AQSParameterInformation.class)
    public JAXBElement<String> createAQSParameterInformationStateAbbreviation(String value) {
        return new JAXBElement<String>(_AQSParameterInformationStateAbbreviation_QNAME, String.class, AQSParameterInformation.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "CountyTribalCode", scope = AQSParameterInformation.class)
    public JAXBElement<String> createAQSParameterInformationCountyTribalCode(String value) {
        return new JAXBElement<String>(_AQSParameterInformationCountyTribalCode_QNAME, String.class, AQSParameterInformation.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "SiteName", scope = AQSParameterInformation.class)
    public JAXBElement<String> createAQSParameterInformationSiteName(String value) {
        return new JAXBElement<String>(_AQSParameterInformationSiteName_QNAME, String.class, AQSParameterInformation.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "SiteCode", scope = AQSParameterInformation.class)
    public JAXBElement<String> createAQSParameterInformationSiteCode(String value) {
        return new JAXBElement<String>(_AQSParameterInformationSiteCode_QNAME, String.class, AQSParameterInformation.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "ParameterName", scope = AQSParameterInformation.class)
    public JAXBElement<String> createAQSParameterInformationParameterName(String value) {
        return new JAXBElement<String>(_AQSParameterInformationParameterName_QNAME, String.class, AQSParameterInformation.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "SystemName", scope = AQSParameterInformation.class)
    public JAXBElement<String> createAQSParameterInformationSystemName(String value) {
        return new JAXBElement<String>(_AQSParameterInformationSystemName_QNAME, String.class, AQSParameterInformation.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "StateCode", scope = AQSParameterInformation.class)
    public JAXBElement<String> createAQSParameterInformationStateCode(String value) {
        return new JAXBElement<String>(_AQSParameterInformationStateCode_QNAME, String.class, AQSParameterInformation.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "AgencyCode", scope = AQSParameterInformation.class)
    public JAXBElement<String> createAQSParameterInformationAgencyCode(String value) {
        return new JAXBElement<String>(_AQSParameterInformationAgencyCode_QNAME, String.class, AQSParameterInformation.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "CountyTribalDescription", scope = AQSParameterInformation.class)
    public JAXBElement<String> createAQSParameterInformationCountyTribalDescription(String value) {
        return new JAXBElement<String>(_AQSParameterInformationCountyTribalDescription_QNAME, String.class, AQSParameterInformation.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "ParameterCode", scope = AQSParameterInformation.class)
    public JAXBElement<String> createAQSParameterInformationParameterCode(String value) {
        return new JAXBElement<String>(_AQSParameterInformationParameterCode_QNAME, String.class, AQSParameterInformation.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Integer }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "ParameterOccurrenceCode", scope = AQSParameterTag.class)
    public JAXBElement<Integer> createAQSParameterTagParameterOccurrenceCode(Integer value) {
        return new JAXBElement<Integer>(_AQSParameterInformationParameterOccurrenceCode_QNAME, Integer.class, AQSParameterTag.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "CountyTribalCode", scope = AQSParameterTag.class)
    public JAXBElement<String> createAQSParameterTagCountyTribalCode(String value) {
        return new JAXBElement<String>(_AQSParameterInformationCountyTribalCode_QNAME, String.class, AQSParameterTag.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "DurationCode", scope = AQSParameterTag.class)
    public JAXBElement<String> createAQSParameterTagDurationCode(String value) {
        return new JAXBElement<String>(_AQSParameterTagDurationCode_QNAME, String.class, AQSParameterTag.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "StateCode", scope = AQSParameterTag.class)
    public JAXBElement<String> createAQSParameterTagStateCode(String value) {
        return new JAXBElement<String>(_AQSParameterInformationStateCode_QNAME, String.class, AQSParameterTag.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ArrayOfstring }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "GenerationWarnings", scope = AQSXmlResultData.class)
    public JAXBElement<ArrayOfstring> createAQSXmlResultDataGenerationWarnings(ArrayOfstring value) {
        return new JAXBElement<ArrayOfstring>(_AQSXmlResultDataGenerationWarnings_QNAME, ArrayOfstring.class, AQSXmlResultData.class, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link byte[]}{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "ZipCompressedAQSXmlDocument", scope = AQSXmlResultData.class)
    public JAXBElement<byte[]> createAQSXmlResultDataZipCompressedAQSXmlDocument(byte[] value) {
        return new JAXBElement<byte[]>(_AQSXmlResultDataZipCompressedAQSXmlDocument_QNAME, byte[].class, AQSXmlResultData.class, ((byte[]) value));
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name = "AQSXmlDocumentText", scope = AQSXmlResultData.class)
    public JAXBElement<String> createAQSXmlResultDataAQSXmlDocumentText(String value) {
        return new JAXBElement<String>(_AQSXmlResultDataAQSXmlDocumentText_QNAME, String.class, AQSXmlResultData.class, value);
    }

}
