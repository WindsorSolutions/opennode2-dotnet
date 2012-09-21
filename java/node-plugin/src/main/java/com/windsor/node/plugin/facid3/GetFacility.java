package com.windsor.node.plugin.facid3;

import java.text.ParseException;
import java.util.Date;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang3.time.DateUtils;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.facid3.domain.AffiliateListDataType;
import com.windsor.node.plugin.facid3.domain.FacilityDataType;
import com.windsor.node.plugin.facid3.domain.FacilityDetailsDataType;
import com.windsor.node.plugin.facid3.domain.FacilityListDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;

public class GetFacility extends BaseFacIdGetFacilityService
{
    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        List<PluginServiceParameterDescriptor> params = super.getParameters();//all parent params, plus Change Date
        params.add(CHANGE_DATE);
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
        String tempFilePath = FilenameUtils.concat(getSettingService().getTempDir().getAbsolutePath(), "FACID3_GetFacility" + docId
                        + ".xml");

        ObjectFactory fact = new ObjectFactory();
        //clear list of affiliation ids before doing anything
        getAffiliationListDataTypeDao().clearAffiliationIds();
        FacilityDetailsDataType facilityDetails = fact.createFacilityDetailsDataType();
        facilityDetails.setSchemaVersion("3.0");
        FacilityListDataType facilityListElem = fact.createFacilityListDataType();
        facilityDetails.setFacilityList(facilityListElem);

        // merge the facilties, in a loop
        List<String> facilityIds = getFacilityIds(transaction);
        for(int i = 0; facilityIds != null && i < facilityIds.size(); i++)
        {
            FacilityDataType facility = getFacilityDataTypeDao().loadFacilityById(facilityIds.get(i));
            facilityListElem.getFacility().add(facility);
        }

        // merge the affiliates, in a loop
        AffiliateListDataType affiliateList = fact.createAffiliateListDataType();
        facilityDetails.setAffiliateList(affiliateList);
        Iterator<String> affilIt = getAffiliationListDataTypeDao().getAffiliationIds().iterator();
        while(affilIt.hasNext())
        {
            String currentId = affilIt.next();
            affiliateList.getAffiliate().add(getAffiliateDataTypeDao().loadAffiliateById(currentId));
        }

        handleTransactionLifecycle(fact.createFacilityDetails(facilityDetails), transaction, result, docId, tempFilePath, fact);
        return result;
    }

    @Override
    protected Map<String, Object> validateAndLoadParameters(NodeTransaction transaction)
    {
        Map<String, Object> params = super.validateAndLoadParameters(transaction);
        String[] args = transaction.getRequest().getParameterValues();
        if(args.length >= 16)
        {
            String changeDate  = args[15];
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
        return params;
    }

}
