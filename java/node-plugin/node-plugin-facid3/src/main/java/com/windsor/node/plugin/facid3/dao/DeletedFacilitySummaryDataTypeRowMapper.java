package com.windsor.node.plugin.facid3.dao;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Calendar;
import java.util.GregorianCalendar;
import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeConstants;
import javax.xml.datatype.DatatypeFactory;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.jdbc.core.RowMapper;
import com.windsor.node.plugin.facid3.domain.DataSourceDataType;
import com.windsor.node.plugin.facid3.domain.FacilitySiteIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.FacilitySummaryDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;

public class DeletedFacilitySummaryDataTypeRowMapper implements RowMapper<FacilitySummaryDataType>
{
    protected Logger logger = LoggerFactory.getLogger(getClass());

    public FacilitySummaryDataType mapRow(ResultSet rs, int rowNum) throws SQLException
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
            GregorianCalendar cal = new GregorianCalendar();
            cal.setTime(rs.getDate("LAST_UPDT_DATE"));
            dataSource.setLastUpdatedDate(datatypeFactory.newXMLGregorianCalendarDate(cal.get(Calendar.YEAR), cal.get(Calendar.MONTH) + 1, cal.get(Calendar.DAY_OF_MONTH), DatatypeConstants.FIELD_UNDEFINED));
        }
        dataSource.setOriginatingPartnerName(rs.getString("ORIG_PART_NAME"));

        FacilitySiteIdentifierDataType facilitySiteIdentifier = fact.createFacilitySiteIdentifierDataType();
        facilitySummary.setFacilitySiteIdentifier(facilitySiteIdentifier);
        facilitySiteIdentifier.setFacilitySiteIdentifierContext(rs.getString("FAC_SITE_IDEN_CONT"));
        facilitySiteIdentifier.setValue(rs.getString("FAC_SITE_IDEN_VAL"));

        return facilitySummary;
    }

}
