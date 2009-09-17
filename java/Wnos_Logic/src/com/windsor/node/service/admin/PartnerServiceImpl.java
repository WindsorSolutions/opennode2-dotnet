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

package com.windsor.node.service.admin;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.Activity;
import com.windsor.node.common.domain.ActivityType;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.SystemRoleType;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.common.service.admin.PartnerService;
import com.windsor.node.data.dao.PartnerDao;
import com.windsor.node.service.BaseService;

public class PartnerServiceImpl extends BaseService implements PartnerService,
        InitializingBean {

    private PartnerDao partnerDao;

    /**
     * check
     */
    public void afterPropertiesSet() {

        super.afterPropertiesSet();

        if (partnerDao == null) {
            throw new RuntimeException("PartnerDao Not Set");
        }

    }

    /**
     * delete
     */
    public void delete(String partnerId, NodeVisit visit) {

        if (StringUtils.isBlank(partnerId)) {
            throw new RuntimeException("partnerId not set.");
        }

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        PartnerIdentity partner = partnerDao.get(partnerId);

        if (partner == null) {
            throw new RuntimeException(
                    "Partner item not present in local database.");
        }

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        // The idea is that both of them need to work independently
        try {

            logEntry.addEntry("{0} attempted to delete partner {1}.",
                    new Object[] { visit.getName(), partner.getName() });

            // NAAS
            logger.debug("Attempting to delete present: " + partner);
            partnerDao.delete(partner.getId());
            logEntry.addEntry("Present deleted from DB.");

        } catch (Exception ex) {
            logger.error(ex);
            logEntry.addEntry("Error while deleting partner: "
                    + ex.getMessage());

            throw new WinNodeException(ex.getMessage());

        } finally {
            getActivityDao().make(logEntry);
        }

    }

    /**
     * save
     */
    public PartnerIdentity save(PartnerIdentity instance, NodeVisit visit) {

        if (instance == null) {
            throw new RuntimeException("PartnerIdentity argument not set.");
        }

        // Make sure the user performing that action has admin rights
        validateByRole(visit, SystemRoleType.Admin);

        Activity logEntry = makeNewActivity(ActivityType.Audit, visit);

        try {

            logEntry.addEntry("{0} attempted to save partner {1}.",
                    new Object[] { visit.getName(), instance.getName() });

            logger.debug("Attempting to save partner in DB");
            instance.setModifiedById(visit.getUserAccount().getId());
            instance = partnerDao.save(instance);
            logEntry.addEntry("Partner saved in DB.");

        } catch (Exception ex) {

            logger.error(ex);
            logEntry.addEntry("Error while saving partner in DB: "
                    + ex.getMessage());

            throw new WinNodeException(ex.getMessage());

        } finally {
            getActivityDao().make(logEntry);
        }

        return instance;

    }

    /**
     * select
     */
    public PartnerIdentity get(String partnerId, NodeVisit visit) {

        if (StringUtils.isBlank(partnerId)) {
            throw new RuntimeException("partnerId argument not set.");
        }

        return partnerDao.get(partnerId);

    }

    /**
     * get
     */
    public List get(NodeVisit visit) {

        return partnerDao.get();

    }

    public void setPartnerDao(PartnerDao partnerDao) {
        this.partnerDao = partnerDao;
    }

}