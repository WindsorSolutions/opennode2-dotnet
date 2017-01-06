package com.windsor.node.web.content.home;

import org.apache.wicket.Component;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.wicketstuff.annotation.mount.MountPath;
import org.wicketstuff.event.annotation.OnEvent;

import com.windsor.node.domain.NaasSyncInfo;
import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.entity.Activity;
import com.windsor.node.service.ActivityService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.WorkspaceTitlePanel;
import com.windsor.node.web.component.page.NodeDetailPage;
import com.windsor.node.web.content.activity.ActivityDetailPanel;
import com.windsor.node.web.model.LoggedInAccountModel;
import com.windsor.node.web.model.lazy.AccountModels;
import com.windsor.stack.web.wicket.component.modal.WindsorBaseModal;
import com.windsor.stack.web.wicket.component.modal.WindsorModal;
import com.windsor.stack.web.wicket.component.modal.WindsorModalWindowPanel;
import com.windsor.stack.web.wicket.event.ViewEvent;
import com.windsor.stack.web.wicket.model.EntityModel;
import com.windsor.stack.web.wicket.model.GenericModels;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

/**
 * Provides the Home page for the application.
 */
@MountPath("/")
public class HomePage extends NodeDetailPage<Account> {

    @SpringBean
    private ActivityService service;

    private WindsorModalWindowPanel modal;

    public HomePage() {
        super();
        setModel(new LoggedInAccountModel());
        modal = new WindsorModalWindowPanel("modal");
        add(modal);
    }

    @Override
    protected IModel<String> getPageTitleModel() {
        return new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_HOME);
    }

    @Override
    protected Component titlePanel(String cid, IModel<Account> model) {
        return new WorkspaceTitlePanel<>(cid, model,
                AccountModels.bindNaasAccount(model),
                new IdentifiableResourceModel(NodeResourceModelKeys.TITLE_PAGE_SUBHEAD_HOME),
                GenericModels.MODEL_EMPTY);
    }

    @Override
    protected Component contentPanel(String cid, IModel<Account> model) {
        return new DashboardPanel(cid, model);
    }

    @Override
    protected Component rightPanel(String cid, IModel<Account> model) {
        return new HomeSidePanel(cid, new IdentifiableResourceModel(NodeResourceModelKeys.HELP_HOME));
    }

    @OnEvent(types = Activity.class)
    public void handleViewEvent(ViewEvent<Activity> event) {
        WindsorModal m = modal.getModal();
        m.setSizeModel(Model.of(WindsorBaseModal.Size.Large));
        m.setContentPanel(new ActivityDetailPanel(m.getContentId(),
                new EntityModel<>(service, event.getPayload().getId())));
        m.show(event.getTarget());
    }
    
    @OnEvent(types = NaasSyncInfo.class)
    public void handleViewNaasSyncInfoActivity(ViewEvent<NaasSyncInfo> event) {
        WindsorModal m = modal.getModal();
        m.setSizeModel(Model.of(WindsorBaseModal.Size.Large));
        m.setContentPanel(new ActivityDetailPanel(m.getContentId(),
                new EntityModel<>(service, event.getPayload().getActivityId())));
        m.show(event.getTarget());
    }

}
