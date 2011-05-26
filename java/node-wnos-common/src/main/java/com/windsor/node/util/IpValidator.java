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

import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public final class IpValidator {

    private static final int FOUR = 4;

    private static final int THREE = 3;

    private static final String STRING = "String \"";

    private static final String IP_ADDRESS = "Ip address \"";

    private static final String DOUBLE_QUOTE = "\"";

    private static final String STAR = "*";

    private static final Logger LOGGER = LoggerFactory.getLogger(IpValidator.class);

    private static final char DOT = '.';

    private IpValidator() {
    }

    public static boolean contains(List aList, String ip) {

        boolean bool = false;

        List ipList = cleanupList(aList);

        LOGGER.debug("Whitelist: " + ipList);
        LOGGER.debug("Testing IP: " + ip);

        if (StringUtils.isNotBlank(ip)) {

            validateIpString(ip);

            String[] ipParts = StringUtils.split(ip.trim(), DOT);
            LOGGER.debug("IP Parts: " + StringUtils.join(ipParts));

            /* loop through the IP list */
            for (int i = 0; i < ipList.size(); i++) {

                String item = ((String) ipList.get(i)).trim();
                LOGGER.debug("Whitelist Item: " + item);

                if (ip.equalsIgnoreCase(item)) {

                    LOGGER.debug("Whitelist direct hit: " + ip + "=" + item);
                    bool = true;

                } else {

                    bool = matchIpToMask(ip, item);
                }

                if (bool) {
                    break;
                }
            }
        }
        return bool;
    }

    protected static boolean matchIpToMask(String ip, String item) {

        boolean bool = false;

        LOGGER.debug("Matching ip address " + ip + " to pattern " + item);

        String[] ipParts = StringUtils.split(ip, DOT);
        String[] maskParts = StringUtils.split(item, DOT);

        /* we allow an all-inclusive whitelist - USE JUDICIOUSLY!!! */
        if (maskParts[0].equals(STAR)) {

            bool = true;

        } else {

            for (int i = 0; i < maskParts.length; i++) {

                if (!ipParts[i].equals(maskParts[i])) {
                    break;
                } else {
                    LOGGER.debug("Matched address element " + ipParts[i]
                            + " to pattern element " + maskParts[i]);
                    if (i < (maskParts.length - 1)) {
                        if (maskParts[i + 1].equals(STAR)) {
                            LOGGER.debug("Found mask wildcard \"*\"");
                            bool = true;
                        }
                    } else {
                        bool = true;
                    }
                }
            }
        }

        if (bool) {
            LOGGER.debug(IP_ADDRESS + ip + "\" matches pattern \"" + item
                    + DOUBLE_QUOTE);
        } else {
            LOGGER.debug(IP_ADDRESS + ip + "\" does not match pattern \""
                    + item + DOUBLE_QUOTE);
        }

        return bool;
    }

    protected static boolean validateIpString(String ip) {

        boolean bool = false;
        String[] ipParts = StringUtils.split(ip, DOT);

        LOGGER.debug("Validating string \"" + ip + "\" as an ip address");

        if (ipParts.length == FOUR) {
            for (int i = 0; i < FOUR; i++) {
                if (ipParts[i].length() <= THREE
                        && StringUtils.isNumeric(ipParts[i])) {
                    bool = true;
                } else {
                    bool = false;
                }
            }
        }

        if (bool) {
            LOGGER.debug(STRING + ip + "\" is valid");
        } else {
            LOGGER.debug(STRING + ip + "\" is not valid");
        }
        return bool;
    }

    protected static List cleanupList(List aList) {

        List newList = new ArrayList();

        String s;

        for (int i = 0; i < aList.size(); i++) {

            s = (String) aList.get(i);

            if (StringUtils.contains(s, ',')) {

                String[] items = StringUtils.split(s, ',');

                for (int z = 0; z < items.length; z++) {

                    newList.add(items[z].trim());
                }
            } else {

                newList.add(s.trim());
            }
        }

        return newList;
    }

}
