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
using System.Collections.Generic;
using System.Text;

namespace Windsor.Node2008.WNOSPlugin.HERE.TIER2
{
    internal class Tier2Transform
    {


        internal static TierIIDataType Transform(Tier2DataSet ds)
        {

            TierIIDataType list = new TierIIDataType();
            List<SubmissionDataType> subList = new List<SubmissionDataType>();
            
            foreach (Tier2DataSet.T2_SUBMISSIONRow subRow in ds.T2_SUBMISSION.Rows)
            {
                SubmissionDataType t2Sub = new SubmissionDataType();

                #region SubmissionDataType 

                t2Sub.SubmissionDate = subRow.SubmissionDate;
                t2Sub.SubmissionIdentifier = subRow.SubmissionIdentifier;
                t2Sub.SubmissionMethod = subRow.SubmissionMethod;
                t2Sub.SubmissionStatus = subRow.SubmissionStatus;
                
                #endregion

                #region TierIIReportDataType List

                //Assume there walways will be one report, otherwise the whole flow makes no sense
                List<TierIIReportDataType> reportList = new List<TierIIReportDataType>();
                
                foreach (Tier2DataSet.T2_REPORTRow rptRow in subRow.GetT2_REPORTRows())
                {

                    Tier2DataSet.T2_FAC_SITERow facRow = null;
                    TierIIReportDataType rptItem = null;

                    //Find one facility and one report
                    Tier2DataSet.T2_FAC_SITERow[] facRows = rptRow.GetT2_FAC_SITERows();
                    if (facRows != null && facRows.Length == 1)
                    {
                        //Facility Item & Report Item exist
                        facRow = facRows[0];
                        rptItem = new TierIIReportDataType();
                         
                        #region ReportIdentityDataType

                        rptItem.ReportIdentity = new ReportIdentityDataType();
                        rptItem.ReportIdentity.ReplacedReportIdentifier = rptRow.ReplacedReportIdentifier;
                        rptItem.ReportIdentity.ReportCreateByName = GetIndividualIdentity(rptRow.ReportCreateByName, null, null);
                        rptItem.ReportIdentity.ReportCreateDate = rptRow.ReportCreateDate;
                        rptItem.ReportIdentity.ReportCreateTime = rptRow.ReportCreateTime;
                        rptItem.ReportIdentity.ReportDueDate = rptRow.ReportDueDate;
                        rptItem.ReportIdentity.ReportIdentifier = new ReportIdentifierDataType();
                        rptItem.ReportIdentity.ReportIdentifier.Value = rptRow.ReportIdentifier;
                        rptItem.ReportIdentity.ReportingPeriodEndDate = rptRow.ReportingPeriodEndDate;
                        rptItem.ReportIdentity.ReportingPeriodStartDate = rptRow.ReportingPeriodStartDate;
                        rptItem.ReportIdentity.ReportReceivedDate = rptRow.ReportReceivedDate;
                        rptItem.ReportIdentity.ReportRecipientName = rptRow.ReportRecipientName;
                        if (!string.IsNullOrEmpty(rptRow.ReportType))
                        {
                            rptItem.ReportIdentity.ReportType = new ReportTypeDataType();
                            rptItem.ReportIdentity.ReportType.ReportTypeCode = rptRow.ReportType;
                        }
                        rptItem.ReportIdentity.RevisionIndicator = rptRow.ReplacedReportIdentifier;
                        
                        #endregion

                        #region FacilityDataType

                        rptItem.TierIIFacility = new TierIIFacilityDataType();

                        #region Facility Simple Types

                        rptItem.TierIIFacility.FacilitySiteName = facRow.FacilitySiteName;
                        rptItem.TierIIFacility.FacilityStatus = facRow.FacilityStatus;
                        rptItem.TierIIFacility.MailingFacilitySiteName = facRow.MailingFacilitySiteName;
                        rptItem.TierIIFacility.ParentCompanyNameNAIndicator = facRow.ParentCompanyNameNAIndicator;
                        rptItem.TierIIFacility.ParentCompanyNameText = facRow.ParentCompanyNameText;
                        rptItem.TierIIFacility.ParentDunBradstreetCode = facRow.ParentDunBradstreetCode;
                        rptItem.TierIIFacility.FireDistrictNameText = facRow.FireDistrict;

                        #region Fac IDs

                        if (!string.IsNullOrEmpty(facRow.FacilitySiteIdentifier))
                        {
                            rptItem.TierIIFacility.FacilityIdentifier = new FacilitySiteIdentifierDataType[1];
                            rptItem.TierIIFacility.FacilityIdentifier[0] = new FacilitySiteIdentifierDataType();
                            rptItem.TierIIFacility.FacilityIdentifier[0].Value = facRow.FacilitySiteIdentifier;
                        }

                        #endregion

                        #region Mailing address

                        rptItem.TierIIFacility.MailingAddress = new MailingAddressDataType1();
                        rptItem.TierIIFacility.MailingAddress.AddressPostalCode = new AddressPostalCodeDataType();
                        rptItem.TierIIFacility.MailingAddress.AddressPostalCode.Value = facRow.MailingAddressPostalCode;

                        rptItem.TierIIFacility.MailingAddress.CountryIdentity = new CountryIdentityDataType();
                        rptItem.TierIIFacility.MailingAddress.CountryIdentity.CountryCode = facRow.MailingCountryCode;
                        rptItem.TierIIFacility.MailingAddress.CountryIdentity.CountryCodeListIdentifier = new CountryCodeListIdentifierDataType();
                        rptItem.TierIIFacility.MailingAddress.CountryIdentity.CountryCodeListIdentifier.Value = facRow.MailingCountryCodeListIdentifier;
                        rptItem.TierIIFacility.MailingAddress.CountryIdentity.CountryName = facRow.MailingCountryName;

                        rptItem.TierIIFacility.MailingAddress.MailingAddressCityName = facRow.MailingAddressCityName;
                        rptItem.TierIIFacility.MailingAddress.MailingAddressText = facRow.MailingAddressText;
                        
                        rptItem.TierIIFacility.MailingAddress.StateIdentity = new StateIdentityDataType();
                        rptItem.TierIIFacility.MailingAddress.StateIdentity.StateCode = facRow.MailingStateCode;
                        rptItem.TierIIFacility.MailingAddress.StateIdentity.StateCodeListIdentifier = new StateCodeListIdentifierDataType();
                        rptItem.TierIIFacility.MailingAddress.StateIdentity.StateCodeListIdentifier.Value = facRow.MailingStateCodeListIdentifier;
                        rptItem.TierIIFacility.MailingAddress.StateIdentity.StateName = facRow.MailingStateName;

                        rptItem.TierIIFacility.MailingAddress.SupplementalAddressText = facRow.MailingSupplementalAddressText;


                        #endregion


                        #region Location Address

                        rptItem.TierIIFacility.LocationAddress = new LocationAddressDataType();
                        rptItem.TierIIFacility.LocationAddress.AddressPostalCode = new AddressPostalCodeDataType();
                        rptItem.TierIIFacility.LocationAddress.AddressPostalCode.Value = facRow.AddressPostalCode;

                        rptItem.TierIIFacility.LocationAddress.CountryIdentity = new CountryIdentityDataType();
                        rptItem.TierIIFacility.LocationAddress.CountryIdentity.CountryCode = facRow.CountryCode;
                        rptItem.TierIIFacility.LocationAddress.CountryIdentity.CountryCodeListIdentifier = new CountryCodeListIdentifierDataType();
                        rptItem.TierIIFacility.LocationAddress.CountryIdentity.CountryCodeListIdentifier.Value = facRow.CountryCodeListIdentifier;
                        rptItem.TierIIFacility.LocationAddress.CountryIdentity.CountryName = facRow.CountryName;

                        rptItem.TierIIFacility.LocationAddress.CountyIdentity = new CountyIdentityDataType();
                        rptItem.TierIIFacility.LocationAddress.CountyIdentity.CountyCode = facRow.CountyCode;
                        rptItem.TierIIFacility.LocationAddress.CountyIdentity.CountyCodeListIdentifier = new CountyCodeListIdentifierDataType();
                        rptItem.TierIIFacility.LocationAddress.CountyIdentity.CountyCodeListIdentifier.Value = facRow.CountyCodeListIdentifier;
                        rptItem.TierIIFacility.LocationAddress.CountyIdentity.CountyName = facRow.CountyName;

                        rptItem.TierIIFacility.LocationAddress.LocalityName = facRow.LocalityName;
                        rptItem.TierIIFacility.LocationAddress.LocationAddressText = facRow.LocationAddressText;
                        rptItem.TierIIFacility.LocationAddress.LocationDescriptionText = facRow.LocationDescriptionText;

                        rptItem.TierIIFacility.LocationAddress.StateIdentity = new StateIdentityDataType();
                        rptItem.TierIIFacility.LocationAddress.StateIdentity.StateCode = facRow.StateCode;
                        rptItem.TierIIFacility.LocationAddress.StateIdentity.StateCodeListIdentifier = new StateCodeListIdentifierDataType();
                        rptItem.TierIIFacility.LocationAddress.StateIdentity.StateCodeListIdentifier.Value = facRow.StateCodeListIdentifier;
                        rptItem.TierIIFacility.LocationAddress.StateIdentity.StateName = facRow.StateName;

                        rptItem.TierIIFacility.LocationAddress.SupplementalLocationText = facRow.SupplementalLocationText;


                        #endregion


                        #endregion

                        #region DUN

                        List<string> dunList = new List<string>();

                        foreach (Tier2DataSet.T2_FAC_DUNDB_IDRow dunRow in facRow.GetT2_FAC_DUNDB_IDRows())
                        {
                            dunList.Add(dunRow.FacilityDunBradstreetCode);
                        }

                        if (dunList.Count > 0)
                        {
                            rptItem.TierIIFacility.FacilityDunBradstreetCode = dunList.ToArray();
                        }

                        #endregion
                        
                        #region NAICS

                        List<NAICSIdentityDataType> naicsList = new List<NAICSIdentityDataType>();

                        foreach (Tier2DataSet.T2_FAC_NAICSRow naicsRow in facRow.GetT2_FAC_NAICSRows())
                        {
                            NAICSIdentityDataType naics = new NAICSIdentityDataType();
                            naics.NAICSCode = naicsRow.NAICSCode;
                            naics.NAICSGroupCode = naicsRow.NAICSGroupCode;
                            naics.NAICSIndustryCode = naicsRow.NAICSIndustryCode;
                            naics.NAICSSectorCode = naicsRow.NAICSSectorCode;
                            naics.NAICSSubsectorCode = naicsRow.NAICSSubsectorCode;
                            naicsList.Add(naics);
                        }

                        if (naicsList.Count > 0)
                        {
                            rptItem.TierIIFacility.NAICSIdentity = naicsList.ToArray();
                        }

                        #endregion

                        #region SIC

                        List<FacilitySICDataType> sicList = new List<FacilitySICDataType>();

                        foreach (Tier2DataSet.T2_FAC_SICRow sicRow in facRow.GetT2_FAC_SICRows())
                        {
                            FacilitySICDataType sic = new FacilitySICDataType();
                            sic.SICCode = sicRow.SICCode;
                            sic.SICPrimaryIndicator = sicRow.SICPrimaryIndicator;
                            sicList.Add(sic);
                        }

                        if (sicList.Count > 0)
                        {
                            rptItem.TierIIFacility.FacilitySIC = sicList.ToArray();
                        }


                        #endregion

                        #region FACGEO

                        Tier2DataSet.T2_FAC_GEORow[] facGeoRows = facRow.GetT2_FAC_GEORows();
                        if (facGeoRows != null && facGeoRows.Length == 1)
                        {
                            Tier2DataSet.T2_FAC_GEORow geoRow = facGeoRows[0];
                            rptItem.TierIIFacility.Geo = new GeographicLocationDescriptionDataType3();

                            rptItem.TierIIFacility.Geo.AMeasure = geoRow.A_MEASURE;
                            rptItem.TierIIFacility.Geo.BMeasure = geoRow.B_MEASURE;

                            rptItem.TierIIFacility.Geo.CoordinateDataSource = new CoordinateDataSourceDataType();
                            rptItem.TierIIFacility.Geo.CoordinateDataSource.CoordinateDataSourceCode = geoRow.COORD_DATA_SRC_CD;
                            rptItem.TierIIFacility.Geo.CoordinateDataSource.CoordinateDataSourceCodeListIdentifier =
                                (CoordinateDataSourceCodeListIdentifierDataType)GetCodeList(geoRow.COORD_DATA_SRC_CDLISTID);
                            rptItem.TierIIFacility.Geo.CoordinateDataSource.CoordinateDataSourceName = geoRow.COORD_DATA_SRC_NM;

                            rptItem.TierIIFacility.Geo.DataCollectionDate = geoRow.DATA_COLL_DATE;

                            //GeographicReferencePoint
                            rptItem.TierIIFacility.Geo.GeographicReferencePoint = GetGeographicReference(
                                geoRow.REF_POINT_CD,
                                geoRow.REF_POINT_CDLISTID,
                                geoRow.REF_POINT_NAME);

                            //GeometricType
                            rptItem.TierIIFacility.Geo.GeometricType = GetGeometricType(geoRow.GEO_TYPE_CD,
                                geoRow.GEO_TYPE_CDLISTID, geoRow.GEO_TYPE_NM);

                            //HorizontalAccuracyMeasure
                            rptItem.TierIIFacility.Geo.HorizontalAccuracyMeasure = GetMeasureDataType(geoRow.HORIZ_ACCUR_MEASURE_VALUE,
                                geoRow.HORIZ_ACCUR_PREC_TXT,
                                geoRow.HORIZ_ACCUR_MEASURE_UNITCD, geoRow.HORIZ_ACCUR_MEASURE_UNITCDLISTID, geoRow.HORIZ_ACCUR_MEASURE_UNIT_NAME,
                                geoRow.HORIZ_ACCUR_RESULT_QUAL_CD, geoRow.HORIZ_ACCUR_RESULT_QUAL_CD, geoRow.HORIZ_ACCUR_RESULT_QUAL_CD);

                            //HorizontalCollectionMethod
                            rptItem.TierIIFacility.Geo.HorizontalCollectionMethod = GetReferenceMethodDataType(geoRow.HORIZ_COLL_METH_DESC,
                                geoRow.HORIZ_COLL_METH_DEVIATIONS, geoRow.HORIZ_COLL_METH_IDCODE, geoRow.HORIZ_COLL_METH_CDLISTID, geoRow.HORIZ_COLL_METH_NAME);

                            //HorizontalReferenceDatum
                            rptItem.TierIIFacility.Geo.HorizontalReferenceDatum = GetGeographicReferenceDatum(
                                geoRow.HORIZ_REF_DATUM_CD,
                                geoRow.HORIZ_REF_DATUM_CDLISTID,
                                geoRow.HORIZ_REF_DATUM_NM);


                            rptItem.TierIIFacility.Geo.LocationCommentsText = geoRow.LOC_COMMENTS;
                            rptItem.TierIIFacility.Geo.SourceMapScaleNumber = geoRow.SRC_MAP_SCALE_NUM;

                            //VerificationMethod
                            rptItem.TierIIFacility.Geo.VerificationMethod = GetReferenceMethodDataType(geoRow.VERIF_METH_DESC,
                                geoRow.VERIF_METH_DEVIATIONS, geoRow.VERIF_METH_IDCODE, geoRow.VERIF_METH_CDLISTID, geoRow.VERIF_METH_NAME);

                            rptItem.TierIIFacility.Geo.VerticalCollectionMethod = GetReferenceMethodDataType(geoRow.VERT_COLL_METH_DESC,
                                geoRow.VERT_COLL_METH_DEVIATIONS, geoRow.VERT_COLL_METH_IDCODE, geoRow.VERT_COLL_METH_CDLISTID, geoRow.VERT_COLL_METH_NAME);

                            rptItem.TierIIFacility.Geo.VerticalMeasure = GetMeasureDataType(geoRow.VERT_MEASURE_VALUE, geoRow.VERT_MEASURE_PREC_TXT,
                                geoRow.VERT_MEASURE_UNITCD, geoRow.VERT_MEASURE_UNITCDLISTID, geoRow.VERT_MEASURE_UNIT_NAME,
                                geoRow.VERT_MEASURE_RESULT_QUAL_CD, geoRow.VERT_MEASURE_RESULT_QUAL_CD, geoRow.VERT_MEASURE_RESULT_QUAL_CD);


                            rptItem.TierIIFacility.Geo.VerticalReferenceDatum = GetGeographicReferenceDatum(geoRow.VERT_REF_DATUM_CD,
                                geoRow.VERT_REF_DATUM_CDLISTID, geoRow.VERT_REF_DATUM_NM);
                        }

                        #endregion

                        #region NPDES

                        List<string> npdsList = new List<string>();

                        foreach (Tier2DataSet.T2_FAC_NPDES_IDRow npdsRow in facRow.GetT2_FAC_NPDES_IDRows())
                        {
                            npdsList.Add(npdsRow.NPDESIdentificationNumber);
                        }

                        if (npdsList.Count > 0)
                        {
                            rptItem.TierIIFacility.NPDESIdentificationNumber = npdsList.ToArray();
                        }


                        #endregion

                        #region RCRA

                        List<string> rcraList = new List<string>();

                        foreach (Tier2DataSet.T2_FAC_RCRA_IDRow rcraRow in facRow.GetT2_FAC_RCRA_IDRows())
                        {
                            rcraList.Add(rcraRow.RCRAIdentificationNumber);
                        }

                        if (rcraList.Count > 0)
                        {
                            rptItem.TierIIFacility.RCRAIdentificationNumber = rcraList.ToArray();
                        }


                        #endregion

                        #region UIC

                        List<string> uicList = new List<string>();

                        foreach (Tier2DataSet.T2_FAC_UIC_IDRow uicRow in facRow.GetT2_FAC_UIC_IDRows())
                        {
                            uicList.Add(uicRow.UICIdentificationNumber);
                        }

                        if (uicList.Count > 0)
                        {
                            rptItem.TierIIFacility.UICIdentificationNumber = uicList.ToArray();
                        }

                        #endregion

                        #region FAC Contact

                        List<FacilityContactDataType> facContactList = new List<FacilityContactDataType>();

                        foreach (Tier2DataSet.T2_FAC_INDRow indRow in facRow.GetT2_FAC_INDRows())
                        {

                            FacilityContactDataType facContact = new FacilityContactDataType();

                            #region IndividualIdentity
                            facContact.IndividualIdentity = GetIndividualIdentity(
                                indRow.IndividualFullName, indRow.IndividualIdentifier, indRow.IndividualTitleText);


                            #region Mailing address

                            facContact.MailingAddress = new MailingAddressDataType();
                            facContact.MailingAddress.AddressPostalCode = new AddressPostalCodeDataType();
                            facContact.MailingAddress.AddressPostalCode.Value = indRow.MailingAddressPostalCode;

                            facContact.MailingAddress.CountryIdentity = new CountryIdentityDataType();
                            facContact.MailingAddress.CountryIdentity.CountryCode = indRow.MailingCountryCode;
                            facContact.MailingAddress.CountryIdentity.CountryCodeListIdentifier = new CountryCodeListIdentifierDataType();
                            facContact.MailingAddress.CountryIdentity.CountryCodeListIdentifier.Value = indRow.MailingCountryCodeListIdentifier;
                            facContact.MailingAddress.CountryIdentity.CountryName = indRow.MailingCountryName;

                            facContact.MailingAddress.MailingAddressCityName = indRow.MailingAddressCityName;
                            facContact.MailingAddress.MailingAddressText = indRow.MailingAddressText;

                            facContact.MailingAddress.StateIdentity = new StateIdentityDataType();
                            facContact.MailingAddress.StateIdentity.StateCode = indRow.MailingStateCode;
                            facContact.MailingAddress.StateIdentity.StateCodeListIdentifier = new StateCodeListIdentifierDataType();
                            facContact.MailingAddress.StateIdentity.StateCodeListIdentifier.Value = indRow.MailingStateCodeListIdentifier;
                            facContact.MailingAddress.StateIdentity.StateName = indRow.MailingStateName;

                            facContact.MailingAddress.SupplementalAddressText = indRow.MailingSupplementalAddressText;


                            #endregion


                            #endregion

                            #region FACINDEMAIL

                            Tier2DataSet.T2_FAC_IND_EMAILRow[] emailRows = indRow.GetT2_FAC_IND_EMAILRows();

                            if (emailRows != null && emailRows.Length > 0)
                            {

                                List<ElectronicAddressDataType> emailList = new List<ElectronicAddressDataType>();

                                foreach (Tier2DataSet.T2_FAC_IND_EMAILRow emailRow in emailRows)
                                {
                                    ElectronicAddressDataType email = new ElectronicAddressDataType();
                                    email.ElectronicAddressText = emailRow.ElectronicAddressText;
                                    email.ElectronicAddressTypeName = emailRow.ElectronicAddressTypeName;
                                    emailList.Add(email);
                                }

                                if (emailList.Count > 0)
                                {
                                    facContact.ElectronicAddress = emailList.ToArray();
                                }

                            }

                            #endregion

                            #region FACINDPHONE

                            Tier2DataSet.T2_FAC_IND_PHONERow[] phoneRows = indRow.GetT2_FAC_IND_PHONERows();

                            if (phoneRows != null && phoneRows.Length > 0)
                            {

                                List<TelephonicDataType> phoneList = new List<TelephonicDataType>();

                                foreach (Tier2DataSet.T2_FAC_IND_PHONERow phoneRow in phoneRows)
                                {
                                    TelephonicDataType phone = new TelephonicDataType();
                                    phone.TelephoneExtensionNumberText = phoneRow.TelephoneExtensionNumberText;
                                    phone.TelephoneNumberText = phoneRow.TelephoneNumberText;
                                    phone.TelephoneNumberTypeName = phoneRow.TelephoneNumberTypeName;
                                    phoneList.Add(phone);
                                }

                                if (phoneList.Count > 0)
                                {
                                    facContact.Telephonic = phoneList.ToArray();
                                }

                            }

                            #endregion

                            #region FACINDTYPE

                            Tier2DataSet.T2_FAC_IND_TYPERow[] indTypeRows = indRow.GetT2_FAC_IND_TYPERows();

                            if (indTypeRows != null && indTypeRows.Length > 0)
                            {

                                List<string> typeList = new List<string>();

                                foreach (Tier2DataSet.T2_FAC_IND_TYPERow indTypeRow in indTypeRows)
                                {
                                    typeList.Add(indTypeRow.ContactType);
                                }

                                if (typeList.Count > 0)
                                {
                                    facContact.ContactType = typeList.ToArray();
                                }

                            }


                            #endregion

                            facContactList.Add(facContact);

                        }

                        rptItem.TierIIFacility.FacilityContact = facContactList.ToArray();

                        #endregion

                        #endregion

                        #region ChemicalInventoryDataType List

                        List<ChemicalInventoryDataType> chemList = new List<ChemicalInventoryDataType>();

                        foreach (Tier2DataSet.T2_CHEM_INVRow chemRow in facRow.GetT2_CHEM_INVRows())
                        {
                            ChemicalInventoryDataType chem = new ChemicalInventoryDataType();

                            //ChemicalIdentification
                            chem.ChemicalIdentification = new ChemicalIndentificationDataType();
                            chem.ChemicalIdentification.CASNumber = chemRow.CASNumber;
                            chem.ChemicalIdentification.ChemicalNameContext = chemRow.ChemicalNameContext;
                            chem.ChemicalIdentification.ChemicalSubstanceSystematicName = chemRow.ChemSubstanceSystematicName;
                            chem.ChemicalIdentification.EPAChemicalIdentifier = chemRow.EPAChemicalIdentifier;
                            chem.ChemicalIdentification.EPAChemicalRegistryName = chemRow.EPAChemicalRegistryName;

                            chem.EHSIndicator = chemRow.EHSIndicator;
                            chem.TradeSecretIndicator = chemRow.TradeSecretIndicator;


                            #region Inventory Details

                            List<ChemicalInventoryDetailsDataType> chemDetailList = new List<ChemicalInventoryDetailsDataType>();

                            foreach (Tier2DataSet.T2_CHEM_INV_DTLSRow chemDetailRow in chemRow.GetT2_CHEM_INV_DTLSRows())
                            {
                                ChemicalInventoryDetailsDataType chemDetail = new ChemicalInventoryDetailsDataType();

                                chemDetail.AverageCode = chemDetailRow.AverageCode;
                                chemDetail.AverageDailyAmount = chemDetailRow.AverageDailyAmount;
                                chemDetail.MaximumCode = chemDetailRow.MaximumCode;
                                chemDetail.MaximumDailyAmount = chemDetailRow.MaximumDailyAmount;
                                chemDetail.NumberOfDaysOnsite = chemDetailRow.NumberOfDaysOnsite;

                                chemDetailList.Add(chemDetail);
                            }

                            if (chemDetailList.Count > 0)
                            {
                                chem.ChemicalInventoryDetails = chemDetailList.ToArray();
                            }

                            #endregion



                            #region Inventory ChemicalPhysicalState

                            List<string> chemPhysList = new List<string>();

                            foreach (Tier2DataSet.T2_CHEM_INV_PHYSRow chemPhysRow in chemRow.GetT2_CHEM_INV_PHYSRows())
                            {
                                chemPhysList.Add(chemPhysRow.ChemicalPhysicalState);
                            }

                            if (chemPhysList.Count > 0)
                            {
                                chem.ChemicalPhysicalState = chemPhysList.ToArray();
                            }

                            #endregion



                            #region ChemicalStorageLocations

                            List<ChemicalStorageLocationDataType> chemStoreList = new List<ChemicalStorageLocationDataType>();

                            foreach (Tier2DataSet.T2_CHEM_LOCRow chemStoreRow in chemRow.GetT2_CHEM_LOCRows())
                            {
                                ChemicalStorageLocationDataType chemStoreLoc = new ChemicalStorageLocationDataType();

                                chemStoreLoc.ConfidentialLocationIndicator = chemStoreRow.ConfidentialLocationIndicator;
                                chemStoreLoc.MaximumAmountAtLocation = chemStoreRow.MaximumAmountAtLocation;
                                chemStoreLoc.MeasurementUnit = chemStoreRow.MeasurementUnit;
                                chemStoreLoc.StorageLocationDescription = chemStoreRow.StorageLocDescription;
                                chemStoreLoc.StorageLocationPressureCode = chemStoreRow.StorageLocPressureCode;
                                chemStoreLoc.StorageLocationPressureDescription = chemStoreRow.StorageLocPressureDesc;
                                chemStoreLoc.StorageLocationTemperatureCode = chemStoreRow.StorageLocTemperatureCode;
                                chemStoreLoc.StorageLocationTemperatureDescription = chemStoreRow.StorageLocTemperatureDesc;
                                chemStoreLoc.StorageTypeCode = chemStoreRow.StorageTypeCode;
                                chemStoreLoc.StorageTypeDescription = chemStoreRow.StorageTypeDescription;

                                chemStoreList.Add(chemStoreLoc);
                            }

                            if (chemStoreList.Count > 0)
                            {
                                chem.ChemicalStorageLocations = chemStoreList.ToArray();
                            }

                            #endregion




                            #region HazardType

                            List<string> hazTypeList = new List<string>();

                            foreach (Tier2DataSet.T2_CHEM_INV_HAZRow hazTypeRow in chemRow.GetT2_CHEM_INV_HAZRows())
                            {
                                hazTypeList.Add(hazTypeRow.HazardType);
                            }

                            if (hazTypeList.Count > 0)
                            {
                                chem.HazardType = hazTypeList.ToArray();
                            }

                            #endregion




                            #region HealthEffects

                            List<string> healthEffList = new List<string>();

                            foreach (Tier2DataSet.T2_CHEM_INV_HLTHRow hlthEffRow in chemRow.GetT2_CHEM_INV_HLTHRows())
                            {
                                healthEffList.Add(hlthEffRow.HealthEffects);
                            }

                            if (healthEffList.Count > 0)
                            {
                                chem.HealthEffects = healthEffList.ToArray();
                            }

                            #endregion







                            #region MixtureComponents

                            List<MixtureComponentsDataType> mixComList = new List<MixtureComponentsDataType>();

                            foreach (Tier2DataSet.T2_CHEM_MIXRow chemMixRow in chemRow.GetT2_CHEM_MIXRows())
                            {
                                MixtureComponentsDataType chemMixLoc = new MixtureComponentsDataType();

                                chemMixLoc.CASNumber = chemMixRow.CASNumber;
                                chemMixLoc.Component = chemMixRow.Component;
                                chemMixLoc.ComponentPercentage = chemMixRow.ComponentPercentage;
                                chemMixLoc.WeightOrVolume = chemMixRow.WeightOrVolume;
                                chemMixLoc.EHSIndicator = chemMixRow.EHSIndicator;

                                mixComList.Add(chemMixLoc);
                            }

                            if (mixComList.Count > 0)
                            {
                                chem.MixtureComponents = mixComList.ToArray();
                            }

                            #endregion




                            
                            chemList.Add(chem);
                        }

                        rptItem.ChemicalInventory = chemList.ToArray();

                        #endregion

                        //Add item to list
                        reportList.Add(rptItem);

                    } //end for each site

                }

                t2Sub.TierIIReport = reportList.ToArray();

                #endregion

                //Add the submission to the list
                subList.Add(t2Sub);

            }

            list.Submission = subList.ToArray();
            
            return list;
        }


