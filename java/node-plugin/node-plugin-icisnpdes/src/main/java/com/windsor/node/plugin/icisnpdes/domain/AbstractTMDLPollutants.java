package com.windsor.node.plugin.icisnpdes.domain;

import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;
import java.io.Serializable;

/**
 *
 */
@MappedSuperclass
@XmlAccessorType(XmlAccessType.FIELD)
public abstract class AbstractTMDLPollutants implements Serializable {

    /**
     * Serialization version.
     */
    private static final long serialVersionUID = 1L;

    @XmlTransient
    private String featureId;

    @Column(name = "ICS_PRMT_FEATR_ID", insertable = false, updatable = false)
    public String getFeatureId() {
        return featureId;
    }

    public void setFeatureId(String featureId) {
        this.featureId = featureId;
    }
}
