package com.windsor.node.plugin.facid3.dao;

import java.math.BigInteger;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Calendar;
import java.util.GregorianCalendar;
import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeConstants;
import javax.xml.datatype.DatatypeFactory;
import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.jdbc.core.RowMapper;
import com.windsor.node.plugin.facid3.domain.CoordinateDataSourceCodeListIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.CoordinateDataSourceDataType;
import com.windsor.node.plugin.facid3.domain.DirectPositionType;
import com.windsor.node.plugin.facid3.domain.FacilityPrimaryGeographicLocationDescriptionDataType;
import com.windsor.node.plugin.facid3.domain.GeographicReferencePointDataType;
import com.windsor.node.plugin.facid3.domain.MeasureDataType;
import com.windsor.node.plugin.facid3.domain.MeasureUnitCodeListIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.MeasureUnitDataType;
import com.windsor.node.plugin.facid3.domain.MethodIdentifierCodeListIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;
import com.windsor.node.plugin.facid3.domain.PointType;
import com.windsor.node.plugin.facid3.domain.ReferenceMethodDataType;
import com.windsor.node.plugin.facid3.domain.ReferencePointCodeListIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.ResultQualifierCodeListIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.ResultQualifierDataType;

public class FacilityPrimaryGeographicLocationDescriptionDataTypeRowMapper implements RowMapper
{
    protected Logger logger = LoggerFactory.getLogger(getClass());
    FacilityDataTypeDao facilityDataTypeDao;

    public FacilityPrimaryGeographicLocationDescriptionDataTypeRowMapper(FacilityDataTypeDao facilityDataTypeDao)
    {
        setFacilityDataTypeDao(facilityDataTypeDao);
    }

