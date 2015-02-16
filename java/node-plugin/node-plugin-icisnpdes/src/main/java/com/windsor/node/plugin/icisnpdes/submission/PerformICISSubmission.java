package com.windsor.node.plugin.icisnpdes.submission;

import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.persistence.EntityManager;

import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.plugin.icisnpdes.dao.PayloadOperationDao;
import com.windsor.node.plugin.icisnpdes.dao.jdbc.PayloadOperationDaoJdbc;
import com.windsor.node.plugin.icisnpdes.domain.PayloadOperation;
import com.windsor.node.plugin.icisnpdes.generated.BasicPermitData;
import com.windsor.node.plugin.icisnpdes.generated.BiosolidsPermitData;
import com.windsor.node.plugin.icisnpdes.generated.BiosolidsProgramReportData;
import com.windsor.node.plugin.icisnpdes.generated.CAFOAnnualReportData;
import com.windsor.node.plugin.icisnpdes.generated.CAFOPermitData;
import com.windsor.node.plugin.icisnpdes.generated.CSOEventReportData;
import com.windsor.node.plugin.icisnpdes.generated.CSOPermitData;
import com.windsor.node.plugin.icisnpdes.generated.ComplianceMonitoringData;
import com.windsor.node.plugin.icisnpdes.generated.ComplianceMonitoringLinkageData;
import com.windsor.node.plugin.icisnpdes.generated.ComplianceScheduleData;
import com.windsor.node.plugin.icisnpdes.generated.DMRProgramReportLinkageData;
import com.windsor.node.plugin.icisnpdes.generated.DMRViolationData;
import com.windsor.node.plugin.icisnpdes.generated.DischargeMonitoringReportData;
import com.windsor.node.plugin.icisnpdes.generated.EffluentTradePartnerData;
import com.windsor.node.plugin.icisnpdes.generated.EnforcementActionMilestoneData;
import com.windsor.node.plugin.icisnpdes.generated.EnforcementActionViolationLinkageData;
import com.windsor.node.plugin.icisnpdes.generated.FinalOrderViolationLinkageData;
import com.windsor.node.plugin.icisnpdes.generated.FormalEnforcementActionData;
import com.windsor.node.plugin.icisnpdes.generated.GeneralPermitData;
import com.windsor.node.plugin.icisnpdes.generated.HistoricalPermitScheduleEventsData;
import com.windsor.node.plugin.icisnpdes.generated.InformalEnforcementActionData;
import com.windsor.node.plugin.icisnpdes.generated.LimitSetData;
import com.windsor.node.plugin.icisnpdes.generated.LimitsData;
import com.windsor.node.plugin.icisnpdes.generated.LocalLimitsProgramReportData;
import com.windsor.node.plugin.icisnpdes.generated.MasterGeneralPermitData;
import com.windsor.node.plugin.icisnpdes.generated.NarrativeConditionScheduleData;
import com.windsor.node.plugin.icisnpdes.generated.ObjectFactory;
import com.windsor.node.plugin.icisnpdes.generated.OperationType;
import com.windsor.node.plugin.icisnpdes.generated.POTWPermitData;
import com.windsor.node.plugin.icisnpdes.generated.ParameterLimitsData;
import com.windsor.node.plugin.icisnpdes.generated.PayloadData;
import com.windsor.node.plugin.icisnpdes.generated.PermitReissuanceData;
import com.windsor.node.plugin.icisnpdes.generated.PermitTerminationData;
import com.windsor.node.plugin.icisnpdes.generated.PermitTrackingEventData;
import com.windsor.node.plugin.icisnpdes.generated.PermittedFeatureData;
import com.windsor.node.plugin.icisnpdes.generated.PretreatmentPerformanceSummaryData;
import com.windsor.node.plugin.icisnpdes.generated.PretreatmentPermitData;
import com.windsor.node.plugin.icisnpdes.generated.SSOAnnualReportData;
import com.windsor.node.plugin.icisnpdes.generated.SSOEventReportData;
import com.windsor.node.plugin.icisnpdes.generated.SSOMonthlyEventReportData;
import com.windsor.node.plugin.icisnpdes.generated.SWConstructionPermitData;
import com.windsor.node.plugin.icisnpdes.generated.SWEventReportData;
import com.windsor.node.plugin.icisnpdes.generated.SWIndustrialPermitData;
import com.windsor.node.plugin.icisnpdes.generated.SWMS4LargePermitData;
import com.windsor.node.plugin.icisnpdes.generated.SWMS4ProgramReportData;
import com.windsor.node.plugin.icisnpdes.generated.SWMS4SmallPermitData;
import com.windsor.node.plugin.icisnpdes.generated.ScheduleEventViolationData;
import com.windsor.node.plugin.icisnpdes.generated.SingleEventViolationData;
import com.windsor.node.plugin.icisnpdes.generated.UnpermittedFacilityData;

