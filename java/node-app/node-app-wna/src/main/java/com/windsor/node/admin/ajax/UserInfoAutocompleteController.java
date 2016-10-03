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

/**
 * 
 */
package com.windsor.node.admin.ajax;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import net.sf.json.JSONArray;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.service.admin.AccountService;
import org.springframework.web.servlet.ModelAndView;

import java.io.Writer;
import java.util.List;

/**
 * Concrete class to access the user access list
 * 
 * @author Eric Chan
 * 
 */
public class UserInfoAutocompleteController extends
        AbstractAutocompleteController implements InitializingBean {

    private AccountService accountService;

    public void afterPropertiesSet() throws Exception {

        if (accountService == null) {
            throw new Exception("accountService not set");
        }

    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.admin.ajax.AbstractAutocompleteController#getList(javax
     * .servlet.http.HttpServletRequest)
     */
    protected Object getList(HttpServletRequest request) {
        return accountService.getActiveUsernames(VisitUtils.getVisit(request));
    }

    public AccountService getAccountService() {
        return accountService;
    }

    public void setAccountService(AccountService accountService) {
        this.accountService = accountService;
    }

    @Override
    protected ModelAndView handleRequestInternal(HttpServletRequest request, HttpServletResponse response) throws Exception {
        response.setDateHeader("Expires", 0);
        response
                .setHeader("Cache-Control",
                        "no-store, no-cache, must-revalidate, post-check=0, pre-check=0");
        response.setHeader("Pragma", "no-cache");

        List list =
                accountService.findAccountNameByName(request.getParameter(getParameter()), getMaxParameter(request));

        if (list == null || list.size() < 1) {
            return null;
        }

        Writer writer = response.getWriter();

        JSONArray json = JSONArray.fromObject(list);
        writer.write(json.toString());

        return null;
    }
}