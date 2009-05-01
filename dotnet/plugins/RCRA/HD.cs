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

using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOSPlugin.RCRA
{
	/// <remarks/>
	[Serializable]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0")]
	[System.Xml.Serialization.XmlRootAttribute("HazardousWasteHandlerSubmission", Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=false)]
	public class HazardousWasteHandlerSubmission 
	{
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("FacilitySubmission")]
		public FacilitySubmission[] FacilitySubmission;

		//default schema location
		//private string mSchemaLocation = "urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0 http://www.windsorsolutions.biz/xsd/RCRA_v1.0/EN_RCRA_HazardousWasteHandlerSubmission_v1.0.xsd";
		//private string mSchemaLocation = "urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0 https://test-fortress.wa.gov/ecy/node/registry/rcra_registry/EN_RCRA_HazardousWasteHandlerSubmission_v1.0.xsd";
		
		private string mSchemaLocation = "urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0 https://fortress.wa.gov/ecy/node/registry/rcra_registry/EN_RCRA_HazardousWasteHandlerSubmission_v1.0.xsd";

		//default schema location
		// private string mSchemaLocation = "urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0 http://www.windsorsolutions.biz/xsd/RCRA_v1.0/EN_RCRA_HazardousWasteHandlerSubmission_v1.0.xsd";

		[XmlAnyAttribute]
		public XmlAttribute[] XAttributes;

		//constructor
		public HazardousWasteHandlerSubmission()
		{
			XmlDocument d = new XmlDocument();

			this.XAttributes = new XmlAttribute[1];

			XmlAttribute xsi = d.CreateAttribute("xsi", "schemaLocation", XmlSchema.InstanceNamespace); 
			xsi.Value = mSchemaLocation;
			this.XAttributes[0] = xsi;
		}

		
		/// <summary>
		/// SerializeToStream
		/// </summary>
		/// <returns></returns>
		public MemoryStream SerializeToStream(){
			MemoryStream ms = null;
			XmlTextWriter tw = null;

			try {

				ms = new MemoryStream();
                tw = new XmlTextWriter(ms, StringUtils.UTF8);
				
				
				tw.Formatting = Formatting.None;
				
				
				XmlSerializer saveXML = new XmlSerializer(this.GetType());
				
				saveXML.Serialize(tw,this);
               
				ms.Seek(0,System.IO.SeekOrigin.Begin);

				//Return the MemoryStream
				return ms;

			}
			catch (Exception ex){

				//If there is an exception cleanup so that next call may have a chance to work 

				if (tw != null) {
					tw.Close();
				}
				if (ms != null) {
					ms.Close(); 
				}

				//Must rethrow the original exception
				throw ex;
            
			}
		
		}
		
		
		public void SerializeToFile(string path) {

			TextWriter tw = null;
			try {
				XmlSerializer saveXML = new XmlSerializer(this.GetType());
				tw = new StreamWriter(path);
				saveXML.Serialize(tw, this);
			}
			catch (Exception ex){
				throw ex;
			}
			finally {
				if (tw != null) {
					tw.Close();
				}
			}
		}


		
	}	//~ class


 //*******************************************************************************************************************************
 //*******************************************************************************************************************************
	/// <remarks/>
	[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=true)]
	public class AddressContact 
	{
    
		/// <remarks/>
		public Contact Contact;
    
		/// <remarks/>
		public MailingAddress MailingAddress;
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=true)]
	public class Contact 
	{
		/// <remarks/>
		public string FirstName;
    
		/// <remarks/>
		public string MiddleInitial;
    
		/// <remarks/>
		public string LastName;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElement(Namespace="http://www.epa.gov/xml")]
		public string OrganizationFormalName;

		/// <remarks/>
		public RCRAPhoneEmail RCRAPhoneEmail;
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.epa.gov/xml", IsNullable=true)]
	public class RCRAPhoneEmail 
	{

		[System.Xml.Serialization.XmlElement(Namespace="http://www.epa.gov/xml")]
		public string EmailAddressText;
    
		[System.Xml.Serialization.XmlElement(Namespace="http://www.epa.gov/xml")]
		public string TelephoneNumber;
    
		[System.Xml.Serialization.XmlElement(Namespace="http://www.epa.gov/xml")]
		public string PhoneExtension;
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.epa.gov/xml", IsNullable=true)]
	public class MailingAddress 
	{
    
		/// <remarks/>
		public string MailingAddressText;
    
		/// <remarks/>
		public string SupplementalAddressText;
    
		/// <remarks/>
		public string MailingAddressCityName;
    
		/// <remarks/>
		public string MailingAddressStateUSPSCode;
    
		/// <remarks/>
		public string MailingAddressStateName;
    
		/// <remarks/>
		public string MailingAddressCountryName;
    
		/// <remarks/>
		public string MailingAddressZIPCode;
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=true)]
	public class Certification 
	{
    
		/// <remarks/>
		public string TransactionCode;
    
		/// <remarks/>
		public Int32 CertificationSequenceNumber;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnore()]
		public bool CertificationSequenceNumberSpecified;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
		public System.DateTime SignedDate;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnore()]
		public bool SignedDateSpecified;

		/// <remarks/>
		public string Title;
    
		/// <remarks/>
		public string FirstName;
    
		/// <remarks/>
		public string MiddleInitial;
    
		/// <remarks/>
		public string LastName;
    
		/// <remarks/>
		public string SupplementalInformation;
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=true)]
	public class ContactAddress 
	{
    
		/// <remarks/>
		public Contact Contact;
    
		/// <remarks/>
		public MailingAddress MailingAddress;
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=false)]
	public class FacilitySubmission 
	{
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("TransactionCode")]
		public string TransactionCode;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("HandlerID")]
		public string HandlerID;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("PublicUseExtractIndicator")]
		public bool PublicUseExtractIndicator;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("FacilityRegistryID")]
		public string FacilityRegistryID;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("SupplementalInformation")]
		public string SupplementalInformation;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("PreviousHandler")]
		public PreviousHandler[] PreviousHandler;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Handler")]
		public HandlerDataType[] Handler;


	}

		/// <remarks/>
		[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=true)]
		public class PreviousHandler 
		{
    
			/// <remarks/>
			public string TransactionCode;
    
			/// <remarks/>
			public string PreviousHandlerID;
    
			/// <remarks/>
			public string SupplementalInformation;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=false)]
		public class HandlerDataType
		{
    
			/// <remarks/>
			public string TransactionCode;
    
			/// <remarks/>
			public string ActivityLocationCode;
    
			/// <remarks/>
			public string SourceTypeCode;
    
			/// <remarks/>
			public Int32 SourceRecordSequenceNumber;
	
			/// <remarks/>
			[System.Xml.Serialization.XmlIgnore()]
			public bool SourceRecordSequenceNumberSpecified;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
			public System.DateTime ReceiveDate;

			[System.Xml.Serialization.XmlIgnore()]
			public bool ReceiveDateSpecified;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
			public System.DateTime AcknowledgeReceiptDate;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlIgnore()]
			public bool AcknowledgeReceiptDateSpecified;

			/// <remarks/>
			public bool NonNotifierIndicator;
    
			/// <remarks/>
			public Int32 OnsiteEmployeeQuantity;
	
			/// <remarks/>
			[System.Xml.Serialization.XmlIgnore]
			public bool OnsiteEmployeeQuantitySpecified;
    
			/// <remarks/>
			public string TransferFacilityCode;
    
			/// <remarks/>
			public string SecondaryID;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
			public System.DateTime TreatmentStorageDisposalDate;
   
			/// <remarks/>
			[System.Xml.Serialization.XmlIgnore()]
			public bool TreatmentStorageDisposalDateSpecified;

			/// <remarks/>
			public string OffsiteWasteReceiptCode;
    
			/// <remarks/>
			public string AccessibilityCode;
    
			/// <remarks/>
			public string CountyCodeOwner;
    
			/// <remarks/>
			public string CountyCode;
    
			/// <remarks/>
			public string SupplementalInformation;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute("LocationAddress")]
			public RCRALocationAddress[] RCRALocationAddress;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute("MailingAddress")]
			public MailingAddress[] MailingAddress;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute("ContactAddress")]
			public ContactAddress[] ContactAddress;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute("PermitContactAddress")]
			public PermitContactAddress[] PermitContactAddress;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute("RCRAGeographicCoordinate")]
			public RCRAGeographicCoordinate[] RCRAGeographicCoordinate;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute("UsedOil")]
			public UsedOil[] UsedOil;
    
			/// <remarks/>
			public WasteActivitySite WasteActivitySite;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute("StateWasteGenerator")]
			public StateWasteGenerator[] StateWasteGenerator;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute("FederalWasteGenerator")]
			public FederalWasteGenerator[] FederalWasteGenerator;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute("Certification")]
			public Certification[] Certification;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute("NAICS")]
			public NAICS[] NAICS;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute("OwnerOperatorFacility")]
			public OwnerOperatorFacility[] OwnerOperatorFacility;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute("PermitEnvironmental")]
			public PermitEnvironmental[] PermitEnvironmental;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute("StateActivity")]
			public StateActivity[] StateActivity;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute("HandlerUniversalWaste")]
			public HandlerUniversalWaste[] HandlerUniversalWaste;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute("HandlerWasteCodeDetails")]
			public HandlerWasteCodeDetails[] HandlerWasteCodeDetails;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.epa.gov/xml", IsNullable=true)]
		public class RCRALocationAddress 
		{
    
			/// <remarks/>
			public string LocationAddressText;
    
			/// <remarks/>
			public string SupplementalLocationText;
    
			/// <remarks/>
			public string LocalityName;
    
			/// <remarks/>
			public string CountyStateFIPSCode;
    
			/// <remarks/>
			public string CountyName;
    
			/// <remarks/>
			public string StateUSPSCode;
    
			/// <remarks/>
			public string StateName;
    
			/// <remarks/>
			public string CountryName;
    
			/// <remarks/>
			public string LocationZIPCode;
    
			/// <remarks/>
			public string LocationDescriptionText;
    
			/// <remarks/>
			public string TransactionCode;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=true)]
		public class PermitContactAddress 
		{
    
			/// <remarks/>
			public Contact Contact;
    
			/// <remarks/>
			public MailingAddress MailingAddress;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.epa.gov/xml", IsNullable=true)]
		public class RCRAGeographicCoordinate 
		{
    
			/// <remarks/>
			public string TransactionCode;
    
			/// <remarks/>
			public System.Decimal LatitudeMeasure;
    
			[System.Xml.Serialization.XmlIgnore()]
			public bool LatitudeMeasureSpecified;

			/// <remarks/>
			public System.Decimal LongitudeMeasure;
    
			[System.Xml.Serialization.XmlIgnore()]
			public bool LongitudeMeasureSpecified;

			/// <remarks/>
			public Int32 HorizontalAccuracyMeasure;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlIgnore()]
			public bool HorizontalAccuracyMeasureSpecified;

			/// <remarks/>
			public string HorizontalCollectionMethod;
    
			/// <remarks/>
			public string HorizontalReferenceDatumName;
    
			/// <remarks/>
			public Int32 SourceMapScaleNumber;
		
			/// <remarks/>
			[System.Xml.Serialization.XmlIgnore()]
			public bool SourceMapScaleNumberSpecificed;
    
			/// <remarks/>
			public string ReferencePoint;
    
			/// <remarks/>
			public string GeometricTypeName;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=true)]
		public class UsedOil 
		{
    
			/// <remarks/>
			public string TransactionCode;
    
			/// <remarks/>
			public string FuelBurnerCode;
    
			/// <remarks/>
			public string ProcessorCode;
    
			/// <remarks/>
			public string RefinerCode;
    
			/// <remarks/>
			public string MarketBurnerCode;
    
			/// <remarks/>
			public string SpecificationMarketerCode;
    
			/// <remarks/>
			public string TransferFacilityCode;
    
			/// <remarks/>
			public string TransporterCode;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=true)]
		public class WasteActivitySite 
		{
    
			/// <remarks/>
			public string TransactionCode;
    
			/// <remarks/>
			public string FacilitySiteName;
    
			/// <remarks/>
			public string LandTypeCode;
    
			/// <remarks/>
			public string StateDistrictCode;
    
			/// <remarks/>
			public string ImporterActivityCode;
    
			/// <remarks/>
			public string MixedWasteGeneratorCode;
    
			/// <remarks/>
			public string RecyclerActivityCode;
    
			/// <remarks/>
			public string TransporterActivityCode;
    
			/// <remarks/>
			public string TreatmentStorageDisposalActivityCode;
    
			/// <remarks/>
			public string UndergroundInjectionActivityCode;
    
			/// <remarks/>
			public bool UniversalWasteDestinationFacilityIndicator;
    
			/// <remarks/>
			public bool TransferFacilityIndicator;
    
			/// <remarks/>
			public string OnsiteBurnerExemptionCode;
    
			/// <remarks/>
			public string FurnaceExemptionCode;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=true)]
		public class StateWasteGenerator 
		{
    
			/// <remarks/>
			public string TransactionCode;
    
			/// <remarks/>
			public string WasteGeneratorOwnerName;
    
			/// <remarks/>
			public string WasteGeneratorStatusCode;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=true)]
		public class FederalWasteGenerator 
		{
    
			/// <remarks/>
			public string TransactionCode;
    
			/// <remarks/>
			public string WasteGeneratorOwnerName;
    
			/// <remarks/>
			public string WasteGeneratorStatusCode;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=true)]
		public class NAICS 
		{
    
			/// <remarks/>
			public string TransactionCode;
    
			/// <remarks/>
			public string NAICSSequenceNumber;
    
			/// <remarks/>
			public string NAICSOwnerCode;
    
			/// <remarks/>
			public string NAICSCode;
    
			/// <remarks/>
			public string SupplementalInformation;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=true)]
		public class OwnerOperatorFacility 
		{
    
			/// <remarks/>
			public string TransactionCode;
    
			/// <remarks/>
			public Int32 OwnerOperatorSequenceNumber;
	
			/// <remarks/>
			[System.Xml.Serialization.XmlIgnore()]
			public bool OwnerOperatorSequenceNumberSpecified;
    
			/// <remarks/>
			public string OwnerOperatorIndicator;
    
			/// <remarks/>
			public string OwnerOperatorTypeCode;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
			public System.DateTime CurrentStartDate;

			[System.Xml.Serialization.XmlIgnore()]
			public bool CurrentStartDateSpecified;
    
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
			public System.DateTime CurrentEndDate;
    
			[System.Xml.Serialization.XmlIgnore()]
			public bool CurrentEndDateSpecified;

			/// <remarks/>
			public string DUNSID;
    
			/// <remarks/>
			public string SupplementalInformation;
    
			/// <remarks/>
			public AddressContact AddressContact;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=true)]
		public class PermitEnvironmental 
		{
    
			/// <remarks/>
			public string TransactionCode;
    
			/// <remarks/>
			public string EnvironmentalPermitID;
    
			/// <remarks/>
			public string EnvironmentalPermitOwnerName;
    
			/// <remarks/>
			public string EnvironmentalPermitTypeCode;
    
			/// <remarks/>
			public string EnvironmentalPermitDescription;
    
			/// <remarks/>
			public string SupplementalInformation;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=true)]
		public class StateActivity 
		{
    
			/// <remarks/>
			public string TransactionCode;
    
			/// <remarks/>
			public string StateActivityOwnerName;
    
			/// <remarks/>
			public string StateActivityTypeCode;
    
			/// <remarks/>
			public string SupplementalInformation;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=true)]
		public class HandlerUniversalWaste 
		{
    
			/// <remarks/>
			public string TransactionCode;
    
			/// <remarks/>
			public string UniversalWasteOwnerName;
    
			/// <remarks/>
			public string UniversalWasteTypeCode;
    
			/// <remarks/>
			public string AccumulatedWasteCode;
    
			/// <remarks/>
			public string GeneratedHandlerCode;
    
			/// <remarks/>
			public string SupplementalInformation;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork:RCRA:RCRA_C:1:0", IsNullable=true)]
		public class HandlerWasteCodeDetails 
		{
    
			/// <remarks/>
			public string TransactionCode;
    
			/// <remarks/>
			public string WasteCodeOwnerName;
    
			/// <remarks/>
			public string WasteCode;
		}

}