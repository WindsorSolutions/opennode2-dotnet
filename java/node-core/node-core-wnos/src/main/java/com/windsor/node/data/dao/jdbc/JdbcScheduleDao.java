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
import java.sql.Timestamp;
import java.sql.Types;
import java.util.List;

import org.apache.commons.lang3.StringUtils;
import org.apache.commons.lang3.math.NumberUtils;
import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.common.domain.ScheduleArgument;
import com.windsor.node.common.domain.ScheduleExecuteStatus;
import com.windsor.node.common.domain.ScheduleFrequencyType;
import com.windsor.node.common.domain.ScheduledItem;
import com.windsor.node.common.domain.ScheduledItemSourceType;
import com.windsor.node.common.domain.ScheduledItemTargetType;
import com.windsor.node.data.dao.ActivityDao;
import com.windsor.node.data.dao.ScheduleDao;
import com.windsor.node.util.DateUtil;
import com.windsor.node.util.FormatUtil;

public class JdbcScheduleDao extends BaseJdbcDao implements ScheduleDao {

    private ActivityDao activityDao;

    /**
     * SQL SELECT statement for this table
     */
    protected static final String SQL_SELECT_ARG = "SELECT Id, ArgKey, ArgValue FROM NScheduleSourceArg "
            + "WHERE ScheduleId = ? ORDER BY ArgKey ";

    /**
     * SQL INSERT statement for this table
     */
    protected static final String SQL_INSERT_ARG = "INSERT INTO NScheduleSourceArg "
            + "( Id, ScheduleId, ArgKey, ArgValue ) VALUES ( ?, ?, ?, ? )";

    /**
     * SQL DELETE statement for this table
     */
    protected static final String SQL_DELETE_ARG = "DELETE FROM NScheduleSourceArg WHERE ScheduleId = ?";

    /**
     * All finder methods in this class use this SELECT constant to build their
     * queries
     */
    private static final String SQL_SELECT = "SELECT Id, Name, FlowId, StartOn, EndOn, "
            + " SourceType, SourceId, SourceOperation, TargetType, TargetId, "
            + " LastExecutionInfo, LastExecutedOn, NextRun, FrequencyType, "
            + " Frequency, ModifiedBy, ModifiedOn, IsActive, "
            + " IsRunNow, ExecuteStatus, SourceFlow, TargetFlow, TargetOperation, "
            + " LastExecuteActivityId FROM NSchedule ";

    private static final String SQL_SELECT_ID = SQL_SELECT + " WHERE Id = ? ";

    private static final String SQL_SELECT_ALL = SQL_SELECT + " ORDER BY Name ";

    private static final String SQL_SELECT_FOR_EXEC = SQL_SELECT
            + " WHERE ((IsRunNow = ?) OR (((NextRun IS NOT NULL) AND (? > NextRun)) "
            + " AND (? BETWEEN StartOn AND EndOn) AND (IsActive = 'Y'))) ";

    private static final String SQL_UPDATE_FOR_EXEC = "UPDATE NSchedule SET ExecuteStatus = ?, IsRunNow = 'N' "
            + " WHERE Id = ? AND ExecuteStatus != ? ";

    /**
     * SQL INSERT statement for this table
     */
    private static final String SQL_INSERT = "INSERT INTO NSchedule ( Name, FlowId, StartOn, EndOn, "
            + "SourceType, SourceId, SourceOperation, TargetType, TargetId, LastExecutionInfo, "
            + "LastExecutedOn, NextRun, FrequencyType, Frequency, ModifiedBy, ModifiedOn, IsActive, "
            + "IsRunNow, ExecuteStatus, SourceFlow, TargetFlow, TargetOperation, LastExecuteActivityId, Id) "
            + "VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ? )";

