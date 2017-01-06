package com.windsor.node.web.content.profile;

import java.util.Arrays;

import org.apache.wicket.Component;
import org.apache.wicket.markup.html.WebMarkupContainer;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.markup.html.form.FormComponent;
import org.apache.wicket.markup.html.form.PasswordTextField;
import org.apache.wicket.markup.html.form.TextField;
import org.apache.wicket.markup.html.form.validation.EqualPasswordInputValidator;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.wicketstuff.event.annotation.OnEvent;

import com.windsor.node.domain.edit.EditPasswordBean;
import com.windsor.node.service.converter.EditPasswordBeanService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.model.LDResourceModel;
import com.windsor.node.web.model.lazy.EditPasswordBeanModels;
import com.windsor.node.web.validator.PasswordValidator;
import com.windsor.node.web.validator.UniqueUsernameValidator;
import com.windsor.stack.web.wicket.component.feedback.WindsorFeedbackPanel;
import com.windsor.stack.web.wicket.component.modal.WindsorBaseModal;
import com.windsor.stack.web.wicket.component.panel.ButtonsPanel;
import com.windsor.stack.web.wicket.component.panel.modal.ModalizablePanel;
import com.windsor.stack.web.wicket.event.RenderFeedbackPanelEvent;
import com.windsor.stack.web.wicket.markup.html.form.RequirableFormGroup;
import com.windsor.stack.web.wicket.markup.html.form.ValidationForm;
import com.windsor.stack.web.wicket.markup.html.form.button.CancelButton;
import com.windsor.stack.web.wicket.markup.html.form.button.SaveButton;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

import de.agilecoders.wicket.core.markup.html.bootstrap.form.InputBehavior;

public class PasswordChangeFormPanel extends ModalizablePanel<EditPasswordBean> {

	@SpringBean
	private EditPasswordBeanService editPasswordBeanService;
	
    private Form<EditPasswordBean> form;
    private Component feedback;

    public PasswordChangeFormPanel(String id, IModel<EditPasswordBean> model, boolean promptForOldPassword) {
        super(id, model);
        boolean newUser = model.getObject().getNaasAccount() == null;
        
        feedback = new WindsorFeedbackPanel("feedback");
        add(feedback);

        form = new ValidationForm<>("form", model);
        add(form);

        FormComponent<String> emailField = new TextField<>("field",
                EditPasswordBeanModels.bindNaasAccount(model))
                .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_EMAIL))
                .setRequired(true);
        emailField.add(new InputBehavior());
        emailField.add(new UniqueUsernameValidator());
        WebMarkupContainer emailGroup = new RequirableFormGroup("emailGroup");
        emailGroup.setVisible(newUser);
        form.add(emailGroup.add(emailField));

        FormComponent<String> oldPasswordField = new PasswordTextField("field",
                EditPasswordBeanModels.bindOldPassword(model))
                .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_OLD_PASSWORD))
                .setRequired(true);
        oldPasswordField.add(new InputBehavior());
        WebMarkupContainer oldPasswordGroup = new RequirableFormGroup("oldPasswordGroup");
        oldPasswordGroup.setVisible((!newUser) && promptForOldPassword);
        form.add(oldPasswordGroup.add(oldPasswordField));

        FormComponent<String> newPasswordField = new PasswordTextField("field",
                EditPasswordBeanModels.bindNewPassword(model))
                .setLabel(new LDResourceModel<>(() -> getModelObject().getId() == null
                    ? NodeResourceModelKeys.LABEL_PASSWORD
                    : NodeResourceModelKeys.LABEL_NEW_PASSWORD))
                .setRequired(true);
        newPasswordField.add(new InputBehavior());
        newPasswordField.add(new PasswordValidator());
        form.add(new RequirableFormGroup("newPasswordGroup").add(newPasswordField));

        FormComponent<String> repeatedPasswordField = new PasswordTextField("field",
                Model.of())
                .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_CONFIRM))
                .setRequired(true);
        repeatedPasswordField.add(new InputBehavior());
        form.add(new RequirableFormGroup("repeatedPasswordGroup").add(repeatedPasswordField));

        form.add(new EqualPasswordInputValidator(newPasswordField, repeatedPasswordField));
    }

    @OnEvent
    public void handleErrorFeedbackEvent(final RenderFeedbackPanelEvent event) {
        event.getTarget().add(feedback);
    }
    
    @Override
    public IModel<String> getModalTitleModel() {
        return new LDResourceModel<>(() -> getModelObject().getId() == null
                ? NodeResourceModelKeys.LABEL_NEW_ACCOUNT
                : NodeResourceModelKeys.LABEL_CHANGE_PASSWORD);
    }

    @Override
    public Component getFooterPanel() {
        return new ButtonsPanel(WindsorBaseModal.getFooterId(), id ->
            Arrays.asList(new SaveButton(id, form), new CancelButton(id)));
    }

}
