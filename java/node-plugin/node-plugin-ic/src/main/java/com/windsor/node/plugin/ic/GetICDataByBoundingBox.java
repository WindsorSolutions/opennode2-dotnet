package com.windsor.node.plugin.ic;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import javax.sql.DataSource;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;

public class GetICDataByBoundingBox extends AbstractICPlugin
{
    private static final long serialVersionUID = 1L;

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

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName(GetICDataByBoundingBox.class.getName());
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Allows for a variety of filter criteria to be supplied when retrieving institutional control data.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(GetICDataByBoundingBox.class.getCanonicalName());
    }

    public GetICDataByBoundingBox()
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
        params.add(BOUNDING_COORDINATE_NORTH);
        params.add(BOUNDING_COORDINATE_SOUTH);
        params.add(BOUNDING_COORDINATE_WEST);
        params.add(BOUNDING_COORDINATE_EAST);
        return params;
    }

    protected Map<String, Object> loadParameters(NodeTransaction transaction)
    {
        Map<String, Object> params = new HashMap<String, Object>();
        //determine which endpoint the request came in on, seriously, why haven't I automated this by now?
        //can't check which endpoint version because some endpoints opt to not send by name despite being v2.1
        //Blame Canada
        if(transaction.getRequest().getParameters().get(BOUNDING_COORDINATE_NORTH.getName()) != null)
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
        if(args.length == 4)
        {
            String param = args[0];
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

            param = args[1];
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

            param = args[2];
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

            param = args[3];
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
        else
        {
            logger.error("All bounding coordinates are required but null was passed for one or more.");
            throw new WinNodeException("All bounding coordinates are required but null was passed for one or more.");
        }
        return params;
    }

    private Map<String, Object> getNamedParameters(NodeTransaction transaction)
    {
        Map<String, Object> params = new HashMap<String, Object>();
        ByIndexOrNameMap namedParams = transaction.getRequest().getParameters();
        if(namedParams.get(BOUNDING_COORDINATE_NORTH.getName()) == null
                        || namedParams.get(BOUNDING_COORDINATE_SOUTH.getName()) == null
                        || namedParams.get(BOUNDING_COORDINATE_WEST.getName()) == null
                        || namedParams.get(BOUNDING_COORDINATE_EAST.getName()) == null)
        {
            logger.error("All bounding coordinates are required but null was passed for one or more.");
            throw new WinNodeException("All bounding coordinates are required but null was passed for one or more.");
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

        return params;
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName)
    {
        return null;
    }
}
