package com.windsor.node.domain;

import java.util.Arrays;
import java.util.Collection;

import com.windsor.stack.domain.IIdentifiable;

/**
 * Provides an enumeration of permissions for the application.
 */
public enum NodePermission implements IIdentifiable<String> {

    ADMIN_USER(NodeConstants.PERM_ADMIN_USER),
    NONE_USER(NodeConstants.PERM_NONE_USER),
    PROGRAM_USER(NodeConstants.PERM_PROGRAM_USER),
    AUTHED_USER(NodeConstants.PERM_AUTHED_USER),
    ANONYMOUS_USER(NodeConstants.PERM_ANONYMOUS_USER);

    public static final Collection<NodePermission> NON_ADMIN_USER_PERMISSIONS =
            Arrays.asList(NONE_USER, PROGRAM_USER, AUTHED_USER, ANONYMOUS_USER);

    private String id;

    NodePermission(String id) {
        this.id = id;
    }

    @Override
    public String getId() {
        return id;
    }

}
