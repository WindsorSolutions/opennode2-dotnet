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

public class NodeDocument implements java.io.Serializable {

	static final long serialVersionUID = 1;

	private java.lang.String name;

	private java.lang.String type;

	private Object content;

	public NodeDocument() {
	}

	public NodeDocument(java.lang.String name, java.lang.String type,
			Object content) {
		this.name = name;
		this.type = type;
		this.content = content;
	}

	/**
	 * Gets the name value for this NodeDocument.
	 * 
	 * @return name
	 */
	public java.lang.String getName() {
		return name;
	}

	/**
	 * Sets the name value for this NodeDocument.
	 * 
	 * @param name
	 */
	public void setName(java.lang.String name) {
		this.name = name;
	}

	/**
	 * Gets the type value for this NodeDocument.
	 * 
	 * @return type
	 */
	public java.lang.String getType() {
		return type;
	}

	/**
	 * Sets the type value for this NodeDocument.
	 * 
	 * @param type
	 */
	public void setType(java.lang.String type) {
		this.type = type;
	}

	/**
	 * Gets the content value for this NodeDocument.
	 * 
	 * @return content
	 */
	public Object getContent() {
		return this.content;
	}

	/** 
	 * Sets the content value for this NodeDocument.
	 * 
	 * @param content
	 */
	public void setContent(Object content) {
		this.content = content;
	}
	
	
    public byte[] getBytesFromStream(DataHandler data) {
    	InputStream in = null;
    	byte[] out = null;
    	try {
    	    in = data.getInputStream();
    	    if (in != null) {
    		out = new byte[in.available()];
    		in.read(out);
    	    } else
    		out = new byte[0];
    	} catch (IOException ex) {
    	    System.out.println("Could not get Bytes.");
    	}
    	return out;
	}
	
	
	
	
    public byte[] retreaveContentCustom() {

    	Object locContent = this.getContent();
    	byte[] dataOUT = null;
    	if (locContent instanceof byte[])
    	    dataOUT = (byte[]) locContent;
    	else if (locContent instanceof DataHandler) {
    	    DataHandler dhData = (DataHandler) locContent;
    	    dataOUT = getBytesFromStream(dhData);
    	} else if (locContent instanceof AttachmentPart) {
    	    AttachmentPart attch = (AttachmentPart) locContent;
    	    dataOUT = getBytesFromStream(attch.getActivationDataHandler());
    	} else if (locContent instanceof String) {
    		String tempStr = (String)locContent;
    		try {
    			dataOUT = tempStr.getBytes("UTF8");
    		}catch (UnsupportedEncodingException ex){
    			throw new IllegalArgumentException(ex.getMessage());
    		}
    	} else {
    	    throw new IllegalArgumentException
    		      ("Could not convert to bytes from: " + content
    		       + " Argument type is unknown!");
    	}
    	return dataOUT;
    	
    }

	public void populateContentCustom(Object data, boolean sendAsDIME) {
		if (!sendAsDIME) {
		    content = data;
		} else {
			content = convertToDataHandler((byte[])data);
		}
	}
	
	
	
    public DataHandler convertToDataHandler(byte[] dataIN) {
		DataHandler dataOUT = null;
		ByteArrayInputStream byteStream = null;
		ManagedMemoryDataSource source = null;
		byteStream = new ByteArrayInputStream(dataIN);
		try {
		    source = new ManagedMemoryDataSource(
		    		byteStream, 
				10240,
				"application/octet-stream", 
				true);
		} catch (IOException ex) {
			System.out.println("Could not convert to attachment.");
		    return null;
		}
		dataOUT = new DataHandler(source);
		return dataOUT;
    }
	
	
	

	private java.lang.Object __equalsCalc = null;

	public synchronized boolean equals(java.lang.Object obj) {
		if (!(obj instanceof NodeDocument))
			return false;
		NodeDocument other = (NodeDocument) obj;
		if (obj == null)
			return false;
		if (this == obj)
			return true;
		if (__equalsCalc != null) {
			return (__equalsCalc == obj);
		}
		__equalsCalc = obj;
		boolean _equals;
		_equals = true
				&& ((this.name == null && other.getName() == null) || (this.name != null && this.name
						.equals(other.getName())))
				&& ((this.type == null && other.getType() == null) || (this.type != null && this.type
						.equals(other.getType())));
		__equalsCalc = null;
		return _equals;
	}

	private boolean __hashCodeCalc = false;

	public synchronized int hashCode() {
		if (__hashCodeCalc) {
			return 0;
		}
		__hashCodeCalc = true;
		int _hashCode = 1;
		if (getName() != null) {
			_hashCode += getName().hashCode();
		}
		if (getType() != null) {
			_hashCode += getType().hashCode();
		}
		if (getContent() != null) {
			for (int i = 0; i < java.lang.reflect.Array.getLength(getContent()); i++) {
				java.lang.Object obj = java.lang.reflect.Array.get(
						getContent(), i);
				if (obj != null && !obj.getClass().isArray()) {
					_hashCode += obj.hashCode();
				}
			}
		}
		__hashCodeCalc = false;
		return _hashCode;
	}

	// Type metadata
	private static org.apache.axis.description.TypeDesc typeDesc = new org.apache.axis.description.TypeDesc(
			NodeDocument.class, true);

	static {
		typeDesc.setXmlType(new javax.xml.namespace.QName(
				"http://www.ExchangeNetwork.net/schema/v1.0/node.xsd",
				"NodeDocument"));
		org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
		elemField.setFieldName("name");
		elemField.setXmlName(new javax.xml.namespace.QName(
				"http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", "name"));
		elemField.setXmlType(new javax.xml.namespace.QName(
				"http://www.w3.org/2001/XMLSchema", "string"));
		elemField.setNillable(false);
		typeDesc.addFieldDesc(elemField);
		elemField = new org.apache.axis.description.ElementDesc();
		elemField.setFieldName("type");
		elemField.setXmlName(new javax.xml.namespace.QName(
				"http://www.ExchangeNetwork.net/schema/v1.0/node.xsd", "type"));
		elemField.setXmlType(new javax.xml.namespace.QName(
				"http://www.w3.org/2001/XMLSchema", "string"));
		elemField.setNillable(false);
		typeDesc.addFieldDesc(elemField);
		elemField = new org.apache.axis.description.ElementDesc();
		elemField.setFieldName("content");
		elemField.setXmlName(new javax.xml.namespace.QName(
				"http://www.ExchangeNetwork.net/schema/v1.0/node.xsd",
				"content"));
		elemField.setXmlType(new javax.xml.namespace.QName(
				"http://www.w3.org/2001/XMLSchema", "base64Binary"));
		elemField.setNillable(false);
		typeDesc.addFieldDesc(elemField);
	}

	/**
	 * Return type metadata object
	 */
	public static org.apache.axis.description.TypeDesc getTypeDesc() {
		return typeDesc;
	}

	/**
	 * Get Custom Serializer
	 */
	public static org.apache.axis.encoding.Serializer getSerializer(
			java.lang.String mechType, java.lang.Class _javaType,
			javax.xml.namespace.QName _xmlType) {
		return new org.apache.axis.encoding.ser.BeanSerializer(_javaType,
				_xmlType, typeDesc);
	}

	/**
	 * Get Custom Deserializer
	 */
	public static org.apache.axis.encoding.Deserializer getDeserializer(
			java.lang.String mechType, java.lang.Class _javaType,
			javax.xml.namespace.QName _xmlType) {
		return new org.apache.axis.encoding.ser.BeanDeserializer(_javaType,
				_xmlType, typeDesc);
	}

}