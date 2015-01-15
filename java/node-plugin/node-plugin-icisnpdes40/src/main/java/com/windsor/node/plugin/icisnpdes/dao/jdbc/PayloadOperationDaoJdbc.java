package com.windsor.node.plugin.icisnpdes.dao.jdbc;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;

import javax.sql.DataSource;

import org.springframework.jdbc.core.RowMapper;
import org.springframework.jdbc.core.support.JdbcDaoSupport;

import com.windsor.node.plugin.icisnpdes.dao.PayloadOperationDao;
import com.windsor.node.plugin.icisnpdes.domain.PayloadOperation;

/**
 * A JDBC implementation of the {@link PayloadOperationDao}.
 * 
 */
public class PayloadOperationDaoJdbc extends JdbcDaoSupport implements PayloadOperationDao {

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
     * Default constructor.
     * 
     * @param dataSource
     *            where the ICS_PAYLOAD table is located.
     */
    public PayloadOperationDaoJdbc(DataSource dataSource) {
        setDataSource(dataSource);
    }
    
    /**
     * {@inheritDoc}
     */
    @SuppressWarnings("unchecked")
    @Override
    public List<PayloadOperation> findPayloadsToSubmit() {
        
        return getJdbcTemplate().query(SQL_SELECT_FILTER_BY_ENABLED_YES, new RowMapper() {
            
            @Override
            public Object mapRow(ResultSet rs, int rowNum) throws SQLException {
                
                return new PayloadOperation(
                            rs.getString(SQL_COL_PAYLOAD_ID), 
                            rs.getString(SQL_COL_OPERATION), 
                            Boolean.TRUE);
            }
        });
    }
}
