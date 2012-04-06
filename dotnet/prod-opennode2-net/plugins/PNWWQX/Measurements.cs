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
	/// Summary description for Measurements.
	/// </summary>
	public class Measurements : Common
	{
        public static void LoadMeasurementsValues(ref ArrayList measurmentsArray, ref DataSet ds)
        {

            /* Tables[0] is Providing Organization  */
            /* Tables[1] is Projects */
            /* Tables[2] is Stations  */
            /* Tables[3] is well detail*/
            /* Tables[4] is Location Descriptors */
            /* Tables[5] is Field Events which includes SampleCollectionMethod (due to one-to-one relationship in schema)*/
            /* Tables[6] is ContactEntity*/
            /* Tables[7] is BinaryLargeObject */
            /* Tables[8] is Results */
            /* Tables[9] is Detection Levels */

            //Load relationships
            LoadRelationships(ref ds, PNWWQDXIdentity.Measurements);


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
                PNWWQXMeasurementsList measurementsListItem = new PNWWQXMeasurementsList();

                #region Load Providing Organization

                // Instantiate the copy of prov org detail
                measurementsListItem.ProvidingOrganizationDetails = new ProvidingOrganizationDetailsType();

                //ProvidingOrganizationIdentifier
                measurementsListItem.ProvidingOrganizationDetails.ProvidingOrganizationIdentifier = Utility.toStr(drProvidingOrg["ProvidingOrganizationIdentifier"]);
			
                //ProvidingOrganization
                measurementsListItem.ProvidingOrganizationDetails.ProvidingOrganizationName = Utility.toStr(drProvidingOrg["ProvidingOrganizationName"]);

                //ProvidingOrganizationType
                measurementsListItem.ProvidingOrganizationDetails.ProvidingOrganizationType = Utility.toStr(drProvidingOrg["ProvidingOrganizationType"]);
			
                //ProvidingOrganizationContact
                measurementsListItem.ProvidingOrganizationDetails.ProvidingOrganizationContactName = Utility.toStr(drProvidingOrg["ProvidingOrganizationContactName"]);

                //ProvidingOrganizationMailingAddressType
				if(
					drProvidingOrg["MailingAddress"] != DBNull.Value ||
					drProvidingOrg["MailingAddressCityName"] != DBNull.Value ||
					drProvidingOrg["MailingAddressStateName"] != DBNull.Value ||
					drProvidingOrg["MailingAddressZIPCode"] != DBNull.Value
					)
				{
					measurementsListItem.ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress = new MailingAddressType();
					
					if(drProvidingOrg["MailingAddress"] != DBNull.Value) measurementsListItem.ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddress = Utility.toStr(drProvidingOrg["MailingAddress"]);
					if(drProvidingOrg["MailingAddressCityName"] != DBNull.Value) measurementsListItem.ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddressCityName = Utility.toStr(drProvidingOrg["MailingAddressCityName"]);
					if(drProvidingOrg["MailingAddressStateName"] != DBNull.Value) measurementsListItem.ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddressStateName = Utility.toStr(drProvidingOrg["MailingAddressStateName"]);
					if(drProvidingOrg["MailingAddressZIPCode"] != DBNull.Value) measurementsListItem.ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddressZIPCode = Utility.toStr(drProvidingOrg["MailingAddressZIPCode"]);
				}

                //ProvidingOrganizationPhoneEmailType
                measurementsListItem.ProvidingOrganizationDetails.ProvidingOrganizationPhoneEmail = new PhoneEmailType();
                measurementsListItem.ProvidingOrganizationDetails.ProvidingOrganizationPhoneEmail.TelephoneNumber = Utility.toStr(drProvidingOrg["TelephoneNumber"]);
				if(drProvidingOrg["ElectronicMailAddressText"] != DBNull.Value) measurementsListItem.ProvidingOrganizationDetails.ProvidingOrganizationPhoneEmail.ElectronicMailAddressText = Utility.toStr(drProvidingOrg["ElectronicMailAddressText"]);
                
				//ProvidingOrganizationURL
				if(drProvidingOrg["ProvidingOrganizationURL"] != DBNull.Value) measurementsListItem.ProvidingOrganizationDetails.ProvidingOrganizationURL = Utility.toStr(drProvidingOrg["ProvidingOrganizationURL"]);
                #endregion


                #region Load Projects for this Providing Organization

                // Array to hold the individual instances of project detail type
                ArrayList projectList = new ArrayList();

                foreach(DataRow drProject in drProvidingOrg.GetChildRows(ds.Relations["Org_Projects"]))
                {

                    #region Project Details

                    // Create an individual instances of project detail type
                    ProjectDetails_ForMeasurements projectItem = new ProjectDetails_ForMeasurements();

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

                    #region Load Project Binary Large Object

                    //ProjectBinaryLargeObject - Get by relationship and llop througheach row
                    //projectItem.ProjectBinaryLargeObject

                    ArrayList projectBinaryObject = new ArrayList();

                    foreach(DataRow drObject in drProject.GetChildRows(ds.Relations["Project_Binary"]))
                    {
                        BinaryLargeObject objectItem = new BinaryLargeObject();

                        //BinaryObject
						if(drObject["content"] != System.DBNull.Value)
						{
							objectItem.BinaryObject = new NodeDocument();
							objectItem.BinaryObject.name = Utility.toStr(drObject["name"]);
							objectItem.BinaryObject.type = Utility.toStr(drObject["type"]);
							objectItem.BinaryObject.content = (byte[])drObject["content"];
						}

                        if(drObject["BinaryObjectURL"] != DBNull.Value) objectItem.BinaryObjectURL = Utility.toStr(drObject["BinaryObjectURL"]);
                        if(drObject["BinaryObjectSize"] != DBNull.Value) objectItem.BinaryObjectSize = Utility.toInt(drObject["BinaryObjectSize"]).ToString();
                        if(drObject["BinaryObjectTitleText"] != DBNull.Value) objectItem.BinaryObjectTitleText = Utility.toStr(drObject["BinaryObjectTitleText"]);
                        if(drObject["BinaryObjectCreator"] != DBNull.Value) objectItem.BinaryObjectCreator = Utility.toStr(drObject["BinaryObjectCreator"]);
                        if(drObject["BinaryObjectSubject"] != DBNull.Value) objectItem.BinaryObjectSubject = Utility.toStr(drObject["BinaryObjectSubject"]);
                        if(drObject["BinaryObjectDescription"] != DBNull.Value) objectItem.BinaryObjectDescription = Utility.toStr(drObject["BinaryObjectDescription"]);
                        if(drObject["BinaryObjectPublisher"] != DBNull.Value) objectItem.BinaryObjectPublisher = Utility.toStr(drObject["BinaryObjectPublisher"]);
                        if(drObject["BinaryObjectContributor"] != DBNull.Value) objectItem.BinaryObjectContributor = Utility.toStr(drObject["BinaryObjectContributor"]);
                        if(drObject["BinaryObjectDate"] != DBNull.Value) objectItem.BinaryObjectDate = Utility.toDT(drObject["BinaryObjectDate"]);
                        if(drObject["BinaryObjectType"] != DBNull.Value) objectItem.BinaryObjectType = Utility.toStr(drObject["BinaryObjectType"]);
                        if(drObject["BinaryObjectContentTypeText"] != DBNull.Value) objectItem.BinaryObjectContentTypeText = Utility.toStr(drObject["BinaryObjectContentTypeText"]);
                        if(drObject["BinaryObjectIdentifierText"] != DBNull.Value) objectItem.BinaryObjectIdentifierText = Utility.toStr(drObject["BinaryObjectIdentifierText"]);
                        if(drObject["BinaryObjectSource"] != DBNull.Value) objectItem.BinaryObjectSource = Utility.toStr(drObject["BinaryObjectSource"]);
                        if(drObject["BinaryObjectLanguage"] != DBNull.Value) objectItem.BinaryObjectLanguage = Utility.toStr(drObject["BinaryObjectLanguage"]);
                        if(drObject["BinaryObjectRelation"] != DBNull.Value) objectItem.BinaryObjectRelation = Utility.toStr(drObject["BinaryObjectRelation"]);
                        if(drObject["BinaryObjectCoverage"] != DBNull.Value) objectItem.BinaryObjectCoverage = Utility.toStr(drObject["BinaryObjectCoverage"]);
                        if(drObject["BinaryObjectRights"] != DBNull.Value) objectItem.BinaryObjectRights = Utility.toStr(drObject["BinaryObjectRights"]);

                        projectBinaryObject.Add(objectItem);
                    }

                    projectItem.ProjectBinaryLargeObject = (BinaryLargeObject[])projectBinaryObject.ToArray(typeof(BinaryLargeObject));


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
                measurementsListItem.ProjectDetails = (ProjectDetails_ForMeasurements[])projectList.ToArray(typeof(ProjectDetails_ForMeasurements));

                #endregion


                #region Load Stations for this Providing Organization

                // Array to hold the individual instances of project detail type
                ArrayList stationList = new ArrayList();

                foreach(DataRow drStation in drProvidingOrg.GetChildRows(ds.Relations["Org_Station"]))
                {

                    #region Staion Details

                    // Create an individual instances of station detail type
                    StationDetails_ForMeasurements stationItem = new StationDetails_ForMeasurements();

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
                measurementsListItem.StationDetails = (StationDetails_ForMeasurements[])stationList.ToArray(typeof(StationDetails_ForMeasurements));

                #endregion


                #region Load Field Event for this Providing Organization

                // Array to hold the individual instances of project detail type
                ArrayList fieldEventList = new ArrayList();

                foreach(DataRow drFieldEvent in drProvidingOrg.GetChildRows(ds.Relations["Org_FieldEvent"]))
                {
                    FieldEventDetails fieldevent = new FieldEventDetails();

                    #region FieldEventDetailsType

                    fieldevent.FieldEventDetailsType = new FieldEventDetailsType();

                    fieldevent.FieldEventDetailsType.FieldEventStartDate = Utility.toDT(drFieldEvent["FieldEventStartDate"]);
                    fieldevent.FieldEventDetailsType.FieldEventStartTimeZone = Utility.toStr(drFieldEvent["FieldEventStartTimeZone"]);
                    fieldevent.FieldEventDetailsType.FieldEventEndDate = Utility.toDT(drFieldEvent["FieldEventEndDate"]);
                    fieldevent.FieldEventDetailsType.FieldEventEndTimeZone = Utility.toStr(drFieldEvent["FieldEventEndTimeZone"]);
                    fieldevent.FieldEventDetailsType.FieldEventTypeText = Utility.toStr(drFieldEvent["FieldEventTypeText"]);
                    if(drFieldEvent["SampleIdentificationText"] != DBNull.Value) fieldevent.FieldEventDetailsType.SampleIdentificationText = Utility.toStr(drFieldEvent["SampleIdentificationText"]);

					if(drFieldEvent["FieldEventUpperDepthMeasure"] != DBNull.Value) fieldevent.FieldEventDetailsType.FieldEventUpperDepthMeasure = Utility.toDecimal(drFieldEvent["FieldEventUpperDepthMeasure"]);
                    if(drFieldEvent["FieldEventLowerDepthMeasure"] != DBNull.Value) fieldevent.FieldEventDetailsType.FieldEventLowerDepthMeasure = Utility.toDecimal(drFieldEvent["FieldEventLowerDepthMeasure"]);
                    if(drFieldEvent["FieldEventDepthUnitMeasureName"] != DBNull.Value) fieldevent.FieldEventDetailsType.FieldEventDepthUnitMeasureName = Utility.toStr(drFieldEvent["FieldEventDepthUnitMeasureName"]);
                    if(drFieldEvent["FieldEventDepthComment"] != DBNull.Value) fieldevent.FieldEventDetailsType.FieldEventDepthComment = Utility.toStr(drFieldEvent["FieldEventDepthComment"]);
                    if(drFieldEvent["FieldEventNotes"] != DBNull.Value) fieldevent.FieldEventDetailsType.FieldEventNotes = Utility.toStr(drFieldEvent["FieldEventNotes"]);
                    
					fieldevent.FieldEventDetailsType.MediaText = Utility.toStr(drFieldEvent["MediaText"]);

                    //taxon
                    if (drFieldEvent["BiologicalSystematicContextName"] != DBNull.Value)
                    {
                        fieldevent.FieldEventDetailsType.Taxon = new TaxonType();
                        if(drFieldEvent["BiologicalSystematicIdentifier"] != DBNull.Value) fieldevent.FieldEventDetailsType.Taxon.BiologicalSystematicIdentifier = Utility.toStr(drFieldEvent["BiologicalSystematicIdentifier"]);
                        if(drFieldEvent["BiologicalSystematicName"] != DBNull.Value) fieldevent.FieldEventDetailsType.Taxon.BiologicalSystematicName = Utility.toStr(drFieldEvent["BiologicalSystematicName"]);
                        fieldevent.FieldEventDetailsType.Taxon.BiologicalSystematicContextName = Utility.toStr(drFieldEvent["BiologicalSystematicContextName"]);
                    }

                    //SampleCollectionMethod
                    //DataRow[] collMethods = drFieldEvent.GetChildRows(ds.Relations["FieldEvent_SampleColMethod"]);
                    //if ((collMethods != null) && (collMethods.Length > 0))
                    //{
                    //    DataRow collMethod = collMethods[0];
                        fieldevent.FieldEventDetailsType.SampleCollectionMethod = new MethodType();
                        if(drFieldEvent["MethodCode"] != DBNull.Value) fieldevent.FieldEventDetailsType.SampleCollectionMethod.MethodCode = Utility.toStr(drFieldEvent["MethodCode"]);
                        if(drFieldEvent["MethodContext"] != DBNull.Value) fieldevent.FieldEventDetailsType.SampleCollectionMethod.MethodContext = Utility.toStr(drFieldEvent["MethodContext"]);
                        if(drFieldEvent["MethodDescription"] != DBNull.Value) fieldevent.FieldEventDetailsType.SampleCollectionMethod.MethodDescription = Utility.toStr(drFieldEvent["MethodDescription"]);
                    //}


                    #region SamplePreparationMethod

                    ArrayList samplePrepMethodList = new ArrayList();
                    foreach(DataRow drSamplePrepMethod in drFieldEvent.GetChildRows(ds.Relations["FieldEvent_SamplePrepMethod"]))
                    {
                        MethodType samplePrepMethod = new MethodType();
                        if(drSamplePrepMethod["MethodCode"] != DBNull.Value) samplePrepMethod.MethodCode = Utility.toStr(drSamplePrepMethod["MethodCode"]);
                        if(drSamplePrepMethod["MethodContext"] != DBNull.Value) samplePrepMethod.MethodContext = Utility.toStr(drSamplePrepMethod["MethodContext"]);
                        if(drSamplePrepMethod["MethodDescription"] != DBNull.Value) samplePrepMethod.MethodDescription = Utility.toStr(drSamplePrepMethod["MethodDescription"]);

                        samplePrepMethodList.Add(samplePrepMethod);
                    }

                    fieldevent.FieldEventDetailsType.SamplePreparationMethod = (MethodType[])samplePrepMethodList.ToArray(typeof(MethodType));
                    
                    #endregion

                    #region SamplePreservationMethod

                    ArrayList samplePreservMethodList = new ArrayList();

                    foreach(DataRow drSamplePreservMethod in drFieldEvent.GetChildRows(ds.Relations["FieldEvent_SamplePresMethod"]))
                    {
                        MethodType samplePreservMethod = new MethodType();

                        if(drSamplePreservMethod["MethodCode"] != DBNull.Value) samplePreservMethod.MethodCode = Utility.toStr(drSamplePreservMethod["MethodCode"]);
                        if(drSamplePreservMethod["MethodContext"] != DBNull.Value) samplePreservMethod.MethodContext = Utility.toStr(drSamplePreservMethod["MethodContext"]);
                        if(drSamplePreservMethod["MethodDescription"] != DBNull.Value) samplePreservMethod.MethodDescription = Utility.toStr(drSamplePreservMethod["MethodDescription"]);

                        samplePreservMethodList.Add(samplePreservMethod);
                    }

                    fieldevent.FieldEventDetailsType.SamplePreservationMethod = (MethodType[])samplePreservMethodList.ToArray(typeof(MethodType));;
                    
                    #endregion


                    #endregion

                    //Singles
                    fieldevent.FieldEventProjectIdentifier = Utility.toStr(drFieldEvent["FieldEventProjectIdentifier"]);
                    fieldevent.FieldEventStationIdentifier = Utility.toStr(drFieldEvent["FieldEventStationIdentifier"]);

                    #region Load Field Event Contacts

                    //FieldEventContact - Get by relationship and llop througheach row

                    ArrayList fieldeventContactList = new ArrayList();

                    foreach(DataRow drContactFieldEvent in drFieldEvent.GetChildRows(ds.Relations["FieldEvent_Contact"]))
                    {
                        fieldeventContactList.Add(Utility.toStr(drContactFieldEvent["ContactEntityIdentifier"]));
                    }

                    fieldevent.FieldEventContactIdentifier = (string[])fieldeventContactList.ToArray(typeof(string));


                    #endregion


                    #region Load FieldEvent Binary Large Object

                    //FieldEventBinaryLargeObject - Get by relationship and llop througheach row

                    ArrayList fieldeventBinaryObject = new ArrayList();

                    foreach(DataRow drObjectFieldEvent in drFieldEvent.GetChildRows(ds.Relations["FieldEvent_Binary"]))
                    {
                        BinaryLargeObject objectItem = new BinaryLargeObject();

                        //BinaryObject
						if(drObjectFieldEvent["content"] != System.DBNull.Value)
						{
							objectItem.BinaryObject = new NodeDocument();
							objectItem.BinaryObject.name = Utility.toStr(drObjectFieldEvent["name"]);
							objectItem.BinaryObject.type = Utility.toStr(drObjectFieldEvent["type"]);
							objectItem.BinaryObject.content = (byte[])drObjectFieldEvent["content"];
						}

                        if(drObjectFieldEvent["BinaryObjectURL"] != DBNull.Value) objectItem.BinaryObjectURL = Utility.toStr(drObjectFieldEvent["BinaryObjectURL"]);
                        if(drObjectFieldEvent["BinaryObjectSize"] != DBNull.Value) objectItem.BinaryObjectSize = Utility.toInt(drObjectFieldEvent["BinaryObjectSize"]).ToString();
                        if(drObjectFieldEvent["BinaryObjectTitleText"] != DBNull.Value) objectItem.BinaryObjectTitleText = Utility.toStr(drObjectFieldEvent["BinaryObjectTitleText"]);
                        if(drObjectFieldEvent["BinaryObjectCreator"] != DBNull.Value) objectItem.BinaryObjectCreator = Utility.toStr(drObjectFieldEvent["BinaryObjectCreator"]);
                        if(drObjectFieldEvent["BinaryObjectSubject"] != DBNull.Value) objectItem.BinaryObjectSubject = Utility.toStr(drObjectFieldEvent["BinaryObjectSubject"]);
                        if(drObjectFieldEvent["BinaryObjectDescription"] != DBNull.Value) objectItem.BinaryObjectDescription = Utility.toStr(drObjectFieldEvent["BinaryObjectDescription"]);
                        if(drObjectFieldEvent["BinaryObjectPublisher"] != DBNull.Value) objectItem.BinaryObjectPublisher = Utility.toStr(drObjectFieldEvent["BinaryObjectPublisher"]);
                        if(drObjectFieldEvent["BinaryObjectContributor"] != DBNull.Value) objectItem.BinaryObjectContributor = Utility.toStr(drObjectFieldEvent["BinaryObjectContributor"]);
                        if(drObjectFieldEvent["BinaryObjectDate"] != DBNull.Value) objectItem.BinaryObjectDate = Utility.toDT(drObjectFieldEvent["BinaryObjectDate"]);
                        if(drObjectFieldEvent["BinaryObjectType"] != DBNull.Value) objectItem.BinaryObjectType = Utility.toStr(drObjectFieldEvent["BinaryObjectType"]);
                        if(drObjectFieldEvent["BinaryObjectContentTypeText"] != DBNull.Value) objectItem.BinaryObjectContentTypeText = Utility.toStr(drObjectFieldEvent["BinaryObjectContentTypeText"]);
                        if(drObjectFieldEvent["BinaryObjectIdentifierText"] != DBNull.Value) objectItem.BinaryObjectIdentifierText = Utility.toStr(drObjectFieldEvent["BinaryObjectIdentifierText"]);
                        if(drObjectFieldEvent["BinaryObjectSource"] != DBNull.Value) objectItem.BinaryObjectSource = Utility.toStr(drObjectFieldEvent["BinaryObjectSource"]);
                        if(drObjectFieldEvent["BinaryObjectLanguage"] != DBNull.Value) objectItem.BinaryObjectLanguage = Utility.toStr(drObjectFieldEvent["BinaryObjectLanguage"]);
                        if(drObjectFieldEvent["BinaryObjectRelation"] != DBNull.Value) objectItem.BinaryObjectRelation = Utility.toStr(drObjectFieldEvent["BinaryObjectRelation"]);
                        if(drObjectFieldEvent["BinaryObjectCoverage"] != DBNull.Value) objectItem.BinaryObjectCoverage = Utility.toStr(drObjectFieldEvent["BinaryObjectCoverage"]);
                        if(drObjectFieldEvent["BinaryObjectRights"] != DBNull.Value) objectItem.BinaryObjectRights = Utility.toStr(drObjectFieldEvent["BinaryObjectRights"]);

                        fieldeventBinaryObject.Add(objectItem);
                    }

                    fieldevent.FieldEventLargeObject = (BinaryLargeObject[])fieldeventBinaryObject.ToArray(typeof(BinaryLargeObject));


                    #endregion


                    #region ResultDetails

                    ArrayList resultList = new ArrayList();

                    foreach(DataRow drResult in drFieldEvent.GetChildRows(ds.Relations["FieldEvent_Result"]))
                    {

                        ResultDetails result = new ResultDetails();
                       
                        #region ResultDetailsType

                        result.ResultDetailsType = new ResultDetailsType();

                        //ResultDetailsType
                        result.ResultDetailsType.ResultValueMeasure = Utility.toStr(drResult["ResultValueMeasure"]);
                        if(drResult["ResultValueSignificantDigitsNumber"] != DBNull.Value) result.ResultDetailsType.ResultValueSignificantDigitsNumber = Utility.toInt(drResult["ResultValueSignificantDigitsNumber"]); //numeric
                        result.ResultDetailsType.ResultUnitMeasureName = Utility.toStr(drResult["ResultUnitMeasureName"]);
                        if(drResult["ResultQualifier"] != DBNull.Value) result.ResultDetailsType.ResultQualifier = Utility.toStr(drResult["ResultQualifier"]);
                        
						result.ResultDetailsType.ResultQualityAssessment = Utility.toStr(drResult["ResultQualityAssessment"]);
                        result.ResultDetailsType.ResultStatus = Utility.toStr(drResult["ResultStatus"]);
                        result.ResultDetailsType.ResultAvailabilityDescription = Utility.toStr(drResult["ResultAvailabilityDescription"]);
                        
						result.ResultDetailsType.QAQCExceptionIndicator = Utility.toBool(drResult["QAQCExceptionIndicator"]);
                        if(drResult["QAQCExceptionCommentText"] != DBNull.Value) result.ResultDetailsType.QAQCExceptionCommentText = Utility.toStr(drResult["QAQCExceptionCommentText"]);

                        //ResultTaxon
						if(drResult["BiologicalSystematicContextName"] != DBNull.Value)
						{
							result.ResultDetailsType.ResultTaxon = new TaxonType();
							if(drResult["BiologicalSystematicIdentifier"] != DBNull.Value) result.ResultDetailsType.ResultTaxon.BiologicalSystematicIdentifier = Utility.toStr(drResult["BiologicalSystematicIdentifier"]);
							if(drResult["BiologicalSystematicName"] != DBNull.Value) result.ResultDetailsType.ResultTaxon.BiologicalSystematicName = Utility.toStr(drResult["BiologicalSystematicName"]);
							result.ResultDetailsType.ResultTaxon.BiologicalSystematicContextName = Utility.toStr(drResult["BiologicalSystematicContextName"]);
						}

                        //ResultAnalyte
                        result.ResultDetailsType.ResultAnalyte = new AnalyteType();
                        if(drResult["AnalyteIdentifier"] != DBNull.Value) result.ResultDetailsType.ResultAnalyte.AnalyteIdentifier = Utility.toStr(drResult["AnalyteIdentifier"]);
                        result.ResultDetailsType.ResultAnalyte.AnalyteName = Utility.toStr(drResult["AnalyteName"]);
                        result.ResultDetailsType.ResultAnalyte.AnalyteContextName = Utility.toStr(drResult["AnalyteContextName"]);

                        //ResultAnalyticalMethod
                        result.ResultDetailsType.ResultAnalyticalMethod = new MethodType();
                        if(drResult["MethodCode"] != DBNull.Value) result.ResultDetailsType.ResultAnalyticalMethod.MethodCode = Utility.toStr(drResult["MethodCode"]);
                        if(drResult["MethodContext"] != DBNull.Value) result.ResultDetailsType.ResultAnalyticalMethod.MethodContext = Utility.toStr(drResult["MethodContext"]);
                        if(drResult["MethodDescription"] != DBNull.Value) result.ResultDetailsType.ResultAnalyticalMethod.MethodDescription = Utility.toStr(drResult["MethodDescription"]);


                        #region ResultDetectionLevels

                        ArrayList resultDetectionLevList = new ArrayList();

                        foreach(DataRow drDetectionLev in drResult.GetChildRows(ds.Relations["Result_DetectionLevel"]))
                        {
                            DetectionQuantitationLevelType detect = new DetectionQuantitationLevelType();
                            detect.DetectionQuantitationLevelMeasure = Utility.toInt(drDetectionLev["DetectionQuantitationLevelMeasure"]);
                            detect.DetectionQuantitationLevelTypeText = Utility.toStr(drDetectionLev["DetectionQuantitationLevelTypeText"]);
                            detect.DetectionQuantitationLevelUnitMeasureName = Utility.toStr(drDetectionLev["DetectionQuantitationLevelUnitMeasureName"]);
                            
                            resultDetectionLevList.Add(detect);
                        }
                        result.ResultDetailsType.ResultDetectionLevels = (DetectionQuantitationLevelType[])resultDetectionLevList.ToArray(typeof(DetectionQuantitationLevelType));


                        #endregion

                        #endregion


                        #region Load Result Contacts

                        //ResultContactIdentifier - Get by relationship and llop througheach row
                        if(drResult["ContactEntityIdentifier"] != DBNull.Value) result.ResultContactIdentifier = Utility.toStr(drResult["ContactEntityIdentifier"]);

                        #endregion


                        //Add result to collection
                        resultList.Add(result);
                    }

                    // Cast the copy of fieldevent result detail array to the root type
                    fieldevent.ResultDetails = (ResultDetails[])resultList.ToArray(typeof(ResultDetails));

                    #endregion


                    fieldEventList.Add(fieldevent);
                }

                
                // Cast the copy of project detail array to the root type
                measurementsListItem.FieldEventDetails = (FieldEventDetails[])fieldEventList.ToArray(typeof(FieldEventDetails));

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
                measurementsListItem.ContactEntityDetails = (ContactEntityDetails[])contactList.ToArray(typeof(ContactEntityDetails));


                #endregion



                // Add the copy of Instantiated array element to the return array
                measurmentsArray.Add(measurementsListItem);

            }       
        }
	}
}
