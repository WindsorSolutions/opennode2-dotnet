package com.windsor.node.web.content.exchange;

import java.util.List;
import java.util.stream.Collectors;

import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.markup.html.WebMarkupContainer;
import org.apache.wicket.markup.html.list.ListItem;
import org.apache.wicket.markup.html.list.ListView;
import org.apache.wicket.model.IModel;
import org.apache.wicket.spring.injection.annot.SpringBean;

import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.search.ExchangeSearchCriteria;
import com.windsor.node.domain.search.ExchangeSorts;
import com.windsor.node.service.ExchangeService;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import com.windsor.stack.web.wicket.model.LDModel;

/**
 * Provides a list of Exchange instances.
 */
public class ExchangeListPanel extends AbstractBasePanel<ExchangeSearchCriteria> {

    @SpringBean
    private ExchangeService service;
    
    private IModel<List<Exchange>> exchangeListModel;
    private WebMarkupContainer container; 
    
    public ExchangeListPanel(String cid, IModel<ExchangeSearchCriteria> model) {
        super(cid, model);
        exchangeListModel = new LDModel<>(() -> service
                .find(model.getObject(), ExchangeSorts.NAME)
                .collect(Collectors.toList()));
        container = new WebMarkupContainer("container");
        container.setOutputMarkupId(true);
        add(container);
        container.add(new ListView<Exchange>("exchanges", exchangeListModel) {

            @Override
            protected void populateItem(ListItem<Exchange> listItem) {
                listItem.add(new ExchangeDetailPanel("exchange", listItem.getModel()));
            }

        });
    }
    
    public void refresh(AjaxRequestTarget target) {
    	exchangeListModel.detach();
    	target.add(container);
    }
    
}
