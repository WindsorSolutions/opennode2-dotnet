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

import org.apache.commons.lang3.StringUtils;
import org.slf4j.LoggerFactory;
import org.springframework.validation.Errors;
import com.windsor.node.common.domain.DataProviderInfo;

public class DataSourceValidator extends AbstractValidator {

    public static final int MAX_CODE_LENGTH = 50;

    public static final String CODE = "code";

    public DataSourceValidator() {
        logger = LoggerFactory.getLogger(DataSourceValidator.class);
    }

    public boolean supports(Class obj) {
        return obj.isAssignableFrom(DataProviderInfo.class);
    }

    public void validate(Object obj, Errors errors) {

        logger.debug(VALIDATE + this.getClass());

        DataProviderInfo item = (DataProviderInfo) obj;

        logger.debug(VALIDATING_WITH + item);

        if (item == null) {
            throw new IllegalArgumentException("Object null");
        } else {

            if (StringUtils.isBlank(item.getCode())) {
                errors.rejectValue(CODE, REQUIRED_ERR_CODE, REQUIRED_MSG);
            } else {
                if (item.getCode().length() > MAX_CODE_LENGTH) {
                    errors.rejectValue(CODE, FORMAT_ERR_CODE, "Too long");
                }
            }

            if (StringUtils.isBlank(item.getProviderType())) {
                errors.rejectValue("providerType", REQUIRED_ERR_CODE,
                        REQUIRED_MSG);
            }

            if (StringUtils.isBlank(item.getConnectionString())) {
                errors.rejectValue("connectionString", REQUIRED_ERR_CODE,
                        REQUIRED_MSG);
            }
        }

    }

}
