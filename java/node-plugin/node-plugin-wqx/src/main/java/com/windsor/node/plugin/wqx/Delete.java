package com.windsor.node.plugin.wqx;

import java.util.ArrayList;
import java.util.List;

import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.plugin.common.xml.stream.ElementWriter;
import com.windsor.node.plugin.wqx.domain.Component;
import com.windsor.node.plugin.wqx.domain.DeleteComponentIdentifier;
import com.windsor.node.plugin.wqx.domain.OperationType;
import com.windsor.node.plugin.wqx.domain.SubmissionHistory;
import com.windsor.node.plugin.wqx.domain.Header;
import com.windsor.node.plugin.wqx.domain.generated.DeleteComponentIdentifierObjectFactory;
import com.windsor.node.plugin.wqx.domain.generated.OrganizationDataType;
import com.windsor.node.plugin.wqx.service.AbstractSubmittingWqxService;
import com.windsor.node.plugin.wqx.service.ScheduleParameters;
import com.windsor.node.plugin.wqx.xml.DeleteXmlOutputStreamWriter;

public class Delete extends AbstractSubmittingWqxService<List<DeleteComponentIdentifier>, DeleteComponentIdentifier> {

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("Delete");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Reads from the WQX_DELETE staging table and prepares the data in XML format to perform the deletion of data in WQX.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(Delete.class.getCanonicalName());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
    {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    private final DeleteComponentIdentifierObjectFactory objectFactory = new DeleteComponentIdentifierObjectFactory();

    @Override
    protected ServiceType supportsServiceType() {
        return ServiceType.TASK;
    }

    @Override
    protected OperationType submissionType() {
        return OperationType.Delete;
    }

    /**
     * {@inheritDoc}
     *
     * Returns the following lists in this order:
     *
     * <ul>
     * <li>OrganizationIdentifier</li>
     * <li>ProjectIdentifier</li>
     * <li>MonitoringLocationIdentifier</li>
     * <li>ActivityIdentifier</li>
     * <li>ActivityGroupIdentifier</li>
     * <li>IndexIdentifier</li>
     * </ul>
     *
     * The list is derived from the WQX_DELETES tables. An identifier element
     * is created based on the Component column in the table.
     */
    @Override
    protected List<List<DeleteComponentIdentifier>> getSubmissionData(ScheduleParameters parameters) {

        SubmissionHistory submissionHistory = getSubmissionHistoryDao().findLatestCompleted(parameters.getOrgId(), submissionType().operation());

        OrganizationDataType org = getWqxDao().findOrganizationByOrgId(parameters.getOrgId());

        if (org == null) {
            throw new RuntimeException("Unable to locate WQX_ORGANIZATION record for Org ID {" + parameters.getOrgId() + "}");
        }

        List<List<DeleteComponentIdentifier>> uberList = new ArrayList<List<DeleteComponentIdentifier>>();

        if (parameters.getStartDate() != null) {

            if (parameters.getEndDate() != null) {

                // WQXUPDATE BETWEEN STARTDATE AND ENDDATE
                uberList.add(getWqxDao().findByOrgIdAndComponentAndUpdatedBetween(org.getDbid(), Component.Project, parameters.getStartDate(), parameters.getEndDate()));
                uberList.add(getWqxDao().findByOrgIdAndComponentAndUpdatedBetween(org.getDbid(), Component.MonitoringLocation, parameters.getStartDate(), parameters.getEndDate()));
                uberList.add(getWqxDao().findByOrgIdAndComponentAndUpdatedBetween(org.getDbid(), Component.Activity, parameters.getStartDate(), parameters.getEndDate()));
                uberList.add(getWqxDao().findByOrgIdAndComponentAndUpdatedBetween(org.getDbid(), Component.ActivityGroup, parameters.getStartDate(), parameters.getEndDate()));
                uberList.add(getWqxDao().findByOrgIdAndComponentAndUpdatedBetween(org.getDbid(), Component.BiologicalHabitatIndex, parameters.getStartDate(), parameters.getEndDate()));

            } else  {

                // WQXUPDATE AFTER STARTDATE
                uberList.add(getWqxDao().findByOrgIdAndComponentAndUpdatedAfter(org.getDbid(), Component.Project, parameters.getStartDate()));
                uberList.add(getWqxDao().findByOrgIdAndComponentAndUpdatedAfter(org.getDbid(), Component.MonitoringLocation, parameters.getStartDate()));
                uberList.add(getWqxDao().findByOrgIdAndComponentAndUpdatedAfter(org.getDbid(), Component.Activity, parameters.getStartDate()));
                uberList.add(getWqxDao().findByOrgIdAndComponentAndUpdatedAfter(org.getDbid(), Component.ActivityGroup, parameters.getStartDate()));
                uberList.add(getWqxDao().findByOrgIdAndComponentAndUpdatedAfter(org.getDbid(), Component.BiologicalHabitatIndex, parameters.getStartDate()));
            }

        } else {

            if (submissionHistory != null && submissionHistory.getWqxDateTime() != null) {

                // WQXUPDATE >= AFTER_LAST_PROCESSED
                uberList.add(getWqxDao().findByOrgIdAndComponentAndUpdatedAfter(org.getDbid(), Component.Project, submissionHistory.getWqxDateTime()));
                uberList.add(getWqxDao().findByOrgIdAndComponentAndUpdatedAfter(org.getDbid(), Component.MonitoringLocation, submissionHistory.getWqxDateTime()));
                uberList.add(getWqxDao().findByOrgIdAndComponentAndUpdatedAfter(org.getDbid(), Component.Activity, submissionHistory.getWqxDateTime()));
                uberList.add(getWqxDao().findByOrgIdAndComponentAndUpdatedAfter(org.getDbid(), Component.ActivityGroup, submissionHistory.getWqxDateTime()));
                uberList.add(getWqxDao().findByOrgIdAndComponentAndUpdatedAfter(org.getDbid(), Component.BiologicalHabitatIndex, submissionHistory.getWqxDateTime()));

            } else  {

                // ALL RECORDS BY ORG ID
                uberList.add(getWqxDao().findByOrgIdAndComponent(org.getDbid(), Component.Project));
                uberList.add(getWqxDao().findByOrgIdAndComponent(org.getDbid(), Component.MonitoringLocation));
                uberList.add(getWqxDao().findByOrgIdAndComponent(org.getDbid(), Component.Activity));
                uberList.add(getWqxDao().findByOrgIdAndComponent(org.getDbid(), Component.ActivityGroup));
                uberList.add(getWqxDao().findByOrgIdAndComponent(org.getDbid(), Component.BiologicalHabitatIndex));

            }
        }
        return uberList;
    }

    @Override
    protected void writeElement(ElementWriter writer, Object o) {

        DeleteComponentIdentifier deleteIdentifier = (DeleteComponentIdentifier) o;

        switch(deleteIdentifier.getComponentAsEnum()) {

            case Project:
                writer.write(objectFactory.createProjectIdentifier(deleteIdentifier.getIdentifier()));
                break;
            case MonitoringLocation:
                writer.write(objectFactory.createMonitoringLocationIdentifier(deleteIdentifier.getIdentifier()));
                break;
            case Activity:
                writer.write(objectFactory.createActivityIdentifier(deleteIdentifier.getIdentifier()));
                break;
            case ActivityGroup:
                writer.write(objectFactory.createActivityGroupIdentifier(deleteIdentifier.getIdentifier()));
                break;
            case BiologicalHabitatIndex:
                writer.write(objectFactory.createIndexIdentifier(deleteIdentifier.getIdentifier()));
                break;
        }
    }

    @Override
    protected ElementWriter getJaxbElementWriter(ScheduleParameters parameters, Header headerData) {
        return new DeleteXmlOutputStreamWriter(headerData, parameters.getOrgId());
    }
}
