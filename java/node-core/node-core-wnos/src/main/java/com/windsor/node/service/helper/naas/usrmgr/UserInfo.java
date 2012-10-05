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
 * UserInfo.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.3 Oct 05, 2005 (05:23:37 EDT) WSDL2Java emitter.
 */

package com.windsor.node.service.helper.naas.usrmgr;

public class UserInfo implements java.io.Serializable {

    private static final long serialVersionUID = 1;

    private java.lang.String userId;

    private java.lang.String userGroup;

    private java.lang.String owner;

    private java.lang.String node;

    private java.lang.String affiliate;

    public UserInfo() {
    }

    public UserInfo(java.lang.String userId, java.lang.String userGroup,
            java.lang.String owner, java.lang.String node,
            java.lang.String affiliate) {
        this.userId = userId;
        this.userGroup = userGroup;
        this.owner = owner;
        this.node = node;
        this.affiliate = affiliate;
    }

    /**
     * Gets the userId value for this UserInfo.
     * 
     * @return userId
     */
    public java.lang.String getUserId() {
        return userId;
    }

    /**
     * Sets the userId value for this UserInfo.
     * 
     * @param userId
     */
    public void setUserId(java.lang.String userId) {
        this.userId = userId;
    }

    /**
     * Gets the userGroup value for this UserInfo.
     * 
     * @return userGroup
     */
    public java.lang.String getUserGroup() {
        return userGroup;
    }

    /**
     * Sets the userGroup value for this UserInfo.
     * 
     * @param userGroup
     */
    public void setUserGroup(java.lang.String userGroup) {
        this.userGroup = userGroup;
    }

    /**
     * Gets the owner value for this UserInfo.
     * 
     * @return owner
     */
    public java.lang.String getOwner() {
        return owner;
    }

    /**
     * Sets the owner value for this UserInfo.
     * 
     * @param owner
     */
    public void setOwner(java.lang.String owner) {
        this.owner = owner;
    }

    /**
     * Gets the node value for this UserInfo.
     * 
     * @return node
     */
    public java.lang.String getNode() {
        return node;
    }

    /**
     * Sets the node value for this UserInfo.
     * 
     * @param node
     */
    public void setNode(java.lang.String node) {
        this.node = node;
    }

    /**
     * Gets the affiliate value for this UserInfo.
     * 
     * @return affiliate
     */
    public java.lang.String getAffiliate() {
        return affiliate;
    }

    /**
     * Sets the affiliate value for this UserInfo.
     * 
     * @param affiliate
     */
    public void setAffiliate(java.lang.String affiliate) {
        this.affiliate = affiliate;
    }

    private java.lang.Object __equalsCalc = null;

    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof UserInfo))
            return false;
        UserInfo other = (UserInfo) obj;
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
                && ((this.userId == null && other.getUserId() == null) || (this.userId != null && this.userId
                        .equals(other.getUserId())))
                && ((this.userGroup == null && other.getUserGroup() == null) || (this.userGroup != null && this.userGroup
                        .equals(other.getUserGroup())))
                && ((this.owner == null && other.getOwner() == null) || (this.owner != null && this.owner
                        .equals(other.getOwner())))
                && ((this.node == null && other.getNode() == null) || (this.node != null && this.node
                        .equals(other.getNode())))
                && ((this.affiliate == null && other.getAffiliate() == null) || (this.affiliate != null && this.affiliate
                        .equals(other.getAffiliate())));
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
        if (getUserId() != null) {
            _hashCode += getUserId().hashCode();
        }
        if (getUserGroup() != null) {
            _hashCode += getUserGroup().hashCode();
        }
        if (getOwner() != null) {
            _hashCode += getOwner().hashCode();
        }
        if (getNode() != null) {
            _hashCode += getNode().hashCode();
        }
        if (getAffiliate() != null) {
            _hashCode += getAffiliate().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc = new org.apache.axis.description.TypeDesc(
            UserInfo.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "UserInfo"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userId");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "UserId"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userGroup");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "UserGroup"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("owner");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "Owner"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("node");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "Node"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("affiliate");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "Affiliate"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
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