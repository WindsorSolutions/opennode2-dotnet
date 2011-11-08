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

import java.util.ArrayList;
import java.util.List;

import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;

public class WqxGetDeleteSubmission extends BaseWqxXmlPlugin {

    public static final String SERVICE_NAME = "WQXGetDeleteSubmission";
    private static final String TEMPLATE_NAME = "WQX_Delete.vm";
    private static final String OUTFILE_BASE_NAME = "WQX_2_Delete";

    public static final PluginServiceParameterDescriptor ORG_ID = new PluginServiceParameterDescriptor("Org ID",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.TRUE,
                    "The Org ID to be used in the submission Header. Also governs SELECT logic on WQX_ORGANIZATION table.");
    /*public static final PluginServiceParameterDescriptor ADD_HEADER = new PluginServiceParameterDescriptor("Add Header?",
                    PluginServiceParameterDescriptor.TYPE_BOOLEAN, Boolean.FALSE,
                    "Indicates whether or not to add a Header to the submission.  Defaults to true if not supplied.");
    public static final PluginServiceParameterDescriptor USE_SUBMISSION_HISTORY = new PluginServiceParameterDescriptor(
                    "Use Submission History?", PluginServiceParameterDescriptor.TYPE_BOOLEAN, Boolean.FALSE,
                    "Indicates whether the submission will be recorded in the Submission History table.  Defaults to true if not supplied.");
    public static final PluginServiceParameterDescriptor START_DATE = new PluginServiceParameterDescriptor(
                    "Start Date",
                    PluginServiceParameterDescriptor.TYPE_DATE,
                    Boolean.FALSE,
                    "Applies a date filter on the WQXUPDATEDATE field greater than or equal to the date supplied. Used to send only a subset of activity data.");
    public static final PluginServiceParameterDescriptor END_DATE = new PluginServiceParameterDescriptor(
                    "End Date",
                    PluginServiceParameterDescriptor.TYPE_DATE,
                    Boolean.FALSE,
                    "Applies a date filter on the WQXUPDATEDATE field less than to the date supplied. Used to send only a subset of activity data.");*/

    public WqxGetDeleteSubmission() {

        super();
        debug("WqxGetDeleteSubmission instantiated.");
    }

    public ProcessContentResult process(NodeTransaction transaction) {

        return generateAndSubmitFile(transaction, TEMPLATE_NAME,
                OUTFILE_BASE_NAME, WqxOperationType.DELETE);
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

        List<DataServiceRequestParameter> list = null;

        if (serviceName.equalsIgnoreCase(SERVICE_NAME)) {

            list = new ArrayList<DataServiceRequestParameter>();

            DataServiceRequestParameter param = new DataServiceRequestParameter();
            param.setName(TEMPLATE_ORG_ID);

            list.add(param);
        }

        return list;
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParamters()
    {
        List<PluginServiceParameterDescriptor> params = new ArrayList<PluginServiceParameterDescriptor>();
        params.add(ORG_ID);
        /*params.add(ADD_HEADER);
        params.add(USE_SUBMISSION_HISTORY);
        params.add(START_DATE);
        params.add(END_DATE);*/
        return params;
    }
}
