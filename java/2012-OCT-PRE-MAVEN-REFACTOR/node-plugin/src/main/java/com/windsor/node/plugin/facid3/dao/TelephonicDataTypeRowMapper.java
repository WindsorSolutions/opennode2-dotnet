package com.windsor.node.plugin.facid3.dao;

import java.sql.ResultSet;
import java.sql.SQLException;
import org.springframework.jdbc.core.RowMapper;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;
import com.windsor.node.plugin.facid3.domain.TelephonicDataType;

public class TelephonicDataTypeRowMapper implements RowMapper
{
    public Object mapRow(ResultSet rs, int rowNum) throws SQLException
    {
        ObjectFactory fact = new ObjectFactory();
        TelephonicDataType telephonic = fact.createTelephonicDataType();
        telephonic.setTelephoneExtensionNumberText(rs.getString("TELE_EXT_NUM_TEXT"));
        telephonic.setTelephoneNumberText(rs.getString("TELE_NUM_TEXT"));
        telephonic.setTelephoneNumberTypeName(rs.getString("TELE_NUM_TYPE_NAME"));
        return telephonic;
    }
}
