package com.windsor.node.plugin.icisnpdes.submission.exception;

/**
 * Thrown when exception occurs while executing the ETL stored procedure.
 */
public class ETLExecutionException extends Exception {

    private static final long serialVersionUID = 1L;

    public ETLExecutionException(String msg, Throwable t) {
        super(msg, t);
    }

    public ETLExecutionException(String msg) {
        super(msg);
    }
}