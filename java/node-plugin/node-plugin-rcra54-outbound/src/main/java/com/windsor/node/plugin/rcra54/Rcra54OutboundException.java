package com.windsor.node.plugin.rcra54;

/**
 * Provides an exception that encapsulates an exception for the RCRA 5.4 Outbound plugin.
 */
public class Rcra54OutboundException extends Exception {

    public Rcra54OutboundException(String message) {
        super(message);
    }

    public Rcra54OutboundException(String message, Exception exception) {
        super(message, exception);
    }
}
