package com.windsor.node.web.content.exchange;

import java.util.Arrays;
import java.util.List;

import org.apache.wicket.Component;
import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.markup.html.WebMarkupContainer;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.form.CheckBox;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.markup.html.form.TextField;
import org.apache.wicket.markup.html.list.ListItem;
import org.apache.wicket.markup.html.list.ListView;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.domain.edit.EditExchangeServiceBean;
import com.windsor.node.domain.edit.EditServiceArgumentBean;
import com.windsor.node.domain.entity.DataSource;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.ServiceType;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.service.DataSourceService;
import com.windsor.node.service.ExchangeServiceService;
import com.windsor.node.service.PluginService;
import com.windsor.node.service.converter.EditExchangeServiceBeanService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.select2.DataSourceChoiceProvider;
import com.windsor.node.web.component.select2.PluginServiceImplementorDescriptorChoiceProvider;
import com.windsor.node.web.component.select2.ServiceTypeChoiceProvider;
import com.windsor.node.web.model.PluginModel;
import com.windsor.node.web.model.PluginServiceImplementorDescriptorListModel;
import com.windsor.node.web.model.lazy.EditExchangeServiceBeanModels;
import com.windsor.stack.web.wicket.behavior.VisibleModelBehavior;
import com.windsor.stack.web.wicket.component.modal.WindsorBaseModal;
import com.windsor.stack.web.wicket.component.panel.ButtonsPanel;
import com.windsor.stack.web.wicket.component.panel.modal.ModalizablePanel;
import com.windsor.stack.web.wicket.markup.html.form.RequirableFormGroup;
import com.windsor.stack.web.wicket.markup.html.form.SaveOnChangeBehavior;
import com.windsor.stack.web.wicket.markup.html.form.ValidationForm;
import com.windsor.stack.web.wicket.markup.html.form.button.CancelButton;
import com.windsor.stack.web.wicket.markup.html.form.button.SaveButton;
import com.windsor.stack.web.wicket.markup.html.form.select2.WindsorSelect2Choice;
import com.windsor.stack.web.wicket.model.EntityModel;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import com.windsor.stack.web.wicket.model.LDModel;

import de.agilecoders.wicket.core.markup.html.bootstrap.form.FormGroup;
import de.agilecoders.wicket.core.markup.html.bootstrap.form.InputBehavior;

public class ServiceFormPanel extends ModalizablePanel<EditExchangeServiceBean> {

    static final Logger LOGGER = LoggerFactory.getLogger(ServiceFormPanel.class);

    @SpringBean
    private com.windsor.node.service.ExchangeService exchangeService;

    @SpringBean
    private ExchangeServiceService exchangeServiceService;

    @SpringBean
    private DataSourceService dataSourceService;

    @SpringBean
    private PluginService pluginService;

    @SpringBean
    private EditExchangeServiceBeanService editExchangeServiceBeanService;

    private Form<EditExchangeServiceBean> form;

    public ServiceFormPanel(String id, IModel<EditExchangeServiceBean> model) {
        super(id, model);

        /*
         * Models.
         */
        IModel<Exchange> exchangeModel = new EntityModel<>(exchangeService, model.getObject().getExchangeId());
        IModel<List<PluginServiceImplementorDescriptor>> pluginListModel = new PluginServiceImplementorDescriptorListModel(exchangeModel);
        IModel<BaseWnosPlugin> pluginModel = new PluginModel(EditExchangeServiceBeanModels.bindImplementorDescriptorClassname(model), exchangeModel);
        IModel<List<ServiceType>> serviceTypeListModel = new LDModel<>(() -> pluginService.transform(pluginModel.getObject().getSupportedPluginTypes()));

        /*
         * Form.
         */
        form = new ValidationForm<>("form", model);
        add(form);

        /*
         * Name.
         */
        form.add(new RequirableFormGroup("nameGroup")
                .add(new TextField<>("field", EditExchangeServiceBeanModels.bindName(model))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_NAME))
                        .setRequired(true)
                        .add(new InputBehavior())));

        /*
         * Whether active.
         */
        form.add(new FormGroup("activeGroup")
                .add(new CheckBox("field", EditExchangeServiceBeanModels.bindActive(model)))
                .add(new Label("label", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ACTIVE)))
                .add(new Label("labelActive", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SERVUCE_ACTIVE))));

        /*
         * Plugin type.
         */
        Component typeField = new WindsorSelect2Choice<>("field", EditExchangeServiceBeanModels.bindType(model),
                new ServiceTypeChoiceProvider(serviceTypeListModel))
                .setRequired(true)
                .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_TYPE))
                .setOutputMarkupId(true);
        form.add(new RequirableFormGroup("typeGroup").add(typeField));

        /*
         * Parameters.
         */
        IModel<List<EditServiceArgumentBean>> m = EditExchangeServiceBeanModels.bindArguments(model);
        Component parameterPanel = new WebMarkupContainer("parameterPanel", m)
	        .add(new ListView<EditServiceArgumentBean>("parameters", m) {
	
	            @Override
	            protected void populateItem(ListItem<EditServiceArgumentBean> listItem) {
	                listItem.add(new ServiceParameterFormPanel("parameter", listItem.getModel()));
	            }
	
	        }).setOutputMarkupPlaceholderTag(true)
	        .add(new VisibleModelBehavior(new LDModel<>(() -> m.getObject() != null && (!m.getObject().isEmpty()))));
        form.add(parameterPanel);

        /*
         * Data source.
         */
        form.add(new RequirableFormGroup("dataSourceGroup")
                .add(new WindsorSelect2Choice<DataSource>("field", EditExchangeServiceBeanModels.bindDataSource(model),
                        new DataSourceChoiceProvider(dataSourceService))
                        .width("100%")
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_DATA_SOURCE))));

        /*
         * Implementor info.
         */
        Component labelImplementorDescription = new Label("labelImplementor",
                    EditExchangeServiceBeanModels.bindImplementorDescriptorDescription(model))
                .setOutputMarkupId(true);
        form.add(new RequirableFormGroup("implementorGroup")
                .add(labelImplementorDescription)
                .add(new WindsorSelect2Choice<>("field",
                        EditExchangeServiceBeanModels.bindImplementorDescriptor(model),
                        new PluginServiceImplementorDescriptorChoiceProvider(pluginListModel))
                        .width("100%")
                        .setRequired(true)
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_IMPLEMENTOR))
                .add(new SaveOnChangeBehavior() {

                    @Override
                    protected void onUpdate(AjaxRequestTarget target) {
                        editExchangeServiceBeanService.updateArguments(model.getObject());
                        target.add(typeField, parameterPanel);
                    }

                })));
    }

    @Override
    public IModel<String> getModalTitleModel() {
        return Model.of("Edit Exchange Service");
    }

    @Override
    public Component getFooterPanel() {
        return new ButtonsPanel(WindsorBaseModal.getFooterId(), id ->
            Arrays.asList(new SaveButton(id, form), new CancelButton(id)));
    }

}

