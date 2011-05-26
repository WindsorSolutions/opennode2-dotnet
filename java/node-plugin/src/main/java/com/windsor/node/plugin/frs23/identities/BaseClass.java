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

/*
 * Created on Nov 6, 2004
 *
 */
package com.windsor.node.plugin.frs23.identities;

import java.lang.reflect.Field;

import org.apache.commons.lang.StringEscapeUtils;

import com.windsor.node.plugin.xml.ElementUtil;

/**
 * @author mchmarny
 * 
 */
public abstract class BaseClass {

    /**
     * We have to provide a getFieldNames to make sure that we get the fields in
     * order because different JVMs may not pull them in the right order using
     * Field.getDeclaredFields()
     * 
     * @return
     */
    public abstract String[] getFieldNames();

    public String toXml() {

        int elementCount = 0;
        Class thisObj = this.getClass();
        String root = thisObj.getName();
        root = root.substring(root.lastIndexOf(".") + 1);

        String[] fieldNames = getFieldNames();

        StringBuffer xml = new StringBuffer("<");
        xml.append(root);
        xml.append(">");

        for (int i = 0; i < fieldNames.length; i++) {
            try {
                Field field = thisObj.getField(fieldNames[i]);
                Object tempValue = field.get(this);
                if ((tempValue != null) && (tempValue.toString().trim() != "")) {
                    xml.append(ElementUtil.getElement(field.getName(),
                            StringEscapeUtils.escapeXml(tempValue.toString()
                                    .trim())));
                    elementCount++;
                }
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }

        if (elementCount > 0) {
            xml.append("</");
            xml.append(root);
            xml.append(">\n");
            return xml.toString();
        } else {
            return "";
        }

    }

}