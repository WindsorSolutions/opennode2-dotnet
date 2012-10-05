package com.windsor.node.plugin.wqx.dao;

import java.io.Serializable;

import javax.persistence.EntityManager;

import com.windsor.node.plugin.common.persistence.JpaPagedList;

public class PagedListFilteredByOrgId<T extends Serializable> extends JpaPagedList<T> {

    private static final String PARAMETER_ORGANIZATION_ID = "organizationId";

    public PagedListFilteredByOrgId(Class<T> entityClass, EntityManager em, int cacheSize, String organizationId) {
        super(entityClass, em, cacheSize);
        addNamedParameter(PARAMETER_ORGANIZATION_ID, organizationId);
    }

    @Override
    protected String getDataQuery() {
        return String.format("select x from %s x where x.organizationId = :%s", getEntityClass().getSimpleName(), PARAMETER_ORGANIZATION_ID);
    }

    @Override
    protected String getCountQuery() {
        return String.format("select count(x) from %s x where x.organizationId = :%s", getEntityClass().getSimpleName(), PARAMETER_ORGANIZATION_ID);
    }
}
