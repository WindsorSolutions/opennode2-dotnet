using System.Xml.Serialization;
using System.Data;
using System;
using System.Collections.Generic;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.Core;
using Windsor.Node2008.WNOSPlugin.BEACHES_22;

// NOTIF_ORGANIZATION
[assembly: AppliedAttribute(typeof(OrganizationDetailDataType), "OrganizationIdentifier", typeof(ColumnAttribute), "ORGANIZATIONIDENTIFIER", 12, false)]
[assembly: AppliedAttribute(typeof(OrganizationNameDetailDataType), "OrganizationTypeCode", typeof(ColumnAttribute), "ORGANIZATIONTYPECODE", 12)]
[assembly: AppliedAttribute(typeof(OrganizationNameDetailDataType), "OrganizationName", typeof(ColumnAttribute), "ORGANIZATIONNAME", 60)]
[assembly: AppliedAttribute(typeof(OrganizationNameDetailDataType), "OrganizationDescriptionText", typeof(ColumnAttribute), "ORGANIZATIONDESCRIPTION", 255)]
[assembly: AppliedAttribute(typeof(OrganizationNameDetailDataType), "OrganizationAbbreviationText", typeof(ColumnAttribute), "ORGANIZATIONABBREVIATION", 30)]

// NOTIF_ORGANIZATIONMAILINGADDR
[assembly: AppliedAttribute(typeof(OrganizationMailingAddressDataType), "MailingAddressTypeCode", typeof(ColumnAttribute), "MAILINGADDRTYPECODE", 12, false)]
[assembly: AppliedAttribute(typeof(OrganizationMailingAddressDataType), "MailingAddressStreetLine1Text", typeof(ColumnAttribute), "MAILINGADDRLINE1", 100, false)]
[assembly: AppliedAttribute(typeof(OrganizationMailingAddressDataType), "MailingAddressStreetLine2Text", typeof(ColumnAttribute), "MAILINGADDRLINE2", 100)]
[assembly: AppliedAttribute(typeof(OrganizationMailingAddressDataType), "MailingAddressStreetLine3Text", typeof(ColumnAttribute), "MAILINGADDRLINE3", 100)]
[assembly: AppliedAttribute(typeof(OrganizationMailingAddressDataType), "MailingAddressCityName", typeof(ColumnAttribute), "MAILINGADDRCITY", 50, false)]
[assembly: AppliedAttribute(typeof(OrganizationMailingAddressDataType), "StateCode", typeof(ColumnAttribute), "STATECODE", 2, false, DbType.AnsiStringFixedLength)]
[assembly: AppliedAttribute(typeof(OrganizationMailingAddressDataType), "AddressPostalCode", typeof(ColumnAttribute), "ZIPCODE", 12, false)]
[assembly: AppliedAttribute(typeof(OrganizationMailingAddressDataType), "MailingAddressEffectiveDate", typeof(ColumnAttribute), "MAILINGADDREFFECTIVEDATE", 25, false, DbType.AnsiString)]
[assembly: AppliedAttribute(typeof(OrganizationMailingAddressDataType), "MailingAddressStatusIndicator", typeof(ColumnAttribute), "MAILINGADDRSTATUS", 8, false)]

// NOTIF_ORGELECTRONICADDR
[assembly: AppliedAttribute(typeof(OrganizationElectronicAddressType), "ElectronicAddressTypeCode", typeof(ColumnAttribute), "ELECTRONICADDRTYPECODE", 12, false)]
[assembly: AppliedAttribute(typeof(OrganizationElectronicAddressType), "ElectronicAddressText", typeof(ColumnAttribute), "ELECTRONICADDR", 255, false)]
[assembly: AppliedAttribute(typeof(OrganizationElectronicAddressType), "ElectronicAddressEffectiveDate", typeof(ColumnAttribute), "ELECTRONICADDREFFDATE", 25, false, DbType.AnsiString)]
[assembly: AppliedAttribute(typeof(OrganizationElectronicAddressType), "ElectronicAddressStatusIndicator", typeof(ColumnAttribute), "ELECTRONICADDRSTATUS", 8, false)]

// NOTIF_ORGANIZATIONTELEPHONE
[assembly: AppliedAttribute(typeof(OrganizationTelephoneType), "TelephoneTypeCode", typeof(ColumnAttribute), "TELEPHONETYPECODE", 12, false)]
[assembly: AppliedAttribute(typeof(OrganizationTelephoneType), "TelephoneNumberText", typeof(ColumnAttribute), "TELEPHONENUMBER", 12, false)]
[assembly: AppliedAttribute(typeof(OrganizationTelephoneType), "TelephoneEffectiveDate", typeof(ColumnAttribute), "TELEPHONEEFFECTIVEDATE", 25, false, DbType.AnsiString)]
[assembly: AppliedAttribute(typeof(OrganizationTelephoneType), "TelephoneStatusIndicator", typeof(ColumnAttribute), "TELEPHONESTATUS", 8, false)]

// NOTIF_PERSON
[assembly: AppliedAttribute(typeof(PersonDetailDataType), "PersonIdentifier", typeof(ColumnAttribute), "PERSONIDENTIFIER", 12, false)]
[assembly: AppliedAttribute(typeof(PersonNameDetailDataType), "PersonStatusIndicator", typeof(ColumnAttribute), "PERSONSTATUS", 8)]
[assembly: AppliedAttribute(typeof(PersonNameDetailDataType), "FirstName", typeof(ColumnAttribute), "FIRSTNAME", 50)]
[assembly: AppliedAttribute(typeof(PersonNameDetailDataType), "LastName", typeof(ColumnAttribute), "LASTNAME", 50)]
[assembly: AppliedAttribute(typeof(PersonNameDetailDataType), "PersonMiddleInitial", typeof(ColumnAttribute), "MIDDLEINITIAL", 2)]
[assembly: AppliedAttribute(typeof(PersonNameDetailDataType), "NameSuffixText", typeof(ColumnAttribute), "SUFFIX", 5)]
[assembly: AppliedAttribute(typeof(PersonNameDetailDataType), "NamePrefixText", typeof(ColumnAttribute), "TITLE", 60)]

