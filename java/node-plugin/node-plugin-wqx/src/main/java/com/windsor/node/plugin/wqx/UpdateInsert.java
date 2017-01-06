package com.windsor.node.plugin.wqx;

import java.util.ArrayList;
import java.util.List;

import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.plugin.common.xml.stream.ElementWriter;
import com.windsor.node.plugin.wqx.domain.ActivityDataType;
import com.windsor.node.plugin.wqx.domain.ActivityGroupDataType;
import com.windsor.node.plugin.wqx.domain.BiologicalHabitatIndexDataType;
import com.windsor.node.plugin.wqx.domain.ElectronicAddressDataType;
import com.windsor.node.plugin.wqx.domain.Header;
import com.windsor.node.plugin.wqx.domain.MonitoringLocationDataType;
import com.windsor.node.plugin.wqx.domain.ObjectFactory;
import com.windsor.node.plugin.wqx.domain.OperationType;
import com.windsor.node.plugin.wqx.domain.OrganizationAddressDataType;
import com.windsor.node.plugin.wqx.domain.OrganizationDataType;
import com.windsor.node.plugin.wqx.domain.OrganizationDescriptionDataType;
import com.windsor.node.plugin.wqx.domain.ProjectDataType;
import com.windsor.node.plugin.wqx.domain.SubmissionHistory;
import com.windsor.node.plugin.wqx.domain.TelephonicDataType;
import com.windsor.node.plugin.wqx.service.AbstractSubmittingWqxService;
import com.windsor.node.plugin.wqx.service.ScheduleParameters;
import com.windsor.node.plugin.wqx.xml.UpdateInsertXmlOutputStreamWriter;

public class UpdateInsert extends AbstractSubmittingWqxService {

