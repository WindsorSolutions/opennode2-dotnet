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

import java.sql.Timestamp;
import java.text.SimpleDateFormat;
import java.util.Date;

import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.propertyeditors.ClassEditor;

public class CustomTimestampEditor extends ClassEditor {

    protected Logger logger = LoggerFactory.getLogger(CustomTimestampEditor.class);

    private final SimpleDateFormat format;

    public CustomTimestampEditor(String format) {
        this.format = new SimpleDateFormat(format);
        this.format.setLenient(true);
    }


    public void setAsText(String text) throws IllegalArgumentException {

        if (StringUtils.isBlank(text)) {

            setValue(null);

        } else {

            try {

                logger.debug("Parsing date: " + text);

                Date date = format.parse(text);

                logger.debug("Parsed Date: " + date);

                Timestamp stamp = new Timestamp(date.getTime());

                logger.debug("Parsed Timestamp: " + stamp);

                setValue(stamp);

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

            return format.format(getValue());
        }
    }
}
