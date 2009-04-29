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

package com.windsor.node.ws2.util;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;

import javax.activation.DataHandler;
import javax.mail.internet.MimeUtility;
import javax.xml.namespace.QName;

import net.exchangenetwork.www.schema.node._2.AttachmentType;
import net.exchangenetwork.www.schema.node._2.DocumentFormatType;
import net.exchangenetwork.www.schema.node._2.GenericXmlType;
import net.exchangenetwork.www.schema.node._2.NodeDocumentType;

import org.apache.axiom.attachments.ByteArrayDataSource;
import org.apache.axiom.om.OMAbstractFactory;
import org.apache.axiom.om.OMElement;
import org.apache.axiom.om.impl.llom.util.AXIOMUtil;
import org.apache.axiom.om.util.Base64;
import org.apache.axis2.databinding.types.Id;
import org.apache.log4j.Logger;
import org.w3.www._2005._05.xmlmime.ContentType_type0;

import sun.misc.BASE64Decoder;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.util.CommonContentAndFormatConverter;
import com.windsor.node.ws2.Endpoint2FaultMessage;

public class NodeUtil {

	private static final Logger logger = Logger.getLogger(NodeUtil.class);

	public static Document getDocumentFromNodeDocumentType(
			NodeDocumentType wsdlDoc) {

		try {

			Document wnosDoc = new Document();
			wnosDoc.setDocumentId(null);
			wnosDoc.setDocumentName(wsdlDoc.getDocumentName());
			wnosDoc.setType(CommonContentAndFormatConverter.convert(wsdlDoc
					.getDocumentFormat().getValue()));
			wnosDoc.setContent(inputStreamToBytes(wsdlDoc.getDocumentContent()
					.getBase64Binary().getInputStream()));

			// AttachmentType content = wsdlDoc.getDocumentContent();
			// DataHandler handler = content.getBase64Binary();
			//
			// ByteArrayOutputStream baos = new ByteArrayOutputStream();
			// ObjectOutputStream so = new ObjectOutputStream(baos);
			// handler.writeTo(so);
			// so.flush();
			// so.close();
			//
			// // Decode the bytes
			// ByteArrayInputStream decodedStream = new
			// ByteArrayInputStream(baos
			// .toByteArray());
			// wnosDoc.setContent(new
			// BASE64Decoder().decodeBuffer(decodedStream));
			// decodedStream.close();

			return wnosDoc;

		} catch (Exception ex) {
			throw new RuntimeException(ex);
		}

	}

	public static byte[] encode(byte[] b) {
		try {
			ByteArrayOutputStream baos = new ByteArrayOutputStream();
			OutputStream b64os = MimeUtility.encode(baos, "Base64");
			b64os.write(b);
			b64os.close();
			return baos.toByteArray();
		} catch (Exception ex) {
			throw new RuntimeException("Error while encoding bytes", ex);
		}
	}

	public static byte[] decode(byte[] b) {
		try {
			ByteArrayInputStream bais = new ByteArrayInputStream(b);
			InputStream b64is = MimeUtility.decode(bais, "Base64");
			byte[] tmp = new byte[b.length];
			int n = b64is.read(tmp);
			byte[] res = new byte[n];
			System.arraycopy(tmp, 0, res, 0, n);
			return res;
		} catch (Exception ex) {
			throw new RuntimeException("Error while decoding bytes", ex);
		}
	}

	public static byte[] inputStreamToBytes(InputStream in) throws IOException {

		try {
			ByteArrayOutputStream out = new ByteArrayOutputStream(1024);
			byte[] buffer = new byte[1024];
			int len;

			while ((len = in.read(buffer)) >= 0)
				out.write(buffer, 0, len);

			in.close();
			out.close();
			return out.toByteArray();
		} catch (IOException ex) {
			throw new RuntimeException(
					"Error while converting stream to bytes", ex);
		}
	}

	/**
	 * getGenericXmlType
	 * 
	 * @param type
	 * @param content
	 * @return
	 * @throws Endpoint2FaultMessage
	 */
	public static GenericXmlType getGenericXmlType(CommonContentType type,
			byte[] content) {

		logger.error("[getGenericXmlType]: type: " + type);

		try {
			GenericXmlType gxt = new GenericXmlType();

			if (type == CommonContentType.XML) {

				gxt.setFormat(DocumentFormatType.XML);
				gxt.setExtraElement(AXIOMUtil.stringToOM(new String(content,
						"UTF-8")));

			} else if (type == CommonContentType.ZIP) {

				OMElement zip = OMAbstractFactory.getOMFactory()
						.createOMElement(new QName("base64Zip"));
				zip.setText(Base64.encode(content));
				gxt.setFormat(DocumentFormatType.ZIP);
				gxt.setExtraElement(zip);

			} else {

				gxt.setFormat(DocumentFormatType.OTHER);
				gxt.setExtraElement(AXIOMUtil.stringToOM(new String(content)));

			}

			return gxt;

		} catch (Exception ex) {
			logger.error("[getGenericXmlType]: ERROR: " + ex.getMessage());
			throw new RuntimeException(ex);
		}

	}

	public static Document getBytesFromGenericXmlType(GenericXmlType content) {

		logger.debug("[getBytesFromGenericXmlType]:");

		try {

			Document resultDoc = new Document();

			// If the content is a zip it can't be parsed as XMl
			// so, to keep it compress, assuming there was a good reason
			// for this to be ZIP, we keep it this way for as long as possible
			if (content.getFormat() == DocumentFormatType.ZIP) {
				resultDoc.setType(CommonContentType.ZIP);

				// Decode from base64 first in order to keep it clean.
				resultDoc.setContent(new BASE64Decoder().decodeBuffer(content
						.getExtraElement().getText()));

			} else {
				resultDoc.setType(CommonContentType.XML);
				resultDoc.setContent(content.getExtraElement().toString()
						.getBytes("UTF-8"));
			}

			return resultDoc;

		} catch (Exception ex) {
			logger.error("[getBytesFromGenericXmlType]: ERROR: "
					+ ex.getMessage());
			throw new RuntimeException(ex);
		}

	}

	public static NodeDocumentType getNodeDocumentFromWnosDoc(Document wnosDoc) {

		logger.debug("WNOS Doc: " + wnosDoc);

		try {

			NodeDocumentType newDoc = new NodeDocumentType();
			AttachmentType attachment = new AttachmentType();

			// Document attributes
			newDoc.setDocumentFormat(DocumentFormatType.Factory
					.fromValue(wnosDoc.getType().getName()));

			newDoc.setDocumentId(new Id(wnosDoc.getDocumentId()));
			newDoc.setDocumentName(wnosDoc.getDocumentName());

			// Content Type
			logger.error("Creating datasource...");
			ContentType_type0 contentType = new ContentType_type0();
			if (wnosDoc.getType().equals(CommonContentType.XML_STR)) {
				contentType.setContentType_type0("application/xml");
			} else {
				contentType.setContentType_type0("application/octet-stream");
			}

			// Actual attachment
			logger.error("Creating datasource...");
			ByteArrayDataSource bads = new ByteArrayDataSource(wnosDoc
					.getContent());
			logger.error("Creating data handler...");
			attachment.setBase64Binary(new DataHandler(bads));

			// Final assembly of object
			attachment.setContentType(contentType);
			newDoc.setDocumentContent(attachment);

			return newDoc;

		} catch (Exception ex) {
			logger.error("[getNodeDocumentFromWnosDoc]: ERROR: "
					+ ex.getMessage());
			throw new RuntimeException(ex);
		}
	}
}