        private static MeasureUnitDataType GetMeasureUnitDataType(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            else
            {
                MeasureUnitDataType obj = new MeasureUnitDataType();
                obj.MeasureUnitName = name;
                return obj;
            }
        }

        private static CodeListIdentifierDataType GetCodeList(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            else
            {
                CodeListIdentifierDataType obj = new CodeListIdentifierDataType();
                obj.Value = value;
                return obj;
            }
        }


        private static ReferenceMethodDataType GetReferenceMethodDataType(string desc, string deviation, string idCode, string methodCodeList, string name)  
        {
            if (string.IsNullOrEmpty(desc) && string.IsNullOrEmpty(idCode))
            {
                return null;
            }
            else
            {
                ReferenceMethodDataType obj = new ReferenceMethodDataType();
                obj.MethodDescriptionText = desc;
                obj.MethodDeviationsText = deviation;
                obj.MethodIdentifierCode = idCode;
                obj.MethodIdentifierCodeListIdentifier = (MethodIdentifierCodeListIdentifierDataType)GetCodeList(methodCodeList);
                obj.MethodName = name;
                return obj;
            }
        }


        private static GeographicReferenceDatumDataType GetGeographicReferenceDatum(string code, string codeListId, string name)
        {
            if (string.IsNullOrEmpty(code) && string.IsNullOrEmpty(name))
            {
                return null;
            }
            else
            {
                GeographicReferenceDatumDataType obj = new GeographicReferenceDatumDataType();
                obj.GeographicReferenceDatumCode = code;
                obj.GeographicReferenceDatumCodeListIdentifier = (GeographicReferenceDatumCodeListIdentifierDataType)GetCodeList(codeListId);
                obj.GeographicReferenceDatumName = name;
                return obj;
            }
        }

