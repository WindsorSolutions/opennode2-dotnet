package com.windsor.node.plugin.facid3;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang3.StringUtils;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.facid3.domain.generated.AffiliateListDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityDetailsDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityListDataType;
import com.windsor.node.plugin.facid3.domain.generated.ObjectFactory;

public class GetFacilityById extends BaseFacIdGetFacilityService
{
    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        List<PluginServiceParameterDescriptor> params = new ArrayList<PluginServiceParameterDescriptor>();
        params.add(FACILITY_SITE_IDENTIFIER);
        // The below is a way to switch these params to be required (which they normally are not)
        params.add(new PluginServiceParameterDescriptor(ORIGINATING_PARTNER_NAME.getName(), ORIGINATING_PARTNER_NAME.getType(),
                        Boolean.TRUE, ORIGINATING_PARTNER_NAME.getDescription(), ORIGINATING_PARTNER_NAME.getDefaultValue()));
        params.add(new PluginServiceParameterDescriptor(INFO_SYSTEM_ACORNYM_NAME.getName(), INFO_SYSTEM_ACORNYM_NAME.getType(),
                        Boolean.TRUE, INFO_SYSTEM_ACORNYM_NAME.getDescription(), INFO_SYSTEM_ACORNYM_NAME.getDefaultValue()));
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
        // clear list of affiliation ids before doing anything
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
        if(transaction.getRequest().getParameterValues() == null)
        {
            // error condition
        }

        Map<String, Object> params = new HashMap<String, Object>();
        String[] args = transaction.getRequest().getParameterValues();
        if(args.length >= 1 && StringUtils.isNotBlank(args[0]))
        {
            params.put(FACILITY_SITE_IDENTIFIER.getName(), args[0]);
        }
        else
        {
            logger.error("Facility Site Identifier parameter cannot be null or empty.");
            throw new RuntimeException("Facility Site Identifier parameter cannot be null or empty.");
        }
        if(args.length >= 2 && StringUtils.isNotBlank(args[1]))
        {
            params.put(ORIGINATING_PARTNER_NAME.getName(), args[1]);
        }
        else
        {
            logger.error("Originating Partner Name parameter cannot be null or empty.");
            throw new RuntimeException("Originating Partner Name parameter cannot be null or empty.");
        }
        if(args.length >= 3 && StringUtils.isNotBlank(args[2]))
        {
            params.put(INFO_SYSTEM_ACORNYM_NAME.getName(), args[2]);
        }
        else
        {
            logger.error("Information System Acronym Name parameter cannot be null or empty.");
            throw new RuntimeException("Information System Acronym Name parameter cannot be null or empty.");
        }
        return params;
    }

}
