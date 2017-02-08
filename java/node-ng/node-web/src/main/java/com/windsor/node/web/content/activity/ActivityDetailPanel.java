package com.windsor.node.web.content.activity;

import com.windsor.node.domain.entity.Activity;
import com.windsor.node.service.ActivityDetailService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.model.lazy.ActivityModels;
import com.windsor.stack.web.wicket.component.panel.modal.ModalizablePanel;
import com.windsor.stack.web.wicket.component.tabs.WindsorAjaxTabbedPanel;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import com.windsor.stack.web.wicket.model.LDModel;
import org.apache.wicket.extensions.markup.html.tabs.AbstractTab;
import org.apache.wicket.extensions.markup.html.tabs.ITab;
import org.apache.wicket.markup.html.WebMarkupContainer;
import org.apache.wicket.markup.html.link.ExternalLink;
import org.apache.wicket.model.IModel;
import org.apache.wicket.request.Url;
import org.apache.wicket.request.cycle.RequestCycle;
import org.apache.wicket.request.mapper.parameter.PageParameters;
import org.apache.wicket.spring.injection.annot.SpringBean;

import java.util.Arrays;
import java.util.List;

public class ActivityDetailPanel extends ModalizablePanel<Activity> {

    @SpringBean
    private ActivityDetailService service;

    public ActivityDetailPanel(String id, IModel<Activity> model) {
        super(id, model);
        add(new WindsorAjaxTabbedPanel<>("tabs", newTabs(model)));
        PageParameters activityIdPageParameters = new PageParameters();
        activityIdPageParameters.set(ActivityPage.PARAM_ACTIVITY_ID, model.getObject().getId());
        IModel<String> urlModel = new LDModel<>(() -> RequestCycle.get().getUrlRenderer()
                .renderFullUrl(Url.parse(urlFor(ActivityPage.class, activityIdPageParameters).toString())));
        add(new ExternalLink("url", urlModel, urlModel));
    }

    private List<ITab> newTabs(IModel<Activity> model) {
        return Arrays.asList(

                new AbstractTab(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_TRANSACTION)) {

                    @Override
                    public WebMarkupContainer getPanel(String panelId) {
                        return new TransactionDetailPanel(panelId, ActivityModels.bindTransaction(model));
                    }

                    @Override
                    public boolean isVisible() {
                        return model.getObject().getTransaction() != null;
                    }

                },
                new AbstractTab(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ACTIVITY)) {

                    @Override
                    public WebMarkupContainer getPanel(String panelId) {
                        return new ActivityDetailDataTablePanel(panelId, model);
                    }

                });
    }

    @Override
    public IModel<String> getModalTitleModel() {
        return new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_DETAILS);
    }

    @Override
    public Boolean isFooterVisible() {
        return false;
    }

}
