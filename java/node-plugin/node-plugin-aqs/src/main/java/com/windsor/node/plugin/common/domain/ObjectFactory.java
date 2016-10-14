/*     */ package com.windsor.node.plugin.common.domain;
/*     */ 
/*     */ import java.math.BigInteger;
/*     */ import javax.xml.bind.JAXBElement;
/*     */ import javax.xml.bind.annotation.XmlElementDecl;
/*     */ import javax.xml.bind.annotation.XmlRegistry;
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
/*  36 */   private static final QName _Signature_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "Signature");
/*  37 */   private static final QName _PGPData_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "PGPData");
/*  38 */   private static final QName _DSAKeyValue_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "DSAKeyValue");
/*  39 */   private static final QName _SPKIData_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "SPKIData");
/*  40 */   private static final QName _SignedInfo_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "SignedInfo");
/*  41 */   private static final QName _RetrievalMethod_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "RetrievalMethod");
/*  42 */   private static final QName _CanonicalizationMethod_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "CanonicalizationMethod");
/*  43 */   private static final QName _Object_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "Object");
/*  44 */   private static final QName _SignatureProperty_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "SignatureProperty");
/*  45 */   private static final QName _Manifest_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "Manifest");
/*  46 */   private static final QName _SignatureValue_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "SignatureValue");
/*  47 */   private static final QName _Transforms_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "Transforms");
/*  48 */   private static final QName _Transform_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "Transform");
/*  49 */   private static final QName _X509Data_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "X509Data");
/*  50 */   private static final QName _SignatureMethod_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "SignatureMethod");
/*  51 */   private static final QName _KeyInfo_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "KeyInfo");
/*  52 */   private static final QName _DigestValue_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "DigestValue");
/*  53 */   private static final QName _DigestMethod_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "DigestMethod");
/*  54 */   private static final QName _Document_QNAME = new QName("http://www.exchangenetwork.net/schema/header/2", "Document");
/*  55 */   private static final QName _SignatureProperties_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "SignatureProperties");
/*  56 */   private static final QName _MgmtData_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "MgmtData");
/*  57 */   private static final QName _KeyName_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "KeyName");
/*  58 */   private static final QName _KeyValue_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "KeyValue");
/*  59 */   private static final QName _Reference_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "Reference");
/*  60 */   private static final QName _RSAKeyValue_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "RSAKeyValue");
/*  61 */   private static final QName _SignatureMethodTypeHMACOutputLength_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "HMACOutputLength");
/*  62 */   private static final QName _SPKIDataTypeSPKISexp_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "SPKISexp");
/*  63 */   private static final QName _X509DataTypeX509IssuerSerial_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "X509IssuerSerial");
/*  64 */   private static final QName _X509DataTypeX509Certificate_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "X509Certificate");
/*  65 */   private static final QName _X509DataTypeX509SKI_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "X509SKI");
/*  66 */   private static final QName _X509DataTypeX509SubjectName_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "X509SubjectName");
/*  67 */   private static final QName _X509DataTypeX509CRL_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "X509CRL");
/*  68 */   private static final QName _PGPDataTypePGPKeyID_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "PGPKeyID");
/*  69 */   private static final QName _PGPDataTypePGPKeyPacket_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "PGPKeyPacket");
/*  70 */   private static final QName _TransformTypeXPath_QNAME = new QName("http://www.w3.org/2000/09/xmldsig#", "XPath");
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
/*     */   public SignaturePropertyType createSignaturePropertyType()
/*     */   {
/*  84 */     return new SignaturePropertyType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public X509IssuerSerialType createX509IssuerSerialType()
/*     */   {
/*  92 */     return new X509IssuerSerialType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public SignatureType createSignatureType()
/*     */   {
/* 100 */     return new SignatureType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public DSAKeyValueType createDSAKeyValueType()
/*     */   {
/* 108 */     return new DSAKeyValueType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public DigestMethodType createDigestMethodType()
/*     */   {
/* 116 */     return new DigestMethodType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public SignatureValueType createSignatureValueType()
/*     */   {
/* 124 */     return new SignatureValueType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public PGPDataType createPGPDataType()
/*     */   {
/* 132 */     return new PGPDataType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public ReferenceType createReferenceType()
/*     */   {
/* 140 */     return new ReferenceType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public DocumentHeaderType createDocumentHeaderType()
/*     */   {
/* 148 */     return new DocumentHeaderType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public TransformsType createTransformsType()
/*     */   {
/* 156 */     return new TransformsType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public SignaturePropertiesType createSignaturePropertiesType()
/*     */   {
/* 164 */     return new SignaturePropertiesType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public RSAKeyValueType createRSAKeyValueType()
/*     */   {
/* 172 */     return new RSAKeyValueType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public ObjectType createObjectType()
/*     */   {
/* 180 */     return new ObjectType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public KeyInfoType createKeyInfoType()
/*     */   {
/* 188 */     return new KeyInfoType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public ManifestType createManifestType()
/*     */   {
/* 196 */     return new ManifestType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public RetrievalMethodType createRetrievalMethodType()
/*     */   {
/* 204 */     return new RetrievalMethodType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public DocumentPayloadType createDocumentPayloadType()
/*     */   {
/* 212 */     return new DocumentPayloadType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public SignatureMethodType createSignatureMethodType()
/*     */   {
/* 220 */     return new SignatureMethodType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public CanonicalizationMethodType createCanonicalizationMethodType()
/*     */   {
/* 228 */     return new CanonicalizationMethodType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public SignedInfoType createSignedInfoType()
/*     */   {
/* 236 */     return new SignedInfoType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public ExchangeNetworkDocumentType createExchangeNetworkDocumentType()
/*     */   {
/* 244 */     return new ExchangeNetworkDocumentType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public KeyValueType createKeyValueType()
/*     */   {
/* 252 */     return new KeyValueType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public TransformType createTransformType()
/*     */   {
/* 260 */     return new TransformType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public SPKIDataType createSPKIDataType()
/*     */   {
/* 268 */     return new SPKIDataType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public X509DataType createX509DataType()
/*     */   {
/* 276 */     return new X509DataType();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   public NameValuePair createNameValuePair()
/*     */   {
/* 284 */     return new NameValuePair();
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="Signature")
/*     */   public JAXBElement<SignatureType> createSignature(SignatureType value)
/*     */   {
/* 293 */     return new JAXBElement(_Signature_QNAME, SignatureType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="PGPData")
/*     */   public JAXBElement<PGPDataType> createPGPData(PGPDataType value)
/*     */   {
/* 302 */     return new JAXBElement(_PGPData_QNAME, PGPDataType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="DSAKeyValue")
/*     */   public JAXBElement<DSAKeyValueType> createDSAKeyValue(DSAKeyValueType value)
/*     */   {
/* 311 */     return new JAXBElement(_DSAKeyValue_QNAME, DSAKeyValueType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="SPKIData")
/*     */   public JAXBElement<SPKIDataType> createSPKIData(SPKIDataType value)
/*     */   {
/* 320 */     return new JAXBElement(_SPKIData_QNAME, SPKIDataType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="SignedInfo")
/*     */   public JAXBElement<SignedInfoType> createSignedInfo(SignedInfoType value)
/*     */   {
/* 329 */     return new JAXBElement(_SignedInfo_QNAME, SignedInfoType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="RetrievalMethod")
/*     */   public JAXBElement<RetrievalMethodType> createRetrievalMethod(RetrievalMethodType value)
/*     */   {
/* 338 */     return new JAXBElement(_RetrievalMethod_QNAME, RetrievalMethodType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="CanonicalizationMethod")
/*     */   public JAXBElement<CanonicalizationMethodType> createCanonicalizationMethod(CanonicalizationMethodType value)
/*     */   {
/* 347 */     return new JAXBElement(_CanonicalizationMethod_QNAME, CanonicalizationMethodType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="Object")
/*     */   public JAXBElement<ObjectType> createObject(ObjectType value)
/*     */   {
/* 356 */     return new JAXBElement(_Object_QNAME, ObjectType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="SignatureProperty")
/*     */   public JAXBElement<SignaturePropertyType> createSignatureProperty(SignaturePropertyType value)
/*     */   {
/* 365 */     return new JAXBElement(_SignatureProperty_QNAME, SignaturePropertyType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="Manifest")
/*     */   public JAXBElement<ManifestType> createManifest(ManifestType value)
/*     */   {
/* 374 */     return new JAXBElement(_Manifest_QNAME, ManifestType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="SignatureValue")
/*     */   public JAXBElement<SignatureValueType> createSignatureValue(SignatureValueType value)
/*     */   {
/* 383 */     return new JAXBElement(_SignatureValue_QNAME, SignatureValueType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="Transforms")
/*     */   public JAXBElement<TransformsType> createTransforms(TransformsType value)
/*     */   {
/* 392 */     return new JAXBElement(_Transforms_QNAME, TransformsType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="Transform")
/*     */   public JAXBElement<TransformType> createTransform(TransformType value)
/*     */   {
/* 401 */     return new JAXBElement(_Transform_QNAME, TransformType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="X509Data")
/*     */   public JAXBElement<X509DataType> createX509Data(X509DataType value)
/*     */   {
/* 410 */     return new JAXBElement(_X509Data_QNAME, X509DataType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="SignatureMethod")
/*     */   public JAXBElement<SignatureMethodType> createSignatureMethod(SignatureMethodType value)
/*     */   {
/* 419 */     return new JAXBElement(_SignatureMethod_QNAME, SignatureMethodType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="KeyInfo")
/*     */   public JAXBElement<KeyInfoType> createKeyInfo(KeyInfoType value)
/*     */   {
/* 428 */     return new JAXBElement(_KeyInfo_QNAME, KeyInfoType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="DigestValue")
/*     */   public JAXBElement<byte[]> createDigestValue(byte[] value)
/*     */   {
/* 437 */     return new JAXBElement(_DigestValue_QNAME, byte[].class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="DigestMethod")
/*     */   public JAXBElement<DigestMethodType> createDigestMethod(DigestMethodType value)
/*     */   {
/* 446 */     return new JAXBElement(_DigestMethod_QNAME, DigestMethodType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.exchangenetwork.net/schema/header/2", name="Document")
/*     */   public JAXBElement<ExchangeNetworkDocumentType> createDocument(ExchangeNetworkDocumentType value)
/*     */   {
/* 455 */     return new JAXBElement(_Document_QNAME, ExchangeNetworkDocumentType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="SignatureProperties")
/*     */   public JAXBElement<SignaturePropertiesType> createSignatureProperties(SignaturePropertiesType value)
/*     */   {
/* 464 */     return new JAXBElement(_SignatureProperties_QNAME, SignaturePropertiesType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="MgmtData")
/*     */   public JAXBElement<String> createMgmtData(String value)
/*     */   {
/* 473 */     return new JAXBElement(_MgmtData_QNAME, String.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="KeyName")
/*     */   public JAXBElement<String> createKeyName(String value)
/*     */   {
/* 482 */     return new JAXBElement(_KeyName_QNAME, String.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="KeyValue")
/*     */   public JAXBElement<KeyValueType> createKeyValue(KeyValueType value)
/*     */   {
/* 491 */     return new JAXBElement(_KeyValue_QNAME, KeyValueType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="Reference")
/*     */   public JAXBElement<ReferenceType> createReference(ReferenceType value)
/*     */   {
/* 500 */     return new JAXBElement(_Reference_QNAME, ReferenceType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="RSAKeyValue")
/*     */   public JAXBElement<RSAKeyValueType> createRSAKeyValue(RSAKeyValueType value)
/*     */   {
/* 509 */     return new JAXBElement(_RSAKeyValue_QNAME, RSAKeyValueType.class, null, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="HMACOutputLength", scope=SignatureMethodType.class)
/*     */   public JAXBElement<BigInteger> createSignatureMethodTypeHMACOutputLength(BigInteger value)
/*     */   {
/* 518 */     return new JAXBElement(_SignatureMethodTypeHMACOutputLength_QNAME, BigInteger.class, SignatureMethodType.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="SPKISexp", scope=SPKIDataType.class)
/*     */   public JAXBElement<byte[]> createSPKIDataTypeSPKISexp(byte[] value)
/*     */   {
/* 527 */     return new JAXBElement(_SPKIDataTypeSPKISexp_QNAME, byte[].class, SPKIDataType.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="X509IssuerSerial", scope=X509DataType.class)
/*     */   public JAXBElement<X509IssuerSerialType> createX509DataTypeX509IssuerSerial(X509IssuerSerialType value)
/*     */   {
/* 536 */     return new JAXBElement(_X509DataTypeX509IssuerSerial_QNAME, X509IssuerSerialType.class, X509DataType.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="X509Certificate", scope=X509DataType.class)
/*     */   public JAXBElement<byte[]> createX509DataTypeX509Certificate(byte[] value)
/*     */   {
/* 545 */     return new JAXBElement(_X509DataTypeX509Certificate_QNAME, byte[].class, X509DataType.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="X509SKI", scope=X509DataType.class)
/*     */   public JAXBElement<byte[]> createX509DataTypeX509SKI(byte[] value)
/*     */   {
/* 554 */     return new JAXBElement(_X509DataTypeX509SKI_QNAME, byte[].class, X509DataType.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="X509SubjectName", scope=X509DataType.class)
/*     */   public JAXBElement<String> createX509DataTypeX509SubjectName(String value)
/*     */   {
/* 563 */     return new JAXBElement(_X509DataTypeX509SubjectName_QNAME, String.class, X509DataType.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="X509CRL", scope=X509DataType.class)
/*     */   public JAXBElement<byte[]> createX509DataTypeX509CRL(byte[] value)
/*     */   {
/* 572 */     return new JAXBElement(_X509DataTypeX509CRL_QNAME, byte[].class, X509DataType.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="PGPKeyID", scope=PGPDataType.class)
/*     */   public JAXBElement<byte[]> createPGPDataTypePGPKeyID(byte[] value)
/*     */   {
/* 581 */     return new JAXBElement(_PGPDataTypePGPKeyID_QNAME, byte[].class, PGPDataType.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="PGPKeyPacket", scope=PGPDataType.class)
/*     */   public JAXBElement<byte[]> createPGPDataTypePGPKeyPacket(byte[] value)
/*     */   {
/* 590 */     return new JAXBElement(_PGPDataTypePGPKeyPacket_QNAME, byte[].class, PGPDataType.class, value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   @XmlElementDecl(namespace="http://www.w3.org/2000/09/xmldsig#", name="XPath", scope=TransformType.class)
/*     */   public JAXBElement<String> createTransformTypeXPath(String value)
/*     */   {
/* 599 */     return new JAXBElement(_TransformTypeXPath_QNAME, String.class, TransformType.class, value);
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\domain\ObjectFactory.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */