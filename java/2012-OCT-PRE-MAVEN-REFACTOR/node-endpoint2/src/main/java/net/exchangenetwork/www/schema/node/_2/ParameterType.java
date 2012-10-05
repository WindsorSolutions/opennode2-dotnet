/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
 */

/**
 * ParameterType.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.4  Built on : Apr 26, 2008 (06:25:17 EDT)
 */

package net.exchangenetwork.www.schema.node._2;

/**
 * ParameterType bean class
 */

public class ParameterType implements org.apache.axis2.databinding.ADBBean {
    /*
     * This type was generated from the piece of schema that had name =
     * ParameterType Namespace URI =
     * http://www.exchangenetwork.net/schema/node/2 Namespace Prefix = ns1
     */

    private static java.lang.String generatePrefix(java.lang.String namespace) {
        if (namespace.equals("http://www.exchangenetwork.net/schema/node/2")) {
            return "ns1";
        }
        return org.apache.axis2.databinding.utils.BeanUtil.getUniquePrefix();
    }

    /**
     * field for String
     */

    protected java.lang.String localString;

    /**
     * Auto generated getter method
     * 
     * @return java.lang.String
     */
    public java.lang.String getString() {
        return localString;
    }

    /**
     * Auto generated setter method
     * 
     * @param param
     *            String
     */
    public void setString(java.lang.String param) {

        this.localString = param;

    }

    public java.lang.String toString() {

        return localString.toString();

    }

    /**
     * field for ParameterName This was an Attribute!
     */

    protected java.lang.String localParameterName;

    /**
     * Auto generated getter method
     * 
     * @return java.lang.String
     */
    public java.lang.String getParameterName() {
        return localParameterName;
    }

    /**
     * Auto generated setter method
     * 
     * @param param
     *            ParameterName
     */
    public void setParameterName(java.lang.String param) {

        this.localParameterName = param;

    }

    /**
     * field for ParameterType This was an Attribute!
     */

    protected javax.xml.namespace.QName localParameterType;

    /**
     * Auto generated getter method
     * 
     * @return javax.xml.namespace.QName
     */
    public javax.xml.namespace.QName getParameterType() {
        return localParameterType;
    }

    /**
     * Auto generated setter method
     * 
     * @param param
     *            ParameterType
     */
    public void setParameterType(javax.xml.namespace.QName param) {

        this.localParameterType = param;

    }

    /**
     * field for ParameterEncoding This was an Attribute!
     */

    protected net.exchangenetwork.www.schema.node._2.EncodingType localParameterEncoding;

    /**
     * Auto generated getter method
     * 
     * @return net.exchangenetwork.www.schema.node._2.EncodingType
     */
    public net.exchangenetwork.www.schema.node._2.EncodingType getParameterEncoding() {
        return localParameterEncoding;
    }

    /**
     * Auto generated setter method
     * 
     * @param param
     *            ParameterEncoding
     */
    public void setParameterEncoding(
            net.exchangenetwork.www.schema.node._2.EncodingType param) {

        this.localParameterEncoding = param;

    }

    /**
     * isReaderMTOMAware
     * 
     * @return true if the reader supports MTOM
     */
    public static boolean isReaderMTOMAware(
            javax.xml.stream.XMLStreamReader reader) {
        boolean isReaderMTOMAware = false;

        try {
            isReaderMTOMAware = java.lang.Boolean.TRUE
                    .equals(reader
                            .getProperty(org.apache.axiom.om.OMConstants.IS_DATA_HANDLERS_AWARE));
        } catch (java.lang.IllegalArgumentException e) {
            isReaderMTOMAware = false;
        }
        return isReaderMTOMAware;
    }

