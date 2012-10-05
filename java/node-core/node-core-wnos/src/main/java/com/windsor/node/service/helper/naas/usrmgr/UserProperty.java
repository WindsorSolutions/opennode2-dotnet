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
 * UserProperty.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.3 Oct 05, 2005 (05:23:37 EDT) WSDL2Java emitter.
 */

package com.windsor.node.service.helper.naas.usrmgr;

public class UserProperty implements java.io.Serializable {

    private static final long serialVersionUID = 1;

    private java.lang.String userId;

    private java.lang.String commonName;

    private java.lang.String organization;

    private java.lang.String organizationUnit;

    private java.lang.String address;

    private java.lang.String city;

    private java.lang.String state;

    private java.lang.String zipCode;

    private java.lang.String phone;

    private java.lang.String supervisor;

    private java.lang.String supervisorPhone;

    private java.lang.String userData;

    private java.lang.String securityLevel;

    private java.lang.String certificateStatus;

    private java.lang.String lastChange;

    public UserProperty() {
    }

    public UserProperty(java.lang.String userId, java.lang.String commonName,
            java.lang.String organization, java.lang.String organizationUnit,
            java.lang.String address, java.lang.String city,
            java.lang.String state, java.lang.String zipCode,
            java.lang.String phone, java.lang.String supervisor,
            java.lang.String supervisorPhone, java.lang.String userData,
            java.lang.String securityLevel, java.lang.String certificateStatus,
            java.lang.String lastChange) {
        this.userId = userId;
        this.commonName = commonName;
        this.organization = organization;
        this.organizationUnit = organizationUnit;
        this.address = address;
        this.city = city;
        this.state = state;
        this.zipCode = zipCode;
        this.phone = phone;
        this.supervisor = supervisor;
        this.supervisorPhone = supervisorPhone;
        this.userData = userData;
        this.securityLevel = securityLevel;
        this.certificateStatus = certificateStatus;
        this.lastChange = lastChange;
    }

    /**
     * Gets the userId value for this UserProperty.
     * 
     * @return userId
     */
    public java.lang.String getUserId() {
        return userId;
    }

    /**
     * Sets the userId value for this UserProperty.
     * 
     * @param userId
     */
    public void setUserId(java.lang.String userId) {
        this.userId = userId;
    }

    /**
     * Gets the commonName value for this UserProperty.
     * 
     * @return commonName
     */
    public java.lang.String getCommonName() {
        return commonName;
    }

    /**
     * Sets the commonName value for this UserProperty.
     * 
     * @param commonName
     */
    public void setCommonName(java.lang.String commonName) {
        this.commonName = commonName;
    }

    /**
     * Gets the organization value for this UserProperty.
     * 
     * @return organization
     */
    public java.lang.String getOrganization() {
        return organization;
    }

    /**
     * Sets the organization value for this UserProperty.
     * 
     * @param organization
     */
    public void setOrganization(java.lang.String organization) {
        this.organization = organization;
    }

    /**
     * Gets the organizationUnit value for this UserProperty.
     * 
     * @return organizationUnit
     */
    public java.lang.String getOrganizationUnit() {
        return organizationUnit;
    }

    /**
     * Sets the organizationUnit value for this UserProperty.
     * 
     * @param organizationUnit
     */
    public void setOrganizationUnit(java.lang.String organizationUnit) {
        this.organizationUnit = organizationUnit;
    }

    /**
     * Gets the address value for this UserProperty.
     * 
     * @return address
     */
    public java.lang.String getAddress() {
        return address;
    }

    /**
     * Sets the address value for this UserProperty.
     * 
     * @param address
     */
    public void setAddress(java.lang.String address) {
        this.address = address;
    }

    /**
     * Gets the city value for this UserProperty.
     * 
     * @return city
     */
    public java.lang.String getCity() {
        return city;
    }

