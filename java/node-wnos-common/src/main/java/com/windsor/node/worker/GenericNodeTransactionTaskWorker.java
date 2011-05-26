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

package com.windsor.node.worker;

import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.NodeMethodType;

public class GenericNodeTransactionTaskWorker extends NodeTransactionTaskWorker
        implements InitializingBean {

    private NodeMethodType documentType;
    private String documentSubmissionType;

    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        if (StringUtils.isBlank(documentSubmissionType)) {
            throw new RuntimeException("DocumentSubmissionType Not Set");
        }

        if (!NodeMethodType.getEnumMap().containsKey(documentSubmissionType)) {
            throw new RuntimeException("Invalid NodeMethodType: "
                    + documentSubmissionType);
        }

        documentType = (NodeMethodType) NodeMethodType.getEnumMap().get(
                documentSubmissionType);

        if (getPartnerDataProcessor() == null
                && documentType == NodeMethodType.SOLICIT) {
            throw new RuntimeException("PartnerDataProcessor Not Set");
        }
    }

    public void run() {
        super.run(documentType);
    }

    public void setDocumentSubmissionType(String documentSubmissionType) {
        this.documentSubmissionType = documentSubmissionType;
    }

}