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
using System.Reflection;
using Spring.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.FRS23
{

    public enum FRSDataProviderParameterType
    {
        SourceProvider
    }

    [Serializable]
    public class QueryProcessor : BaseWNOSPlugin, ISolicitProcessor, IQueryProcessor
    {
        protected const string CONFIG_ADD_HEADER = "Add Header";
        protected const string CONFIG_AUTHOR = "Author";
        protected const string CONFIG_ORGANIZATION = "Organization";
        protected const string CONFIG_CONTACT_INFO = "Contact Info";
        protected const string CONFIG_NOTIFICATIONS = "Notifications";
        protected const string CONFIG_PAYLOAD_OPERATION = "Payload Operation";
        protected const string CONFIG_TITLE = "Title";

        #region fields
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private IRequestManager _requestManager;
        private ISerializationHelper _serializationHelper;
        private ICompressionHelper _compressionHelper;
        private IDocumentManager _documentManager;
        private IHeaderDocumentHelper _headerDocumentHelper;
        private ISettingsProvider _settingsProvider;


        private bool _addHeader;
        private string _author;
        private string _organization;
        private string _contactInfo;
        private string _notifications;
        private string _payloadOperation;
        private string _title;

        #endregion


        /// <summary>
        /// Responsible for processing all FRS services
        /// </summary>
        public QueryProcessor()
        {
            ConfigurationArguments.Add(CONFIG_ADD_HEADER, null);
            ConfigurationArguments.Add(CONFIG_AUTHOR, null);
            ConfigurationArguments.Add(CONFIG_ORGANIZATION, null);
            ConfigurationArguments.Add(CONFIG_CONTACT_INFO, null);
            ConfigurationArguments.Add(CONFIG_NOTIFICATIONS, null);
            ConfigurationArguments.Add(CONFIG_PAYLOAD_OPERATION, null);
            ConfigurationArguments.Add(CONFIG_TITLE, null);

            //Load Data Sources
            foreach (string arg in Enum.GetNames(typeof(FRSDataProviderParameterType)))
            {
                DataProviders.Add(arg, null);
            }
        }

        protected void LazyInit()
        {
            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _headerDocumentHelper);
            GetServiceImplementation(out _settingsProvider);

            _addHeader = IsOn(CONFIG_ADD_HEADER);
            if (_addHeader)
            {
                _author = ValidateNonEmptyConfigParameter(CONFIG_AUTHOR);
                _organization = ValidateNonEmptyConfigParameter(CONFIG_ORGANIZATION);
                _contactInfo = ValidateNonEmptyConfigParameter(CONFIG_CONTACT_INFO);
                _payloadOperation = ValidateNonEmptyConfigParameter(CONFIG_PAYLOAD_OPERATION);
                _title = ValidateNonEmptyConfigParameter(CONFIG_TITLE);
                TryGetConfigParameter(CONFIG_NOTIFICATIONS, ref _notifications);
            }
        }

        public enum TableRelationships
        {
            Facility_AltName,
            Facility_EnvInt,
            Facility_GeoCoord,
            Facility_MailAdd,
            Facility_NAICS,
            Facility_SIC,
            EnvInt_Indiv,
            EnvInt_Org
        }


        #region Private methods

        /// <summary>
        /// PopulateFacilitySiteList
        /// </summary>
        /// <param name="fsList"></param>
        /// <param name="ds">Dataset</param>
        /// <returns>Collection of FacilitySiteList</returns>
        private FacilitySiteList PopulateDeletedFacilitySiteList(ref string[] deletedIDs)
        {

            FacilitySiteList fsList = new FacilitySiteList();

            //Create an array to hold the individual fs lists in collection
            ArrayList detailArray = new ArrayList();


            //for each data row in the parent table (PK)
            foreach (string id in deletedIDs)
            {
                //Create a new instance of the FacilitySiteAllDetails
                FacilitySiteAllDetails fsDetail = new FacilitySiteAllDetails();

                fsDetail.StateFacilityIdentifier = id;
                fsDetail.StateFacilitySystemAcronymName = "WADOEFSIS";
                fsDetail.LastReportedDateSpecified = false;

                //Add Loaded object (parent) to the collection
                detailArray.Add(fsDetail);
            }


            //Assign the collection of FacilitySiteAllDetails of the parent table
            fsList.FacilitySiteAllDetails = (FacilitySiteAllDetails[])detailArray.ToArray(typeof(FacilitySiteAllDetails));

            //Return loaded collection
            return fsList;

        }


        /// <summary>
        /// PopulateFacilitySiteList
        /// </summary>
        /// <param name="fsList"></param>
        /// <param name="ds">Dataset</param>
        /// <returns>Collection of FacilitySiteList</returns>
        private FacilitySiteList PopulateFacilitySiteList(ref DataSet ds)
        {


            FacilitySiteList fsList = new FacilitySiteList();


            //Order of tables from the SP
            //
            //                0. FRS_FacilitySite
            //                1. FRS_AlternateName
            //                2. FRS_EnvironmentalInterest
            //                3. FRS_GeographicCoordinates
            //                4. FRS_Individual
            //                5. FRS_MailingAddress
            //                6. FRS_NAICSCode
            //                7. FRS_Organization
            //                8. FRS_SICCode




            //The FacilitySiteAllDetails class members
            //
            //         FacilitySiteDataType FacilitySite;
            //         LocationAddressDataType LocationAddress;
            //         EnvironmentalInterest[] EnvironmentalInterestDetails;
            //         IndividualDetails[] IndividualDetails;
            //         OrganizationDetails[] OrganizationDetails;
            //         AltNameDataType AlternativeNameInfo;
            //         MailingAddressDataType MailingAddress;
            //         SICCodeDetails[] SICCodeDetails;
            //         NAICSCodeDetails[] NAICSCodeDetails;
            //         GeographicCoordinateDataType GeographicCoordinates;
            //         string SourceOfData;
            //         System.DateTime LastReportedDate;
            //         string StateFacilitySystemAcronymName;
            //         string StateFacilityIdentifier;

            //for each data row in the parent table (PK)

            if (ds.Tables["Facility"] == null)
            {
                return fsList;
            }
            
            //Create an array to hold the individual fs lists in collection
            ArrayList detailArray = new ArrayList();

            foreach (DataRow dr in ds.Tables["Facility"].Rows)
            {

                //Create a new instance of the FacilitySiteAllDetails
                FacilitySiteAllDetails fsDetail = new FacilitySiteAllDetails();


                #region Facilty Level Properties

                //Primitive properties at the top level
                if (dr["LastReportedDate"] == DBNull.Value)
                {
                    fsDetail.LastReportedDateSpecified = false;
                }
                else
                {
                    fsDetail.LastReportedDateSpecified = true;
                    fsDetail.LastReportedDate = FormatDBNullDateTime(dr["LastReportedDate"]);
                }

                fsDetail.SourceOfData = FormatDBNullString(dr["DataSourceName"]);
                fsDetail.StateFacilityIdentifier = FormatDBNullString(dr["StateFacilityIdentifier"]);
                fsDetail.StateFacilitySystemAcronymName = FormatDBNullString(dr["StateFacilitySystemAcronymName"]);

                #endregion

                #region FacilitySite

                //Create an instance of the complex property
                FacilitySiteDataType fs = new FacilitySiteDataType();

                //LegislativeDistrictNumber
                fs.FacilityRegistryIdentifier = FormatDBNullString(dr["FacilityRegistryIdentifier"]);
                fs.FacilitySiteName = FormatDBNullString(dr["FacilitySiteName"]);
                fs.FacilitySiteTypeName = FormatDBNullString(dr["FacilitySiteTypeName"]);
                if (dr["FederalFacilityIndicator"] == DBNull.Value)
                {
                    fs.FederalFacilityIndicatorSpecified = false;
                }
                else
                {
                    fs.FederalFacilityIndicator = ConvertToYesNoIndicatorDataType(dr["FederalFacilityIndicator"]);
                    fs.FederalFacilityIndicatorSpecified = true;
                }
                if (dr["TribalLandIndicator"] == DBNull.Value)
                {
                    fs.TribalLandIndicatorSpecified = false;
                }
                else
                {
                    fs.TribalLandIndicator = ConvertToYesNoIndicatorDataType(dr["TribalLandIndicator"]);
                    fs.TribalLandIndicatorSpecified = true;
                }
                fs.TribalLandName = FormatDBNullString(dr["TribalLandName"]);
                fs.CongressionalDistrictNumber = FormatDBNullString(dr["CongressionalDistrictNumber"]);
                fs.LegislativeDistrictNumber = FormatDBNullString(dr["LegislativeDistrictNumber"]);
                fs.HUCCode = FormatDBNullString(dr["HUCCode"]);

                fsDetail.FacilitySite = fs;

                #endregion

                #region LocationAddress

                //Create an instance of the complex property
                LocationAddressDataType fsAddress = new LocationAddressDataType();

                fsAddress.LocationAddressText = FormatDBNullString(dr["LocationAddressText"]);
                fsAddress.SupplementalLocationText = FormatDBNullString(dr["SupplementalLocationText"]);
                fsAddress.LocalityName = FormatDBNullString(dr["LocalityName"]);
                fsAddress.CountyStateFIPSCode = FormatDBNullString(dr["CountyStateFIPSCode"]);
                fsAddress.CountyName = FormatDBNullString(dr["CountyName"]);
                fsAddress.StateUSPSCode = FormatDBNullString(dr["StateUSPSCode"]);
                fsAddress.StateName = FormatDBNullString(dr["StateName"]);
                fsAddress.CountryName = FormatDBNullString(dr["CountryName"]);
                fsAddress.LocationZIPCode = FormatDBNullString(dr["LocationZIPCode"]);
                fsAddress.LocationDescriptionText = FormatDBNullString(dr["LocationDescriptionText"]);

                fsDetail.LocationAddress = fsAddress;

                #endregion

                #region EnvironmentalInterest

                ArrayList envArray = new ArrayList();

                foreach (DataRow childRow in dr.GetChildRows(TableRelationships.Facility_EnvInt.ToString()))
                {

                    //Create an instance of the complex property
                    EnvironmentalInterest envDataType = new EnvironmentalInterest();

                    envDataType.InformationSystemAcronymName = FormatDBNullString(childRow["InformationSystemAcronymName"]);
                    envDataType.InformationSystemIdentifier = FormatDBNullString(childRow["InformationSystemIdentifier"]);
                    envDataType.EnvironmentalInterestTypeText = FormatDBNullString(childRow["EnvironmentalInterestTypeText"]);

                    if (childRow["FederalStateInterestIndicator"] == DBNull.Value)
                    {
                        envDataType.FederalStateInterestIndicatorSpecified = false;
                    }
                    else
                    {
                        envDataType.FederalStateInterestIndicator = ConvertToFederalStateIndicatorDataType(childRow["FederalStateInterestIndicator"]);
                        envDataType.FederalStateInterestIndicatorSpecified = true;
                    }


                    //EnvironmentalInterestStartDate
                    if (IsValidDateTime(childRow["EnvironmentalInterestStartDate"], DateTime.Parse("1/1/1900")))
                    {
                        envDataType.EnvironmentalInterestStartDate = FormatDBNullDateTime(childRow["EnvironmentalInterestStartDate"]);
                        envDataType.EnvironmentalInterestStartDateSpecified = true;
                        envDataType.InterestStartDateQualifierText = FormatDBNullString(childRow["InterestStartDateQualifierText"]);



                        //EnvironmentalInterestEndDate
                        //Specify only if the start date is there
                        if (IsValidDateTime(childRow["EnvironmentalInterestEndDate"], envDataType.EnvironmentalInterestStartDate))
                        {
                            envDataType.EnvironmentalInterestEndDate = FormatDBNullDateTime(childRow["EnvironmentalInterestEndDate"]);
                            envDataType.EnvironmentalInterestEndDateSpecified = true;
                            envDataType.InterestEndDateQualifierText = FormatDBNullString(childRow["InterestEndDateQualifierText"]);
                        }
                        else
                        {
                            envDataType.EnvironmentalInterestEndDateSpecified = false;
                        }

                    }
                    else
                    {
                        envDataType.EnvironmentalInterestStartDateSpecified = false;
                        envDataType.EnvironmentalInterestEndDateSpecified = false;
                    }


                    envArray.Add(envDataType);





                }

                fsDetail.EnvironmentalInterestDetails = (EnvironmentalInterest[])envArray.ToArray(typeof(EnvironmentalInterest));


                #endregion


                #region Individual

                ArrayList indArray = new ArrayList();

                foreach (DataRow childRowInd in dr.GetChildRows(TableRelationships.EnvInt_Indiv.ToString()))
                {

                    //Create an instance of the complex property
                    IndividualDetails indDtl = new IndividualDetails();


                    //Affiliation
                    AffiliationDataType affType = new AffiliationDataType();
                    affType.AffiliationTypeText = FormatDBNullString(childRowInd["AffiliationTypeText"]);

                    if (IsValidDateTime(childRowInd["AffiliationStartDate"], DateTime.Parse("1/1/1900")))
                    {
                        affType.AffiliationStartDate = FormatDBNullDateTime(childRowInd["AffiliationStartDate"]);
                        affType.AffiliationStartDateSpecified = true;

                        if (IsValidDateTime(childRowInd["AffiliationEndDate"], affType.AffiliationStartDate))
                        {
                            affType.AffiliationEndDate = FormatDBNullDateTime(childRowInd["AffiliationEndDate"]);
                            affType.AffiliationEndDateSpecified = true;
                        }
                        else
                        {
                            affType.AffiliationEndDateSpecified = false;
                        }

                    }
                    else
                    {
                        affType.AffiliationStartDateSpecified = false;
                        affType.AffiliationEndDateSpecified = false;
                    }


                    indDtl.Affiliation = affType;

                    //PhoneFaxEmail
                    PhoneFaxEmailDataType pfType = new PhoneFaxEmailDataType();
                    pfType.EmailAddressText = FormatDBNullString(childRowInd["EmailAddressText"]);
                    pfType.TelephoneNumber = FormatDBNullString(childRowInd["TelephoneNumber"]);
                    pfType.PhoneExtension = FormatDBNullString(childRowInd["PhoneExtension"]);
                    pfType.FaxNumber = FormatDBNullString(childRowInd["FaxNumber"]);
                    pfType.AlternateTelephoneNumber = FormatDBNullString(childRowInd["AlternateTelephoneNumber"]);
                    //indDtl.PhoneFaxEmail = pfType;	//adding check to avoid empty PhoneFaxEmail tags
                    if (FormatDBNullString(childRowInd["TelephoneNumber"]) != null)
                    {
                        indDtl.PhoneFaxEmail = pfType;
                    }

                    //IndividualDataType
                    IndividualDataType indType = new IndividualDataType();
                    indType.IndividualFullName = FormatDBNullString(childRowInd["IndividualFullName"]);
                    indType.IndividualTitleText = FormatDBNullString(childRowInd["IndividualTitleText"]);
                    indDtl.Individual = indType;

                    //MailingAddress
                    MailingAddressDataType mailAdd = new MailingAddressDataType();
                    mailAdd.MailingAddressText = FormatDBNullString(childRowInd["MailingAddressText"]);
                    mailAdd.SupplementalAddressText = FormatDBNullString(childRowInd["SupplementalAddressText"]);
                    mailAdd.MailingAddressCityName = FormatDBNullString(childRowInd["MailingAddressCityName"]);
                    mailAdd.MailingAddressStateUSPSCode = FormatDBNullString(childRowInd["MailingAddressStateUSPSCode"]);
                    mailAdd.MailingAddressStateName = FormatDBNullString(childRowInd["MailingAddressStateName"]);
                    mailAdd.MailingAddressCountryName = FormatDBNullString(childRowInd["MailingAddressCountryName"]);
                    mailAdd.MailingAddressZIPCode = FormatDBNullString(childRowInd["MailingAddressZIPCode"]);
                    indDtl.MailingAddress = mailAdd;

                    indArray.Add(indDtl);

                }

                fsDetail.IndividualDetails = (IndividualDetails[])indArray.ToArray(typeof(IndividualDetails));


                #endregion



                #region Organization

                ArrayList orgArray = new ArrayList();

                foreach (DataRow childRowOrg in dr.GetChildRows(TableRelationships.EnvInt_Org.ToString()))
                {

                    //Create an instance of the complex property
                    OrganizationDetails orgDtl = new OrganizationDetails();

                    //Affiliation
                    AffiliationDataType affType = new AffiliationDataType();
                    affType.AffiliationTypeText = FormatDBNullString(childRowOrg["AffiliationTypeText"]);

                    if (IsValidDateTime(childRowOrg["AffiliationStartDate"], DateTime.Parse("1/1/1900")))
                    {
                        affType.AffiliationStartDate = FormatDBNullDateTime(childRowOrg["AffiliationStartDate"]);
                        affType.AffiliationStartDateSpecified = true;

                        if (IsValidDateTime(childRowOrg["AffiliationEndDate"], DateTime.Parse("1/1/1900")))
                        {
                            affType.AffiliationEndDate = FormatDBNullDateTime(childRowOrg["AffiliationEndDate"]);
                            affType.AffiliationEndDateSpecified = true;
                        }
                        else
                        {
                            affType.AffiliationEndDateSpecified = false;
                        }
                    }
                    else
                    {
                        affType.AffiliationStartDateSpecified = false;
                        affType.AffiliationEndDateSpecified = false;
                    }

                    orgDtl.Affiliation = affType;

                    //PhoneFaxEmail
                    PhoneFaxEmailDataType pfType = new PhoneFaxEmailDataType();
                    pfType.EmailAddressText = FormatDBNullString(childRowOrg["EmailAddressText"]);
                    pfType.TelephoneNumber = FormatDBNullString(childRowOrg["TelephoneNumber"]);
                    pfType.PhoneExtension = FormatDBNullString(childRowOrg["PhoneExtension"]);
                    pfType.FaxNumber = FormatDBNullString(childRowOrg["FaxNumber"]);
                    pfType.AlternateTelephoneNumber = FormatDBNullString(childRowOrg["AlternateTelephoneNumber"]);
                    //orgDtl.PhoneFaxEmail = pfType;
                    //adding check to avoid empty PhoneFaxEmail tags
                    if (FormatDBNullString(childRowOrg["TelephoneNumber"]) != null)
                    {
                        orgDtl.PhoneFaxEmail = pfType;
                    }

                    //Organization
                    OrganizationDataType orgType = new OrganizationDataType();
                    orgType.OrganizationFormalName = FormatDBNullString(childRowOrg["OrganizationFormalName"]);
                    orgType.OrganizationDUNSNumber = FormatDBNullString(childRowOrg["OrganizationDUNSNumber"]);
                    orgType.OrganizationTypeText = FormatDBNullString(childRowOrg["OrganizationTypeText"]);
                    orgType.EmployerIdentifier = FormatDBNullString(childRowOrg["EmployerIdentifier"]);
                    orgType.StateBusinessIdentifier = FormatDBNullString(childRowOrg["StateBusinessIdentifier"]);
                    orgType.UltimateParentName = FormatDBNullString(childRowOrg["UltimateParentName"]);
                    orgType.UltimateParentDUNSNumber = FormatDBNullString(childRowOrg["UltimateParentDUNSNumber"]);
                    orgDtl.Organization = orgType;
                    //						adding check to avoid empty Organization tags
                    //						if(FormatDBNullString(childRowOrg["OrganizationFormalName"]) != null)
                    //						{
                    //							orgDtl.Organization = orgType;
                    //						}
                    //////////////////////////////////////////////////////problem here in this area?

                    //MailingAddress
                    MailingAddressDataType mailAdd = new MailingAddressDataType();
                    mailAdd.MailingAddressText = FormatDBNullString(childRowOrg["MailingAddressText"]);
                    mailAdd.SupplementalAddressText = FormatDBNullString(childRowOrg["SupplementalAddressText"]);
                    mailAdd.MailingAddressCityName = FormatDBNullString(childRowOrg["MailingAddressCityName"]);
                    mailAdd.MailingAddressStateUSPSCode = FormatDBNullString(childRowOrg["MailingAddressStateUSPSCode"]);
                    mailAdd.MailingAddressStateName = FormatDBNullString(childRowOrg["MailingAddressStateName"]);
                    mailAdd.MailingAddressCountryName = FormatDBNullString(childRowOrg["MailingAddressCountryName"]);
                    mailAdd.MailingAddressZIPCode = FormatDBNullString(childRowOrg["MailingAddressZIPCode"]);
                    orgDtl.MailingAddress = mailAdd;

                    orgArray.Add(orgDtl);

                }

                fsDetail.OrganizationDetails = (OrganizationDetails[])orgArray.ToArray(typeof(OrganizationDetails));

                #endregion


                #region AlternateName

                DataRow[] altInfoRows = dr.GetChildRows(TableRelationships.Facility_AltName.ToString());

                if (altInfoRows.Length > 0)
                {

                    //Create an instance of the complex property
                    AltNameDataType altInfo = new AltNameDataType();

                    //AlternativeName, AlternativeNameTypeText, DataSourceName, LastReportedDate, 
                    //StateFacilitySystemAcronymName, StateFacilityIdentifier
                    altInfo.AlternativeName = FormatDBNullString(altInfoRows[0]["AlternativeName"]);
                    altInfo.AlternativeNameTypeText = FormatDBNullString(altInfoRows[0]["AlternativeNameTypeText"]);

                    fsDetail.AlternativeNameInfo = altInfo;

                }

                #endregion


                #region MailingAddress

                DataRow[] mailAddRows = dr.GetChildRows(TableRelationships.Facility_MailAdd.ToString());

                if (mailAddRows.Length > 0)
                {

                    //Create an instance of the complex property
                    MailingAddressDataType mailAdd = new MailingAddressDataType();

                    //AffiliationTypeText, DataSourceName, LastReportedDate, 
                    //StateFacilitySystemAcronymName, StateFacilityIdentifier

                    mailAdd.MailingAddressText = FormatDBNullString(mailAddRows[0]["MailingAddressText"]);
                    mailAdd.SupplementalAddressText = FormatDBNullString(mailAddRows[0]["SupplementalAddressText"]);
                    mailAdd.MailingAddressCityName = FormatDBNullString(mailAddRows[0]["MailingAddressCityName"]);
                    mailAdd.MailingAddressStateUSPSCode = FormatDBNullString(mailAddRows[0]["MailingAddressStateUSPSCode"]);
                    mailAdd.MailingAddressStateName = FormatDBNullString(mailAddRows[0]["MailingAddressStateName"]);
                    mailAdd.MailingAddressCountryName = FormatDBNullString(mailAddRows[0]["MailingAddressCountryName"]);
                    mailAdd.MailingAddressZIPCode = FormatDBNullString(mailAddRows[0]["MailingAddressZIPCode"]);

                    fsDetail.MailingAddress = mailAdd;

                }

                #endregion

                #region SICCode

                ArrayList sicArray = new ArrayList();

                foreach (DataRow childRow in dr.GetChildRows(TableRelationships.Facility_SIC.ToString()))
                {

                    if (childRow["SICCode"] != DBNull.Value)
                    {

                        //Create an instance of the complex property
                        SICCodeDetails sicDtl = new SICCodeDetails();

                        sicDtl.SICCode = FormatDBNullSICCode(childRow["SICCode"]);
                        if (childRow["SICPrimaryIndicator"] == DBNull.Value)
                        {
                            sicDtl.SICPrimaryIndicatorSpecified = false;
                        }
                        else
                        {
                            sicDtl.SICPrimaryIndicator = ConvertToPrimaryIndicatorDataType(childRow["SICPrimaryIndicator"]);
                            sicDtl.SICPrimaryIndicatorSpecified = true;
                        }

                        sicArray.Add(sicDtl);

                    }
                }

                fsDetail.SICCodeDetails = (SICCodeDetails[])sicArray.ToArray(typeof(SICCodeDetails));


                #endregion


                #region NAICSCode

                ArrayList naicsArray = new ArrayList();

                foreach (DataRow childRow in dr.GetChildRows(TableRelationships.Facility_NAICS.ToString()))
                {

                    if (childRow["NAICSCode"] != DBNull.Value)
                    {

                        //Create an instance of the complex property
                        NAICSCodeDetails naicsDtl = new NAICSCodeDetails();



                        if (childRow["NAICSCode"] == DBNull.Value)
                        {
                            naicsDtl.NAICSPrimaryIndicatorSpecified = false;
                        }
                        else
                        {
                            naicsDtl.NAICSCode = FormatDBNullNAICSCode(childRow["NAICSCode"]);
                            naicsDtl.NAICSPrimaryIndicator = ConvertToPrimaryIndicatorDataType(childRow["NAICSPrimaryIndicator"]);
                            naicsDtl.NAICSPrimaryIndicatorSpecified = true;
                        }

                        naicsArray.Add(naicsDtl);

                    }

                }

                fsDetail.NAICSCodeDetails = (NAICSCodeDetails[])naicsArray.ToArray(typeof(NAICSCodeDetails));


                #endregion



                #region GeographicCoordinates

                DataRow[] geoRows = dr.GetChildRows(TableRelationships.Facility_GeoCoord.ToString());

                if (geoRows.Length > 0)
                {

                    //Create an instance of the complex property
                    GeographicCoordinateDataType geoDtl = new GeographicCoordinateDataType();

                    // StateFacilitySystemAcronymName, StateFacilityIdentifier
                    if (geoRows[0]["LatitudeMeasure"] != DBNull.Value)
                    {
                        geoDtl.LatitudeMeasure = FormatDBNullDecimal(geoRows[0]["LatitudeMeasure"]);
                    }

                    if (geoRows[0]["LongitudeMeasure"] != DBNull.Value)
                    {
                        geoDtl.LongitudeMeasure = FormatDBNullDecimal(geoRows[0]["LongitudeMeasure"]);
                    }

                    geoDtl.HorizontalAccuracyMeasure = FormatDBNullString(geoRows[0]["HorizontalAccuracyMeasure"]);

                    if (geoRows[0]["HorizontalCollectionMethodText"] == DBNull.Value)
                    {
                        geoDtl.HorizontalCollectionMethodTextSpecified = false;
                    }
                    else
                    {
                        geoDtl.HorizontalCollectionMethodText = ConvertToHorizontalMethodDataType(geoRows[0]["HorizontalCollectionMethodText"]);
                        geoDtl.HorizontalCollectionMethodTextSpecified = true;
                    }

                    if (geoRows[0]["HorizontalReferenceDatumName"] == DBNull.Value)
                    {
                        geoDtl.HorizontalReferenceDatumNameSpecified = false;
                    }
                    else
                    {
                        geoDtl.HorizontalReferenceDatumName = ConvertToHorizontalDatumDataType(geoRows[0]["HorizontalReferenceDatumName"]);
                        geoDtl.HorizontalReferenceDatumNameSpecified = true;
                    }

                    geoDtl.SourceMapScaleNumber = FormatDBNullString(geoRows[0]["SourceMapScaleNumber"]);

                    if (geoRows[0]["ReferencePointText"] == DBNull.Value)
                    {
                        geoDtl.ReferencePointTextSpecified = false;
                    }
                    else
                    {
                        geoDtl.ReferencePointText = ConvertToReferencePointDataType(geoRows[0]["ReferencePointText"]);
                        geoDtl.ReferencePointTextSpecified = true;
                    }

                    if (geoRows[0]["DataCollectionDate"] == DBNull.Value)
                    {
                        geoDtl.DataCollectionDateSpecified = false;
                    }
                    else
                    {
                        geoDtl.DataCollectionDate = FormatDBNullDateTime(geoRows[0]["DataCollectionDate"]);
                        geoDtl.DataCollectionDateSpecified = true;
                    }

                    if (geoRows[0]["GeometricTypeName"] != DBNull.Value)
                    {
                        geoDtl.GeometricTypeName = ConvertToGeometricDataType(geoRows[0]["GeometricTypeName"]);
                        geoDtl.GeometricTypeNameSpecified = true;
                    }
                    else
                    {
                        geoDtl.GeometricTypeNameSpecified = false;
                    }

                    geoDtl.LocationCommentsText = FormatDBNullString(geoRows[0]["LocationCommentsText"]);

                    if (geoRows[0]["VerticalCollectionMethodText"] == DBNull.Value)
                    {
                        geoDtl.VerticalCollectionMethodTextSpecified = false;
                    }
                    else
                    {
                        geoDtl.VerticalCollectionMethodText = ConvertToVerticalMethodDataType(geoRows[0]["VerticalCollectionMethodText"]);
                        geoDtl.VerticalCollectionMethodTextSpecified = true;
                    }

                    if (geoRows[0]["VerticalMeasure"] != DBNull.Value)
                    {
                        geoDtl.VerticalMeasure = FormatDBNullDecimal(geoRows[0]["VerticalMeasure"]);
                    }

                    geoDtl.VerticalAccuracyMeasure = FormatDBNullString(geoRows[0]["VerticalAccuracyMeasure"]);

                    if (geoRows[0]["VerticalReferenceDatumName"] == DBNull.Value)
                    {
                        geoDtl.VerticalReferenceDatumNameSpecified = false;
                    }
                    else
                    {
                        geoDtl.VerticalReferenceDatumName = ConvertToVerticalDatumDataType(geoRows[0]["VerticalReferenceDatumName"]);
                        geoDtl.VerticalReferenceDatumNameSpecified = true;
                    }

                    geoDtl.DataSourceName = FormatDBNullString(geoRows[0]["DataSourceName"]);
                    geoDtl.CoordinateDataSourceName = FormatDBNullString(geoRows[0]["CoordinateDataSourceName"]);
                    geoDtl.SubEntityIdentifier = FormatDBNullString(geoRows[0]["SubEntityIdentifier"]);

                    if (geoRows[0]["SubEntityTypeName"] == DBNull.Value)
                    {
                        geoDtl.SubEntityTypeNameSpecified = false;
                    }
                    else
                    {
                        geoDtl.SubEntityTypeName = ConvertToSubEntityDataType(geoRows[0]["SubEntityTypeName"]);
                        geoDtl.SubEntityTypeNameSpecified = true;
                    }

                    fsDetail.GeographicCoordinates = geoDtl;

                }


                #endregion



                //Add Loaded object (parent) to the collection
                detailArray.Add(fsDetail);



            }



            //Assign the collection of FacilitySiteAllDetails of the parent table
            fsList.FacilitySiteAllDetails = (FacilitySiteAllDetails[])detailArray.ToArray(typeof(FacilitySiteAllDetails));

            //Return loaded collection
            return fsList;

        }



        #endregion



        #region IQueryProcessor Interface Implementation

        /// <summary>
        /// ProcessQuery
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public PaginatedContentResult ProcessQuery(string requestId)
        {
            LOG.DebugEnter(MethodBase.GetCurrentMethod(), requestId);

            LazyInit();

            DataRequest request = GetAndPrintRequest(requestId);

            FacilitySiteList list = GetFacilitySiteList(request);
            AppendAuditLogEvent("Records found: " + list.FacilitySiteAllDetails.Length);

            LOG.Debug("Creating PaginatedContentResult");
            PaginatedContentResult result = new PaginatedContentResult();
            result.Paging = new PaginationIndicator(request.RowIndex, request.MaxRowCount, true);

            if (_addHeader)
            {
                LOG.Debug("Serializing data and making header...");
                AppendAuditLogEvent("Serializing data and making header...");
                result.Content = new SimpleContent(CommonContentType.XML, File.ReadAllBytes(MakeHeaderFile(list)));

            }
            else
            {
                LOG.Debug("Serializing data...");
                AppendAuditLogEvent("Serializing data...");
                result.Content = new SimpleContent(CommonContentType.XML, _serializationHelper.Serialize(list));

            }

            LOG.Debug("OK");
            AppendAuditLogEvent("ProcessQuery: OK");
            return result;
        }

        #endregion


        #region ISolicitProcessor Interface Implementation

        /// <summary>
        /// ProcessSolicit
        /// </summary>
        /// <param name="requestId"></param>
        public void ProcessSolicit(string requestId)
        {

            LOG.DebugEnter(MethodBase.GetCurrentMethod(), requestId);

            LazyInit();

            DataRequest request = GetAndPrintRequest(requestId);

            FacilitySiteList list = GetFacilitySiteList(request);
            AppendAuditLogEvent("Records found: " + ((list.FacilitySiteAllDetails != null) ? list.FacilitySiteAllDetails.Length.ToString() : "0"));

            string serializedFilePath = null;
            if (_addHeader)
            {
                LOG.Debug("Serializing results and making header...");
                AppendAuditLogEvent("Serializing results and making header...");
                serializedFilePath = MakeHeaderFile(list);
            }
            else
            {
                LOG.Debug("Serializing results to file...");
                AppendAuditLogEvent("Serializing results to file...");
                serializedFilePath = _serializationHelper.SerializeToTempFile(list);
            }

            LOG.Debug("Serialized file path: " + serializedFilePath);
            AppendAuditLogEvent("Serialized file path: " + serializedFilePath);


            LOG.Debug("Compressing serialized file...");
            AppendAuditLogEvent("Compressing serialized file...");
            string compressedFilePath = _compressionHelper.CompressFile(serializedFilePath);
            LOG.Debug("Compressed file path: " + compressedFilePath);
            AppendAuditLogEvent("Compressed file path: " + compressedFilePath);

            LOG.Debug("Adding document...");
            AppendAuditLogEvent("Adding document...");
            _documentManager.AddDocument(request.TransactionId,
                                         CommonTransactionStatusCode.Processed,
                                         "Request Processed: " + request.ToString(),
                                         compressedFilePath);

            LOG.Debug("OK");
            AppendAuditLogEvent("ProcessQuery: OK");


        }

        #endregion



        #region Utilities


        private DataRequest GetAndPrintRequest(string requestId)
        {
            AppendAuditLogEvent("Getting request for by Id: " + requestId);
            DataRequest request = _requestManager.GetDataRequest(requestId);
            LOG.Debug("Request: " + request);

            AppendAuditLogEvent("Service Name: " + request.Service.Name);
            if (request.Parameters != null)
            {

                if (request.Parameters.IsByName)
                {

                    foreach (KeyValuePair<string, string> arg in request.Parameters.NameValuePairs)
                    {
                        AppendAuditLogEvent(string.Format("Arg {0}={1}", arg.Key, arg.Value));
                    }

                }
                else
                {
                    for (int i = 0; i < request.Parameters.Count; i++)
                    {
                        AppendAuditLogEvent(string.Format("Param {0}={1}", i, request.Parameters[i]));
                    }
                }
            }

            AppendAuditLogEvent("Request printed");
            return request;
        }


        private bool IsOn(string type)
        {
            string doHeader = string.Empty;
            if (TryGetConfigParameter(type, ref doHeader) && !string.IsNullOrEmpty(doHeader))
            {
                doHeader = doHeader.Trim().ToLower();
            }
            AppendAuditLogEvent("Do header: " + doHeader);
            return (doHeader == "true" || doHeader == "on" || doHeader == "yes" || doHeader == "ya" || doHeader == "da");
        }

        protected string MakeHeaderFile(FacilitySiteList list)
        {
            AppendAuditLogEvent("Generating header file from results");

            // Configure the submission header helper
            _headerDocumentHelper.Configure(_author, _organization, _title, null, _contactInfo, null);
            _headerDocumentHelper.AddNotifications(_notifications);

            string tempXmlFilePath = _settingsProvider.NewTempFilePath();
            tempXmlFilePath = Path.ChangeExtension(tempXmlFilePath, ".xml");
            AppendAuditLogEvent("Temp file before header:" + tempXmlFilePath);

            string tempXmlFilePath2 = _settingsProvider.NewTempFilePath();
            tempXmlFilePath2 = Path.ChangeExtension(tempXmlFilePath, ".xml");
            AppendAuditLogEvent("Temp file after header:" + tempXmlFilePath2);

            _serializationHelper.Serialize(list, tempXmlFilePath);
            AppendAuditLogEvent("Temp file serialized");

            if (!File.Exists(tempXmlFilePath))
            {
                throw new IOException("Temp file does not exist: " + tempXmlFilePath);
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(tempXmlFilePath);
            AppendAuditLogEvent("Xml document loaded");

            _headerDocumentHelper.AddPayload(_payloadOperation, doc.DocumentElement);

            AppendAuditLogEvent("Header payload added");

            _headerDocumentHelper.Serialize(tempXmlFilePath2);

            AppendAuditLogEvent("Header serialized");

            if (!File.Exists(tempXmlFilePath2))
            {
                throw new IOException("Header file does not exist: " + tempXmlFilePath2);
            }

            return tempXmlFilePath2;

        }

        private FacilitySiteList GetFacilitySiteList(DataRequest request)
        {

            LOG.DebugEnter(MethodBase.GetCurrentMethod(), request);

            IDbProvider dbProvider = DataProviders[FRSDataProviderParameterType.SourceProvider.ToString()];
            bool isOracle = SpringBaseDao.IsOracleDatabaseProvider(dbProvider);
            LOG.Debug("Provider: {0}, IsOracle: {1}", dbProvider, isOracle.ToString());


            // Validate Method name
            if (request == null)
            {
                throw new ApplicationException("Service name is required.");
            }

            List<string> parameters = GetParameterListSortedByName(request.Parameters);

            string connectionString = dbProvider.ConnectionString;
            FacilitySiteList fsList;

            switch (request.Service.Name.ToLower().Trim())
            {
                case "getdeletedfacilitybychangedate":

                    string[] ids = Data.GetDeletedFacilities(isOracle, "getdeletedfacilitybychangedate",
                        request.RowIndex, request.MaxRowCount, parameters, connectionString);
                    fsList = PopulateDeletedFacilitySiteList(ref ids);
                    break;

                default:

                    DataSet ds = Data.GetFacilityData(isOracle, request.Service.Name,
                        request.RowIndex, request.MaxRowCount, parameters, connectionString);
                    fsList = PopulateFacilitySiteList(ref ds);
                    break;
            }

            return fsList;
        }
        public override IList<TypedParameter> GetDataServiceParameters(string serviceName, out DataServicePublishFlags publishFlags)
        {
            List<TypedParameter> list = null;
            publishFlags = DataServicePublishFlags.DoNotPublish;
            switch (serviceName.ToLower())
            {
                case "getdeletedfacilitybychangedate":
                    list = new List<TypedParameter>(1);
                    list.Add(new TypedParameter("P01 - DeletionDate", "Deletion Date (YYYY-MM-DD)", true, typeof(string), true));
                    publishFlags = DataServicePublishFlags.PublishToEndpointVersion11And20;
                    break;
                case "getfacilitybychangedate":
                    list = new List<TypedParameter>(2);
                    list.Add(new TypedParameter("P01 - StateUSPSCode", "State USPS Code", true, typeof(string), true));
                    list.Add(new TypedParameter("P02 - ChangeDate", "Change Date (YYYY-MM-DD)", true, typeof(string), true));
                    publishFlags = DataServicePublishFlags.PublishToEndpointVersion11And20;
                    break;
                case "getfacility":
                    list = new List<TypedParameter>(2);
                    list.Add(new TypedParameter("P01 - StateUSPSCode", "State USPS Code", true, typeof(string), true));
                    list.Add(new TypedParameter("P02 - FacilityName", "Facility Name (Starts With)", true, typeof(string), true));
                    publishFlags = DataServicePublishFlags.PublishToEndpointVersion11And20;
                    break;
                case "getfacilitybyname":
                    list = new List<TypedParameter>(34);
                    list.Add(new TypedParameter("P01 - StateUSPSCode", "State USPS Code", false, typeof(string), true));
                    list.Add(new TypedParameter("P02 - FacilityName", "Facility Name (Starts With)", false, typeof(string), true));
                    list.Add(new TypedParameter("P03 - StateFacilityId", "State Facility Id", false, typeof(string), true));
                    list.Add(new TypedParameter("P04 - ChangeDate", "Change Date (YYYY-MM-DD)", false, typeof(string), true));
                    list.Add(new TypedParameter("P05 - StateSystemId", "State SystemI d", false, typeof(string), true));
                    list.Add(new TypedParameter("P06 - EnvIntTypes", "Env Int Types", false, typeof(string), true));
                    list.Add(new TypedParameter("P07 - StateSystemAcronym", "State System Acronym", false, typeof(string), true));
                    list.Add(new TypedParameter("P08 - SICCodes", "SIC Codes", false, typeof(string), true));
                    list.Add(new TypedParameter("P09 - NaicsCodes", "Naics Codes", false, typeof(string), true));
                    list.Add(new TypedParameter("P10 - LocationAddress", "Location Address", false, typeof(string), true));
                    list.Add(new TypedParameter("P11 - CityName", "City Name", false, typeof(string), true));
                    list.Add(new TypedParameter("P12 - ZipCode", "Zip Code", false, typeof(string), true));
                    list.Add(new TypedParameter("P13 - State", "State", false, typeof(string), true));
                    list.Add(new TypedParameter("P14 - EPARegions", "EPA Regions", false, typeof(string), true));
                    list.Add(new TypedParameter("P15 - HUCCode", "HUC Code", false, typeof(string), true));
                    list.Add(new TypedParameter("P16 - FIPSCodes", "FIPS Codes", false, typeof(string), true));
                    list.Add(new TypedParameter("P17 - CountyNames", "County Names", false, typeof(string), true));
                    list.Add(new TypedParameter("P18 - NBoundingLong", "N Bounding Long", false, typeof(string), true));
                    list.Add(new TypedParameter("P19 - SBoundingLong", "S Bounding Long", false, typeof(string), true));
                    list.Add(new TypedParameter("P20 - EBoundingLat", "E Bounding Lat", false, typeof(string), true));
                    list.Add(new TypedParameter("P21 - WBoundingLat", "W Bounding Lat", false, typeof(string), true));
                    list.Add(new TypedParameter("P22 - TRSQ", "TRSQ", false, typeof(string), true));
                    list.Add(new TypedParameter("P23 - StateCongressDistNums", "State Congress Dist Nums", false, typeof(string), true));
                    list.Add(new TypedParameter("P24 - StateHouseDistNums", "State House Dist Nums", false, typeof(string), true));
                    list.Add(new TypedParameter("P25 - StateSenateDistNums", "State Senate Dist Nums", false, typeof(string), true));
                    list.Add(new TypedParameter("P26 - FedCongressDistNums", "Fed Congress Dist Nums", false, typeof(string), true));
                    list.Add(new TypedParameter("P27 - FedHouseDistNums", "Fed House Dist Nums", false, typeof(string), true));
                    list.Add(new TypedParameter("P28 - FedSenateDistNums", "Fed Senate Dist Nums", false, typeof(string), true));
                    list.Add(new TypedParameter("P29 - TribalLandCode", "Tribal Land Code", false, typeof(string), true));
                    list.Add(new TypedParameter("P30 - TribalLandName", "Tribal Land Name", false, typeof(string), true));
                    list.Add(new TypedParameter("P31 - FederalFacility", "Federal Facility", false, typeof(string), true));
                    list.Add(new TypedParameter("P32 - OrgDUNSNum", "Org DUNS Num", false, typeof(string), true));
                    list.Add(new TypedParameter("P33 - OrgName", "Org Name", false, typeof(string), true));
                    list.Add(new TypedParameter("P34 - IndividualName", "Individual Name", false, typeof(string), true));
                    publishFlags = DataServicePublishFlags.PublishToEndpointVersion11And20;
                    break;
            }
            return list;
        }

        /// <summary>
        /// FormatDBNullNAICSCode
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string FormatDBNullNAICSCode(object val)
        {
            if (val != DBNull.Value)
            {
                string naics = val.ToString().Trim();
                if (naics.Length < 6)
                {
                    switch (naics.Length)
                    {

                        default:
                            return "000000";
                        case 1:
                            return naics + "00000";
                        case 2:
                            return naics + "0000";
                        case 3:
                            return naics + "000";
                        case 4:
                            return naics + "00";
                        case 5:
                            return naics + "0";
                    }
                }
                else
                {
                    return naics;
                }
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// FormatDBNullDateTime
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string FormatDBNullSICCode(object val)
        {
            if (val != DBNull.Value)
            {
                string sic = val.ToString().Trim();
                if (sic.Length < 4)
                {
                    switch (sic.Length)
                    {

                        default:
                            return "0000";
                        case 1:
                            return sic + "000";
                        case 2:
                            return sic + "00";
                        case 3:
                            return sic + "0";
                    }
                }
                else
                {
                    return sic;
                }
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// FormatDBNullDateTime
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private DateTime FormatDBNullDateTime(object val)
        {
            try
            {
                DateTime testDate = DateTime.Parse(val.ToString());
                if (testDate < DateTime.Parse("1/1/1900"))
                {
                    return DateTime.MinValue;
                }
                else
                {
                    return testDate;
                }
            }
            catch
            {
                return DateTime.MinValue;
            }
        }


        private bool IsValidDateTime(object val, DateTime mustBeGreaterThanDate)
        {
            try
            {
                if (val == DBNull.Value)
                {
                    return false;
                }
                else
                {
                    return (DateTime.Parse(val.ToString()) >= mustBeGreaterThanDate);
                }
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// ConvertToYesNoIndicatorDataType
        /// </summary>
        /// <param name="boolValue"></param>
        /// <returns></returns>
        private YesNoIndicatorDataType ConvertToYesNoIndicatorDataType(object val)
        {
            try
            {
                if (val.ToString().Trim().ToUpper() == "Y")
                    return YesNoIndicatorDataType.Y;
                else
                    return YesNoIndicatorDataType.N;
            }
            catch
            {
                return YesNoIndicatorDataType.N;
            }
        }

        /// <summary>
        /// ConvertToFederalStateIndicatorDataType
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        private FederalStateIndicatorDataType ConvertToFederalStateIndicatorDataType(object val)
        {
            return (val.ToString().Trim().ToUpper() == "S") ? FederalStateIndicatorDataType.S : FederalStateIndicatorDataType.F;
        }


        /// <summary>
        /// FormatString
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string FormatDBNullString(object val)
        {
            if ((val == DBNull.Value) || (val == null) || (val.ToString().Trim().Equals(string.Empty)))
            {
                return null;
            }
            else
            {
                string output = val.ToString().Trim();
                output = output.Replace("\n", " ");
                output = output.Replace("\t", " ");
                output = output.Replace("\r", " ");
                return output;
            }
        }


        /// <summary>
        /// FormatDBNullDecimal
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private System.Decimal FormatDBNullDecimal(object val)
        {
            return (val == DBNull.Value) ? Decimal.Zero : System.Decimal.Parse(val.ToString());
        }


        /// <summary>
        /// FormatToGeometricDataType
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private GeometricDataType ConvertToGeometricDataType(object val)
        {

            switch (parseEnumValue(val))
            {

                case "POINT":
                    return GeometricDataType.POINT;

                case "LINE":
                    return GeometricDataType.POINT;

                case "AREA":
                    return GeometricDataType.POINT;

                case "REGION":
                    return GeometricDataType.POINT;

                case "ROUTE":
                    return GeometricDataType.POINT;

                default:
                    return GeometricDataType.POINT;

            }

        }


        /// <summary>
        /// ConvertToPrimaryIndicatorDataType
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private PrimaryIndicatorDataType ConvertToPrimaryIndicatorDataType(object val)
        {

            if (val == DBNull.Value)
            {
                return PrimaryIndicatorDataType.UNKNOWN;
            }
            else
            {

                if (parseEnumValue(val) == PrimaryIndicatorDataType.PRIMARY.ToString())
                {
                    return PrimaryIndicatorDataType.PRIMARY;
                }
                else
                {
                    return PrimaryIndicatorDataType.SECONDARY;
                }
            }
        }


        /// <summary>
        /// ConvertToHorizontalDatumDataType
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private HorizontalDatumDataType ConvertToHorizontalDatumDataType(object val)
        {

            if (val == DBNull.Value)
            {
                return HorizontalDatumDataType.NAD83;
            }
            else
            {

                switch (parseEnumValue(val))
                {
                    case "NAD27":
                        return HorizontalDatumDataType.NAD27;
                    case "WGS84":
                        return HorizontalDatumDataType.WGS84;
                    default:
                        return HorizontalDatumDataType.NAD83;
                }
            }

        }


        /// <summary>
        /// ConvertToVerticalMethodDataType
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private VerticalMethodDataType ConvertToVerticalMethodDataType(object val)
        {

            if (val == DBNull.Value)
            {
                return VerticalMethodDataType.OTHER;
            }
            else
            {

                switch (parseEnumValue(val))
                {

                    default:
                        return VerticalMethodDataType.OTHER;

                    case "GPSCARRIERPHASESTATICRELATIVEPOSITION":
                        return VerticalMethodDataType.GPSCARRIERPHASESTATICRELATIVEPOSITION;

                    case "GPSCARRIERPHASEKINEMATICRELATIVEPOSITION":
                        return VerticalMethodDataType.GPSCARRIERPHASEKINEMATICRELATIVEPOSITION;

                    case "GPSCODEPSEUDORANGEDIFFERENTIAL":
                        return VerticalMethodDataType.GPSCODEPSEUDORANGEDIFFERENTIAL;

                    case "GPSCODEPSEUDORANGEPRECISEPOSITION":
                        return VerticalMethodDataType.GPSCODEPSEUDORANGEPRECISEPOSITION;

                    case "GPSCODEPSEUDORANGESTANDARDPOSITIONSAOFF":
                        return VerticalMethodDataType.GPSCODEPSEUDORANGESTANDARDPOSITIONSAOFF;

                    case "GPSCODEPSEUDORANGESTANDARDPOSITIONSAON":
                        return VerticalMethodDataType.GPSCODEPSEUDORANGESTANDARDPOSITIONSAON;

                    case "CLASSICALSURVEYINGTECHNIQUES":
                        return VerticalMethodDataType.CLASSICALSURVEYINGTECHNIQUES;

                    case "ALTIMETRY":
                        return VerticalMethodDataType.ALTIMETRY;

                    case "PRECISELEVELINGBENCHMARK":
                        return VerticalMethodDataType.PRECISELEVELINGBENCHMARK;

                    case "LEVELINGNONBENCHMARKCONTROLPOINTS":
                        return VerticalMethodDataType.LEVELINGNONBENCHMARKCONTROLPOINTS;

                    case "TRIGONOMETRICLEVELING":
                        return VerticalMethodDataType.TRIGONOMETRICLEVELING;

                    case "PHOTOGRAMMETRIC":
                        return VerticalMethodDataType.PHOTOGRAMMETRIC;

                    case "TOPOGRAPHICMAPINTERPOLATION":
                        return VerticalMethodDataType.TOPOGRAPHICMAPINTERPOLATION;
                }
            }
        }


        /// <summary>
        /// ConvertToVerticalDatumDataType
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private VerticalDatumDataType ConvertToVerticalDatumDataType(object val)
        {

            switch (parseEnumValue(val))
            {

                default:
                    return VerticalDatumDataType.NAVD88;

                case "NAVD88":
                    return VerticalDatumDataType.NAVD88;

                case "NGVD29":
                    return VerticalDatumDataType.NAVD88;

                case "MEANSEALEVEL":
                    return VerticalDatumDataType.NAVD88;

                case "LOCALTIDALDATUM":
                    return VerticalDatumDataType.NAVD88;

            }
        }



        /// <summary>
        /// ConvertToReferencePointDataType
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private ReferencePointDataType ConvertToReferencePointDataType(object val)
        {

            if (val == DBNull.Value)
            {
                return ReferencePointDataType.UNKNOWN;
            }
            else
            {

                switch (parseEnumValue(val))
                {


                    default:
                        return ReferencePointDataType.UNKNOWN;

                    case "PLANTENTRANCEGENERAL":
                        return ReferencePointDataType.PLANTENTRANCEGENERAL;

                    case "OTHER":
                        return ReferencePointDataType.OTHER;

                    case "PLANTENTRANCEPERSONNEL":
                        return ReferencePointDataType.PLANTENTRANCEPERSONNEL;

                    case "PLANTENTRANCEFREIGHT":
                        return ReferencePointDataType.PLANTENTRANCEFREIGHT;

                    case "AIRRELEASESTACK":
                        return ReferencePointDataType.AIRRELEASESTACK;

                    case "AIRRELEASEVENT":
                        return ReferencePointDataType.AIRRELEASEVENT;

                    case "STORAGETANK":
                        return ReferencePointDataType.STORAGETANK;

                    case "WATERRELEASEPIPE":
                        return ReferencePointDataType.WATERRELEASEPIPE;

                    case "LAGOONORSETTLINGPOND":
                        return ReferencePointDataType.LAGOONORSETTLINGPOND;

                    case "LIQUIDWASTETREATMENTUNIT":
                        return ReferencePointDataType.LIQUIDWASTETREATMENTUNIT;

                    case "ATMOSPHERICEMISSIONSTREATMENTUNIT":
                        return ReferencePointDataType.ATMOSPHERICEMISSIONSTREATMENTUNIT;

                    case "SOLIDWASTETREATMENTDISPUNIT":
                        return ReferencePointDataType.SOLIDWASTETREATMENTDISPUNIT;

                    case "SOLIDWASTESTORAGEAREA":
                        return ReferencePointDataType.SOLIDWASTESTORAGEAREA;

                    case "LOADINGFACILITY":
                        return ReferencePointDataType.LOADINGFACILITY;

                    case "LOADINGAREACENTROID":
                        return ReferencePointDataType.LOADINGAREACENTROID;

                    case "PROCESSUNIT":
                        return ReferencePointDataType.PROCESSUNIT;

                    case "PROCESSUNITAREACENTROID":
                        return ReferencePointDataType.PROCESSUNITAREACENTROID;

                    case "ADMINISTRATIVEBUILDING":
                        return ReferencePointDataType.ADMINISTRATIVEBUILDING;

                    case "FACILITYCENTROID":
                        return ReferencePointDataType.FACILITYCENTROID;

                    case "NECORNEROFLANDPARCEL":
                        return ReferencePointDataType.NECORNEROFLANDPARCEL;

                    case "SECORNEROFLANDPARCEL":
                        return ReferencePointDataType.SECORNEROFLANDPARCEL;

                    case "NWCORNEROFLANDPARCEL":
                        return ReferencePointDataType.NWCORNEROFLANDPARCEL;

                    case "SWCORNEROFLANDPARCEL":
                        return ReferencePointDataType.SWCORNEROFLANDPARCEL;

                    case "CENTEROFFACILITY":
                        return ReferencePointDataType.CENTEROFFACILITY;

                    case "WELLHEADPROTECTIONAREA":
                        return ReferencePointDataType.WELLHEADPROTECTIONAREA;

                    case "WATERMONITORINGSTATION":
                        return ReferencePointDataType.WATERMONITORINGSTATION;

                    case "INTAKEPIPE":
                        return ReferencePointDataType.INTAKEPIPE;

                    case "WELL":
                        return ReferencePointDataType.WELL;

                    case "AIRMONITORINGSTATION":
                        return ReferencePointDataType.AIRMONITORINGSTATION;

                    case "WATERWELL":
                        return ReferencePointDataType.WATERWELL;

                    case "SPRING":
                        return ReferencePointDataType.SPRING;

                    case "SOURCEWATERAREA":
                        return ReferencePointDataType.SOURCEWATERAREA;

                    case "POTENTIALCONTAMINANTSOURCE":
                        return ReferencePointDataType.POTENTIALCONTAMINANTSOURCE;

                    case "SOURCEWATERPROTECTIONAREA":
                        return ReferencePointDataType.SOURCEWATERPROTECTIONAREA;

                    case "SLUDGEFIELD":
                        return ReferencePointDataType.SLUDGEFIELD;

                    case "INCINERATOR":
                        return ReferencePointDataType.INCINERATOR;

                    case "EMERGENCYOVERFLOW":
                        return ReferencePointDataType.EMERGENCYOVERFLOW;

                    case "COMBINEDANIMALFEEDOPERATIONCAFO":
                        return ReferencePointDataType.COMBINEDANIMALFEEDOPERATIONCAFO;

                }


            }

        }


        /// <summary>
        /// ConvertToSubEntityDataType
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private SubEntityDataType ConvertToSubEntityDataType(object val)
        {

            switch (parseEnumValue(val))
            {

                default:
                    return SubEntityDataType.SAMPLINGPOINT;

                case "POINTOFRECORD":
                    return SubEntityDataType.POINTOFRECORD;

                case "BOUNDRYPOINT":
                    return SubEntityDataType.BOUNDRYPOINT;

                case "SAMPLINGPOINT":
                    return SubEntityDataType.SAMPLINGPOINT;

                case "ENDOFDISCHARGEPOINT":
                    return SubEntityDataType.ENDOFDISCHARGEPOINT;

                case "WELLHEAD":
                    return SubEntityDataType.WELLHEAD;

                case "TRANSECTORIGIN":
                    return SubEntityDataType.TRANSECTORIGIN;

                case "GRIDORIGIN":
                    return SubEntityDataType.GRIDORIGIN;

                case "STACK":
                    return SubEntityDataType.STACK;

                case "SPILLS":
                    return SubEntityDataType.SPILLS;

                case "SLUDGE":
                    return SubEntityDataType.SLUDGE;

                case "LANDFILL":
                    return SubEntityDataType.LANDFILL;

                case "EMERGENCYOVERFLOW":
                    return SubEntityDataType.EMERGENCYOVERFLOW;

                case "INCINERATOR":
                    return SubEntityDataType.INCINERATOR;
            }
        }




        /// <summary>
        /// ConvertToHorizontalMethodDataType
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private HorizontalMethodDataType ConvertToHorizontalMethodDataType(object val)
        {

            if (val == DBNull.Value)
            {
                return HorizontalMethodDataType.UNKNOWN;
            }
            else
            {
                switch (parseEnumValue(val))
                {


                    case "ADDRESSMATCHINGBLOCKFACE":
                        return HorizontalMethodDataType.ADDRESSMATCHINGBLOCKFACE;

                    case "ADDRESSMATCHINGDIGITIZED":
                        return HorizontalMethodDataType.ADDRESSMATCHINGDIGITIZED;

                    case "ADDRESSMATCHINGHOUSENUMBER":
                        return HorizontalMethodDataType.ADDRESSMATCHINGHOUSENUMBER;

                    case "ADDRESSMATCHINGNEARESTINTERSECTION":
                        return HorizontalMethodDataType.ADDRESSMATCHINGNEARESTINTERSECTION;

                    case "ADDRESSMATCHINGOTHER":
                        return HorizontalMethodDataType.ADDRESSMATCHINGOTHER;

                    case "ADDRESSMATCHINGPRIMARYNAME":
                        return HorizontalMethodDataType.ADDRESSMATCHINGPRIMARYNAME;

                    case "ADDRESSMATCHINGSTREETCENTERLINE":
                        return HorizontalMethodDataType.ADDRESSMATCHINGSTREETCENTERLINE;

                    case "CENSUSBLOCKGROUP1990CENTROID":
                        return HorizontalMethodDataType.CENSUSBLOCKGROUP1990CENTROID;

                    case "CENSUSBLOCKTRACT1990CENTROID":
                        return HorizontalMethodDataType.CENSUSBLOCKTRACT1990CENTROID;

                    case "CENSUSBLOCK1990CENTROID":
                        return HorizontalMethodDataType.CENSUSBLOCK1990CENTROID;

                    case "CENSUSOTHER":
                        return HorizontalMethodDataType.CENSUSOTHER;

                    case "CLASSICALSURVEYINGTECHNIQUES":
                        return HorizontalMethodDataType.CLASSICALSURVEYINGTECHNIQUES;

                    case "GPSUNSPECIFIED":
                        return HorizontalMethodDataType.GPSUNSPECIFIED;

                    case "GPSCARRIERPHASEKINEMATICRELATIVEPOSITION":
                        return HorizontalMethodDataType.GPSCARRIERPHASEKINEMATICRELATIVEPOSITION;

                    case "GPSCARRIERPHASESTATICRELATIVEPOSITION":
                        return HorizontalMethodDataType.GPSCARRIERPHASESTATICRELATIVEPOSITION;

                    case "GPSCODEPSEUDORANGEDIFFERENTIAL":
                        return HorizontalMethodDataType.GPSCODEPSEUDORANGEDIFFERENTIAL;

                    case "GPSCODEPSEUDORANGEPRECISEPOSITION":
                        return HorizontalMethodDataType.GPSCODEPSEUDORANGEPRECISEPOSITION;

                    case "GPSCODEPSEUDORANGESTANDARDPOSITIONSAOFF":
                        return HorizontalMethodDataType.GPSCODEPSEUDORANGESTANDARDPOSITIONSAOFF;

                    case "GPSCODEPSEUDORANGESTANDARDPOSITIONSAON":
                        return HorizontalMethodDataType.GPSCODEPSEUDORANGESTANDARDPOSITIONSAON;

                    case "GPSWITHCANADIANACTIVECONTROLSYSTEM":
                        return HorizontalMethodDataType.GPSWITHCANADIANACTIVECONTROLSYSTEM;

                    case "INTERPOLATIONDIGITALMAPSRCETIGER":
                        return HorizontalMethodDataType.INTERPOLATIONDIGITALMAPSRCETIGER;

                    case "INTERPOLATIONSPOT":
                        return HorizontalMethodDataType.INTERPOLATIONSPOT;

                    case "INTERPOLATIONMSS":
                        return HorizontalMethodDataType.INTERPOLATIONMSS;

                    case "INTERPOLATIONTM":
                        return HorizontalMethodDataType.INTERPOLATIONTM;

                    case "INTERPOLATIONMAP":
                        return HorizontalMethodDataType.INTERPOLATIONMAP;

                    case "INTERPOLATIONOTHER":
                        return HorizontalMethodDataType.INTERPOLATIONOTHER;

                    case "INTERPOLATIONPHOTO":
                        return HorizontalMethodDataType.INTERPOLATIONPHOTO;

                    case "INTERPOLATIONSATELLITE":
                        return HorizontalMethodDataType.INTERPOLATIONSATELLITE;

                    case "LORANC":
                        return HorizontalMethodDataType.LORANC;

                    case "PUBLICLANDSURVEYEIGHTHSECTION":
                        return HorizontalMethodDataType.PUBLICLANDSURVEYEIGHTHSECTION;

                    case "PUBLICLANDSURVEYFOOTING":
                        return HorizontalMethodDataType.PUBLICLANDSURVEYFOOTING;

                    case "PUBLICLANDSURVEYSIXTEENTHSECTION":
                        return HorizontalMethodDataType.PUBLICLANDSURVEYSIXTEENTHSECTION;

                    case "PUBLICLANDSURVEYQUARTERSECTION":
                        return HorizontalMethodDataType.PUBLICLANDSURVEYQUARTERSECTION;

                    case "PUBLICLANDSURVEYSECTION":
                        return HorizontalMethodDataType.PUBLICLANDSURVEYSECTION;

                    case "ZIPCODECENTROID":
                        return HorizontalMethodDataType.ZIPCODECENTROID;

                    case "ZIP2CENTROID":
                        return HorizontalMethodDataType.ZIP2CENTROID;

                    case "ZIP4CENTROID":
                        return HorizontalMethodDataType.ZIP4CENTROID;
                    default:
                        return HorizontalMethodDataType.UNKNOWN;

                }
            }

        }


        /// <summary>
        /// Bad Chars for parseEnumValue
        /// </summary>
        private string[] badChars = new string[] { ",", " ", "-", "/", "\\", "(", ")", "~", "!", "@", "#", "$", "%", "^", "&", "*", "+", "<", ">", "?", "|" };


        /// <summary>
        /// parseEnumValue
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string parseEnumValue(object val)
        {
            string newVal = string.Empty;
            if (val != DBNull.Value)
            {
                newVal = val.ToString();

                for (int i = 0; i < badChars.Length; i++)
                {
                    newVal = newVal.Replace(badChars[i], "");
                }
            }
            return newVal.Trim().ToUpper();
        }



        #endregion


    }
}
