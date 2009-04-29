CREATE TABLE [AR].[dbo].[Activity] ( [ResultCount] char (255)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[ActivityDescription] ( [ActivityIdentifier] char (35)  NOT NULL , CONSTRAINT [CK_ActivityDescription_ActivityIdentifier] CHECK ( (  LEN ( [ActivityIdentifier] )  >= 1 )  )  , [ActivityTypeCode] char (70)  NOT NULL , CONSTRAINT [CK_ActivityDescription_ActivityTypeCode] CHECK ( (  LEN ( [ActivityTypeCode] )  >= 1 )  )  , [ActivityMediaName] char (20)  NOT NULL , CONSTRAINT [CK_ActivityDescription_ActivityMediaName] CHECK ( (  LEN ( [ActivityMediaName] )  >= 1 )  )  , [ActivityMediaSubdivisionName] char (45)  NOT NULL , [ActivityStartDate] datetime  NOT NULL , [ActivityEndDate] datetime  NOT NULL , [ActivityRelativeDepthName] char (15)  NOT NULL , [ActivityDepthAltitudeReferencePointText] char (125)  NOT NULL , [ProjectIdentifier] char (35)  NOT NULL , CONSTRAINT [CK_ActivityDescription_ProjectIdentifier] CHECK ( (  LEN ( [ProjectIdentifier] )  >= 1 )  )  , [ActivityConductingOrganizationText] char (120)  NOT NULL , [MonitoringLocationIdentifier] char (35)  NOT NULL , CONSTRAINT [CK_ActivityDescription_MonitoringLocationIdentifier] CHECK ( (  LEN ( [MonitoringLocationIdentifier] )  >= 1 )  )  , [ActivityCommentText] char (4000)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[ActivityStartTime] ( [Time] datetime  NOT NULL , [TimeZoneCode] char (4)  NOT NULL , CONSTRAINT [CK_ActivityStartTime_TimeZoneCode] CHECK ( (  LEN ( [TimeZoneCode] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[HorizontalAccuracyMeasure] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[ActivityBottomDepthHeightMeasure] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[ActivityEndTime] ( [Time] datetime  NOT NULL , [TimeZoneCode] char (4)  NOT NULL , CONSTRAINT [CK_ActivityEndTime_TimeZoneCode] CHECK ( (  LEN ( [TimeZoneCode] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[ActivityDepthHeightMeasure] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[ActivityTopDepthHeightMeasure] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[ActivityLocation] ( [LatitudeMeasure] decimal (12, 10)  NOT NULL , [LongitudeMeasure] decimal (14, 11)  NOT NULL , [SourceMapScaleNumeric] int  NOT NULL , [HorizontalCollectionMethodName] char (150)  NOT NULL , CONSTRAINT [CK_ActivityLocation_HorizontalCollectionMethodName] CHECK ( (  LEN ( [HorizontalCollectionMethodName] )  >= 1 )  )  , [HorizontalCoordinateReferenceSystemDatumName] char (6)  NOT NULL , CONSTRAINT [CK_ActivityLocation_HorizontalCoordinateReferenceSystemDatumName] CHECK ( (  LEN ( [HorizontalCoordinateReferenceSystemDatumName] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[BiologicalActivityDescription] ( [AssemblageSampledName] char (50)  NOT NULL , [ToxicityTestType] char (7)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[BiologicalHabitatCollectionInformation] ( [SamplingComponentName] char (15)  NOT NULL , [SamplingComponentPlaceInSeriesNumeric] int  NOT NULL , [PassCount] int  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[CollectionDuration] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[ReachLengthMeasure] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[ReachWidthMeasure] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[NetInformation] ( [NetTypeName] char (30)  NOT NULL , CONSTRAINT [CK_NetInformation_NetTypeName] CHECK ( (  LEN ( [NetTypeName] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[SampleDescription] ( [SampleCollectionEquipmentName] char (40)  NOT NULL , CONSTRAINT [CK_SampleDescription_SampleCollectionEquipmentName] CHECK ( (  LEN ( [SampleCollectionEquipmentName] )  >= 1 )  )  , [SampleCollectionEquipmentCommentText] char (4000)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[SampleCollectionMethod] ( [MethodIdentifier] char (20)  NOT NULL , CONSTRAINT [CK_SampleCollectionMethod_MethodIdentifier] CHECK ( (  LEN ( [MethodIdentifier] )  >= 1 )  )  , [MethodIdentifierContext] char (120)  NOT NULL , CONSTRAINT [CK_SampleCollectionMethod_MethodIdentifierContext] CHECK ( (  LEN ( [MethodIdentifierContext] )  >= 1 )  )  , [MethodName] char (120)  NOT NULL , CONSTRAINT [CK_SampleCollectionMethod_MethodName] CHECK ( (  LEN ( [MethodName] )  >= 1 )  )  , [MethodQualifierTypeName] char (25)  NOT NULL , [MethodDescriptionText] char (500)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[SamplePreparation] ( [SampleContainerTypeName] char (35)  NOT NULL , CONSTRAINT [CK_SamplePreparation_SampleContainerTypeName] CHECK ( (  LEN ( [SampleContainerTypeName] )  >= 1 )  )  , [SampleContainerColorName] char (15)  NOT NULL , CONSTRAINT [CK_SamplePreparation_SampleContainerColorName] CHECK ( (  LEN ( [SampleContainerColorName] )  >= 1 )  )  , [ChemicalPreservativeUsedName] char (250)  NOT NULL , [ThermalPreservativeUsedName] char (25)  NOT NULL , [SampleTransportStorageDescription] char (250)  NOT NULL , CONSTRAINT [CK_SamplePreparation_SampleTransportStorageDescription] CHECK ( (  LEN ( [SampleTransportStorageDescription] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[SamplePreparationMethod] ( [MethodIdentifier] char (20)  NOT NULL , CONSTRAINT [CK_SamplePreparationMethod_MethodIdentifier] CHECK ( (  LEN ( [MethodIdentifier] )  >= 1 )  )  , [MethodIdentifierContext] char (120)  NOT NULL , CONSTRAINT [CK_SamplePreparationMethod_MethodIdentifierContext] CHECK ( (  LEN ( [MethodIdentifierContext] )  >= 1 )  )  , [MethodName] char (120)  NOT NULL , CONSTRAINT [CK_SamplePreparationMethod_MethodName] CHECK ( (  LEN ( [MethodName] )  >= 1 )  )  , [MethodQualifierTypeName] char (25)  NOT NULL , [MethodDescriptionText] char (500)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[ActivityMetric] ( [MetricScoreNumeric] char (10)  NOT NULL , [MetricCommentText] char (4000)  NOT NULL , [IndexIdentifier] char (35)  NOT NULL , CONSTRAINT [CK_ActivityMetric_IndexIdentifier] CHECK ( (  LEN ( [IndexIdentifier] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[ActivityMetricType] ( [MetricTypeIdentifier] char (35)  NOT NULL , [MetricTypeIdentifierContext] char (50)  NOT NULL , [MetricTypeName] char (50)  NOT NULL , [MetricTypeScaleText] char (50)  NOT NULL , [FormulaDescriptionText] char (50)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[MetricTypeCitation] ( [ResourceTitleName] char (120)  NOT NULL , CONSTRAINT [CK_MetricTypeCitation_ResourceTitleName] CHECK ( (  LEN ( [ResourceTitleName] )  >= 1 )  )  , [ResourceCreatorName] char (120)  NOT NULL , [ResourceSubjectText] char (500)  NOT NULL , [ResourcePublisherName] char (60)  NOT NULL , [ResourceDate] datetime  NOT NULL , [ResourceIdentifier] char (255)  NOT NULL , CONSTRAINT [CK_MetricTypeCitation_ResourceIdentifier] CHECK ( (  LEN ( [ResourceIdentifier] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[MetricValueMeasure] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[AttachedBinaryObject] ( [BinaryObjectFileName] char (255)  NOT NULL , CONSTRAINT [CK_AttachedBinaryObject_BinaryObjectFileName] CHECK ( (  LEN ( [BinaryObjectFileName] )  >= 1 )  )  , [BinaryObjectFileTypeCode] char (6)  NOT NULL , CONSTRAINT [CK_AttachedBinaryObject_BinaryObjectFileTypeCode] CHECK ( (  LEN ( [BinaryObjectFileTypeCode] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[ResultDescription] ( [DataLoggerLineName] char (15)  NOT NULL , [ResultDetectionConditionText] char (35)  NOT NULL , [CharacteristicName] char (120)  NOT NULL , [MethodSpeciationName] char (20)  NOT NULL , [ResultSampleFractionText] char (25)  NOT NULL , [ResultStatusIdentifier] char (12)  NOT NULL , [StatisticalBaseCode] char (25)  NOT NULL , [ResultValueTypeName] char (20)  NOT NULL , [ResultWeightBasisText] char (15)  NOT NULL , [ResultTimeBasisText] char (12)  NOT NULL , [ResultTemperatureBasisText] char (12)  NOT NULL , [ResultParticleSizeBasisText] char (15)  NOT NULL , [ResultCommentText] char (4000)  NOT NULL , [ResultDepthAltitudeReferencePointText] char (125)  NOT NULL , [ResultSamplingPointName] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[ResultMeasure] ( [ResultMeasureValue] char (60)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL , [MeasureQualifierCode] char (5)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[DataQuality] ( [PrecisionValue] char (60)  NOT NULL , [BiasValue] char (60)  NOT NULL , [ConfidenceIntervalValue] char (15)  NOT NULL , [UpperConfidenceLimitValue] char (15)  NOT NULL , [LowerConfidenceLimitValue] char (15)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[ResultDepthHeightMeasure] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[BiologicalResultDescription] ( [BiologicalIntentName] char (35)  NOT NULL , [BiologicalIndividualIdentifier] char (4)  NOT NULL , [SubjectTaxonomicName] char (120)  NOT NULL , [UnidentifiedSpeciesIdentifier] char (120)  NOT NULL , [SampleTissueAnatomyName] char (30)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[GroupSummaryCountWeight] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[TaxonomicDetails] ( [CellFormName] char (11)  NOT NULL , [CellShapeName] char (18)  NOT NULL , [HabitName] char (15)  NOT NULL , [VoltinismName] char (25)  NOT NULL , [TaxonomicPollutionTolerance] char (4)  NOT NULL , [TaxonomicPollutionToleranceScaleText] char (50)  NOT NULL , [TrophicLevelName] char (4)  NOT NULL , [FunctionalFeedingGroupName] char (6)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[FrequencyClassInformation] ( [FrequencyClassDescriptorCode] char (50)  NOT NULL , [FrequencyClassDescriptorUnitCode] char (12)  NOT NULL , [LowerClassBoundValue] char (8)  NOT NULL , [UpperClassBoundValue] char (8)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[ResultAnalyticalMethod] ( [MethodIdentifier] char (20)  NOT NULL , CONSTRAINT [CK_ResultAnalyticalMethod_MethodIdentifier] CHECK ( (  LEN ( [MethodIdentifier] )  >= 1 )  )  , [MethodIdentifierContext] char (120)  NOT NULL , CONSTRAINT [CK_ResultAnalyticalMethod_MethodIdentifierContext] CHECK ( (  LEN ( [MethodIdentifierContext] )  >= 1 )  )  , [MethodName] char (120)  NOT NULL , CONSTRAINT [CK_ResultAnalyticalMethod_MethodName] CHECK ( (  LEN ( [MethodName] )  >= 1 )  )  , [MethodQualifierTypeName] char (25)  NOT NULL , [MethodDescriptionText] char (500)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[ResultLabInformation] ( [LaboratoryName] char (60)  NOT NULL , [AnalysisStartDate] datetime  NOT NULL , [AnalysisEndDate] datetime  NOT NULL , [ResultLaboratoryCommentCode] char (3)  NOT NULL , [LaboratoryAccreditationIndicator] bit  NOT NULL , [LaboratoryAccreditationAuthorityName] char (20)  NOT NULL , [TaxonomistAccreditationIndicator] bit  NOT NULL , [TaxonomistAccreditationAuthorityName] char (20)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[AnalysisStartTime] ( [Time] datetime  NOT NULL , [TimeZoneCode] char (4)  NOT NULL , CONSTRAINT [CK_AnalysisStartTime_TimeZoneCode] CHECK ( (  LEN ( [TimeZoneCode] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[AnalysisEndTime] ( [Time] datetime  NOT NULL , [TimeZoneCode] char (4)  NOT NULL , CONSTRAINT [CK_AnalysisEndTime_TimeZoneCode] CHECK ( (  LEN ( [TimeZoneCode] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[ResultDetectionQuantitationLimit] ( [DetectionQuantitationLimitTypeName] char (35)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[LabSamplePreparation] ( [PreparationStartDate] datetime  NOT NULL , [PreparationEndDate] datetime  NOT NULL , [SubstanceDilutionFactorNumeric] char (10)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[LabSamplePreparationMethod] ( [MethodIdentifier] char (20)  NOT NULL , CONSTRAINT [CK_LabSamplePreparationMethod_MethodIdentifier] CHECK ( (  LEN ( [MethodIdentifier] )  >= 1 )  )  , [MethodIdentifierContext] char (120)  NOT NULL , CONSTRAINT [CK_LabSamplePreparationMethod_MethodIdentifierContext] CHECK ( (  LEN ( [MethodIdentifierContext] )  >= 1 )  )  , [MethodName] char (120)  NOT NULL , CONSTRAINT [CK_LabSamplePreparationMethod_MethodName] CHECK ( (  LEN ( [MethodName] )  >= 1 )  )  , [MethodQualifierTypeName] char (25)  NOT NULL , [MethodDescriptionText] char (500)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[PreparationStartTime] ( [Time] datetime  NOT NULL , [TimeZoneCode] char (4)  NOT NULL , CONSTRAINT [CK_PreparationStartTime_TimeZoneCode] CHECK ( (  LEN ( [TimeZoneCode] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[PreparationEndTime] ( [Time] datetime  NOT NULL , [TimeZoneCode] char (4)  NOT NULL , CONSTRAINT [CK_PreparationEndTime_TimeZoneCode] CHECK ( (  LEN ( [TimeZoneCode] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[ActivityGroup] ( [ActivityGroupIdentifier] char (35)  NOT NULL , CONSTRAINT [CK_ActivityGroup_ActivityGroupIdentifier] CHECK ( (  LEN ( [ActivityGroupIdentifier] )  >= 1 )  )  , [ActivityGroupName] char (50)  NOT NULL , [ActivityGroupTypeCode] char (50)  NOT NULL , CONSTRAINT [CK_ActivityGroup_ActivityGroupTypeCode] CHECK ( (  LEN ( [ActivityGroupTypeCode] )  >= 1 )  )  , [ActivityIdentifier] char (35)  NOT NULL , CONSTRAINT [CK_ActivityGroup_ActivityIdentifier] CHECK ( (  LEN ( [ActivityIdentifier] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[AlternateMonitoringLocationIdentity] ( [MonitoringLocationIdentifier] char (35)  NOT NULL , CONSTRAINT [CK_AlternateMonitoringLocationIdentity_MonitoringLocationIdentifier] CHECK ( (  LEN ( [MonitoringLocationIdentifier] )  >= 1 )  )  , [MonitoringLocationIdentifierContext] char (120)  NOT NULL , CONSTRAINT [CK_AlternateMonitoringLocationIdentity_MonitoringLocationIdentifierContext] CHECK ( (  LEN ( [MonitoringLocationIdentifierContext] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[BibliographicReference] ( [ResourceTitleName] char (120)  NOT NULL , CONSTRAINT [CK_BibliographicReference_ResourceTitleName] CHECK ( (  LEN ( [ResourceTitleName] )  >= 1 )  )  , [ResourceCreatorName] char (120)  NOT NULL , [ResourceSubjectText] char (500)  NOT NULL , [ResourcePublisherName] char (60)  NOT NULL , [ResourceDate] datetime  NOT NULL , [ResourceIdentifier] char (255)  NOT NULL , CONSTRAINT [CK_BibliographicReference_ResourceIdentifier] CHECK ( (  LEN ( [ResourceIdentifier] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[BiologicalHabitatIndex] ( [IndexIdentifier] char (35)  NOT NULL , CONSTRAINT [CK_BiologicalHabitatIndex_IndexIdentifier] CHECK ( (  LEN ( [IndexIdentifier] )  >= 1 )  )  , [IndexScoreNumeric] char (10)  NOT NULL , [IndexQualifierCode] char (5)  NOT NULL , [IndexCommentText] char (4000)  NOT NULL , [IndexCalculatedDate] datetime  NOT NULL , [MonitoringLocationIdentifier] char (35)  NOT NULL , CONSTRAINT [CK_BiologicalHabitatIndex_MonitoringLocationIdentifier] CHECK ( (  LEN ( [MonitoringLocationIdentifier] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[IndexType] ( [IndexTypeIdentifier] char (35)  NOT NULL , CONSTRAINT [CK_IndexType_IndexTypeIdentifier] CHECK ( (  LEN ( [IndexTypeIdentifier] )  >= 1 )  )  , [IndexTypeIdentifierContext] char (50)  NOT NULL , [IndexTypeName] char (50)  NOT NULL , [IndexTypeScaleText] char (50)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[IndexTypeCitation] ( [ResourceTitleName] char (120)  NOT NULL , CONSTRAINT [CK_IndexTypeCitation_ResourceTitleName] CHECK ( (  LEN ( [ResourceTitleName] )  >= 1 )  )  , [ResourceCreatorName] char (120)  NOT NULL , [ResourceSubjectText] char (500)  NOT NULL , [ResourcePublisherName] char (60)  NOT NULL , [ResourceDate] datetime  NOT NULL , [ResourceIdentifier] char (255)  NOT NULL , CONSTRAINT [CK_IndexTypeCitation_ResourceIdentifier] CHECK ( (  LEN ( [ResourceIdentifier] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[BoatSpeedMeasure] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[CurrentSpeedMeasure] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[DetectionQuantitationLimit] ( [DetectionQuantitationLimitTypeName] char (35)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[DetectionQuantitationLimitMeasure] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[ElectronicAddress] ( [ElectronicAddressText] char (120)  NOT NULL , [ElectronicAddressTypeName] char (8)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[LocationWeightingFactorMeasure] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[Measure] ( [ResultMeasureValue] char (60)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL , [MeasureQualifierCode] char (5)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[MeasureCompact] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[MonitoringLocationIdentity] ( [MonitoringLocationIdentifier] char (35)  NOT NULL , CONSTRAINT [CK_MonitoringLocationIdentity_MonitoringLocationIdentifier] CHECK ( (  LEN ( [MonitoringLocationIdentifier] )  >= 1 )  )  , [MonitoringLocationName] char (255)  NOT NULL , CONSTRAINT [CK_MonitoringLocationIdentity_MonitoringLocationName] CHECK ( (  LEN ( [MonitoringLocationName] )  >= 1 )  )  , [MonitoringLocationTypeName] char (45)  NOT NULL , CONSTRAINT [CK_MonitoringLocationIdentity_MonitoringLocationTypeName] CHECK ( (  LEN ( [MonitoringLocationTypeName] )  >= 1 )  )  , [MonitoringLocationDescriptionText] char (1999)  NOT NULL , [HUCEightDigitCode] char (8)  NOT NULL , [HUCTwelveDigitCode] char (12)  NOT NULL , [TribalLandIndicator] bit  NOT NULL , [TribalLandName] char (200)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[MonitoringLocationGeospatial] ( [LatitudeMeasure] decimal (12, 10)  NOT NULL , [LongitudeMeasure] decimal (14, 11)  NOT NULL , [SourceMapScaleNumeric] int  NOT NULL , [HorizontalCollectionMethodName] char (150)  NOT NULL , CONSTRAINT [CK_MonitoringLocationGeospatial_HorizontalCollectionMethodName] CHECK ( (  LEN ( [HorizontalCollectionMethodName] )  >= 1 )  )  , [HorizontalCoordinateReferenceSystemDatumName] char (6)  NOT NULL , CONSTRAINT [CK_MonitoringLocationGeospatial_HorizontalCoordinateReferenceSystemDatumName] CHECK ( (  LEN ( [HorizontalCoordinateReferenceSystemDatumName] )  >= 1 )  )  , [VerticalCollectionMethodName] char (50)  NOT NULL , [VerticalCoordinateReferenceSystemDatumName] char (10)  NOT NULL , [CountryCode] char (2)  NOT NULL , [StateCode] char (2)  NOT NULL , [CountyCode] char (3)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[VerticalMeasure] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[WellInformation] ( [WellTypeText] char (255)  NOT NULL , [AquiferName] char (120)  NOT NULL , [FormationTypeText] char (50)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[WellHoleDepthMeasure] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[NetSurfaceAreaMeasure] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[NetMeshSizeMeasure] ( [MeasureValue] char (12)  NOT NULL , [MeasureUnitCode] char (12)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[OrganizationDescription] ( [OrganizationIdentifier] char (30)  NOT NULL , CONSTRAINT [CK_OrganizationDescription_OrganizationIdentifier] CHECK ( (  LEN ( [OrganizationIdentifier] )  >= 1 )  )  , [OrganizationFormalName] char (120)  NOT NULL , CONSTRAINT [CK_OrganizationDescription_OrganizationFormalName] CHECK ( (  LEN ( [OrganizationFormalName] )  >= 1 )  )  , [OrganizationDescriptionText] char (500)  NOT NULL , [TribalCode] char (3)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[Telephonic] ( [TelephoneNumberText] char (15)  NOT NULL , [TelephoneNumberTypeName] char (6)  NOT NULL , [TelephoneExtensionNumberText] char (6)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[OrganizationAddress] ( [AddressTypeName] char (8)  NOT NULL , [AddressText] char (50)  NOT NULL , [SupplementalAddressText] char (120)  NOT NULL , [LocalityName] char (30)  NOT NULL , [StateCode] char (2)  NOT NULL , [PostalCode] char (10)  NOT NULL , [CountryCode] char (2)  NOT NULL , [CountyCode] char (3)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[Project] ( [ProjectIdentifier] char (35)  NOT NULL , CONSTRAINT [CK_Project_ProjectIdentifier] CHECK ( (  LEN ( [ProjectIdentifier] )  >= 1 )  )  , [ProjectName] char (120)  NOT NULL , CONSTRAINT [CK_Project_ProjectName] CHECK ( (  LEN ( [ProjectName] )  >= 1 )  )  , [ProjectDescriptionText] char (1999)  NOT NULL , [SamplingDesignTypeCode] char (20)  NOT NULL , CONSTRAINT [CK_Project_SamplingDesignTypeCode] CHECK ( (  LEN ( [SamplingDesignTypeCode] )  >= 1 )  )  , [QAPPApprovedIndicator] bit  NOT NULL , [QAPPApprovalAgencyName] char (50)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[ProjectMonitoringLocationWeighting] ( [MonitoringLocationIdentifier] char (35)  NOT NULL , CONSTRAINT [CK_ProjectMonitoringLocationWeighting_MonitoringLocationIdentifier] CHECK ( (  LEN ( [MonitoringLocationIdentifier] )  >= 1 )  )  , [StatisticalStratumText] char (15)  NOT NULL , [LocationCategoryName] char (50)  NOT NULL , [LocationStatusName] char (15)  NOT NULL , [ReferenceLocationTypeCode] char (20)  NOT NULL , [ReferenceLocationStartDate] datetime  NOT NULL , [ReferenceLocationEndDate] datetime  NOT NULL , [CommentText] char (4000)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[ReferenceLocationCitation] ( [ResourceTitleName] char (120)  NOT NULL , CONSTRAINT [CK_ReferenceLocationCitation_ResourceTitleName] CHECK ( (  LEN ( [ResourceTitleName] )  >= 1 )  )  , [ResourceCreatorName] char (120)  NOT NULL , [ResourceSubjectText] char (500)  NOT NULL , [ResourcePublisherName] char (60)  NOT NULL , [ResourceDate] datetime  NOT NULL , [ResourceIdentifier] char (255)  NOT NULL , CONSTRAINT [CK_ReferenceLocationCitation_ResourceIdentifier] CHECK ( (  LEN ( [ResourceIdentifier] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[ReferenceMethod] ( [MethodIdentifier] char (20)  NOT NULL , CONSTRAINT [CK_ReferenceMethod_MethodIdentifier] CHECK ( (  LEN ( [MethodIdentifier] )  >= 1 )  )  , [MethodIdentifierContext] char (120)  NOT NULL , CONSTRAINT [CK_ReferenceMethod_MethodIdentifierContext] CHECK ( (  LEN ( [MethodIdentifierContext] )  >= 1 )  )  , [MethodName] char (120)  NOT NULL , CONSTRAINT [CK_ReferenceMethod_MethodName] CHECK ( (  LEN ( [MethodName] )  >= 1 )  )  , [MethodQualifierTypeName] char (25)  NOT NULL , [MethodDescriptionText] char (500)  NOT NULL ) ;

CREATE TABLE [AR].[dbo].[TaxonomicDetailsCitation] ( [ResourceTitleName] char (120)  NOT NULL , CONSTRAINT [CK_TaxonomicDetailsCitation_ResourceTitleName] CHECK ( (  LEN ( [ResourceTitleName] )  >= 1 )  )  , [ResourceCreatorName] char (120)  NOT NULL , [ResourceSubjectText] char (500)  NOT NULL , [ResourcePublisherName] char (60)  NOT NULL , [ResourceDate] datetime  NOT NULL , [ResourceIdentifier] char (255)  NOT NULL , CONSTRAINT [CK_TaxonomicDetailsCitation_ResourceIdentifier] CHECK ( (  LEN ( [ResourceIdentifier] )  >= 1 )  )  ) ;

CREATE TABLE [AR].[dbo].[WQXTime] ( [Time] datetime  NOT NULL , [TimeZoneCode] char (4)  NOT NULL , CONSTRAINT [CK_WQXTime_TimeZoneCode] CHECK ( (  LEN ( [TimeZoneCode] )  >= 1 )  )  ) ;

