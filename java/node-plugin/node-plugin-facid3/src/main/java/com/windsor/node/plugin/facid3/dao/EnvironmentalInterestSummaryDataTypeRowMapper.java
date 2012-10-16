package com.windsor.node.plugin.facid3.dao;

import java.sql.ResultSet;
import java.sql.SQLException;

import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.jdbc.core.RowMapper;

import com.windsor.node.plugin.facid3.domain.generated.DataSourceDataType;
import com.windsor.node.plugin.facid3.domain.generated.EnvironmentalInterestSummaryDataType;
import com.windsor.node.plugin.facid3.domain.generated.ObjectFactory;

public class EnvironmentalInterestSummaryDataTypeRowMapper implements RowMapper
{
    protected Logger logger = LoggerFactory.getLogger(getClass());
    private EnvironmentalInterestDataTypeDao environmentalInterestDataTypeDao;

    public EnvironmentalInterestSummaryDataTypeRowMapper(EnvironmentalInterestDataTypeDao environmentalInterestDataTypeDao)
    {
        setEnvironmentalInterestDataTypeDao(environmentalInterestDataTypeDao);
    }

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

        EnvironmentalInterestSummaryDataType environmentalInterestSummary = fact.createEnvironmentalInterestSummaryDataType();
        environmentalInterestSummary.setEnvironmentalInterestIdentifier(rs.getString("ENVR_INTR_IDEN"));
        environmentalInterestSummary.setEnvironmentalInterestTypeText(rs.getString("ENVR_INTR_TYPE_TEXT"));
        environmentalInterestSummary.setEnvironmentalInterestURLText(rs.getString("ENVR_INTR_URL_TEXT"));

        DataSourceDataType dataSource = fact.createDataSourceDataType();
        environmentalInterestSummary.setDataSource(dataSource);
        dataSource.setInformationSystemAcronymName(rs.getString("INFO_SYS_ACRO_NAME"));
        if(rs.getString("LAST_UPDT_DATE") != null && datatypeFactory != null)
        {
            dataSource.setLastUpdatedDate(rs.getDate("LAST_UPDT_DATE"));
        }
        dataSource.setOriginatingPartnerName(rs.getString("ORIG_PART_NAME"));

        return environmentalInterestSummary;
    }

    public EnvironmentalInterestDataTypeDao getEnvironmentalInterestDataTypeDao()
    {
        return environmentalInterestDataTypeDao;
    }

    public void setEnvironmentalInterestDataTypeDao(EnvironmentalInterestDataTypeDao environmentalInterestDataTypeDao)
    {
        this.environmentalInterestDataTypeDao = environmentalInterestDataTypeDao;
    }

}
