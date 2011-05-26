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
package com.windsor.node.plugin.common;

import java.io.StringWriter;
import java.util.List;
import java.util.Properties;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.apache.velocity.Template;
import org.apache.velocity.VelocityContext;
import org.apache.velocity.app.VelocityEngine;
import org.apache.velocity.runtime.RuntimeConstants;
import org.apache.velocity.runtime.log.Log4JLogChute;

/**
 * @author jniski
 * 
 */
public abstract class VelocityXmlGenerator {

    public static final String XML_DECLARATION = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";

    public static final String LINE_SEP = System.getProperty("line.separator");
    public static final String FILE_SEP = System.getProperty("line.separator");
    public static final String TAB = "    "; // 4 spaces

    protected Logger logger = LoggerFactory.getLogger(getClass());
    protected VelocityEngine ve;

    public VelocityXmlGenerator(String templatePath) {

        logger
                .debug("creating VelocityXmlGenerator, loading templates from the filesystem location: "
                        + templatePath);

        // configuration for VelocityEngine
        Properties props = new Properties();
        props.setProperty("resource.loader", "file");
        props.setProperty("file.resource.loader.path", templatePath);
        props.setProperty("file.resource.loader.cache", "true");
        props
                .setProperty("file.resource.loader.class",
                        "org.apache.velocity.runtime.resource.loader.FileResourceLoader");
        props.setProperty(RuntimeConstants.RUNTIME_LOG_LOGSYSTEM_CLASS,
                "org.apache.velocity.runtime.log.Log4JLogChute");
        props.setProperty(Log4JLogChute.RUNTIME_LOG_LOG4J_LOGGER,
                "org.apache.velocity");

        try {
            ve = new VelocityEngine(props);
        } catch (Exception e) {
            throw new RuntimeException("Problem initializing VelocityEngine", e);
        }

    }

    protected StringWriter genList(String contextKey, String templateName,
            List templateData) {

        VelocityContext context = new VelocityContext();
        context.put(contextKey, templateData.toArray());
        return merge(templateName, context);
    }

    protected StringWriter genItem(String contextKey, String templateName,
            Object templateData) {

        VelocityContext context = new VelocityContext();
        context.put(contextKey, templateData);
        return merge(templateName, context);
    }

    private StringWriter merge(String templateName, VelocityContext context) {

        Template t = getTemplate(templateName);
        StringWriter sw = new StringWriter();

        try {
            t.merge(context, sw);
        } catch (Exception e) {
            logger.error("Problem merging template " + templateName + ": "
                    + e.getMessage());
            throw new RuntimeException("Problem merging template "
                    + templateName, e);
        }

        logger.trace("Output from merging " + templateName + ":\n"
                + sw.toString());
        return sw;
    }

    protected Template getTemplate(String templateName) {

        Template t = null;

        try {
            t = ve.getTemplate(templateName);
        } catch (Exception e) {
            String msg = "Problem getting Template named " + templateName
                    + ": " + e.getMessage();
            logger.error(msg);
            throw new RuntimeException(msg, e);
        }

        return t;
    }
}
