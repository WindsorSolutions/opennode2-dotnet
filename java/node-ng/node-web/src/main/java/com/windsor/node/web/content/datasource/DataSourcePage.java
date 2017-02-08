package com.windsor.node.web.content.datasource;

import com.windsor.node.domain.DataSourceTestResult;
import com.windsor.node.domain.entity.DataSource;
import com.windsor.node.domain.search.DataSourceSearchCriteria;
import com.windsor.node.service.DataSourceService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.NodeModalWindowPanel;
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
import org.apache.wicket.Component;
import org.apache.wicket.PageReference;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.request.mapper.parameter.PageParameters;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.wicketstuff.event.annotation.OnEvent;

/**
 * Provides a page for managing DataSource instances.
 */
public class DataSourcePage extends NodeDetailPage<DataSourceSearchCriteria> {

    @SpringBean
    private DataSourceService service;

    private WindsorModalWindowPanel modal;

    public DataSourcePage(PageParameters pageParameters) {
        this(pageParameters, null);
    }

    public DataSourcePage(PageParameters pageParameters, PageReference pageReference) {
        super(pageParameters, pageReference);
        setModel(Model.of(new DataSourceSearchCriteria()));
        modal = new NodeModalWindowPanel("modal");
        add(modal);
    }

    @Override
    protected IModel<String> getPageTitleModel() {
        return new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_DATA_SOURCE);
    }

    @Override
    protected Component titlePanel(String cid, IModel<DataSourceSearchCriteria> model) {
        return new WorkspaceTitlePanel<>(cid, model,
                new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_DATA_SOURCE),
                new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_SUBHEAD),
                Model.of(""));
    }

    @Override
    protected Component contentPanel(String cid, IModel<DataSourceSearchCriteria> model) {
        return new DataSourcePanel(cid, model);
    }

    @Override
    protected Component rightPanel(String cid, IModel<DataSourceSearchCriteria> model) {
        return new SidePanel(cid, new IdentifiableResourceModel(NodeResourceModelKeys.HELP_DATA_SOURCE));
    }

    @OnEvent(types = DataSource.class)
    public void handleSaveEvent(final SaveEvent<DataSource> event) {
        modal.getModal().close(event.getTarget());
        service.save(event.getPayload());
        refreshWorkspace(event.getTarget());
    }

    @OnEvent(types = DataSource.class)
    public void handleDeleteEvent(final DeleteEvent<DataSource> event) {
        service.delete(event.getPayload());
        refreshWorkspace(event.getTarget());
    }

    @OnEvent(types = DataSource.class, stop = true)
    public void handleTestEvent(final TestEvent<DataSource> event) {
        DataSourceTestResult result = service.test(event.getPayload());
        if (result.isSuccess()) {
            success(result.getMessage());
        } else {
            error(result.getMessage());
        }
        refreshWorkspace(event.getTarget());
    }

    @OnEvent(types = DataSourceSearchCriteria.class)
    public void handleArgumentSearchEvent(SearchEvent<DataSourceSearchCriteria> event) {
        refreshWorkspace(event.getTarget());
    }

    @OnEvent(types = DataSource.class)
    public void handleAddArgumentEvent(AddEvent event) {
        WindsorModal m = modal.getModal();
        m.setContentPanel(new DataSourceFormPanel(m.getContentId(), Model.of(new DataSource())));
        m.show(event.getTarget());
    }

    @OnEvent(types = DataSource.class)
    public void handleEditEvent(final EditEvent<DataSource> event) {
        WindsorModal m = modal.getModal();
        m.setContentPanel(new DataSourceFormPanel(m.getContentId(), Model.of(event.getPayload())));
        m.show(event.getTarget());
    }

}
