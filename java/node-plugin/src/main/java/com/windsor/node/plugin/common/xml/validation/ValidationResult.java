package com.windsor.node.plugin.common.xml.validation;

import java.util.Collection;

/**
 * Contains the results of XML validation.
 * 
 * @see Validator
 */
public interface ValidationResult {

    /**
     * Are there any validation errors?
     * 
     * @return validation errors?
     */
    boolean hasErrors();

    /**
     * Returns a {@link Collection} of errors, empty when there are no errors.
     * 
     * @return A {@link Collection} of error messages.
     */
    Collection<String> errors();
}
