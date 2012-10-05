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
import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.windsor.node.common.domain.DataProviderInfo;

public final class DataSourceUtil {

    //private static final Logger LOGGER = LoggerFactory.getLogger(DataSourceUtil.class);

    private static final String PROVIDER_NOT_SET = "Provider is not set";

    private DataSourceUtil() {
    }

    public static DataSource makeBasicDataSource(DataProviderInfo sourceInfo) {
        Logger LOGGER = LoggerFactory.getLogger(DataSourceUtil.class);
        if (sourceInfo == null) {
            throw new RuntimeException("Source info is not set");
        }

        if (StringUtils.isBlank(sourceInfo.getProviderType())) {
            throw new RuntimeException(PROVIDER_NOT_SET);
        }

        if (StringUtils.isBlank(sourceInfo.getConnectionString())) {
            throw new RuntimeException(PROVIDER_NOT_SET);
        }

        BasicDataSource bds = new BasicDataSource();
        LOGGER.debug("Driver Class Name: " + sourceInfo.getProviderType());
        bds.setDriverClassName(sourceInfo.getProviderType());
        LOGGER.debug("Url: " + sourceInfo.getConnectionString());
        bds.setUrl(sourceInfo.getConnectionString());

        //add the following for stability reasons
        bds.setPoolPreparedStatements(true);
        bds.setInitialSize(5);
        bds.setMaxActive(50);
        bds.setMaxIdle(3);
        bds.setTestOnBorrow(true);
        bds.setTestOnReturn(false);
        bds.setTestWhileIdle(true);
        bds.setTimeBetweenEvictionRunsMillis(10000);
        bds.setNumTestsPerEvictionRun(5);
        bds.setMinEvictableIdleTimeMillis(300000);

        //Oracle needs a special validationQuery
        if(sourceInfo.getProviderType().equalsIgnoreCase("oracle.jdbc.OracleDriver"))
        {
            bds.setValidationQuery("select 1 from dual");
        }
        else
        {
            bds.setValidationQuery("select 1");
        }
        return (DataSource) bds;
    }

}
