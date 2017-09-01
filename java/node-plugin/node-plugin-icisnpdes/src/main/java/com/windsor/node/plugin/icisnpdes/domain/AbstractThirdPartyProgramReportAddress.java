package com.windsor.node.plugin.icisnpdes.domain;

import com.windsor.node.plugin.icisnpdes.generated.Address;
import org.hibernate.annotations.NotFound;
import org.hibernate.annotations.NotFoundAction;

import javax.persistence.*;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;
import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;

/**
 *
 */
@Embeddable
@MappedSuperclass
@XmlAccessorType(XmlAccessType.FIELD)
public abstract class AbstractThirdPartyProgramReportAddress {

    /**
     * Serialization version.
     */
    private static final long serialVersionUID = 1L;

    @XmlTransient
    private String biosolidManagementPracticeId;

    @Column(name = "ICS_BS_MGMT_PRACTICES_ID", insertable = false, updatable = false)
    public String getBiosolidManagementPracticeId() {
        return biosolidManagementPracticeId;
    }

    public void setBiosolidManagementPracticeId(String biosolidManagementPracticeId) {
        this.biosolidManagementPracticeId = biosolidManagementPracticeId;
    }
}
