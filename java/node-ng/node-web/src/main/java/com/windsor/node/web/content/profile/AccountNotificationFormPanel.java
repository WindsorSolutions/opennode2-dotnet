package com.windsor.node.web.content.profile;

import java.util.Arrays;

import org.apache.wicket.Component;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.form.CheckBox;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.markup.html.list.ListItem;
import org.apache.wicket.markup.html.list.ListView;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.util.ListModel;
import org.wicketstuff.event.annotation.OnEvent;

import com.windsor.node.domain.edit.EditNotificationBean;
import com.windsor.node.domain.edit.EditNotificationsBean;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.button.ToggleButton;
import com.windsor.node.web.event.ToggleEvent;
import com.windsor.node.web.model.lazy.EditNotificationBeanModels;
import com.windsor.stack.web.wicket.component.modal.WindsorBaseModal;
import com.windsor.stack.web.wicket.component.panel.ButtonsPanel;
import com.windsor.stack.web.wicket.component.panel.modal.ModalizablePanel;
import com.windsor.stack.web.wicket.markup.html.form.button.CancelButton;
import com.windsor.stack.web.wicket.markup.html.form.button.SaveButton;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

public class AccountNotificationFormPanel extends ModalizablePanel<EditNotificationsBean> {

    private Form<EditNotificationsBean> form;

    public AccountNotificationFormPanel(String id, IModel<EditNotificationsBean> model) {
        super(id, model);

        form = new Form<>("form", model);
        add(form);

        form.add(new ListView<EditNotificationBean>("exchanges", new ListModel<>(model.getObject().getNotifications())) {

            @Override
            protected void populateItem(ListItem<EditNotificationBean> item) {
                IModel<EditNotificationBean> model = item.getModel();
                item.add(new Label("name", EditNotificationBeanModels.bindExchangeName(model)));
                item.add(new CheckBox("solicit", EditNotificationBeanModels.bindSolicit(model))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SOLICIT))
                        .setOutputMarkupId(true));
                item.add(new CheckBox("query", EditNotificationBeanModels.bindQuery(model))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_QUERY))
                        .setOutputMarkupId(true));
                item.add(new CheckBox("submit", EditNotificationBeanModels.bindSubmit(model))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SUBMIT))
                        .setOutputMarkupId(true));
                item.add(new CheckBox("notify", EditNotificationBeanModels.bindNotify(model))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_NOTIFY))
                        .setOutputMarkupId(true));
                item.add(new CheckBox("schedule", EditNotificationBeanModels.bindSchedule(model))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SCHEDULE))
                        .setOutputMarkupId(true));
                item.add(new CheckBox("download", EditNotificationBeanModels.bindDownload(model))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_DOWNLOAD))
                        .setOutputMarkupId(true));
                item.add(new CheckBox("execute", EditNotificationBeanModels.bindExecute(model))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_EXECUTE))
                        .setOutputMarkupId(true));
                item.add(new CheckBox("error", EditNotificationBeanModels.bindError(model))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ERROR))
                        .setOutputMarkupId(true));
                item.add(new ToggleButton("toggle", () -> item.getModelObject()));
            }

        });

    }

    @Override
    public IModel<String> getModalTitleModel() {
        return new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_EDIT_ACCOUNT_NOTIFICATIONS);
    }

    @Override
    public Component getFooterPanel() {
        return new ButtonsPanel(WindsorBaseModal.getFooterId(), id ->
            Arrays.asList(new SaveButton(id, form), new CancelButton(id)));
    }

    @OnEvent(types = EditNotificationBean.class)
    public void handleToggleEvent(ToggleEvent<EditNotificationBean> event) {
        EditNotificationBean bean = event.getPayload();
        bean.setAll(bean.isEmpty());
        event.getTarget().add(form);
    }

}
