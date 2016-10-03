package com.windsor.node.plugin.icisnpdes;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.OutputStreamWriter;
import java.io.Writer;
import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.xml.XMLConstants;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.Marshaller;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;

import org.testng.Assert;

import com.windsor.node.plugin.common.xml.validation.ValidationResult;
import com.windsor.node.plugin.common.xml.validation.jaxb.JaxbXmlValidator;
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
import com.windsor.node.plugin.icisnpdes.generated.Document;
import com.windsor.node.plugin.icisnpdes.generated.EffluentTradePartnerData;
import com.windsor.node.plugin.icisnpdes.generated.EnforcementActionMilestoneData;
import com.windsor.node.plugin.icisnpdes.generated.EnforcementActionViolationLinkageData;
import com.windsor.node.plugin.icisnpdes.generated.FinalOrderViolationLinkageData;
import com.windsor.node.plugin.icisnpdes.generated.FormalEnforcementActionData;
import com.windsor.node.plugin.icisnpdes.generated.GeneralPermitData;
import com.windsor.node.plugin.icisnpdes.generated.HeaderData;
import com.windsor.node.plugin.icisnpdes.generated.HistoricalPermitScheduleEventsData;
import com.windsor.node.plugin.icisnpdes.generated.InformalEnforcementActionData;
//import com.windsor.node.plugin.icisnpdes.generated.LimitSetData;
//import com.windsor.node.plugin.icisnpdes.generated.LimitsData;
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
import com.windsor.node.plugin.test.AbstractExistingDbIT;

public class IcisNpdesExistingDatabaseIT //extends AbstractExistingDbIT
{

