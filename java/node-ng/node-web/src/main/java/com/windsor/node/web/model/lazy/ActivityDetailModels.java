package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import java.time.LocalDateTime;

import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.entity.ActivityDetail;

/**
 * Provides lazy models for the Activity Detail object.
 */
public final class ActivityDetailModels {

    public static final LazyModel<LocalDateTime> CREATE_DATE = model(from(ActivityDetail.class).getModifiedOn());
    public static final LazyModel<String> DETAIL = model(from(ActivityDetail.class).getDetail());

    private ActivityDetailModels() {

    }

}
