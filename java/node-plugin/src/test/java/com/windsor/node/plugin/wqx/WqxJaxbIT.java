package com.windsor.node.plugin.wqx;

import static org.testng.Assert.assertEquals;

import java.io.File;
import java.io.IOException;
import java.io.StringWriter;
import java.net.URISyntaxException;

import javax.xml.XMLConstants;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;

import org.apache.commons.io.FileUtils;
import org.testng.annotations.Test;
import org.xml.sax.SAXException;

import com.windsor.node.plugin.wqx.domain.generated.ObjectFactory;
import com.windsor.node.plugin.wqx.domain.generated.OrganizationDataType;
import com.windsor.node.plugin.wqx.domain.generated.WQXDataType;

/**
 * WQX JAXB integration tests.
 *
 */
public class WqxJaxbIT extends AbstractWqxIT {

	/**
	 * Path to the root schema file, relative to the classpath.
	 */
	private static final String SCHEMA_ROOT_PATH = "/" + SCHEMA_DIR + "/root.xsd";

	/**
	 * Path to the test XML file, relative to the classpath.
	 */
	private static final String XML_PATH = "/" + TEST_XML + "/wqx-1.xml";

	@Test(groups = WQX_TEST_GROUP_NAME, description = "Tests that the marshalled data validates against the schema")
	public void marshalTest() throws JAXBException, SAXException, URISyntaxException, IOException {
		final OrganizationDataType org = getEntityManager().createQuery(
				"select x from OrganizationDataType x", OrganizationDataType.class)
				.getSingleResult();
		final ObjectFactory factory = new ObjectFactory();
		final WQXDataType wqx = factory.createWQXDataType();
		wqx.setOrganization(org);

		final JAXBContext jc = JAXBContext.newInstance(WQXDataType.class);
		final Marshaller m = jc.createMarshaller();

		final SchemaFactory sf = SchemaFactory.newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI);
		final Schema schema = sf.newSchema(getClass().getResource(SCHEMA_ROOT_PATH));
		m.setSchema(schema);
		m.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);
		final StringWriter writer = new StringWriter();
		m.marshal(wqx, writer);

		final File f = new File(getClass().getResource(XML_PATH).toURI());
		final String s = FileUtils.readFileToString(f, "UTF8");
		assertEquals(writer.toString(), s);
	}

}
