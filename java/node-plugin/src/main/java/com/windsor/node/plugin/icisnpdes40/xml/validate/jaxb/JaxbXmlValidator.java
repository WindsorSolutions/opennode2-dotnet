package com.windsor.node.plugin.icisnpdes40.xml.validate.jaxb;

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
import javax.xml.validation.Validator;

import org.xml.sax.SAXException;

import com.windsor.node.plugin.icisnpdes40.xml.validate.ValidationException;
import com.windsor.node.plugin.icisnpdes40.xml.validate.ValidationResult;
import com.windsor.node.plugin.icisnpdes40.xml.validate.XmlValidator;

/**
 * A JAXB {@link XmlValidator} implementation class. Please be aware that this
 * class is NOT thread safe.
 * 
 * @see XmlValidator
 */
public class JaxbXmlValidator implements XmlValidator {

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

        JaxbValidationResult results = new JaxbValidationResult();
        
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
            Validator validator = schema.newValidator();

            /**
             * Create a source for the XML to validate.
             */
            Source xmlFile = new StreamSource(xmlInputStream);

            /**
             * Validate the input source. If the document is invalid an
             * SAXException is thrown, otherwise it will return quietly.
             */
            try {
                validator.validate(xmlFile);
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
