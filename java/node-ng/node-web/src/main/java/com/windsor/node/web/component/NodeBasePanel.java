package com.windsor.node.web.component;

import com.windsor.node.domain.entity.Account;
import com.windsor.node.web.model.LoggedInAccountModel;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import org.apache.wicket.model.IModel;

/**
 * Provides a base panel to be the foundation of more specialized panels.
 */
public class NodeBasePanel<T> extends AbstractBasePanel<T> {

    private IModel<Account> loggedInUserModel = new LoggedInAccountModel();

    public NodeBasePanel(String id, IModel<T> model) {
        super(id, model);
    }

    protected IModel<Account> getLoggedInUserModel() {
        return loggedInUserModel;
    }

    @Override
    protected void onDetach() {
        super.onDetach();
        loggedInUserModel.detach();
    }

}