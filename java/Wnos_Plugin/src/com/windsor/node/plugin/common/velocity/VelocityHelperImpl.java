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

package com.windsor.node.plugin.common.velocity;

import java.io.BufferedOutputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.UnsupportedEncodingException;
import java.io.Writer;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import java.util.Properties;

import javax.sql.DataSource;

import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;
import org.apache.velocity.Template;
import org.apache.velocity.VelocityContext;
import org.apache.velocity.app.VelocityEngine;
import org.apache.velocity.runtime.RuntimeConstants;
import org.apache.velocity.runtime.log.Log4JLogChute;

/**
 * VelocityHelper implementation for merging arbitrary value objects with
 * Velocity Template Language (VTL) templates.
 * 
 * <p>
 * This class is intended to be driven by configuration files and invoked by
 * Node plugins. Template developers will be interested in
 * {@link TemplateHelper} for the template API it provides.
 * </p>
 * 
 */
public class VelocityHelperImpl implements VelocityHelper {

    public static final String TEXT_ENCODING = "UTF-8";
    public static final int BUFFER_SIZE = 1024 * 24;

    protected Logger logger = Logger.getLogger(getClass());
    protected VelocityContext context;
    protected VelocityEngine velocityEngine;
    protected TemplateHelper templateHelper;

    private int resultingRecordCount;

    /**
     * NOTE: this implementation ignores the DataSource and simply calls
     * <code>configure(String templateDirectory)</code>.
     * 
     * @see 
     *      com.windsor.node.velocity.VelocityHelper#configure(javax.sql.DataSource
     *      , String templateDirectory)
     */
    public void configure(DataSource dataSource, String templateDirectory) {

        configure(templateDirectory);
    }

    /**
     * 
     * @see com.windsor.node.velocity.VelocityHelper#configure(, String
     *      templateDirectory)
     */
    public void configure(String templateDirectory) {

        logger.info("Template directory: " + templateDirectory);

        // configuration for VelocityEngine
        Properties props = new Properties();
        props.setProperty("resource.loader", "file");
        props.setProperty("file.resource.loader.description",
                "Velocity File Resource Loader");
        props
                .setProperty("file.resource.loader.class",
                        "org.apache.velocity.runtime.resource.loader.FileResourceLoader");
        props.setProperty("file.resource.loader.path", templateDirectory);
        props.setProperty("file.resource.loader.cache", "false");
        props
                .setProperty("file.resource.loader.modificationCheckInterval",
                        "0");
        props.setProperty("input.encoding", TEXT_ENCODING);
        props.setProperty("output.encoding", TEXT_ENCODING);

        props.setProperty(RuntimeConstants.RUNTIME_LOG_LOGSYSTEM_CLASS,
                "org.apache.velocity.runtime.log.Log4JLogChute");
        props.setProperty(Log4JLogChute.RUNTIME_LOG_LOG4J_LOGGER,
                "org.apache.velocity");

        props.setProperty("eventhandler.referenceinsertion.class",
                "org.apache.velocity.app.event.implement.EscapeXmlReference");
        props.setProperty("eventhandler.escape.html.match", "/.*/");
        props.setProperty("directive.foreach.counter.name", "velocityCount");
        props.setProperty("directive.foreach.counter.initial.value", "1");

        try {
            velocityEngine = new VelocityEngine(props);
        } catch (Exception e) {
            throw new RuntimeException("Error while creating VelocityEngine:"
                    + e.getMessage(), e);
        }

        templateHelper = new TemplateHelper();
        context = new VelocityContext();

    }

    /**
     * 
     * @see com.windsor.node.velocity.VelocityHelper#setTemplateArg(java.lang
     *      .String, java.lang.Object)
     */
    public void setTemplateArg(String key, Object arg) {
        context.put(key, arg);
    }

    /**
     * 
     * @see com.windsor.node.velocity.VelocityHelper#setTemplateArgs(java.util
     *      .Map)
     */
    public void setTemplateArgs(Map<String, Object> args) {
        Iterator<Map.Entry<String, Object>> it = args.entrySet().iterator();
        while (it.hasNext()) {
            Map.Entry<String, Object> pairs = (Map.Entry<String, Object>) it
                    .next();
            context.put(pairs.getKey().toString(), pairs.getValue());
        }

    }

    /**
     * 
     * @see com.windsor.node.velocity.VelocityHelper#splitTemplateArgs(java.lang
     *      .String)
     */
    public Map<String, Object> splitTemplateArgs(String helperArgs) {

        Map<String, Object> map = new HashMap<String, Object>();

        String[] argPairs = StringUtils.split(helperArgs,
                VelocityHelper.HELPER_ARGS_DELIM);

        for (int i = 0; i < argPairs.length; i++) {

            logger.info(argPairs[i]);

            String[] argPair = StringUtils.split(argPairs[i],
                    VelocityHelper.HELPER_NAME_VAL_DELIM);

            if (argPair.length != 2) {
                throw new IllegalArgumentException(
                        "Invalid argument, expected key value pair delimited by '^' char");
            } else {

                map.put(argPair[0].trim(), argPair[1].trim());
            }
        }
        return map;
    }

    /**
     * 
     * @see com.windsor.node.velocity.VelocityHelper#merge(java.lang.String,
     *      java.lang.String)
     */
    public int merge(String template, String targetFilePath) {

        OutputStreamWriter out = null;

        try {
            out = new OutputStreamWriter(new BufferedOutputStream(
                    new FileOutputStream(targetFilePath), BUFFER_SIZE),
                    TEXT_ENCODING);

            return merge(template, out);

        } catch (FileNotFoundException ex) {
            throw new RuntimeException("Error while merging: file not found."
                    + ex.getMessage(), ex);
        } catch (UnsupportedEncodingException e) {
            throw new RuntimeException(
                    "Error while merging: unsupported encoding"
                            + e.getMessage(), e);
        } finally {
            if (out != null) {
                try {
                    out.flush();
                    out.close();
                } catch (IOException e) {
                    logger.error(e);
                }

            }
        }

    }

    /**
     * 
     * @see com.windsor.node.velocity.VelocityHelper#merge(java.lang.String,
     *      java.io.Writer)
     */
    public int merge(String template, Writer writer) {

        if (velocityEngine == null || templateHelper == null) {
            throw new RuntimeException(
                    "Engine not configured. Call configure(String templateDirectory) first!");
        }

        try {

            Template tmpl = velocityEngine.getTemplate(FilenameUtils
                    .getName(template));
            logger.info("Template: " + tmpl.getName());

            logger.debug("Merging template...");
            tmpl.merge(context, writer);

        } catch (Exception e) {
            logger.error("Exception: " + e.getMessage(), e);
            throw new RuntimeException("Template error: " + e.getMessage(), e);
        }

        return getResultingRecordCount();
    }

    public int getResultingRecordCount() {
        return resultingRecordCount;
    }

    public void setResultingRecordCount(int resultingRecordCount) {
        this.resultingRecordCount = resultingRecordCount;
    }

}
