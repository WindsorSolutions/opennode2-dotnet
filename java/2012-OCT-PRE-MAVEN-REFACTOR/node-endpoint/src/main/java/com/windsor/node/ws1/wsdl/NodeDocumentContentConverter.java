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

package com.windsor.node.ws1.wsdl;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.UnsupportedEncodingException;

import javax.activation.DataHandler;

import org.apache.axis.attachments.AttachmentPart;
import org.apache.axis.attachments.ManagedMemoryDataSource;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public final class NodeDocumentContentConverter {

    public static final int CONTENT_TYPE_BYTES = 0;
    public static final int CONTENT_TYPE_ATTACHMENT = 1;

    public static final String OCTET_STREAM = "application/octet-stream";
    public static final String ATTACHMENT_TYPE_TEXT_NAME = "text/plain";
    public static final String ATTACHMENT_TYPE_XML_NAME = "text/xml";
    public static final String ATTACHMENT_TYPE_BIN_NAME = OCTET_STREAM;
    public static final String ATTACHMENT_TYPE_ZIP_NAME = OCTET_STREAM;
    public static final String ATTACHMENT_TYPE_OTHER_NAME = OCTET_STREAM;

    public static final String[] ATTACHMENT_TYPE_NAMES = {
            ATTACHMENT_TYPE_TEXT_NAME, ATTACHMENT_TYPE_XML_NAME,
            ATTACHMENT_TYPE_BIN_NAME, ATTACHMENT_TYPE_ZIP_NAME,
            ATTACHMENT_TYPE_OTHER_NAME };

    private static final int MAX_CACHED_BYTES = 10240;

    /*private static final Logger LOGGER = LoggerFactory
            .getLogger(com.windsor.node.ws1.wsdl.NodeDocumentContentConverter.class);*/

    private NodeDocumentContentConverter() {
    }

    public static byte[] convertToBytes(NodeDocument doc) {
        Logger LOGGER = LoggerFactory.getLogger(com.windsor.node.ws1.wsdl.NodeDocumentContentConverter.class);
        Object content = null;
        byte[] dataOut = null;

        LOGGER.debug("getting content");
        content = doc.getContent();

        if (content instanceof byte[]) {
            LOGGER.debug("content byte");
            dataOut = (byte[]) content;

        } else if (content instanceof DataHandler) {
            LOGGER.debug("content DataHandler");
            DataHandler dhData = (DataHandler) content;
            dataOut = getBytesFromStream(dhData);

        } else if (content instanceof AttachmentPart) {
            LOGGER.debug("content AttachmentPart");
            AttachmentPart attch = (AttachmentPart) content;
            dataOut = getBytesFromStream(attch.getActivationDataHandler());

        } else if (content instanceof String) {
            LOGGER.debug("content String");
            String attchStr = (String) content;
            try {
                dataOut = attchStr.getBytes("UTF-8");
            } catch (UnsupportedEncodingException uee) {
                throw new RuntimeException(
                        "Error while converting string to bytes: "
                                + uee.getMessage(), uee);
            }
        } else {
            throw new IllegalArgumentException(
                    "Could not convert to bytes from: [" + content
                            + "] Argument type is unknown!");
        }
        return dataOut;
    }

    public static byte[] getBytesFromStream(DataHandler data) {
        Logger LOGGER = LoggerFactory.getLogger(com.windsor.node.ws1.wsdl.NodeDocumentContentConverter.class);
        LOGGER.debug("getBytesFromStream: in");
        InputStream in = null;
        byte[] out = null;
        if (data == null) {
            throw new RuntimeException("Null DataHandler");
        }
        LOGGER.debug("Class: " + data.getClass());
        try {
            in = data.getInputStream();
            if (in != null) {
                out = new byte[in.available()];
                in.read(out);
            } else {
                out = new byte[0];
            }
        } catch (IOException iex) {
            LOGGER.error("Could not get Bytes:", iex);
        } catch (Exception ex) {
            LOGGER.error("Error while getting bytes: ", ex);
        }
        LOGGER.debug("getBytesFromStream: out");
        return out;
    }

    public static DataHandler convertToAttachment(byte[] dataIN, String dataType) {
        Logger LOGGER = LoggerFactory.getLogger(com.windsor.node.ws1.wsdl.NodeDocumentContentConverter.class);
        LOGGER.debug("[convertToAttachment]");
        DataHandler dataOUT = null;
        ByteArrayInputStream byteStream = null;
        ManagedMemoryDataSource source = null;
        byteStream = new ByteArrayInputStream(dataIN);
        try {
            source = new ManagedMemoryDataSource(byteStream, MAX_CACHED_BYTES,
                    getDataTypeName(dataType), true);
        } catch (IOException ex) {
            LOGGER.debug("Could not convert to attachment.");
            return null;
        }
        dataOUT = new DataHandler(source);
        return dataOUT;
    }

    private static String getDataTypeName(String dataType) {
        Logger LOGGER = LoggerFactory.getLogger(com.windsor.node.ws1.wsdl.NodeDocumentContentConverter.class);
        LOGGER.debug("getDataTypeName()");
        String out = ATTACHMENT_TYPE_OTHER_NAME;
        if (dataType.equalsIgnoreCase("flat")) {
            out = ATTACHMENT_TYPE_TEXT_NAME;
        } else if (dataType.equalsIgnoreCase("xml")) {
            out = ATTACHMENT_TYPE_XML_NAME;
        } else if (dataType.equalsIgnoreCase("bin")) {
            out = ATTACHMENT_TYPE_BIN_NAME;
        } else if (dataType.equalsIgnoreCase("zip")) {
            out = ATTACHMENT_TYPE_ZIP_NAME;
        } else {
            out = ATTACHMENT_TYPE_TEXT_NAME;
        }
        return out;
    }

}
