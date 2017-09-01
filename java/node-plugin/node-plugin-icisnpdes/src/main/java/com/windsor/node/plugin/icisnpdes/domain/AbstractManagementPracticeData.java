package com.windsor.node.plugin.icisnpdes.domain;

import com.windsor.node.plugin.icisnpdes.generated.BiosolidsAnnualProgramReportData;
import com.windsor.node.plugin.icisnpdes.generated.ManagementPracticeData;
import com.windsor.node.plugin.icisnpdes.generated.ThirdPartyProgramReportAddress;
import com.windsor.node.plugin.icisnpdes.generated.ThirdPartyProgramReportContact;

import javax.persistence.*;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;
import java.util.ArrayList;
import java.util.List;

/**
 *
 */
@MappedSuperclass
@XmlAccessorType(XmlAccessType.FIELD)
public abstract class AbstractManagementPracticeData {

    /**
     * Serialization version.
     */
    private static final long serialVersionUID = 1L;

//    @XmlTransient
//    private String managementPracticeDataId;
//
//    @Column(name = "ICS_BS_MGMT_PRACTICES_ID", updatable = false, insertable = false)
//    public String getManagementPracticeDataId() {
//        return managementPracticeDataId;
//    }
//
//    public void setManagementPracticeDataId(String managementPracticeDataId) {
//        this.managementPracticeDataId = managementPracticeDataId;
//    }
}
