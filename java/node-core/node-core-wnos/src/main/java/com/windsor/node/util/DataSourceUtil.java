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

import java.util.Map;
import java.util.Properties;
import java.util.TreeMap;

import javax.sql.DataSource;

import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.windsor.node.common.domain.DataProviderInfo;
import com.zaxxer.hikari.HikariConfig;
import com.zaxxer.hikari.HikariDataSource;

public final class DataSourceUtil {

    //private static final Logger LOGGER = LoggerFactory.getLogger(DataSourceUtil.class);

    private static final String PROVIDER_NOT_SET = "Provider is not set";
    private static final Map<String, DataSource> dataSourceCache = new TreeMap<String, DataSource>();

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

        /*BasicDataSource bds = new BasicDataSource();
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
        if(sourceInfo.getProviderType().equalsIgnoreCase("com.mysql.jdbc.Driver"))
        {
            //MySql has some max_allowed_packet setting which it is desireable to increase for sessions that include saving large XML files
            bds.addConnectionProperty("max_allowed_packet", "1000000000");
            //Doesn't seem effective on mysql server 5.1
        }
        return (DataSource) bds;*/

        /*        <property name="url">
            <value>${jdbc.url}</value>
        </property>
        <property name="dataSource.user">
            <value>${jdbc.username}</value>
        </property>
        <property name="dataSource.password">
            <value>${jdbc.password}</value>
        </property>
        <property name="dataSource.autoCommit" value="false" />
        <property name="poolName" value="springHikariCP" />
        <property name="dataSource.connectionTestQuery" value="select count(1) from NAccount"/>
*/
        //Only create this if it's not cached.
        String dataSourceKey = generateDataSourceKey(sourceInfo);
        HikariDataSource ds = (HikariDataSource)dataSourceCache.get(dataSourceKey);
        if(ds == null)
        {
            ds = generateNewDataSource(sourceInfo);
            dataSourceCache.put(dataSourceKey, ds);
        }
        return ds;
    }

    private static String generateDataSourceKey(DataProviderInfo sourceInfo)
    {
        StringBuffer sb = new StringBuffer();
        sb.append(sourceInfo.getCode()).append(sourceInfo.getProviderType()).append(sourceInfo.getConnectionString());
        return sb.toString();
    }

    private static HikariDataSource generateNewDataSource(DataProviderInfo sourceInfo)
    {
        Properties props = new Properties();
        props.put("dataSource.URL", sourceInfo.getConnectionString());

        if(sourceInfo.getProviderType().equalsIgnoreCase("com.mysql.jdbc.Driver"))
        {
            props.put("dataSource.cachePrepStmts", Boolean.TRUE);
            props.put("dataSource.prepStmtCacheSize", 250);
            props.put("dataSource.prepStmtCacheSqlLimit", 2048);
            props.put("dataSource.useServerPrepStmts", Boolean.TRUE);
        }

        HikariConfig config = new HikariConfig(props);
        config.setConnectionTimeout(1000L * 60);

        if(sourceInfo.getProviderType().equalsIgnoreCase("oracle.jdbc.OracleDriver"))
        {
            config.setConnectionTestQuery("select 1 from dual");
        }
        else
        {
            config.setConnectionTestQuery("select 1");
        }

        //set datasource
        //oracle.jdbc.pool.OracleConnectionPoolDataSource or oracle.jdbc.pool.OracleDataSource
        //com.mysql.jdbc.jdbc2.optional.MysqlConnectionPoolDataSource extends com.mysql.jdbc.jdbc2.optional.MysqlDataSource
        //com.microsoft.sqlserver.jdbc.SQLServerConnectionPoolDataSource or com.microsoft.sqlserver.jdbc.SQLServerDataSource
        if(sourceInfo.getProviderType().equalsIgnoreCase("oracle.jdbc.OracleDriver"))
        {
            config.setDataSourceClassName("oracle.jdbc.pool.OracleDataSource");
        }
        else if(sourceInfo.getProviderType().equalsIgnoreCase("com.mysql.jdbc.Driver"))
        {
            //config.setDataSourceClassName("com.mysql.jdbc.jdbc2.optional.MysqlDataSource");
            config.setDataSourceClassName("com.mysql.jdbc.jdbc2.optional.MysqlConnectionPoolDataSource");
        }
        else if(sourceInfo.getProviderType().equalsIgnoreCase("com.microsoft.sqlserver.jdbc.SQLServerDriver"))
        {
            config.setDataSourceClassName("com.microsoft.sqlserver.jdbc.SQLServerConnectionPoolDataSource");
        }

        HikariDataSource ds = new HikariDataSource(config);
        return ds;
    }
}
