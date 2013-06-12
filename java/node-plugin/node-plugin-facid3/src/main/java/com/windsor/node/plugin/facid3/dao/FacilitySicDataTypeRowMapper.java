package com.windsor.node.plugin.facid3.dao;

import java.sql.ResultSet;
import java.sql.SQLException;
import org.springframework.jdbc.core.RowMapper;
import com.windsor.node.plugin.facid3.domain.FacilitySICDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;
import com.windsor.node.plugin.facid3.domain.SICPrimaryIndicatorDataType;

public class FacilitySicDataTypeRowMapper implements RowMapper<FacilitySICDataType>
{

    public FacilitySICDataType mapRow(ResultSet rs, int rowNum) throws SQLException
    {
        ObjectFactory fact = new ObjectFactory();
        FacilitySICDataType facilitySic = fact.createFacilitySICDataType();
        facilitySic.setSICCode(rs.getString("SIC_CODE"));

        if("Primary".equalsIgnoreCase(rs.getString("SIC_PRI_INDI")))
        {
            facilitySic.setSICPrimaryIndicator(SICPrimaryIndicatorDataType.PRIMARY);
        }
        else if("Secondary".equalsIgnoreCase(rs.getString("SIC_PRI_INDI")))
        {
            facilitySic.setSICPrimaryIndicator(SICPrimaryIndicatorDataType.SECONDARY);
        }
        else if("Unknown".equalsIgnoreCase(rs.getString("SIC_PRI_INDI")))
        {
            facilitySic.setSICPrimaryIndicator(SICPrimaryIndicatorDataType.UNKNOWN);
        }
        return facilitySic;
    }

}
