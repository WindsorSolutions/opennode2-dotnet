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
using System.Collections;
using System.Data;
using System.Text;

namespace Windsor.Node2008.WNOSPlugin.RCRA
{
    /// <summary>
    /// Summary description for Data.
    /// </summary>
    public class Data
    {

		public enum Relationships 
		{
			FacilitySubmission_PreviousHandler,
			FacilitySubmission_Handler,
			Handler_GeographicCoordinate,
			Handler_UsedOil,
			Handler_StateWasteGenerator,
			Handler_FederalWasteGenerator,
			Handler_Certification,
			Handler_NAICS,
			Handler_OwnerOperatorFacility,
			Handler_PermitEnvironmental,
			Handler_StateActivity,
			Handler_HandlerUniversalWaste,
			Handler_HandlerWasteCodeDetails,
			Handler_WasteActivitySite
		}

		private static string FixSql(string input)
		{
			string output = input;
			output = output.Replace("\n", " ");
			output = output.Replace("\t", " ");
			output = output.Replace("\r", " ");
			
			while(output.IndexOf("  ",0)>0){
			
			  output = output.Replace("  ", " ");
			}
			
			return output;
		}

		public static DataSet GetData(string connectionString) 
		{

			DataSet ds = new DataSet("RCRA");


			// --------------------------------------------------------------------
			// Get Data Tables
			// --------------------------------------------------------------------
			DataTable FacilitySubmission = GetData(0, connectionString);
			DataTable PreviousHandler = GetData(1, connectionString);
			DataTable Handler = GetData(2, connectionString);
			DataTable RCRAGeographicCoordinate = GetData(3, connectionString);
			DataTable UsedOil = GetData(4, connectionString);
			DataTable StateWasteGenerator = GetData(5, connectionString);
			DataTable FederalWasteGenerator = GetData(6, connectionString);
			DataTable Certification = GetData(7, connectionString);
			DataTable NAICS = GetData(8, connectionString);
			DataTable OwnerOperatorFacility = GetData(9, connectionString);
			DataTable PermitEnvironmental = GetData(10, connectionString);
			DataTable StateActivity = GetData(11, connectionString);
			DataTable HandlerUniversalWaste = GetData(12, connectionString);
			DataTable HandlerWasteCodeDetails = GetData(13, connectionString);
			DataTable WasteActivitySite = GetData(14, connectionString);

			// --------------------------------------------------------------------
			// Merge Data Tables
			// --------------------------------------------------------------------
			ds.Tables.Add(FacilitySubmission.Copy());
			ds.Tables[0].TableName = "FacilitySubmission";

			ds.Tables.Add(PreviousHandler.Copy());
			ds.Tables[1].TableName = "PreviousHandler";
                
			ds.Tables.Add(Handler.Copy());
			ds.Tables[2].TableName = "Handler";

			ds.Tables.Add(RCRAGeographicCoordinate.Copy());
			ds.Tables[3].TableName = "RCRAGeographicCoordinate";

			ds.Tables.Add(UsedOil.Copy());
			ds.Tables[4].TableName = "UsedOil";

			ds.Tables.Add(StateWasteGenerator.Copy());
			ds.Tables[5].TableName = "StateWasteGenerator";

			ds.Tables.Add(FederalWasteGenerator.Copy());
			ds.Tables[6].TableName = "FederalWasteGenerator";

			ds.Tables.Add(Certification.Copy());
			ds.Tables[7].TableName = "Certification";

			ds.Tables.Add(NAICS.Copy());
			ds.Tables[8].TableName = "NAICS";
			
			ds.Tables.Add(OwnerOperatorFacility.Copy());
			ds.Tables[9].TableName = "OwnerOperatorFacility";

			ds.Tables.Add(PermitEnvironmental.Copy());
			ds.Tables[10].TableName = "PermitEnvironmental";

			ds.Tables.Add(StateActivity.Copy());
			ds.Tables[11].TableName = "StateActivity";
			
			ds.Tables.Add(HandlerUniversalWaste.Copy());
			ds.Tables[12].TableName = "HandlerUniversalWaste";

			ds.Tables.Add(HandlerWasteCodeDetails.Copy());
			ds.Tables[13].TableName = "HandlerWasteCodeDetails";

			ds.Tables.Add(WasteActivitySite.Copy());
			ds.Tables[14].TableName = "WasteActivitySite";


			ds.AcceptChanges();


			if ((ds == null) || (ds.Tables.Count != 15))
			{
				return null;
			}

			//Relationships

			ds.Relations.Add("FacilitySubmission_PreviousHandler",
				ds.Tables[0].Columns["EPAHandlerID"],
				ds.Tables[1].Columns["EPAHandlerID"]);

			ds.Relations.Add("FacilitySubmission_Handler",
				ds.Tables[0].Columns["EPAHandlerID"],
				ds.Tables[2].Columns["EPAHandlerID"]);

			ds.Relations.Add("Handler_GeographicCoordinate",
				ds.Tables[2].Columns["PERF_ACT_ID"],
				ds.Tables[3].Columns["PERF_ACT_ID"]);

			ds.Relations.Add("Handler_UsedOil",
				ds.Tables[2].Columns["PERF_ACT_ID"],
				ds.Tables[4].Columns["PERF_ACT_ID"]);

			ds.Relations.Add("Handler_StateWasteGenerator",
				ds.Tables[2].Columns["PERF_ACT_ID"],
				ds.Tables[5].Columns["PERF_ACT_ID"]);

			ds.Relations.Add("Handler_FederalWasteGenerator",
				ds.Tables[2].Columns["PERF_ACT_ID"],
				ds.Tables[6].Columns["PERF_ACT_ID"]);

			ds.Relations.Add("Handler_Certification",
				ds.Tables[2].Columns["PERF_ACT_ID"],
				ds.Tables[7].Columns["PERF_ACT_ID"]);

			ds.Relations.Add("Handler_NAICS",
				ds.Tables[2].Columns["PERF_ACT_ID"],
				ds.Tables[8].Columns["PERF_ACT_ID"]);

			ds.Relations.Add("Handler_OwnerOperatorFacility",
				ds.Tables[2].Columns["PERF_ACT_ID"],
				ds.Tables[9].Columns["PERF_ACT_ID"]);	

			ds.Relations.Add("Handler_PermitEnvironmental",
				ds.Tables[2].Columns["PERF_ACT_ID"],
				ds.Tables[10].Columns["PERF_ACT_ID"]);

			ds.Relations.Add("Handler_StateActivity",
				ds.Tables[2].Columns["PERF_ACT_ID"],
				ds.Tables[11].Columns["PERF_ACT_ID"]);

			ds.Relations.Add("Handler_HandlerUniversalWaste",
				ds.Tables[2].Columns["PERF_ACT_ID"],
				ds.Tables[12].Columns["PERF_ACT_ID"]);

			ds.Relations.Add("Handler_HandlerWasteCodeDetails",
				ds.Tables[2].Columns["PERF_ACT_ID"],
				ds.Tables[13].Columns["PERF_ACT_ID"]);

			ds.Relations.Add("Handler_WasteActivitySite",
				ds.Tables[2].Columns["PERF_ACT_ID"],
				ds.Tables[14].Columns["PERF_ACT_ID"]);

			ds.AcceptChanges();

			return ds;
		}


