//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.11 at 01:40:11 PM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.JoinColumn;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlTransient;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import com.windsor.node.plugin.icisnpdes40.adapter.IntegerAdapter;
import org.jvnet.jaxb2_commons.lang.Equals;
import org.jvnet.jaxb2_commons.lang.EqualsStrategy;
import org.jvnet.jaxb2_commons.lang.HashCode;
import org.jvnet.jaxb2_commons.lang.HashCodeStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBEqualsStrategy;
import org.jvnet.jaxb2_commons.lang.JAXBHashCodeStrategy;
import org.jvnet.jaxb2_commons.locator.ObjectLocator;
import org.jvnet.jaxb2_commons.locator.util.LocatorUtils;


/**
 * <p>Java class for ReportParameter complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ReportParameter">
 *   &lt;complexContent>
 *     &lt;extension base="{http://www.exchangenetwork.net/schema/icis/4}ParameterKeyElements">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}ReportSampleTypeText" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}ReportingFrequencyCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}ReportNumberOfExcursions" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}ConcentrationNumericReportUnitMeasureCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}QuantityNumericReportUnitMeasureCode" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}NumericReport" maxOccurs="5" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ReportParameter", propOrder = {
    "reportSampleTypeText",
    "reportingFrequencyCode",
    "reportNumberOfExcursions",
    "concentrationNumericReportUnitMeasureCode",
    "quantityNumericReportUnitMeasureCode",
    "numericReport"
})
@Entity(name = "ReportParameter")
@Table(name = "ICS_REP_PARAM")
@Inheritance(strategy = InheritanceType.JOINED)
public class ReportParameter
    extends ParameterKeyElements
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "ReportSampleTypeText")
    protected String reportSampleTypeText;
    @XmlElement(name = "ReportingFrequencyCode")
    protected String reportingFrequencyCode;
    @XmlElement(name = "ReportNumberOfExcursions", type = String.class)
    @XmlJavaTypeAdapter(IntegerAdapter.class)
    protected Integer reportNumberOfExcursions;
    @XmlElement(name = "ConcentrationNumericReportUnitMeasureCode")
    protected String concentrationNumericReportUnitMeasureCode;
    @XmlElement(name = "QuantityNumericReportUnitMeasureCode")
    protected String quantityNumericReportUnitMeasureCode;
    @XmlElement(name = "NumericReport")
    protected List<NumericReport> numericReport;
    @XmlTransient
    protected String dbid;

    /**
     * Gets the value of the reportSampleTypeText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "REP_SMPL_TYPE_TXT", length = 3)
    public String getReportSampleTypeText() {
        return reportSampleTypeText;
    }

    /**
     * Sets the value of the reportSampleTypeText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setReportSampleTypeText(String value) {
        this.reportSampleTypeText = value;
    }

    @Transient
    public boolean isSetReportSampleTypeText() {
        return (this.reportSampleTypeText!= null);
    }

    /**
     * Gets the value of the reportingFrequencyCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "REP_FREQ_CODE", length = 5)
    public String getReportingFrequencyCode() {
        return reportingFrequencyCode;
    }

    /**
     * Sets the value of the reportingFrequencyCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setReportingFrequencyCode(String value) {
        this.reportingFrequencyCode = value;
    }

    @Transient
    public boolean isSetReportingFrequencyCode() {
        return (this.reportingFrequencyCode!= null);
    }

    /**
     * Gets the value of the reportNumberOfExcursions property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "REP_NUM_OF_EXCURSIONS", scale = 0)
    public Integer getReportNumberOfExcursions() {
        return reportNumberOfExcursions;
    }

    /**
     * Sets the value of the reportNumberOfExcursions property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setReportNumberOfExcursions(Integer value) {
        this.reportNumberOfExcursions = value;
    }

    @Transient
    public boolean isSetReportNumberOfExcursions() {
        return (this.reportNumberOfExcursions!= null);
    }

    /**
     * Gets the value of the concentrationNumericReportUnitMeasureCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "CONCEN_NUM_REP_UNIT_MEAS_CODE", length = 2)
    public String getConcentrationNumericReportUnitMeasureCode() {
        return concentrationNumericReportUnitMeasureCode;
    }

    /**
     * Sets the value of the concentrationNumericReportUnitMeasureCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setConcentrationNumericReportUnitMeasureCode(String value) {
        this.concentrationNumericReportUnitMeasureCode = value;
    }

    @Transient
    public boolean isSetConcentrationNumericReportUnitMeasureCode() {
        return (this.concentrationNumericReportUnitMeasureCode!= null);
    }

    /**
     * Gets the value of the quantityNumericReportUnitMeasureCode property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    @Basic
    @Column(name = "QTY_NUM_REP_UNIT_MEAS_CODE", length = 2)
    public String getQuantityNumericReportUnitMeasureCode() {
        return quantityNumericReportUnitMeasureCode;
    }

    /**
     * Sets the value of the quantityNumericReportUnitMeasureCode property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setQuantityNumericReportUnitMeasureCode(String value) {
        this.quantityNumericReportUnitMeasureCode = value;
    }

    @Transient
    public boolean isSetQuantityNumericReportUnitMeasureCode() {
        return (this.quantityNumericReportUnitMeasureCode!= null);
    }

    /**
     * Gets the value of the numericReport property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the numericReport property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getNumericReport().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link NumericReport }
     * 
     * 
     */
    @OneToMany(targetEntity = NumericReport.class, cascade = {
        CascadeType.ALL
    })
    @JoinColumn(name = "ICS_REP_PARAM_ID")
    public List<NumericReport> getNumericReport() {
        if (numericReport == null) {
            numericReport = new ArrayList<NumericReport>();
        }
        return this.numericReport;
    }

    /**
     * 
     * 
     */
    public void setNumericReport(List<NumericReport> numericReport) {
        this.numericReport = numericReport;
    }

    @Transient
    public boolean isSetNumericReport() {
        return ((this.numericReport!= null)&&(!this.numericReport.isEmpty()));
    }

    public void unsetNumericReport() {
        this.numericReport = null;
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
    @Column(name = "ICS_REP_PARAM_ID")
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
        if (!(object instanceof ReportParameter)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        if (!super.equals(thisLocator, thatLocator, object, strategy)) {
            return false;
        }
        final ReportParameter that = ((ReportParameter) object);
        {
            String lhsReportSampleTypeText;
            lhsReportSampleTypeText = this.getReportSampleTypeText();
            String rhsReportSampleTypeText;
            rhsReportSampleTypeText = that.getReportSampleTypeText();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "reportSampleTypeText", lhsReportSampleTypeText), LocatorUtils.property(thatLocator, "reportSampleTypeText", rhsReportSampleTypeText), lhsReportSampleTypeText, rhsReportSampleTypeText)) {
                return false;
            }
        }
        {
            String lhsReportingFrequencyCode;
            lhsReportingFrequencyCode = this.getReportingFrequencyCode();
            String rhsReportingFrequencyCode;
            rhsReportingFrequencyCode = that.getReportingFrequencyCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "reportingFrequencyCode", lhsReportingFrequencyCode), LocatorUtils.property(thatLocator, "reportingFrequencyCode", rhsReportingFrequencyCode), lhsReportingFrequencyCode, rhsReportingFrequencyCode)) {
                return false;
            }
        }
        {
            Integer lhsReportNumberOfExcursions;
            lhsReportNumberOfExcursions = this.getReportNumberOfExcursions();
            Integer rhsReportNumberOfExcursions;
            rhsReportNumberOfExcursions = that.getReportNumberOfExcursions();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "reportNumberOfExcursions", lhsReportNumberOfExcursions), LocatorUtils.property(thatLocator, "reportNumberOfExcursions", rhsReportNumberOfExcursions), lhsReportNumberOfExcursions, rhsReportNumberOfExcursions)) {
                return false;
            }
        }
        {
            String lhsConcentrationNumericReportUnitMeasureCode;
            lhsConcentrationNumericReportUnitMeasureCode = this.getConcentrationNumericReportUnitMeasureCode();
            String rhsConcentrationNumericReportUnitMeasureCode;
            rhsConcentrationNumericReportUnitMeasureCode = that.getConcentrationNumericReportUnitMeasureCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "concentrationNumericReportUnitMeasureCode", lhsConcentrationNumericReportUnitMeasureCode), LocatorUtils.property(thatLocator, "concentrationNumericReportUnitMeasureCode", rhsConcentrationNumericReportUnitMeasureCode), lhsConcentrationNumericReportUnitMeasureCode, rhsConcentrationNumericReportUnitMeasureCode)) {
                return false;
            }
        }
        {
            String lhsQuantityNumericReportUnitMeasureCode;
            lhsQuantityNumericReportUnitMeasureCode = this.getQuantityNumericReportUnitMeasureCode();
            String rhsQuantityNumericReportUnitMeasureCode;
            rhsQuantityNumericReportUnitMeasureCode = that.getQuantityNumericReportUnitMeasureCode();
            if (!strategy.equals(LocatorUtils.property(thisLocator, "quantityNumericReportUnitMeasureCode", lhsQuantityNumericReportUnitMeasureCode), LocatorUtils.property(thatLocator, "quantityNumericReportUnitMeasureCode", rhsQuantityNumericReportUnitMeasureCode), lhsQuantityNumericReportUnitMeasureCode, rhsQuantityNumericReportUnitMeasureCode)) {
                return false;
            }
        }
        {
            List<NumericReport> lhsNumericReport;
            lhsNumericReport = (this.isSetNumericReport()?this.getNumericReport():null);
            List<NumericReport> rhsNumericReport;
            rhsNumericReport = (that.isSetNumericReport()?that.getNumericReport():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "numericReport", lhsNumericReport), LocatorUtils.property(thatLocator, "numericReport", rhsNumericReport), lhsNumericReport, rhsNumericReport)) {
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
            String theReportSampleTypeText;
            theReportSampleTypeText = this.getReportSampleTypeText();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "reportSampleTypeText", theReportSampleTypeText), currentHashCode, theReportSampleTypeText);
        }
        {
            String theReportingFrequencyCode;
            theReportingFrequencyCode = this.getReportingFrequencyCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "reportingFrequencyCode", theReportingFrequencyCode), currentHashCode, theReportingFrequencyCode);
        }
        {
            Integer theReportNumberOfExcursions;
            theReportNumberOfExcursions = this.getReportNumberOfExcursions();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "reportNumberOfExcursions", theReportNumberOfExcursions), currentHashCode, theReportNumberOfExcursions);
        }
        {
            String theConcentrationNumericReportUnitMeasureCode;
            theConcentrationNumericReportUnitMeasureCode = this.getConcentrationNumericReportUnitMeasureCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "concentrationNumericReportUnitMeasureCode", theConcentrationNumericReportUnitMeasureCode), currentHashCode, theConcentrationNumericReportUnitMeasureCode);
        }
        {
            String theQuantityNumericReportUnitMeasureCode;
            theQuantityNumericReportUnitMeasureCode = this.getQuantityNumericReportUnitMeasureCode();
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "quantityNumericReportUnitMeasureCode", theQuantityNumericReportUnitMeasureCode), currentHashCode, theQuantityNumericReportUnitMeasureCode);
        }
        {
            List<NumericReport> theNumericReport;
            theNumericReport = (this.isSetNumericReport()?this.getNumericReport():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "numericReport", theNumericReport), currentHashCode, theNumericReport);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}
