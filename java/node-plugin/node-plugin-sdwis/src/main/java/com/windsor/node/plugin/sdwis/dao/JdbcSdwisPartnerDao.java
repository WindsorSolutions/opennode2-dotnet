package com.windsor.node.plugin.sdwis.dao;

import java.net.MalformedURLException;
import java.net.URL;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;
import java.util.List;
import org.springframework.dao.DataAccessException;
import org.springframework.jdbc.core.RowMapper;
import com.windsor.node.common.domain.EndpointVersionType;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.data.dao.jdbc.JdbcPartnerDao;

public class JdbcSdwisPartnerDao extends JdbcPartnerDao
{
    private static final String SQL_SELECT_URL = "SELECT Id, Name, Url, ModifiedBy, ModifiedOn, Version FROM NPartner WHERE UPPER(Url) = UPPER(?) ";

    public PartnerIdentity getByUrl(String url)
    {
        validateStringArg(url);
        return (PartnerIdentity)queryForObject(SQL_SELECT_URL, new Object[]{url}, new int[]{Types.VARCHAR}, new PartnerMapper());
    }

    // FIXME remove this as soon as 2.0 is out
    private class PartnerMapper implements RowMapper
    {
        public Object mapRow(ResultSet rs, int rowNum) throws SQLException
        {
            PartnerIdentity obj = new PartnerIdentity();
            try
            {
                obj.setId(rs.getString("Id"));
                obj.setName(rs.getString("Name"));
                obj.setUrl(new URL(rs.getString("Url")));
                obj.setModifiedById(rs.getString("ModifiedBy"));
                obj.setModifiedOn(rs.getTimestamp("ModifiedOn"));
                obj.setVersion(EndpointVersionType.fromString(rs.getString("Version")));
            }
            catch(MalformedURLException mue)
            {
                throw new SQLException("Url format error. How did it get into the Db?");
            }
            return obj;
        }
    }

    public Object queryForObject(String sql, Object[] args, int[] argTypes, RowMapper rowMapper) throws DataAccessException
    {
        logger.debug("SQL: " + sql);
        printourArgs(args);
        List<?> result = getJdbcTemplate().query(sql, args, argTypes, rowMapper);
        if(result == null || result.size() < 1)
        {
            return null;
        }
        else
        {
            return result.get(0);
        }
    }
}
