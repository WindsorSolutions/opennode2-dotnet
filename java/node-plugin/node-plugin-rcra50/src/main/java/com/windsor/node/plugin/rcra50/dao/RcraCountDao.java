package com.windsor.node.plugin.rcra50.dao;

import javax.sql.DataSource;
import com.windsor.node.data.dao.jdbc.BaseJdbcDao;
/**
 * Dumb class that assumes you create it with a SELECT COUNT statement, does no checking and will error should you not.
 * 
 * @author tmurdock
 */
public class RcraCountDao extends BaseJdbcDao
{
    private String submissionCountSql = null;

    public RcraCountDao(DataSource dataSource)
    {
        super();
        super.setDataSource(dataSource);
    }

    protected void checkDaoConfig()
    {
        //super.checkDaoConfig();
    }

    public String getSubmissionCountSql()
    {
        return submissionCountSql;
    }

    public void setSubmissionCountSql(String submissionCountSql)
    {
        this.submissionCountSql = submissionCountSql;
    }

    public int countSubmissions()
    {
        //checkDaoConfig();
        logger.debug("running query: " + getSubmissionCountSql());
        return getJdbcTemplate().queryForObject(getSubmissionCountSql(), Integer.class);
    }
}