    private final ObjectFactory objectFactory = new ObjectFactory();

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("UpdateInsert");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Reads data from the WQX staging database and prepares the data in XML format for delivery for Insert/Update into WQX.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(UpdateInsert.class.getCanonicalName());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
    {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    @Override
    protected ServiceType supportsServiceType() {
        return ServiceType.TASK;
    }

    @Override
    protected OperationType submissionType() {
        return OperationType.UpdateInsert;
    }

    @Override
    protected ElementWriter getJaxbElementWriter(final ScheduleParameters scheduleParameters, final Header headerData) {
        return new UpdateInsertXmlOutputStreamWriter(headerData);
    }

    /**
     * {@inheritDoc}
     *
     * Returns the following lists in this order:
     *
     * <ul>
     *   <li>{@link OrganizationDescriptionDataType}</li>
     *   <li>{@link ElectronicAddressDataType}</li>
     *   <li>{@link TelephonicDataType}</li>
     *   <li>{@link OrganizationAddressDataType}</li>
     *   <li>{@link ProjectDataType}</li>
     *   <li>{@link MonitoringLocationDataType}</li>
     *   <li>{@link BiologicalHabitatIndexDataType}</li>
     *   <li>{@link ActivityDataType}</li>
     *   <li>{@link ActivityGroupDataType}</li>
     * </ul>
     *
     */
    @Override
    protected List<List<?>> getSubmissionData(final ScheduleParameters parameters) {

        final OrganizationDataType org = getWqxDao().findOrganizationByOrgId(parameters.getOrgId());

        if (org == null) {
            throw new RuntimeException("Unable to locate WQX_ORGANIZATION record for Org ID {" + parameters.getOrgId() + "}");
        }

        final List<List<?>> uberList = new ArrayList<List<?>>();

        /**
         * OrganizationDescriptionDataType
         */
        final List<OrganizationDescriptionDataType> description = new ArrayList<OrganizationDescriptionDataType>(1);
        description.add(org.getOrganizationDescription());
        uberList.add(description);

        /**
         * ElectronicAddressDataType
         *
         */
        uberList.add(org.getElectronicAddress());

        /**
         * TelephonicDataType
         *
         */
        uberList.add(org.getTelephonic());

        /**
         * TelephonicDataType
         *
         */
        uberList.add(org.getOrganizationAddress());

        /**
         * ProjectDataType
         * MonitoringLocationDataType
         * BiologicalHabitatIndexDataType
         * ActivityDataType
         * ActivityGroupDataType
         */
        if (parameters.getStartDate() != null) {

            if (parameters.getEndDate() != null) {

                // WQXUPDATE BETWEEN STARTDATE AND ENDDATE
                uberList.add(getWqxDao().findProjectsByOrgIdAndUpdatedBetween(org.getDbid(), parameters.getStartDate(), parameters.getEndDate()));
                uberList.add(getWqxDao().findMonitoringLocationsByOrgIdAndUpdatedBetween(org.getDbid(), parameters.getStartDate(), parameters.getEndDate()));
                uberList.add(getWqxDao().findBiologicalHabitatIndexByOrgIdAndUpdatedBetween(org.getDbid(), parameters.getStartDate(), parameters.getEndDate()));
                uberList.add(getWqxDao().findActivityByOrgIdAndUpdatedBetween(org.getDbid(), parameters.getStartDate(), parameters.getEndDate()));
                uberList.add(getWqxDao().findActivityGroupsByOrgIdAndUpdatedBetween(org.getDbid(), parameters.getStartDate(), parameters.getEndDate()));
            } else  {

                // WQXUPDATE AFTER STARTDATE
                uberList.add(getWqxDao().findProjectsByOrgIdAndUpdatedAfter(org.getDbid(), parameters.getStartDate()));
                uberList.add(getWqxDao().findMonitoringLocationsByOrgIdAndUpdatedAfter(org.getDbid(), parameters.getStartDate()));
                uberList.add(getWqxDao().findBiologicalHabitatIndexByOrgIdAndUpdatedAfter(org.getDbid(), parameters.getStartDate()));
                uberList.add(getWqxDao().findActivityByOrgIdAndUpdatedAfter(org.getDbid(), parameters.getStartDate()));
                uberList.add(getWqxDao().findActivityGroupsByOrgIdAndUpdatedAfter(org.getDbid(), parameters.getStartDate()));
            }

        } else {

            final SubmissionHistory submissionHistory = getSubmissionHistoryDao().findLatestCompleted(parameters.getOrgId(), submissionType().operation());

            if (submissionHistory != null && submissionHistory.getWqxDateTime() != null) {

                // WQXUPDATE >= AFTER_LAST_PROCESSED
                uberList.add(getWqxDao().findProjectsByOrgIdAndUpdatedAfter(org.getDbid(), submissionHistory.getWqxDateTime()));
                uberList.add(getWqxDao().findMonitoringLocationsByOrgIdAndUpdatedAfter(org.getDbid(), submissionHistory.getWqxDateTime()));
                uberList.add(getWqxDao().findBiologicalHabitatIndexByOrgIdAndUpdatedAfter(org.getDbid(), submissionHistory.getWqxDateTime()));
                uberList.add(getWqxDao().findActivityByOrgIdAndUpdatedAfter(org.getDbid(), submissionHistory.getWqxDateTime()));
                uberList.add(getWqxDao().findActivityGroupsByOrgIdAndUpdatedAfter(org.getDbid(), submissionHistory.getWqxDateTime()));

            } else  {

                // ALL RECORDS BY ORG ID
                uberList.add(getWqxDao().findProjectsByOrgId(org.getDbid()));
                uberList.add(getWqxDao().findMonitoringLocationsByOrgId(org.getDbid()));
                uberList.add(getWqxDao().findBiologicalHabitatIndexByOrgId(org.getDbid()));
                uberList.add(getWqxDao().findActivityByOrgId(org.getDbid()));
                uberList.add(getWqxDao().findActivityGroupsByOrgId(org.getDbid()));

            }
        }
        return uberList;
    }

    /**
     * Operation >> UpdateInsert
     *
     * OrganizationDescriptionDataType
     * ElectronicAddressDataType
     * TelephonicDataType
     * OrganizationAddressDataType
     * ProjectDataType
     * MonitoringLocationDataType
     * BiologicalHabitatIndexDataType
     * ActivityDataType
     * ActivityGroupDataType
     */
    @Override
    protected void writeElement(final ElementWriter writer, final Object o) {

        if (OrganizationDescriptionDataType.class.isAssignableFrom(o.getClass())) {
            writer.write( objectFactory.createOrganizationDescription((OrganizationDescriptionDataType)o));
        } else if (ElectronicAddressDataType.class.isAssignableFrom(o.getClass())) {
            writer.write( objectFactory.createElectronicAddress((ElectronicAddressDataType)o));
        } else if (TelephonicDataType.class.isAssignableFrom(o.getClass())) {
            writer.write( objectFactory.createTelephonic((TelephonicDataType)o));
        } else if (OrganizationAddressDataType.class.isAssignableFrom(o.getClass())) {
            writer.write( objectFactory.createOrganizationAddress((OrganizationAddressDataType)o));
        } else if (ProjectDataType.class.isAssignableFrom(o.getClass())) {
            writer.write( objectFactory.createProject((ProjectDataType)o));
        } else if (MonitoringLocationDataType.class.isAssignableFrom(o.getClass())) {
            writer.write( objectFactory.createMonitoringLocation((MonitoringLocationDataType)o));
        } else if (BiologicalHabitatIndexDataType.class.isAssignableFrom(o.getClass())) {
            writer.write( objectFactory.createBiologicalHabitatIndex((BiologicalHabitatIndexDataType)o));
        } else if(ActivityDataType.class.isAssignableFrom(o.getClass())) {
            writer.write( objectFactory.createActivity((ActivityDataType)o));
        } else if(ActivityGroupDataType.class.isAssignableFrom(o.getClass())) {
            writer.write( objectFactory.createActivityGroup((ActivityGroupDataType)o));
        }
    }
}
