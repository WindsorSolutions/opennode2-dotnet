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

package com.windsor.node.plugin.frs23;

import java.text.SimpleDateFormat;

import javax.sql.DataSource;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.jdbc.core.support.JdbcDaoSupport;

import com.windsor.node.util.DateUtil;

/**
 * 
 * @author mchmarny
 * 
 */
public class AppStateDataProvider extends JdbcDaoSupport {

    private Logger logger = LoggerFactory.getLogger(getClass());

    private final String SQL_SELECT = "SELECT CURRENT_STATE FROM APP_STATE WHERE APP_KEY = ? ";
    private final String SQL_UPDATE = "UPDATE APP_STATE SET CURRENT_STATE = ?, LAST_SET_ON = ? WHERE APP_KEY = ? ";
    private static final SimpleDateFormat XML_DATE_FORMATER = new SimpleDateFormat(
            "yyyy-MM-dd");

    public AppStateDataProvider(DataSource dataSource) {
        setDataSource(dataSource);
    }

    /**
     * Gets Application State table value based on a key
     * 
     * @param key
     * @return String value
     */
    public String getStateAsString(String key) {

        try {

            logger.debug("Getting value as String for: " + key);

            return (String) getJdbcTemplate().queryForObject(SQL_SELECT,
                    new Object[] { key }, String.class);

        } catch (Exception ex) {
            ex.printStackTrace();
            logger.error(ex.getMessage(), ex);
            throw new RuntimeException("Error while obtaining data: "
                    + ex.getMessage(), ex);
        }

    }

    /**
     * Sets application value as string
     * 
     * @param key
     * @param value
     */
    public void setState(String key, String value) {

        try {

            logger.debug("Setting value for: " + key + " as: " + value);

            getJdbcTemplate().update(SQL_UPDATE,
                    new Object[] { value, DateUtil.getNow(), key });

        } catch (Exception ex) {
            ex.printStackTrace();
            logger.error(ex.getMessage(), ex);
            throw new RuntimeException("Error while setting data: "
                    + ex.getMessage(), ex);
        }

    }

    /**
     * Sets the application value to the current date in XML format
     * 
     * @param key
     */
    public void setStateToNowXmlDate(String key) {

        setState(key, XML_DATE_FORMATER.format(DateUtil.getNow()));

    }

}
