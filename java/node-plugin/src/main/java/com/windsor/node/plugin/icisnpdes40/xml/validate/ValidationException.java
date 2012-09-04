package com.windsor.node.plugin.icisnpdes40.xml.validate;

/**
 * Thrown when XML validation cannot be executed, typically when a resource
 * cannot be found.
 */
public class ValidationException extends RuntimeException {

    /**
     * Serialization UID
     */
    private static final long serialVersionUID = 1L;

    /**
     * Convenience constructor.
     * 
     * @param message
     *            exception message.
     * @param t
     *            the exception.
     */
    public ValidationException(String message, Throwable t) {
        super(message, t);
    }

    /**
     * Convenience constructor.
     * 
     * @param message
     *            exception message
     */
    public ValidationException(String message) {
        super(message);
    }
}
