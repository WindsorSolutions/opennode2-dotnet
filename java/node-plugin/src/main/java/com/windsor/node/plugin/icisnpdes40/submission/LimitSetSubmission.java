package com.windsor.node.plugin.icisnpdes40.submission;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.EntityManager;

import com.windsor.node.plugin.icisnpdes40.generated.LimitSetData;
import com.windsor.node.plugin.icisnpdes40.generated.PayloadData;

public class LimitSetSubmission extends AbstractIcisNpdesSubmission {

    @Override
    public void appendToPayload(EntityManager em, PayloadData data) {
        
        final List<LimitSetData> list = em.createQuery("select ls from LimitSetData ls").getResultList();
        
        List<LimitSetData> limitSetData = new ArrayList<LimitSetData>();
        
        for(LimitSetData lsd : list) {
            limitSetData.add(lsd);
        }
        
        data.setLimitSetData(limitSetData);
    }

}
