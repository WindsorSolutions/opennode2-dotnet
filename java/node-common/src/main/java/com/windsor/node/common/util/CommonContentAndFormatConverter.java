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

package com.windsor.node.common.util;

import java.io.Serializable;
import java.util.HashMap;
import java.util.Map;
import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.Wsdl11ContentType;

/**
 * Utility class for converting between Strings and Mime data types, for mapping
 * between filename extensions and data types, and for converting to types
 * supported by v1.1 of the Exchange Network Node specification.
 * 
 */
public final class CommonContentAndFormatConverter implements Serializable {

    /**
     * Mime type &quot;application/x&quot;
     */
    public static final String OTHER_MIME = "application/x";

    /**
     * Mime type &quot;text/xml&quot;
     */
    public static final String XML_MIME = "text/xml";

    /**
     * Mime type &quot;text/plain&quot;
     */
    public static final String FLAT_MIME = "text/plain";

    /**
     * Mime type &quot;application/octet-stream&quot;
     */
    public static final String BIN_MIME = "application/octet-stream";

    /**
     * Mime type &quot;application/zip&quot;
     */
    public static final String ZIP_MIME = "application/zip";

    /**
     * Filename extension &quot;dat&quot;
     */
    public static final String OTHER_EXT = "dat";

    /**
     * Filename extension &quot;xml&quot;
     */
    public static final String XML_EXT = "xml";

    /**
     * Filename extension &quot;txt&quot;
     */
    public static final String FLAT_EXT = "txt";

    /**
     * Filename extension &quot;bin&quot;
     */
    public static final String BIN_EXT = "bin";

    /**
     * Filename extension &quot;zip&quot;
     */
    public static final String ZIP_EXT = "zip";

    /**
     * Filename extension &quot;odf&quot;
     */
    public static final String ODF_EXT = "odf";

    private static final int EXTENSION_LENGTH = 3;

    private static final long serialVersionUID = 1;

    private static Map<CommonContentType, String> commonContentToFormat;

    static
    {
        commonContentToFormat = new HashMap<CommonContentType, String>();
        commonContentToFormat.put(CommonContentType.OTHER, OTHER_MIME);
        commonContentToFormat.put(CommonContentType.XML, XML_MIME);
        commonContentToFormat.put(CommonContentType.Flat, FLAT_MIME);
        commonContentToFormat.put(CommonContentType.Bin, BIN_MIME);
        commonContentToFormat.put(CommonContentType.ZIP, ZIP_MIME);
    }

    private CommonContentAndFormatConverter() {
    }

    /**
     * Given a String, look up the corresponding instance of
     * {@link com.windsor.node.common.domain.CommonContentType
     * CommonContentType}.
     * 
     * @param s
     *            the String to convert
     * @return a CommonContentType
     * @throws IllegalArgumentException
     *             if no CommonContentType corresponds to the input String
     */
    public static CommonContentType convert(String s)
    {
        CommonContentType cct = CommonContentType.valueOf(s);
        // Object o = ;
        /*
         * if ((null != o) && (o instanceof CommonContentType)) { cct = (CommonContentType) o; } else {
         */
        if(cct == null)
        {
            throw new IllegalArgumentException("The string \"" + s + "\" does not represent a common content type.");
        }
        return cct;
    }

    /**
     * Given a CommonContentType, look up the corresponding Mime string.
     * 
     * @param cct
     *            the CommonContentType to convert
     * @return the corresponding Mime string (falls back to &quot;OTHER&quot;)
     */
    public static String convertToMimeType(CommonContentType cct)
    {
        String s;
        if(commonContentToFormat.containsKey(cct))
        {
            s = (String)commonContentToFormat.get(cct);
        }
        else
        {
            s = OTHER_MIME;
        }
        return s;
    }

    /**
     * Given a CommonContentType, look up the corresponding type for the Node
     * v.1.1 specification.
     * 
     * @param cct
     *            the CommonContentType to convert
     * @return the corresponding
     *         {@link com.windsor.node.common.domain.Wsdl11ContentType
     *         Wsdl11ContentType}
     * 
     * @throws IllegalArgumentException
     *             if no Wsdl11ContentType corresponds to the input
     *             CommonContentType
     */
    public static Wsdl11ContentType convertTo11Type(CommonContentType cct)
    {
        Wsdl11ContentType wct = null;
        /* _ODF is the only 2.0 type missing from 1.1 */
        if(cct.equals(CommonContentType.ODF))
        {
            wct = Wsdl11ContentType.OTHER;
        }
        else
        {
            String s = cct.getType();
            wct = Wsdl11ContentType.valueOf(s);
            if(wct == null)
            {
                throw new IllegalArgumentException("The type \"" + s + "\" does not map to a WSDL 1.1 content type.");
            }
        }
        return wct;
    }

    /**
     * Given a CommonContentType, look up the corresponding filename extension.
     * 
     * @param cct
     *            the CommonContentType to convert
     * @return the filename extention, <b>null</b> if not found
     */
    public static String getFileExtension(CommonContentType cct) {
        String s = null;
        if (cct.equals(CommonContentType.Bin)) {
            s = BIN_EXT;
        }
        if (cct.equals(CommonContentType.Flat)) {
            s = FLAT_EXT;
        }
        if (cct.equals(CommonContentType.ODF)) {
            s = ODF_EXT;
        }
        if (cct.equals(CommonContentType.OTHER)) {
            s = OTHER_EXT;
        }
        if (cct.equals(CommonContentType.XML)) {
            s = XML_EXT;
        }
        if (cct.equals(CommonContentType.ZIP)) {
            s = ZIP_EXT;
        }
        return s;
    }

    /**
     * Given a filename extension, look up the corresponding CommonContentType.
     * 
     * @param s
     *            a filename extension
     * @return the corresponding CommonContentType, <b>null</b> if not found
     */
    public static CommonContentType getFileTypeFromExtension(String ext) {
        String s = ext;
        CommonContentType cct = null;
        if (s.charAt(0) == '.') {
            s = s.substring(s.length() - EXTENSION_LENGTH, s.length());
        }
        if (s.equalsIgnoreCase(BIN_EXT)) {
            cct = CommonContentType.Bin;
        } else if (s.equalsIgnoreCase(FLAT_EXT)) {
            cct = CommonContentType.Flat;
        } else if (s.equalsIgnoreCase(ODF_EXT)) {
            cct = CommonContentType.ODF;
        } else if (s.equalsIgnoreCase(XML_EXT)) {
            cct = CommonContentType.XML;
        } else if (s.equalsIgnoreCase(ZIP_EXT)) {
            cct = CommonContentType.ZIP;
        } else {
            cct = CommonContentType.OTHER;
        }

        return cct;
    }
}