    /**
     * Sets the city value for this UserProperty.
     * 
     * @param city
     */
    public void setCity(java.lang.String city) {
        this.city = city;
    }

    /**
     * Gets the state value for this UserProperty.
     * 
     * @return state
     */
    public java.lang.String getState() {
        return state;
    }

    /**
     * Sets the state value for this UserProperty.
     * 
     * @param state
     */
    public void setState(java.lang.String state) {
        this.state = state;
    }

    /**
     * Gets the zipCode value for this UserProperty.
     * 
     * @return zipCode
     */
    public java.lang.String getZipCode() {
        return zipCode;
    }

    /**
     * Sets the zipCode value for this UserProperty.
     * 
     * @param zipCode
     */
    public void setZipCode(java.lang.String zipCode) {
        this.zipCode = zipCode;
    }

    /**
     * Gets the phone value for this UserProperty.
     * 
     * @return phone
     */
    public java.lang.String getPhone() {
        return phone;
    }

    /**
     * Sets the phone value for this UserProperty.
     * 
     * @param phone
     */
    public void setPhone(java.lang.String phone) {
        this.phone = phone;
    }

    /**
     * Gets the supervisor value for this UserProperty.
     * 
     * @return supervisor
     */
    public java.lang.String getSupervisor() {
        return supervisor;
    }

    /**
     * Sets the supervisor value for this UserProperty.
     * 
     * @param supervisor
     */
    public void setSupervisor(java.lang.String supervisor) {
        this.supervisor = supervisor;
    }

    /**
     * Gets the supervisorPhone value for this UserProperty.
     * 
     * @return supervisorPhone
     */
    public java.lang.String getSupervisorPhone() {
        return supervisorPhone;
    }

    /**
     * Sets the supervisorPhone value for this UserProperty.
     * 
     * @param supervisorPhone
     */
    public void setSupervisorPhone(java.lang.String supervisorPhone) {
        this.supervisorPhone = supervisorPhone;
    }

    /**
     * Gets the userData value for this UserProperty.
     * 
     * @return userData
     */
    public java.lang.String getUserData() {
        return userData;
    }

    /**
     * Sets the userData value for this UserProperty.
     * 
     * @param userData
     */
    public void setUserData(java.lang.String userData) {
        this.userData = userData;
    }

    /**
     * Gets the securityLevel value for this UserProperty.
     * 
     * @return securityLevel
     */
    public java.lang.String getSecurityLevel() {
        return securityLevel;
    }

    /**
     * Sets the securityLevel value for this UserProperty.
     * 
     * @param securityLevel
     */
    public void setSecurityLevel(java.lang.String securityLevel) {
        this.securityLevel = securityLevel;
    }

    /**
     * Gets the certificateStatus value for this UserProperty.
     * 
     * @return certificateStatus
     */
    public java.lang.String getCertificateStatus() {
        return certificateStatus;
    }

    /**
     * Sets the certificateStatus value for this UserProperty.
     * 
     * @param certificateStatus
     */
    public void setCertificateStatus(java.lang.String certificateStatus) {
        this.certificateStatus = certificateStatus;
    }

    /**
     * Gets the lastChange value for this UserProperty.
     * 
     * @return lastChange
     */
    public java.lang.String getLastChange() {
        return lastChange;
    }

    /**
     * Sets the lastChange value for this UserProperty.
     * 
     * @param lastChange
     */
    public void setLastChange(java.lang.String lastChange) {
        this.lastChange = lastChange;
    }

