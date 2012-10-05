package com.windsor.node.plugin.common.xml.validation.jaxb;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

import org.apache.commons.collections.CollectionUtils;

import com.windsor.node.plugin.common.xml.validation.ValidationResult;
import com.windsor.node.plugin.common.xml.validation.Validator;

/**
 * An {@link ValidationResult} implementation used by {@link JaxbXmlValidator}.
 *
 * @see ValidationResult
 * @see Validator
 * @see JaxbXmlValidator
 */
public class JaxbValidationResult implements ValidationResult {

    /**
     * Holds the error messages.
     */
    private final List<String> errors;

    /**
     * Constructor.
     */
    public JaxbValidationResult() {
        this.errors = new ArrayList<String>();
    }

    /**
     * Adds the message to list of errors.
     *
     * @param message
     *            The error message.
     */
    public void error(String message) {
        errors.add(message);
    }

    /**
     * {@inheritDoc}
     */
    @SuppressWarnings("unchecked")
    @Override
    public Collection<String> errors() {
        return CollectionUtils.unmodifiableCollection(errors);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public boolean hasErrors() {
        return errors.size() > 0;
    }
}
