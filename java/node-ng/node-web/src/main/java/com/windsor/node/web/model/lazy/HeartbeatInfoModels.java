package com.windsor.node.web.model.lazy;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.HeartbeatInfo;
import com.windsor.node.domain.entity.PartnerVersion;

public class HeartbeatInfoModels {

    public static final LazyModel<String> ENDPOINT = LazyModel.model(LazyModel.from(HeartbeatInfo.class).getEndpoint());
    public static final LazyModel<PartnerVersion> PARTNER_VERSION = LazyModel.model(LazyModel.from(HeartbeatInfo.class).getPartnerVersion());
    public static final LazyModel<Boolean> VALIDATED = LazyModel.model(LazyModel.from(HeartbeatInfo.class).isValidated());

    private HeartbeatInfoModels() {

    }

    public static LazyModel<String> bindEndpoint(IModel<HeartbeatInfo> model) {
        return ENDPOINT.bind(model);
    }

    public static LazyModel<PartnerVersion> bindVersion(IModel<HeartbeatInfo> model) {
        return PARTNER_VERSION.bind(model);
    }

    public static LazyModel<Boolean> bindValidated(IModel<HeartbeatInfo> model) {
        return VALIDATED.bind(model);
    }

}
