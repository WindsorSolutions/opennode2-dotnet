package com.windsor.node.plugin.facid3;

import java.io.IOException;
import java.io.StringWriter;
import java.math.BigDecimal;
import java.net.URISyntaxException;
import java.util.List;

import javax.xml.XMLConstants;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;

import org.testng.annotations.Test;
import org.xml.sax.SAXException;

import com.windsor.node.plugin.ExistingOracleDbIT;
import com.windsor.node.plugin.facid3.domain.generated.AffiliateDataType;
import com.windsor.node.plugin.facid3.domain.generated.AffiliateListDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityDetailsDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityListDataType;
import com.windsor.node.plugin.facid3.domain.generated.ObjectFactory;

public class Facid3ExistingOracleDbJaxbIT extends ExistingOracleDbIT {

	/**
	 * Path to the root schema file, relative to the classpath.
	 */
	private static final String SCHEMA_ROOT_PATH = "/" + SCHEMA_DIR + "/index.xsd";

	@Override
	protected String getRootEntityPackage() {
		return "com.windsor.node.plugin.facid3.domain.generated";
	}

	@Test(description = "Tests that the marshalled facility details XML document validates against the schema.")
	public void facilityDetailsTest() throws JAXBException, SAXException, URISyntaxException,
			IOException, ParserConfigurationException {

		final List<FacilityDataType> facilities = getEntityManager()
				.createQuery(
						"select x from FacilityDataType x left outer join fetch x.facilityPrimaryGeographicLocationDescription",
						FacilityDataType.class).getResultList();

		final List<AffiliateDataType> affiliates = getEntityManager().createQuery(
				"select x from AffiliateDataType x", AffiliateDataType.class).getResultList();

		// construct the in-memory doc

		final ObjectFactory factory = new ObjectFactory();

		final FacilityDetailsDataType details = factory.createFacilityDetailsDataType();

		final FacilityListDataType facilityList = factory.createFacilityListDataType();
		facilityList.setFacility(facilities);
		details.setFacilityList(facilityList);

		final AffiliateListDataType affiliateList = factory.createAffiliateListDataType();
		affiliateList.setAffiliate(affiliates);
		details.setAffiliateList(affiliateList);

		details.setSchemaVersion(new BigDecimal("3.0"));

		final JAXBContext jc = JAXBContext.newInstance(FacilityDataType.class);
		final Marshaller m = jc.createMarshaller();

		final SchemaFactory sf = SchemaFactory.newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI);
		final Schema schema = sf.newSchema(getClass().getResource(SCHEMA_ROOT_PATH));
		m.setSchema(schema);
		m.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);
		final StringWriter writer = new StringWriter();
		m.marshal(details, writer);
		final String marshalledXml = writer.toString();

	}
}
