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

package com.windsor.node.util;

import javax.sql.DataSource;

import org.apache.commons.dbcp.BasicDataSource;
import org.apache.commons.lang.StringUtils;
import org.apache.log4j.Logger;

import com.windsor.node.common.domain.DataProviderInfo;

public final class DataSourceUtil {

    private static final Logger LOGGER = Logger.getLogger(DataSourceUtil.class);

    private static final String PROVIDER_NOT_SET = "Provider is not set";

    private DataSourceUtil() {
    }

    public static DataSource makeBasicDataSource(DataProviderInfo sourceInfo) {

        if (sourceInfo == null) {
            throw new RuntimeException("Source info is not set");
        }

        if (StringUtils.isBlank(sourceInfo.getProviderType())) {
            throw new RuntimeException(PROVIDER_NOT_SET);
        }

        if (StringUtils.isBlank(sourceInfo.getConnectionString())) {
            throw new RuntimeException(PROVIDER_NOT_SET);
        }
        // TODO verify whether we really need to catch anything here, since
        // we're already logging what we're doing
        // try {

        BasicDataSource bds = new BasicDataSource();
        LOGGER.debug("Driver Class Name: " + sourceInfo.getProviderType());
        bds.setDriverClassName(sourceInfo.getProviderType());
        LOGGER.debug("Url: " + sourceInfo.getConnectionString());
        bds.setUrl(sourceInfo.getConnectionString());

        return (DataSource) bds;

        // } catch (Exception e) {
        // e.printStackTrace();
        // throw new RuntimeException("Error while getting connection from: "
        // + sourceInfo);
        // }

    }

}