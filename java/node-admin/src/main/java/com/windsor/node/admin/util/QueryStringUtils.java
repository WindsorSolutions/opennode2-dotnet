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

import java.util.Enumeration;

import javax.servlet.http.HttpServletRequest;

import org.apache.commons.lang.StringUtils;
import org.springframework.web.bind.ServletRequestUtils;

public final class QueryStringUtils {

    public static final String QS_BAR_INDEX = "bi";
    public static final String QS_EDIT_INDICATOR = "editmode";

    private QueryStringUtils() {
    }

    /**
     * getParameterValues
     * 
     * @param request
     * @param key
     * @return
     */
    public static String[] getParameterValues(HttpServletRequest request,
            String key) {

        Enumeration paramNames = request.getParameterNames();

        while (paramNames.hasMoreElements()) {

            String name = (String) paramNames.nextElement();

            if (StringUtils.isNotBlank(name) && name.equalsIgnoreCase(key)) {
                return request.getParameterValues(name);
            }

        }

        return null;

    }

    public static void printParameters(HttpServletRequest request) {

        Enumeration paramNames = request.getParameterNames();

        while (paramNames.hasMoreElements()) {

            String name = (String) paramNames.nextElement();

            if (StringUtils.isNotBlank(name)) {
                System.out.print("name: " + request.getParameterValues(name));
            }

        }

    }

    /**
     * getParameterValueAsInteger
     * 
     * @param request
     * @param key
     * @return
     */
    public static Integer getBarIndex(HttpServletRequest request) {

        return new Integer(ServletRequestUtils.getIntParameter(request,
                QS_BAR_INDEX, 0));

    }

    /**
     * getParameterValue
     * 
     * @param request
     * @param key
     * @return
     */
    public static String getParameterValue(HttpServletRequest request,
            String key) {

        Enumeration paramNames = request.getParameterNames();

        while (paramNames.hasMoreElements()) {

            String name = (String) paramNames.nextElement();

            if (StringUtils.isNotBlank(name) && name.equalsIgnoreCase(key)) {
                return request.getParameter(name);
            }

        }

        return null;

    }

    /**
     * parameterHasValue
     * 
     * @param request
     * @param key
     * @param val
     * @return
     */
    public static boolean hasPageViewIndex(HttpServletRequest request,
            String val) {

        return request.getParameter(QS_BAR_INDEX) != null
                && request.getParameter(QS_BAR_INDEX).equalsIgnoreCase(val);

    }

    /**
     * parameterHasValue
     * 
     * @param request
     * @param key
     * @param val
     * @param noKeyTrue
     * @return
     */
    public static boolean hasPageViewIndex(HttpServletRequest request,
            String val, boolean noKeyTrue) {

        if (request.getParameter(QS_BAR_INDEX) == null) {

            return noKeyTrue;

        } else {
            return request.getParameter(QS_BAR_INDEX).equalsIgnoreCase(val);
        }

    }

}