public class PerformICISSubmission extends AbstractIcisNpdesSubmission {

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
     * elements is determined by looking at the ICS_PAYLOAD table. Each record
     * in the table has the type of submission operation to complete. The name
     * of the operation is used to dynamically invoke a setter on
     * {@link PayloadData} instance before adding it to list.
     *
     */
    @Override
    public List<PayloadData> createAllPayloads(ProcessContentResult result, EntityManager em) {

        log("Creating new list for <Payload>", "");

        List<PayloadData> allPayloads = new ArrayList<PayloadData>();

        PayloadsCountMessage countMessage = new PayloadsCountMessage();;

        /**
         * Instantiate a new DAO to lookup ICS_PAYLOAD records.
         */
        PayloadOperationDao payloadOperationDao = new PayloadOperationDaoJdbc(getDataSource());

        List<PayloadOperation> dbConfiguredOperationsToSubmit = payloadOperationDao.findPayloadsToSubmit();

        log("Found {} operations to submit to ICIS.", dbConfiguredOperationsToSubmit.size());

        /**
         * Iterate over the list ICS_PAYLOAD records.
         */
        for (PayloadOperation op : dbConfiguredOperationsToSubmit) {

            log("...Starting the {} operation", op.getOperationType());

            PayloadData payloadData = new ObjectFactory().createPayloadData();

            /**
             * Look up the @Entity class that holds the payload operation data.
             * The class definition will drive the rest of the flow in this
             * loop.
             */
            Class<?> klass = payloadOperationTypeJpaEntityMap().get(op.getOperationType());

            if (klass != null) {

                String klassName = klass.getSimpleName();

                log("...Found the {} class for operation {}", klassName, op.getOperationType());

                /**
                 * Use the class name to create a JPQL select statement and then
                 * get the results.
                 */
                final List<?> list = em.createQuery("select ls from " + klassName + " ls where ls.transactionHeader.transactionType is not null")
                                .getResultList();

                log("...Found {} records in the database.", list.size());

                countMessage.addCount(op.getOperationType().value(), list.size());

                if (list.size() > 0 ) {

                    /**
                     * Set the type operation to send to ICIS. Only set if there are records for this operation.
                     */
                    payloadData.setOperation(op.getOperationType());

                    String methodName = "set" + klassName;

                    for(Method method : PayloadData.class.getMethods()) {

                        if (method.getName().equals(methodName)) {

                            log(".....invoking " + methodName);

                            try {
                                method.invoke(payloadData, list);
                            } catch (Exception e) {
                                error("Unable to invoke the method {}", method.getName());
                            }
                        }
                    }
                    allPayloads.add(payloadData);
                }
            } else {
                log("....did not find an @Entity class for {} operation.", op.getOperationType());
            }
        }

        debug(result, countMessage.formatAsActivityEntry());

        return allPayloads;
    }

    /**
     * Holds the count for payload operation type, will also return a format
     * message to use as an {@link ActivityEntry}.
     *
     */
    private class PayloadsCountMessage {

        private final List<String> payloadsCounts = new ArrayList<String>();

        public void addCount(String operationTypeName, int count) {
            payloadsCounts.add(operationTypeName + " (" + count + ")");
        }

