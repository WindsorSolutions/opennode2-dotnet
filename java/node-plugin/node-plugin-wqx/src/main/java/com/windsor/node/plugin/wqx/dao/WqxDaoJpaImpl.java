package com.windsor.node.plugin.wqx.dao;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.NoResultException;
import javax.persistence.Query;

import com.windsor.node.plugin.wqx.domain.ActivityDataType;
import com.windsor.node.plugin.wqx.domain.ActivityGroupDataType;
import com.windsor.node.plugin.wqx.domain.BiologicalHabitatIndexDataType;
import com.windsor.node.plugin.wqx.domain.Component;
import com.windsor.node.plugin.wqx.domain.DeleteComponentIdentifier;
import com.windsor.node.plugin.wqx.domain.MonitoringLocationDataType;
import com.windsor.node.plugin.wqx.domain.OrganizationDataType;
import com.windsor.node.plugin.wqx.domain.ProjectDataType;

public class WqxDaoJpaImpl implements WqxDao {

    private static final int DEFAULT_CACHE_SIZE = 1000;

    private final EntityManager em;

    public WqxDaoJpaImpl(EntityManager em) {
        this.em = em;
    }

    @Override
    public OrganizationDataType findOrganizationByOrgId(String orgId) throws OrganizationNotFoundException {
        Query q = em.createQuery("select org from com.windsor.node.plugin.wqx.domain.OrganizationDataType org where org.organizationDescription.organizationIdentifier = :orgId");
        q.setParameter("orgId", orgId);

        try {
            return (OrganizationDataType) q.getSingleResult();
        } catch (NoResultException e) {
            throw new OrganizationNotFoundException(String.format("Unable to find Organization for id \"%s\".", orgId));
        }
    }

    @Override
    public List<ProjectDataType> findProjectsByOrgId(String orgId) {
        return new PagedListFilteredByOrgId<ProjectDataType>(ProjectDataType.class, em, DEFAULT_CACHE_SIZE, orgId);
    }

    @Override
    public List<ProjectDataType> findProjectsByOrgIdAndUpdatedBetween(String orgId, Date start, Date end) {
        return new PagedListFilteredByOrgIdAndUpdatedBetween<ProjectDataType>(ProjectDataType.class, em, DEFAULT_CACHE_SIZE, orgId, start, end);
    }

    @Override
    public List<ProjectDataType> findProjectsByOrgIdAndUpdatedAfter(String orgId, Date after) {
        return new PagedListFilteredByOrgIdAndUpdatedAfter<ProjectDataType>(ProjectDataType.class, em, DEFAULT_CACHE_SIZE, orgId, after);
    }

    @Override
    public List<MonitoringLocationDataType> findMonitoringLocationsByOrgId(String orgId) {
        return new PagedListFilteredByOrgId<MonitoringLocationDataType>(MonitoringLocationDataType.class, em, DEFAULT_CACHE_SIZE, orgId);
    }

    @Override
    public List<MonitoringLocationDataType> findMonitoringLocationsByOrgIdAndUpdatedBetween(String orgId, Date start, Date end) {
        return new PagedListFilteredByOrgIdAndUpdatedBetween<MonitoringLocationDataType>(MonitoringLocationDataType.class, em, DEFAULT_CACHE_SIZE, orgId, start, end);
    }

    @Override
    public List<MonitoringLocationDataType> findMonitoringLocationsByOrgIdAndUpdatedAfter(String orgId, Date after) {
        return new PagedListFilteredByOrgIdAndUpdatedAfter<MonitoringLocationDataType>(MonitoringLocationDataType.class, em, DEFAULT_CACHE_SIZE, orgId, after);
    }

    @Override
    public List<BiologicalHabitatIndexDataType> findBiologicalHabitatIndexByOrgId(String orgId) {
        return new PagedListFilteredByOrgId<BiologicalHabitatIndexDataType>(BiologicalHabitatIndexDataType.class, em, DEFAULT_CACHE_SIZE, orgId);
    }

