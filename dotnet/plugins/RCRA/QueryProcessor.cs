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
using System.Data;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Soap;
using Windsor.Node.Plugin.Interface30;

namespace Windsor.Node.Flow.RCRA.CS 
{

	public class QueryProcessor : INodeExecutable 
	{
       
		private ArrayList m_SupportedServices = new ArrayList();
		private const int VERSION_NUMBER  = 3;
		private const string FLOW_NAME  = "RCRA";
		private const bool SUPPORTS_INBOUND_SUBMIT = false;
		private DateTime MIN_DATE = DateTime.Parse("1/1/1900");


		public QueryProcessor() 
		{
        
			#region GetRCRAData
            
			NodeService srvGetRCRAData = new NodeService(
				"GetRcraData", 
				"http://www.exchangenetwork.net/schema/v1.0/ExchangeNetworkDocument.xsd", 
				false, 
				true);
			 
			m_SupportedServices.Add(srvGetRCRAData);
			

			#endregion

		}


		#region Private methods

		private NodeService GetRequestedService(string serviceName)
		{
		
			NodeService returnService = null;
			
			NodeService[] nodeServices= (NodeService[])m_SupportedServices.ToArray(typeof(NodeService));
		  
			serviceName = serviceName.ToLower();
		  
			foreach(NodeService thisNodeService in  nodeServices)
			{
		  
				if(thisNodeService.DataServiceName.ToLower().Equals(serviceName.ToLower()))
				{
					returnService = thisNodeService;
				}
			
			}//~foreach
		
			return returnService;
		
		}//~method

		#endregion
		private HazardousWasteHandlerSubmission GetHazardousWasteHandlerSubmission(
			string connectionString,
			string serviceName,
			int rowId,
			int maxRows,
			string[] parameters)
		{
			
			#region Requested Service/Parameter Validation block	
																																						
			// Validate Method name
			if (serviceName == null) 
			{
				throw new ApplicationException("Service name is required.");
			}


			//Check the supported services for a name match
			NodeService requestedService  = this.GetRequestedService(serviceName);

			// Validate Method name
			if (requestedService == null) 
			{
				throw new ApplicationException(string.Format("Service not supported {0}.", serviceName));
			}

			//Validate parameters
			if ((requestedService.ServiceParameters != null) && (requestedService.ServiceParameters.Length != 0))
			{
				if (parameters == null) 
				{
					throw new ApplicationException(string.Format(
						"Incorrect number of parameters. Expected: {0} Provided: NULL",
						requestedService.ServiceParameters.Length));
				}
				else 
				{
					if (parameters.Length != requestedService.ServiceParameters.Length) 
					{
						throw new ApplicationException(string.Format(
							"Incorrect number of parameters. Expected: {0} Provided: {1}",
							requestedService.ServiceParameters.Length, parameters.Length));
					}
				}
			}
			
			#endregion
			
			//Get Dataset
			DataSet ds = Data.GetData(connectionString);
					
			//Pass DS to populate the object array
			return PopulateHazardousWasteHandlerSubmission(ref ds, rowId, maxRows);
		
		}   //~method
		
		