    /**
     * 
     * @param parentQName
     * @param factory
     * @return org.apache.axiom.om.OMElement
     */
    public org.apache.axiom.om.OMElement getOMElement(
            final javax.xml.namespace.QName parentQName,
            final org.apache.axiom.om.OMFactory factory)
            throws org.apache.axis2.databinding.ADBException {

        org.apache.axiom.om.OMDataSource dataSource = new org.apache.axis2.databinding.ADBDataSource(
                this, parentQName) {

            public void serialize(
                    org.apache.axis2.databinding.utils.writer.MTOMAwareXMLStreamWriter xmlWriter)
                    throws javax.xml.stream.XMLStreamException {
                ParameterType.this.serialize(parentQName, factory, xmlWriter);
            }
        };
        return new org.apache.axiom.om.impl.llom.OMSourcedElementImpl(
                parentQName, factory, dataSource);

    }

    public void serialize(
            final javax.xml.namespace.QName parentQName,
            final org.apache.axiom.om.OMFactory factory,
            org.apache.axis2.databinding.utils.writer.MTOMAwareXMLStreamWriter xmlWriter)
            throws javax.xml.stream.XMLStreamException,
            org.apache.axis2.databinding.ADBException {
        serialize(parentQName, factory, xmlWriter, false);
    }

    public void serialize(
            final javax.xml.namespace.QName parentQName,
            final org.apache.axiom.om.OMFactory factory,
            org.apache.axis2.databinding.utils.writer.MTOMAwareXMLStreamWriter xmlWriter,
            boolean serializeType) throws javax.xml.stream.XMLStreamException,
            org.apache.axis2.databinding.ADBException {

        java.lang.String prefix = null;
        java.lang.String namespace = null;

        prefix = parentQName.getPrefix();
        namespace = parentQName.getNamespaceURI();

        if ((namespace != null) && (namespace.trim().length() > 0)) {
            java.lang.String writerPrefix = xmlWriter.getPrefix(namespace);
            if (writerPrefix != null) {
                xmlWriter.writeStartElement(namespace, parentQName
                        .getLocalPart());
            } else {
                if (prefix == null) {
                    prefix = generatePrefix(namespace);
                }

                xmlWriter.writeStartElement(prefix, parentQName.getLocalPart(),
                        namespace);
                xmlWriter.writeNamespace(prefix, namespace);
                xmlWriter.setPrefix(prefix, namespace);
            }
        } else {
            xmlWriter.writeStartElement(parentQName.getLocalPart());
        }

        if (serializeType) {

            java.lang.String namespacePrefix = registerPrefix(xmlWriter,
                    "http://www.exchangenetwork.net/schema/node/2");
            if ((namespacePrefix != null)
                    && (namespacePrefix.trim().length() > 0)) {
                writeAttribute("xsi",
                        "http://www.w3.org/2001/XMLSchema-instance", "type",
                        namespacePrefix + ":ParameterType", xmlWriter);
            } else {
                writeAttribute("xsi",
                        "http://www.w3.org/2001/XMLSchema-instance", "type",
                        "ParameterType", xmlWriter);
            }

        }

        if (localParameterName != null) {

            writeAttribute("", "parameterName",
                    org.apache.axis2.databinding.utils.ConverterUtil
                            .convertToString(localParameterName), xmlWriter);

        }

        else {
            throw new org.apache.axis2.databinding.ADBException(
                    "required attribute localParameterName is null");
        }

        if (localParameterType != null) {

            writeQNameAttribute("", "parameterType", localParameterType,
                    xmlWriter);

        }

        if (localParameterEncoding != null) {
            writeAttribute("", "parameterEncoding", localParameterEncoding
                    .toString(), xmlWriter);
        }

        if (localString == null) {
            // write the nil attribute

            throw new org.apache.axis2.databinding.ADBException(
                    "string cannot be null!!");

        } else {

            xmlWriter.writeCharacters(localString);

        }

        xmlWriter.writeEndElement();

    }

    /**
     * Util method to write an attribute with the ns prefix
     */
    private void writeAttribute(java.lang.String prefix,
            java.lang.String namespace, java.lang.String attName,
            java.lang.String attValue,
            javax.xml.stream.XMLStreamWriter xmlWriter)
            throws javax.xml.stream.XMLStreamException {
        if (xmlWriter.getPrefix(namespace) == null) {
            xmlWriter.writeNamespace(prefix, namespace);
            xmlWriter.setPrefix(prefix, namespace);

        }

        xmlWriter.writeAttribute(namespace, attName, attValue);

    }

