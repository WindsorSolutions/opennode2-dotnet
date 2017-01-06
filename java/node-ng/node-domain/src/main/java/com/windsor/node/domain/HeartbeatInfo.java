package com.windsor.node.domain;

import java.io.Serializable;

import com.windsor.node.domain.entity.PartnerVersion;

public class HeartbeatInfo implements Serializable {

    private PartnerVersion partnerVersion;
    private String endpoint;
    private boolean validated;

    public HeartbeatInfo(PartnerVersion partnerVersion, String endpoint, boolean validated) {
        this.partnerVersion = partnerVersion;
        this.endpoint = endpoint;
        this.validated = validated;
    }

    public PartnerVersion getPartnerVersion() {
        return partnerVersion;
    }

    public void setPartnerVersion(PartnerVersion partnerVersion) {
        this.partnerVersion = partnerVersion;
    }

    public String getEndpoint() {
        return endpoint;
    }

    public void setEndpoint(String endpoint) {
        this.endpoint = endpoint;
    }

    public boolean isValidated() {
        return validated;
    }

    public void setValidated(boolean validated) {
        this.validated = validated;
    }

}
