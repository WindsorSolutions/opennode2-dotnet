package com.windsor.node.web.content.account;

import org.apache.wicket.Component;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.basic.MultiLineLabel;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.model.IModel;
import org.wicketstuff.event.annotation.OnEvent;

import com.windsor.node.domain.edit.EditPasswordBean;
import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.search.AccountSearchCriteria;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.stack.web.wicket.component.feedback.WindsorFeedbackPanel;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import com.windsor.stack.web.wicket.event.RenderFeedbackPanelEvent;
import com.windsor.stack.web.wicket.markup.html.form.button.AddButton;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

/**
 * Provides a side panel.
 */
public class AccountListSidePanel extends AbstractBasePanel<AccountSearchCriteria> {

	private Component feedback;
	
    public AccountListSidePanel(String id, IModel<AccountSearchCriteria> model, IModel<String> contentModel) {
        super(id, model);

        /*
         * Feedback.
         */
        feedback = new WindsorFeedbackPanel("feedback");
        add(feedback);
        
        add(new Label("actions", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ACTIONS)));

        Form<?> actionForm = new Form<>("actionForm", model);
        add(actionForm);

        actionForm.add(new AddButton("add",
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ASSOCIATE_EXISTING_NAAS_USER),
                Account.class));
        actionForm.add(new AddButton("new",
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_NEW_USER),
                EditPasswordBean.class));

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