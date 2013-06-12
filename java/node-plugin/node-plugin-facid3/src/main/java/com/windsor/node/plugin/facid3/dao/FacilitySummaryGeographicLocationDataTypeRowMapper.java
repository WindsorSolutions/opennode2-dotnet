package com.windsor.node.plugin.facid3.dao;

import java.math.BigInteger;
import java.sql.ResultSet;
import java.sql.SQLException;
import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.jdbc.core.RowMapper;
import com.windsor.node.plugin.facid3.domain.DirectPositionType;
import com.windsor.node.plugin.facid3.domain.FacilitySummaryGeographicLocationDataType;
import com.windsor.node.plugin.facid3.domain.MeasureDataType;
import com.windsor.node.plugin.facid3.domain.MeasureUnitCodeListIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.MeasureUnitDataType;
import com.windsor.node.plugin.facid3.domain.MethodIdentifierCodeListIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;
import com.windsor.node.plugin.facid3.domain.PointType;
import com.windsor.node.plugin.facid3.domain.ReferenceMethodDataType;
import com.windsor.node.plugin.facid3.domain.ResultQualifierCodeListIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.ResultQualifierDataType;

public class FacilitySummaryGeographicLocationDataTypeRowMapper implements RowMapper<FacilitySummaryGeographicLocationDataType>
{
    protected Logger logger = LoggerFactory.getLogger(getClass());
    private FacilityDataTypeDao facilityDataTypeDao;

    public FacilitySummaryGeographicLocationDataTypeRowMapper(FacilityDataTypeDao facilityDataTypeDao)
    {
        setFacilityDataTypeDao(facilityDataTypeDao);
    }

