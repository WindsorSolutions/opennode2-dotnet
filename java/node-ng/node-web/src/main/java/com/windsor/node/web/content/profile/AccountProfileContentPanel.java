package com.windsor.node.web.content.profile;

import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.panel.Panel;
import org.apache.wicket.model.IModel;

import com.windsor.node.domain.entity.Account;
import com.windsor.node.web.model.lazy.AccountModels;

/**
 * Provides the main panel for the account home page.
 */
public class AccountProfileContentPanel extends Panel {

    public AccountProfileContentPanel(String id, IModel<Account> model) {
        super(id, model);
        add(new Label("email", AccountModels.bindNaasAccount(model)));
        add(new Label("role", AccountModels.bindSystemRoleType(model)));
        add(new Label("active", AccountModels.bindActive(model)));
        add(new Label("modifiedBy", AccountModels.bindModifiedBy(model)));
        add(new Label("modifiedOn", AccountModels.bindModifiedOn(model)));
    }

}
