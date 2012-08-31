//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.08.31 at 05:44:03 AM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlTransient;
import javax.xml.bind.annotation.XmlType;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for DMRProgramReportLinkage complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="DMRProgramReportLinkage">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/4}DischargeMonitoringReportKeyElements">
 *       &lt;choice>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LinkageBiosolidsReport"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LinkageSWEventReport"/>
 *       &lt;/choice>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "DMRProgramReportLinkage", propOrder = {
    "linkageBiosolidsReport",
    "linkageSWEventReport"
})
@Entity(name = "DMRProgramReportLinkage")
@Table(name = "ICS_DMR_PROG_REP_LNK")
@Inheritance(strategy = InheritanceType.JOINED)
public class DMRProgramReportLinkage
    extends DischargeMonitoringReportKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "LinkageBiosolidsReport")
    protected LinkageBiosolidsReport linkageBiosolidsReport;
    @XmlElement(name = "LinkageSWEventReport")
    protected LinkageSWEventReport linkageSWEventReport;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the linkageBiosolidsReport property.
     * 
     * @return
     *     possible object is
     *     {@link LinkageBiosolidsReport }
     *     
     */
    @ManyToOne(targetEntity = LinkageBiosolidsReport.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_DMR_PROG_REP_LNK_ID", insertable = false, updatable = false)
    public LinkageBiosolidsReport getLinkageBiosolidsReport() {
        return linkageBiosolidsReport;
    }

    /**
     * Sets the value of the linkageBiosolidsReport property.
     * 
     * @param value
     *     allowed object is
     *     {@link LinkageBiosolidsReport }
     *     
     */
    public void setLinkageBiosolidsReport(LinkageBiosolidsReport value) {
        this.linkageBiosolidsReport = value;
    }

    @Transient
    public boolean isSetLinkageBiosolidsReport() {
        return (this.linkageBiosolidsReport!= null);
    }

    /**
     * Gets the value of the linkageSWEventReport property.
     * 
     * @return
     *     possible object is
     *     {@link LinkageSWEventReport }
     *     
     */
    @ManyToOne(targetEntity = LinkageSWEventReport.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_DMR_PROG_REP_LNK_ID", insertable = false, updatable = false)
    public LinkageSWEventReport getLinkageSWEventReport() {
        return linkageSWEventReport;
    }

    /**
     * Sets the value of the linkageSWEventReport property.
     * 
     * @param value
     *     allowed object is
     *     {@link LinkageSWEventReport }
     *     
     */
    public void setLinkageSWEventReport(LinkageSWEventReport value) {
        this.linkageSWEventReport = value;
    }

    @Transient
    public boolean isSetLinkageSWEventReport() {
        return (this.linkageSWEventReport!= null);
    }

    /**
     * 
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Id
    @Column(name = "ICS_DMR_PROG_REP_LNK_ID")
    public String getdbid() {
        return dbid;
    }

    /**
     * 
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setdbid(String value) {
        this.dbid = value;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof DMRProgramReportLinkage)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final DMRProgramReportLinkage that = ((DMRProgramReportLinkage) object);
        {
            LinkageBiosolidsReport lhsLinkageBiosolidsReport;
            lhsLinkageBiosolidsReport = this.getLinkageBiosolidsReport();
            LinkageBiosolidsReport rhsLinkageBiosolidsReport;
            rhsLinkageBiosolidsReport = that.getLinkageBiosolidsReport();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "linkageBiosolidsReport", lhsLinkageBiosolidsReport), LocatorUtils.property(thatLocator, "linkageBiosolidsReport", rhsLinkageBiosolidsReport), lhsLinkageBiosolidsReport, rhsLinkageBiosolidsReport)) {
                return false;
            }
        }
        {
            LinkageSWEventReport lhsLinkageSWEventReport;
            lhsLinkageSWEventReport = this.getLinkageSWEventReport();
            LinkageSWEventReport rhsLinkageSWEventReport;
            rhsLinkageSWEventReport = that.getLinkageSWEventReport();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "linkageSWEventReport", lhsLinkageSWEventReport), LocatorUtils.property(thatLocator, "linkageSWEventReport", rhsLinkageSWEventReport), lhsLinkageSWEventReport, rhsLinkageSWEventReport)) {
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
        int currentHashCode = super.hashCode(locator, strategy);
        {
            LinkageBiosolidsReport theLinkageBiosolidsReport;
            theLinkageBiosolidsReport = this.getLinkageBiosolidsReport();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "linkageBiosolidsReport", theLinkageBiosolidsReport), currentHashCode, theLinkageBiosolidsReport);
        }
        {
            LinkageSWEventReport theLinkageSWEventReport;
            theLinkageSWEventReport = this.getLinkageSWEventReport();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "linkageSWEventReport", theLinkageSWEventReport), currentHashCode, theLinkageSWEventReport);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}