    /**
     * SQL UPDATE statement for this table
     */
    private static final String SQL_UPDATE = "UPDATE NSchedule SET Name = ?, FlowId = ?, "
            + " StartOn = ?, EndOn = ?, SourceType = ?, SourceId = ?, SourceOperation = ?, "
            + " TargetType = ?, TargetId = ?, LastExecutionInfo = ?, LastExecutedOn = ?, "
            + " NextRun = ?, FrequencyType = ?, Frequency = ?, ModifiedBy = ?, ModifiedOn = ?, "
            + " IsActive = ?, IsRunNow = ?, ExecuteStatus = ?, SourceFlow = ?, "
            + " TargetFlow = ?, TargetOperation = ?, LastExecuteActivityId = ? WHERE Id = ?";

    /**
     * SQL UPDATE statement for this table
     */
    @Deprecated
    private static final String SQL_UPDATE_NEXT = "UPDATE NSchedule SET NextRun = ?, IsRunNow = 'N' WHERE Id = ?";

    @Deprecated
    private static final String SQL_UPDATE_INFO = "UPDATE NSchedule SET LastExecutedOn = ?, LastExecutionInfo = ?, "
            + "ExecuteStatus = ?, IsRunNow = 'N' WHERE Id = ?";

    /**
     * SQL DELETE statement for this table
     */
    private static final String SQL_DELETE = "DELETE FROM NSchedule WHERE Id = ?";

    /**
     * SQL DELETE statement for this table
     */
    private static final String SQL_DELETE_FLOW = "DELETE FROM NSchedule WHERE FlowId = ?";

    /**
     * get
     */
    @Override
	public ScheduledItem get(String id) {

        validateStringArg(id);

        return (ScheduledItem) queryForObject(SQL_SELECT_ID,
                new Object[] { id }, new ScheduleMapper());
    }

    @Override
	@Deprecated
    public void setRunInfo(String scheduleId, String info,
            ScheduleExecuteStatus executeStatus) {

        if (StringUtils.isBlank(scheduleId)) {
            throw new RuntimeException("scheduleId not set.");
        }

        if (executeStatus == null) {
            throw new RuntimeException("executeStatus not set.");
        }

        if (StringUtils.isBlank(info)) {
            return;
        }

        // UPDATE NSchedule SET
        // LastExecutedOn = ?,
        // LastExecutionInfo = ?,
        // ExecuteStatus = ?
        // WHERE Id = ?
        Object[] args = new Object[] { DateUtil.getTimestamp(), info,
                executeStatus.name(), scheduleId };

        int[] types = new int[] { Types.TIMESTAMP, Types.VARCHAR,
                Types.VARCHAR, Types.VARCHAR };

        getJdbcTemplate().update(SQL_UPDATE_INFO, args, types);

    }

    /**
     * setRun
     */
    @Override
	@Deprecated
    public void setRun(String scheduleId, Timestamp time) {

        if (StringUtils.isBlank(scheduleId)) {
            throw new RuntimeException("scheduleId not set.");
        }

        logger.debug("setting nextRun to " + time + " for schedule id "
                + scheduleId);

        Object[] args = new Object[2];

        args[0] = time;
        args[1] = scheduleId;

        int[] types = new int[2];
        types[0] = Types.TIMESTAMP;
        types[1] = Types.VARCHAR;

        getJdbcTemplate().update(SQL_UPDATE_NEXT, args, types);

    }

    /**
     * save
     */
    @Override
	public ScheduledItem save(ScheduledItem instance) {

        validateObjectArg(instance, "ScheduledItem");

        String sql = SQL_UPDATE;
        if (StringUtils.isBlank(instance.getId())) {
            instance.setId(idGenerator.createId());
            sql = SQL_INSERT;
        }

        logger.debug("Deleting schedule arguments...");

        // delete ScheduleSourceArgs
        delete(SQL_DELETE_ARG, instance.getId());

        logger.debug("Setting schedule save arguments from: " + instance);

        Object[] args = scheduleToFieldArray(instance);

        int[] types = jdbcTypesForScheduledItem();

        logger.debug("SQL: " + sql);

        printourArgs(args);

        getJdbcTemplate().update(sql, args, types);

        //saveSourceArgs(instance.getSourceArgs(), instance.getId());
        saveScheduleArguments(instance);

        return get(instance.getId());

    }