// NOTIF_PERSONMAILINGADDRESS
[assembly: AppliedAttribute(typeof(PersonMailingAddressDataType), "MailingAddressTypeCode", typeof(ColumnAttribute), "MAILINGADDRTYPECODE", 12, false)]
[assembly: AppliedAttribute(typeof(PersonMailingAddressDataType), "MailingAddressStreetLine1Text", typeof(ColumnAttribute), "MAILINGADDRLINE1", 100, false)]
[assembly: AppliedAttribute(typeof(PersonMailingAddressDataType), "MailingAddressStreetLine2Text", typeof(ColumnAttribute), "MAILINGADDRLINE2", 100)]
[assembly: AppliedAttribute(typeof(PersonMailingAddressDataType), "MailingAddressStreetLine3Text", typeof(ColumnAttribute), "MAILINGADDRLINE3", 100)]
[assembly: AppliedAttribute(typeof(PersonMailingAddressDataType), "MailingAddressCityName", typeof(ColumnAttribute), "MAILINGADDRCITY", 50, false)]
[assembly: AppliedAttribute(typeof(PersonMailingAddressDataType), "StateCode", typeof(ColumnAttribute), "STATECODE", 2, false, DbType.AnsiStringFixedLength)]
[assembly: AppliedAttribute(typeof(PersonMailingAddressDataType), "AddressPostalCode", typeof(ColumnAttribute), "ZIPCODE", 12, false)]
[assembly: AppliedAttribute(typeof(PersonMailingAddressDataType), "MailingAddressEffectiveDate", typeof(ColumnAttribute), "MAILINGADDREFFECTIVEDATE", 25, false, DbType.AnsiString)]
[assembly: AppliedAttribute(typeof(PersonMailingAddressDataType), "MailingAddressStatusIndicator", typeof(ColumnAttribute), "MAILINGADDRSTATUS", 8, false)]

// NOTIF_PERSONELECTRONICADDRESS
[assembly: AppliedAttribute(typeof(PersonElectronicAddressType), "ElectronicAddressTypeCode", typeof(ColumnAttribute), "ELECTRONICADDRESSTYPECODE", 12, false)]
[assembly: AppliedAttribute(typeof(PersonElectronicAddressType), "ElectronicAddressText", typeof(ColumnAttribute), "ELECTRONICADDRESS", 255, false)]
[assembly: AppliedAttribute(typeof(PersonElectronicAddressType), "ElectronicAddressEffectiveDate", typeof(ColumnAttribute), "ELECTRONICADDRESSEFFECTIVEDATE", 25, false, DbType.AnsiString)]
[assembly: AppliedAttribute(typeof(PersonElectronicAddressType), "ElectronicAddressStatusIndicator", typeof(ColumnAttribute), "ELECTRONICADDRESSSTATUS", 8, false)]

// NOTIF_PERSONTELEPHONE
[assembly: AppliedAttribute(typeof(PersonTelephoneType), "TelephoneTypeCode", typeof(ColumnAttribute), "TELEPHONETYPECODE", 12, false)]
[assembly: AppliedAttribute(typeof(PersonTelephoneType), "TelephoneNumberText", typeof(ColumnAttribute), "TELEPHONENUMBER", 12, false)]
[assembly: AppliedAttribute(typeof(PersonTelephoneType), "TelephoneEffectiveDate", typeof(ColumnAttribute), "TELEPHONEEFFECTIVEDATE", 25, false, DbType.AnsiString)]
[assembly: AppliedAttribute(typeof(PersonTelephoneType), "TelephoneStatusIndicator", typeof(ColumnAttribute), "TELEPHONESTATUS", 8, false)]

