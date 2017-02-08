package com.windsor.node.web.content.account;

import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.entity.SystemRoleType;
import com.windsor.node.domain.search.AccountSearchCriteria;
import com.windsor.node.domain.search.AccountSorts;
import com.windsor.node.service.AccountService;
import com.windsor.node.web.app.Icons;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.NodeModalWindowPanel;
import com.windsor.node.web.component.button.ResetPasswordButton;
import com.windsor.node.web.component.column.Select2SingleChoiceFilteredLazyColumn;
import com.windsor.node.web.component.select2.SystemRoleTypeProviderChoiceProvider;
import com.windsor.node.web.model.AccountAffiliatedWithNodeModel;
import com.windsor.node.web.model.lazy.AccountModels;
import com.windsor.node.web.model.lazy.AccountSearchCriteriaModels;
import com.windsor.stack.web.wicket.behavior.VisibleModelBehavior;
import com.windsor.stack.web.wicket.component.datatable.WindsorDataTableConfiguration;
import com.windsor.stack.web.wicket.component.datatable.WindsorDataTablePanel;
import com.windsor.stack.web.wicket.component.datatable.column.lazy.ButtonsColumn;
import com.windsor.stack.web.wicket.component.datatable.column.lazy.TextFilteredLazyColumn;
import com.windsor.stack.web.wicket.component.modal.WindsorModalWindowPanel;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import com.windsor.stack.web.wicket.markup.html.form.button.ConfirmationButton;
import com.windsor.stack.web.wicket.markup.html.form.button.DeleteButton;
import com.windsor.stack.web.wicket.markup.html.form.button.EditButton;
import com.windsor.stack.web.wicket.markup.html.repeater.util.FinderDataProvider;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import de.agilecoders.wicket.core.markup.html.bootstrap.image.GlyphIconType;
import org.apache.wicket.extensions.markup.html.repeater.data.table.IColumn;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.spring.injection.annot.SpringBean;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

/**
 * Provides a data table of Account instances.
 */
public class AccountListDataTable extends AbstractBasePanel<AccountSearchCriteria> {

    @SpringBean
    private AccountService service;

    private WindsorModalWindowPanel modal;

    public AccountListDataTable(String cid, IModel<AccountSearchCriteria> model) {
        super(cid, model);

        modal = new NodeModalWindowPanel("modal");
        add(modal);

        add(new WindsorDataTablePanel<>("table", newColumns(),
                new FinderDataProvider<>(service, model, AccountSorts.NAME), 25L,
                new WindsorDataTableConfiguration().filteringToolbarVisible(true)));
    }

    private List<IColumn<Account, AccountSorts>> newColumns() {
        return Arrays.asList(
              new TextFilteredLazyColumn<>(
                      new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_NAME),
                      AccountModels.NAAS_ACCOUNT,
                      AccountSorts.NAME,
                      AccountSearchCriteriaModels.NAME),
              new TextFilteredLazyColumn<>(
                      new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_AFFILIATION),
                      AccountModels.AFFILIATION,
                      AccountSorts.AFFILIATION,
                      AccountSearchCriteriaModels.AFFILIATION),
              new Select2SingleChoiceFilteredLazyColumn<>(
                      new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ROLE),
                      AccountSorts.SYSTEM_ROLE_TYPE,
                      AccountModels.SYSTEM_ROLE_TYPE,
                      AccountSearchCriteriaModels.ROLE_TYPE,
                      new SystemRoleTypeProviderChoiceProvider(SystemRoleType.LOCAL_ROLES)),
            new ButtonsColumn<>(
                    new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ACTIONS),
                    (id, m) -> Stream.of(
                            new EditButton(id),
                            new ConfirmationButton(
                                    id,
                                    modal,
                                    Icons.ICON_DELETE,
                                    Model.of(""),
                                    new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_CONFIRM_DELETE_ACCOUNT),
                                    bid -> new DeleteButton(bid,
                                            new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_YES),
                                            GlyphIconType.check,
                                            f -> m.getObject()),
                                    new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_REMOVE_USER)),
                            new ResetPasswordButton(id, m)
                                    .add(new VisibleModelBehavior(new AccountAffiliatedWithNodeModel(m)))
                            )));
    }

}