    public Object mapRow(ResultSet rs, int rowNum) throws SQLException
    {
        ObjectFactory fact = new ObjectFactory();
        FacilityPrimaryGeographicLocationDescriptionDataType priGeoLoc = fact.createFacilityPrimaryGeographicLocationDescriptionDataType();

        PointType point = fact.createPointType();
        priGeoLoc.setPoint(point);
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

        priGeoLoc.setLocationCommentsText(rs.getString("LOC_COMM_TEXT"));
        if(StringUtils.isNumeric(rs.getString("SRC_MAP_SCALE_NUM")))
        {
            priGeoLoc.setSourceMapScaleNumber(new BigInteger(rs.getString("SRC_MAP_SCALE_NUM")));
        }
        DatatypeFactory datatypeFactory;
        try
        {
            datatypeFactory = DatatypeFactory.newInstance();
            if(rs.getString("DATA_COLL_DATE") != null)
            {
                GregorianCalendar cal = new GregorianCalendar();
                cal.setTime(rs.getDate("DATA_COLL_DATE"));
                priGeoLoc.setDataCollectionDate(datatypeFactory.newXMLGregorianCalendarDate(cal.get(Calendar.YEAR), cal.get(Calendar.MONTH) + 1, cal.get(Calendar.DAY_OF_MONTH), DatatypeConstants.FIELD_UNDEFINED));
            }
        }
        catch(DatatypeConfigurationException e)
        {
            logger.warn("A serious configuration error occured when trying to create a factory to handle XML date objects, recovering, but no dates can be parsed or included in file.",
                        e.getMessage());
        }

        // BEGIN SC:Coordinate Data Source
        CoordinateDataSourceDataType coordinateDataSource = fact.createCoordinateDataSourceDataType();
        priGeoLoc.setCoordinateDataSource(coordinateDataSource);
        coordinateDataSource.setCoordinateDataSourceCode(rs.getString("CORD_DATA_SRC_CODE"));
        coordinateDataSource.setCoordinateDataSourceName(rs.getString("CORD_DATA_SRC_NAME"));

        CoordinateDataSourceCodeListIdentifierDataType coordinateDataSourceCodeListIdentifier = fact.createCoordinateDataSourceCodeListIdentifierDataType();
        coordinateDataSource.setCoordinateDataSourceCodeListIdentifier(coordinateDataSourceCodeListIdentifier);
        coordinateDataSourceCodeListIdentifier.setCodeListVersionAgencyIdentifier(rs.getString("COR_DAT_SRC_COD_LIS_VER_AGN_ID"));
        coordinateDataSourceCodeListIdentifier.setCodeListVersionIdentifier(rs.getString("CORD_DATA_SRC_CODE_LIS_VER_IDE"));
        coordinateDataSourceCodeListIdentifier.setValue(rs.getString("CORD_DATA_SRC_CODE_LST_VER_VAL"));
        // END SC:Coordinate Data Source

        // BEGIN SC:Geographic Reference Point
        GeographicReferencePointDataType geograpgicReferencePoint = fact.createGeographicReferencePointDataType();
        priGeoLoc.setGeographicReferencePoint(geograpgicReferencePoint);
        geograpgicReferencePoint.setGeographicReferencePointCode(rs.getString("GEO_REF_PT_CODE"));
        geograpgicReferencePoint.setGeographicReferencePointName(rs.getString("GEO_REF_PT_NAME"));

        ReferencePointCodeListIdentifierDataType referencePointCodeListIdentifier = fact.createReferencePointCodeListIdentifierDataType();
        geograpgicReferencePoint.setReferencePointCodeListIdentifier(referencePointCodeListIdentifier);
        referencePointCodeListIdentifier.setCodeListVersionAgencyIdentifier(rs.getString("GEO_REF_PT_COD_LIS_VER_AGN_IDE"));
        referencePointCodeListIdentifier.setCodeListVersionIdentifier(rs.getString("GEO_REF_PT_CODE_LIST_VERS_IDEN"));
        referencePointCodeListIdentifier.setValue(rs.getString("GEO_REF_PT_CODE_LST_VER_VAL"));
        // END SC:Geographic Reference Point

        // BEGIN SC:Measure Data
        MeasureDataType horizontalMeasure = fact.createMeasureDataType();
        priGeoLoc.setHorizontalAccuracyMeasure(horizontalMeasure);
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
        priGeoLoc.setHorizontalCollectionMethod(horizontalRefereneceMethod);
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

        // BEGIN SC:Reference Method (Verification)
        ReferenceMethodDataType verificationReferenceMethod = fact.createReferenceMethodDataType();
        priGeoLoc.setVerificationMethod(verificationReferenceMethod);
        verificationReferenceMethod.setMethodDescriptionText(rs.getString("VERF_METH_METH_DESC_TEXT"));
        verificationReferenceMethod.setMethodDeviationsText(rs.getString("VERF_METH_METH_DEVI_TEXT"));
        verificationReferenceMethod.setMethodIdentifierCode(rs.getString("VERF_METH_METH_IDEN_CODE"));
        verificationReferenceMethod.setMethodName(rs.getString("VERF_METH_METH_NAME"));

        MethodIdentifierCodeListIdentifierDataType verificationMethodIdentifierCodeListIdentifier = fact.createMethodIdentifierCodeListIdentifierDataType();
        verificationReferenceMethod.setMethodIdentifierCodeListIdentifier(verificationMethodIdentifierCodeListIdentifier);
        verificationMethodIdentifierCodeListIdentifier.setCodeListVersionAgencyIdentifier(rs.getString("VERF_METH_CODE_LIS_VER_AGN_IDE"));
        verificationMethodIdentifierCodeListIdentifier.setCodeListVersionIdentifier(rs.getString("VERF_METH_CODE_LIST_VERS_IDEN"));
        verificationMethodIdentifierCodeListIdentifier.setValue(rs.getString("VERF_METH_CODE_LST_VER_VAL"));
        // END SC:Reference Method (Verification)

        // BEGIN SC:Reference Method (Vertical)
        ReferenceMethodDataType verticalRefereneceMethod = fact.createReferenceMethodDataType();
        priGeoLoc.setVerticalCollectionMethod(verticalRefereneceMethod);
        verticalRefereneceMethod.setMethodDescriptionText(rs.getString("VERT_COLL_METH_METH_DESC_TEXT"));
        verticalRefereneceMethod.setMethodDeviationsText(rs.getString("VERT_COLL_METH_METH_DEVI_TEXT"));
        verticalRefereneceMethod.setMethodIdentifierCode(rs.getString("VERT_COLL_METH_METH_IDEN_CODE"));
        verticalRefereneceMethod.setMethodName(rs.getString("VERT_COLL_METH_METH_NAME"));

        MethodIdentifierCodeListIdentifierDataType verticalMethodIdentifierCodeListIdentifier = fact.createMethodIdentifierCodeListIdentifierDataType();
        verticalRefereneceMethod.setMethodIdentifierCodeListIdentifier(verticalMethodIdentifierCodeListIdentifier);
        verticalMethodIdentifierCodeListIdentifier.setCodeListVersionAgencyIdentifier(rs.getString("VER_COL_MET_COD_LIS_VER_AGN_ID"));
        verticalMethodIdentifierCodeListIdentifier.setCodeListVersionIdentifier(rs.getString("VERT_COLL_METH_COD_LIS_VER_IDE"));
        verticalMethodIdentifierCodeListIdentifier.setValue(rs.getString("VERT_COLL_METH_COD_LST_VER_VAL"));
        // END SC:Reference Method (Vertical)
        return priGeoLoc;
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
