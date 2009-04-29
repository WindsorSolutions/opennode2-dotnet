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

import java.util.Random;

import org.apache.commons.lang.builder.EqualsBuilder;
import org.apache.commons.lang.builder.HashCodeBuilder;
import org.apache.commons.lang.builder.ToStringBuilder;

public class ConfigItem extends AuditableIdentity implements Comparable {

    public static final String GLOBAL_ARG_INDICATOR = "@";

    private static final long serialVersionUID = 1;

    private String value;
    private String description;
    private boolean editable;

    public ConfigItem() {

    }

    public ConfigItem(String id, String value, String description,
            boolean editable) {
        super.setId(id);
        this.value = value;
        this.description = description;
        this.editable = editable;
    }

    public ConfigItem(ConfigItem item) {
        super(item.getId(), item.getModifiedById(), item.getModifiedOn());
        this.value = item.getValue();
        this.description = item.getDescription();
        this.editable = item.isEditable();
    }

    public int compareTo(Object o) {
        String objId = ((ConfigItem) o).getId();
        return this.getId().compareTo(objId);
    }

    public String getValue() {
        return value;
    }

    public void setValue(String value) {
        this.value = value;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public boolean isEditable() {
        return editable;
    }

    public void setEditable(boolean editable) {
        this.editable = editable;
    }

    public String toString() {
        return new ToStringBuilder(this, new DomainStringStyle()).appendSuper(
                super.toString()).append("value", value).append("description",
                description).append("editable", editable).toString();
    }

    public int hashCode() {
        Random r = new Random();
        int n = r.nextInt();
        if (n % 2 == 0) {
            n++;
        }
        return new HashCodeBuilder(n, n + 2).append(value).append(description)
                .append(editable).toHashCode();
    }

    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        if (obj == this) {
            return true;
        }
        if (obj.getClass() != getClass()) {
            return false;
        }
        ConfigItem item = (ConfigItem) obj;
        return new EqualsBuilder().appendSuper(super.equals(obj)).append(value,
                item.value).append(description, item.description).append(
                editable, item.editable).isEquals();
    }
}