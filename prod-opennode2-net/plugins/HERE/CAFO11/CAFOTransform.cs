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

namespace Windsor.Node2008.WNOSPlugin.HERE.CAFO11
{
    internal class CAFOTransform
    {
        internal static CAFOFacilityList Transform(CAFO ds)
        {

            CAFOFacilityList list = new CAFOFacilityList();
            list.CAFOFacilities = new List<CAFOFacilityDataType>();

            foreach (CAFO.CAFO_FACRow facRow in ds.CAFO_FAC.Rows)
            {
                //NOTE: I don't think we need the identifier class
                #region Facilty Level Properties
                CAFOFacilityDataType facCAFO = new CAFOFacilityDataType();
                facCAFO.FacilitySiteName = facRow.FacilitySiteName;
                facCAFO.FacilityAlternativeName = facRow.FacilityAltName;
                facCAFO.FacilityInformationURL = facRow.FacilityInfoURL;

                if (!string.IsNullOrEmpty(facRow.FacilityRegistryID))
                {
                    facCAFO.FacilityRegistryIdentifier = new FacilitySiteIdentifierDataType();
                    facCAFO.FacilityRegistryIdentifier.Value = facRow.FacilityRegistryID;
                }

                if (!string.IsNullOrEmpty(facRow.StateFacilityID))
                {
                    facCAFO.StateFacilityIdentifier = new FacilitySiteIdentifierDataType();
                    facCAFO.StateFacilityIdentifier.Value = facRow.StateFacilityID;
                }

                #endregion

                #region Geographic Coordinates
                foreach (CAFO.CAFO_GEORow geoRow in facRow.GetCAFO_GEORows())
                {
                    facCAFO.GeographicLocation = new GeographicLocationDataType();

                    facCAFO.GeographicLocation.LatitudeMeasureDecimal = geoRow.Latitude;
                    facCAFO.GeographicLocation.LongitudeMeasureDecimal = geoRow.Longitude;
                    facCAFO.GeographicLocation.HydrologicUnitCode = geoRow.HydrologicUnitCode;
                    facCAFO.GeographicLocation.LocationCommentsText = geoRow.LocationComments;
                    facCAFO.GeographicLocation.HorizontalAccuracyMeasure = new MeasureDataType();
                    facCAFO.GeographicLocation.HorizontalAccuracyMeasure.MeasurePrecisionText = geoRow.PrecText;
                    facCAFO.GeographicLocation.HorizontalAccuracyMeasure.MeasureValue = geoRow.HorizAccurValue;
                    facCAFO.GeographicLocation.HorizontalAccuracyMeasure.MeasureUnit = new MeasureUnitDataType();
                    facCAFO.GeographicLocation.HorizontalAccuracyMeasure.MeasureUnit.MeasureUnitCode = geoRow.HorizAccurUnitCode;
                    facCAFO.GeographicLocation.HorizontalAccuracyMeasure.MeasureUnit.MeasureUnitCodeListIdentifier = new MeasureUnitCodeListIdentifierDataType();
                    facCAFO.GeographicLocation.HorizontalAccuracyMeasure.MeasureUnit.MeasureUnitCodeListIdentifier.Value = geoRow.HorizAccurUnitCodeListID;


                    facCAFO.GeographicLocation.HorizontalAccuracyMeasure.MeasureUnit.MeasureUnitName = geoRow.HorizAccurUnitName;
                    facCAFO.GeographicLocation.HorizontalAccuracyMeasure.ResultQualifier = new ResultQualifierDataType();
                    facCAFO.GeographicLocation.HorizontalAccuracyMeasure.ResultQualifier.ResultQualifierCode = geoRow.ResultQualCode;
                    facCAFO.GeographicLocation.HorizontalAccuracyMeasure.ResultQualifier.ResultQualifierCodeListIdentifier = new ResultQualifierCodeListIdentifierDataType();
                    facCAFO.GeographicLocation.HorizontalAccuracyMeasure.ResultQualifier.ResultQualifierCodeListIdentifier.Value = geoRow.ResultQualCodeListID;

                    facCAFO.GeographicLocation.HorizontalAccuracyMeasure.ResultQualifier.ResultQualifierName = geoRow.ResultQualName;
                    facCAFO.GeographicLocation.HorizontalMethod = new ReferenceMethodDataType();
                    facCAFO.GeographicLocation.HorizontalMethod.MethodName = geoRow.HorizMethodName;
                    facCAFO.GeographicLocation.HorizontalMethod.MethodDescriptionText = geoRow.HorizMethodDesc;
                    facCAFO.GeographicLocation.HorizontalMethod.MethodDeviationsText = geoRow.HorizMethodDeviations;
                    facCAFO.GeographicLocation.HorizontalMethod.MethodIdentifierCode = geoRow.HorizMethodIDCode;

                    if (!string.IsNullOrEmpty(geoRow.HorizMethodIDCodeListID))
                    {
                        facCAFO.GeographicLocation.HorizontalMethod.MethodIdentifierCodeListIdentifier = new MethodIdentifierCodeListIdentifierDataType();
                        facCAFO.GeographicLocation.HorizontalMethod.MethodIdentifierCodeListIdentifier.Value = geoRow.HorizMethodIDCodeListID;
                    }
                }
                #endregion

                #region Address
                foreach (CAFO.CAFO_ADDRow addRow in facRow.GetCAFO_ADDRows())
                {
                    facCAFO.LocationAddress = new LocationAddressDataType();

                    facCAFO.LocationAddress.LocationAddressText = addRow.LocationAddress;
                    facCAFO.LocationAddress.SupplementalAddressText = addRow.SupplementalAddress;
                    facCAFO.LocationAddress.LocalityName = addRow.LocalityName;
                    facCAFO.LocationAddress.CountyName = addRow.CountyName;
                    facCAFO.LocationAddress.StateName = addRow.StateName;
                    facCAFO.LocationAddress.StateUSPSCode = addRow.StateUSPSCode;
                    if (!string.IsNullOrEmpty(addRow.AddressPostalCode))
                    {
                        facCAFO.LocationAddress.AddressPostalCode = new AddressPostalCodeDataType();
                        facCAFO.LocationAddress.AddressPostalCode.Value = addRow.AddressPostalCode;
                    }
                }
                #endregion
                
                #region Animals
                foreach (CAFO.CAFO_ANIMALRow aniRow in facRow.GetCAFO_ANIMALRows())
                {
                    if (facCAFO.AnimalTypeList == null)
                    {
                        facCAFO.AnimalTypeList = new List<AnimalTypeDataType>();
                    }
                    AnimalTypeDataType aniDtl = new AnimalTypeDataType();

                    aniDtl.AnimalTypeCode = aniRow.AnimalTypeCode;
                    aniDtl.AnimalTypeName = aniRow.AnimalTypeName;
                    aniDtl.TotalNumbersEachLivestock = aniRow.TotalNumsEachLivestock;
                    aniDtl.TotalNumbersEachLivestockSpecified = true;
                    aniDtl.HousedUnderRoofConfinementCount = aniRow.HousedUnderRoofCount;
                    aniDtl.HousedUnderRoofConfinementCountSpecified = true;
                    aniDtl.OpenConfinementCount = aniRow.OpenCount;
                    aniDtl.OpenConfinementCountSpecified = true;

                    facCAFO.AnimalTypeList.Add(aniDtl);

                }
                #endregion

                #region Regulatory Details
                foreach (CAFO.CAFO_REG_DTLSRow regRow in facRow.GetCAFO_REG_DTLSRows())
                {
                    facCAFO.RegulatoryDetails = new RegulatoryDetailsDataType();

                    facCAFO.RegulatoryDetails.DischargesFromProductionAreaIndicator =  regRow.DischrgFromProdArea;
                    facCAFO.RegulatoryDetails.DischargesFromProductionAreaIndicatorSpecified = true;
                    facCAFO.RegulatoryDetails.AuthorizedDischargeIndicator = regRow.AuthorizedDischarge;
                    facCAFO.RegulatoryDetails.AuthorizedDischargeIndicatorSpecified = true;
                    facCAFO.RegulatoryDetails.UnauthorizedDischargeIndicator = regRow.UnauthorizedDischarge;
                    facCAFO.RegulatoryDetails.UnauthorizedDischargeIndicatorSpecified = true;
                    facCAFO.RegulatoryDetails.PermittingAuthorityReportReceivedDate = regRow.PermittingAuthRepRecDate;
                    facCAFO.RegulatoryDetails.PermittingAuthorityReportReceivedDateSpecified = true;
                    facCAFO.RegulatoryDetails.IsAnimalFacilityTypeCAFOIndicator = regRow.IsAnimalFacilityTypeCAFO;
                    facCAFO.RegulatoryDetails.IsAnimalFacilityTypeCAFOIndicatorSpecified = true;
                    
                    facCAFO.RegulatoryDetails.NMPDevelopedCertifiedPlannerApprovedIndicator = regRow.NMPDevCertPlanApproved;
                    facCAFO.RegulatoryDetails.NMPDevelopedCertifiedPlannerApprovedIndicatorSpecified = true;
                    facCAFO.RegulatoryDetails.TotalNumberAcresNMPIdentified = regRow.TotalNumAcresNMPIdentified;
                    facCAFO.RegulatoryDetails.TotalNumberAcresNMPIdentifiedSpecified = true;
                    facCAFO.RegulatoryDetails.TotalNumberAcresUsedLandApplication = regRow.TotalNumAcresUsedLandApp;
                    facCAFO.RegulatoryDetails.TotalNumberAcresUsedLandApplicationSpecified = true;
    
                    facCAFO.RegulatoryDetails.SolidManureLitterGeneratedAmount = new MeasureDataType();
                    facCAFO.RegulatoryDetails.SolidManureLitterGeneratedAmount.MeasurePrecisionText =regRow.SolManurePrec;
                    facCAFO.RegulatoryDetails.SolidManureLitterGeneratedAmount.MeasureValue = regRow.SolManureValue;
                    facCAFO.RegulatoryDetails.SolidManureLitterGeneratedAmount.ResultQualifier = new ResultQualifierDataType();
                    facCAFO.RegulatoryDetails.SolidManureLitterGeneratedAmount.ResultQualifier.ResultQualifierCode = regRow.SolManureResultCode;
                    facCAFO.RegulatoryDetails.SolidManureLitterGeneratedAmount.ResultQualifier.ResultQualifierCodeListIdentifier = new ResultQualifierCodeListIdentifierDataType();
                    facCAFO.RegulatoryDetails.SolidManureLitterGeneratedAmount.ResultQualifier.ResultQualifierCodeListIdentifier.Value = regRow.SolManureResultCodeListID;
                    facCAFO.RegulatoryDetails.SolidManureLitterGeneratedAmount.ResultQualifier.ResultQualifierName = regRow.SolManureResultName;
                    facCAFO.RegulatoryDetails.SolidManureLitterGeneratedAmount.MeasureUnit = new MeasureUnitDataType();
                    facCAFO.RegulatoryDetails.SolidManureLitterGeneratedAmount.MeasureUnit.MeasureUnitCode = regRow.SolManureUnitCode;
                    facCAFO.RegulatoryDetails.SolidManureLitterGeneratedAmount.MeasureUnit.MeasureUnitName = regRow.SolManureUnitName;
                    facCAFO.RegulatoryDetails.SolidManureLitterGeneratedAmount.MeasureUnit.MeasureUnitCodeListIdentifier = new MeasureUnitCodeListIdentifierDataType();
                    facCAFO.RegulatoryDetails.SolidManureLitterGeneratedAmount.MeasureUnit.MeasureUnitCodeListIdentifier.Value = regRow.SolManureUnitCodeListID;

                    facCAFO.RegulatoryDetails.LiquidManureWastewaterGeneratedAmount = new MeasureDataType();
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterGeneratedAmount.MeasurePrecisionText = regRow.LiqManurePrec;
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterGeneratedAmount.MeasureValue = regRow.LiqManureValue;
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterGeneratedAmount.ResultQualifier = new ResultQualifierDataType();
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterGeneratedAmount.ResultQualifier.ResultQualifierCode = regRow.LiqManureResultCode;
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterGeneratedAmount.ResultQualifier.ResultQualifierCodeListIdentifier = new ResultQualifierCodeListIdentifierDataType();
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterGeneratedAmount.ResultQualifier.ResultQualifierCodeListIdentifier.Value = regRow.LiqManureResultCodeListID;
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterGeneratedAmount.ResultQualifier.ResultQualifierName = regRow.LiqManureResultName;
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterGeneratedAmount.MeasureUnit = new MeasureUnitDataType();
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterGeneratedAmount.MeasureUnit.MeasureUnitCode = regRow.LiqManureUnitCode;
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterGeneratedAmount.MeasureUnit.MeasureUnitName = regRow.LiqManureUnitName;
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterGeneratedAmount.MeasureUnit.MeasureUnitCodeListIdentifier = new MeasureUnitCodeListIdentifierDataType();
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterGeneratedAmount.MeasureUnit.MeasureUnitCodeListIdentifier.Value = regRow.LiqManureUnitCodeListID;
                    
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterTransferAmount = new MeasureDataType();
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterTransferAmount.MeasurePrecisionText = regRow.LiqManureTranPrec;
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterTransferAmount.MeasureValue = regRow.LiqManureTranValue;
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterTransferAmount.ResultQualifier = new ResultQualifierDataType();
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterTransferAmount.ResultQualifier.ResultQualifierCode = regRow.LiqManureTranResultCode;
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterTransferAmount.ResultQualifier.ResultQualifierCodeListIdentifier = new ResultQualifierCodeListIdentifierDataType();
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterTransferAmount.ResultQualifier.ResultQualifierCodeListIdentifier.Value = regRow.LiqManureTranResultCodeListID;
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterTransferAmount.ResultQualifier.ResultQualifierName = regRow.LiqManureTranResultName;
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterTransferAmount.MeasureUnit = new MeasureUnitDataType();
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterTransferAmount.MeasureUnit.MeasureUnitCode = regRow.LiqManureTranUnitCode;
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterTransferAmount.MeasureUnit.MeasureUnitName = regRow.LiqManureTranUnitName;
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterTransferAmount.MeasureUnit.MeasureUnitCodeListIdentifier = new MeasureUnitCodeListIdentifierDataType();
                    facCAFO.RegulatoryDetails.LiquidManureWastewaterTransferAmount.MeasureUnit.MeasureUnitCodeListIdentifier.Value = regRow.LiqManureTranUnitCodeListID;

                    facCAFO.RegulatoryDetails.SolidManureLitterTransferAmount = new MeasureDataType();
                    facCAFO.RegulatoryDetails.SolidManureLitterTransferAmount.MeasurePrecisionText = regRow.SolManureTranPrec;
                    facCAFO.RegulatoryDetails.SolidManureLitterTransferAmount.MeasureValue = regRow.SolManureTranValue;
                    facCAFO.RegulatoryDetails.SolidManureLitterTransferAmount.ResultQualifier = new ResultQualifierDataType();
                    facCAFO.RegulatoryDetails.SolidManureLitterTransferAmount.ResultQualifier.ResultQualifierCode = regRow.SolManureTranResultCode;
                    facCAFO.RegulatoryDetails.SolidManureLitterTransferAmount.ResultQualifier.ResultQualifierCodeListIdentifier = new ResultQualifierCodeListIdentifierDataType();
                    facCAFO.RegulatoryDetails.SolidManureLitterTransferAmount.ResultQualifier.ResultQualifierCodeListIdentifier.Value = regRow.SolManureTranResultCodeListID;
                    facCAFO.RegulatoryDetails.SolidManureLitterTransferAmount.ResultQualifier.ResultQualifierName = regRow.SolManureTranResultName;
                    facCAFO.RegulatoryDetails.SolidManureLitterTransferAmount.MeasureUnit = new MeasureUnitDataType();
                    facCAFO.RegulatoryDetails.SolidManureLitterTransferAmount.MeasureUnit.MeasureUnitCode = regRow.SolManureTranUnitCode;
                    facCAFO.RegulatoryDetails.SolidManureLitterTransferAmount.MeasureUnit.MeasureUnitName = regRow.SolManureTranUnitName;
                    facCAFO.RegulatoryDetails.SolidManureLitterTransferAmount.MeasureUnit.MeasureUnitCodeListIdentifier = new MeasureUnitCodeListIdentifierDataType();
                    facCAFO.RegulatoryDetails.SolidManureLitterTransferAmount.MeasureUnit.MeasureUnitCodeListIdentifier.Value = regRow.SolManureTranUnitCodeListID;


                    #region Permit
                    foreach (CAFO.CAFO_PERMITRow permRow in regRow.GetCAFO_PERMITRows())
                    {
                        if (facCAFO.RegulatoryDetails.PermitIdentity == null)
                        {
                            facCAFO.RegulatoryDetails.PermitIdentity = new List<PermitIdentityDataType>();
                        }
                        PermitIdentityDataType permitDetail = new PermitIdentityDataType();
                        

                        // NOTE: I think the identifier types generated by xsd.exe are not necessary.
                        permitDetail.PermitName = permRow.PermitName;
                        permitDetail.ProgramName = permRow.ProgramName;
                        permitDetail.PermitType = new PermitTypeDataType();
                        permitDetail.PermitType.PermitTypeCode = permRow.PermitTypeCode;
                        permitDetail.PermitType.PermitTypeCodeListIdentifier = new PermitTypeCodeListIdentifierDataType();
                        permitDetail.PermitType.PermitTypeCodeListIdentifier.Value = permRow.PermitTypeCodeListID;
                        permitDetail.PermitType.PermitTypeName = permRow.PermitTypeName;

                        if (!string.IsNullOrEmpty(permRow.PermitId))
                        {
                            permitDetail.PermitIdentifier = new PermitIdentifierDataType();
                            permitDetail.PermitIdentifier.Value = permRow.PermitId;
                        }

                        if (!string.IsNullOrEmpty(permRow.OtherPermitId))
                        {
                            permitDetail.OtherPermitIdentifier = new OtherPermitIdentifierDataType();
                            permitDetail.OtherPermitIdentifier.Value = permRow.OtherPermitId;
                        }

                        facCAFO.RegulatoryDetails.PermitIdentity.Add(permitDetail);
                    }
                    #endregion

                }

                #endregion

                //Keep on the end
                list.CAFOFacilities.Add(facCAFO);

            }

            return list;
        }

    }
}
