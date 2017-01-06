package com.windsor.node.web.content.exchange;

import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.form.CheckBox;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.markup.html.form.TextField;
import org.apache.wicket.markup.html.panel.Panel;
import org.apache.wicket.model.IModel;
import org.apache.wicket.spring.injection.annot.SpringBean;

import com.windsor.node.domain.edit.EditServiceArgumentBean;
import com.windsor.node.domain.entity.Argument;
import com.windsor.node.service.ArgumentService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.select2.ArgumentChoiceProvider;
import com.windsor.node.web.model.lazy.EditServiceArgumentBeanModels;
import com.windsor.stack.web.wicket.behavior.VisibleModelBehavior;
import com.windsor.stack.web.wicket.markup.html.form.RequirableFormGroup;
import com.windsor.stack.web.wicket.markup.html.form.SaveOnChangeBehavior;
import com.windsor.stack.web.wicket.markup.html.form.select2.WindsorSelect2Choice;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import com.windsor.stack.web.wicket.model.LDModel;

import de.agilecoders.wicket.core.markup.html.bootstrap.form.InputBehavior;

public class ServiceParameterFormPanel extends Panel {

    @SpringBean
    private ArgumentService argumentService;

    public ServiceParameterFormPanel(String id, IModel<EditServiceArgumentBean> model) {
        super(id, model);

        Form<EditServiceArgumentBean> form = new Form<>("form", model);
        add(form);

        form.add(new RequirableFormGroup("nameGroup")
                .add(new TextField<>("field", EditServiceArgumentBeanModels.bindValue(model))
                        .setLabel(EditServiceArgumentBeanModels.bindKey(model))
                        .add(new InputBehavior())
                        .add(new VisibleModelBehavior(new LDModel<>(() -> !model.getObject().isUseGlobalArgument())))));

        form.add(new RequirableFormGroup("globalFieldGroup")
                .add(new WindsorSelect2Choice<Argument>("field",
                        EditServiceArgumentBeanModels.bindArgument(model),
                        new ArgumentChoiceProvider(argumentService))
                        .width("100%"))
                        .add(new VisibleModelBehavior(EditServiceArgumentBeanModels.bindGlobal(model))));

        form.add(new RequirableFormGroup("globalGroup")
                .add(new Label("label", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SERVICE_USE_GLOBAL)))
                .add(new CheckBox("field", EditServiceArgumentBeanModels.bindGlobal(model))
                .add(new SaveOnChangeBehavior() {

                    @Override
                    protected void onUpdate(AjaxRequestTarget target) {
                        target.add(form);
                    }

                })));

    }

}

