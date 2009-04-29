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
 * ExtensionMapper.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.4  Built on : Apr 26, 2008 (06:25:17 EDT)
 */

package net.exchangenetwork.www.schema.node._2;

/**
 * ExtensionMapper class
 */

public class ExtensionMapper {

    public static java.lang.Object getTypeObject(java.lang.String namespaceURI,
            java.lang.String typeName, javax.xml.stream.XMLStreamReader reader)
            throws java.lang.Exception {

        if ("http://www.exchangenetwork.net/schema/node/2".equals(namespaceURI)
                && "NotificationTypeCode".equals(typeName)) {

            return net.exchangenetwork.www.schema.node._2.NotificationTypeCode.Factory
                    .parse(reader);

        }

        if ("http://www.exchangenetwork.net/schema/node/2".equals(namespaceURI)
                && "NotificationMessageType".equals(typeName)) {

            return net.exchangenetwork.www.schema.node._2.NotificationMessageType.Factory
                    .parse(reader);

        }

        if ("http://www.exchangenetwork.net/schema/node/2".equals(namespaceURI)
                && "NodeDocumentType".equals(typeName)) {

            return net.exchangenetwork.www.schema.node._2.NodeDocumentType.Factory
                    .parse(reader);

        }

        if ("http://www.exchangenetwork.net/schema/node/2".equals(namespaceURI)
                && "ParameterType".equals(typeName)) {

            return net.exchangenetwork.www.schema.node._2.ParameterType.Factory
                    .parse(reader);

        }

        if ("http://www.exchangenetwork.net/schema/node/2".equals(namespaceURI)
                && "AttachmentType".equals(typeName)) {

            return net.exchangenetwork.www.schema.node._2.AttachmentType.Factory
                    .parse(reader);

        }

        if ("http://www.exchangenetwork.net/schema/node/2".equals(namespaceURI)
                && "TransactionStatusCode".equals(typeName)) {

            return net.exchangenetwork.www.schema.node._2.TransactionStatusCode.Factory
                    .parse(reader);

        }

        if ("http://www.w3.org/2005/05/xmlmime".equals(namespaceURI)
                && "contentType_type0".equals(typeName)) {

            return org.w3.www._2005._05.xmlmime.ContentType_type0.Factory
                    .parse(reader);

        }

        if ("http://www.exchangenetwork.net/schema/node/2".equals(namespaceURI)
                && "EncodingType".equals(typeName)) {

            return net.exchangenetwork.www.schema.node._2.EncodingType.Factory
                    .parse(reader);

        }

        if ("http://www.exchangenetwork.net/schema/node/2".equals(namespaceURI)
                && "ResultSetType".equals(typeName)) {

            return net.exchangenetwork.www.schema.node._2.ResultSetType.Factory
                    .parse(reader);

        }

        if ("http://www.exchangenetwork.net/schema/node/2".equals(namespaceURI)
                && "StatusResponseType".equals(typeName)) {

            return net.exchangenetwork.www.schema.node._2.StatusResponseType.Factory
                    .parse(reader);

        }

        if ("http://www.exchangenetwork.net/schema/node/2".equals(namespaceURI)
                && "NotificationMessageCategoryType".equals(typeName)) {

            return net.exchangenetwork.www.schema.node._2.NotificationMessageCategoryType.Factory
                    .parse(reader);

        }

        if ("http://www.exchangenetwork.net/schema/node/2".equals(namespaceURI)
                && "DocumentFormatType".equals(typeName)) {

            return net.exchangenetwork.www.schema.node._2.DocumentFormatType.Factory
                    .parse(reader);

        }

        if ("http://www.exchangenetwork.net/schema/node/2".equals(namespaceURI)
                && "GenericXmlType".equals(typeName)) {

            return net.exchangenetwork.www.schema.node._2.GenericXmlType.Factory
                    .parse(reader);

        }

        if ("http://www.exchangenetwork.net/schema/node/2".equals(namespaceURI)
                && "NotificationURIType".equals(typeName)) {

            return net.exchangenetwork.www.schema.node._2.NotificationURIType.Factory
                    .parse(reader);

        }

        if ("http://www.exchangenetwork.net/schema/node/2".equals(namespaceURI)
                && "NodeStatusCode".equals(typeName)) {

            return net.exchangenetwork.www.schema.node._2.NodeStatusCode.Factory
                    .parse(reader);

        }

        if ("http://www.exchangenetwork.net/schema/node/2".equals(namespaceURI)
                && "ErrorCodeList".equals(typeName)) {

            return net.exchangenetwork.www.schema.node._2.ErrorCodeList.Factory
                    .parse(reader);

        }

        throw new org.apache.axis2.databinding.ADBException("Unsupported type "
                + namespaceURI + " " + typeName);
    }

}