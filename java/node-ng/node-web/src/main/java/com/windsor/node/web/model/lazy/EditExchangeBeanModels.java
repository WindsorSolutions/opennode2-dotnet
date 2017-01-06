package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.edit.EditExchangeBean;
import com.windsor.node.domain.entity.Account;

/**
 * Provides lazy models for the Exchange object.
 */
public final class EditExchangeBeanModels {

    public static final LazyModel<String> ID = model(from(EditExchangeBean.class).getId());
    public static final LazyModel<String> NAAS_ACCOUNT = model(from(EditExchangeBean.class).getContact().getNaasAccount());
    public static final LazyModel<Account> ACCOUNT = model(from(EditExchangeBean.class).getContact());
    public static final LazyModel<Boolean> SECURE = model(from(EditExchangeBean.class).isSecure());
    public static final LazyModel<String> DESCRIPTION = model(from(EditExchangeBean.class).getDescription());
    public static final LazyModel<String> NAME = model(from(EditExchangeBean.class).getName());
    public static final LazyModel<String> TARGET_EXCHANGE_NAME = model(from(EditExchangeBean.class).getTargetExchangeName());
    public static final LazyModel<String> URL = model(from(EditExchangeBean.class).getUrl());

    private EditExchangeBeanModels() {

    }

    public static IModel<String> bindId(IModel<EditExchangeBean> model) {
        return ID.bind(model);
    }

    public static IModel<String> bindNaasAccount(IModel<EditExchangeBean> model) {
        return NAAS_ACCOUNT.bind(model);
    }

    public static IModel<Account> bindAccount(IModel<EditExchangeBean> model) {
        return ACCOUNT.bind(model);
    }

    public static IModel<Boolean> bindSecure(IModel<EditExchangeBean> model) {
        return SECURE.bind(model);
    }

    public static IModel<String> bindDescription(IModel<EditExchangeBean> model) {
        return DESCRIPTION.bind(model);
    }

    public static IModel<String> bindName(IModel<EditExchangeBean> model) {
        return NAME.bind(model);
    }

    public static IModel<String> bindTargetExchangeName(IModel<EditExchangeBean> model) {
        return TARGET_EXCHANGE_NAME.bind(model);
    }

    public static IModel<String> bindUrl(IModel<EditExchangeBean> model) {
        return URL.bind(model);
    }

}
