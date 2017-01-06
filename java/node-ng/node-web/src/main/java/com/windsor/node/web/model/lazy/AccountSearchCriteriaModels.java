package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import java.util.Collection;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.entity.SystemRoleType;
import com.windsor.node.domain.search.AccountSearchCriteria;

/**
 * Provides lazy models for ArgumentSearchCriteria instances.
 */
public final class AccountSearchCriteriaModels {

    public static final LazyModel<String> NAME = model(from(AccountSearchCriteria.class).getName());
    public static final LazyModel<Collection<SystemRoleType>> ROLE_TYPES = model(from(AccountSearchCriteria.class).getSystemRoleTypes());
    public static final LazyModel<SystemRoleType> ROLE_TYPE = model(from(AccountSearchCriteria.class).getSystemRoleType());
    public static final LazyModel<String> AFFILIATION = model(from(AccountSearchCriteria.class).getAffiliation());
    public static final LazyModel<Boolean> ACTIVE = model(from(AccountSearchCriteria.class).getActive().getValue());
    public static final LazyModel<Boolean> LOCAL_ONLY = model(from(AccountSearchCriteria.class).getLocalAccountsOnly().getValue());

    private AccountSearchCriteriaModels() {

    }

    public static LazyModel<Boolean> bindLocalOnly(IModel<AccountSearchCriteria> model) {
        return LOCAL_ONLY.bind(model);
    }

}
