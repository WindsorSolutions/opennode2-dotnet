package com.windsor.node.web.content.exchange;

import org.apache.wicket.Component;
import org.apache.wicket.PageReference;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.request.mapper.parameter.PageParameters;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.wicketstuff.event.annotation.OnEvent;

import com.windsor.node.domain.edit.EditExchangeBean;
import com.windsor.node.domain.edit.EditExchangeServiceBean;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.search.ExchangeSearchCriteria;
import com.windsor.node.service.ExchangeService;
import com.windsor.node.service.ExchangeServiceService;
import com.windsor.node.service.PluginService;
import com.windsor.node.service.converter.EditExchangeBeanService;
import com.windsor.node.service.converter.EditExchangeServiceBeanService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.WorkspaceTitlePanel;
import com.windsor.node.web.component.page.NodeDetailPage;
import com.windsor.stack.web.wicket.component.modal.WindsorModal;
import com.windsor.stack.web.wicket.component.modal.WindsorModalWindowPanel;
import com.windsor.stack.web.wicket.event.AddEvent;
import com.windsor.stack.web.wicket.event.DeleteEvent;
import com.windsor.stack.web.wicket.event.SaveEvent;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

/**
 * Provides a page for managing Exchange instances.
 */
public class ExchangePage extends NodeDetailPage<ExchangeSearchCriteria> {

    @SpringBean
    private ExchangeService service;

    @SpringBean
    private PluginService pluginService;

    @SpringBean
    private EditExchangeBeanService editExchangeBeanService;

    @SpringBean
    private EditExchangeServiceBeanService editExchangeServiceBeanService;

    @SpringBean
    private ExchangeServiceService exchangeServiceService;

    private WindsorModalWindowPanel modal;
    private ExchangeListPanel content;

    public ExchangePage(PageParameters pageParameters) {
        this(pageParameters, null);
    }

    public ExchangePage(PageParameters pageParameters, PageReference pageReference) {
        super(pageParameters, pageReference);
        setModel(Model.of(new ExchangeSearchCriteria()));
        modal = new WindsorModalWindowPanel("modal");
        add(modal);
    }

    @Override
    protected IModel<String> getPageTitleModel() {
        return new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_EXCHANGES);
    }

    @Override
    protected Component titlePanel(String cid, IModel<ExchangeSearchCriteria> model) {
        return new WorkspaceTitlePanel<>(cid, model,
                new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_EXCHANGES),
                new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_SUBHEAD_NO_SEARCH),
                Model.of(""));
    }

    @Override
    protected Component contentPanel(String cid, IModel<ExchangeSearchCriteria> model) {
        content = new ExchangeListPanel(cid, model);
        return content;
    }

    @Override
    protected Component rightPanel(String cid, IModel<ExchangeSearchCriteria> model) {
        return new ExchangeSidePanel(cid, model, new IdentifiableResourceModel(NodeResourceModelKeys.HELP_EXCHANGE));
    }

    /*
     * Save event handlers.
     */

    @OnEvent(types = EditExchangeBean.class)
    public void handleSaveEditExchangeBeanEvent(final SaveEvent<EditExchangeBean> event) {
    	modal.getModal().close(event.getTarget());
        EditExchangeBean bean = event.getPayload();
        editExchangeBeanService.save(bean);
    	if (bean.isNameChanged()) {
    		content.refresh(event.getTarget());
    	}
    }

    @OnEvent(types = EditExchangeServiceBean.class)
    public void handleSaveEditExchangeServiceBeanEvent(SaveEvent<EditExchangeServiceBean> event) {
        editExchangeServiceBeanService.save(event.getPayload());
    }

    /*
     * Delete event handlers.
     */

    @OnEvent(types = Exchange.class)
    public void handleDeleteEvent(final DeleteEvent<Exchange> event) {
        service.delete(event.getPayload());
        content.refresh(event.getTarget());
    }

    @OnEvent(types = com.windsor.node.domain.entity.ExchangeService.class)
    public void handleDeleteExchangeServiceEvent(final DeleteEvent<com.windsor.node.domain.entity.ExchangeService> event) {
        exchangeServiceService.delete(event.getPayload());
    }

    /*
     * Add event handlers.
     */

    @OnEvent(types = Exchange.class)
    public void handleAddArgumentEvent(AddEvent event) {
        WindsorModal m = modal.getModal();
        m.setContentPanel(new ExchangeFormPanel(m.getContentId(), Model.of(new EditExchangeBean())));
        m.show(event.getTarget());
    }

}
