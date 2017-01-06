package com.windsor.node.web.content.exchange;

import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.wicketstuff.event.annotation.OnEvent;

import com.windsor.node.domain.edit.EditExchangeBean;
import com.windsor.node.domain.edit.EditExchangeServiceBean;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.ExchangeService;
import com.windsor.node.service.converter.EditExchangeBeanService;
import com.windsor.node.service.converter.EditExchangeServiceBeanService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.event.AddWithContextEvent;
import com.windsor.node.web.model.lazy.ExchangeModels;
import com.windsor.stack.web.wicket.app.Icons;
import com.windsor.stack.web.wicket.component.modal.WindsorModal;
import com.windsor.stack.web.wicket.component.modal.WindsorModalWindowPanel;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import com.windsor.stack.web.wicket.event.DeleteEvent;
import com.windsor.stack.web.wicket.event.EditEvent;
import com.windsor.stack.web.wicket.event.SaveEvent;
import com.windsor.stack.web.wicket.markup.html.form.button.AddButton;
import com.windsor.stack.web.wicket.markup.html.form.button.ConfirmationButton;
import com.windsor.stack.web.wicket.markup.html.form.button.DeleteButton;
import com.windsor.stack.web.wicket.markup.html.form.button.EditButton;
import com.windsor.stack.web.wicket.model.GenericModels;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

import de.agilecoders.wicket.core.markup.html.bootstrap.button.Buttons;

/**
 * Provides a panel with detail information about an Exchange instance.
 */
public class ExchangeDetailPanel extends AbstractBasePanel<Exchange> {

	@SpringBean
	private EditExchangeBeanService editExchangeBeanService;
	
	@SpringBean
	private EditExchangeServiceBeanService editExchangeServiceBeanService;
	
    private WindsorModalWindowPanel modalPanel;
    private Form<Exchange> form;

    public ExchangeDetailPanel(String cid, IModel<Exchange> model) {
        super(cid, model);

        add(modalPanel = new WindsorModalWindowPanel("modal"));

        form = new Form<>("form", model);
        add(form);

        form.add(new Label("name", ExchangeModels.bindName(model)));
        form.add(new AddButton("add", Model.of(""), Buttons.Type.Default,
                        (t, f) -> new AddWithContextEvent<>(t, model.getObject(), ExchangeService.class)));
        form.add(new EditButton("edit", true));

        form.add(new ConfirmationButton("delete",
                modalPanel,
                Icons.ICON_DELETE,
                GenericModels.MODEL_EMPTY,
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_CONFIRM_DELETE_EXCHANGE),
                bid -> new DeleteButton(bid,
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_YES),
                        Icons.ICON_SELECT,
                        f -> model.getObject())
                .setDefaultFormProcessing(false)));

        form.add(new ServiceDataTable("table", model));
    }

    @OnEvent(types = EditExchangeBean.class)
    public void handleEditExchangeBeanSaveEvent(SaveEvent<EditExchangeBean> event) {
    	modalPanel.getModal().close(event.getTarget());
    	event.getTarget().add(form);
    }
    
    @OnEvent(types = ExchangeService.class)
    public void handleDeleteExchangeServiceEvent(DeleteEvent<ExchangeService> event) {
    	event.getTarget().add(form);
    }
    
    @OnEvent(types = EditExchangeServiceBean.class)
    public void handleEditExchangeServiceBeanSaveEvent(SaveEvent<EditExchangeServiceBean> event) {
    	modalPanel.getModal().close(event.getTarget());
    	event.getTarget().add(form);
    }
    
    @OnEvent(types = Exchange.class)
    public void handleEditExchangeEvent(final EditEvent<Exchange> event) {
        WindsorModal m = modalPanel.getModal();
        m.setContentPanel(new ExchangeFormPanel(m.getContentId(),
                Model.of(editExchangeBeanService.toBean(event.getPayload()))));
        m.show(event.getTarget());
    }

    @OnEvent(types = ExchangeService.class)
    public void handleEditExchangeServiceEvent(final EditEvent<ExchangeService> event) {
        WindsorModal m = modalPanel.getModal();
        EditExchangeServiceBean bean = editExchangeServiceBeanService.toBean(event.getPayload());
        m.setContentPanel(new ServiceFormPanel(m.getContentId(), Model.of(bean)));
        m.show(event.getTarget());
    }
    
    @OnEvent(types = {com.windsor.node.domain.entity.ExchangeService.class, Exchange.class})
    public void handleAddExchangeServiceEvent(AddWithContextEvent<Exchange> event) {
        WindsorModal m = modalPanel.getModal();
        m.setContentPanel(new ServiceFormPanel(m.getContentId(),
                Model.of(new EditExchangeServiceBean(event.getPayload().getId()))));
        m.show(event.getTarget());
    }
    
}
