package com.windsor.node.plugin.wqx.dao;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.EntityManager;

import com.windsor.node.plugin.common.persistence.JpaPagedList;

public class PagedListFilteredByOrgIdAndUpdatedAfter<T extends Serializable> extends JpaPagedList<T> {

    private static final String PARAMETER_ORGANIZATION_ID = "organizationId";

    private static final String PARAMETER_UPDATED_AFTER = "updatedDate";

    public PagedListFilteredByOrgIdAndUpdatedAfter(Class<T> entityClass, EntityManager em, int cacheSize, String organizationId, Date updatedAfterDate) {
        super(entityClass, em, cacheSize);
        addNamedParameter(PARAMETER_ORGANIZATION_ID, organizationId);
        addNamedParameter(PARAMETER_UPDATED_AFTER, updatedAfterDate);
    }

    @Override
    protected String getDataQuery() {
        return String.format("select x from %s x where x.organizationId = :%s and x.updatedDate >= :%s",
                getEntityClass().getSimpleName(),
                PARAMETER_ORGANIZATION_ID,
                PARAMETER_UPDATED_AFTER);
    }

    @Override
    protected String getCountQuery() {
        return String.format("select count(x) from %s x where x.organizationId = :%s and x.updatedDate >= :%s",
                getEntityClass().getSimpleName(),
                PARAMETER_ORGANIZATION_ID,
                PARAMETER_UPDATED_AFTER);
    }
}
