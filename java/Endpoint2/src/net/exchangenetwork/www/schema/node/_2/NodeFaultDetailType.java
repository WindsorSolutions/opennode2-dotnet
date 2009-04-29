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
 * NodeFaultDetailType.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.4  Built on : Apr 26, 2008 (06:25:17 EDT)
 */

package net.exchangenetwork.www.schema.node._2;

/**
 * NodeFaultDetailType bean class
 */

public class NodeFaultDetailType implements
		org.apache.axis2.databinding.ADBBean {

	private static final long serialVersionUID = 1;

	public static final javax.xml.namespace.QName MY_QNAME = new javax.xml.namespace.QName(
			"http://www.exchangenetwork.net/schema/node/2",
			"NodeFaultDetailType", "ns1");

	private static java.lang.String generatePrefix(java.lang.String namespace) {
		if (namespace.equals("http://www.exchangenetwork.net/schema/node/2")) {
			return "ns1";
		}
		return org.apache.axis2.databinding.utils.BeanUtil.getUniquePrefix();
	}

	/**
	 * field for ErrorCode
	 */

	protected net.exchangenetwork.www.schema.node._2.ErrorCodeList localErrorCode;

	/**
	 * Auto generated getter method
	 * 
	 * @return net.exchangenetwork.www.schema.node._2.ErrorCodeList
	 */
	public net.exchangenetwork.www.schema.node._2.ErrorCodeList getErrorCode() {
		return localErrorCode;
	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            ErrorCode
	 */
	public void setErrorCode(
			net.exchangenetwork.www.schema.node._2.ErrorCodeList param) {

		this.localErrorCode = param;

	}

	/**
	 * field for Description
	 */

	protected java.lang.String localDescription;

	/**
	 * Auto generated getter method
	 * 
	 * @return java.lang.String
	 */
	public java.lang.String getDescription() {
		return localDescription;
	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            Description
	 */
	public void setDescription(java.lang.String param) {

		this.localDescription = param;

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
				this, MY_QNAME) {

			public void serialize(
					org.apache.axis2.databinding.utils.writer.MTOMAwareXMLStreamWriter xmlWriter)
					throws javax.xml.stream.XMLStreamException {
				NodeFaultDetailType.this
						.serialize(MY_QNAME, factory, xmlWriter);
			}
		};
		return new org.apache.axiom.om.impl.llom.OMSourcedElementImpl(MY_QNAME,
				factory, dataSource);

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
						namespacePrefix + ":NodeFaultDetailType", xmlWriter);
			} else {
				writeAttribute("xsi",
						"http://www.w3.org/2001/XMLSchema-instance", "type",
						"NodeFaultDetailType", xmlWriter);
			}

		}

		if (localErrorCode == null) {
			throw new org.apache.axis2.databinding.ADBException(
					"errorCode cannot be null!!");
		}
		localErrorCode.serialize(new javax.xml.namespace.QName(
				"http://www.exchangenetwork.net/schema/node/2", "errorCode"),
				factory, xmlWriter);

		namespace = "http://www.exchangenetwork.net/schema/node/2";
		if (!namespace.equals("")) {
			prefix = xmlWriter.getPrefix(namespace);

			if (prefix == null) {
				prefix = generatePrefix(namespace);

				xmlWriter.writeStartElement(prefix, "description", namespace);
				xmlWriter.writeNamespace(prefix, namespace);
				xmlWriter.setPrefix(prefix, namespace);

			} else {
				xmlWriter.writeStartElement(namespace, "description");
			}

		} else {
			xmlWriter.writeStartElement("description");
		}

		if (localDescription == null) {
			// write the nil attribute

			throw new org.apache.axis2.databinding.ADBException(
					"description cannot be null!!");

		} else {

			xmlWriter.writeCharacters(localDescription);

		}

		xmlWriter.writeEndElement();

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

		elementList.add(new javax.xml.namespace.QName(
				"http://www.exchangenetwork.net/schema/node/2", "errorCode"));

		if (localErrorCode == null) {
			throw new org.apache.axis2.databinding.ADBException(
					"errorCode cannot be null!!");
		}
		elementList.add(localErrorCode);

		elementList.add(new javax.xml.namespace.QName(
				"http://www.exchangenetwork.net/schema/node/2", "description"));

		if (localDescription != null) {
			elementList.add(org.apache.axis2.databinding.utils.ConverterUtil
					.convertToString(localDescription));
		} else {
			throw new org.apache.axis2.databinding.ADBException(
					"description cannot be null!!");
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
		public static NodeFaultDetailType parse(
				javax.xml.stream.XMLStreamReader reader)
				throws java.lang.Exception {

			NodeFaultDetailType object = new NodeFaultDetailType();

			try {

				while (!reader.isStartElement() && !reader.isEndElement()) {
					reader.next();
				}

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

						if (!"NodeFaultDetailType".equals(type)) {
							// find namespace for the prefix
							java.lang.String nsUri = reader
									.getNamespaceContext().getNamespaceURI(
											nsPrefix);
							return (NodeFaultDetailType) net.exchangenetwork.www.schema.node._2.ExtensionMapper
									.getTypeObject(nsUri, type, reader);
						}

					}

				}

				reader.next();

				// CODE
				while (!reader.isStartElement() && !reader.isEndElement())
					reader.next();

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"errorCode").equals(reader.getName())) {

					object
							.setErrorCode(net.exchangenetwork.www.schema.node._2.ErrorCodeList.Factory
									.parse(reader));

					reader.next();

				} else {
					object.localDescription = object.localDescription
							+ " (Invalid Node Exception. Unexpected subelement "
							+ reader.getLocalName() + ")";
				}

				while (!reader.isStartElement() && !reader.isEndElement()) {
					reader.next();
				}

				// DESCRIPTION
				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"description").equals(reader.getName())) {

					java.lang.String content = reader.getElementText();

					object
							.setDescription(org.apache.axis2.databinding.utils.ConverterUtil
									.convertToString(content));

					reader.next();

				} else {
					object.localDescription = "No description provided";
				}

				while (!reader.isStartElement() && !reader.isEndElement()) {
					reader.next();
				}

			} catch (javax.xml.stream.XMLStreamException e) {

				object.localDescription = "Error while parsing content: "
						+ e.getMessage();
			}

			return object;
		}

	}// end of factory class

}