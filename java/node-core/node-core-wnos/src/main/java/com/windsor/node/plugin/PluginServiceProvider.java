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

package com.windsor.node.plugin;

import java.util.Map;

import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.windsor.node.service.helper.ServiceFactory;

/**
 * Creates a Spring ApplicationContext and retreives instances of internal Node
 * services that enable plugins, {@link com.windsor.node.common.domain.DataFlow
 * DataFlows} and {@link com.windsor.node.common.domain.DataService
 * DataServices}.
 */
public class PluginServiceProvider implements ServiceFactory, InitializingBean {

    /** Logger for this class and subclasses */
    private final Logger logger = LoggerFactory
            .getLogger(PluginServiceProvider.class);

    /** The Spring ApplicationContext created by this class. */
    private ApplicationContext context;

    /**
     * Locations of Spring configuration files that define the available
     * services.
     */
    private String[] configLocations;

    /*
     * (non-Javadoc)
     * 
     * @see
     * org.springframework.beans.factory.InitializingBean#afterPropertiesSet()
     */
    public void afterPropertiesSet() {

        if (configLocations == null || configLocations.length < 1) {
            throw new RuntimeException("ConfigLocations not set");
        }

        logger
                .debug("Creating plugin service provider using following sources: "
                        + StringUtils.join(configLocations, ", "));
        context = new ClassPathXmlApplicationContext(configLocations);
        logger.debug("Acquired beans: " + context.getBeanDefinitionCount());
        logger.debug("Acquired beans: "
                + StringUtils.join(context.getBeanDefinitionNames(), ", "));

    }

    /*
     * (non-Javadoc)
     * 
     * @see
     * com.windsor.node.service.helper.ServiceFactory#makeService(java.lang.
     * Class)
     */
    public Object makeService(Class<?> serviceType) {

        logger.debug("Logging for: " + serviceType);

        Map results = context.getBeansOfType(serviceType);

        if (results == null || results.size() < 1) {

            logger.debug("Loaded bean count: "
                    + context.getBeanDefinitionCount());
            logger.debug("Loaded bean names: "
                    + StringUtils.join(context.getBeanDefinitionNames()));

            throw new RuntimeException(
                    "Unable to find service of this type. Must be defined in these files: "
                            + StringUtils.join(configLocations));
        }

        Object objectId = results.keySet().toArray()[0];
        logger.debug("Found: " + objectId);

        return results.get(objectId);
    }

    /**
     * Called by Spring to set the locations of config files.
     * 
     * @param configLocations
     */
    public void setConfigLocations(String[] configLocations) {
        this.configLocations = configLocations;
    }

}
