package com.windsor.node.plugin.facid3;

import java.text.ParseException;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang3.StringUtils;
import org.apache.commons.lang3.time.DateUtils;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.facid3.domain.AffiliateListDataType;
import com.windsor.node.plugin.facid3.domain.FacilityDataType;
import com.windsor.node.plugin.facid3.domain.FacilityDetailsDataType;
import com.windsor.node.plugin.facid3.domain.FacilityListDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;

public class GetFacilityByChangeDate extends BaseFacIdGetFacilityService
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
        /*if(EndpointVersionType.EN11 == transaction.getEndpointVersion())
        {
            params = getParametersEn11(transaction);
        }
        else if(EndpointVersionType.EN20 == transaction.getEndpointVersion())
        {
            params = getParametersEn21(transaction);
        }
        else
        {
            //error, undefined endpoint version, could not determine param strategy
        }*/
        if(transaction.getRequest().getParameters().get(CHANGE_DATE.getName()) != null)
        {//then params are named
            params = getParametersEn21(transaction);
        }
        else
        {//use ordered params
            params = getParametersEn11(transaction);
        }
        return params;
    }

    private Map<String, Object> getParametersEn11(NodeTransaction transaction)
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
                throw new RuntimeException("Unparseable date passed in for Change Date:  " + changeDate);
            }
            params.put(CHANGE_DATE.getName(), parsedChangeDate);
        }
        else
        {
            logger.error("Change Date is required but null was passed.");
            throw new RuntimeException("Change Date is required but null was passed.");
        }
        if(args.length >= 2 && StringUtils.isNotBlank(args[1]))
        {
            params.put(ORIGINATING_PARTNER_NAME.getName(), args[1]);
        }
        if(args.length >= 3 && StringUtils.isNotBlank(args[2]))
        {
            params.put(INFO_SYSTEM_ACORNYM_NAME.getName(), args[2]);
        }
        return params;
    }

    private Map<String, Object> getParametersEn21(NodeTransaction transaction)
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
            throw new RuntimeException(CHANGE_DATE.getName() + " is required but null was passed.");
        }
        if(StringUtils.isNotEmpty((String)namedParams.get(ORIGINATING_PARTNER_NAME.getName())))
        {
            params.put(ORIGINATING_PARTNER_NAME.getName(), namedParams.get(ORIGINATING_PARTNER_NAME.getName()));
        }
        if(StringUtils.isNotEmpty((String)namedParams.get(INFO_SYSTEM_ACORNYM_NAME.getName())))
        {
            params.put(INFO_SYSTEM_ACORNYM_NAME.getName(), namedParams.get(INFO_SYSTEM_ACORNYM_NAME.getName()));
        }
        return params;
    }
}
