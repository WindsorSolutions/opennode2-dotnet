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

import java.io.File;
import java.io.UnsupportedEncodingException;

import org.apache.log4j.Logger;

public final class IOUtil {

    private static Logger logger = Logger.getLogger(IOUtil.class);

    private IOUtil() {
    }

    public static String cleanForPath(String val) {
        return org.springframework.util.StringUtils.cleanPath(val);
    }

    /**
     * getExistentFile
     * 
     * @param path
     * @return
     */
    public static File getExistentFile(String path) {

        File testFile = new File(path);

        if (!testFile.exists()) {
            throw new RuntimeException("Unable to find path: " + path);
        }

        return testFile;

    }

    /**
     * Detect whether a byte[] begins with the (unreadable) UTF-8 byte-order
     * marker; for use in SAX-based XML parsing.
     * 
     * <p>
     * Google for &apos;xerces &quot;Content is not allowed in
     * prolog&quot;&apos; to see why this is valuable.
     * </p>
     * 
     * @param input
     * @return
     */
    public static byte[] filterUtf8Bom(byte[] input) {

        byte[] filteredInput = null;

        logger.debug("looking for UTF-8 Byte-order-mark at start of byte[]...");

        /*
         * lifted from
         * http://stackoverflow.com/questions/712004/does-java-have-methods-to
         * -get-the-various-byte-order-marks
         */
        try {

            byte[] utf8bom = "\uFEFF".getBytes("UTF-8");

            if (input[0] == utf8bom[0] && input[1] == utf8bom[1]
                    && input[2] == utf8bom[2]) {

                logger.debug("Found UTF-8 Byte-order-mark, removing");

                filteredInput = new byte[input.length - utf8bom.length];

                for (int i = utf8bom.length; i < input.length; i++) {
                    filteredInput[i - utf8bom.length] = input[i];
                }

            } else {

                logger.debug("No UTF-8 Byte-order-mark found.");

                filteredInput = input;
            }

        } catch (UnsupportedEncodingException e) {

            throw new RuntimeException(e.getMessage(), e);
        }

        return filteredInput;

    }

}