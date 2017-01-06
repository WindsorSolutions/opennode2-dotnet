package com.windsor.node.web.model.lazy;

import com.windsor.node.domain.entity.Partner;
import com.windsor.node.domain.entity.PartnerVersion;
import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

/**
 * Provides lazy models for the Partner object.
 */
public class PartnerModels {

    public static final LazyModel<String> ID = model(from(Partner.class).getId());
    public static final LazyModel<String> NAME = model(from(Partner.class).getName());
    public static final LazyModel<String> URL = model(from(Partner.class).getUrl());
    public static final LazyModel<PartnerVersion> VERSION = model(from(Partner.class).getVersion());

    private PartnerModels() {

    }

    public static IModel<String> bindId(IModel<Partner> model) {
        return ID.bind(model);
    }

    public static IModel<String> bindName(IModel<Partner> model) {
        return NAME.bind(model);
    }

    public static IModel<String> bindUrl(IModel<Partner> model) {
        return URL.bind(model);
    }

    public static IModel<PartnerVersion> bindVersion(IModel<Partner> model) {
        return VERSION.bind(model);
    }
}
