//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2014.09.02 at 11:05:46 AM PDT 
//


package com.windsor.node.plugin.icisair.domain.generated;

import java.io.Serializable;

import javax.persistence.CascadeType;
import javax.persistence.Embeddable;
import javax.persistence.Embedded;
import javax.persistence.JoinColumn;
import javax.persistence.OneToOne;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
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
 * <p>Java class for ComplianceMonitoringLinkage complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ComplianceMonitoringLinkage">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/5}ComplianceMonitoringKeyElements">
 *       &lt;choice>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}LinkageComplianceMonitoring"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/5}LinkageAirDAEnforcementAction"/>
 *       &lt;/choice>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ComplianceMonitoringLinkage", propOrder = {
    "linkageComplianceMonitoring",
    "linkageAirDAEnforcementAction"
})
@Embeddable
public class ComplianceMonitoringLinkage
    extends ComplianceMonitoringKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "LinkageComplianceMonitoring")
    protected LinkageComplianceMonitoring linkageComplianceMonitoring;
    @XmlElement(name = "LinkageAirDAEnforcementAction")
    protected LinkageAirDAEnforcementAction linkageAirDAEnforcementAction;

    /**
     * Gets the value of the linkageComplianceMonitoring property.
     * 
     * @return
     *     possible object is
     *     {@link LinkageComplianceMonitoring }
     *     
     */
    /*@OneToOne(targetEntity = LinkageComplianceMonitoring.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICA_CMPL_MON_LNK_ID")*/
    @Embedded
    public LinkageComplianceMonitoring getLinkageComplianceMonitoring() {
        return linkageComplianceMonitoring;
    }

    /**
     * Sets the value of the linkageComplianceMonitoring property.
     * 
     * @param value
     *     allowed object is
     *     {@link LinkageComplianceMonitoring }
     *     
     */
    public void setLinkageComplianceMonitoring(LinkageComplianceMonitoring value) {
        this.linkageComplianceMonitoring = value;
    }

    @Transient
    public boolean isSetLinkageComplianceMonitoring() {
        return (this.linkageComplianceMonitoring!= null);
    }

    /**
     * Gets the value of the linkageAirDAEnforcementAction property.
     * 
     * @return
     *     possible object is
     *     {@link LinkageAirDAEnforcementAction }
     *     
     */
    /*@OneToOne(targetEntity = LinkageAirDAEnforcementAction.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICA_CMPL_MON_LNK_ID")*/
    @Embedded
    public LinkageAirDAEnforcementAction getLinkageAirDAEnforcementAction() {
        return linkageAirDAEnforcementAction;
    }

    /**
     * Sets the value of the linkageAirDAEnforcementAction property.
     * 
     * @param value
     *     allowed object is
     *     {@link LinkageAirDAEnforcementAction }
     *     
     */
    public void setLinkageAirDAEnforcementAction(LinkageAirDAEnforcementAction value) {
        this.linkageAirDAEnforcementAction = value;
    }

    @Transient
    public boolean isSetLinkageAirDAEnforcementAction() {
        return (this.linkageAirDAEnforcementAction!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof ComplianceMonitoringLinkage)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final ComplianceMonitoringLinkage that = ((ComplianceMonitoringLinkage) object);
        {
            LinkageComplianceMonitoring lhsLinkageComplianceMonitoring;
            lhsLinkageComplianceMonitoring = this.getLinkageComplianceMonitoring();
            LinkageComplianceMonitoring rhsLinkageComplianceMonitoring;
            rhsLinkageComplianceMonitoring = that.getLinkageComplianceMonitoring();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "linkageComplianceMonitoring", lhsLinkageComplianceMonitoring), LocatorUtils.property(thatLocator, "linkageComplianceMonitoring", rhsLinkageComplianceMonitoring), lhsLinkageComplianceMonitoring, rhsLinkageComplianceMonitoring)) {
                return false;
            }
        }
        {
            LinkageAirDAEnforcementAction lhsLinkageAirDAEnforcementAction;
            lhsLinkageAirDAEnforcementAction = this.getLinkageAirDAEnforcementAction();
            LinkageAirDAEnforcementAction rhsLinkageAirDAEnforcementAction;
            rhsLinkageAirDAEnforcementAction = that.getLinkageAirDAEnforcementAction();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "linkageAirDAEnforcementAction", lhsLinkageAirDAEnforcementAction), LocatorUtils.property(thatLocator, "linkageAirDAEnforcementAction", rhsLinkageAirDAEnforcementAction), lhsLinkageAirDAEnforcementAction, rhsLinkageAirDAEnforcementAction)) {
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
            LinkageComplianceMonitoring theLinkageComplianceMonitoring;
            theLinkageComplianceMonitoring = this.getLinkageComplianceMonitoring();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "linkageComplianceMonitoring", theLinkageComplianceMonitoring), currentHashCode, theLinkageComplianceMonitoring);
        }
        {
            LinkageAirDAEnforcementAction theLinkageAirDAEnforcementAction;
            theLinkageAirDAEnforcementAction = this.getLinkageAirDAEnforcementAction();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "linkageAirDAEnforcementAction", theLinkageAirDAEnforcementAction), currentHashCode, theLinkageAirDAEnforcementAction);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}
