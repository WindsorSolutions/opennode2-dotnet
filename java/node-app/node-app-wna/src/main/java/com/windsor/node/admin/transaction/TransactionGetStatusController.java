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
package com.windsor.node.admin.transaction;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import org.springframework.web.bind.ServletRequestUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.AbstractController;
import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.domain.TransactionStatus;
import com.windsor.node.common.service.admin.TransactionService;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.service.helper.client.NodeClientFactory;

public class TransactionGetStatusController extends AbstractController
{
    private NodeClientFactory nodeClientFactory;
    private TransactionService transactionService;

    @Override
    protected ModelAndView handleRequestInternal(HttpServletRequest request, HttpServletResponse response)
                    throws Exception
    {
        NodeVisit visit = VisitUtils.getVisit(request);
        if(visit == null)
        {
            logger.debug(AdminConstants.UNAUTHED + " transaction " + AdminConstants.ACCESS_REQUEST);
            return VisitUtils.getUnauthedView(request);
        }
        String transactionId = ServletRequestUtils.getRequiredStringParameter(request, "transactionId");
        NodeTransaction trans = getTransactionService().get(transactionId, visit);
        if(trans != null)
        {
            PartnerIdentity oldPartner = new PartnerIdentity();
            oldPartner.setUrl(trans.getNetworkEndpointUrl());
            oldPartner.setVersion(trans.getNetworkEndpointVersion());
            NodeClientService ncl = getNodeClientFactory().makeAndConfigure(oldPartner);
            TransactionStatus status = ncl.getStatus(trans.getNetworkId());
            //TODO fix this service to have an actual save method
            getTransactionService().update(transactionId, status.getStatus(), visit);
        }
        return new ModelAndView("redirect:tran.htm?id=" + transactionId);
    }

    public NodeClientFactory getNodeClientFactory()
    {
        return nodeClientFactory;
    }

    public void setNodeClientFactory(NodeClientFactory nodeClientFactory)
    {
        this.nodeClientFactory = nodeClientFactory;
    }

    public TransactionService getTransactionService()
    {
        return transactionService;
    }

    public void setTransactionService(TransactionService transactionService)
    {
        this.transactionService = transactionService;
    }

}