    //FIXME replace with non-IT test
	/*private static final String SCHEMA_ROOT_PATH = SCHEMA_DIR + "/index.xsd";

	@Override
	protected String getRootEntityPackage() {
		return "com.windsor.node.plugin.icisnpdes.generated";
	}

	private Map<OperationType, Class<?>> payloadOperationTypeJpaEntityMap() {
		final Map<OperationType, Class<?>> map = new HashMap<OperationType, Class<?>>();
		map.put(OperationType.BASIC_PERMIT_SUBMISSION, BasicPermitData.class);
		map.put(OperationType.BIOSOLIDS_PERMIT_SUBMISSION, BiosolidsPermitData.class);
		map.put(OperationType.BIOSOLIDS_PROGRAM_REPORT_SUBMISSION, BiosolidsProgramReportData.class);
		map.put(OperationType.CAFO_ANNUAL_REPORT_SUBMISSION, CAFOAnnualReportData.class);
		map.put(OperationType.CAFO_PERMIT_SUBMISSION, CAFOPermitData.class);
		map.put(OperationType.COMPLIANCE_MONITORING_SUBMISSION, ComplianceMonitoringData.class);
		map.put(OperationType.COMPLIANCE_MONITORING_LINKAGE_SUBMISSION,
				ComplianceMonitoringLinkageData.class);
		map.put(OperationType.COMPLIANCE_SCHEDULE_SUBMISSION, ComplianceScheduleData.class);
		map.put(OperationType.CSO_EVENT_REPORT_SUBMISSION, CSOEventReportData.class);
		map.put(OperationType.CSO_PERMIT_SUBMISSION, CSOPermitData.class);
		map.put(OperationType.DISCHARGE_MONITORING_REPORT_SUBMISSION,
				DischargeMonitoringReportData.class);
		map.put(OperationType.DMR_PROGRAM_REPORT_LINKAGE_SUBMISSION,
				DMRProgramReportLinkageData.class);
		map.put(OperationType.DMR_VIOLATION_SUBMISSION, DMRViolationData.class);
		map.put(OperationType.EFFLUENT_TRADE_PARTNER_SUBMISSION, EffluentTradePartnerData.class);
		map.put(OperationType.ENFORCEMENT_ACTION_MILESTONE_SUBMISSION,
				EnforcementActionMilestoneData.class);
		map.put(OperationType.ENFORCEMENT_ACTION_VIOLATION_LINKAGE_SUBMISSION,
				EnforcementActionViolationLinkageData.class);
		map.put(OperationType.FINAL_ORDER_VIOLATION_LINKAGE_SUBMISSION,
				FinalOrderViolationLinkageData.class);
		map.put(OperationType.FORMAL_ENFORCEMENT_ACTION_SUBMISSION,
				FormalEnforcementActionData.class);
		map.put(OperationType.GENERAL_PERMIT_SUBMISSION, GeneralPermitData.class);
		map.put(OperationType.HISTORICAL_PERMIT_SCHEDULE_EVENTS_SUBMISSION,
				HistoricalPermitScheduleEventsData.class);
		map.put(OperationType.INFORMAL_ENFORCEMENT_ACTION_SUBMISSION,
				InformalEnforcementActionData.class);
		map.put(OperationType.LIMIT_SET_SUBMISSION, LimitSetData.class);
		map.put(OperationType.LIMITS_SUBMISSION, LimitsData.class);
		map.put(OperationType.LOCAL_LIMITS_PROGRAM_REPORT_SUBMISSION,
				LocalLimitsProgramReportData.class);
		map.put(OperationType.MASTER_GENERAL_PERMIT_SUBMISSION, MasterGeneralPermitData.class);
		map.put(OperationType.NARRATIVE_CONDITION_SCHEDULE_SUBMISSION,
				NarrativeConditionScheduleData.class);
		map.put(OperationType.PARAMETER_LIMITS_SUBMISSION, ParameterLimitsData.class);
		map.put(OperationType.PERMIT_REISSUANCE_SUBMISSION, PermitReissuanceData.class);
		map.put(OperationType.PERMITTED_FEATURE_SUBMISSION, PermittedFeatureData.class);
		map.put(OperationType.PERMIT_TERMINATION_SUBMISSION, PermitTerminationData.class);
		map.put(OperationType.PERMIT_TRACKING_EVENT_SUBMISSION, PermitTrackingEventData.class);
		map.put(OperationType.PRETREATMENT_PERMIT_SUBMISSION, PretreatmentPermitData.class);
		map.put(OperationType.PRETREATMENT_PERFORMANCE_SUMMARY_SUBMISSION,
				PretreatmentPerformanceSummaryData.class);
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

	public void test2() throws Exception {
		final List<PayloadData> allPayloads = new ArrayList<PayloadData>();

		final ObjectFactory factory = new ObjectFactory();
		final HeaderData header = factory.createHeaderData();
		final Document document = factory.createDocument();
		document.setHeader(header);
		header.setAuthor("Author");
		header.setComment("Comment");
		header.setContactInfo("Contact Info");
		header.setCreationTime(new Date());
		header.setDataService("Data Service");
		header.setId("My Id");
		header.setTitle("Title");

		for (final Map.Entry<OperationType, Class<?>> entry : payloadOperationTypeJpaEntityMap()
				.entrySet()) {

			final OperationType op = entry.getKey();
			final Class<?> klass = entry.getValue();

			if (klass != null) {
				final String klassName = klass.getSimpleName();

				*//**
				 * Use the class name to create a JPQL select statement and then
				 * get the results.
				 *//*
				final List<?> list = getEntityManager().createQuery(
						"select ls from " + klassName
								+ " ls where ls.transactionHeader.transactionType is not null")
						.getResultList();

				if (list.size() > 0) {

					final PayloadData payloadData = factory.createPayloadData();
					payloadData.setOperation(op);

					final String methodName = "set" + klassName;

					for (final Method method : PayloadData.class.getMethods()) {

						if (method.getName().equals(methodName)) {
							method.invoke(payloadData, list);
						}
					}
					allPayloads.add(payloadData);
				}
			}
		}

		document.setPayload(allPayloads);

		final JAXBContext context = JAXBContext.newInstance(Document.class);


		final Marshaller m = context.createMarshaller();
		final SchemaFactory sf = SchemaFactory.newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI);
		final Schema schema = sf.newSchema(IcisNpdesExistingDatabaseIT.class.getResource(SCHEMA_ROOT_PATH));
		m.setSchema(schema);

		final String xmlPath = System.getenv("XML_PATH");

		m.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);
		final Writer writer = new OutputStreamWriter(new FileOutputStream(xmlPath), "UTF-8");
		m.marshal(document, writer);
		writer.close();

		final String schemaPath = new File(getClass().getResource(SCHEMA_ROOT_PATH).toURI()).getPath();
		final JaxbXmlValidator validator = new JaxbXmlValidator(schemaPath);
		final ValidationResult result = validator.validate(new FileInputStream(xmlPath));
		Assert.assertFalse(result.hasErrors());

	}*/

}
