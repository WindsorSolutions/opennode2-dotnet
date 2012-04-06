namespace Windsor.Node2008.WNOSPlugin.UIC_20
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("WellTypeDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class WellTypeDetailDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Well Type table - The first four characters are the prim" +
            "acy agency code (appendix D). The rest is DI program or State’s choice (letters " +
            "and numbers only) identifying unique well type (e.g. TXEQWDW369, …).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string WellTypeIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Type of injection wells located at the listed facility.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string WellTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Date that well type is determined (YYYYMMDD).  This field ONLY applies when the well changes" +
            " from one well type to another well type (e.g. converted from injection to produ" +
            "ction).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string WellTypeDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Well table.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string WellTypeWellIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("WellStatusDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class WellStatusDetailType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Well Status table - The first four characters are the pr" +
            "imacy agency code (appendix D). The rest is DI program or State’s choice (letter" +
            "s and numbers only identifying the unique Well Status (e.g. TXEQ WDW369, …).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string WellStatusIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Date that well status is determined (YYYYMMDD).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string WellStatusDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The current operating status of well.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public WellStatusOperatingStatusType WellStatusOperatingStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Well table.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string WellStatusWellIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("WellStatusOperatingStatusCode", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public enum WellStatusOperatingStatusType
    {

        /// <remarks/>
        AC,

        /// <remarks/>
        UC,

        /// <remarks/>
        TA,

        /// <remarks/>
        PA,

        /// <remarks/>
        AN,

        /// <remarks/>
        PW,

        /// <remarks/>
        PI,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("LocationDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class LocationDetailType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Location table - The first four characters are the prima" +
            "cy agency code (appendix D). The rest is DI program or State’s choice (letters a" +
            "nd numbers only identifying unique location (e.g. 03DI0000000000M00905).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LocationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name of the U.S. county or county equivalent in which the regulated well is p" +
            "hysically located.")]
        public string LocationAddressCounty;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute(@"Quantitative measurement of the amount of deviation from true value in a measurement for latitude or longitude (estimate of error).  It describes the correctness of the latitude/longitude measurement, in meters.  Only the least accurate measurement is recorded, regardless whether it is for longitude or latitude.")]
        public string LocationAccuracyValueMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Code representing the category of the feature referenced by the latitude and long" +
            "itude.")]
        public string GeographicReferencePointCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code representing the reference standard for three dimensional and horizontal pos" +
            "itioning established by the U.S. National Geodetic Survey (NGS) and other bodies" +
            ".")]
        public string HorizontalCoordinateReferenceSystemDatumCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Code representing the method used to determine the latitude/longitude.  This repr" +
            "esents the primary source of the data.")]
        public string HorizontalCollectionMethodCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Code representing the value indicating whether the latitude and longitude coordin" +
            "ates represent a point, multiple points on a line, or an area.")]
        public string LocationPointLineAreaCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Code representing the scale of the map used to determine the latitude and longitu" +
            "de coordinates.")]
        public string SourceMapScaleNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Well table.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LocationWellIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("Coordinate representing a location on the surface of the earth, using the earth\'s" +
            " Equator as the origin, reported in decimal format.  If an area permit is being " +
            "requested, give the latitude and longitude of the approximate center of the area" +
            ".")]
        public string LatitudeMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute(@"Coordinate representing a location on the surface of the earth, using the Prime Meridian (Greenwich, England) as the origin, reported in decimal format. If an area permit is being requested, give the latitude and longitude of the approximate center of the area.")]
        public string LongitudeMeasure;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("CorrectionDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class CorrectionDetailType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Correction table - The first four characters are the pri" +
            "macy agency code (appendix D). The rest is DI program or State’s choice (letters" +
            " and numbers only identifying the unique  corrective action (e.g. 04DI00000139, " +
            "…).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string CorrectionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Type of actions taken to correct deficiencies.")]
        public string CorrectionActionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Narrative description of actions taken by the facility or assistance to help the " +
            "facility come into compliance.")]
        public string CorrectionCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The unique identification of Inspection table.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string CorrectionInspectionIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityInspectionDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class FacilityInspectionDetailType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Inspection table - The first four characters are the pri" +
            "macy agency code (appendix D). The rest is DI program or State’s choice (letters" +
            " and numbers only) identifying unique  inspection (e.g. WYEQ00 000566, …).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string InspectionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The date inspection action was completed (YYYYMMDD).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string InspectionActionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The type of inspection action that was conducted.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public InspectionTypeActionCode InspectionTypeActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Facility table- This field ONLY applies for Class V “No " +
            "Well” inspection.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string InspectionFacilityIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public enum InspectionTypeActionCode
    {

        /// <remarks/>
        MI,

        /// <remarks/>
        EC,

        /// <remarks/>
        CO,

        /// <remarks/>
        WP,

        /// <remarks/>
        RP,

        /// <remarks/>
        NW,

        /// <remarks/>
        FI,

        /// <remarks/>
        OT,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("WellInspectionDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class WellInspectionDetailType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Inspection table - The first four characters are the pri" +
            "macy agency code (appendix D). The rest is DI program or State’s choice (letters" +
            " and numbers only) identifying unique  inspection (e.g. WYEQ00 000566, …).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string InspectionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute(@"Compliance assistance provided by the inspector based on national policy:

-- General Assistance: involves distributing prepared information on regulatory compliance, P2 or other written materials/websites.

-- Site-specific Assistance: involves on-site assistance by the inspector to support actions taken to address deficiencies.")]
        public string InspectionAssistanceCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Potential violations found by EPA inspector during inspection.")]
        public string InspectionDeficiencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The date inspection action was completed (YYYYMMDD).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string InspectionActionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute(@"The reason for performing a Compliance Monitoring action:

-- Agency Priority: The compliance monitoring action was performed in furtherance of a priority or initiative of the Compliance Monitoring Agency or a partner agency.

-- Core Program: The compliance monitoring action was performed as part of the Compliance Monitoring Agency's core programmatic activities.

-- Selected Monitoring Action: The Compliance Monitoring Agency selected the facility or regulated entity for compliance monitoring in response to a referral from another unit. 
")]
        public string InspectionICISComplianceMonitoringReasonCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Type of compliance monitoring taken by a regulatory agency.")]
        public string InspectionICISComplianceMonitoringTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Type of compliance activity taken by a regulatory agency.")]
        public string InspectionICISComplianceActivityTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The name of Memorandum of Agreement (MOA) associated with the activity.")]
        public string InspectionICISMOAName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The name of regional priority associated with the activity.")]
        public string InspectionICISRegionalPriorityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The type of inspection action that was conducted.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public InspectionTypeActionCode InspectionTypeActionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Well table.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string InspectionWellIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CorrectionDetail", Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Container for Correction information.")]
        public CorrectionDetailType[] CorrectionDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityResponseDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class ResponseDetailDataType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Enforcement table - The first four characters are the pr" +
            "imacy agency code (Appendix D). The rest is DI program or State’s choice (letter" +
            "s and numbers only identifying unique  enforcement action (e.g. 08DI000766, …).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ResponseEnforcementIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Violation table - The first four characters are the prim" +
            "acy agency code (Appendix D). The rest is DI program or State’s choice (letters " +
            "and numbers only identifying unique violation (e.g. 08DI000905, …).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ResponseViolationIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityViolationDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class FacilityViolationDetailType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Violation table - The first four characters are the prim" +
            "acy agency code (appendix D).  The rest is DI program or State’s choice (letters" +
            " and numbers only) identifying unique  violation (e.g. 08DI000366, …).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ViolationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Well in noncompliance has allegedly contaminated an underground source of drinkin" +
            "g water (USDW) this year to date.")]
        public string ViolationContaminationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A violation that results in the well potentially or actually endangering the USDW" +
            ".  The endangering fluid contaminant from the well is in violation of RCRA or SD" +
            "WA or applicable regulations.")]
        public string ViolationEndangeringCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The calendar date, determined by the Responsible Authority, on which the regulate" +
            "d entity actually returned to compliance with respect to the legal obligation th" +
            "at is the subject of the violation determined date (YYYYMMDD).")]
        public string ViolationReturnComplianceDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The indication whether or not the violation is in Significant Non-Compliance (SNC" +
            ").")]
        public string ViolationSignificantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The calendar date the Responsible Authority determines that a regulated entity is" +
            " in violation of a legally enforceable obligation (YYYYMMDD).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ViolationDeterminedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The type of violation that is the subject of the Violation Date.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ViolationTypeCodeType ViolationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Facility table-  This field ONLY applies for Class V vio" +
            "lations at FACILITY.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ViolationFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityResponseDetail", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Container for Response information.")]
        //TSM:
        //public ResponseDetailDataType[] FacilityResponseDetail;
        public FacilityResponseDetailDataType[] FacilityResponseDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("ViolationTypeCode", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public enum ViolationTypeCodeType
    {

        /// <remarks/>
        UI,

        /// <remarks/>
        MI,

        /// <remarks/>
        IP,

        /// <remarks/>
        PA,

        /// <remarks/>
        FO,

        /// <remarks/>
        FA,

        /// <remarks/>
        MR,

        /// <remarks/>
        FI,

        /// <remarks/>
        OM,

        /// <remarks/>
        OT,

        /// <remarks/>
        FR,

        /// <remarks/>
        MO,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("WellViolationDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class WellViolationDetailType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Violation table - The first four characters are the prim" +
            "acy agency code (appendix D).  The rest is DI program or State’s choice (letters" +
            " and numbers only) identifying unique  violation (e.g. 08DI000366, …).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ViolationIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Well in noncompliance has allegedly contaminated an underground source of drinkin" +
            "g water (USDW) this year to date.")]
        public string ViolationContaminationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A violation that results in the well potentially or actually endangering the USDW" +
            ".  The endangering fluid contaminant from the well is in violation of RCRA or SD" +
            "WA or applicable regulations.")]
        public string ViolationEndangeringCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The calendar date, determined by the Responsible Authority, on which the regulate" +
            "d entity actually returned to compliance with respect to the legal obligation th" +
            "at is the subject of the violation determined date (YYYYMMDD).")]
        public string ViolationReturnComplianceDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The indication whether or not the violation is in Significant Non-Compliance (SNC" +
            ").")]
        public string ViolationSignificantCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The calendar date the Responsible Authority determines that a regulated entity is" +
            " in violation of a legally enforceable obligation (YYYYMMDD).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ViolationDeterminedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The type of violation that is the subject of the Violation Date.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ViolationTypeCodeType ViolationTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Well table.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ViolationWellIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WellResponseDetail", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Container for Response information.")]
        //TSM:
        //public ResponseDetailDataType[] WellResponseDetail;
        public WellResponseDetailDataType[] WellResponseDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("MITestDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class MITestDetailType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Mechanical Integrity Test table - The first four charact" +
            "ers are the primacy agency code (appendix D). The rest is DI program or State’s " +
            "choice (letters and numbers only) identifying unique MIT (e.g. 03DIVA000235, …)." +
            "")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MechanicalIntegrityTestIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The date that mechanical integrity test was completed (YYYYMMDD).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MechanicalIntegrityTestCompletedDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The result of mechanical integrity test on that date (see above).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public MechanicalIntegrityTestResultType MechanicalIntegrityTestResultCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Type of mechanical integrity test.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public MechanicalIntegrityTestType MechanicalIntegrityTestTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The date (corresponding to Remedial Action Type) when a well that failed an MI te" +
            "st received successful remedial action (YYYYMMDD).")]
        public string MechanicalIntegrityTestRemedialActionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Type of successful remedial action that well has received on the remedial action " +
            "date.")]
        public string MechanicalIntegrityTestRemedialActionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Well table.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string MechanicalIntegrityTestWellIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("MechanicalIntegrityTestResultCode", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public enum MechanicalIntegrityTestResultType
    {

        /// <remarks/>
        PS,

        /// <remarks/>
        FU,

        /// <remarks/>
        FP,

        /// <remarks/>
        FA,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("MechanicalIntegrityTestTypeCode", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public enum MechanicalIntegrityTestType
    {

        /// <remarks/>
        AP,

        /// <remarks/>
        CT,

        /// <remarks/>
        MR,

        /// <remarks/>
        WI,

        /// <remarks/>
        WA,

        /// <remarks/>
        AT,

        /// <remarks/>
        SR,

        /// <remarks/>
        OL,

        /// <remarks/>
        CR,

        /// <remarks/>
        TN,

        /// <remarks/>
        RC,

        /// <remarks/>
        CB,

        /// <remarks/>
        OA,

        /// <remarks/>
        RS,

        /// <remarks/>
        DC,

        /// <remarks/>
        OF,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("EngineeringDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class EngineeringDetailType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Engineering table - The first four characters are the pr" +
            "imacy agency code (appendix D). The rest is DI program or State’s choice (letter" +
            "s and numbers only identifying unique engineering information  (e.g. WYEQ0000054" +
            "3, …).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EngineeringIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Maximum flow rate of injectate in the current quartermeasured in gallons per minu" +
            "te.")]
        public string EngineeringMaximumFlowRateNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Permitted on-site injected volume measured in million gallon per month.")]
        public string EngineeringPermittedOnsiteInjectionVolumeNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Permitted off-site injected volume measured in million gallon per month.")]
        public string EngineeringPermittedOffsiteInjectionVolumeNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of an injection well.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EngineeringWellIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("ConstituentDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class ConstituentDetailType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Constituent  table - The first four characters are the p" +
            "rimacy agency code (appendix D). The rest is DI program or State’s choice (lette" +
            "rs and numbers only) identifying constituent information (e.g. WYEQ0000000000 00" +
            "0389, …).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ConstituentIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The concentration of the individual waste constituent as reported by EPA Regional" +
            " staff and/or state agency staff (measured in mg/l or pCi/l).")]
        public string MeasureValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Unit of measuring concentration (mg/l or pCi/l).")]
        public string MeasureUnitCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The chemical name or a description of the waste, in accordance with EPA Chemical/" +
            "Biological Internal Tracking Name (http://www.epa.gov/srs/).")]
        public string ConstituentNameText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Unique identification for waste records.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ConstituentWasteIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("WasteDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class WasteDetailType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification for waste records - The first four characters are primacy a" +
            "gency code (appendix D) and followed by 8 additional characters identifying uniq" +
            "ue waste (e.g. WYEQ00000543, …).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string WasteIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The RCRA or state waste code included when the constituent has been assigned a co" +
            "de.")]
        public string WasteCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A classification of the waste stream that contains various constituents and waste" +
            " codes in various concentrations.  These are liquids waste approved to go down t" +
            "he well.")]
        public string WasteStreamClassificationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of an injection well.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string WasteWellIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ConstituentDetail", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Container for Constituent information.")]
        public ConstituentDetailType[] ConstituentDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("WellDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class WellDetailType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Well table - The first four characters are the primacy a" +
            "gency code (appendix D). The rest is DI program or State’s choice (letters and n" +
            "umbers only) identifying unique well (e.g. TXEQWDW366, …).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string WellIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Well injects into exempting aquifer.")]
        public string WellAquiferExemptionInjectionCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The vertical depth (in feet) from the surface to the bottom of injection well.")]
        public string WellTotalDepthNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("High priority Class V wells include all active motor vehicle waste disposal wells" +
            " (MVWDWs) and large-capacity cesspools regulated under the 1999 Class V Rule, in" +
            "dustrial wells, plus all other Class V wells identified as high priority by Stat" +
            "e Directors.")]
        public string WellHighPriorityDesignationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Contact record.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string WellContactIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Facility record.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string WellFacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Unique identification for Geology record.")]
        public string WellGeologyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Name of the area where many Class III, IV, or V ( storm water drainage) injection" +
            " wells are physically located or conducted.")]
        public string WellSiteAreaNameText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Permit table.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string WellPermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The well identification assigned by primacy state or direct implementation (DI) p" +
            "rogram.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string WellStateIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("State postal code or tribal code (for American Indian or Alaska Native) indicatin" +
            "g a program Directly Implemented by an EPA region (for DI programs).")]
        public string WellStateTribalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The well location in relation to the boundary of the ground water based source wa" +
            "ter area (SWA) delineated by the primacy state under the State Source Water Asse" +
            "ssment Program (SWAP).")]
        public string WellInSourceWaterAreaLocationText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("The name that designates the well.")]
        public string WellName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WellStatusDetail", Order = 13)]
        [System.ComponentModel.DescriptionAttribute("Container for Well Status information.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public WellStatusDetailType[] WellStatusDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WellTypeDetail", Order = 14)]
        [System.ComponentModel.DescriptionAttribute("Container for Well Type information.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public WellTypeDetailDataType[] WellTypeDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("Container for Location information.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public LocationDetailType LocationDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WellViolationDetail", Order = 16)]
        [System.ComponentModel.DescriptionAttribute("Container for Well Violation information.")]
        public WellViolationDetailType[] WellViolationDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WellInspectionDetail", Order = 17)]
        [System.ComponentModel.DescriptionAttribute("Container for Well Inspection information.")]
        public WellInspectionDetailType[] WellInspectionDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MITestDetail", Order = 18)]
        [System.ComponentModel.DescriptionAttribute("Container for MI Test information.")]
        public MITestDetailType[] MITestDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EngineeringDetail", Order = 19)]
        [System.ComponentModel.DescriptionAttribute("Container for Engineering information.")]
        public EngineeringDetailType[] EngineeringDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WasteDetail", Order = 20)]
        [System.ComponentModel.DescriptionAttribute("Container for Waste information.")]
        public WasteDetailType[] WasteDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityList", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class FacilityListType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Container for Facility information.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public FacilityDetailType FacilityDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WellDetail", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Container for Well information.")]
        public WellDetailType[] WellDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class FacilityDetailType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Facility table - The first four characters are the prima" +
            "cy agency code (appendix D).  The rest is DI program or State’s choice (letters " +
            "and numbers only) identifying unique facility (e.g. DENR0000197590, …).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FacilityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The name of the city, town, or village where the facility is located.")]
        public string LocalityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The public or commercial name of a facility site (i.e., the full name that common" +
            "ly appears on invoices, signs, or other business documents, or as assigned by th" +
            "e state when the name is ambiguous).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FacilitySiteName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Status of review of no-migration petition (this is a technical demonstration requ" +
            "ired before Class I hazardous waste injection facilities may begin operating).")]
        public string FacilityPetitionStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The U.S. Postal Service abbreviation that represents the state.")]
        public string LocationAddressStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Facility identification assigned by DI program or primacy state.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string FacilityStateIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The address that describes the physical (geographic) location of the main entranc" +
            "e of a facility site, including urban-style street address or rural address, wel" +
            "l field entrance, etc.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LocationAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Class I well waste is disposed in either of two types of facilities: (1) Commerci" +
            "al- where the waste is generated offsite but transported to the disposal facilit" +
            "y, or (2) Non-commercial-where the waste is generated onsite and disposed there " +
            "also.")]
        public string FacilitySiteTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The NAICS code that represents a subdivision of an industry that accommodates use" +
            "r needs in the United States (6-digits)--(Only primary code).")]
        public string NAICSCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the economic activity of a company (4-digits)--(only the" +
            " primary code).")]
        public string SICCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digi" +
            "t extension code (if available) that represents the geographic segment that is a" +
            " subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic lo" +
            "cation.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string LocationAddressPostalCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityInspectionDetail", Order = 11)]
        [System.ComponentModel.DescriptionAttribute("Container for Facility Inspection information.")]
        public FacilityInspectionDetailType[] FacilityInspectionDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityViolationDetail", Order = 12)]
        [System.ComponentModel.DescriptionAttribute("Container for Facility Violation information.")]
        public FacilityViolationDetailType[] FacilityViolationDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("ContactDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class ContactDetailType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Contact table - The first four characters are the primac" +
            "y agency code (appendix D). The rest is DI program or State’s choice (letters an" +
            "d numbers only) identifying unique contact for a well. (e.g. NMNR30005003490000)" +
            ".")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ContactIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The phone number of a contact for the well.")]
        public string TelephoneNumberText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The legal and complete name of a contact person (including first name, middle nam" +
            "e or initial, and surname) for the well.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string IndividualFullName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The name of the city, town, or village of the contact for a well.")]
        public string ContactCityName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The name of the state where the contact is located or the name of the country, if" +
            " outside the U.S. ")]
        public string ContactAddressStateCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The street address of the contact for a well.  This can be physical location or a" +
            " mailing address.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ContactAddressText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute(@"The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. ")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ContactAddressPostalCode;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("PermitActivityDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class PermitActivityDetailType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Permit Activity table - The first four characters are th" +
            "e primacy agency code (appendix D). The rest is DI program or State’s choice (le" +
            "tters and numbers only) identifying the unique permit activity (e.g. TXRC0000000" +
            "000WDW567, …).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PermitActivityIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Type of permit action or authorization by rule.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public PermitActivityActionTypeCodeType PermitActivityActionTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute(@"The calendar date (YYYYMMDD) corresponding to each acceptable value of Permit Action Type includes:

