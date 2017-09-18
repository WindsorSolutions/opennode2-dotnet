namespace Windsor.Node2008.WNOSPlugin.CERS_12
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityIdentification", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class FacilityIdentificationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An identifier by which the facility site is referred to by a system.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FacilitySiteIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the information management system which has responsibili" +
            "ty for the data in a linked or interrelated information management system.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ProgramSystemCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The list is from FIPS Counties codes used for the identification of the Counties " +
            "and County equivalents of the United States.")]
        public string StateAndCountyFIPSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the American Indian Tribe or Alaskan Native entity.")]
        public string TribalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The code that represents a State and Country for States in Mexico and Provinces i" +
            "n Canada.")]
        public string StateAndCountryFIPSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The date on which the identifier became effective.")]
        public System.DateTime EffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EffectiveDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The date on which the identifier is no longer applicable.")]
        public System.DateTime EndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("AlternativeFacilityName", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class AlternativeFacilityNameDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An alternative, historic, or program-specific name for the facility site.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AlternativeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the information management system which has responsibili" +
            "ty for the data in a linked or interrelated information management system.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ProgramSystemCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The type of alternative, historical, or program-specific name for the facility si" +
            "te (e.g., primary, legal, historical, local). ")]
        public string AlternativeNameTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The date on which the identifier became effective.")]
        public System.DateTime EffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EffectiveDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("UnitQualityIdentification", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class QualityIdentificationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An identifier for the quality finding.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string QualityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the information management system which has responsibili" +
            "ty for the data in a linked or interrelated information management system.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ProgramSystemCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("IndividualIdentification", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class IdentificationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An identifier by which an element is referred to in another system.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string Identifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the information management system which has responsibili" +
            "ty for the data in a linked or interrelated information management system.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ProgramSystemCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The date on which the identifier became effective.")]
        public System.DateTime EffectiveDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EffectiveDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The date on which the identifier is no longer applicable.")]
        public System.DateTime EndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("ProcessRegulation", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class RegulationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that describes the regulation applicable to the emissions unit activity " +
            "or process.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string RegulatoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Text describing the non-federal regulation applicable to the emissions unit or pr" +
            "ocess.")]
        public string AgencyCodeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The year in which the enissions unit or process became subject to the regulation." +
            "")]
        public string RegulatoryStartYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The year in which the enissions unit or process was no longer effected by the reg" +
            "ulation.")]
        public string RegulatoryEndYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Comments regarding the regulation.")]
        public string RegulationComment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("ControlMeasure", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class ControlMeasureDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code that identifies the piece of equipment or practice that is used to reduce on" +
            "e or more pollutants.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ControlMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The sequnce in which the pollutant stream passes through the various devices in t" +
            "he control group.")]
        public string ControlMeasureSequence;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("ControlPollutant", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class ControlPollutantDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code identifying the pollutant for which emissions are reported.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The percent reduction achieved for the pollutant when all control measures are op" +
            "erating as designed.")]
        public decimal PercentControlMeasuresReductionEfficiency;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentControlMeasuresReductionEfficiencySpecified;
    }

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    //[System.Xml.Serialization.XmlRootAttribute("ProcessControlApproach", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    //public partial class ControlApproachDataType
    //{

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    //    [System.ComponentModel.DescriptionAttribute("Description of the overall control system or approach applied to an emissions uni" +
    //        "t or process.")]
    //    public string ControlApproachDescription;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    //    [System.ComponentModel.DescriptionAttribute("An estimate of that portion of an affected emission stream that is collected and " +
    //        "routed to the control measures when the capture or collection system is operatin" +
    //        "g as designed, reported as a percent.")]
    //    public decimal PercentControlApproachCaptureEfficiency;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool PercentControlApproachCaptureEfficiencySpecified;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    //    [System.ComponentModel.DescriptionAttribute(@"An estimate of the portion of the reporting period's activity for which the overall control system or approach (including both capture and control measures) were operating as designed (regardless of whether the control measure is due to rule or voluntary).")]
    //    public decimal PercentControlApproachEffectiveness;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool PercentControlApproachEffectivenessSpecified;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    //    [System.ComponentModel.DescriptionAttribute("An estimate of the percent value of the nonpoint activity throughput that is affe" +
    //        "cted by a rule or voluntary approach for the given location.  (Nonpoint only.)")]
    //    public decimal PercentControlApproachPenetration;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool PercentControlApproachPenetrationSpecified;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 4)]
    //    [System.ComponentModel.DescriptionAttribute("The inventory year for which the controls were implemented.  (Point only.)")]
    //    public string FirstInventoryYear;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 5)]
    //    [System.ComponentModel.DescriptionAttribute("The last inventory year for which the controls were active.  (Point only.)")]
    //    public string LastInventoryYear;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
    //    [System.ComponentModel.DescriptionAttribute("Comments regarding the control approach.")]
    //    public string ControlApproachComment;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("ControlMeasure", Order = 7)]
    //    [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
    //    public ControlMeasureDataType[] ControlMeasure;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("ControlPollutant", Order = 8)]
    //    [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
    //    public ControlPollutantDataType[] ControlPollutant;
    //}

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("OperatingDetails", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class OperatingDetailsDataType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Actual number of hours the process is active or operating during for the reportin" +
            "g period.")]
        public string ActualHoursPerPeriod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The average number of days per week that the emissions process is active within t" +
            "he reporting period.")]
        public string AverageDaysPerWeek;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The average number of hours per day that the emissions process is active within t" +
            "he reporting period.")]
        public string AverageHoursPerDay;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The average number of weeks that the emissions process is active within the repor" +
            "ting period.")]
        public string AverageWeeksPerPeriod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The percentage of the annual activity that occurred during the Winter months (Dec" +
            "ember, January, February).")]
        public decimal PercentWinterActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentWinterActivitySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The percentage of the annual activity that occurred during the Spring months (Mar" +
            "ch, April, May).")]
        public decimal PercentSpringActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentSpringActivitySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The percentage of the annual activity that occurred during the Summer months (Jun" +
            "e, July, August).")]
        public decimal PercentSummerActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentSummerActivitySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The percentage of the annual activity that occurred during the Fall months (Septe" +
            "mber, October, November).")]
        public decimal PercentFallActivity;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentFallActivitySpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("SupplementalCalculationParameter", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class SupplementalCalculationParameterDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of the parameter that describes the type of activity, throughput or input us" +
            "ed in the calculation.")]
        public string SupplementalCalculationParameterType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The value of the parameter.")]
        public string SupplementalCalculationParameterValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The numerator unit of measure for the parameter.")]
        public string SupplementalCalculationParameterNumeratorUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The denominator unit of measure for the parameter.")]
        public string SupplementalCalculationParameterDenominatorUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The year represented by the supplemental data if it is different from the emissio" +
            "ns year.")]
        public string SupplementalCalculationParameterDataYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The source of the supplemental parameter data used.")]
        public string SupplementalCalculationParameterDataSource;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Any comments regarding the parameter.")]
        public string SupplementalCalculationParameterComment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("CO2Equivalent", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class CO2EquivalentDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The total CO2 equivalent emissions.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string CO2e;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The unit of measure for the CO2 equivalent emissions.")]
        public string CO2eUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Global warming potential (GWP) used to calculate CO2e.")]
        public string CO2ConversionFactor;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The source of reference for the GWP value.")]
        public string CO2ConversionFactorSource;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("EventEmissionsProcessEmissions", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class EmissionsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code identifying the pollutant for which emissions are reported.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PollutantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Total calculated or estimated amount of the pollutant.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string TotalEmissions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Unit of measure for reported emissions.")]
        public string EmissionsUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The emission factor used for the emissions value if a calculated value was provid" +
            "ed.")]
        public string EmissionFactor;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The numerator for the unit of measure of the reported emission factor.")]
        public string EmissionFactorNumeratorUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The denominator for the unit of measure of the reported emission factor.")]
        public string EmissionFactorDenominatorUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Code that identifies the emission factor formula used to calculate emissions.")]
        public string EmissionFactorFormulaCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Explanation for emission factor.")]
        public string EmissionFactorText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Code that defines the method used to calculate emissions.")]
        public string EmissionCalculationMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Reference given for the emission factor used in the calculation.")]
        public string EmissionFactorReferenceText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The formula used to calculate emissions.")]
        public string AlgorithmFormulaText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Information about the algorithm, including units of measure, for the calculation " +
            "method.")]
        public string AlgorithmComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("The accuracy assessment of an emission. Examples Include: Tier A, Tier B, Tier C," +
            " CARB, Part 75, etc. ")]
        public string CalculationMethodAccuracyAssessmentCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Status indicating if emissions are de minimis.")]
        public string EmissionsDeMinimisStatus;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Any comments regarding the emissions, method of calculation, or emission factor.")]
        public string EmissionsComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public CO2EquivalentDataType CO2Equivalent;
    }

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    //[System.Xml.Serialization.XmlRootAttribute("ReportingPeriod", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    //public partial class ReportingPeriodDataType
    //{

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    //    [System.ComponentModel.DescriptionAttribute("The time period type for which emissions are reported.")]
    //    [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
    //    public string ReportingPeriodTypeCode;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    //    [System.ComponentModel.DescriptionAttribute("Code identifying the operating state for the emissions being reported.")]
    //    public string EmissionOperatingTypeCode;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
    //    [System.ComponentModel.DescriptionAttribute("The date on which the reporting period began.  Applies to the reporting of episod" +
    //        "ic or event emissions only.")]
    //    public System.DateTime StartDate;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool StartDateSpecified;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
    //    [System.ComponentModel.DescriptionAttribute("The date on which the identifier is no longer applicable.")]
    //    public System.DateTime EndDate;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool EndDateSpecified;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
    //    [System.ComponentModel.DescriptionAttribute("Code indicating whether the material measured is an input to the process, an outp" +
    //        "ut of the process or a static count (not a throughput). ")]
    //    public string CalculationParameterTypeCode;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
    //    [System.ComponentModel.DescriptionAttribute("Activity or throughput of the process for a given time period.")]
    //    public string CalculationParameterValue;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
    //    [System.ComponentModel.DescriptionAttribute("Code for the unit of measure for calculation parameter value.")]
    //    public string CalculationParameterUnitofMeasure;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
    //    [System.ComponentModel.DescriptionAttribute("Code for material or fuel processed.")]
    //    public string CalculationMaterialCode;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 8)]
    //    [System.ComponentModel.DescriptionAttribute("The actual year represented by the data if it is different from the emissions yea" +
    //        "r.")]
    //    public string CalculationDataYear;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
    //    [System.ComponentModel.DescriptionAttribute("The source of the data used.")]
    //    public string CalculationDataSource;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
    //    [System.ComponentModel.DescriptionAttribute("Any comments regarding the reporting period.")]
    //    public string ReportingPeriodComment;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("ReportingPeriodQualityIdentification", Order = 11)]
    //    // TSM:
    //    // public QualityIdentificationDataType[] ReportingPeriodQualityIdentification;
    //    public ReportingPeriodQualityIdentificationDataType[] ReportingPeriodQualityIdentification;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
    //    public OperatingDetailsDataType OperatingDetails;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("SupplementalCalculationParameter", Order = 13)]
    //    public SupplementalCalculationParameterDataType[] SupplementalCalculationParameter;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("ReportingPeriodEmissions", Order = 14)]
    //    [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
    //    // TSM:
    //    // public EmissionsDataType[] ReportingPeriodEmissions;
    //    public ReportingPeriodEmissionsDataType[] ReportingPeriodEmissions;
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    //[System.Xml.Serialization.XmlRootAttribute("ReleasePointApportionment", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    //public partial class ReleasePointApportionmentDataType
    //{

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    //    [System.ComponentModel.DescriptionAttribute("The average annual percent of an emissions process that is vented through a relea" +
    //        "se point.")]
    //    [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
    //    public decimal AveragePercentEmissions;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    //    [System.ComponentModel.DescriptionAttribute("Comment regarding the average apportionment of emissions vented through a release" +
    //        " point.")]
    //    public string ReleasePointApportionmentComment;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("ReleasePointApportionmentIdentification", Order = 2)]
    //    [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
    //    // TSM:
    //    // public IdentificationDataType[] ReleasePointApportionmentIdentification;
    //    public ReleasePointApportionmentIdentificationDataType[] ReleasePointApportionmentIdentification;
    //}

    // TSM:
    /// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    //[System.Xml.Serialization.XmlRootAttribute("LocationEmissionsProcess", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    //public partial class ProcessDataType
    //{

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    //    [System.ComponentModel.DescriptionAttribute("EPA Source Classification Code that identifies an emissions process.")]
    //    public string SourceClassificationCode;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    //    [System.ComponentModel.DescriptionAttribute("Defines the type of emissions produced by Onroad and Nonroad sources. Used for Mo" +
    //        "bile sources only. Examples include exhaust, evaporative and tire wear.")]
    //    public string EmissionsTypeCode;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    //    [System.ComponentModel.DescriptionAttribute("Identifies the combination of aircraft and engine type for airport emissions.")]
    //    public string AircraftEngineTypeCode;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    //    [System.ComponentModel.DescriptionAttribute("Defines the type of emissions produced by GHG processes. Examples included for a " +
    //        "Scope 1 Stationary Combustion might be oil, gas, coal.")]
    //    public string ProcessTypeCode;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
    //    [System.ComponentModel.DescriptionAttribute("A text description of the emissions process.")]
    //    public string ProcessDescription;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 5)]
    //    [System.ComponentModel.DescriptionAttribute("The last year in which emissions occurred for this process.")]
    //    public string LastEmissionsYear;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
    //    [System.ComponentModel.DescriptionAttribute("Any comments regarding the emissions process.")]
    //    public string ProcessComment;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("ProcessIdentification", Order = 7)]
    //    // TSM:
    //    // public IdentificationDataType[] ProcessIdentification;
    //    public ProcessIdentificationDataType[] ProcessIdentification;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("ProcessRegulation", Order = 8)]
    //    // TSM:
    //    // public RegulationDataType[] ProcessRegulation;
    //    public ProcessRegulationDataType[] ProcessRegulation;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
    //    public ControlApproachDataType ProcessControlApproach;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("ReportingPeriod", Order = 10)]
    //    public ReportingPeriodDataType[] ReportingPeriod;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("ReleasePointApportionment", Order = 11)]
    //    public ReleasePointApportionmentDataType[] ReleasePointApportionment;
    //}

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("EmissionsUnit", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class EmissionsUnitDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that identifies the scope of emissions data that are reported. Examples " +
            "include Scope 1 - Stationary Combustion, Scope 1 - Mobile Combustion, Scope 2 - " +
            "Purchased Electricity, and Scope 3 - Indirect.")]
        public string Scope;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Text description of the emissions unit.")]
        public string UnitDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code that identifies the type of emissions unit activity.")]
        public string UnitTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The location or building number of the emissions source.")]
        public string UnitSourceLocation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Indicates if the emissions source is insignificant.")]
        public string InsignificantSourceIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The measure of the size of the unit based on the maximum continuous throughput ca" +
            "pacity of the unit.")]
        public string UnitDesignCapacity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Unit of measure for the design capacity of the emissions unit.")]
        public string UnitDesignCapacityUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Code that identifies the operating status of the emissions unit.")]
        public string UnitStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The year in which the unit status became applicable.")]
        public string UnitStatusCodeYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The date on which unit activity became operational.")]
        public System.DateTime UnitOperationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UnitOperationDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The date in which the unit commenced operational activities")]
        public System.DateTime UnitCommercialOperationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UnitCommercialOperationDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Any comments regarding the emissions unit activity.")]
        public string UnitComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UnitQualityIdentification", Order = 12)]
        // TSM:
        // public QualityIdentificationDataType[] UnitQualityIdentification;
        public EmissionsUnitQualityIdentificationDataType[] UnitQualityIdentification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UnitIdentification", Order = 13)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        // public IdentificationDataType[] UnitIdentification;
        public EmissionsUnitIdentificationDataType[] UnitIdentification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UnitRegulation", Order = 14)]
        // TSM:
        // public RegulationDataType[] UnitRegulation;
        public EmissionsUnitRegulationDataType[] UnitRegulation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        // TSM:
        // public ControlApproachDataType UnitControlApproach;
        public EmissionsUnitControlApproachDataType UnitControlApproach;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UnitEmissionsProcess", Order = 16)]
        // TSM:
        // public ProcessDataType[] UnitEmissionsProcess;
        public EmissionsUnitProcessDataType[] UnitEmissionsProcess;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("ReleasePointTest", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class ReleasePointTestDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The height of the plume rise from the release point above sea level. ")]
        public string ReleasePointPlumeHeightMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The plume height unit of measure.")]
        public string ReleasePointPlumeHeightUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The percent of oxygen content present in the stack test.")]
        public decimal PercentOxygenContent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentOxygenContentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The percent of moisture content present in the stack test.")]
        public decimal PercentMoistureContent;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentMoistureContentSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Date in which stack test was taken.")]
        public System.DateTime ReleasePointTestDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ReleasePointTestDateSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("EventGeographicCoordinates", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class GeographicCoordinatesDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The measure of the angular distance on a meridian north or south of the equator.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The measure of the angular distance on a meridian east or west of the prime merid" +
            "ian.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LongitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The number that represents the proportional distance on the ground for one unit o" +
            "f measure on the map or photo.")]
        public string SourceMapScaleNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The horizontal measure, in meters, of the relative accuracy of the latitude and l" +
            "ongitude coordinates.")]
        public string HorizontalAccuracyMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The horizonal accuracy unit of measure.")]
        public string HorizontalAccuracyUnitofMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The code that identifies the method used to determine the latitude and longitude " +
            "coordinates for a point on the earth.")]
        public string HorizontalCollectionMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the reference datum used in determining latitude and lon" +
            "gitude coordinates.")]
        public string HorizontalReferenceDatumCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the place for which geographic coordinates were establis" +
            "hed.")]
        public string GeographicReferencePointCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The calendar date when data were collected.")]
        public System.DateTime DataCollectionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DataCollectionDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The text that provides additional information about the geographic coordinates.")]
        public string GeographicComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The measure of elevation (i.e., the altitude), above or below a reference datum.")]
        public string VerticalMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The vertical unit of measure.")]
        public string VerticalUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("The code that identifies the method used to collect the vertical measure (i.e., t" +
            "he altitude) of a reference point.")]
        public string VerticalCollectionMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the reference datum used to determine the vertical measu" +
            "re (i.e., the altitude).")]
        public string VerticalReferenceDatumCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the process used to verify the latitude and longitude co" +
            "ordinates.")]
        public string VerificationMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the party responsible for providing the latitude and lon" +
            "gitude coordinates.")]
        public string CoordinateDataSourceCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the geometric entity represented by one point or a seque" +
            "nce of latitude and longitude points.")]
        public string GeometricTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Total area that is contained within the event perimeter for the reporting period." +
            "")]
        public string AreaWithinPerimeter;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Code that identifies the unit of measure for the area within the event perimeter." +
            "")]
        public string AreaWithinPerimeterUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("The percent of the area within the shape or perimeter that was affected by the ev" +
            "ent (e.g., area actually blackened by a fire).")]
        public decimal PercentofAreaProducingEmissions;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentofAreaProducingEmissionsSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("ReleasePoint", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class ReleasePointDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code that identifies the type of release point.")]
        public string ReleasePointTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Text description of release point.")]
        public string ReleasePointDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The height of the stack from the ground.")]
        public string ReleasePointStackHeightMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The stack height unit of measure.")]
        public string ReleasePointStackHeightUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The internal diameter of the stack (measured in feet) at the release height.")]
        public string ReleasePointStackDiameterMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("the stack diameter unit of measure.")]
        public string ReleasePointStackDiameterUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The velocity of an exit gas stream.")]
        public string ReleasePointExitGasVelocityMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The unit of measure for the velocity of an exit gas stream value.  ")]
        public string ReleasePointExitGasVelocityUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The value of the stack gas flow rate.")]
        public string ReleasePointExitGasFlowRateMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The unit of measure for the stack gas flow rate value.  ")]
        public string ReleasePointExitGasFlowRateUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The temperature of an exit gas stream (measured in degrees Fahrenheit).")]
        public string ReleasePointExitGasTemperatureMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The measure of the horizontal distance to the nearest fence line of a property wi" +
            "thin which the release point is located.")]
        public string ReleasePointFenceLineDistanceMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("The fence line distance unit of measure.")]
        public string ReleasePointFenceLineDistanceUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("The fugitive release height above terrain of fugitive emissions.")]
        public string ReleasePointFugitiveHeightMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("The fugitive release height unit of measure.")]
        public string ReleasePointFugitiveHeightUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("The width of the fugitive release in the East-West direction as if the angle is z" +
            "ero degrees.")]
        public string ReleasePointFugitiveWidthMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("The fugitive width unit of measure code.")]
        public string ReleasePointFugitiveWidthUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("The length (measured in feet) of the fugitive release in the North-South directio" +
            "n as if the angle is zero degrees.")]
        public string ReleasePointFugitiveLengthMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("The fugitive length unit of measure code.")]
        public string ReleasePointFugitiveLengthUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 19)]
        [System.ComponentModel.DescriptionAttribute("The orientation angle for the area in degrees from North, measured positive in th" +
            "e clockwise direction.")]
        public string ReleasePointFugitiveAngleMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Any comments regarding the release point.")]
        public string ReleasePointComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 21)]
        [System.ComponentModel.DescriptionAttribute("Code that identifies the operating status of the release point.")]
        public string ReleasePointStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 22)]
        [System.ComponentModel.DescriptionAttribute("The year in which the release point status became applicable.")]
        public string ReleasePointStatusCodeYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReleasePointIdentification", Order = 23)]
        // TSM:
        // public IdentificationDataType[] ReleasePointIdentification;
        public ReleasePointIdentificationDataType[] ReleasePointIdentification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReleasePointTest", Order = 24)]
        public ReleasePointTestDataType[] ReleasePointTest;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 25)]
        public GeographicCoordinatesDataType ReleasePointGeographicCoordinates;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteAddress", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class AddressDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The exact address where mail is intended to be delivered, including street addres" +
            "s, rural route, and P.O. Box.")]
        public string MailingAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The text that provides additional information to facilitate the delivery of mail." +
            "")]
        public string SupplementalAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name of the city or town.")]
        public string MailingAddressCityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The name of the county.")]
        public string MailingAddressCountyText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The alphabetic codes that represent the name of the principal administrative subd" +
            "ivision of the United States, Canada, or Mexico.")]
        public string MailingAddressStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The code that represents a U.S. ZIP code or International postal code.")]
        public string MailingAddressPostalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("A code designator used to identify a primary geopolitical unit of the world.")]
        public string MailingAddressCountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The physical location of a facility site or organization.")]
        public string LocationAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The text that provides additional information about a place, including a building" +
            " name with its secondary unit and number, an industrial park name, an installati" +
            "on name, or descriptive text where no formal address is available.")]
        public string SupplementalLocationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The name of the city, town, village, or other locality.")]
        public string LocalityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The alphabetic codes that represent the name of the principal administrative subd" +
            "ivision of the United States, Canada, or Mexico.")]
        public string LocationAddressStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The code that represents a U.S. ZIP code or International postal code.")]
        public string LocationAddressPostalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("A code designator used to identify a primary geopolitical unit of the world.")]
        public string LocationAddressCountryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Any comments regarding the address information.")]
        public string AddressComment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("IndividualCommunication", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class CommunicationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The number that identifies a particular telephone connection.  This includes the " +
            "prefix for international standards.")]
        public string TelephoneNumberText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The type of telephone connection. Examples include Fax, Home, Mobile, Office, etc" +
            ".")]
        public string TelephoneNumberTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The number assigned within an organization to an individual telephone that extend" +
            "s the external telephone number.")]
        public string TelephoneExtensionNumberText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A location within a system of worldwide electronic communication where a computer" +
            " user can access information or receive electronic mail.")]
        public string ElectronicAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("A resource address, usually consisting of the access protocol, the domain name, a" +
            "nd optionally, the path to a file or location.")]
        public string ElectronicAddressTypeName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("EventAttachedFile", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class AttachedFileDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The text describing the descriptive name used to represent the file, including fi" +
            "le extension.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AttachmentFileName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Description of file.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AttachmentFileDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The size of the attached file.")]
        public string AttachmentFileSize;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("A code describing the content type of a file.")]
        public string AttachmentFileContentTypeCode;
    }

    // TSM:
    /// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    //[System.Xml.Serialization.XmlRootAttribute("AffiliationIndividual", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    //public partial class IndividualDataType
    //{

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    //    [System.ComponentModel.DescriptionAttribute("The title held by a person in an organization.")]
    //    public string IndividualTitleText;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    //    [System.ComponentModel.DescriptionAttribute("The text that precedes an individual\'s name.")]
    //    public string NamePrefixText;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    //    [System.ComponentModel.DescriptionAttribute("The given name of an individual.")]
    //    public string FirstName;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    //    [System.ComponentModel.DescriptionAttribute("The middle name or initial of an individual.")]
    //    public string MiddleName;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
    //    [System.ComponentModel.DescriptionAttribute("The surname of an individual.")]
    //    public string LastName;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
    //    [System.ComponentModel.DescriptionAttribute("the text that follows an individuals name.")]
    //    public string NameSuffixText;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("IndividualIdentification", Order = 6)]
    //    // TSM:
    //    // public IdentificationDataType[] IndividualIdentification;
    //    public IndividualIdentificationDataType[] IndividualIdentification;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("IndividualAddress", Order = 7)]
    //    // TSM:
    //    // public AddressDataType[] IndividualAddress;
    //    public IndividualAddressDataType[] IndividualAddress;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("IndividualCommunication", Order = 8)]
    //    // TSM:
    //    // public CommunicationDataType[] IndividualCommunication;
    //    public IndividualCommunicationDataType[] IndividualCommunication;
    //}

    // TSM:
    /// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    //[System.Xml.Serialization.XmlRootAttribute("AffiliationOrganization", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    //public partial class OrganizationDataType
    //{

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    //    [System.ComponentModel.DescriptionAttribute("Name of the organization.")]
    //    [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
    //    public string OrganizationFormalName;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    //    [System.ComponentModel.DescriptionAttribute("Contains information on the percentage of ownership an organization has for a fac" +
    //        "ility site.")]
    //    public decimal PercentOwnership;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlIgnoreAttribute()]
    //    public bool PercentOwnershipSpecified;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    //    [System.ComponentModel.DescriptionAttribute("Consolidation methodology for an organization, including:  operation control, fin" +
    //        "ancial control, operation control and equity share, financial control and equity" +
    //        " share, equity share.")]
    //    public string ConsolidationMethodology;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("OrganizationIdentification", Order = 3)]
    //    // TSM:
    //    // public IdentificationDataType[] OrganizationIdentification;
    //    public OrganizationIdentificationDataType[] OrganizationIdentification;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("OrganizationAddress", Order = 4)]
    //    // TSM:
    //    // public AddressDataType[] OrganizationAddress;
    //    public OrganizationAddressDataType[] OrganizationAddress;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("OrganizationCommunication", Order = 5)]
    //    // TSM:
    //    // public CommunicationDataType[] OrganizationCommunication;
    //    public OrganizationCommunicationDataType[] OrganizationCommunication;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("OrganizationIndividual", Order = 6)]
    //    // TSM:
    //    // public IndividualDataType[] OrganizationIndividual;
    //    public OrganizationIndividualDataType[] OrganizationIndividual;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
    //    public AttachedFileDataType OrganizationAttachedFile;
    //}

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteAffiliation", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class AffiliationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Identifies the function that an organization or individual serves, or the relatio" +
            "nship between an individual or organization and the facility site.  Examples inc" +
            "lude: Internal Reviewer, Lead Verifier, Verifying Body.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string AffiliationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The date on which the affiliation between the organization or individual and the " +
            "facility, project, or action began.")]
        public System.DateTime AffiliationStartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AffiliationStartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The date on which the affiliation between the organization or individual and the " +
            "facility, project, or action ended.")]
        public System.DateTime AffiliationEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AffiliationEndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AffiliationOrganization", Order = 3)]
        // TSM:
        // public OrganizationDataType[] AffiliationOrganization;
        public AffiliationOrganizationDataType[] AffiliationOrganization;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AffiliationIndividual", Order = 4)]
        // TSM:
        // public IndividualDataType[] AffiliationIndividual;
        public AffiliationIndividualDataType[] AffiliationIndividual;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityNAICS", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class FacilityNAICSDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents a subdivision of an industry that accommodates user need" +
            "s in the United States.")]
        public string NAICSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name that indicates whether the associated NAICS Code represents the primary " +
            "activity occurring at the facility site.")]
        public string NAICSPrimaryIndicator;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySite", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class FacilitySiteDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code that identifies the Clean Air Act Stationary Source designation.  Examples i" +
            "nclude major, minor, and synthetic minor.")]
        public string FacilityCategoryCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name assigned to the facility site by the reporter.")]
        public string FacilitySiteName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Supplemental text that describes the facility site.")]
        public string FacilitySiteDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Code that identifies the operating status of the facility site.")]
        public string FacilitySiteStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The year in which the operating status became applicable.")]
        public string FacilitySiteStatusCodeYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The associated primary sector for a facility site.  Examples include:  General St" +
            "ationary Combustion, Energy Production, Cement Production, Waste Water Treatment" +
            ", etc.")]
        public string SectorTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The name of the regulatory state or region where the facility is located in.")]
        public string AgencyName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Any comments regarding the facility site.")]
        public string FacilitySiteComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityNAICS", Order = 8)]
        public FacilityNAICSDataType[] FacilityNAICS;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityIdentification", Order = 9)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public FacilityIdentificationDataType[] FacilityIdentification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AlternativeFacilityName", Order = 10)]
        public AlternativeFacilityNameDataType[] AlternativeFacilityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilitySiteAddress", Order = 11)]
        // TSM:
        // public AddressDataType[] FacilitySiteAddress;
        public FacilitySiteAddressDataType[] FacilitySiteAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public GeographicCoordinatesDataType FacilitySiteGeographicCoordinates;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilitySiteQualityIdentification", Order = 13)]
        // TSM:
        // public QualityIdentificationDataType[] FacilitySiteQualityIdentification;
        public FacilitySiteQualityIdentificationDataType[] FacilitySiteQualityIdentification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilitySiteAttachedFile", Order = 14)]
        public AttachedFileDataType FacilitySiteAttachedFile;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilitySiteAffiliation", Order = 15)]
        public AffiliationDataType[] FacilitySiteAffiliation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EmissionsUnit", Order = 16)]
        public EmissionsUnitDataType[] EmissionsUnit;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReleasePoint", Order = 17)]
        public ReleasePointDataType[] ReleasePoint;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("ExcludedLocationParameter", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class ExcludedLocationParameterDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Identifies the type of code or identifier that is being excluded.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LocationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The code value or the identifier for the location type code.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LocationParameter;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Any comments regarding the location.")]
        public string LocationComment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("Location", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class LocationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The list is from FIPS Counties codes used for the identification of the Counties " +
            "and County equivalents of the United States.")]
        public string StateAndCountyFIPSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the American Indian Tribe or Alaskan Native entity.")]
        public string TribalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The code that represents a State and Country for States in Mexico and Provinces i" +
            "n Canada.")]
        public string StateAndCountryFIPSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The identifier that represents the post 1990 census block, which is the smallest " +
            "geographic entity recognized by the census.")]
        public string CensusBlockIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The identifier that represents the post 1990 census tract, which is ideally a nei" +
            "ghborhood within a city.")]
        public string CensusTractIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The shape file identifier issued by EPA for a predefined geospatial shape.")]
        public string ShapeIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Any comments regarding the location.")]
        public string LocationComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ExcludedLocationParameter", Order = 7)]
        public ExcludedLocationParameterDataType[] ExcludedLocationParameter;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LocationEmissionsProcess", Order = 8)]
        // TSM:
        // public ProcessDataType[] LocationEmissionsProcess;
        public LocationProcessDataType[] LocationEmissionsProcess;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("MergedEvents", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class MergedEventsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An identifier provided by the land or event manager that identifies an event.  Th" +
            "is identifier is unique for each event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the information management system which has responsibili" +
            "ty for the data in a linked or interrelated information management system.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ProgramSystemCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The first data that the discrete event is reported with the complex event.")]
        public System.DateTime MergedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MergedDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Any comments regarding the merged event.")]
        public string MergedEventsComment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("GeospatialParameters", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class GeospatialParametersDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An identifier provided by the reporting agency that identifies the geospatial sha" +
            "pe file for the reported emissions.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ShapeFileIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Total area that is contained within the event shape for the reporting period.")]
        public string AreaWithinShape;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Code that identifies the unit of measure for the area within the shape file.")]
        public string AreaWithinShapeUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The percent of the area within the shape or perimeter that was affected by the ev" +
            "ent (e.g., area actually blackened by a fire).")]
        public decimal PercentofAreaProducingEmissions;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentofAreaProducingEmissionsSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Any comments regarding the geospatial parameters.")]
        public string GeospatialParametersComment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("EventEmissionsProcess", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class EventEmissionsProcessDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("EPA Source Classification Code that identifies an emissions process.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string SourceClassificationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The predominant configuration of the fuel burned (i.e., pile, windrow, broadcast " +
            "or natural).")]
        public string FuelConfigurationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Fuel per acre available to consume.")]
        public string FuelLoading;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Code that identifies the numerator of the unit of measure for the fuel loading.")]
        public string FuelLoadingUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("For a given day, the amount of fuel consumed in the defined geographic area.")]
        public string AmountofFuelConsumed;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Code that identifies the unit of measure for the amount of fuel consumed.")]
        public string AmountofFuelConsumedUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The ten-hour fuel moisture for the location, on the particular day the fire or sm" +
            "oldering occurred, in percent.")]
        public decimal PercentTenHourFuelMoisture;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentTenHourFuelMoistureSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The one-thousand-hour fuel moisture for the location, on the particular day the f" +
            "ire or smoldering occurred, in percent.")]
        public decimal PercentOneThousandHourFuelMoisture;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentOneThousandHourFuelMoistureSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The amount of water expressed as the percent of oven dry weight of living plant m" +
            "atter.")]
        public decimal PercentLiveFuelMoisture;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentLiveFuelMoistureSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The amount of water expressed as the percent of the oven dry weight of any cured " +
            "or dead plant part.  This may include dead plant matter still attached to living" +
            " plants.")]
        public decimal PercentDuffFuelMoisture;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentDuffFuelMoistureSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The amount of effective thermal energy (measured in million BTUs per hour or day)" +
            " available to provide buoyant plume rise.")]
        public string HeatRelease;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Code that identifies the unit of measure for heat release.")]
        public string HeatReleaseUnitofMeasureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Code identifying the method used for reducing emissions from prescribed fires, ag" +
            "ricultural fires, Native American Fires and Wildland Use fires emissions.")]
        public string EmissionReductionTechniqueCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Any comments regarding the event emissions process.")]
        public string EventEmissionsProcessComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EventEmissionsProcessEmissions", Order = 14)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        // public EmissionsDataType[] EventEmissionsProcessEmissions;
        public EventEmissionsEmissionsDataType[] EventEmissionsProcessEmissions;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("EventLocation", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class EventLocationDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The list is from FIPS Counties codes used for the identification of the Counties " +
            "and County equivalents of the United States.")]
        public string StateAndCountyFIPSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the American Indian Tribe or Alaskan Native entity.")]
        public string TribalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The code that represents a State and Country for States in Mexico and Provinces i" +
            "n Canada.")]
        public string StateAndCountryFIPSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public GeographicCoordinatesDataType EventGeographicCoordinates;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("GeospatialParameters", Order = 4)]
        public GeospatialParametersDataType[] GeospatialParameters;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EventEmissionsProcess", Order = 5)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public EventEmissionsProcessDataType[] EventEmissionsProcess;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("EventReportingPeriod", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class EventReportingPeriodDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The first day for which emissions are reported for the reporting period.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime EventBeginDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The last day for which emissions are reported for the reporting period.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public System.DateTime EventEndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identifies whether emissions reported are due to flaming, smoldering, or both.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EventStageCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The hour of the day in which the event began.  The hour is reported as a value be" +
            "tween 00 and 23 inclusive, representing the hours of the day in 24 increments.")]
        public string BeginHour;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The hour of the day in which the event ended.  The hour is reported as a value be" +
            "tween 00 and 23 inclusive, representing the hours of the day in 24 increments.")]
        public string EndHour;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Any comments regarding the event reporting period.")]
        public string EventReportingPeriodComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EventLocation", Order = 6)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public EventLocationDataType[] EventLocation;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("Event", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class EventDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An identifier provided by the land or event manager that identifies an event.  Th" +
            "is identifier is unique for each event.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EventIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the information management system which has responsibili" +
            "ty for the data in a linked or interrelated information management system.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ProgramSystemCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name of the event.")]
        public string EventName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Identifies the Federal, State, Private, Municipal, County, Tribal agency or land " +
            "owner that is managing the fire or responding to event.")]
        public string LandManager;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Description of the location of the event.")]
        public string LocationDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Code that identifies the classification of the fire.")]
        public string EventClassificationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The code that identifies the method used to determine the size of the event.")]
        public string EventSizeSourceCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The date on which the event was contained.")]
        public System.DateTime ContainmentDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ContainmentDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether a prescribed or agricultural fire has occurred previously at th" +
            "is location (Y/N).")]
        public string RecurrenceIndicatorCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The most recent year in which the fire recurred in this location.")]
        public string RecurrenceYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether ground-based data were included and if so, identifies their sou" +
            "rce.")]
        public string GroundBasedDataSourceCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Indicates whether remotely-sensed data were included and if so, identifies their " +
            "source.")]
        public string RemoteSensingDataSourceCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("The model(s) used to calculate fuel consumption and emissions estimates.")]
        public string FuelConsumptionAndEmissionsModelCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("The fuel model used to characterize available fuel beds (e.g., FCCS or NFDRS).")]
        public string FuelTypeModelCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("The method used (on-site survey vs. GIS overlay) to select the appropriate fuel b" +
            "eds (e.g., red spruce, chaparral, sawgrass, or logging slash).")]
        public string FuelSelectionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("The method used to ignite the fire (i.e., DAID, helitorch, or driptorch).")]
        public string IgnitionMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("The location and distribution of the ignition points within the burn area (e.g., " +
            "center or multiple).")]
        public string IgnitionLocationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("The  technique used to direct the orientation of the fire\'s movement with respect" +
            " to the wind (i.e., backing, strip-heading, or flanking).")]
        public string IgnitionOrientationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Any comments regarding the event.")]
        public string EventComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EventAttachedFile", Order = 19)]
        public AttachedFileDataType EventAttachedFile;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MergedEvents", Order = 20)]
        public MergedEventsDataType[] MergedEvents;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EventReportingPeriod", Order = 21)]
        public EventReportingPeriodDataType[] EventReportingPeriod;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("QualityFinding", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class QualityFindingDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("An identifier for the quality finding.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string QualityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the information management system which has responsibili" +
            "ty for the data in a linked or interrelated information management system.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ProgramSystemCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identifies the type of verification, such as entity inventory or emissions reduct" +
            "ion project. ")]
        public string QualityVerificationType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The nature of the verification report issued. Examples include: adverse or qualif" +
            "ied.")]
        public string QualityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Any exceptions that the verifier has reported.")]
        public string QualityExceptions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The quality or verification status of the facility site, emissions unit or emissi" +
            "ons. Examples include:  verified or unverified.")]
        public string QualityStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The degree of assurance the intended user required in the verification findings. " +
            " Examples include:  reasonable and limited.")]
        public string QualityLevelofAssuranceCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The source of the standard such as ISO 14064-3, TCR GVP, CCAR GVP, etc.")]
        public string QualityStandardsSource;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Date on which status was determined.")]
        public System.DateTime QualityDeterminationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool QualityDeterminationDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        // TSM:
        // public OrganizationDataType QualityFindingOrganization;
        public QualityFindingOrganizationDataType[] QualityFindingOrganization;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("QualityFindingAttachedFile", Order = 10)]
        public AttachedFileDataType QualityFindingAttachedFile;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("CERS", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class CERSDataType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identifier of a user record.  This identifier is assigned by the receiving" +
            " system and is unique for each user.  Permissions for updating data are granted " +
            "based on the user identification.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string UserIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the information management system which has responsibili" +
            "ty for the data in a linked or interrelated information management system.  ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ProgramSystemCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The year of the submitted emissions.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EmissionsYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The name of the model or the conversion tool used for generating the emissions da" +
            "ta.")]
        public string Model;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The version of the model or conversion tool.")]
        public string ModelVersion;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Date that the data being submitted were created, or the date when the model gener" +
            "ating the data was run.")]
        public System.DateTime EmissionsCreationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EmissionsCreationDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Any comments regarding the file submission.")]
        public string SubmittalComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilitySite", Order = 7)]
        public FacilitySiteDataType[] FacilitySite;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Location", Order = 8)]
        public LocationDataType[] Location;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Event", Order = 9)]
        public EventDataType[] Event;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("QualityFinding", Order = 10)]
        public QualityFindingDataType[] QualityFinding;
    }
}