    /**
     * Util method to write an attribute without the ns prefix
     */
    private void writeAttribute(java.lang.String namespace,
            java.lang.String attName, java.lang.String attValue,
            javax.xml.stream.XMLStreamWriter xmlWriter)
            throws javax.xml.stream.XMLStreamException {
        if (namespace.equals("")) {
            xmlWriter.writeAttribute(attName, attValue);
        } else {
            registerPrefix(xmlWriter, namespace);
            xmlWriter.writeAttribute(namespace, attName, attValue);
        }
    }

    /**
     * Util method to write an attribute without the ns prefix
     */
    private void writeQNameAttribute(java.lang.String namespace,
            java.lang.String attName, javax.xml.namespace.QName qname,
            javax.xml.stream.XMLStreamWriter xmlWriter)
            throws javax.xml.stream.XMLStreamException {

        java.lang.String attributeNamespace = qname.getNamespaceURI();
        java.lang.String attributePrefix = xmlWriter
                .getPrefix(attributeNamespace);
        if (attributePrefix == null) {
            attributePrefix = registerPrefix(xmlWriter, attributeNamespace);
        }
        java.lang.String attributeValue;
        if (attributePrefix.trim().length() > 0) {
            attributeValue = attributePrefix + ":" + qname.getLocalPart();
        } else {
            attributeValue = qname.getLocalPart();
        }

        if (namespace.equals("")) {
            xmlWriter.writeAttribute(attName, attributeValue);
        } else {
            registerPrefix(xmlWriter, namespace);
            xmlWriter.writeAttribute(namespace, attName, attributeValue);
        }
    }

    /**
     * method to handle Qnames
     */

    private void writeQName(javax.xml.namespace.QName qname,
            javax.xml.stream.XMLStreamWriter xmlWriter)
            throws javax.xml.stream.XMLStreamException {
        java.lang.String namespaceURI = qname.getNamespaceURI();
        if (namespaceURI != null) {
            java.lang.String prefix = xmlWriter.getPrefix(namespaceURI);
            if (prefix == null) {
                prefix = generatePrefix(namespaceURI);
                xmlWriter.writeNamespace(prefix, namespaceURI);
                xmlWriter.setPrefix(prefix, namespaceURI);
            }

            if (prefix.trim().length() > 0) {
                xmlWriter.writeCharacters(prefix
                        + ":"
                        + org.apache.axis2.databinding.utils.ConverterUtil
                                .convertToString(qname));
            } else {
                // i.e this is the default namespace
                xmlWriter
                        .writeCharacters(org.apache.axis2.databinding.utils.ConverterUtil
                                .convertToString(qname));
            }

        } else {
            xmlWriter
                    .writeCharacters(org.apache.axis2.databinding.utils.ConverterUtil
                            .convertToString(qname));
        }
    }

    private void writeQNames(javax.xml.namespace.QName[] qnames,
            javax.xml.stream.XMLStreamWriter xmlWriter)
            throws javax.xml.stream.XMLStreamException {

        if (qnames != null) {
            // we have to store this data until last moment since it is not
            // possible to write any
            // namespace data after writing the charactor data
            java.lang.StringBuffer stringToWrite = new java.lang.StringBuffer();
            java.lang.String namespaceURI = null;
            java.lang.String prefix = null;

            for (int i = 0; i < qnames.length; i++) {
                if (i > 0) {
                    stringToWrite.append(" ");
                }
                namespaceURI = qnames[i].getNamespaceURI();
                if (namespaceURI != null) {
                    prefix = xmlWriter.getPrefix(namespaceURI);
                    if ((prefix == null) || (prefix.length() == 0)) {
                        prefix = generatePrefix(namespaceURI);
                        xmlWriter.writeNamespace(prefix, namespaceURI);
                        xmlWriter.setPrefix(prefix, namespaceURI);
                    }

                    if (prefix.trim().length() > 0) {
                        stringToWrite
                                .append(prefix)
                                .append(":")
                                .append(
                                        org.apache.axis2.databinding.utils.ConverterUtil
                                                .convertToString(qnames[i]));
                    } else {
                        stringToWrite
                                .append(org.apache.axis2.databinding.utils.ConverterUtil
                                        .convertToString(qnames[i]));
                    }
                } else {
                    stringToWrite
                            .append(org.apache.axis2.databinding.utils.ConverterUtil
                                    .convertToString(qnames[i]));
                }
            }
            xmlWriter.writeCharacters(stringToWrite.toString());
        }

    }

