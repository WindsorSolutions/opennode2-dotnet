package com.windsor.node.web.content.exchange;

import com.windsor.node.common.domain.PluginMetaData;
import com.windsor.node.domain.edit.EditExchangeBean;
import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.search.AccountSearchCriteria;
import com.windsor.node.service.AccountService;
import com.windsor.node.service.ExchangeService;
import com.windsor.node.service.PluginService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.select2.AccountChoiceProvider;
import com.windsor.node.web.model.LDResourceModel;
import com.windsor.node.web.model.PluginMetaDataModel;
import com.windsor.node.web.model.lazy.EditExchangeBeanModels;
import com.windsor.node.web.model.lazy.PluginMetaDataModels;
import com.windsor.node.web.validator.UniqueValidator;
import com.windsor.stack.web.wicket.component.modal.WindsorBaseModal;
import com.windsor.stack.web.wicket.component.panel.ButtonsPanel;
import com.windsor.stack.web.wicket.component.panel.modal.ModalizablePanel;
import com.windsor.stack.web.wicket.markup.html.form.RequirableFormGroup;
import com.windsor.stack.web.wicket.markup.html.form.ValidationForm;
import com.windsor.stack.web.wicket.markup.html.form.button.CancelButton;
import com.windsor.stack.web.wicket.markup.html.form.button.SaveButton;
import com.windsor.stack.web.wicket.markup.html.form.select2.WindsorSelect2Choice;
import com.windsor.stack.web.wicket.model.EntityModel;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import de.agilecoders.wicket.core.markup.html.bootstrap.form.FormGroup;
import de.agilecoders.wicket.core.markup.html.bootstrap.form.InputBehavior;
import org.apache.wicket.Component;
import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.form.CheckBox;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.markup.html.form.TextField;
import org.apache.wicket.markup.html.form.upload.FileUpload;
import org.apache.wicket.markup.html.form.upload.FileUploadField;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.util.ListModel;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.apache.wicket.util.lang.Bytes;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class ExchangeFormPanel extends ModalizablePanel<EditExchangeBean> {

    @SpringBean
    private AccountService accountService;

    @SpringBean
    private ExchangeService exchangeService;

    @SpringBean
    private PluginService pluginService;

    private Form<EditExchangeBean> form;
    private FileUploadField fileUpload;

    public ExchangeFormPanel(final String id, IModel<EditExchangeBean> model) {
        super(id, model);

        IModel<Exchange> exchangeModel = new EntityModel<>(exchangeService, model.getObject().getId());
        IModel<PluginMetaData> pluginMetaDataModel = new PluginMetaDataModel(exchangeModel);
        IModel<List<FileUpload>> fileUploadListModel = new ListModel<>(new ArrayList<>());

        form = new ValidationForm<EditExchangeBean>("form", model);
        form.setMultiPart(true);
        form.setMaxSize(Bytes.megabytes(10L));
        add(form);

        fileUpload = new FileUploadField("pluginUpload", fileUploadListModel);
        form.add(new RequirableFormGroup("pluginGroup")
                .add(fileUpload)
                .add(new Label("labelPluginUpload",
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PLUGIN_UPLOAD))));

        form.add(new RequirableFormGroup("nameGroup")
                .add(new TextField<>("field", EditExchangeBeanModels.bindName(model))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_NAME))
                        .setRequired(true)
                        .add(new UniqueValidator<>(name -> exchangeService.isNameUnique(name, model.getObject().getId())))
                        .add(new InputBehavior())));

        form.add(new RequirableFormGroup("targetGroup")
                .add(new TextField<>("field", EditExchangeBeanModels.bindTargetExchangeName(model))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_TARGET_EXCHANGE_NAME))
                        .add(new InputBehavior())));

        form.add(new RequirableFormGroup("descriptionGroup")
                .add(new TextField<>("field", EditExchangeBeanModels.bindDescription(model))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_DESCRIPTION))
                        .add(new InputBehavior())));

        form.add(new RequirableFormGroup("contactGroup")
                .add(new WindsorSelect2Choice<Account>("field", EditExchangeBeanModels.bindAccount(model),
                        new AccountChoiceProvider(accountService, () -> new AccountSearchCriteria().withExchangeRoles()))
                        .width("100%")
                        .setRequired(true)
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_CONTACT))));

        form.add(new RequirableFormGroup("urlGroup")
                .add(new TextField<>("field", EditExchangeBeanModels.bindUrl(getModel()))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_URL))
                        .add(new InputBehavior())));

        form.add(new FormGroup("secureGroup")
                .add(new CheckBox("field", EditExchangeBeanModels.bindSecure(getModel())))
                .add(new Label("label", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PROTECTED))));

        form.add(new Label("labelProtected", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PROTECTED_TEXT)));

        form.add(new Label("labelPluginInformation",
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PLUGIN_INFORMATION)));

        form.add(new Label("labelPluginName", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PLUGIN_NAME)));
        form.add(new Label("pluginName", PluginMetaDataModels.bindName(pluginMetaDataModel)));

        form.add(new Label("labelPluginFullName",
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PLUGIN_FULL_NAME)));
        form.add(new Label("pluginFullName", PluginMetaDataModels.bindFullName(pluginMetaDataModel)));

        form.add(new Label("labelPluginDescription",
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PLUGIN_DESCRIPTION)));
        form.add(new Label("pluginDescription", PluginMetaDataModels.bindDescription(pluginMetaDataModel)));

        form.add(new Label("labelPluginVersion",
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PLUGIN_VERSION)));
        form.add(new Label("pluginVersion", PluginMetaDataModels.bindVersion(pluginMetaDataModel)));
    }

    @Override
    public IModel<String> getModalTitleModel() {
        return new LDResourceModel<>(() -> getModelObject().getId() == null
                ? NodeResourceModelKeys.TITLE_ADD_EXCHANGE
                : NodeResourceModelKeys.TITLE_EDIT_EXCHANGE);
    }

    @Override
    public Component getFooterPanel() {
        return new ButtonsPanel(WindsorBaseModal.getFooterId(), id ->
            Arrays.asList(
                    new SaveButton(id, form) {

                        @Override
                        protected void onSubmit(AjaxRequestTarget target, Form<?> form) {
                            FileUpload file = fileUpload.getFileUpload();
                            if (file != null) {
                                ExchangeFormPanel.this.getModel().getObject()
                                        .setPluginContent(file.getBytes());
                            }
                            super.onSubmit(target, form);
                        }

                    },
                    new CancelButton(id)));
    }

}
