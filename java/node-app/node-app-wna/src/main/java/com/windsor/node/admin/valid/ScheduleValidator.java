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
import com.windsor.node.common.domain.ScheduledItem;
import com.windsor.node.common.domain.ScheduledItemSourceType;

public class ScheduleValidator extends AbstractValidator {

    public static final int MAX_ITEM_FREQUENCY = 525600;
    public static final int MIN_ITEM_FREQUENCY = 0;

    private static final String AND = " and ";

    public ScheduleValidator() {
        logger = LoggerFactory.getLogger(ScheduleValidator.class);
    }

    public boolean supports(Class obj) {
        return obj.isAssignableFrom(ScheduledItem.class);
    }

    public void validate(Object obj, Errors errors) {

        logger.debug(VALIDATE + this.getClass());

        ScheduledItem item = (ScheduledItem) obj;

        logger.debug(VALIDATING_WITH + item);

        if (null == item) {

            throw new RuntimeException("No object to validate.");

        }

        if (StringUtils.isBlank(item.getName())) {
            logger.debug("getName() is blank");
            errors.rejectValue("name", REQUIRED_ERR_CODE, REQUIRED_MSG);
        }

        else if (StringUtils.isBlank(item.getFlowId())) {
            logger.debug("getFlowId() is blank");
            errors.rejectValue("flowId", REQUIRED_ERR_CODE, REQUIRED_MSG);
        }

        else if (item.getStartOn() == null) {
            logger.debug("getStartOn() is null");
            errors.rejectValue("startOn", REQUIRED_ERR_CODE, REQUIRED_MSG);
        }

        else if (StringUtils.isBlank(item.getSourceId())) {
            logger.debug("getSourceId() is blank");
            errors.rejectValue("sourceId", REQUIRED_ERR_CODE, REQUIRED_MSG);
        }

        else if (item.getSourceType() == null
                || item.getSourceType() == ScheduledItemSourceType.None) {
            logger.debug("getSourceType() is null");
            errors.rejectValue("sourceType", REQUIRED_ERR_CODE, REQUIRED_MSG);
        }

        else if ((item.getSourceType() == ScheduledItemSourceType.WebServiceQuery || item
                .getSourceType() == ScheduledItemSourceType.WebServiceSolicit)
                && StringUtils.isBlank(item.getSourceOperation())) {
            logger.debug("sourceOperation is blank");
            errors.rejectValue("sourceOperation", REQUIRED_ERR_CODE,
                    REQUIRED_MSG);
        }

        else if (item.getFrequencyType() == null) {
            logger.debug("getFrequencyType() is null");
            errors
                    .rejectValue("frequencyType", REQUIRED_ERR_CODE,
                            REQUIRED_MSG);
        }

        else if (item.getFrequency() < MIN_ITEM_FREQUENCY
                || item.getFrequency() > MAX_ITEM_FREQUENCY) {

            String msg = "Frequency is out of range. Must be between ";
            logger.debug(msg + MIN_ITEM_FREQUENCY + AND + MAX_ITEM_FREQUENCY);
            errors.rejectValue("frequency", REQUIRED_ERR_CODE, msg
                    + MIN_ITEM_FREQUENCY + AND + MAX_ITEM_FREQUENCY);
        }

        else if (item.getEndOn().before(item.getStartOn())) {

            String msg = "Ends On is out of range. Must be after Starts On";
            logger.debug(msg);
            errors.rejectValue("endOn", OUT_OF_RANGE_ERR_CODE, msg);
        }
    }
}
