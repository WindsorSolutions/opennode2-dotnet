package com.windsor.node.web.content.schedule;

import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.markup.html.form.TextField;
import org.apache.wicket.markup.html.panel.Panel;
import org.apache.wicket.model.IModel;

import com.windsor.node.domain.edit.EditScheduleBean;
import com.windsor.node.domain.entity.ScheduleSourceType;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.radio.ScheduleSourceTypeRadioGroup;
import com.windsor.node.web.model.lazy.EditScheduleBeanModels;
import com.windsor.stack.web.wicket.behavior.VisibleModelBehavior;
import com.windsor.stack.web.wicket.markup.html.form.RequirableFormGroup;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import com.windsor.stack.web.wicket.model.LDModel;

import de.agilecoders.wicket.core.markup.html.bootstrap.form.InputBehavior;
import de.agilecoders.wicket.core.markup.html.bootstrap.form.radio.BootstrapRadioGroup;

/**
 * Provides a form with details about the source.
 */
public class SourceFormPanel extends Panel {

    public SourceFormPanel(String cid, IModel<EditScheduleBean> model) {
        super(cid, model);

        Form<EditScheduleBean> form = new Form<>("form", model);
        add(form);

        form.add(new Label("dataSourceLabel",
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SCHEDULE_DATA_SOURCE)));
        form.add(new ScheduleSourceTypeRadioGroup("sourceTypeGroup",
                        EditScheduleBeanModels.bindSourceType(model),
                        new BootstrapRadioGroup.ISelectionChangeHandler<ScheduleSourceType>() {

                            @Override
                            public void onSelectionChanged(AjaxRequestTarget target, ScheduleSourceType sourceType) {
                                target.add(form);
                            }

                        }));

        form.add(new Label("sourceTypeHelp", EditScheduleBeanModels.bindSourceTypeHelpText(model)));

        form.add(new LocalServiceFormPanel("localServicePanel", model)
                .add(new VisibleModelBehavior(new LDModel<>(() -> ScheduleSourceType.LOCAL_SERVICE.equals(model.getObject().getSourceType())))));

        form.add(new RequirableFormGroup("filePathGroup")
                .add(new TextField<>("field", EditScheduleBeanModels.bindSourcePath(model))
                        .setRequired(true)
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SCHEDULE_SOURCE_PATH))
                        .add(new InputBehavior()))
                        .add(new VisibleModelBehavior(new LDModel<>(() -> ScheduleSourceType.FILE.equals(model.getObject().getSourceType())))));
    }
}
