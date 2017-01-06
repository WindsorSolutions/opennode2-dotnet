package com.windsor.node.web.content.schedule;

import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.markup.html.WebMarkupContainer;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.markup.html.form.TextField;
import org.apache.wicket.markup.html.panel.GenericPanel;
import org.apache.wicket.model.IModel;
import org.apache.wicket.spring.injection.annot.SpringBean;

import com.windsor.node.domain.edit.EditScheduleBean;
import com.windsor.node.domain.entity.Partner;
import com.windsor.node.domain.entity.ScheduleTargetType;
import com.windsor.node.service.PartnerService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.radio.ScheduleTargetTypeRadioGroup;
import com.windsor.node.web.component.select2.PartnerChoiceProvider;
import com.windsor.node.web.model.lazy.EditScheduleBeanModels;
import com.windsor.stack.web.wicket.behavior.VisibleModelBehavior;
import com.windsor.stack.web.wicket.markup.html.form.RequirableFormGroup;
import com.windsor.stack.web.wicket.markup.html.form.ValidationForm;
import com.windsor.stack.web.wicket.markup.html.form.select2.WindsorSelect2Choice;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import com.windsor.stack.web.wicket.model.LDModel;

import de.agilecoders.wicket.core.markup.html.bootstrap.form.InputBehavior;
import de.agilecoders.wicket.core.markup.html.bootstrap.form.radio.BootstrapRadioGroup;

/**
 * Provides a form for editing Schedule datatarget data.
 */
public class TargetFormPanel extends GenericPanel<EditScheduleBean> {

    @SpringBean
    private PartnerService partnerService;

    public TargetFormPanel(String cid, IModel<EditScheduleBean> model) {
        super(cid, model);

        /*
         * Form
         */
        Form<EditScheduleBean> form = new ValidationForm<>("form", model);
        add(form);

        IModel<ScheduleTargetType> targetTypeModel = EditScheduleBeanModels.bindTargetType(model);

        /*
         * Target type.
         */
        form.add(new Label("targetLabel",
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SCHEDULE_TARGET)));
        form.add(new ScheduleTargetTypeRadioGroup("targetType", targetTypeModel,
                        new BootstrapRadioGroup.ISelectionChangeHandler<ScheduleTargetType>() {

                            @Override
                            public void onSelectionChanged(AjaxRequestTarget target, ScheduleTargetType targetType) {
                                target.add(form);
                            }

                        }));
        form.add(new Label("targetTypeHelp", EditScheduleBeanModels.bindTargetTypeHelpText(model)));

        /*
         * Partner
         */
        form.add(new WebMarkupContainer("partnerContainer")
                .add(new RequirableFormGroup("partnerGroup")
                    .add(new WindsorSelect2Choice<Partner>("field",
                            EditScheduleBeanModels.bindTargetPartner(model),
                            new PartnerChoiceProvider(partnerService))
                            .width("100%")
                            .setRequired(true)))
                .add(new TargetTypeVisibleBehavior(targetTypeModel, ScheduleTargetType.PARTNER)));

        /*
         * Email
         */
        form.add(new WebMarkupContainer("emailContainer")
                .add(new RequirableFormGroup("emailGroup")
                    .add(new TextField<>("field", EditScheduleBeanModels.bindTargetEmail(model))
                            .setRequired(true)
                            .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_EMAIL))
                            .add(new InputBehavior())))
                .add(new TargetTypeVisibleBehavior(targetTypeModel, ScheduleTargetType.EMAIL)));

        /*
         * File
         */
        form.add(new WebMarkupContainer("fileContainer")
                .add(new RequirableFormGroup("filePathGroup")
                    .add(new TextField<>("field", EditScheduleBeanModels.bindTargetPath(model))
                            .setRequired(true)
                            .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SCHEDULE_SOURCE_PATH))
                            .add(new InputBehavior())))
                .add(new TargetTypeVisibleBehavior(targetTypeModel, ScheduleTargetType.FILE)));

    }

    private class TargetTypeVisibleBehavior extends VisibleModelBehavior {

        public TargetTypeVisibleBehavior(IModel<ScheduleTargetType> model, ScheduleTargetType scheduleTargetType) {
            super(new LDModel<>(() -> scheduleTargetType.equals(model.getObject())));
        }

    }

}
