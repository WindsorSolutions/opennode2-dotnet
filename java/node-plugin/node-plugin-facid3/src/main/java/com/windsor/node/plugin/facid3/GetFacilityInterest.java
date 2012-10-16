package com.windsor.node.plugin.facid3;

import java.util.List;

import org.apache.commons.io.FilenameUtils;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.plugin.facid3.domain.generated.FacilityInterestDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityInterestSummaryDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityInterestSummaryListDataType;
import com.windsor.node.plugin.facid3.domain.generated.ObjectFactory;

public class GetFacilityInterest extends BaseFacIdGetFacilityService
{

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
        String tempFilePath = FilenameUtils.concat(getSettingService().getTempDir().getAbsolutePath(), "FACID3_GetFacilityInterest" + docId
                        + ".xml");

        ObjectFactory fact = new ObjectFactory();
        FacilityInterestDataType facilityInterest = fact.createFacilityInterestDataType();
        facilityInterest.setSchemaVersion("3.0");

        FacilityInterestSummaryListDataType facilityInterestSummaryList = fact.createFacilityInterestSummaryListDataType();
        facilityInterest.setFacilityInterestSummaryList(facilityInterestSummaryList);

        //get facility interest ids
        List<String> facilityInterestIds = getFacilityIds(transaction);
        for(int i = 0; facilityInterestIds != null && i < facilityInterestIds.size(); i++)
        {
            FacilityInterestSummaryDataType facilityInterestSummary = getFacilityDataTypeDao().loadFacilityInterestSummaryById(facilityInterestIds.get(i));
            facilityInterestSummaryList.getFacilityInterestSummary().add(facilityInterestSummary);
        }

        handleTransactionLifecycle(fact.createFacilityInterest(facilityInterest), transaction, result, docId, tempFilePath, fact);
        return result;
    }
}
