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

namespace Windsor.Node2008.WNOSPlugin.PNWWQX
{
	/// <summary>
	/// Summary description for Stations.
	/// </summary>
	public class Stations : Common
	{
		public static void loadStationsValues(ref ArrayList stationsArray, ref DataSet ds)
		{

			/* Tables[0] is Providing Organization  */
			/* Tables[1] is Projects */
			/* Tables[2] is Stations  */
			/* Tables[3] is well detail*/
			/* Tables[4] is Location Descriptors */
			/* Tables[5] is ContactEntity*/
			/* Tables[6] is BinaryLargeObject */

			//Load relationships
			LoadRelationships(ref ds, PNWWQDXIdentity.Station);


			// ********************************************************
			// Populate data plan
			// ********************************************************
			// ForEach ProvidingOrganization 
			//      Load ProvidingOrganization
			//      Get Projects for this ProvidingOrganization
			//      ForEach Project in Projects
			//          Load Project
			//          Get Binary Large Objects for this Project
			//          ForEach Object in Binary Large Objects
			//              Load Object
			//          End ForEach Object in Binary Large Objects
			//          Get Project Contacts for this Project
			//          ForEach Contact in Project Contacts
			//              Load Contact
			//          End ForEach Contact in Project Contacts
			//      End ForEach Project in Projects
			// End ForEach ProvidingOrganization


			// ForEach ProvidingOrganization 
			foreach(DataRow drProvidingOrg in ds.Tables[0].Rows)
			{

				// Instantiate a copy of the array element
				PNWWQXStationsList stationsListItem = new PNWWQXStationsList();

				#region Load Providing Organization

				// Instantiate the copy of prov org detail
				stationsListItem.ProvidingOrganizationDetails = new ProvidingOrganizationDetailsType();

				//ProvidingOrganizationIdentifier
				stationsListItem.ProvidingOrganizationDetails.ProvidingOrganizationIdentifier = Utility.toStr(drProvidingOrg["ProvidingOrganizationIdentifier"]);
			
				//ProvidingOrganization
				stationsListItem.ProvidingOrganizationDetails.ProvidingOrganizationName = Utility.toStr(drProvidingOrg["ProvidingOrganizationName"]);

				//ProvidingOrganizationType
				stationsListItem.ProvidingOrganizationDetails.ProvidingOrganizationType = Utility.toStr(drProvidingOrg["ProvidingOrganizationType"]);
			
				//ProvidingOrganizationContact
				stationsListItem.ProvidingOrganizationDetails.ProvidingOrganizationContactName = Utility.toStr(drProvidingOrg["ProvidingOrganizationContactName"]);

				//ProvidingOrganizationMailingAddressType
				if(drProvidingOrg["MailingAddress"] != DBNull.Value ||
					drProvidingOrg["MailingAddressCityName"] != DBNull.Value ||
					drProvidingOrg["MailingAddressStateName"] != DBNull.Value ||
					drProvidingOrg["MailingAddressZIPCode"] != DBNull.Value)
				{
					stationsListItem.ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress = new MailingAddressType();
					if(drProvidingOrg["MailingAddress"] != DBNull.Value) stationsListItem.ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddress = Utility.toStr(drProvidingOrg["MailingAddress"]);
					if(drProvidingOrg["MailingAddressCityName"] != DBNull.Value) stationsListItem.ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddressCityName = Utility.toStr(drProvidingOrg["MailingAddressCityName"]);
					if(drProvidingOrg["MailingAddressStateName"] != DBNull.Value) stationsListItem.ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddressStateName = Utility.toStr(drProvidingOrg["MailingAddressStateName"]);
					if(drProvidingOrg["MailingAddressZIPCode"] != DBNull.Value) stationsListItem.ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddressZIPCode = Utility.toStr(drProvidingOrg["MailingAddressZIPCode"]);
				}

				//ProvidingOrganizationPhoneEmailType
				stationsListItem.ProvidingOrganizationDetails.ProvidingOrganizationPhoneEmail = new PhoneEmailType();
				stationsListItem.ProvidingOrganizationDetails.ProvidingOrganizationPhoneEmail.TelephoneNumber = Utility.toStr(drProvidingOrg["TelephoneNumber"]);
				if(drProvidingOrg["ElectronicMailAddressText"] != DBNull.Value) stationsListItem.ProvidingOrganizationDetails.ProvidingOrganizationPhoneEmail.ElectronicMailAddressText = Utility.toStr(drProvidingOrg["ElectronicMailAddressText"]);

				//ProvidingOrganizationURL
				if(drProvidingOrg["ProvidingOrganizationURL"] != DBNull.Value) stationsListItem.ProvidingOrganizationDetails.ProvidingOrganizationURL = Utility.toStr(drProvidingOrg["ProvidingOrganizationURL"]);

				#endregion


				#region Load Projects for this Providing Organization

				// Array to hold the individual instances of project detail type
				ArrayList projectList = new ArrayList();

				foreach(DataRow drProject in drProvidingOrg.GetChildRows(ds.Relations["Org_Projects"]))
				{

					#region Project Details

					// Create an individual instances of project detail type
					ProjectDetails_ForStations projectItem = new ProjectDetails_ForStations();

					//ProjectDetailsType
					projectItem.ProjectDetailsType = new ProjectDetailsType();
					projectItem.ProjectDetailsType.ProjectIdentifier = Utility.toStr(drProject["ProjectIdentifier"]);
					projectItem.ProjectDetailsType.ProjectName = Utility.toStr(drProject["ProjectName"]);
					projectItem.ProjectDetailsType.ProjectDescription = Utility.toStr(drProject["ProjectDescription"]);
					projectItem.ProjectDetailsType.ProjectStartDate =  Utility.toDT(drProject["ProjectStartDate"]);
					if(drProject["ProjectEndDate"] != DBNull.Value) projectItem.ProjectDetailsType.ProjectEndDate = Utility.toDT(drProject["ProjectEndDate"]);
					if(drProject["ProjectAreaDescription"] != DBNull.Value) projectItem.ProjectDetailsType.ProjectAreaDescription = Utility.toStr(drProject["ProjectAreaDescription"]);
					projectItem.ProjectDetailsType.ProjectQAPPIndicator = Utility.toBool(drProject["ProjectQAPPIndicator"]);
					if(drProject["ProjectQAPPDescription"] != DBNull.Value) projectItem.ProjectDetailsType.ProjectQAPPDescription = Utility.toStr(drProject["ProjectQAPPDescription"]);


					#endregion

					#region Load Project Contacts

					//ProjectContact - Get by relationship and llop througheach row
					//                 If contact identifier = project contact, prim = true

					ArrayList projectContactList = new ArrayList();
					Hashtable loadedProjectContacts = new Hashtable();

					foreach(DataRow drContact in drProject.GetChildRows(ds.Relations["Project_Contact"]))
					{
						if (!loadedProjectContacts.ContainsKey(Utility.toStr(drContact["ContactEntityIdentifier"])))
						{
							ProjectContactType contactItem = new ProjectContactType();

							contactItem.ProjectContactIdentifier = Utility.toStr(drContact["ContactEntityIdentifier"]);
							contactItem.PrimaryDataSourceIndicator = (Utility.toStr(drProject["ProjectContactIdentifier"]).Equals(
								contactItem.ProjectContactIdentifier));

							projectContactList.Add(contactItem);
							loadedProjectContacts.Add(Utility.toStr(drContact["ContactEntityIdentifier"]), drContact["ContactEntityIdentifier"]);
						}
					}

					projectItem.ProjectContact = (ProjectContactType[])projectContactList.ToArray(typeof(ProjectContactType));


					#endregion


					// Add individual instances of project detail type to the project detail array
					projectList.Add(projectItem);

				}

				// Cast the copy of project detail array to the root type
				stationsListItem.ProjectDetails = (ProjectDetails_ForStations[])projectList.ToArray(typeof(ProjectDetails_ForStations));

				#endregion


				#region Load Stations for this Providing Organization

				// Array to hold the individual instances of project detail type
				ArrayList stationList = new ArrayList();

				foreach(DataRow drStation in drProvidingOrg.GetChildRows(ds.Relations["Org_Station"]))
				{

					#region Staion Details

					// Create an individual instances of station detail type
					StationDetails_ForStations stationItem = new StationDetails_ForStations();

					//StationDetailsType
					stationItem.StationDetailsType = new StationDetailsType();
					stationItem.StationDetailsType.StationIdentifier = Utility.toStr(drStation["StationIdentifier"]);
					stationItem.StationDetailsType.StationName = Utility.toStr(drStation["StationName"]);
					if(drStation["StationLocationDescription"] != DBNull.Value) stationItem.StationDetailsType.StationLocationDescription = Utility.toStr(drStation["StationLocationDescription"]);
					stationItem.StationDetailsType.StationType = Utility.toStr(drStation["StationType"]);
					
					stationItem.StationDetailsType.LatitudeMeasure = Utility.toDecimal(drStation["LatitudeMeasure"]);
					stationItem.StationDetailsType.LongitudeMeasure = Utility.toDecimal(drStation["LongitudeMeasure"]);
					
					if(drStation["HorizontalAccuracyMeasure"] != DBNull.Value) stationItem.StationDetailsType.HorizontalAccuracyMeasure = Utility.toInt(drStation["HorizontalAccuracyMeasure"]).ToString();
					if(drStation["SourceMapScaleNumber"] != DBNull.Value) stationItem.StationDetailsType.SourceMapScaleNumber = Utility.toInt(drStation["SourceMapScaleNumber"]).ToString();
					if(drStation["CoordinateDataSourceName"] != DBNull.Value) stationItem.StationDetailsType.CoordinateDataSourceName = Utility.toStr(drStation["CoordinateDataSourceName"]);
					
					stationItem.StationDetailsType.HorizontalCollectionMethodText = Utility.toStr(drStation["HorizontalCollectionMethodText"]);
					stationItem.StationDetailsType.HorizontalReferenceDatumName = Utility.toStr(drStation["HorizontalReferenceDatumName"]);
					
					if(drStation["ReferencePointText"] != DBNull.Value) stationItem.StationDetailsType.ReferencePointText = Utility.toStr(drStation["ReferencePointText"]);
					if(drStation["VerticalMeasure"] != DBNull.Value) stationItem.StationDetailsType.VerticalMeasure = Utility.toInt(drStation["VerticalMeasure"]).ToString(); 
					if(drStation["VerticalMeasureUnitofMeasure"] != DBNull.Value) stationItem.StationDetailsType.VerticalMeasureUnitofMeasure = Utility.toStr(drStation["VerticalMeasureUnitofMeasure"]);
					if(drStation["VerticalAccuracyMeasure"] != DBNull.Value) stationItem.StationDetailsType.VerticalAccuracyMeasure = Utility.toInt(drStation["VerticalAccuracyMeasure"]).ToString();
					if(drStation["VerticalCollectionMethodText"] != DBNull.Value) stationItem.StationDetailsType.VerticalCollectionMethodText = Utility.toStr(drStation["VerticalCollectionMethodText"]);
					if(drStation["VerticalReferenceDatumName"] != DBNull.Value) stationItem.StationDetailsType.VerticalReferenceDatumName = Utility.toStr(drStation["VerticalReferenceDatumName"]);
					if(drStation["VerticalReferencePointContextText"] != DBNull.Value) stationItem.StationDetailsType.VerticalReferencePointContextText = Utility.toStr(drStation["VerticalReferencePointContextText"]);
                    
					#region StationLocationDescriptor

					//StationLocationDescriptor
					ArrayList stationLocDescrList = new ArrayList();

					foreach(DataRow drStationLocDescr in drStation.GetChildRows(ds.Relations["Station_LocationDescriptor"]))
					{
						LocationDescriptor stationLocDescr = new LocationDescriptor();
						stationLocDescr.LocationDescriptorName = Utility.toStr(drStationLocDescr["LocationDescriptorName"]);
						stationLocDescr.LocationDescriptorContext = Utility.toStr(drStationLocDescr["LocationDescriptorContext"]);
					}

					stationItem.StationDetailsType.LocationDescriptor = (LocationDescriptor[])stationLocDescrList.ToArray(typeof(LocationDescriptor));

					#endregion

                    
					#region WellDetail
                  
					DataRow[] drWellDetails = drStation.GetChildRows(ds.Relations["Station_Well"]);
					if ((drWellDetails != null) && (drWellDetails.Length > 0))
					{
						DataRow drWellDetail = drWellDetails[0];
						stationItem.StationDetailsType.WellDetail = new WellDetailType();
						stationItem.StationDetailsType.WellDetail.WellIdentifier = Utility.toStr(drWellDetail["WellIdentifier"]);
						stationItem.StationDetailsType.WellDetail.WellIdentifierContext = Utility.toStr(drWellDetail["WellIdentifierContext"]);
						
						if(drWellDetail["WellDepthCompletionMeasure"] != DBNull.Value) stationItem.StationDetailsType.WellDetail.WellDepthCompletionMeasure = Utility.toDecimal(drWellDetail["WellDepthCompletionMeasure"]);
						if(drWellDetail["WellOpenIntervalType"] != DBNull.Value) stationItem.StationDetailsType.WellDetail.WellOpenIntervalType = Utility.toStr(drWellDetail["WellOpenIntervalType"]);
						if(drWellDetail["WellDepthTopOpenIntervalMeasure"] != DBNull.Value) stationItem.StationDetailsType.WellDetail.WellDepthTopOpenIntervalMeasure = Utility.toDecimal(drWellDetail["WellDepthTopOpenIntervalMeasure"]);
						if(drWellDetail["WellDepthBottomOpenIntervalMeasure"] != DBNull.Value) stationItem.StationDetailsType.WellDetail.WellDepthBottomOpenIntervalMeasure = Utility.toDecimal(drWellDetail["WellDepthBottomOpenIntervalMeasure"]);
						if(drWellDetail["WellDepthUnitMeasureName"] != DBNull.Value) stationItem.StationDetailsType.WellDetail.WellDepthUnitMeasureName = Utility.toStr(drWellDetail["WellDepthUnitMeasureName"]);
						if(drWellDetail["WellDiameterMeasure"] != DBNull.Value) stationItem.StationDetailsType.WellDetail.WellDiameterMeasure = Utility.toDecimal(drWellDetail["WellDiameterMeasure"]);
						if(drWellDetail["WellDiameterUnitMeasureName"] != DBNull.Value) stationItem.StationDetailsType.WellDetail.WellDiameterUnitMeasureName = Utility.toStr(drWellDetail["WellDiameterUnitMeasureName"]);
						
						stationItem.StationDetailsType.WellDetail.WellStatus = Utility.toStr(drWellDetail["WellStatus"]);
						stationItem.StationDetailsType.WellDetail.WellUse = Utility.toStr(drWellDetail["WellUse"]);
                        
					}

					#endregion

					#endregion

					#region Load Station Binary Large Object

					//StationBinaryLargeObject - Get by relationship and llop througheach row

					ArrayList stationBinaryObject = new ArrayList();

					foreach(DataRow drObjectStation in drStation.GetChildRows(ds.Relations["Station_Binary"]))
					{
						BinaryLargeObject objectItem = new BinaryLargeObject();

						//BinaryObject
						if(drObjectStation["content"] != System.DBNull.Value)
						{
							objectItem.BinaryObject = new NodeDocument();
							objectItem.BinaryObject.name = Utility.toStr(drObjectStation["name"]);
							objectItem.BinaryObject.type = Utility.toStr(drObjectStation["type"]);
							objectItem.BinaryObject.content = (byte[])drObjectStation["content"];
						}

						if(drObjectStation["BinaryObjectURL"] != DBNull.Value) objectItem.BinaryObjectURL = Utility.toStr(drObjectStation["BinaryObjectURL"]);
						if(drObjectStation["BinaryObjectSize"] != DBNull.Value) objectItem.BinaryObjectSize = Utility.toInt(drObjectStation["BinaryObjectSize"]).ToString();
						if(drObjectStation["BinaryObjectTitleText"] != DBNull.Value) objectItem.BinaryObjectTitleText = Utility.toStr(drObjectStation["BinaryObjectTitleText"]);
						if(drObjectStation["BinaryObjectCreator"] != DBNull.Value) objectItem.BinaryObjectCreator = Utility.toStr(drObjectStation["BinaryObjectCreator"]);
						if(drObjectStation["BinaryObjectSubject"] != DBNull.Value) objectItem.BinaryObjectSubject = Utility.toStr(drObjectStation["BinaryObjectSubject"]);
						if(drObjectStation["BinaryObjectDescription"] != DBNull.Value) objectItem.BinaryObjectDescription = Utility.toStr(drObjectStation["BinaryObjectDescription"]);
						if(drObjectStation["BinaryObjectPublisher"] != DBNull.Value) objectItem.BinaryObjectPublisher = Utility.toStr(drObjectStation["BinaryObjectPublisher"]);
						if(drObjectStation["BinaryObjectContributor"] != DBNull.Value) objectItem.BinaryObjectContributor = Utility.toStr(drObjectStation["BinaryObjectContributor"]);
						if(drObjectStation["BinaryObjectDate"] != DBNull.Value) objectItem.BinaryObjectDate = Utility.toDT(drObjectStation["BinaryObjectDate"]);
						if(drObjectStation["BinaryObjectType"] != DBNull.Value) objectItem.BinaryObjectType = Utility.toStr(drObjectStation["BinaryObjectType"]);
						if(drObjectStation["BinaryObjectContentTypeText"] != DBNull.Value) objectItem.BinaryObjectContentTypeText = Utility.toStr(drObjectStation["BinaryObjectContentTypeText"]);
						if(drObjectStation["BinaryObjectIdentifierText"] != DBNull.Value) objectItem.BinaryObjectIdentifierText = Utility.toStr(drObjectStation["BinaryObjectIdentifierText"]);
						if(drObjectStation["BinaryObjectSource"] != DBNull.Value) objectItem.BinaryObjectSource = Utility.toStr(drObjectStation["BinaryObjectSource"]);
						if(drObjectStation["BinaryObjectLanguage"] != DBNull.Value) objectItem.BinaryObjectLanguage = Utility.toStr(drObjectStation["BinaryObjectLanguage"]);
						if(drObjectStation["BinaryObjectRelation"] != DBNull.Value) objectItem.BinaryObjectRelation = Utility.toStr(drObjectStation["BinaryObjectRelation"]);
						if(drObjectStation["BinaryObjectCoverage"] != DBNull.Value) objectItem.BinaryObjectCoverage = Utility.toStr(drObjectStation["BinaryObjectCoverage"]);
						if(drObjectStation["BinaryObjectRights"] != DBNull.Value) objectItem.BinaryObjectRights = Utility.toStr(drObjectStation["BinaryObjectRights"]);

						stationBinaryObject.Add(objectItem);
					}

					stationItem.StationBinaryLargeObject = (BinaryLargeObject[])stationBinaryObject.ToArray(typeof(BinaryLargeObject));


					#endregion

					#region StationProjectIdentifier
					//StationProjectIdentifier - Get by relationship and llop througheach row

					ArrayList stationProjectIdentifierList = new ArrayList();

					foreach(DataRow drStationProjectIdentifier in drStation.GetChildRows(ds.Relations["Station_ProjectStation"]))
					{
						stationProjectIdentifierList.Add(Utility.toStr(drStationProjectIdentifier["StationProjectIdentifier"]));
					}

					stationItem.StationProjectIdentifier = (string[])stationProjectIdentifierList.ToArray(typeof(string));
					#endregion

					#region Load Station Contacts

					//StationContact - Get by relationship and llop througheach row
					//                 If contact identifier = station contact, prim = true

					ArrayList stationContactList = new ArrayList();
					Hashtable loadedStationContacts = new Hashtable();

					foreach(DataRow drContactStation in drStation.GetChildRows(ds.Relations["Station_Contact"]))
					{
						if (!loadedStationContacts.ContainsKey(Utility.toStr(drContactStation["ContactEntityIdentifier"])))
						{
							stationContactList.Add(Utility.toStr(drContactStation["ContactEntityIdentifier"]));
							loadedStationContacts.Add(Utility.toStr(drContactStation["ContactEntityIdentifier"]), drContactStation["ContactEntityIdentifier"]);
						}
					}

					stationItem.StationContactIdentifier = (string[])stationContactList.ToArray(typeof(string));


					#endregion


					// Add individual instances of project detail type to the project detail array
					stationList.Add(stationItem);

				}


				// Cast the copy of project detail array to the root type
				stationsListItem.StationDetails = (StationDetails_ForStations[])stationList.ToArray(typeof(StationDetails_ForStations));

				#endregion


				#region Load Contact for this Providing Organization

				//Contact - Get by relationship and llop througheach row

				ArrayList contactList = new ArrayList();
				Hashtable loadedContacts = new Hashtable();

				foreach(DataRow drContactRoot in drProvidingOrg.GetChildRows(ds.Relations["Org_Contact"]))
				{
					if (!loadedContacts.ContainsKey(Utility.toStr(drContactRoot["ContactEntityIdentifier"])))
					{
						ContactEntityDetails contactItem = new ContactEntityDetails();

						contactItem.ContactEntityIdentifier = Utility.toStr(drContactRoot["ContactEntityIdentifier"]);

						//ContactOrganization
						if(drContactRoot["ContactOrganizationName"] != DBNull.Value) contactItem.ContactOrganizationName = Utility.toStr(drContactRoot["ContactOrganizationName"]);

						//ContactEntityType
						contactItem.ContactEntityType = Utility.toStr(drContactRoot["ContactEntityType"]);

						//Contact
						contactItem.ContactIndividualName = Utility.toStr(drContactRoot["ContactIndividualName"]);

						//ContactMailingAddress
						if(drContactRoot["MailingAddress"] != DBNull.Value ||
							drContactRoot["MailingAddressCityName"] != DBNull.Value ||
							drContactRoot["MailingAddressStateName"] != DBNull.Value ||
							drContactRoot["MailingAddressZIPCode"] != DBNull.Value)
						{
							contactItem.ContactMailingAddress = new MailingAddressType();
							if(drContactRoot["MailingAddress"] != DBNull.Value) contactItem.ContactMailingAddress.MailingAddress = Utility.toStr(drContactRoot["MailingAddress"]);
							if(drContactRoot["MailingAddressCityName"] != DBNull.Value) contactItem.ContactMailingAddress.MailingAddressCityName = Utility.toStr(drContactRoot["MailingAddressCityName"]);
							if(drContactRoot["MailingAddressStateName"] != DBNull.Value) contactItem.ContactMailingAddress.MailingAddressStateName = Utility.toStr(drContactRoot["MailingAddressStateName"]);
							if(drContactRoot["MailingAddressZIPCode"] != DBNull.Value) contactItem.ContactMailingAddress.MailingAddressZIPCode = Utility.toStr(drContactRoot["MailingAddressZIPCode"]);
						}
						//ContactPhoneEmail
						contactItem.ContactPhoneEmail = new PhoneEmailType();
						if(drContactRoot["ElectronicMailAddressText"] != DBNull.Value) contactItem.ContactPhoneEmail.ElectronicMailAddressText = Utility.toStr(drContactRoot["ElectronicMailAddressText"]);
						contactItem.ContactPhoneEmail.TelephoneNumber = Utility.toStr(drContactRoot["TelephoneNumber"]);

						//Add to list
						contactList.Add(contactItem);
						loadedContacts.Add(Utility.toStr(drContactRoot["ContactEntityIdentifier"]),drContactRoot["ContactEntityIdentifier"]);
					}
				}

				//Cast back to the collection
				stationsListItem.ContactEntityDetails = (ContactEntityDetails[])contactList.ToArray(typeof(ContactEntityDetails));


				#endregion



				// Add the copy of Instantiated array element to the return array
				stationsArray.Add(stationsListItem);

			}       
		}
	}
}