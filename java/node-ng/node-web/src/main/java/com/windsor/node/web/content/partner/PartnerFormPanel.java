package com.windsor.node.web.content.partner;

import com.windsor.node.domain.entity.Partner;
import com.windsor.node.domain.entity.PartnerVersion;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.select2.PartnerVersionChoiceProvider;
import com.windsor.node.web.model.LDResourceModel;
import com.windsor.node.web.model.lazy.PartnerModels;
import com.windsor.stack.web.wicket.component.modal.WindsorBaseModal;
import com.windsor.stack.web.wicket.component.panel.ButtonsPanel;
import com.windsor.stack.web.wicket.component.panel.modal.ModalizablePanel;
import com.windsor.stack.web.wicket.markup.html.form.RequirableFormGroup;
import com.windsor.stack.web.wicket.markup.html.form.ValidationForm;
import com.windsor.stack.web.wicket.markup.html.form.button.CancelButton;
import com.windsor.stack.web.wicket.markup.html.form.button.SaveButton;
import com.windsor.stack.web.wicket.markup.html.form.select2.WindsorSelect2Choice;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import de.agilecoders.wicket.core.markup.html.bootstrap.form.InputBehavior;
import org.apache.wicket.Component;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.markup.html.form.TextField;
import org.apache.wicket.model.IModel;

import java.util.Arrays;

/**
 * Provides a form for editing Partner instances.
 */
public class PartnerFormPanel extends ModalizablePanel<Partner> {

    private Form<Partner> form;

    public PartnerFormPanel(final String cid, IModel<Partner> model) {
        super(cid, model);

        form = new ValidationForm<>("form", model);
        add(form);

        form.add(new RequirableFormGroup("nameGroup")
                .add(new TextField<>("field", PartnerModels.bindName(getModel()))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_NAME))
                        .setRequired(true)
                        .add(new InputBehavior())));
        form.add(new RequirableFormGroup("urlGroup")
                .add(new TextField<>("field", PartnerModels.bindUrl(getModel()))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_URL))
                        .setRequired(true)
                        .add(new InputBehavior())));
        form.add(new RequirableFormGroup("versionGroup")
                .add(new WindsorSelect2Choice<PartnerVersion>("field", PartnerModels.bindVersion(getModel()),
                        new PartnerVersionChoiceProvider())
                        .setRequired(true)
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PROVIDER))));
    }

    @Override
    public Component getFooterPanel() {
        return new ButtonsPanel(WindsorBaseModal.getFooterId(), id ->
            Arrays.asList(new SaveButton(id, form), new CancelButton(id)));
    }

    @Override
    public IModel<String> getModalTitleModel() {
        return new LDResourceModel<>(() -> getModelObject().getId() == null
                ? NodeResourceModelKeys.TITLE_ADD_PARTNER
                : NodeResourceModelKeys.TITLE_EDIT_PARTNER);
    }

}
