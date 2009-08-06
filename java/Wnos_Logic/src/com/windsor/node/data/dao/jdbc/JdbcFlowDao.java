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
import java.sql.Types;
import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.data.dao.FlowDao;
import com.windsor.node.data.dao.ScheduleDao;
import com.windsor.node.data.dao.ServiceDao;
import com.windsor.node.data.dao.UserAccessPolicyDao;
import com.windsor.node.service.helper.IdGenerator;
import com.windsor.node.util.DateUtil;
import com.windsor.node.util.FormatUtil;

public class JdbcFlowDao extends BaseJdbcDao implements FlowDao,
        InitializingBean {

    protected static final String SQL_SELECT = "SELECT Id, InfoUrl, Contact, "
            + "IsProtected, ModifiedBy, ModifiedOn, Code, Description FROM NFlow ";

    protected static final String SQL_SELECT_NAMES = "SELECT Code FROM NFlow ORDER BY Code ";

    protected static final String SQL_SELECT_ID_EXISTS = "SELECT COUNT(*) FROM NFlow WHERE Id = ? ";

    protected static final String SQL_SELECT_CODE_EXISTS = "SELECT COUNT(*) FROM NFlow WHERE Code = ? ";

    protected static final String SQL_SELECT_ID = SQL_SELECT + "WHERE Id = ? ";

    protected static final String SQL_SELECT_NAME = SQL_SELECT
            + "WHERE Code = ? ";

    protected static final String SQL_SELECT_PROTECTED = SQL_SELECT
            + " WHERE IsProtected = 'Y' ORDER BY Code ";

    protected static final String SQL_SELECT_ORDER_BY_CODE = SQL_SELECT
            + "ORDER BY Code ";

    /**
     * SQL INSERT statement for this table
     */
    protected static final String SQL_INSERT = "INSERT INTO NFlow ( InfoUrl, Contact, IsProtected, "
            + "ModifiedBy, ModifiedOn, Code, Description, Id ) VALUES ( ?, ?, ?, ?, ?, ?, ?, ? )";

    /**
     * SQL UPDATE statement for this table
     */
    protected static final String SQL_UPDATE = "UPDATE NFlow SET InfoUrl = ?, Contact = ?, "
            + "IsProtected = ?, ModifiedBy = ?, ModifiedOn = ?, Code = ?, Description = ? WHERE Id = ?";

    /**
     * SQL DELETE statement for this table
     */
    protected static final String SQL_DELETE = "DELETE FROM NFlow WHERE Id = ?";

    private UserAccessPolicyDao userAccessPolicyDao;
    private ServiceDao serviceDao;
    private ScheduleDao scheduleDao;

    /**
     * checkDaoConfig
     */
    protected void checkDaoConfig() {

        super.checkDaoConfig();

        if (userAccessPolicyDao == null) {
            throw new RuntimeException("connectionDao Not Set");
        }
        if (serviceDao == null) {
            throw new RuntimeException("serviceDao Not Set");
        }
        if (scheduleDao == null) {
            throw new RuntimeException("scheduleDao Not Set");
        }
    }

    /**
     * get
     */
    public DataFlow get(String id) {

        validateStringArg(id);

        return (DataFlow) queryForObject(SQL_SELECT_ID, new Object[] { id },
                new FlowMapper());

    }

    public DataFlow getByCode(String code) {

        validateStringArg(code);

        return (DataFlow) queryForObject(SQL_SELECT_NAME,
                new Object[] { code }, new FlowMapper());

    }

    public DataFlow save(DataFlow instance) {

        validateObjectArg(instance, "DataFlow");

        logger.debug("Saving DataFlow:" + instance);

        String sql = SQL_UPDATE;
        if (StringUtils.isBlank(instance.getId())) {
            instance.setId(idGenerator.createId());
            sql = SQL_INSERT;
        }

        logger.debug("Flow Id: " + instance.getId());

        Object[] args = new Object[] { instance.getInfoUrl(),
                instance.getContactUserId(),
                FormatUtil.toYNFromBoolean(instance.isSecured()),
                instance.getModifiedById(), DateUtil.getTimestamp(),
                instance.getName(), instance.getDescription(), instance.getId() };

        int[] types = new int[] { Types.VARCHAR, Types.VARCHAR, Types.VARCHAR,
                Types.VARCHAR, Types.TIMESTAMP, Types.VARCHAR, Types.VARCHAR,
                Types.VARCHAR };

        printourArgs(args);

        getJdbcTemplate().update(sql, args, types);

        return instance;

    }

    /**
     * delete
     */
    public void delete(String id) {

        validateStringArg(id);

        logger.debug("Deleting flow");
        delete(SQL_DELETE, id);

    }

    /**
     * get
     */
    public List<?> get() {

        return getJdbcTemplate().query(SQL_SELECT_ORDER_BY_CODE,
                new FlowMapper());
    }

    @SuppressWarnings("unchecked")
    public List<String> getFlowNames() {
        return (List<String>) getList(SQL_SELECT_NAMES);
    }

    /*
     * (non-Javadoc)
     * 
     * @see com.windsor.node.data.dao.FlowDao#getProtectedFlows()
     */
    @SuppressWarnings("unchecked")
    public List<DataFlow> getSecuredFlows() {

        return (List<DataFlow>) getJdbcTemplate().query(SQL_SELECT_PROTECTED,
                new FlowMapper());
    }

    /**
     * FlowMapper
     * 
     * @author mchmarny
     * 
     */
    private class FlowMapper implements RowMapper {

        public Object mapRow(ResultSet rs, int rowNum) throws SQLException {

            DataFlow obj = new DataFlow();

            obj.setId(rs.getString("Id"));
            obj.setInfoUrl(rs.getString("InfoUrl"));
            obj.setContactUserId(rs.getString("Contact"));
            obj.setSecured(FormatUtil.toBooleanFromYN(rs
                    .getString("IsProtected")));
            obj.setModifiedById(rs.getString("ModifiedBy"));
            obj.setModifiedOn(rs.getTimestamp("ModifiedOn"));
            obj.setName(rs.getString("Code"));
            obj.setDescription(rs.getString("Description"));
            obj.setServices(serviceDao.getByFlowId(obj.getId()));

            return obj;

        }

    }

    public void setUserAccessPolicyDao(UserAccessPolicyDao userAccessPolicyDao) {
        this.userAccessPolicyDao = userAccessPolicyDao;
    }

    public void setServiceDao(ServiceDao serviceDao) {
        this.serviceDao = serviceDao;
    }

    public void setScheduleDao(ScheduleDao scheduleDao) {
        this.scheduleDao = scheduleDao;
    }

    public void setIdGenerator(IdGenerator idGenerator) {
        this.idGenerator = idGenerator;
    }

}
