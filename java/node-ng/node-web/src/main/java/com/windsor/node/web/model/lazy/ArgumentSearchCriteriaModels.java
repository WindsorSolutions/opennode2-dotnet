package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.search.ArgumentSearchCriteria;

/**
 * Provides lazy models for ArgumentSearchCriteria instances.
 */
public final class ArgumentSearchCriteriaModels {

    public static final LazyModel<String> NAME = model(from(ArgumentSearchCriteria.class).getName());
    public static final LazyModel<String> VALUE = model(from(ArgumentSearchCriteria.class).getValue());
    public static final LazyModel<String> DESCRIPTION = model(from(ArgumentSearchCriteria.class).getDescription());
    public static final LazyModel<Boolean> EDITABLE = model(from(ArgumentSearchCriteria.class).getEditable().getValue());

    private ArgumentSearchCriteriaModels() {

    }
}
