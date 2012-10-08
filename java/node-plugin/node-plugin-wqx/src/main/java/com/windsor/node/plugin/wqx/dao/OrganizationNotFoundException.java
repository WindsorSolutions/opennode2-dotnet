package com.windsor.node.plugin.wqx.dao;

public class OrganizationNotFoundException extends RuntimeException {

    private static final long serialVersionUID = 1L;

    public OrganizationNotFoundException(String message) {
        super(message);
    }
}