- Application Date for Permit Issuance: Date of receipt of an application by state or DI program for permit issued.

- Application Date for Major Permit Modification: Date of receipt of an application by the state or DI program for major permit modification.

- Permit Issued Date: Date of signature (approval) by state/DI official for the issuance/denial/ withdrawal of permit.

- Permit Denied/Withdrawn Date: Date of signature by state/DI official for the denial/withdrawal of permit.

- Approved Major Permit Modification Date: Approval date of a major permit modification.  This is a date where an approved major modification requires a complete technical review, public notification or review, and a final decision document signed by the regulating authority.

- File Review Date (Class II only): Date of rule-authorized file review to determine whether the well is in compliance with UIC regulatory requirements.
			")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PermitActivityDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Permit table.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PermitActivityPermitIdentifier;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("PermitActivityActionTypeCode", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public enum PermitActivityActionTypeCodeType
    {

        /// <remarks/>
        AI,

        /// <remarks/>
        AM,

        /// <remarks/>
        PI,

        /// <remarks/>
        PD,

        /// <remarks/>
        PM,

        /// <remarks/>
        PN,

        /// <remarks/>
        FR,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("PermitDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class PermitDetailType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Permit table - The first four characters are the primacy" +
            " agency code (appendix D). The rest is DI program or State’s choice (letters and" +
            " numbers only) identifying unique permit(e.g. 04DI0000000000WDW366, …).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PermitIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Number of wells identified in area of review (AOR) requiring corrective action.")]
        public string PermitAORWellNumberNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identification of whether well is permitted or rule authorized.  If the well is p" +
            "ermitted, the acceptable authorization types are individual, area, general, or e" +
            "mergency permits.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public PermitAuthorizedStatusCodeType PermitAuthorizedStatusCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Type of ownership for a UIC well.")]
        public string PermitOwnershipTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "normalizedString", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Identification assigned by DI program or primacy state to permit or rule authoriz" +
            "ed well.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PermitAuthorizedIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitActivityDetail", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Container for Permit Activity information.")]
        public PermitActivityDetailType[] PermitActivityDetail;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("PermitAuthorizedStatusCode", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public enum PermitAuthorizedStatusCodeType
    {

        /// <remarks/>
        IP,

        /// <remarks/>
        AP,

        /// <remarks/>
        GP,

        /// <remarks/>
        EP,

        /// <remarks/>
        RA,

        /// <remarks/>
        NO,

        /// <remarks/>
        OP,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("GeologyDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class GeologyDetailType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Geology table - The first four characters are the primac" +
            "y agency code (appendix D). The rest is DI program or State’s choice (letters an" +
            "d numbers only) identifying unique geology information (e.g. 04DI0000000000 0005" +
            "66, …).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string GeologyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Geologic formation name.")]
        public string GeologyConfiningZoneName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The top of the geologic arresting layer that keeps injectate confined in the inje" +
            "ction zone measured in feet below surface.")]
        public string GeologyConfiningZoneTopNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The bottom of the geologic arresting layer that keeps injectate confined in the i" +
            "njection zone OR:The top of the vertical dimension of the zone in which waste is" +
            " injected. -- measured in feet below surface.")]
        public string GeologyConfiningZoneBottomNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Confining zone data in the form of a simple lithologic description of the formati" +
            "on.")]
        public string GeologyLithologicConfiningZoneText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Geologic formation name for injection zone.")]
        public string GeologyInjectionZoneFormationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The bottom of the vertical dimension of the zone in which waste is injected, meas" +
            "ured in feet below surface.")]
        public string GeologyBottomInjectionZoneNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Injection zone data in the form of a simple lithologic description of the formati" +
            "on.")]
        public string GeologyLithologicInjectionZoneText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The top of the vertical dimension of the specific layer(s) of the Injection.")]
        public string GeologyTopInjectionIntervalNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The bottom of the vertical dimension of the specific layer(s) of the Injection Zo" +
            "ne in which waste is authorized to be injected into, measured in feet below surf" +
            "ace.")]
        public string GeologyBottomInjectionIntervalNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("The rate of diffusion of fluids (in this case liquid waste) under pressure throug" +
            "h porous material (formation rock) that is measured in millidarcies (mD).")]
        public string GeologyInjectioneZonePermeabilityRateNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The percent of pore space the injection zone formation rock contains (measured in" +
            " %).")]
        public string GeologyInjectionZonePorosityPercentNumeric;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("The depth (in feet) to the base of the underground source of drinking water (USDW" +
            ").")]
        public string GeologyUSDWDepthNumeric;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("EnforcementDetail", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public partial class EnforcementDetailType : Windsor.Commons.XsdOrm.BaseChildDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Unique identification of Enforcement table - The first four characters are the pr" +
            "imacy agency code (Appendix D). The rest is DI program or State’s choice (letter" +
            "s and numbers only) identifying unique  enforcement action (e.g. 08DI000566, …)." +
            "")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnforcementIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The calendar date the enforcement action was issued or filed (YYYYMMDD).")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string EnforcementActionDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The type of enforcement action taken by the EPA or states.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public EnforcementActionTypeDataType EnforcementActionType;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("EnforcementActionType", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    public enum EnforcementActionTypeDataType
    {

        /// <remarks/>
        FAO,

        /// <remarks/>
        NOV,

        /// <remarks/>
        CGT,

        /// <remarks/>
        DAO,

        /// <remarks/>
        CIR,

        /// <remarks/>
        CRR,

        /// <remarks/>
        SHT,

        /// <remarks/>
        PSE,

        /// <remarks/>
        TOA,

        /// <remarks/>
        OTR,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/uic/2")]
    [System.Xml.Serialization.XmlRootAttribute("UIC", Namespace = "http://www.exchangenetwork.net/schema/uic/2", IsNullable = false)]
    //TSM:
    //public partial class UICDataType : Windsor.Commons.XsdOrm.BaseDataType
    public partial class UICDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("4 character code of the Primacy Agency making the submission.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string PrimacyAgencyCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityList", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Container for multiple Facility information submissions.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public FacilityListType[] FacilityList;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ContactDetail", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Container for Contact information.")]
        public ContactDetailType[] ContactDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitDetail", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Container for Permit information.")]
        public PermitDetailType[] PermitDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("GeologyDetail", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Container for Geology information.")]
        public GeologyDetailType[] GeologyDetail;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EnforcementDetail", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Container for Enforcement information.")]
        public EnforcementDetailType[] EnforcementDetail;
    }
}
