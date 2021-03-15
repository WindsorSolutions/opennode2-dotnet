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
using System.Xml;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.ProviderBase;
using Windsor.Node2008.WNOSPlugin;
using System.Diagnostics;
using System.Reflection;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Spring.Data.Common;
using Spring.Transaction.Support;
using Spring.Data.Core;
using System.ComponentModel;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;
using Windsor.Node2008.WNOSPlugin.WQX2XsdOrm;

namespace Windsor.Node2008.WNOSPlugin.WQX3
{
    [Serializable]
    internal class WQXPluginMapper
    {
        private string _attachedBinaryObjectFolder;
        private int _attachedBinaryFileCount;

        public WQXPluginMapper(string attachedBinaryObjectFolder)
        {
            _attachedBinaryObjectFolder = attachedBinaryObjectFolder;
        }
        public string AttachedBinaryObjectFolder
        {
            get { return _attachedBinaryObjectFolder; }
            set { _attachedBinaryObjectFolder = value; }
        }
        public int AttachedBinaryFileCount
        {
            get { return _attachedBinaryFileCount; }
            set { _attachedBinaryFileCount = value; }
        }

        public static ProjectMonitoringLocationWeightingDataType MapProjectMonitoringLocationWeighting(NamedNullMappingDataReader readerEx)
        {
            ProjectMonitoringLocationWeightingDataType weighting = new ProjectMonitoringLocationWeightingDataType();
            weighting.MonitoringLocationIdentifier = readerEx.GetString("MONLOCID");
            weighting.LocationWeightingFactorMeasure =
                GetNullMeasureCompactData(readerEx, "LOCWEIGHTINGFACMEASURE", "LOCWEIGHTINGFACMEASUREUNIT");
            weighting.StatisticalStratumText = readerEx.GetNullString("STATISTICALSTRATUM");
            weighting.LocationCategoryName = readerEx.GetNullString("LOCATIONCATERY");
            weighting.LocationStatusName = readerEx.GetNullString("LOCATIONSTATUS");
            weighting.ReferenceLocationTypeCode = readerEx.GetNullString("REFLOCATIONTYPECODE");
            weighting.ReferenceLocationStartDateSpecified = !readerEx.IsDBNull("REFLOCATIONSTARTDATE");
            if (weighting.ReferenceLocationStartDateSpecified)
            {
                weighting.ReferenceLocationStartDate = readerEx.GetDateTime("REFLOCATIONSTARTDATE");
            }
            weighting.ReferenceLocationEndDateSpecified = !readerEx.IsDBNull("REFLOCATIONENDDATE");
            if (weighting.ReferenceLocationEndDateSpecified)
            {
                weighting.ReferenceLocationEndDate = readerEx.GetDateTime("REFLOCATIONENDDATE");
            }
            if (!readerEx.IsDBNull("RESOURCETITLE") || !readerEx.IsDBNull("RESOURCEID"))
            {
                weighting.ReferenceLocationCitation = new BibliographicReferenceDataType();
                weighting.ReferenceLocationCitation.ResourceTitleName = readerEx.GetString("RESOURCETITLE");
                weighting.ReferenceLocationCitation.ResourceCreatorName = readerEx.GetNullString("RESOURCECREATOR");
                weighting.ReferenceLocationCitation.ResourceSubjectText = readerEx.GetNullString("RESOURCESUBJECT");
                weighting.ReferenceLocationCitation.ResourcePublisherName = readerEx.GetNullString("RESOURCEPUBLISHER");
                weighting.ReferenceLocationCitation.ResourceDate = readerEx.GetDateTime("RESOURCEDATE");
                weighting.ReferenceLocationCitation.ResourceIdentifier = readerEx.GetString("RESOURCEID");
            }
            weighting.CommentText = readerEx.GetNullString("PROJMONLOCCOMMENT");
            return weighting;
        }
        public static ActivityMetricDataType MapActivityMetric(NamedNullMappingDataReader readerEx)
        {
            ActivityMetricDataType activityMetric = new ActivityMetricDataType();
            activityMetric.ActivityMetricType = new ActivityMetricTypeDataType();
            activityMetric.ActivityMetricType.MetricTypeIdentifier = readerEx.GetString("METRICTYPEID");
            activityMetric.ActivityMetricType.MetricTypeIdentifierContext = readerEx.GetString("METRICTYPEIDCONTEXT");
            activityMetric.ActivityMetricType.MetricTypeName = readerEx.GetNullString("METRICTYPENAME");
            if (!readerEx.IsDBNull("CITATIONRESOURCETITLE") || !readerEx.IsDBNull("CITATIONRESOURCEID"))
            {
                activityMetric.ActivityMetricType.MetricTypeCitation = new BibliographicReferenceDataType();
                activityMetric.ActivityMetricType.MetricTypeCitation.ResourceTitleName = readerEx.GetString("CITATIONRESOURCETITLE");
                activityMetric.ActivityMetricType.MetricTypeCitation.ResourceCreatorName = readerEx.GetNullString("CITATIONRESOURCECREATOR");
                activityMetric.ActivityMetricType.MetricTypeCitation.ResourceSubjectText = readerEx.GetNullString("CITATIONRESOURCESUBJECT");
                activityMetric.ActivityMetricType.MetricTypeCitation.ResourcePublisherName = readerEx.GetNullString("CITATIONRESOURCEPUBLISHER");
                activityMetric.ActivityMetricType.MetricTypeCitation.ResourceDate = readerEx.GetDateTime("CITATIONRESOURCEDATE");
                activityMetric.ActivityMetricType.MetricTypeCitation.ResourceIdentifier = readerEx.GetString("CITATIONRESOURCEID");
            }
            activityMetric.ActivityMetricType.MetricTypeScaleText = readerEx.GetNullString("METRICTYPESCALE");
            activityMetric.ActivityMetricType.FormulaDescriptionText = readerEx.GetNullString("METRICTYPEFORMULADESC");
            activityMetric.MetricValueMeasure =
                GetNullMeasureCompactData(readerEx, "METRICVALUEMEASURE", "METRICVALUEMEASUREUNIT");
            activityMetric.MetricScoreNumeric = readerEx.GetString("METRICSCORE");
            activityMetric.MetricCommentText = readerEx.GetNullString("METRICCOMMENT");
            if (!readerEx.IsDBNull("METRICINDEXID"))
            {
                activityMetric.IndexIdentifier = readerEx.GetString("METRICINDEXID");
            }
            return activityMetric;
        }
        public T MapAttachedBinaryObject<T>(NamedNullMappingDataReader readerEx) where T : AttachedBinaryObjectDataType, new()
        {
            T attachedBinaryObject = new T();
            attachedBinaryObject.BinaryObjectFileName = readerEx.GetString("BINARYOBJECTFILE");
            attachedBinaryObject.BinaryObjectFileTypeCode = readerEx.GetString("BINARYOBJECTFILETYPECODE");
            SaveAttachedBinaryContent(attachedBinaryObject.BinaryObjectFileName,
                                      readerEx.GetNullBytes("BINARYOBJECTCONTENT"));
            return attachedBinaryObject;
        }
        public static OrganizationDescriptionDataType MapOrganizationDescription(NamedNullMappingDataReader readerEx)
        {
            OrganizationDescriptionDataType organizationDescriptionDataType = new OrganizationDescriptionDataType();
            organizationDescriptionDataType.OrganizationIdentifier = readerEx.GetString("ORGID");
            organizationDescriptionDataType.OrganizationFormalName = readerEx.GetString("ORGFORMALNAME");
            organizationDescriptionDataType.OrganizationDescriptionText = readerEx.GetNullString("ORGDESC");
            organizationDescriptionDataType.TribalCode = readerEx.GetNullString("TRIBALCODE");
            return organizationDescriptionDataType;
        }
        public static ElectronicAddressDataType MapElectronicAddress(NamedNullMappingDataReader readerEx)
        {
            ElectronicAddressDataType address = new ElectronicAddressDataType();
            address.ElectronicAddressText = readerEx.GetNullString("ELECTRONICADDRESS");
            address.ElectronicAddressTypeName = readerEx.GetNullString("ELECTRONICADDRESSTYPE");
            return address;
        }
        public static OrganizationAddressDataType MapOrganizationAddress(NamedNullMappingDataReader readerEx)
        {
            OrganizationAddressDataType address = new OrganizationAddressDataType();
            address.AddressTypeName = readerEx.GetNullString("ADDRESSTYPE");
            address.AddressText = readerEx.GetNullString("ADDRESS");
            address.SupplementalAddressText = readerEx.GetNullString("SUPPLEMENTALADDRESS");
            address.LocalityName = readerEx.GetNullString("LOCALITY");
            address.StateCode = readerEx.GetNullString("STATECODE");
            address.PostalCode = readerEx.GetNullString("POSTALCODE");
            address.CountryCode = readerEx.GetNullString("COUNTRYCODE");
            address.CountyCode = readerEx.GetNullString("COUNTYCODE");
            return address;
        }
        public static ProjectDataType MapProject(NamedNullMappingDataReader readerEx)
        {
            ProjectDataType project = new ProjectDataType();
            project.ProjectIdentifier = readerEx.GetString("PROJECTID");
            project.ProjectName = readerEx.GetString("PROJECTNAME");
            project.ProjectDescriptionText = readerEx.GetNullString("PROJECTDESC");
            project.SamplingDesignTypeCode = readerEx.GetNullString("SAMPLINGDESIGNTYPECODE");
            project.QAPPApprovedIndicatorSpecified = !readerEx.IsDBNull("QAPPAPPROVEDIND");
            if (project.QAPPApprovedIndicatorSpecified)
            {
                project.QAPPApprovedIndicator = ToBool(readerEx.GetString("QAPPAPPROVEDIND"));
            }
            project.QAPPApprovalAgencyName = readerEx.GetNullString("QAPPAPPROVALAGENCYNAME");
            return project;
        }
        public static TelephonicDataType MapTelephonic(NamedNullMappingDataReader readerEx)
        {
            TelephonicDataType telephonic = new TelephonicDataType();
            telephonic.TelephoneNumberText = readerEx.GetNullString("TELEPHONENUMBER");
            telephonic.TelephoneNumberTypeName = readerEx.GetNullString("TELEPHONENUMBERTYPE");
            telephonic.TelephoneExtensionNumberText = readerEx.GetNullString("TELEPHONEEXT");
            return telephonic;
        }
        public static ResultDataType MapResult(NamedNullMappingDataReader readerEx)
        {
            ResultDataType result = new ResultDataType();
            result.RecordId = readerEx.GetString("RECORDID");
            result.ResultDescription = new ResultDescriptionDataType();
            result.ResultDescription.DataLoggerLineName = readerEx.GetNullString("DATALOGGERLINENAME");
            result.ResultDescription.ResultDetectionConditionText = readerEx.GetNullString("RESULTDETECTIONCONDITION");
            result.ResultDescription.CharacteristicName = readerEx.GetNullString("CHARACTERISTICNAME");
            result.ResultDescription.MethodSpeciationName = readerEx.GetNullString("METHODSPECIATIONNAME");
            result.ResultDescription.ResultSampleFractionText = readerEx.GetNullString("RESULTSAMPFRACTION");
            result.ResultDescription.ResultMeasure = new MeasureDataType();
            result.ResultDescription.ResultMeasure.ResultMeasureValue = readerEx.GetNullString("RESULTMEASURE");
            result.ResultDescription.ResultMeasure.MeasureUnitCode = readerEx.GetNullString("RESULTMEASUREUNIT");
            result.ResultDescription.ResultMeasure.MeasureQualifierCode = readerEx.GetNullString("RESULTMEASUREQUALIFIERCODE");
            result.ResultDescription.ResultStatusIdentifier = readerEx.GetNullString("STATUSID");
            result.ResultDescription.StatisticalBaseCode = readerEx.GetNullString("STATISTICALBASECODE");
            result.ResultDescription.ResultValueTypeName = readerEx.GetNullString("VALUETYPE");
            result.ResultDescription.ResultWeightBasisText = readerEx.GetNullString("WEIGHTBASIS");
            result.ResultDescription.ResultTimeBasisText = readerEx.GetNullString("TIMEBASIS");
            result.ResultDescription.ResultTemperatureBasisText = readerEx.GetNullString("TEMPERATUREBASIS");
            result.ResultDescription.ResultParticleSizeBasisText = readerEx.GetNullString("PARTICLESIZEBASIS");
            result.ResultDescription.DataQuality = new DataQualityDataType();
            result.ResultDescription.DataQuality.PrecisionValue = readerEx.GetNullString("PRECISIONVALUE");
            result.ResultDescription.DataQuality.BiasValue = readerEx.GetNullString("BIASVALUE");
            result.ResultDescription.DataQuality.ConfidenceIntervalValue = readerEx.GetNullString("CONFIDENCEINTERVALVALUE");
            result.ResultDescription.DataQuality.UpperConfidenceLimitValue = readerEx.GetNullString("UPPERCONFIDENCELIMITVALUE");
            result.ResultDescription.DataQuality.LowerConfidenceLimitValue = readerEx.GetNullString("LOWERCONFIDENCELIMITVALUE");
            result.ResultDescription.ResultCommentText = readerEx.GetNullString("RESULTCOMMENT");
            result.ResultDescription.ResultDepthHeightMeasure =
                GetNullMeasureCompactData(readerEx, "DEPTHHEIGHTMEASURE", "DEPTHHEIGHTMEASUREUNIT");
            result.ResultDescription.ResultDepthAltitudeReferencePointText = readerEx.GetNullString("DEPTHALTITUDEREFPOINT");
            result.ResultDescription.ResultSamplingPointName = readerEx.GetNullString("RESULTSAMPPOINT");

            if (!readerEx.IsDBNull("BIORESULTINTENT") || !readerEx.IsDBNull("BIORESULTSUBJECTTAXONOMIC"))
            {
                result.BiologicalResultDescription = new BiologicalResultDescriptionDataType();
                result.BiologicalResultDescription.BiologicalIntentName = readerEx.GetString("BIORESULTINTENT");
                result.BiologicalResultDescription.BiologicalIndividualIdentifier = readerEx.GetNullString("BIORESULTINDIVIDUALID");
                result.BiologicalResultDescription.SubjectTaxonomicName = readerEx.GetString("BIORESULTSUBJECTTAXONOMIC");
                result.BiologicalResultDescription.UnidentifiedSpeciesIdentifier = readerEx.GetNullString("BIORESULTUNIDENTIFIEDSPECIESID");
                result.BiologicalResultDescription.SampleTissueAnatomyName = readerEx.GetNullString("BIORESULTSAMPTISSUEANATOMY");
                result.BiologicalResultDescription.GroupSummaryCountWeight =
                    GetNullMeasureCompactData(readerEx, "GRPSUMMCOUNTWEIGHTMEASURE", "GRPSUMMCOUNTWEIGHTMEASUREUNIT");
                result.BiologicalResultDescription.TaxonomicDetails = new TaxonomicDetailsDataType();
                result.BiologicalResultDescription.TaxonomicDetails.CellFormName = readerEx.GetNullString("TAXDETAILSCELLFORM");
                result.BiologicalResultDescription.TaxonomicDetails.CellShapeName = readerEx.GetNullString("TAXDETAILSCELLSHAPE");
                if (!readerEx.IsDBNull("TAXDETAILSHABITNAME"))
                {
                    result.BiologicalResultDescription.TaxonomicDetails.HabitName =
                        WQXDataHelper.PipedStringToStrings(readerEx.GetString("TAXDETAILSHABITNAME"));
                }
                result.BiologicalResultDescription.TaxonomicDetails.VoltinismName = readerEx.GetNullString("TAXDETAILSVOLTINISM");
                result.BiologicalResultDescription.TaxonomicDetails.TaxonomicPollutionTolerance = readerEx.GetNullString("TAXDETAILSPOLLTOLERANCE");
                result.BiologicalResultDescription.TaxonomicDetails.TaxonomicPollutionToleranceScaleText = readerEx.GetNullString("TAXDETAILSPOLLTOLERANCESCALE");
                result.BiologicalResultDescription.TaxonomicDetails.TrophicLevelName = readerEx.GetNullString("TAXDETAILSTROPHICLEVEL");
                if (!readerEx.IsDBNull("TAXDETAILSFUNCFEEDINGGROUP"))
                {
                    result.BiologicalResultDescription.TaxonomicDetails.FunctionalFeedingGroupName =
                        WQXDataHelper.PipedStringToStrings(readerEx.GetString("TAXDETAILSFUNCFEEDINGGROUP"));
                }
                if (!readerEx.IsDBNull("CITATIONRESOURCETITLE") || !readerEx.IsDBNull("CITATIONRESOURCEID"))
                {
                    result.BiologicalResultDescription.TaxonomicDetails.TaxonomicDetailsCitation = new BibliographicReferenceDataType();
                    result.BiologicalResultDescription.TaxonomicDetails.TaxonomicDetailsCitation.ResourceTitleName = readerEx.GetString("CITATIONRESOURCETITLE");
                    result.BiologicalResultDescription.TaxonomicDetails.TaxonomicDetailsCitation.ResourceCreatorName = readerEx.GetNullString("CITATIONRESOURCECREATOR");
                    result.BiologicalResultDescription.TaxonomicDetails.TaxonomicDetailsCitation.ResourceSubjectText = readerEx.GetNullString("CITATIONRESOURCESUBJECT");
                    result.BiologicalResultDescription.TaxonomicDetails.TaxonomicDetailsCitation.ResourcePublisherName = readerEx.GetNullString("CITATIONRESOURCEPUBLISHER");
                    result.BiologicalResultDescription.TaxonomicDetails.TaxonomicDetailsCitation.ResourceDate = readerEx.GetDateTime("CITATIONRESOURCEDATE");
                    result.BiologicalResultDescription.TaxonomicDetails.TaxonomicDetailsCitation.ResourceIdentifier = readerEx.GetString("CITATIONRESOURCEID");
                }
                if (!readerEx.IsDBNull("FREQCLASSDESCCODE"))
                {
                    result.BiologicalResultDescription.FrequencyClassInformation = new FrequencyClassInformationDataType();
                    result.BiologicalResultDescription.FrequencyClassInformation.FrequencyClassDescriptorCode = readerEx.GetString("FREQCLASSDESCCODE");
                    result.BiologicalResultDescription.FrequencyClassInformation.FrequencyClassDescriptorUnitCode = readerEx.GetNullString("FREQCLASSDESCUNITCODE");
                    result.BiologicalResultDescription.FrequencyClassInformation.LowerClassBoundValue = readerEx.GetNullString("FREQCLASSLOWERBOUNDVALUE");
                    result.BiologicalResultDescription.FrequencyClassInformation.UpperClassBoundValue = readerEx.GetNullString("FREQCLASSUPPERBOUNDVALUE");
                }
            }
            if (!readerEx.IsDBNull("ANALYTICALMETHODID") || !readerEx.IsDBNull("ANALYTICALMETHODIDCONTEXT"))
            {
                result.ResultAnalyticalMethod = new ResultAnalyticalMethodDataType();
                result.ResultAnalyticalMethod.MethodIdentifier = readerEx.GetString("ANALYTICALMETHODID");
                result.ResultAnalyticalMethod.MethodIdentifierContext = readerEx.GetString("ANALYTICALMETHODIDCONTEXT");
                result.ResultAnalyticalMethod.MethodName = readerEx.GetNullString("ANALYTICALMETHODNAME");
                result.ResultAnalyticalMethod.MethodQualifierTypeName = readerEx.GetNullString("ANALYTICALMETHODQUALIFIERTYPE");
                result.ResultAnalyticalMethod.MethodDescriptionText = readerEx.GetNullString("ANALYTICALMETHODDESC");
            }
            result.ResultLabInformation = new ResultLabInformationDataType();
            result.ResultLabInformation.LaboratoryName = readerEx.GetNullString("LABNAME");
            result.ResultLabInformation.AnalysisStartDateSpecified = !readerEx.IsDBNull("LABANALYSISSTARTDATE");
            if (result.ResultLabInformation.AnalysisStartDateSpecified)
            {
                result.ResultLabInformation.AnalysisStartDate = readerEx.GetDateTime("LABANALYSISSTARTDATE");
            }
            result.ResultLabInformation.AnalysisStartTime = GetNullTimeData(readerEx, "LABANALYSISSTARTTIME", "LABANALYSISSTARTTIMEZONECODE");
            result.ResultLabInformation.AnalysisEndDateSpecified = !readerEx.IsDBNull("LABANALYSISENDDATE");
            if (result.ResultLabInformation.AnalysisEndDateSpecified)
            {
                result.ResultLabInformation.AnalysisEndDate = readerEx.GetDateTime("LABANALYSISENDDATE");
            }
            result.ResultLabInformation.AnalysisEndTime = GetNullTimeData(readerEx, "LABANALYSISENDTIME", "LABANALYSISENDTIMEZONECODE");
            result.ResultLabInformation.ResultLaboratoryCommentCode = readerEx.GetNullString("RESULTLABCOMMENTCODE");
            result.ResultLabInformation.LaboratoryAccreditationIndicatorSpecified = !readerEx.IsDBNull("LABACCIND");
            if (result.ResultLabInformation.LaboratoryAccreditationIndicatorSpecified)
            {
                result.ResultLabInformation.LaboratoryAccreditationIndicator = ToBool(readerEx.GetString("LABACCIND"));
            }
            result.ResultLabInformation.LaboratoryAccreditationAuthorityName = readerEx.GetNullString("LABACCAUTHORITYNAME");
            result.ResultLabInformation.TaxonomistAccreditationIndicatorSpecified = !readerEx.IsDBNull("LABTAXACCIND");
            if (result.ResultLabInformation.TaxonomistAccreditationIndicatorSpecified)
            {
                result.ResultLabInformation.TaxonomistAccreditationIndicator = ToBool(readerEx.GetString("LABTAXACCIND"));
            }
            result.ResultLabInformation.TaxonomistAccreditationAuthorityName = readerEx.GetNullString("LABTAXACCAUTHORITYNAME");
#if NO
        // TODO
        result.BiologicalResultDescription.FrequencyClassInformation
        result.LabSamplePreparation
#endif
            return result;
        }
        protected static DateTime GetDateTimeByObject(NamedNullMappingDataReader readerEx, string colName)
        {
            int index = readerEx.GetOrdinal(colName);
            object value = readerEx.GetValue(index);
            if (value.GetType() != typeof(DateTime))
            {
                return DateTime.Parse(value.ToString());
            }
            return (DateTime)value;
        }
        public static ActivityDataType MapActivity(NamedNullMappingDataReader readerEx)
        {
            ActivityDataType activity = new ActivityDataType();
            activity.ActivityDescription = new ActivityDescriptionDataType();
            activity.ActivityDescription.ActivityIdentifier = readerEx.GetString("ACTIVITYID");
            activity.ActivityDescription.ActivityTypeCode = readerEx.GetString("ACTIVITYTYPECODE");
            activity.ActivityDescription.ActivityMediaName = readerEx.GetString("ACTIVITYMEDIA");
            activity.ActivityDescription.ActivityMediaSubdivisionName = readerEx.GetNullString("ACTIVITYMEDIASUBDIVISION");
            activity.ActivityDescription.ActivityStartDate = readerEx.GetDateTime("ACTIVITYSTARTDATE");
            activity.ActivityDescription.ActivityStartTime = GetNullTimeData(readerEx, "STARTTIME", "STARTTIMEZONE");
            activity.ActivityDescription.ActivityEndDateSpecified = !readerEx.IsDBNull("ACTIVITYENDDATE");
            if (activity.ActivityDescription.ActivityEndDateSpecified)
            {
                activity.ActivityDescription.ActivityEndDate = readerEx.GetDateTime("ACTIVITYENDDATE");
            }
            activity.ActivityDescription.ActivityEndTime = GetNullTimeData(readerEx, "ENDTIME", "ENDTIMEZONE");
            activity.ActivityDescription.ActivityRelativeDepthName = readerEx.GetNullString("RELATIVEDEPTH");
            activity.ActivityDescription.ActivityDepthHeightMeasure =
                GetNullMeasureCompactData(readerEx, "DEPTHHEIGHTMEASURE", "DEPTHHEIGHTMEASUREUNIT");
            activity.ActivityDescription.ActivityTopDepthHeightMeasure =
                GetNullMeasureCompactData(readerEx, "TOPDEPTHHEIGHTMEASURE", "TOPDEPTHHEIGHTMEASUREUNIT");
            activity.ActivityDescription.ActivityBottomDepthHeightMeasure =
                GetNullMeasureCompactData(readerEx, "BOTTOMDEPTHHEIGHTMEASURE", "BOTTOMDEPTHHEIGHTMEASUREUNIT");
            activity.ActivityDescription.ActivityDepthAltitudeReferencePointText = readerEx.GetNullString("DEPTHALTITUDEREFPOINT");
            activity.ActivityDescription.MonitoringLocationIdentifier = readerEx.GetNullString("MONLOCID");
            activity.ActivityDescription.ActivityCommentText = readerEx.GetNullString("ACTIVITYCOMMENT");
            if (!readerEx.IsDBNull("LATITUDEMEASURE") || !readerEx.IsDBNull("LONGITUDEMEASURE") ||
                !readerEx.IsDBNull("HORIZCOLLMETHOD") || !readerEx.IsDBNull("HORIZCOORDREFSYSDATUM"))
            {
                activity.ActivityLocation = new ActivityLocationDataType();
                activity.ActivityLocation.LatitudeMeasure = ToDecimal(readerEx.GetString("LATITUDEMEASURE"));
                activity.ActivityLocation.LongitudeMeasure = ToDecimal(readerEx.GetString("LONGITUDEMEASURE"));
                activity.ActivityLocation.SourceMapScaleNumeric = readerEx.GetNullString("SOURCEMAPSCALE");
                activity.ActivityLocation.HorizontalAccuracyMeasure =
                    GetNullMeasureCompactData(readerEx, "HORIZACCURACYMEASURE", "HORIZACCURACYMEASUREUNIT");
                activity.ActivityLocation.HorizontalCollectionMethodName = readerEx.GetString("HORIZCOLLMETHOD");
                activity.ActivityLocation.HorizontalCoordinateReferenceSystemDatumName = readerEx.GetString("HORIZCOORDREFSYSDATUM");
            }
            activity.BiologicalActivityDescription = new BiologicalActivityDescriptionDataType();
            activity.BiologicalActivityDescription.AssemblageSampledName = readerEx.GetNullString("BIOACTIVITYASSEMBLAGESAMPD");
            activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation = new BiologicalHabitatCollectionInformationDataType();
            activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.CollectionDuration =
                GetNullMeasureCompactData(readerEx, "BIOHABCOLLDURATIONMEASURE", "BIOHABCOLLDURATIONMEASUREUNIT");
            activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.SamplingComponentName =
                readerEx.GetNullString("BIOHABSAMPCOMP");
            activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.SamplingComponentPlaceInSeriesNumeric =
                readerEx.GetNullString("BIOHABSAMPCOMPPLACEINSERIES");
            activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.ReachWidthMeasure =
                GetNullMeasureCompactData(readerEx, "BIOHABREACHLENGTHMEASURE", "BIOHABREACHLENGTHMEASUREUNIT");
            activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.ReachLengthMeasure =
                GetNullMeasureCompactData(readerEx, "BIOHABREACHWIDTHMEASURE", "BIOHABREACHWIDTHMEASUREUNIT");
            activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.PassCount = readerEx.GetNullString("BIOHABPASSCOUNT");
            if (!readerEx.IsDBNull("BIOHABNETTYPE") || 
                !readerEx.IsDBNull("BIOHABNETSURFACEAREAMEASURE") || !readerEx.IsDBNull("BIOHABNETSURFACEMEASUREUNIT") ||
                !readerEx.IsDBNull("BIOHABNETMESHSIZEMEASURE") || !readerEx.IsDBNull("BIOHABNETMESHMEASUREUNIT"))
            {
                activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.NetInformation = new NetInformationDataType();
                activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.NetInformation.NetTypeName =
                    readerEx.GetString("BIOHABNETTYPE");
                activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.NetInformation.NetSurfaceAreaMeasure =
                    GetNullMeasureCompactData(readerEx, "BIOHABNETSURFACEAREAMEASURE", "BIOHABNETSURFACEMEASUREUNIT");
                activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.NetInformation.NetMeshSizeMeasure =
                    GetNullMeasureCompactData(readerEx, "BIOHABNETMESHSIZEMEASURE", "BIOHABNETMESHMEASUREUNIT");
                activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.NetInformation.BoatSpeedMeasure =
                    GetNullMeasureCompactData(readerEx, "BIOHABNETBOATSPEEDMEASURE", "BIOHABNETBOATSPEEDMEASUREUNIT");
                activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.NetInformation.CurrentSpeedMeasure =
                    GetNullMeasureCompactData(readerEx, "BIOHABNETCURRSPEEDMEASURE", "BIOHABNETCURRSPEEDMEASUREUNIT");
            }
            if ((activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.CollectionDuration == null) &&
                string.IsNullOrEmpty(activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.SamplingComponentName) &&
                string.IsNullOrEmpty(activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.SamplingComponentPlaceInSeriesNumeric) &&
                (activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.ReachWidthMeasure == null) &&
                (activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.ReachLengthMeasure == null) &&
                string.IsNullOrEmpty(activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.PassCount) &&
                (activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation.NetInformation == null))
            {
                activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation = null;
            }
            activity.BiologicalActivityDescription.ToxicityTestType = readerEx.GetNullString("BIOACTIVITYTOXICITYTESTTYPE");
            if (string.IsNullOrEmpty(activity.BiologicalActivityDescription.AssemblageSampledName) &&
                 string.IsNullOrEmpty(activity.BiologicalActivityDescription.ToxicityTestType) &&
                 (activity.BiologicalActivityDescription.BiologicalHabitatCollectionInformation == null))
            {
                activity.BiologicalActivityDescription = null;
            }
            activity.SampleDescription = new SampleDescriptionDataType();
            if (!readerEx.IsDBNull("SAMPCOLLMETHODID") || !readerEx.IsDBNull("SAMPCOLLMETHODIDCONTEXT") || !readerEx.IsDBNull("SAMPCOLLMETHOD"))
            {
                activity.SampleDescription.SampleCollectionMethod = new ReferenceMethodDataType();
                activity.SampleDescription.SampleCollectionMethod.MethodIdentifier = readerEx.GetString("SAMPCOLLMETHODID");
                activity.SampleDescription.SampleCollectionMethod.MethodIdentifierContext = readerEx.GetString("SAMPCOLLMETHODIDCONTEXT");
                activity.SampleDescription.SampleCollectionMethod.MethodName = readerEx.GetString("SAMPCOLLMETHOD");
                activity.SampleDescription.SampleCollectionMethod.MethodQualifierTypeName = readerEx.GetNullString("SAMPCOLLMETHODQUALIFIER");
                activity.SampleDescription.SampleCollectionMethod.MethodDescriptionText = readerEx.GetNullString("SAMPCOLLMETHODDESC");
            } 
            activity.SampleDescription.SampleCollectionEquipmentName = readerEx.GetString("SAMPCOLLEQUIPMENT");
            activity.SampleDescription.SampleCollectionEquipmentCommentText = readerEx.GetNullString("SAMPCOLLEQUIPMENTCOMMENT");
            if (!readerEx.IsDBNull("SAMPPREPCONTTYPE") || !readerEx.IsDBNull("SAMPPREPCONTCOLOR") || !readerEx.IsDBNull("SAMPPREPCONTSAMPTRANSSTORDESC") ||
                !readerEx.IsDBNull("SAMPPREPID") || !readerEx.IsDBNull("SAMPPREPIDCONTEXT") || !readerEx.IsDBNull("SAMPPREP"))
            {
                activity.SampleDescription.SamplePreparation = new SamplePreparationDataType();
                if (!readerEx.IsDBNull("SAMPPREPID") || !readerEx.IsDBNull("SAMPPREPIDCONTEXT") || !readerEx.IsDBNull("SAMPPREP"))
                {
                    activity.SampleDescription.SamplePreparation.SamplePreparationMethod = new ReferenceMethodDataType();
                    activity.SampleDescription.SamplePreparation.SamplePreparationMethod.MethodIdentifier = readerEx.GetString("SAMPPREPID");
                    activity.SampleDescription.SamplePreparation.SamplePreparationMethod.MethodIdentifierContext = readerEx.GetString("SAMPPREPIDCONTEXT");
                    activity.SampleDescription.SamplePreparation.SamplePreparationMethod.MethodName = readerEx.GetString("SAMPPREP");
                    activity.SampleDescription.SamplePreparation.SamplePreparationMethod.MethodQualifierTypeName = readerEx.GetNullString("SAMPPREPQUALIFIERTYPE");
                    activity.SampleDescription.SamplePreparation.SamplePreparationMethod.MethodDescriptionText = readerEx.GetNullString("SAMPPREPDESC");
                }
                activity.SampleDescription.SamplePreparation.SampleContainerTypeName = readerEx.GetString("SAMPPREPCONTTYPE");
                activity.SampleDescription.SamplePreparation.SampleContainerColorName = readerEx.GetString("SAMPPREPCONTCOLOR");
                activity.SampleDescription.SamplePreparation.ChemicalPreservativeUsedName = readerEx.GetNullString("SAMPPREPCONTCHEMPRESERVUSED");
                activity.SampleDescription.SamplePreparation.ThermalPreservativeUsedName = readerEx.GetNullString("SAMPPREPCONTTHERMALPRESERVUSED");
                activity.SampleDescription.SamplePreparation.SampleTransportStorageDescription = readerEx.GetString("SAMPPREPCONTSAMPTRANSSTORDESC");
            }
            if (activity.SampleDescription.SampleCollectionMethod == null)
            {
                DebugUtils.AssertDebuggerBreak(string.IsNullOrEmpty(activity.SampleDescription.SampleCollectionEquipmentName));
                // SampleCollectionMethod is required
                activity.SampleDescription = null;
            }
            activity.ResultCount = readerEx.GetNullString("RESULTCOUNT");
            // TODO: TMPACTIVITYTYPE and TMPPROJECTID not used
            return activity;
        }
        public static MonitoringLocationDataType MapMonitoringLocation(NamedNullMappingDataReader readerEx)
        {
            MonitoringLocationDataType location = new MonitoringLocationDataType();
            location.MonitoringLocationIdentity = new MonitoringLocationIdentityDataType();
            location.MonitoringLocationIdentity.MonitoringLocationIdentifier = readerEx.GetString("MONITORINGLOCATIONID");
            location.MonitoringLocationIdentity.MonitoringLocationName = readerEx.GetString("MONLOCNAME");
            location.MonitoringLocationIdentity.MonitoringLocationTypeName = readerEx.GetString("MONLOCTYPE");
            location.MonitoringLocationIdentity.MonitoringLocationDescriptionText = readerEx.GetNullString("MONLOCDESC");
            location.MonitoringLocationIdentity.HUCEightDigitCode = readerEx.GetNullString("HUCEIGHTDIGITCODE");
            location.MonitoringLocationIdentity.HUCTwelveDigitCode = readerEx.GetNullString("HUCTWELVEDIGITCODE");
            location.MonitoringLocationIdentity.TribalLandIndicatorSpecified = !readerEx.IsDBNull("TRIBALLANDIND");
            location.MonitoringLocationIdentity.TribalLandIndicator = ToBool(readerEx.GetString("TRIBALLANDIND"));
            if (location.MonitoringLocationIdentity.TribalLandIndicator)
            {
                location.MonitoringLocationIdentity.TribalLandName = readerEx.GetNullString("TRIBALLANDNAME");
            }
            if (!readerEx.IsDBNull("LATITUDEMEASURE") || !readerEx.IsDBNull("LONGITUDEMEASURE") || !readerEx.IsDBNull("HORIZCOLLMETHOD") ||
                !readerEx.IsDBNull("HORIZCOORDREFSYSDATUM"))
            {
                location.MonitoringLocationGeospatial = new MonitoringLocationGeospatialDataType();
                location.MonitoringLocationGeospatial.LatitudeMeasure = ToDecimal(readerEx.GetString("LATITUDEMEASURE"));
                location.MonitoringLocationGeospatial.LongitudeMeasure = ToDecimal(readerEx.GetString("LONGITUDEMEASURE"));
                location.MonitoringLocationGeospatial.SourceMapScaleNumeric = readerEx.GetInt32("SOURCEMAPSCALE").ToString();
                location.MonitoringLocationGeospatial.HorizontalAccuracyMeasure =
                    GetNullMeasureCompactData(readerEx, "HORIZACCURACYMEASURE", "HORIZACCURACYMEASUREUNIT");
                location.MonitoringLocationGeospatial.HorizontalCollectionMethodName = readerEx.GetString("HORIZCOLLMETHOD");
                location.MonitoringLocationGeospatial.HorizontalCoordinateReferenceSystemDatumName = readerEx.GetString("HORIZCOORDREFSYSDATUM");
                location.MonitoringLocationGeospatial.VerticalMeasure =
                    GetNullMeasureCompactData(readerEx, "VERTICALMEASURE", "VERTICALMEASUREUNIT");
                location.MonitoringLocationGeospatial.VerticalCollectionMethodName = readerEx.GetNullString("VERTICALCOLLMETHOD");
                location.MonitoringLocationGeospatial.VerticalCoordinateReferenceSystemDatumName = readerEx.GetNullString("VERTICALCOORDREFSYSDATUM");
                location.MonitoringLocationGeospatial.CountryCode = readerEx.GetNullString("COUNTRYCODE");
                location.MonitoringLocationGeospatial.StateCode = readerEx.GetNullString("STATECODE");
                location.MonitoringLocationGeospatial.CountyCode = readerEx.GetNullString("COUNTYCODE");
            }
            if (!readerEx.IsDBNull("WELLTYPE"))
            {
                location.WellInformation = new WellInformationDataType();
                location.WellInformation.WellTypeText = readerEx.GetString("WELLTYPE");
                location.WellInformation.AquiferName = readerEx.GetNullString("AQUIFERNAME");
                location.WellInformation.FormationTypeText = readerEx.GetNullString("FORMATIONTYPE");
                location.WellInformation.WellHoleDepthMeasure =
                    GetNullMeasureCompactData(readerEx, "WELLHOLEDEPTHMEASURE", "WELLHOLEDEPTHMEASUREUNIT");
            }
            return location;

        }
        public static BiologicalHabitatIndexDataType MapBiologicalHabitatIndex(NamedNullMappingDataReader readerEx)
        {
            BiologicalHabitatIndexDataType habitat = new BiologicalHabitatIndexDataType();
            habitat.IndexIdentifier = readerEx.GetString("INDEXID");
            habitat.IndexType = new IndexTypeDataType();
            habitat.IndexType.IndexTypeIdentifier = readerEx.GetString("INDEXTYPEID");
            habitat.IndexType.IndexTypeIdentifierContext = readerEx.GetString("INDEXTYPEIDCONTEXT");
            habitat.IndexType.IndexTypeName = readerEx.GetString("INDEXTYPENAME");
            if (!readerEx.IsDBNull("RESOURCEID") || !readerEx.IsDBNull("RESOURCEDATE") || !readerEx.IsDBNull("RESOURCETITLE"))
            {
                habitat.IndexType.IndexTypeCitation = new BibliographicReferenceDataType();
                habitat.IndexType.IndexTypeCitation.ResourceTitleName = readerEx.GetString("RESOURCETITLE");
                habitat.IndexType.IndexTypeCitation.ResourceCreatorName = readerEx.GetNullString("RESOURCECREATOR");
                habitat.IndexType.IndexTypeCitation.ResourceSubjectText = readerEx.GetNullString("RESOURCESUBJECT");
                habitat.IndexType.IndexTypeCitation.ResourcePublisherName = readerEx.GetNullString("RESOURCEPUBLISHER");
                habitat.IndexType.IndexTypeCitation.ResourceDate = GetDateTimeByObject(readerEx, "RESOURCEDATE");
                habitat.IndexType.IndexTypeCitation.ResourceIdentifier = readerEx.GetString("RESOURCEID");
            }
            habitat.IndexType.IndexTypeScaleText = readerEx.GetNullString("INDEXTYPESCALE");
            habitat.IndexScoreNumeric = readerEx.GetString("INDEXSCORE");
            habitat.IndexQualifierCode = readerEx.GetNullString("INDEXQUALIFIERCODE");
            habitat.IndexCommentText = readerEx.GetNullString("INDEXCOMMENT");
            habitat.IndexCalculatedDateSpecified = !readerEx.IsDBNull("INDEXCALCULATEDDATE");
            if (habitat.IndexCalculatedDateSpecified)
            {
                habitat.IndexCalculatedDate = GetDateTimeByObject(readerEx, "INDEXCALCULATEDDATE");
            }
            habitat.MonitoringLocationIdentifier = readerEx.GetString("MONLOCID");
            return habitat;
        }
        public static AlternateMonitoringLocationIdentityDataType MapAlternateMonitoringLocationIdentity(NamedNullMappingDataReader readerEx)
        {
            AlternateMonitoringLocationIdentityDataType location = new AlternateMonitoringLocationIdentityDataType();
            location.MonitoringLocationIdentifier = readerEx.GetString("MONLOCID");
            location.MonitoringLocationIdentifierContext = readerEx.GetString("MONLOCIDCONTEXT");
            return location;
        }
        public static DetectionQuantitationLimitDataType MapDetectionQuantitationLimit(NamedNullMappingDataReader readerEx)
        {
            DetectionQuantitationLimitDataType detectionQuantitationLimit = new DetectionQuantitationLimitDataType();
            detectionQuantitationLimit.DetectionQuantitationLimitTypeName = readerEx.GetString("DETECTQUANTLIMITTYPE");
            detectionQuantitationLimit.DetectionQuantitationLimitMeasure =
                GetNullMeasureCompactData(readerEx, "DETECTQUANTLIMITMEASURE", "DETECTQUANTLIMITMEASUNITCODE");
            return detectionQuantitationLimit;
        }
        public static LabSamplePreparationDataType MapLabSamplePreparation(NamedNullMappingDataReader readerEx)
        {
            LabSamplePreparationDataType labSamplePreparation = new LabSamplePreparationDataType();
            if (!readerEx.IsDBNull("METHODID") || !readerEx.IsDBNull("METHODIDCONTEXT") || !readerEx.IsDBNull("METHODNAME"))
            {
                labSamplePreparation.LabSamplePreparationMethod = new ReferenceMethodDataType();
                labSamplePreparation.LabSamplePreparationMethod.MethodIdentifier = readerEx.GetString("METHODID");
                labSamplePreparation.LabSamplePreparationMethod.MethodIdentifierContext = readerEx.GetString("METHODIDCONTEXT");
                labSamplePreparation.LabSamplePreparationMethod.MethodName = readerEx.GetString("METHODNAME");
                labSamplePreparation.LabSamplePreparationMethod.MethodQualifierTypeName = readerEx.GetNullString("METHODQUALIFIERTYPE");
                labSamplePreparation.LabSamplePreparationMethod.MethodDescriptionText = readerEx.GetNullString("METHODDESC");
            }
            labSamplePreparation.PreparationStartDateSpecified = !readerEx.IsDBNull("PREPSTARTDATE");
            if (labSamplePreparation.PreparationStartDateSpecified)
            {
                labSamplePreparation.PreparationStartDate = readerEx.GetDateTime("PREPSTARTDATE");
            }
            labSamplePreparation.PreparationStartTime = GetNullTimeData(readerEx, "PREPSTARTTIME", "PREPSTARTTIMEZONECODE");
            labSamplePreparation.PreparationEndDateSpecified = !readerEx.IsDBNull("PREPENDDATE");
            if (labSamplePreparation.PreparationEndDateSpecified)
            {
                labSamplePreparation.PreparationEndDate = readerEx.GetDateTime("PREPENDDATE");
            }
            labSamplePreparation.PreparationEndTime = GetNullTimeData(readerEx, "PREPENDTIME", "PREPENDTIMEZONECODE");
            labSamplePreparation.SubstanceDilutionFactorNumeric = readerEx.GetNullString("SUBSTANCEDILUTIONFACTOR");
            return labSamplePreparation;
        }
        public static T[] ToArray<T>(List<T> list)
        {
            return (list != null) ? list.ToArray() : null;
        }
        public static bool ToBool(string value)
        {
            return string.IsNullOrEmpty(value) ? false : ((value == "Y") || (value == "y"));
        }
        public static decimal ToDecimal(string value)
        {
            return string.IsNullOrEmpty(value) ? 0 : decimal.Parse(value);
        }
        public static string ToDateString(bool isOracle, DateTime value)
        {
            return isOracle ? value.ToString("dd-MMM-yyyy") : value.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static WQXTimeDataType GetNullTimeData(NamedNullMappingDataReader readerEx, string timeName,
                                                       string zoneName)
        {
            if (!readerEx.IsDBNull(timeName))
            {
                WQXTimeDataType data = new WQXTimeDataType();
//                data.Time = readerEx.GetDateTime(timeName);
                data.Time = readerEx.GetString(timeName);
                data.TimeZoneCode = readerEx.GetString(zoneName);
                return data;
            }
            else
            {
                return null;
            }
        }
        public static MeasureCompactDataType GetNullMeasureCompactData(NamedNullMappingDataReader readerEx, string valueName,
                                                                       string codeName)
        {
            if (!readerEx.IsDBNull(valueName))
            {
                MeasureCompactDataType data = new MeasureCompactDataType();
                data = new MeasureCompactDataType();
                data.MeasureValue = readerEx.GetString(valueName);
                data.MeasureUnitCode = readerEx.GetString(codeName);
                return data;
            }
            else
            {
                return null;
            }
        }
        public void SaveAttachedBinaryContent(string name, byte[] content)
        {
            if (!CollectionUtils.IsNullOrEmpty(content))
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("An attached binary object did not have a name.");
                }
                if (!Directory.Exists(_attachedBinaryObjectFolder))
                {
                    Directory.CreateDirectory(_attachedBinaryObjectFolder);
                }
                string filePath = Path.Combine(_attachedBinaryObjectFolder, name);
                if ( File.Exists(filePath) )
                {
                    throw new ArgumentException(string.Format("A duplicate name was found for an attached binary object: \"{0}\"",
                                                              name));
                }
                File.WriteAllBytes(filePath, content);
                ++_attachedBinaryFileCount;
            }
        }
    }
}
