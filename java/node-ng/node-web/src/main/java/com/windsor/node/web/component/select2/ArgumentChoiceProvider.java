package com.windsor.node.web.component.select2;

import com.windsor.node.domain.entity.Argument;
import com.windsor.node.domain.search.ArgumentSearchCriteria;
import com.windsor.node.domain.search.ArgumentSorts;
import com.windsor.node.service.ArgumentService;

/**
 * Provides a provider for selecting an Argument instance.
 */
public class ArgumentChoiceProvider extends NodeEntityChoiceProvider<Argument> {

    private static final int PAGE_SIZE = 20;

    public ArgumentChoiceProvider(ArgumentService service) {
        super(PAGE_SIZE, Argument::getName, (term, page) ->
                service.find(new ArgumentSearchCriteria().name(term),
                        ArgumentSorts.NAME, PAGE_SIZE * page, PAGE_SIZE), service);
    }
}
