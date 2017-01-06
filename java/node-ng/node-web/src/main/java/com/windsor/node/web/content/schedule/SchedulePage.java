package com.windsor.node.web.content.schedule;

import org.apache.wicket.Component;
import org.apache.wicket.PageReference;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.request.mapper.parameter.PageParameters;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.wicketstuff.event.annotation.OnEvent;

import com.windsor.node.domain.edit.EditScheduleBean;
import com.windsor.node.domain.entity.Schedule;
import com.windsor.node.domain.search.ScheduleSearchCriteria;
import com.windsor.node.service.ActivityService;
import com.windsor.node.service.ScheduleService;
import com.windsor.node.service.converter.EditScheduleBeanService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.WorkspaceTitlePanel;
import com.windsor.node.web.component.page.NodeDetailPage;
import com.windsor.node.web.content.activity.ActivityDetailPanel;
import com.windsor.node.web.event.RunEvent;
import com.windsor.stack.web.wicket.component.modal.WindsorBaseModal;
import com.windsor.stack.web.wicket.component.modal.WindsorModal;
import com.windsor.stack.web.wicket.component.modal.WindsorModalWindowPanel;
import com.windsor.stack.web.wicket.event.DeleteEvent;
import com.windsor.stack.web.wicket.event.SaveEvent;
import com.windsor.stack.web.wicket.event.ViewEvent;
import com.windsor.stack.web.wicket.model.EntityModel;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

/**
 * Provides a page for managing Schedule instances.
 */
public class SchedulePage extends NodeDetailPage<ScheduleSearchCriteria> {

    @SpringBean
    private ScheduleService scheduleService;

    @SpringBean
    private EditScheduleBeanService editScheduleBeanService;

    @SpringBean
    private ActivityService activityService;

    private WindsorModalWindowPanel modal;

    public SchedulePage(PageParameters pageParameters) {
        this(pageParameters, null);
    }

    public SchedulePage(PageParameters pageParameters, PageReference pageReference) {
        super(pageParameters, pageReference);
        setModel(Model.of(new ScheduleSearchCriteria()));
        modal = new WindsorModalWindowPanel("modal");
        add(modal);
    }

    @Override
    protected IModel<String> getPageTitleModel() {
        return new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_SCHEDULE);
    }

    @Override
    protected Component titlePanel(String cid, IModel<ScheduleSearchCriteria> model) {
        return new WorkspaceTitlePanel<>(cid, model,
                new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_SCHEDULE),
                new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_SUBHEAD_NO_SEARCH),
                Model.of(""));
    }

    @Override
    protected Component contentPanel(String cid, IModel<ScheduleSearchCriteria> model) {
        return new ScheduleExchangeListPanel(cid, model);
    }

    @Override
    protected Component rightPanel(String cid, IModel<ScheduleSearchCriteria> model) {
        return new ScheduleSidePanel(cid, model, new IdentifiableResourceModel(NodeResourceModelKeys.HELP_SCHEDULE));
    }

    @OnEvent(types = EditScheduleBean.class)
    public void handleSaveEvent(final SaveEvent<EditScheduleBean> event) {
        editScheduleBeanService.save(event.getPayload());
    }

    @OnEvent(types = Schedule.class)
    public void handleDeleteEvent(final DeleteEvent<Schedule> event) {
        scheduleService.delete(event.getPayload());
    }

    @OnEvent(types = Schedule.class)
    public void handleRunEvent(final RunEvent<Schedule> event) {
    	scheduleService.runNow(event.getPayload().getId());
    }

    @OnEvent(types = Schedule.class)
    public void handleViewEvent(final ViewEvent<Schedule> event) {
        WindsorModal m = modal.getModal();
        if(event.getPayload().getActivity() != null) {
            m.setSizeModel(Model.of(WindsorBaseModal.Size.Large));
            m.setContentPanel(new ActivityDetailPanel(m.getContentId(),
                    new EntityModel<>(activityService, event.getPayload().getActivity().getId())));
            m.show(event.getTarget());
        }
    }

}
