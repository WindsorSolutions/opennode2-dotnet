package com.windsor.node.web.content.argument;

import com.windsor.node.domain.entity.Argument;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.model.LDResourceModel;
import com.windsor.node.web.model.lazy.ArgumentModels;
import com.windsor.stack.web.wicket.component.modal.WindsorBaseModal;
import com.windsor.stack.web.wicket.component.panel.ButtonsPanel;
import com.windsor.stack.web.wicket.component.panel.modal.ModalizablePanel;
import com.windsor.stack.web.wicket.markup.html.form.RequirableFormGroup;
import com.windsor.stack.web.wicket.markup.html.form.ValidationForm;
import com.windsor.stack.web.wicket.markup.html.form.button.CancelButton;
import com.windsor.stack.web.wicket.markup.html.form.button.SaveButton;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import de.agilecoders.wicket.core.markup.html.bootstrap.form.InputBehavior;
import org.apache.wicket.Component;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.markup.html.form.TextField;
import org.apache.wicket.model.IModel;

import java.util.Arrays;

/**
 * Provides a form for editing Argument instances.
 */
public class ArgumentFormPanel extends ModalizablePanel<Argument> {

    private Form<Argument> form;

    public ArgumentFormPanel(final String cid, IModel<Argument> model) {
        super(cid, model);

        form = new ValidationForm<>("form", model);
        add(form);

        form.add(new RequirableFormGroup("nameGroup")
                .add(new TextField<>("field", ArgumentModels.bindName(getModel()))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_NAME))
                        .setRequired(true)
                        .add(new InputBehavior())));
        form.add(new RequirableFormGroup("valueGroup")
                .add(new TextField<>("field", ArgumentModels.bindValue(getModel()))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_VALUE))
                        .setRequired(true)
                        .add(new InputBehavior())));
        form.add(new RequirableFormGroup("descriptionGroup")
                .add(new TextField<>("field", ArgumentModels.bindDescription(getModel()))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_DESCRIPTION))
                        .add(new InputBehavior())));

    }

    @Override
    public IModel<String> getModalTitleModel() {
        return new LDResourceModel<>(() -> getModelObject().getId() == null
                ? NodeResourceModelKeys.TITLE_ADD_ARGUMENT
                : NodeResourceModelKeys.TITLE_EDIT_ARGUMENT);
    }

    @Override
    public Component getFooterPanel() {
        return new ButtonsPanel(WindsorBaseModal.getFooterId(), id ->
            Arrays.asList(new SaveButton(id, form), new CancelButton(id)));
    }

}
