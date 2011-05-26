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

package com.windsor.node.admin.valid;

import java.net.MalformedURLException;
import java.net.URL;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.validation.Errors;

import com.windsor.node.common.domain.DataFlow;

public class FlowValidator extends AbstractValidator {

    public static final String INFO_URL = "infoUrl";

    public FlowValidator() {
        logger = LoggerFactory.getLogger(FlowValidator.class);
    }

    public boolean supports(Class obj) {
        return obj.isAssignableFrom(DataFlow.class);
    }

    public void validate(Object obj, Errors errors) {

        logger.debug(VALIDATE + this.getClass());

        DataFlow item = (DataFlow) obj;

        logger.debug(VALIDATING_WITH + item);

        if (item == null) {
            throw new IllegalArgumentException("Object null");
        } else {

            if (item.getContactUserId() == null
                    || StringUtils.isBlank(item.getContactUserId())) {
                errors.rejectValue("contactUserId", REQUIRED_ERR_CODE,
                        REQUIRED_MSG);
            }

            if (StringUtils.isBlank(item.getInfoUrl())) {
                errors.rejectValue(INFO_URL, REQUIRED_ERR_CODE, REQUIRED_MSG);
            }

            try {
                URL testUrl = new URL(item.getInfoUrl());
                item.setInfoUrl(testUrl.toString());
            } catch (MalformedURLException ex) {
                errors.rejectValue(INFO_URL, FORMAT_ERR_CODE, "Invalid format");
            }
        }

    }

}
