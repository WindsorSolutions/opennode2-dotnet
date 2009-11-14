using System.Xml.Serialization;
using System.Data;
using System;
using System.Collections.Generic;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.Core;
using System.ComponentModel;
using System.IO;
using Windsor.Commons.Spring;
using Windsor.Node2008.WNOSProviders;

namespace Windsor.Node2008.WNOSPlugin.CERS_12
{
    public enum DataCategory
    {
        [Description("FacilityInventory")]
        FacilityInventory,
        [Description("Point")]
        Point,
        [Description("Nonpoint")]
        Nonpoint,
        [Description("Onroad")]
        Onroad,
        [Description("Nonroad")]
        Nonroad,
        [Description("Event")]
        Event,
        [Description("OnroadNonroadActivity")]
        OnroadNonroadActivity
    }
    public class BaseTableClass
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string _FK;
    }

    [DefaultTableNamePrefixAttribute("CERS")]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [NamePostfixAppliedAttribute("Year", typeof(ColumnAttribute), DbType.Int32)]

    [AppliedAttribute(typeof(CERSDataType), "EmissionsYear", typeof(ColumnAttribute), DbType.Int32, false)]
    [AppliedAttribute(typeof(CERSDataType), "EmissionsYear", typeof(DbIndexableAttribute))]

    public partial class CERSDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [Column("DATA_CATEGORY", false)]
        [DbIndexable]
        public DataCategory DataCategory;

        public delegate void AttachedFileAction(AttachedFileDataType attachedFile);

        public IList<string> GetAttachmentFileNames()
        {
            List<string> fileNames = null;
            ForEachAttachedFile(delegate(AttachedFileDataType attachedFile)
            {
                CollectionUtils.Add(attachedFile.AttachmentFileName, ref fileNames);
            });
            return fileNames;
        }
        public int AddAttachmentsToZipFile(string zipFilePath, string attachmentParentFolderPath,
                                           SpringBaseDao baseDao, ICompressionHelper compressionHelper)
        {
            int numAdded = 0;
            ForEachAttachedFile(delegate(AttachedFileDataType attachedFile)
            {
                // TODO: blob handling not completed yet
                string filePath = Path.Combine(attachmentParentFolderPath, attachedFile.AttachmentFileName);
                if (!File.Exists(filePath))
                {
                    throw new InvalidOperationException(string.Format("Attached file \"{0}\" could not be found for element: {1}",
                                                                      filePath, ReflectionUtils.GetPublicPropertiesString(attachedFile)));
                }
                compressionHelper.CompressFile(filePath, zipFilePath);
            });
            return numAdded;
        }

        protected void ValidateAttachedFile(AttachedFileDataType attachedFile)
        {
            if (string.IsNullOrEmpty(attachedFile.AttachmentFileName))
            {
                throw new InvalidOperationException(string.Format("AttachedFileDataType.AttachmentFileName is empty for element: {0}",
                                                                  ReflectionUtils.GetPublicPropertiesString(attachedFile)));
            }
        }
        protected void ForEachAttachedFile(AttachedFileAction action)
        {
            CollectionUtils.ForEach(FacilitySite,
                delegate(FacilitySiteDataType facility)
                {
                    if (facility.FacilitySiteAttachedFile != null)
                    {
                        ValidateAttachedFile(facility.FacilitySiteAttachedFile);
                        action(facility.FacilitySiteAttachedFile);
                    }
                    CollectionUtils.ForEach(facility.FacilitySiteAffiliation,
                        delegate(AffiliationDataType affiliation)
                        {
                            CollectionUtils.ForEach(affiliation.AffiliationOrganization,
                                delegate(AffiliationOrganizationDataType affiliationOrganization)
                                {
                                    if (affiliationOrganization.OrganizationAttachedFile != null)
                                    {
                                        ValidateAttachedFile(facility.FacilitySiteAttachedFile);
                                        action(facility.FacilitySiteAttachedFile);
                                    }
                                });
                        });
                });
            CollectionUtils.ForEach(Event,
                delegate(EventDataType eventObj)
                {
                    if (eventObj.EventAttachedFile != null)
                    {
                        ValidateAttachedFile(eventObj.EventAttachedFile);
                        action(eventObj.EventAttachedFile);
                    }
                });
            CollectionUtils.ForEach(QualityFinding,
                delegate(QualityFindingDataType qualityFinding)
                {
                    if (qualityFinding.QualityFindingAttachedFile != null)
                    {
                        ValidateAttachedFile(qualityFinding.QualityFindingAttachedFile);
                        action(qualityFinding.QualityFindingAttachedFile);
                    }
                    CollectionUtils.ForEach(qualityFinding.QualityFindingOrganization,
                        delegate(QualityFindingOrganizationDataType qualityFindingOrganization)
                        {
                            if (qualityFindingOrganization.OrganizationAttachedFile != null)
                            {
                                ValidateAttachedFile(qualityFindingOrganization.OrganizationAttachedFile);
                                action(qualityFindingOrganization.OrganizationAttachedFile);
                            }
                        });
                });
        }
    }
    public partial class AttachedFileDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [System.ComponentModel.DescriptionAttribute("The data content of a file.")]
        [DbNoLoad]
        public byte[] AttachmentFileContent;
    }

    public partial class LocationDataType : BaseTableClass
    {
        [System.Xml.Serialization.XmlIgnore]
        public AttachedFileDataType LocationAttachedFile;
    }
    public partial class FacilitySiteDataType : BaseTableClass { }
    public partial class EventDataType : BaseTableClass { }
    public partial class QualityFindingDataType : BaseTableClass { }
    public partial class MergedEventsDataType : BaseTableClass { }
    public partial class EventReportingPeriodDataType : BaseTableClass { }
    public partial class EventLocationDataType : BaseTableClass { }
    public partial class GeospatialParametersDataType : BaseTableClass { }
    public partial class EventEmissionsProcessDataType : BaseTableClass { }
    public partial class EmissionsDataType : BaseTableClass { }
    public class EventEmissionsEmissionsDataType : EmissionsDataType { }
    public class EmissionsUnitProcessReportingPeriodEmissionsDataType : EmissionsDataType { }
    public class LocationProcessReportingPeriodEmissionsDataType : EmissionsDataType { }
    public partial class ExcludedLocationParameterDataType : BaseTableClass { }
    public partial class IdentificationDataType : BaseTableClass { }
    public class EmissionsUnitProcessReleasePointApportionmentIdentificationDataType : IdentificationDataType { }
    public class LocationProcessReleasePointApportionmentIdentificationDataType : IdentificationDataType { }
    public class EmissionsUnitProcessIdentificationDataType : IdentificationDataType { }
    public class LocationProcessIdentificationDataType : IdentificationDataType { }
    public class EmissionsUnitIdentificationDataType : IdentificationDataType { }
    public class ReleasePointIdentificationDataType : IdentificationDataType { }
    public class QualityFindingOrganizationIndividualIdentificationDataType : IdentificationDataType { }
    public class AffiliationOrganizationIndividualIdentificationDataType : IdentificationDataType { }
    public class AffiliationIndividualIdentificationDataType : IdentificationDataType { }
    public class QualityFindingOrganizationIdentificationDataType : IdentificationDataType { }
    public class AffiliationOrganizationIdentificationDataType : IdentificationDataType { }
    public partial class RegulationDataType : BaseTableClass { }
    public class EmissionsUnitProcessRegulationDataType : RegulationDataType { }
    public class LocationProcessRegulationDataType : RegulationDataType { }
    public class EmissionsUnitRegulationDataType : RegulationDataType { }
    public partial class FacilityNAICSDataType : BaseTableClass { }
    public partial class FacilityIdentificationDataType : BaseTableClass { }
    public partial class AlternativeFacilityNameDataType : BaseTableClass { }
    public partial class AddressDataType : BaseTableClass { }
    public class QualityFindingOrganizationIndividualAddressDataType : AddressDataType { }
    public class AffiliationOrganizationIndividualAddressDataType : AddressDataType { }
    public class AffiliationIndividualAddressDataType : AddressDataType { }
    public class QualityFindingOrganizationAddressDataType : AddressDataType { }
    public class AffiliationOrganizationAddressDataType : AddressDataType { }
    public class FacilitySiteAddressDataType : AddressDataType { }
    public partial class QualityIdentificationDataType : BaseTableClass { }
    public class EmissionsUnitProcessReportingPeriodQualityIdentificationDataType : QualityIdentificationDataType { }
    public class LocationProcessReportingPeriodQualityIdentificationDataType : QualityIdentificationDataType { }
    public class EmissionsUnitQualityIdentificationDataType : QualityIdentificationDataType { }
    public class FacilitySiteQualityIdentificationDataType : QualityIdentificationDataType { }
    public partial class AffiliationDataType : BaseTableClass { }
    public partial class EmissionsUnitDataType : BaseTableClass { }
    public partial class ReleasePointDataType : BaseTableClass { }
    public partial class CommunicationDataType : BaseTableClass { }
    public class QualityFindingOrganizationIndividualCommunicationDataType : CommunicationDataType { }
    public class AffiliationOrganizationCommunicationDataType : CommunicationDataType { }
    public class AffiliationIndividualCommunicationDataType : CommunicationDataType { }
    public class QualityFindingOrganizationCommunicationDataType : CommunicationDataType { }
    public class AffiliationOrganizationIndividualCommunicationDataType : CommunicationDataType { }
    public partial class ControlPollutantDataType : BaseTableClass { }
    public class EmissionsUnitProcessControlApproachControlPollutantDataType : ControlPollutantDataType { }
    public class LocationProcessControlApproachControlPollutantDataType : ControlPollutantDataType { }
    public class EmissionsUnitControlApproachControlPollutantDataType : ControlPollutantDataType { }
    public partial class ControlMeasureDataType : BaseTableClass { }
    public class EmissionsUnitProcessControlApproachControlMeasureDataType : ControlMeasureDataType { }
    public class LocationProcessControlApproachControlMeasureDataType : ControlMeasureDataType { }
    public class EmissionsUnitControlApproachControlMeasureDataType : ControlMeasureDataType { }
    public partial class SupplementalCalculationParameterDataType : BaseTableClass { }
    public class LocationProcessReportingPeriodSupplementalCalculationParameterDataType : SupplementalCalculationParameterDataType { }
    public class EmissionsUnitProcessReportingPeriodSupplementalCalculationParameterDataType : SupplementalCalculationParameterDataType { }
    public partial class ReleasePointTestDataType : BaseTableClass { }


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("AffiliationOrganization", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class QualityFindingOrganizationDataType : BaseTableClass // OrganizationDataType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of the organization.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string OrganizationFormalName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Contains information on the percentage of ownership an organization has for a fac" +
            "ility site.")]
        public decimal PercentOwnership;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentOwnershipSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Consolidation methodology for an organization, including:  operation control, fin" +
            "ancial control, operation control and equity share, financial control and equity" +
            " share, equity share.")]
        public string ConsolidationMethodology;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrganizationIdentification", Order = 3)]
        // TSM:
        // public IdentificationDataType[] OrganizationIdentification;
        public QualityFindingOrganizationIdentificationDataType[] OrganizationIdentification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrganizationAddress", Order = 4)]
        // TSM:
        // public AddressDataType[] OrganizationAddress;
        public QualityFindingOrganizationAddressDataType[] OrganizationAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrganizationCommunication", Order = 5)]
        // TSM:
        // public CommunicationDataType[] OrganizationCommunication;
        public QualityFindingOrganizationCommunicationDataType[] OrganizationCommunication;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrganizationIndividual", Order = 6)]
        // TSM:
        // public IndividualDataType[] OrganizationIndividual;
        public QualityFindingOrganizationIndividualDataType[] OrganizationIndividual;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public AttachedFileDataType OrganizationAttachedFile;
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("AffiliationOrganization", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class AffiliationOrganizationDataType : BaseTableClass // OrganizationDataType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Name of the organization.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string OrganizationFormalName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Contains information on the percentage of ownership an organization has for a fac" +
            "ility site.")]
        public decimal PercentOwnership;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentOwnershipSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Consolidation methodology for an organization, including:  operation control, fin" +
            "ancial control, operation control and equity share, financial control and equity" +
            " share, equity share.")]
        public string ConsolidationMethodology;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrganizationIdentification", Order = 3)]
        // TSM:
        // public IdentificationDataType[] OrganizationIdentification;
        public AffiliationOrganizationIdentificationDataType[] OrganizationIdentification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrganizationAddress", Order = 4)]
        // TSM:
        // public AddressDataType[] OrganizationAddress;
        public AffiliationOrganizationAddressDataType[] OrganizationAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrganizationCommunication", Order = 5)]
        // TSM:
        // public CommunicationDataType[] OrganizationCommunication;
        public AffiliationOrganizationCommunicationDataType[] OrganizationCommunication;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OrganizationIndividual", Order = 6)]
        // TSM:
        // public IndividualDataType[] OrganizationIndividual;
        public AffiliationOrganizationIndividualDataType[] OrganizationIndividual;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public AttachedFileDataType OrganizationAttachedFile;
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("AffiliationIndividual", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public class QualityFindingOrganizationIndividualDataType : BaseTableClass // IndividualDataType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The title held by a person in an organization.")]
        public string IndividualTitleText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The text that precedes an individual\'s name.")]
        public string NamePrefixText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The given name of an individual.")]
        public string FirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The middle name or initial of an individual.")]
        public string MiddleName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The surname of an individual.")]
        public string LastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("the text that follows an individuals name.")]
        public string NameSuffixText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IndividualIdentification", Order = 6)]
        // TSM:
        // public IdentificationDataType[] IndividualIdentification;
        public QualityFindingOrganizationIndividualIdentificationDataType[] IndividualIdentification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IndividualAddress", Order = 7)]
        // TSM:
        // public AddressDataType[] IndividualAddress;
        public QualityFindingOrganizationIndividualAddressDataType[] IndividualAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IndividualCommunication", Order = 8)]
        // TSM:
        // public CommunicationDataType[] IndividualCommunication;
        public QualityFindingOrganizationIndividualCommunicationDataType[] IndividualCommunication;
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("AffiliationIndividual", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public class AffiliationOrganizationIndividualDataType : BaseTableClass // IndividualDataType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The title held by a person in an organization.")]
        public string IndividualTitleText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The text that precedes an individual\'s name.")]
        public string NamePrefixText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The given name of an individual.")]
        public string FirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The middle name or initial of an individual.")]
        public string MiddleName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The surname of an individual.")]
        public string LastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("the text that follows an individuals name.")]
        public string NameSuffixText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IndividualIdentification", Order = 6)]
        // TSM:
        // public IdentificationDataType[] IndividualIdentification;
        public AffiliationOrganizationIndividualIdentificationDataType[] IndividualIdentification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IndividualAddress", Order = 7)]
        // TSM:
        // public AddressDataType[] IndividualAddress;
        public AffiliationOrganizationIndividualAddressDataType[] IndividualAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IndividualCommunication", Order = 8)]
        // TSM:
        // public CommunicationDataType[] IndividualCommunication;
        public AffiliationOrganizationIndividualCommunicationDataType[] IndividualCommunication;
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("AffiliationIndividual", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public class AffiliationIndividualDataType : BaseTableClass // IndividualDataType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The title held by a person in an organization.")]
        public string IndividualTitleText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The text that precedes an individual\'s name.")]
        public string NamePrefixText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The given name of an individual.")]
        public string FirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The middle name or initial of an individual.")]
        public string MiddleName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The surname of an individual.")]
        public string LastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("the text that follows an individuals name.")]
        public string NameSuffixText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IndividualIdentification", Order = 6)]
        // TSM:
        // public IdentificationDataType[] IndividualIdentification;
        public AffiliationIndividualIdentificationDataType[] IndividualIdentification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IndividualAddress", Order = 7)]
        // TSM:
        // public AddressDataType[] IndividualAddress;
        public AffiliationIndividualAddressDataType[] IndividualAddress;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IndividualCommunication", Order = 8)]
        // TSM:
        // public CommunicationDataType[] IndividualCommunication;
        public AffiliationIndividualCommunicationDataType[] IndividualCommunication;
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("ProcessControlApproach", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class LocationProcessControlApproachDataType // ControlApproachDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Description of the overall control system or approach applied to an emissions uni" +
            "t or process.")]
        public string ControlApproachDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("An estimate of that portion of an affected emission stream that is collected and " +
            "routed to the control measures when the capture or collection system is operatin" +
            "g as designed, reported as a percent.")]
        public decimal PercentControlApproachCaptureEfficiency;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentControlApproachCaptureEfficiencySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute(@"An estimate of the portion of the reporting period's activity for which the overall control system or approach (including both capture and control measures) were operating as designed (regardless of whether the control measure is due to rule or voluntary).")]
        public decimal PercentControlApproachEffectiveness;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentControlApproachEffectivenessSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("An estimate of the percent value of the nonpoint activity throughput that is affe" +
            "cted by a rule or voluntary approach for the given location.  (Nonpoint only.)")]
        public decimal PercentControlApproachPenetration;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentControlApproachPenetrationSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The inventory year for which the controls were implemented.  (Point only.)")]
        public string FirstInventoryYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The last inventory year for which the controls were active.  (Point only.)")]
        public string LastInventoryYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Comments regarding the control approach.")]
        public string ControlApproachComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ControlMeasure", Order = 7)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        // public ControlMeasureDataType[] ControlMeasure;
        public LocationProcessControlApproachControlMeasureDataType[] ControlMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ControlPollutant", Order = 8)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        // public ControlPollutantDataType[] ControlPollutant;
        public LocationProcessControlApproachControlPollutantDataType[] ControlPollutant;
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("ProcessControlApproach", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class EmissionsUnitControlApproachDataType // ControlApproachDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Description of the overall control system or approach applied to an emissions uni" +
            "t or process.")]
        public string ControlApproachDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("An estimate of that portion of an affected emission stream that is collected and " +
            "routed to the control measures when the capture or collection system is operatin" +
            "g as designed, reported as a percent.")]
        public decimal PercentControlApproachCaptureEfficiency;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentControlApproachCaptureEfficiencySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute(@"An estimate of the portion of the reporting period's activity for which the overall control system or approach (including both capture and control measures) were operating as designed (regardless of whether the control measure is due to rule or voluntary).")]
        public decimal PercentControlApproachEffectiveness;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentControlApproachEffectivenessSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("An estimate of the percent value of the nonpoint activity throughput that is affe" +
            "cted by a rule or voluntary approach for the given location.  (Nonpoint only.)")]
        public decimal PercentControlApproachPenetration;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentControlApproachPenetrationSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The inventory year for which the controls were implemented.  (Point only.)")]
        public string FirstInventoryYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The last inventory year for which the controls were active.  (Point only.)")]
        public string LastInventoryYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Comments regarding the control approach.")]
        public string ControlApproachComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ControlMeasure", Order = 7)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        // public ControlMeasureDataType[] ControlMeasure;
        public EmissionsUnitControlApproachControlMeasureDataType[] ControlMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ControlPollutant", Order = 8)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        // public ControlPollutantDataType[] ControlPollutant;
        public EmissionsUnitControlApproachControlPollutantDataType[] ControlPollutant;
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("ProcessControlApproach", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class EmissionsUnitProcessControlApproachDataType // ControlApproachDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Description of the overall control system or approach applied to an emissions uni" +
            "t or process.")]
        public string ControlApproachDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("An estimate of that portion of an affected emission stream that is collected and " +
            "routed to the control measures when the capture or collection system is operatin" +
            "g as designed, reported as a percent.")]
        public decimal PercentControlApproachCaptureEfficiency;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentControlApproachCaptureEfficiencySpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute(@"An estimate of the portion of the reporting period's activity for which the overall control system or approach (including both capture and control measures) were operating as designed (regardless of whether the control measure is due to rule or voluntary).")]
        public decimal PercentControlApproachEffectiveness;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentControlApproachEffectivenessSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("An estimate of the percent value of the nonpoint activity throughput that is affe" +
            "cted by a rule or voluntary approach for the given location.  (Nonpoint only.)")]
        public decimal PercentControlApproachPenetration;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PercentControlApproachPenetrationSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The inventory year for which the controls were implemented.  (Point only.)")]
        public string FirstInventoryYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The last inventory year for which the controls were active.  (Point only.)")]
        public string LastInventoryYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Comments regarding the control approach.")]
        public string ControlApproachComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ControlMeasure", Order = 7)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        // public ControlMeasureDataType[] ControlMeasure;
        public EmissionsUnitProcessControlApproachControlMeasureDataType[] ControlMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ControlPollutant", Order = 8)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        // public ControlPollutantDataType[] ControlPollutant;
        public EmissionsUnitProcessControlApproachControlPollutantDataType[] ControlPollutant;
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("ReleasePointApportionment", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class LocationProcessReleasePointApportionmentDataType : BaseTableClass // ReleasePointApportionmentDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The average annual percent of an emissions process that is vented through a relea" +
            "se point.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public decimal AveragePercentEmissions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Comment regarding the average apportionment of emissions vented through a release" +
            " point.")]
        public string ReleasePointApportionmentComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReleasePointApportionmentIdentification", Order = 2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        // public IdentificationDataType[] ReleasePointApportionmentIdentification;
        public LocationProcessReleasePointApportionmentIdentificationDataType[] ReleasePointApportionmentIdentification;
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("ReleasePointApportionment", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class EmissionsUnitProcessReleasePointApportionmentDataType : BaseTableClass // ReleasePointApportionmentDataType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The average annual percent of an emissions process that is vented through a relea" +
            "se point.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public decimal AveragePercentEmissions;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Comment regarding the average apportionment of emissions vented through a release" +
            " point.")]
        public string ReleasePointApportionmentComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReleasePointApportionmentIdentification", Order = 2)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        // public IdentificationDataType[] ReleasePointApportionmentIdentification;
        public EmissionsUnitProcessReleasePointApportionmentIdentificationDataType[] ReleasePointApportionmentIdentification;
    }


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("LocationEmissionsProcess", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class EmissionsUnitProcessDataType : BaseTableClass // ProcessDataType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("EPA Source Classification Code that identifies an emissions process.")]
        public string SourceClassificationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Defines the type of emissions produced by Onroad and Nonroad sources. Used for Mo" +
            "bile sources only. Examples include exhaust, evaporative and tire wear.")]
        public string EmissionsTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identifies the combination of aircraft and engine type for airport emissions.")]
        public string AircraftEngineTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Defines the type of emissions produced by GHG processes. Examples included for a " +
            "Scope 1 Stationary Combustion might be oil, gas, coal.")]
        public string ProcessTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("A text description of the emissions process.")]
        public string ProcessDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The last year in which emissions occurred for this process.")]
        public string LastEmissionsYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Any comments regarding the emissions process.")]
        public string ProcessComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProcessIdentification", Order = 7)]
        // TSM:
        // public IdentificationDataType[] ProcessIdentification;
        public EmissionsUnitProcessIdentificationDataType[] ProcessIdentification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProcessRegulation", Order = 8)]
        // TSM:
        // public RegulationDataType[] ProcessRegulation;
        public EmissionsUnitProcessRegulationDataType[] ProcessRegulation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        // TSM:
        // public ControlApproachDataType ProcessControlApproach;
        public EmissionsUnitProcessControlApproachDataType ProcessControlApproach;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportingPeriod", Order = 10)]
        // TSM:
        // public ReportingPeriodDataType[] ReportingPeriod;
        public EmissionsUnitProcessReportingPeriodDataType[] ReportingPeriod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReleasePointApportionment", Order = 11)]
        // TSM:
        // public ReleasePointApportionmentDataType[] ReleasePointApportionment;
        public EmissionsUnitProcessReleasePointApportionmentDataType[] ReleasePointApportionment;
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("LocationEmissionsProcess", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class LocationProcessDataType : BaseTableClass // ProcessDataType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("EPA Source Classification Code that identifies an emissions process.")]
        public string SourceClassificationCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Defines the type of emissions produced by Onroad and Nonroad sources. Used for Mo" +
            "bile sources only. Examples include exhaust, evaporative and tire wear.")]
        public string EmissionsTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("Identifies the combination of aircraft and engine type for airport emissions.")]
        public string AircraftEngineTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Defines the type of emissions produced by GHG processes. Examples included for a " +
            "Scope 1 Stationary Combustion might be oil, gas, coal.")]
        public string ProcessTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("A text description of the emissions process.")]
        public string ProcessDescription;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The last year in which emissions occurred for this process.")]
        public string LastEmissionsYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Any comments regarding the emissions process.")]
        public string ProcessComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProcessIdentification", Order = 7)]
        // TSM:
        // public IdentificationDataType[] ProcessIdentification;
        public LocationProcessIdentificationDataType[] ProcessIdentification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProcessRegulation", Order = 8)]
        // TSM:
        // public RegulationDataType[] ProcessRegulation;
        public LocationProcessRegulationDataType[] ProcessRegulation;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        // TSM:
        // public ControlApproachDataType ProcessControlApproach;
        public LocationProcessControlApproachDataType ProcessControlApproach;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportingPeriod", Order = 10)]
        // TSM:
        // public ReportingPeriodDataType[] ReportingPeriod;
        public LocationProcessReportingPeriodDataType[] ReportingPeriod;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReleasePointApportionment", Order = 11)]
        // TSM:
        // public ReleasePointApportionmentDataType[] ReleasePointApportionment;
        public LocationProcessReleasePointApportionmentDataType[] ReleasePointApportionment;
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("ReportingPeriod", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class EmissionsUnitProcessReportingPeriodDataType : BaseTableClass // ReportingPeriodDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The time period type for which emissions are reported.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ReportingPeriodTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code identifying the operating state for the emissions being reported.")]
        public string EmissionOperatingTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The date on which the reporting period began.  Applies to the reporting of episod" +
            "ic or event emissions only.")]
        public System.DateTime StartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The date on which the identifier is no longer applicable.")]
        public System.DateTime EndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code indicating whether the material measured is an input to the process, an outp" +
            "ut of the process or a static count (not a throughput). ")]
        public string CalculationParameterTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Activity or throughput of the process for a given time period.")]
        public string CalculationParameterValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Code for the unit of measure for calculation parameter value.")]
        public string CalculationParameterUnitofMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Code for material or fuel processed.")]
        public string CalculationMaterialCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The actual year represented by the data if it is different from the emissions yea" +
            "r.")]
        public string CalculationDataYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The source of the data used.")]
        public string CalculationDataSource;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Any comments regarding the reporting period.")]
        public string ReportingPeriodComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportingPeriodQualityIdentification", Order = 11)]
        // TSM:
        // public QualityIdentificationDataType[] ReportingPeriodQualityIdentification;
        public EmissionsUnitProcessReportingPeriodQualityIdentificationDataType[] ReportingPeriodQualityIdentification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public OperatingDetailsDataType OperatingDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SupplementalCalculationParameter", Order = 13)]
        // TSM:
        // public SupplementalCalculationParameterDataType[] SupplementalCalculationParameter;
        public EmissionsUnitProcessReportingPeriodSupplementalCalculationParameterDataType[] SupplementalCalculationParameter;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportingPeriodEmissions", Order = 14)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        // public EmissionsDataType[] ReportingPeriodEmissions;
        public EmissionsUnitProcessReportingPeriodEmissionsDataType[] ReportingPeriodEmissions;
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/cer/1")]
    [System.Xml.Serialization.XmlRootAttribute("ReportingPeriod", Namespace = "http://www.exchangenetwork.net/schema/cer/1", IsNullable = false)]
    public partial class LocationProcessReportingPeriodDataType : BaseTableClass // ReportingPeriodDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The time period type for which emissions are reported.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string ReportingPeriodTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Code identifying the operating state for the emissions being reported.")]
        public string EmissionOperatingTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The date on which the reporting period began.  Applies to the reporting of episod" +
            "ic or event emissions only.")]
        public System.DateTime StartDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StartDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The date on which the identifier is no longer applicable.")]
        public System.DateTime EndDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EndDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Code indicating whether the material measured is an input to the process, an outp" +
            "ut of the process or a static count (not a throughput). ")]
        public string CalculationParameterTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Activity or throughput of the process for a given time period.")]
        public string CalculationParameterValue;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("Code for the unit of measure for calculation parameter value.")]
        public string CalculationParameterUnitofMeasure;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("Code for material or fuel processed.")]
        public string CalculationMaterialCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "gYear", Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The actual year represented by the data if it is different from the emissions yea" +
            "r.")]
        public string CalculationDataYear;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The source of the data used.")]
        public string CalculationDataSource;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Any comments regarding the reporting period.")]
        public string ReportingPeriodComment;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportingPeriodQualityIdentification", Order = 11)]
        // TSM:
        // public QualityIdentificationDataType[] ReportingPeriodQualityIdentification;
        public LocationProcessReportingPeriodQualityIdentificationDataType[] ReportingPeriodQualityIdentification;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        public OperatingDetailsDataType OperatingDetails;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SupplementalCalculationParameter", Order = 13)]
        // TSM:
        // public SupplementalCalculationParameterDataType[] SupplementalCalculationParameter;
        public LocationProcessReportingPeriodSupplementalCalculationParameterDataType[] SupplementalCalculationParameter;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReportingPeriodEmissions", Order = 14)]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        // TSM:
        // public EmissionsDataType[] ReportingPeriodEmissions;
        public LocationProcessReportingPeriodEmissionsDataType[] ReportingPeriodEmissions;
    }
}
