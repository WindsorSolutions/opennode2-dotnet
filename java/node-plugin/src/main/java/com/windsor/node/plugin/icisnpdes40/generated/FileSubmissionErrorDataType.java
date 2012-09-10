//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.2.4 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.09.10 at 12:24:29 PM PDT 
//


package com.windsor.node.plugin.icisnpdes40.generated;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
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
 * <p>Java class for FileSubmissionErrorDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="FileSubmissionErrorDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/icis/4}FileErrorReport" maxOccurs="unbounded" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "FileSubmissionErrorDataType", propOrder = {
    "fileErrorReport"
})
public class FileSubmissionErrorDataType
    implements Serializable, Equals, HashCode
{

    private final static long serialVersionUID = 1L;
    @XmlElement(name = "FileErrorReport")
    protected List<FileErrorReportDataType> fileErrorReport;

    /**
     * Gets the value of the fileErrorReport property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the fileErrorReport property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getFileErrorReport().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link FileErrorReportDataType }
     * 
     * 
     */
    public List<FileErrorReportDataType> getFileErrorReport() {
        if (fileErrorReport == null) {
            fileErrorReport = new ArrayList<FileErrorReportDataType>();
        }
        return this.fileErrorReport;
    }

    /**
     * 
     * 
     */
    public void setFileErrorReport(List<FileErrorReportDataType> fileErrorReport) {
        this.fileErrorReport = fileErrorReport;
    }

    public boolean isSetFileErrorReport() {
        return ((this.fileErrorReport!= null)&&(!this.fileErrorReport.isEmpty()));
    }

    public void unsetFileErrorReport() {
        this.fileErrorReport = null;
    }

    public boolean equals(ObjectLocator thisLocator, ObjectLocator thatLocator, Object object, EqualsStrategy strategy) {
        if (!(object instanceof FileSubmissionErrorDataType)) {
            return false;
        }
        if (this == object) {
            return true;
        }
        final FileSubmissionErrorDataType that = ((FileSubmissionErrorDataType) object);
        {
            List<FileErrorReportDataType> lhsFileErrorReport;
            lhsFileErrorReport = (this.isSetFileErrorReport()?this.getFileErrorReport():null);
            List<FileErrorReportDataType> rhsFileErrorReport;
            rhsFileErrorReport = (that.isSetFileErrorReport()?that.getFileErrorReport():null);
            if (!strategy.equals(LocatorUtils.property(thisLocator, "fileErrorReport", lhsFileErrorReport), LocatorUtils.property(thatLocator, "fileErrorReport", rhsFileErrorReport), lhsFileErrorReport, rhsFileErrorReport)) {
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
            List<FileErrorReportDataType> theFileErrorReport;
            theFileErrorReport = (this.isSetFileErrorReport()?this.getFileErrorReport():null);
            currentHashCode = strategy.hashCode(LocatorUtils.property(locator, "fileErrorReport", theFileErrorReport), currentHashCode, theFileErrorReport);
        }
        return currentHashCode;
    }

    public int hashCode() {
        final HashCodeStrategy strategy = JAXBHashCodeStrategy.INSTANCE;
        return this.hashCode(null, strategy);
    }

}
