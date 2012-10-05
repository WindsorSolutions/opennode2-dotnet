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
 * SchematronType.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.3 Oct 05, 2005 (05:23:37 EDT) WSDL2Java emitter.
 */

package com.windsor.node.service.helper.schematron;

public class SchematronType implements java.io.Serializable {

    private static final long serialVersionUID = 1;

    private java.lang.String _value_;
    private static java.util.HashMap _table_ = new java.util.HashMap();

    // Constructor
    protected SchematronType(java.lang.String value) {
        _value_ = value;
        _table_.put(_value_, this);
    }

    public static final java.lang.String _AQS_Submission_v2_0 = "AQS_Submission_v2_0";
    public static final java.lang.String _AQS_Submission_v1_1 = "AQS_Submission_v1_1";
    public static final java.lang.String _NEI_AreaNonroad_v3_0 = "NEI_AreaNonroad_v3_0";
    public static final java.lang.String _NEI_Biogenic_v3_0 = "NEI_Biogenic_v3_0";
    public static final java.lang.String _NEI_Onroad_v3_0 = "NEI_Onroad_v3_0";
    public static final java.lang.String _NEI_Point_v3_0 = "NEI_Point_v3_0";
    public static final java.lang.String _OWWQX_v1_0 = "OWWQX_v1_0";
    public static final java.lang.String _VERIFY_MotorcycleSubmission_v2_0 = "VERIFY_MotorcycleSubmission_v2_0";
    public static final java.lang.String _VERIFY_CommonServices_v1_0 = "VERIFY_CommonServices_v1_0";

    public static final SchematronType AQS_Submission_v2_0 = new SchematronType(
            _AQS_Submission_v2_0);
    public static final SchematronType AQS_Submission_v1_1 = new SchematronType(
            _AQS_Submission_v1_1);
    public static final SchematronType NEI_AreaNonroad_v3_0 = new SchematronType(
            _NEI_AreaNonroad_v3_0);
    public static final SchematronType NEI_Biogenic_v3_0 = new SchematronType(
            _NEI_Biogenic_v3_0);
    public static final SchematronType NEI_Onroad_v3_0 = new SchematronType(
            _NEI_Onroad_v3_0);
    public static final SchematronType NEI_Point_v3_0 = new SchematronType(
            _NEI_Point_v3_0);
    public static final SchematronType OWWQX_v1_0 = new SchematronType(
            _OWWQX_v1_0);
    public static final SchematronType VERIFY_MotorcycleSubmission_v2_0 = new SchematronType(
            _VERIFY_MotorcycleSubmission_v2_0);
    public static final SchematronType VERIFY_CommonServices_v1_0 = new SchematronType(
            _VERIFY_CommonServices_v1_0);

    public java.lang.String getValue() {
        return _value_;
    }

    public static SchematronType fromValue(java.lang.String value)
            throws java.lang.IllegalArgumentException {
        SchematronType enumeration = (SchematronType) _table_.get(value);
        if (enumeration == null)
            throw new java.lang.IllegalArgumentException();
        return enumeration;
    }

    public static SchematronType fromString(java.lang.String value)
            throws java.lang.IllegalArgumentException {
        return fromValue(value);
    }

    public boolean equals(java.lang.Object obj) {
        return (obj == this);
    }

    public int hashCode() {
        return toString().hashCode();
    }

    public java.lang.String toString() {
        return _value_;
    }

    public java.lang.Object readResolve() throws java.io.ObjectStreamException {
        return fromValue(_value_);
    }

    public static org.apache.axis.encoding.Serializer getSerializer(
            java.lang.String mechType, java.lang.Class _javaType,
            javax.xml.namespace.QName _xmlType) {
        return new org.apache.axis.encoding.ser.EnumSerializer(_javaType,
                _xmlType);
    }

    public static org.apache.axis.encoding.Deserializer getDeserializer(
            java.lang.String mechType, java.lang.Class _javaType,
            javax.xml.namespace.QName _xmlType) {
        return new org.apache.axis.encoding.ser.EnumDeserializer(_javaType,
                _xmlType);
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc = new org.apache.axis.description.TypeDesc(
            SchematronType.class);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName(
                "http://www.neien.org/schema/v1.0/validator.xsd",
                "SchematronType"));
    }

    /**
     * Return type metadata object
     */
    public static org.apache.axis.description.TypeDesc getTypeDesc() {
        return typeDesc;
    }

}