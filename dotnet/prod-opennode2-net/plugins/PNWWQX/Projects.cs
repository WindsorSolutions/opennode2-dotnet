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
    /// Summary description for Project.
    /// </summary>
    public class Project : Common
    {
        public static void loadProjectValues(ref ArrayList projectArray, ref DataSet ds)
        {

            /* Tables[0] is Providing Organization  */
            /* Tables[1] is Projects */
            /* Tables[2] is ContactEntity*/

            //Load relationships
            LoadRelationships(ref ds, PNWWQDXIdentity.Project);


            // ********************************************************
            // Populate data plan
            // ********************************************************
            // ForEach ProvidingOrganization 
            //      Load ProvidingOrganization
            //      Get Projects for this ProvidingOrganization
            //      ForEach Project in Projects
            //          Load Project
            //          Get Project Contacts for this Project
            //          ForEach Contact in Project Contacts
            //              Load Contact
            //          End ForEach Contact in Project Contacts
            //      End ForEach Project in Projects
            // End ForEach ProvidingOrganization


            // ForEach ProvidingOrganization 
            foreach (DataRow drProvidingOrg in ds.Tables[0].Rows)
            {

                // Instantiate a copy of the array element
                PNWWQXProjectsList projectListItem = new PNWWQXProjectsList();

                #region Load Providing Organization

                // Instantiate the copy of prov org detail
                projectListItem.ProvidingOrganizationDetails = new ProvidingOrganizationDetailsType();

                //ProvidingOrganizationIdentifier
                projectListItem.ProvidingOrganizationDetails.ProvidingOrganizationIdentifier = Utility.toStr(drProvidingOrg["ProvidingOrganizationIdentifier"]);

                //ProvidingOrganization
                projectListItem.ProvidingOrganizationDetails.ProvidingOrganizationName = Utility.toStr(drProvidingOrg["ProvidingOrganizationName"]);

                //ProvidingOrganizationType
                projectListItem.ProvidingOrganizationDetails.ProvidingOrganizationType = Utility.toStr(drProvidingOrg["ProvidingOrganizationType"]);

                //ProvidingOrganizationContact
                projectListItem.ProvidingOrganizationDetails.ProvidingOrganizationContactName = Utility.toStr(drProvidingOrg["ProvidingOrganizationContactName"]);

                //ProvidingOrganizationMailingAddressType
                if (drProvidingOrg["MailingAddress"] != DBNull.Value ||
                    drProvidingOrg["MailingAddressCityName"] != DBNull.Value ||
                    drProvidingOrg["MailingAddressStateName"] != DBNull.Value ||
                    drProvidingOrg["MailingAddressZIPCode"] != DBNull.Value
                    )
                {
                    projectListItem.ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress = new MailingAddressType();
                    if (drProvidingOrg["MailingAddress"] != DBNull.Value)
                        projectListItem.ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddress = Utility.toStr(drProvidingOrg["MailingAddress"]);
                    if (drProvidingOrg["MailingAddressCityName"] != DBNull.Value)
                        projectListItem.ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddressCityName = Utility.toStr(drProvidingOrg["MailingAddressCityName"]);
                    if (drProvidingOrg["MailingAddressStateName"] != DBNull.Value)
                        projectListItem.ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddressStateName = Utility.toStr(drProvidingOrg["MailingAddressStateName"]);
                    if (drProvidingOrg["MailingAddressZIPCode"] != DBNull.Value)
                        projectListItem.ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddressZIPCode = Utility.toStr(drProvidingOrg["MailingAddressZIPCode"]);
                }

                //ProvidingOrganizationPhoneEmailType
                projectListItem.ProvidingOrganizationDetails.ProvidingOrganizationPhoneEmail = new PhoneEmailType();
                projectListItem.ProvidingOrganizationDetails.ProvidingOrganizationPhoneEmail.TelephoneNumber = Utility.toStr(drProvidingOrg["TelephoneNumber"]);
                if (drProvidingOrg["ElectronicMailAddressText"] != DBNull.Value)
                    projectListItem.ProvidingOrganizationDetails.ProvidingOrganizationPhoneEmail.ElectronicMailAddressText = Utility.toStr(drProvidingOrg["ElectronicMailAddressText"]);

                //ProvidingOrganizationURL
                if (drProvidingOrg["ProvidingOrganizationURL"] != DBNull.Value)
                    projectListItem.ProvidingOrganizationDetails.ProvidingOrganizationURL = Utility.toStr(drProvidingOrg["ProvidingOrganizationURL"]);

                #endregion

                #region Load Projects for this Providing Organization

                // Array to hold the individual instances of project detail type
                ArrayList projectList = new ArrayList();

                foreach (DataRow drProject in drProvidingOrg.GetChildRows(ds.Relations["Org_Projects"]))
                {

                    #region Project Details

                    // Create an individual instances of project detail type
                    ProjectDetails_ForProjects projectItem = new ProjectDetails_ForProjects();

                    //ProjectDetailsType
                    projectItem.ProjectDetailsType = new ProjectDetailsType();
                    projectItem.ProjectDetailsType.ProjectIdentifier = Utility.toStr(drProject["ProjectIdentifier"]);
                    projectItem.ProjectDetailsType.ProjectName = Utility.toStr(drProject["ProjectName"]);
                    projectItem.ProjectDetailsType.ProjectDescription = Utility.toStr(drProject["ProjectDescription"]);
                    if (drProject["ProjectStartDate"] != DBNull.Value)
                        projectItem.ProjectDetailsType.ProjectStartDate = Utility.toDT(drProject["ProjectStartDate"]);
                    if (drProject["ProjectEndDate"] != DBNull.Value)
                        projectItem.ProjectDetailsType.ProjectEndDate = Utility.toDT(drProject["ProjectEndDate"]);
                    if (drProject["ProjectAreaDescription"] != DBNull.Value)
                        projectItem.ProjectDetailsType.ProjectAreaDescription = Utility.toStr(drProject["ProjectAreaDescription"]);
                    projectItem.ProjectDetailsType.ProjectQAPPIndicator = Utility.toBool(drProject["ProjectQAPPIndicator"]);
                    if (drProject["ProjectQAPPDescription"] != DBNull.Value)
                        projectItem.ProjectDetailsType.ProjectQAPPDescription = Utility.toStr(drProject["ProjectQAPPDescription"]);


                    #endregion

                    #region Load Project Binary Large Object

                    //ProjectBinaryLargeObject - Get by relationship and llop througheach row
                    //projectItem.ProjectBinaryLargeObject

                    ArrayList projectBinaryObject = new ArrayList();

                    foreach (DataRow drObject in drProject.GetChildRows(ds.Relations["Project_Binary"]))
                    {
                        BinaryLargeObject objectItem = new BinaryLargeObject();

                        //BinaryObject
                        if (drObject["content"] != System.DBNull.Value)
                        {
                            objectItem.BinaryObject = new NodeDocument();
                            objectItem.BinaryObject.name = Utility.toStr(drObject["name"]);
                            objectItem.BinaryObject.type = Utility.toStr(drObject["type"]);
                            objectItem.BinaryObject.content = (byte[])drObject["content"];
                        }

                        if (drObject["BinaryObjectURL"] != DBNull.Value)
                            objectItem.BinaryObjectURL = Utility.toStr(drObject["BinaryObjectURL"]);
                        if (drObject["BinaryObjectSize"] != DBNull.Value)
                            objectItem.BinaryObjectSize = Utility.toInt(drObject["BinaryObjectSize"]).ToString();
                        if (drObject["BinaryObjectTitleText"] != DBNull.Value)
                            objectItem.BinaryObjectTitleText = Utility.toStr(drObject["BinaryObjectTitleText"]);
                        if (drObject["BinaryObjectCreator"] != DBNull.Value)
                            objectItem.BinaryObjectCreator = Utility.toStr(drObject["BinaryObjectCreator"]);
                        if (drObject["BinaryObjectSubject"] != DBNull.Value)
                            objectItem.BinaryObjectSubject = Utility.toStr(drObject["BinaryObjectSubject"]);
                        if (drObject["BinaryObjectDescription"] != DBNull.Value)
                            objectItem.BinaryObjectDescription = Utility.toStr(drObject["BinaryObjectDescription"]);
                        if (drObject["BinaryObjectPublisher"] != DBNull.Value)
                            objectItem.BinaryObjectPublisher = Utility.toStr(drObject["BinaryObjectPublisher"]);
                        if (drObject["BinaryObjectContributor"] != DBNull.Value)
                            objectItem.BinaryObjectContributor = Utility.toStr(drObject["BinaryObjectContributor"]);
                        if (drObject["BinaryObjectDate"] != DBNull.Value)
                            objectItem.BinaryObjectDate = Utility.toDT(drObject["BinaryObjectDate"]);
                        if (drObject["BinaryObjectType"] != DBNull.Value)
                            objectItem.BinaryObjectType = Utility.toStr(drObject["BinaryObjectType"]);
                        if (drObject["BinaryObjectContentTypeText"] != DBNull.Value)
                            objectItem.BinaryObjectContentTypeText = Utility.toStr(drObject["BinaryObjectContentTypeText"]);
                        if (drObject["BinaryObjectIdentifierText"] != DBNull.Value)
                            objectItem.BinaryObjectIdentifierText = Utility.toStr(drObject["BinaryObjectIdentifierText"]);
                        if (drObject["BinaryObjectSource"] != DBNull.Value)
                            objectItem.BinaryObjectSource = Utility.toStr(drObject["BinaryObjectSource"]);
                        if (drObject["BinaryObjectLanguage"] != DBNull.Value)
                            objectItem.BinaryObjectLanguage = Utility.toStr(drObject["BinaryObjectLanguage"]);
                        if (drObject["BinaryObjectRelation"] != DBNull.Value)
                            objectItem.BinaryObjectRelation = Utility.toStr(drObject["BinaryObjectRelation"]);
                        if (drObject["BinaryObjectCoverage"] != DBNull.Value)
                            objectItem.BinaryObjectCoverage = Utility.toStr(drObject["BinaryObjectCoverage"]);
                        if (drObject["BinaryObjectRights"] != DBNull.Value)
                            objectItem.BinaryObjectRights = Utility.toStr(drObject["BinaryObjectRights"]);

                        projectBinaryObject.Add(objectItem);
                    }

                    projectItem.ProjectBinaryLargeObject = (BinaryLargeObject[])projectBinaryObject.ToArray(typeof(BinaryLargeObject));


                    #endregion

                    #region Load Project Contacts

                    //ProjectContact - Get by relationship and llop througheach row
                    //                 If contact identifier = project contact, prim = true

                    ArrayList projectContactList = new ArrayList();
                    Hashtable loadedProjectContacts = new Hashtable();

                    foreach (DataRow drContact in drProject.GetChildRows(ds.Relations["Project_Contact"]))
                    {
                        if (!loadedProjectContacts.ContainsKey(Utility.toStr(drContact["ContactEntityIdentifier"])))
                        {
                            ProjectContactType contactItem = new ProjectContactType();

                            contactItem.ProjectContactIdentifier = Utility.toStr(drContact["ContactEntityIdentifier"]);
                            string projectContactIdentifier = Utility.toStr(drProject["ProjectContactIdentifier"]);
                            contactItem.PrimaryDataSourceIndicator = !string.IsNullOrEmpty(contactItem.ProjectContactIdentifier) &&
                                string.Equals(contactItem.ProjectContactIdentifier, projectContactIdentifier);

                            projectContactList.Add(contactItem);
                            loadedProjectContacts.Add(Utility.toStr(drContact["ContactEntityIdentifier"]), drContact["ContactEntityIdentifier"]);
                        }
                    }

                    projectItem.ProjectContact = (ProjectContactType[])projectContactList.ToArray(typeof(ProjectContactType));


                    #endregion

                    #region Analyte
                    ArrayList alAnalyteType = new ArrayList();
                    foreach (DataRow drProject_Analyte in drProject.GetChildRows(ds.Relations["Project_Analyte"]))
                    {
                        AnalyteType analyteItem = new AnalyteType();
                        if (drProject_Analyte["AnalyteIdentifier"] != DBNull.Value)
                            analyteItem.AnalyteIdentifier = Utility.toStr(drProject_Analyte["AnalyteIdentifier"]);
                        analyteItem.AnalyteName = Utility.toStr(drProject_Analyte["AnalyteName"]);
                        analyteItem.AnalyteContextName = Utility.toStr(drProject_Analyte["AnalyteContextName"]);
                        alAnalyteType.Add(analyteItem);
                    }
                    projectItem.Analyte = (AnalyteType[])alAnalyteType.ToArray(typeof(AnalyteType));
                    #endregion

                    // Add individual instances of project detail type to the project detail array
                    projectList.Add(projectItem);

                }

                // Cast the copy of project detail array to the root type
                projectListItem.ProjectDetails = (ProjectDetails_ForProjects[])projectList.ToArray(typeof(ProjectDetails_ForProjects));

                #endregion

                #region Load Contact for this Providing Organization

                //Contact - Get by relationship and llop througheach row

                ArrayList contactList = new ArrayList();
                Hashtable loadedContacts = new Hashtable();

                foreach (DataRow drContactRoot in drProvidingOrg.GetChildRows(ds.Relations["Org_Contact"]))
                {
                    if (!loadedContacts.ContainsKey(Utility.toStr(drContactRoot["ContactEntityIdentifier"])))
                    {
                        ContactEntityDetails contactItem = new ContactEntityDetails();

                        contactItem.ContactEntityIdentifier = Utility.toStr(drContactRoot["ContactEntityIdentifier"]);

                        //ContactOrganization
                        if (drContactRoot["ContactOrganizationName"] != DBNull.Value)
                            contactItem.ContactOrganizationName = Utility.toStr(drContactRoot["ContactOrganizationName"]);

                        //ContactEntityType
                        contactItem.ContactEntityType = Utility.toStr(drContactRoot["ContactEntityType"]);

                        //Contact
                        contactItem.ContactIndividualName = Utility.toStr(drContactRoot["ContactIndividualName"]);

                        //ContactMailingAddress
                        if (drContactRoot["MailingAddress"] != DBNull.Value ||
                            drContactRoot["MailingAddressCityName"] != DBNull.Value ||
                            drContactRoot["MailingAddressStateName"] != DBNull.Value ||
                            drContactRoot["MailingAddressZIPCode"] != DBNull.Value)
                        {
                            contactItem.ContactMailingAddress = new MailingAddressType();
                            if (drContactRoot["MailingAddress"] != DBNull.Value)
                                contactItem.ContactMailingAddress.MailingAddress = Utility.toStr(drContactRoot["MailingAddress"]);
                            if (drContactRoot["MailingAddressCityName"] != DBNull.Value)
                                contactItem.ContactMailingAddress.MailingAddressCityName = Utility.toStr(drContactRoot["MailingAddressCityName"]);
                            if (drContactRoot["MailingAddressStateName"] != DBNull.Value)
                                contactItem.ContactMailingAddress.MailingAddressStateName = Utility.toStr(drContactRoot["MailingAddressStateName"]);
                            if (drContactRoot["MailingAddressZIPCode"] != DBNull.Value)
                                contactItem.ContactMailingAddress.MailingAddressZIPCode = Utility.toStr(drContactRoot["MailingAddressZIPCode"]);
                        }

                        //ContactPhoneEmail
                        contactItem.ContactPhoneEmail = new PhoneEmailType();
                        if (drContactRoot["ElectronicMailAddressText"] != DBNull.Value)
                            contactItem.ContactPhoneEmail.ElectronicMailAddressText = Utility.toStr(drContactRoot["ElectronicMailAddressText"]);
                        contactItem.ContactPhoneEmail.TelephoneNumber = Utility.toStr(drContactRoot["TelephoneNumber"]);

                        //Add to list
                        contactList.Add(contactItem);
                        loadedContacts.Add(Utility.toStr(drContactRoot["ContactEntityIdentifier"]), drContactRoot["ContactEntityIdentifier"]);
                    }
                }

                //Cast back to the collection
                projectListItem.ContactEntityDetails = (ContactEntityDetails[])contactList.ToArray(typeof(ContactEntityDetails));


                #endregion



                // Add the copy of Instantiated array element to the return array
                projectArray.Add(projectListItem);

            }
        }
    }
}