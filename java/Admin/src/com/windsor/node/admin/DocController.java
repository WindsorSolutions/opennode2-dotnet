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

package com.windsor.node.admin;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.util.FileCopyUtils;
import org.springframework.web.bind.ServletRequestUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.Controller;

import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.service.admin.TransactionService;

public class DocController implements Controller, InitializingBean {

    private static final long serialVersionUID = 1;
    
    private static final String NO_CACHE = "no-cache";

    protected Logger logger = Logger.getLogger(DocController.class);

    private TransactionService transactionService;

    public void afterPropertiesSet() throws Exception {

        if (transactionService == null) {
            throw new Exception("transactionService not set");
        }

    }

    public ModelAndView handleRequest(HttpServletRequest request,
            HttpServletResponse response) throws Exception {

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED_CONFIG);
            throw new IllegalArgumentException(AdminConstants.UNAUTHED_CONFIG
                    + ": No visit.");
        }

        String id = ServletRequestUtils.getRequiredStringParameter(request,
                "id");

        String tid = ServletRequestUtils.getRequiredStringParameter(request,
                "tid");

        String name = ServletRequestUtils.getRequiredStringParameter(request,
                "name");

        if (StringUtils.isBlank(id) && StringUtils.isBlank(tid)
                && StringUtils.isBlank(name)) {
            throw new IllegalArgumentException(
                    "Invalid transaction or document Id");
        }

        byte[] content = transactionService.downloadContent(tid, id, visit);

        response.setHeader("Cache-Control", NO_CACHE);
        response.setHeader("Pragma", NO_CACHE);
        response.setDateHeader("Expires", 0);
        response.setBufferSize(content.length);
        response.setContentType("application/zip");
        response.setContentLength(content.length);

        response.setHeader("Content-Disposition", "attachment; filename=\""
                + name + "\"");

        FileCopyUtils.copy(content, response.getOutputStream());

        return null;

    }

    public void setTransactionService(TransactionService transactionService) {
        this.transactionService = transactionService;
    }

}