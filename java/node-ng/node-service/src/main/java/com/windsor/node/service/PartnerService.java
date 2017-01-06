package com.windsor.node.service;

import com.windsor.node.domain.entity.Partner;
import com.windsor.node.domain.search.PartnerSearchCriteria;
import com.windsor.node.domain.search.PartnerSort;
import com.windsor.stack.domain.service.ICrudService;

/**
 * Provides a service for managing Partner instances.
 */
public interface PartnerService extends ICrudService<Partner, String, PartnerSearchCriteria, PartnerSort> {

    Partner load(String id);

    String validatePartner(Partner partner) throws Exception;
}
