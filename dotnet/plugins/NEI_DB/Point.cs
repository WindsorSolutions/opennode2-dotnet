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
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Windsor.Node2008.WNOSPlugin.NEI_DB
{
    //<remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.epa.gov/exchangenetwork"), System.Xml.Serialization.XmlRootAttribute("PointSourceSubmissionGroup", Namespace = "http://www.epa.gov/exchangenetwork", IsNullable = false)]
    public class PointSourceSubmissionGroupType
    {
        //default schema location
        [XmlAnyAttributeAttribute()]
        public XmlAttribute[] XAttributes = new XmlAttribute[0];

        //<remarks/>
        public SystemRecordCountValuesType SystemRecordCountValues;

        //<remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TransmittalSubmissionGroup")]
        public TransmittalSubmissionGroupType[] TransmittalSubmissionGroup;

        //<remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SiteSubmissionGroup")]
        public SiteSubmissionGroupType[] SiteSubmissionGroup;

        //<remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EmissionUnitSubmissionGroup")]
        public EmissionUnitSubmissionGroupType[] EmissionUnitSubmissionGroup;

        //<remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EmissionReleasePointSubmissionGroup")]
        public EmissionReleasePointSubmissionGroupType[] EmissionReleasePointSubmissionGroup;

        //<remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EmissionProcessSubmissionGroup")]
        public EmissionProcessSubmissionGroupType[] EmissionProcessSubmissionGroup;

        //<remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EmissionPeriodSubmissionGroup")]
        public EmissionPeriodSubmissionGroupType[] EmissionPeriodSubmissionGroup;

        //<remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EmissionSubmissionGroup")]
        public EmissionSubmissionGroupType[] EmissionSubmissionGroup;

        //<remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ControlEquipmentSubmissionGroup")]
        public ControlEquipmentSubmissionGroupType[] ControlEquipmentSubmissionGroup;

        //<remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal schemaVersion;
    }

    //<remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.epa.gov/exchangenetwork"), System.Xml.Serialization.XmlRootAttribute("SystemRecordCountValues", Namespace = "http://www.epa.gov/exchangenetwork", IsNullable = false)]
    public class SystemRecordCountValuesType
    {

        //<remarks/>
        public double SystemRecordCountTransmittalValue;

        //<remarks/>
        public double SystemRecordCountSiteValue;

        //<remarks/>
        public double SystemRecordCountEmissionUnitValue;

        //<remarks/>
        public double SystemRecordCountEmissionReleasePointValue;

        //<remarks/>
        public double SystemRecordCountEmissionProcessValue;

        //<remarks/>
        public double SystemRecordCountEmissionPeriodValue;

        //<remarks/>
        public double SystemRecordCountEmissionValue;

        //<remarks/>
        public double SystemRecordCountControlEquipmentValue;

        //<remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal schemaVersion = decimal.Parse("3.0");
    }

    //<remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.epa.gov/exchangenetwork"), System.Xml.Serialization.XmlRootAttribute("ControlEquipmentSubmissionGroup", Namespace = "http://www.epa.gov/exchangenetwork", IsNullable = false)]
    public class ControlEquipmentSubmissionGroupType
    {

        //<remarks/>
        public string ControlEquipmentRecordTypeCode;

        //<remarks/>
        public string CountyStateFIPSCode;

        //<remarks/>
        public string StateFacilityIdentifier;

        //<remarks/>
        public string EmissionUnitIdentifier;

        //<remarks/>
        public string ProcessIdentifier;

        //<remarks/>
        public string PollutantCode;

        //<remarks/>
        public double PrimaryEfficiencyPercent;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PrimaryEfficiencyPercentSpecified;

        //<remarks/>
        public double CaptureEfficiencyPercent;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CaptureEfficiencyPercentSpecified;

        //<remarks/>
        public double TotalCaptureEfficiencyPercent;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalCaptureEfficiencyPercentSpecified;

        //<remarks/>
        public string DevicePrimaryTypeCode;

        //<remarks/>
        public string DeviceSecondaryTypeCode;

        //<remarks/>
        public string ControlSystemDescription;

        //<remarks/>
        public string DeviceThirdTypeCode;

        //<remarks/>
        public string DeviceFourthTypeCode;

        //<remarks/>
        public string TransactionSubmittalCode;

        //<remarks/>
        public string TribalCode;

        //<remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal schemaVersion = decimal.Parse("3.0");
    }

    //<remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.epa.gov/exchangenetwork"), System.Xml.Serialization.XmlRootAttribute("EmissionSubmissionGroup", Namespace = "http://www.epa.gov/exchangenetwork", IsNullable = false)]
    public class EmissionSubmissionGroupType
    {

        //<remarks/>
        public string EmissionRecordTypeCode;

        //<remarks/>
        public string CountyStateFIPSCode;

        //<remarks/>
        public string StateFacilityIdentifier;

        //<remarks/>
        public string EmissionUnitIdentifier;

        //<remarks/>
        public string ProcessIdentifier;

        //<remarks/>
        public string PollutantCode;

        //<remarks/>
        public string ReleasePointIdentifier;

        //<remarks/>
        public string EmissionPeriodStartDate;

        //<remarks/>
        public string EmissionPeriodEndDate;

        //<remarks/>
        public string EmissionPeriodStartTime;

        //<remarks/>
        public string EmissionPeriodEndTime;

        //<remarks/>
        public double EmissionValue;

        //<remarks/>
        public string EmissionUnitNumeratorValue;

        //<remarks/>
        public string EmissionTypeCode;

        //<remarks/>
        public double ReliabilityIndicator;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReliabilityIndicatorSpecified;

        //<remarks/>
        public string EmissionFactorValue;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EmissionFactorValueSpecified;

        //<remarks/>
        public string FactorUnitNumeratorValue;

        //<remarks/>
        public string FactorUnitDenominatorValue;

        //<remarks/>
        public double MaterialCode;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaterialCodeSpecified;

        //<remarks/>
        public string MaterialInputOutputCode;

        //<remarks/>
        public string EmissionCalculationMethodCode;

        //<remarks/>
        public string EmissionFactorReliabilityIndicator;

        //<remarks/>
        public double RuleEffectivenessMeasure;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RuleEffectivenessMeasureSpecified;

        //<remarks/>
        public string RuleEffectivenessMethodCode;

        //<remarks/>
        public string HAPEmissionsPerformanceLevelCode;

        //<remarks/>
        public string ControlStatusCode;

        //<remarks/>
        public string EmissionDataLevelIdentifier;

        //<remarks/>
        public string TransactionSubmittalCode;

        //<remarks/>
        public string TribalCode;

        //<remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal schemaVersion = decimal.Parse("3.0");
    }

    //<remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.epa.gov/exchangenetwork"), System.Xml.Serialization.XmlRootAttribute("EmissionPeriodSubmissionGroup", Namespace = "http://www.epa.gov/exchangenetwork", IsNullable = false)]
    public class EmissionPeriodSubmissionGroupType
    {

        //<remarks/>
        public string EmissionPeriodRecordTypeCode;

        //<remarks/>
        public string CountyStateFIPSCode;

        //<remarks/>
        public string StateFacilityIdentifier;

        //<remarks/>
        public string EmissionUnitIdentifier;

        //<remarks/>
        public string ProcessIdentifier;

        //<remarks/>
        public string EmissionPeriodStartDate;

        //<remarks/>
        public string EmissionPeriodEndDate;

        //<remarks/>
        public string EmissionPeriodStartTime;

        //<remarks/>
        public string EmissionPeriodEndTime;

        //<remarks/>
        public string ThroughputValue;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ThroughputValueSpecified;

        //<remarks/>
        public string UnitNumeratorValue;

        //<remarks/>
        public double MaterialCode;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaterialCodeSpecified;

        //<remarks/>
        public string MaterialInputOutputCode;

        //<remarks/>
        public double AverageDaysPerWeekValue;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AverageDaysPerWeekValueSpecified;

        //<remarks/>
        public double AverageWeeksPerPeriodValue;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AverageWeeksPerPeriodValueSpecified;

        //<remarks/>
        public double AverageHoursPerDayValue;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AverageHoursPerDayValueSpecified;

        //<remarks/>
        public double AverageHoursPerPeriodValue;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AverageHoursPerPeriodValueSpecified;

        //<remarks/>
        public string TransactionSubmittalCode;

        //<remarks/>
        public string TribalCode;

        //<remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal schemaVersion = decimal.Parse("3.0");
    }

    //<remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.epa.gov/exchangenetwork"), System.Xml.Serialization.XmlRootAttribute("EmissionProcessSubmissionGroup", Namespace = "http://www.epa.gov/exchangenetwork", IsNullable = false)]
    public class EmissionProcessSubmissionGroupType
    {

        //<remarks/>
        public string EmissionProcessRecordTypeCode;

        //<remarks/>
        public string CountyStateFIPSCode;

        //<remarks/>
        public string StateFacilityIdentifier;

        //<remarks/>
        public string EmissionUnitIdentifier;

        //<remarks/>
        public string ReleasePointIdentifier;

        //<remarks/>
        public string ProcessIdentifier;

        //<remarks/>
        public string SourceCategoryCode;

        //<remarks/>
        public string MACTCode;

        //<remarks/>
        public string EmissionProcessDescription;

        //<remarks/>
        public double ThroughputWinterPercent;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ThroughputWinterPercentSpecified;

        //<remarks/>
        public double ThroughputSpringPercent;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ThroughputSpringPercentSpecified;

        //<remarks/>
        public double ThroughputSummerPercent;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ThroughputSummerPercentSpecified;

        //<remarks/>
        public double ThroughputFallPercent;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ThroughputFallPercentSpecified;

        //<remarks/>
        public double AverageDaysPerWeekValue;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AverageDaysPerWeekValueSpecified;

        //<remarks/>
        public double AverageWeeksPerYearValue;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AverageWeeksPerYearValueSpecified;

        //<remarks/>
        public double AverageHoursPerDayValue;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AverageHoursPerDayValueSpecified;

        //<remarks/>
        public double AverageHoursPerYearValue;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AverageHoursPerYearValueSpecified;

        //<remarks/>
        public double FuelHeatContentMeasure;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FuelHeatContentMeasureSpecified;

        //<remarks/>
        public double FuelSulfurContentMeasure;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FuelSulfurContentMeasureSpecified;

        //<remarks/>
        public double FuelAshContentMeasure;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FuelAshContentMeasureSpecified;

        //<remarks/>
        public string MACTComplianceStatusCode;

        //<remarks/>
        public string TransactionSubmittalCode;

        //<remarks/>
        public string TribalCode;

        //<remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal schemaVersion = decimal.Parse("3.0");
    }

    //<remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.epa.gov/exchangenetwork"), System.Xml.Serialization.XmlRootAttribute("EmissionReleasePointSubmissionGroup", Namespace = "http://www.epa.gov/exchangenetwork", IsNullable = false)]
    public class EmissionReleasePointSubmissionGroupType
    {

        //<remarks/>
        public string EmissionReleasePointRecordTypeCode;

        //<remarks/>
        public string CountyStateFIPSCode;

        //<remarks/>
        public string StateFacilityIdentifier;

        //<remarks/>
        public string ReleasePointIdentifier;

        //<remarks/>
        public string ReleasePointTypeCode;

        //<remarks/>
        public double StackHeightValue;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StackHeightValueSpecified;

        //<remarks/>
        public double StackDiameterValue;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StackDiameterValueSpecified;

        //<remarks/>
        public double StackFencelineDistanceValue;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StackFencelineDistanceValueSpecified;

        //<remarks/>
        public double ExitGasTemperatureValue;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ExitGasTemperatureValueSpecified;

        //<remarks/>
        public double ExitGasStreamVelocityRate;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ExitGasStreamVelocityRateSpecified;

        //<remarks/>
        public double ExitGasFlowRate;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ExitGasFlowRateSpecified;

        //<remarks/>
        public string LongitudeMeasure;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LongitudeMeasureSpecified;

        //<remarks/>
        public string LatitudeMeasure;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LatitudeMeasureSpecified;

        //<remarks/>
        public string UTMZoneCode;

        //<remarks/>
        public string XYCoordinateTypeCode;

        //<remarks/>
        public double FugitiveHorizontalAreaValue;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FugitiveHorizontalAreaValueSpecified;

        //<remarks/>
        public double FugitiveReleaseHeightValue;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FugitiveReleaseHeightValueSpecified;

        //<remarks/>
        public string FugitiveUnitOfMeasureCode;

        //<remarks/>
        public string ReleasePointDescription;

        //<remarks/>
        public string TransactionSubmittalCode;

        //<remarks/>
        public string HorizontalCollectionMethodCode;

        //<remarks/>
        public string HorizontalAccuracyMeasure;

        //<remarks/>
        public string HorizontalReferenceDatumCode;

        //<remarks/>
        public string ReferencePointCode;

        //<remarks/>
        public string SourceMapScaleNumber;

        //<remarks/>
        public string CoordinateDataSourceCode;

        //<remarks/>
        public string TribalCode;

        //<remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal schemaVersion = decimal.Parse("3.0");
    }

    //<remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.epa.gov/exchangenetwork"), System.Xml.Serialization.XmlRootAttribute("EmissionUnitSubmissionGroup", Namespace = "http://www.epa.gov/exchangenetwork", IsNullable = false)]
    public class EmissionUnitSubmissionGroupType
    {

        //<remarks/>
        public string EmissionUnitRecordTypeCode;

        //<remarks/>
        public string CountyStateFIPSCode;

        //<remarks/>
        public string StateFacilityIdentifier;

        //<remarks/>
        public string EmissionUnitIdentifier;

        //<remarks/>
        public string ORISBoilerIdentifier;

        //<remarks/>
        public string SICCode;

        //<remarks/>
        public string NAICSCode;

        //<remarks/>
        public double DesignCapacityMeasure;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DesignCapacityMeasureSpecified;

        //<remarks/>
        public string UnitNumeratorValue;

        //<remarks/>
        public string UnitDenominatorValue;

        //<remarks/>
        public double DesignCapacityMaximumNameplateValue;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DesignCapacityMaximumNameplateValueSpecified;

        //<remarks/>
        public string EmissionUnitDescription;

        //<remarks/>
        public string TransactionSubmittalCode;

        //<remarks/>
        public string TribalCode;

        //<remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal schemaVersion = decimal.Parse("3.0");
    }

    //<remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.epa.gov/exchangenetwork"), System.Xml.Serialization.XmlRootAttribute("SiteSubmissionGroup", Namespace = "http://www.epa.gov/exchangenetwork", IsNullable = false)]
    public class SiteSubmissionGroupType
    {

        //<remarks/>
        public string SiteRecordTypeCode;

        //<remarks/>
        public string CountyStateFIPSCode;

        //<remarks/>
        public string StateFacilityIdentifier;

        //<remarks/>
        public string FacilityRegistryIdentifier;

        //<remarks/>
        public string FacilityCategoryCode;

        //<remarks/>
        public string ORISFacilityCode;

        //<remarks/>
        public string SICCode;

        //<remarks/>
        public string NAICSCode;

        //<remarks/>
        public string FacilitySiteName;

        //<remarks/>
        public string FacilityDescription;

        //<remarks/>
        public string LocationAddressText;

        //<remarks/>
        public string LocalityName;

        //<remarks/>
        public string LocationAddressStateAbbrev;

        //<remarks/>
        public string LocationZipCode;

        //<remarks/>
        public string CountryName;

        //<remarks/>
        public string FacilityNTIIdentifier;

        //<remarks/>
        public string OrganizationDUNSNumber;

        //<remarks/>
        public string FacilityTRIIdentifier;

        //<remarks/>
        public string TransactionSubmittalCode;

        //<remarks/>
        public string TribalCode;

        //<remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal schemaVersion = decimal.Parse("3.0");
    }

    //<remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.epa.gov/exchangenetwork"), System.Xml.Serialization.XmlRootAttribute("TransmittalSubmissionGroup", Namespace = "http://www.epa.gov/exchangenetwork", IsNullable = false)]
    public class TransmittalSubmissionGroupType
    {

        //<remarks/>
        public string TransmittalRecordTypeCode;

        //<remarks/>
        public string CountyStateFIPSCode;

        //<remarks/>
        public string OrganizationFormalName;

        //<remarks/>
        public string TransactionTypeCode;

        //<remarks/>
        public string InventoryYear;

        //<remarks/>
        public string InventoryTypeCode;

        //<remarks/>
        public string TransactionCreationDate;

        //<remarks/>
        public double SubmissionNumber;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SubmissionNumberSpecified;

        //<remarks/>
        public double ReliabilityIndicator;

        //<remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReliabilityIndicatorSpecified;

        //<remarks/>
        public string TransactionComment;

        //<remarks/>
        public string IndividualFullName;

        //<remarks/>
        public string TelephoneNumber;

        //<remarks/>
        public string TelephoneNumberTypeName;

        //<remarks/>
        public string ElectronicAddressText;

        //<remarks/>
        public string ElectronicAddressTypeName;

        //<remarks/>
        public string SourceTypeCode;

        //<remarks/>
        public string AffiliationTypeText;

        //<remarks/>
        public double FormatVersionNumber;

        //<remarks/>
        public string TribalCode;

        //<remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal schemaVersion = decimal.Parse("3.0");
    }
}