// NOTIF_BEACH
[assembly: AppliedAttribute(typeof(BeachDetailDataType), "BeachIdentifier", typeof(ColumnAttribute), "BEACHIDENTIFIER", 8, false)]
[assembly: AppliedAttribute(typeof(ProgramInterestDataType), "ProgramInterestName", typeof(ColumnAttribute), "BEACHNAME", 60)]
[assembly: AppliedAttribute(typeof(ProgramInterestDataType), "ProgramInterestDescriptionText", typeof(ColumnAttribute), "BEACHDESCRIPTION", 255)]
[assembly: AppliedAttribute(typeof(ProgramInterestDataType), "ProgramInterestCommentText", typeof(ColumnAttribute), "BEACHCOMMENT", 255)]
[assembly: AppliedAttribute(typeof(ProgramInterestDataType), "ProgramInterestStateCode", typeof(ColumnAttribute), "BEACHSTATECODE", 2, DbType.AnsiStringFixedLength)]
[assembly: AppliedAttribute(typeof(ProgramInterestDataType), "ProgramInterestFIPSCountyCode", typeof(ColumnAttribute), "BEACHFIPSCOUNTYCODE", 5)]
[assembly: AppliedAttribute(typeof(BeachAccessibilityDetailDataType), "BeachAccessibilityType", typeof(ColumnAttribute), "BEACHACCESSTYPE", 12)]
[assembly: AppliedAttribute(typeof(BeachAccessibilityDetailDataType), "BeachAccessibilityComment", typeof(ColumnAttribute), "BEACHACCESSCOMMENT", 255)]
[assembly: AppliedAttribute(typeof(BeachAttributeDetailDataType), "AttributeEffectiveYear", typeof(ColumnAttribute), "EFFECTIVEYEAR", 4)]
[assembly: AppliedAttribute(typeof(ExtentDetailDataType), "ExtentLengthMeasure", typeof(ColumnAttribute), "EXTENTLENGTHMEASURE", DbType.Decimal)]
[assembly: AppliedAttribute(typeof(ExtentDetailDataType), "ExtentUnitOfMeasureCode", typeof(ColumnAttribute), "EXTENTUNITOFMEASURE", 12)]
[assembly: AppliedAttribute(typeof(BeachSwimSeasonLengthDetailDataType), "SwimSeasonStartDate", typeof(ColumnAttribute), "SWIMSEASONSTARTDATE", 25, DbType.AnsiString)]
[assembly: AppliedAttribute(typeof(BeachSwimSeasonLengthDetailDataType), "SwimSeasonEndDate", typeof(ColumnAttribute), "SWIMSEASONENDDATE", 25, DbType.AnsiString)]
[assembly: AppliedAttribute(typeof(BeachSwimSeasonLengthDetailDataType), "SwimSeasonLengthMeasure", typeof(ColumnAttribute), "SWIMSEASONLENGTH", DbType.Decimal)]
[assembly: AppliedAttribute(typeof(BeachSwimSeasonLengthDetailDataType), "SwimSeasonUnitOfMeasureCode", typeof(ColumnAttribute), "SWIMSEASONUNITOFMEASURE", 12)]
[assembly: AppliedAttribute(typeof(MonitoringFrequencyDetailDataType), "SwimSeasonFrequencyMeasure", typeof(ColumnAttribute), "SWIMSEASONFREQUENCYMEASURE", DbType.Decimal)]
[assembly: AppliedAttribute(typeof(MonitoringFrequencyDetailDataType), "OffSeasonFrequencyMeasure", typeof(ColumnAttribute), "OFFSEASONFREQUENCYMEASURE", DbType.Decimal)]
[assembly: AppliedAttribute(typeof(MonitoringFrequencyDetailDataType), "MonitoringFrequencyUnitOfMeasureCode", typeof(ColumnAttribute), "MONITORINGFREQUNITOFMEASURE", 255)]
[assembly: AppliedAttribute(typeof(MonitoringFrequencyDetailDataType), "MonitoredIrregularly", typeof(ColumnAttribute), "MONITOREDIRREGULARLY", 5)]
[assembly: AppliedAttribute(typeof(MonitoringFrequencyDetailDataType), "MonitoredIrregularlyComment", typeof(ColumnAttribute), "MONITOREDIRREGULARLYCOMMENT", 255)]
[assembly: AppliedAttribute(typeof(BeachAttributeDetailDataType), "BeachTierRanking", typeof(ColumnAttribute), "BEACHTIERRANKING", 1)]
[assembly: AppliedAttribute(typeof(BeachAttributeDetailDataType), "BeachActBeachIndicator", typeof(ColumnAttribute), "BEACHACTBEACHINDICATOR", 5)]
[assembly: AppliedAttribute(typeof(BeachPollutionSourceDetailDataType), "NoPollutionSourcesIndicator", typeof(ColumnAttribute), "NOPOLLUTIONSOURCES", 5)]
[assembly: AppliedAttribute(typeof(BeachPollutionSourceDetailDataType), "PollutionSourcesUninvestigatedIndicator", typeof(ColumnAttribute), "POLLUTIONSOURCESUNINVESTIGATED", 5)]
[assembly: AppliedAttribute(typeof(ProgramInterestDataType), "WaterBodyNameCode", typeof(ColumnAttribute), "WATERBODYNAMECODE", 25)]
[assembly: AppliedAttribute(typeof(ProgramInterestDataType), "WaterBodyTypeCode", typeof(ColumnAttribute), "WATERBODYTYPECODE", 25)]
[assembly: AppliedPathAttribute("BeachCoordinateStartPointDetail.LatitudeMeasure", typeof(ColumnAttribute), "STARTLATMEASURE", 25)]
[assembly: AppliedPathAttribute("BeachCoordinateStartPointDetail.LongitudeMeasure", typeof(ColumnAttribute), "STARTLONGMEASURE", 25)]
[assembly: AppliedPathAttribute("BeachCoordinateEndPointDetail.LatitudeMeasure", typeof(ColumnAttribute), "ENDLATMEASURE", 25)]
[assembly: AppliedPathAttribute("BeachCoordinateEndPointDetail.LongitudeMeasure", typeof(ColumnAttribute), "ENDLONGMEASURE", 25)]
[assembly: AppliedPathAttribute("BeachCoordinateStartPointDetail.SourceMapScaleNumeric", typeof(ColumnAttribute), "SOURCEMAPSCALE", 25)]
[assembly: AppliedPathAttribute("BeachCoordinateStartPointDetail.HorizontalCollectionMethodName", typeof(ColumnAttribute), "HORIZCOLLMETHOD", 25)]
[assembly: AppliedPathAttribute("BeachCoordinateStartPointDetail.HorizontalCoordinateReferenceSystemDatumName", typeof(ColumnAttribute), "HORIZCOLLDATUM", 25)]
[assembly: AppliedPathAttribute("BeachCoordinateEndPointDetail.SourceMapScaleNumeric", typeof(DbIgnoreAttribute))]
[assembly: AppliedPathAttribute("BeachCoordinateEndPointDetail.HorizontalCollectionMethodName", typeof(DbIgnoreAttribute))]
[assembly: AppliedPathAttribute("BeachCoordinateEndPointDetail.HorizontalCoordinateReferenceSystemDatumName", typeof(DbIgnoreAttribute))]
[assembly: AppliedAttribute(typeof(CoordinateDetailDataType), "BeachCoordinateDescriptionText", typeof(DbIgnoreAttribute))]

