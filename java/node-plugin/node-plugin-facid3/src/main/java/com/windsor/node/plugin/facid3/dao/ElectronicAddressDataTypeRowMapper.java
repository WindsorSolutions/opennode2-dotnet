package com.windsor.node.plugin.facid3.dao;

import java.sql.ResultSet;
import java.sql.SQLException;
import org.springframework.jdbc.core.RowMapper;
import com.windsor.node.plugin.facid3.domain.ElectronicAddressDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;

public class ElectronicAddressDataTypeRowMapper implements RowMapper<ElectronicAddressDataType>
{

    public ElectronicAddressDataType mapRow(ResultSet rs, int rowNum) throws SQLException
    {
        ObjectFactory fact = new ObjectFactory();
        ElectronicAddressDataType electronicAddress = fact.createElectronicAddressDataType();
        electronicAddress.setElectronicAddressText(rs.getString("ELEC_ADDR_TEXT"));
        electronicAddress.setElectronicAddressTypeName(rs.getString("ELEC_ADDR_TYPE_NAME"));

        return electronicAddress;
    }

}