        public String formatAsActivityEntry() {

            StringBuilder sb = new StringBuilder(
                    "The following ICIS payload(s) were loaded from the database: ");

            if (!payloadsCounts.isEmpty()) {

                /**
                 * Iterate over each item in the list and append to
                 * StringBuilder.
                 */
                for (String s : this.payloadsCounts) {
                    sb.append(s + ", ");
                }

                /**
                 * Remove the last comma.
                 */
                sb.delete(sb.lastIndexOf(", "), sb.length());

            } else {
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
    private Map<OperationType, Class<?>> payloadOperationTypeJpaEntityMap() {
        Map<OperationType, Class<?>> map = new HashMap<OperationType, Class<?>>();
        map.put(OperationType.BASIC_PERMIT_SUBMISSION, BasicPermitData.class);
        map.put(OperationType.BIOSOLIDS_PERMIT_SUBMISSION, BiosolidsPermitData.class);
        map.put(OperationType.BIOSOLIDS_PROGRAM_REPORT_SUBMISSION, BiosolidsProgramReportData.class);
        map.put(OperationType.CAFO_ANNUAL_REPORT_SUBMISSION, CAFOAnnualReportData.class);
        map.put(OperationType.CAFO_PERMIT_SUBMISSION, CAFOPermitData.class);
        map.put(OperationType.COMPLIANCE_MONITORING_SUBMISSION, ComplianceMonitoringData.class);
        map.put(OperationType.COMPLIANCE_MONITORING_LINKAGE_SUBMISSION, ComplianceMonitoringLinkageData.class);
        map.put(OperationType.COMPLIANCE_SCHEDULE_SUBMISSION, ComplianceScheduleData.class);
        map.put(OperationType.CSO_EVENT_REPORT_SUBMISSION, CSOEventReportData.class);
        map.put(OperationType.CSO_PERMIT_SUBMISSION, CSOPermitData.class);
        map.put(OperationType.DISCHARGE_MONITORING_REPORT_SUBMISSION, DischargeMonitoringReportData.class);
        map.put(OperationType.DMR_PROGRAM_REPORT_LINKAGE_SUBMISSION, DMRProgramReportLinkageData.class);
        map.put(OperationType.DMR_VIOLATION_SUBMISSION, DMRViolationData.class);
        map.put(OperationType.EFFLUENT_TRADE_PARTNER_SUBMISSION, EffluentTradePartnerData.class);
        map.put(OperationType.ENFORCEMENT_ACTION_MILESTONE_SUBMISSION, EnforcementActionMilestoneData.class);
        map.put(OperationType.ENFORCEMENT_ACTION_VIOLATION_LINKAGE_SUBMISSION, EnforcementActionViolationLinkageData.class);
        //map.put(OperationType.FEDERAL_COMPLIANCE_MONITORING_SUBMISSION, .class);
        map.put(OperationType.FINAL_ORDER_VIOLATION_LINKAGE_SUBMISSION, FinalOrderViolationLinkageData.class);
        map.put(OperationType.FORMAL_ENFORCEMENT_ACTION_SUBMISSION, FormalEnforcementActionData.class);
        map.put(OperationType.GENERAL_PERMIT_SUBMISSION, GeneralPermitData.class);
        map.put(OperationType.HISTORICAL_PERMIT_SCHEDULE_EVENTS_SUBMISSION, HistoricalPermitScheduleEventsData.class);
        map.put(OperationType.INFORMAL_ENFORCEMENT_ACTION_SUBMISSION, InformalEnforcementActionData.class);
        map.put(OperationType.LIMIT_SET_SUBMISSION, LimitSetData.class);
        map.put(OperationType.LIMITS_SUBMISSION, LimitsData.class);
        map.put(OperationType.LOCAL_LIMITS_PROGRAM_REPORT_SUBMISSION, LocalLimitsProgramReportData.class);
        map.put(OperationType.MASTER_GENERAL_PERMIT_SUBMISSION, MasterGeneralPermitData.class);
        map.put(OperationType.NARRATIVE_CONDITION_SCHEDULE_SUBMISSION, NarrativeConditionScheduleData.class);
        map.put(OperationType.PARAMETER_LIMITS_SUBMISSION, ParameterLimitsData.class);
        map.put(OperationType.PERMIT_REISSUANCE_SUBMISSION, PermitReissuanceData.class);
        map.put(OperationType.PERMITTED_FEATURE_SUBMISSION, PermittedFeatureData.class);
        map.put(OperationType.PERMIT_TERMINATION_SUBMISSION, PermitTerminationData.class);
        map.put(OperationType.PERMIT_TRACKING_EVENT_SUBMISSION, PermitTrackingEventData.class);
        map.put(OperationType.PRETREATMENT_PERMIT_SUBMISSION, PretreatmentPermitData.class);
        map.put(OperationType.PRETREATMENT_PERFORMANCE_SUMMARY_SUBMISSION, PretreatmentPerformanceSummaryData.class);
        map.put(OperationType.SCHEDULE_EVENT_VIOLATION_SUBMISSION, ScheduleEventViolationData.class);
        map.put(OperationType.SINGLE_EVENT_VIOLATION_SUBMISSION, SingleEventViolationData.class);
        map.put(OperationType.SSO_ANNUAL_REPORT_SUBMISSION, SSOAnnualReportData.class);
        map.put(OperationType.SSO_EVENT_REPORT_SUBMISSION, SSOEventReportData.class);
        map.put(OperationType.SSO_MONTHLY_EVENT_REPORT_SUBMISSION, SSOMonthlyEventReportData.class);
        map.put(OperationType.POTW_PERMIT_SUBMISSION, POTWPermitData.class);
        map.put(OperationType.SW_CONSTRUCTION_PERMIT_SUBMISSION, SWConstructionPermitData.class);
        map.put(OperationType.SW_EVENT_REPORT_SUBMISSION, SWEventReportData.class);
        map.put(OperationType.SW_INDUSTRIAL_PERMIT_SUBMISSION, SWIndustrialPermitData.class);
        map.put(OperationType.SWMS_4_LARGE_PERMIT_SUBMISSION, SWMS4LargePermitData.class);
        map.put(OperationType.SWMS_4_PROGRAM_REPORT_SUBMISSION, SWMS4ProgramReportData.class);
        map.put(OperationType.SWMS_4_SMALL_PERMIT_SUBMISSION, SWMS4SmallPermitData.class);
        map.put(OperationType.UNPERMITTED_FACILITY_SUBMISSION, UnpermittedFacilityData.class);
        return map;
    }

    /**
     * A convenience debug method, implementation can be changed in one place.
     *
     * @param format A formatted string, eg. log("Successfully found {}.", arg)
     * @param args The arguments for the string message
     */
    private void log(String format, Object... args) {
        if (logger.isDebugEnabled()) {
            logger.debug(format, args);
        }
    }

    /**
     * A convenience error method, implementation can be changed in one place.
     *
     * @param format A formatted string, eg. log("Successfully found {}.", arg)
     * @param args The arguments for the string message
     */
    private void error(String format, Object... args) {
        logger.error(format, args);
    }
}
