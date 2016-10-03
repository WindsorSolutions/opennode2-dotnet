//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2016.06.15 at 06:46:14 PM EDT 
//


package com.windsor.node.plugin.rcra52.domain.generated;

import java.util.ArrayList;
import java.util.List;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.JoinColumn;
import javax.persistence.OneToMany;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
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
 * used to submit GIS data for a Handler, Area, or Unit
 * 
 * <p>Java class for GeographicInformationSubmissionDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="GeographicInformationSubmissionDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/RCRA/5}GISFacilitySubmission" maxOccurs="unbounded"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "GeographicInformationSubmissionDataType", propOrder = {
    "gisFacilitySubmission"
})
@Entity(name = "GeographicInformationSubmissionDataType")
@Table(name = "RCRA_GEOGINFSUB")
@Inheritance(strategy = InheritanceType.JOINED)
public class GeographicInformationSubmissionDataType
    implements Equals, HashCode
{

    @XmlElement(name = "GISFacilitySubmission", required = true)
    protected List<GISFacilitySubmissionDataType> gisFacilitySubmission;
    @XmlAttribute(name = "Id")
    protected Long id;

    /**
     * Gets the value of the gisFacilitySubmission property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the gisFacilitySubmission property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getGISFacilitySubmission().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link GISFacilitySubmissionDataType }
     * 
     * 
     */
    @OneToMany(targetEntity = GISFacilitySubmissionDataType.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "GEOINFSUBID")
    public List<GISFacilitySubmissionDataType> getGISFacilitySubmission() {
        if (gisFacilitySubmission == null) {
            gisFacilitySubmission = new ArrayList<GISFacilitySubmissionDataType>();
        }
        return this.gisFacilitySubmission;
    }

    /**
     * 
     * 
     */
    public void setGISFacilitySubmission(List<GISFacilitySubmissionDataType> gisFacilitySubmission) {
        this.gisFacilitySubmission = gisFacilitySubmission;
    }

    /**
     * Gets the value of the id property.
     * 
     * @return
     *     possible object is
     *     {@link Long }
     *     
     */
    @Id
    @Column(name = "ID")
    @GeneratedValue(generator = "ColSequence", strategy = GenerationType.AUTO)
    @SequenceGenerator(name = "ColSequence", sequenceName = "COLUMN_ID_SEQUENCE", allocationSize = 1)
    public Long getId() {
        return id;
    }

    /**
     * Sets the value of the id property.
     * 
     * @param value
     *     allowed object is
     *     {@link Long }
     *     
     */
    public void setId(Long value) {
        this.id = value;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof GeographicInformationSubmissionDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final GeographicInformationSubmissionDataType that = ((GeographicInformationSubmissionDataType) object);
        {
            List<GISFacilitySubmissionDataType> lhsGISFacilitySubmission;
            lhsGISFacilitySubmission = (((this.gisFacilitySubmission!= null)&&(!this.gisFacilitySubmission.isEmpty()))?this.getGISFacilitySubmission():null);
            List<GISFacilitySubmissionDataType> rhsGISFacilitySubmission;
            rhsGISFacilitySubmission = (((that.gisFacilitySubmission!= null)&&(!that.gisFacilitySubmission.isEmpty()))?that.getGISFacilitySubmission():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "gisFacilitySubmission", lhsGISFacilitySubmission), LocatorUtils.property(thatLocator, "gisFacilitySubmission", rhsGISFacilitySubmission), lhsGISFacilitySubmission, rhsGISFacilitySubmission)) {
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
            List<GISFacilitySubmissionDataType> theGISFacilitySubmission;
            theGISFacilitySubmission = (((this.gisFacilitySubmission!= null)&&(!this.gisFacilitySubmission.isEmpty()))?this.getGISFacilitySubmission():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "gisFacilitySubmission", theGISFacilitySubmission), currentHashCode, theGISFacilitySubmission);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}
