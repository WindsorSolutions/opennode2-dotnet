package com.windsor.node.web.content.schedule;

import com.windsor.node.domain.edit.EditScheduleBean;
import com.windsor.node.domain.entity.ScheduleFrequencyType;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.app.NodeWebConstants;
import com.windsor.node.web.component.select2.ScheduleFrequencyTypeChoiceProvider;
import com.windsor.node.web.model.LDResourceModel;
import com.windsor.node.web.model.lazy.EditScheduleBeanModels;
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
import de.agilecoders.wicket.extensions.markup.html.bootstrap.form.datetime.DatetimePicker;
import org.apache.wicket.Component;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.form.CheckBox;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.markup.html.form.NumberTextField;
import org.apache.wicket.markup.html.form.TextField;
import org.apache.wicket.model.IModel;

import java.util.Arrays;

/**
 * Provides a form for editing Schedule instances.
 */
public class ScheduleFormPanel extends ModalizablePanel<EditScheduleBean> {

    private Form<EditScheduleBean> form;

    public ScheduleFormPanel(String cid, IModel<EditScheduleBean> model) {
        super(cid, model);

        form = new ValidationForm<>("form", model);
        add(form);

        form.add(new RequirableFormGroup("nameGroup")
                .add(new TextField<>("field", EditScheduleBeanModels.bindName(model))
                        .setRequired(true)
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_NAME))
                        .add(new InputBehavior())));

        form.add(new RequirableFormGroup("activeGroup")
                .add(new CheckBox("field", EditScheduleBeanModels.bindActive(getPanelModel())))
                .add(new Label("label", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ACTIVE))));

        form.add(new RequirableFormGroup("startGroup")
                .add(new DatetimePicker("field", EditScheduleBeanModels.bindStart(model), NodeWebConstants.SCHEDULE_DATE_TIME_FORMAT)
                        .setRequired(true)
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SCHEDULE_START))));

        form.add(new RequirableFormGroup("endGroup")
                .add(new DatetimePicker("field", EditScheduleBeanModels.bindEnd(getPanelModel()), NodeWebConstants.SCHEDULE_DATE_TIME_FORMAT)
                        .setRequired(true)
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SCHEDULE_END))));

        form.add(new RequirableFormGroup("frequencyGroup")
                .add(new NumberTextField<Integer>("field", EditScheduleBeanModels.bindFrequency(getModel()))
                        .setRequired(true)
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SCHEDULE_FREQUENCY))
                        .add(new InputBehavior())));

        form.add(new RequirableFormGroup("intervalGroup")
                .add(new WindsorSelect2Choice<ScheduleFrequencyType>("field", EditScheduleBeanModels.bindFrequencyType(getPanelModel()),
                        new ScheduleFrequencyTypeChoiceProvider())
                        .width("100%")
                        .setRequired(true)
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SCHEDULE_INTERVAL))));

        form.add(new SourceFormPanel("dataSourceForm", getPanelModel()));

        form.add(new TargetFormPanel("targetForm", getPanelModel()));
    }

    @Override
    public IModel<String> getModalTitleModel() {
        return new LDResourceModel<>(() -> getModelObject().getId() == null
                ? NodeResourceModelKeys.TITLE_ADD_SCHEDULE
                : NodeResourceModelKeys.TITLE_EDIT_SCHEDULE);
    }

    @Override
    public Component getFooterPanel() {
        return new ButtonsPanel(WindsorBaseModal.getFooterId(), id ->
            Arrays.asList(new SaveButton(id, form), new CancelButton(id)));
    }

}
