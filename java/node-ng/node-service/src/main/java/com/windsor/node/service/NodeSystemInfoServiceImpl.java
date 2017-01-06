package com.windsor.node.service;

import com.windsor.node.domain.NodeConstants;
import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Component;

/**
 * Provides an implementation of the application system info service.
 */
@Component
public class NodeSystemInfoServiceImpl implements NodeSystemInfoService {

    @Value(NodeConstants.VALUE_BUILD_TIMESTAMP)
    private String buildTimeStamp;

    @Value(NodeConstants.VALUE_RUN_PROFILE)
    private String profile;

    @Value(NodeConstants.VALUE_BUILD_NUMBER)
    private String buildNumber;

    @Value(NodeConstants.VALUE_BUILD_INFO)
    private String buildInfo;

    @Override
    public String getBuildTimestamp() {
        return buildTimeStamp;
    }

    @Override
    public String getBuildNumber() {
        return buildNumber;
    }

    @Override
    public String getRunProfile() {
        return profile;
    }

    @Override
    public String getBuildInfo() {
        return buildInfo;
    }

    @Override
    public boolean isProfileActive(Profile profile) {
        return profile.name().toLowerCase().equals(StringUtils.lowerCase(getRunProfile()));
    }
}