    /**
     * Register a namespace prefix
     */
    private java.lang.String registerPrefix(
            javax.xml.stream.XMLStreamWriter xmlWriter,
            java.lang.String namespace)
            throws javax.xml.stream.XMLStreamException {
        java.lang.String prefix = xmlWriter.getPrefix(namespace);

        if (prefix == null) {
            prefix = generatePrefix(namespace);

            while (xmlWriter.getNamespaceContext().getNamespaceURI(prefix) != null) {
                prefix = org.apache.axis2.databinding.utils.BeanUtil
                        .getUniquePrefix();
            }

            xmlWriter.writeNamespace(prefix, namespace);
            xmlWriter.setPrefix(prefix, namespace);
        }

        return prefix;
    }

    /**
     * databinding method to get an XML representation of this object
     * 
     */
    public javax.xml.stream.XMLStreamReader getPullParser(
            javax.xml.namespace.QName qName)
            throws org.apache.axis2.databinding.ADBException {

        java.util.ArrayList elementList = new java.util.ArrayList();
        java.util.ArrayList attribList = new java.util.ArrayList();

        elementList
                .add(org.apache.axis2.databinding.utils.reader.ADBXMLStreamReader.ELEMENT_TEXT);

        if (localString != null) {
            elementList.add(org.apache.axis2.databinding.utils.ConverterUtil
                    .convertToString(localString));
        } else {
            throw new org.apache.axis2.databinding.ADBException(
                    "string cannot be null!!");
        }

        attribList.add(new javax.xml.namespace.QName("", "parameterName"));

        attribList.add(org.apache.axis2.databinding.utils.ConverterUtil
                .convertToString(localParameterName));

        attribList.add(new javax.xml.namespace.QName("", "parameterType"));

        attribList.add(org.apache.axis2.databinding.utils.ConverterUtil
                .convertToString(localParameterType));

        attribList.add(new javax.xml.namespace.QName("", "parameterEncoding"));

        attribList.add(localParameterEncoding.toString());

        return new org.apache.axis2.databinding.utils.reader.ADBXMLStreamReaderImpl(
                qName, elementList.toArray(), attribList.toArray());

    }

    /**
     * Factory class that keeps the parse method
     */
    public static class Factory {

        public static ParameterType fromString(java.lang.String value,
                java.lang.String namespaceURI) {
            ParameterType returnValue = new ParameterType();

            returnValue
                    .setString(org.apache.axis2.databinding.utils.ConverterUtil
                            .convertToString(value));

            return returnValue;
        }

        public static ParameterType fromString(
                javax.xml.stream.XMLStreamReader xmlStreamReader,
                java.lang.String content) {
            if (content.indexOf(":") > -1) {
                java.lang.String prefix = content.substring(0, content
                        .indexOf(":"));
                java.lang.String namespaceUri = xmlStreamReader
                        .getNamespaceContext().getNamespaceURI(prefix);
                return ParameterType.Factory.fromString(content, namespaceUri);
            } else {
                return ParameterType.Factory.fromString(content, "");
            }
        }