    public FacilitySummaryGeographicLocationDataType mapRow(ResultSet rs, int rowNum) throws SQLException
    {
        ObjectFactory fact = new ObjectFactory();
        FacilitySummaryGeographicLocationDataType facilitySummaryGeographicLocation = fact.createFacilitySummaryGeographicLocationDataType();

        PointType point = fact.createPointType();
        facilitySummaryGeographicLocation.setPoint(point);
        //point.setId(rs.getString(""));//?
        if(StringUtils.isNumeric(rs.getString("SRS_DIM")))
        {
            point.setSrsDimension(new BigInteger(rs.getString("SRS_DIM")));
        }
        else
        {
            logger.warn("SRS Dim could not be parsed as a number, cannot include it in extract.  It was:  " + rs.getString("SRS_DIM"));
        }
        point.setSrsName(rs.getString("SRS_NAME"));

        DirectPositionType directPosition = fact.createDirectPositionType();
        point.setPos(directPosition);
        /*directPosition.setSrsDimension(bigint);
        directPosition.setSrsName(value);*/
        try
        {
            if(StringUtils.isNotBlank(rs.getString("LATITUDE")) && StringUtils.isNotBlank(rs.getString("LONGITUDE")))
            {
                directPosition.getValue().add(new Double(rs.getString("LATITUDE")));
                directPosition.getValue().add(new Double(rs.getString("LONGITUDE")));
                if(StringUtils.isNotBlank(rs.getString("ELEVATION")))
                {
                    directPosition.getValue().add(new Double(rs.getString("ELEVATION")));
                }
            }
        }
        catch(NumberFormatException e)
        {
            logger.error("Lat and/or Long was not numeric and could not be included in the document.  They were lat:  "
                            + rs.getString("LATITUDE") + " and long:  " + rs.getString("LONGITUDE")
                            + ";   If it was included, elevation may have also been in error, it was:  " + rs.getString("ELEVATION"));
            throw new RuntimeException("Lat and/or Long was not numeric and could not be included in the document.  They were lat:  "
                                       + rs.getString("LATITUDE") + " and long:  " + rs.getString("LONGITUDE")
                                       + ";   If it was included, elevation may have also been in error, it was:  " + rs.getString("ELEVATION"));
        }

        // BEGIN SC:Measure Data
        MeasureDataType horizontalMeasure = fact.createMeasureDataType();
        facilitySummaryGeographicLocation.setHorizontalAccuracyMeasure(horizontalMeasure);
        horizontalMeasure.setMeasurePrecisionText(rs.getString("MEAS_PREC_TEXT"));
        horizontalMeasure.setMeasureValue(rs.getString("MEAS_VAL"));

        MeasureUnitDataType horizontalMeasureUnit = fact.createMeasureUnitDataType();
        horizontalMeasure.setMeasureUnit(horizontalMeasureUnit);
        horizontalMeasureUnit.setMeasureUnitCode(rs.getString("MEAS_UNIT_CODE"));
        horizontalMeasureUnit.setMeasureUnitName(rs.getString("MEAS_UNIT_NAME"));

        MeasureUnitCodeListIdentifierDataType horizontalMeasureUnitCodeListIdentifier = fact.createMeasureUnitCodeListIdentifierDataType();
        horizontalMeasureUnit.setMeasureUnitCodeListIdentifier(horizontalMeasureUnitCodeListIdentifier);
        horizontalMeasureUnitCodeListIdentifier.setCodeListVersionAgencyIdentifier(rs.getString("CODE_LIST_VERS_AGN_IDEN"));
        horizontalMeasureUnitCodeListIdentifier.setCodeListVersionIdentifier(rs.getString("CODE_LIST_VERS_IDEN"));
        horizontalMeasureUnitCodeListIdentifier.setValue(rs.getString("CODE_LST_VER_VAL"));

        ResultQualifierDataType horizontalResultQualifier = fact.createResultQualifierDataType();
        horizontalMeasure.setResultQualifier(horizontalResultQualifier);
        horizontalResultQualifier.setResultQualifierCode(rs.getString("RSLT_QUAL_CODE"));
        horizontalResultQualifier.setResultQualifierName(rs.getString("RSLT_QUAL_NAME"));

        ResultQualifierCodeListIdentifierDataType horizontalResultQualifierListIdentifier = fact.createResultQualifierCodeListIdentifierDataType();
        horizontalResultQualifier.setResultQualifierCodeListIdentifier(horizontalResultQualifierListIdentifier);
        horizontalResultQualifierListIdentifier.setCodeListVersionAgencyIdentifier(rs.getString("RSLT_QUAL_CODE_LIS_VER_AGN_IDE"));
        horizontalResultQualifierListIdentifier.setCodeListVersionIdentifier(rs.getString("RSLT_QUAL_CODE_LIST_VERS_IDEN"));
        horizontalResultQualifierListIdentifier.setValue(rs.getString("RSLT_QUAL_CODE_LST_VER_VAL"));
        // END SC:Measure Data

        // BEGIN SC:Reference Method (Horizontal)
        ReferenceMethodDataType horizontalRefereneceMethod = fact.createReferenceMethodDataType();
        facilitySummaryGeographicLocation.setHorizontalCollectionMethod(horizontalRefereneceMethod);
        horizontalRefereneceMethod.setMethodDescriptionText(rs.getString("METH_DESC_TEXT"));
        horizontalRefereneceMethod.setMethodDeviationsText(rs.getString("METH_DEVI_TEXT"));
        horizontalRefereneceMethod.setMethodIdentifierCode(rs.getString("METH_IDEN_CODE"));
        horizontalRefereneceMethod.setMethodName(rs.getString("METH_NAME"));

        MethodIdentifierCodeListIdentifierDataType horizontalMethodIdentifierCodeListIdentifier = fact.createMethodIdentifierCodeListIdentifierDataType();
        horizontalRefereneceMethod.setMethodIdentifierCodeListIdentifier(horizontalMethodIdentifierCodeListIdentifier);
        horizontalMethodIdentifierCodeListIdentifier.setCodeListVersionAgencyIdentifier(rs.getString("HOR_COL_MET_COD_LIS_VER_AGN_ID"));
        horizontalMethodIdentifierCodeListIdentifier.setCodeListVersionIdentifier(rs.getString("HORZ_COLL_METH_COD_LIS_VER_IDE"));
        horizontalMethodIdentifierCodeListIdentifier.setValue(rs.getString("HORZ_COLL_METH_COD_LST_VER_VAL"));
        // END SC:Reference Method (Horizontal)

        return facilitySummaryGeographicLocation;
    }

    public FacilityDataTypeDao getFacilityDataTypeDao()
    {
        return facilityDataTypeDao;
    }

    public void setFacilityDataTypeDao(FacilityDataTypeDao facilityDataTypeDao)
    {
        this.facilityDataTypeDao = facilityDataTypeDao;
    }
}
