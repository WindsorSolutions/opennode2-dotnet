package com.windsor.node.plugin.facid3;

import static org.testng.Assert.assertFalse;

import java.io.IOException;
import java.io.StringWriter;
import java.io.UnsupportedEncodingException;
import java.io.Writer;
import java.math.BigInteger;
import java.net.URISyntaxException;
import java.util.Arrays;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.xml.XMLConstants;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;

import org.testng.annotations.Test;
import org.xml.sax.SAXException;

import com.windsor.node.plugin.common.xml.validation.ValidationException;
import com.windsor.node.plugin.facid3.domain.generated.AffiliateDataType;
import com.windsor.node.plugin.facid3.domain.generated.AffiliateListDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityCountDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityDetailsDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityIndexDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityInterestDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityInterestSummaryDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityInterestSummaryListDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityListDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilitySummaryDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilitySummaryListDataType;
import com.windsor.node.plugin.facid3.domain.generated.ObjectFactory;
import com.windsor.node.plugin.test.AbstractExistingDbIT;
import com.windsor.node.plugin.test.XmlUtils;

public class Facid3ExistingDbIT extends AbstractExistingDbIT {

	/**
	 * Path to the root schema file, relative to the classpath.
	 */
	private static final String SCHEMA_ROOT_PATH = SCHEMA_DIR + "/index.xsd";

	private final ObjectFactory factory = new ObjectFactory();

	private final String SCHEMA_VERSION = "3.0";

	public void test() {
		final FacilityCriteriaQueryService factory = new FacilityCriteriaQueryService(getEntityManager());
		final Map<String, Object> parameters = new HashMap<String, Object>();
//		parameters.put(BaseFacIdGetFacilityService.BOUNDING.getName(), new BoundingCoordinates(1.5, 2.5, 1.5, 2.5));
		parameters.put(BaseFacIdGetFacilityService.S_BOUNDING_LAT.getName(), 2.5);
		parameters.put(BaseFacIdGetFacilityService.W_BOUNDING_LONG.getName(), 1.5);
		parameters.put(BaseFacIdGetFacilityService.E_BOUNDING_LONG.getName(), 2.5);
		parameters.put(BaseFacIdGetFacilityService.FACILITY_SITE_IDENTIFIER.getName(), "mnop");
		parameters.put(BaseFacIdGetFacilityService.CHANGE_DATE.getName(), new Date());
		parameters.put(BaseFacIdGetFacilityService.NAICS_CODE.getName(), Arrays.asList(new String[] {"MNO", "PQR"}));
		parameters.put(BaseFacIdGetFacilityService.SIC_CODE.getName(), Arrays.asList(new String[] {"ABC", "XYZ"}));
		parameters.put(BaseFacIdGetFacilityService.FACILITY_NAME.getName(), "XYZ%");
		parameters.put(BaseFacIdGetFacilityService.FEDERAL_FACILITY.getName(), "N");
		parameters.put(BaseFacIdGetFacilityService.TRIBAL_LAND_CODE.getName(), "N");
		parameters.put(BaseFacIdGetFacilityService.ZIP_CODE.getName(), Arrays.asList(new String[]{"5", "6"}));
		parameters.put(BaseFacIdGetFacilityService.ORIGINATING_PARTNER_NAME.getName(), "ghij");
		parameters.put(BaseFacIdGetFacilityService.INFO_SYSTEM_ACORNYM_NAME.getName(), "klmn");
		parameters.put(BaseFacIdGetFacilityService.STANDARD_ENVIRONMENTAL_INTEREST_TYPE.getName(), Arrays.asList(new String[]{"5", "6"}));
		final List<FacilityDataType> facilityList = factory.getDistinctResultList(FacilityDataType.class, parameters);
		final long count = factory.getDistinctCount(parameters);
	}

