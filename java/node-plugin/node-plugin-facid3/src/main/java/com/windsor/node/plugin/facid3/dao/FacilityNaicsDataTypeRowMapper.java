package com.windsor.node.plugin.facid3.dao;

import java.sql.ResultSet;
import java.sql.SQLException;
import org.springframework.jdbc.core.RowMapper;
import com.windsor.node.plugin.facid3.domain.FacilityNAICSDataType;
import com.windsor.node.plugin.facid3.domain.FacilityNAICSPrimaryIndicatorDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;

public class FacilityNaicsDataTypeRowMapper implements RowMapper<FacilityNAICSDataType>
{

    public FacilityNAICSDataType mapRow(ResultSet rs, int rowNum) throws SQLException
    {
        ObjectFactory fact = new ObjectFactory();
        FacilityNAICSDataType facilityNaics = fact.createFacilityNAICSDataType();
        facilityNaics.setFacilityNAICSCode(rs.getString("FAC_NAICS_CODE"));

        if("Primary".equalsIgnoreCase(rs.getString("FAC_NAICS_PRI_INDI")))
        {
            facilityNaics.setFacilityNAICSPrimaryIndicator(FacilityNAICSPrimaryIndicatorDataType.PRIMARY);
        }
        else if("Secondary".equalsIgnoreCase(rs.getString("FAC_NAICS_PRI_INDI")))
        {
            facilityNaics.setFacilityNAICSPrimaryIndicator(FacilityNAICSPrimaryIndicatorDataType.SECONDARY);
        }
        else if("Unknown".equalsIgnoreCase(rs.getString("FAC_NAICS_PRI_INDI")))
        {
            facilityNaics.setFacilityNAICSPrimaryIndicator(FacilityNAICSPrimaryIndicatorDataType.UNKNOWN);
        }
        return facilityNaics;
    }

}
