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

package com.windsor.node.admin.editor;

import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import org.springframework.beans.propertyeditors.ClassEditor;

import com.windsor.node.admin.valid.ScheduleValidator;
import com.windsor.node.common.util.ByIndexOrNameMap;

public class ByIndexOrNameMapEditor extends ClassEditor {

    private static final String LINE_INDICATOR = System
            .getProperty("line.separator");

    protected Logger logger = LoggerFactory
            .getLogger(ScheduleValidator.class);

    public void setAsText(String text) throws IllegalArgumentException {

        if (StringUtils.isBlank(text)) {
            setValue(new ByIndexOrNameMap());
        } else {

            try {

                logger.debug("ByIndexOrNameMapEditor: " + text);

                String[] args = StringUtils.split(text, LINE_INDICATOR);

                ByIndexOrNameMap map = new ByIndexOrNameMap();

                for (int i = 0; i < args.length; i++) {

                    String testStr = args[i].trim();

                    int firstEqualIndex = testStr.indexOf("=");

                    logger.debug("firstEqualIndex: " + firstEqualIndex);

                    if (firstEqualIndex > -1) {

                        logger.debug("Using key/value strategy");

                        String key = testStr.substring(0, firstEqualIndex);
                        logger.debug("Item key: " + key);

                        String itemValue = testStr
                                .substring(firstEqualIndex + 1);
                        logger.debug("Item value: " + itemValue);

                        if (map.containsKey(key)) {
                            throw new RuntimeException(
                                    "When using key/value argument pairs the key must be unique.");
                        }

                        map.put(key, itemValue);

                    } else {

                        logger.debug("Using index strategy");

                        map.put(i, args[i]);
                    }

                }

                setValue(map);

            } catch (Exception ex) {
                throw new IllegalArgumentException(
                        "Value could not be converted: " + text);
            }
        }
    }

    public String getAsText() {

        if (getValue() == null) {
            return null;
        } else {

            ByIndexOrNameMap map = (ByIndexOrNameMap) getValue();

            logger.debug("ByIndexOrNameMap Values: " + map);

            String[] valueStr = map.toValueStringArray();

            logger.debug("resultStr: " + valueStr);

            String resultStr = StringUtils.join(map.toValueStringArray(),
                    LINE_INDICATOR);

            return resultStr;
        }
    }

}
