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
 * NotificationMessageType.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.4  Built on : Apr 26, 2008 (06:25:17 EDT)
 */

package net.exchangenetwork.www.schema.node._2;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

/**
 * NotificationMessageType bean class
 */

public class NotificationMessageType implements
		org.apache.axis2.databinding.ADBBean {

	private static final Logger logger = LoggerFactory
			.getLogger(NotificationMessageType.class);

	/*
	 * This type was generated from the piece of schema that had name =
	 * NotificationMessageType Namespace URI =
	 * http://www.exchangenetwork.net/schema/node/2 Namespace Prefix = ns1
	 */

	private static String generatePrefix(String namespace) {
		if (namespace.equals("http://www.exchangenetwork.net/schema/node/2")) {
			return "ns1";
		}
		return org.apache.axis2.databinding.utils.BeanUtil.getUniquePrefix();
	}

	/**
	 * field for MessageCategory
	 */

	protected net.exchangenetwork.www.schema.node._2.NotificationMessageCategoryType localMessageCategory;

	/**
	 * Auto generated getter method
	 * 
	 * @return net.exchangenetwork.www.schema.node._2.NotificationMessageCategoryType
	 */
	public net.exchangenetwork.www.schema.node._2.NotificationMessageCategoryType getMessageCategory() {
		return localMessageCategory;
	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            MessageCategory
	 */
	public void setMessageCategory(
			net.exchangenetwork.www.schema.node._2.NotificationMessageCategoryType param) {

		this.localMessageCategory = param;

	}

	/**
	 * field for MessageName
	 */

	protected String localMessageName;

	/**
	 * Auto generated getter method
	 * 
	 * @return String
	 */
	public String getMessageName() {
		return localMessageName;
	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            MessageName
	 */
	public void setMessageName(String param) {

		this.localMessageName = param;

	}

	/**
	 * field for Status
	 */

	protected net.exchangenetwork.www.schema.node._2.TransactionStatusCode localStatus;

	/**
	 * Auto generated getter method
	 * 
	 * @return net.exchangenetwork.www.schema.node._2.TransactionStatusCode
	 */
	public net.exchangenetwork.www.schema.node._2.TransactionStatusCode getStatus() {
		return localStatus;
	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            Status
	 */
	public void setStatus(
			net.exchangenetwork.www.schema.node._2.TransactionStatusCode param) {

		this.localStatus = param;

	}

	/**
	 * field for StatusDetail
	 */

	protected String localStatusDetail;

	/**
	 * Auto generated getter method
	 * 
	 * @return String
	 */
	public String getStatusDetail() {
		return localStatusDetail;
	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            StatusDetail
	 */
	public void setStatusDetail(String param) {

		this.localStatusDetail = param;

	}

	/**
	 * field for ObjectId This was an Attribute!
	 */

	protected String localObjectId;

	/**
	 * Auto generated getter method
	 * 
	 * @return String
	 */
	public String getObjectId() {
		return localObjectId;
	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            ObjectId
	 */
	public void setObjectId(String param) {

		this.localObjectId = param;

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
			isReaderMTOMAware = Boolean.TRUE
					.equals(reader
							.getProperty(org.apache.axiom.om.OMConstants.IS_DATA_HANDLERS_AWARE));
		} catch (IllegalArgumentException e) {
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
				NotificationMessageType.this.serialize(parentQName, factory,
						xmlWriter);
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

		String prefix = null;
		String namespace = null;

		prefix = parentQName.getPrefix();
		namespace = parentQName.getNamespaceURI();

		if ((namespace != null) && (namespace.trim().length() > 0)) {
			String writerPrefix = xmlWriter.getPrefix(namespace);
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

			String namespacePrefix = registerPrefix(xmlWriter,
					"http://www.exchangenetwork.net/schema/node/2");
			if ((namespacePrefix != null)
					&& (namespacePrefix.trim().length() > 0)) {
				writeAttribute("xsi",
						"http://www.w3.org/2001/XMLSchema-instance", "type",
						namespacePrefix + ":NotificationMessageType", xmlWriter);
			} else {
				writeAttribute("xsi",
						"http://www.w3.org/2001/XMLSchema-instance", "type",
						"NotificationMessageType", xmlWriter);
			}

		}

		if (localObjectId != null) {

			writeAttribute("", "objectId",
					org.apache.axis2.databinding.utils.ConverterUtil
							.convertToString(localObjectId), xmlWriter);

		}

		else {
			throw new org.apache.axis2.databinding.ADBException(
					"required attribute localObjectId is null");
		}

		if (localMessageCategory == null) {
			throw new org.apache.axis2.databinding.ADBException(
					"messageCategory cannot be null!!");
		}
		localMessageCategory.serialize(new javax.xml.namespace.QName(
				"http://www.exchangenetwork.net/schema/node/2",
				"messageCategory"), factory, xmlWriter);

		namespace = "http://www.exchangenetwork.net/schema/node/2";
		if (!namespace.equals("")) {
			prefix = xmlWriter.getPrefix(namespace);

			if (prefix == null) {
				prefix = generatePrefix(namespace);

				xmlWriter.writeStartElement(prefix, "messageName", namespace);
				xmlWriter.writeNamespace(prefix, namespace);
				xmlWriter.setPrefix(prefix, namespace);

			} else {
				xmlWriter.writeStartElement(namespace, "messageName");
			}

		} else {
			xmlWriter.writeStartElement("messageName");
		}

		if (localMessageName == null) {
			// write the nil attribute

			throw new org.apache.axis2.databinding.ADBException(
					"messageName cannot be null!!");

		} else {

			xmlWriter.writeCharacters(localMessageName);

		}

		xmlWriter.writeEndElement();

		if (localStatus == null) {
			throw new org.apache.axis2.databinding.ADBException(
					"status cannot be null!!");
		}
		localStatus.serialize(new javax.xml.namespace.QName(
				"http://www.exchangenetwork.net/schema/node/2", "status"),
				factory, xmlWriter);

		namespace = "http://www.exchangenetwork.net/schema/node/2";
		if (!namespace.equals("")) {
			prefix = xmlWriter.getPrefix(namespace);

			if (prefix == null) {
				prefix = generatePrefix(namespace);

				xmlWriter.writeStartElement(prefix, "statusDetail", namespace);
				xmlWriter.writeNamespace(prefix, namespace);
				xmlWriter.setPrefix(prefix, namespace);

			} else {
				xmlWriter.writeStartElement(namespace, "statusDetail");
			}

		} else {
			xmlWriter.writeStartElement("statusDetail");
		}

		if (localStatusDetail == null) {
			// write the nil attribute

			throw new org.apache.axis2.databinding.ADBException(
					"statusDetail cannot be null!!");

		} else {

			xmlWriter.writeCharacters(localStatusDetail);

		}

		xmlWriter.writeEndElement();

		xmlWriter.writeEndElement();

	}

	/**
	 * Util method to write an attribute with the ns prefix
	 */
	private void writeAttribute(String prefix, String namespace,
			String attName, String attValue,
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
	private void writeAttribute(String namespace, String attName,
			String attValue, javax.xml.stream.XMLStreamWriter xmlWriter)
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
	private void writeQNameAttribute(String namespace, String attName,
			javax.xml.namespace.QName qname,
			javax.xml.stream.XMLStreamWriter xmlWriter)
			throws javax.xml.stream.XMLStreamException {

		String attributeNamespace = qname.getNamespaceURI();
		String attributePrefix = xmlWriter.getPrefix(attributeNamespace);
		if (attributePrefix == null) {
			attributePrefix = registerPrefix(xmlWriter, attributeNamespace);
		}
		String attributeValue;
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
		String namespaceURI = qname.getNamespaceURI();
		if (namespaceURI != null) {
			String prefix = xmlWriter.getPrefix(namespaceURI);
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
			StringBuffer stringToWrite = new StringBuffer();
			String namespaceURI = null;
			String prefix = null;

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
	private String registerPrefix(javax.xml.stream.XMLStreamWriter xmlWriter,
			String namespace) throws javax.xml.stream.XMLStreamException {
		String prefix = xmlWriter.getPrefix(namespace);

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
				"http://www.exchangenetwork.net/schema/node/2",
				"messageCategory"));

		if (localMessageCategory == null) {
			throw new org.apache.axis2.databinding.ADBException(
					"messageCategory cannot be null!!");
		}
		elementList.add(localMessageCategory);

		elementList.add(new javax.xml.namespace.QName(
				"http://www.exchangenetwork.net/schema/node/2", "messageName"));

		if (localMessageName != null) {
			elementList.add(org.apache.axis2.databinding.utils.ConverterUtil
					.convertToString(localMessageName));
		} else {
			throw new org.apache.axis2.databinding.ADBException(
					"messageName cannot be null!!");
		}

		elementList.add(new javax.xml.namespace.QName(
				"http://www.exchangenetwork.net/schema/node/2", "status"));

		if (localStatus == null) {
			throw new org.apache.axis2.databinding.ADBException(
					"status cannot be null!!");
		}
		elementList.add(localStatus);

		elementList
				.add(new javax.xml.namespace.QName(
						"http://www.exchangenetwork.net/schema/node/2",
						"statusDetail"));

		if (localStatusDetail != null) {
			elementList.add(org.apache.axis2.databinding.utils.ConverterUtil
					.convertToString(localStatusDetail));
		} else {
			throw new org.apache.axis2.databinding.ADBException(
					"statusDetail cannot be null!!");
		}

		attribList.add(new javax.xml.namespace.QName("", "objectId"));

		attribList.add(org.apache.axis2.databinding.utils.ConverterUtil
				.convertToString(localObjectId));

		return new org.apache.axis2.databinding.utils.reader.ADBXMLStreamReaderImpl(
				qName, elementList.toArray(), attribList.toArray());

	}

	/**
	 * Factory class that keeps the parse method
	 */
	public static class Factory {

		private static final Logger logger = LoggerFactory
				.getLogger(NotificationMessageType.class);

		public static NotificationMessageType parse(
				javax.xml.stream.XMLStreamReader reader) throws Exception {

			NotificationMessageType object = new NotificationMessageType();

			try {

				while (!reader.isStartElement() && !reader.isEndElement())
					reader.next();

				if (reader.getAttributeValue(
						"http://www.w3.org/2001/XMLSchema-instance", "type") != null) {
					String fullTypeName = reader
							.getAttributeValue(
									"http://www.w3.org/2001/XMLSchema-instance",
									"type");
					if (fullTypeName != null) {
						String nsPrefix = null;
						if (fullTypeName.indexOf(":") > -1) {
							nsPrefix = fullTypeName.substring(0, fullTypeName
									.indexOf(":"));
						}
						nsPrefix = nsPrefix == null ? "" : nsPrefix;

						String type = fullTypeName.substring(fullTypeName
								.indexOf(":") + 1);

						if (!"NotificationMessageType".equals(type)) {
							// find namespace for the prefix
							String nsUri = reader.getNamespaceContext()
									.getNamespaceURI(nsPrefix);
							return (NotificationMessageType) net.exchangenetwork.www.schema.node._2.ExtensionMapper
									.getTypeObject(nsUri, type, reader);
						}

					}

				}

				// Note all attributes that were handled. Used to differ normal
				// attributes
				// from anyAttributes.
				java.util.Vector handledAttributes = new java.util.Vector();

				logger.debug("Looking for objectId...");

				// handle attribute "objectId"
				String tempAttribObjectId = reader.getAttributeValue(null,
						"objectId");

				if (tempAttribObjectId != null) {

					// String content = tempAttribObjectId;

					object.setObjectId(tempAttribObjectId);

				}

				handledAttributes.add("objectId");

				reader.next();

				while (!reader.isStartElement() && !reader.isEndElement()) {
					reader.next();
				}

				logger.debug("Looking for messageCategory...");

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"messageCategory").equals(reader.getName())) {

					object
							.setMessageCategory(net.exchangenetwork.www.schema.node._2.NotificationMessageCategoryType.Factory
									.parse(reader));

					reader.next();

				}

				while (!reader.isStartElement() && !reader.isEndElement()) {
					reader.next();
				}

				logger.debug("Looking for messageName...");

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"messageName").equals(reader.getName())) {

					String content = reader.getElementText();

					object
							.setMessageName(org.apache.axis2.databinding.utils.ConverterUtil
									.convertToString(content));

					reader.next();

				}

				while (!reader.isStartElement() && !reader.isEndElement()) {
					reader.next();
				}

				logger.debug("Looking for status...");

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"status").equals(reader.getName())) {

					object
							.setStatus(net.exchangenetwork.www.schema.node._2.TransactionStatusCode.Factory
									.parse(reader));

					reader.next();

				}

				while (!reader.isStartElement() && !reader.isEndElement()) {
					reader.next();
				}

				logger.debug("Looking for statusDetail...");

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"statusDetail").equals(reader.getName())) {

					String content = reader.getElementText();

					object
							.setStatusDetail(org.apache.axis2.databinding.utils.ConverterUtil
									.convertToString(content));

					reader.next();

				}

				while (!reader.isStartElement() && !reader.isEndElement()) {
					reader.next();
				}

			} catch (javax.xml.stream.XMLStreamException e) {
				throw new Exception(e);
			}

			return object;
		}

	}// end of factory class

}
