package com.windsor.node.web.component.select2;

import org.apache.wicket.model.IModel;

import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.ExchangeService;
import com.windsor.node.domain.search.ExchangeServiceSearchCriteria;
import com.windsor.node.domain.search.ExchangeServiceSorts;
import com.windsor.node.service.ExchangeServiceService;

/**
 * Provides a provider for selecting an ExchangeService instance.
 */
public class ExchangeServiceChoiceProvider extends NodeEntityChoiceProvider<ExchangeService> {

    private static final int PAGE_SIZE = 20;

    public ExchangeServiceChoiceProvider(ExchangeServiceService service, IModel<Exchange> exchangeModel) {
        super(PAGE_SIZE, ExchangeService::getName, (term, page) ->
                service.find(new ExchangeServiceSearchCriteria()
                            .exchange(exchangeModel.getObject())
                            .name(term),
                        ExchangeServiceSorts.NAME,
                        PAGE_SIZE * page,
                        PAGE_SIZE),
                service);
    }
}
