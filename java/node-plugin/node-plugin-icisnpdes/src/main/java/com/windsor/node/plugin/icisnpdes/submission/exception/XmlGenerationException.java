package com.windsor.node.plugin.icisnpdes.submission.exception;

/**
 * Thrown when exception occurs while generating XML document.
 */
public class XmlGenerationException extends Exception {
    
    private static final long serialVersionUID = 1L;

    public XmlGenerationException(String msg, Throwable t) {
        super(msg, t);
    }
}