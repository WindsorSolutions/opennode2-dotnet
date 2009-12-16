using System.Xml.Serialization;
using System.Data;
using System;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOSPlugin.ICISNPDES_15
{
    public class BaseTableClass
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string _FK;
    }

    [DefaultTableNamePrefixAttribute("ICIS")]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [FixShortenNameBreakBugAttribute]
    [AdditionalAbbreviationsAttribute("REPORT", "RPT",
                                      "DISCHARGE", "DISCHRG")]

    [AppliedAttribute(typeof(LandApplicationSite), "CropTypesPlanted", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(LandApplicationSite), "CropTypesHarvested", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(HeaderData), "Id", typeof(DbIndexableAttribute))]

    [AppliedAttribute(typeof(HeaderData), "Id", typeof(ColumnAttribute), 30, false)]

    [AppliedAttribute(typeof(DischargeMonitoringReport), "PermitIdentifier", typeof(ColumnAttribute), 9)]
    [AppliedAttribute(typeof(DischargeMonitoringReport), "PermittedFeatureIdentifier", typeof(ColumnAttribute), 4)]
    [AppliedAttribute(typeof(DischargeMonitoringReport), "LimitSetDesignator", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(DischargeMonitoringReport), "PrincipalExecutiveOfficerFirstName", typeof(ColumnAttribute), 30)]
    [AppliedAttribute(typeof(DischargeMonitoringReport), "PrincipalExecutiveOfficerLastName", typeof(ColumnAttribute), 30)]
    [AppliedAttribute(typeof(DischargeMonitoringReport), "PrincipalExecutiveOfficerTitle", typeof(ColumnAttribute), 40)]
    [AppliedAttribute(typeof(DischargeMonitoringReport), "PrincipalExecutiveOfficerTelephone", typeof(ColumnAttribute), 10)]
    [AppliedAttribute(typeof(DischargeMonitoringReport), "SignatoryFirstName", typeof(ColumnAttribute), 30)]
    [AppliedAttribute(typeof(DischargeMonitoringReport), "SignatoryLastName", typeof(ColumnAttribute), 30)]
    [AppliedAttribute(typeof(DischargeMonitoringReport), "SignatoryTelephone", typeof(ColumnAttribute), 10)]
    
    [AppliedAttribute(typeof(LandApplicationSite), "PollutantMetForLandApplication", typeof(ColumnAttribute), 10)]
    [AppliedAttribute(typeof(LandApplicationSite), "PathogenReductionIndicator", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(LandApplicationSite), "VectorReductionIndicator", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(LandApplicationSite), "AgronomicGallonsRateForField", typeof(ColumnAttribute), 5)]
    [AppliedAttribute(typeof(LandApplicationSite), "AgronomicDMTRateForField", typeof(ColumnAttribute), 5)]
    [AppliedAttribute(typeof(LandApplicationSite), "ClassAAlternativeUsed", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(LandApplicationSite), "ClassBAlternativeUsed", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(LandApplicationSite), "VARAlternativeUsed", typeof(ColumnAttribute), 3)]

    [AppliedAttribute(typeof(SurfaceDisposalSite), "PathogenReductionIndicator", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(SurfaceDisposalSite), "VectorReductionIndicator", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(SurfaceDisposalSite), "ManagementPracticesIndicator", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(SurfaceDisposalSite), "CertificationStatementIndicator", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(SurfaceDisposalSite), "CertifierFirstName", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(SurfaceDisposalSite), "CertifierLastName", typeof(ColumnAttribute), 1)]
    [AppliedAttribute(typeof(SurfaceDisposalSite), "ClassAAlternativeUsed", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(SurfaceDisposalSite), "ClassBAlternativeUsed", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(SurfaceDisposalSite), "VARAlternativeUsed", typeof(ColumnAttribute), 3)]

    [AppliedAttribute(typeof(ReportParameter), "ParameterCode", typeof(ColumnAttribute), 5)]
    [AppliedAttribute(typeof(ReportParameter), "MonitoringSiteDescriptionCode", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(ReportParameter), "LimitSeasonNumber", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(ReportParameter), "ReportSampleTypeText", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(ReportParameter), "ReportingFrequencyCode", typeof(ColumnAttribute), 5)]
    [AppliedAttribute(typeof(ReportParameter), "ReportNumberOfExcursions", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(ReportParameter), "ConcentrationNumericReportUnitMeasureCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(ReportParameter), "QuantityNumericReportUnitMeasureCode", typeof(ColumnAttribute), 2)]

    [AppliedAttribute(typeof(NumericReport), "NumericReportCode", typeof(ColumnAttribute), 2)]
    [AppliedAttribute(typeof(NumericReport), "NumericReportNoDischargeIndicator", typeof(ColumnAttribute), 3)]
    [AppliedAttribute(typeof(NumericReport), "NumericConditionQualifier", typeof(ColumnAttribute), 3)]

    public partial class Document : IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;
        
        public void BeforeSaveToDatabase()
        {
            DateTime now = DateTime.Now;
            CollectionUtils.ForEach(Payload, delegate(PayloadData data)
            {
                data.LastPayloadUpdateDate = now;
                data.BeforeSaveToDatabase();
            });
        }
        public void AfterLoadFromDatabase()
        {
            CollectionUtils.ForEach(Payload, delegate(PayloadData data)
            {
                data.AfterLoadFromDatabase();
            });
        }
    }

    public partial class PayloadData : BaseTableClass, IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        [System.Xml.Serialization.XmlIgnore]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute]
        [Windsor.Commons.XsdOrm.DbIndexableAttribute]
        [System.ComponentModel.DescriptionAttribute("The date and time that this payload was last updated for submission.")]
        public DateTime LastPayloadUpdateDate;

        public void BeforeSaveToDatabase()
        {
            CollectionUtils.ForEach(DischargeMonitoringReportData, delegate(DischargeMonitoringReportData data)
            {
                data.BeforeSaveToDatabase();
            });
        }
        public void AfterLoadFromDatabase()
        {
            CollectionUtils.ForEach(DischargeMonitoringReportData, delegate(DischargeMonitoringReportData data)
            {
                data.AfterLoadFromDatabase();
            });
        }
    }
    [Table("ICIS_HEADER_PROPERTY")]
    public partial class Property : BaseTableClass { }
    [Table("ICIS_NUMERIC_REPORT")]
    public partial class NumericReport : BaseTableClass { }
    public partial class DischargeMonitoringReportData : BaseTableClass, IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        public void BeforeSaveToDatabase()
        {
            if (DischargeMonitoringReport != null)
            {
                DischargeMonitoringReport.BeforeSaveToDatabase();
            }
        }
        public void AfterLoadFromDatabase()
        {
            if (DischargeMonitoringReport != null)
            {
                DischargeMonitoringReport.AfterLoadFromDatabase();
            }
        }
    }

    public class CropTypesPlantedDataType : BaseTableClass
    {
        [System.Xml.Serialization.XmlIgnore]
        [Column(DbType.AnsiString, 3, false)]
        public string Text;
    }
    public class CropTypesHarvestedDataType : BaseTableClass
    {
        [System.Xml.Serialization.XmlIgnore]
        [Column(DbType.AnsiString, 3, false)]
        public string Text;
    }

    public partial class LandApplicationSite : IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        [System.Xml.Serialization.XmlIgnore]
        public CropTypesPlantedDataType[] CropTypesPlantedList;

        [System.Xml.Serialization.XmlIgnore]
        public CropTypesHarvestedDataType[] CropTypesHarvestedList;

        public void BeforeSaveToDatabase()
        {
            if (!CollectionUtils.IsNullOrEmpty(CropTypesPlanted))
            {
                CropTypesPlantedList = new CropTypesPlantedDataType[CropTypesPlanted.Length];
                for (int i = 0; i < CropTypesPlanted.Length; ++i)
                {
                    CropTypesPlantedList[i] = new CropTypesPlantedDataType();
                    CropTypesPlantedList[i].Text = CropTypesPlanted[i];
                }
            }
            if (!CollectionUtils.IsNullOrEmpty(CropTypesHarvested))
            {
                CropTypesHarvestedList = new CropTypesHarvestedDataType[CropTypesHarvested.Length];
                for (int i = 0; i < CropTypesHarvested.Length; ++i)
                {
                    CropTypesHarvestedList[i] = new CropTypesHarvestedDataType();
                    CropTypesHarvestedList[i].Text = CropTypesHarvested[i];
                }
            }
        }
        public void AfterLoadFromDatabase()
        {
            if (!CollectionUtils.IsNullOrEmpty(CropTypesPlantedList))
            {
                CropTypesPlanted = new string[CropTypesPlantedList.Length];
                for (int i = 0; i < CropTypesPlantedList.Length; ++i)
                {
                    CropTypesPlanted[i] = CropTypesPlantedList[i].Text;
                }
            }
            if (!CollectionUtils.IsNullOrEmpty(CropTypesHarvestedList))
            {
                CropTypesHarvested = new string[CropTypesHarvestedList.Length];
                for (int i = 0; i < CropTypesHarvestedList.Length; ++i)
                {
                    CropTypesHarvested[i] = CropTypesHarvestedList[i].Text;
                }
            }
        }
    }

    public partial class ReportParameter
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string _FK;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.exchangenetwork.net/schema/icis/1", IsNullable = false)]
    public partial class DischargeMonitoringReport : DischargeMonitoringReportKeyElements, IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {

        public void BeforeSaveToDatabase()
        {
            if (LandApplicationSite != null)
            {
                LandApplicationSite.BeforeSaveToDatabase();
            }
        }
        public void AfterLoadFromDatabase()
        {
            if (LandApplicationSite != null)
            {
                LandApplicationSite.AfterLoadFromDatabase();
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string SignatureDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string PrincipalExecutiveOfficerFirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string PrincipalExecutiveOfficerLastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public string PrincipalExecutiveOfficerTitle;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public string PrincipalExecutiveOfficerTelephone;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string SignatoryFirstName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public string SignatoryLastName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public string SignatoryTelephone;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public string ReportCommentText;

        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string DMRNoDischargeIndicator;

        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        public string DMRNoDischargeReceivedDate;
        
        [System.Xml.Serialization.XmlElementAttribute("ReportParameter", Order = 11)]
        public ReportParameter[] ReportParameter;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        public LandApplicationSite LandApplicationSite;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        public SurfaceDisposalSite SurfaceDisposalSite;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        public Incinerator Incinerator;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        public CoDisposalSite CoDisposalSite;
    }
    
    [DefaultTableNamePrefixAttribute("ICIS")]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [FixShortenNameBreakBugAttribute]
    public partial class SubmissionHistoryDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string _PK;

        /// <remarks/>
        [Windsor.Commons.XsdOrm.DbNotNullAttribute]
        [Windsor.Commons.XsdOrm.DbIndexableAttribute]
        [System.ComponentModel.DescriptionAttribute("The user id specified in the document header for the submission, corresponding to Document.Header.Id.")]
        public string DocumentHeaderId;

        /// <remarks/>
        [Windsor.Commons.XsdOrm.DbNotNullAttribute]
        [System.ComponentModel.DescriptionAttribute("The date and time that the payload was submitted to the remote network node.")]
        public DateTime SubmitDate;

        /// <remarks/>
        [Windsor.Commons.XsdOrm.DbNotNullAttribute]
        [System.ComponentModel.DescriptionAttribute("The date and time used to pull data from the staging table (payload data older than this date was pulled).")]
        public DateTime LastPayloadUpdateDate;

        /// <remarks/>
        [Windsor.Commons.XsdOrm.Column(false, ColumnSize=50)]
        [System.ComponentModel.DescriptionAttribute("The transaction id for the submitted data on the local node.")]
        public string LocalTransactionId;
    }
}