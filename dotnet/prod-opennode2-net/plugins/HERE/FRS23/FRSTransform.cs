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
using System.Data;

namespace Windsor.Node2008.WNOSPlugin.HERE.FRS23
{
    internal class FRSTransform
    {

        internal static FacilitySiteList Transform(FRSDataSet ds)
        {

            FacilitySiteList list = new FacilitySiteList();
            list.FacilitySiteAllDetails = new List<FacilitySiteAllDetails>();

            foreach (FRSDataSet.FRS_FACRow facRow in ds.FRS_FAC.Rows)
            {
                #region Facilty Level Properties
                FacilitySiteAllDetails fsDetail = new FacilitySiteAllDetails();
                fsDetail.LastReportedDateSpecified = !string.IsNullOrEmpty(facRow.REPORTED_DATE);
                fsDetail.LastReportedDate = facRow.REPORTED_DATE;
                fsDetail.SourceOfData = facRow.DATA_SRC_NM;
                fsDetail.StateFacilityIdentifier = facRow.ST_FAC_IND;
                fsDetail.StateFacilitySystemAcronymName = facRow.ST_FAC_SYS_AC;
                //list.FacilitySiteAllDetails.Add(fsDetail);
                #endregion

                #region FacilitySite
                FacilitySiteDataType fs = new FacilitySiteDataType();
                fs.FacilityRegistryIdentifier = facRow.FAC_REG_IND;
                fs.FacilitySiteName = facRow.FAC_SITENM;
                fs.FacilitySiteTypeName = facRow.FAC_SITETYPE_NM;
                fs.FederalFacilityIndicator = facRow.FED_FAC;
                fs.TribalLandIndicator = facRow.TRIB_LAND;
                fs.TribalLandName = facRow.TRIB_LAND_NM;
                fs.CongressionalDistrictNumber = facRow.CONG_DIST_NUM;
                fs.LegislativeDistrictNumber = facRow.LEG_DIST_NUM;
                fs.HUCCode = facRow.HUC_CD;
                fsDetail.FacilitySite = fs;
                #endregion

                #region LocationAddress
                LocationAddressDataType fsAddress = new LocationAddressDataType();
                fsAddress.LocationAddressText = facRow.LOC_ADD;
                fsAddress.SupplementalLocationText = facRow.SUPPLEM_LOC;
                fsAddress.LocalityName = facRow.LOCAL_NM;
                fsAddress.CountyStateFIPSCode = facRow.CNTY_ST_FIPS_CD;
                fsAddress.CountyName = facRow.CNTY_NM;
                fsAddress.StateUSPSCode = facRow.ST_CD;
                fsAddress.StateName = facRow.ST_NM;
                fsAddress.CountryName = facRow.CO_NM;
                fsAddress.LocationZIPCode = facRow.LOC_ZIP_CD;
                fsAddress.LocationDescriptionText = facRow.LOC_DESC;
                fsDetail.LocationAddress = fsAddress;
                #endregion

                #region EnvironmentalInterest
                foreach (FRSDataSet.FRS_EIRow eiRow in facRow.GetFRS_EIRows())
                {
                    if (fsDetail.EnvironmentalInterestDetails == null)
                    {
                        fsDetail.EnvironmentalInterestDetails = new List<EnvironmentalInterest>();
                    }
                    EnvironmentalInterest envDataType = new EnvironmentalInterest();
                    envDataType.InformationSystemAcronymName = eiRow.INF_SYS_AC;
                    envDataType.InformationSystemIdentifier = eiRow.INF_SYS_IND;
                    envDataType.EnvironmentalInterestTypeText = eiRow.ENV_INT_TYPE;
                    envDataType.FederalStateInterestIndicator = eiRow.FED_ST_INT;
                    envDataType.EnvironmentalInterestStartDate = eiRow.ENV_INT_START_DATE;
                    envDataType.EnvironmentalInterestStartDateSpecified = !string.IsNullOrEmpty(eiRow.ENV_INT_START_DATE);
                    envDataType.InterestStartDateQualifierText = eiRow.INT_START_DATE_QUAL;
                    envDataType.EnvironmentalInterestEndDate = eiRow.ENV_INT_END_DATE;
                    envDataType.EnvironmentalInterestEndDateSpecified = !string.IsNullOrEmpty(eiRow.ENV_INT_END_DATE);
                    envDataType.InterestEndDateQualifierText = eiRow.INT_END_DATE_QUAL;

                    #region EI Individual
                    foreach (FRSDataSet.FRS_EI_INDRow invRow in eiRow.GetFRS_EI_INDRows())
                    {
                        if (envDataType.IndividualDetails == null)
                        {
                            envDataType.IndividualDetails = new List<IndividualDetails>();
                        }
                        IndividualDetails indDtl = new IndividualDetails();

                        indDtl.Affiliation = new AffiliationDataType();
                        indDtl.Affiliation.AffiliationTypeText = invRow.AFFIL_TYPE;
                        indDtl.Affiliation.AffiliationStartDate = invRow.AFFIL_START_DATE;
                        indDtl.Affiliation.AffiliationStartDateSpecified = !string.IsNullOrEmpty(invRow.AFFIL_START_DATE);
                        indDtl.Affiliation.AffiliationEndDate = invRow.AFFIL_END_DATE;
                        indDtl.Affiliation.AffiliationEndDateSpecified = !string.IsNullOrEmpty(invRow.AFFIL_END_DATE);

                        indDtl.PhoneFaxEmail = new PhoneFaxEmailDataType();
                        indDtl.PhoneFaxEmail.EmailAddressText = invRow.EMAIL_ADD;
                        indDtl.PhoneFaxEmail.TelephoneNumber = invRow.TEL_NUM;
                        indDtl.PhoneFaxEmail.PhoneExtension = invRow.PH_EXT;
                        indDtl.PhoneFaxEmail.FaxNumber = invRow.FAX_NUM;
                        indDtl.PhoneFaxEmail.AlternateTelephoneNumber = invRow.ALT_TEL_NUM;

                        indDtl.Individual = new IndividualDataType();
                        indDtl.Individual.IndividualFullName = invRow.IND_FULL_NM;
                        indDtl.Individual.IndividualTitleText = invRow.IND_TITLE;

                        indDtl.MailingAddress = new MailingAddressDataType();
                        indDtl.MailingAddress.MailingAddressText = invRow.MAIL_ADD;
                        indDtl.MailingAddress.SupplementalAddressText = invRow.SUPPLEM_ADD;
                        indDtl.MailingAddress.MailingAddressCityName = invRow.MAIL_ADD_CITY_NM;
                        indDtl.MailingAddress.MailingAddressStateUSPSCode = invRow.MAIL_ADD_ST_CD;
                        indDtl.MailingAddress.MailingAddressStateName = invRow.MAIL_ADD_ST_NM;
                        indDtl.MailingAddress.MailingAddressCountryName = invRow.MAIL_ADD_CO_NM;
                        indDtl.MailingAddress.MailingAddressZIPCode = invRow.MAIL_ADD_ZIP_CD;

                        envDataType.IndividualDetails.Add(indDtl);
                    }
                    #endregion

                    #region EI Organization
                    foreach (FRSDataSet.FRS_EI_ORGRow orgRow in eiRow.GetFRS_EI_ORGRows())
                    {
                        if (envDataType.OrganizationDetails == null)
                        {
                            envDataType.OrganizationDetails = new List<OrganizationDetails>();
                        }

                        OrganizationDetails orgDtl = new OrganizationDetails();

                        orgDtl.Affiliation = new AffiliationDataType();
                        orgDtl.Affiliation.AffiliationTypeText = orgRow.AFFIL_TYPE;
                        orgDtl.Affiliation.AffiliationStartDate = orgRow.AFFIL_START_DATE;
                        orgDtl.Affiliation.AffiliationStartDateSpecified = !string.IsNullOrEmpty(orgRow.AFFIL_START_DATE);
                        orgDtl.Affiliation.AffiliationEndDate = orgRow.AFFIL_END_DATE;
                        orgDtl.Affiliation.AffiliationEndDateSpecified = !string.IsNullOrEmpty(orgRow.AFFIL_END_DATE);

                        orgDtl.PhoneFaxEmail = new PhoneFaxEmailDataType();
                        orgDtl.PhoneFaxEmail.EmailAddressText = orgRow.EMAIL_ADD;
                        orgDtl.PhoneFaxEmail.TelephoneNumber = orgRow.TEL_NUM;
                        orgDtl.PhoneFaxEmail.PhoneExtension = orgRow.PH_EXT;
                        orgDtl.PhoneFaxEmail.FaxNumber = orgRow.FAX_NUM;
                        orgDtl.PhoneFaxEmail.AlternateTelephoneNumber = orgRow.ALT_TEL_NUM;

                        orgDtl.Organization = new OrganizationDataType();
                        orgDtl.Organization.OrganizationFormalName = orgRow.ORG_FORMAL_NM;
                        orgDtl.Organization.OrganizationDUNSNumber = orgRow.ORG_DUNS_NUM;
                        orgDtl.Organization.OrganizationTypeText = orgRow.ORG_TYPE;
                        orgDtl.Organization.EmployerIdentifier = orgRow.EMPLOYER_IND;
                        orgDtl.Organization.StateBusinessIdentifier = orgRow.ST_BUSINESS_IND;
                        orgDtl.Organization.UltimateParentName = orgRow.ULT_PARENT_NM;
                        orgDtl.Organization.UltimateParentDUNSNumber = orgRow.ULT_PARENT_DUNS_NUM;

                        orgDtl.MailingAddress = new MailingAddressDataType();
                        orgDtl.MailingAddress.MailingAddressText = orgRow.MAIL_ADD;
                        orgDtl.MailingAddress.SupplementalAddressText = orgRow.SUPPLEM_ADD;
                        orgDtl.MailingAddress.MailingAddressCityName = orgRow.MAIL_ADD_CITY_NM;
                        orgDtl.MailingAddress.MailingAddressStateUSPSCode = orgRow.MAIL_ADD_ST_CD;
                        orgDtl.MailingAddress.MailingAddressStateName = orgRow.MAIL_ADD_ST_NM;
                        orgDtl.MailingAddress.MailingAddressCountryName = orgRow.MAIL_ADD_CO_NM;
                        orgDtl.MailingAddress.MailingAddressZIPCode = orgRow.MAIL_ADD_ZIP_CD;

                        envDataType.OrganizationDetails.Add(orgDtl);
                    }
                    #endregion

                    #region EI SICCode
                    foreach (FRSDataSet.FRS_EI_SICRow sicRow in eiRow.GetFRS_EI_SICRows())
                    {
                        if (envDataType.SICCodeDetails == null)
                        {
                            envDataType.SICCodeDetails = new List<SICCodeDetails>();
                        }

                        SICCodeDetails sicDtl = new SICCodeDetails();
                        sicDtl.SICCode = sicRow.SIC_CD;
                        sicDtl.SICPrimaryIndicator = sicRow.SIC_PRIM_IND;

                        envDataType.SICCodeDetails.Add(sicDtl);
                    }
                    #endregion

                    #region EI NAICSCode
                    foreach (FRSDataSet.FRS_EI_NAICSRow neicsRow in eiRow.GetFRS_EI_NAICSRows())
                    {
                        if (envDataType.NAICSCodeDetails == null)
                        {
                            envDataType.NAICSCodeDetails = new List<NAICSCodeDetails>();
                        }

                        //Create an instance of the complex property
                        NAICSCodeDetails naicsDtl = new NAICSCodeDetails();
                        naicsDtl.NAICSCode = neicsRow.NAICS_CD;
                        naicsDtl.NAICSPrimaryIndicator = neicsRow.NAICS_PRIM_IND;

                        envDataType.NAICSCodeDetails.Add(naicsDtl);
                    }
                    #endregion

                    fsDetail.EnvironmentalInterestDetails.Add(envDataType);
                }

                #endregion

                #region Individual
                foreach (FRSDataSet.FRS_FAC_INDRow invRow in facRow.GetFRS_FAC_INDRows())
                {
                    if (fsDetail.IndividualDetails == null)
                    {
                        fsDetail.IndividualDetails = new List<IndividualDetails>();
                    }
                    IndividualDetails indDtl = new IndividualDetails();

                    indDtl.Affiliation = new AffiliationDataType();
                    indDtl.Affiliation.AffiliationTypeText = invRow.AFFIL_TYPE;
                    indDtl.Affiliation.AffiliationStartDate = invRow.AFFIL_START_DATE;
                    indDtl.Affiliation.AffiliationStartDateSpecified = !string.IsNullOrEmpty(invRow.AFFIL_START_DATE);
                    indDtl.Affiliation.AffiliationEndDate = invRow.AFFIL_END_DATE;
                    indDtl.Affiliation.AffiliationEndDateSpecified = !string.IsNullOrEmpty(invRow.AFFIL_END_DATE);

                    indDtl.PhoneFaxEmail = new PhoneFaxEmailDataType();
                    indDtl.PhoneFaxEmail.EmailAddressText = invRow.EMAIL_ADD;
                    indDtl.PhoneFaxEmail.TelephoneNumber = invRow.TEL_NUM;
                    indDtl.PhoneFaxEmail.PhoneExtension = invRow.PH_EXT;
                    indDtl.PhoneFaxEmail.FaxNumber = invRow.FAX_NUM;
                    indDtl.PhoneFaxEmail.AlternateTelephoneNumber = invRow.ALT_TEL_NUM;

                    indDtl.Individual = new IndividualDataType();
                    indDtl.Individual.IndividualFullName = invRow.IND_FULL_NM;
                    indDtl.Individual.IndividualTitleText = invRow.IND_TITLE;

                    indDtl.MailingAddress = new MailingAddressDataType();
                    indDtl.MailingAddress.MailingAddressText = invRow.MAIL_ADD;
                    indDtl.MailingAddress.SupplementalAddressText = invRow.SUPPLEM_ADD;
                    indDtl.MailingAddress.MailingAddressCityName = invRow.MAIL_ADD_CITY_NM;
                    indDtl.MailingAddress.MailingAddressStateUSPSCode = invRow.MAIL_ADD_ST_CD;
                    indDtl.MailingAddress.MailingAddressStateName = invRow.MAIL_ADD_ST_NM;
                    indDtl.MailingAddress.MailingAddressCountryName = invRow.MAIL_ADD_CO_NM;
                    indDtl.MailingAddress.MailingAddressZIPCode = invRow.MAIL_ADD_ZIP_CD;

                    fsDetail.IndividualDetails.Add(indDtl);
                }
                #endregion

                #region Organization
                foreach (FRSDataSet.FRS_FAC_ORGRow orgRow in facRow.GetFRS_FAC_ORGRows())
                {
                    if (fsDetail.OrganizationDetails == null)
                    {
                        fsDetail.OrganizationDetails = new List<OrganizationDetails>();
                    }

                    OrganizationDetails orgDtl = new OrganizationDetails();

                    orgDtl.Affiliation = new AffiliationDataType();
                    orgDtl.Affiliation.AffiliationTypeText = orgRow.AFFIL_TYPE;
                    orgDtl.Affiliation.AffiliationStartDate = orgRow.AFFIL_START_DATE;
                    orgDtl.Affiliation.AffiliationStartDateSpecified = !string.IsNullOrEmpty(orgRow.AFFIL_START_DATE);
                    orgDtl.Affiliation.AffiliationEndDate = orgRow.AFFIL_END_DATE;
                    orgDtl.Affiliation.AffiliationEndDateSpecified = !string.IsNullOrEmpty(orgRow.AFFIL_END_DATE);

                    orgDtl.PhoneFaxEmail = new PhoneFaxEmailDataType();
                    orgDtl.PhoneFaxEmail.EmailAddressText = orgRow.EMAIL_ADD;
                    orgDtl.PhoneFaxEmail.TelephoneNumber = orgRow.TEL_NUM;
                    orgDtl.PhoneFaxEmail.PhoneExtension = orgRow.PH_EXT;
                    orgDtl.PhoneFaxEmail.FaxNumber = orgRow.FAX_NUM;
                    orgDtl.PhoneFaxEmail.AlternateTelephoneNumber = orgRow.ALT_TEL_NUM;

                    orgDtl.Organization = new OrganizationDataType();
                    orgDtl.Organization.OrganizationFormalName = orgRow.ORG_FORMAL_NM;
                    orgDtl.Organization.OrganizationDUNSNumber = orgRow.ORG_DUNS_NUM;
                    orgDtl.Organization.OrganizationTypeText = orgRow.ORG_TYPE;
                    orgDtl.Organization.EmployerIdentifier = orgRow.EMPLOYER_IND;
                    orgDtl.Organization.StateBusinessIdentifier = orgRow.ST_BUSINESS_IND;
                    orgDtl.Organization.UltimateParentName = orgRow.ULT_PARENT_NM;
                    orgDtl.Organization.UltimateParentDUNSNumber = orgRow.ULT_PARENT_DUNS_NUM;

                    orgDtl.MailingAddress = new MailingAddressDataType();
                    orgDtl.MailingAddress.MailingAddressText = orgRow.MAIL_ADD;
                    orgDtl.MailingAddress.SupplementalAddressText = orgRow.SUPPLEM_ADD;
                    orgDtl.MailingAddress.MailingAddressCityName = orgRow.MAIL_ADD_CITY_NM;
                    orgDtl.MailingAddress.MailingAddressStateUSPSCode = orgRow.MAIL_ADD_ST_CD;
                    orgDtl.MailingAddress.MailingAddressStateName = orgRow.MAIL_ADD_ST_NM;
                    orgDtl.MailingAddress.MailingAddressCountryName = orgRow.MAIL_ADD_CO_NM;
                    orgDtl.MailingAddress.MailingAddressZIPCode = orgRow.MAIL_ADD_ZIP_CD;

                    fsDetail.OrganizationDetails.Add(orgDtl);
                }
                #endregion

                #region SICCode
                foreach (FRSDataSet.FRS_FAC_SICRow sicRow in facRow.GetFRS_FAC_SICRows())
                {
                    if (fsDetail.SICCodeDetails == null)
                    {
                        fsDetail.SICCodeDetails = new List<SICCodeDetails>();
                    }

                    SICCodeDetails sicDtl = new SICCodeDetails();
                    sicDtl.SICCode = sicRow.SIC_CD;
                    sicDtl.SICPrimaryIndicator = sicRow.SIC_PRIM_IND;

                    fsDetail.SICCodeDetails.Add(sicDtl);
                }
                #endregion

                #region NAICSCode
                foreach (FRSDataSet.FRS_FAC_NAICSRow neicsRow in facRow.GetFRS_FAC_NAICSRows())
                {
                    if (fsDetail.NAICSCodeDetails == null)
                    {
                        fsDetail.NAICSCodeDetails = new List<NAICSCodeDetails>();
                    }

                        //Create an instance of the complex property
                        NAICSCodeDetails naicsDtl = new NAICSCodeDetails();
                        naicsDtl.NAICSCode = neicsRow.NAICS_CD;
                        naicsDtl.NAICSPrimaryIndicator = neicsRow.NAICS_PRIM_IND;

                        fsDetail.NAICSCodeDetails.Add(naicsDtl);
                }
                #endregion

                #region AlternateName
                foreach (FRSDataSet.FRS_ALT_NMRow altNameRow in facRow.GetFRS_ALT_NMRows())
                {
                    fsDetail.AlternativeNameInfo = new AltNameDataType();
                    fsDetail.AlternativeNameInfo.AlternativeName = altNameRow.ALT_NM;
                    fsDetail.AlternativeNameInfo.AlternativeNameTypeText = altNameRow.ALT_NAME_TYPE;
                    break;
                }
                #endregion

                #region MailingAddress
                foreach (FRSDataSet.FRS_ADDRow addRow in facRow.GetFRS_ADDRows())
                {
                    fsDetail.MailingAddress = new MailingAddressDataType();
                    fsDetail.MailingAddress.MailingAddressText = addRow.MAIL_ADD;
                    fsDetail.MailingAddress.SupplementalAddressText = addRow.SUPPLEM_ADD;
                    fsDetail.MailingAddress.MailingAddressCityName = addRow.MAIL_ADD_CITY_NM;
                    fsDetail.MailingAddress.MailingAddressStateUSPSCode = addRow.MAIL_ADD_ST_CD;
                    fsDetail.MailingAddress.MailingAddressStateName = addRow.MAIL_ADD_ST_NM;
                    fsDetail.MailingAddress.MailingAddressCountryName = addRow.MAIL_ADD_CO_NM;
                    fsDetail.MailingAddress.MailingAddressZIPCode = addRow.MAIL_ADD_ZIP_CD;
                    break;
                }
                #endregion

                #region GeographicCoordinates
                foreach (FRSDataSet.FRS_GEORow geoRow in facRow.GetFRS_GEORows())
                {
                    fsDetail.GeographicCoordinates = new GeographicCoordinateDataType();
                    fsDetail.GeographicCoordinates.LatitudeMeasure = geoRow.LAT_MEASURE;
                    fsDetail.GeographicCoordinates.LongitudeMeasure = geoRow.LON_MEASURE;
                    fsDetail.GeographicCoordinates.HorizontalAccuracyMeasure = geoRow.HORIZ_ACCUR_MEASURE;
                    fsDetail.GeographicCoordinates.HorizontalCollectionMethodTextSpecified = !string.IsNullOrEmpty(geoRow.HORIZ_COLL_METH);
                    fsDetail.GeographicCoordinates.HorizontalCollectionMethodText = geoRow.HORIZ_COLL_METH;
                    fsDetail.GeographicCoordinates.HorizontalReferenceDatumNameSpecified = !string.IsNullOrEmpty(geoRow.HORIZ_REF_DATUM_NM);
                    fsDetail.GeographicCoordinates.HorizontalReferenceDatumName = geoRow.HORIZ_REF_DATUM_NM;
                    fsDetail.GeographicCoordinates.SourceMapScaleNumber = geoRow.SRC_MAP_SCALE_NUM;
                    fsDetail.GeographicCoordinates.ReferencePointTextSpecified = !string.IsNullOrEmpty(geoRow.REF_POINT);
                    fsDetail.GeographicCoordinates.ReferencePointText = geoRow.REF_POINT;
                    fsDetail.GeographicCoordinates.DataCollectionDateSpecified = !string.IsNullOrEmpty(geoRow.DATA_COLL_DATE);
                    fsDetail.GeographicCoordinates.DataCollectionDate = geoRow.DATA_COLL_DATE;
                    fsDetail.GeographicCoordinates.GeometricTypeName = geoRow.GEO_TYPE_NM;
                    fsDetail.GeographicCoordinates.GeometricTypeNameSpecified = string.IsNullOrEmpty(geoRow.GEO_TYPE_NM);
                    fsDetail.GeographicCoordinates.LocationCommentsText = geoRow.LOC_COMMENTS;
                    fsDetail.GeographicCoordinates.VerticalCollectionMethodTextSpecified = !string.IsNullOrEmpty(geoRow.VERT_COLL_METH);
                    fsDetail.GeographicCoordinates.VerticalCollectionMethodText = geoRow.VERT_COLL_METH;
                    fsDetail.GeographicCoordinates.VerticalMeasure = geoRow.VERT_MEASURE;
                    fsDetail.GeographicCoordinates.VerticalAccuracyMeasure = geoRow.VERT_ACCUR_MEASURE;
                    fsDetail.GeographicCoordinates.VerticalReferenceDatumNameSpecified = !string.IsNullOrEmpty(geoRow.VERT_REF_DATUM_NM);
                    fsDetail.GeographicCoordinates.VerticalReferenceDatumName = geoRow.VERT_REF_DATUM_NM;
                    fsDetail.GeographicCoordinates.DataSourceName = geoRow.DATA_SRC_NM;
                    fsDetail.GeographicCoordinates.CoordinateDataSourceName = geoRow.COORD_DATA_SRC_NM;
                    fsDetail.GeographicCoordinates.SubEntityIdentifier = geoRow.SUB_ENT_IND;
                    fsDetail.GeographicCoordinates.SubEntityTypeNameSpecified = !string.IsNullOrEmpty(geoRow.SUB_ENT_TYPE_NM);
                    fsDetail.GeographicCoordinates.SubEntityTypeName = geoRow.SUB_ENT_TYPE_NM;
                    break;
                }
                #endregion

                //Keep on the end
                list.FacilitySiteAllDetails.Add(fsDetail);
                
            }

            return list;
        }



        internal static FacilitySiteList Transform(Dictionary<string, string> idList,
            string sourceOfData)
        {

            FacilitySiteList list = new FacilitySiteList();
            list.FacilitySiteAllDetails = new List<FacilitySiteAllDetails>();

            foreach (KeyValuePair<string, string> facRow in idList)
            {

                FacilitySiteAllDetails fsDetail = new FacilitySiteAllDetails();
                
                fsDetail.LastReportedDateSpecified = true;
                fsDetail.LastReportedDate = facRow.Value;
                fsDetail.SourceOfData = sourceOfData;
                fsDetail.StateFacilityIdentifier = facRow.Key;
                fsDetail.StateFacilitySystemAcronymName = sourceOfData;

                list.FacilitySiteAllDetails.Add(fsDetail);

            }

            return list;
        }

    }
}
