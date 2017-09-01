package com.windsor.node.plugin.icisnpdes.domain;

import com.windsor.node.plugin.icisnpdes.generated.Address;
import com.windsor.node.plugin.icisnpdes.generated.BiosolidsManagementPractices;
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
public abstract class AbstractThirdPartyProgramReportAddress {

    /**
     * Serialization version.
     */
    private static final long serialVersionUID = 1L;

//    @XmlTransient
//    private BiosolidsManagementPractices biosolidsManagementPractices;
//
//    @OneToOne(mappedBy = "managementPracticeData.thirdPartyProgramReportAddress", cascade = CascadeType.ALL, fetch = FetchType.LAZY, optional = false)
//    public BiosolidsManagementPractices getBiosolidsManagementPractices() {
//        return biosolidsManagementPractices;
//    }
//
//    public void setBiosolidsManagementPractices(BiosolidsManagementPractices biosolidsManagementPractices) {
//        this.biosolidsManagementPractices = biosolidsManagementPractices;
//    }
}
