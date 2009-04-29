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
 * Notify.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.4  Built on : Apr 26, 2008 (06:25:17 EDT)
 */

package net.exchangenetwork.www.schema.node._2;

import org.apache.log4j.Logger;

/**
 * Notify bean class
 */

public class Notify implements org.apache.axis2.databinding.ADBBean {

	public static final javax.xml.namespace.QName MY_QNAME = new javax.xml.namespace.QName(
			"http://www.exchangenetwork.net/schema/node/2", "Notify", "ns1");

	private static String generatePrefix(String namespace) {
		if (namespace.equals("http://www.exchangenetwork.net/schema/node/2")) {
			return "ns1";
		}
		return org.apache.axis2.databinding.utils.BeanUtil.getUniquePrefix();
	}

	/**
	 * field for SecurityToken
	 */

	protected String localSecurityToken;

	/**
	 * Auto generated getter method
	 * 
	 * @return String
	 */
	public String getSecurityToken() {
		return localSecurityToken;
	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            SecurityToken
	 */
	public void setSecurityToken(String param) {

		this.localSecurityToken = param;

	}

	/**
	 * field for NodeAddress
	 */

	protected String localNodeAddress;

	/**
	 * Auto generated getter method
	 * 
	 * @return String
	 */
	public String getNodeAddress() {
		return localNodeAddress;
	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            NodeAddress
	 */
	public void setNodeAddress(String param) {

		this.localNodeAddress = param;

	}

	/**
	 * field for Dataflow
	 */

	protected org.apache.axis2.databinding.types.NCName localDataflow;

	/**
	 * Auto generated getter method
	 * 
	 * @return org.apache.axis2.databinding.types.NCName
	 */
	public org.apache.axis2.databinding.types.NCName getDataflow() {
		return localDataflow;
	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            Dataflow
	 */
	public void setDataflow(org.apache.axis2.databinding.types.NCName param) {

		this.localDataflow = param;

	}

	/**
	 * field for Messages This was an Array!
	 */

	protected NotificationMessageType[] localMessages;

	/**
	 * Auto generated getter method
	 * 
	 * @return NotificationMessageType[]
	 */
	public NotificationMessageType[] getMessages() {
		return localMessages;
	}

	/**
	 * validate the array for Messages
	 */
	protected void validateMessages(NotificationMessageType[] param) {

		if ((param != null) && (param.length < 1)) {
			throw new RuntimeException();
		}

	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            Messages
	 */
	public void setMessages(NotificationMessageType[] param) {

		validateMessages(param);

		this.localMessages = param;
	}

	/**
	 * Auto generated add method for the array for convenience
	 * 
	 * @param param
	 *            NotificationMessageType
	 */
	public void addMessages(NotificationMessageType param) {
		if (localMessages == null) {
			localMessages = new NotificationMessageType[] {};
		}

		java.util.List list = org.apache.axis2.databinding.utils.ConverterUtil
				.toList(localMessages);
		list.add(param);
		this.localMessages = (NotificationMessageType[]) list
				.toArray(new NotificationMessageType[list.size()]);

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
				this, MY_QNAME) {

			public void serialize(
					org.apache.axis2.databinding.utils.writer.MTOMAwareXMLStreamWriter xmlWriter)
					throws javax.xml.stream.XMLStreamException {
				Notify.this.serialize(MY_QNAME, factory, xmlWriter);
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
						namespacePrefix + ":Notify", xmlWriter);
			} else {
				writeAttribute("xsi",
						"http://www.w3.org/2001/XMLSchema-instance", "type",
						"Notify", xmlWriter);
			}

		}

		namespace = "http://www.exchangenetwork.net/schema/node/2";
		if (!namespace.equals("")) {
			prefix = xmlWriter.getPrefix(namespace);

			if (prefix == null) {
				prefix = generatePrefix(namespace);

				xmlWriter.writeStartElement(prefix, "securityToken", namespace);
				xmlWriter.writeNamespace(prefix, namespace);
				xmlWriter.setPrefix(prefix, namespace);

			} else {
				xmlWriter.writeStartElement(namespace, "securityToken");
			}

		} else {
			xmlWriter.writeStartElement("securityToken");
		}

		if (localSecurityToken == null) {
			// write the nil attribute

			throw new org.apache.axis2.databinding.ADBException(
					"securityToken cannot be null!!");

		} else {

			xmlWriter.writeCharacters(localSecurityToken);

		}

		xmlWriter.writeEndElement();

		namespace = "http://www.exchangenetwork.net/schema/node/2";
		if (!namespace.equals("")) {
			prefix = xmlWriter.getPrefix(namespace);

			if (prefix == null) {
				prefix = generatePrefix(namespace);

				xmlWriter.writeStartElement(prefix, "nodeAddress", namespace);
				xmlWriter.writeNamespace(prefix, namespace);
				xmlWriter.setPrefix(prefix, namespace);

			} else {
				xmlWriter.writeStartElement(namespace, "nodeAddress");
			}

		} else {
			xmlWriter.writeStartElement("nodeAddress");
		}

		if (localNodeAddress == null) {
			// write the nil attribute

			throw new org.apache.axis2.databinding.ADBException(
					"nodeAddress cannot be null!!");

		} else {

			xmlWriter.writeCharacters(localNodeAddress);

		}

		xmlWriter.writeEndElement();

		namespace = "http://www.exchangenetwork.net/schema/node/2";
		if (!namespace.equals("")) {
			prefix = xmlWriter.getPrefix(namespace);

			if (prefix == null) {
				prefix = generatePrefix(namespace);

				xmlWriter.writeStartElement(prefix, "dataflow", namespace);
				xmlWriter.writeNamespace(prefix, namespace);
				xmlWriter.setPrefix(prefix, namespace);

			} else {
				xmlWriter.writeStartElement(namespace, "dataflow");
			}

		} else {
			xmlWriter.writeStartElement("dataflow");
		}

		if (localDataflow == null) {
			// write the nil attribute

			throw new org.apache.axis2.databinding.ADBException(
					"dataflow cannot be null!!");

		} else {

			xmlWriter
					.writeCharacters(org.apache.axis2.databinding.utils.ConverterUtil
							.convertToString(localDataflow));

		}

		xmlWriter.writeEndElement();

		if (localMessages != null) {
			for (int i = 0; i < localMessages.length; i++) {
				if (localMessages[i] != null) {
					localMessages[i].serialize(new javax.xml.namespace.QName(
							"http://www.exchangenetwork.net/schema/node/2",
							"messages"), factory, xmlWriter);
				} else {

					throw new org.apache.axis2.databinding.ADBException(
							"messages cannot be null!!");

				}

			}
		} else {

			throw new org.apache.axis2.databinding.ADBException(
					"messages cannot be null!!");

		}

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

		elementList
				.add(new javax.xml.namespace.QName(
						"http://www.exchangenetwork.net/schema/node/2",
						"securityToken"));

		if (localSecurityToken != null) {
			elementList.add(org.apache.axis2.databinding.utils.ConverterUtil
					.convertToString(localSecurityToken));
		} else {
			throw new org.apache.axis2.databinding.ADBException(
					"securityToken cannot be null!!");
		}

		elementList.add(new javax.xml.namespace.QName(
				"http://www.exchangenetwork.net/schema/node/2", "nodeAddress"));

		if (localNodeAddress != null) {
			elementList.add(org.apache.axis2.databinding.utils.ConverterUtil
					.convertToString(localNodeAddress));
		} else {
			throw new org.apache.axis2.databinding.ADBException(
					"nodeAddress cannot be null!!");
		}

		elementList.add(new javax.xml.namespace.QName(
				"http://www.exchangenetwork.net/schema/node/2", "dataflow"));

		if (localDataflow != null) {
			elementList.add(org.apache.axis2.databinding.utils.ConverterUtil
					.convertToString(localDataflow));
		} else {
			throw new org.apache.axis2.databinding.ADBException(
					"dataflow cannot be null!!");
		}

		if (localMessages != null) {
			for (int i = 0; i < localMessages.length; i++) {

				if (localMessages[i] != null) {
					elementList.add(new javax.xml.namespace.QName(
							"http://www.exchangenetwork.net/schema/node/2",
							"messages"));
					elementList.add(localMessages[i]);
				} else {

					throw new org.apache.axis2.databinding.ADBException(
							"messages cannot be null !!");

				}

			}
		} else {

			throw new org.apache.axis2.databinding.ADBException(
					"messages cannot be null!!");

		}

		return new org.apache.axis2.databinding.utils.reader.ADBXMLStreamReaderImpl(
				qName, elementList.toArray(), attribList.toArray());

	}

	/**
	 * Factory class that keeps the parse method
	 */
	public static class Factory {

		private static final Logger logger = Logger.getLogger(Factory.class);

		public static Notify parse(javax.xml.stream.XMLStreamReader reader)
				throws Exception {

			logger.debug("Initializing notifty message parsing...");

			Notify object = new Notify();

			try {

				while (!reader.isStartElement() && !reader.isEndElement()) {
					reader.next();
				}

				if (reader.getAttributeValue(
						"http://www.w3.org/2001/XMLSchema-instance", "type") != null) {

					logger.debug("Using type");

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

						if (!"Notify".equals(type)) {

							// find namespace for the prefix
							String nsUri = reader.getNamespaceContext()
									.getNamespaceURI(nsPrefix);
							return (Notify) ExtensionMapper.getTypeObject(
									nsUri, type, reader);

						}

					}

				}

				reader.next();

				java.util.ArrayList list4 = new java.util.ArrayList();

				while (!reader.isStartElement() && !reader.isEndElement()) {
					reader.next();
				}

				logger.debug("Looking for securityToken...");

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"securityToken").equals(reader.getName())) {

					String content = reader.getElementText();
					logger.debug("securityToken: " + content);

					object
							.setSecurityToken(org.apache.axis2.databinding.utils.ConverterUtil
									.convertToString(content));

					reader.next();

				}

				while (!reader.isStartElement() && !reader.isEndElement()) {
					reader.next();
				}

				logger.debug("Looking for nodeAddress...");

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"nodeAddress").equals(reader.getName())) {

					String content = reader.getElementText();
					logger.debug("nodeAddress: " + content);

					object
							.setNodeAddress(org.apache.axis2.databinding.utils.ConverterUtil
									.convertToString(content));

					reader.next();

				}

