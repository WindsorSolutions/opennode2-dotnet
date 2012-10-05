package com.windsor.node.plugin.wqx.dao;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.EntityManager;

import com.windsor.node.plugin.common.persistence.JpaPagedList;

public class PagedListFilteredByOrgIdAndUpdatedBetween<T extends Serializable> extends JpaPagedList<T> {

    private static final String PARAMETER_ORGANIZATION_ID = "organizationId";

    private static final String PARAMETER_LOWER_BOUND_DATE = "lower";

    private static final String PARAMETER_UPPER_BOUND_DATE = "upper";

    public PagedListFilteredByOrgIdAndUpdatedBetween(Class<T> entityClass, EntityManager em, int cacheSize, String organizationId, Date lowerBoundUpdatedDate, Date upperBoundUpdatedDate) {
        super(entityClass, em, cacheSize);
        addNamedParameter(PARAMETER_ORGANIZATION_ID, organizationId);
        addNamedParameter(PARAMETER_LOWER_BOUND_DATE, lowerBoundUpdatedDate);
        addNamedParameter(PARAMETER_UPPER_BOUND_DATE, upperBoundUpdatedDate);
    }

    @Override
    protected String getDataQuery() {

        return String.format("select x from %s x where x.organizationId = :%s and x.updatedDate between :%s and :%s",
                getEntityClass().getSimpleName(),
                PARAMETER_ORGANIZATION_ID,
                PARAMETER_LOWER_BOUND_DATE,
                PARAMETER_UPPER_BOUND_DATE);
    }

    @Override
    protected String getCountQuery() {
        return String.format("select x from %s x where x.organizationId = :%s and x.updatedDate between :%s and :%s",
                getEntityClass().getSimpleName(),
                PARAMETER_ORGANIZATION_ID,
                PARAMETER_LOWER_BOUND_DATE,
                PARAMETER_UPPER_BOUND_DATE);
    }
}
