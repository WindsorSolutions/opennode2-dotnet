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

package com.windsor.node.plugin.common.velocity.jdbc;

import java.io.Writer;

import javax.sql.DataSource;

import org.apache.commons.io.FilenameUtils;
import org.apache.velocity.Template;

import com.windsor.node.plugin.common.velocity.VelocityHelperImpl;

/**
 * VelocityHelper implementation for merging relational data with Velocity
 * Template Language (VTL) templates.
 * 
 * <p>
 * This class is intended to be driven by configuration files and invoked by
 * Node plugins. Template developers will be interested in
 * {@link JdbcTemplateHelper} for the template API it provides.
 * </p>
 * 
 */
public class JdbcVelocityHelper extends VelocityHelperImpl {

    /**
     * 
     * @see com.windsor.node.velocity.VelocityHelper#configure(javax.sql.DataSource
     *      )
     */
    public void configure(DataSource dataSource, String templateDirectory) {

        configure(templateDirectory);

        if (dataSource == null) {
            throw new NullPointerException("Null dataSource");
        }

        templateHelper = new JdbcTemplateHelper(dataSource);
        context.put("helper", templateHelper);

    }

    /**
     * Merge a VTL template, using the SQL statements embedded within it.
     * 
     * @param template
     *            the template file name, relative to the templateDirectory used
     *            in configuring this VelocityHelper
     * @param targetFilePath
     *            fully qualified file name for the merged output
     * @return the number of rows returned from the outermost query (the
     *         template developer must manage this in the template)
     * @see com.windsor.node.velocity.VelocityHelper#merge(java.lang.String,
     *      java.lang.String)
     */
    public int merge(String template, String targetFilePath) {

        return super.merge(template, targetFilePath);
    }

    /**
     * Merge a VTL template, using the SQL statements embedded within it.
     * 
     * @param template
     *            the template file name, relative to the templateDirectory used
     *            in configuring this VelocityHelper
     * @param writer
     *            a java.io.Writer implementation for writing the merged output
     * @return the number of rows returned from the outermost query (the
     *         template developer must manage this in the template)
     * @see com.windsor.node.velocity.VelocityHelper#merge(java.lang.String,
     *      java.io.Writer)
     */
    public int merge(String template, Writer writer) {

        if (velocityEngine == null || templateHelper == null) {
            throw new RuntimeException(
                    "Helper not configured. configure(DataSource dataSource, String templateDirectory) first!");
        }

        try {

            Template tmpl = velocityEngine.getTemplate(FilenameUtils
                    .getName(template));
            logger.info("Template: " + tmpl.getName());

            logger.debug("Merging template...");
            tmpl.merge(context, writer);

            return ((JdbcTemplateHelper) templateHelper)
                    .getResultingRecordCount();

        } catch (Exception e) {
            logger.error("Exception: " + e.getMessage(), e);
            throw new RuntimeException("Template error: " + e.getMessage(), e);
        }

    }

}
