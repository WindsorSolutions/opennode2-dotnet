package com.windsor.node.web.content.schedule;

import java.util.List;

import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.ajax.form.AjaxFormComponentUpdatingBehavior;
import org.apache.wicket.markup.html.WebMarkupContainer;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.markup.html.form.TextField;
import org.apache.wicket.markup.html.list.ListItem;
import org.apache.wicket.markup.html.list.ListView;
import org.apache.wicket.markup.html.panel.Panel;
import org.apache.wicket.model.IModel;
import org.apache.wicket.spring.injection.annot.SpringBean;

import com.windsor.node.domain.edit.EditScheduleArgumentBean;
import com.windsor.node.domain.edit.EditScheduleBean;
import com.windsor.node.service.ExchangeServiceService;
import com.windsor.node.service.converter.EditScheduleBeanService;
import com.windsor.node.web.component.select2.ExchangeServiceChoiceProvider;
import com.windsor.node.web.model.lazy.EditScheduleArgumentBeanModels;
import com.windsor.node.web.model.lazy.EditScheduleBeanModels;
import com.windsor.stack.web.wicket.behavior.RequiredModelBehavior;
import com.windsor.stack.web.wicket.behavior.VisibleModelBehavior;
import com.windsor.stack.web.wicket.markup.html.form.RequirableFormGroup;
import com.windsor.stack.web.wicket.markup.html.form.ValidationForm;
import com.windsor.stack.web.wicket.markup.html.form.select2.WindsorSelect2Choice;
import com.windsor.stack.web.wicket.model.EntityModel;
import com.windsor.stack.web.wicket.model.LDModel;

import de.agilecoders.wicket.core.markup.html.bootstrap.form.InputBehavior;

/**
 * Provides a form for the LocalService data source.
 */
public class LocalServiceFormPanel extends Panel {

    @SpringBean
    private com.windsor.node.service.ExchangeService exchangeService;

    @SpringBean
    private ExchangeServiceService exchangeServiceService;

    @SpringBean
    private EditScheduleBeanService editScheduleBeanService;

    public LocalServiceFormPanel(String cid, IModel<EditScheduleBean> model) {
        super(cid, model);

        Form<EditScheduleBean> form = new ValidationForm<>("form", model);
        add(form);

        form.add(new RequirableFormGroup("serviceSourceGroup")
                .add(new WindsorSelect2Choice<>("field", EditScheduleBeanModels.bindExchangeService(model),
                        new ExchangeServiceChoiceProvider(exchangeServiceService,
                                new EntityModel<>(exchangeService, model.getObject().getExchangeId())))
                        .width("100%")
                        .setRequired(true)
                        .add(new AjaxFormComponentUpdatingBehavior("onchange") {

                            @Override
                            protected void onUpdate(AjaxRequestTarget ajaxRequestTarget) {
                                editScheduleBeanService.refreshBeanArguments(model.getObject());
                                ajaxRequestTarget.add(form);
                            }

                        })));

        IModel<List<EditScheduleArgumentBean>> argumentsModel = EditScheduleBeanModels.bindArguments(model);
        WebMarkupContainer argumentsPanel = new WebMarkupContainer("argumentsPanel");
        argumentsPanel.setOutputMarkupPlaceholderTag(true);
        argumentsPanel.add(new VisibleModelBehavior(new LDModel<>(() -> 
        		argumentsModel.getObject() != null && (!argumentsModel.getObject().isEmpty()))));
        form.add(argumentsPanel);
        argumentsPanel.add(new ListView<EditScheduleArgumentBean>("arguments", argumentsModel) {

            @Override
            protected void populateItem(ListItem<EditScheduleArgumentBean> listItem) {
                IModel<EditScheduleArgumentBean> model = listItem.getModel();
                listItem.add(new RequirableFormGroup("argumentGroup")
                        .add(new TextField<>("field", EditScheduleArgumentBeanModels.bindValue(model))
                                .setLabel(EditScheduleArgumentBeanModels.bindKey(model))
                                .add(new InputBehavior())
                                .add(new RequiredModelBehavior(EditScheduleArgumentBeanModels.bindRequired(model)))));

            }

        });

    }

}
