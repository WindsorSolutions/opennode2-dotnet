package com.windsor.node.web.content.partner;

import org.apache.wicket.Component;
import org.apache.wicket.PageReference;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.request.mapper.parameter.PageParameters;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.wicketstuff.event.annotation.OnEvent;

import com.windsor.node.domain.entity.Partner;
import com.windsor.node.domain.search.PartnerSearchCriteria;
import com.windsor.node.service.PartnerService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.WorkspaceTitlePanel;
import com.windsor.node.web.component.page.NodeDetailPage;
import com.windsor.node.web.event.TestEvent;
import com.windsor.stack.web.wicket.component.modal.WindsorModal;
import com.windsor.stack.web.wicket.component.modal.WindsorModalWindowPanel;
import com.windsor.stack.web.wicket.event.AddEvent;
import com.windsor.stack.web.wicket.event.DeleteEvent;
import com.windsor.stack.web.wicket.event.EditEvent;
import com.windsor.stack.web.wicket.event.SaveEvent;
import com.windsor.stack.web.wicket.event.SearchEvent;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

/**
 * Provides a page for managing Partner instances.
 */
public class PartnerPage extends NodeDetailPage<PartnerSearchCriteria> {

    @SpringBean
    private PartnerService service;

    private WindsorModalWindowPanel modal;

    public PartnerPage(PageParameters pageParameters) {
        this(pageParameters, null);
    }

    public PartnerPage(PageParameters pageParameters, PageReference pageReference) {
        super(pageParameters, pageReference);
        setModel(Model.of(new PartnerSearchCriteria()));
        modal = new WindsorModalWindowPanel("modal");
        add(modal);
    }

    @Override
    protected IModel<String> getPageTitleModel() {
        return new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_PARTNER);
    }

    @Override
    protected Component titlePanel(String cid, IModel<PartnerSearchCriteria> model) {
        return new WorkspaceTitlePanel<>(cid, model,
                new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_PARTNER),
                new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_SUBHEAD),
                Model.of(""));
    }

    @Override
    protected Component contentPanel(String cid, IModel<PartnerSearchCriteria> model) {
        return new PartnerPanel(cid, model);
    }

    @Override
    protected Component rightPanel(String cid, IModel<PartnerSearchCriteria> model) {
        return new SidePanel(cid, new IdentifiableResourceModel(NodeResourceModelKeys.HELP_PARTNER));
    }

    @OnEvent(types = Partner.class)
    public void handleSaveEvent(final SaveEvent<Partner> event) {
        modal.getModal().close(event.getTarget());
        service.save(event.getPayload());
        refreshWorkspace(event.getTarget());
    }

    @OnEvent(types = Partner.class)
    public void handleDeleteEvent(final DeleteEvent<Partner> event) {
        service.delete(event.getPayload());
        refreshWorkspace(event.getTarget());
    }

    @OnEvent(types = PartnerSearchCriteria.class)
    public void handleArgumentSearchEvent(SearchEvent<PartnerSearchCriteria> event) {
        refreshWorkspace(event.getTarget());
    }

    @OnEvent(types = Partner.class, stop = true)
    public void handleTestEvent(final TestEvent<Partner> event) {
        Partner partner = event.getPayload();
        try {
            String result = service.validatePartner(partner);
            success("Successfully contacted the partner, the response was \"" + result + "\"");
        } catch(Exception exception) {
            error("Could not contact the partner: " + exception.getMessage());
        }
        refreshWorkspace(event.getTarget());
    }

    @OnEvent(types = Partner.class)
    public void handleEditEvent(final EditEvent<Partner> event) {
        WindsorModal m = modal.getModal();
        m.setContentPanel(
                new PartnerFormPanel(m.getContentId(), Model.of(event.getPayload())));
        m.show(event.getTarget());
    }

    @OnEvent(types = Partner.class)
    public void handleAddArgumentEvent(AddEvent event) {
        WindsorModal m = modal.getModal();
        m.setContentPanel(new PartnerFormPanel(m.getContentId(), Model.of(new Partner())));
        m.show(event.getTarget());
    }

}
