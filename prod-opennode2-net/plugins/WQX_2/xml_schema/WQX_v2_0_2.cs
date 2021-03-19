namespace Windsor.Node2008.WNOSPlugin.WQX2XsdOrm
{
    using System;
    using System.Xml.Serialization;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;
    using Windsor.Commons.XsdOrm;
    using Windsor.Commons.Core;

    public static class WQXDataHelper
    {
        private const string PIPE = "|";
        private static readonly string[] PIPE_ARRAY = new string[] { PIPE };
        public static string StringsToPipedString(string[] strings)
        {
            string rtnString = null;
            if (!CollectionUtils.IsNullOrEmpty(strings))
            {
                rtnString = string.Join(PIPE, strings);
            }
            return rtnString;
        }
        public static string[] PipedStringToStrings(string value)
        {
            string[] rtnStrings = null;
            if (!string.IsNullOrEmpty(value))
            {
                rtnStrings = value.Split(PIPE_ARRAY, StringSplitOptions.RemoveEmptyEntries);
            }
            return rtnStrings;
        }

    }

    // string[] ActivityDataType.ActivityMetricDataType.IndexIdentifier -> Maps to single column -> WQX_ACTIVITYMETRIC.METRICINDEXID
    // string[] ResultDataType.BiologicalResultDescriptionDataType.TaxonomicDetailsDataType.HabitName -> Maps to single column -> WQX_RESULT.TAXDETAILSHABITNAME
    // string[] ResultDataType.BiologicalResultDescriptionDataType.TaxonomicDetailsDataType.FunctionalFeedingGroupName -> Maps to single column -> WQX_RESULT.TAXDETAILSFUNCFEEDINGGROUP
    // FrequencyClassInformationDataType[] ResultDataType.BiologicalResultDescriptionDataType.FrequencyClassInformation -> Maps to single columns -> WQX_RESULT.FREQCLASSDESCCODE, etc.
    // Why is the WQX_ACTIVITYGROUP.ACTIVITYID field present (an ActivityGroup can have many Activities)

    // OrganizationDataType
    [AppliedAttribute(typeof(OrganizationDescriptionDataType), "OrganizationIdentifier", typeof(DbIndexableAttribute))]
    [AppliedAttribute(typeof(OrganizationDescriptionDataType), "OrganizationIdentifier", typeof(ColumnAttribute), "ORGID", DbType.AnsiString, 30, false)]
    [AppliedAttribute(typeof(OrganizationDescriptionDataType), "OrganizationFormalName", typeof(ColumnAttribute), "ORGFORMALNAME", DbType.AnsiString, 120, false)]
    [AppliedAttribute(typeof(OrganizationDescriptionDataType), "OrganizationDescriptionText", typeof(ColumnAttribute), "ORGDESC", DbType.AnsiString, 500, true)]
    [AppliedAttribute(typeof(OrganizationDescriptionDataType), "TribalCode", typeof(ColumnAttribute), "TRIBALCODE", DbType.AnsiString, 3, true)]

    // ElectronicAddressDataType
    [AppliedAttribute(typeof(ElectronicAddressDataType), "ElectronicAddressText", typeof(ColumnAttribute), "ELECTRONICADDRESS", DbType.AnsiString, 120, false)]
    [AppliedAttribute(typeof(ElectronicAddressDataType), "ElectronicAddressTypeName", typeof(ColumnAttribute), "ELECTRONICADDRESSTYPE", DbType.AnsiString, 8, true)]

    // TelephonicDataType
    [AppliedAttribute(typeof(TelephonicDataType), "TelephoneNumberText", typeof(ColumnAttribute), "TELEPHONENUMBER", DbType.AnsiString, 15, false)]
    [AppliedAttribute(typeof(TelephonicDataType), "TelephoneNumberTypeName", typeof(ColumnAttribute), "TELEPHONENUMBERTYPE", DbType.AnsiString, 6, true)]
    [AppliedAttribute(typeof(TelephonicDataType), "TelephoneExtensionNumberText", typeof(ColumnAttribute), "TELEPHONEEXT", DbType.AnsiString, 6, true)]

    // OrganizationAddressDataType
    [AppliedAttribute(typeof(OrganizationAddressDataType), "AddressTypeName", typeof(ColumnAttribute), "ADDRESSTYPE", DbType.AnsiString, 8, true)]
    [AppliedAttribute(typeof(OrganizationAddressDataType), "AddressText", typeof(ColumnAttribute), "ADDRESS", DbType.AnsiString, 50, false)]
    [AppliedAttribute(typeof(OrganizationAddressDataType), "SupplementalAddressText", typeof(ColumnAttribute), "SUPPLEMENTALADDRESS", DbType.AnsiString, 120, true)]
    [AppliedAttribute(typeof(OrganizationAddressDataType), "LocalityName", typeof(ColumnAttribute), "LOCALITY", DbType.AnsiString, 30, true)]
    [AppliedAttribute(typeof(OrganizationAddressDataType), "StateCode", typeof(ColumnAttribute), "STATECODE", DbType.AnsiString, 2, true)]
    [AppliedAttribute(typeof(OrganizationAddressDataType), "PostalCode", typeof(ColumnAttribute), "POSTALCODE", DbType.AnsiString, 10, true)]
    [AppliedAttribute(typeof(OrganizationAddressDataType), "CountryCode", typeof(ColumnAttribute), "COUNTRYCODE", DbType.AnsiString, 2, true)]
    [AppliedAttribute(typeof(OrganizationAddressDataType), "CountyCode", typeof(ColumnAttribute), "COUNTYCODE", DbType.AnsiString, 3, true)]

    // ProjectDataType
    [AppliedAttribute(typeof(ProjectDataType), "ProjectIdentifier", typeof(DbIndexableAttribute))]
    [AppliedAttribute(typeof(ProjectDataType), "ProjectIdentifier", typeof(ColumnAttribute), "PROJECTID", DbType.AnsiString, 35, false)]
    [AppliedAttribute(typeof(ProjectDataType), "ProjectName", typeof(ColumnAttribute), "PROJECTNAME", DbType.AnsiString, 120, false)]
    [AppliedAttribute(typeof(ProjectDataType), "ProjectDescriptionText", typeof(ColumnAttribute), "PROJECTDESC", DbType.AnsiString, 1999, true)]
    [AppliedAttribute(typeof(ProjectDataType), "SamplingDesignTypeCode", typeof(ColumnAttribute), "SAMPLINGDESIGNTYPECODE", DbType.AnsiString, 20, true)]
    [AppliedAttribute(typeof(ProjectDataType), "QAPPApprovedIndicator", typeof(ColumnAttribute), "QAPPAPPROVEDIND", DbType.AnsiStringFixedLength, 1, true)]
    [AppliedAttribute(typeof(ProjectDataType), "QAPPApprovalAgencyName", typeof(ColumnAttribute), "QAPPAPPROVALAGENCYNAME", DbType.AnsiString, 50, true)]

    // MonitoringLocationDataType
    [AppliedAttribute(typeof(MonitoringLocationIdentityDataType), "MonitoringLocationIdentifier", typeof(DbIndexableAttribute))]
    [AppliedAttribute(typeof(MonitoringLocationIdentityDataType), "MonitoringLocationIdentifier", typeof(ColumnAttribute), "MONITORINGLOCATIONID", DbType.AnsiString, 35, false)]
    [AppliedAttribute(typeof(MonitoringLocationIdentityDataType), "MonitoringLocationName", typeof(ColumnAttribute), "MONLOCNAME", DbType.AnsiString, 255, false)]
    [AppliedAttribute(typeof(MonitoringLocationIdentityDataType), "MonitoringLocationTypeName", typeof(ColumnAttribute), "MONLOCTYPE", DbType.AnsiString, 45, false)]
    [AppliedAttribute(typeof(MonitoringLocationIdentityDataType), "MonitoringLocationDescriptionText", typeof(ColumnAttribute), "MONLOCDESC", DbType.AnsiString, 1999, true)]
    [AppliedAttribute(typeof(MonitoringLocationIdentityDataType), "HUCEightDigitCode", typeof(ColumnAttribute), "HUCEIGHTDIGITCODE", DbType.AnsiString, 8, true)]
    [AppliedAttribute(typeof(MonitoringLocationIdentityDataType), "HUCTwelveDigitCode", typeof(ColumnAttribute), "HUCTWELVEDIGITCODE", DbType.AnsiString, 12, true)]
    [AppliedAttribute(typeof(MonitoringLocationIdentityDataType), "TribalLandIndicator", typeof(ColumnAttribute), "TRIBALLANDIND", DbType.AnsiStringFixedLength, 1, true)]
    [AppliedAttribute(typeof(MonitoringLocationIdentityDataType), "TribalLandName", typeof(ColumnAttribute), "TRIBALLANDNAME", DbType.AnsiString, 200, true)]
    [AppliedAttribute(typeof(MonitoringLocationGeospatialDataType), "LatitudeMeasure", typeof(ColumnAttribute), "LATITUDEMEASURE", DbType.AnsiString, 30, false)]
    [AppliedAttribute(typeof(MonitoringLocationGeospatialDataType), "LongitudeMeasure", typeof(ColumnAttribute), "LONGITUDEMEASURE", DbType.AnsiString, 30, false)]
    [AppliedAttribute(typeof(MonitoringLocationGeospatialDataType), "SourceMapScaleNumeric", typeof(ColumnAttribute), "SOURCEMAPSCALE", DbType.Int32, true)]
    [AppliedPathAttribute("MonitoringLocationGeospatial.HorizontalAccuracyMeasure.MeasureValue", typeof(ColumnAttribute), "HORIZACCURACYMEASURE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("MonitoringLocationGeospatial.HorizontalAccuracyMeasure.MeasureUnitCode", typeof(ColumnAttribute), "HORIZACCURACYMEASUREUNIT", DbType.AnsiString, 12, true)]
    [AppliedAttribute(typeof(MonitoringLocationGeospatialDataType), "HorizontalCollectionMethodName", typeof(ColumnAttribute), "HORIZCOLLMETHOD", DbType.AnsiString, 150, false)]
    [AppliedAttribute(typeof(MonitoringLocationGeospatialDataType), "HorizontalCoordinateReferenceSystemDatumName", typeof(ColumnAttribute), "HORIZCOORDREFSYSDATUM", DbType.AnsiString, 6, false)]
    [AppliedPathAttribute("MonitoringLocationGeospatial.VerticalMeasure.MeasureValue", typeof(ColumnAttribute), "VERTICALMEASURE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("MonitoringLocationGeospatial.VerticalMeasure.MeasureUnitCode", typeof(ColumnAttribute), "VERTICALMEASUREUNIT", DbType.AnsiString, 12, true)]
    [AppliedAttribute(typeof(MonitoringLocationGeospatialDataType), "VerticalCollectionMethodName", typeof(ColumnAttribute), "VERTICALCOLLMETHOD", DbType.AnsiString, 50, true)]
    [AppliedAttribute(typeof(MonitoringLocationGeospatialDataType), "VerticalCoordinateReferenceSystemDatumName", typeof(ColumnAttribute), "VERTICALCOORDREFSYSDATUM", DbType.AnsiString, 10, true)]
    [AppliedAttribute(typeof(MonitoringLocationGeospatialDataType), "CountryCode", typeof(ColumnAttribute), "COUNTRYCODE", DbType.AnsiString, 2, true)]
    [AppliedAttribute(typeof(MonitoringLocationGeospatialDataType), "StateCode", typeof(ColumnAttribute), "STATECODE", DbType.AnsiString, 2, true)]
    [AppliedAttribute(typeof(MonitoringLocationGeospatialDataType), "CountyCode", typeof(ColumnAttribute), "COUNTYCODE", DbType.AnsiString, 3, true)]
    [AppliedAttribute(typeof(WellInformationDataType), "WellTypeText", typeof(ColumnAttribute), "WELLTYPE", DbType.AnsiString, 255, true)]
    [AppliedAttribute(typeof(WellInformationDataType), "AquiferName", typeof(ColumnAttribute), "AQUIFERNAME", DbType.AnsiString, 120, true)]
    [AppliedAttribute(typeof(WellInformationDataType), "FormationTypeText", typeof(ColumnAttribute), "FORMATIONTYPE", DbType.AnsiString, 50, true)]
    [AppliedPathAttribute("WellHoleDepthMeasure.MeasureValue", typeof(ColumnAttribute), "WELLHOLEDEPTHMEASURE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("WellHoleDepthMeasure.MeasureUnitCode", typeof(ColumnAttribute), "WELLHOLEDEPTHMEASUREUNIT", DbType.AnsiString, 12, true)]

    // BiologicalHabitatIndexDataType
    [AppliedAttribute(typeof(BiologicalHabitatIndexDataType), "IndexIdentifier", typeof(ColumnAttribute), "INDEXID", DbType.AnsiString, 35, false)]
    [AppliedAttribute(typeof(IndexTypeDataType), "IndexTypeIdentifier", typeof(ColumnAttribute), "INDEXTYPEID", DbType.AnsiString, 35, false)]
    [AppliedAttribute(typeof(IndexTypeDataType), "IndexTypeIdentifierContext", typeof(ColumnAttribute), "INDEXTYPEIDCONTEXT", DbType.AnsiString, 50, false)]
    [AppliedAttribute(typeof(IndexTypeDataType), "IndexTypeName", typeof(ColumnAttribute), "INDEXTYPENAME", DbType.AnsiString, 50, false)]
    [AppliedPathAttribute("IndexTypeCitation.ResourceTitleName", typeof(ColumnAttribute), "RESOURCETITLE", DbType.AnsiString, 120, true)]
    [AppliedPathAttribute("IndexTypeCitation.ResourceCreatorName", typeof(ColumnAttribute), "RESOURCECREATOR", DbType.AnsiString, 120, true)]
    [AppliedPathAttribute("IndexTypeCitation.ResourceSubjectText", typeof(ColumnAttribute), "RESOURCESUBJECT", DbType.AnsiString, 500, true)]
    [AppliedPathAttribute("IndexTypeCitation.ResourcePublisherName", typeof(ColumnAttribute), "RESOURCEPUBLISHER", DbType.AnsiString, 60, true)]
    [AppliedPathAttribute("IndexTypeCitation.ResourceDate", typeof(ColumnAttribute), "RESOURCEDATE", DbType.AnsiString, 10, true)]
    [AppliedPathAttribute("IndexTypeCitation.ResourceIdentifier", typeof(ColumnAttribute), "RESOURCEID", DbType.AnsiString, 255, true)]
    [AppliedAttribute(typeof(IndexTypeDataType), "IndexTypeScaleText", typeof(ColumnAttribute), "INDEXTYPESCALE", DbType.AnsiString, 50, true)]
    [AppliedAttribute(typeof(BiologicalHabitatIndexDataType), "IndexScoreNumeric", typeof(ColumnAttribute), "INDEXSCORE", DbType.AnsiString, 10, false)]
    [AppliedAttribute(typeof(BiologicalHabitatIndexDataType), "IndexQualifierCode", typeof(ColumnAttribute), "INDEXQUALIFIERCODE", DbType.AnsiString, 5, true)]
    [AppliedAttribute(typeof(BiologicalHabitatIndexDataType), "IndexCommentText", typeof(ColumnAttribute), "INDEXCOMMENT", DbType.AnsiString, 4000, true)]
    [AppliedAttribute(typeof(BiologicalHabitatIndexDataType), "IndexCalculatedDate", typeof(ColumnAttribute), "INDEXCALCULATEDDATE", DbType.AnsiString, 10, true)]
    [AppliedAttribute(typeof(BiologicalHabitatIndexDataType), "MonitoringLocationIdentifier", typeof(DbIndexableAttribute))]
    [AppliedAttribute(typeof(BiologicalHabitatIndexDataType), "MonitoringLocationIdentifier", typeof(ColumnAttribute), "MONLOCID", DbType.AnsiString, 35, false)]

    // ActivityDataType
    [AppliedAttribute(typeof(ActivityDescriptionDataType), "ActivityIdentifier", typeof(DbIndexableAttribute))]
    [AppliedAttribute(typeof(ActivityDescriptionDataType), "ActivityIdentifier", typeof(ColumnAttribute), "ACTIVITYID", DbType.AnsiString, 35, false)]
    [AppliedAttribute(typeof(ActivityDescriptionDataType), "ActivityTypeCode", typeof(ColumnAttribute), "ACTIVITYTYPECODE", DbType.AnsiString, 70, false)]
    [AppliedAttribute(typeof(ActivityDescriptionDataType), "ActivityMediaName", typeof(ColumnAttribute), "ACTIVITYMEDIA", DbType.AnsiString, 20, false)]
    [AppliedAttribute(typeof(ActivityDescriptionDataType), "ActivityMediaSubdivisionName", typeof(ColumnAttribute), "ACTIVITYMEDIASUBDIVISION", DbType.AnsiString, 45, true)]
    [AppliedAttribute(typeof(ActivityDescriptionDataType), "ActivityStartDate", typeof(DbIndexableAttribute))]
    [AppliedAttribute(typeof(ActivityDescriptionDataType), "ActivityStartDate", typeof(ColumnAttribute), "ACTIVITYSTARTDATE", DbType.DateTime, 0, false)]
    [AppliedPathAttribute("ActivityStartTime.Time", typeof(ColumnAttribute), "STARTTIME", DbType.AnsiString, 20, true)]
    [AppliedPathAttribute("ActivityStartTime.TimeZoneCode", typeof(ColumnAttribute), "STARTTIMEZONE", DbType.AnsiString, 4, true)]
    [AppliedAttribute(typeof(ActivityDescriptionDataType), "ActivityEndDate", typeof(ColumnAttribute), "ACTIVITYENDDATE", DbType.DateTime, 0, true)]
    [AppliedPathAttribute("ActivityEndTime.Time", typeof(ColumnAttribute), "ENDTIME", DbType.AnsiString, 20, true)]
    [AppliedPathAttribute("ActivityEndTime.TimeZoneCode", typeof(ColumnAttribute), "ENDTIMEZONE", DbType.AnsiString, 4, true)]
    [AppliedAttribute(typeof(ActivityDescriptionDataType), "ActivityRelativeDepthName", typeof(ColumnAttribute), "RELATIVEDEPTH", DbType.AnsiString, 15, true)]
    [AppliedPathAttribute("ActivityDepthHeightMeasure.MeasureValue", typeof(ColumnAttribute), "DEPTHHEIGHTMEASURE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("ActivityDepthHeightMeasure.MeasureUnitCode", typeof(ColumnAttribute), "DEPTHHEIGHTMEASUREUNIT", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("ActivityTopDepthHeightMeasure.MeasureValue", typeof(ColumnAttribute), "TOPDEPTHHEIGHTMEASURE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("ActivityTopDepthHeightMeasure.MeasureUnitCode", typeof(ColumnAttribute), "TOPDEPTHHEIGHTMEASUREUNIT", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("ActivityBottomDepthHeightMeasure.MeasureValue", typeof(ColumnAttribute), "BOTTOMDEPTHHEIGHTMEASURE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("ActivityBottomDepthHeightMeasure.MeasureUnitCode", typeof(ColumnAttribute), "BOTTOMDEPTHHEIGHTMEASUREUNIT", DbType.AnsiString, 12, true)]
    [AppliedAttribute(typeof(ActivityDescriptionDataType), "ActivityDepthAltitudeReferencePointText", typeof(ColumnAttribute), "DEPTHALTITUDEREFPOINT", DbType.AnsiString, 125, true)]
    //?? string[] ProjectIdentifier
    [AppliedAttribute(typeof(ActivityDescriptionDataType), "ProjectIdentifier", typeof(DbIgnoreAttribute))]
    //?? string[] ActivityConductingOrganizationText
    [AppliedAttribute(typeof(ActivityDescriptionDataType), "ActivityConductingOrganizationText", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(ActivityDescriptionDataType), "MonitoringLocationIdentifier", typeof(DbIndexableAttribute))]
    [AppliedAttribute(typeof(ActivityDescriptionDataType), "MonitoringLocationIdentifier", typeof(ColumnAttribute), "MONLOCID", DbType.AnsiString, 35, true)]
    [AppliedAttribute(typeof(ActivityDescriptionDataType), "ActivityCommentText", typeof(ColumnAttribute), "ACTIVITYCOMMENT", DbType.AnsiString, 4000, true)]
    [AppliedAttribute(typeof(ActivityLocationDataType), "LatitudeMeasure", typeof(ColumnAttribute), "LATITUDEMEASURE", DbType.AnsiString, 30, true)]
    [AppliedAttribute(typeof(ActivityLocationDataType), "LongitudeMeasure", typeof(ColumnAttribute), "LONGITUDEMEASURE", DbType.AnsiString, 30, true)]
    [AppliedAttribute(typeof(ActivityLocationDataType), "SourceMapScaleNumeric", typeof(ColumnAttribute), "SOURCEMAPSCALE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("ActivityLocation.HorizontalAccuracyMeasure.MeasureValue", typeof(ColumnAttribute), "HORIZACCURACYMEASURE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("ActivityLocation.HorizontalAccuracyMeasure.MeasureUnitCode", typeof(ColumnAttribute), "HORIZACCURACYMEASUREUNIT", DbType.AnsiString, 12, true)]
    [AppliedAttribute(typeof(ActivityLocationDataType), "HorizontalCollectionMethodName", typeof(ColumnAttribute), "HORIZCOLLMETHOD", DbType.AnsiString, 150, true)]
    [AppliedAttribute(typeof(ActivityLocationDataType), "HorizontalCoordinateReferenceSystemDatumName", typeof(ColumnAttribute), "HORIZCOORDREFSYSDATUM", DbType.AnsiString, 6, true)]
    [AppliedAttribute(typeof(BiologicalActivityDescriptionDataType), "AssemblageSampledName", typeof(ColumnAttribute), "BIOACTIVITYASSEMBLAGESAMPD", DbType.AnsiString, 50, true)]
    [AppliedPathAttribute("CollectionDuration.MeasureValue", typeof(ColumnAttribute), "BIOHABCOLLDURATIONMEASURE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("CollectionDuration.MeasureUnitCode", typeof(ColumnAttribute), "BIOHABCOLLDURATIONMEASUREUNIT", DbType.AnsiString, 12, true)]
    [AppliedAttribute(typeof(BiologicalHabitatCollectionInformationDataType), "SamplingComponentName", typeof(ColumnAttribute), "BIOHABSAMPCOMP", DbType.AnsiString, 15, true)]
    [AppliedAttribute(typeof(BiologicalHabitatCollectionInformationDataType), "SamplingComponentPlaceInSeriesNumeric", typeof(ColumnAttribute), "BIOHABSAMPCOMPPLACEINSERIES", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("ReachLengthMeasure.MeasureValue", typeof(ColumnAttribute), "BIOHABREACHLENGTHMEASURE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("ReachLengthMeasure.MeasureUnitCode", typeof(ColumnAttribute), "BIOHABREACHLENGTHMEASUREUNIT", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("ReachWidthMeasure.MeasureValue", typeof(ColumnAttribute), "BIOHABREACHWIDTHMEASURE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("ReachWidthMeasure.MeasureUnitCode", typeof(ColumnAttribute), "BIOHABREACHWIDTHMEASUREUNIT", DbType.AnsiString, 12, true)]
    [AppliedAttribute(typeof(BiologicalHabitatCollectionInformationDataType), "PassCount", typeof(ColumnAttribute), "BIOHABPASSCOUNT", DbType.AnsiString, 12, true)]
    [AppliedAttribute(typeof(NetInformationDataType), "NetTypeName", typeof(ColumnAttribute), "BIOHABNETTYPE", DbType.AnsiString, 30, true)]
    [AppliedPathAttribute("NetSurfaceAreaMeasure.MeasureValue", typeof(ColumnAttribute), "BIOHABNETSURFACEAREAMEASURE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("NetSurfaceAreaMeasure.MeasureUnitCode", typeof(ColumnAttribute), "BIOHABNETSURFACEMEASUREUNIT", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("NetMeshSizeMeasure.MeasureValue", typeof(ColumnAttribute), "BIOHABNETMESHSIZEMEASURE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("NetMeshSizeMeasure.MeasureUnitCode", typeof(ColumnAttribute), "BIOHABNETMESHMEASUREUNIT", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("BoatSpeedMeasure.MeasureValue", typeof(ColumnAttribute), "BIOHABNETBOATSPEEDMEASURE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("BoatSpeedMeasure.MeasureUnitCode", typeof(ColumnAttribute), "BIOHABNETBOATSPEEDMEASUREUNIT", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("CurrentSpeedMeasure.MeasureValue", typeof(ColumnAttribute), "BIOHABNETCURRSPEEDMEASURE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("CurrentSpeedMeasure.MeasureUnitCode", typeof(ColumnAttribute), "BIOHABNETCURRSPEEDMEASUREUNIT", DbType.AnsiString, 12, true)]
    [AppliedAttribute(typeof(BiologicalActivityDescriptionDataType), "ToxicityTestType", typeof(ColumnAttribute), "BIOACTIVITYTOXICITYTESTTYPE", DbType.AnsiString, 7, true)]
    [AppliedPathAttribute("SampleCollectionMethod.MethodIdentifier", typeof(ColumnAttribute), "SAMPCOLLMETHODID", DbType.AnsiString, 20, true)]
    [AppliedPathAttribute("SampleCollectionMethod.MethodIdentifierContext", typeof(ColumnAttribute), "SAMPCOLLMETHODIDCONTEXT", DbType.AnsiString, 120, true)]
    [AppliedPathAttribute("SampleCollectionMethod.MethodName", typeof(ColumnAttribute), "SAMPCOLLMETHOD", DbType.AnsiString, 120, true)]
    [AppliedPathAttribute("SampleCollectionMethod.MethodQualifierTypeName", typeof(ColumnAttribute), "SAMPCOLLMETHODQUALIFIER", DbType.AnsiString, 25, true)]
    [AppliedPathAttribute("SampleCollectionMethod.MethodDescriptionText", typeof(ColumnAttribute), "SAMPCOLLMETHODDESC", DbType.AnsiString, 500, true)]
    [AppliedAttribute(typeof(SampleDescriptionDataType), "SampleCollectionEquipmentName", typeof(ColumnAttribute), "SAMPCOLLEQUIPMENT", DbType.AnsiString, 40, true)]
    [AppliedAttribute(typeof(SampleDescriptionDataType), "SampleCollectionEquipmentCommentText", typeof(ColumnAttribute), "SAMPCOLLEQUIPMENTCOMMENT", DbType.AnsiString, 4000, true)]
    [AppliedPathAttribute("SamplePreparationMethod.MethodIdentifier", typeof(ColumnAttribute), "SAMPPREPID", DbType.AnsiString, 20, true)]
    [AppliedPathAttribute("SamplePreparationMethod.MethodIdentifierContext", typeof(ColumnAttribute), "SAMPPREPIDCONTEXT", DbType.AnsiString, 120, true)]
    [AppliedPathAttribute("SamplePreparationMethod.MethodName", typeof(ColumnAttribute), "SAMPPREP", DbType.AnsiString, 120, true)]
    [AppliedPathAttribute("SamplePreparationMethod.MethodQualifierTypeName", typeof(ColumnAttribute), "SAMPPREPQUALIFIERTYPE", DbType.AnsiString, 25, true)]
    [AppliedPathAttribute("SamplePreparationMethod.MethodDescriptionText", typeof(ColumnAttribute), "SAMPPREPDESC", DbType.AnsiString, 500, true)]
    [AppliedAttribute(typeof(SamplePreparationDataType), "SampleContainerTypeName", typeof(ColumnAttribute), "SAMPPREPCONTTYPE", DbType.AnsiString, 35, true)]
    [AppliedAttribute(typeof(SamplePreparationDataType), "SampleContainerColorName", typeof(ColumnAttribute), "SAMPPREPCONTCOLOR", DbType.AnsiString, 15, true)]
    [AppliedAttribute(typeof(SamplePreparationDataType), "ChemicalPreservativeUsedName", typeof(ColumnAttribute), "SAMPPREPCONTCHEMPRESERVUSED", DbType.AnsiString, 250, true)]
    [AppliedAttribute(typeof(SamplePreparationDataType), "ThermalPreservativeUsedName", typeof(ColumnAttribute), "SAMPPREPCONTTHERMALPRESERVUSED", DbType.AnsiString, 25, true)]
    [AppliedAttribute(typeof(SamplePreparationDataType), "SampleTransportStorageDescription", typeof(ColumnAttribute), "SAMPPREPCONTSAMPTRANSSTORDESC", DbType.AnsiString, 250, true)]
    [AppliedAttribute(typeof(ActivityDataType), "ResultCount", typeof(ColumnAttribute), "RESULTCOUNT", DbType.AnsiString, 255, true)]

    // ActivityGroupDataType
    [AppliedAttribute(typeof(ActivityGroupDataType), "ActivityGroupIdentifier", typeof(ColumnAttribute), "ACTIVITYGROUPID", DbType.AnsiString, 35, false)]
    [AppliedAttribute(typeof(ActivityGroupDataType), "ActivityGroupName", typeof(ColumnAttribute), "ACTIVITYGROUPNAME", DbType.AnsiString, 50, false)]
    [AppliedAttribute(typeof(ActivityGroupDataType), "ActivityGroupTypeCode", typeof(ColumnAttribute), "ACTIVITYGROUPTYPECODE", DbType.AnsiString, 50, false)]
    //?? string[] ActivityIdentifier
    [AppliedAttribute(typeof(ActivityGroupDataType), "ActivityIdentifier", typeof(DbIgnoreAttribute))]

    // AttachedBinaryObjectDataType
    [AppliedAttribute(typeof(AttachedBinaryObjectDataType), "BinaryObjectFileName", typeof(ColumnAttribute), "BINARYOBJECTFILE", DbType.AnsiString, 255, false)]
    [AppliedAttribute(typeof(AttachedBinaryObjectDataType), "BinaryObjectFileTypeCode", typeof(ColumnAttribute), "BINARYOBJECTFILETYPECODE", DbType.AnsiString, 6, false)]
    [AppliedAttribute(typeof(AttachedBinaryObjectDataType), "BinaryContent", typeof(ColumnAttribute), "BINARYOBJECTCONTENT", DbType.Binary)]

    // ProjectAttachedBinaryObjectDataType
    [AppliedAttribute(typeof(ProjectAttachedBinaryObjectDataType), "BinaryObjectFileName", typeof(ColumnAttribute), "BINARYOBJECTFILE", DbType.AnsiString, 255, false)]
    [AppliedAttribute(typeof(ProjectAttachedBinaryObjectDataType), "BinaryObjectFileTypeCode", typeof(ColumnAttribute), "BINARYOBJECTFILETYPECODE", DbType.AnsiString, 6, false)]
    [AppliedAttribute(typeof(ProjectAttachedBinaryObjectDataType), "BinaryContent", typeof(ColumnAttribute), "BINARYOBJECTCONTENT", DbType.Binary)]

    // MonitoringLocationAttachedBinaryObjectDataType
    [AppliedAttribute(typeof(MonitoringLocationAttachedBinaryObjectDataType), "BinaryObjectFileName", typeof(ColumnAttribute), "BINARYOBJECTFILE", DbType.AnsiString, 255, false)]
    [AppliedAttribute(typeof(MonitoringLocationAttachedBinaryObjectDataType), "BinaryObjectFileTypeCode", typeof(ColumnAttribute), "BINARYOBJECTFILETYPECODE", DbType.AnsiString, 6, false)]
    [AppliedAttribute(typeof(MonitoringLocationAttachedBinaryObjectDataType), "BinaryContent", typeof(ColumnAttribute), "BINARYOBJECTCONTENT", DbType.Binary)]

    // ActivityAttachedBinaryObjectDataType
    [AppliedAttribute(typeof(ActivityAttachedBinaryObjectDataType), "BinaryObjectFileName", typeof(ColumnAttribute), "BINARYOBJECTFILE", DbType.AnsiString, 255, false)]
    [AppliedAttribute(typeof(ActivityAttachedBinaryObjectDataType), "BinaryObjectFileTypeCode", typeof(ColumnAttribute), "BINARYOBJECTFILETYPECODE", DbType.AnsiString, 6, false)]
    [AppliedAttribute(typeof(ActivityAttachedBinaryObjectDataType), "BinaryContent", typeof(ColumnAttribute), "BINARYOBJECTCONTENT", DbType.Binary)]

    // ResultAttachedBinaryObjectDataType
    [AppliedAttribute(typeof(ResultAttachedBinaryObjectDataType), "BinaryObjectFileName", typeof(ColumnAttribute), "BINARYOBJECTFILE", DbType.AnsiString, 255, false)]
    [AppliedAttribute(typeof(ResultAttachedBinaryObjectDataType), "BinaryObjectFileTypeCode", typeof(ColumnAttribute), "BINARYOBJECTFILETYPECODE", DbType.AnsiString, 6, false)]
    [AppliedAttribute(typeof(ResultAttachedBinaryObjectDataType), "BinaryContent", typeof(ColumnAttribute), "BINARYOBJECTCONTENT", DbType.Binary)]

    // ProjectMonitoringLocationWeightingDataType
    [AppliedAttribute(typeof(ProjectMonitoringLocationWeightingDataType), "MonitoringLocationIdentifier", typeof(ColumnAttribute), "MONLOCID", DbType.AnsiString, 35, false)]
    [AppliedPathAttribute("LocationWeightingFactorMeasure.MeasureValue", typeof(ColumnAttribute), "LOCWEIGHTINGFACMEASURE", DbType.AnsiString, 12, false)]
    [AppliedPathAttribute("LocationWeightingFactorMeasure.MeasureUnitCode", typeof(ColumnAttribute), "LOCWEIGHTINGFACMEASUREUNIT", DbType.AnsiString, 12, false)]
    [AppliedAttribute(typeof(ProjectMonitoringLocationWeightingDataType), "StatisticalStratumText", typeof(ColumnAttribute), "STATISTICALSTRATUM", DbType.AnsiString, 15, true)]
    [AppliedAttribute(typeof(ProjectMonitoringLocationWeightingDataType), "LocationCategoryName", typeof(ColumnAttribute), "LOCATIONCATERY", DbType.AnsiString, 50, true)]
    [AppliedAttribute(typeof(ProjectMonitoringLocationWeightingDataType), "LocationStatusName", typeof(ColumnAttribute), "LOCATIONSTATUS", DbType.AnsiString, 15, true)]
    [AppliedAttribute(typeof(ProjectMonitoringLocationWeightingDataType), "ReferenceLocationTypeCode", typeof(ColumnAttribute), "REFLOCATIONTYPECODE", DbType.AnsiString, 20, true)]
    [AppliedAttribute(typeof(ProjectMonitoringLocationWeightingDataType), "ReferenceLocationStartDate", typeof(ColumnAttribute), "REFLOCATIONSTARTDATE", DbType.DateTime, 0, true)]
    [AppliedAttribute(typeof(ProjectMonitoringLocationWeightingDataType), "ReferenceLocationEndDate", typeof(ColumnAttribute), "REFLOCATIONENDDATE", DbType.DateTime, 0, true)]
    [AppliedPathAttribute("ReferenceLocationCitation.ResourceTitleName", typeof(ColumnAttribute), "RESOURCETITLE", DbType.AnsiString, 120, true)]
    [AppliedPathAttribute("ReferenceLocationCitation.ResourceCreatorName", typeof(ColumnAttribute), "RESOURCECREATOR", DbType.AnsiString, 120, true)]
    [AppliedPathAttribute("ReferenceLocationCitation.ResourceSubjectText", typeof(ColumnAttribute), "RESOURCESUBJECT", DbType.AnsiString, 500, true)]
    [AppliedPathAttribute("ReferenceLocationCitation.ResourcePublisherName", typeof(ColumnAttribute), "RESOURCEPUBLISHER", DbType.AnsiString, 60, true)]
    [AppliedPathAttribute("ReferenceLocationCitation.ResourceDate", typeof(ColumnAttribute), "RESOURCEDATE", DbType.DateTime, 0, true)]
    [AppliedPathAttribute("ReferenceLocationCitation.ResourceIdentifier", typeof(ColumnAttribute), "RESOURCEID", DbType.AnsiString, 255, true)]
    [AppliedAttribute(typeof(ProjectMonitoringLocationWeightingDataType), "CommentText", typeof(ColumnAttribute), "PROJMONLOCCOMMENT", DbType.AnsiString, 4000, true)]

    // ActivityMetricDataType
    [AppliedAttribute(typeof(ActivityMetricTypeDataType), "MetricTypeIdentifier", typeof(ColumnAttribute), "METRICTYPEID", DbType.AnsiString, 35, false)]
    [AppliedAttribute(typeof(ActivityMetricTypeDataType), "MetricTypeIdentifierContext", typeof(ColumnAttribute), "METRICTYPEIDCONTEXT", DbType.AnsiString, 50, false)]
    [AppliedAttribute(typeof(ActivityMetricTypeDataType), "MetricTypeName", typeof(ColumnAttribute), "METRICTYPENAME", DbType.AnsiString, 50, true)]
    [AppliedPathAttribute("MetricTypeCitation.ResourceTitleName", typeof(ColumnAttribute), "CITATIONRESOURCETITLE", DbType.AnsiString, 120, true)]
    [AppliedPathAttribute("MetricTypeCitation.ResourceCreatorName", typeof(ColumnAttribute), "CITATIONRESOURCECREATOR", DbType.AnsiString, 120, true)]
    [AppliedPathAttribute("MetricTypeCitation.ResourceSubjectText", typeof(ColumnAttribute), "CITATIONRESOURCESUBJECT", DbType.AnsiString, 500, true)]
    [AppliedPathAttribute("MetricTypeCitation.ResourcePublisherName", typeof(ColumnAttribute), "CITATIONRESOURCEPUBLISHER", DbType.AnsiString, 60, true)]
    [AppliedPathAttribute("MetricTypeCitation.ResourceDate", typeof(ColumnAttribute), "CITATIONRESOURCEDATE", DbType.DateTime, 0, true)]
    [AppliedPathAttribute("MetricTypeCitation.ResourceIdentifier", typeof(ColumnAttribute), "CITATIONRESOURCEID", DbType.AnsiString, 255, true)]
    [AppliedAttribute(typeof(ActivityMetricTypeDataType), "MetricTypeScaleText", typeof(ColumnAttribute), "METRICTYPESCALE", DbType.AnsiString, 50, true)]
    [AppliedAttribute(typeof(ActivityMetricTypeDataType), "FormulaDescriptionText", typeof(ColumnAttribute), "METRICTYPEFORMULADESC", DbType.AnsiString, 50, true)]
    [AppliedPathAttribute("MetricValueMeasure.MeasureValue", typeof(ColumnAttribute), "METRICVALUEMEASURE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("MetricValueMeasure.MeasureUnitCode", typeof(ColumnAttribute), "METRICVALUEMEASUREUNIT", DbType.AnsiString, 12, true)]
    [AppliedAttribute(typeof(ActivityMetricDataType), "MetricScoreNumeric", typeof(ColumnAttribute), "METRICSCORE", DbType.AnsiString, 10, true)]
    [AppliedAttribute(typeof(ActivityMetricDataType), "MetricCommentText", typeof(ColumnAttribute), "METRICCOMMENT", DbType.AnsiString, 4000, true)]
    //??** string[] IndexIdentifier
    [AppliedAttribute(typeof(ActivityMetricDataType), "IndexIdentifier", typeof(ColumnAttribute), "METRICINDEXID", DbType.AnsiString, 35, true)]

    // ResultDataType
    [AppliedAttribute(typeof(ResultDescriptionDataType), "DataLoggerLineName", typeof(ColumnAttribute), "DATALOGGERLINENAME", DbType.AnsiString, 15, true)]
    [AppliedAttribute(typeof(ResultDescriptionDataType), "ResultDetectionConditionText", typeof(ColumnAttribute), "RESULTDETECTIONCONDITION", DbType.AnsiString, 35, true)]
    [AppliedAttribute(typeof(ResultDescriptionDataType), "CharacteristicName", typeof(ColumnAttribute), "CHARACTERISTICNAME", DbType.AnsiString, 120, true)]
    [AppliedAttribute(typeof(ResultDescriptionDataType), "MethodSpeciationName", typeof(ColumnAttribute), "METHODSPECIATIONNAME", DbType.AnsiString, 20, true)]
    [AppliedAttribute(typeof(ResultDescriptionDataType), "ResultSampleFractionText", typeof(ColumnAttribute), "RESULTSAMPFRACTION", DbType.AnsiString, 25, true)]
    [AppliedPathAttribute("ResultDescription.ResultMeasure.ResultMeasureValue", typeof(ColumnAttribute), "RESULTMEASURE", DbType.AnsiString, 60, true)]
    [AppliedPathAttribute("ResultDescription.ResultMeasure.MeasureUnitCode", typeof(ColumnAttribute), "RESULTMEASUREUNIT", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("ResultDescription.ResultMeasure.MeasureQualifierCode", typeof(ColumnAttribute), "RESULTMEASUREQUALIFIERCODE", DbType.AnsiString, 5, true)]
    [AppliedAttribute(typeof(ResultDescriptionDataType), "ResultStatusIdentifier", typeof(ColumnAttribute), "STATUSID", DbType.AnsiString, 12, true)]
    [AppliedAttribute(typeof(ResultDescriptionDataType), "StatisticalBaseCode", typeof(ColumnAttribute), "STATISTICALBASECODE", DbType.AnsiString, 25, true)]
    [AppliedAttribute(typeof(ResultDescriptionDataType), "ResultValueTypeName", typeof(ColumnAttribute), "VALUETYPE", DbType.AnsiString, 20, true)]
    [AppliedAttribute(typeof(ResultDescriptionDataType), "ResultWeightBasisText", typeof(ColumnAttribute), "WEIGHTBASIS", DbType.AnsiString, 15, true)]
    [AppliedAttribute(typeof(ResultDescriptionDataType), "ResultTimeBasisText", typeof(ColumnAttribute), "TIMEBASIS", DbType.AnsiString, 12, true)]
    [AppliedAttribute(typeof(ResultDescriptionDataType), "ResultTemperatureBasisText", typeof(ColumnAttribute), "TEMPERATUREBASIS", DbType.AnsiString, 12, true)]
    [AppliedAttribute(typeof(ResultDescriptionDataType), "ResultParticleSizeBasisText", typeof(ColumnAttribute), "PARTICLESIZEBASIS", DbType.AnsiString, 15, true)]
    [AppliedAttribute(typeof(DataQualityDataType), "PrecisionValue", typeof(ColumnAttribute), "PRECISIONVALUE", DbType.AnsiString, 60, true)]
    [AppliedAttribute(typeof(DataQualityDataType), "BiasValue", typeof(ColumnAttribute), "BIASVALUE", DbType.AnsiString, 60, true)]
    [AppliedAttribute(typeof(DataQualityDataType), "ConfidenceIntervalValue", typeof(ColumnAttribute), "CONFIDENCEINTERVALVALUE", DbType.AnsiString, 15, true)]
    [AppliedAttribute(typeof(DataQualityDataType), "UpperConfidenceLimitValue", typeof(ColumnAttribute), "UPPERCONFIDENCELIMITVALUE", DbType.AnsiString, 15, true)]
    [AppliedAttribute(typeof(DataQualityDataType), "LowerConfidenceLimitValue", typeof(ColumnAttribute), "LOWERCONFIDENCELIMITVALUE", DbType.AnsiString, 15, true)]
    [AppliedAttribute(typeof(ResultDescriptionDataType), "ResultCommentText", typeof(ColumnAttribute), "RESULTCOMMENT", DbType.AnsiString, 4000, true)]
    [AppliedPathAttribute("ResultDepthHeightMeasure.MeasureValue", typeof(ColumnAttribute), "DEPTHHEIGHTMEASURE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("ResultDepthHeightMeasure.MeasureUnitCode", typeof(ColumnAttribute), "DEPTHHEIGHTMEASUREUNIT", DbType.AnsiString, 12, true)]
    [AppliedAttribute(typeof(ResultDescriptionDataType), "ResultDepthAltitudeReferencePointText", typeof(ColumnAttribute), "DEPTHALTITUDEREFPOINT", DbType.AnsiString, 125, true)]
    [AppliedAttribute(typeof(ResultDescriptionDataType), "ResultSamplingPointName", typeof(ColumnAttribute), "RESULTSAMPPOINT", DbType.AnsiString, 12, true)]
    [AppliedAttribute(typeof(BiologicalResultDescriptionDataType), "BiologicalIntentName", typeof(ColumnAttribute), "BIORESULTINTENT", DbType.AnsiString, 35, true)]
    [AppliedAttribute(typeof(BiologicalResultDescriptionDataType), "BiologicalIndividualIdentifier", typeof(ColumnAttribute), "BIORESULTINDIVIDUALID", DbType.AnsiString, 4, true)]
    [AppliedAttribute(typeof(BiologicalResultDescriptionDataType), "SubjectTaxonomicName", typeof(ColumnAttribute), "BIORESULTSUBJECTTAXONOMIC", DbType.AnsiString, 120, true)]
    [AppliedAttribute(typeof(BiologicalResultDescriptionDataType), "UnidentifiedSpeciesIdentifier", typeof(ColumnAttribute), "BIORESULTUNIDENTIFIEDSPECIESID", DbType.AnsiString, 120, true)]
    [AppliedAttribute(typeof(BiologicalResultDescriptionDataType), "SampleTissueAnatomyName", typeof(ColumnAttribute), "BIORESULTSAMPTISSUEANATOMY", DbType.AnsiString, 30, true)]
    [AppliedPathAttribute("GroupSummaryCountWeight.MeasureValue", typeof(ColumnAttribute), "GRPSUMMCOUNTWEIGHTMEASURE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("GroupSummaryCountWeight.MeasureUnitCode", typeof(ColumnAttribute), "GRPSUMMCOUNTWEIGHTMEASUREUNIT", DbType.AnsiString, 12, true)]
    [AppliedAttribute(typeof(TaxonomicDetailsDataType), "CellFormName", typeof(ColumnAttribute), "TAXDETAILSCELLFORM", DbType.AnsiString, 11, true)]
    [AppliedAttribute(typeof(TaxonomicDetailsDataType), "CellShapeName", typeof(ColumnAttribute), "TAXDETAILSCELLSHAPE", DbType.AnsiString, 18, true)]
    //??** string[] HabitName
    [AppliedAttribute(typeof(TaxonomicDetailsDataType), "HabitNameDBValue", typeof(ColumnAttribute), "TAXDETAILSHABITNAME", DbType.AnsiString, 15, true)]
    [AppliedAttribute(typeof(TaxonomicDetailsDataType), "VoltinismName", typeof(ColumnAttribute), "TAXDETAILSVOLTINISM", DbType.AnsiString, 25, true)]
    [AppliedAttribute(typeof(TaxonomicDetailsDataType), "TaxonomicPollutionTolerance", typeof(ColumnAttribute), "TAXDETAILSPOLLTOLERANCE", DbType.AnsiString, 4, true)]
    [AppliedAttribute(typeof(TaxonomicDetailsDataType), "TaxonomicPollutionToleranceScaleText", typeof(ColumnAttribute), "TAXDETAILSPOLLTOLERANCESCALE", DbType.AnsiString, 50, true)]
    [AppliedAttribute(typeof(TaxonomicDetailsDataType), "TrophicLevelName", typeof(ColumnAttribute), "TAXDETAILSTROPHICLEVEL", DbType.AnsiString, 4, true)]
    //??** string[] FunctionalFeedingGroupName
    [AppliedAttribute(typeof(TaxonomicDetailsDataType), "FunctionalFeedingGroupNameDBValue", typeof(ColumnAttribute), "TAXDETAILSFUNCFEEDINGGROUP", DbType.AnsiString, 6, true)]
    [AppliedPathAttribute("TaxonomicDetailsCitation.ResourceTitleName", typeof(ColumnAttribute), "CITATIONRESOURCETITLE", DbType.AnsiString, 120, true)]
    [AppliedPathAttribute("TaxonomicDetailsCitation.ResourceCreatorName", typeof(ColumnAttribute), "CITATIONRESOURCECREATOR", DbType.AnsiString, 120, true)]
    [AppliedPathAttribute("TaxonomicDetailsCitation.ResourceSubjectText", typeof(ColumnAttribute), "CITATIONRESOURCESUBJECT", DbType.AnsiString, 500, true)]
    [AppliedPathAttribute("TaxonomicDetailsCitation.ResourcePublisherName", typeof(ColumnAttribute), "CITATIONRESOURCEPUBLISHER", DbType.AnsiString, 60, true)]
    [AppliedPathAttribute("TaxonomicDetailsCitation.ResourceDate", typeof(ColumnAttribute), "CITATIONRESOURCEDATE", DbType.DateTime, 0, true)]
    [AppliedPathAttribute("TaxonomicDetailsCitation.ResourceIdentifier", typeof(ColumnAttribute), "CITATIONRESOURCEID", DbType.AnsiString, 255, true)]
    //??** FrequencyClassInformationDataType[] FrequencyClassInformation
    [AppliedAttribute(typeof(FrequencyClassInformationDataType), "FrequencyClassDescriptorCode", typeof(ColumnAttribute), "FREQCLASSDESCCODE", DbType.AnsiString, 50, true)]
    [AppliedAttribute(typeof(FrequencyClassInformationDataType), "FrequencyClassDescriptorUnitCode", typeof(ColumnAttribute), "FREQCLASSDESCUNITCODE", DbType.AnsiString, 12, true)]
    [AppliedAttribute(typeof(FrequencyClassInformationDataType), "LowerClassBoundValue", typeof(ColumnAttribute), "FREQCLASSLOWERBOUNDVALUE", DbType.AnsiString, 8, true)]
    [AppliedAttribute(typeof(FrequencyClassInformationDataType), "UpperClassBoundValue", typeof(ColumnAttribute), "FREQCLASSUPPERBOUNDVALUE", DbType.AnsiString, 8, true)]
    [AppliedAttribute(typeof(ResultAnalyticalMethodDataType), "MethodIdentifier", typeof(ColumnAttribute), "ANALYTICALMETHODID", DbType.AnsiString, 20, true)]
    [AppliedAttribute(typeof(ResultAnalyticalMethodDataType), "MethodIdentifierContext", typeof(ColumnAttribute), "ANALYTICALMETHODIDCONTEXT", DbType.AnsiString, 120, true)]
    [AppliedAttribute(typeof(ResultAnalyticalMethodDataType), "MethodName", typeof(ColumnAttribute), "ANALYTICALMETHODNAME", DbType.AnsiString, 120, true)]
    [AppliedAttribute(typeof(ResultAnalyticalMethodDataType), "MethodQualifierTypeName", typeof(ColumnAttribute), "ANALYTICALMETHODQUALIFIERTYPE", DbType.AnsiString, 25, true)]
    [AppliedAttribute(typeof(ResultAnalyticalMethodDataType), "MethodDescriptionText", typeof(ColumnAttribute), "ANALYTICALMETHODDESC", DbType.AnsiString, 500, true)]
    [AppliedAttribute(typeof(ResultLabInformationDataType), "LaboratoryName", typeof(ColumnAttribute), "LABNAME", DbType.AnsiString, 60, true)]
    [AppliedAttribute(typeof(ResultLabInformationDataType), "AnalysisStartDate", typeof(ColumnAttribute), "LABANALYSISSTARTDATE", DbType.DateTime, 0, true)]
    [AppliedPathAttribute("AnalysisStartTime.Time", typeof(ColumnAttribute), "LABANALYSISSTARTTIME", DbType.AnsiString, 20, true)]
    [AppliedPathAttribute("AnalysisStartTime.TimeZoneCode", typeof(ColumnAttribute), "LABANALYSISSTARTTIMEZONECODE", DbType.AnsiString, 4, true)]
    [AppliedAttribute(typeof(ResultLabInformationDataType), "AnalysisEndDate", typeof(ColumnAttribute), "LABANALYSISENDDATE", DbType.DateTime, 0, true)]
    [AppliedPathAttribute("AnalysisEndTime.Time", typeof(ColumnAttribute), "LABANALYSISENDTIME", DbType.AnsiString, 20, true)]
    [AppliedPathAttribute("AnalysisEndTime.TimeZoneCode", typeof(ColumnAttribute), "LABANALYSISENDTIMEZONECODE", DbType.AnsiString, 4, true)]
    [AppliedAttribute(typeof(ResultLabInformationDataType), "ResultLaboratoryCommentCode", typeof(ColumnAttribute), "RESULTLABCOMMENTCODE", DbType.AnsiString, 3, true)]
    [AppliedAttribute(typeof(ResultLabInformationDataType), "LaboratoryAccreditationIndicator", typeof(ColumnAttribute), "LABACCIND", DbType.AnsiStringFixedLength, 1, true)]
    [AppliedAttribute(typeof(ResultLabInformationDataType), "LaboratoryAccreditationAuthorityName", typeof(ColumnAttribute), "LABACCAUTHORITYNAME", DbType.AnsiString, 20, true)]
    [AppliedAttribute(typeof(ResultLabInformationDataType), "TaxonomistAccreditationIndicator", typeof(ColumnAttribute), "LABTAXACCIND", DbType.AnsiStringFixedLength, 1, true)]
    [AppliedAttribute(typeof(ResultLabInformationDataType), "TaxonomistAccreditationAuthorityName", typeof(ColumnAttribute), "LABTAXACCAUTHORITYNAME", DbType.AnsiString, 20, true)]

    // DetectionQuantitationLimitDataType
    [AppliedAttribute(typeof(DetectionQuantitationLimitDataType), "DetectionQuantitationLimitTypeName", typeof(ColumnAttribute), "DETECTQUANTLIMITTYPE", DbType.AnsiString, 35, false)]
    [AppliedPathAttribute("DetectionQuantitationLimitMeasure.MeasureValue", typeof(ColumnAttribute), "DETECTQUANTLIMITMEASURE", DbType.AnsiString, 12, true)]
    [AppliedPathAttribute("DetectionQuantitationLimitMeasure.MeasureUnitCode", typeof(ColumnAttribute), "DETECTQUANTLIMITMEASUNITCODE", DbType.AnsiString, 12, true)]

    // LabSamplePreparationDataType
    [AppliedPathAttribute("LabSamplePreparationMethod.MethodIdentifier", typeof(ColumnAttribute), "METHODID", DbType.AnsiString, 20, false)]
    [AppliedPathAttribute("LabSamplePreparationMethod.MethodIdentifierContext", typeof(ColumnAttribute), "METHODIDCONTEXT", DbType.AnsiString, 120, false)]
    [AppliedPathAttribute("LabSamplePreparationMethod.MethodName", typeof(ColumnAttribute), "METHODNAME", DbType.AnsiString, 120, false)]
    [AppliedPathAttribute("LabSamplePreparationMethod.MethodQualifierTypeName", typeof(ColumnAttribute), "METHODQUALIFIERTYPE", DbType.AnsiString, 25, true)]
    [AppliedPathAttribute("LabSamplePreparationMethod.MethodDescriptionText", typeof(ColumnAttribute), "METHODDESC", DbType.AnsiString, 500, true)]
    [AppliedAttribute(typeof(LabSamplePreparationDataType), "PreparationStartDate", typeof(ColumnAttribute), "PREPSTARTDATE", DbType.DateTime, 0, true)]
    [AppliedPathAttribute("PreparationStartTime.Time", typeof(ColumnAttribute), "PREPSTARTTIME", DbType.AnsiString, 20, true)]
    [AppliedPathAttribute("PreparationStartTime.TimeZoneCode", typeof(ColumnAttribute), "PREPSTARTTIMEZONECODE", DbType.AnsiString, 4, true)]
    [AppliedAttribute(typeof(LabSamplePreparationDataType), "PreparationEndDate", typeof(ColumnAttribute), "PREPENDDATE", DbType.DateTime, 0, true)]
    [AppliedPathAttribute("PreparationEndTime.Time", typeof(ColumnAttribute), "PREPENDTIME", DbType.AnsiString, 20, true)]
    [AppliedPathAttribute("PreparationEndTime.TimeZoneCode", typeof(ColumnAttribute), "PREPENDTIMEZONECODE", DbType.AnsiString, 4, true)]
    [AppliedAttribute(typeof(LabSamplePreparationDataType), "SubstanceDilutionFactorNumeric", typeof(ColumnAttribute), "SUBSTANCEDILUTIONFACTOR", DbType.AnsiString, 10, true)]

    // AlternateMonitoringLocationIdentityDataType
    [AppliedAttribute(typeof(AlternateMonitoringLocationIdentityDataType), "MonitoringLocationIdentifier", typeof(ColumnAttribute), "MONLOCID", DbType.AnsiString, 35, false)]
    [AppliedAttribute(typeof(AlternateMonitoringLocationIdentityDataType), "MonitoringLocationIdentifierContext", typeof(ColumnAttribute), "MONLOCIDCONTEXT", DbType.AnsiString, 120, false)]

    [Table("WQX_ORGANIZATION")]
    public partial class WQXDataType : IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        public void AssignWqxUpdateDates(DateTime time)
        {
            if (Organization != null)
            {
                Organization.AssignWqxUpdateDates(time);
            }
        }
        public void BeforeSaveToDatabase()
        {
            if (Organization != null)
            {
                Organization.BeforeSaveToDatabase();
            }
        }
        public void AfterLoadFromDatabase()
        {
            if (Organization != null)
            {
                Organization.AfterLoadFromDatabase();
            }
        }
        public int WriteBinaryObjectDataToFolder(string folderPath)
        {
            if (Organization != null)
            {
                return Organization.WriteBinaryObjectDataToFolder(folderPath);
            }
            return 0;
        }
    }

    // OrganizationDeleteDataType
    [AppliedAttribute(typeof(OrganizationDeleteDataType), "OrganizationIdentifier", typeof(ColumnAttribute), "ORGID", DbType.AnsiString, 30, false)]
    [AppliedAttribute(typeof(OrganizationDeleteDataType), "OrganizationFormalName", typeof(ColumnAttribute), "ORGFORMALNAME", DbType.AnsiString, 120, false)]
    [AppliedAttribute(typeof(OrganizationDeleteDataType), "ProjectIdentifier", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(OrganizationDeleteDataType), "MonitoringLocationIdentifier", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(OrganizationDeleteDataType), "ActivityIdentifier", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(OrganizationDeleteDataType), "ActivityGroupIdentifier", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(OrganizationDeleteDataType), "IndexIdentifier", typeof(DbIgnoreAttribute))]

    [Table("WQX_ORGANIZATION")]
    public partial class WQXDeleteDataType : IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        public const string DELETE_PROJECT_COMP_NAME = "PROJECT";
        public const string DELETE_ACTIVITY_COMP_NAME = "ACTIVITY";
        public const string DELETE_MONITORING_LOC_COMP_NAME = "MONITORINGLOCATION";
        public const string DELETE_ACTIVITY_GROUP_COMP_NAME = "ACTIVITYGROUP";
        public const string DELETE_BIOLOGICAL_HABITAT_INDEX_COMP_NAME = "BIOLOGICALHABITATINDEX";

        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        public void AssignWqxUpdateDates(DateTime time)
        {
            if (OrganizationDelete != null)
            {
                OrganizationDelete.AssignWqxUpdateDates(time);
            }
        }
        public void BeforeSaveToDatabase()
        {
            if (OrganizationDelete != null)
            {
                OrganizationDelete.BeforeSaveToDatabase();
            }
        }
        public void AfterLoadFromDatabase()
        {
            if (OrganizationDelete != null)
            {
                OrganizationDelete.AfterLoadFromDatabase();
            }
        }
    }

    [AppliedAttribute(typeof(WQXSubmissionDataType), "OrganizationIdentifier", typeof(ColumnAttribute), "ORGID", DbType.AnsiString, 30, false)]
    [AppliedAttribute(typeof(WQXSubmissionDataType), "OrganizationFormalName", typeof(ColumnAttribute), "ORGFORMALNAME", DbType.AnsiString, 120, false)]

    [Table("WQX_ORGANIZATION")]
    public class WQXSubmissionDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        public string OrganizationIdentifier;

        [System.Xml.Serialization.XmlIgnore]
        public string OrganizationFormalName;

        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;
    }

    public partial class OrganizationDataType : IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        public void BeforeSaveToDatabase()
        {
            // Setup ProjectActivity linking table
            if (!CollectionUtils.IsNullOrEmpty(Project) && !CollectionUtils.IsNullOrEmpty(Activity))
            {
                Dictionary<string, string> projectIdentifierToPkMap = new Dictionary<string, string>();
                CollectionUtils.ForEach(Project, delegate(ProjectDataType project)
                {
                    if (string.IsNullOrEmpty(project.RecordId))
                    {
                        project.RecordId = Guid.NewGuid().ToString();
                    }
                    projectIdentifierToPkMap.Add(project.ProjectIdentifier, project.RecordId);
                });
                CollectionUtils.ForEach(Activity, delegate(ActivityDataType activity)
                {
                    activity.BeforeSaveToDatabase(projectIdentifierToPkMap);
                });
            }
            // Setup ActivityActivityGroup linking table
            if (!CollectionUtils.IsNullOrEmpty(ActivityGroup) && !CollectionUtils.IsNullOrEmpty(Activity))
            {
                Dictionary<string, string> activityIdentifierToPkMap = new Dictionary<string, string>();
                CollectionUtils.ForEach(Activity, delegate(ActivityDataType activity)
                {
                    if (string.IsNullOrEmpty(activity.RecordId))
                    {
                        activity.RecordId = Guid.NewGuid().ToString();
                    }
                    activityIdentifierToPkMap.Add(activity.ActivityDescription.ActivityIdentifier, activity.RecordId);
                });
                CollectionUtils.ForEach(ActivityGroup, delegate(ActivityGroupDataType activityGroup)
                {
                    activityGroup.BeforeSaveToDatabase(activityIdentifierToPkMap);
                });
            }
            // Assign wqx update dates
            AssignWqxUpdateDates(DateTime.Now);
        }
        public void AfterLoadFromDatabase()
        {
            // Assign project identifiers to activities
            if (!CollectionUtils.IsNullOrEmpty(Project) && !CollectionUtils.IsNullOrEmpty(Activity))
            {
                Dictionary<string, string> projectPkToIdentifierMap = new Dictionary<string, string>();
                CollectionUtils.ForEach(Project, delegate(ProjectDataType project)
                {
                    projectPkToIdentifierMap.Add(project.RecordId, project.ProjectIdentifier);
                });
                CollectionUtils.ForEach(Activity, delegate(ActivityDataType activity)
                {
                    activity.AfterLoadFromDatabase(projectPkToIdentifierMap);
                });
            }
            // Assign activity identifiers to activity groups
            if (!CollectionUtils.IsNullOrEmpty(ActivityGroup) && !CollectionUtils.IsNullOrEmpty(Activity))
            {
                Dictionary<string, string> activityPkToIdentifierMap = new Dictionary<string, string>();
                CollectionUtils.ForEach(Activity, delegate(ActivityDataType activity)
                {
                    activityPkToIdentifierMap.Add(activity.RecordId, activity.ActivityDescription.ActivityIdentifier);
                });
                CollectionUtils.ForEach(ActivityGroup, delegate(ActivityGroupDataType activityGroup)
                {
                    activityGroup.AfterLoadFromDatabase(activityPkToIdentifierMap);
                });
            }
        }
        public int WriteBinaryObjectDataToFolder(string folderPath)
        {
            int fileCount = 0;
            CollectionUtils.ForEach(Project, delegate(ProjectDataType project) {
                fileCount += WriteBinaryObjectDataToFolder(folderPath, project.AttachedBinaryObject);
            });
            CollectionUtils.ForEach(Activity, delegate(ActivityDataType activity)
            {
                fileCount += WriteBinaryObjectDataToFolder(folderPath, activity.AttachedBinaryObject);
                CollectionUtils.ForEach(activity.Result, delegate(ResultDataType result)
                {
                    fileCount += WriteBinaryObjectDataToFolder(folderPath, result.AttachedBinaryObject);
                });
            });
            CollectionUtils.ForEach(MonitoringLocation, delegate(MonitoringLocationDataType monitoringLocation)
            {
                fileCount += WriteBinaryObjectDataToFolder(folderPath, monitoringLocation.AttachedBinaryObject);
            });
            return fileCount;
        }
        public static int WriteBinaryObjectDataToFolder<T>(string folderPath, T[] elements) where T : AttachedBinaryObjectDataType
        {
            int fileCount = 0;
            CollectionUtils.ForEach(elements, delegate(AttachedBinaryObjectDataType element)
            {
                if (WriteBinaryObjectDataToFolder(folderPath, element.BinaryObjectFileName, element.BinaryContent))
                {
                    ++fileCount;
                }
            });
            return fileCount;
        }
        public static bool WriteBinaryObjectDataToFolder(string folderPath, string name, byte[] content)
        {
            if (!CollectionUtils.IsNullOrEmpty(content))
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("An attached binary object did not have a name.");
                }
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string filePath = Path.Combine(folderPath, name);
                if (File.Exists(filePath))
                {
                    throw new ArgumentException(string.Format("A duplicate name was found for an attached binary object: \"{0}\"",
                                                              name));
                }
                File.WriteAllBytes(filePath, content);
                return true;
            }
            return false;
        }
        public void AssignWqxUpdateDates(DateTime time)
        {
            CollectionUtils.ForEach(Project, delegate(ProjectDataType project)
            {
                if (project.WqxUpdateDate == DateTime.MinValue)
                {
                    project.WqxUpdateDate = time;
                }
            });
            CollectionUtils.ForEach(MonitoringLocation, delegate(MonitoringLocationDataType monitoringLocation)
            {
                if (monitoringLocation.WqxUpdateDate == DateTime.MinValue)
                {
                    monitoringLocation.WqxUpdateDate = time;
                }
            });
            CollectionUtils.ForEach(BiologicalHabitatIndex, delegate(BiologicalHabitatIndexDataType biologicalHabitatIndex)
            {
                if (biologicalHabitatIndex.WqxUpdateDate == DateTime.MinValue)
                {
                    biologicalHabitatIndex.WqxUpdateDate = time;
                }
            });
            CollectionUtils.ForEach(Activity, delegate(ActivityDataType activity)
            {
                if (activity.WqxUpdateDate == DateTime.MinValue)
                {
                    activity.WqxUpdateDate = time;
                }
            });
            CollectionUtils.ForEach(ActivityGroup, delegate(ActivityGroupDataType activityGroup)
            {
                if (activityGroup.WqxUpdateDate == DateTime.MinValue)
                {
                    activityGroup.WqxUpdateDate = time;
                }
            });
        }
    }

    public partial class OrganizationDeleteDataType : IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        public const string UNDEFINED_FORMAL_NAME = "UNDEFINED";

        [System.Xml.Serialization.XmlIgnore]
        public string OrganizationFormalName = UNDEFINED_FORMAL_NAME;

        [System.Xml.Serialization.XmlIgnore]
        public DeleteDataType[] Delete;

        public void AssignWqxUpdateDates(DateTime time)
        {
            CollectionUtils.ForEach(Delete, delegate(DeleteDataType del)
            {
                if (del.WqxUpdateDate == DateTime.MinValue)
                {
                    del.WqxUpdateDate = time;
                }
            });
        }
        public void BeforeSaveToDatabase()
        {
            DateTime now = DateTime.Now;
            List<DeleteDataType> deleteList = null;
            AddToDeleteList(WQXDeleteDataType.DELETE_PROJECT_COMP_NAME, ProjectIdentifier, now, ref deleteList);
            AddToDeleteList(WQXDeleteDataType.DELETE_MONITORING_LOC_COMP_NAME, MonitoringLocationIdentifier, now, ref deleteList);
            AddToDeleteList(WQXDeleteDataType.DELETE_ACTIVITY_COMP_NAME, ActivityIdentifier, now, ref deleteList);
            AddToDeleteList(WQXDeleteDataType.DELETE_ACTIVITY_GROUP_COMP_NAME, ActivityGroupIdentifier, now, ref deleteList);
            AddToDeleteList(WQXDeleteDataType.DELETE_BIOLOGICAL_HABITAT_INDEX_COMP_NAME, IndexIdentifier, now, ref deleteList);
            if (!CollectionUtils.IsNullOrEmpty(deleteList))
            {
                Delete = deleteList.ToArray();
            }
        }
        public void AfterLoadFromDatabase()
        {
            if (!CollectionUtils.IsNullOrEmpty(Delete))
            {
                int listCapacity = (Delete.Length + 1) / 2;
                List<string> projectIdentifiers = new List<string>(listCapacity);
                List<string> monitoringLocationIdentifiers = new List<string>(listCapacity);
                List<string> activityIdentifiers = new List<string>(listCapacity);
                List<string> activityGroupIdentifiers = new List<string>(listCapacity);
                List<string> indexIdentifiers = new List<string>(listCapacity);
                CollectionUtils.ForEach(Delete, delegate(DeleteDataType del)
                {
                    switch (del.Component.ToUpper())
                    {
                        case WQXDeleteDataType.DELETE_PROJECT_COMP_NAME:
                            projectIdentifiers.Add(del.Identifier);
                            break;
                        case WQXDeleteDataType.DELETE_MONITORING_LOC_COMP_NAME:
                            monitoringLocationIdentifiers.Add(del.Identifier);
                            break;
                        case WQXDeleteDataType.DELETE_ACTIVITY_COMP_NAME:
                            activityIdentifiers.Add(del.Identifier);
                            break;
                        case WQXDeleteDataType.DELETE_ACTIVITY_GROUP_COMP_NAME:
                            activityGroupIdentifiers.Add(del.Identifier);
                            break;
                        case WQXDeleteDataType.DELETE_BIOLOGICAL_HABITAT_INDEX_COMP_NAME:
                            indexIdentifiers.Add(del.Identifier);
                            break;
                        default:
                            throw new ArgumentException(string.Format("Unrecognized Delete component: {0}", del.Component));
                    }
                });
                if (projectIdentifiers.Count > 0)
                {
                    ProjectIdentifier = projectIdentifiers.ToArray();
                }
                if (monitoringLocationIdentifiers.Count > 0)
                {
                    MonitoringLocationIdentifier = monitoringLocationIdentifiers.ToArray();
                }
                if (activityIdentifiers.Count > 0)
                {
                    ActivityIdentifier = activityIdentifiers.ToArray();
                }
                if (activityGroupIdentifiers.Count > 0)
                {
                    ActivityGroupIdentifier = activityGroupIdentifiers.ToArray();
                }
                if (indexIdentifiers.Count > 0)
                {
                    IndexIdentifier = indexIdentifiers.ToArray();
                }
            }
        }
        protected static void AddToDeleteList(string component, string[] identifiers, DateTime now,
                                              ref List<DeleteDataType> deleteList)
        {
            if (!CollectionUtils.IsNullOrEmpty(identifiers))
            {
                if (deleteList == null)
                {
                    deleteList = new List<DeleteDataType>(identifiers.Length);
                }
                else
                {
                    deleteList.Capacity = deleteList.Count + identifiers.Length;
                }
                foreach (string identifier in identifiers)
                {
                    DeleteDataType deleteDataType = new DeleteDataType();
                    deleteDataType.Component = component;
                    deleteDataType.Identifier = identifier;
                    deleteDataType.WqxUpdateDate = now;
                    deleteList.Add(deleteDataType);
                }
            }
        }
    }

    [Table("WQX_DELETES")]
    public partial class DeleteDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;

        [System.Xml.Serialization.XmlIgnore]
        [Column("COMPONENT", DbType.AnsiString, 50, IsNullable = false)]
        public string Component;

        [System.Xml.Serialization.XmlIgnore]
        [Column("IDENTIFIER", DbType.AnsiString, 50, IsNullable = false)]
        public string Identifier;

        [System.Xml.Serialization.XmlIgnore]
        [Column("WQXUPDATEDATE", DbType.DateTime, 0, IsNullable = false)]
        [DbIndexableAttribute]
        public DateTime WqxUpdateDate;
    }

    [Table("WQX_SUBMISSIONHISTORY")]
    public class SubmissionHistoryDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [Column("PARENTID", DbType.AnsiString, 50, IsNullable = false)]
        public string ParentId;

        [System.Xml.Serialization.XmlIgnore]
        [Column("SCHEDULERUNDATE", DbType.DateTime, 0, IsNullable = false)]
        public DateTime ScheduleRunDate;

        [System.Xml.Serialization.XmlIgnore]
        [Column("WQXUPDATEDATE", DbType.DateTime, 0, IsNullable = false)]
        [DbIndexableAttribute]
        public DateTime WqxUpdateDate;

        [System.Xml.Serialization.XmlIgnore]
        [Column("SUBMISSIONTYPE", DbType.AnsiString, 13, IsNullable = false)]
        public string SubmissionType;

        [System.Xml.Serialization.XmlIgnore]
        [Column("LOCALTRANSACTIONID", DbType.AnsiString, 50, IsNullable = false)]
        public string LocalTransactionId;

        [System.Xml.Serialization.XmlIgnore]
        [Column("CDXPROCESSINGSTATUS", DbType.AnsiString, 50, IsNullable = false)]
        public string CdxProcessingStatus;
        
        [System.Xml.Serialization.XmlIgnore]
        [Column("ORGID", DbType.AnsiString, 30, IsNullable = false)]
        public string OrgId;
    }

    [Table("WQX_ELECTRONICADDRESS")]
    public partial class ElectronicAddressDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;
    }
    [Table("WQX_TELEPHONIC")]
    public partial class TelephonicDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;
    }
    [Table("WQX_ORGADDRESS")]
    public partial class OrganizationAddressDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;
    }
    [Table("WQX_PROJECT")]
    public partial class ProjectDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;
        
        [System.Xml.Serialization.XmlIgnore]
        [Column("WQXUPDATEDATE", DbType.DateTime, 0, IsNullable = false)]
        [DbIndexableAttribute]
        public DateTime WqxUpdateDate;

        public ProjectDataType(string projectIdentifier)
        {
            ProjectIdentifier = projectIdentifier;
        }
        public ProjectDataType()
        {
        }
    }
    [Table("WQX_MONITORINGLOCATION")]
    public partial class MonitoringLocationDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;

        [System.Xml.Serialization.XmlIgnore]
        [Column("WQXUPDATEDATE", DbType.DateTime, 0, IsNullable = false)]
        [DbIndexableAttribute]
        public DateTime WqxUpdateDate;

        public MonitoringLocationDataType(string monitoringLocationIdentifier)
        {
            MonitoringLocationIdentity = new MonitoringLocationIdentityDataType();
            MonitoringLocationIdentity.MonitoringLocationIdentifier = monitoringLocationIdentifier;
        }
        public MonitoringLocationDataType()
        {
        }
    }
    [Table("WQX_BIOLOGICALHABITATINDEX")]
    public partial class BiologicalHabitatIndexDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;

        [System.Xml.Serialization.XmlIgnore]
        [Column("WQXUPDATEDATE", DbType.DateTime, 0, IsNullable = false)]
        [DbIndexableAttribute]
        public DateTime WqxUpdateDate;
    }
    [Table("WQX_ACTIVITY")]
    public partial class ActivityDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;

        [System.Xml.Serialization.XmlIgnore]
        [Column("WQXUPDATEDATE", DbType.DateTime, 0, IsNullable = false)]
        [DbIndexableAttribute]
        public DateTime WqxUpdateDate;

        //[System.Xml.Serialization.XmlIgnore]
        //[Column("TMPPROJECTID", DbType.AnsiString, 50)]
        //public string TmpProjectId;

        [System.Xml.Serialization.XmlIgnore]
        public ProjectActivityDataType[] ProjectActivity;

        public void BeforeSaveToDatabase(Dictionary<string, string> projectIdentifierToPkMap)
        {
            CollectionUtils.ForEach(Result, delegate(ResultDataType result)
            {
                if ( (result.BiologicalResultDescription != null) && (result.BiologicalResultDescription.TaxonomicDetails != null) ) {
                    result.BiologicalResultDescription.TaxonomicDetails.HabitNameDBValue =
                        WQXDataHelper.StringsToPipedString(result.BiologicalResultDescription.TaxonomicDetails.HabitName);
                    result.BiologicalResultDescription.TaxonomicDetails.FunctionalFeedingGroupNameDBValue =
                        WQXDataHelper.StringsToPipedString(result.BiologicalResultDescription.TaxonomicDetails.FunctionalFeedingGroupName);
                }
            });
            if (ActivityDescription == null)
            {
                return;
            }
            List<ProjectActivityDataType> projectActivities = null;
            CollectionUtils.ForEach(ActivityDescription.ProjectIdentifier, delegate(string projectIdentifier)
            {
                if (projectActivities == null)
                {
                    projectActivities = new List<ProjectActivityDataType>(ActivityDescription.ProjectIdentifier.Length);
                    if (string.IsNullOrEmpty(this.RecordId))
                    {
                        this.RecordId = Guid.NewGuid().ToString();
                    }
                }
                string projectPk;
                if (!projectIdentifierToPkMap.TryGetValue(projectIdentifier, out projectPk))
                {
                    throw new ArgumentException(string.Format("An activity (\"{0}\") has a project mapped to it (\"{1}\") that cannot be found.",
                                                              this.RecordId, projectIdentifier));
                }
                ProjectActivityDataType projectActivity = new ProjectActivityDataType();
                projectActivity.ActivityParentId = this.RecordId;
                projectActivity.ProjectParentId = projectPk;
                if (CollectionUtils.InsertIntoSortedList(projectActivities, projectActivity, s_ProjectActivityDataTypeComparer))
                {
                    projectActivity.RecordId = Guid.NewGuid().ToString();
                }
            });
            if (projectActivities != null)
            {
                this.ProjectActivity = projectActivities.ToArray();
            }

            List<ActivityConductingOrganizationDataType> conductingOrganizations = null;
            CollectionUtils.ForEach(ActivityDescription.ActivityConductingOrganizationText, delegate(string conductingOrganizationText)
            {
                ActivityConductingOrganizationDataType conductingOrganization = new ActivityConductingOrganizationDataType();
                conductingOrganization.RecordId = Guid.NewGuid().ToString();
                conductingOrganization.ParentId = this.RecordId;
                conductingOrganization.ActivityId = this.ActivityDescription.ActivityIdentifier;
                conductingOrganization.ActivityConductingOrganizationText = conductingOrganizationText;
                CollectionUtils.Add(conductingOrganization, ref conductingOrganizations);
            });
            if (conductingOrganizations != null)
            {
                this.ActivityDescription.ActivityConductingOrganization = conductingOrganizations.ToArray();
            }
        }
        public void AfterLoadFromDatabase(Dictionary<string, string> projectPkToIdentifierMap)
        {
            CollectionUtils.ForEach(Result, delegate(ResultDataType result)
            {
                if ((result.BiologicalResultDescription != null) && (result.BiologicalResultDescription.TaxonomicDetails != null))
                {
                    result.BiologicalResultDescription.TaxonomicDetails.HabitName =
                        WQXDataHelper.PipedStringToStrings(result.BiologicalResultDescription.TaxonomicDetails.HabitNameDBValue);
                    result.BiologicalResultDescription.TaxonomicDetails.FunctionalFeedingGroupName =
                        WQXDataHelper.PipedStringToStrings(result.BiologicalResultDescription.TaxonomicDetails.FunctionalFeedingGroupNameDBValue);
                }
            });
            List<string> projectIds = null;
            CollectionUtils.ForEach(ProjectActivity, delegate(ProjectActivityDataType projectActivity)
            {
                if (projectIds == null)
                {
                    projectIds = new List<string>(ProjectActivity.Length);
                }
                string projectId;
                if ( !projectPkToIdentifierMap.TryGetValue(projectActivity.ProjectParentId, out projectId) )
                {
                    throw new ArgumentException(string.Format("An activity (\"{0}\") has a project mapped to it (\"{1}\") that cannot be found.",
                                                              this.RecordId, projectActivity.ProjectParentId));
                }
                CollectionUtils.InsertIntoSortedList(projectIds, projectId);
            });
            if (projectIds != null)
            {
                ActivityDescription.ProjectIdentifier = projectIds.ToArray();
            }
            List<string> conductingOrganizationTextList = null;
            CollectionUtils.ForEach(ActivityDescription.ActivityConductingOrganization, delegate(ActivityConductingOrganizationDataType conductingOrganization)
            {
                if (!string.IsNullOrEmpty(conductingOrganization.ActivityConductingOrganizationText))
                {
                    CollectionUtils.Add(conductingOrganization.ActivityConductingOrganizationText, ref conductingOrganizationTextList);
                }
            });
            if (conductingOrganizationTextList != null)
            {
                ActivityDescription.ActivityConductingOrganizationText = conductingOrganizationTextList.ToArray();
            }
        }
        private static ProjectActivityDataTypeComparer s_ProjectActivityDataTypeComparer = new ProjectActivityDataTypeComparer();
    }
    internal class ProjectActivityDataTypeComparer : IComparer<ProjectActivityDataType> 
    {
        public int Compare(ProjectActivityDataType x, ProjectActivityDataType y)
        {
            return string.Compare(x.ProjectParentId, y.ProjectParentId);
        }
    }
    [Table("WQX_ACTIVITYGROUP")]
    public partial class ActivityGroupDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;

        [System.Xml.Serialization.XmlIgnore]
        [Column("WQXUPDATEDATE", DbType.DateTime, 0, IsNullable = false)]
        [DbIndexableAttribute]
        public DateTime WqxUpdateDate;
        
        [System.Xml.Serialization.XmlIgnore]
        public ActivityActivityGroupDataType[] ActivityActivityGroup;

        public void BeforeSaveToDatabase(Dictionary<string, string> activityIdentifierToPkMap)
        {
            List<ActivityActivityGroupDataType> activityActivityGroups = null;
            CollectionUtils.ForEach(ActivityIdentifier, delegate(string activityIdentifier)
            {
                if (activityActivityGroups == null)
                {
                    activityActivityGroups = new List<ActivityActivityGroupDataType>(ActivityIdentifier.Length);
                    if (string.IsNullOrEmpty(this.RecordId))
                    {
                        this.RecordId = Guid.NewGuid().ToString();
                    }
                }
                string activityPk;
                if (!activityIdentifierToPkMap.TryGetValue(activityIdentifier, out activityPk))
                {
                    throw new ArgumentException(string.Format("An activity group (\"{0}\") has an activity mapped to it (\"{1}\") that cannot be found.",
                                                              this.RecordId, activityIdentifier));
                }
                ActivityActivityGroupDataType activityActivityGroup = new ActivityActivityGroupDataType();
                activityActivityGroup.ActivityGroupParentId = this.RecordId;
                activityActivityGroup.ActivityParentId = activityPk;
                if (CollectionUtils.InsertIntoSortedList(activityActivityGroups, activityActivityGroup, s_ActivityActivityGroupDataTypeComparer))
                {
                    activityActivityGroup.RecordId = Guid.NewGuid().ToString();
                }
            });
            if (activityActivityGroups != null)
            {
                this.ActivityActivityGroup = activityActivityGroups.ToArray();
            }
        }
        public void AfterLoadFromDatabase(Dictionary<string, string> activityPkToIdentifierMap)
        {
            List<string> activityIds = null;
            CollectionUtils.ForEach(ActivityActivityGroup, delegate(ActivityActivityGroupDataType activityActivityGroup)
            {
                if (activityIds == null)
                {
                    activityIds = new List<string>(ActivityActivityGroup.Length);
                }
                string activityId;
                if (!activityPkToIdentifierMap.TryGetValue(activityActivityGroup.ActivityParentId, out activityId))
                {
                    throw new ArgumentException(string.Format("An activity group (\"{0}\") has an activity mapped to it (\"{1}\") that cannot be found.",
                                                              this.RecordId, activityActivityGroup.ActivityParentId));
                }
                CollectionUtils.InsertIntoSortedList(activityIds, activityId);
            });
            if (activityIds != null)
            {
                ActivityIdentifier = activityIds.ToArray();
            }
        }
        private static ActivityActivityGroupDataTypeComparer s_ActivityActivityGroupDataTypeComparer = new ActivityActivityGroupDataTypeComparer();
    }
    internal class ActivityActivityGroupDataTypeComparer : IComparer<ActivityActivityGroupDataType>
    {
        public int Compare(ActivityActivityGroupDataType x, ActivityActivityGroupDataType y)
        {
            return string.Compare(x.ActivityParentId, y.ActivityParentId);
        }
    }
    [Table("WQX_PROJATTACHEDBINARYOBJECT")]
    public partial class ProjectAttachedBinaryObjectDataType : AttachedBinaryObjectDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;
    }
    [Table("WQX_PROJECTMONLOC")]
    public partial class ProjectMonitoringLocationWeightingDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;
    }
    [Table("WQX_MONLOCATTACHEDBINARYOBJECT")]
    public partial class MonitoringLocationAttachedBinaryObjectDataType : AttachedBinaryObjectDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;
    }
    [Table("WQX_ACTIVITYMETRIC")]
    public partial class ActivityMetricDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;
    }
    [Table("WQX_ACTATTACHEDBINARYOBJECT")]
    public partial class ActivityAttachedBinaryObjectDataType : AttachedBinaryObjectDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;
    }
    [Table("WQX_RESULTATTACHEDBINARYOBJECT")]
    public partial class ResultAttachedBinaryObjectDataType : AttachedBinaryObjectDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;
    }
    [Table("WQX_RESULT")]
    public partial class ResultDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;
    }
    [Table("WQX_RESULTDETECTQUANTLIMIT")]
    public partial class DetectionQuantitationLimitDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;
    }
    [Table("WQX_LABSAMPLEPREP")]
    public partial class LabSamplePreparationDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;
    }
    [Table("WQX_ALTMONLOC")]
    public partial class AlternateMonitoringLocationIdentityDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;
    }
    public partial class ActivityDescriptionDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        public ActivityConductingOrganizationDataType[] ActivityConductingOrganization;

        [System.Xml.Serialization.XmlIgnore]
        [Column("TMPPROJECTID", DbType.AnsiString, 50, IsNullable = true)]
        public string TmpProjectId;
    }

    [Table("WQX_ACTIVITYCONDUCTINGORG")]
    public class ActivityConductingOrganizationDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PARENTID", 50)]
        public string ParentId;

        [System.Xml.Serialization.XmlIgnore]
        [Column("ACTIVITYID", DbType.AnsiString, 35, IsNullable = false)]
        public string ActivityId;

        [System.Xml.Serialization.XmlIgnore]
        [Column("ACTIVITYCONDUCTINGORG", DbType.AnsiString, 120, IsNullable = false)]
        public string ActivityConductingOrganizationText;
    }

    [Table("WQX_ACTIVITYACTIVITYGROUP")]
    public class ActivityActivityGroupDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("ACTIVITYGROUPPARENTID", 50)]
        public string ActivityGroupParentId;

        [System.Xml.Serialization.XmlIgnore]
        [Column("ACTIVITYPARENTID", DbType.AnsiString, 50, IsNullable = false)]
        [DbIndexableAttribute]
        public string ActivityParentId;
    }

    [Table("WQX_PROJECTACTIVITY")]
    public class ProjectActivityDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("RECORDID", 50)]
        public string RecordId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("ACTIVITYPARENTID", 50)]
        public string ActivityParentId;

        [System.Xml.Serialization.XmlIgnore]
        [Column("PROJECTPARENTID", DbType.AnsiString, 50, IsNullable = false)]
        [DbIndexableAttribute]
        public string ProjectParentId;
    }
    public partial class ResultDescriptionDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [Column("TMPACTIVITYID", DbType.AnsiString, 35, IsNullable = true)]
        public string TmpActivityId;
    }
}