        private static GeographicReferencePointDataType GetGeographicReference(string code, string codeListId, string name)
        {
            if (string.IsNullOrEmpty(code) && string.IsNullOrEmpty(name))
            {
                return null;
            }
            else
            {
                GeographicReferencePointDataType obj = new GeographicReferencePointDataType();
                obj.GeographicReferencePointCode = code;
                obj.ReferencePointCodeListIdentifier = (ReferencePointCodeListIdentifierDataType)GetCodeList(codeListId);
                obj.GeographicReferencePointName = name;
                return obj;
            }
        }


        private static GeometricTypeDataType GetGeometricType(string code, string codeListId, string name)
        {
            if (string.IsNullOrEmpty(code) && string.IsNullOrEmpty(name))
            {
                return null;
            }
            else
            {
                GeometricTypeDataType obj = new GeometricTypeDataType();
                obj.GeometricTypeCode = code;
                obj.GeometricTypeCodeListIdentifier = (GeometricTypeCodeListIdentifierDataType)GetCodeList(codeListId);
                obj.GeometricTypeName = name;
                return obj;
            }
        }

        private static IndividualIdentityDataType GetIndividualIdentity(string fullName, string id, string title)
        {
            if (string.IsNullOrEmpty(fullName) && string.IsNullOrEmpty(id) && string.IsNullOrEmpty(title))
            {
                return null;
            }
            else
            {
                IndividualIdentityDataType obj = new IndividualIdentityDataType();
                
                obj.IndividualFullName = fullName;
                obj.IndividualIdentifier = new IndividualIdentifierDataType();
                obj.IndividualIdentifier.Value = id;
                obj.IndividualTitleText = title;
                
                return obj;
            }
        }


        private static MeasureDataType GetMeasureDataType(string value, string precTxt, 
            string unitCode, string unitCodeId, string unitName,
            string qualCode, string qualCodeId, string qualName)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            else
            {
                MeasureDataType obj = new MeasureDataType();

                obj.MeasureValue = value;
                obj.MeasurePrecisionText = precTxt;

                if (!string.IsNullOrEmpty(unitCode))
                {
                    obj.MeasureUnit = new MeasureUnitDataType();
                    obj.MeasureUnit.MeasureUnitCode = unitCode;
                    obj.MeasureUnit.MeasureUnitCodeListIdentifier = (MeasureUnitCodeListIdentifierDataType)GetCodeList(unitCodeId);
                    obj.MeasureUnit.MeasureUnitName = unitName;
                }

                if (!string.IsNullOrEmpty(qualCode))
                {
                    obj.ResultQualifier = new ResultQualifierDataType();
                    obj.ResultQualifier.ResultQualifierCode = qualCode;
                    obj.ResultQualifier.ResultQualifierCodeListIdentifier = (ResultQualifierCodeListIdentifierDataType)GetCodeList(qualCodeId);
                    obj.ResultQualifier.ResultQualifierName = qualName;
                }

                return obj;
            }


        }


    }
}
