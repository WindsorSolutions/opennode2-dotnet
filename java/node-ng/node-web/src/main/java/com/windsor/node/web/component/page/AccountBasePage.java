package com.windsor.node.web.component.page;

import org.apache.wicket.PageReference;
import org.apache.wicket.request.mapper.parameter.PageParameters;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.apache.wicket.util.string.StringValue;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.windsor.node.domain.entity.Account;
import com.windsor.node.service.AccountService;
import com.windsor.stack.web.wicket.model.EntityModel;
import com.windsor.stack.web.wicket.security.SpringAuthenticatedWebSession;

/**
 * Provides a base page that all account pages may inherit from.
 */
public class AccountBasePage extends NodeDetailPage<Account> {

    public final static Logger logger = LoggerFactory.getLogger(AccountBasePage.class);

    /**
     * Parameter used to indicate the unique identifier of a User instance.
     */
    public static final String PARAM_ID = "id";

    @SpringBean
    private AccountService service;

    public AccountBasePage(PageParameters pageParameters) {
        this(pageParameters, null);
    }

    @SuppressWarnings("unchecked")
    public AccountBasePage(PageParameters pageParameters, PageReference previousPageReference) {
        super(pageParameters, previousPageReference);

        StringValue sv = pageParameters.get(PARAM_ID);
        String accountId = null;
        if (!sv.isEmpty()) {
            accountId = sv.toString();
        } else {
            accountId = ((SpringAuthenticatedWebSession<Account>) getSession()).getSecurityUser().get().getUser().getId();
        }

        setModel(new EntityModel<>(service, accountId));
    }

    public static PageParameters newPageParameters(Account account, PageReference previousPageReference) {

        PageParameters pageParameters = newPageParameters(previousPageReference);

        if(account != null) {
            pageParameters.add(PARAM_ID, account.getId());
        }

        return pageParameters;
    }
}
