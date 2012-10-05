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

import org.apache.axis.message.MessageElement;
import org.w3c.dom.Document;
import org.w3c.dom.Element;

public abstract class QuerylResultConverter {

	public QuerylResultConverter() {
	}

	public static String validateWellformness(String result) throws Exception {
		XMLBytesConverter.ToDOM(result.getBytes());
		return result;
	}

	public static Document ToW3CDocument(QueryResult resultVO) throws Exception {
		return ToW3CDocument(resultVO.getAny());
	}

	public static Element ToDOM(QueryResult resultVO) throws Exception {
		return ToDOM(resultVO.getAny());
	}

	public static byte[] ToByteArray(QueryResult resultVO) throws Exception {
		return ToByteArray(resultVO.getAny());
	}

	public static Document ToW3CDocument(MessageElement messageElementArray[])
			throws Exception {
		if (messageElementArray == null || messageElementArray.length == 0)
			return null;
		else
			return messageElementArray[0].getAsDocument();
	}

	public static byte[] ToByteArray(MessageElement messageElementArray[])
			throws Exception {
		return XMLBytesConverter
				.ToByteArray(ToW3CDocument(messageElementArray));
	}

	public static Element ToDOM(MessageElement messageElementArray[])
			throws Exception {
		Document doc = ToW3CDocument(messageElementArray);
		return doc == null ? null : doc.getDocumentElement();
	}

	/**
	 * @deprecated Method TosqlResult is deprecated
	 */

	public static QueryResult TosqlResult(byte byteArray[]) throws Exception {
		QueryResult doc = new QueryResult();
		MessageElement messageEl = new MessageElement(XMLBytesConverter
				.ToDOM(byteArray));
		MessageElement messageElArray[] = new MessageElement[1];
		messageElArray[0] = messageEl;
		doc.setAny(messageElArray);
		return doc;
	}

	public static String validateAndConverToString(byte byteArray[])
			throws Exception {
		return new String(byteArray);
	}
}