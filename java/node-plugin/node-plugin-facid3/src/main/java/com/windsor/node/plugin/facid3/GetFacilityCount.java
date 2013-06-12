package com.windsor.node.plugin.facid3;

import java.math.BigInteger;
import java.util.ArrayList;
import java.util.List;
import org.apache.commons.io.FilenameUtils;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.facid3.domain.FacilityCountDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;

public class GetFacilityCount extends BaseFacIdGetFacilityService
{

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("GetFacilityCount");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Partners may choose to implement this internally for costing purposes, so that over-large queries can be intercepted before they are run.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(GetFacilityCount.class.getCanonicalName());
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

    /**
     * This process implementer currently will not work when Solicited on the 2.1 endpoint with named parameters that are 
     * out of the default order.  An updated implementer that fixes this issue will soon be deployed.
     */
    @Override
    public ProcessContentResult process(NodeTransaction transaction)
    {
        ProcessContentResult result = super.process(transaction);
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);

        String docId = getIdGenerator().createId();
        String tempFilePath = FilenameUtils.concat(getSettingService().getTempDir().getAbsolutePath(), "FACID3_GetFacilityCount" + docId
                        + ".xml");

        ObjectFactory fact = new ObjectFactory();
        FacilityCountDataType facilityCount = fact.createFacilityCountDataType();
        facilityCount.setSchemaVersion("3.0");
        // get count
        List<String> facilityIds = getFacilityIds(transaction);
        BigInteger facilityCountMeasure = new BigInteger("" + facilityIds.size());
        facilityCount.setFacilityCountMeasure(facilityCountMeasure);

        handleTransactionLifecycle(fact.createFacilityCount(facilityCount), transaction, result, docId, tempFilePath, fact);
        return result;
    }
}
