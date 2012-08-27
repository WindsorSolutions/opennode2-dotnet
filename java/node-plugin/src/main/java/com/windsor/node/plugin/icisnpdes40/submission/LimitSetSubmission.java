package com.windsor.node.plugin.icisnpdes40.submission;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.EntityManager;

import com.windsor.node.plugin.icisnpdes40.generated.LimitSetData;
import com.windsor.node.plugin.icisnpdes40.generated.ObjectFactory;
import com.windsor.node.plugin.icisnpdes40.generated.OperationType;
import com.windsor.node.plugin.icisnpdes40.generated.PayloadData;

public class LimitSetSubmission extends AbstractIcisNpdesSubmission {

    private final OperationType operationType = OperationType.LIMIT_SET_SUBMISSION;

    @Override
    public List<PayloadData> createAllPayloads(EntityManager em) {

        ObjectFactory fact = new ObjectFactory();
        PayloadData payloadData = fact.createPayloadData();
        payloadData.setOperation(operationType);

        @SuppressWarnings("unchecked")
        final List<LimitSetData> list = em.createQuery("select ls from LimitSetData ls").getResultList();

        List<LimitSetData> limitSetData = new ArrayList<LimitSetData>();
        
        for(LimitSetData lsd : list) {
            limitSetData.add(lsd);
        }

        payloadData.setLimitSetData(limitSetData);
        List<PayloadData> allPayloads = new ArrayList<PayloadData>();
        allPayloads.add(payloadData);
        return allPayloads;
    }

}
