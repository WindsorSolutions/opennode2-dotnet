package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import com.windsor.node.domain.entity.Account;
import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.entity.Exchange;

/**
 * Provides lazy models for the Exchange object.
 */
public final class ExchangeModels {

    public static final LazyModel<String> ID = model(from(Exchange.class).getId());
    public static final LazyModel<String> NAAS_ACCOUNT = model(from(Exchange.class).getContact().getNaasAccount());
    public static final LazyModel<Account> ACCOUNT = model(from(Exchange.class).getContact());
    public static final LazyModel<Boolean> SECURE = model(from(Exchange.class).isSecure());
    public static final LazyModel<String> DESCRIPTION = model(from(Exchange.class).getDescription());
    public static final LazyModel<String> NAME = model(from(Exchange.class).getName());
    public static final LazyModel<String> TARGET_EXCHANGE_NAME = model(from(Exchange.class).getTargetExchangeName());
    public static final LazyModel<String> URL = model(from(Exchange.class).getUrl());

    private ExchangeModels() {

    }

    public static IModel<String> bindId(IModel<Exchange> model) {
        return ID.bind(model);
    }

    public static IModel<String> bindNaasAccount(IModel<Exchange> model) {
        return NAAS_ACCOUNT.bind(model);
    }

    public static IModel<Account> bindAccount(IModel<Exchange> model) {
        return ACCOUNT.bind(model);
    }

    public static IModel<Boolean> bindSecure(IModel<Exchange> model) {
        return SECURE.bind(model);
    }

    public static IModel<String> bindDescription(IModel<Exchange> model) {
        return DESCRIPTION.bind(model);
    }

    public static IModel<String> bindName(IModel<Exchange> model) {
        return NAME.bind(model);
    }

    public static IModel<String> bindTargetExchangeName(IModel<Exchange> model) {
        return TARGET_EXCHANGE_NAME.bind(model);
    }

    public static IModel<String> bindUrl(IModel<Exchange> model) {
        return URL.bind(model);
    }

}
