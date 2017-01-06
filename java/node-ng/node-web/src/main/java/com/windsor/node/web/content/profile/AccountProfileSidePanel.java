package com.windsor.node.web.content.profile;

import org.apache.wicket.Component;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.basic.MultiLineLabel;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.model.IModel;
import org.wicketstuff.event.annotation.OnEvent;

import com.windsor.node.domain.entity.Account;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.button.ChangePasswordButton;
import com.windsor.stack.web.wicket.component.feedback.WindsorFeedbackPanel;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import com.windsor.stack.web.wicket.event.RenderFeedbackPanelEvent;
import com.windsor.stack.web.wicket.markup.html.form.button.EditButton;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

/**
 * Provides a side panel.
 */
public class AccountProfileSidePanel extends AbstractBasePanel<Account> {

    private Component feedback;

    public AccountProfileSidePanel(String id, IModel<Account> model, IModel<String> contentModel) {
        super(id, model);

        /*
         * Feedback.
         */
        feedback = new WindsorFeedbackPanel("feedback");
        add(feedback);

        /*
         * Password.
         */
        add(new Label("passwordHeader", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PASSWORD)));
        Form<Account> passwordForm = new Form<>("passwordForm", model);
        add(passwordForm);
        passwordForm.add(new ChangePasswordButton("changePassword"));

        /*
         * Notifications.
         */
        add(new Label("notificationsHeader", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_NOTIFICATIONS)));
        Form<Account> notificationsForm = new Form<>("notificationsForm", model);
        add(notificationsForm);
        notificationsForm.add(new EditButton("editNotifications",
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_EDIT_NOTIFICATIONS)));

        /*
         * Help.
         */
        add(new Label("title", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_HELP)));
        add(new MultiLineLabel("content", contentModel)
                .setEscapeModelStrings(false)
                .setOutputMarkupId(true));
    }

    @OnEvent
    public void refreshFeedbackPanel(RenderFeedbackPanelEvent event) {
        event.getTarget().add(feedback);
    }

}