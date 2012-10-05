package com.windsor.node.plugin.flowsecurity.xml;

import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.xml.sax.InputSource;
import org.xml.sax.SAXException;
import org.xml.sax.XMLReader;
import org.xml.sax.helpers.XMLReaderFactory;

import com.windsor.node.common.domain.flowsecurity.AuthorizationRequest;
import com.windsor.node.util.IOUtil;

public class AuthRequestParser {

    private Logger logger = LoggerFactory.getLogger(getClass());

    public AuthorizationRequest parseFile(String inputFileName) {

        logger.debug("Creating File from String " + inputFileName);
        File inputFile = new File(inputFileName);

        return parseFile(inputFile);

    }

    public AuthorizationRequest parseFile(File inputFile) {

        try {

            logger.debug("Creating FileInputStream from File " + inputFile);
            /*
             * DON'T use a FileReader here due to BOM issues in the document
             * prolog. see
             * http://osdir.com/ml/text.xml.xerces-j.user/2005/msg00489.html or
             * Google for "xerces "Content is not allowed in prolog""
             */

            FileInputStream fis = new FileInputStream(inputFile);

            return parseInputStream(fis);

        } catch (FileNotFoundException e) {

            throw new RuntimeException("FileNotFoundException: "
                    + e.getMessage(), e);
        }
    }

    public AuthorizationRequest parseByteArray(byte[] input) {

        logger.debug("Creating ByteArrayInputStream from byte[] " + input);

        ByteArrayInputStream bais = new ByteArrayInputStream(IOUtil
                .filterUtf8Bom(input));

        return parseInputStream(bais);
    }

    public AuthorizationRequest parseInputStream(InputStream is) {

        AuthorizationRequest authRequest = null;
        AuthRequestHandler handler = new AuthRequestHandler();
        XMLReader xr;

        try {

            logger.debug("Creating XMLReader from environment...");
            xr = XMLReaderFactory.createXMLReader();

            logger.debug("XMLReader class: " + xr.getClass().getName());
            logger.debug("XMLReader validation setting: "
                    + xr.getFeature("http://xml.org/sax/features/validation"));

            xr.setContentHandler(handler);
            xr.setErrorHandler(handler);

            logger.debug("Creating InputSource from InputStream...");
            InputSource input = new InputSource(is);

            xr.parse(input);
            authRequest = handler.getAuthRequest();

        } catch (SAXException e) {

            throw new RuntimeException("SAXException: " + e.getMessage(), e);

        } catch (IOException e) {

            throw new RuntimeException("IOException: " + e.getMessage(), e);
        }

        return authRequest;
    }
}
