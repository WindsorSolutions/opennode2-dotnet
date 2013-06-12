package com.windsor.node.plugin.facid3.dao;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.Set;
import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeConstants;
import javax.xml.datatype.DatatypeFactory;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.jdbc.core.RowMapper;
import com.windsor.node.plugin.facid3.domain.AffiliationDataType;
import com.windsor.node.plugin.facid3.domain.FacilityAffiliationDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;

public class FacilityAffiliationDataTypeRowMapper implements RowMapper<FacilityAffiliationDataType>
{
    protected Logger logger = LoggerFactory.getLogger(getClass());
    private Set<String> affiliationIds;

    public FacilityAffiliationDataTypeRowMapper(Set<String> affiliationIds)
    {
        setAffiliationIds(affiliationIds);
    }

    public FacilityAffiliationDataType mapRow(ResultSet rs, int rowNum) throws SQLException
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
        FacilityAffiliationDataType facilityAffiliation = fact.createFacilityAffiliationDataType();
        facilityAffiliation.setAffiliateIdentifier(rs.getString("AFFL_IDEN"));

        AffiliationDataType affiliation = fact.createAffiliationDataType();
        facilityAffiliation.setAffiliation(affiliation);
        if(rs.getString("AFFL_START_DATE") != null && datatypeFactory != null)
        {
            GregorianCalendar cal = new GregorianCalendar();
            cal.setTime(rs.getDate("AFFL_START_DATE"));
            affiliation.setAffiliationStartDate(datatypeFactory.newXMLGregorianCalendarDate(cal.get(Calendar.YEAR), cal.get(Calendar.MONTH) + 1, cal.get(Calendar.DAY_OF_MONTH), DatatypeConstants.FIELD_UNDEFINED));
        }
        if(rs.getString("AFFL_END_DATE") != null && datatypeFactory != null)
        {
            GregorianCalendar cal = new GregorianCalendar();
            cal.setTime(rs.getDate("AFFL_END_DATE"));
            affiliation.setAffiliationEndDate(datatypeFactory.newXMLGregorianCalendarDate(cal.get(Calendar.YEAR), cal.get(Calendar.MONTH) + 1, cal.get(Calendar.DAY_OF_MONTH), DatatypeConstants.FIELD_UNDEFINED));
        }
        if(rs.getString("AFFL_STAT_DETR_DATE") != null && datatypeFactory != null)
        {
            GregorianCalendar cal = new GregorianCalendar();
            cal.setTime(rs.getDate("AFFL_STAT_DETR_DATE"));
            affiliation.setAffiliationStatusDetermineDate(datatypeFactory.newXMLGregorianCalendarDate(cal.get(Calendar.YEAR), cal.get(Calendar.MONTH) + 1, cal.get(Calendar.DAY_OF_MONTH), DatatypeConstants.FIELD_UNDEFINED));
        }
        affiliation.setAffiliationStatusText(rs.getString("AFFL_STAT_TEXT"));
        affiliation.setAffiliationTypeText(rs.getString("AFFL_TYPE_TEXT"));
        //add this Affiliate's Id to the set to be looked up subsequently
        getAffiliationIds().add(facilityAffiliation.getAffiliateIdentifier());
        return facilityAffiliation;
    }

    public Set<String> getAffiliationIds()
    {
        return affiliationIds;
    }

    public void setAffiliationIds(Set<String> affiliationIds)
    {
        this.affiliationIds = affiliationIds;
    }
}