	private <T> void marshal(final Class<T> topLevelClass, final T data, final Writer writer)
			throws JAXBException, SAXException {
		final JAXBContext jc = JAXBContext.newInstance(topLevelClass);
		final Marshaller m = jc.createMarshaller();
		final SchemaFactory sf = SchemaFactory.newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI);
		final Schema schema = sf.newSchema(getClass().getResource(SCHEMA_ROOT_PATH));
		m.setSchema(schema);
		m.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);
		m.marshal(data, writer);
	}

	public void facilityInterestTest() throws JAXBException, SAXException, ValidationException,
			UnsupportedEncodingException, URISyntaxException {
		final List<FacilityInterestSummaryDataType> list = getEntityManager().createQuery(
				"select f from FacilityInterestSummaryDataType f left outer join fetch f.facilitySummaryGeographicLocation left outer join fetch f.location", FacilityInterestSummaryDataType.class)
				.getResultList();
		final FacilityInterestDataType facilityInterest = factory.createFacilityInterestDataType();
		facilityInterest.setSchemaVersion(SCHEMA_VERSION);
		final FacilityInterestSummaryListDataType interestList = factory.createFacilityInterestSummaryListDataType();
		interestList.setFacilityInterestSummary(list);
		facilityInterest.setFacilityInterestSummaryList(interestList);
		final StringWriter writer = new StringWriter();
		marshal(FacilityInterestDataType.class, facilityInterest, writer);
		final String xml = writer.toString();
		LOGGER.debug("Marshalled XML: {}", xml);
		assertFalse(XmlUtils.validate(getClass().getResource(SCHEMA_ROOT_PATH), xml).hasErrors());
	}

	public void facilityCountTest() throws JAXBException, SAXException, ValidationException,
			UnsupportedEncodingException, URISyntaxException {
		final Long count = getEntityManager().createQuery(
				"select count(f) from FacilityDataType f", Long.class).getSingleResult();
		final FacilityCountDataType facilityCount = factory.createFacilityCountDataType();
		facilityCount.setSchemaVersion(SCHEMA_VERSION);
		facilityCount.setFacilityCountMeasure(new BigInteger(count.toString()));
		final StringWriter writer = new StringWriter();
		marshal(FacilityCountDataType.class, facilityCount, writer);
		final String xml = writer.toString();
		LOGGER.debug("Marshalled XML: {}", xml);
		assertFalse(XmlUtils.validate(getClass().getResource(SCHEMA_ROOT_PATH), xml).hasErrors());
	}

	public void facilityIndexTest() throws JAXBException, SAXException, ValidationException,
			UnsupportedEncodingException, URISyntaxException {
		final List<FacilitySummaryDataType> list = getEntityManager()
				.createQuery(
						"select f from FacilitySummaryDataType f left outer join fetch f.facilitySummaryGeographicLocation left outer join fetch f.location",
						FacilitySummaryDataType.class).getResultList();
		final FacilityIndexDataType facilityIndex = factory.createFacilityIndexDataType();
		facilityIndex.setSchemaVersion(SCHEMA_VERSION);
		final FacilitySummaryListDataType summaryList = factory.createFacilitySummaryListDataType();
		summaryList.setFacilitySummary(list);
		facilityIndex.setFacilitySummaryList(summaryList);

		final StringWriter writer = new StringWriter();
		marshal(FacilityIndexDataType.class, facilityIndex, writer);
		final String xml = writer.toString();
		LOGGER.debug("Marshalled XML: {}", xml);
		assertFalse(XmlUtils.validate(getClass().getResource(SCHEMA_ROOT_PATH), xml).hasErrors());
	}

	@Test(description = "Tests that the marshalled facility details XML document validates against the schema.")
	public void facilityDetailsTest() throws JAXBException, SAXException, URISyntaxException,
			IOException, ParserConfigurationException {

		final List<FacilityDataType> facilities = getEntityManager().createQuery(
				"select x from FacilityDataType x "
						+ "left outer join fetch x.facilityPrimaryGeographicLocationDescription left outer join x.location",
				FacilityDataType.class).getResultList();

		final List<AffiliateDataType> affiliates = getEntityManager().createQuery(
				"select x from AffiliateDataType x", AffiliateDataType.class).getResultList();

		// construct the in-memory doc

		final FacilityDetailsDataType details = factory.createFacilityDetailsDataType();

		final FacilityListDataType facilityList = factory.createFacilityListDataType();
		facilityList.setFacility(facilities);
		details.setFacilityList(facilityList);

		final AffiliateListDataType affiliateList = factory.createAffiliateListDataType();
		affiliateList.setAffiliate(affiliates);
		details.setAffiliateList(affiliateList);

		details.setSchemaVersion(SCHEMA_VERSION);

		final JAXBContext jc = JAXBContext.newInstance(FacilityDataType.class);
		final Marshaller m = jc.createMarshaller();

		final SchemaFactory sf = SchemaFactory.newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI);
		final Schema schema = sf.newSchema(getClass().getResource(SCHEMA_ROOT_PATH));
		m.setSchema(schema);
		m.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);
		final StringWriter writer = new StringWriter();
		m.marshal(details, writer);
	}

	@Override
	protected String getRootEntityPackage() {
		return "com.windsor.node.plugin.facid3.domain.generated";
	}

}
