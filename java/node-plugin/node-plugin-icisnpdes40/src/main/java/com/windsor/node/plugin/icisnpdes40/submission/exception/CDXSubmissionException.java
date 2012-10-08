package com.windsor.node.plugin.icisnpdes40.submission.exception;

/**
 * Thrown when exception occurs while sending document to CDX.
 */
public class CDXSubmissionException extends Exception {
    
    private static final long serialVersionUID = 1L;

    public CDXSubmissionException(String msg, Throwable t) {
        super(msg, t);
    }
}