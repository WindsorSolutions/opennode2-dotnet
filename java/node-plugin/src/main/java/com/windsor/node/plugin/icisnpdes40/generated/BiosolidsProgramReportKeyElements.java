//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.03 at 11:14:37 AM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.MappedSuperclass;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlSchemaType;
import javax.xml.bind.annotation.XmlSeeAlso;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import com.windsor.node.plugin.icisnpdes40.adapter.DateAdapter;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for BiosolidsProgramReportKeyElements complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="BiosolidsProgramReportKeyElements">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;group ref="{http://www.exchangenetwork.net/schema/icis/4}BiosolidsProgramReportKeyElementsGroup"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "BiosolidsProgramReportKeyElements", propOrder = {
    "permitIdentifier",
    "reportCoverageEndDate"
})
@XmlSeeAlso({
    BiosolidsProgramReport.class
})
@MappedSuperclass
public class BiosolidsProgramReportKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "PermitIdentifier", required = true)
    protected String permitIdentifier;
    @XmlElement(name = "ReportCoverageEndDate", required = true, type = String.class)
    @XmlJavaTypeAdapter(DateAdapter.class)
    @XmlSchemaType(name = "date")
    protected Date reportCoverageEndDate;

    /**
     * Gets the value of the permitIdentifier property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "PRMT_IDENT", columnDefinition = "char(9)", length = 9)
    public String getPermitIdentifier() {
        return permitIdentifier;
    }

    /**
     * Sets the value of the permitIdentifier property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setPermitIdentifier(String value) {
        this.permitIdentifier = value;
    }

    @Transient
    public boolean isSetPermitIdentifier() {
        return (this.permitIdentifier!= null);
    }

    /**
     * Gets the value of the reportCoverageEndDate property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "REP_COVERAGE_END_DATE")
    @Temporal(TemporalType.DATE)
    public Date getReportCoverageEndDate() {
        return reportCoverageEndDate;
    }

    /**
     * Sets the value of the reportCoverageEndDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setReportCoverageEndDate(Date value) {
        this.reportCoverageEndDate = value;
    }

    @Transient
    public boolean isSetReportCoverageEndDate() {
        return (this.reportCoverageEndDate!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof BiosolidsProgramReportKeyElements)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final BiosolidsProgramReportKeyElements that = ((BiosolidsProgramReportKeyElements) object);
        {
            String lhsPermitIdentifier;
            lhsPermitIdentifier = this.getPermitIdentifier();
            String rhsPermitIdentifier;
            rhsPermitIdentifier = that.getPermitIdentifier();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "permitIdentifier", lhsPermitIdentifier), LocatorUtils.property(thatLocator, "permitIdentifier", rhsPermitIdentifier), lhsPermitIdentifier, rhsPermitIdentifier)) {
                return false;
            }
        }
        {
            Date lhsReportCoverageEndDate;
            lhsReportCoverageEndDate = this.getReportCoverageEndDate();
            Date rhsReportCoverageEndDate;
            rhsReportCoverageEndDate = that.getReportCoverageEndDate();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "reportCoverageEndDate", lhsReportCoverageEndDate), LocatorUtils.property(thatLocator, "reportCoverageEndDate", rhsReportCoverageEndDate), lhsReportCoverageEndDate, rhsReportCoverageEndDate)) {
                return false;
            }
        }
        return true;
    }

    public boolean equals(Object object) {
        final EqualsStrategy strategy = JAXBEqualsStrategy.INSTANCE;
        return equals(null, null, object, strategy);
    }

    public int hashCode(ObjectLocator locator, HashCodeStrategy strategy) {
        int currentHashCode = 1;
        {
            String thePermitIdentifier;
            thePermitIdentifier = this.getPermitIdentifier();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "permitIdentifier", thePermitIdentifier), currentHashCode, thePermitIdentifier);
        }
        {
            Date theReportCoverageEndDate;
            theReportCoverageEndDate = this.getReportCoverageEndDate();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "reportCoverageEndDate", theReportCoverageEndDate), currentHashCode, theReportCoverageEndDate);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}
