package com.windsor.node.plugin.ic;

import java.text.ParseException;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import javax.sql.DataSource;
import org.apache.commons.lang3.time.DateUtils;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;

public class GetICDataByChangeDate extends AbstractICPlugin
{
    private static final long serialVersionUID = 1L;

    public static final PluginServiceParameterDescriptor CHANGE_DATE = new PluginServiceParameterDescriptor(
                    "ChangeDate",
                    PluginServiceParameterDescriptor.TYPE_DATE,
                    Boolean.TRUE,
                    "Date since any data element of an institutional control has been modified. Response will include all institutional controls that have changed on or after this date.\n\n Format of input date is YYYY-MM-DD.");

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName(GetICDataByChangeDate.class.getName());
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Used to support the creation and maintenance of a replica set of institutional control data across partners (i.e., data synchronization).");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(GetICDataByChangeDate.class.getCanonicalName());
    }

    public GetICDataByChangeDate()
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
        params.add(CHANGE_DATE);
        return params;
    }

    protected Map<String, Object> loadParameters(NodeTransaction transaction)
    {
        Map<String, Object> params = new HashMap<String, Object>();
        //determine which endpoint the request came in on, seriously, why haven't I automated this by now?
        //can't check which endpoint version because some endpoints opt to not send by name despite being v2.1
        //Blame Canada
        if(transaction.getRequest().getParameters().get(CHANGE_DATE.getName()) != null)
        {
            params = getNamedParameters(transaction);
        }
        else
        {
            params = getOrderedParameters(transaction);
        }
        return params;
    }

    private Map<String, Object> getOrderedParameters(NodeTransaction transaction)
    {
        Map<String, Object> params = new HashMap<String, Object>();
        String[] args = transaction.getRequest().getParameterValues();
        if(args.length >= 1)
        {
            String changeDate = args[0];
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
        else
        {
            logger.error("Change Date is required but null was passed.");
            throw new RuntimeException("Change Date is required but null was passed.");
        }
        return params;
    }

    protected Map<String, Object> getNamedParameters(NodeTransaction transaction)
    {
        Map<String, Object> params = new HashMap<String, Object>();
        ByIndexOrNameMap namedParams = transaction.getRequest().getParameters();
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
                throw new RuntimeException("Unparseable date passed in for Change Date:  " + changeDate);
            }
            params.put(CHANGE_DATE.getName(), parsedChangeDate);
        }
        else
        {
            logger.error(CHANGE_DATE.getName() + " is required but null was passed.");
            throw new WinNodeException(CHANGE_DATE.getName() + " is required but null was passed.");
        }
        return params;
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName)
    {
        return null;
    }
}
