package com.windsor.node.plugin.wqx.service;

public class PendingSubmissionInProgressException extends RuntimeException {

    private static final long serialVersionUID = 1L;

    public PendingSubmissionInProgressException(String message) {
        super(message);
    }
}
