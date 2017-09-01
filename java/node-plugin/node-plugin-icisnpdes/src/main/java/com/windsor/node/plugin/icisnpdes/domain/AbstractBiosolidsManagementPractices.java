package com.windsor.node.plugin.icisnpdes.domain;

import com.windsor.node.plugin.icisnpdes.generated.BiosolidsAnnualProgramReport;

import javax.persistence.*;
import javax.xml.bind.annotation.*;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

@MappedSuperclass
@XmlAccessorType(XmlAccessType.FIELD)
public abstract class AbstractBiosolidsManagementPractices implements Serializable {

    /**
     * Serialization version.
     */
    private static final long serialVersionUID = 1L;

    @XmlTransient
    private BiosolidsAnnualProgramReport biosolidsAnnualProgramReport;

    @OneToOne(fetch=FetchType.LAZY)
    @JoinColumn(name="ICS_BS_ANNUL_PROG_REP_ID")
    public BiosolidsAnnualProgramReport getBiosolidsAnnualProgramReport() {
        return biosolidsAnnualProgramReport;
    }

    public void setBiosolidsAnnualProgramReport(BiosolidsAnnualProgramReport biosolidsAnnualProgramReport) {
        this.biosolidsAnnualProgramReport = biosolidsAnnualProgramReport;
    }
}
