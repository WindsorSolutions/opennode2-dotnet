package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.service.props.NaasProperties;

public class NaasPropertiesModels {

    public static final LazyModel<String> ADMIN_USERNAME = model(from(NaasProperties.class).getNaasAdminUsername());
    public static final LazyModel<String> AUTH_URL = model(from(NaasProperties.class).getNaasAuthenticationUrl());

    private NaasPropertiesModels() {
        super();
    }

    public static LazyModel<String> bindAdminUsername(IModel<NaasProperties> model) {
        return ADMIN_USERNAME.bind(model);
    }

    public static LazyModel<String> bindAuthUrl(IModel<NaasProperties> model) {
        return AUTH_URL.bind(model);
    }

}
