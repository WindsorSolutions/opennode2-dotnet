//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.10 at 06:26:27 AM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import javax.persistence.CascadeType;
import javax.persistence.Embeddable;
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
 * <p>Java class for LocalLimitsProgramReport complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="LocalLimitsProgramReport">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/4}LocalLimitsProgramReportKeyElements">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}LocalLimits" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}RemovalCredits" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "LocalLimitsProgramReport", propOrder = {
    "localLimits",
    "removalCredits"
})
@Embeddable
public class LocalLimitsProgramReport
    extends LocalLimitsProgramReportKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "LocalLimits")
    protected LocalLimits localLimits;
    @XmlElement(name = "RemovalCredits")
    protected RemovalCredits removalCredits;

    /**
     * Gets the value of the localLimits property.
     * 
     * @return
     *     possible object is
     *     {@link LocalLimits }
     *     
     */
    @OneToOne(targetEntity = LocalLimits.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_LOC_LMTS_PROG_REP_ID")
    public LocalLimits getLocalLimits() {
        return localLimits;
    }

    /**
     * Sets the value of the localLimits property.
     * 
     * @param value
     *     allowed object is
     *     {@link LocalLimits }
     *     
     */
    public void setLocalLimits(LocalLimits value) {
        this.localLimits = value;
    }

    @Transient
    public boolean isSetLocalLimits() {
        return (this.localLimits!= null);
    }

    /**
     * Gets the value of the removalCredits property.
     * 
     * @return
     *     possible object is
     *     {@link RemovalCredits }
     *     
     */
    @OneToOne(targetEntity = RemovalCredits.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_LOC_LMTS_PROG_REP_ID")
    public RemovalCredits getRemovalCredits() {
        return removalCredits;
    }

    /**
     * Sets the value of the removalCredits property.
     * 
     * @param value
     *     allowed object is
     *     {@link RemovalCredits }
     *     
     */
    public void setRemovalCredits(RemovalCredits value) {
        this.removalCredits = value;
    }

    @Transient
    public boolean isSetRemovalCredits() {
        return (this.removalCredits!= null);
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof LocalLimitsProgramReport)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final LocalLimitsProgramReport that = ((LocalLimitsProgramReport) object);
        {
            LocalLimits lhsLocalLimits;
            lhsLocalLimits = this.getLocalLimits();
            LocalLimits rhsLocalLimits;
            rhsLocalLimits = that.getLocalLimits();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "localLimits", lhsLocalLimits), LocatorUtils.property(thatLocator, "localLimits", rhsLocalLimits), lhsLocalLimits, rhsLocalLimits)) {
                return false;
            }
        }
        {
            RemovalCredits lhsRemovalCredits;
            lhsRemovalCredits = this.getRemovalCredits();
            RemovalCredits rhsRemovalCredits;
            rhsRemovalCredits = that.getRemovalCredits();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "removalCredits", lhsRemovalCredits), LocatorUtils.property(thatLocator, "removalCredits", rhsRemovalCredits), lhsRemovalCredits, rhsRemovalCredits)) {
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
            LocalLimits theLocalLimits;
            theLocalLimits = this.getLocalLimits();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "localLimits", theLocalLimits), currentHashCode, theLocalLimits);
        }
        {
            RemovalCredits theRemovalCredits;
            theRemovalCredits = this.getRemovalCredits();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "removalCredits", theRemovalCredits), currentHashCode, theRemovalCredits);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}
