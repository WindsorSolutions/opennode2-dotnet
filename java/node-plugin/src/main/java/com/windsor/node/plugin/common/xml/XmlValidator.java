/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
 */

package com.windsor.node.plugin.common.xml;

import java.io.File;
import java.io.IOException;

import javax.xml.XMLConstants;
import javax.xml.transform.Source;
import javax.xml.transform.stream.StreamSource;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;
import javax.xml.validation.Validator;

import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;
import org.xml.sax.ErrorHandler;
import org.xml.sax.SAXException;
import org.xml.sax.SAXParseException;

/**
 * Use com.windsor.node.plugin.common.xml.validation.Validator instead
 *
 * @deprecated
 */
@Deprecated
public class XmlValidator implements InitializingBean {

    protected static Logger logger = LoggerFactory.getLogger(XmlValidator.class);

    private String schemaFilename;

    public XmlValidator() {
    }

    public XmlValidator(String schemaFileName) {

        this.schemaFilename = schemaFileName;
    }

    /**
     * Fail on validation errors, but first log errors first.
     *
     * @param filename
     *            the file to validate
     * @return whether the file is valid in a strict sense
     *
     * @see http://www.ibm.com/developerworks/xml/library/x-javaxmlvalidapi.html
     */
    public boolean validate(String filename) {

        validateLenient(filename);
        return validateHarsh(filename);

    }

    /**
     * Fail on validation errors.
     *
     * @param filename
     *            the file to validate
     * @return whether the file is valid in a strict sense
     * @see http://www.ibm.com/developerworks/xml/library/x-javaxmlvalidapi.html
     */
    public boolean validateHarsh(String filename) {

        logger.debug("Validating xml file " + filename);

        SchemaFactory factory = SchemaFactory
                .newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI);

        boolean isValid = false;

        try {

            File schemaLocation = new File(schemaFilename);
            Schema schema = factory.newSchema(schemaLocation);

            Validator validator = schema.newValidator();

            Source source = new StreamSource(filename);

            validator.validate(source);

            isValid = true;

            logger.info(filename + " is valid.");

        } catch (SAXParseException spe) {

            isValid = false;
            logger.info(filename + " is not valid.");

        } catch (SAXException ex) {

            logger.error(errMsg(filename) + ex.getMessage());

            throw new RuntimeException(errMsg(filename) + ex.getMessage(), ex);

        } catch (IOException e) {

            logger.error(e.getMessage());

            throw new RuntimeException(e);
        }

        return isValid;
    }

    /**
     * Print validation errors verbosely.
     *
     * @param filename
     *            the file to validate
     * @return whether the file is valid in a lenient sense
     * @see http://www.ibm.com/developerworks/xml/library/x-javaxmlvalidapi.html
     */
    public boolean validateLenient(String filename) {

        logger.debug("Gently validating xml file " + filename);

        SchemaFactory factory = SchemaFactory
                .newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI);

        boolean isValid = false;

        try {

            File schemaLocation = new File(schemaFilename);
            Schema schema = factory.newSchema(schemaLocation);

            Validator validator = schema.newValidator();
            logger.debug("validator implementation: " + validator.getClass());
            ErrorHandler lenient = new ForgivingErrorHandler();
            validator.setErrorHandler(lenient);

            Source source = new StreamSource(filename);

            validator.validate(source);

            isValid = true;

            logger.info(filename + " may or may not be valid.");

        } catch (SAXException ex) {

            logger.error(errMsg(filename) + ex.getMessage());

            throw new RuntimeException(errMsg(filename) + ex.getMessage(), ex);

        } catch (IOException e) {

            logger.error(e.getMessage());

            throw new RuntimeException(e);
        }

        return isValid;

    }

    private String errMsg(String filename) {

        return filename + " is not valid, message: ";
    }

    private String saxParseExceptionMsg(SAXParseException ex) {

        return ex.getMessage() + " at line " + ex.getLineNumber() + ", column "
                + ex.getColumnNumber();
    }

    /**
     * @return
     */
    public String getSchemaFilename() {
        return schemaFilename;
    }

    /**
     * @param schemaFilename
     *            the xsd to be used in validation
     */
    public void setSchemaFilename(String schemaFilename) {
        this.schemaFilename = schemaFilename;
    }

    /**
     * Logs warnings and errors with reference to location in file, fails only
     * on fatal errors.
     *
     * @author jniski
     *
     */
    private class ForgivingErrorHandler implements ErrorHandler {

        @Override
        public void warning(SAXParseException ex) {
            logger.warn("Warning: " + saxParseExceptionMsg(ex));
        }

        @Override
        public void error(SAXParseException ex) {
            logger.error("Error: " + saxParseExceptionMsg(ex));
        }

        @Override
        public void fatalError(SAXParseException ex) throws SAXException {
            logger.error("Fatal error: " + saxParseExceptionMsg(ex));
            throw ex;
        }

    }

    @Override
    public void afterPropertiesSet() throws Exception {

        if (StringUtils.isBlank(schemaFilename)) {
            throw new RuntimeException("schemaFilename is null or empty");
        }

    }

}
