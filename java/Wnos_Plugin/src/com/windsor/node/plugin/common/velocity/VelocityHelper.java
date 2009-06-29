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

import java.io.Writer;
import java.util.Map;

import javax.sql.DataSource;

public interface VelocityHelper {

    /** Key for bean in the Sping context_config.xml. */
    String VELOCITY_HELPER_CTX_KEY = "velocityHelper";

    /** Key for bean in the Sping context_config.xml. */
    String DATASOURCE_CTX_KEY = "dataSource";

    /** Key for bean in the Sping context_config.xml. */
    String OUTPUT_FILENAME_CTX_KEY = "outputFilename";

    /** Key for value in helper.properties */
    String OUTPUT_FILENAME_PROPS_KEY = "helper.output";

    /** Key for bean in the Sping context_config.xml. */
    String TEMPLATE_CTX_KEY = "templateFilename";

    /** Key for value in helper.properties */
    String TEMPLATE_PROPS_KEY = "helper.template";

    /** Key for bean in the Sping context_config.xml. */
    String HELPER_ARGS_CTX_KEY = "helperArgs";

    /** Key for value in helper.properties */
    String HELPER_ARGS_PROPS_KEY = "helper.args";

    /** Delimiter for arguments in helper.properties */
    String HELPER_ARGS_DELIM = "|";

    /** Delimiter for name-value argument elements in helper.properties */
    String HELPER_NAME_VAL_DELIM = "^";

    /**
     * Configure the helper instance.
     * 
     * @param templateDirectory
     *            the filesystem location of the Velocity templates
     */
    void configure(String templateDirectory);

    /**
     * Configure the helper instance.
     * 
     * @param dataSource
     *            a JDBC DataSource
     * @param templateDirectory
     *            the filesystem location of the Velocity templates
     */
    void configure(DataSource dataSource, String templateDirectory);

    /**
     * Split a formatted String into name-value pairs, intended for reading an
     * arbitrary set of Velocity template variables from a single line of text.
     * 
     * <p>
     * The input string must be of the form:<br>
     * 
     * <pre>
     * &lt;name&gt;&circ;&lt;value&gt;|&lt;name&gt;&circ;&lt;value&gt;|...
     * </pre>
     * 
     * <br>
     * A java.lang.IllegalArgumentException should be thrown if the input is in
     * the wrong format.
     * </p>
     * 
     * @param args
     * @return
     */
    Map<String, Object> splitTemplateArgs(String args);

    /**
     * Set a Velocity Template Language (VTL) variable that can be referenced by
     * $key in the template file.
     * 
     * @param key
     * @param arg
     */
    void setTemplateArg(String key, Object arg);

    /**
     * Set a batch of VTL variables.
     * 
     * @param args
     *            assumed to be a Map of String-Object pairs
     */
    void setTemplateArgs(Map<String, Object> args);

    /**
     * Merge a VTL template.
     * 
     * @param template
     *            the template file name, relative to the templateDirectory used
     *            in configuring this VelocityHelper
     * @param writer
     *            a java.io.Writer implementation for writing the merged output
     * @return implementation-specific number (e.g., status code, result count)
     */
    int merge(String template, Writer writer);

    /**
     * Merge a VTL template.
     * 
     * @param template
     *            the template file name, relative to the templateDirectory used
     *            in configuring this VelocityHelper
     * @param targetFilePath
     *            fully qualified file name for the merged output
     * @return implementation-specific number (e.g., status code, result count)
     */
    int merge(String template, String targetFilePath);

}
