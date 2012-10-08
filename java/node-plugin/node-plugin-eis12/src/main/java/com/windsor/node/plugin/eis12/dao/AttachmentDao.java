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

package com.windsor.node.plugin.eis12.dao;

import javax.sql.DataSource;

import org.springframework.dao.EmptyResultDataAccessException;

import com.windsor.node.plugin.common.dao.BaseJdbcDao;
import com.windsor.node.plugin.eis12.DataCategory;

/**
 * *
 * 
 * @author jniski
 * 
 */
public class AttachmentDao extends BaseJdbcDao {

    public static final String SQL_GET_CERS_ID = "select CERS_ID from CERS_CERS where DATA_CATEGORY = ? "
            + "and EMIS_YEAR = ? ";

    public static final String SQL_GET_EVENT_FILENAME = "select ATCH_FILE_NAME from CERS_EVENT where CERS_ID in ( "
            + SQL_GET_CERS_ID + R_PAREN;

    public static final String SQL_GET_NDC_DATA_FILENAME = "select ATCH_FILE_NAME from CERS_LOC where CERS_ID in ( "
            + SQL_GET_CERS_ID + R_PAREN;

    public AttachmentDao(DataSource dataSource) {

        super();
        super.setDataSource(dataSource);
    }

    public String getFilename(DataCategory dataCategory, String emissionYear) {

        String fileName = null;
        String sql = null;

        if (dataCategory.equals(DataCategory.Event)) {

            sql = SQL_GET_EVENT_FILENAME;

        } else if (dataCategory.equals(DataCategory.OnAndNonRoad)) {

            sql = SQL_GET_NDC_DATA_FILENAME;

        } else {

            throw new IllegalArgumentException(
                    "dataCategory must be either Event or OnAndNonRoad");
        }

        try {

            logger.debug(sql);

            fileName = (String) getJdbcTemplate().queryForObject(sql,
                    new Object[] { dataCategory.toString(), emissionYear },
                    String.class);

        } catch (EmptyResultDataAccessException e) {

            logger.debug("No filename found, but that's ok");
        }

        logger.debug("fileName: " + fileName);
        return fileName;
    }
}
