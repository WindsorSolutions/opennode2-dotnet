package com.windsor.node.web.content.schedule;

import com.windsor.node.domain.edit.EditScheduleBean;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.Schedule;
import com.windsor.node.domain.entity.ScheduleExecuteStatus;
import com.windsor.node.service.ScheduleService;
import com.windsor.node.service.converter.EditScheduleBeanService;
import com.windsor.node.web.component.NodeModalWindowPanel;
import com.windsor.node.web.event.StopEvent;
import com.windsor.node.web.model.lazy.ExchangeModels;
import com.windsor.stack.web.wicket.component.modal.WindsorBaseModal.Size;
import com.windsor.stack.web.wicket.component.modal.WindsorModal;
import com.windsor.stack.web.wicket.component.modal.WindsorModalWindowPanel;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import com.windsor.stack.web.wicket.event.AddEvent;
import com.windsor.stack.web.wicket.event.DeleteEvent;
import com.windsor.stack.web.wicket.event.EditEvent;
import com.windsor.stack.web.wicket.event.SaveEvent;
import com.windsor.stack.web.wicket.markup.html.form.button.AddButton;
import com.windsor.stack.web.wicket.model.GenericModels;
import de.agilecoders.wicket.core.markup.html.bootstrap.button.Buttons;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.wicketstuff.event.annotation.OnEvent;

/**
 * Provides a panel with detail information about an Exchange instance.
 */
public class ScheduleExchangeDetailPanel extends AbstractBasePanel<Exchange> {

    @SpringBean
    private EditScheduleBeanService service;
    
    @SpringBean
    private EditScheduleBeanService editScheduleBeanService;

    @SpringBean
    private ScheduleService scheduleService;

    private Form<Exchange> form;
    private WindsorModalWindowPanel modal;

    public ScheduleExchangeDetailPanel(String cid, IModel<Exchange> model) {
        super(cid, model);

        modal = new NodeModalWindowPanel("modal");
        add(modal);
        
        form = new Form<>("form", model);
        add(form);

        form.add(new Label("name", ExchangeModels.bindName(model)));
        form.add(new AddButton("add",
                GenericModels.MODEL_EMPTY,
                Buttons.Type.Default,
                (t, f) -> new AddEvent(t, Schedule.class)));

        form.add(new ScheduleDataTable("table", model));
    }
    
    @OnEvent(types = EditScheduleBean.class)
    public void handleSaveEvent(SaveEvent<EditScheduleBean> event) {
    	modal.getModal().appendCloseDialogJavaScript(event.getTarget());
    	event.getTarget().add(form);
    }

    @OnEvent(types = Schedule.class)
    public void handleStopEvent(StopEvent<Schedule> event) {
        Schedule schedule = event.getPayload();
        schedule.setRunNow(false);
        scheduleService.save(schedule);
        event.getTarget().add(form);
    }

    @OnEvent(types = Schedule.class)
    public void handleDeleteEvent(DeleteEvent<Schedule> event) {
        event.getTarget().add(form);
    }
    
    @OnEvent(types = Schedule.class)
    public void handleEditEvent(final EditEvent<Schedule> event) {
        WindsorModal m = modal.getModal();
        m.setContentPanel(
                new ScheduleFormPanel(m.getContentId(),
                        Model.of(editScheduleBeanService.toBean(event.getPayload()))));
        m.show(event.getTarget());
    }

    @OnEvent(types = Schedule.class)
    public void handleAddEvent(AddEvent event) {
        WindsorModal m = modal.getModal();
        m.setSizeModel(Model.of(Size.Default));
        Exchange exchange = getPanelModelObject();
        String exchangeId = exchange.getId();
        m.setContentPanel(new ScheduleFormPanel(m.getContentId(),
                Model.of(new EditScheduleBean(exchangeId))));
        m.show(event.getTarget());
    }

}