				while (!reader.isStartElement() && !reader.isEndElement()) {
					reader.next();
				}

				logger.debug("Looking for dataflow...");

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"dataflow").equals(reader.getName())) {

					String content = reader.getElementText();
					logger.debug("dataflow: " + content);

					object
							.setDataflow(org.apache.axis2.databinding.utils.ConverterUtil
									.convertToNCName(content));

					reader.next();

				}

				while (!reader.isStartElement() && !reader.isEndElement()) {
					reader.next();
				}

				logger.debug("Looking for messages...");

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"messages").equals(reader.getName())) {

					// Process the array and step past its final element's end.
					list4.add(NotificationMessageType.Factory.parse(reader));

					// loop until we find a start element that is not part of
					// this array
					boolean loopDone4 = false;
					while (!loopDone4) {
						// We should be at the end element, but make sure
						while (!reader.isEndElement())
							reader.next();
						// Step out of this element
						reader.next();
						// Step to next element event.
						while (!reader.isStartElement()
								&& !reader.isEndElement())
							reader.next();
						if (reader.isEndElement()) {
							// two continuous end elements means we are exiting
							// the xml structure
							loopDone4 = true;
						} else {
							if (new javax.xml.namespace.QName(
									"http://www.exchangenetwork.net/schema/node/2",
									"messages").equals(reader.getName())) {
								list4.add(NotificationMessageType.Factory
										.parse(reader));

							} else {
								loopDone4 = true;
							}
						}
					}
					// call the converter utility to convert and smessageet the
					// array

					object
							.setMessages((NotificationMessageType[]) org.apache.axis2.databinding.utils.ConverterUtil
									.convertToArray(
											NotificationMessageType.class,
											list4));

				}

				while (!reader.isStartElement() && !reader.isEndElement()) {
					reader.next();
				}

			} catch (Exception ex) {
				logger.error(ex.getMessage(), ex);
				throw new RuntimeException("Error while parsing Notify: "
						+ ex.getMessage(), ex);
			}

			return object;
		}

	}// end of factory class

}