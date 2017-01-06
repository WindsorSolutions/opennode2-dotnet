package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import java.time.LocalDateTime;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.entity.SystemRoleType;

/**
 * Provides lazy models for the Account object.
 */
public final class AccountModels {

    public static final LazyModel<String> ID = model(from(Account.class).getId());
    public static final LazyModel<String> NAAS_ACCOUNT = model(from(Account.class).getNaasAccount());
    public static final LazyModel<Boolean> ACTIVE = model(from(Account.class).isActive());
    public static final LazyModel<SystemRoleType> SYSTEM_ROLE_TYPE = model(from(Account.class).getSystemRoleType());
    public static final LazyModel<String> AFFILIATION = model(from(Account.class).getAffiliation());
    public static final LazyModel<Boolean> DELETED = model(from(Account.class).getDeleted());
    public static final LazyModel<Boolean> DEMO_USER = model(from(Account.class).getDemoUser());
    public static final LazyModel<String> MODIFIED_BY = model(from(Account.class).getModifiedBy().getNaasAccount());
    public static final LazyModel<LocalDateTime> MODIFIED_ON = model(from(Account.class).getModifiedOn());

    private AccountModels() {

    }

    public static IModel<String> bindId(IModel<Account> model) {
        return ID.bind(model);
    }

    public static IModel<String> bindNaasAccount(IModel<Account> model) {
        return NAAS_ACCOUNT.bind(model);
    }

    public static IModel<Boolean> bindActive(IModel<Account> model) {
        return ACTIVE.bind(model);
    }

    public static IModel<SystemRoleType> bindSystemRoleType(IModel<Account> model) {
        return SYSTEM_ROLE_TYPE.bind(model);
    }

    public static IModel<String> bindAffiliation(IModel<Account> model) {
        return AFFILIATION.bind(model);
    }

    public static IModel<Boolean> bindDeleted(IModel<Account> model) {
        return DELETED.bind(model);
    }

    public static IModel<Boolean> bindDemoUser(IModel<Account> model) {
        return DEMO_USER.bind(model);
    }

    public static IModel<String> bindModifiedBy(IModel<Account> model) {
        return MODIFIED_BY.bind(model);
    }

    public static IModel<LocalDateTime> bindModifiedOn(IModel<Account> model) {
        return MODIFIED_ON.bind(model);
    }

}
