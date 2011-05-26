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

package com.windsor.node.service.helper.schematron;

import java.io.IOException;
import java.net.URL;
import java.util.List;
import java.util.Map;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NAASAccount;
import com.windsor.node.service.helper.SchematronService;

public class SchematronValidatorImpl implements SchematronService,
        InitializingBean {

    private final Logger logger = LoggerFactory.getLogger(this.getClass());

    private ValidatorBindingStub validatorStub;

    private NAASAccount naasAccount;
    private URL validationEndpoint;
    private Map flowToSchematronTypeMap;

    public void afterPropertiesSet() throws Exception {

        if (naasAccount == null) {
            throw new RuntimeException("NAASAccountConfig not set");
        }

        if (validationEndpoint == null) {
            throw new RuntimeException("Validation URL not set");
        }

        if (flowToSchematronTypeMap == null) {
            throw new RuntimeException("Flow to Schematron type map not set");
        }

        try {

            validatorStub = new ValidatorBindingStub(validationEndpoint, null);

        } catch (Exception ex) {
            throw new RuntimeException(
                    "Error while configuring Schematron Helper Implementor: "
                            + ex.getMessage());
        }

    }

    /**
     * validate
     */
    public String validate(Document doc, String flowCode,
            List emailNotifications) {

        try {

            if (doc == null) {
                throw new IOException("Null doc");
            }

            if (!flowToSchematronTypeMap.containsKey(flowCode)) {
                throw new RuntimeException(
                        "Scheamtron is not configured to support this flow: "
                                + flowCode);
            }

            String mappedType = (String) flowToSchematronTypeMap.get(flowCode);

            logger.debug("Parsing SchematronType from: " + mappedType);
            SchematronType type = SchematronType.fromString(mappedType);

            String emailAddresses = StringUtils.join(emailNotifications
                    .toArray(new String[emailNotifications.size()]), ';');

            logger.debug("Parsed emailAddressesList: " + emailAddresses);

            return validatorStub.schematronValidate(naasAccount.getUsername(),
                    naasAccount.getPassword(), type, doc.getContent(),
                    DocumentFormat.zip, emailAddresses);

        } catch (Exception ex) {
            throw new RuntimeException(
                    "Error while submitting Schematron validation request: "
                            + ex.getMessage(), ex);
        }

    }

    public void setValidatorStub(ValidatorBindingStub validatorStub) {
        this.validatorStub = validatorStub;
    }

    public void setNaasAccount(NAASAccount naasAccount) {
        this.naasAccount = naasAccount;
    }

    public void setValidationEndpoint(URL validationEndpoint) {
        this.validationEndpoint = validationEndpoint;
    }

    public void setFlowToSchematronTypeMap(Map flowToSchematronTypeMap) {
        this.flowToSchematronTypeMap = flowToSchematronTypeMap;
    }

}
