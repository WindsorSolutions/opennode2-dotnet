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

package com.windsor.node.plugin.rcra50;

import java.util.List;

import javax.sql.DataSource;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.plugin.rcra50.dao.RcraStatusDao;

/**
 * Resets the CDXPROCESSINGSTATUS column of the WQX_SUBMISSIONHISTORY table, so
 * that the next run can set a status of &quot;Pending&quot; if it needs to,
 * while leaving the submission history intact.
 */
public class RcraStatusResetter extends BaseRcra50Plugin {

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("RcraStatusResetter");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Attempts to reset the CDXPROCESSINGSTATUS locally so another submission can be sent.  Can fail if transaction is hung at CDX.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(RcraStatusResetter.class.getCanonicalName());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
    {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    public RcraStatusResetter() {

        super();

        debug("Setting service types");
        getSupportedPluginTypes().add(ServiceType.TASK);

        debug("RcraStatusResetter instantiated.");
    }

    public ProcessContentResult process(NodeTransaction transaction) {

        debug("Processing transaction...");

        ProcessContentResult result = new ProcessContentResult();
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);

        try {

            // data access for internal housekeeping for this flow
            DataSource ds = (DataSource) getDataSources().get(ARG_DS_SOURCE);
            RcraStatusDao dao = new RcraStatusDao(ds);

            result
                    .getAuditEntries()
                    .add(
                            makeEntry("Attempting to reset CDXPROCESSINGSTATUS so there are no rows marked pending."));

            dao.resetStatus(getOperationTypeFromTransaction(transaction));

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Processed);
            result.getAuditEntries().add(makeEntry("Done: OK"));

        } catch (Exception ex) {

            error(ex);
            ex.printStackTrace();

            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.Failed);

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

        if (!getDataSources().containsKey(ARG_DS_SOURCE)) {
            throw new RuntimeException("Data source not set");
        }

        debug("DwqHistoryResetter data source validated");

    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.plugin.BaseWnosPlugin#getServiceRequestParamSpecs(java
     * .lang.String)
     */
    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(
            String serviceName) {
        return null;
    }
}
