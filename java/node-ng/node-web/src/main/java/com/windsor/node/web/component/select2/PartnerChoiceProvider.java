package com.windsor.node.web.component.select2;

import com.windsor.node.domain.entity.Partner;
import com.windsor.node.domain.search.PartnerSearchCriteria;
import com.windsor.node.domain.search.PartnerSorts;
import com.windsor.node.service.PartnerService;

/**
 * Provides a provider for selecting a Partner instances.
 */
public class PartnerChoiceProvider extends NodeEntityChoiceProvider<Partner> {

    private static final int PAGE_SIZE = 20;

    public PartnerChoiceProvider(PartnerService service) {
        super(PAGE_SIZE, Partner::getName, (term, page) ->
                service.find(new PartnerSearchCriteria().name(term),
                        PartnerSorts.NAME, PAGE_SIZE * page, PAGE_SIZE), service);
    }
}
