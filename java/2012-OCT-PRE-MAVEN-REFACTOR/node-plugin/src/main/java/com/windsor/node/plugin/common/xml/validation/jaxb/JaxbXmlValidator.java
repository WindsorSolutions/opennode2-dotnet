package com.windsor.node.plugin.common.xml.validation.jaxb;

import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.net.MalformedURLException;
import java.net.URL;

import javax.xml.XMLConstants;
import javax.xml.transform.Source;
import javax.xml.transform.stream.StreamSource;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;

import org.xml.sax.ErrorHandler;
import org.xml.sax.SAXException;
import org.xml.sax.SAXParseException;

import com.windsor.node.plugin.common.xml.validation.ValidationException;
import com.windsor.node.plugin.common.xml.validation.ValidationResult;
import com.windsor.node.plugin.common.xml.validation.Validator;

/**
 * A JAXB {@link Validator} implementation class. Please be aware that this
 * class is NOT thread safe.
 *
 * @see Validator
 */
public class JaxbXmlValidator implements Validator {

    private URL schemaFile;

    /**
     * Constructor.
     *
     * @param schemaFile
     *            {@link URL} of the XSD the XML should be validated against.
     */
    public JaxbXmlValidator(URL schemaFile) {
        setSchemaUrl(schemaFile);
    }

    /**
     * Constructor.
     *
     * @param schemaFile
     *            {@link String} of the XSD the XML should be validated against.
     */
    public JaxbXmlValidator(String schemaFilePath) {

        try {
        	setSchemaUrl(new File(schemaFilePath).toURI().toURL());
        } catch (MalformedURLException e) {
            throw new ValidationException(e.getLocalizedMessage(), e);
        }
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public ValidationResult validate(InputStream xmlInputStream) throws ValidationException {

        final JaxbValidationResult results = new JaxbValidationResult();

        try {

            /**
             * Load a schema factory for the language the schema is written in.
             */
            SchemaFactory schemaFactory = SchemaFactory.newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI);

            /**
             * Compile the schema from it's source.
             */
            Schema schema = schemaFactory.newSchema(schemaFile);

            /**
             * Create a validator from the compiled schema.
             */
            javax.xml.validation.Validator jaxbValidator = schema.newValidator();

            jaxbValidator.setErrorHandler(new ErrorHandler() {

                @Override
                public void warning(SAXParseException exception) throws SAXException { }

                @Override
                public void fatalError(SAXParseException exception) throws SAXException {
                    results.error(exception.getLocalizedMessage());
                }

                @Override
                public void error(SAXParseException exception) throws SAXException {
                    results.error(exception.getLocalizedMessage());
                }
            });

            /**
             * Create a source for the XML to validate.
             */
            Source xmlFile = new StreamSource(xmlInputStream);

            /**
             * Validate the input source. If the document is invalid an
             * SAXException is thrown, otherwise it will return quietly.
             */
            try {
                jaxbValidator.validate(xmlFile);
            } catch (SAXException e) {
                results.error(e.getLocalizedMessage());
            } catch (IOException e) {

            }

        } catch (SAXException e) {
            throw new ValidationException(e.getLocalizedMessage(), e);
        }

        return results;
    }

    /**
     * Sets the {@link URL} of the schema to validate with.
     *
     * @param schemaUrl
     *            The schema to validate with.
     */
    public void setSchemaUrl(URL schemaUrl) {
        this.schemaFile = schemaUrl;
    }
}
