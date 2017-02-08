package com.windsor.node.web.content.profile;

import com.windsor.node.domain.NaasException;
import com.windsor.node.domain.NodePermission;
import com.windsor.node.domain.edit.EditNotificationsBean;
import com.windsor.node.domain.edit.EditPasswordBean;
import com.windsor.node.domain.entity.Account;
import com.windsor.node.service.NAASAuthenticationService;
import com.windsor.node.service.converter.EditNotificationsBeanService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.NodeModalWindowPanel;
import com.windsor.node.web.component.WorkspaceTitlePanel;
import com.windsor.node.web.component.page.AccountBasePage;
import com.windsor.node.web.event.ChangePasswordEvent;
import com.windsor.stack.web.wicket.component.modal.WindsorBaseModal.Size;
import com.windsor.stack.web.wicket.component.modal.WindsorModal;
import com.windsor.stack.web.wicket.component.modal.WindsorModalWindowPanel;
import com.windsor.stack.web.wicket.event.EditEvent;
import com.windsor.stack.web.wicket.event.RenderFeedbackPanelEvent;
import com.windsor.stack.web.wicket.event.SaveEvent;
import com.windsor.stack.web.wicket.model.GenericModels;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import com.windsor.stack.web.wicket.security.authorization.IPrivilege;
import com.windsor.stack.web.wicket.security.authorization.ISecureRenderInstance;
import org.apache.wicket.Component;
import org.apache.wicket.PageReference;
import org.apache.wicket.event.Broadcast;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.request.mapper.parameter.PageParameters;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.wicketstuff.event.annotation.OnEvent;

/**
 * Provides the home page for logged-in customers.
 */
public class AccountProfilePage extends AccountBasePage implements ISecureRenderInstance<Account> {

    @SpringBean
    private NAASAuthenticationService naasServivce;

    @SpringBean
    private EditNotificationsBeanService editNotificationsBeanService;

    private WindsorModalWindowPanel modal;

    public AccountProfilePage(PageParameters pageParameters) {
        this(pageParameters, null);
    }

    public AccountProfilePage(PageParameters pageParameters, PageReference pageReference) {
        super(pageParameters, pageReference);
        modal = new NodeModalWindowPanel("modal");
        add(modal);
    }

    @Override
    protected IModel<String> getPageTitleModel() {
        return new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_PROFILE);
    }

    @Override
    protected Component titlePanel(String cid, IModel<Account> model) {
        return new WorkspaceTitlePanel<>(cid, model,
                new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_PROFILE),
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_EDIT),
                GenericModels.MODEL_EMPTY);
    }

    @Override
    protected Component contentPanel(String cid, IModel<Account> model) {
        return new AccountProfileContentPanel(cid, model);
    }

    @Override
    protected Component rightPanel(String cid, IModel<Account> model) {
        return new AccountProfileSidePanel(cid, model, new IdentifiableResourceModel(NodeResourceModelKeys.HELP_PROFILE));
    }

    @Override
    public IPrivilege<Account> getRenderPrivilege() {
        return su -> Account.HAS_PERMISSION.apply(su.getUser(), NodePermission.ADMIN_USER)
                || getModelObject().getId().equals(su.getUser().getId());
    }

    @OnEvent(types = Account.class)
    public void handleChangePasswordEvent(ChangePasswordEvent<Account> event) {
        WindsorModal m = modal.getModal();
        m.setSizeModel(Model.of(Size.Medium));
        m.setContentPanel(new PasswordChangeFormPanel(m.getContentId(),
                Model.of(new EditPasswordBean(event.getPayload().getId(), event.getPayload().getNaasAccount())), true));
        m.setSizeModel(Model.of(Size.Default));
        m.show(event.getTarget());
    }

    @OnEvent(types = EditPasswordBean.class)
    public void handleChangePasswordEvent(SaveEvent<EditPasswordBean> event) {
    	WindsorModal m = modal.getModal();
        EditPasswordBean bean = event.getPayload();
        try {
            naasServivce.changePassword(bean.getNaasAccount(), bean.getOldPassword(), bean.getNewPassword());
            success("Password successfully changed");
            send(getPage(), Broadcast.BREADTH, new RenderFeedbackPanelEvent(event.getTarget()));
            modal.getModal().close(event.getTarget());
        } catch (NaasException e) {
        	error(e.getMessage());
        	m.send(m, Broadcast.BREADTH, new RenderFeedbackPanelEvent(event.getTarget()));
        }
    }

    @OnEvent(types = Account.class)
    public void handleEditNotifications(EditEvent<Account> event) {
        EditNotificationsBean bean = editNotificationsBeanService.toBean(event.getPayload());
        WindsorModal m = modal.getModal();
        m.setContentPanel(new AccountNotificationFormPanel(m.getContentId(), Model.of(bean)));
        m.setSizeModel(Model.of(Size.Large));
        m.show(event.getTarget());
    }

    @OnEvent(types = EditNotificationsBean.class)
    public void handleSaveNotifications(SaveEvent<EditNotificationsBean> event) {
        modal.getModal().close(event.getTarget());
        editNotificationsBeanService.save(event.getPayload());
        success("Notifications successfully changed");
        send(getPage(), Broadcast.BREADTH, new RenderFeedbackPanelEvent(event.getTarget()));
    }

}