// NOTIF_BEACHACTIVITY
[assembly: AppliedAttribute(typeof(ActivityDataType), "ActivityTypeCode", typeof(ColumnAttribute), "ACTIVITYTYPECODE", 12, false)]
[assembly: AppliedAttribute(typeof(ActivityDataType), "ActivityName", typeof(ColumnAttribute), "ACTIVITYNAME", 60, false)]
[assembly: AppliedAttribute(typeof(ActivityDataType), "ActivityActualStartDate", typeof(ColumnAttribute), "ACTUALSTARTDATE", 25, false, DbType.AnsiString)]
[assembly: AppliedAttribute(typeof(ActivityDataType), "ActivityActualStopDate", typeof(ColumnAttribute), "ACTUALSTOPDATE", 25, false, DbType.AnsiString)]
[assembly: AppliedAttribute(typeof(ActivityDataType), "ActivityDescriptionText", typeof(ColumnAttribute), "ACTIVITYDESCRIPTION", 255)]
[assembly: AppliedAttribute(typeof(ActivityDataType), "ActivityCommentText", typeof(ColumnAttribute), "ACTIVITYCOMMENT", 255)]
[assembly: AppliedAttribute(typeof(ActivityDataType), "ActivityMonitoringStationIdentifier", typeof(DbIgnoreAttribute))]
[assembly: AppliedAttribute(typeof(ActivityExtentDetailDataType), "ActivityExtentStartMeasure", typeof(ColumnAttribute), "EXTENTSTARTMEASURE", DbType.Decimal)]
[assembly: AppliedAttribute(typeof(ActivityExtentDetailDataType), "ActivityExtentLengthMeasure", typeof(ColumnAttribute), "EXTENTLENGTHMEASURE", DbType.Decimal)]
[assembly: AppliedAttribute(typeof(ActivityExtentDetailDataType), "ActivityExtentUnitOfMeasureCode", typeof(ColumnAttribute), "EXTENTUNITOFMEASURE", 255)]

// NOTIF_BEACHPOLLUTION
[assembly: AppliedAttribute(typeof(BeachPollutionSourceDataType), "BeachPollutionSourceCode", typeof(ColumnAttribute), "POLLUTIONSOURCECODE", 12, false)]
[assembly: AppliedAttribute(typeof(BeachPollutionSourceDataType), "BeachPollutionSourceDescription", typeof(ColumnAttribute), "POLLUTIONSOURCEDESCRIPTION", 255)]

// NOTIF_ACTIVITYREASON
[assembly: AppliedAttribute(typeof(ActivityReasonDetailDataType), "ActivityReasonType", typeof(ColumnAttribute), "REASONTYPE", 60, false)]
[assembly: AppliedAttribute(typeof(ActivityReasonDetailDataType), "ActivityReasonDescriptionText", typeof(ColumnAttribute), "REASONDESCRIPTION", 255)]

// NOTIF_ACTIVITYSOURCE
[assembly: AppliedAttribute(typeof(ActivitySourceDetailDataType), "ActivitySourceType", typeof(ColumnAttribute), "SOURCETYPE", 60, false)]
[assembly: AppliedAttribute(typeof(ActivitySourceDetailDataType), "ActivitySourceDescriptionText", typeof(ColumnAttribute), "SOURCEDESCRIPTION", 255)]

// NOTIF_ACTIVITYINDICATOR
[assembly: AppliedAttribute(typeof(ActivityIndicatorDetailDataType), "ActivityIndicatorType", typeof(ColumnAttribute), "INDICATORTYPE", 60, false)]
[assembly: AppliedAttribute(typeof(ActivityIndicatorDetailDataType), "ActivityIndicatorDescriptionText", typeof(ColumnAttribute), "INDICATORDESCRIPTION", 255)]

// NOTIF_PERSONBEACHROLE
[assembly: AppliedAttribute(typeof(PersonRoleDetailDataType), "BeachRoleTypeCode", typeof(ColumnAttribute), "ROLETYPECODE", 12, false)]
[assembly: AppliedAttribute(typeof(PersonRoleDetailDataType), "BeachRoleEffectiveDate", typeof(ColumnAttribute), "ROLEEFFECTIVEDATE", 25, false, DbType.AnsiString)]
[assembly: AppliedAttribute(typeof(PersonRoleDetailDataType), "BeachRoleStatusIndicator", typeof(ColumnAttribute), "ROLESTATUS", 8, false)]
[assembly: AppliedAttribute(typeof(PersonRoleDetailDataType), "BeachRoleOrganizationIdentifier", typeof(DbIgnoreAttribute))]
[assembly: AppliedAttribute(typeof(PersonRoleDetailDataType), "BeachRolePersonIdentifier", typeof(DbIgnoreAttribute))]

// NOTIF_ORGANIZATIONBEACHROLE
[assembly: AppliedAttribute(typeof(OrganizationRoleDetailDataType), "BeachRoleTypeCode", typeof(ColumnAttribute), "ROLETYPECODE", 12, false)]
[assembly: AppliedAttribute(typeof(OrganizationRoleDetailDataType), "BeachRoleEffectiveDate", typeof(ColumnAttribute), "ROLEEFFECTIVEDATE", 25, false, DbType.AnsiString)]
[assembly: AppliedAttribute(typeof(OrganizationRoleDetailDataType), "BeachRoleStatusIndicator", typeof(ColumnAttribute), "ROLESTATUS", 8, false)]
[assembly: AppliedAttribute(typeof(OrganizationRoleDetailDataType), "BeachRoleOrganizationIdentifier", typeof(DbIgnoreAttribute))]
[assembly: AppliedAttribute(typeof(OrganizationRoleDetailDataType), "BeachRolePersonIdentifier", typeof(DbIgnoreAttribute))]

// NOTIF_PROCEDURE
[assembly: AppliedAttribute(typeof(BeachProcedureDetailDataType), "ProcedureIdentifier", typeof(ColumnAttribute), "PROCEDUREIDENTIFIER", 8, false)]
[assembly: AppliedAttribute(typeof(BeachProcedureDetailDataType), "ProcedureTypeCode", typeof(ColumnAttribute), "PROCEDURETYPECODE", 12, false)]
[assembly: AppliedAttribute(typeof(BeachProcedureDetailDataType), "ProcedureDescriptionText", typeof(ColumnAttribute), "PROCEDUREDESCRIPTION", 255, false)]
[assembly: AppliedAttribute(typeof(BeachProcedureDetailDataType), "ProcedureBeachIdentifier", typeof(DbIgnoreAttribute))]

