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
 * NodeDocumentType.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.4  Built on : Apr 26, 2008 (06:25:17 EDT)
 */

package net.exchangenetwork.www.schema.node._2;

/**
 * NodeDocumentType bean class
 */

public class NodeDocumentType implements org.apache.axis2.databinding.ADBBean {
	/*
	 * This type was generated from the piece of schema that had name =
	 * NodeDocumentType Namespace URI =
	 * http://www.exchangenetwork.net/schema/node/2 Namespace Prefix = ns1
	 */

	private static java.lang.String generatePrefix(java.lang.String namespace) {
		if (namespace.equals("http://www.exchangenetwork.net/schema/node/2")) {
			return "ns1";
		}
		return org.apache.axis2.databinding.utils.BeanUtil.getUniquePrefix();
	}

	/**
	 * field for DocumentName
	 */

	protected java.lang.String localDocumentName;

	/**
	 * Auto generated getter method
	 * 
	 * @return java.lang.String
	 */
	public java.lang.String getDocumentName() {
		return localDocumentName;
	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            DocumentName
	 */
	public void setDocumentName(java.lang.String param) {

		this.localDocumentName = param;

	}

	/**
	 * field for DocumentFormat
	 */

	protected net.exchangenetwork.www.schema.node._2.DocumentFormatType localDocumentFormat;

	/**
	 * Auto generated getter method
	 * 
	 * @return net.exchangenetwork.www.schema.node._2.DocumentFormatType
	 */
	public net.exchangenetwork.www.schema.node._2.DocumentFormatType getDocumentFormat() {
		return localDocumentFormat;
	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            DocumentFormat
	 */
	public void setDocumentFormat(
			net.exchangenetwork.www.schema.node._2.DocumentFormatType param) {

		this.localDocumentFormat = param;

	}

	/**
	 * field for DocumentContent
	 */

	protected net.exchangenetwork.www.schema.node._2.AttachmentType localDocumentContent;

	/**
	 * Auto generated getter method
	 * 
	 * @return net.exchangenetwork.www.schema.node._2.AttachmentType
	 */
	public net.exchangenetwork.www.schema.node._2.AttachmentType getDocumentContent() {
		return localDocumentContent;
	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            DocumentContent
	 */
	public void setDocumentContent(
			net.exchangenetwork.www.schema.node._2.AttachmentType param) {

		this.localDocumentContent = param;

	}

	/**
	 * field for DocumentId This was an Attribute!
	 */

	protected org.apache.axis2.databinding.types.Id localDocumentId;

	/**
	 * Auto generated getter method
	 * 
	 * @return org.apache.axis2.databinding.types.Id
	 */
	public org.apache.axis2.databinding.types.Id getDocumentId() {
		return localDocumentId;
	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            DocumentId
	 */
	public void setDocumentId(org.apache.axis2.databinding.types.Id param) {

		this.localDocumentId = param;

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
				NodeDocumentType.this
						.serialize(parentQName, factory, xmlWriter);
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
						namespacePrefix + ":NodeDocumentType", xmlWriter);
			} else {
				writeAttribute("xsi",
						"http://www.w3.org/2001/XMLSchema-instance", "type",
						"NodeDocumentType", xmlWriter);
			}

		}

		if (localDocumentId != null) {

			writeAttribute("", "documentId",
					org.apache.axis2.databinding.utils.ConverterUtil
							.convertToString(localDocumentId), xmlWriter);

		}

		namespace = "http://www.exchangenetwork.net/schema/node/2";

		if (!namespace.equals("")) {
			prefix = xmlWriter.getPrefix(namespace);

			if (prefix == null) {
				prefix = generatePrefix(namespace);

				xmlWriter.writeStartElement(prefix, "documentName", namespace);
				xmlWriter.writeNamespace(prefix, namespace);
				xmlWriter.setPrefix(prefix, namespace);

			} else {
				xmlWriter.writeStartElement(namespace, "documentName");
			}

		} else {
			xmlWriter.writeStartElement("documentName");
		}

		if (localDocumentName != null) {

			xmlWriter.writeCharacters(localDocumentName);

		}

		xmlWriter.writeEndElement();

		if (localDocumentFormat != null) {
			localDocumentFormat.serialize(new javax.xml.namespace.QName(
					"http://www.exchangenetwork.net/schema/node/2",
					"documentFormat"), factory, xmlWriter);
		}

		if (localDocumentContent != null) {
			localDocumentContent.serialize(new javax.xml.namespace.QName(
					"http://www.exchangenetwork.net/schema/node/2",
					"documentContent"), factory, xmlWriter);
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
				.add(new javax.xml.namespace.QName(
						"http://www.exchangenetwork.net/schema/node/2",
						"documentName"));

		if (localDocumentName != null) {
			elementList.add(org.apache.axis2.databinding.utils.ConverterUtil
					.convertToString(localDocumentName));
		}

		elementList.add(new javax.xml.namespace.QName(
				"http://www.exchangenetwork.net/schema/node/2",
				"documentFormat"));

		if (localDocumentFormat != null) {
			elementList.add(localDocumentFormat);
		}

		elementList.add(new javax.xml.namespace.QName(
				"http://www.exchangenetwork.net/schema/node/2",
				"documentContent"));

		if (localDocumentContent != null) {
			elementList.add(localDocumentContent);
		}

		attribList.add(new javax.xml.namespace.QName("", "documentId"));
		if (localDocumentId != null) {
			attribList.add(org.apache.axis2.databinding.utils.ConverterUtil
					.convertToString(localDocumentId));
		}

		return new org.apache.axis2.databinding.utils.reader.ADBXMLStreamReaderImpl(
				qName, elementList.toArray(), attribList.toArray());

	}

	/**
	 * Factory class that keeps the parse method
	 */
	public static class Factory {

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
		public static NodeDocumentType parse(
				javax.xml.stream.XMLStreamReader reader)
				throws java.lang.Exception {

			NodeDocumentType object = new NodeDocumentType();

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

						if (!"NodeDocumentType".equals(type)) {
							// find namespace for the prefix
							java.lang.String nsUri = reader
									.getNamespaceContext().getNamespaceURI(
											nsPrefix);
							return (NodeDocumentType) net.exchangenetwork.www.schema.node._2.ExtensionMapper
									.getTypeObject(nsUri, type, reader);
						}

					}

				}

				// Note all attributes that were handled. Used to differ normal
				// attributes
				// from anyAttributes.
				java.util.Vector handledAttributes = new java.util.Vector();

				// handle attribute "documentId"
				java.lang.String tempAttribDocumentId =

				reader.getAttributeValue(null, "documentId");

				if (tempAttribDocumentId != null) {
					java.lang.String content = tempAttribDocumentId;

					object
							.setDocumentId(org.apache.axis2.databinding.utils.ConverterUtil
									.convertToID(tempAttribDocumentId));

				}

				handledAttributes.add("documentId");

				reader.next();

				while (!reader.isStartElement() && !reader.isEndElement())
					reader.next();

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"documentName").equals(reader.getName())) {

					java.lang.String content = reader.getElementText();

					object
							.setDocumentName(org.apache.axis2.databinding.utils.ConverterUtil
									.convertToString(content));

					reader.next();

				}

				while (!reader.isStartElement() && !reader.isEndElement())
					reader.next();

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"documentFormat").equals(reader.getName())) {

					object
							.setDocumentFormat(net.exchangenetwork.www.schema.node._2.DocumentFormatType.Factory
									.parse(reader));

					reader.next();

				}

				while (!reader.isStartElement() && !reader.isEndElement())
					reader.next();

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"documentContent").equals(reader.getName())) {

					object
							.setDocumentContent(net.exchangenetwork.www.schema.node._2.AttachmentType.Factory
									.parse(reader));

					reader.next();

				}

				while (!reader.isStartElement() && !reader.isEndElement())
					reader.next();

			} catch (javax.xml.stream.XMLStreamException e) {
				throw new java.lang.Exception(e);
			}

			return object;
		}

	}// end of factory class

}