    private Object[] scheduleToFieldArray(ScheduledItem instance) {

        // CHECKSTYLE:OFF
        Object[] args = new Object[24];

        // Name
        args[0] = instance.getName();
        // FlowId
        args[1] = instance.getFlowId();
        // StartOn
        args[2] = instance.getStartOn();
        // EndOn
        args[3] = instance.getEndOn();
        // SourceType
        args[4] = instance.getSourceType().toString();
        // SourceId
        args[5] = instance.getSourceId();
        // SourceOperation
        args[6] = instance.getSourceOperation();
        // TargetType
        args[7] = instance.getTargetType().toString();
        // TargetId
        args[8] = instance.getTargetId();
        // LastExecutionInfo
        args[9] = instance.getLastExecutionInfo();
        // LastExecutedOn
        args[10] = instance.getLastExecutedOn();
        // NextRun
        args[11] = instance.getNextRunOn();
        // FrequencyType
        args[12] = instance.getFrequencyType().toString();
        // Frequency
        args[13] = new Integer(instance.getFrequency());
        // ModifiedBy
        args[14] = instance.getModifiedById();
        // ModifiedOn
        args[15] = DateUtil.getTimestamp();
        // IsActive
        args[16] = FormatUtil.toYNFromBoolean(instance.isActive());
        // IsRunNow
        args[17] = FormatUtil.toYNFromBoolean(instance.isRunNow());
        // ExecuteStatus
        args[18] = instance.getExecuteStatus().name();

        args[19] = instance.getSourceFlow();//SourceFlow
        args[20] = instance.getTargetFlow();//TargetFlow
        args[21] = instance.getTargetOperation();//TargetOperation
        if(instance.getLastExecutionActivity() != null)
        {
            args[22] = instance.getLastExecutionActivity().getId();//LastExecuteActivityId
        }

        //id
        args[23] = instance.getId();

        return args;
    }

    private int[] jdbcTypesForScheduledItem() {

        // CHECKSTYLE:OFF

        int[] types = new int[24];
        // Name
        types[0] = Types.VARCHAR;
        // FlowId
        types[1] = Types.VARCHAR;
        // StartOn
        types[2] = Types.TIMESTAMP;
        // EndOn
        types[3] = Types.TIMESTAMP;
        // SourceType
        types[4] = Types.VARCHAR;
        // SourceId
        types[5] = Types.VARCHAR;
        // SourceOperation
        types[6] = Types.VARCHAR;
        // TargetType
        types[7] = Types.VARCHAR;
        // TargetId
        types[8] = Types.VARCHAR;
        // LastExecutionInfo
        types[9] = Types.VARCHAR;
        // LastExecutedOn
        types[10] = Types.TIMESTAMP;
        // NextRun
        types[11] = Types.TIMESTAMP;
        // FrequencyType
        types[12] = Types.VARCHAR;
        // Frequency
        types[13] = Types.INTEGER;
        // ModifiedBy
        types[14] = Types.VARCHAR;
        // ModifiedOn
        types[15] = Types.TIMESTAMP;
        // IsActive
        types[16] = Types.VARCHAR;
        // IsRunNow
        types[17] = Types.VARCHAR;
        // ExecuteStatus
        types[18] = Types.VARCHAR;

        types[19] = Types.VARCHAR;//SourceFlow
        types[20] = Types.VARCHAR;//TargetFlow
        types[21] = Types.VARCHAR;//TargetOperation
        types[22] = Types.VARCHAR;//LastExecuteActivityId

        // Id
        types[23] = Types.VARCHAR;
        // CHECKSTYLE:ON

        return types;
    }

