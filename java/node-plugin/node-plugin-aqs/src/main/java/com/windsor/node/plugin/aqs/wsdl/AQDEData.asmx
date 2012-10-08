<?xml version="1.0" encoding="utf-8"?>
<wsdl:definitions xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/" xmlns:tns="urn:schemas-drdas-com:reporter.aqde.webservice" xmlns:s="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/" targetNamespace="urn:schemas-drdas-com:reporter.aqde.webservice" xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">
  <wsdl:types>
    <s:schema elementFormDefault="qualified" targetNamespace="urn:schemas-drdas-com:reporter.aqde.webservice">
      <s:element name="queryAQSRawData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="FileGenerationPurposeCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="BeginDate" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="BeginTime" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="EndDate" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="EndTime" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="TimeType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="SampleDuration" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="SubstanceName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MonitorType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="DataValidityCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="DataApprovalIndicator" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="StateName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="CountyName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="CityName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="TribeName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="FacilitySiteIdentifier" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MinLatitudeMeasure" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MaxLatitudeMeasure" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MinLongitudeMeasure" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MaxLongitudeMeasure" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="LastUpdatedDate" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="IncludeMonitorDetails" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="IncludeEventData" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="SchemaVersion" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="queryAQSRawDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="queryAQSRawDataResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="queryAQSMonitorData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="FileGenerationPurposeCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="SubstanceName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MonitorType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="StateName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="CountyName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="CityName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="TribeName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="FacilitySiteIdentifier" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MinLatitudeMeasure" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MaxLatitudeMeasure" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MinLongitudeMeasure" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MaxLongitudeMeasure" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="LastUpdatedDate" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="SchemaVersion" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="queryAQSMonitorDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="queryAQSMonitorDataResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="solicitAQSRawData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="FileGenerationPurposeCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="BeginDate" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="BeginTime" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="EndDate" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="EndTime" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="TimeType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="SampleDuration" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="SubstanceName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MonitorType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="DataValidityCode" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="DataApprovalIndicator" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="StateName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="CountyName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="CityName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="TribeName" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="FacilitySiteIdentifier" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MinLatitudeMeasure" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MaxLatitudeMeasure" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MinLongitudeMeasure" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="MaxLongitudeMeasure" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="LastUpdatedDate" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="IncludeMonitorDetails" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="IncludeEventData" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="SchemaVersion" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="RequestId" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="CompressionEnabled" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="solicitAQSRawDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="solicitAQSRawDataResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
    </s:schema>
  </wsdl:types>
  <wsdl:message name="queryAQSRawDataSoapIn">
    <wsdl:part name="parameters" element="tns:queryAQSRawData" />
  </wsdl:message>
  <wsdl:message name="queryAQSRawDataSoapOut">
    <wsdl:part name="parameters" element="tns:queryAQSRawDataResponse" />
  </wsdl:message>
  <wsdl:message name="queryAQSMonitorDataSoapIn">
    <wsdl:part name="parameters" element="tns:queryAQSMonitorData" />
  </wsdl:message>
  <wsdl:message name="queryAQSMonitorDataSoapOut">
    <wsdl:part name="parameters" element="tns:queryAQSMonitorDataResponse" />
  </wsdl:message>
  <wsdl:message name="solicitAQSRawDataSoapIn">
    <wsdl:part name="parameters" element="tns:solicitAQSRawData" />
  </wsdl:message>
  <wsdl:message name="solicitAQSRawDataSoapOut">
    <wsdl:part name="parameters" element="tns:solicitAQSRawDataResponse" />
  </wsdl:message>
  <wsdl:portType name="AQDEDataSoap">
    <wsdl:operation name="queryAQSRawData">
      <wsdl:input message="tns:queryAQSRawDataSoapIn" />
      <wsdl:output message="tns:queryAQSRawDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="queryAQSMonitorData">
      <wsdl:input message="tns:queryAQSMonitorDataSoapIn" />
      <wsdl:output message="tns:queryAQSMonitorDataSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="solicitAQSRawData">
      <wsdl:input message="tns:solicitAQSRawDataSoapIn" />
      <wsdl:output message="tns:solicitAQSRawDataSoapOut" />
    </wsdl:operation>
  </wsdl:portType>
  <wsdl:binding name="AQDEDataSoap" type="tns:AQDEDataSoap">
    <soap:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="queryAQSRawData">
      <soap:operation soapAction="urn:schemas-drdas-com:reporter.aqde.webservice/queryAQSRawData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="queryAQSMonitorData">
      <soap:operation soapAction="urn:schemas-drdas-com:reporter.aqde.webservice/queryAQSMonitorData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="solicitAQSRawData">
      <soap:operation soapAction="urn:schemas-drdas-com:reporter.aqde.webservice/solicitAQSRawData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:binding name="AQDEDataSoap12" type="tns:AQDEDataSoap">
    <soap12:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="queryAQSRawData">
      <soap12:operation soapAction="urn:schemas-drdas-com:reporter.aqde.webservice/queryAQSRawData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="queryAQSMonitorData">
      <soap12:operation soapAction="urn:schemas-drdas-com:reporter.aqde.webservice/queryAQSMonitorData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="solicitAQSRawData">
      <soap12:operation soapAction="urn:schemas-drdas-com:reporter.aqde.webservice/solicitAQSRawData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:service name="AQDEData">
    <wsdl:port name="AQDEDataSoap" binding="tns:AQDEDataSoap">
      <soap:address location="http://134.179.252.121/Reporter/AQDEData.asmx" />
    </wsdl:port>
    <wsdl:port name="AQDEDataSoap12" binding="tns:AQDEDataSoap12">
      <soap12:address location="http://134.179.252.121/Reporter/AQDEData.asmx" />
    </wsdl:port>
  </wsdl:service>
</wsdl:definitions>