    @Override
    public List<BiologicalHabitatIndexDataType> findBiologicalHabitatIndexByOrgIdAndUpdatedBetween(String orgId, Date start, Date end) {
        return new PagedListFilteredByOrgIdAndUpdatedBetween<BiologicalHabitatIndexDataType>(BiologicalHabitatIndexDataType.class, em, DEFAULT_CACHE_SIZE, orgId, start, end);
    }

    @Override
    public List<BiologicalHabitatIndexDataType> findBiologicalHabitatIndexByOrgIdAndUpdatedAfter(String orgId, Date after) {
        return new PagedListFilteredByOrgIdAndUpdatedAfter<BiologicalHabitatIndexDataType>(BiologicalHabitatIndexDataType.class, em, DEFAULT_CACHE_SIZE, orgId, after);
    }

    @Override
    public List<ActivityDataType> findActivityByOrgId(String orgId) {
        return new PagedListFilteredByOrgId<ActivityDataType>(ActivityDataType.class, em, DEFAULT_CACHE_SIZE, orgId);
    }

    @Override
    public List<ActivityDataType> findActivityByOrgIdAndUpdatedBetween(String orgId, Date start, Date end) {
        return new PagedListFilteredByOrgIdAndUpdatedBetween<ActivityDataType>(ActivityDataType.class, em, DEFAULT_CACHE_SIZE, orgId, start, end);
    }

    @Override
    public List<ActivityDataType> findActivityByOrgIdAndUpdatedAfter(String orgId, Date after) {
        return new PagedListFilteredByOrgIdAndUpdatedAfter<ActivityDataType>(ActivityDataType.class, em, DEFAULT_CACHE_SIZE, orgId, after);
    }

    @Override
    public List<ActivityGroupDataType> findActivityGroupsByOrgId(String orgId) {
        return new PagedListFilteredByOrgId<ActivityGroupDataType>(ActivityGroupDataType.class, em, DEFAULT_CACHE_SIZE, orgId);
    }

    @Override
    public List<ActivityGroupDataType> findActivityGroupsByOrgIdAndUpdatedBetween(String orgId, Date start, Date end) {
        return new PagedListFilteredByOrgIdAndUpdatedBetween<ActivityGroupDataType>(ActivityGroupDataType.class, em, DEFAULT_CACHE_SIZE, orgId, start, end);
    }

    @Override
    public List<ActivityGroupDataType> findActivityGroupsByOrgIdAndUpdatedAfter(String orgId, Date after) {
        return new PagedListFilteredByOrgIdAndUpdatedAfter<ActivityGroupDataType>(ActivityGroupDataType.class, em, DEFAULT_CACHE_SIZE, orgId, after);
    }

    // Delete Service

    @Override
    public List<DeleteComponentIdentifier> findByOrgIdAndComponentAndUpdatedBetween(String orgId, Component component, Date start, Date end) {
        Query q = em.createQuery("select x from com.windsor.node.plugin.wqx.domain.DeleteComponentIdentifier x where x.organizationId = :orgId and x.component = :component and x.updatedDate between :start and :end");
        q.setParameter("orgId", orgId);
        q.setParameter("component", component.componentName());
        q.setParameter("start", start);
        q.setParameter("end", end);
        return q.getResultList();
    }

    /**
     * TODO Fix implementation to set query parameters correctly
     */
    @Override
    public List<DeleteComponentIdentifier> findByOrgIdAndComponentAndUpdatedAfter(String orgId, Component component, Date after) {
        Query q = em.createQuery("select x from com.windsor.node.plugin.wqx.domain.DeleteComponentIdentifier x where x.organizationId = :orgId and x.component = :component and x.updatedDate >= :updatedDate");
        q.setParameter("orgId", orgId);
        q.setParameter("component", component.componentName());
        q.setParameter("updatedDate", after);
        return q.getResultList();
    }

    /**
     * TODO Fix implementation to set query parameters correctly
     */
    @Override
    public List<DeleteComponentIdentifier> findByOrgIdAndComponent(String orgId, Component component) {
        Query q = em.createQuery("select x from com.windsor.node.plugin.wqx.domain.DeleteComponentIdentifier x where x.organizationId = :orgId and x.component = :component");
        q.setParameter("orgId", orgId);
        q.setParameter("component", component.componentName());
        return q.getResultList();
    }
}