    /*private void saveSourceArgs(ByIndexOrNameMap sourceArgs, String scheduleId) {

        validateObjectArg(sourceArgs, "ByIndexOrNameMap");

        int[] types = new int[] { Types.VARCHAR, Types.VARCHAR, Types.VARCHAR,
                Types.VARCHAR };

        Object[] args = new Object[types.length];
        Set<?> keySet = sourceArgs.keySet();
        Iterator<?> i = keySet.iterator();

        while (i.hasNext()) {
            String name = (String) i.next();
            args[0] = idGenerator.createId();
            args[1] = scheduleId;
            args[2] = name;
            args[3] = ((String) sourceArgs.get(name)).trim();

            getJdbcTemplate().update(SQL_INSERT_ARG, args, types);
        }
    }*/
    private void saveScheduleArguments(ScheduledItem instance)
    {
        if(instance == null || instance.getScheduleArguments() == null)
        {
            //maybe an error?
            return;
        }
        int[] types = new int[] { Types.VARCHAR, Types.VARCHAR, Types.VARCHAR,
                        Types.VARCHAR };
        Object[] args = new Object[types.length];
        
        for(int i = 0; i < instance.getScheduleArguments().size(); i++)
        {
            ScheduleArgument current = instance.getScheduleArguments().get(i);
            if(current != null && StringUtils.isNotBlank(current.getArgumentValue()))
            {
                args[0] = idGenerator.createId();
                args[1] = instance.getId();
                args[2] = current.getArgumentKey();
                args[3] = current.getArgumentValue();
                getJdbcTemplate().update(SQL_INSERT_ARG, args, types);
            }
        }
    }

    /**
     * delete
     */
    @Override
	public void delete(String id) {

        validateStringArg(id);

        // delete ScheduleSourceArgs
        delete(SQL_DELETE_ARG, id);
        // now dekete the Schedule
        delete(SQL_DELETE, id);

    }

    /**
     * deleteByFlowId
     */
    @Override
	public void deleteByFlowId(String id) {

        validateStringArg(id);
        /*
         * we rely on the databse to cascade deletes, and have a unit test to
         * verify
         */
        delete(SQL_DELETE_FLOW, id);
    }

    @Override
	public List<ScheduledItem> get()
    {
        return getJdbcTemplate().query(SQL_SELECT_ALL, new ScheduleMapper());
    }

    /**
     * Returns a single schedule for execution; makes sure the schedule is not
     * already running.
     * 
     * @return the ScheduledItem to run
     */
    @Override
	public ScheduledItem getForNextExec() {

        ScheduledItem item = null;

        // NOTE: When disconnected this returns an invalid time (?)
        Timestamp now = DateUtil.getTimestamp();

        logger.debug("Now: " + now);

        List<?> schedules = getJdbcTemplate().query(SQL_SELECT_FOR_EXEC,
                new Object[] { FormatUtil.YES, now, now },
                new int[] { Types.VARCHAR, Types.TIMESTAMP, Types.TIMESTAMP },
                new ScheduleMapper());

        logger.debug("Found: " + schedules.size());

        for (int i = 0; i < schedules.size(); i++) {

            item = (ScheduledItem) schedules.get(i);

            Object[] args = new Object[3];

            args[0] = ScheduleExecuteStatus.Running.name();
            args[1] = item.getId();
            args[2] = ScheduleExecuteStatus.Running.name();

            getJdbcTemplate().update(SQL_UPDATE_FOR_EXEC, args);

        }

        // returning null is ok
        return item;

    }

    /**
     * ScheduleMapper
     * 
     * @author mchmarny
     * 
     */
    private class ScheduleMapper implements RowMapper<ScheduledItem> {

