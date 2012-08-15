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

package com.windsor.node.data.dao.jdbc;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;

import org.apache.commons.lang3.StringUtils;
import org.springframework.jdbc.core.RowMapper;

public class HelperDao extends BaseJdbcDao {

    public List getMapList(String sql, Object[] args, int[] types, int rowId,
            int maxRows) {

        logger.debug(sql);
        if(args != null)
        {
            if(args != null)
            {
                logger.debug(args.toString());
            }
            else
            {
                logger.debug("null");
            }
        }

        if (types != null && types.length > 0 && args != null
                && args.length > 0) {

            return getJdbcTemplate().query(sql, args, types,
                    new MapRowMapper(rowId, maxRows));

        } else {

            if (args != null && args.length > 0) {
                return getJdbcTemplate().query(sql, args,
                        new MapRowMapper(rowId, maxRows));
            } else {
                return getJdbcTemplate().query(sql,
                        new MapRowMapper(rowId, maxRows));
            }

        }

    }

    protected class MapRowMapper implements RowMapper {

        private int rowId;
        private int maxRows;

        public MapRowMapper(int rowId, int maxRows) {
            this.rowId = rowId;
            this.maxRows = maxRows;
        }

        private List colList = null;

        public Object mapRow(ResultSet rs, int rowNum) throws SQLException {

            logger.debug("row: " + rowNum);

            if (rowNum < rowId || rowNum > maxRows) {
                return null;
            }

            if (colList == null) {
                colList = new ArrayList();

                for (int i = 0; i < rs.getMetaData().getColumnCount(); i++) {
                    colList.add(rs.getMetaData().getColumnName(i + 1));
                }

                logger.debug("cols" + colList);
            }

            // This does not work!... still case SENSETIVE
            Map rowMap = new TreeMap(String.CASE_INSENSITIVE_ORDER);

            for (int i = 0; i < colList.size(); i++) {

                Object test = rs.getObject(colList.get(i).toString());
                String colName = colList.get(i).toString().toUpperCase();

                if (test == null || StringUtils.isBlank(test.toString())) {
                    rowMap.put(colName, null);
                } else {
                    rowMap.put(colName, test);
                    // rowMap.put(colName, StringEscapeUtils.escapeXml(test
                    // .toString()));
                }

            }

            return rowMap;

        }
    }

}