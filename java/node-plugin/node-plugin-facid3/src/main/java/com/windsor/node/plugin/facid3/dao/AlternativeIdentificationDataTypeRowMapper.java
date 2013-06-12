package com.windsor.node.plugin.facid3.dao;

import java.sql.ResultSet;
import java.sql.SQLException;
import org.springframework.jdbc.core.RowMapper;
import com.windsor.node.plugin.facid3.domain.AlternativeIdentificationDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;

public class AlternativeIdentificationDataTypeRowMapper implements RowMapper<AlternativeIdentificationDataType>
{

    public AlternativeIdentificationDataType mapRow(ResultSet rs, int rowNum) throws SQLException
    {
        ObjectFactory fact = new ObjectFactory();
        AlternativeIdentificationDataType alternativeIdentification = fact.createAlternativeIdentificationDataType();
        alternativeIdentification.setAlternativeIdentificationIdentifier(rs.getString("ALT_IDEN_IDEN"));
        alternativeIdentification.setAlternativeIdentificationTypeText(rs.getString("ALT_IDEN_TYPE_TEXT"));

        return alternativeIdentification;
    }

}
