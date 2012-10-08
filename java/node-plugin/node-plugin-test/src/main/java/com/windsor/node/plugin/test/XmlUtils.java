package com.windsor.node.plugin.test;

import java.io.IOException;
import java.io.InputStream;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

import org.w3c.dom.Document;
import org.xml.sax.SAXException;

public class XmlUtils {

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