        /**
         * static method to create the object Precondition: If this object is an
         * element, the current or next start element starts this object and any
         * intervening reader events are ignorable If this object is not an
         * element, it is a complex type and the reader is at the event just
         * after the outer start element Postcondition: If this object is an
         * element, the reader is positioned at its end element If this object
         * is a complex type, the reader is positioned at the end element of its
         * outer element
         */
        public static ParameterType parse(
                javax.xml.stream.XMLStreamReader reader)
                throws java.lang.Exception {
            ParameterType object = new ParameterType();

            int event;
            java.lang.String nillableValue = null;
            java.lang.String prefix = "";
            java.lang.String namespaceuri = "";
            try {

                while (!reader.isStartElement() && !reader.isEndElement())
                    reader.next();

                if (reader.getAttributeValue(
                        "http://www.w3.org/2001/XMLSchema-instance", "type") != null) {
                    java.lang.String fullTypeName = reader
                            .getAttributeValue(
                                    "http://www.w3.org/2001/XMLSchema-instance",
                                    "type");
                    if (fullTypeName != null) {
                        java.lang.String nsPrefix = null;
                        if (fullTypeName.indexOf(":") > -1) {
                            nsPrefix = fullTypeName.substring(0, fullTypeName
                                    .indexOf(":"));
                        }
                        nsPrefix = nsPrefix == null ? "" : nsPrefix;

                        java.lang.String type = fullTypeName
                                .substring(fullTypeName.indexOf(":") + 1);

                        if (!"ParameterType".equals(type)) {
                            // find namespace for the prefix
                            java.lang.String nsUri = reader
                                    .getNamespaceContext().getNamespaceURI(
                                            nsPrefix);
                            return (ParameterType) net.exchangenetwork.www.schema.node._2.ExtensionMapper
                                    .getTypeObject(nsUri, type, reader);
                        }

                    }

                }

                // Note all attributes that were handled. Used to differ normal
                // attributes
                // from anyAttributes.
                java.util.Vector handledAttributes = new java.util.Vector();

                // handle attribute "parameterName"
                java.lang.String tempAttribParameterName =

                reader.getAttributeValue(null, "parameterName");

                if (tempAttribParameterName != null) {
                    java.lang.String content = tempAttribParameterName;

                    object
                            .setParameterName(org.apache.axis2.databinding.utils.ConverterUtil
                                    .convertToString(tempAttribParameterName));

                } else {

                    throw new org.apache.axis2.databinding.ADBException(
                            "Required attribute parameterName is missing");

                }
                handledAttributes.add("parameterName");

                // handle attribute "parameterType"
                java.lang.String tempAttribParameterType =

                reader.getAttributeValue(null, "parameterType");

                if (tempAttribParameterType != null) {
                    java.lang.String content = tempAttribParameterType;

                    int index = tempAttribParameterType.indexOf(":");
                    if (index > -1) {
                        prefix = tempAttribParameterType.substring(0, index);
                    } else {
                        // i.e this is in default namesace
                        prefix = "";
                    }
                    namespaceuri = reader.getNamespaceURI(prefix);

                    object
                            .setParameterType(org.apache.axis2.databinding.utils.ConverterUtil
                                    .convertToQName(tempAttribParameterType,
                                            namespaceuri));

                } else {

                }
                handledAttributes.add("parameterType");

                // handle attribute "parameterEncoding"
                java.lang.String tempAttribParameterEncoding =

                reader.getAttributeValue(null, "parameterEncoding");

                if (tempAttribParameterEncoding != null) {
                    java.lang.String content = tempAttribParameterEncoding;

                    object
                            .setParameterEncoding(net.exchangenetwork.www.schema.node._2.EncodingType.Factory
                                    .fromString(reader,
                                            tempAttribParameterEncoding));

                } else {

                }
                handledAttributes.add("parameterEncoding");

                while (!reader.isEndElement()) {
                    if (reader.isStartElement() || reader.hasText()) {

                        if (reader.isStartElement() || reader.hasText()) {

                            java.lang.String content = reader.getElementText();

                            object
                                    .setString(org.apache.axis2.databinding.utils.ConverterUtil
                                            .convertToString(content));

                        } // End of if for expected property start element

                        else {
                            // A start element we are not expecting indicates an
                            // invalid parameter was passed
                            throw new org.apache.axis2.databinding.ADBException(
                                    "Unexpected subelement "
                                            + reader.getLocalName());
                        }

                    } else {
                        reader.next();
                    }
                } // end of while loop

            } catch (javax.xml.stream.XMLStreamException e) {
                throw new java.lang.Exception(e);
            }

            return object;
        }

    }// end of factory class

}