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

import java.io.Serializable;
import java.lang.reflect.Array;
import java.util.Arrays;

import javax.xml.namespace.QName;

import org.apache.axis.description.TypeDesc;
import org.apache.axis.encoding.Deserializer;
import org.apache.axis.encoding.Serializer;
import org.apache.axis.encoding.ser.BeanDeserializer;
import org.apache.axis.encoding.ser.BeanSerializer;
import org.apache.axis.message.MessageElement;

public class QueryResult implements Serializable {

    private static final long serialVersionUID = 1L;
    private static TypeDesc typeDesc;
    private MessageElement[] any;
    private Object equalsCalc;
    private boolean hashCodeCalc;

    static {
        typeDesc = new TypeDesc(com.windsor.node.ws1.wsdl.QueryResult.class);
        typeDesc.setXmlType(new QName(
                "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd",
                "QueryResult"));
    }

    public QueryResult() {
        equalsCalc = null;
        hashCodeCalc = false;
    }

    public MessageElement[] getAny() {
        return any;
    }

    public void setAny(MessageElement[] any) {
        this.any = any;
    }

    public synchronized boolean equals(Object obj) {
        if (!(obj instanceof QueryResult)) {
            return false;
        }
        QueryResult other = (QueryResult) obj;
        if (obj == null) {
            return false;
        }
        if (this == obj) {
            return true;
        }
        if (equalsCalc != null) {
            return equalsCalc == obj;
        } else {
            equalsCalc = obj;
            boolean isEqual = any == null && other.getAny() == null
                    || any != null && Arrays.equals(any, other.getAny());
            equalsCalc = null;
            return isEqual;
        }
    }

    public synchronized int hashCode() {
        if (hashCodeCalc) {
            return 0;
        }
        hashCodeCalc = true;
        int code = 1;
        if (getAny() != null) {
            for (int i = 0; i < Array.getLength(getAny()); i++) {
                Object obj = Array.get(getAny(), i);
                if (obj != null && !obj.getClass().isArray()) {
                    code += obj.hashCode();
                }
            }

        }
        hashCodeCalc = false;
        return code;
    }

    public static TypeDesc getTypeDesc() {
        return typeDesc;
    }

    public static Serializer getSerializer(String mechType, Class javaType,
            QName xmlType) {
        return new BeanSerializer(javaType, xmlType, typeDesc);
    }

    public static Deserializer getDeserializer(String mechType,
            Class javaType, QName xmlType) {
        return new BeanDeserializer(javaType, xmlType, typeDesc);
    }
}