//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, vJAXB 2.1.10 in JDK 6 
// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2012.01.24 at 11:33:47 AM PST 
//


package com.windsor.node.plugin.facid3.domain;

import java.math.BigInteger;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import javax.xml.datatype.XMLGregorianCalendar;


/**
 * <p>Java class for FacilityGeographicLocationDescriptionDataType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="FacilityGeographicLocationDescriptionDataType">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;choice>
 *           &lt;element ref="{http://www.opengis.net/gml}Point" minOccurs="0"/>
 *           &lt;element ref="{http://www.opengis.net/gml}LineString" minOccurs="0"/>
 *           &lt;element ref="{http://www.opengis.net/gml}Polygon" minOccurs="0"/>
 *           &lt;element ref="{http://www.opengis.net/gml}Envelope" minOccurs="0"/>
 *         &lt;/choice>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/facilityid/3}SourceMapScaleNumber" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/facilityid/3}HorizontalAccuracyMeasure" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/facilityid/3}HorizontalCollectionMethod" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/facilityid/3}GeographicReferencePoint" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/facilityid/3}DataCollectionDate" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/facilityid/3}LocationCommentsText" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/facilityid/3}VerticalCollectionMethod" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/facilityid/3}VerificationMethod" minOccurs="0"/>
 *         &lt;element ref="{http://www.exchangenetwork.net/schema/facilityid/3}CoordinateDataSource" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "FacilityGeographicLocationDescriptionDataType", propOrder = {
    "point",
    "lineString",
    "polygon",
    "envelope",
    "sourceMapScaleNumber",
    "horizontalAccuracyMeasure",
    "horizontalCollectionMethod",
    "geographicReferencePoint",
    "dataCollectionDate",
    "locationCommentsText",
    "verticalCollectionMethod",
    "verificationMethod",
    "coordinateDataSource"
})
public class FacilityGeographicLocationDescriptionDataType {

    @XmlElement(name = "Point", namespace = "http://www.opengis.net/gml")
    protected PointType point;
    @XmlElement(name = "LineString", namespace = "http://www.opengis.net/gml")
    protected LineStringType lineString;
    @XmlElement(name = "Polygon", namespace = "http://www.opengis.net/gml")
    protected PolygonType polygon;
    @XmlElement(name = "Envelope", namespace = "http://www.opengis.net/gml")
    protected EnvelopeType envelope;
    @XmlElement(name = "SourceMapScaleNumber")
    protected BigInteger sourceMapScaleNumber;
    @XmlElement(name = "HorizontalAccuracyMeasure")
    protected MeasureDataType horizontalAccuracyMeasure;
    @XmlElement(name = "HorizontalCollectionMethod")
    protected ReferenceMethodDataType horizontalCollectionMethod;
    @XmlElement(name = "GeographicReferencePoint")
    protected GeographicReferencePointDataType geographicReferencePoint;
    @XmlElement(name = "DataCollectionDate")
    protected XMLGregorianCalendar dataCollectionDate;
    @XmlElement(name = "LocationCommentsText")
    protected String locationCommentsText;
    @XmlElement(name = "VerticalCollectionMethod")
    protected ReferenceMethodDataType verticalCollectionMethod;
    @XmlElement(name = "VerificationMethod")
    protected ReferenceMethodDataType verificationMethod;
    @XmlElement(name = "CoordinateDataSource")
    protected CoordinateDataSourceDataType coordinateDataSource;

    /**
     * Gets the value of the point property.
     * 
     * @return
     *     possible object is
     *     {@link PointType }
     *     
     */
    public PointType getPoint() {
        return point;
    }

    /**
     * Sets the value of the point property.
     * 
     * @param value
     *     allowed object is
     *     {@link PointType }
     *     
     */
    public void setPoint(PointType value) {
        this.point = value;
    }

    /**
     * Gets the value of the lineString property.
     * 
     * @return
     *     possible object is
     *     {@link LineStringType }
     *     
     */
    public LineStringType getLineString() {
        return lineString;
    }

    /**
     * Sets the value of the lineString property.
     * 
     * @param value
     *     allowed object is
     *     {@link LineStringType }
     *     
     */
    public void setLineString(LineStringType value) {
        this.lineString = value;
    }

    /**
     * Gets the value of the polygon property.
     * 
     * @return
     *     possible object is
     *     {@link PolygonType }
     *     
     */
    public PolygonType getPolygon() {
        return polygon;
    }

    /**
     * Sets the value of the polygon property.
     * 
     * @param value
     *     allowed object is
     *     {@link PolygonType }
     *     
     */
    public void setPolygon(PolygonType value) {
        this.polygon = value;
    }

    /**
     * Gets the value of the envelope property.
     * 
     * @return
     *     possible object is
     *     {@link EnvelopeType }
     *     
     */
    public EnvelopeType getEnvelope() {
        return envelope;
    }

    /**
     * Sets the value of the envelope property.
     * 
     * @param value
     *     allowed object is
     *     {@link EnvelopeType }
     *     
     */
    public void setEnvelope(EnvelopeType value) {
        this.envelope = value;
    }

    /**
     * Gets the value of the sourceMapScaleNumber property.
     * 
     * @return
     *     possible object is
     *     {@link BigInteger }
     *     
     */
    public BigInteger getSourceMapScaleNumber() {
        return sourceMapScaleNumber;
    }

    /**
     * Sets the value of the sourceMapScaleNumber property.
     * 
     * @param value
     *     allowed object is
     *     {@link BigInteger }
     *     
     */
    public void setSourceMapScaleNumber(BigInteger value) {
        this.sourceMapScaleNumber = value;
    }

    /**
     * Gets the value of the horizontalAccuracyMeasure property.
     * 
     * @return
     *     possible object is
     *     {@link MeasureDataType }
     *     
     */
    public MeasureDataType getHorizontalAccuracyMeasure() {
        return horizontalAccuracyMeasure;
    }

    /**
     * Sets the value of the horizontalAccuracyMeasure property.
     * 
     * @param value
     *     allowed object is
     *     {@link MeasureDataType }
     *     
     */
    public void setHorizontalAccuracyMeasure(MeasureDataType value) {
        this.horizontalAccuracyMeasure = value;
    }

    /**
     * Gets the value of the horizontalCollectionMethod property.
     * 
     * @return
     *     possible object is
     *     {@link ReferenceMethodDataType }
     *     
     */
    public ReferenceMethodDataType getHorizontalCollectionMethod() {
        return horizontalCollectionMethod;
    }

    /**
     * Sets the value of the horizontalCollectionMethod property.
     * 
     * @param value
     *     allowed object is
     *     {@link ReferenceMethodDataType }
     *     
     */
    public void setHorizontalCollectionMethod(ReferenceMethodDataType value) {
        this.horizontalCollectionMethod = value;
    }

    /**
     * Gets the value of the geographicReferencePoint property.
     * 
     * @return
     *     possible object is
     *     {@link GeographicReferencePointDataType }
     *     
     */
    public GeographicReferencePointDataType getGeographicReferencePoint() {
        return geographicReferencePoint;
    }

    /**
     * Sets the value of the geographicReferencePoint property.
     * 
     * @param value
     *     allowed object is
     *     {@link GeographicReferencePointDataType }
     *     
     */
    public void setGeographicReferencePoint(GeographicReferencePointDataType value) {
        this.geographicReferencePoint = value;
    }

    /**
     * Gets the value of the dataCollectionDate property.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public XMLGregorianCalendar getDataCollectionDate() {
        return dataCollectionDate;
    }

    /**
     * Sets the value of the dataCollectionDate property.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setDataCollectionDate(XMLGregorianCalendar value) {
        this.dataCollectionDate = value;
    }

    /**
     * Gets the value of the locationCommentsText property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getLocationCommentsText() {
        return locationCommentsText;
    }

    /**
     * Sets the value of the locationCommentsText property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setLocationCommentsText(String value) {
        this.locationCommentsText = value;
    }

    /**
     * Gets the value of the verticalCollectionMethod property.
     * 
     * @return
     *     possible object is
     *     {@link ReferenceMethodDataType }
     *     
     */
    public ReferenceMethodDataType getVerticalCollectionMethod() {
        return verticalCollectionMethod;
    }

    /**
     * Sets the value of the verticalCollectionMethod property.
     * 
     * @param value
     *     allowed object is
     *     {@link ReferenceMethodDataType }
     *     
     */
    public void setVerticalCollectionMethod(ReferenceMethodDataType value) {
        this.verticalCollectionMethod = value;
    }

    /**
     * Gets the value of the verificationMethod property.
     * 
     * @return
     *     possible object is
     *     {@link ReferenceMethodDataType }
     *     
     */
    public ReferenceMethodDataType getVerificationMethod() {
        return verificationMethod;
    }

    /**
     * Sets the value of the verificationMethod property.
     * 
     * @param value
     *     allowed object is
     *     {@link ReferenceMethodDataType }
     *     
     */
    public void setVerificationMethod(ReferenceMethodDataType value) {
        this.verificationMethod = value;
    }

    /**
     * Gets the value of the coordinateDataSource property.
     * 
     * @return
     *     possible object is
     *     {@link CoordinateDataSourceDataType }
     *     
     */
    public CoordinateDataSourceDataType getCoordinateDataSource() {
        return coordinateDataSource;
    }

    /**
     * Sets the value of the coordinateDataSource property.
     * 
     * @param value
     *     allowed object is
     *     {@link CoordinateDataSourceDataType }
     *     
     */
    public void setCoordinateDataSource(CoordinateDataSourceDataType value) {
        this.coordinateDataSource = value;
    }

}
