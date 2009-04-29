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

package com.windsor.node.plugin.wqx;

import javax.sql.DataSource;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.wqx.dao.WqxStatusDao;

/**
 * Resets the CDXPROCESSINGSTATUS column of the WQX_SUBMISSIONHISTORY table, so
 * that the next run can set a status of &quot;Pending&quot; if it needs to,
 * while leaving the submission history intact.
 */
public class WqxStatusResetter extends BaseWnosPlugin {

    public WqxStatusResetter() {

        super();

        debug("Setting internal data source list");
        getDataSources().put(DS_SOURCE, (DataSource) null);

        debug("Setting service types");
        getSupportedPluginTypes().add(ServiceType.SOLICIT);

        debug("DwqHistoryResetter initialized");
    }

    public ProcessContentResult process(NodeTransaction transaction) {

        debug("Processing transaction...");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.FAILED);

        try {

            // data access for internal housekeeping for this flow
            DataSource ds = (DataSource) getDataSources().get(DS_SOURCE);
            WqxStatusDao dao = new WqxStatusDao(ds);

            result
                    .getAuditEntries()
                    .add(
                            makeEntry("Attempting to reset CDXPROCESSINGSTATUS so there are no rows marked pending."));

            dao.resetStatus();

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.PROCESSED);
            result.getAuditEntries().add(makeEntry("Done: OK"));

        } catch (Exception ex) {

            error(ex);
            ex.printStackTrace();

            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.FAILED);

            result.getAuditEntries().add(
                    makeEntry("Error while executing: "
                            + this.getClass().getName() + "Message: "
                            + ex.getMessage()));

        }
        return result;
    }

    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        debug("Validating data sources");

        if (getDataSources() == null) {
            throw new RuntimeException("Data sources not set");
        }

        if (!getDataSources().containsKey(DS_SOURCE)) {
            throw new RuntimeException("Data source not set");
        }

        debug("DwqHistoryResetter data source validated");

    }
}