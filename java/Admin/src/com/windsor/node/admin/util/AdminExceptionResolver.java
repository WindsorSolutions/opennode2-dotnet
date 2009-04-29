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
import javax.servlet.http.HttpServletResponse;

import org.apache.log4j.Logger;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.handler.SimpleMappingExceptionResolver;

public class AdminExceptionResolver extends SimpleMappingExceptionResolver {

    protected Logger logger = Logger
            .getLogger(AdminExceptionResolver.class);

    public ModelAndView resolveException(HttpServletRequest request,
            HttpServletResponse response, Object handler, Exception ex) {

        logger.error("Caught exception: " + ex);

        if (ex.getStackTrace().length > 0) {
            logger.error("Top element of exception stack: "
                    + ex.getStackTrace()[0]);
        }

        if (ex.getStackTrace().length > 1) {
            logger.error("Bottom element of exception stack: "
                    + ex.getStackTrace()[ex.getStackTrace().length - 1]);
        }

        logger.error("Sending exception stack trace to standard error");

        if (ex.getCause() != null) {
            logger.error("Cause was: " + ex.getCause());

            if (ex.getCause().getStackTrace().length > 0) {
                logger.error("Top element of cause stack: "
                        + ex.getCause().getStackTrace()[0]);
            }

            if (ex.getCause().getStackTrace().length > 1) {
                logger.error("Bottom element of cause stack: "
                        + ex.getCause().getStackTrace()[ex.getCause()
                                .getStackTrace().length - 1]);
            }

            logger.error("Sending cause stack trace to standard error");
            ex.getCause().printStackTrace();
        }

        // will resolve to default global error page
        return null;
    }
}