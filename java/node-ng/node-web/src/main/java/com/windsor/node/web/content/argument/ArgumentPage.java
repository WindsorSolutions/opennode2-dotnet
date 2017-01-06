package com.windsor.node.web.content.argument;

import org.apache.wicket.Component;
import org.apache.wicket.PageReference;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.request.mapper.parameter.PageParameters;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.wicketstuff.event.annotation.OnEvent;

import com.windsor.node.domain.entity.Argument;
import com.windsor.node.domain.search.ArgumentSearchCriteria;
import com.windsor.node.service.ArgumentService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.WorkspaceTitlePanel;
import com.windsor.node.web.component.page.NodeDetailPage;
import com.windsor.stack.web.wicket.component.modal.WindsorModal;
import com.windsor.stack.web.wicket.component.modal.WindsorModalWindowPanel;
import com.windsor.stack.web.wicket.event.AddEvent;
import com.windsor.stack.web.wicket.event.DeleteEvent;
import com.windsor.stack.web.wicket.event.EditEvent;
import com.windsor.stack.web.wicket.event.SaveEvent;
import com.windsor.stack.web.wicket.event.SearchEvent;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

/**
 * Provides a page for managing Argument instances.
 */
public class ArgumentPage extends NodeDetailPage<ArgumentSearchCriteria> {

    @SpringBean
    private ArgumentService service;

    private WindsorModalWindowPanel modal;

    public ArgumentPage(PageParameters pageParameters) {
        this(pageParameters, null);
    }

    public ArgumentPage(PageParameters pageParameters, PageReference pageReference) {
        super(pageParameters, pageReference);
        setModel(Model.of(new ArgumentSearchCriteria()));
        modal = new WindsorModalWindowPanel("modal");
        add(modal);
    }

    @Override
    protected IModel<String> getPageTitleModel() {
        return new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_ARGUMENT);
    }

    @Override
    protected Component titlePanel(String cid, IModel<ArgumentSearchCriteria> model) {
        return new WorkspaceTitlePanel<>(cid, model,
                new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_ARGUMENT),
                new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_SUBHEAD),
                Model.of(""));
    }

    @Override
    protected Component contentPanel(String cid, IModel<ArgumentSearchCriteria> model) {
        return new ArgumentDataTable(cid, model);
    }

    @Override
    protected Component rightPanel(String cid, IModel<ArgumentSearchCriteria> model) {
        return new SidePanel(cid, new IdentifiableResourceModel(NodeResourceModelKeys.HELP_ARGUMENT));
    }

    @OnEvent(types = Argument.class)
    public void handleSaveEvent(final SaveEvent<Argument> event) {
        modal.getModal().close(event.getTarget());
        service.save(event.getPayload());
        refreshWorkspace(event.getTarget());
    }

    @OnEvent(types = Argument.class)
    public void handleDeleteEvent(final DeleteEvent<Argument> event) {
        service.delete(event.getPayload());
        refreshWorkspace(event.getTarget());
    }

    @OnEvent(types = ArgumentSearchCriteria.class)
    public void handleArgumentSearchEvent(SearchEvent<ArgumentSearchCriteria> event) {
        refreshWorkspace(event.getTarget());
    }

    @OnEvent(types = Argument.class)
    public void handleEditEvent(final EditEvent<Argument> event) {
        WindsorModal m = modal.getModal();
        m.setContentPanel(new ArgumentFormPanel(m.getContentId(), Model.of(event.getPayload())));
        m.show(event.getTarget());
    }

    @OnEvent(types = Argument.class)
    public void handleAddArgumentEvent(AddEvent event) {
        WindsorModal m = modal.getModal();
        m.setContentPanel(new ArgumentFormPanel(m.getContentId(), Model.of(new Argument())));
        m.show(event.getTarget());
    }

}
