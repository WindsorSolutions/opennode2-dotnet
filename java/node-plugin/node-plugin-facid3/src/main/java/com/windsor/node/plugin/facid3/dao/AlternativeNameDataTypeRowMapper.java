package com.windsor.node.plugin.facid3.dao;

import java.sql.ResultSet;
import java.sql.SQLException;

import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.plugin.facid3.domain.generated.AlternativeNameDataType;
import com.windsor.node.plugin.facid3.domain.generated.ObjectFactory;

public class AlternativeNameDataTypeRowMapper implements RowMapper
{
    @Override
	public Object mapRow(ResultSet rs, int rowNum) throws SQLException
    {
        ObjectFactory fact = new ObjectFactory();
        AlternativeNameDataType alternativeName = fact.createAlternativeNameDataType();
        alternativeName.setAlternativeNameText(rs.getString("ALT_NAME_TEXT"));
        alternativeName.setAlternativeNameTypeText(rs.getString("ALT_NAME_TYPE_TEXT"));
        return alternativeName;
    }
}
