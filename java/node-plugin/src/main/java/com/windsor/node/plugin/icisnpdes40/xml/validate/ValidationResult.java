package com.windsor.node.plugin.icisnpdes40.xml.validate;

import java.util.Collection;

/**
 * Contains the results of XML validation.
 * 
 * @see XmlValidator
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
