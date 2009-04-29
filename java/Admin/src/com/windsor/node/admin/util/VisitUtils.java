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

package com.windsor.node.admin.util;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;

import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

import com.windsor.node.common.domain.NodeVisit;

public final class VisitUtils {

    private static final Logger LOGGER = Logger.getLogger(VisitUtils.class);
    private static final String VISIT_SESSION_NAME = "WINNODE";
    private static final String VISIT_EXISTS = "visit exists in session";

    private VisitUtils() {
    }

    /**
     * gets system visit from the session
     * 
     * @param request
     *            HttpServletRequest
     * @return SystemVisitIdentity or null
     */
    public static NodeVisit getVisit(HttpServletRequest request) {

        LOGGER.debug("getting system visit");

        NodeVisit visit = null;
        HttpSession session = request.getSession(false);

        if (session != null && session.getAttribute(VISIT_SESSION_NAME) != null) {

            LOGGER.debug(VISIT_EXISTS);

            visit = (NodeVisit) session.getAttribute(VISIT_SESSION_NAME);

            LOGGER.debug("visit: " + visit);

        } else {
            LOGGER.debug("visit does not exist in session");
        }

        return visit;

    }

    public static ModelAndView getUnauthedView(HttpServletRequest request) {

        String requestedUri = request.getRequestURI();
        LOGGER.debug("requestedUri: " + requestedUri);

        String queryString = request.getQueryString();
        LOGGER.debug("request QueryString: " + queryString);

        if (StringUtils.isNotBlank(queryString)) {
            requestedUri = requestedUri + "?" + queryString;
        }

        RedirectView view = new RedirectView("auth.htm?ru=" + requestedUri);

        LOGGER.debug("redirecting to: " + view);

        return new ModelAndView(view);

    }

    /**
     * clearVisit
     * 
     * @param request
     */
    public static void clearVisit(HttpServletRequest request) {

        LOGGER.debug("clearing system visit");

        HttpSession session = request.getSession(false);

        if (session != null && session.getAttribute(VISIT_SESSION_NAME) != null) {

            LOGGER.debug(VISIT_EXISTS);

            session.removeAttribute(VISIT_SESSION_NAME);
            session.setAttribute(VISIT_SESSION_NAME, null);
            session.invalidate();

            LOGGER.debug("visit removed from session");

        } else {
            LOGGER.debug("visit not in session");
        }

    }

    /**
     * setVisit to session
     * 
     * @param request
     * @param visit
     */
    public static void setVisit(HttpServletRequest request, NodeVisit visit) {

        LOGGER.debug("setting system visit");

        HttpSession session = request.getSession(false);

        if (session != null) {
            session.setAttribute(VISIT_SESSION_NAME, visit);
        }

        LOGGER.debug("system visit set");

    }

}