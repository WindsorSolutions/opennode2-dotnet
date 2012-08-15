package com.windsor.node.plugin.facid3;

import java.text.ParseException;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang3.time.DateUtils;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.facid3.domain.FacilityIndexDataType;
import com.windsor.node.plugin.facid3.domain.FacilitySummaryDataType;
import com.windsor.node.plugin.facid3.domain.FacilitySummaryListDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;

public class GetDeletedFacilityByChangeDate extends BaseFacIdPlugin
{
    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        List<PluginServiceParameterDescriptor> params = new ArrayList<PluginServiceParameterDescriptor>();
        params.add(CHANGE_DATE);
        params.add(ORIGINATING_PARTNER_NAME);
        params.add(INFO_SYSTEM_ACORNYM_NAME);
        return params;
    }

    @Override
    public ProcessContentResult process(NodeTransaction transaction)
    {
        ProcessContentResult result = super.process(transaction);
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);

        String docId = getIdGenerator().createId();
        String tempFilePath = FilenameUtils.concat(getSettingService().getTempDir().getAbsolutePath(),
                                                   "FACID3_GetDeletedFacilityByChangeDate" + docId + ".xml");

        ObjectFactory fact = new ObjectFactory();
        FacilityIndexDataType facilityIndex = fact.createFacilityIndexDataType();
        facilityIndex.setSchemaVersion("3.0");
        FacilitySummaryListDataType facilitySummaryList = fact.createFacilitySummaryListDataType();
        facilityIndex.setFacilitySummaryList(facilitySummaryList);

        List<String> facilityIds = getFacilityIds(transaction);
        for(int i = 0; facilityIds != null && i < facilityIds.size(); i++)
        {
            FacilitySummaryDataType facilitySummary = getFacilityDataTypeDao().loadDeletedFacilitySummaryById(facilityIds.get(i));
            facilitySummaryList.getFacilitySummary().add(facilitySummary);
        }

        handleTransactionLifecycle(fact.createFacilityIndex(facilityIndex), transaction, result, docId, tempFilePath, fact);
        return result;
    }

    private List<String> getFacilityIds(NodeTransaction transaction)
    {
        Map<String, Object> params = validateAndLoadParameters(transaction);
        return getFacilityDataTypeDao().loadAllDeletedFacilityIdsByParams(params);
    }

    private Map<String, Object> validateAndLoadParameters(NodeTransaction transaction)
    {
        if(transaction.getRequest().getParameterValues() == null)
        {
            //error condition
        }

        //These don't currently come in named, which makes them hard for the rest of the system
        //to deal with, so solve that here by putting them in a map with the PluginServiceParameterDescriptor
        //names as the keys
        Map<String, Object> params = new HashMap<String, Object>();
        String[] args = transaction.getRequest().getParameterValues();
        // Change Date is required and must be parseable to a Date
        if(args.length >= 1)
        {
            String changeDate  = args[0];
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
            if(parsedChangeDate == null)
            {
                logger.error("Change Date is required but null was passed.");
                throw new RuntimeException("Change Date is required but null was passed.");
            }
            params.put(CHANGE_DATE.getName(), parsedChangeDate);
        }
        if(args.length >= 2 && args[1] != null)
        {
            params.put(ORIGINATING_PARTNER_NAME.getName(), args[1]);
        }
        if(args.length >= 3 && args[2] != null)
        {
            params.put(INFO_SYSTEM_ACORNYM_NAME.getName(), args[2]);
        }
        return params;
    }
}
