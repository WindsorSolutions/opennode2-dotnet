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

import java.io.Writer;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import net.sf.json.JSONArray;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.lang.math.NumberUtils;
import org.apache.log4j.Logger;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.AbstractController;

/**
 * Controller that handles a list of objects and returns them as a JSON
 * response. The default max results is 10.
 * 
 * @author Eric Chan
 * 
 */
public abstract class AbstractAutocompleteController extends AbstractController {

    private static final int DEFAULT_MAX = 10;

    private static final Logger LOGGER = Logger
            .getLogger(AbstractAutocompleteController.class);
    private SearchService search;
    private String parameter;
    private String maxParameter;
    private int defaultMax;

    public AbstractAutocompleteController() {
        // set defaults
        setParameter("q");
        setMaxParameter("limit");
        setDefaultMax(DEFAULT_MAX);
    }

    /**
     * Takes in a parameter, limit parameter and performs a search. Then writes
     * to the response as a JSON array.
     */
    protected ModelAndView handleRequestInternal(HttpServletRequest request,
            HttpServletResponse response) throws Exception {

        response.setDateHeader("Expires", 0);
        response
                .setHeader("Cache-Control",
                        "no-store, no-cache, must-revalidate, post-check=0, pre-check=0");
        response.setHeader("Pragma", "no-cache");

        List list = getSearch().find(getList(request),
                request.getParameter(getParameter()), getMaxParameter(request));

        if (list == null || list.size() < 1) {
            return null;
        }

        Writer writer = response.getWriter();

        JSONArray json = JSONArray.fromObject(list);
        writer.write(json.toString());

        return null;
    }

    /**
     * Get the list to search from.
     * 
     * @param request
     * @return
     */
    protected abstract Object getList(HttpServletRequest request);

    protected int getMaxParameter(HttpServletRequest request) {

        String max = request.getParameter(getMaxParameter());
        return maxParameterAsInt(max);
    }

    protected int maxParameterAsInt(String max) {

        int returnVal;

        if (StringUtils.isBlank(max) || !NumberUtils.isNumber(max)) {
            returnVal = getDefaultMax();
        }
        try {

            Integer maxResults = Integer.valueOf(max);
            returnVal = maxResults.intValue();

        } catch (Exception e) {
            LOGGER.error("Error trying to convert " + max + " to int", e);
            returnVal = getDefaultMax();
        }
        return returnVal;
    }

    public String getParameter() {
        return parameter;
    }

    public void setParameter(String parameter) {
        this.parameter = parameter;
    }

    public String getMaxParameter() {
        return maxParameter;
    }

    public void setMaxParameter(String maxParameter) {
        this.maxParameter = maxParameter;
    }

    public SearchService getSearch() {
        return search;
    }

    public void setSearch(SearchService search) {
        this.search = search;
    }

    public int getDefaultMax() {
        return defaultMax;
    }

    public void setDefaultMax(int defaultMax) {
        this.defaultMax = defaultMax;
    }

}