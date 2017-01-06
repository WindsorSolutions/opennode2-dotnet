package com.windsor.node.plugin.rcra54.solicit;

/**
 * Provided an exception for wrapping exceptions that occur during the
 * execution of a stored procedure.
 */
public class StoredProcedureException extends Exception {

    public StoredProcedureException(String message, Throwable cause) {
        super(message, cause);
    }
}
