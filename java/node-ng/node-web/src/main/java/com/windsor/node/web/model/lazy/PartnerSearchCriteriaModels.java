package com.windsor.node.web.model.lazy;

import com.windsor.node.domain.entity.PartnerVersion;
import com.windsor.node.domain.search.PartnerSearchCriteria;
import org.wicketstuff.lazymodel.LazyModel;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

/**
 * Provides lazy models for PartnerSearchCriteria instances.
 */
public class PartnerSearchCriteriaModels {

    public static final LazyModel<String> NAME = model(from(PartnerSearchCriteria.class).getName());
    public static final LazyModel<String> URL = model(from(PartnerSearchCriteria.class).getUrl());
    public static final LazyModel<PartnerVersion> VERSION = model(from(PartnerSearchCriteria.class).getVersion());

    private PartnerSearchCriteriaModels() {

    }
}