		private HazardousWasteHandlerSubmission PopulateHazardousWasteHandlerSubmission(ref DataSet ds, int rowID, int maxRows)
		{
		
			if (ds == null) 
			{
				return null;
			}
	

			HazardousWasteHandlerSubmission hdRoot = new HazardousWasteHandlerSubmission();

			//Create an array to hold the individual hd lists in collection
			ArrayList detailArray = new ArrayList();

			//for each data row in the parent table (PK)
			int rowCount = 0;
			foreach (DataRow dr in ds.Tables[0].Rows) 
			{
				//Create a new instance of the FacilitySubmissionType
				FacilitySubmission facType = new FacilitySubmission();

				facType.TransactionCode = Util.ToString(dr["TransactionCode"]);
				facType.HandlerID = Util.ToString(dr["EPAHandlerID"]);

				if (Util.IsValidBool(dr["PublicUseExtractIndicator"]))
				{
					facType.PublicUseExtractIndicator = Util.ToBool(dr["PublicUseExtractIndicator"]);
				}

				facType.FacilityRegistryID = Util.ToString(dr["FacilityRegistryID"]);
				facType.SupplementalInformation = Util.ToString(dr["SupplementalInformation"]);


				#region Previous Handlers

				//Get Previous Handlers
				ArrayList prevHandlers = new ArrayList();

				
				foreach(DataRow drChild in dr.GetChildRows(
					Data.Relationships.FacilitySubmission_PreviousHandler.ToString()))
				{
					PreviousHandler prevHand = new PreviousHandler();

					prevHand.TransactionCode = Util.ToString(drChild["TransactionCode"]);
					prevHand.PreviousHandlerID = Util.ToString(drChild["PreviousHandlerID"]);
					prevHand.SupplementalInformation = Util.ToString(drChild["SupplementalInformation"]);

					prevHandlers.Add(prevHand);
				}

				facType.PreviousHandler = (PreviousHandler[])prevHandlers.ToArray(typeof(PreviousHandler));

				#endregion
				
				#region Handlers

				//Get Handlers
				ArrayList handlers = new ArrayList();

				foreach(DataRow drChild in dr.GetChildRows(
					Data.Relationships.FacilitySubmission_Handler.ToString()))
				{
					HandlerDataType hand = new HandlerDataType();


					#region Handler Module
					//HD2
					hand.TransactionCode = Util.ToString(drChild["HTransactionCode"]);
					hand.ActivityLocationCode = Util.ToString(drChild["HActivityLocationCode"]);
					hand.SourceTypeCode = Util.ToString(drChild["HSourceTypeCode"]);

					hand.SourceRecordSequenceNumberSpecified = Util.IsValidInt(drChild["HSourceRecordSequenceNumber"], true);
					if(hand.SourceRecordSequenceNumberSpecified)
					{
						hand.SourceRecordSequenceNumber = Util.ToInt(drChild["HSourceRecordSequenceNumber"]);
					}


					hand.ReceiveDateSpecified = Util.IsValidDateTime(drChild["HReceiveDate"], MIN_DATE);
					if (hand.ReceiveDateSpecified)
					{
						hand.ReceiveDate = Util.ToDateTime(drChild["HReceiveDate"]);
					}

					hand.AcknowledgeReceiptDateSpecified = Util.IsValidDateTime(drChild["HAcknowledgeReceiptDate"], MIN_DATE);
					if(hand.AcknowledgeReceiptDateSpecified)
					{
						hand.AcknowledgeReceiptDate = Util.ToDateTime(drChild["HAcknowledgeReceiptDate"]);
					}

					if(Util.IsValidBool(drChild["HNonNotifierIndicator"]))
					{
						hand.NonNotifierIndicator = Util.ToBool(drChild["HNonNotifierIndicator"]);
					}

					hand.OnsiteEmployeeQuantitySpecified = Util.IsValidInt(drChild["HOnsiteEmployeeQuantity"], true);
					if (hand.OnsiteEmployeeQuantitySpecified)
					{
						hand.OnsiteEmployeeQuantity = Util.ToInt(drChild["HOnsiteEmployeeQuantity"]);
					}

					hand.TransferFacilityCode = Util.ToString(drChild["HTransferFacilityCode"]);
					hand.SecondaryID = Util.ToString(drChild["HSecondaryID"]);

					hand.TreatmentStorageDisposalDateSpecified = Util.IsValidDateTime(drChild["HTreatmentStorageDisposalDate"], MIN_DATE);
					if (hand.TreatmentStorageDisposalDateSpecified)
					{
						hand.TreatmentStorageDisposalDate = Util.ToDateTime(drChild["HTreatmentStorageDisposalDate"]);
					}

					hand.OffsiteWasteReceiptCode = Util.ToString(drChild["HOffsiteWasteReceiptCode"]);
					hand.AccessibilityCode = Util.ToString(drChild["HAccessibilityCode"]);
					hand.CountyCodeOwner = Util.ToString(drChild["HCountyCodeOwner"]);
					hand.CountyCode = Util.ToString(drChild["HCountyCode"]);
					hand.SupplementalInformation = Util.ToString(drChild["HSupplementalInformation"]);

					#endregion


					#region RCRALocationAddress

					hand.RCRALocationAddress = new RCRALocationAddress[1];
					hand.RCRALocationAddress[0] = new RCRALocationAddress();
					hand.RCRALocationAddress[0].LocationAddressText = Util.ToString(drChild["HLALocationAddressText"]); 
					hand.RCRALocationAddress[0].SupplementalLocationText = Util.ToString(drChild["HLASupplementalLocationText"]);
					hand.RCRALocationAddress[0].LocalityName = Util.ToString(drChild["HLALocalityName"]);
					hand.RCRALocationAddress[0].CountyStateFIPSCode = Util.ToString(drChild["HLACountyStateFIPSCode"]);
					hand.RCRALocationAddress[0].CountyName = Util.ToString(drChild["HLACountyName"]);
					hand.RCRALocationAddress[0].StateUSPSCode = Util.ToString(drChild["HLAStateUSPSCode"]);
					hand.RCRALocationAddress[0].StateName = Util.ToString(drChild["HLAStateName"]);
					hand.RCRALocationAddress[0].CountryName = Util.ToString(drChild["HLACountryName"]);
					hand.RCRALocationAddress[0].LocationZIPCode = Util.ToString(drChild["HLALocationZIPCode"]);
					hand.RCRALocationAddress[0].LocationDescriptionText = Util.ToString(drChild["HLALocationDescriptionText"]); 
						
					#endregion


					#region RCRAMailingAddress

					//"if" conditions added to eliminate empty xml tags when no data is present
					if(drChild["HMAMailingAddressText"] != DBNull.Value)
					{
						hand.MailingAddress = new MailingAddress[1];
						hand.MailingAddress[0] = new MailingAddress();
						hand.MailingAddress[0].MailingAddressText = Util.ToString(drChild["HMAMailingAddressText"]);
						//hand.MailingAddress[0].SupplementalAddressText = Util.ToString(drChild["HMASupplementalAddressText"]);
						if(drChild["HMASupplementalAddressText"] != DBNull.Value) hand.MailingAddress[0].SupplementalAddressText = Util.ToString(drChild["HMASupplementalAddressText"]);
						hand.MailingAddress[0].MailingAddressCityName = Util.ToString(drChild["HMAMailingAddressCityName"]);
						//hand.MailingAddress[0].MailingAddressStateUSPSCode = Util.ToString(drChild["HMAMailingAddressStateUSPSCode"]);
						if(drChild["HMAMailingAddressStateUSPSCode"] != DBNull.Value) hand.MailingAddress[0].MailingAddressStateUSPSCode = Util.ToString(drChild["HMAMailingAddressStateUSPSCode"]);
						//hand.MailingAddress[0].MailingAddressStateName = Util.ToString(drChild["HMAMailingAddressStateName"]);
						if(drChild["HMAMailingAddressStateName"] != DBNull.Value) hand.MailingAddress[0].MailingAddressStateName = Util.ToString(drChild["HMAMailingAddressStateName"]);
						//hand.MailingAddress[0].MailingAddressCountryName = Util.ToString(drChild["HMAMailingAddressCountryName"]);
						if(drChild["HMAMailingAddressCountryName"] != DBNull.Value) hand.MailingAddress[0].MailingAddressCountryName = Util.ToString(drChild["HMAMailingAddressCountryName"]);
						hand.MailingAddress[0].MailingAddressZIPCode = Util.ToString(drChild["HMAMailingAddressZIPCode"]);
					}
					
					#endregion


					#region ContactAddress

					//"if" conditions added to eliminate empty xml tags when no data is present
					if(drChild["CAFirstName"] != DBNull.Value || drChild["CAOrganizationFormalName"] != DBNull.Value)
					{
						hand.ContactAddress = new ContactAddress[1];
						hand.ContactAddress[0] = new ContactAddress();
						hand.ContactAddress[0].Contact = new Contact();

						if(drChild["CAFirstName"] != DBNull.Value)
						{
							hand.ContactAddress[0].Contact.FirstName = Util.ToString(drChild["CAFirstName"]);
							hand.ContactAddress[0].Contact.MiddleInitial = Util.ToString(drChild["CAMiddleInitial"]);
							if(drChild["CAMiddleInitial"] != DBNull.Value) hand.ContactAddress[0].Contact.MiddleInitial = Util.ToString(drChild["CAMiddleInitial"]);
							hand.ContactAddress[0].Contact.LastName = Util.ToString(drChild["CALastName"]);
						}
						else
						{
							hand.ContactAddress[0].Contact.OrganizationFormalName = Util.ToString(drChild["CAOrganizationFormalName"]);
						}
						hand.ContactAddress[0].Contact.RCRAPhoneEmail = new RCRAPhoneEmail();
						if(drChild["CAElectronicAddressText"] != DBNull.Value) hand.ContactAddress[0].Contact.RCRAPhoneEmail.EmailAddressText = Util.ToString(drChild["CAElectronicAddressText"]);
						hand.ContactAddress[0].Contact.RCRAPhoneEmail.TelephoneNumber = Util.ToString(drChild["CATelephoneNumber"]);
						if(drChild["CAPhoneExtension"] != DBNull.Value) hand.ContactAddress[0].Contact.RCRAPhoneEmail.PhoneExtension = Util.ToString(drChild["CAPhoneExtension"]);

						if(drChild["CMAMailingAddressText"] != DBNull.Value)
						{
							hand.ContactAddress[0].MailingAddress = new MailingAddress();
							hand.ContactAddress[0].MailingAddress.MailingAddressText = Util.ToString(drChild["CMAMailingAddressText"]);
							if(drChild["CMASupplementalAddressText"] != DBNull.Value) hand.ContactAddress[0].MailingAddress.SupplementalAddressText = Util.ToString(drChild["CMASupplementalAddressText"]);
							hand.ContactAddress[0].MailingAddress.MailingAddressCityName = Util.ToString(drChild["CMAMailingAddressCityName"]);
							if(drChild["CMAMailingAddressStateUSPSCode"] != DBNull.Value) hand.ContactAddress[0].MailingAddress.MailingAddressStateUSPSCode = Util.ToString(drChild["CMAMailingAddressStateUSPSCode"]);
							if(drChild["CMAMailingAddressStateName"] != DBNull.Value) hand.ContactAddress[0].MailingAddress.MailingAddressStateName = Util.ToString(drChild["CMAMailingAddressStateName"]);
							if(drChild["CMAMailingAddressCountryName"] != DBNull.Value) hand.ContactAddress[0].MailingAddress.MailingAddressCountryName = Util.ToString(drChild["CMAMailingAddressCountryName"]);
							hand.ContactAddress[0].MailingAddress.MailingAddressZIPCode = Util.ToString(drChild["CMAMailingAddressZIPCode"]);
						}
					}

					#endregion


					#region PermitContactAddress

					//"if" conditions added to eliminate empty xml tags when no data is present (all nulled out currentlty)
					if(drChild["PCAFirstName"] != DBNull.Value || drChild["PCAOrganizationFormalName"] != DBNull.Value)
					{
						hand.PermitContactAddress = new PermitContactAddress[1];
						hand.PermitContactAddress[0] = new PermitContactAddress();
						hand.PermitContactAddress[0].Contact = new Contact();

						if(drChild["PCAFirstName"] != DBNull.Value)
						{
							hand.PermitContactAddress[0].Contact.FirstName = Util.ToString(drChild["PCAFirstName"]);
							hand.PermitContactAddress[0].Contact.MiddleInitial = Util.ToString(drChild["PCAMiddleInitial"]);
							hand.PermitContactAddress[0].Contact.LastName = Util.ToString(drChild["PCALastName"]);
						}
						else
						{
							hand.PermitContactAddress[0].Contact.OrganizationFormalName = Util.ToString(drChild["PCAOrganizationFormalName"]);
						}
	
						hand.PermitContactAddress[0].Contact.RCRAPhoneEmail = new RCRAPhoneEmail();
						hand.PermitContactAddress[0].Contact.RCRAPhoneEmail.EmailAddressText = Util.ToString(drChild["PCAElectronicAddressText"]);
						hand.PermitContactAddress[0].Contact.RCRAPhoneEmail.TelephoneNumber = Util.ToString(drChild["PCATelephoneNumber"]);
						hand.PermitContactAddress[0].Contact.RCRAPhoneEmail.PhoneExtension = Util.ToString(drChild["PCAPhoneExtension"]);
	
						hand.PermitContactAddress[0].MailingAddress = new MailingAddress();
						hand.PermitContactAddress[0].MailingAddress.MailingAddressText = Util.ToString(drChild["PCAMailingAddressText"]);
						hand.PermitContactAddress[0].MailingAddress.SupplementalAddressText = Util.ToString(drChild["PCASupplementalAddressText"]);
						hand.PermitContactAddress[0].MailingAddress.MailingAddressCityName = Util.ToString(drChild["PCAMailingAddressCityName"]);
						hand.PermitContactAddress[0].MailingAddress.MailingAddressStateUSPSCode = Util.ToString(drChild["PCAMailingAddressStateUSPSCode"]);
						hand.PermitContactAddress[0].MailingAddress.MailingAddressStateName = Util.ToString(drChild["PCAMailingAddressStateName"]);
						hand.PermitContactAddress[0].MailingAddress.MailingAddressCountryName = Util.ToString(drChild["PCAMailingAddressCountryName"]);
						hand.PermitContactAddress[0].MailingAddress.MailingAddressZIPCode = Util.ToString(drChild["PCAMailingAddressZIPCode"]);
					}

					#endregion


					#region RCRAGeographicCoordinate

					ArrayList geocords = new ArrayList();

					foreach(DataRow drSubChild in drChild.GetChildRows(
						Data.Relationships.Handler_GeographicCoordinate.ToString()))
					{
						RCRAGeographicCoordinate rcraGeoCoord = new RCRAGeographicCoordinate();

						rcraGeoCoord.TransactionCode = Util.ToString(drSubChild["TransactionCode"]);
						rcraGeoCoord.LatitudeMeasure = Util.ToDecimal(drSubChild["LatitudeMeasure"]);
						rcraGeoCoord.LongitudeMeasure = Util.ToDecimal(drSubChild["LongitudeMeasure"]);
						rcraGeoCoord.HorizontalAccuracyMeasureSpecified = Util.IsValidInt(drSubChild["HorizontalAccuracyMeasure"], true);
						if (rcraGeoCoord.HorizontalAccuracyMeasureSpecified)
						{
							rcraGeoCoord.HorizontalAccuracyMeasure = Util.ToInt(drSubChild["HorizontalAccuracyMeasure"]);
						}
						rcraGeoCoord.HorizontalCollectionMethod = Util.ToString(drSubChild["HorizontalCollectionMethod"]);
						rcraGeoCoord.HorizontalReferenceDatumName = Util.ToString(drSubChild["HorizontalReferenceDatumName"]);
						rcraGeoCoord.SourceMapScaleNumberSpecificed = Util.IsValidInt(drSubChild["SourceMapScaleNumber"], true);
						if (rcraGeoCoord.SourceMapScaleNumberSpecificed)
						{
							rcraGeoCoord.SourceMapScaleNumber = Util.ToInt(drSubChild["SourceMapScaleNumber"]);
						}
						rcraGeoCoord.ReferencePoint = Util.ToString(drSubChild["ReferencePoint"]);
						rcraGeoCoord.GeometricTypeName = Util.ToString(drSubChild["GeometricTypeName"]);

						geocords.Add(rcraGeoCoord);

					}

					hand.RCRAGeographicCoordinate = (RCRAGeographicCoordinate[])geocords.ToArray(typeof(RCRAGeographicCoordinate));
					#endregion



					#region UsedOil
					
					ArrayList oils = new ArrayList();

					foreach(DataRow drSubChild in drChild.GetChildRows(
						Data.Relationships.Handler_UsedOil.ToString()))
					{
						UsedOil usedOil = new UsedOil();
						usedOil.TransactionCode = Util.ToString(drSubChild["TransactionCode"]);
						usedOil.FuelBurnerCode = Util.ToString(drSubChild["FuelBurnerCode"]);
						usedOil.ProcessorCode = Util.ToString(drSubChild["ProcessorCode"]);
						usedOil.RefinerCode = Util.ToString(drSubChild["RefinerCode"]);
						usedOil.MarketBurnerCode = Util.ToString(drSubChild["MarketBurnerCode"]);
						usedOil.SpecificationMarketerCode = Util.ToString(drSubChild["SpecificationMarketerCode"]);
						usedOil.TransferFacilityCode = Util.ToString(drSubChild["TransferFacilityCode"]);
						usedOil.TransporterCode = Util.ToString(drSubChild["TransporterCode"]);

						oils.Add(usedOil);
						
						
					}

					hand.UsedOil = (UsedOil[])oils.ToArray(typeof(UsedOil));
					#endregion


					#region WasteActivitySite

					DataRow[] drWA = drChild.GetChildRows(Data.Relationships.Handler_WasteActivitySite.ToString());

					if (drWA.Length > 0) 
					{

						hand.WasteActivitySite = new WasteActivitySite();
						hand.WasteActivitySite.TransactionCode = Util.ToString(drWA[0]["WASTransactionCode"]);
						hand.WasteActivitySite.FacilitySiteName = Util.ToString(drWA[0]["WASFacilitySiteName"]);
						hand.WasteActivitySite.LandTypeCode = Util.ToString(drWA[0]["WASLandTypeCode"]);
						hand.WasteActivitySite.StateDistrictCode = Util.ToString(drWA[0]["WASStateDistrictCode"]);
						hand.WasteActivitySite.ImporterActivityCode = Util.ToString(drWA[0]["WASImporterActivityCode"]);
						hand.WasteActivitySite.MixedWasteGeneratorCode = Util.ToString(drWA[0]["WASMixedWasteGeneratorCode"]);
						hand.WasteActivitySite.RecyclerActivityCode = Util.ToString(drWA[0]["WASRecyclerActivityCode"]);
						hand.WasteActivitySite.TransporterActivityCode = Util.ToString(drWA[0]["WASTransporterActivityCode"]);
						hand.WasteActivitySite.TreatmentStorageDisposalActivityCode = Util.ToString(drWA[0]["WASTSDActivityCode"]);
						hand.WasteActivitySite.UndergroundInjectionActivityCode = Util.ToString(drWA[0]["WASUGInjectionActivityCode"]);
						if(Util.IsValidBool(drWA[0]["WASUWDFacilityIndicator"]))
						{
							hand.WasteActivitySite.UniversalWasteDestinationFacilityIndicator = Util.ToBool(drWA[0]["WASUWDFacilityIndicator"]);
						}
						if(Util.IsValidBool(drWA[0]["WASTransferFacilityIndicator"]))
						{
							hand.WasteActivitySite.TransferFacilityIndicator = Util.ToBool(drWA[0]["WASTransferFacilityIndicator"]);
						}
						hand.WasteActivitySite.OnsiteBurnerExemptionCode = Util.ToString(drWA[0]["WASOnsiteBurnerExemptionCode"]);
						hand.WasteActivitySite.FurnaceExemptionCode = Util.ToString(drWA[0]["WASFurnaceExemptionCode"]);

					}
					#endregion



					#region StateWasteGenerator
					
					ArrayList stateGens = new ArrayList();

					foreach(DataRow drSubChild in drChild.GetChildRows(
						Data.Relationships.Handler_StateWasteGenerator.ToString()))
					{
						StateWasteGenerator stateGen = new StateWasteGenerator();
						stateGen.TransactionCode = Util.ToString(drSubChild["TransactionCode"]);
						stateGen.WasteGeneratorOwnerName = Util.ToString(drSubChild["WasteGeneratorOwnerName"]);
						stateGen.WasteGeneratorStatusCode = Util.ToString(drSubChild["WasteGeneratorStatusCode"]);

						stateGens.Add(stateGen);
					}

					hand.StateWasteGenerator = (StateWasteGenerator[])stateGens.ToArray(typeof(StateWasteGenerator));

					#endregion



					#region FederalWasteGenerator
					
					ArrayList fedGens = new ArrayList();

					foreach(DataRow drSubChild in drChild.GetChildRows(
						Data.Relationships.Handler_FederalWasteGenerator.ToString()))
					{
						FederalWasteGenerator fedGen = new FederalWasteGenerator();
						fedGen.TransactionCode = Util.ToString(drSubChild["TransactionCode"]);
						fedGen.WasteGeneratorOwnerName = Util.ToString(drSubChild["WasteGeneratorOwnerName"]);
						fedGen.WasteGeneratorStatusCode = Util.ToString(drSubChild["WasteGeneratorStatusCode"]);

						fedGens.Add(fedGen);
					}

					hand.FederalWasteGenerator = (FederalWasteGenerator[])fedGens.ToArray(typeof(FederalWasteGenerator));


					#endregion



					#region Certification

					//Get Handlers
					ArrayList certs = new ArrayList();

					foreach(DataRow drSubChild in drChild.GetChildRows(
						Data.Relationships.Handler_Certification.ToString()))
					{

						Certification cert = new Certification();
						cert.TransactionCode = Util.ToString(drSubChild["TransactionCode"]);
						cert.CertificationSequenceNumberSpecified = Util.IsValidInt(drSubChild["CertificationSequenceNumber"], true);
						if (cert.CertificationSequenceNumberSpecified)
						{
							cert.CertificationSequenceNumber = Util.ToInt(drSubChild["CertificationSequenceNumber"]);
						}
						cert.SignedDateSpecified = Util.IsValidDateTime(drSubChild["SignedDate"], MIN_DATE);
						if(cert.SignedDateSpecified)
						{
							cert.SignedDate = Util.ToDateTime(drSubChild["SignedDate"]);
						}
						cert.Title = Util.ToString(drSubChild["Title"]);
						cert.FirstName = Util.ToString(drSubChild["FirstName"]);
						cert.MiddleInitial = Util.ToString(drSubChild["MiddleInitial"]);
						cert.LastName = Util.ToString(drSubChild["LastName"]);
						cert.SupplementalInformation = Util.ToString(drSubChild["SupplementalInformation"]);

						certs.Add(cert);

					}

					hand.Certification = (Certification[])certs.ToArray(typeof(Certification));

					#endregion



					#region NAICS

					//Get Handlers
					ArrayList naicses = new ArrayList();

					foreach(DataRow drSubChild in drChild.GetChildRows(
						Data.Relationships.Handler_NAICS.ToString()))
					{
						NAICS naics = new NAICS();
						naics.TransactionCode = Util.ToString(drSubChild["TransactionCode"]);
						naics.NAICSSequenceNumber = Util.ToString(drSubChild["NAICSSequenceNumber"]);
						naics.NAICSOwnerCode = Util.ToString(drSubChild["NAICSOwnerCode"]);
						if(Util.ToString(drSubChild["NAICSCODE"]) != null)
						{
							naics.NAICSCode = Util.ToString(drSubChild["NAICSCODE"]).PadRight(6,'0');
						}
						naics.SupplementalInformation = Util.ToString(drSubChild["SUPPLEMENTALINFORMATION"]);
						naicses.Add(naics);
					}

					hand.NAICS = (NAICS[])naicses.ToArray(typeof(NAICS));

					#endregion



					#region OwnerOperatorFacility

					//Get Handlers
					ArrayList ownerFacs = new ArrayList();

					foreach(DataRow drSubChild in drChild.GetChildRows(
						Data.Relationships.Handler_OwnerOperatorFacility.ToString()))
					{
						OwnerOperatorFacility ownerFac = new OwnerOperatorFacility();
						ownerFac.TransactionCode = Util.ToString(drSubChild["TransactionCode"]);
						ownerFac.OwnerOperatorSequenceNumberSpecified = Util.IsValidInt(drSubChild["OwnerOperatorSequenceNumber"], true);
						if (ownerFac.OwnerOperatorSequenceNumberSpecified)
						{
							ownerFac.OwnerOperatorSequenceNumber = Util.ToInt(drSubChild["OwnerOperatorSequenceNumber"]);
						}

						//if (Util.IsValidBool(drSubChild["OwnerOperatorIndicator"]))
						//{
						//	ownerFac.OwnerOperatorIndicator = Util.ToBool(drSubChild["OwnerOperatorIndicator"]);
						//}
						if (Util.ToString(drSubChild["OwnerOperatorIndicator"])!= "")
						{
							ownerFac.OwnerOperatorIndicator = Util.ToString(drSubChild["OwnerOperatorIndicator"]);
						}

						ownerFac.OwnerOperatorTypeCode = Util.ToString(drSubChild["OwnerOperatorTypeCode"]);
						ownerFac.CurrentStartDateSpecified = Util.IsValidDateTime(drSubChild["CurrentStartDate"], MIN_DATE);
						if(ownerFac.CurrentStartDateSpecified)
						{
							ownerFac.CurrentStartDate = Util.ToDateTime(drSubChild["CurrentStartDate"]);
						}
						ownerFac.CurrentEndDateSpecified = Util.IsValidDateTime(drSubChild["CurrentEndDate"], ownerFac.CurrentStartDate);
						if(ownerFac.CurrentEndDateSpecified)
						{
							ownerFac.CurrentEndDate = Util.ToDateTime(drSubChild["CurrentEndDate"]);
						}
						ownerFac.DUNSID = Util.ToString(drSubChild["DUNSID"]);
						ownerFac.SupplementalInformation = Util.ToString(drSubChild["SupplementalInformation"]);


						ownerFac.AddressContact = new AddressContact();
						ownerFac.AddressContact.Contact = new Contact();
						ownerFac.AddressContact.Contact.OrganizationFormalName = Util.ToString(drSubChild["OwnerOperatorName"]);
						
						if(drSubChild["MailingAddressText"] != DBNull.Value)
						{
							ownerFac.AddressContact.MailingAddress = new MailingAddress();
							ownerFac.AddressContact.MailingAddress.MailingAddressText = Util.ToString(drSubChild["MailingAddressText"]);
							//ownerFac.AddressContact.MailingAddress.SupplementalAddressText = Util.ToString(drSubChild["SupplementalAddressText"]);
							if(drSubChild["SupplementalAddressText"] != DBNull.Value) ownerFac.AddressContact.MailingAddress.SupplementalAddressText = Util.ToString(drSubChild["SupplementalAddressText"]);
							ownerFac.AddressContact.MailingAddress.MailingAddressCityName = Util.ToString(drSubChild["MailingAddressCityName"]);
							//ownerFac.AddressContact.MailingAddress.MailingAddressStateUSPSCode = Util.ToString(drSubChild["MailingAddressStateUSPSCode"]);
							if(drSubChild["MailingAddressStateUSPSCode"] != DBNull.Value) ownerFac.AddressContact.MailingAddress.MailingAddressStateUSPSCode = Util.ToString(drSubChild["MailingAddressStateUSPSCode"]);
							//ownerFac.AddressContact.MailingAddress.MailingAddressStateName = Util.ToString(drSubChild["MailingAddressStateName"]);
							if(drSubChild["MailingAddressStateName"] != DBNull.Value) ownerFac.AddressContact.MailingAddress.MailingAddressStateName = Util.ToString(drSubChild["MailingAddressStateName"]);
							//ownerFac.AddressContact.MailingAddress.MailingAddressCountryName = Util.ToString(drSubChild["MailingAddressCountryName"]);
							if(drSubChild["MailingAddressCountryName"] != DBNull.Value) ownerFac.AddressContact.MailingAddress.MailingAddressCountryName = Util.ToString(drSubChild["MailingAddressCountryName"]);
							ownerFac.AddressContact.MailingAddress.MailingAddressZIPCode = Util.ToString(drSubChild["MailingAddressZIPCode"]);
						}
						ownerFacs.Add(ownerFac);
	
					}

					hand.OwnerOperatorFacility = (OwnerOperatorFacility[])ownerFacs.ToArray(typeof(OwnerOperatorFacility));

					#endregion



					#region PermitEnvironmental

					//Get Handlers
					ArrayList pemEnvs = new ArrayList();

					foreach(DataRow drSubChild in drChild.GetChildRows(
						Data.Relationships.Handler_PermitEnvironmental.ToString()))
					{
						PermitEnvironmental pemEnv = new PermitEnvironmental();
						pemEnv.TransactionCode = Util.ToString(drSubChild["TransactionCode"]);
						pemEnv.EnvironmentalPermitID = Util.ToString(drSubChild["EnvironmentalPermitID"]);
						pemEnv.EnvironmentalPermitOwnerName = Util.ToString(drSubChild["EnvironmentalPermitOwnerName"]);
						pemEnv.EnvironmentalPermitTypeCode = Util.ToString(drSubChild["EnvironmentalPermitTypeCode"]);
						pemEnv.EnvironmentalPermitDescription = Util.ToString(drSubChild["EnvironmentalPermitDescription"]);
						pemEnv.SupplementalInformation = Util.ToString(drSubChild["SupplementalInformation"]);

						pemEnvs.Add(pemEnv);
					}

					hand.PermitEnvironmental = (PermitEnvironmental[])pemEnvs.ToArray(typeof(PermitEnvironmental));

					#endregion



					#region StateActivity

					//Get Handlers
					ArrayList stateActs = new ArrayList();

					foreach(DataRow drSubChild in drChild.GetChildRows(
						Data.Relationships.Handler_StateActivity.ToString()))
					{
						StateActivity stateAct = new StateActivity();
						stateAct.TransactionCode = Util.ToString(drSubChild["TransactionCode"]);
						stateAct.StateActivityOwnerName = Util.ToString(drSubChild["StateActivityOwnerName"]);
						stateAct.StateActivityTypeCode = Util.ToString(drSubChild["StateActivityTypeCode"]);
						stateAct.SupplementalInformation = Util.ToString(drSubChild["SupplementalInformation"]);
						stateActs.Add(stateAct);
					}

					hand.StateActivity = (StateActivity[])stateActs.ToArray(typeof(StateActivity));

					#endregion



					#region HandlerUniversalWaste

					//Get Handlers
					ArrayList handUnivs = new ArrayList();

					foreach(DataRow drSubChild in drChild.GetChildRows(
						Data.Relationships.Handler_HandlerUniversalWaste.ToString()))
					{
						HandlerUniversalWaste handUniv = new HandlerUniversalWaste();
						handUniv.TransactionCode = Util.ToString(drSubChild["TransactionCode"]);
						handUniv.UniversalWasteOwnerName = Util.ToString(drSubChild["UniversalWasteOwnerName"]);
						handUniv.UniversalWasteTypeCode = Util.ToString(drSubChild["UniversalWasteTypeCode"]);
						handUniv.AccumulatedWasteCode = Util.ToString(drSubChild["AccumulatedWasteCode"]);
						handUniv.GeneratedHandlerCode = Util.ToString(drSubChild["GeneratedHandlerCode"]);
						handUniv.SupplementalInformation = Util.ToString(drSubChild["SupplementalInformation"]);
						handUnivs.Add(handUniv);
					}

					hand.HandlerUniversalWaste = (HandlerUniversalWaste[])handUnivs.ToArray(typeof(HandlerUniversalWaste));

					#endregion



					#region HandlerWasteCodeDetails

					//Get Handlers
					ArrayList handWastes = new ArrayList();

					foreach(DataRow drSubChild in drChild.GetChildRows(
						Data.Relationships.Handler_HandlerWasteCodeDetails.ToString()))
					{
						HandlerWasteCodeDetails handWaste = new HandlerWasteCodeDetails();
						handWaste.TransactionCode = Util.ToString(drSubChild["TransactionCode"]);
						handWaste.WasteCodeOwnerName = Util.ToString(drSubChild["WasteCodeOwnerName"]);
						handWaste.WasteCode = Util.ToString(drSubChild["WasteCode"]);
						handWastes.Add(handWaste);
					}

					hand.HandlerWasteCodeDetails = (HandlerWasteCodeDetails[])handWastes.ToArray(typeof(HandlerWasteCodeDetails));

					#endregion


					handlers.Add(hand);
				}
				

				facType.Handler = (HandlerDataType[])handlers.ToArray(typeof(HandlerDataType));

				#endregion

				//Add Loaded object (parent) to the collection
				detailArray.Add(facType);

				//Increment
				rowCount++;

				if ((rowCount >= maxRows) && (maxRows != -1))
				{
					break;
				}

			}

			//Assign the collection of FacilitySubmissionType of the parent table
			hdRoot.FacilitySubmission = (FacilitySubmission[]) detailArray.ToArray(typeof(FacilitySubmission));

			return hdRoot;

		}

