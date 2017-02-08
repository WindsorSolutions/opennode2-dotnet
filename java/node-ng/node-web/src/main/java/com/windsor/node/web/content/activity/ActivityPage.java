package com.windsor.node.web.content.activity;

import com.windsor.node.domain.entity.Activity;
import com.windsor.node.domain.search.ActivitySearchCriteria;
import com.windsor.node.service.ActivityService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.NodeModalWindowPanel;
import com.windsor.node.web.component.WorkspaceTitlePanel;
import com.windsor.node.web.component.page.NodeDetailPage;
import com.windsor.stack.web.wicket.component.datatable.WindsorDataTableConfiguration;
import com.windsor.stack.web.wicket.component.modal.WindsorBaseModal;
import com.windsor.stack.web.wicket.component.modal.WindsorModal;
import com.windsor.stack.web.wicket.component.modal.WindsorModalWindowPanel;
import com.windsor.stack.web.wicket.event.ResetEvent;
import com.windsor.stack.web.wicket.event.SearchEvent;
import com.windsor.stack.web.wicket.event.ViewEvent;
import com.windsor.stack.web.wicket.model.EntityModel;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import org.apache.wicket.Component;
import org.apache.wicket.PageReference;
import org.apache.wicket.ajax.AbstractAjaxTimerBehavior;
import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.request.mapper.parameter.PageParameters;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.apache.wicket.util.string.StringValue;
import org.apache.wicket.util.time.Duration;
import org.wicketstuff.event.annotation.OnEvent;

/**
 * Provides a page for viewing Activity information.
 */
public class ActivityPage extends NodeDetailPage<ActivitySearchCriteria> {

    public static final String PARAM_ACTIVITY_ID = "id";

    @SpringBean
    private ActivityService service;

    private WindsorModalWindowPanel modal;

    public ActivityPage(PageParameters pageParameters) {
        this(pageParameters, null);
    }

    public ActivityPage(PageParameters pageParameters, PageReference pageReference) {
        super(pageParameters, pageReference);
        setModel(Model.of(new ActivitySearchCriteria()));
        modal = new NodeModalWindowPanel("modal");
        add(modal);
        StringValue activityIdParam = pageParameters.get(PARAM_ACTIVITY_ID);
        if (!activityIdParam.isEmpty()) {
            String activityId = activityIdParam.toString();
            add(new AbstractAjaxTimerBehavior(Duration.milliseconds(50)) {

                public void onTimer(AjaxRequestTarget target) {
                    stop(target);
                    Activity activity = service.load(activityId);
                    if (activity != null) {
                        handleViewEvent(new ViewEvent<>(target, activity));
                    }
                }

            });
        }
    }

    @Override
    protected IModel<String> getPageTitleModel() {
        return new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_ACTIVITY);
    }

    @Override
    protected Component titlePanel(String cid, IModel<ActivitySearchCriteria> model) {
        return new WorkspaceTitlePanel<>(cid, model,
                new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_ACTIVITY),
                new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_SUBHEAD),
                Model.of(""));
    }

    @Override
    protected Component contentPanel(String cid, IModel<ActivitySearchCriteria> model) {
        return new ActivityDataTablePanel(cid, model, 25L, true,
                new WindsorDataTableConfiguration().filteringToolbarVisible(true));
    }

    @Override
    protected Component rightPanel(String cid, IModel<ActivitySearchCriteria> model) {
        return new ActivitySidePanel(cid, model, new IdentifiableResourceModel(NodeResourceModelKeys.HELP_ACTIVITY));
    }

    @OnEvent(types = ActivitySearchCriteria.class)
    public void handleAccountResetEvent(ResetEvent<ActivitySearchCriteria> event) {
        getModelObject().reset();
        event.getTarget().add(this);
    }

    @OnEvent(types = ActivitySearchCriteria.class)
    public void handleAccountSearchEvent(SearchEvent<ActivitySearchCriteria> event) {
        refreshWorkspace(event.getTarget());
    }

    @OnEvent(types = Activity.class)
    public void handleViewEvent(ViewEvent<Activity> event) {
        WindsorModal m = modal.getModal();
        m.setSizeModel(Model.of(WindsorBaseModal.Size.Large));
        m.setContentPanel(new ActivityDetailPanel(m.getContentId(),
                new EntityModel<>(service, event.getPayload().getId())));
        m.show(event.getTarget());
    }

}
