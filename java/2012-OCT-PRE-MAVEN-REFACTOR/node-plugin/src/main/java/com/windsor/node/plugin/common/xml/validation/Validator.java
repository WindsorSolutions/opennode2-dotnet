package com.windsor.node.plugin.common.xml.validation;

import java.io.InputStream;

import com.windsor.node.plugin.common.xml.validation.jaxb.JaxbXmlValidator;

/**
 * Primary XML validation interface. Instantiate a new validator implementation
 * and then call <code>validate</code>. A {@link ValidationResult} will
 * provide the results of the validation. Implementors will determine how an XML
 * file is valid, meaning validators may validate an XML file against an XSD or
 * some other way.
 *
 * @see JaxbXmlValidator
 * @see ValidationResult
 */
public interface Validator {

    /**
     * Validates the supplied XML file.
     *
     * @param xmlInputStream
     *            An {@link InputStream} of the XML file to validate.
     * @return Results of the validation.
     * @throws ValidationException
     *             Unable to execute the validation, typically when a resource
     *             cannot be found.
     */
    ValidationResult validate(InputStream xmlInputStream) throws ValidationException;

}
