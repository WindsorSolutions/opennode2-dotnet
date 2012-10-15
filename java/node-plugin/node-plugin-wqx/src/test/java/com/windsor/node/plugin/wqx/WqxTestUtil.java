package com.windsor.node.plugin.wqx;

import static org.testng.Assert.assertFalse;

import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.IOException;
import java.io.StringWriter;
import java.net.URISyntaxException;

import javax.persistence.EntityManager;
import javax.xml.XMLConstants;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;

import org.xml.sax.SAXException;

import com.windsor.node.plugin.common.xml.validation.ValidationResult;
import com.windsor.node.plugin.common.xml.validation.jaxb.JaxbXmlValidator;
import com.windsor.node.plugin.test.AbstractJpaIT;
import com.windsor.node.plugin.wqx.domain.generated.ObjectFactory;
import com.windsor.node.plugin.wqx.domain.generated.OrganizationDataType;
import com.windsor.node.plugin.wqx.domain.generated.WQXDataType;

public class WqxTestUtil {

	/**
	 * Name of the package containing the WQX entity classes.
	 */
	public static final String JAVA_PACKAGE_NAME = "com.windsor.node.plugin.wqx.domain.generated";

	/**
	 * Path to the root schema file, relative to the classpath.
	 */
	public static final String SCHEMA_ROOT_PATH = AbstractJpaIT.SCHEMA_DIR + "/root.xsd";

	public static String validateXml(final EntityManager em) throws JAXBException, SAXException,
			URISyntaxException, IOException, ParserConfigurationException {
		final OrganizationDataType org = em.createQuery("select x from OrganizationDataType x",
				OrganizationDataType.class).getSingleResult();
		final ObjectFactory factory = new ObjectFactory();
		final WQXDataType wqx = factory.createWQXDataType();
		wqx.setOrganization(org);

		final JAXBContext jc = JAXBContext.newInstance(WQXDataType.class);
		final Marshaller m = jc.createMarshaller();

		final SchemaFactory sf = SchemaFactory.newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI);
		final Schema schema = sf.newSchema(WqxTestUtil.class.getResource(SCHEMA_ROOT_PATH));
		m.setSchema(schema);
		m.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);
		final StringWriter writer = new StringWriter();
		m.marshal(wqx, writer);

		final String schemaPath = new File(WqxTestUtil.class.getResource(SCHEMA_ROOT_PATH).toURI()).getPath();
		final JaxbXmlValidator validator = new JaxbXmlValidator(schemaPath);
		final String s = writer.toString();
		final ValidationResult result = validator.validate(new ByteArrayInputStream(s.getBytes("UTF-8")));

		assertFalse(result.hasErrors());

		return s;
	}

}
