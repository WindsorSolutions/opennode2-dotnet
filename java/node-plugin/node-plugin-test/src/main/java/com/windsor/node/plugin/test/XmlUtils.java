package com.windsor.node.plugin.test;

import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.io.UnsupportedEncodingException;
import java.net.URISyntaxException;
import java.net.URL;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

import org.w3c.dom.Document;
import org.xml.sax.SAXException;

import com.windsor.node.plugin.common.xml.validation.ValidationException;
import com.windsor.node.plugin.common.xml.validation.ValidationResult;
import com.windsor.node.plugin.common.xml.validation.jaxb.JaxbXmlValidator;

public class XmlUtils {

	/**
	 * Validates the {@code xml} against the {@code schema}. Returns a
	 * {@link ValidationResult} object describing the validation result.
	 *
	 * @param schema
	 *            {@link URL} to the schema
	 * @param xml
	 *            XML document as a String
	 * @return {@link ValidationResult} object describing the validation result
	 * @throws URISyntaxException
	 * @throws ValidationException
	 * @throws UnsupportedEncodingException
	 */
	public static ValidationResult validate(final URL schema, final String xml)
			throws URISyntaxException, ValidationException, UnsupportedEncodingException {
		final String schemaPath = new File(schema.toURI()).getPath();
		final JaxbXmlValidator validator = new JaxbXmlValidator(schemaPath);
		final ValidationResult result = validator.validate(new ByteArrayInputStream(xml
				.getBytes("UTF-8")));
		return result;
	}

	/**
	 * Returns whether the two XML documents, referenced by the
	 * {@link InputStream}s, have the same content.
	 *
	 * @param is1
	 * @param is2
	 * @return
	 * @throws ParserConfigurationException
	 * @throws SAXException
	 * @throws IOException
	 */
	public static boolean equals(final InputStream is1, final InputStream is2)
			throws ParserConfigurationException, SAXException, IOException {
		/*
		 * Create a builder for parsing the XML.
		 */
		final DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
		dbf.setNamespaceAware(true);
		dbf.setCoalescing(true);
		dbf.setIgnoringElementContentWhitespace(true);
		dbf.setIgnoringComments(true);
		final DocumentBuilder db = dbf.newDocumentBuilder();

		/*
		 * Parse the XML.
		 */
		final Document doc1 = db.parse(is1);
		doc1.normalizeDocument();
		final Document doc2 = db.parse(is2);
		doc2.normalizeDocument();

		/*
		 * Verify that the XML documents have the same content.
		 */
		return doc1.isEqualNode(doc2);
	}

}
