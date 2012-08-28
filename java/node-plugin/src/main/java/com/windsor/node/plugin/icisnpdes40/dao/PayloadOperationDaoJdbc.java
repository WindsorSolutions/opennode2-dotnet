package com.windsor.node.plugin.icisnpdes40.dao;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;

import javax.sql.DataSource;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.plugin.icisnpdes40.domain.PayloadOperation;

/**
 * A JDBC implementation of the {@link PayloadOperationDao}.
 * 
 */
public class PayloadOperationDaoJdbc implements PayloadOperationDao {

    /**
     * A complete SQL statement to find all ICS_PAYLOAD that are enabled to be
     * submitted to ICIS.
     */
    private static final String SQL_SELECT_FILTER_BY_ENABLED_YES = "select * from ICS_PAYLOAD where enabled = 'Y'";

    /**
     * The ICS_PAYLOAD primary key column name.
     */
    private static final String SQL_COL_PAYLOAD_ID = "ics_payload_id";
    
    /**
     * The ICS_PAYLOAD operation column name.
     */
    private static final String SQL_COL_OPERATION = "operation";
    
    
    /**
     * The datasource where the ICS_PAYLOAD table is located.
     */
    private DataSource dataSource;
    
    /**
     * Default constructor.
     * 
     * @param dataSource
     *            where the ICS_PAYLOAD table is located.
     */
    public PayloadOperationDaoJdbc(DataSource dataSource) {
        this.dataSource = dataSource;
    }
    
    /**
     * {@inheritDoc}
     */
    @SuppressWarnings("unchecked")
    @Override
    public List<PayloadOperation> findPayloadsToSubmit() {
        
        JdbcTemplate jdbcTemplate = new JdbcTemplate(getDataSource());
        
        return jdbcTemplate.query(SQL_SELECT_FILTER_BY_ENABLED_YES, new RowMapper() {
            
            @Override
            public Object mapRow(ResultSet rs, int rowNum) throws SQLException {
                
                return new PayloadOperation(
                            rs.getString(SQL_COL_PAYLOAD_ID), 
                            rs.getString(SQL_COL_OPERATION), 
                            Boolean.TRUE);
            }
        });
    }

    private DataSource getDataSource() {
        return this.dataSource;
    }
}
