package com.windsor.node.plugin.facid3;

import java.util.List;
import org.apache.commons.io.FilenameUtils;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.plugin.facid3.domain.FacilityIndexDataType;
import com.windsor.node.plugin.facid3.domain.FacilitySummaryDataType;
import com.windsor.node.plugin.facid3.domain.FacilitySummaryListDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;

public class GetFacilityList extends BaseFacIdGetFacilityService
{

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("GetFacilityList");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("This service supports a full set of query parameters but returns a light payload (FacilityIndex) to aid in performance.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(GetFacilityList.class.getCanonicalName());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
    {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
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
        String tempFilePath = FilenameUtils.concat(getSettingService().getTempDir().getAbsolutePath(), "FACID3_GetFacilityList" + docId
                        + ".xml");

        ObjectFactory fact = new ObjectFactory();
        FacilityIndexDataType facilityIndex = fact.createFacilityIndexDataType();
        facilityIndex.setSchemaVersion("3.0");
        FacilitySummaryListDataType facilitySummaryList = fact.createFacilitySummaryListDataType();
        facilityIndex.setFacilitySummaryList(facilitySummaryList);

        //facilitySummaryList.getFacilitySummary().add(facilitySummary);
        List<String> facilityIds = getFacilityIds(transaction);
        for(int i = 0; facilityIds != null && i < facilityIds.size(); i++)
        {
            FacilitySummaryDataType facilitySummary = getFacilityDataTypeDao().loadFacilitySummaryById(facilityIds.get(i));
            facilitySummaryList.getFacilitySummary().add(facilitySummary);
        }

        handleTransactionLifecycle(fact.createFacilityIndex(facilityIndex), transaction, result, docId, tempFilePath, fact);
        return result;
    }
}
