#region License
/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Windsor.Node2008.WNOSPlugin.PNWWQX
{


    #region RootElements

	[System.Xml.Serialization.XmlRootAttribute("PNWWQXProjects", Namespace="urn:us:net:exchangenetwork", IsNullable=false)]
    public class PNWWQXProjects
    {

		public PNWWQXProjects()		
		{
			XmlDocument d = new XmlDocument();
			XmlAttribute xsi = d.CreateAttribute("xsi", "schemaLocation", XmlSchema.InstanceNamespace);
			xsi.Value = "urn:us:net:exchangenetwork http://www.exchangenetwork.net/Registry/PNWWQX_Projects_v.1.3.xsd";
			this.XAttributes = new XmlAttribute[] {xsi};
			xmlns = new XmlSerializerNamespaces();
			xmlns.Add("pnwwqx", "urn:us:net:exchangenetwork");
		}

		[XmlAnyAttribute]
		public XmlAttribute[] XAttributes;

		[XmlNamespaceDeclarations]
		public XmlSerializerNamespaces xmlns;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PNWWQXProjectsList")]
        public PNWWQXProjectsList[] PNWWQXProjectsList;
    }


	[System.Xml.Serialization.XmlRootAttribute("PNWWQXStations", Namespace="urn:us:net:exchangenetwork", IsNullable=false)]
    public class PNWWQXStations
    {
    
		public PNWWQXStations()	
		{
			XmlDocument d = new XmlDocument();
			XmlAttribute xsi = d.CreateAttribute("xsi", "schemaLocation", XmlSchema.InstanceNamespace);
			xsi.Value = "urn:us:net:exchangenetwork http://www.exchangenetwork.net/Registry/PNWWQX_Stations_v.1.3.xsd";
			this.XAttributes = new XmlAttribute[] {xsi};
			xmlns = new XmlSerializerNamespaces();
			xmlns.Add("pnwwqx", "urn:us:net:exchangenetwork");
		}

		[XmlAnyAttribute]
		public XmlAttribute[] XAttributes;

		[XmlNamespaceDeclarations]
		public XmlSerializerNamespaces xmlns;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PNWWQXStationsList")]
        public PNWWQXStationsList[] PNWWQXStationsList;
    }


    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:us:net:exchangenetwork")]
    [System.Xml.Serialization.XmlRootAttribute("PNWWQXMeasurements", Namespace="urn:us:net:exchangenetwork", IsNullable=false)]
    public class PNWWQXMeasurements
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PNWWQXMeasurementsList")]
        public PNWWQXMeasurementsList[] PNWWQXMeasurementsList;

		public PNWWQXMeasurements()
		{
			XmlDocument d = new XmlDocument();

			XmlAttribute xsi = d.CreateAttribute("xsi", "schemaLocation", XmlSchema.InstanceNamespace);
			xsi.Value = "urn:us:net:exchangenetwork http://www.exchangenetwork.net/Registry/PNWWQX_Measurements_v.1.3.xsd";

			this.XAttributes = new XmlAttribute[] {xsi};

            xmlns = new XmlSerializerNamespaces();
            xmlns.Add("pnwwqx", "urn:us:net:exchangenetwork");

		}

		[XmlAnyAttribute]
		public XmlAttribute[] XAttributes;

        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns;

    }

    #endregion


    public class PNWWQXProjectsList 
    {
    
        /// <remarks/>
        public ProvidingOrganizationDetailsType ProvidingOrganizationDetails;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectDetails")]
        public ProjectDetails_ForProjects[] ProjectDetails;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ContactEntityDetails")]
        public ContactEntityDetails[] ContactEntityDetails;
    }


    public class ProvidingOrganizationDetailsType 
    {
    
        /// <remarks/>
        public string ProvidingOrganizationIdentifier;
    
        /// <remarks/>
        public string ProvidingOrganizationName;
    
        /// <remarks/>
        public string ProvidingOrganizationType;
    
        /// <remarks/>
        public string ProvidingOrganizationContactName;
    
        /// <remarks/>
        public MailingAddressType ProvidingOrganizationMailingAddress;
    
        /// <remarks/>
        public PhoneEmailType ProvidingOrganizationPhoneEmail;
    
        /// <remarks/>
        public string ProvidingOrganizationURL;
    }

    public class ProjectDetails_ForMetaData 
    {
    
        /// <remarks/>
        public string ProjectName;
    
        /// <remarks/>
        public string ProjectOrganizationName;
    
        /// <remarks/>
        public System.Decimal ProjectAreaBoundaryCoordinatesMaximumLatitude;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ProjectAreaBoundaryCoordinatesMaximumLatitudeSpecified;
    
        /// <remarks/>
        public System.Decimal ProjectAreaBoundaryCoordinatesMaximumLongitude;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ProjectAreaBoundaryCoordinatesMaximumLongitudeSpecified;
    
        /// <remarks/>
        public System.Decimal ProjectAreaBoundaryCoordinatesMinimumLatitude;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ProjectAreaBoundaryCoordinatesMinimumLatitudeSpecified;
    
        /// <remarks/>
        public System.Decimal ProjectAreaBoundaryCoordinatesMinimumLongitude;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ProjectAreaBoundaryCoordinatesMinimumLongitudeSpecified;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime ProjectStartDate;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime ProjectEndDate;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ProjectEndDateSpecified;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger")]
        public string NumberofStations;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger")]
        public string NumberofResults;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitoredMedia")]
        public string[] MonitoredMedia;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitoredAnalyte")]
        public AnalyteType[] MonitoredAnalyte;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MonitoredStationType")]
        public string[] MonitoredStationType;
    
        /// <remarks/>
        public string AvailabilityDescription;
    }

    public class AnalyteType 
    {
    
        /// <remarks/>
        public string AnalyteIdentifier;
    
        /// <remarks/>
        public string AnalyteName;
    
        /// <remarks/>
        public string AnalyteContextName;
    }

    public class ProvidingOrganizationDetailsType_ForMetaData 
    {
    
        /// <remarks/>
        public string ProvidingOrganizationIdentifier;
    
        /// <remarks/>
        public string ProvidingOrganizationName;
    
        /// <remarks/>
        public string ProvidingOrganizationContactName;
    
        /// <remarks/>
        public PhoneEmailType ProvidingOrganizationPhoneEmail;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime RefreshDate;
    
        /// <remarks/>
        public string DataSourceAccessMethod;
    
        /// <remarks/>
        public string DataSourceLocation;
    }

    public class PhoneEmailType 
    {
    
        /// <remarks/>
        public string TelephoneNumber;
    
        /// <remarks/>
        public string ElectronicMailAddressText;
    }

    public class PNWWQXMetadataRegistryList 
    {
    
        /// <remarks/>
        public ProvidingOrganizationDetailsType_ForMetaData ProvidingOrganization;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Project")]
        public ProjectDetails_ForMetaData[] Project;
    }

    public class DetectionQuantitationLevelType 
    {
    
        /// <remarks/>
        public System.Decimal DetectionQuantitationLevelMeasure;
    
        /// <remarks/>
        public string DetectionQuantitationLevelTypeText;
    
        /// <remarks/>
        public string DetectionQuantitationLevelUnitMeasureName;
    }

    public class ResultDetailsType 
    {
    
        /// <remarks/>
        public string ResultValueMeasure;
    
        /// <remarks/>
        public int ResultValueSignificantDigitsNumber;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ResultValueSignificantDigitsNumberSpecified;
    
        /// <remarks/>
        public string ResultUnitMeasureName;
    
        /// <remarks/>
        public string ResultQualifier;
    
        /// <remarks/>
        public AnalyteType ResultAnalyte;
    
        /// <remarks/>
        public TaxonType ResultTaxon;
    
        /// <remarks/>
        public string ResultQualityAssessment;
    
        /// <remarks/>
        public string ResultStatus;
    
        /// <remarks/>
        public string ResultAvailabilityDescription;
    
        /// <remarks/>
        public MethodType ResultAnalyticalMethod;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ResultDetectionLevels")]
        public DetectionQuantitationLevelType[] ResultDetectionLevels;
    
        /// <remarks/>
        public bool QAQCExceptionIndicator;
    
        /// <remarks/>
        public string QAQCExceptionCommentText;
    }

    public class TaxonType 
    {
        /// <remarks/>
        public string BiologicalSystematicName;
    
        /// <remarks/>
        public string BiologicalSystematicContextName;

		/// <remarks/>
		public string BiologicalSystematicIdentifier;
    }

    public class MethodType 
    {
    
        /// <remarks/>
        public string MethodCode;
    
        /// <remarks/>
        public string MethodContext;
    
        /// <remarks/>
        public string MethodDescription;
    }

    public class ResultDetails 
    {
    
        /// <remarks/>
        public ResultDetailsType ResultDetailsType;
    
        /// <remarks/>
        public string ResultContactIdentifier;
    }

    public class FieldEventDetailsType 
    {
    
        /// <remarks/>
        public System.DateTime FieldEventStartDate;
    
        /// <remarks/>
        public string FieldEventStartTimeZone;
    
        /// <remarks/>
        public System.DateTime FieldEventEndDate;
    
        /// <remarks/>
        public string FieldEventEndTimeZone;
    
        /// <remarks/>
        public string FieldEventTypeText;
    
        /// <remarks/>
        public string SampleIdentificationText;
    
        /// <remarks/>
        public string MediaText;
    
        /// <remarks/>
        public TaxonType Taxon;
    
        /// <remarks/>
        public System.Decimal FieldEventUpperDepthMeasure;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FieldEventUpperDepthMeasureSpecified;
    
        /// <remarks/>
        public System.Decimal FieldEventLowerDepthMeasure;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FieldEventLowerDepthMeasureSpecified;
    
        /// <remarks/>
        public string FieldEventDepthUnitMeasureName;
    
        /// <remarks/>
        public string FieldEventDepthComment;
    
        /// <remarks/>
        public string FieldEventNotes;
    
        /// <remarks/>
        public MethodType SampleCollectionMethod;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SamplePreparationMethod")]
        public MethodType[] SamplePreparationMethod;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SamplePreservationMethod")]
        public MethodType[] SamplePreservationMethod;
    }


    public class FieldEventDetails 
    {
    
        /// <remarks/>
        public FieldEventDetailsType FieldEventDetailsType;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FieldEventLargeObject")]
        public BinaryLargeObject[] FieldEventLargeObject;
    
        /// <remarks/>
        public string FieldEventProjectIdentifier;
    
        /// <remarks/>
        public string FieldEventStationIdentifier;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FieldEventContactIdentifier")]
        public string[] FieldEventContactIdentifier;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ResultDetails")]
        public ResultDetails[] ResultDetails;
    }

    public class BinaryLargeObject 
    {
    
        /// <remarks/>
        public NodeDocument BinaryObject;
    
        /// <remarks/>
        public string BinaryObjectURL;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger")]
        public string BinaryObjectSize;
    
        /// <remarks/>
        public string BinaryObjectTitleText;
    
        /// <remarks/>
        public string BinaryObjectCreator;
    
        /// <remarks/>
        public string BinaryObjectSubject;
    
        /// <remarks/>
        public string BinaryObjectDescription;
    
        /// <remarks/>
        public string BinaryObjectPublisher;
    
        /// <remarks/>
        public string BinaryObjectContributor;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime BinaryObjectDate;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BinaryObjectDateSpecified;
    
        /// <remarks/>
        public string BinaryObjectType;
    
        /// <remarks/>
        public string BinaryObjectContentTypeText;
    
        /// <remarks/>
        public string BinaryObjectIdentifierText;
    
        /// <remarks/>
        public string BinaryObjectSource;
    
        /// <remarks/>
        public string BinaryObjectLanguage;
    
        /// <remarks/>
        public string BinaryObjectRelation;
    
        /// <remarks/>
        public string BinaryObjectCoverage;
    
        /// <remarks/>
        public string BinaryObjectRights;
    }

    public class NodeDocument 
    {
    
        /// <remarks/>
        public string name;
    
        /// <remarks/>
        public string type;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public System.Byte[] content;
    }

    public class StationDetails_ForMeasurements 
    {
    
        /// <remarks/>
        public StationDetailsType StationDetailsType;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StationBinaryLargeObject")]
        public BinaryLargeObject[] StationBinaryLargeObject;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StationContactIdentifier")]
        public string[] StationContactIdentifier;
    }

    public class StationDetailsType 
    {
    
        /// <remarks/>
        public string StationIdentifier;
    
        /// <remarks/>
        public string StationName;
    
        /// <remarks/>
        public string StationLocationDescription;
    
        /// <remarks/>
        public string StationType;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LocationDescriptor")]
        public LocationDescriptor[] LocationDescriptor;
    
        /// <remarks/>
        public System.Decimal LatitudeMeasure;
    
        /// <remarks/>
        public System.Decimal LongitudeMeasure;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger")]
        public string HorizontalAccuracyMeasure;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger")]
        public string SourceMapScaleNumber;
    
        /// <remarks/>
        public string CoordinateDataSourceName;
    
        /// <remarks/>
        public string HorizontalCollectionMethodText;
    
        /// <remarks/>
        public string HorizontalReferenceDatumName;
    
        /// <remarks/>
        public string ReferencePointText;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReferencePointTextSpecified;
    
        /// <remarks/>
        public string VerticalMeasure;
    
        /// <remarks/>
        public string VerticalMeasureUnitofMeasure;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger")]
        public string VerticalAccuracyMeasure;
    
        /// <remarks/>
        public string VerticalCollectionMethodText;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VerticalCollectionMethodTextSpecified;
    
        /// <remarks/>
        public string VerticalReferenceDatumName;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VerticalReferenceDatumNameSpecified;
    
        /// <remarks/>
        public string VerticalReferencePointContextText;
    
        /// <remarks/>
        public WellDetailType WellDetail;
    }

    public class LocationDescriptor 
    {
    
        /// <remarks/>
        public string LocationDescriptorName;
    
        /// <remarks/>
        public string LocationDescriptorContext;
    }


    public class WellDetailType 
    {
    
        /// <remarks/>
        public string WellIdentifier;
    
        /// <remarks/>
        public string WellIdentifierContext;
    
        /// <remarks/>
        public System.Decimal WellDepthCompletionMeasure;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WellDepthCompletionMeasureSpecified;
    
        /// <remarks/>
        public string WellOpenIntervalType;
    
        /// <remarks/>
        public System.Decimal WellDepthTopOpenIntervalMeasure;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WellDepthTopOpenIntervalMeasureSpecified;
    
        /// <remarks/>
        public System.Decimal WellDepthBottomOpenIntervalMeasure;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WellDepthBottomOpenIntervalMeasureSpecified;
    
        /// <remarks/>
        public string WellDepthUnitMeasureName;
    
        /// <remarks/>
        public System.Decimal WellDiameterMeasure;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WellDiameterMeasureSpecified;
    
        /// <remarks/>
        public string WellDiameterUnitMeasureName;
    
        /// <remarks/>
        public string WellStatus;
    
        /// <remarks/>
        public string WellUse;
    }


    public class ProjectDetails_ForMeasurements 
    {
    
        /// <remarks/>
        public ProjectDetailsType ProjectDetailsType;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectBinaryLargeObject")]
        public BinaryLargeObject[] ProjectBinaryLargeObject;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectContact")]
        public ProjectContactType[] ProjectContact;
    }

    public class ProjectDetailsType 
    {
    
        /// <remarks/>
        public string ProjectIdentifier;
    
        /// <remarks/>
        public string ProjectName;
    
        /// <remarks/>
        public string ProjectDescription;
    
        /// <remarks/>
        public bool ProjectQAPPIndicator;
    
        /// <remarks/>
        public string ProjectQAPPDescription;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime ProjectStartDate;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime ProjectEndDate;
    
        /// <remarks/>
        public string ProjectAreaDescription;
    }

    public class ProjectContactType 
    {
    
        /// <remarks/>
        public string ProjectContactIdentifier;
    
        /// <remarks/>
        public bool PrimaryDataSourceIndicator;
    }

    public class PNWWQXMeasurementsList 
    {
    
        /// <remarks/>
        public ProvidingOrganizationDetailsType ProvidingOrganizationDetails;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectDetails")]
        public ProjectDetails_ForMeasurements[] ProjectDetails;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StationDetails")]
        public StationDetails_ForMeasurements[] StationDetails;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FieldEventDetails")]
        public FieldEventDetails[] FieldEventDetails;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ContactEntityDetails")]
        public ContactEntityDetails[] ContactEntityDetails;
    }

    public class ContactEntityDetails 
    {
    
        /// <remarks/>
        public string ContactEntityIdentifier;
    
        /// <remarks/>
        public string ContactOrganizationName;
    
        /// <remarks/>
        public string ContactEntityType;
    
        /// <remarks/>
        public string ContactIndividualName;
    
        /// <remarks/>
        public MailingAddressType ContactMailingAddress;
    
        /// <remarks/>
        public PhoneEmailType ContactPhoneEmail;
    }

    public class MailingAddressType 
    {
    
        /// <remarks/>
        public string MailingAddress;
    
        /// <remarks/>
        public string MailingAddressCityName;
    
        /// <remarks/>
        public string MailingAddressStateName;
    
        /// <remarks/>
        public string MailingAddressZIPCode;
    }

    public class ProjectDetails_ForStations 
    {
    
        /// <remarks/>
        public ProjectDetailsType ProjectDetailsType;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectContact")]
        public ProjectContactType[] ProjectContact;
    }

    public class StationDetails_ForStations 
    {
    
        /// <remarks/>
        public StationDetailsType StationDetailsType;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StationBinaryLargeObject")]
        public BinaryLargeObject[] StationBinaryLargeObject;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StationProjectIdentifier")]
        public string[] StationProjectIdentifier;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StationContactIdentifier")]
        public string[] StationContactIdentifier;
    }

    public class PNWWQXStationsList 
    {
    
        /// <remarks/>
        public ProvidingOrganizationDetailsType ProvidingOrganizationDetails;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StationDetails")]
        public StationDetails_ForStations[] StationDetails;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectDetails")]
        public ProjectDetails_ForStations[] ProjectDetails;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ContactEntityDetails")]
        public ContactEntityDetails[] ContactEntityDetails;
    }

    public class ProjectDetails_ForDocumentation 
    {
    
        /// <remarks/>
        public ProjectDetailsType ProjectDetailsType;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectBinaryLargeObject")]
        public BinaryLargeObject[] ProjectBinaryLargeObject;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectContact")]
        public ProjectContactType[] ProjectContact;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Analyte")]
        public AnalyteType[] Analyte;
    }

    public class PNWWQXProjectDocumentationList 
    {
    
        /// <remarks/>
        public ProvidingOrganizationDetailsType ProvidingOrganizationDetails;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectDetails")]
        public ProjectDetails_ForDocumentation[] ProjectDetails;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ContactEntityDetails")]
        public ContactEntityDetails[] ContactEntityDetails;
    }

    public class ProjectDetails_ForProjects 
    {
    
        /// <remarks/>
        public ProjectDetailsType ProjectDetailsType;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ProjectBinaryLargeObject")]
		public BinaryLargeObject[] ProjectBinaryLargeObject;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProjectContact")]
        public ProjectContactType[] ProjectContact;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Analyte")]
		public AnalyteType[] Analyte;
    }



}
