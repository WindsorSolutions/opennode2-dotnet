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
 * Submit.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.4  Built on : Apr 26, 2008 (06:25:17 EDT)
 */

package net.exchangenetwork.www.schema.node._2;

/**
 * Submit bean class
 */

public class Submit implements org.apache.axis2.databinding.ADBBean {

	public static final javax.xml.namespace.QName MY_QNAME = new javax.xml.namespace.QName(
			"http://www.exchangenetwork.net/schema/node/2", "Submit", "ns1");

	private static java.lang.String generatePrefix(java.lang.String namespace) {
		if (namespace.equals("http://www.exchangenetwork.net/schema/node/2")) {
			return "ns1";
		}
		return org.apache.axis2.databinding.utils.BeanUtil.getUniquePrefix();
	}

	/**
	 * field for SecurityToken
	 */

	protected java.lang.String localSecurityToken;

	/**
	 * Auto generated getter method
	 * 
	 * @return java.lang.String
	 */
	public java.lang.String getSecurityToken() {
		return localSecurityToken;
	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            SecurityToken
	 */
	public void setSecurityToken(java.lang.String param) {

		this.localSecurityToken = param;

	}

	/**
	 * field for TransactionId
	 */

	protected java.lang.String localTransactionId;

	/**
	 * Auto generated getter method
	 * 
	 * @return java.lang.String
	 */
	public java.lang.String getTransactionId() {
		return localTransactionId;
	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            TransactionId
	 */
	public void setTransactionId(java.lang.String param) {

		this.localTransactionId = param;

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
	 * field for FlowOperation
	 */

	protected java.lang.String localFlowOperation;

	/**
	 * Auto generated getter method
	 * 
	 * @return java.lang.String
	 */
	public java.lang.String getFlowOperation() {
		return localFlowOperation;
	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            FlowOperation
	 */
	public void setFlowOperation(java.lang.String param) {

		this.localFlowOperation = param;

	}

	/**
	 * field for Recipient This was an Array!
	 */

	protected java.lang.String[] localRecipient;

	/*
	 * This tracker boolean wil be used to detect whether the user called the
	 * set method for this attribute. It will be used to determine whether to
	 * include this field in the serialized XML
	 */
	protected boolean localRecipientTracker = false;

	/**
	 * Auto generated getter method
	 * 
	 * @return java.lang.String[]
	 */
	public java.lang.String[] getRecipient() {
		return localRecipient;
	}

	/**
	 * validate the array for Recipient
	 */
	protected void validateRecipient(java.lang.String[] param) {

	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            Recipient
	 */
	public void setRecipient(java.lang.String[] param) {

		validateRecipient(param);

		if (param != null) {
			// update the setting tracker
			localRecipientTracker = true;
		} else {
			localRecipientTracker = false;

		}

		this.localRecipient = param;
	}

	/**
	 * Auto generated add method for the array for convenience
	 * 
	 * @param param
	 *            java.lang.String
	 */
	public void addRecipient(java.lang.String param) {
		if (localRecipient == null) {
			localRecipient = new java.lang.String[] {};
		}

		// update the setting tracker
		localRecipientTracker = true;

		java.util.List list = org.apache.axis2.databinding.utils.ConverterUtil
				.toList(localRecipient);
		list.add(param);
		this.localRecipient = (java.lang.String[]) list
				.toArray(new java.lang.String[list.size()]);

	}

	/**
	 * field for NotificationURI This was an Array!
	 */

	protected net.exchangenetwork.www.schema.node._2.NotificationURIType[] localNotificationURI;

	/*
	 * This tracker boolean wil be used to detect whether the user called the
	 * set method for this attribute. It will be used to determine whether to
	 * include this field in the serialized XML
	 */
	protected boolean localNotificationURITracker = false;

	/**
	 * Auto generated getter method
	 * 
	 * @return net.exchangenetwork.www.schema.node._2.NotificationURIType[]
	 */
	public net.exchangenetwork.www.schema.node._2.NotificationURIType[] getNotificationURI() {
		return localNotificationURI;
	}

	/**
	 * validate the array for NotificationURI
	 */
	protected void validateNotificationURI(
			net.exchangenetwork.www.schema.node._2.NotificationURIType[] param) {

	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            NotificationURI
	 */
	public void setNotificationURI(
			net.exchangenetwork.www.schema.node._2.NotificationURIType[] param) {

		validateNotificationURI(param);

		if (param != null) {
			// update the setting tracker
			localNotificationURITracker = true;
		} else {
			localNotificationURITracker = false;

		}

		this.localNotificationURI = param;
	}

	/**
	 * Auto generated add method for the array for convenience
	 * 
	 * @param param
	 *            net.exchangenetwork.www.schema.node._2.NotificationURIType
	 */
	public void addNotificationURI(
			net.exchangenetwork.www.schema.node._2.NotificationURIType param) {
		if (localNotificationURI == null) {
			localNotificationURI = new net.exchangenetwork.www.schema.node._2.NotificationURIType[] {};
		}

		// update the setting tracker
		localNotificationURITracker = true;

		java.util.List list = org.apache.axis2.databinding.utils.ConverterUtil
				.toList(localNotificationURI);
		list.add(param);
		this.localNotificationURI = (net.exchangenetwork.www.schema.node._2.NotificationURIType[]) list
				.toArray(new net.exchangenetwork.www.schema.node._2.NotificationURIType[list
						.size()]);

	}

	/**
	 * field for Documents This was an Array!
	 */

	protected net.exchangenetwork.www.schema.node._2.NodeDocumentType[] localDocuments;

	/**
	 * Auto generated getter method
	 * 
	 * @return net.exchangenetwork.www.schema.node._2.NodeDocumentType[]
	 */
	public net.exchangenetwork.www.schema.node._2.NodeDocumentType[] getDocuments() {
		return localDocuments;
	}

	/**
	 * validate the array for Documents
	 */
	protected void validateDocuments(
			net.exchangenetwork.www.schema.node._2.NodeDocumentType[] param) {

		if ((param != null) && (param.length < 1)) {
			throw new java.lang.RuntimeException();
		}

	}

	/**
	 * Auto generated setter method
	 * 
	 * @param param
	 *            Documents
	 */
	public void setDocuments(
			net.exchangenetwork.www.schema.node._2.NodeDocumentType[] param) {

		validateDocuments(param);

		this.localDocuments = param;
	}

	/**
	 * Auto generated add method for the array for convenience
	 * 
	 * @param param
	 *            net.exchangenetwork.www.schema.node._2.NodeDocumentType
	 */
	public void addDocuments(
			net.exchangenetwork.www.schema.node._2.NodeDocumentType param) {
		if (localDocuments == null) {
			localDocuments = new net.exchangenetwork.www.schema.node._2.NodeDocumentType[] {};
		}

		java.util.List list = org.apache.axis2.databinding.utils.ConverterUtil
				.toList(localDocuments);
		list.add(param);
		this.localDocuments = (net.exchangenetwork.www.schema.node._2.NodeDocumentType[]) list
				.toArray(new net.exchangenetwork.www.schema.node._2.NodeDocumentType[list
						.size()]);

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
				Submit.this.serialize(MY_QNAME, factory, xmlWriter);
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
						namespacePrefix + ":Submit", xmlWriter);
			} else {
				writeAttribute("xsi",
						"http://www.w3.org/2001/XMLSchema-instance", "type",
						"Submit", xmlWriter);
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

				xmlWriter.writeStartElement(prefix, "transactionId", namespace);
				xmlWriter.writeNamespace(prefix, namespace);
				xmlWriter.setPrefix(prefix, namespace);

			} else {
				xmlWriter.writeStartElement(namespace, "transactionId");
			}

		} else {
			xmlWriter.writeStartElement("transactionId");
		}

		if (localTransactionId == null) {
			// write the nil attribute

			throw new org.apache.axis2.databinding.ADBException(
					"transactionId cannot be null!!");

		} else {

			xmlWriter.writeCharacters(localTransactionId);

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

		namespace = "http://www.exchangenetwork.net/schema/node/2";
		if (!namespace.equals("")) {
			prefix = xmlWriter.getPrefix(namespace);

			if (prefix == null) {
				prefix = generatePrefix(namespace);

				xmlWriter.writeStartElement(prefix, "flowOperation", namespace);
				xmlWriter.writeNamespace(prefix, namespace);
				xmlWriter.setPrefix(prefix, namespace);

			} else {
				xmlWriter.writeStartElement(namespace, "flowOperation");
			}

		} else {
			xmlWriter.writeStartElement("flowOperation");
		}

		if (localFlowOperation == null) {
			xmlWriter.writeCharacters("");
		} else {
			xmlWriter.writeCharacters(localFlowOperation);
		}

		xmlWriter.writeEndElement();
		if (localRecipientTracker) {
			if (localRecipient != null) {
				namespace = "http://www.exchangenetwork.net/schema/node/2";
				boolean emptyNamespace = namespace == null
						|| namespace.length() == 0;
				prefix = emptyNamespace ? null : xmlWriter.getPrefix(namespace);
				for (int i = 0; i < localRecipient.length; i++) {

					if (localRecipient[i] != null) {

						if (!emptyNamespace) {
							if (prefix == null) {
								java.lang.String prefix2 = generatePrefix(namespace);

								xmlWriter.writeStartElement(prefix2,
										"recipient", namespace);
								xmlWriter.writeNamespace(prefix2, namespace);
								xmlWriter.setPrefix(prefix2, namespace);

							} else {
								xmlWriter.writeStartElement(namespace,
										"recipient");
							}

						} else {
							xmlWriter.writeStartElement("recipient");
						}

						xmlWriter
								.writeCharacters(org.apache.axis2.databinding.utils.ConverterUtil
										.convertToString(localRecipient[i]));

						xmlWriter.writeEndElement();

					} else {

						// we have to do nothing since minOccurs is zero

					}

				}
			} else {

				throw new org.apache.axis2.databinding.ADBException(
						"recipient cannot be null!!");

			}

		}
		if (localNotificationURITracker) {
			if (localNotificationURI != null) {
				for (int i = 0; i < localNotificationURI.length; i++) {
					if (localNotificationURI[i] != null) {
						localNotificationURI[i]
								.serialize(
										new javax.xml.namespace.QName(
												"http://www.exchangenetwork.net/schema/node/2",
												"notificationURI"), factory,
										xmlWriter);
					} else {

						// we don't have to do any thing since minOccures is
						// zero

					}

				}
			} else {

				throw new org.apache.axis2.databinding.ADBException(
						"notificationURI cannot be null!!");

			}
		}
		if (localDocuments != null) {

			for (int i = 0; i < localDocuments.length; i++) {
				if (localDocuments[i] != null) {
					localDocuments[i].serialize(new javax.xml.namespace.QName(
							"http://www.exchangenetwork.net/schema/node/2",
							"documents"), factory, xmlWriter);
				} else {

					throw new org.apache.axis2.databinding.ADBException(
							"documents cannot be null!!");

				}

			}
		} else {

			localDocuments = new net.exchangenetwork.www.schema.node._2.NodeDocumentType[0];

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
						"securityToken"));

		if (localSecurityToken != null) {
			elementList.add(org.apache.axis2.databinding.utils.ConverterUtil
					.convertToString(localSecurityToken));
		} else {
			throw new org.apache.axis2.databinding.ADBException(
					"securityToken cannot be null!!");
		}

		elementList
				.add(new javax.xml.namespace.QName(
						"http://www.exchangenetwork.net/schema/node/2",
						"transactionId"));

		if (localTransactionId != null) {
			elementList.add(org.apache.axis2.databinding.utils.ConverterUtil
					.convertToString(localTransactionId));
		} else {
			throw new org.apache.axis2.databinding.ADBException(
					"transactionId cannot be null!!");
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

		elementList
				.add(new javax.xml.namespace.QName(
						"http://www.exchangenetwork.net/schema/node/2",
						"flowOperation"));

		if (localFlowOperation != null) {
			elementList.add(org.apache.axis2.databinding.utils.ConverterUtil
					.convertToString(localFlowOperation));
		} else {
			throw new org.apache.axis2.databinding.ADBException(
					"flowOperation cannot be null!!");
		}
		if (localRecipientTracker) {
			if (localRecipient != null) {
				for (int i = 0; i < localRecipient.length; i++) {

					if (localRecipient[i] != null) {
						elementList.add(new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"recipient"));
						elementList
								.add(org.apache.axis2.databinding.utils.ConverterUtil
										.convertToString(localRecipient[i]));
					} else {

						// have to do nothing

					}

				}
			} else {

				throw new org.apache.axis2.databinding.ADBException(
						"recipient cannot be null!!");

			}

		}
		if (localNotificationURITracker) {
			if (localNotificationURI != null) {
				for (int i = 0; i < localNotificationURI.length; i++) {

					if (localNotificationURI[i] != null) {
						elementList.add(new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"notificationURI"));
						elementList.add(localNotificationURI[i]);
					} else {

						// nothing to do

					}

				}
			} else {

				throw new org.apache.axis2.databinding.ADBException(
						"notificationURI cannot be null!!");

			}

		}
		if (localDocuments != null) {

			for (int i = 0; i < localDocuments.length; i++) {

				if (localDocuments[i] != null) {
					elementList.add(new javax.xml.namespace.QName(
							"http://www.exchangenetwork.net/schema/node/2",
							"documents"));
					elementList.add(localDocuments[i]);
				} else {

					throw new org.apache.axis2.databinding.ADBException(
							"documents cannot be null !!");

				}

			}
		} else {

			throw new org.apache.axis2.databinding.ADBException(
					"documents cannot be null!!");

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
		public static Submit parse(javax.xml.stream.XMLStreamReader reader)
				throws java.lang.Exception {
			Submit object = new Submit();

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

						if (!"Submit".equals(type)) {
							// find namespace for the prefix
							java.lang.String nsUri = reader
									.getNamespaceContext().getNamespaceURI(
											nsPrefix);
							return (Submit) net.exchangenetwork.www.schema.node._2.ExtensionMapper
									.getTypeObject(nsUri, type, reader);
						}

					}

				}

				// Note all attributes that were handled. Used to differ normal
				// attributes
				// from anyAttributes.
				java.util.Vector handledAttributes = new java.util.Vector();

				reader.next();

				java.util.ArrayList list5 = new java.util.ArrayList();

				java.util.ArrayList list6 = new java.util.ArrayList();

				java.util.ArrayList list7 = new java.util.ArrayList();

				while (!reader.isStartElement() && !reader.isEndElement())
					reader.next();

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"securityToken").equals(reader.getName())) {

					java.lang.String content = reader.getElementText();

					object
							.setSecurityToken(org.apache.axis2.databinding.utils.ConverterUtil
									.convertToString(content));

					reader.next();

				} // End of if for expected property start element

				else {
					// A start element we are not expecting indicates an invalid
					// parameter was passed
					throw new org.apache.axis2.databinding.ADBException(
							"Unexpected subelement " + reader.getLocalName());
				}

				while (!reader.isStartElement() && !reader.isEndElement())
					reader.next();

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"transactionId").equals(reader.getName())) {

					java.lang.String content = reader.getElementText();

					object
							.setTransactionId(org.apache.axis2.databinding.utils.ConverterUtil
									.convertToString(content));

					reader.next();

				} // End of if for expected property start element

				else {
					// A start element we are not expecting indicates an invalid
					// parameter was passed
					throw new org.apache.axis2.databinding.ADBException(
							"Unexpected subelement " + reader.getLocalName());
				}

				while (!reader.isStartElement() && !reader.isEndElement())
					reader.next();

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"dataflow").equals(reader.getName())) {

					java.lang.String content = reader.getElementText();

					object
							.setDataflow(org.apache.axis2.databinding.utils.ConverterUtil
									.convertToNCName(content));

					reader.next();

				} // End of if for expected property start element

				else {
					// A start element we are not expecting indicates an invalid
					// parameter was passed
					throw new org.apache.axis2.databinding.ADBException(
							"Unexpected subelement " + reader.getLocalName());
				}

				while (!reader.isStartElement() && !reader.isEndElement())
					reader.next();

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"flowOperation").equals(reader.getName())) {

					java.lang.String content = reader.getElementText();

					object
							.setFlowOperation(org.apache.axis2.databinding.utils.ConverterUtil
									.convertToString(content));

					reader.next();

				} // End of if for expected property start element

				else {
					// A start element we are not expecting indicates an invalid
					// parameter was passed
					throw new org.apache.axis2.databinding.ADBException(
							"Unexpected subelement " + reader.getLocalName());
				}

				while (!reader.isStartElement() && !reader.isEndElement())
					reader.next();

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"recipient").equals(reader.getName())) {

					// Process the array and step past its final element's end.
					list5.add(reader.getElementText());

					// loop until we find a start element that is not part of
					// this array
					boolean loopDone5 = false;
					while (!loopDone5) {
						// Ensure we are at the EndElement
						while (!reader.isEndElement()) {
							reader.next();
						}
						// Step out of this element
						reader.next();
						// Step to next element event.
						while (!reader.isStartElement()
								&& !reader.isEndElement())
							reader.next();
						if (reader.isEndElement()) {
							// two continuous end elements means we are exiting
							// the xml structure
							loopDone5 = true;
						} else {
							if (new javax.xml.namespace.QName(
									"http://www.exchangenetwork.net/schema/node/2",
									"recipient").equals(reader.getName())) {
								list5.add(reader.getElementText());

							} else {
								loopDone5 = true;
							}
						}
					}
					// call the converter utility to convert and set the array

					object.setRecipient((java.lang.String[]) list5
							.toArray(new java.lang.String[list5.size()]));

				} // End of if for expected property start element

				else {

				}

				while (!reader.isStartElement() && !reader.isEndElement())
					reader.next();

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"notificationURI").equals(reader.getName())) {

					// Process the array and step past its final element's end.
					list6
							.add(net.exchangenetwork.www.schema.node._2.NotificationURIType.Factory
									.parse(reader));

					// loop until we find a start element that is not part of
					// this array
					boolean loopDone6 = false;
					while (!loopDone6) {
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
							loopDone6 = true;
						} else {
							if (new javax.xml.namespace.QName(
									"http://www.exchangenetwork.net/schema/node/2",
									"notificationURI").equals(reader.getName())) {
								list6
										.add(net.exchangenetwork.www.schema.node._2.NotificationURIType.Factory
												.parse(reader));

							} else {
								loopDone6 = true;
							}
						}
					}
					// call the converter utility to convert and set the array

					object
							.setNotificationURI((net.exchangenetwork.www.schema.node._2.NotificationURIType[]) org.apache.axis2.databinding.utils.ConverterUtil
									.convertToArray(
											net.exchangenetwork.www.schema.node._2.NotificationURIType.class,
											list6));

				} // End of if for expected property start element

				else {

				}

				while (!reader.isStartElement() && !reader.isEndElement())
					reader.next();

				if (reader.isStartElement()
						&& new javax.xml.namespace.QName(
								"http://www.exchangenetwork.net/schema/node/2",
								"documents").equals(reader.getName())) {

					// Process the array and step past its final element's end.
					list7
							.add(net.exchangenetwork.www.schema.node._2.NodeDocumentType.Factory
									.parse(reader));

					// loop until we find a start element that is not part of
					// this array
					boolean loopDone7 = false;
					while (!loopDone7) {
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
							loopDone7 = true;
						} else {
							if (new javax.xml.namespace.QName(
									"http://www.exchangenetwork.net/schema/node/2",
									"documents").equals(reader.getName())) {
								list7
										.add(net.exchangenetwork.www.schema.node._2.NodeDocumentType.Factory
												.parse(reader));

							} else {
								loopDone7 = true;
							}
						}
					}
					// call the converter utility to convert and set the array

					object
							.setDocuments((net.exchangenetwork.www.schema.node._2.NodeDocumentType[]) org.apache.axis2.databinding.utils.ConverterUtil
									.convertToArray(
											net.exchangenetwork.www.schema.node._2.NodeDocumentType.class,
											list7));

				} // End of if for expected property start element

				else {
					// A start element we are not expecting indicates an invalid
					// parameter was passed
					throw new org.apache.axis2.databinding.ADBException(
							"Unexpected subelement " + reader.getLocalName());
				}

				while (!reader.isStartElement() && !reader.isEndElement())
					reader.next();

				if (reader.isStartElement())
					// A start element we are not expecting indicates a trailing
					// invalid property
					throw new org.apache.axis2.databinding.ADBException(
							"Unexpected subelement " + reader.getLocalName());

			} catch (javax.xml.stream.XMLStreamException e) {
				throw new java.lang.Exception(e);
			}

			return object;
		}

	}// end of factory class

}