		/// <summary>
		/// GetData
		/// </summary>
		/// <param name="tableIndex"></param>
		/// <param name="connectionString"></param>
		/// <returns></returns>
		private static DataTable GetData(int tableIndex, string connectionString)
		{

			string sql = null;
			DataTable td = null;


			switch (tableIndex)
			{

				case 0:
					sql = @"
						SELECT     
							TransactionCode, 
							HandlerID AS EPAHandlerID, 
							PublicUseExtractIndicator, 
							FacilityRegistryID, 
							SupplementalInformation
						FROM RCRA_FacilitySubmission
						ORDER BY HandlerID
					";
					break;
				case 1:
					sql = @"
						SELECT     
							HandlerID AS EPAHandlerID, 
							TransactionCode, 
							PreviousHandlerID, 
							SupplementalInformation
						FROM RCRA_PREVIOUSHANDLER
					";
					break;
				case 2:
					sql = @"
						SELECT     	      
							Handler.PERF_ACT_ID AS PERF_ACT_ID, 
							Handler.HANDLERID AS EPAHandlerID, 
							Handler.TransactionCode AS HTransactionCode, 
							Handler.ActivityLocationCode AS HActivityLocationCode, 
							Handler.SourceTypeCode AS HSourceTypeCode, 
							Handler.SourceRecordSequenceNumber AS HSourceRecordSequenceNumber, 
							Handler.ReceiveDate AS HReceiveDate, 
							Handler.AcknowledgeReceiptDate AS HAcknowledgeReceiptDate, 
							Handler.NonNotifierIndicator AS HNonNotifierIndicator, 
							Handler.OnsiteEmployeeQuantity AS HOnsiteEmployeeQuantity, 
							Handler.TransferFacilityCode AS HTransferFacilityCode, 
							Handler.SecondaryID AS HSecondaryID, 
							Handler.TreatmentStorageDisposalDate AS HTreatmentStorageDisposalDate, 
							Handler.OffsiteWasteReceiptCode AS HOffsiteWasteReceiptCode, 
							Handler.AccessibilityCode AS HAccessibilityCode, 
							Handler.CountyCodeOwner AS HCountyCodeOwner, 
							Handler.CountyCode AS HCountyCode, 
							Handler.SupplementalInformation AS HSupplementalInformation, 

							RCRALocationAddress.LocationAddressText AS HLALocationAddressText, 
							RCRALocationAddress.SupplementalLocationText AS HLASupplementalLocationText, 
							RCRALocationAddress.LocalityName AS HLALocalityName, 
							NULL AS HLACountyStateFIPSCode, 
							NULL AS HLACountyName, 
							RCRALocationAddress.StateUSPSCode AS HLAStateUSPSCode, 
							NULL AS HLAStateName, 
							NULL AS HLACountryName, 
							RCRALocationAddress.LocationZIPCode AS HLALocationZIPCode, 
							NULL AS HLALocationDescriptionText,

							RCRAMailingAddress.MailingAddressText AS HMAMailingAddressText, 
							RCRAMailingAddress.SupplementalAddressText AS HMASupplementalAddressText, 
							RCRAMailingAddress.MailingAddressCityName AS HMAMailingAddressCityName, 
							RCRAMailingAddress.MailingAddressStateUSPSCode AS HMAMailingAddressStateUSPSCode, 
							NULL AS HMAMailingAddressStateName, 
							NULL AS HMAMailingAddressCountryName, 
							RCRAMailingAddress.MailingAddressZIPCode AS HMAMailingAddressZIPCode, 
							
							Contact.FirstName AS CAFirstName, 
							Contact.MiddleInitial  AS CAMiddleInitial, 
							Contact.LastName AS CALastName, 
							Contact.OrganizationFormalName as CAOrganizationFormalName,

							Contact.ELECTRONICADDRESSTEXT AS CAElectronicAddressText,
							Contact.TELEPHONENUMBER AS CATelephoneNumber,
							Contact.PHONEEXTENSION AS CAPhoneExtension,

							MailingAddressContact.MailingAddressText AS CMAMailingAddressText, 
							MailingAddressContact.SupplementalAddressText AS CMASupplementalAddressText, 
							MailingAddressContact.MailingAddressCityName AS CMAMailingAddressCityName, 
							MailingAddressContact.MailingAddressStateUSPSCode AS CMAMailingAddressStateUSPSCode, 
							MailingAddressContact.MAILINGADDRESSSTATENAME AS CMAMailingAddressStateName, 
							MailingAddressContact.MailingAddressCountryName AS CMAMailingAddressCountryName, 
							MailingAddressContact.MailingAddressZIPCode AS CMAMailingAddressZIPCode, 

							NULL AS PCAFirstName, 
							NULL AS PCAMiddleInitial, 
							NULL AS PCALastName, 
							NULL AS PCAOrganizationFormalName,

							NULL AS PCAElectronicAddressText,
							NULL AS PCATelephoneNumber,
							NULL AS PCAPhoneExtension,
							
							NULL AS PCAMailingAddressText, 
							NULL AS PCASupplementalAddressText, 
							NULL AS PCAMailingAddressCityName, 
							NULL AS PCAMailingAddressStateUSPSCode, 
							NULL AS PCAMailingAddressStateName, 
							NULL AS PCAMailingAddressCountryName, 
							NULL AS PCAMailingAddressZIPCode

						FROM RCRA_Handler  Handler 
						LEFT OUTER JOIN RCRA_MailingAddress RCRAMailingAddress ON RCRAMailingAddress.PERF_ACT_ID = Handler.PERF_ACT_ID 
						LEFT OUTER JOIN RCRA_Contact Contact ON Handler.PERF_ACT_ID = Contact.PERF_ACT_ID
						LEFT OUTER JOIN RCRA_LocationAddress RCRALocationAddress ON Handler.PERF_ACT_ID = RCRALocationAddress.PERF_ACT_ID
						LEFT OUTER JOIN	RCRA_MailingAddress MailingAddressContact ON MailingAddressContact.PERF_ACT_ID = Contact.PERF_ACT_ID 
					";
					break;
				case 3:
					sql = @"
						SELECT     
							PERF_ACT_ID, 
							TransactionCode, 
							LatitudeMeasure, 
							LongitudeMeasure, 
							HorizontalAccuracyMeasure, 
							HorizontalCollectionMethod, 
							HorizontalReferenceDatumName, 
							SourceMapScaleNumber, 
							ReferencePoint, 
							GeometricTypeName
						FROM RCRA_GEOGRAPHICCOORDINATE
					";
					break;
				case 4:
					sql = @"
						SELECT     
							PERF_ACT_ID, 
							TransactionCode, 
							FuelBurnerCode, 
							ProcessorCode, 
							RefinerCode, 
							MarketBurnerCode, 
							SpecificationMarketerCode, 
							TransferFacilityCode, 
							TransporterCode
						FROM    RCRA_UsedOil
					";
					break;
				case 5:
					sql = @"
						SELECT     
							PERF_ACT_ID, 
							TransactionCode, 
							WasteGeneratorOwnerName, 
							WasteGeneratorStatusCode
						FROM    RCRA_StateWasteGenerator
					";
					break;
				case 6:
					sql = @"
						SELECT  
							PERF_ACT_ID, 
							TransactionCode, 
							WasteGeneratorOwnerName, 
							WasteGeneratorStatusCode
						FROM    RCRA_FederalWasteGenerator
					";
					break;
				case 7:
					sql = @"
						SELECT  
							PERF_ACT_ID, 
							TransactionCode, 
							CertificationSequenceNumber, 
							SignedDate, 
							Title, 
							FirstName, 
							MiddleInitial, 
							LastName, 
							SupplementalInformation
						FROM    RCRA_Certification
					";
					break;
				case 8:
					sql = @"
						SELECT     
							PERF_ACT_ID, 
							TransactionCode, 
							NAICSSequenceNumber, 
							NAICSOwnerCode, 
							NAICSCODE, 
							SupplementalInformation
						FROM    RCRA_NAICS
					";
					break;
				case 9:
					sql = @"
						SELECT     
							OwnerOperatorFacility.ACTOR_PA_ID, 
							OwnerOperatorFacility.PERF_ACT_ID, 
							OwnerOperatorFacility.TransactionCode, 
							OwnerOperatorFacility.OwnerOperatorSequenceNumber, 
							OwnerOperatorFacility.OwnerOperatorName, 
							OwnerOperatorFacility.OwnerOperatorIndicator, 
							OwnerOperatorFacility.OwnerOperatorTypeCode, 
							OwnerOperatorFacility.CurrentStartDate, 
							OwnerOperatorFacility.CurrentEndDate, 
							OwnerOperatorFacility.DUNSID, 
							OwnerOperatorFacility.SupplementalInformation, 
							
							MailingAddressContact.MailingAddressText, 
							MailingAddressContact.SupplementalAddressText, 
							MailingAddressContact.MailingAddressCityName, 
							MailingAddressContact.MailingAddressStateUSPSCode, 
							NULL AS MailingAddressStateName, 
							MailingAddressContact.MailingAddressCountryName, 
							MailingAddressContact.MailingAddressZIPCode

						FROM    RCRA_OwnerOperatorFacility OwnerOperatorFacility
						LEFT OUTER JOIN RCRA_MailingAddressOwnerOper MailingAddressOwnerOper ON OwnerOperatorFacility.ACTOR_PA_ID = MailingAddressOwnerOper.ACTOR_PA_ID 
						LEFT OUTER JOIN RCRA_MailingAddress MailingAddressContact ON OwnerOperatorFacility.PERF_ACT_ID = MailingAddressContact.PERF_ACT_ID
					";
					break;
				case 10:
					sql = @"
						SELECT
							PERF_ACT_ID, 
							TransactionCode, 
							EnvironmentalPermitID, 
							EnvironmentalPermitOwnerName, 
							EnvironmentalPermitTypeCode, 
							EnvironmentalPermitDescription, 
							SupplementalInformation
						FROM RCRA_PERMITENVIRONMENTAL
					";
					break;
				case 11:
					sql = @"
						SELECT     
							PERF_ACT_ID, 
							TransactionCode, 
							StateActivityOwnerName, 
							StateActivityTypeCode, 
							SupplementalInformation
						FROM    RCRA_StateActivity
					";
					break;
				case 12:
					//NOTE: Over 1 min.
					sql = @"
						SELECT     
							PERF_ACT_ID, 
							TransactionCode, 
							UniversalWasteOwnerName, 
							UniversalWasteTypeCode, 
							Waste_Code, 
							AccumulatedWasteCode, 
							SupplementalInformation,
							GeneratedHandlerCode
						FROM    RCRA_HandlerUniversalWaste
					";
					break;
				case 13:
					sql = @"
						SELECT  
							PERF_ACT_ID, 
							TransactionCode, 
							WasteCodeOwnerName, 
							WasteCode
						FROM RCRA_HandlerWasteCodeDetails
					";
					break;
				case 14:
					sql = @"
						SELECT  
							WasteActivitySite.PERF_ACT_ID,
							WasteActivitySite.TransactionCode AS WASTransactionCode, 
							WasteActivitySite.FacilitySiteName AS WASFacilitySiteName, 
							WasteActivitySite.LandTypeCode AS WASLandTypeCode, 
							WasteActivitySite.StateDistrictCode AS WASStateDistrictCode, 
							WasteActivitySite.ImporterActivityCode AS WASImporterActivityCode, 
							WasteActivitySite.MixedWasteGeneratorCode AS WASMixedWasteGeneratorCode, 
							WasteActivitySite.RecyclerActivityCode AS WASRecyclerActivityCode, 
							WasteActivitySite.TRANSPACTIVITYCODE AS WASTransporterActivityCode, 
							WasteActivitySite.TSDActivityCode AS WASTSDActivityCode, 
							WasteActivitySite.UGInjectionActivityCode AS WASUGInjectionActivityCode, 
							WasteActivitySite.UWDESTFACILITYINDICATOR AS WASUWDFacilityIndicator, 
							WasteActivitySite.TransferFacilityIndicator AS WASTransferFacilityIndicator, 
							WasteActivitySite.OnsiteBurnerExemptionCode AS WASOnsiteBurnerExemptionCode, 
							WasteActivitySite.FurnaceExemptionCode AS WASFurnaceExemptionCode
						FROM RCRA_WasteActivitySite WasteActivitySite 
					";
					break;
				default:
					throw new ApplicationException("Invalid table index.");
			}


			if (sql != null)
			{

				sql = FixSql(sql);

#if DEBUG
		Console.WriteLine(sql);
		Console.WriteLine(Environment.NewLine + Environment.NewLine);
#endif

#if ORACLE
				td = OracleHelper.ExecuteDataset(connectionString, CommandType.Text, sql).Tables[0];
#else
				td = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sql).Tables[0];

#endif
			}

			return td;


		}
       
    }
}
