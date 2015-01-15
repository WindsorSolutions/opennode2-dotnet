package com.windsor.node.plugin.icisnpdes.submission;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;
import java.util.HashMap;
import java.util.Map;

import javax.sql.DataSource;

import org.apache.commons.lang3.StringUtils;
import org.springframework.dao.DataAccessException;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.jdbc.core.SqlOutParameter;
import org.springframework.jdbc.object.StoredProcedure;

/**
 * Wrapper class to execute ETL stored procedure.
 */
public class ETLStoredProcedure extends StoredProcedure {

    private static final String OUT_WORKFLOW_ID = "p_ics_subm_track_id";

    /**
     * Default constructor.
     * 
     * @param dataSource
     *            the configured {@link DataSource} containing the ETL stored
     *            procedure.
     * @param sprocName
     *            the name of the ETL stored procedure.
     */
    public ETLStoredProcedure(DataSource dataSource, String sprocName) {
        super(dataSource, StringUtils.trim(sprocName));
        declareParameter(new SqlOutParameter(OUT_WORKFLOW_ID, Types.VARCHAR,
                new RowMapper() {

                    @Override
                    public Object mapRow(ResultSet rs, int rowNum)
                            throws SQLException {
                        return rs.getString(OUT_WORKFLOW_ID);
                    }
                }));
        compile();
    }

    /**
     * Execute the ETL stored procedure returning the workflow id.
     * 
     * @return workflow id.
     * @throws DataAccessException
     *             when execution fails.
     */
    public String execute() throws DataAccessException {
        Map<String, Object> out = super.execute(new HashMap<String, Object>());
        return (String)out.get(OUT_WORKFLOW_ID);
    }
}