		#region INodeExecutable Members

		/// <summary>
		/// ProcessSynchronousRequest
		/// </summary>
		/// <param name="sourceResource"></param>
		/// <param name="serviceName"></param>
		/// <param name="paramValues"></param>
		/// <param name="rowId"></param>
		/// <param name="maxRows"></param>
		/// <returns></returns>
		public MemoryStream ProcessSynchronousRequest(
			string sourceResource, 
			string serviceName, 
			string[] paramValues, 
			int rowId, 
			int maxRows) 
		{
			throw new ApplicationException("RCRA Flow does not support synchronous requests. Please consult RCRA FCD.");
		}

		
		/// <summary>
		/// ProcessAsynchronousRequest
		/// </summary>
		/// <param name="sourceResource"></param>
		/// <param name="targetResource"></param>
		/// <param name="serviceName"></param>
		/// <param name="paramValues"></param>
		public void ProcessAsynchronousRequest(
			string sourceResource, 
			string targetResource, 
			string serviceName, 
			string[] paramValues) 
		{
			HazardousWasteHandlerSubmission returnSubmission = GetHazardousWasteHandlerSubmission(
				sourceResource, 
				serviceName, 
				0, 
				int.MaxValue, 
				paramValues);

			returnSubmission.SerializeToFile(targetResource);		

		}

		
		/// <summary>
		/// ProcessInboundSubmission
		/// </summary>
		/// <param name="sourceResource"></param>
		/// <param name="targetResource"></param>
		/// <param name="submittedDocument"></param>
		public void ProcessInboundSubmission(
			string sourceResource, 
			string targetResource, 
			object submittedDocument) 
		{
			throw new ApplicationException("Method not implemented. Please see Flow Configuration Documentation.");
		}

		
		public int VersionNumber 
		{ 
			get 
			{
				return VERSION_NUMBER;
			}
		}


		public string FlowName 
		{
			get 
			{
				return FLOW_NAME;
			}
		}
  
  
		public bool SupportsInboundSubmit 
		{ 
			get 
			{
				return SUPPORTS_INBOUND_SUBMIT;
			}
		}


		public INodeService[] SupportedServices 
		{
			get { return (NodeService[])m_SupportedServices.ToArray(typeof(NodeService));}
		}


		#endregion
		
		
	}
}