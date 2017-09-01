package com.windsor.node.plugin.icisnpdes.domain;

import com.windsor.node.plugin.icisnpdes.generated.Contact;
import com.windsor.node.plugin.icisnpdes.generated.ManagementPracticeData;
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
public abstract class AbstractThirdPartyProgramReportContact {

    /**
     * Serialization version.
     */
    private static final long serialVersionUID = 1L;

    @XmlTransient
    private ManagementPracticeData managementPracticeData;

    public ManagementPracticeData getManagementPracticeData() {
        return managementPracticeData;
    }

    @OneToOne(fetch=FetchType.LAZY)
    @JoinColumn(name="ICS_BS_MGMT_PRACTICES_ID")
    public void setManagementPracticeData(ManagementPracticeData managementPracticeData) {
        this.managementPracticeData = managementPracticeData;
    }
}
