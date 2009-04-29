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

import java.io.File;

import javax.naming.ConfigurationException;
import javax.sql.DataSource;

import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

/**
 * Provides a command-line interface to the templating subsystem.
 * 
 * For the template API, see 
 * @link{com.windsor.node.plugin.common.velocity.jdbc.JdbcTemplateHelper TemplateHelper}.
 */
public class ConsoleVelocityHelper implements InitializingBean {

    protected static Logger logger = Logger
            .getLogger(ConsoleVelocityHelper.class.getClass());

    private VelocityHelper velocityHelper;
    private DataSource dataSource;
    private String helperArgs;
    private String outputFile;
    private String templatePath;

    public void afterPropertiesSet() throws Exception {

        if (velocityHelper == null) {
            throw new ConfigurationException("null velocityHelper");
        }

        if (dataSource == null) {
            throw new ConfigurationException("null dataSource");
        }

        if (outputFile == null) {
            throw new ConfigurationException("null outputFile");
        }

        if (StringUtils.isBlank(templatePath)) {
            throw new ConfigurationException("null templatePath");
        }

        File templateFile = new File(templatePath);
        if (!templateFile.exists()) {
            throw new ConfigurationException("templatePath does not exist:"
                    + templateFile);
        }

        if (StringUtils.isBlank(helperArgs)) {
            throw new ConfigurationException("null helperArgs");
        }

    }

    public void run() {

        try {

            logger.info("Configuring...");

            velocityHelper.configure(dataSource, FilenameUtils
                    .getFullPath(templatePath));

            velocityHelper.setTemplateArgs(velocityHelper
                    .splitTemplateArgs(helperArgs));

//            velocityHelper.setTemplateArgs(velocityHelper.split)
//            String[] argPairs = StringUtils.split(helperArgs, '|');
//
//            for (int i = 0; i < argPairs.length; i++) {
//
//                logger.info(argPairs[i]);
//
//                String[] argPair = StringUtils.split(argPairs[i], ':');
//
//                if (argPair.length != 2) {
//                    throw new ConfigurationException(
//                            "Invalid argument, expected key value pair deliminated by ':' char");
//                }
//
//                velocityHelper.setTemplateArg(argPair[0].trim(), argPair[1]
//                        .trim());
//
//            }

            logger.info("Template: " + FilenameUtils.getName(templatePath));
            logger.info("Output: " + outputFile);

            int recordCount = velocityHelper.merge(templatePath, outputFile);

            logger.info("Merged records: " + recordCount);

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
        }

    }

    public void setVelocityHelper(VelocityHelper velocityHelper) {
        this.velocityHelper = velocityHelper;
    }

    public void setDataSource(DataSource dataSource) {
        this.dataSource = dataSource;
    }

    public void setConsoleArgs(String consoleArgs) {
        this.helperArgs = consoleArgs;
    }

    public void setOutputFile(String outputFile) {
        this.outputFile = outputFile;
    }

    public void setTemplatePath(String templatePath) {
        this.templatePath = templatePath;
    }

    /**
     * Takes a single argument, the path to the Spring context configuration
     * file, typically hard-wired in a shell script or batch file.
     * 
     * @param args
     */
    public static void main(String[] args) {

        try {

            logger.debug("Initializing application context...");
            ApplicationContext context = new ClassPathXmlApplicationContext(
                    args);

            if (!context.containsBean("console")) {
                throw new ConfigurationException("null console");
            }

            ConsoleVelocityHelper helper = (ConsoleVelocityHelper) context
                    .getBean("console");
            helper.run();

        } catch (Exception ex) {
            logger.error(ex.getMessage(), ex);
        } finally {

            logger.debug("Done");

        }

    }

    public void setHelperArgs(String helperArgs) {
        this.helperArgs = helperArgs;
    }
}