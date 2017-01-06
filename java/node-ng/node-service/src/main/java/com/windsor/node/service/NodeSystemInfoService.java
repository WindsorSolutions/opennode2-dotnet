package com.windsor.node.service;

/**
 * Provides information about the application.
 */
public interface NodeSystemInfoService {

    enum Profile {
        DEV,
        TEST,
        QA,
        PROD;
    }

    String getBuildTimestamp();

    String getBuildNumber();

    String getRunProfile();

    String getBuildInfo();

    boolean isProfileActive(Profile profile);
}
