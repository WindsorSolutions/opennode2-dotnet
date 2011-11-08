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
package com.windsor.node.common.domain;

import org.apache.commons.lang3.builder.ReflectionToStringBuilder;

/**
 * Represents a RequestParameterType used by the Exchange Network Discovery
 * Services v.20 &quot;GetServices&quot; method.
 * 
 * @since OpenNode2 v1.1.4
 */
public class DataServiceRequestParameter {

    private String name;
    private String type = "string";
    private String typeDescriptor;
    private Boolean required = true;
    private RequestParameterEncodingType encodingType = RequestParameterEncodingType.NONE;
    private Integer sortIndex = 0;
    private Integer occurenceNum = 1;

    @Override
    public String toString() {
        ReflectionToStringBuilder rtsb = new ReflectionToStringBuilder(this,
                new DomainStringStyle());
        rtsb.setAppendStatics(false);
        rtsb.setAppendTransients(false);
        return rtsb.toString();
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public String getTypeDescriptor() {
        return typeDescriptor;
    }

    public void setTypeDescriptor(String typeDescriptor) {
        this.typeDescriptor = typeDescriptor;
    }

    public Boolean isRequired() {
        return required;
    }

    public void setRequired(Boolean required) {
        this.required = required;
    }

    public RequestParameterEncodingType getEncodingType() {
        return encodingType;
    }

    public void setEncodingType(RequestParameterEncodingType encodingType) {
        this.encodingType = encodingType;
    }

    public Integer getSortIndex() {
        return sortIndex;
    }

    public void setSortIndex(Integer sortIndex) {
        this.sortIndex = sortIndex;
    }

    public Integer getOccurenceNum() {
        return occurenceNum;
    }

    public void setOccurenceNum(Integer occurenceNum) {
        this.occurenceNum = occurenceNum;
    }

    // CHECKSTYLE:OFF
    @Override
    public int hashCode() {
        final int prime = 31;
        int result = 1;
        result = prime * result
                + ((encodingType == null) ? 0 : encodingType.hashCode());
        result = prime * result + ((name == null) ? 0 : name.hashCode());
        result = prime * result
                + ((occurenceNum == null) ? 0 : occurenceNum.hashCode());
        result = prime * result
                + ((required == null) ? 0 : required.hashCode());
        result = prime * result
                + ((sortIndex == null) ? 0 : sortIndex.hashCode());
        result = prime * result + ((type == null) ? 0 : type.hashCode());
        result = prime * result
                + ((typeDescriptor == null) ? 0 : typeDescriptor.hashCode());
        return result;
    }

    // CHECKSTYLE:ON

    // CHECKSTYLE:OFF
    @Override
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (obj == null)
            return false;
        if (getClass() != obj.getClass())
            return false;
        DataServiceRequestParameter other = (DataServiceRequestParameter) obj;
        if (encodingType == null) {
            if (other.encodingType != null)
                return false;
        } else if (!encodingType.equals(other.encodingType))
            return false;
        if (name == null) {
            if (other.name != null)
                return false;
        } else if (!name.equals(other.name))
            return false;
        if (occurenceNum == null) {
            if (other.occurenceNum != null)
                return false;
        } else if (!occurenceNum.equals(other.occurenceNum))
            return false;
        if (required == null) {
            if (other.required != null)
                return false;
        } else if (!required.equals(other.required))
            return false;
        if (sortIndex == null) {
            if (other.sortIndex != null)
                return false;
        } else if (!sortIndex.equals(other.sortIndex))
            return false;
        if (type == null) {
            if (other.type != null)
                return false;
        } else if (!type.equals(other.type))
            return false;
        if (typeDescriptor == null) {
            if (other.typeDescriptor != null)
                return false;
        } else if (!typeDescriptor.equals(other.typeDescriptor))
            return false;
        return true;
    }
    // CHECKSTYLE:ON

}
