package com.windsor.node.domain;

/**
 * Application-wide constants.
 */
public final class NodeConstants {

    public static final String PERM_NAME_MONITOR_APPLICATION = "monitorApplication";

    // development settings
    public static final String DEV_ENV_NAME = "dev";
    public static final String DOCKER_ENV_NAME = "docker";

    // build information properties
    public static final String PROPERTY_BUILD_INFO = "buildInfo";
    public static final String PROPERTY_BUILD_NUMBER = "build.number";
    public static final String PROPERTY_BUILD_TIMESTAMP = "build.timestamp";
    public static final String PROPERTY_RUN_PROFILE = "spring.profiles.active";

    // build information values
    public static final String VALUE_BUILD_INFO = "${" + PROPERTY_BUILD_INFO + "}";
    public static final String VALUE_BUILD_NUMBER = "${" + PROPERTY_BUILD_NUMBER + "}";
    public static final String VALUE_BUILD_TIMESTAMP = "${" + PROPERTY_BUILD_TIMESTAMP + "}";
    public static final String VALUE_RUN_PROFILE = "${" + PROPERTY_RUN_PROFILE + "}";

    // role type names
    public static final String ROLE_TYPE_NONE = "None";
    public static final String ROLE_TYPE_AUTHED = "Authenticated";
    public static final String ROLE_TYPE_PROGRAM = "Program";
    public static final String ROLE_TYPE_ADMIN = "Administrator";
    public static final String ROLE_TYPE_ANONYMOUS = "Anonymous";

    // permission names
    public static final String PERM_ADMIN_USER = "Admin";
    public static final String PERM_NONE_USER = "None";
    public static final String PERM_PROGRAM_USER = "Program";
    public static final String PERM_AUTHED_USER = "Authed";
    public static final String PERM_ANONYMOUS_USER = "Anonymous";

    private NodeConstants() {
        super();
    }
}