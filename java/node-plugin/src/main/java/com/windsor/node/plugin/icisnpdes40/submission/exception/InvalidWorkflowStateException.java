package com.windsor.node.plugin.icisnpdes40.submission.exception;

/**
 * Thrown if the workflow is in an invalid state.
 */
public class InvalidWorkflowStateException extends Exception {
    
    private static final long serialVersionUID = 1L;

    public InvalidWorkflowStateException(String msg) {
        super(msg);
    }
}