package com.windsor.node.web.content.account;

import com.windsor.node.domain.NaasException;
import com.windsor.node.domain.edit.EditAccountBean;
import com.windsor.node.domain.edit.EditPasswordBean;
import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.search.AccountSearchCriteria;
import com.windsor.node.service.AccountService;
import com.windsor.node.service.converter.EditAccountBeanService;
import com.windsor.node.service.converter.EditPasswordBeanService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.NodeModalWindowPanel;
import com.windsor.node.web.component.WorkspaceTitlePanel;
import com.windsor.node.web.component.page.NodeDetailPage;
import com.windsor.node.web.content.profile.PasswordChangeFormPanel;
import com.windsor.node.web.event.ChangePasswordEvent;
import com.windsor.node.web.model.LoggedInAccountModel;
import com.windsor.stack.web.wicket.component.modal.WindsorModal;
import com.windsor.stack.web.wicket.component.modal.WindsorModalWindowPanel;
import com.windsor.stack.web.wicket.event.AddEvent;
import com.windsor.stack.web.wicket.event.DeleteEvent;
import com.windsor.stack.web.wicket.event.EditEvent;
import com.windsor.stack.web.wicket.event.RenderFeedbackPanelEvent;
import com.windsor.stack.web.wicket.event.ResetEvent;
import com.windsor.stack.web.wicket.event.SaveEvent;
import com.windsor.stack.web.wicket.event.SearchEvent;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import org.apache.wicket.Component;
import org.apache.wicket.PageReference;
import org.apache.wicket.event.Broadcast;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.request.mapper.parameter.PageParameters;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.wicketstuff.event.annotation.OnEvent;

/**
 * Provides a page for managing Argument instances.
 */
public class AccountListPage extends NodeDetailPage<AccountSearchCriteria> {

    @SpringBean
    private AccountService accountService;

    @SpringBean
    private EditPasswordBeanService editPasswordBeanService;

    @SpringBean
    private EditAccountBeanService editAccountBeanService;

    private IModel<Account> userAccountModel;
    private WindsorModalWindowPanel modal;

    public AccountListPage(PageParameters pageParameters) {
        this(pageParameters, null);
    }

    public AccountListPage(PageParameters pageParameters, PageReference pageReference) {
        super(pageParameters, pageReference);
        userAccountModel = new LoggedInAccountModel();
        setModel(Model.of(new AccountSearchCriteria(AccountSearchCriteria.ACTIVE_LOCAL_ACCOUNT_CRITERIA)));
        modal = new NodeModalWindowPanel("modal");
        add(modal);
    }

    @Override
    protected IModel<String> getPageTitleModel() {
        return new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_ACCOUNTS);
    }

    @Override
    protected Component titlePanel(String cid, IModel<AccountSearchCriteria> model) {
        return new WorkspaceTitlePanel<>(cid, model,
                new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_ACCOUNTS),
                new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_SUBHEAD),
                Model.of(""));
    }

    @Override
    protected Component contentPanel(String cid, IModel<AccountSearchCriteria> model) {
        return new AccountListDataTable(cid, model);
    }

    @Override
    protected Component rightPanel(String cid, IModel<AccountSearchCriteria> model) {
        return new AccountListSidePanel(cid, model, new IdentifiableResourceModel(NodeResourceModelKeys.HELP_ACCOUNT));
    }

    @Override
	protected void onDetach() {
		super.onDetach();
		userAccountModel.detach();
	}

	@OnEvent(types = AccountSearchCriteria.class)
    public void handleAccountSearchEvent(SearchEvent<AccountSearchCriteria> event) {
        refreshWorkspace(event.getTarget());
    }

    @OnEvent(types = AccountSearchCriteria.class)
    public void handleAccountRestEvent(ResetEvent<AccountSearchCriteria> event) {
        getModelObject().reset();
        refreshWorkspace(event.getTarget());
    }

    @OnEvent(types = EditAccountBean.class)
    public void handleSaveAccountEvent(final SaveEvent<EditAccountBean> event) {
        modal.getModal().close(event.getTarget());
        editAccountBeanService.save(event.getPayload());
        refreshWorkspace(event.getTarget());
    }

    @OnEvent(types = EditPasswordBean.class)
    public void handleNewUserEvent(final SaveEvent<EditPasswordBean> event) {
    	WindsorModal m = modal.getModal();
        EditPasswordBean bean = event.getPayload();
        try {
            editPasswordBeanService.changePassword(bean, userAccountModel.getObject());
            success("Password successfully changed");
            send(getPage(), Broadcast.BREADTH, new RenderFeedbackPanelEvent(event.getTarget()));
            m.close(event.getTarget());
        } catch (NaasException e) {
        	error(e.getMessage());
        	m.send(m, Broadcast.BREADTH, new RenderFeedbackPanelEvent(event.getTarget()));
        }
    }

    @OnEvent(types = Account.class)
    public void handleEditEvent(final EditEvent<Account> event) {
        modal.getModal().setContentPanel(
                new AccountFormPanel(modal.getModal().getContentId(),
                        Model.of(editAccountBeanService.toBean(event.getPayload()))));
        modal.getModal().show(event.getTarget());
    }

    @OnEvent(types = Account.class)
    public void handleAddAccountEvent(AddEvent event) {
        WindsorModal m = modal.getModal();
        m.setContentPanel(new AccountFormPanel(m.getContentId(), Model.of()));
        m.show(event.getTarget());
    }

    @OnEvent(types = EditPasswordBean.class)
    public void handleNewAccountEvent(AddEvent event) {
        WindsorModal m = modal.getModal();
        m.setContentPanel(new PasswordChangeFormPanel(m.getContentId(), Model.of(new EditPasswordBean()), false));
        m.show(event.getTarget());
    }

    @OnEvent(types = Account.class)
    public void handleDeleteAccountEvent(DeleteEvent<Account> event) {
        WindsorModal.closeCurrent(event.getTarget());
        accountService.logicalDelete(event.getPayload());
        refreshWorkspace(event.getTarget());
    }

    @OnEvent(types = Account.class)
    public void handleChangePasswordEvent(ChangePasswordEvent<Account> event) {
        WindsorModal m = modal.getModal();
        Account account = event.getPayload();
        m.setContentPanel(new PasswordChangeFormPanel(m.getContentId(), Model.of(new EditPasswordBean(account.getId(), account.getNaasAccount())), false));
        m.show(event.getTarget());
    }

}
