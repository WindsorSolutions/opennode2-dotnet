package com.windsor.node.plugin.wqx;

import java.io.IOException;
import java.net.URISyntaxException;

import javax.xml.bind.JAXBException;
import javax.xml.parsers.ParserConfigurationException;

import org.xml.sax.SAXException;

import com.windsor.node.plugin.test.AbstractExistingDbIT;

/**
 * Runs tests against existing databases. To run these tests, the proper
 * environment variables must be set up. See {@link AbstractExistingDbIT} for
 * more information about howt to set these tests up.
 *
 */
public class WqxExistingDbIT extends AbstractExistingDbIT {

	@Override
	protected String getRootEntityPackage() {
		return WqxTestUtil.JAVA_PACKAGE_NAME;
	}

	public void testValidXmlGeneratedFromExistingDb() throws JAXBException, SAXException,
			URISyntaxException, IOException, ParserConfigurationException {
		getEntityManager().getTransaction().begin();
		WqxTestUtil.validateXml(getEntityManager());
		getEntityManager().getTransaction().commit();
	}

}