        @Override
		public ScheduledItem mapRow(ResultSet rs, int rowNum) throws SQLException {

            ScheduledItem item = new ScheduledItem();

            // Id
            item.setId(rs.getString("Id"));
            // FlowId
            item.setFlowId(rs.getString("FlowId"));
            // Name
            item.setName(rs.getString("Name"));
            // StartOn
            item.setStartOn(rs.getTimestamp("StartOn"));
            // EndOn
            item.setEndOn(rs.getTimestamp("EndOn"));

            // SourceType
            item.setSourceType(ScheduledItemSourceType
                    .valueOf(rs.getString("SourceType")));

            // SourceId
            item.setSourceId(rs.getString("SourceId"));
            // SourceOperation
            item.setSourceOperation(rs.getString("SourceOperation"));

            // SourceArgs, changed this to be an actual object, this was very hard to work with beforehand.
            List<ScheduleArgument> args = getJdbcTemplate().query(SQL_SELECT_ARG, new Object[] {rs.getString("Id")}, new RowMapper<ScheduleArgument>(){
                @Override
				public ScheduleArgument mapRow(ResultSet rs, int rowNum) throws SQLException
                {
                    ScheduleArgument arg = new ScheduleArgument();
                    arg.setId(rs.getString("Id"));
                    arg.setArgumentKey(rs.getString("ArgKey"));
                    arg.setArgumentValue(rs.getString("ArgValue"));
                    return arg;
                }
            });
            if(args != null)
            {
                //handle missing arg keys
                //FIXME org.apache.commons.collections.list.LazyList may eliminate the need for this crufty loop
                for(int i = 0, y = 0; i < args.size(); i++, y++)
                {
                    while(NumberUtils.isNumber(args.get(i).getArgumentKey()) && y != Integer.parseInt(args.get(i).getArgumentKey()))
                    {
                        ScheduleArgument newArg = new ScheduleArgument();
                        String newKey = "" + (y);
                        while(newKey.length() < 3)
                        {
                            newKey = "0" + newKey;
                        }
                        newArg.setArgumentKey(newKey);
                        item.getScheduleArguments().add(newArg);
                        y++;
                    }
                    item.getScheduleArguments().add(args.get(i));
                }
            }
            //add N more blank ones, hopefully this won't cause a problem, a bit bigger as the AQS plugin is beyond the pale
            //moved to EditScheduleController as a test
            /*int initialSize = item.getScheduleArguments().size();
            for(int i = initialSize; i < initialSize+30; i++)
            {
                ScheduleArgument newArg = new ScheduleArgument();
                String newKey = "" + (i);
                while(newKey.length() < 3)
                {
                    newKey = "0" + newKey;
                }
                newArg.setArgumentKey(newKey);
                item.getScheduleArguments().add(newArg);
            }*/

            // TargetType
            item.setTargetType(ScheduledItemTargetType
                    .valueOf(rs.getString("TargetType")));

            // TargetId
            item.setTargetId(rs.getString("TargetId"));
            // LastExecutionInfo
            item.setLastExecutionInfo(rs.getString("LastExecutionInfo"));
            // LastExecutedOn
            item.setLastExecutedOn(rs.getTimestamp("LastExecutedOn"));
            // NextRun
            item.setNextRunOn(rs.getTimestamp("NextRun"));

            // FrequencyType
            item.setFrequencyType(ScheduleFrequencyType.valueOf(rs.getString("FrequencyType")));

            // Frequency
            item.setFrequency(rs.getInt("Frequency"));
            // ModifiedBy
            item.setModifiedById(rs.getString("ModifiedBy"));
            // ModifiedOn
            item.setModifiedOn(rs.getTimestamp("ModifiedOn"));
            // IsActive
            item.setActive(FormatUtil.toBooleanFromYN(rs.getString("IsActive")));
            // IsRunNow
            item.setRunNow(FormatUtil.toBooleanFromYN(rs.getString("IsRunNow")));

            // ExecuteStatus
            item.setExecuteStatus(ScheduleExecuteStatus
                    .valueOf(rs.getString("ExecuteStatus")));

            item.setSourceFlow(rs.getString("SourceFlow"));
            item.setTargetFlow(rs.getString("TargetFlow"));
            item.setTargetOperation(rs.getString("TargetOperation"));
            String LastExecuteActivityId = rs.getString("LastExecuteActivityId");
            if(StringUtils.isNotBlank(LastExecuteActivityId))
            {
                item.setLastExecutionActivity(getActivityDao().get(LastExecuteActivityId));
            }

            return item;

        }

    }

    public ActivityDao getActivityDao()
    {
        return activityDao;
    }

    public void setActivityDao(ActivityDao activityDao)
    {
        this.activityDao = activityDao;
    }

}
