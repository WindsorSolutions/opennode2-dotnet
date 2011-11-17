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

import java.util.ArrayList;
import java.util.List;

import javax.sql.DataSource;

import org.apache.commons.lang.StringUtils;

import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.data.dao.jdbc.JdbcPartnerDao;
import com.windsor.node.data.dao.jdbc.JdbcTransactionDao;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.rcra50.dao.RcraStatusDao;
import com.windsor.node.service.helper.client.NodeClientFactory;

public abstract class BaseRcra50Plugin extends BaseWnosPlugin {

    /**
     * Required runtime argument, set in service configuration.
     */
    protected static final String ARG_PARTNER_NAME = "Submission Partner Name";
    protected static final String NOT_SET = " not set";

    private String partnerName;
    private JdbcPartnerDao partnerDao;
    private RcraStatusDao statusDao;
    private JdbcTransactionDao transactionDao;

    public BaseRcra50Plugin() {
        super();

        setPublishForEN11(false);
        setPublishForEN20(false);

        debug("Setting internal data source list");
        getDataSources().put(ARG_DS_SOURCE, (DataSource) null);

        debug("Setting internal runtime argument list");
        getConfigurationArguments().put(ARG_PARTNER_NAME, "");

        debug("BaseRcra50Plugin instantiated.");
    }

    protected RcraOperationType getOperationTypeFromTransaction(
            NodeTransaction tran) {

        String opTypeStr = getRequiredValueFromTransactionArgs(tran, 0);

        return RcraOperationType.fromString(opTypeStr);
    }

    protected PartnerIdentity makePartner() {

        logger.debug("Looking for partner named " + partnerName);

        List<?> partners = partnerDao.get();

        PartnerIdentity partner = null;

        for (int i = 0; i < partners.size(); i++) {

            PartnerIdentity testPartner = (PartnerIdentity) partners.get(i);
            logger.debug("Found partner named " + testPartner.getName());

            if (testPartner.getName().equals(partnerName)) {

                logger.debug("Found partner match");
                partner = testPartner;
                break;
            }
        }

        if (null == partner) {
            throw new RuntimeException("No partner named " + partnerName
                    + " exists in partner configuration.");
        }

        return partner;

    }

    protected NodeClientService makeNodeClient(PartnerIdentity partner) {

        NodeClientFactory clientFactory = (NodeClientFactory) getServiceFactory()
                .makeService(NodeClientFactory.class);

        String msg = "Creating Node Client with partner ";
        debug(msg + partner);
        return clientFactory.makeAndConfigure(partner);
    }

    public void afterPropertiesSet() {
        super.afterPropertiesSet();

        debug("Validating data sources");

        partnerDao = (JdbcPartnerDao) getServiceFactory().makeService(
                JdbcPartnerDao.class);

        if (partnerDao == null) {
            throw new RuntimeException("Unable to obtain partnerDao");
        }

        statusDao = new RcraStatusDao((DataSource) getDataSources().get(
                ARG_DS_SOURCE));

        if (statusDao == null) {
            throw new RuntimeException("Unable to obtain statusDao");
        }

        transactionDao = (JdbcTransactionDao) getServiceFactory().makeService(
                JdbcTransactionDao.class);

        if (transactionDao == null) {
            throw new RuntimeException("Unable to obtain transactionDao");
        }

        if (StringUtils.isBlank(partnerName)) {
            partnerName = (String) getRequiredConfigValueAsString(ARG_PARTNER_NAME);
        }
        debug("partnerName: " + partnerName);

        if (!getConfigurationArguments().containsKey(ARG_PARTNER_NAME)) {
            throw new RuntimeException(ARG_PARTNER_NAME + NOT_SET);
        }

    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        return new ArrayList<PluginServiceParameterDescriptor>();
    }

    /**
     * @return the statusDao
     */
    public RcraStatusDao getStatusDao() {
        return statusDao;
    }

    /**
     * @param statusDao
     *            the statusDao to set
     */
    public void setStatusDao(RcraStatusDao statusDao) {
        this.statusDao = statusDao;
    }

    /**
     * @return the transactionDao
     */
    public JdbcTransactionDao getTransactionDao() {
        return transactionDao;
    }

    /**
     * @param transactionDao
     *            the transactionDao to set
     */
    public void setTransactionDao(JdbcTransactionDao transactionDao) {
        this.transactionDao = transactionDao;
    }

    /**
     * @return the partnerName
     */
    public String getPartnerName() {
        return partnerName;
    }

    /**
     * @param partnerName
     *            the partnerName to set
     */
    public void setPartnerName(String partnerName) {
        this.partnerName = partnerName;
    }

}
