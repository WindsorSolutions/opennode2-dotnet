package com.windsor.node.web.model.lazy;

import com.windsor.node.domain.entity.*;
import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import java.util.List;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

/**
 * Provides lazy models for the ExchangeService object.
 */
public final class ExchangeServiceModels {

    public static final LazyModel<String> ID = model(from(ExchangeService.class).getId());
    public static final LazyModel<String> NAME = model(from(ExchangeService.class).getName());
    public static final LazyModel<Exchange> EXCHANGE = model(from(ExchangeService.class).getExchange());
    public static final LazyModel<Boolean> ACTIVE = model(from(ExchangeService.class).isActive());
    public static final LazyModel<ServiceType> TYPE = model(from(ExchangeService.class).getType());
    public static final LazyModel<ServiceAuthorizationLevel> AUTHORIZATION =
            model(from(ExchangeService.class).getAuthorization());
    public static final LazyModel<Boolean> SECURE = model(from(ExchangeService.class).getSecure());
    public static final LazyModel<List<ServiceArgument>> ARGUMENTS = model(from(ExchangeService.class).getArguments());
    public static final LazyModel<String> IMPLEMENTOR = model(from(ExchangeService.class).getImplementor());

    private ExchangeServiceModels() {

    }

    public static IModel<String> bindId(IModel<ExchangeService> model) {
        return ID.bind(model);
    }

    public static IModel<String> bindName(IModel<ExchangeService> model) {
        return NAME.bind(model);
    }

    public static IModel<Exchange> bindExchange(IModel<ExchangeService> model) {
        return EXCHANGE.bind(model);
    }

    public static IModel<Boolean> bindActive(IModel<ExchangeService> model) {
        return ACTIVE.bind(model);
    }

    public static IModel<ServiceType> bindType(IModel<ExchangeService> model) {
        return TYPE.bind(model);
    }

    public static IModel<ServiceAuthorizationLevel> bindAuthorization(IModel<ExchangeService> model) {
        return AUTHORIZATION.bind(model);
    }

    public static IModel<Boolean> bindSecure(IModel<ExchangeService> model) {
        return SECURE.bind(model);
    }

    public static IModel<List<ServiceArgument>> bindArguments(IModel<ExchangeService> model) {
        return ARGUMENTS.bind(model);
    }

    public static IModel<String> bindImplementor(IModel<ExchangeService> model) {
        return IMPLEMENTOR.bind(model);
    }
}
