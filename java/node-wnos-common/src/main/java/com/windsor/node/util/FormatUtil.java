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

package com.windsor.node.util;

import java.text.FieldPosition;
import java.text.MessageFormat;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import org.apache.commons.lang.StringUtils;

public final class FormatUtil {

    public static final String YES = "Y";
    public static final String NO = "N";

    private FormatUtil() {
    }

    public static boolean toBooleanFromYN(String val) {
        return val != null && YES.equalsIgnoreCase(val.trim());
    }

    public static String toYNFromBoolean(boolean val) {
        if (val) {
            return YES;
        } else {
            return NO;
        }
    }

    /**
     * parseFlowPolicyArg
     * 
     * @param flowName
     * @return
     */
    public static String parseFlowPolicyArg(String prefix, String flowName) {

        if (StringUtils.isBlank(prefix)) {
            throw new IllegalArgumentException("prefix not set");
        }

        if (StringUtils.isBlank(flowName)) {
            throw new IllegalArgumentException("flowName not set");
        }

        return prefix + flowName.toLowerCase();
    }

    /**
     * Basic format based on the arg intdex
     * 
     * @param pattern
     * @param arguments
     * @return
     */
    public static String format(String pattern, Object[] arguments) {
        MessageFormat mf = new MessageFormat(pattern);
        StringBuffer sb = new StringBuffer();
        FieldPosition fp = new FieldPosition(NumberFormat.INTEGER_FIELD);
        return mf.format(arguments, sb, fp).toString();
    }

    /**
     * mapToArray
     * 
     * @param list
     * @param useValue
     * @return
     */
    public static Object[] mapToArray(Map list, Boolean useValue) {

        if (list == null) {
            return new String[] {};
        }

        List resultList = new ArrayList();

        for (Iterator it = list.entrySet().iterator(); it.hasNext();) {

            Map.Entry entry = (Map.Entry) it.next();

            if (useValue.booleanValue()) {
                resultList.add(entry.getKey());
            } else {
                resultList.add(entry.getValue());
            }
        }

        return resultList.toArray();

    }

}