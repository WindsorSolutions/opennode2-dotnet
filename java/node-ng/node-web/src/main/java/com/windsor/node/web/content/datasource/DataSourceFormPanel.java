package com.windsor.node.web.content.datasource;

import com.windsor.node.domain.DataSourceTestResult;
import com.windsor.node.domain.entity.DataSource;
import com.windsor.node.domain.entity.DataSourceProvider;
import com.windsor.node.service.DataSourceService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.button.TestButton;
import com.windsor.node.web.component.select2.DataSourceProviderChoiceProvider;
import com.windsor.node.web.event.TestEvent;
import com.windsor.node.web.model.LDResourceModel;
import com.windsor.node.web.model.lazy.DataSourceModels;
import com.windsor.stack.web.wicket.component.feedback.WindsorFeedbackPanel;
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
import org.apache.wicket.model.Model;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.wicketstuff.event.annotation.OnEvent;

import java.util.Arrays;

/**
 * Provides a form for editing DataSource instances.
 */
public class DataSourceFormPanel extends ModalizablePanel<DataSource> {

    @SpringBean
    private DataSourceService service;

    private Form<DataSource> form;
    private Component feedback;

    public DataSourceFormPanel(final String cid, IModel<DataSource> model) {
        super(cid, model);

        feedback = new WindsorFeedbackPanel("feedback");
        add(feedback);

        form = new ValidationForm<>("form", model);
        add(form);

        form.add(new RequirableFormGroup("nameGroup")
                .add(new TextField<>("field", DataSourceModels.bindName(getModel()))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_NAME))
                        .setRequired(true)
                        .add(new InputBehavior())));
        form.add(new RequirableFormGroup("providerGroup")
                .add(new WindsorSelect2Choice<DataSourceProvider>("field", DataSourceModels.bindProvider(getModel()),
                        new DataSourceProviderChoiceProvider())
                        .setRequired(true)
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PROVIDER))));
        form.add(new RequirableFormGroup("connectionGroup", Model.of("Connection Information"),
                Model.of("Example: jdbc:oracle:thin:CA_NODE_FLOW/password@ora11g-win.windsor.com:1521:ORA11G"))
                .add(new TextField<>("field", DataSourceModels.bindConnection(getModel()))
                        .setRequired(true)
                        .setLabel(Model.of("Connection Information"))
                        .add(new InputBehavior())));
        form.add(new TestButton("test", Model.of("Test Connection")));
    }

    @Override
    public IModel<String> getModalTitleModel() {
        return new LDResourceModel<>(() -> getModelObject().getId() == null
                ? NodeResourceModelKeys.TITLE_ADD_DATA_SOURCE
                : NodeResourceModelKeys.TITLE_EDIT_DATA_SOURCE);
    }

    @Override
    public Component getFooterPanel() {
        return new ButtonsPanel(WindsorBaseModal.getFooterId(), id ->
            Arrays.asList(new SaveButton(id, form), new CancelButton(id)));
    }

    @OnEvent(types = DataSource.class, stop = true)
    public void handleTestEvent(final TestEvent<DataSource> event) {
        DataSourceTestResult result = service.test(event.getPayload());
        if (result.isSuccess()) {
            success(result.getMessage());
        } else {
            error(result.getMessage());
        }
        event.getTarget().add(feedback);
    }

}
