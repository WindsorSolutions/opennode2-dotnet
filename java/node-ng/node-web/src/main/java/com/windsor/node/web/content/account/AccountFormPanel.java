package com.windsor.node.web.content.account;

import com.windsor.node.domain.edit.EditAccountBean;
import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.SystemRoleType;
import com.windsor.node.domain.search.AccountSearchCriteria;
import com.windsor.node.domain.search.ExchangeSearchCriteria;
import com.windsor.node.domain.search.ExchangeSorts;
import com.windsor.node.service.AccountService;
import com.windsor.node.service.ExchangeService;
import com.windsor.node.service.converter.EditAccountBeanService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.select2.AccountChoiceProvider;
import com.windsor.node.web.component.select2.SystemRoleTypeProviderChoiceProvider;
import com.windsor.node.web.model.LDResourceModel;
import com.windsor.node.web.model.lazy.EditAccountBeanModels;
import com.windsor.node.web.model.lazy.ExchangeModels;
import com.windsor.stack.web.wicket.behavior.VisibleModelBehavior;
import com.windsor.stack.web.wicket.component.modal.WindsorBaseModal;
import com.windsor.stack.web.wicket.component.panel.ButtonsPanel;
import com.windsor.stack.web.wicket.component.panel.modal.ModalizablePanel;
import com.windsor.stack.web.wicket.markup.html.form.RequirableFormGroup;
import com.windsor.stack.web.wicket.markup.html.form.button.CancelButton;
import com.windsor.stack.web.wicket.markup.html.form.button.SaveButton;
import com.windsor.stack.web.wicket.markup.html.form.select2.WindsorSelect2Choice;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import com.windsor.stack.web.wicket.model.LDModel;
import de.agilecoders.wicket.core.markup.html.bootstrap.form.BootstrapForm;
import org.apache.wicket.Component;
import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.ajax.form.OnChangeAjaxBehavior;
import org.apache.wicket.markup.html.WebMarkupContainer;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.form.Check;
import org.apache.wicket.markup.html.form.CheckGroup;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.markup.html.list.ListItem;
import org.apache.wicket.markup.html.list.ListView;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.wicketstuff.select2.Settings;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public class AccountFormPanel extends ModalizablePanel<EditAccountBean> {

    private Form<EditAccountBean> form;

    @SpringBean
    private ExchangeService exchangeService;

    @SpringBean
    private AccountService accountService;

    @SpringBean
    private EditAccountBeanService editAccountBeanService;

    public AccountFormPanel(String id, IModel<EditAccountBean> model) {
        super(id, model);
        boolean selectUser = model.getObject() == null;

        form = new BootstrapForm<>("form", model);
        form.add(new VisibleModelBehavior(new LDModel<>(() -> model.getObject() != null)));
        form.setOutputMarkupPlaceholderTag(true);
        add(form);

        WebMarkupContainer accountGroup = new WebMarkupContainer("emailGroup");
        accountGroup.setVisible(! selectUser);
        form.add(accountGroup);
        accountGroup.add(new Label("email", EditAccountBeanModels.bindNaasAccount(model)));
        form.add(new Label("affiliation", EditAccountBeanModels.bindAffiliation(model)));

        form.add(new RequirableFormGroup("roleGroup")
                .add(new WindsorSelect2Choice<>(
                    "field",
                    EditAccountBeanModels.bindSystemRoleType(model),
                    new SystemRoleTypeProviderChoiceProvider(SystemRoleType.LOCAL_ROLES))
                .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ROLE))
                .setRequired(true)));

        CheckGroup<Exchange> exchangeCheckgroup = new CheckGroup<>("group",
                EditAccountBeanModels.bindExchanges(model));
        form.add(exchangeCheckgroup);

        IModel<List<Exchange>> secureExchangeListModel = new LDModel<>(() ->
            exchangeService.find(new ExchangeSearchCriteria().secure(true),
                    ExchangeSorts.NAME)
            .collect(Collectors.toList()));

         exchangeCheckgroup.add(new ListView<Exchange>("exchanges", secureExchangeListModel) {

            @Override
            protected void populateItem(ListItem<Exchange> item) {
                item.add(new Check<>("exchange", item.getModel(), exchangeCheckgroup));
                item.add(new Label("name", ExchangeModels.bindName(item.getModel())));
            }

        });
        form.add(new RequirableFormGroup("exchangesGroup").add(exchangeCheckgroup));

        IModel<Account> accountModel = Model.of();
        Form<Account> accountForm = new Form<>("accountForm", accountModel);
        add(accountForm);
        accountForm.setVisible(selectUser);

        WindsorSelect2Choice<Account> accountSelector = new WindsorSelect2Choice<>(
                "field",
                accountModel,
                new AccountChoiceProvider(accountService,
                        () -> new AccountSearchCriteria().systemRoleTypes(SystemRoleType.NON_LOCAL_ROLES)));
        accountSelector.setRequired(true);
        accountSelector.setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ACCOUNT));
        accountSelector.add(new OnChangeAjaxBehavior() {

            @Override
            protected void onUpdate(AjaxRequestTarget target) {
                EditAccountBean bean = editAccountBeanService.toBean(accountModel.getObject());
                if (selectUser) {
                    bean.setSystemRoleType(null);
                }
                model.setObject(bean);
                target.add(form);
            }
        });
        Settings settings = accountSelector.getSettings();
        settings.setWidth("300px");

        accountForm.add(new RequirableFormGroup("accountGroup").add(accountSelector));
    }

    @Override
    public Component getFooterPanel() {
        return new ButtonsPanel(WindsorBaseModal.getFooterId(), id ->
            Arrays.asList(new SaveButton(id, form), new CancelButton(id)));
    }

    @Override
    public IModel<String> getModalTitleModel() {
        EditAccountBean bean = getModelObject();
        return new LDResourceModel<>(() -> bean == null || bean.getId() == null
                ? NodeResourceModelKeys.TITLE_ADD_ACCOUNT
                : NodeResourceModelKeys.TITLE_EDIT_ACCOUNT);
    }

}
