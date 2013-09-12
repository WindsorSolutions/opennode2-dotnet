package com.windsor.node.plugin.ic;

import java.math.BigDecimal;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import javax.sql.DataSource;
import org.apache.commons.lang3.StringUtils;
import org.apache.commons.lang3.time.DateUtils;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;

public class GetICDataByParameters extends AbstractICPlugin
{
    private static final long serialVersionUID = 1L;

    public static final PluginServiceParameterDescriptor INSTRUMENT_IDENTIFIER = new PluginServiceParameterDescriptor(
                    "InstrumentIdentifier",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "Return institutional controls matching one or more of the instrument identifiers in the parameter array.");
    public static final PluginServiceParameterDescriptor FACILITY_IDENTIFIER = new PluginServiceParameterDescriptor(
                    "FacilityIdentifier",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "Return institutional controls matching one or more of the facility identifiers in the parameter array.");
    public static final PluginServiceParameterDescriptor FACILITY_SITE_NAME = new PluginServiceParameterDescriptor(
                    "FacilitySiteName",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "Return institutional controls matching one or more of the facility site names in the parameter array.  Use % to indicate a wildcard search.");
    public static final PluginServiceParameterDescriptor USE_RESTRICTION_TYPE_CODE = new PluginServiceParameterDescriptor(
                    "UseRestrictionTypeCode",
                    PluginServiceParameterDescriptor.TYPE_STRING,
                    Boolean.FALSE,
                    "Return institutional controls matching one or more of the Use Restriction type codes in the parameter array.  Refer to the Institutional Controls.");
    public static final PluginServiceParameterDescriptor BOUNDING_COORDINATE_NORTH = new PluginServiceParameterDescriptor(
                    "BoundingCoordinateNorth",
                    PluginServiceParameterDescriptor.TYPE_DECIMAL,
                    Boolean.FALSE,
                    "Maximum latitude value of bounding box expressed in decimal degrees.");
    public static final PluginServiceParameterDescriptor BOUNDING_COORDINATE_SOUTH = new PluginServiceParameterDescriptor(
                    "BoundingCoordinateSouth",
                    PluginServiceParameterDescriptor.TYPE_DECIMAL,
                    Boolean.FALSE,
                    "Minimum latitude value of bounding box expressed in decimal degrees.");
    public static final PluginServiceParameterDescriptor BOUNDING_COORDINATE_WEST = new PluginServiceParameterDescriptor(
                    "BoundingCoordinateWest",
                    PluginServiceParameterDescriptor.TYPE_DECIMAL,
                    Boolean.FALSE,
                    "Minimum longitude value of bounding box expressed in decimal degrees.\n\nNote that longitudinal values (in decimal degrees) are expressed as negative numbers within the Western Hemisphere.");
    public static final PluginServiceParameterDescriptor BOUNDING_COORDINATE_EAST = new PluginServiceParameterDescriptor(
                    "BoundingCoordinateEast",
                    PluginServiceParameterDescriptor.TYPE_DECIMAL,
                    Boolean.FALSE,
                    "Maximum longitude value of bounding box expressed in decimal degrees.\n\nNote that longitudinal values (in decimal degrees) are expressed as negative numbers within the Western Hemisphere.");
    public static final PluginServiceParameterDescriptor CHANGE_DATE = new PluginServiceParameterDescriptor(
                    "ChangeDate",
                    PluginServiceParameterDescriptor.TYPE_DATE,
                    Boolean.FALSE,
                    "Date since any data element of an institutional control has been modified. Response will include all institutional controls that have changed on or after this date.\n\n Format of input date is YYYY-MM-DD.");

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName(GetICDataByParameters.class.getName());
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Returns all IC data within a bounding box (area) specified by maximum and minimum latitude/longitude coordinate pairs.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(GetICDataByParameters.class.getCanonicalName());
    }

    public GetICDataByParameters()
    {
        setPublishForEN11(true);
        setPublishForEN20(true);
        getDataSources().put(ARG_DS_SOURCE, (DataSource)null);
        getSupportedPluginTypes().add(ServiceType.QUERY_OR_SOLICIT);
    }

    @Override
    public void afterPropertiesSet()
    {
        super.afterPropertiesSet();
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
    {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        List<PluginServiceParameterDescriptor> params = new ArrayList<PluginServiceParameterDescriptor>();
        params.add(INSTRUMENT_IDENTIFIER);
        params.add(FACILITY_IDENTIFIER);
        params.add(FACILITY_SITE_NAME);
        params.add(USE_RESTRICTION_TYPE_CODE);
        params.add(BOUNDING_COORDINATE_NORTH);
        params.add(BOUNDING_COORDINATE_SOUTH);
        params.add(BOUNDING_COORDINATE_WEST);
        params.add(BOUNDING_COORDINATE_EAST);
        params.add(CHANGE_DATE);
        return params;
    }

    protected Map<String, Object> loadParameters(NodeTransaction transaction)
    {
        Map<String, Object> params = new HashMap<String, Object>();
        //determine which endpoint the request came in on, seriously, why haven't I automated this by now?
        //can't check which endpoint version because some endpoints opt to not send by name despite being v2.1
        //Blame Canada
        if(transaction.getRequest().getParameters().get(CHANGE_DATE.getName()) != null
                        || transaction.getRequest().getParameters().get(FACILITY_IDENTIFIER.getName()) != null
                        || transaction.getRequest().getParameters().get(FACILITY_SITE_NAME.getName()) != null
                        || transaction.getRequest().getParameters().get(USE_RESTRICTION_TYPE_CODE.getName()) != null
                        || transaction.getRequest().getParameters().get(BOUNDING_COORDINATE_NORTH.getName()) != null
                        || transaction.getRequest().getParameters().get(BOUNDING_COORDINATE_SOUTH.getName()) != null
                        || transaction.getRequest().getParameters().get(BOUNDING_COORDINATE_EAST.getName()) != null
                        || transaction.getRequest().getParameters().get(BOUNDING_COORDINATE_WEST.getName()) != null
                        || transaction.getRequest().getParameters().get(CHANGE_DATE.getName()) != null)
        {
            params = getNamedParameters(transaction);
        }
        else
        {
            params = getOrderedParameters(transaction);
        }
        if(transaction.getRequest() != null && transaction.getRequest().getPaging() != null)
        {
            if(transaction.getRequest().getPaging().getStart() > 0)
            {
                params.put("rowId", new Integer(transaction.getRequest().getPaging().getStart()));
            }
            if(transaction.getRequest().getPaging().getCount() > 0)
            {
                params.put("maxRows", new Integer(transaction.getRequest().getPaging().getCount()));
                if(params.get("rowId") == null)//if there's a maxRows and no rowId, simply consider rowId to be the first row
                {
                    params.put("rowId", new Integer(1));
                }
            }
        }
        return params;
    }

    private Map<String, Object> getOrderedParameters(NodeTransaction transaction)
    {
        Map<String, Object> params = new HashMap<String, Object>();
        String[] args = transaction.getRequest().getParameterValues();

        if(args.length >= 1 && StringUtils.isNotBlank(args[0]))
        {
            String sicCode = args[0];
            List<String> sicCodeList = new ArrayList<String>();
            String[] split = sicCode.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                sicCodeList.add(split[i]);
            }
            params.put(INSTRUMENT_IDENTIFIER.getName(), sicCodeList);
        }
        if(args.length >= 2 && StringUtils.isNotBlank(args[1]))
        {
            String sicCode = args[1];
            List<String> sicCodeList = new ArrayList<String>();
            String[] split = sicCode.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                sicCodeList.add(split[i]);
            }
            params.put(FACILITY_IDENTIFIER.getName(), sicCodeList);
        }
        if(args.length >= 3 && StringUtils.isNotBlank(args[2]))
        {
            String sicCode = args[2];
            List<String> sicCodeList = new ArrayList<String>();
            String[] split = sicCode.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                sicCodeList.add(split[i]);
            }
            params.put(FACILITY_SITE_NAME.getName(), sicCodeList);
        }
        if(args.length >= 4 && StringUtils.isNotBlank(args[3]))
        {
            String sicCode = args[3];
            List<String> sicCodeList = new ArrayList<String>();
            String[] split = sicCode.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                sicCodeList.add(split[i]);
            }
            params.put(USE_RESTRICTION_TYPE_CODE.getName(), sicCodeList);
        }

        if(args.length >= 8)
        {
            String param = args[4];
            BigDecimal decimal = null;
            try
            {
                decimal = new BigDecimal(param);
            }
            catch(NumberFormatException e)
            {
                logger.error("Unparseable date passed in for Bounding Coordinate North:  " + param);
                throw new WinNodeException("Unparseable date passed in for Bounding Coordinate North:  " + param);
            }
            params.put(BOUNDING_COORDINATE_NORTH.getName(), decimal);

            param = args[5];
            try
            {
                decimal = new BigDecimal(param);
            }
            catch(NumberFormatException e)
            {
                logger.error("Unparseable date passed in for Bounding Coordinate South:  " + param);
                throw new WinNodeException("Unparseable date passed in for Bounding Coordinate South:  " + param);
            }
            params.put(BOUNDING_COORDINATE_SOUTH.getName(), decimal);

            param = args[6];
            try
            {
                decimal = new BigDecimal(param);
            }
            catch(NumberFormatException e)
            {
                logger.error("Unparseable date passed in for Bounding Coordinate West:  " + param);
                throw new WinNodeException("Unparseable date passed in for Bounding Coordinate West:  " + param);
            }
            params.put(BOUNDING_COORDINATE_WEST.getName(), decimal);

            param = args[7];
            try
            {
                decimal = new BigDecimal(param);
            }
            catch(NumberFormatException e)
            {
                logger.error("One or more bounding coordinates existed, but null was passed for one or more.");
                throw new WinNodeException("One or more bounding coordinates existed, but null was passed for one or more.");
            }
            params.put(BOUNDING_COORDINATE_EAST.getName(), decimal);
        }
        if(args.length >= 8 &&(
                        (args[4] != null &&
                            (args[5] == null
                            || args[6] == null
                            || args[7] == null
                            )
                        )
                        ||
                        (args[5] != null &&
                            (args[4] == null
                            || args[6] == null
                            || args[7] == null
                            )
                        )
                        ||
                        (args[6] != null &&
                            (args[5] == null
                            || args[4] == null
                            || args[7] == null
                            )
                        )
                        ||
                        (args[7] != null &&
                            (args[5] == null
                            || args[6] == null
                            || args[4] == null
                            )
                        )
                        )
        )
        {
            logger.error("All bounding coordinates are required but null was passed for one or more.");
            throw new WinNodeException("All bounding coordinates are required but null was passed for one or more.");
        }
        if(args.length == 8)
        {
            String changeDate = args[8];
            Date parsedChangeDate = null;
            try
            {
                parsedChangeDate = DateUtils.parseDate(changeDate, new String[]{"yyyy/MM/dd", "yyyy-MM-dd"});
            }
            catch(ParseException e)
            {
                logger.error("Unparseable date passed in for Change Date:  " + changeDate);
                throw new WinNodeException("Unparseable date passed in for Change Date:  " + changeDate);
            }
            params.put(CHANGE_DATE.getName(), parsedChangeDate);
        }
        return params;
    }

    private Map<String, Object> getNamedParameters(NodeTransaction transaction)
    {
        Map<String, Object> params = new HashMap<String, Object>();
        ByIndexOrNameMap namedParams = transaction.getRequest().getParameters();

        if(namedParams.get(INSTRUMENT_IDENTIFIER.getName()) != null)
        {
            String sicCode = (String)namedParams.get(INSTRUMENT_IDENTIFIER.getName());
            List<String> sicCodeList = new ArrayList<String>();
            String[] split = sicCode.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                sicCodeList.add(split[i]);
            }
            params.put(INSTRUMENT_IDENTIFIER.getName(), sicCodeList);
        }
        if(namedParams.get(FACILITY_IDENTIFIER.getName()) != null)
        {
            String sicCode = (String)namedParams.get(FACILITY_IDENTIFIER.getName());
            List<String> sicCodeList = new ArrayList<String>();
            String[] split = sicCode.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                sicCodeList.add(split[i]);
            }
            params.put(FACILITY_IDENTIFIER.getName(), sicCodeList);
        }
        if(namedParams.get(FACILITY_SITE_NAME.getName()) != null)
        {
            String sicCode = (String)namedParams.get(FACILITY_SITE_NAME.getName());
            List<String> sicCodeList = new ArrayList<String>();
            String[] split = sicCode.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                sicCodeList.add(split[i]);
            }
            params.put(FACILITY_SITE_NAME.getName(), sicCodeList);
        }
        if(namedParams.get(USE_RESTRICTION_TYPE_CODE.getName()) != null)
        {
            String sicCode = (String)namedParams.get(USE_RESTRICTION_TYPE_CODE.getName());
            List<String> sicCodeList = new ArrayList<String>();
            String[] split = sicCode.split("\\|");
            for(int i = 0; i < split.length; i++)
            {
                sicCodeList.add(split[i]);
            }
            params.put(USE_RESTRICTION_TYPE_CODE.getName(), sicCodeList);
        }

        //If any bounding coordinates exist, they all must exist
        if((namedParams.get(BOUNDING_COORDINATE_NORTH.getName()) != null &&
                        (namedParams.get(BOUNDING_COORDINATE_SOUTH.getName()) == null
                        || namedParams.get(BOUNDING_COORDINATE_WEST.getName()) == null
                        || namedParams.get(BOUNDING_COORDINATE_EAST.getName()) == null))
                        ||
                        (namedParams.get(BOUNDING_COORDINATE_SOUTH.getName()) != null &&
                        (namedParams.get(BOUNDING_COORDINATE_NORTH.getName()) == null
                        || namedParams.get(BOUNDING_COORDINATE_WEST.getName()) == null
                        || namedParams.get(BOUNDING_COORDINATE_EAST.getName()) == null))
                        ||
                        (namedParams.get(BOUNDING_COORDINATE_WEST.getName()) != null &&
                        (namedParams.get(BOUNDING_COORDINATE_SOUTH.getName()) == null
                        || namedParams.get(BOUNDING_COORDINATE_NORTH.getName()) == null
                        || namedParams.get(BOUNDING_COORDINATE_EAST.getName()) == null))
                        ||
                        (namedParams.get(BOUNDING_COORDINATE_EAST.getName()) != null &&
                        (namedParams.get(BOUNDING_COORDINATE_SOUTH.getName()) == null
                        || namedParams.get(BOUNDING_COORDINATE_WEST.getName()) == null
                        || namedParams.get(BOUNDING_COORDINATE_NORTH.getName()) == null))
                        )
        {
            logger.error("One or more bounding coordinates existed, but null was passed for one or more.");
            throw new WinNodeException("One or more bounding coordinates existed, but null was passed for one or more.");
        }
        if(namedParams.get(BOUNDING_COORDINATE_NORTH.getName()) != null)
        {
            String param = (String)namedParams.get(BOUNDING_COORDINATE_NORTH.getName());
            BigDecimal decimal = null;
            try
            {
                decimal = new BigDecimal(param);
            }
            catch(NumberFormatException e)
            {
                logger.error("Unparseable date passed in for Bounding Coordinate North:  " + param);
                throw new WinNodeException("Unparseable date passed in for Bounding Coordinate North:  " + param);
            }
            params.put(BOUNDING_COORDINATE_NORTH.getName(), decimal);
        }
        if(namedParams.get(BOUNDING_COORDINATE_SOUTH.getName()) != null)
        {
            String param = (String)namedParams.get(BOUNDING_COORDINATE_SOUTH.getName());
            BigDecimal decimal = null;
            try
            {
                decimal = new BigDecimal(param);
            }
            catch(NumberFormatException e)
            {
                logger.error("Unparseable date passed in for Bounding Coordinate South:  " + param);
                throw new WinNodeException("Unparseable date passed in for Bounding Coordinate South:  " + param);
            }
            params.put(BOUNDING_COORDINATE_SOUTH.getName(), decimal);
        }
        if(namedParams.get(BOUNDING_COORDINATE_WEST.getName()) != null)
        {
            String param = (String)namedParams.get(BOUNDING_COORDINATE_WEST.getName());
            BigDecimal decimal = null;
            try
            {
                decimal = new BigDecimal(param);
            }
            catch(NumberFormatException e)
            {
                logger.error("Unparseable date passed in for Bounding Coordinate West:  " + param);
                throw new WinNodeException("Unparseable date passed in for Bounding Coordinate West:  " + param);
            }
            params.put(BOUNDING_COORDINATE_WEST.getName(), decimal);
        }
        if(namedParams.get(BOUNDING_COORDINATE_EAST.getName()) != null)
        {
            String param = (String)namedParams.get(BOUNDING_COORDINATE_EAST.getName());
            BigDecimal decimal = null;
            try
            {
                decimal = new BigDecimal(param);
            }
            catch(NumberFormatException e)
            {
                logger.error("Unparseable date passed in for Bounding Coordinate East:  " + param);
                throw new WinNodeException("Unparseable date passed in for Bounding Coordinate East:  " + param);
            }
            params.put(BOUNDING_COORDINATE_EAST.getName(), decimal);
        }

        if(namedParams.get(CHANGE_DATE.getName()) != null)
        {
            String changeDate = (String)namedParams.get(CHANGE_DATE.getName());
            Date parsedChangeDate = null;
            try
            {
                parsedChangeDate = DateUtils.parseDate(changeDate, new String[]{"yyyy/MM/dd", "yyyy-MM-dd"});
            }
            catch(ParseException e)
            {
                logger.error("Unparseable date passed in for Change Date:  " + changeDate);
                throw new WinNodeException("Unparseable date passed in for Change Date:  " + changeDate);
            }
            params.put(CHANGE_DATE.getName(), parsedChangeDate);
        }
        return params;
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName)
    {
        return null;
    }
}
