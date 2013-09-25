package com.windsor.node.plugin.facid3;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import org.apache.commons.lang3.StringUtils;
import com.windsor.node.common.domain.EndpointVersionType;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;

public abstract class BaseFacIdGetFacilityService extends BaseFacIdPlugin
{
    public static final PluginServiceParameterDescriptor STANDARD_ENVIRONMENTAL_INTEREST_TYPE = new PluginServiceParameterDescriptor(
                    "Standard Environmental Interest Type",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "Return facilities having one or more of any of the standard types included in the parameter array. A pipe delimiter (i.e., '|') should be used between values.");
    public static final PluginServiceParameterDescriptor ZIP_CODE = new PluginServiceParameterDescriptor(
                    "ZIP Code",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "The combination of the 5‑digit Zone Improvement Plan (ZIP) code and the four digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location; or the postal zone specific to the country, other than the U.S., where the facility site is located. Will return all facilities in the provided zip code.  If Zip+4 is provided, but the receiving node supports only 5 digit codes, treat the input parameter as a 5-digit code.  Do not return facilities where zip code is null or unknown.");
    public static final PluginServiceParameterDescriptor TRIBAL_LAND_CODE = new PluginServiceParameterDescriptor("Tribal Land Code",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE,
                    "Code indicating whether or not the facility site is located on tribal land. Allowable Values: Y, N.");
    public static final PluginServiceParameterDescriptor FEDERAL_FACILITY = new PluginServiceParameterDescriptor("Federal Facility",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE,
                    "Code indicating whether or not the facility is the property of the Federal Government. Allowable Values: Y, N.");
    public static final PluginServiceParameterDescriptor FACILITY_NAME = new PluginServiceParameterDescriptor(
                    "Facility Name",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "The public or commercial name of a facility site (i.e., the full name that commonly appears on invoices, signs, or other business documents, or as assigned by the state when the name is ambiguous).  Return all facilities where the primary name or any alias matches the supplied parameter.");
    public static final PluginServiceParameterDescriptor FACILITY_STATUS = new PluginServiceParameterDescriptor("Facility status ",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE,
                    "Indicator of Active or Inactive, or other status that may be adopted as a part of the overall schema development.");
    public static final PluginServiceParameterDescriptor SIC_CODE = new PluginServiceParameterDescriptor(
                    "SIC Code",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "The industry types that describe the business operations at the Facility. When searching using a SIC code, the system will find any facilities that are in that industry, even if the data about that facility is limited to the equivalent NAICS code(s).");
    public static final PluginServiceParameterDescriptor NAICS_CODE = new PluginServiceParameterDescriptor(
                    "NAICS Code",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "When searching using a NAICS code, the system fill find any facilities that are in that industry, even if the data about that facility is limited to the equivalent SIC code(s).");
    public static final PluginServiceParameterDescriptor CITY_NAME = new PluginServiceParameterDescriptor(
                    "City",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "The name of the city, town, village or other locality, when identifiable, within whose boundaries (the majority of) the facility site is located. This is not always the same as the city used for USPS mail delivery.");
    public static final PluginServiceParameterDescriptor STATE = new PluginServiceParameterDescriptor("State",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE,
                    "The U.S. Postal Service abbreviation that represents the state or state equivalent for the U.S. and Canada. Exact match is required.");
    public static final PluginServiceParameterDescriptor COUNTY_NAME = new PluginServiceParameterDescriptor(
                    "County Name",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "The name of the U.S. county or county equivalent in which the facility site is physically located. Exact match is required.  This value is more broadly supported than FIPS codes, but the FIPS table should be used for spellings--consistent with the data standard.");
    public static final PluginServiceParameterDescriptor N_BOUNDING_LAT = new PluginServiceParameterDescriptor(
                    "N Bounding Latitude",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "Northernmost co-ordinate of a bounding rectangle. Must be a valid decimal Latitude value. These 4 parameters define a box within which the returned facilities must reside based on a location coordinate for each facility.");
    public static final PluginServiceParameterDescriptor S_BOUNDING_LAT = new PluginServiceParameterDescriptor("S Bounding Latitude",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE,
                    "Southernmost co-ordinate of a bounding rectangle. Must be a valid decimal latitude value.");
    public static final PluginServiceParameterDescriptor E_BOUNDING_LONG = new PluginServiceParameterDescriptor("E Bounding Longitude",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE,
                    "Easternmost co-ordinate of a bounding rectangle. Must be a valid decimal longitude value.");
    public static final PluginServiceParameterDescriptor W_BOUNDING_LONG = new PluginServiceParameterDescriptor("W Bounding Longitude",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.FALSE,
                    "Westernmost co-ordinate of a bounding rectangle. Must be a valid decimal Longitude value.");
    public static final PluginServiceParameterDescriptor CHANGE_DATE = new PluginServiceParameterDescriptor("Change Date",
                    PluginServiceParameterDescriptor.TYPE_DATE, Boolean.FALSE,
                    "Date since when any data element of a facility has been modified. Response will include all facilities that have changed on or after this date.");

    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        List<PluginServiceParameterDescriptor> params = new ArrayList<PluginServiceParameterDescriptor>();
        params.add(STANDARD_ENVIRONMENTAL_INTEREST_TYPE);
        params.add(ZIP_CODE);
        params.add(TRIBAL_LAND_CODE);
        params.add(FEDERAL_FACILITY);
        params.add(FACILITY_NAME);
        params.add(FACILITY_STATUS);
        params.add(SIC_CODE);
        params.add(NAICS_CODE);
        params.add(CITY_NAME);
        params.add(STATE);
        params.add(COUNTY_NAME);
        params.add(N_BOUNDING_LAT);
        params.add(S_BOUNDING_LAT);
        params.add(E_BOUNDING_LONG);
        params.add(W_BOUNDING_LONG);
        return params;
    }

    protected List<String> getFacilityIds(NodeTransaction transaction)
    {
        Map<String, Object> params = validateAndLoadParameters(transaction);
        return getFacilityDataTypeDao().loadAllFacilityIdsByParams(params);
    }

    protected Map<String, Object> validateAndLoadParameters(NodeTransaction transaction)
    {
        if(transaction.getRequest().getParameterValues() == null)
        {
            // error condition? no params may be valid
        }

        // These don't always currently come in named, which makes them hard for the rest of the system
        // to deal with, so solve that here by putting them in a map with the PluginServiceParameterDescriptor
        // names as the keys
        Map<String, Object> params = new HashMap<String, Object>();
        if(transaction.getRequest().getParameters().get(FACILITY_SITE_IDENTIFIER.getName()) != null
                        || (EndpointVersionType.EN21.equals(transaction.getEndpointVersion()) || EndpointVersionType.ENREST.equals(transaction.getEndpointVersion())))
        {//then params are named
            params = getParametersEn21(transaction);
        }
        else
        {//use ordered params
            params = getParametersEn11(transaction);
        }

        return params;
    }

    private Map<String, Object> getParametersEn21(NodeTransaction transaction)
    {
        Map<String, Object> params = new HashMap<String, Object>();
        ByIndexOrNameMap namedParams = transaction.getRequest().getParameters();

        if(namedParams.get(STANDARD_ENVIRONMENTAL_INTEREST_TYPE.getName()) != null)
        {// Standard Environmental Interest Type is pipe delimited and only restricted to 60 total characters
            String eiType = (String)namedParams.get(STANDARD_ENVIRONMENTAL_INTEREST_TYPE.getName());
            List<String> eiTypeList = new ArrayList<String>();
            String[] split = eiType.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                eiTypeList.add(split[i]);
            }
            params.put(STANDARD_ENVIRONMENTAL_INTEREST_TYPE.getName(), eiTypeList);
        }
        if(namedParams.get(ZIP_CODE.getName()) != null)
        {
            String zipCode = (String)namedParams.get(ZIP_CODE.getName());
            List<String> zipCodeList = new ArrayList<String>();
            String[] split = zipCode.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                zipCodeList.add(split[i]);
            }
            params.put(ZIP_CODE.getName(), zipCodeList);
        }
        if(namedParams.get(TRIBAL_LAND_CODE.getName()) != null)
        {
            String tribalLandCode = (String)namedParams.get(TRIBAL_LAND_CODE.getName());
            if(!"N".equalsIgnoreCase(tribalLandCode) && !"Y".equalsIgnoreCase(tribalLandCode))
            {
                logger.error("Tribal Land Code must be Y or N, if it is provided, was \"" + tribalLandCode + "\".");
                throw new RuntimeException("Tribal Land Code must be Y or N, if it is provided, was \"" + tribalLandCode + "\".");
            }
            params.put(TRIBAL_LAND_CODE.getName(), tribalLandCode);
        }
        if(namedParams.get(FEDERAL_FACILITY.getName()) != null)
        {
            String federalFacility = (String)namedParams.get(FEDERAL_FACILITY.getName());
            if(!"N".equalsIgnoreCase(federalFacility) && !"Y".equalsIgnoreCase(federalFacility))
            {
                logger.error("Federal Facility must be Y or N, if it is provided, was \"" + federalFacility + "\".");
                throw new RuntimeException("Federal Facility must be Y or N, if it is provided, was \"" + federalFacility + "\".");
            }
            params.put(FEDERAL_FACILITY.getName(), federalFacility);
        }
        if(namedParams.get(FACILITY_NAME.getName()) != null)
        {
            String facilityName = (String)namedParams.get(FACILITY_NAME.getName());
            if(facilityName.length() > 80)
            {
                logger.error("Facility Name must not exceed 80 characters, was  \"" + facilityName.length() + "\" characters.");
                throw new RuntimeException("Facility Name must not exceed 80 characters, was  \"" + facilityName.length() + "\" characters.");
            }
            params.put(FACILITY_NAME.getName(), facilityName);
        }
        if(namedParams.get(FACILITY_STATUS.getName()) != null)
        {
            String facilityStatus = (String)namedParams.get(FACILITY_STATUS.getName());
            //vague param, refers to Active or Inactive but doesn't give values
            params.put(FACILITY_STATUS.getName(), facilityStatus);
        }
        if(namedParams.get(SIC_CODE.getName()) != null)
        {
            String sicCode = (String)namedParams.get(SIC_CODE.getName());
            List<String> sicCodeList = new ArrayList<String>();
            String[] split = sicCode.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                sicCodeList.add(split[i]);
            }
            params.put(SIC_CODE.getName(), sicCodeList);
        }
        if(namedParams.get(NAICS_CODE.getName()) != null)
        {
            String naicsCode = (String)namedParams.get(NAICS_CODE.getName());
            List<String> naicsCodeList = new ArrayList<String>();
            String[] split = naicsCode.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                naicsCodeList.add(split[i]);
            }
            params.put(NAICS_CODE.getName(), naicsCodeList);
        }
        if(namedParams.get(CITY_NAME.getName()) != null)
        {
            String cityName = (String)namedParams.get(CITY_NAME.getName());
            List<String> cityNameList = new ArrayList<String>();
            String[] split = cityName.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                cityNameList.add(split[i]);
            }
            params.put(CITY_NAME.getName(), cityNameList);
        }
        if(namedParams.get(STATE.getName()) != null)
        {
            String state = (String)namedParams.get(STATE.getName());
            List<String> stateList = new ArrayList<String>();
            String[] split = state.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                stateList.add(split[i]);
            }
            params.put(STATE.getName(), stateList);
        }
        if(namedParams.get(COUNTY_NAME.getName()) != null)
        {
            String countyName = (String)namedParams.get(COUNTY_NAME.getName());
            List<String> countyNameList = new ArrayList<String>();
            String[] split = countyName.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                countyNameList.add(split[i]);
            }
            params.put(COUNTY_NAME.getName(), countyNameList);
        }
        if(namedParams.get(N_BOUNDING_LAT.getName()) != null 
                        && namedParams.get(S_BOUNDING_LAT.getName()) != null 
                        && namedParams.get(E_BOUNDING_LONG.getName()) != null
                        && namedParams.get(W_BOUNDING_LONG.getName()) != null)
        {// Take care of bounding coords args, all 4 are required to do the search, must be numeric
            String nBoundingLat = (String)namedParams.get(N_BOUNDING_LAT.getName());
            String sBoundingLat = (String)namedParams.get(S_BOUNDING_LAT.getName());
            String eBoundingLong = (String)namedParams.get(E_BOUNDING_LONG.getName());
            String wBoundingLong = (String)namedParams.get(W_BOUNDING_LONG.getName());

            try
            {
                params.put(N_BOUNDING_LAT.getName(), new Double(nBoundingLat));
                params.put(S_BOUNDING_LAT.getName(), new Double(sBoundingLat));
                params.put(E_BOUNDING_LONG.getName(), new Double(eBoundingLong));
                params.put(W_BOUNDING_LONG.getName(), new Double(wBoundingLong));
            }
            catch(NumberFormatException e)
            {
                logger.error("If any bounding coords are included, they must all be included and must all be numeric, the following inputs failed this requirement:  " +
                                " North Bounding Lat: " + nBoundingLat +
                                " South Bounding Lat: " + sBoundingLat +
                                " East Bounding Long: " + eBoundingLong +
                                " West Bounding Long: " + wBoundingLong);
                throw new WinNodeException("If any bounding coords are included, they must all be included and must all be numeric, the following inputs failed this requirement:  " +
                                " North Bounding Lat: " + nBoundingLat +
                                " South Bounding Lat: " + sBoundingLat +
                                " East Bounding Long: " + eBoundingLong +
                                " West Bounding Long: " + wBoundingLong);
            }
        }

        return params;
    }

    private Map<String, Object> getParametersEn11(NodeTransaction transaction)
    {
        Map<String, Object> params = new HashMap<String, Object>();

        String[] args = transaction.getRequest().getParameterValues();
        if(args.length >= 1 && StringUtils.isNotBlank(args[0]))
        {// Standard Environmental Interest Type is pipe delimited and only restricted to 60 total characters
            String eiType = args[0];
            List<String> eiTypeList = new ArrayList<String>();
            String[] split = eiType.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                eiTypeList.add(split[i]);
            }
            params.put(STANDARD_ENVIRONMENTAL_INTEREST_TYPE.getName(), eiTypeList);
        }
        if(args.length >= 2 && StringUtils.isNotBlank(args[1]))
        {
            String zipCode = args[1];
            List<String> zipCodeList = new ArrayList<String>();
            String[] split = zipCode.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                zipCodeList.add(split[i]);
            }
            params.put(ZIP_CODE.getName(), zipCodeList);
        }
        if(args.length >= 3 && StringUtils.isNotBlank(args[2]))
        {
            String tribalLandCode = args[2];
            if(!"N".equalsIgnoreCase(tribalLandCode) && !"Y".equalsIgnoreCase(tribalLandCode))
            {
                logger.error("Tribal Land Code must be Y or N, if it is provided, was \"" + tribalLandCode + "\".");
                throw new RuntimeException("Tribal Land Code must be Y or N, if it is provided, was \"" + tribalLandCode + "\".");
            }
            params.put(TRIBAL_LAND_CODE.getName(), tribalLandCode);
        }
        if(args.length >= 4 && StringUtils.isNotBlank(args[3]))
        {
            String federalFacility = args[3];
            if(!"N".equalsIgnoreCase(federalFacility) && !"Y".equalsIgnoreCase(federalFacility))
            {
                logger.error("Federal Facility must be Y or N, if it is provided, was \"" + federalFacility + "\".");
                throw new RuntimeException("Federal Facility must be Y or N, if it is provided, was \"" + federalFacility + "\".");
            }
            params.put(FEDERAL_FACILITY.getName(), federalFacility);
        }
        if(args.length >= 5 && StringUtils.isNotBlank(args[4]))
        {
            String facilityName = args[4];
            if(facilityName.length() > 80)
            {
                logger.error("Facility Name must not exceed 80 characters, was  \"" + facilityName.length() + "\" characters.");
                throw new RuntimeException("Facility Name must not exceed 80 characters, was  \"" + facilityName.length() + "\" characters.");
            }
            params.put(FACILITY_NAME.getName(), facilityName);
        }
        if(args.length >= 6 && StringUtils.isNotBlank(args[5]))
        {
            String facilityStatus = args[5];
            //vague param, refers to Active or Inactive but doesn't give values
            params.put(FACILITY_STATUS.getName(), facilityStatus);
        }
        if(args.length >= 7 && StringUtils.isNotBlank(args[6]))
        {
            String sicCode = args[6];
            List<String> sicCodeList = new ArrayList<String>();
            String[] split = sicCode.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                sicCodeList.add(split[i]);
            }
            params.put(SIC_CODE.getName(), sicCodeList);
        }
        if(args.length >= 8 && StringUtils.isNotBlank(args[7]))
        {
            String naicsCode = args[7];
            List<String> naicsCodeList = new ArrayList<String>();
            String[] split = naicsCode.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                naicsCodeList.add(split[i]);
            }
            params.put(NAICS_CODE.getName(), naicsCodeList);
        }
        if(args.length >= 9 && StringUtils.isNotBlank(args[8]))
        {
            String cityName = args[8];
            List<String> cityNameList = new ArrayList<String>();
            String[] split = cityName.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                cityNameList.add(split[i]);
            }
            params.put(CITY_NAME.getName(), cityNameList);
        }
        if(args.length >= 10 && StringUtils.isNotBlank(args[9]))
        {
            String state = args[9];
            List<String> stateList = new ArrayList<String>();
            String[] split = state.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                stateList.add(split[i]);
            }
            params.put(STATE.getName(), stateList);
        }
        if(args.length >= 11 && StringUtils.isNotBlank(args[10]))
        {
            String countyName = args[10];
            List<String> countyNameList = new ArrayList<String>();
            String[] split = countyName.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                countyNameList.add(split[i]);
            }
            params.put(COUNTY_NAME.getName(), countyNameList);
        }
        if(args.length >= 15 && (StringUtils.isNotBlank(args[11]) || StringUtils.isNotBlank(args[12]) || StringUtils.isNotBlank(args[13])
                        || StringUtils.isNotBlank(args[14])))
        {// Take care of bounding coords args, all 4 are required to do the search, must be numeric
            String nBoundingLat = args[11];
            String sBoundingLat = args[12];
            String eBoundingLong = args[13];
            String wBoundingLong = args[14];

            try
            {
                params.put(N_BOUNDING_LAT.getName(), new Double(nBoundingLat));
                params.put(S_BOUNDING_LAT.getName(), new Double(sBoundingLat));
                params.put(E_BOUNDING_LONG.getName(), new Double(eBoundingLong));
                params.put(W_BOUNDING_LONG.getName(), new Double(wBoundingLong));
            }
            catch(NumberFormatException e)
            {
                logger.error("If any bounding coords are included, they must all be included and must all be numeric, the following inputs failed this requirement:  " +
                                " North Bounding Lat: " + nBoundingLat +
                                " South Bounding Lat: " + sBoundingLat +
                                " East Bounding Long: " + eBoundingLong +
                                " West Bounding Long: " + wBoundingLong);
                throw new RuntimeException("If any bounding coords are included, they must all be included and must all be numeric, the following inputs failed this requirement:  " +
                                " North Bounding Lat: " + nBoundingLat +
                                " South Bounding Lat: " + sBoundingLat +
                                " East Bounding Long: " + eBoundingLong +
                                " West Bounding Long: " + wBoundingLong);
            }
        }
        return params;
    }
}
