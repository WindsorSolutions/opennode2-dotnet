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

package com.windsor.node.plugin.xml;


public final class ElementUtil {

    private static final String EMPTY = ""; 
    private static final String LT = "<";
    private static final String GT = ">";
    private static final String[][] BAD_CHARS = { { "&", "&amp;" },
            { LT, "&lt;" }, { GT, "&gt;" }, { "\"\"", "&quot;" },
            { "'", "&apos;" } };

    private ElementUtil() {
    }

    /**
     * getElement
     * 
     * @param elementName
     * @param elementValue
     * @return
     */
    public static String getElement(String elementName, String elementValue) {
        if (isNull(elementValue)) {
            return EMPTY;
        } else {
            return LT + elementName + GT + cleanXml(elementValue.trim()) + "</"
                    + elementName + GT;
        }
    }

    /**
     * cleanXml
     * 
     * @param value
     * @return
     */
    public static String cleanXml(String value) {
        String s = null;
        for (int i = 0; i < BAD_CHARS.length; i++) {
            s = value.replaceAll(BAD_CHARS[i][0], BAD_CHARS[i][1]);
        }
        return s;
    }

    /**
     * isNull
     * 
     * @param val
     * @return
     */
    public static boolean isNull(Object val) {
        return val == null || EMPTY.equals(val);
    }

}