    private java.lang.Object __equalsCalc = null;

    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof UserProperty))
            return false;
        UserProperty other = (UserProperty) obj;
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
                && ((this.commonName == null && other.getCommonName() == null) || (this.commonName != null && this.commonName
                        .equals(other.getCommonName())))
                && ((this.organization == null && other.getOrganization() == null) || (this.organization != null && this.organization
                        .equals(other.getOrganization())))
                && ((this.organizationUnit == null && other
                        .getOrganizationUnit() == null) || (this.organizationUnit != null && this.organizationUnit
                        .equals(other.getOrganizationUnit())))
                && ((this.address == null && other.getAddress() == null) || (this.address != null && this.address
                        .equals(other.getAddress())))
                && ((this.city == null && other.getCity() == null) || (this.city != null && this.city
                        .equals(other.getCity())))
                && ((this.state == null && other.getState() == null) || (this.state != null && this.state
                        .equals(other.getState())))
                && ((this.zipCode == null && other.getZipCode() == null) || (this.zipCode != null && this.zipCode
                        .equals(other.getZipCode())))
                && ((this.phone == null && other.getPhone() == null) || (this.phone != null && this.phone
                        .equals(other.getPhone())))
                && ((this.supervisor == null && other.getSupervisor() == null) || (this.supervisor != null && this.supervisor
                        .equals(other.getSupervisor())))
                && ((this.supervisorPhone == null && other.getSupervisorPhone() == null) || (this.supervisorPhone != null && this.supervisorPhone
                        .equals(other.getSupervisorPhone())))
                && ((this.userData == null && other.getUserData() == null) || (this.userData != null && this.userData
                        .equals(other.getUserData())))
                && ((this.securityLevel == null && other.getSecurityLevel() == null) || (this.securityLevel != null && this.securityLevel
                        .equals(other.getSecurityLevel())))
                && ((this.certificateStatus == null && other
                        .getCertificateStatus() == null) || (this.certificateStatus != null && this.certificateStatus
                        .equals(other.getCertificateStatus())))
                && ((this.lastChange == null && other.getLastChange() == null) || (this.lastChange != null && this.lastChange
                        .equals(other.getLastChange())));
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
        if (getCommonName() != null) {
            _hashCode += getCommonName().hashCode();
        }
        if (getOrganization() != null) {
            _hashCode += getOrganization().hashCode();
        }
        if (getOrganizationUnit() != null) {
            _hashCode += getOrganizationUnit().hashCode();
        }
        if (getAddress() != null) {
            _hashCode += getAddress().hashCode();
        }
        if (getCity() != null) {
            _hashCode += getCity().hashCode();
        }
        if (getState() != null) {
            _hashCode += getState().hashCode();
        }
        if (getZipCode() != null) {
            _hashCode += getZipCode().hashCode();
        }
        if (getPhone() != null) {
            _hashCode += getPhone().hashCode();
        }
        if (getSupervisor() != null) {
            _hashCode += getSupervisor().hashCode();
        }
        if (getSupervisorPhone() != null) {
            _hashCode += getSupervisorPhone().hashCode();
        }
        if (getUserData() != null) {
            _hashCode += getUserData().hashCode();
        }
        if (getSecurityLevel() != null) {
            _hashCode += getSecurityLevel().hashCode();
        }
        if (getCertificateStatus() != null) {
            _hashCode += getCertificateStatus().hashCode();
        }
        if (getLastChange() != null) {
            _hashCode += getLastChange().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc = new org.apache.axis.description.TypeDesc(
            UserProperty.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "UserProperty"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userId");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "UserId"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("commonName");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "CommonName"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("organization");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "Organization"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("organizationUnit");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "OrganizationUnit"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("address");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "Address"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("city");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "City"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("state");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "State"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "StateId"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("zipCode");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "ZipCode"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("phone");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "Phone"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("supervisor");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "Supervisor"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("supervisorPhone");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "SupervisorPhone"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("userData");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "UserData"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("securityLevel");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "SecurityLevel"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("certificateStatus");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "CertificateStatus"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("lastChange");
        elemField.setXmlName(new javax.xml.namespace.QName(
                "http://neien.org/schema/usermgr.xsd", "LastChange"));
        elemField.setXmlType(new javax.xml.namespace.QName(
                "http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setNillable(true);
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