// NOTIF_YEARCOMPLETION
[assembly: AppliedAttribute(typeof(YearCompletionIndicatorDataType), "CompletionYear", typeof(ColumnAttribute), "COMPLETIONYEAR", false, 4)]
[assembly: AppliedAttribute(typeof(YearCompletionIndicatorDataType), "NotificiationDataCompleteIndicator", typeof(ColumnAttribute), "NOTIFICATIONDATACOMPLETIONIND", 5)]
[assembly: AppliedAttribute(typeof(YearCompletionIndicatorDataType), "MonitoringDataCompleteIndicator", typeof(ColumnAttribute), "MONITORINGDATACOMPLETIONIND", 5)]
[assembly: AppliedAttribute(typeof(YearCompletionIndicatorDataType), "LocationDataCompleteIndicator", typeof(ColumnAttribute), "LOCATIONDATACOMPLETIONIND", 5)]

namespace Windsor.Node2008.WNOSPlugin.BEACHES_22
{
    public partial class BeachDataSubmissionDataType : IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        public void BeforeSaveToDatabase()
        {
            // Create GUIDs for all Organizations
            Dictionary<string, string> orgIdentifierToPrimaryKeyMap = new Dictionary<string, string>();
            Dictionary<string, string> personIdentifierToPrimaryKeyMap = new Dictionary<string, string>();
            CollectionUtils.ForEach(OrganizationDetail, delegate(OrganizationDetailDataType organizationDetail)
            {
                organizationDetail.Id = StringUtils.CreateSequentialGuid();
                orgIdentifierToPrimaryKeyMap.Add(organizationDetail.OrganizationIdentifier, organizationDetail.Id);
                CollectionUtils.ForEach(organizationDetail.OrganizationPersonDetail, delegate(PersonDetailDataType personDetail)
                {
                    string personId;
                    if (!personIdentifierToPrimaryKeyMap.TryGetValue(personDetail.PersonIdentifier, out personId))
                    {
                        personId = StringUtils.CreateSequentialGuid();
                        personIdentifierToPrimaryKeyMap.Add(personDetail.PersonIdentifier, personId);
                    }
                    personDetail.Id = personId;
                });
            });
            Dictionary<string, string> beachIdentifierToPrimaryKeyMap = new Dictionary<string, string>();
            // Create GUIDs for all Beach Details
            CollectionUtils.ForEach(BeachDetail, delegate(BeachDetailDataType beachDetail)
            {
                beachDetail.BeforeSaveToDatabase();
                beachDetail.Id = StringUtils.CreateSequentialGuid();
                beachIdentifierToPrimaryKeyMap.Add(beachDetail.BeachIdentifier, beachDetail.Id);
                Dictionary<string, OrganizationRoleDetailDataType> orgMap = new Dictionary<string, OrganizationRoleDetailDataType>();
                Dictionary<string, PersonRoleDetailDataType> personMap = new Dictionary<string, PersonRoleDetailDataType>();
                CollectionUtils.ForEach(beachDetail.BeachRoleDetail, delegate(OrganizationRoleDetailDataType orgRoleDetail)
                {
                    string orgId;
                    if (!orgIdentifierToPrimaryKeyMap.TryGetValue(orgRoleDetail.BeachRoleOrganizationIdentifier, out orgId))
                    {
                        throw new ArgumentException(string.Format("A BeachRoleDetail references Organization with Identifier \"{0}\" that cannot be found",
                                                                  orgRoleDetail.BeachRoleOrganizationIdentifier));
                    }
                    if (!orgMap.ContainsKey(orgRoleDetail.BeachRoleOrganizationIdentifier))
                    {
                        orgMap[orgRoleDetail.BeachRoleOrganizationIdentifier] = orgRoleDetail;
                        orgRoleDetail.OrganizationId = orgId;
                    }
                    if (!string.IsNullOrEmpty(orgRoleDetail.BeachRolePersonIdentifier))
                    {
                        if (!personMap.ContainsKey(orgRoleDetail.BeachRolePersonIdentifier))
                        {
                            string personId;
                            if (!personIdentifierToPrimaryKeyMap.TryGetValue(orgRoleDetail.BeachRolePersonIdentifier, out personId))
                            {
                                throw new ArgumentException(string.Format("A BeachRolePersonIdentifier references Person with Identifier \"{0}\" that cannot be found",
                                                                          orgRoleDetail.BeachRolePersonIdentifier));
                            }
                            PersonRoleDetailDataType personRole = new PersonRoleDetailDataType(orgRoleDetail);
                            personMap[orgRoleDetail.BeachRolePersonIdentifier] = personRole;
                            personRole.PersonId = personId;
                        }
                    }
                });
                beachDetail.BeachRoleDetail = (orgMap.Count > 0) ? CollectionUtils.ToArray(orgMap.Values) : null;
                beachDetail.PersonRoleDetail = (personMap.Count > 0) ? CollectionUtils.ToArray(personMap.Values) : null;
            });
            CollectionUtils.ForEach(BeachProcedureDetail, delegate(BeachProcedureDetailDataType beachProcedureDetail)
            {
                beachProcedureDetail.Id = StringUtils.CreateSequentialGuid();
                if (CollectionUtils.IsNullOrEmpty(beachProcedureDetail.ProcedureBeachIdentifier))
                {
                    throw new ArgumentException(string.Format("The BeachProcedureDetail with Identifier \"{0}\" does not have any associated BeachDetail Identifiers",
                                                              beachProcedureDetail.ProcedureIdentifier));
                }
                Dictionary<string, BeachProcedureDataType> beachProcedureList =
                    new Dictionary<string, BeachProcedureDataType>(beachProcedureDetail.ProcedureBeachIdentifier.Length);
                CollectionUtils.ForEach(beachProcedureDetail.ProcedureBeachIdentifier, delegate(string beachIdentifier)
                {
                    if (!beachProcedureList.ContainsKey(beachIdentifier))
                    {
                        string beachId;
                        if (!beachIdentifierToPrimaryKeyMap.TryGetValue(beachIdentifier, out beachId))
                        {
                            throw new ArgumentException(string.Format("The BeachProcedureDetail with Identifier \"{0}\" references a BeachDetail with Identifier \"{1}\" that cannot be found",
                                                                      beachProcedureDetail.ProcedureIdentifier, beachProcedureDetail.ProcedureBeachIdentifier));
                        }
                        BeachProcedureDataType beachProcedure = new BeachProcedureDataType();
                        beachProcedure.BeachId = beachId;
                        beachProcedure.ProcedureId = beachProcedureDetail.Id;
                        beachProcedureList.Add(beachIdentifier, beachProcedure);
                    }
                });
                beachProcedureDetail.BeachProcedure = new List<BeachProcedureDataType>(beachProcedureList.Values).ToArray();
            });
        }
        public void AfterLoadFromDatabase()
        {
            Dictionary<string, string> personPrimaryKeyToIdentifierMap = new Dictionary<string, string>();
            Dictionary<string, string> personPrimaryKeyToOrgIdentifierMap = new Dictionary<string, string>();
            Dictionary<string, string> orgPrimaryKeyToIdentifierMap = new Dictionary<string, string>();
            CollectionUtils.ForEach(OrganizationDetail, delegate(OrganizationDetailDataType organizationDetail)
            {
                orgPrimaryKeyToIdentifierMap[organizationDetail.Id] = organizationDetail.OrganizationIdentifier;
                CollectionUtils.ForEach(organizationDetail.OrganizationPersonDetail, delegate(PersonDetailDataType personDetail)
                {
                    if (!personPrimaryKeyToIdentifierMap.ContainsKey(personDetail.Id))
                    {
                        personPrimaryKeyToIdentifierMap[personDetail.Id] = personDetail.PersonIdentifier;
                        personPrimaryKeyToOrgIdentifierMap[personDetail.Id] = organizationDetail.OrganizationIdentifier;
                    }
                });
            });
            Dictionary<string, string> beachPrimaryKeyToIdentifierMap = new Dictionary<string, string>();
            CollectionUtils.ForEach(BeachDetail, delegate(BeachDetailDataType beachDetail)
            {
                beachDetail.AfterLoadFromDatabase();
                beachPrimaryKeyToIdentifierMap.Add(beachDetail.Id, beachDetail.BeachIdentifier);
                CollectionUtils.ForEach(beachDetail.BeachRoleDetail, delegate(OrganizationRoleDetailDataType orgRoleDetail)
                {
                    string orgIdentifier;
                    if (!orgPrimaryKeyToIdentifierMap.TryGetValue(orgRoleDetail.OrganizationId, out orgIdentifier))
                    {
                        throw new ArgumentException(string.Format("The BeachDetail with Id \"{0}\" references an Organization with Id \"{1}\" that cannot be found",
                                                                  beachDetail.Id, orgRoleDetail.Id));
                    }
                    orgRoleDetail.BeachRoleOrganizationIdentifier = orgIdentifier;
                });
                CollectionUtils.ForEach(beachDetail.PersonRoleDetail, delegate(PersonRoleDetailDataType personRoleDetail)
                {
                    string orgIdentifier;
                    if (!personPrimaryKeyToOrgIdentifierMap.TryGetValue(personRoleDetail.PersonId, out orgIdentifier))
                    {
                        throw new ArgumentException(string.Format("The Person with Id \"{0}\" references an Organization that cannot be found",
                                                                  personRoleDetail.Id));
                    }
                    string personIdentifier;
                    if (!personPrimaryKeyToIdentifierMap.TryGetValue(personRoleDetail.PersonId, out personIdentifier))
                    {
                        throw new ArgumentException(string.Format("An Identifier for Person with Id \"{0}\" cannot be found",
                                                                  personRoleDetail.Id));
                    }
                    personRoleDetail.BeachRoleOrganizationIdentifier = orgIdentifier;
                    personRoleDetail.BeachRolePersonIdentifier = personIdentifier;
                });
                // Combine Org and Person roles
                if (!CollectionUtils.IsNullOrEmpty(beachDetail.PersonRoleDetail))
                {
                    List<OrganizationRoleDetailDataType> roles = new List<OrganizationRoleDetailDataType>();
                    if (beachDetail.BeachRoleDetail != null)
                    {
                        roles.AddRange(beachDetail.BeachRoleDetail);
                    }
                    CollectionUtils.ForEach(beachDetail.PersonRoleDetail, delegate(PersonRoleDetailDataType personRoleDetail)
                    {
                        roles.Add(new OrganizationRoleDetailDataType(personRoleDetail));
                    });
                    beachDetail.BeachRoleDetail = roles.ToArray();
                }
            });
            CollectionUtils.ForEach(BeachProcedureDetail, delegate(BeachProcedureDetailDataType beachProcedureDetail)
            {
                if (CollectionUtils.IsNullOrEmpty(beachProcedureDetail.BeachProcedure))
                {
                    throw new ArgumentException(string.Format("The BeachProcedureDetail with procedure identifier \"{0}\" does not reference any beaches",
                                                              beachProcedureDetail.ProcedureIdentifier));
                }
                Dictionary<string, string> beachIdentifiers = new Dictionary<string, string>(beachProcedureDetail.BeachProcedure.Length);
                CollectionUtils.ForEach(beachProcedureDetail.BeachProcedure, delegate(BeachProcedureDataType beachProcedure)
                {
                    if (!beachIdentifiers.ContainsKey(beachProcedure.BeachId))
                    {
                        string beachIdentifier;
                        if (!beachPrimaryKeyToIdentifierMap.TryGetValue(beachProcedure.BeachId, out beachIdentifier))
                        {
                            throw new ArgumentException(string.Format("The BeachProcedureDetail with ID \"{0}\" references a BeachDetail with ID \"{1}\" that cannot be found",
                                                                      beachProcedureDetail.Id, beachProcedure.BeachId));
                        }
                        beachIdentifiers.Add(beachProcedure.BeachId, beachIdentifier);
                    }
                });
                beachProcedureDetail.ProcedureBeachIdentifier = new List<string>(beachIdentifiers.Values).ToArray();
            });
        }
    }

    [Table("NOTIF_ORGANIZATION")]
    [DefaultTableNamePrefixAttribute("NOTIF")]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [FixShortenNameBreakBugAttribute]
    [DefaultDecimalPrecision(19, 14)]
    public partial class OrganizationDetailDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_ORG")]
        public string Id;
    }
    [Table("NOTIF_ORGANIZATIONMAILINGADDR")]
    public partial class OrganizationMailingAddressDataType : MailingAddressDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_ORG_MA")]
        public string Id;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("ORGANIZATION_ID", IndexName = "FK_NOT_ORG_MA")]
        public string OrganizationId;
    }
    [Table("NOTIF_ORGELECTRONICADDR")]
    public partial class OrganizationElectronicAddressType : ElectronicAddressType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_ORG_EA")]
        public string Id;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("ORGANIZATION_ID", IndexName = "FK_NOT_ORG_EA")]
        public string OrganizationId;
    }
    [Table("NOTIF_ORGANIZATIONTELEPHONE")]
    public partial class OrganizationTelephoneType : TelephoneType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_ORG_TEL")]
        public string Id;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("ORGANIZATION_ID", IndexName = "FK_NOT_ORG_TEL")]
        public string OrganizationId;
    }
    [Table("NOTIF_PERSON")]
    public partial class PersonDetailDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_PER")]
        public string Id;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("ORGANIZATION_ID", IndexName = "FK_NOT_PER")]
        public string OrganizationId;
    }
    [Table("NOTIF_PERSONMAILINGADDRESS")]
    public partial class PersonMailingAddressDataType : MailingAddressDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_PER_MA")]
        public string Id;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PERSON_ID", IndexName = "FK_NOT_PER_MA")]
        public string PersonId;
    }
    [Table("NOTIF_PERSONELECTRONICADDRESS")]
    public partial class PersonElectronicAddressType : ElectronicAddressType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_PER_EA")]
        public string Id;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PERSON_ID", IndexName = "FK_NOT_PER_EA")]
        public string PersonId;
    }
    [Table("NOTIF_PERSONTELEPHONE")]
    public partial class PersonTelephoneType : TelephoneType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_PER_TEL")]
        public string Id;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PERSON_ID", IndexName = "FK_NOT_PER_TEL")]
        public string PersonId;
    }
    [Table("NOTIF_BEACH")]
    [DefaultTableNamePrefixAttribute("NOTIF")]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [FixShortenNameBreakBugAttribute]
    [DefaultDecimalPrecision(19, 14)]
    public partial class BeachDetailDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_BCH")]
        public string Id;

        [System.Xml.Serialization.XmlIgnore]
        public PersonRoleDetailDataType[] PersonRoleDetail;

        public void BeforeSaveToDatabase()
        {
            if (BeachCoordinateDetail != null)
            {
                if ((BeachCoordinateDetail.BeachCoordinateStartPointDetail != null) &&
                    (BeachCoordinateDetail.BeachCoordinateEndPointDetail != null))
                {
                    if (string.IsNullOrEmpty(BeachCoordinateDetail.BeachCoordinateStartPointDetail.SourceMapScaleNumeric))
                    {
                        BeachCoordinateDetail.BeachCoordinateStartPointDetail.SourceMapScaleNumeric =
                            BeachCoordinateDetail.BeachCoordinateEndPointDetail.SourceMapScaleNumeric;
                    }
                    if (string.IsNullOrEmpty(BeachCoordinateDetail.BeachCoordinateStartPointDetail.HorizontalCollectionMethodName))
                    {
                        BeachCoordinateDetail.BeachCoordinateStartPointDetail.HorizontalCollectionMethodName =
                            BeachCoordinateDetail.BeachCoordinateEndPointDetail.HorizontalCollectionMethodName;
                    }
                    if (string.IsNullOrEmpty(BeachCoordinateDetail.BeachCoordinateStartPointDetail.HorizontalCoordinateReferenceSystemDatumName))
                    {
                        BeachCoordinateDetail.BeachCoordinateStartPointDetail.HorizontalCoordinateReferenceSystemDatumName =
                            BeachCoordinateDetail.BeachCoordinateEndPointDetail.HorizontalCoordinateReferenceSystemDatumName;
                    }
                }
            }
            CollectionUtils.ForEach(BeachActivityDetail, delegate(ActivityDataType activity)
            {
                activity.BeforeSaveToDatabase();
            });
        }
        public void AfterLoadFromDatabase()
        {
            if (BeachCoordinateDetail != null)
            {
                if ((BeachCoordinateDetail.BeachCoordinateStartPointDetail != null) &&
                    (BeachCoordinateDetail.BeachCoordinateEndPointDetail != null))
                {
                    BeachCoordinateDetail.BeachCoordinateEndPointDetail.SourceMapScaleNumeric =
                        BeachCoordinateDetail.BeachCoordinateStartPointDetail.SourceMapScaleNumeric;
                    BeachCoordinateDetail.BeachCoordinateEndPointDetail.HorizontalCollectionMethodName =
                        BeachCoordinateDetail.BeachCoordinateStartPointDetail.HorizontalCollectionMethodName;
                    BeachCoordinateDetail.BeachCoordinateEndPointDetail.HorizontalCoordinateReferenceSystemDatumName =
                        BeachCoordinateDetail.BeachCoordinateStartPointDetail.HorizontalCoordinateReferenceSystemDatumName;
                }
            }
            CollectionUtils.ForEach(BeachActivityDetail, delegate(ActivityDataType activity)
            {
                activity.AfterLoadFromDatabase();
            });
        }
    }
    [Table("NOTIF_BEACHPOLLUTION")]
    public partial class BeachPollutionSourceDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_BCH_POL")]
        public string Id;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("BEACH_ID", IndexName = "FK_NOT_BCH_POL")]
        public string BeachId;
    }
    [Table("NOTIF_BEACHACTIVITYMONSTATION")]
    public class ActivityMonitoringStationIdentifierDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_BCH_POL")]
        public string Id;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("ACTIVITY_ID", IndexName = "FK_NOT_ACT_MON")]
        public string ActivityId;

        [System.Xml.Serialization.XmlIgnore]
        [ColumnAttribute("MONITORINGSTATIONIDENTIFIER", DbType.AnsiString, 65)]
        [DbNotNull]
        public string Identifier;
    }
    [Table("NOTIF_BEACHACTIVITY")]
    public partial class ActivityDataType : IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_BCH_ACT")]
        public string Id;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("BEACH_ID", IndexName = "FK_NOT_BCH_ACT")]
        public string BeachId;

        [System.Xml.Serialization.XmlIgnore]
        public ActivityMonitoringStationIdentifierDataType[] ActivityMonitoringStationIdentifierList;

        [System.Xml.Serialization.XmlIgnore]
        [ColumnAttribute("SENTTOEPA", DbType.AnsiStringFixedLength, 1)]
        public bool SetToEPA;

        public void BeforeSaveToDatabase()
        {
            if (!CollectionUtils.IsNullOrEmpty(ActivityMonitoringStationIdentifier))
            {
                ActivityMonitoringStationIdentifierList =
                    new ActivityMonitoringStationIdentifierDataType[ActivityMonitoringStationIdentifier.Length];
                for (int i = 0; i < ActivityMonitoringStationIdentifier.Length; ++i)
                {
                    ActivityMonitoringStationIdentifierList[i] = new ActivityMonitoringStationIdentifierDataType();
                    ActivityMonitoringStationIdentifierList[i].Identifier = ActivityMonitoringStationIdentifier[i];
                }
            }
        }
        public void AfterLoadFromDatabase()
        {
            if (!CollectionUtils.IsNullOrEmpty(ActivityMonitoringStationIdentifierList))
            {
                ActivityMonitoringStationIdentifier = new string[ActivityMonitoringStationIdentifierList.Length];
                for (int i = 0; i < ActivityMonitoringStationIdentifierList.Length; ++i)
                {
                    ActivityMonitoringStationIdentifier[i] = ActivityMonitoringStationIdentifierList[i].Identifier;
                }
            }
        }
    }
    [Table("NOTIF_ACTIVITYREASON")]
    public partial class ActivityReasonDetailDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_ACT_RSN")]
        public string Id;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("ACTIVITY_ID", IndexName = "FK_NOT_ACT_RSN")]
        public string ActivityId;
    }
    [Table("NOTIF_ACTIVITYSOURCE")]
    public partial class ActivitySourceDetailDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_ACT_SRC")]
        public string Id;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("ACTIVITY_ID", IndexName = "FK_NOT_ACT_SRC")]
        public string ActivityId;
    }
    [Table("NOTIF_ACTIVITYINDICATOR")]
    public partial class ActivityIndicatorDetailDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_ACT_IND")]
        public string Id;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("ACTIVITY_ID", IndexName = "FK_NOT_ACT_IND")]
        public string ActivityId;
    }
    [Table("NOTIF_PERSONBEACHROLE")]
    public partial class PersonRoleDetailDataType : RoleDetailDataType
    {
        public PersonRoleDetailDataType() { }

        public PersonRoleDetailDataType(OrganizationRoleDetailDataType orgRole)
        {
            BeachRoleTypeCode = orgRole.BeachRoleTypeCode;
            BeachRoleOrganizationIdentifier = orgRole.BeachRoleOrganizationIdentifier;
            BeachRolePersonIdentifier = orgRole.BeachRolePersonIdentifier;
            BeachRoleEffectiveDate = orgRole.BeachRoleEffectiveDate;
            BeachRoleStatusIndicator = orgRole.BeachRoleStatusIndicator;
        }

        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_PER_BCH_R")]
        public string Id;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("BEACH_ID", IndexName = "FK_NOT_PER_BCH_R")]
        public string BeachId;

        [System.Xml.Serialization.XmlIgnore]
        [Column("PERSON_ID", 40, IsNullable = false)]
        [DbIndexableAttribute]
        public string PersonId;
    }
    [Table("NOTIF_ORGANIZATIONBEACHROLE")]
    public partial class OrganizationRoleDetailDataType : RoleDetailDataType
    {
        public OrganizationRoleDetailDataType() { }

        public OrganizationRoleDetailDataType(PersonRoleDetailDataType personRoleDetail)
        {
            BeachRoleTypeCode = personRoleDetail.BeachRoleTypeCode;
            BeachRoleOrganizationIdentifier = personRoleDetail.BeachRoleOrganizationIdentifier;
            BeachRolePersonIdentifier = personRoleDetail.BeachRolePersonIdentifier;
            BeachRoleEffectiveDate = personRoleDetail.BeachRoleEffectiveDate;
            BeachRoleStatusIndicator = personRoleDetail.BeachRoleStatusIndicator;
        }
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_ORG_BCH_R")]
        public string Id;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("BEACH_ID", IndexName = "FK_NOT_ORG_BCH_R")]
        public string BeachId;

        [System.Xml.Serialization.XmlIgnore]
        [Column("ORGANIZATION_ID", 40, IsNullable = false)]
        [DbIndexableAttribute]
        public string OrganizationId;
    }
    [Table("NOTIF_PROCEDURE")]
    [DefaultTableNamePrefixAttribute("NOTIF")]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [FixShortenNameBreakBugAttribute]
    [DefaultDecimalPrecision(19, 14)]
    public partial class BeachProcedureDetailDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_PROCEDURE")]
        public string Id;

        [System.Xml.Serialization.XmlIgnore]
        public BeachProcedureDataType[] BeachProcedure;
    }
    [Table("NOTIF_BEACHPROCEDURE")]
    public partial class BeachProcedureDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_BCH_PROC")]
        public string Id;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey("PROCEDURE_ID", IndexName = "FK_NOT_BCHPROC_PROC")]
        public string ProcedureId;

        [System.Xml.Serialization.XmlIgnore]
        [DbNotNull]
        [Column("BEACH_ID", 40)]
        public string BeachId;
    }
    [Table("NOTIF_YEARCOMPLETION")]
    [DefaultTableNamePrefixAttribute("NOTIF")]
    [ShortenNamesByRemovingVowelsFirstAttribute]
    [FixShortenNameBreakBugAttribute]
    [DefaultDecimalPrecision(19, 14)]
    public partial class YearCompletionIndicatorDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey("ID", IndexName = "PK_NOT_YR_COM")]
        public string Id;
    }
}
