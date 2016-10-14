/*     */ package com.windsor.node.plugin.aqs.agilaire;
/*     */ 
/*     */ import java.math.BigDecimal;
/*     */ import java.math.BigInteger;
/*     */ import javax.xml.bind.JAXBElement;
/*     */ import javax.xml.bind.annotation.XmlElementDecl;
/*     */ import javax.xml.bind.annotation.XmlRegistry;
/*     */ import javax.xml.datatype.Duration;
/*     */ import javax.xml.datatype.XMLGregorianCalendar;
/*     */ import javax.xml.namespace.QName;
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
/*     */ @XmlRegistry
/*     */ public class ObjectFactory
/*     */ {
/*  31 */   private static final QName _GetAQS3XmlDataResponseGetAQS3XmlDataResult_QNAME = new QName("http://www.agilairecorp.com/", "GetAQS3XmlDataResult");
/*  32 */   private static final QName _GetAQSXmlDataWebAqsXmlSchemaVersion_QNAME = new QName("http://www.agilairecorp.com/", "aqsXmlSchemaVersion");
/*  33 */   private static final QName _AnyURI_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "anyURI");
/*  34 */   private static final QName _AQSParameterInformation_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "AQSParameterInformation");
/*  35 */   private static final QName _Char_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "char");
/*  36 */   private static final QName _DateTime_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "dateTime");
/*  37 */   private static final QName _QName_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "QName");
/*  38 */   private static final QName _UnsignedShort_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "unsignedShort");
/*  39 */   private static final QName _Float_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "float");
/*  40 */   private static final QName _ArrayOfAQSParameterInformation_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "ArrayOfAQSParameterInformation");
/*  41 */   private static final QName _Long_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "long");
/*  42 */   private static final QName _Short_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "short");
/*  43 */   private static final QName _Base64Binary_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "base64Binary");
/*  44 */   private static final QName _Byte_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "byte");
/*  45 */   private static final QName _AQS3WebServiceArgument_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "AQS3WebServiceArgument");
/*  46 */   private static final QName _Boolean_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "boolean");
/*  47 */   private static final QName _AQSParameterTag_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "AQSParameterTag");
/*  48 */   private static final QName _UnsignedByte_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "unsignedByte");
/*  49 */   private static final QName _AnyType_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "anyType");
/*  50 */   private static final QName _UnsignedInt_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "unsignedInt");
/*  51 */   private static final QName _Int_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "int");
/*  52 */   private static final QName _Decimal_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "decimal");
/*  53 */   private static final QName _ArrayOfstring_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/Arrays", "ArrayOfstring");
/*  54 */   private static final QName _Double_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "double");
/*  55 */   private static final QName _AQSWebServiceArgument_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "AQSWebServiceArgument");
/*  56 */   private static final QName _Guid_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "guid");
/*  57 */   private static final QName _Duration_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "duration");
/*  58 */   private static final QName _String_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "string");
/*  59 */   private static final QName _ArrayOfAQSParameterTag_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "ArrayOfAQSParameterTag");
/*  60 */   private static final QName _AQSXmlResultData_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "AQSXmlResultData");
/*  61 */   private static final QName _UnsignedLong_QNAME = new QName("http://schemas.microsoft.com/2003/10/Serialization/", "unsignedLong");
/*  62 */   private static final QName _GetAQS3XmlDataArgs_QNAME = new QName("http://www.agilairecorp.com/", "args");
/*  63 */   private static final QName _GetAQSParametersResponseGetAQSParametersResult_QNAME = new QName("http://www.agilairecorp.com/", "GetAQSParametersResult");
/*  64 */   private static final QName _AQSParameterTagCountyTribalCode_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "CountyTribalCode");
/*  65 */   private static final QName _AQSParameterTagStateCode_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "StateCode");
/*  66 */   private static final QName _AQSParameterTagParameterOccurrenceCode_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "ParameterOccurrenceCode");
/*  67 */   private static final QName _AQSParameterTagDurationCode_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "DurationCode");
/*  68 */   private static final QName _AQSParameterInformationSystemName_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "SystemName");
/*  69 */   private static final QName _AQSParameterInformationParameterCode_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "ParameterCode");
/*  70 */   private static final QName _AQSParameterInformationSiteCode_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "SiteCode");
/*  71 */   private static final QName _AQSParameterInformationParameterName_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "ParameterName");
/*  72 */   private static final QName _AQSParameterInformationAgencyCode_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "AgencyCode");
/*  73 */   private static final QName _AQSParameterInformationCountyTribalDescription_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "CountyTribalDescription");
/*  74 */   private static final QName _AQSParameterInformationStateAbbreviation_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "StateAbbreviation");
/*  75 */   private static final QName _AQSParameterInformationSiteName_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "SiteName");
/*  76 */   private static final QName _GetAQSXmlDataResponseGetAQSXmlDataResult_QNAME = new QName("http://www.agilairecorp.com/", "GetAQSXmlDataResult");
/*  77 */   private static final QName _GetAQSXmlDataWebResponseGetAQSXmlDataWebResult_QNAME = new QName("http://www.agilairecorp.com/", "GetAQSXmlDataWebResult");
/*  78 */   private static final QName _AQSXmlResultDataGenerationWarnings_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "GenerationWarnings");
/*  79 */   private static final QName _AQSXmlResultDataZipCompressedAQSXmlDocument_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "ZipCompressedAQSXmlDocument");
/*  80 */   private static final QName _AQSXmlResultDataAQSXmlDocumentText_QNAME = new QName("http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", "AQSXmlDocumentText");
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
/*     */   public AQSXmlResultData createAQSXmlResultData()
/*     */   {
/*  94 */     return new AQSXmlResultData();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public ArrayOfAQSParameterTag createArrayOfAQSParameterTag()
/*     */   {
/* 102 */     return new ArrayOfAQSParameterTag();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public AQS3WebServiceArgument createAQS3WebServiceArgument()
/*     */   {
/* 110 */     return new AQS3WebServiceArgument();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public AQSParameterInformation createAQSParameterInformation()
/*     */   {
/* 118 */     return new AQSParameterInformation();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public AQSParameterTag createAQSParameterTag()
/*     */   {
/* 126 */     return new AQSParameterTag();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public AQSWebServiceArgument createAQSWebServiceArgument()
/*     */   {
/* 134 */     return new AQSWebServiceArgument();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public ArrayOfAQSParameterInformation createArrayOfAQSParameterInformation()
/*     */   {
/* 142 */     return new ArrayOfAQSParameterInformation();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public ArrayOfstring createArrayOfstring()
/*     */   {
/* 150 */     return new ArrayOfstring();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public GetAQS3XmlData createGetAQS3XmlData()
/*     */   {
/* 158 */     return new GetAQS3XmlData();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public GetAQSParameters createGetAQSParameters()
/*     */   {
/* 166 */     return new GetAQSParameters();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public GetAQSXmlDataResponse createGetAQSXmlDataResponse()
/*     */   {
/* 174 */     return new GetAQSXmlDataResponse();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public GetAQSXmlDataWebResponse createGetAQSXmlDataWebResponse()
/*     */   {
/* 182 */     return new GetAQSXmlDataWebResponse();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public GetAQSParametersResponse createGetAQSParametersResponse()
/*     */   {
/* 190 */     return new GetAQSParametersResponse();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public GetAQSXmlDataWeb createGetAQSXmlDataWeb()
/*     */   {
/* 198 */     return new GetAQSXmlDataWeb();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public GetAQS3XmlDataResponse createGetAQS3XmlDataResponse()
/*     */   {
/* 206 */     return new GetAQS3XmlDataResponse();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public GetAQSXmlData createGetAQSXmlData()
/*     */   {
/* 214 */     return new GetAQSXmlData();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.agilairecorp.com/", name="GetAQS3XmlDataResult", scope=GetAQS3XmlDataResponse.class)
/*     */   public JAXBElement<AQSXmlResultData> createGetAQS3XmlDataResponseGetAQS3XmlDataResult(AQSXmlResultData value)
/*     */   {
/* 223 */     return new JAXBElement(_GetAQS3XmlDataResponseGetAQS3XmlDataResult_QNAME, AQSXmlResultData.class, GetAQS3XmlDataResponse.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.agilairecorp.com/", name="aqsXmlSchemaVersion", scope=GetAQSXmlDataWeb.class)
/*     */   public JAXBElement<String> createGetAQSXmlDataWebAqsXmlSchemaVersion(String value)
/*     */   {
/* 232 */     return new JAXBElement(_GetAQSXmlDataWebAqsXmlSchemaVersion_QNAME, String.class, GetAQSXmlDataWeb.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="anyURI")
/*     */   public JAXBElement<String> createAnyURI(String value)
/*     */   {
/* 241 */     return new JAXBElement(_AnyURI_QNAME, String.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="AQSParameterInformation")
/*     */   public JAXBElement<AQSParameterInformation> createAQSParameterInformation(AQSParameterInformation value)
/*     */   {
/* 250 */     return new JAXBElement(_AQSParameterInformation_QNAME, AQSParameterInformation.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="char")
/*     */   public JAXBElement<Integer> createChar(Integer value)
/*     */   {
/* 259 */     return new JAXBElement(_Char_QNAME, Integer.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="dateTime")
/*     */   public JAXBElement<XMLGregorianCalendar> createDateTime(XMLGregorianCalendar value)
/*     */   {
/* 268 */     return new JAXBElement(_DateTime_QNAME, XMLGregorianCalendar.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="QName")
/*     */   public JAXBElement<QName> createQName(QName value)
/*     */   {
/* 277 */     return new JAXBElement(_QName_QNAME, QName.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="unsignedShort")
/*     */   public JAXBElement<Integer> createUnsignedShort(Integer value)
/*     */   {
/* 286 */     return new JAXBElement(_UnsignedShort_QNAME, Integer.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="float")
/*     */   public JAXBElement<Float> createFloat(Float value)
/*     */   {
/* 295 */     return new JAXBElement(_Float_QNAME, Float.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="ArrayOfAQSParameterInformation")
/*     */   public JAXBElement<ArrayOfAQSParameterInformation> createArrayOfAQSParameterInformation(ArrayOfAQSParameterInformation value)
/*     */   {
/* 304 */     return new JAXBElement(_ArrayOfAQSParameterInformation_QNAME, ArrayOfAQSParameterInformation.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="long")
/*     */   public JAXBElement<Long> createLong(Long value)
/*     */   {
/* 313 */     return new JAXBElement(_Long_QNAME, Long.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="short")
/*     */   public JAXBElement<Short> createShort(Short value)
/*     */   {
/* 322 */     return new JAXBElement(_Short_QNAME, Short.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="base64Binary")
/*     */   public JAXBElement<byte[]> createBase64Binary(byte[] value)
/*     */   {
/* 331 */     return new JAXBElement(_Base64Binary_QNAME, byte[].class, null, (byte[])value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="byte")
/*     */   public JAXBElement<Byte> createByte(Byte value)
/*     */   {
/* 340 */     return new JAXBElement(_Byte_QNAME, Byte.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="AQS3WebServiceArgument")
/*     */   public JAXBElement<AQS3WebServiceArgument> createAQS3WebServiceArgument(AQS3WebServiceArgument value)
/*     */   {
/* 349 */     return new JAXBElement(_AQS3WebServiceArgument_QNAME, AQS3WebServiceArgument.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="boolean")
/*     */   public JAXBElement<Boolean> createBoolean(Boolean value)
/*     */   {
/* 358 */     return new JAXBElement(_Boolean_QNAME, Boolean.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="AQSParameterTag")
/*     */   public JAXBElement<AQSParameterTag> createAQSParameterTag(AQSParameterTag value)
/*     */   {
/* 367 */     return new JAXBElement(_AQSParameterTag_QNAME, AQSParameterTag.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="unsignedByte")
/*     */   public JAXBElement<Short> createUnsignedByte(Short value)
/*     */   {
/* 376 */     return new JAXBElement(_UnsignedByte_QNAME, Short.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="anyType")
/*     */   public JAXBElement<Object> createAnyType(Object value)
/*     */   {
/* 385 */     return new JAXBElement(_AnyType_QNAME, Object.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="unsignedInt")
/*     */   public JAXBElement<Long> createUnsignedInt(Long value)
/*     */   {
/* 394 */     return new JAXBElement(_UnsignedInt_QNAME, Long.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="int")
/*     */   public JAXBElement<Integer> createInt(Integer value)
/*     */   {
/* 403 */     return new JAXBElement(_Int_QNAME, Integer.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="decimal")
/*     */   public JAXBElement<BigDecimal> createDecimal(BigDecimal value)
/*     */   {
/* 412 */     return new JAXBElement(_Decimal_QNAME, BigDecimal.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/Arrays", name="ArrayOfstring")
/*     */   public JAXBElement<ArrayOfstring> createArrayOfstring(ArrayOfstring value)
/*     */   {
/* 421 */     return new JAXBElement(_ArrayOfstring_QNAME, ArrayOfstring.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="double")
/*     */   public JAXBElement<Double> createDouble(Double value)
/*     */   {
/* 430 */     return new JAXBElement(_Double_QNAME, Double.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="AQSWebServiceArgument")
/*     */   public JAXBElement<AQSWebServiceArgument> createAQSWebServiceArgument(AQSWebServiceArgument value)
/*     */   {
/* 439 */     return new JAXBElement(_AQSWebServiceArgument_QNAME, AQSWebServiceArgument.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="guid")
/*     */   public JAXBElement<String> createGuid(String value)
/*     */   {
/* 448 */     return new JAXBElement(_Guid_QNAME, String.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="duration")
/*     */   public JAXBElement<Duration> createDuration(Duration value)
/*     */   {
/* 457 */     return new JAXBElement(_Duration_QNAME, Duration.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="string")
/*     */   public JAXBElement<String> createString(String value)
/*     */   {
/* 466 */     return new JAXBElement(_String_QNAME, String.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="ArrayOfAQSParameterTag")
/*     */   public JAXBElement<ArrayOfAQSParameterTag> createArrayOfAQSParameterTag(ArrayOfAQSParameterTag value)
/*     */   {
/* 475 */     return new JAXBElement(_ArrayOfAQSParameterTag_QNAME, ArrayOfAQSParameterTag.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="AQSXmlResultData")
/*     */   public JAXBElement<AQSXmlResultData> createAQSXmlResultData(AQSXmlResultData value)
/*     */   {
/* 484 */     return new JAXBElement(_AQSXmlResultData_QNAME, AQSXmlResultData.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.microsoft.com/2003/10/Serialization/", name="unsignedLong")
/*     */   public JAXBElement<BigInteger> createUnsignedLong(BigInteger value)
/*     */   {
/* 493 */     return new JAXBElement(_UnsignedLong_QNAME, BigInteger.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.agilairecorp.com/", name="args", scope=GetAQS3XmlData.class)
/*     */   public JAXBElement<AQS3WebServiceArgument> createGetAQS3XmlDataArgs(AQS3WebServiceArgument value)
/*     */   {
/* 502 */     return new JAXBElement(_GetAQS3XmlDataArgs_QNAME, AQS3WebServiceArgument.class, GetAQS3XmlData.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.agilairecorp.com/", name="GetAQSParametersResult", scope=GetAQSParametersResponse.class)
/*     */   public JAXBElement<ArrayOfAQSParameterInformation> createGetAQSParametersResponseGetAQSParametersResult(ArrayOfAQSParameterInformation value)
/*     */   {
/* 511 */     return new JAXBElement(_GetAQSParametersResponseGetAQSParametersResult_QNAME, ArrayOfAQSParameterInformation.class, GetAQSParametersResponse.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="CountyTribalCode", scope=AQSParameterTag.class)
/*     */   public JAXBElement<String> createAQSParameterTagCountyTribalCode(String value)
/*     */   {
/* 520 */     return new JAXBElement(_AQSParameterTagCountyTribalCode_QNAME, String.class, AQSParameterTag.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="StateCode", scope=AQSParameterTag.class)
/*     */   public JAXBElement<String> createAQSParameterTagStateCode(String value)
/*     */   {
/* 529 */     return new JAXBElement(_AQSParameterTagStateCode_QNAME, String.class, AQSParameterTag.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="ParameterOccurrenceCode", scope=AQSParameterTag.class)
/*     */   public JAXBElement<Integer> createAQSParameterTagParameterOccurrenceCode(Integer value)
/*     */   {
/* 538 */     return new JAXBElement(_AQSParameterTagParameterOccurrenceCode_QNAME, Integer.class, AQSParameterTag.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="DurationCode", scope=AQSParameterTag.class)
/*     */   public JAXBElement<String> createAQSParameterTagDurationCode(String value)
/*     */   {
/* 547 */     return new JAXBElement(_AQSParameterTagDurationCode_QNAME, String.class, AQSParameterTag.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.agilairecorp.com/", name="args", scope=GetAQSXmlData.class)
/*     */   public JAXBElement<AQSWebServiceArgument> createGetAQSXmlDataArgs(AQSWebServiceArgument value)
/*     */   {
/* 556 */     return new JAXBElement(_GetAQS3XmlDataArgs_QNAME, AQSWebServiceArgument.class, GetAQSXmlData.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="SystemName", scope=AQSParameterInformation.class)
/*     */   public JAXBElement<String> createAQSParameterInformationSystemName(String value)
/*     */   {
/* 565 */     return new JAXBElement(_AQSParameterInformationSystemName_QNAME, String.class, AQSParameterInformation.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="ParameterCode", scope=AQSParameterInformation.class)
/*     */   public JAXBElement<String> createAQSParameterInformationParameterCode(String value)
/*     */   {
/* 574 */     return new JAXBElement(_AQSParameterInformationParameterCode_QNAME, String.class, AQSParameterInformation.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="SiteCode", scope=AQSParameterInformation.class)
/*     */   public JAXBElement<String> createAQSParameterInformationSiteCode(String value)
/*     */   {
/* 583 */     return new JAXBElement(_AQSParameterInformationSiteCode_QNAME, String.class, AQSParameterInformation.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="CountyTribalCode", scope=AQSParameterInformation.class)
/*     */   public JAXBElement<String> createAQSParameterInformationCountyTribalCode(String value)
/*     */   {
/* 592 */     return new JAXBElement(_AQSParameterTagCountyTribalCode_QNAME, String.class, AQSParameterInformation.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="StateCode", scope=AQSParameterInformation.class)
/*     */   public JAXBElement<String> createAQSParameterInformationStateCode(String value)
/*     */   {
/* 601 */     return new JAXBElement(_AQSParameterTagStateCode_QNAME, String.class, AQSParameterInformation.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="ParameterName", scope=AQSParameterInformation.class)
/*     */   public JAXBElement<String> createAQSParameterInformationParameterName(String value)
/*     */   {
/* 610 */     return new JAXBElement(_AQSParameterInformationParameterName_QNAME, String.class, AQSParameterInformation.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="AgencyCode", scope=AQSParameterInformation.class)
/*     */   public JAXBElement<String> createAQSParameterInformationAgencyCode(String value)
/*     */   {
/* 619 */     return new JAXBElement(_AQSParameterInformationAgencyCode_QNAME, String.class, AQSParameterInformation.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="ParameterOccurrenceCode", scope=AQSParameterInformation.class)
/*     */   public JAXBElement<Integer> createAQSParameterInformationParameterOccurrenceCode(Integer value)
/*     */   {
/* 628 */     return new JAXBElement(_AQSParameterTagParameterOccurrenceCode_QNAME, Integer.class, AQSParameterInformation.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="CountyTribalDescription", scope=AQSParameterInformation.class)
/*     */   public JAXBElement<String> createAQSParameterInformationCountyTribalDescription(String value)
/*     */   {
/* 637 */     return new JAXBElement(_AQSParameterInformationCountyTribalDescription_QNAME, String.class, AQSParameterInformation.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="StateAbbreviation", scope=AQSParameterInformation.class)
/*     */   public JAXBElement<String> createAQSParameterInformationStateAbbreviation(String value)
/*     */   {
/* 646 */     return new JAXBElement(_AQSParameterInformationStateAbbreviation_QNAME, String.class, AQSParameterInformation.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="SiteName", scope=AQSParameterInformation.class)
/*     */   public JAXBElement<String> createAQSParameterInformationSiteName(String value)
/*     */   {
/* 655 */     return new JAXBElement(_AQSParameterInformationSiteName_QNAME, String.class, AQSParameterInformation.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.agilairecorp.com/", name="GetAQSXmlDataResult", scope=GetAQSXmlDataResponse.class)
/*     */   public JAXBElement<AQSXmlResultData> createGetAQSXmlDataResponseGetAQSXmlDataResult(AQSXmlResultData value)
/*     */   {
/* 664 */     return new JAXBElement(_GetAQSXmlDataResponseGetAQSXmlDataResult_QNAME, AQSXmlResultData.class, GetAQSXmlDataResponse.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.agilairecorp.com/", name="GetAQSXmlDataWebResult", scope=GetAQSXmlDataWebResponse.class)
/*     */   public JAXBElement<AQSXmlResultData> createGetAQSXmlDataWebResponseGetAQSXmlDataWebResult(AQSXmlResultData value)
/*     */   {
/* 673 */     return new JAXBElement(_GetAQSXmlDataWebResponseGetAQSXmlDataWebResult_QNAME, AQSXmlResultData.class, GetAQSXmlDataWebResponse.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="GenerationWarnings", scope=AQSXmlResultData.class)
/*     */   public JAXBElement<ArrayOfstring> createAQSXmlResultDataGenerationWarnings(ArrayOfstring value)
/*     */   {
/* 682 */     return new JAXBElement(_AQSXmlResultDataGenerationWarnings_QNAME, ArrayOfstring.class, AQSXmlResultData.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="ZipCompressedAQSXmlDocument", scope=AQSXmlResultData.class)
/*     */   public JAXBElement<byte[]> createAQSXmlResultDataZipCompressedAQSXmlDocument(byte[] value)
/*     */   {
/* 691 */     return new JAXBElement(_AQSXmlResultDataZipCompressedAQSXmlDocument_QNAME, byte[].class, AQSXmlResultData.class, (byte[])value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://schemas.datacontract.org/2004/07/AirVision.Common.Services.WebServices.AQSXmlService", name="AQSXmlDocumentText", scope=AQSXmlResultData.class)
/*     */   public JAXBElement<String> createAQSXmlResultDataAQSXmlDocumentText(String value)
/*     */   {
/* 700 */     return new JAXBElement(_AQSXmlResultDataAQSXmlDocumentText_QNAME, String.class, AQSXmlResultData.class, value);
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\agilaire\ObjectFactory.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */