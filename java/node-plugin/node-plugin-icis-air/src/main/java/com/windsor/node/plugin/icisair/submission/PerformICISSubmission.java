package com.windsor.node.plugin.icisair.submission;

import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.persistence.EntityManager;

import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.plugin.icisair.dao.PayloadOperationDao;
import com.windsor.node.plugin.icisair.dao.jdbc.PayloadOperationDaoJdbc;
import com.windsor.node.plugin.icisair.domain.PayloadOperation;
import com.windsor.node.plugin.icisair.domain.generated.AirComplianceMonitoringStrategyData;
import com.windsor.node.plugin.icisair.domain.generated.AirDACaseFileData;
import com.windsor.node.plugin.icisair.domain.generated.AirDAComplianceMonitoringData;
import com.windsor.node.plugin.icisair.domain.generated.AirDAEnforcementActionLinkageData;
import com.windsor.node.plugin.icisair.domain.generated.AirDAEnforcementActionMilestoneData;
import com.windsor.node.plugin.icisair.domain.generated.AirDAFormalEnforcementActionData;
import com.windsor.node.plugin.icisair.domain.generated.AirDAInformalEnforcementActionData;
import com.windsor.node.plugin.icisair.domain.generated.AirFacilityData;
import com.windsor.node.plugin.icisair.domain.generated.AirPollutantsData;
import com.windsor.node.plugin.icisair.domain.generated.AirProgramsData;
import com.windsor.node.plugin.icisair.domain.generated.AirTVACCData;
import com.windsor.node.plugin.icisair.domain.generated.CaseFileLinkageData;
import com.windsor.node.plugin.icisair.domain.generated.ComplianceMonitoringLinkageData;
import com.windsor.node.plugin.icisair.domain.generated.ObjectFactory;
import com.windsor.node.plugin.icisair.domain.generated.OperationType;
import com.windsor.node.plugin.icisair.domain.generated.PayloadData;

public class PerformICISSubmission extends AbstractIcisAirSubmission
{

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("PerformICISSubmission");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Perform submission of the various ICIS payloads.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(PerformICISSubmission.class.getCanonicalName());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
    {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    /**
     * Returns a {@link List} of {@link PayloadData} objects. The list of
     * elements is determined by looking at the ICA_PAYLOAD table. Each record
     * in the table has the type of submission operation to complete. The name
     * of the operation is used to dynamically invoke a setter on
     * {@link PayloadData} instance before adding it to list.
     * 
     */
    @Override
    public List<PayloadData> createAllPayloads(ProcessContentResult result, EntityManager em)
    {

        logger.debug("Creating new list for <Payload>", "");

        List<PayloadData> allPayloads = new ArrayList<PayloadData>();

        PayloadsCountMessage countMessage = new PayloadsCountMessage();

        /**
         * Instantiate a new DAO to lookup ICA_PAYLOAD records.
         */
        PayloadOperationDao payloadOperationDao = new PayloadOperationDaoJdbc(getDataSource());

        List<PayloadOperation> dbConfiguredOperationsToSubmit = payloadOperationDao.findPayloadsToSubmit();

        logger.debug("Found {} operations to submit to ICIS.", dbConfiguredOperationsToSubmit.size());

        /**
         * Iterate over the list ICA_PAYLOAD records.
         */
        for (PayloadOperation op : dbConfiguredOperationsToSubmit)
        {

            logger.debug("...Starting the {} operation", op.getOperationType());

            PayloadData payloadData = new ObjectFactory().createPayloadData();

            /**
             * Look up the @Entity class that holds the payload operation data.
             * The class definition will drive the rest of the flow in this
             * loop.
             */
            Class<?> klass = payloadOperationTypeJpaEntityMap().get(op.getOperationType());

            if(klass != null)
            {

                String klassName = klass.getSimpleName();

                logger.debug("...Found the {} class for operation {}", klassName, op.getOperationType());

                /**
                 * Use the class name to create a JPQL select statement and then
                 * get the results.
                 */
                logger.debug("...Executing select: select ls from " + klassName + " ls where ls.transactionHeader.transactionType is not null");
                final List<?> list = em.createQuery("select ls from " + klassName + " ls where ls.transactionHeader.transactionType is not null")
                                .getResultList();

                logger.debug("...Found {} records in the database.", list.size());

                countMessage.addCount(op.getOperationType().value(), list.size());

                if(list.size() > 0)
                {

                    /**
                     * Set the type operation to send to ICIS. Only set if there
                     * are records for this operation.
                     */
                    payloadData.setOperation(op.getOperationType());

                    String methodName = "set" + klassName;

                    for (Method method : PayloadData.class.getMethods())
                    {

                        if(method.getName().equals(methodName))
                        {

                            logger.debug(".....invoking " + methodName);

                            try
                            {
                                method.invoke(payloadData, list);
                            }
                            catch(Exception e)
                            {
                                error("Unable to invoke the method {}", method.getName());
                            }
                        }
                    }
                    allPayloads.add(payloadData);
                }
            }
            else
            {
                logger.debug("....did not find an @Entity class for {} operation.", op.getOperationType());
            }
        }

        addActivityEntry(result, countMessage.formatAsActivityEntry());

        return allPayloads;
    }

    /**
     * Holds the count for payload operation type, will also return a format
     * message to use as an {@link ActivityEntry}.
     * 
     */
    private class PayloadsCountMessage
    {

        private final List<String> payloadsCounts = new ArrayList<String>();

        public void addCount(String operationTypeName, int count)
        {
            payloadsCounts.add(operationTypeName + " (" + count + ")");
        }

        public String formatAsActivityEntry()
        {

            StringBuilder sb = new StringBuilder("The following ICIS-Air payload(s) were loaded from the database: ");

            if(!payloadsCounts.isEmpty())
            {

                /**
                 * Iterate over each item in the list and append to
                 * StringBuilder.
                 */
                for (String s : this.payloadsCounts)
                {
                    sb.append(s + ", ");
                }

                /**
                 * Remove the last comma.
                 */
                sb.delete(sb.lastIndexOf(", "), sb.length());

            }
            else
            {
                sb.append("No payloads were found.");
            }

            return sb.toString();
        }
    }

    /**
     * Returns a map of Classes keyed on {@link OperationType}. Used to look up
     * the class to hold the the payload data originating from the database and
     * then eventually serialized to XML via JAXB. The operation type is known
     * by a lookup to the ICIS_PAYLOAD table.
     * 
     * @return Map
     */
    private Map<OperationType, Class<?>> payloadOperationTypeJpaEntityMap()
    {
        Map<OperationType, Class<?>> map = new HashMap<OperationType, Class<?>>();
        map.put(OperationType.AIR_COMPLIANCE_MONITORING_STRATEGY_SUBMISSION, AirComplianceMonitoringStrategyData.class);

        map.put(OperationType.CASE_FILE_LINKAGE_SUBMISSION, CaseFileLinkageData.class);

        map.put(OperationType.AIR_DA_CASE_FILE_SUBMISSION, AirDACaseFileData.class);
        map.put(OperationType.AIR_DA_COMPLIANCE_MONITORING_SUBMISSION, AirDAComplianceMonitoringData.class);
        map.put(OperationType.AIR_DA_ENFORCEMENT_ACTION_MILESTONE_SUBMISSION, AirDAEnforcementActionMilestoneData.class);
         
        map.put(OperationType.AIR_DA_ENFORCEMENT_ACTION_LINKAGE_SUBMISSION, AirDAEnforcementActionLinkageData.class);

        map.put(OperationType.AIR_DA_FORMAL_ENFORCEMENT_ACTION_SUBMISSION, AirDAFormalEnforcementActionData.class);
        map.put(OperationType.AIR_DA_INFORMAL_ENFORCEMENT_ACTION_SUBMISSION, AirDAInformalEnforcementActionData.class);
        map.put(OperationType.AIR_FACILITY_SUBMISSION, AirFacilityData.class);
        map.put(OperationType.AIR_POLLUTANTS_SUBMISSION, AirPollutantsData.class);
        map.put(OperationType.AIR_PROGRAMS_SUBMISSION, AirProgramsData.class);
        map.put(OperationType.AIR_TVACC_SUBMISSION, AirTVACCData.class);

        map.put(OperationType.COMPLIANCE_MONITORING_LINKAGE_SUBMISSION, ComplianceMonitoringLinkageData.class);

        return map;
    }

    /**
     * A convenience error method, implementation can be changed in one place.
     * 
     * @param format
     *            A formatted string, eg. log("Successfully found {}.", arg)
     * @param args
     *            The arguments for the string message
     */
    private void error(String format, Object... args)
    {
        logger.error(format, args);
    }
}
