package com.windsor.node.plugin.facid3.dao;

import java.sql.ResultSet;
import java.sql.SQLException;

import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.plugin.facid3.domain.generated.DataSourceDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilitySiteIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilitySummaryDataType;
import com.windsor.node.plugin.facid3.domain.generated.ObjectFactory;

public class DeletedFacilitySummaryDataTypeRowMapper implements RowMapper
{
    protected Logger logger = LoggerFactory.getLogger(getClass());

    @Override
	public Object mapRow(ResultSet rs, int rowNum) throws SQLException
    {
        ObjectFactory fact = new ObjectFactory();
        DatatypeFactory datatypeFactory = null;
        try
        {
            datatypeFactory = DatatypeFactory.newInstance();
        }
        catch(DatatypeConfigurationException e)
        {
            logger.warn("A serious configuration error occured when trying to create a factory to handle XML date objects, recovering, but no dates can be parsed or included in file.",
                        e.getMessage());
        }

        FacilitySummaryDataType facilitySummary = fact.createFacilitySummaryDataType();
        facilitySummary.setFacilitySiteName(rs.getString("FAC_SITE_NAME"));

        DataSourceDataType dataSource = fact.createDataSourceDataType();
        facilitySummary.setDataSource(dataSource);
        dataSource.setInformationSystemAcronymName(rs.getString("INFO_SYS_ACRO_NAME"));
        if(rs.getString("LAST_UPDT_DATE") != null && datatypeFactory != null)
        {
            dataSource.setLastUpdatedDate(rs.getDate("LAST_UPDT_DATE"));
        }
        dataSource.setOriginatingPartnerName(rs.getString("ORIG_PART_NAME"));

        FacilitySiteIdentifierDataType facilitySiteIdentifier = fact.createFacilitySiteIdentifierDataType();
        facilitySummary.setFacilitySiteIdentifier(facilitySiteIdentifier);
        facilitySiteIdentifier.setFacilitySiteIdentifierContext(rs.getString("FAC_SITE_IDEN_CONT"));

        return facilitySummary;
    }

}
