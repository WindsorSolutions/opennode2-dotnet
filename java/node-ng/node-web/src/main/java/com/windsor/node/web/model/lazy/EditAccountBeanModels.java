package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import java.util.Collection;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.edit.EditAccountBean;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.SystemRoleType;

/**
 * Provides lazy models for the Account object.
 */
public final class EditAccountBeanModels {

    public static final LazyModel<String> NAAS_ACCOUNT = model(from(EditAccountBean.class).getNaasAccount());
    public static final LazyModel<String> AFFILIATION = model(from(EditAccountBean.class).getAffiliation());
    public static final LazyModel<Boolean> ACTIVE = model(from(EditAccountBean.class).isActive());
    public static final LazyModel<SystemRoleType> SYSTEM_ROLE_TYPE = model(from(EditAccountBean.class).getSystemRoleType());
    public static final LazyModel<Collection<Exchange>> EXCHANGES = model(from(EditAccountBean.class).getExchanges());

    private EditAccountBeanModels() {

    }

    public static IModel<String> bindNaasAccount(IModel<EditAccountBean> model) {
        return NAAS_ACCOUNT.bind(model);
    }

    public static IModel<String> bindAffiliation(IModel<EditAccountBean> model) {
        return AFFILIATION.bind(model);
    }

    public static IModel<Boolean> bindActive(IModel<EditAccountBean> model) {
        return ACTIVE.bind(model);
    }

    public static IModel<SystemRoleType> bindSystemRoleType(IModel<EditAccountBean> model) {
        return SYSTEM_ROLE_TYPE.bind(model);
    }

    public static IModel<Collection<Exchange>> bindExchanges(IModel<EditAccountBean> model) {
        return EXCHANGES.bind(model);
    }


}
