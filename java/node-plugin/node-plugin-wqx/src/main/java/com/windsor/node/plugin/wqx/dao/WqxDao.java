package com.windsor.node.plugin.wqx.dao;

import java.util.Date;
import java.util.List;

import com.windsor.node.plugin.wqx.domain.ActivityDataType;
import com.windsor.node.plugin.wqx.domain.ActivityGroupDataType;
import com.windsor.node.plugin.wqx.domain.BiologicalHabitatIndexDataType;
import com.windsor.node.plugin.wqx.domain.Component;
import com.windsor.node.plugin.wqx.domain.DeleteComponentIdentifier;
import com.windsor.node.plugin.wqx.domain.MonitoringLocationDataType;
import com.windsor.node.plugin.wqx.domain.OrganizationDataType;
import com.windsor.node.plugin.wqx.domain.ProjectDataType;

public interface WqxDao {

    OrganizationDataType findOrganizationByOrgId(String orgId) throws OrganizationNotFoundException;

    List<ProjectDataType> findProjectsByOrgId(String orgId);

    List<ProjectDataType> findProjectsByOrgIdAndUpdatedBetween(String orgId, Date start, Date end);

    List<ProjectDataType> findProjectsByOrgIdAndUpdatedAfter(String orgId, Date after);

    List<MonitoringLocationDataType> findMonitoringLocationsByOrgId(String orgId);

    List<MonitoringLocationDataType> findMonitoringLocationsByOrgIdAndUpdatedBetween(String orgId, Date start, Date end);

    List<MonitoringLocationDataType> findMonitoringLocationsByOrgIdAndUpdatedAfter(String orgId, Date after);

    List<BiologicalHabitatIndexDataType> findBiologicalHabitatIndexByOrgId(String orgId);

    List<BiologicalHabitatIndexDataType> findBiologicalHabitatIndexByOrgIdAndUpdatedBetween(String orgId, Date start, Date end);

    List<BiologicalHabitatIndexDataType> findBiologicalHabitatIndexByOrgIdAndUpdatedAfter(String orgId, Date after);

    List<ActivityDataType> findActivityByOrgId(String orgId);

    List<ActivityDataType> findActivityByOrgIdAndUpdatedBetween(String orgId, Date start, Date end);

    List<ActivityDataType> findActivityByOrgIdAndUpdatedAfter(String orgId, Date after);

    List<ActivityGroupDataType> findActivityGroupsByOrgId(String orgId);

    List<ActivityGroupDataType> findActivityGroupsByOrgIdAndUpdatedBetween(String orgId, Date start, Date end);

    List<ActivityGroupDataType> findActivityGroupsByOrgIdAndUpdatedAfter(String orgId, Date after);

    List<DeleteComponentIdentifier> findByOrgIdAndComponentAndUpdatedBetween(String orgId, Component component, Date start, Date end);

    List<DeleteComponentIdentifier> findByOrgIdAndComponentAndUpdatedAfter(String orgId, Component component, Date after);

    List<DeleteComponentIdentifier> findByOrgIdAndComponent(String orgId, Component component);

}
