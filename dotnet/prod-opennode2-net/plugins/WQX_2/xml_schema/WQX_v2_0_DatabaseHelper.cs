using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm3;
using Windsor.Node2008.WNOSProviders;
using Wintellect.PowerCollections;

using System.Linq;
using System.Data;
using System.IO;
using System.Reflection;
using System.Threading;
using Spring.Transaction;
using Spring.Data;
using Spring.Data.Support;
using Spring.Dao;
using System.Data.SqlClient;

namespace Windsor.Node2008.WNOSPlugin.WQX_20
{
    public static class DatabaseHelper
    {
        //public static void BuildDatabase(IObjectsToDatabase objectsToDatabase)
        //{
        //    objectsToDatabase.BuildDatabase(typeof(Organization), typeof(MappingAttributes));
        //}
        //public static void SaveCurrentDatabaseVersion(SpringBaseDao springBaseDao, IObjectsToDatabase objectsToDatabase)
        //{
        //    string deleteTableName = objectsToDatabase.GetTableNameForType(typeof(Metadata), typeof(MappingAttributes));
        //    springBaseDao.DoSimpleDelete(deleteTableName, null, null);
        //    objectsToDatabase.SaveToDatabase(new Metadata(), false, typeof(MappingAttributes));
        //}
        //public static bool DbCharToBool(char dbChar)
        //{
        //    return char.ToUpper(dbChar) == TRUE_CHAR;
        //}
        //public static bool DbCharToBool(string dbChar)
        //{
        //    return string.Equals(dbChar, TRUE_CHAR.ToString(), StringComparison.OrdinalIgnoreCase);
        //}
        //public static bool DbStringToBool(string dbString)
        //{
        //    return string.Equals(dbString, TRUE_CHAR.ToString(), StringComparison.OrdinalIgnoreCase);
        //}
        //public static bool DbCharToBool(char? dbString, bool defaultValue)
        //{
        //    return (dbString != null) ? DbCharToBool(dbString.Value) : defaultValue;
        //}
        //public static char BoolToDbChar(bool value)
        //{
        //    return value ? TRUE_CHAR : FALSE_CHAR;
        //}
        //public static string NullOrNonEmptyString(string dbString)
        //{
        //    return string.IsNullOrEmpty(dbString) ? null : dbString;
        //}
        //public static T DbStringToEnum<T>(string dbString) where T : struct, IConvertible
        //{
        //    if (string.IsNullOrEmpty(dbString))
        //    {
        //        throw new ArgException("A required enum string in the database is null.");
        //    }
        //    return EnumUtils.ParseEnum<T>(dbString);
        //}
        //public const char TRUE_CHAR = 'Y';
        //public const char FALSE_CHAR = 'N';
        //public static string ToDescription(this ProtocolCategoryCode protocolCategoryCode)
        //{
        //    return (protocolCategoryCode == ProtocolCategoryCode.CollectionEvent) ?
        //        "Collection Event" : "Calculated Metric";
        //}
        //public static string ToDescription(this SpeciesCategoryCode speciesCategoryCode)
        //{
        //    switch (speciesCategoryCode)
        //    {
        //        case SpeciesCategoryCode.Fish:
        //            return "Fish";
        //        case SpeciesCategoryCode.CrabShellfish:
        //            return "Crab/Shellfish";
        //        case SpeciesCategoryCode.Vegetation:
        //            return "Vegetation";
        //    }
        //    return "Other";
        //}
        //public static string ToDescription(this FishIdentifierCategoryCode fishIdentifierCategoryCode)
        //{
        //    return "Species " + fishIdentifierCategoryCode.ToString();
        //}
        //private static void AppendCountString(StringBuilder sb, int count, string countName, string countsName,
        //                                      ref int addCount, ref int commaIndex)
        //{
        //    if (count > 0)
        //    {
        //        if (addCount > 0)
        //        {
        //            commaIndex = sb.Length;
        //            sb.Append(", ");
        //        }
        //        sb.AppendFormat("{0} {1}", count.ToString(), (count == 1) ? countName : ((countsName == null) ? countName + "s" : countsName));
        //        ++addCount;
        //    }
        //}
        //public static string GetNsxOrgCountsString(Organization org)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendFormat("NSX data for organization \"{0}\" contains ", org.OrganizationFriendlyName);

        //    int collectionEventCount = CollectionUtils.Count(org.CollectionEvent);
        //    int calculatedMetricsCount = CollectionUtils.Count(org.CalculatedMetric);
        //    int siteCount = CollectionUtils.Count(org.Site);
        //    int protocolCount = CollectionUtils.Count(org.Protocol);
        //    int equipmentCount = CollectionUtils.Count(org.Equipment);

        //    int addCount = 0, commaIndex = -1;
        //    AppendCountString(sb, collectionEventCount, "Collection Event", null, ref addCount, ref commaIndex);
        //    AppendCountString(sb, calculatedMetricsCount, "Calculated Metric", null, ref addCount, ref commaIndex);
        //    AppendCountString(sb, siteCount, "Site", null, ref addCount, ref commaIndex);
        //    AppendCountString(sb, protocolCount, "Protocol", null, ref addCount, ref commaIndex);
        //    AppendCountString(sb, equipmentCount, "Equipment", null, ref addCount, ref commaIndex);

        //    if (addCount == 0)
        //    {
        //        sb.Append("no collection events or calculated metrics");
        //    }
        //    else if (addCount > 1)
        //    {
        //        sb.Replace(", ", " and ", commaIndex, sb.Length - commaIndex);
        //    }

        //    return sb.ToString();
        //}
        //public static Dictionary<string, DbAppendSelectWhereClause>
        //    GetQuerySelectClauses(SpringBaseDao baseDao, ImportExportDatasetType queryType, string queryOrganizationId,
        //                          DateTime? queryStartDate, DateTime? queryEndDate, DateTime? changedAfterDate,
        //                          QAStatusCode? minQAStatusCode, string queryBasin, string queryWRIA, IList<string> querySpecies)
        //{
        //    ExceptionUtils.ThrowIfNull(baseDao, "baseDao");

        //    bool isCalculatedMetricsQuery = (queryType == ImportExportDatasetType.CalculatedMetricsOnly) || (queryType == ImportExportDatasetType.CollectionEventsAndCalculatedMetrics);
        //    bool isCollectionEventsQuery = (queryType == ImportExportDatasetType.CollectionEventsOnly) || (queryType == ImportExportDatasetType.CollectionEventsAndCalculatedMetrics);
        //    ExceptionUtils.ThrowIfFalse(isCalculatedMetricsQuery || isCollectionEventsQuery);

        //    string validQAStatusCodes = QAStatusCode.Approved.ToString();
        //    if (minQAStatusCode != null)
        //    {
        //        switch (minQAStatusCode.Value)
        //        {
        //            case QAStatusCode.Intermediate:
        //                validQAStatusCodes = StringUtils.Join("','", new string[] { QAStatusCode.Approved.ToString(), QAStatusCode.Intermediate.ToString() });
        //                break;
        //            case QAStatusCode.Preliminary:
        //                validQAStatusCodes = StringUtils.Join("','", new string[] { QAStatusCode.Approved.ToString(), QAStatusCode.Intermediate.ToString(), QAStatusCode.Preliminary.ToString() });
        //                break;
        //        }
        //    }
        //    validQAStatusCodes = "'" + validQAStatusCodes.ToUpper() + "'";

        //    string validSpeciesSubquery = !CollectionUtils.IsNullOrEmpty(querySpecies) ? StringUtils.Join(",", querySpecies).ToUpper() : null;

        //    Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>();

        //    const string BASE_ORG_SELECT_CLAUSE = "(UPPER(ORGANIZATION_ID) = UPPER(?))";
        //    if (!string.IsNullOrEmpty(queryOrganizationId))
        //    {
        //        selectClauses.Add("NSX_ORGANIZATION", new DbAppendSelectWhereClause(baseDao, BASE_ORG_SELECT_CLAUSE, queryOrganizationId));
        //    }

        //    String calculatedMetricsQueryString = null;
        //    List<object> calculatedMetricsQueryParams = null;

        //    if (isCalculatedMetricsQuery)
        //    {
        //        StringBuilder calculatedMetricsQuery =
        //            new StringBuilder("(UPPER(SHARE_WITH_PARTNERS_IND) = '" + DatabaseHelper.TRUE_CHAR + "')");
        //        calculatedMetricsQueryParams = new List<object>();

        //        if (!string.IsNullOrEmpty(queryOrganizationId))
        //        {
        //            calculatedMetricsQuery.Append(" AND " + BASE_ORG_SELECT_CLAUSE);
        //            calculatedMetricsQueryParams.Add(queryOrganizationId);
        //        }
        //        if (queryStartDate != null)
        //        {
        //            calculatedMetricsQuery.Append(" AND (PERIOD_START_DATE >= ?)");
        //            calculatedMetricsQueryParams.Add(DateTimeUtils.StartOfDay(queryStartDate.Value));
        //        }
        //        if (queryEndDate != null)
        //        {
        //            calculatedMetricsQuery.Append(" AND (PERIOD_START_DATE <= ?)");
        //            calculatedMetricsQueryParams.Add(DateTimeUtils.EndOfDay(queryEndDate.Value));
        //        }
        //        if (changedAfterDate != null)
        //        {
        //            calculatedMetricsQuery.Append(" AND (LAST_UPDATED_DATE_TIME >= ?)");
        //            calculatedMetricsQueryParams.Add(DateTimeUtils.StartOfDay(changedAfterDate.Value));
        //        }
        //        if (!string.IsNullOrEmpty(queryBasin) || !string.IsNullOrEmpty(queryWRIA))
        //        {
        //            calculatedMetricsQuery.Append(" AND (SITE_ID IN ");
        //            if (!string.IsNullOrEmpty(queryBasin) && !string.IsNullOrEmpty(queryWRIA))
        //            {
        //                calculatedMetricsQuery.Append("(SELECT DISTINCT SITE_ID FROM NSX_SITE WHERE UPPER(BASIN_NAME) = UPPER(?) AND UPPER(WRIA_NAME) = UPPER(?)))");
        //                calculatedMetricsQueryParams.Add(queryBasin);
        //                calculatedMetricsQueryParams.Add(queryWRIA);
        //            }
        //            else if (!string.IsNullOrEmpty(queryBasin))
        //            {
        //                calculatedMetricsQuery.Append("(SELECT DISTINCT SITE_ID FROM NSX_SITE WHERE UPPER(BASIN_NAME) = UPPER(?)))");
        //                calculatedMetricsQueryParams.Add(queryBasin);
        //            }
        //            else
        //            {
        //                calculatedMetricsQuery.Append("(SELECT DISTINCT SITE_ID FROM NSX_SITE WHERE UPPER(WRIA_NAME) = UPPER(?)))");
        //                calculatedMetricsQueryParams.Add(queryWRIA);
        //            }
        //        }
        //        if (!string.IsNullOrEmpty(validSpeciesSubquery))
        //        {
        //            calculatedMetricsQuery.Append(" AND (UPPER(SPECIES_CODE) IN (?))");
        //            calculatedMetricsQueryParams.Add(validSpeciesSubquery);
        //        }
        //        calculatedMetricsQueryString = calculatedMetricsQuery.ToString();
        //        selectClauses.Add("NSX_CALC_METRIC", new DbAppendSelectWhereClause(baseDao, calculatedMetricsQueryString, calculatedMetricsQueryParams));
        //    }
        //    else
        //    {
        //        selectClauses.Add("NSX_CALC_METRIC", new DbAppendSelectWhereClause(baseDao, "0=1", null));
        //    }

        //    String collectionEventsQueryString = null;
        //    List<object> collectionEventsQueryParams = null;

        //    if (isCollectionEventsQuery)
        //    {
        //        string baseQuerySeed = "(UPPER(SHARE_WITH_PARTNERS_IND) = '" + DatabaseHelper.TRUE_CHAR + "') AND (UPPER(QA_STATUS_CODE) IN (" + validQAStatusCodes + "))";

        //        StringBuilder collectionEventsQuery = new StringBuilder(baseQuerySeed);
        //        collectionEventsQueryParams = new List<object>();

        //        if (!string.IsNullOrEmpty(queryOrganizationId))
        //        {
        //            collectionEventsQuery.Append(" AND " + BASE_ORG_SELECT_CLAUSE);
        //            collectionEventsQueryParams.Add(queryOrganizationId);
        //        }
        //        if (queryStartDate != null)
        //        {
        //            collectionEventsQuery.Append(" AND (EVNT_START_DATE_TIME >= ?)");
        //            collectionEventsQueryParams.Add(DateTimeUtils.StartOfDay(queryStartDate.Value));
        //        }
        //        if (queryEndDate != null)
        //        {
        //            collectionEventsQuery.Append(" AND (EVNT_START_DATE_TIME <= ?)");
        //            collectionEventsQueryParams.Add(DateTimeUtils.EndOfDay(queryEndDate.Value));
        //        }
        //        if (changedAfterDate != null)
        //        {
        //            collectionEventsQuery.Append(" AND (LAST_UPDATED_DATE_TIME >= ?)");
        //            collectionEventsQueryParams.Add(DateTimeUtils.StartOfDay(changedAfterDate.Value));
        //        }
        //        if (!string.IsNullOrEmpty(queryBasin) || !string.IsNullOrEmpty(queryWRIA))
        //        {
        //            collectionEventsQuery.Append(" AND (SITE_ID IN ");
        //            if (!string.IsNullOrEmpty(queryBasin) && !string.IsNullOrEmpty(queryWRIA))
        //            {
        //                collectionEventsQuery.Append("(SELECT DISTINCT SITE_ID FROM NSX_SITE WHERE UPPER(BASIN_NAME) = UPPER(?) AND UPPER(WRIA_NAME) = UPPER(?)))");
        //                collectionEventsQueryParams.Add(queryBasin);
        //                collectionEventsQueryParams.Add(queryWRIA);
        //            }
        //            else if (!string.IsNullOrEmpty(queryBasin))
        //            {
        //                collectionEventsQuery.Append("(SELECT DISTINCT SITE_ID FROM NSX_SITE WHERE UPPER(BASIN_NAME) = UPPER(?)))");
        //                collectionEventsQueryParams.Add(queryBasin);
        //            }
        //            else
        //            {
        //                collectionEventsQuery.Append("(SELECT DISTINCT SITE_ID FROM NSX_SITE WHERE UPPER(WRIA_NAME) = UPPER(?)))");
        //                collectionEventsQueryParams.Add(queryWRIA);
        //            }
        //        }
        //        if (!string.IsNullOrEmpty(validSpeciesSubquery))
        //        {
        //            collectionEventsQuery.Append(" AND (COLLECT_EVNT_ID IN ");
        //            collectionEventsQuery.Append("(SELECT DISTINCT COLLECT_EVNT_ID FROM NSX_SPECIES_SUMMARY WHERE UPPER(SPECIES_CODE) IN (?)))");
        //            collectionEventsQueryParams.Add(validSpeciesSubquery);
        //        }
        //        collectionEventsQueryString = collectionEventsQuery.ToString();
        //        selectClauses.Add("NSX_COLLECT_EVNT", new DbAppendSelectWhereClause(baseDao, collectionEventsQuery.ToString(), collectionEventsQueryParams));
        //    }
        //    else
        //    {
        //        selectClauses.Add("NSX_COLLECT_EVNT", new DbAppendSelectWhereClause(baseDao, "0=1", null));
        //    }

        //    string sitesQuery;
        //    List<object> queryParameters;
        //    if (isCalculatedMetricsQuery && isCollectionEventsQuery)
        //    {
        //        sitesQuery = string.Format("(SITE_ID IN (SELECT DISTINCT SITE_ID FROM NSX_CALC_METRIC WHERE {0})) OR " +
        //                                   "(SITE_ID IN (SELECT DISTINCT SITE_ID FROM NSX_COLLECT_EVNT WHERE {1}))",
        //                                   calculatedMetricsQueryString, collectionEventsQueryString);
        //        queryParameters = new List<object>();
        //        if (!CollectionUtils.IsNullOrEmpty(calculatedMetricsQueryParams))
        //        {
        //            queryParameters.AddRange(calculatedMetricsQueryParams);
        //        }
        //        if (!CollectionUtils.IsNullOrEmpty(collectionEventsQueryParams))
        //        {
        //            queryParameters.AddRange(collectionEventsQueryParams);
        //        }
        //    }
        //    else if (isCalculatedMetricsQuery)
        //    {
        //        sitesQuery = string.Format("SITE_ID IN (SELECT DISTINCT SITE_ID FROM NSX_CALC_METRIC WHERE {0})", calculatedMetricsQueryString);
        //        queryParameters = calculatedMetricsQueryParams;
        //    }
        //    else
        //    {
        //        sitesQuery = string.Format("SITE_ID IN (SELECT DISTINCT SITE_ID FROM NSX_COLLECT_EVNT WHERE {0})", collectionEventsQueryString);
        //        queryParameters = collectionEventsQueryParams;
        //    }
        //    selectClauses.Add("NSX_SITE", new DbAppendSelectWhereClause(baseDao, sitesQuery, queryParameters));

        //    string protocolQuery;
        //    if (isCalculatedMetricsQuery && isCollectionEventsQuery)
        //    {
        //        protocolQuery = string.Format("(PROTOCOL_ID IN (SELECT DISTINCT PROTOCOL_ID FROM NSX_CALC_METRIC WHERE {0})) OR " +
        //                                      "(PROTOCOL_ID IN (SELECT DISTINCT PROTOCOL_ID FROM NSX_COLLECT_EVNT WHERE {1}))",
        //                                      calculatedMetricsQueryString, collectionEventsQueryString);
        //        queryParameters = new List<object>();
        //        if (!CollectionUtils.IsNullOrEmpty(calculatedMetricsQueryParams))
        //        {
        //            queryParameters.AddRange(calculatedMetricsQueryParams);
        //        }
        //        if (!CollectionUtils.IsNullOrEmpty(collectionEventsQueryParams))
        //        {
        //            queryParameters.AddRange(collectionEventsQueryParams);
        //        }
        //    }
        //    else if (isCalculatedMetricsQuery)
        //    {
        //        protocolQuery = string.Format("PROTOCOL_ID IN (SELECT DISTINCT PROTOCOL_ID FROM NSX_CALC_METRIC WHERE {0})", calculatedMetricsQueryString);
        //        queryParameters = calculatedMetricsQueryParams;
        //    }
        //    else
        //    {
        //        protocolQuery = string.Format("PROTOCOL_ID IN (SELECT DISTINCT PROTOCOL_ID FROM NSX_COLLECT_EVNT WHERE {0})", collectionEventsQueryString);
        //        queryParameters = collectionEventsQueryParams;
        //    }
        //    selectClauses.Add("NSX_PROTOCOL", new DbAppendSelectWhereClause(baseDao, protocolQuery, queryParameters));

        //    if (isCollectionEventsQuery)
        //    {
        //        string equipmentQuery = string.Format("EQUIPMENT_ID IN (SELECT DISTINCT EQUIPMENT_ID FROM NSX_COLLECT_EVNT WHERE {0})", collectionEventsQueryString);
        //        selectClauses.Add("NSX_EQUIPMENT", new DbAppendSelectWhereClause(baseDao, equipmentQuery, collectionEventsQueryParams));
        //    }
        //    else
        //    {
        //        selectClauses.Add("NSX_EQUIPMENT", new DbAppendSelectWhereClause(baseDao, "0=1", null));
        //    }

        //    return selectClauses;
        //}
        //public static string MakeEmbeddedNameForAttachedFile(string parentId, string attachedFileName)
        //{
        //    string name = string.Format("{0}_{1}", parentId, attachedFileName);
        //    name = FileUtils.ReplaceInvalidFilenameChars(name, "%%%");
        //    return name;
        //}
        //public static CaseInsensitiveDictionary<LutSpecies> LoadSpeciesTypeMap(SpringBaseDao baseDao)
        //{
        //    CaseInsensitiveDictionary<LutSpecies> speciesTypeMap = new CaseInsensitiveDictionary<LutSpecies>(200);
        //    baseDao.DoJDBCQueryWithRowCallbackDelegate("SELECT SPECIES_CODE,SPECIES_GROUP,SPECIES_CATEGORY_CODE FROM NSX_LUT_SPECIES",
        //                                                         delegate(IDataReader dataReader)
        //                                                         {
        //                                                             string SPECIES_CODE = dataReader.GetString(0);
        //                                                             string SPECIES_GROUP = dataReader.GetString(1);
        //                                                             string SPECIES_CATEGORY_CODE = dataReader.GetString(2);
        //                                                             speciesTypeMap[SPECIES_CODE] = new LutSpecies()
        //                                                             {
        //                                                                 SpeciesCode = SPECIES_CODE,
        //                                                                 SpeciesGroup = SPECIES_GROUP,
        //                                                                 SpeciesCategoryCode = EnumUtils.ParseEnum<SpeciesCategoryCode>(SPECIES_CATEGORY_CODE)
        //                                                             };
        //                                                         }, null);
        //    return speciesTypeMap;
        //}
        //public static CaseInsensitiveDictionary<LutFishIdentifierType> LoadFishIdentifierTypeMap(SpringBaseDao baseDao)
        //{
        //    CaseInsensitiveDictionary<LutFishIdentifierType> fishIdentifierTypeMap = new CaseInsensitiveDictionary<LutFishIdentifierType>(200);
        //    baseDao.DoJDBCQueryWithRowCallbackDelegate("SELECT FISH_IDEN_TYPE_CODE,FISH_IDEN_CATEGORY_CODE FROM NSX_LUT_FISH_IDEN_TYPE",
        //                                                         delegate(IDataReader dataReader)
        //                                                         {
        //                                                             string FISH_IDEN_TYPE_CODE = dataReader.GetString(0);
        //                                                             string FISH_IDEN_CATEGORY_CODE = dataReader.GetString(1);
        //                                                             fishIdentifierTypeMap[FISH_IDEN_TYPE_CODE] = new LutFishIdentifierType()
        //                                                             {
        //                                                                 FishIdentifierTypeCode = FISH_IDEN_TYPE_CODE,
        //                                                                 FishIdentifierCategoryCode = EnumUtils.ParseEnum<FishIdentifierCategoryCode>(FISH_IDEN_CATEGORY_CODE),
        //                                                             };
        //                                                         }, null);
        //    return fishIdentifierTypeMap;
        //}

        //public static void WriteAttachmentFilesToFolder(SpringBaseDao baseDao, NSX data, string folderPath)
        //{
        //    CollectionUtils.ForEach(data.Organization, delegate(Organization org)
        //    {
        //        CollectionUtils.ForEach(org.Protocol, delegate(Protocol protocol)
        //        {
        //            if (protocol.AttachedBinaryObject != null)
        //            {
        //                if (string.IsNullOrEmpty(protocol.AttachedBinaryObject.AttachmentFileName))
        //                {
        //                    throw new ArgException("An attachment for the protocol \"{0}\" with id \"{1}\" does not have an attachment name.",
        //                                            protocol.ProtocolName, protocol.ProtocolId);
        //                }
        //                string fileName = MakeEmbeddedNameForAttachedFile(protocol.ProtocolId, protocol.AttachedBinaryObject.AttachmentFileName);
        //                string filePath = Path.Combine(folderPath, fileName);
        //                if (File.Exists(filePath))
        //                {
        //                    throw new ArgException("Failed to write the attachment \"{0}\" for the protocol \"{1}\" with id \"{2}\" because another file with the same name already exists in the temporary folder: \"{3}\"",
        //                                           protocol.AttachedBinaryObject.AttachmentFileName, protocol.ProtocolName, protocol.ProtocolId, filePath);
        //                }
        //                byte[] content = null;
        //                baseDao.DoJDBCQueryWithRowCallbackDelegate("SELECT ATTACHMENT_CONTENT FROM NSX_ATTACHED_BINARY_OBJECT WHERE UPPER(PROTOCOL_ID) = UPPER(?) AND UPPER(ATTACHMENT_FILE_NAME) = UPPER(?)",
        //                                             delegate(IDataReader dataReader)
        //                                             {
        //                                                 content = (byte[])dataReader.GetValue(0);
        //                                             }, protocol.ProtocolId, protocol.AttachedBinaryObject.AttachmentFileName);

        //                if (content == null)
        //                {
        //                    throw new ArgException("Failed to load attachment content for the file \"{0}\" from the database for the protocol \"{1}\" with id \"{2}\"",
        //                                           protocol.AttachedBinaryObject.AttachmentFileName, protocol.ProtocolName, protocol.ProtocolId);
        //                }
        //                File.WriteAllBytes(filePath, content);
        //            }
        //        });

        //        CollectionUtils.ForEach(org.CollectionEvent, delegate(CollectionEvent collectionEvent)
        //        {
        //            CollectionUtils.ForEach(collectionEvent.AttachedBinaryObject, delegate(AttachedBinaryObject attachedBinaryObject)
        //            {
        //                if (string.IsNullOrEmpty(attachedBinaryObject.AttachmentFileName))
        //                {
        //                    throw new ArgException("An attachment for the collection event with id \"{0}\" does not have an attachment name.",
        //                                            collectionEvent.CollectionEventId);
        //                }
        //                string fileName = MakeEmbeddedNameForAttachedFile(collectionEvent.CollectionEventId, attachedBinaryObject.AttachmentFileName);
        //                string filePath = Path.Combine(folderPath, fileName);
        //                if (File.Exists(filePath))
        //                {
        //                    throw new ArgException("Failed to write the attachment \"{0}\" for the collection event with id \"{1}\" because another file with the same name already exists in the temporary folder: \"{2}\"",
        //                                           attachedBinaryObject.AttachmentFileName, collectionEvent.CollectionEventId, filePath);
        //                }
        //                byte[] content = null;
        //                baseDao.DoJDBCQueryWithRowCallbackDelegate("SELECT ATTACHMENT_CONTENT FROM NSX_ATTACHED_BINARY_OBJECT WHERE UPPER(COLLECT_EVNT_ID) = UPPER(?) AND UPPER(ATTACHMENT_FILE_NAME) = UPPER(?)",
        //                                             delegate(IDataReader dataReader)
        //                                             {
        //                                                 content = (byte[])dataReader.GetValue(0);
        //                                             }, collectionEvent.CollectionEventId, attachedBinaryObject.AttachmentFileName);

        //                if (content == null)
        //                {
        //                    throw new ArgException("Failed to load attachment content for the file \"{0}\" from the database for the collection event with id \"{1}\"",
        //                                           attachedBinaryObject.AttachmentFileName, collectionEvent.CollectionEventId);
        //                }
        //                File.WriteAllBytes(filePath, content);
        //            });
        //        });
        //    });
        //}
        public static WQX GenerateWqxQueryFromDatabase(IAppendAuditLogEvent appendAuditLogEvent, IObjectsFromDatabase objectsFromDatabase, SpringBaseDao baseDao,
                                                       string queryOrganizationIdentifier, out string validationErrorsFile)
        {
            ExceptionUtils.ThrowIfNull(objectsFromDatabase);
            ExceptionUtils.ThrowIfNull(baseDao);
            ExceptionUtils.ThrowIfEmptyString(queryOrganizationIdentifier);

            //appendAuditLogEvent.AppendAuditLogEvent("Querying database for NSX results ...");

            //Dictionary<string, DbAppendSelectWhereClause> selectClauses =
            //    DatabaseHelper.GetQuerySelectClauses(baseDao, queryType, queryOrganizationIdentifier, queryStartDateValue, queryEndDateValue,
            //                                         queryDataChangedAfterValue, qaStatusCode, queryBasinValue, queryWRIAValue,
            //                                         querySpeciesValues);

            //List<Organization> organizations = objectsFromDatabase.LoadFromDatabase<Organization>(baseDao, selectClauses, typeof(MappingAttributes));

            //NSX nsx = new NSX();
            //if (!CollectionUtils.IsNullOrEmpty(organizations))
            //{
            //    nsx.Organization = organizations.ToArray();
            //    StringBuilder sb = new StringBuilder();
            //    sb.AppendFormat("{0} NSX organization(s) were found that matched the query with the following counts:", organizations.Count.ToString());
            //    int count = 1;
            //    foreach (Organization org in organizations)
            //    {
            //        sb.AppendLine();
            //        sb.AppendFormat("{0} - {1}: ", org.OrganizationId, org.OrganizationFormalName);
            //        sb.Append(DatabaseHelper.GetNsxOrgCountsString(org));
            //        ++count;
            //    }
            //    appendAuditLogEvent.AppendAuditLogEvent(sb.ToString());
            //}
            //else
            //{
            //    appendAuditLogEvent.AppendAuditLogEvent("No NSX data was found that matched the query, returning an empty NSX dataset.");
            //}
            return nsx;
        }
        //public static string GenerateAndValidateNsxQueryFile(IAppendAuditLogEvent appendAuditLogEvent, IObjectsFromDatabase objectsFromDatabase,
        //                                                     SpringBaseDao baseDao, ImportExportDatasetType queryType, string queryOrganizationIdentifier,
        //                                                     DateTime? queryStartDateValue, DateTime? queryEndDateValue, DateTime? queryDataChangedAfterValue,
        //                                                     QAStatusCode qaStatusCode, string queryBasinValue, string queryWRIAValue,
        //                                                     IList<string> querySpeciesValues, string sysTempFolderPath,
        //                                                     Assembly xmlSchemaZippedResourceAssembly, string xmlSchemaZippedQualifiedResourceName,
        //                                                     string xmlSchemaRootFileName, ISerializationHelper serializationHelper, ICompressionHelper compressionHelper,
        //                                                     bool doGenerateEmptyFile, out string validationErrorsFile)
        //{
        //    validationErrorsFile = null;

        //    NSX nsx = GenerateNsxQueryFromDatabase(appendAuditLogEvent, objectsFromDatabase, baseDao, queryType, queryOrganizationIdentifier,
        //                                           queryStartDateValue, queryEndDateValue, queryDataChangedAfterValue, qaStatusCode,
        //                                           queryBasinValue, queryWRIAValue, querySpeciesValues);

        //    if (!doGenerateEmptyFile && IsEmptyDataset(nsx))
        //    {
        //        return null;
        //    }

        //    appendAuditLogEvent.AppendAuditLogEvent("Generating NSX xml file from query results ...");

        //    string tempFolderPath = Path.Combine(sysTempFolderPath, Guid.NewGuid().ToString());

        //    string fileName = Guid.NewGuid().ToString();
        //    string tempXmlFilePath = Path.Combine(tempFolderPath, NSX_FILE_PREFIX + fileName + ".xml");
        //    string zipXmlFilePath = Path.ChangeExtension(Path.Combine(sysTempFolderPath, fileName), ".zip");
        //    Directory.CreateDirectory(tempFolderPath);

        //    try
        //    {
        //        serializationHelper.Serialize(nsx, tempXmlFilePath);

        //        appendAuditLogEvent.AppendAuditLogEvent("Generated NSX xml file from query results");

        //        validationErrorsFile =
        //            BaseWNOSPlugin.ValidateXmlFile(tempXmlFilePath, xmlSchemaZippedResourceAssembly, xmlSchemaZippedQualifiedResourceName,
        //                                           xmlSchemaRootFileName, sysTempFolderPath, appendAuditLogEvent, compressionHelper);

        //        if (validationErrorsFile != null)
        //        {
        //            compressionHelper.CompressFile(tempXmlFilePath, zipXmlFilePath);
        //            return zipXmlFilePath;
        //        }

        //        try
        //        {
        //            appendAuditLogEvent.AppendAuditLogEvent("Writing attachment files to temp folder ...");

        //            DatabaseHelper.WriteAttachmentFilesToFolder(baseDao, nsx, tempFolderPath);

        //            appendAuditLogEvent.AppendAuditLogEvent("Compressing NSX xml data file and attachments ...");

        //            compressionHelper.CompressDirectory(zipXmlFilePath, tempFolderPath);
        //        }
        //        catch (Exception)
        //        {
        //            FileUtils.SafeDeleteFile(zipXmlFilePath);
        //            throw;
        //        }
        //        finally
        //        {
        //            FileUtils.SafeDeleteDirectory(tempFolderPath);
        //        }

        //        return zipXmlFilePath;
        //    }
        //    catch (Exception)
        //    {
        //        FileUtils.SafeDeleteFile(tempXmlFilePath);
        //        throw;
        //    }
        //}
        //public static bool IsEmptyDataset(NSX nsx)
        //{
        //    if (nsx == null)
        //    {
        //        return true;
        //    }
        //    bool allEmpty = true;
        //    CollectionUtils.ForEachBreak(nsx.Organization, delegate(Organization organization)
        //    {
        //        if (!CollectionUtils.IsNullOrEmpty(organization.CollectionEvent) ||
        //            !CollectionUtils.IsNullOrEmpty(organization.CalculatedMetric))
        //        {
        //            allEmpty = false;
        //            return false;
        //        }
        //        return true;
        //    });
        //    return allEmpty;
        //}
        //public static string ValidateAndStoreNsxSubmissionFile(IAppendAuditLogEvent appendAuditLogEvent, string submissionFilePath,
        //                                                       IObjectsToDatabase objectsToDatabase, SpringBaseDao baseDao, string sysTempFolderPath,
        //                                                       Assembly xmlSchemaZippedResourceAssembly, string xmlSchemaZippedQualifiedResourceName,
        //                                                       string xmlSchemaRootFileName,
        //                                                       ISerializationHelper serializationHelper, ICompressionHelper compressionHelper,
        //                                                       out string validationErrorsFile)
        //{
        //    string attachmentsFolderPath;
        //    NSX data = GenerateNsxObjectsFromSubmissionFile(appendAuditLogEvent, submissionFilePath, sysTempFolderPath,
        //                                                    xmlSchemaZippedResourceAssembly, xmlSchemaZippedQualifiedResourceName,
        //                                                    xmlSchemaRootFileName, serializationHelper, compressionHelper,
        //                                                    out attachmentsFolderPath, out validationErrorsFile);
        //    if (data == null)
        //    {
        //        return null;
        //    }

        //    return StoreNsxDataToDatabase(appendAuditLogEvent, data, objectsToDatabase, baseDao, attachmentsFolderPath);
        //}

        //public static string StoreNsxDataToDatabase(IAppendAuditLogEvent appendAuditLogEvent, NSX data, IObjectsToDatabase objectsToDatabase,
        //                                            SpringBaseDao baseDao, string attachmentsFolderPath)
        //{
        //    appendAuditLogEvent.AppendAuditLogEvent("Storing NSX data into the database ...");

        //    string countsString = string.Empty;

        //    baseDao.TransactionTemplate.Execute(delegate(Spring.Transaction.ITransactionStatus status)
        //    {
        //        CollectionUtils.ForEach(data.Organization, delegate(Organization org)
        //        {
        //            appendAuditLogEvent.AppendAuditLogEvent("Replacing existing NSX data in database for organization \"{0}\" ...", org.OrganizationFriendlyName);

        //            DeleteOrganizationFromDatabase(org.OrganizationId, baseDao);

        //            appendAuditLogEvent.AppendAuditLogEvent("Storing NSX data into database for organization \"{0}\" ...", org.OrganizationFriendlyName);

        //            appendAuditLogEvent.AppendAuditLogEvent(DatabaseHelper.GetNsxOrgCountsString(org));

        //            Dictionary<string, int> insertCounts = objectsToDatabase.SaveToDatabase(org, baseDao, typeof(MappingAttributes));

        //            DatabaseHelper.StoreAttachmentFilesFromFolder(objectsToDatabase, baseDao, data, attachmentsFolderPath);

        //            countsString += string.Format("Stored NSX data for organization \"{0}\" into the database with the following table row counts:{1}{2}",
        //                                          org.OrganizationFriendlyName, Environment.NewLine, CreateTableRowCountsString(insertCounts));

        //            appendAuditLogEvent.AppendAuditLogEvent(countsString);
        //        });
        //        return null;
        //    });
        //    return countsString;
        //}

        //public static string StoreNsxCEParsedDataToDatabase(IAppendAuditLogEvent appendAuditLogEvent, NSX data, IObjectsToDatabase objectsToDatabase,
        //                                                    SpringBaseDao baseDao)
        //{
        //    appendAuditLogEvent.AppendAuditLogEvent("Storing NSX Collection Event data into the database ...");

        //    string countsString = string.Empty;

        //    baseDao.TransactionTemplate.Execute(delegate(Spring.Transaction.ITransactionStatus status)
        //    {
        //        CollectionUtils.ForEach(data.Organization, delegate(Organization org)
        //        {
        //            appendAuditLogEvent.AppendAuditLogEvent("Updating existing NSX Collection Event data in database for organization \"{0}\" ...", org.OrganizationFriendlyName);

        //            DeleteCollectionEventsFromDatabase(org, baseDao);

        //            appendAuditLogEvent.AppendAuditLogEvent("Storing NSX Collection Event data into database for organization \"{0}\" ...", org.OrganizationFriendlyName);

        //            appendAuditLogEvent.AppendAuditLogEvent(DatabaseHelper.GetNsxOrgCountsString(org));

        //            Dictionary<string, int> insertCounts = objectsToDatabase.SaveToDatabase(org, baseDao, typeof(MappingAttributes));

        //            countsString += string.Format("Stored NSX data for organization \"{0}\" into the database with the following table row counts:{1}{2}",
        //                                          org.OrganizationFriendlyName, Environment.NewLine, CreateTableRowCountsString(insertCounts));

        //            appendAuditLogEvent.AppendAuditLogEvent(countsString);
        //        });
        //        return null;
        //    });
        //    return countsString;
        //}

        //public static void StoreAttachmentFilesFromFolder(IObjectsToDatabase objectsToDatabase, SpringBaseDao baseDao, NSX data, string folderPath)
        //{
        //    CollectionUtils.ForEach(data.Organization, delegate(Organization org)
        //    {
        //        CollectionUtils.ForEach(org.Protocol, delegate(Protocol protocol)
        //        {
        //            if (protocol.AttachedBinaryObject != null)
        //            {
        //                if (string.IsNullOrEmpty(protocol.AttachedBinaryObject.AttachmentFileName))
        //                {
        //                    throw new ArgException("An attachment for the protocol \"{0}\" with id \"{1}\" does not have an attachment name.",
        //                                            protocol.ProtocolName, protocol.ProtocolId);
        //                }
        //                string fileName = MakeEmbeddedNameForAttachedFile(protocol.ProtocolId, protocol.AttachedBinaryObject.AttachmentFileName);
        //                string filePath = Path.Combine(folderPath, fileName);
        //                if (!File.Exists(filePath))
        //                {
        //                    throw new ArgException("Failed to locate an attachment with the name \"{0}\" for the protocol \"{1}\" with id \"{2}\" in the temporary folder: \"{3}\"",
        //                                           protocol.AttachedBinaryObject.AttachmentFileName, protocol.ProtocolName, protocol.ProtocolId, filePath);
        //                }

        //                byte[] content = File.ReadAllBytes(filePath);

        //                int updateCount = baseDao.DoJDBCExecuteNonQuery("UPDATE NSX_ATTACHED_BINARY_OBJECT SET ATTACHMENT_CONTENT = ? WHERE UPPER(PROTOCOL_ID) = UPPER(?) AND UPPER(ATTACHMENT_FILE_NAME) = UPPER(?)",
        //                                                                content, protocol.ProtocolId, protocol.AttachedBinaryObject.AttachmentFileName);
        //                if (updateCount == 0)
        //                {
        //                    throw new ArgException("Failed to update the content for an attachment with the name \"{0}\" for the protocol \"{1}\" with id \"{2}\"",
        //                                           protocol.AttachedBinaryObject.AttachmentFileName, protocol.ProtocolName, protocol.ProtocolId);
        //                }
        //            }
        //        });

        //        CollectionUtils.ForEach(org.CollectionEvent, delegate(CollectionEvent collectionEvent)
        //        {
        //            CollectionUtils.ForEach(collectionEvent.AttachedBinaryObject, delegate(AttachedBinaryObject attachedBinaryObject)
        //            {
        //                if (string.IsNullOrEmpty(attachedBinaryObject.AttachmentFileName))
        //                {
        //                    throw new ArgException("An attachment for the collection event with id \"{0}\" does not have an attachment name.",
        //                                            collectionEvent.CollectionEventId);
        //                }
        //                string fileName = MakeEmbeddedNameForAttachedFile(collectionEvent.CollectionEventId, attachedBinaryObject.AttachmentFileName);
        //                string filePath = Path.Combine(folderPath, fileName);
        //                if (!File.Exists(filePath))
        //                {
        //                    throw new ArgException("Failed to locate an attachment with the name \"{0}\" for the collection event with id \"{1}\" in the temporary folder: \"{2}\"",
        //                                           attachedBinaryObject.AttachmentFileName, collectionEvent.CollectionEventId, filePath);
        //                }

        //                byte[] content = File.ReadAllBytes(filePath);

        //                int updateCount = baseDao.DoJDBCExecuteNonQuery("UPDATE NSX_ATTACHED_BINARY_OBJECT SET ATTACHMENT_CONTENT = ? WHERE UPPER(COLLECT_EVNT_ID) = UPPER(?) AND UPPER(ATTACHMENT_FILE_NAME) = UPPER(?)",
        //                                                                content, collectionEvent.CollectionEventId, attachedBinaryObject.AttachmentFileName);
        //                if (updateCount == 0)
        //                {
        //                    throw new ArgException("Failed to update the content for an attachment with the name \"{0}\" for the collection event with id \"{1}\"",
        //                                           attachedBinaryObject.AttachmentFileName, collectionEvent.CollectionEventId);
        //                }
        //            });
        //        });
        //    });
        //}

        //public delegate bool IsNsxOrgValid(string organizationId);

        //public static string GenerateAndValidateNsxDistinctOrganizationsFile(IAppendAuditLogEvent appendAuditLogEvent, IObjectsFromDatabase objectsFromDatabase,
        //                                                                     SpringBaseDao baseDao, string sysTempFolderPath,
        //                                                                     Assembly xmlSchemaZippedResourceAssembly, string xmlSchemaZippedQualifiedResourceName,
        //                                                                     string xmlSchemaRootFileName, ISerializationHelper serializationHelper,
        //                                                                     ICompressionHelper compressionHelper, IsNsxOrgValid isNsxOrgValidCallback,
        //                                                                     out string validationErrorsFile)
        //{
        //    NSX nsx = GenerateNsxDistinctOrganizationsDatabase(appendAuditLogEvent, objectsFromDatabase, baseDao, isNsxOrgValidCallback);

        //    appendAuditLogEvent.AppendAuditLogEvent("Generating NSX xml file from query results ...");

        //    string fileName = Guid.NewGuid().ToString();
        //    string tempXmlFilePath = Path.Combine(sysTempFolderPath, NSX_FILE_PREFIX + fileName + ".xml");
        //    string tempZipFilePath = Path.ChangeExtension(tempXmlFilePath, ".zip");

        //    try
        //    {
        //        serializationHelper.Serialize(nsx, tempXmlFilePath);

        //        appendAuditLogEvent.AppendAuditLogEvent("Generated NSX xml data file from query results");

        //        validationErrorsFile =
        //            BaseWNOSPlugin.ValidateXmlFile(tempXmlFilePath, xmlSchemaZippedResourceAssembly, xmlSchemaZippedQualifiedResourceName,
        //                                           xmlSchemaRootFileName, sysTempFolderPath, appendAuditLogEvent, compressionHelper);

        //        if (validationErrorsFile != null)
        //        {
        //            return tempXmlFilePath;
        //        }

        //        try
        //        {
        //            appendAuditLogEvent.AppendAuditLogEvent("Compressing NSX xml data file ...");

        //            compressionHelper.CompressFile(tempXmlFilePath, tempZipFilePath);
        //        }
        //        catch (Exception)
        //        {
        //            FileUtils.SafeDeleteFile(tempZipFilePath);
        //            throw;
        //        }
        //        finally
        //        {
        //            FileUtils.SafeDeleteFile(tempXmlFilePath);
        //        }

        //        return tempZipFilePath;
        //    }
        //    catch (Exception)
        //    {
        //        FileUtils.SafeDeleteFile(tempXmlFilePath);
        //        throw;
        //    }
        //}
        //public static NSX GenerateNsxDistinctOrganizationsDatabase(IAppendAuditLogEvent appendAuditLogEvent, IObjectsFromDatabase objectsFromDatabase,
        //                                                           SpringBaseDao baseDao, IsNsxOrgValid isNsxOrgValidCallback)
        //{
        //    ExceptionUtils.ThrowIfNull(objectsFromDatabase);
        //    ExceptionUtils.ThrowIfNull(baseDao);

        //    appendAuditLogEvent.AppendAuditLogEvent("Querying database for NSX results ...");

        //    Dictionary<string, DbAppendSelectWhereClause> selectClauses =
        //        DatabaseHelper.GetDistinctOrganizationsSelectClauses(baseDao);

        //    List<Organization> organizations = objectsFromDatabase.LoadFromDatabase<Organization>(baseDao, selectClauses, typeof(MappingAttributes));

        //    NSX nsx = new NSX();
        //    if (!CollectionUtils.IsNullOrEmpty(organizations) && (isNsxOrgValidCallback != null))
        //    {
        //        for (int i = organizations.Count - 1; i >= 0; --i)
        //        {
        //            if (!isNsxOrgValidCallback(organizations[i].OrganizationId))
        //            {
        //                organizations.RemoveAt(i);
        //            }
        //        }
        //    }
        //    if (!CollectionUtils.IsNullOrEmpty(organizations))
        //    {
        //        nsx.Organization = organizations.ToArray();
        //        appendAuditLogEvent.AppendAuditLogEvent("{0} NSX organization(s) were found that matched the request.");
        //    }
        //    else
        //    {
        //        appendAuditLogEvent.AppendAuditLogEvent("No NSX organizations were found that matched the request, returning an empty NSX dataset.");
        //    }
        //    return nsx;
        //}
        //public static Dictionary<string, DbAppendSelectWhereClause> GetDistinctOrganizationsSelectClauses(SpringBaseDao baseDao)
        //{
        //    ExceptionUtils.ThrowIfNull(baseDao, "baseDao");

        //    Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>();

        //    selectClauses.Add("NSX_CALC_METRIC", new DbAppendSelectWhereClause(baseDao, "0=1", null));

        //    selectClauses.Add("NSX_COLLECT_EVNT", new DbAppendSelectWhereClause(baseDao, "0=1", null));

        //    selectClauses.Add("NSX_SITE", new DbAppendSelectWhereClause(baseDao, "0=1", null));

        //    selectClauses.Add("NSX_PROTOCOL", new DbAppendSelectWhereClause(baseDao, "0=1", null));

        //    selectClauses.Add("NSX_EQUIPMENT", new DbAppendSelectWhereClause(baseDao, "0=1", null));

        //    return selectClauses;
        //}
        //public static void DeleteOrganizationFromDatabase(string organizationId, SpringBaseDao baseDao)
        //{
        //    DeleteCollectionEventsFromDatabase(organizationId, baseDao);

        //    int count = baseDao.DoJDBCExecuteNonQuery("DELETE FROM NSX_ATTACHED_BINARY_OBJECT WHERE PROTOCOL_ID IN " +
        //                                  "(SELECT DISTINCT PROTOCOL_ID FROM NSX_PROTOCOL WHERE UPPER(ORGANIZATION_ID) = UPPER(?))",
        //                                  organizationId);

        //    count = baseDao.DoJDBCExecuteNonQuery("DELETE FROM NSX_ORGANIZATION WHERE UPPER(ORGANIZATION_ID) = UPPER(?)", organizationId);
        //}
        //public static void DeleteCollectionEventsFromDatabase(Organization org, SpringBaseDao baseDao)
        //{
        //    if (CollectionUtils.IsNullOrEmpty(org.CollectionEvent))
        //    {
        //        return;
        //    }
        //    CaseInsensitiveDictionary<CollectionEvent> collectionEventKeys = new CaseInsensitiveDictionary<CollectionEvent>(org.CollectionEvent.Length);
        //    CollectionUtils.ForEach(org.CollectionEvent, delegate(CollectionEvent ce)
        //    {
        //        ExceptionUtils.ThrowIfEmptyString(ce.UniqueParserKey);
        //        collectionEventKeys.Add(ce.UniqueParserKey, ce);
        //    });
        //    MultiDictionary<string, string> collectionEventIdsToReplace = new MultiDictionary<string, string>(false);
        //    baseDao.DoJDBCQueryWithRowCallbackDelegate("SELECT COLLECT_EVNT_ID, SITE_ID, ACTIVITY_TYPE_NAME, SAMPLE_SET_IDEN_TEXT, EVNT_START_DATE_TIME FROM NSX_COLLECT_EVNT WHERE UPPER(ORGANIZATION_ID) = UPPER(?)",
        //                                               delegate(IDataReader dataReader)
        //                                               {
        //                                                   string COLLECT_EVNT_ID = dataReader.GetString(0);
        //                                                   string SITE_ID = dataReader.GetString(1);
        //                                                   string ACTIVITY_TYPE_NAME = dataReader.GetString(2);
        //                                                   string SAMPLE_SET_IDEN_TEXT = dataReader.GetString(3);
        //                                                   DateTime EVNT_START_DATE_TIME = dataReader.GetDateTime(4);
        //                                                   string ceUniqueKey = CollectionEvent.GetCollectionEventUniqueKey(SITE_ID, ACTIVITY_TYPE_NAME, SAMPLE_SET_IDEN_TEXT,
        //                                                                                                                    EVNT_START_DATE_TIME);
        //                                                   CollectionEvent ce;
        //                                                   if (collectionEventKeys.TryGetValue(ceUniqueKey, out ce))
        //                                                   {
        //                                                       ce.CollectionEventId = COLLECT_EVNT_ID;
        //                                                       collectionEventIdsToReplace.Add(ceUniqueKey, COLLECT_EVNT_ID);
        //                                                   }
        //                                               }, org.OrganizationId);

        //    if (collectionEventIdsToReplace.Count == 0)
        //    {
        //        // No elements need to be deleted
        //        return;
        //    }

        //    string tempIdTableName = "#CE_DELETE_IDS_TABLE";
        //    {
        //        // Create a temp table to join with when deleting
        //        List<string> collectionEventIdsToReplaceList = new List<string>(collectionEventIdsToReplace.Values);
        //        string createTempTableCommand = string.Format("CREATE TABLE {0}(COLLECT_EVNT_ID VARCHAR(36))", tempIdTableName);
        //        baseDao.DoJDBCExecuteNonQuery(createTempTableCommand);
        //        string[] tempArray = new string[1];
        //        baseDao.DoBulkInsert(tempIdTableName, "COLLECT_EVNT_ID", delegate(int currentInsertIndex)
        //        {
        //            if (currentInsertIndex < collectionEventIdsToReplaceList.Count)
        //            {
        //                tempArray[0] = collectionEventIdsToReplaceList[currentInsertIndex];
        //                return tempArray;
        //            }
        //            else
        //            {
        //                return null;
        //            }
        //        });
        //    }
        //    string ceIdSubselectStatement = "SELECT COLLECT_EVNT_ID FROM " + tempIdTableName;

        //    int count =
        //        baseDao.DoJDBCExecuteNonQuery("DELETE FROM NSX_ATTACHED_BINARY_OBJECT WHERE COLLECT_EVNT_ID IN (" + ceIdSubselectStatement + ")");
        //    count = baseDao.DoJDBCExecuteNonQuery("DELETE FROM NSX_FISH_COND_TYPE_CODE WHERE SPECIES_SUMMARY_ID IN " +
        //                                          "(SELECT DISTINCT SPECIES_SUMMARY_ID FROM NSX_SPECIES_SUMMARY WHERE COLLECT_EVNT_ID IN (" + ceIdSubselectStatement + "))");
        //    count = baseDao.DoJDBCExecuteNonQuery("DELETE FROM NSX_FISH_COND_TYPE_CODE WHERE INDV_FISH_DETAIL_ID IN " +
        //                                         "(SELECT DISTINCT INDV_FISH_DETAIL_ID FROM NSX_INDV_FISH_DETAIL WHERE SPECIES_SUMMARY_ID IN " +
        //                                         "(SELECT DISTINCT SPECIES_SUMMARY_ID FROM NSX_SPECIES_SUMMARY WHERE COLLECT_EVNT_ID IN (" + ceIdSubselectStatement + ")))");
        //    count = baseDao.DoJDBCExecuteNonQuery("DELETE FROM NSX_FISH_IDEN_DETAIL WHERE SPECIES_SUMMARY_ID IN " +
        //                                          "(SELECT DISTINCT SPECIES_SUMMARY_ID FROM NSX_SPECIES_SUMMARY WHERE COLLECT_EVNT_ID IN (" + ceIdSubselectStatement + "))");
        //    count = baseDao.DoJDBCExecuteNonQuery("DELETE FROM NSX_FISH_IDEN_DETAIL WHERE INDV_FISH_DETAIL_ID IN " +
        //                                          "(SELECT DISTINCT INDV_FISH_DETAIL_ID FROM NSX_INDV_FISH_DETAIL WHERE SPECIES_SUMMARY_ID IN " +
        //                                          "(SELECT DISTINCT SPECIES_SUMMARY_ID FROM NSX_SPECIES_SUMMARY WHERE COLLECT_EVNT_ID IN (" + ceIdSubselectStatement + ")))");
        //    count = baseDao.DoJDBCExecuteNonQuery("DELETE FROM NSX_FISH_IDEN_DETAIL WHERE SPECIES_SUMMARY_ID IN " +
        //                                          "(SELECT DISTINCT SPECIES_SUMMARY_ID FROM NSX_SPECIES_SUMMARY WHERE COLLECT_EVNT_ID IN (" + ceIdSubselectStatement + "))");
        //    count = baseDao.DoJDBCExecuteNonQuery("DELETE FROM NSX_COLLECT_EVNT WHERE COLLECT_EVNT_ID IN (" + ceIdSubselectStatement + ")");
        //}
        //public static void DeleteCollectionEventsFromDatabase(string organizationId, SpringBaseDao baseDao)
        //{
        //    int count =
        //        baseDao.DoJDBCExecuteNonQuery("DELETE FROM NSX_ATTACHED_BINARY_OBJECT WHERE COLLECT_EVNT_ID IN " +
        //                                  "(SELECT DISTINCT COLLECT_EVNT_ID FROM NSX_COLLECT_EVNT WHERE UPPER(ORGANIZATION_ID) = UPPER(?))",
        //                                  organizationId);
        //    count = baseDao.DoJDBCExecuteNonQuery("DELETE FROM NSX_FISH_COND_TYPE_CODE WHERE SPECIES_SUMMARY_ID IN " +
        //                                  "(SELECT DISTINCT SPECIES_SUMMARY_ID FROM NSX_SPECIES_SUMMARY WHERE COLLECT_EVNT_ID IN " +
        //                                  "(SELECT DISTINCT COLLECT_EVNT_ID FROM NSX_COLLECT_EVNT WHERE UPPER(ORGANIZATION_ID) = UPPER(?)))",
        //                                  organizationId);
        //    count = baseDao.DoJDBCExecuteNonQuery("DELETE FROM NSX_FISH_COND_TYPE_CODE WHERE INDV_FISH_DETAIL_ID IN " +
        //                                  "(SELECT DISTINCT INDV_FISH_DETAIL_ID FROM NSX_INDV_FISH_DETAIL WHERE SPECIES_SUMMARY_ID IN " +
        //                                  "(SELECT DISTINCT SPECIES_SUMMARY_ID FROM NSX_SPECIES_SUMMARY WHERE COLLECT_EVNT_ID IN " +
        //                                  "(SELECT DISTINCT COLLECT_EVNT_ID FROM NSX_COLLECT_EVNT WHERE UPPER(ORGANIZATION_ID) = UPPER(?))))",
        //                                  organizationId);
        //    count = baseDao.DoJDBCExecuteNonQuery("DELETE FROM NSX_FISH_IDEN_DETAIL WHERE SPECIES_SUMMARY_ID IN " +
        //                                  "(SELECT DISTINCT SPECIES_SUMMARY_ID FROM NSX_SPECIES_SUMMARY WHERE COLLECT_EVNT_ID IN " +
        //                                  "(SELECT DISTINCT COLLECT_EVNT_ID FROM NSX_COLLECT_EVNT WHERE UPPER(ORGANIZATION_ID) = UPPER(?)))",
        //                                  organizationId);
        //    count = baseDao.DoJDBCExecuteNonQuery("DELETE FROM NSX_FISH_IDEN_DETAIL WHERE INDV_FISH_DETAIL_ID IN " +
        //                                  "(SELECT DISTINCT INDV_FISH_DETAIL_ID FROM NSX_INDV_FISH_DETAIL WHERE SPECIES_SUMMARY_ID IN " +
        //                                  "(SELECT DISTINCT SPECIES_SUMMARY_ID FROM NSX_SPECIES_SUMMARY WHERE COLLECT_EVNT_ID IN " +
        //                                  "(SELECT DISTINCT COLLECT_EVNT_ID FROM NSX_COLLECT_EVNT WHERE UPPER(ORGANIZATION_ID) = UPPER(?))))",
        //                                  organizationId);
        //    count = baseDao.DoJDBCExecuteNonQuery("DELETE FROM NSX_FISH_IDEN_DETAIL WHERE SPECIES_SUMMARY_ID IN " +
        //                                  "(SELECT DISTINCT SPECIES_SUMMARY_ID FROM NSX_SPECIES_SUMMARY WHERE COLLECT_EVNT_ID IN " +
        //                                  "(SELECT DISTINCT COLLECT_EVNT_ID FROM NSX_COLLECT_EVNT WHERE UPPER(ORGANIZATION_ID) = UPPER(?)))",
        //                                  organizationId);
        //    count = baseDao.DoJDBCExecuteNonQuery("DELETE FROM NSX_COLLECT_EVNT WHERE UPPER(ORGANIZATION_ID) = UPPER(?)", organizationId);
        //}
        //public static void MergeLutsToDatabase(Organization org, IObjectsToDatabase objectsToDatabase, SpringBaseDao baseDao,
        //                                       IMappingContext mappingContext)
        //{
        //    Dictionary<Type, List<BaseLut>> mergeLuts = new Dictionary<Type, List<BaseLut>>(30);

        //    List<BaseLut> insertLuts = new List<BaseLut>(40);
        //    UniqueMergeHashCodesComparer comparer = new UniqueMergeHashCodesComparer(mappingContext);
        //    Dictionary<Type, List<string>> existingPrimaryKeysForType = new Dictionary<Type, List<string>>(4);

        //    CollectionUtils.ForEach(org.CalculatedMetric, delegate(CalculatedMetric cm)
        //    {
        //        if (!string.IsNullOrEmpty(cm.ContactName))
        //        {
        //            AddLutToInsertList(baseDao, mappingContext, insertLuts, existingPrimaryKeysForType, comparer,
        //                               new LutPerson(cm.ContactName));
        //        }
        //    });
        //    CollectionUtils.ForEach(org.CollectionEvent, delegate(CollectionEvent ce)
        //    {
        //        if (!string.IsNullOrEmpty(ce.ProjectManagerName))
        //        {
        //            AddLutToInsertList(baseDao, mappingContext, insertLuts, existingPrimaryKeysForType, comparer,
        //                               new LutPerson(ce.ProjectManagerName));
        //        }
        //        if (!string.IsNullOrEmpty(ce.QAPersonName))
        //        {
        //            AddLutToInsertList(baseDao, mappingContext, insertLuts, existingPrimaryKeysForType, comparer,
        //                               new LutPerson(ce.QAPersonName));
        //        }
        //        if (!string.IsNullOrEmpty(ce.PhotoRepositoryDescription))
        //        {
        //            AddLutToInsertList(baseDao, mappingContext, insertLuts, existingPrimaryKeysForType, comparer,
        //                               new LutPhotoRepository(ce.PhotoRepositoryDescription));
        //        }
        //    });
        //    if (insertLuts.Count > 0)
        //    {
        //        objectsToDatabase.SaveToDatabase(insertLuts, baseDao, false, mappingContext, false);
        //    }
        //}
        //private class UniqueMergeHashCodesComparer : IComparer<BaseLut>
        //{
        //    private IMappingContext m_MappingContext;
        //    public UniqueMergeHashCodesComparer(IMappingContext mappingContext)
        //    {
        //        m_MappingContext = mappingContext;
        //    }
        //    public int Compare(BaseLut x, BaseLut y)
        //    {
        //        int xUniqueMergeHashCode = x.GetUniqueMergeHashCode(m_MappingContext);
        //        int yUniqueMergeHashCode = y.GetUniqueMergeHashCode(m_MappingContext);
        //        return xUniqueMergeHashCode.CompareTo(yUniqueMergeHashCode);
        //    }
        //}
        //private static void AddLutToInsertList(SpringBaseDao baseDao, IMappingContext mappingContext, List<BaseLut> insertLuts,
        //                                       Dictionary<Type, List<string>> existingPrimaryKeysForType,
        //                                       UniqueMergeHashCodesComparer comparer, BaseLut baseLut)
        //{
        //    Type lutType = baseLut.GetType();
        //    List<string> existingPrimaryKeys;
        //    if (!existingPrimaryKeysForType.TryGetValue(lutType, out existingPrimaryKeys))
        //    {
        //        existingPrimaryKeys = baseLut.LoadExistingSortedPKs(baseDao, mappingContext);
        //        existingPrimaryKeysForType[lutType] = existingPrimaryKeys;
        //    }
        //    baseLut.ExistingPrimaryKeysForIsUpdateSave = existingPrimaryKeys;
        //    if (!baseLut.IsUpdateSave(baseDao, mappingContext))
        //    {
        //        CollectionUtils.InsertIntoSortedList(insertLuts, baseLut, comparer);
        //    }
        //}
        //public static string CreateTableRowCountsString(Dictionary<string, int> tableRowCounts)
        //{
        //    if (CollectionUtils.IsNullOrEmpty(tableRowCounts))
        //    {
        //        return "None";
        //    }
        //    StringBuilder sb = new StringBuilder();
        //    foreach (KeyValuePair<string, int> pair in tableRowCounts)
        //    {
        //        if (sb.Length > 0)
        //        {
        //            sb.Append(", ");
        //        }
        //        sb.AppendFormat("{0} ({1})", pair.Key, pair.Value.ToString());
        //    }
        //    return sb.ToString();
        //}
        //public static NSX GenerateNsxObjectsFromSubmissionFile(IAppendAuditLogEvent appendAuditLogEvent, string submissionFilePath,
        //                                                       string sysTempFolderPath, ISerializationHelper serializationHelper,
        //                                                       ICompressionHelper compressionHelper, out string attachmentsFolderPath)
        //{
        //    string validationErrorsFile;
        //    return GenerateNsxObjectsFromSubmissionFile(appendAuditLogEvent, submissionFilePath, sysTempFolderPath, null, null, null,
        //                                                serializationHelper, compressionHelper, out attachmentsFolderPath,
        //                                                out validationErrorsFile);
        //}
        //public static NSX GenerateNsxObjectsFromSubmissionFile(IAppendAuditLogEvent appendAuditLogEvent, string submissionFilePath,
        //                                                       string sysTempFolderPath, Assembly xmlSchemaZippedResourceAssembly,
        //                                                       string xmlSchemaZippedQualifiedResourceName, string xmlSchemaRootFileName,
        //                                                       ISerializationHelper serializationHelper, ICompressionHelper compressionHelper,
        //                                                       out string attachmentsFolderPath, out string validationErrorsFile)
        //{
        //    NSX data = null;
        //    attachmentsFolderPath = null;
        //    string nsxFilePath = null;
        //    validationErrorsFile = null;
        //    try
        //    {
        //        attachmentsFolderPath = Path.Combine(sysTempFolderPath, Guid.NewGuid().ToString());
        //        Directory.CreateDirectory(attachmentsFolderPath);

        //        appendAuditLogEvent.AppendAuditLogEvent("Decompressing the NSX data to a temporary folder ...");
        //        try
        //        {
        //            compressionHelper.UncompressDirectory(submissionFilePath, attachmentsFolderPath);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new ArgException("An error occurred decompressing the NSX data: {0}", ExceptionUtils.GetDeepExceptionMessage(ex));
        //        }
        //        string[] xmlFiles = Directory.GetFiles(attachmentsFolderPath, NSX_FILE_PREFIX + "*.xml");
        //        if (xmlFiles.Length == 0)
        //        {
        //            throw new ArgException("Failed to locate an NSX xml file in the NSX data");
        //        }
        //        else if (xmlFiles.Length > 1)
        //        {
        //            throw new ArgException("More than one xml file was found in the NSX data");
        //        }
        //        nsxFilePath = xmlFiles[0];

        //        if (!string.IsNullOrEmpty(xmlSchemaZippedQualifiedResourceName))
        //        {
        //            validationErrorsFile =
        //                BaseWNOSPlugin.ValidateXmlFile(nsxFilePath, xmlSchemaZippedResourceAssembly, xmlSchemaZippedQualifiedResourceName,
        //                                               xmlSchemaRootFileName, sysTempFolderPath, appendAuditLogEvent, compressionHelper);

        //            if (validationErrorsFile != null)
        //            {
        //                FileUtils.SafeDeleteDirectory(attachmentsFolderPath);
        //                return null;
        //            }
        //        }

        //        appendAuditLogEvent.AppendAuditLogEvent("Deserializing the NSX data xml file ...");
        //        try
        //        {
        //            data = serializationHelper.Deserialize<NSX>(nsxFilePath);
        //        }
        //        catch (Exception ex)
        //        {
        //            appendAuditLogEvent.AppendAuditLogEvent("Failed to deserialize the NSX data xml file: {0}", ExceptionUtils.GetDeepExceptionMessage(ex));
        //            throw;
        //        }
        //        if (CollectionUtils.Count(data.Organization) < 1)
        //        {
        //            appendAuditLogEvent.AppendAuditLogEvent("The NSX data does not contain any organizations, so no elements will be stored in the database.");
        //            return null;
        //        }
        //        else
        //        {
        //            CollectionUtils.ForEach(data.Organization, delegate(Organization org)
        //            {
        //                CollectionUtils.ForEach(org.CollectionEvent, delegate(CollectionEvent ce)
        //                {
        //                    ce.ShareWithPartnersIndicator = true;
        //                });
        //                CollectionUtils.ForEach(org.CalculatedMetric, delegate(CalculatedMetric cm)
        //                {
        //                    cm.ShareWithPartnersIndicator = true;
        //                });
        //            });
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        FileUtils.SafeDeleteDirectory(attachmentsFolderPath);
        //        throw;
        //    }
        //    finally
        //    {
        //        FileUtils.SafeDeleteFile(nsxFilePath);
        //    }
        //    return data;
        //}
        //public const string PARAM_ORGANIZATION_ID_KEY = "OrganizationIdentifier";
        //public const string PARAM_BASIN_KEY = "Basin";
        //public const string PARAM_WRIA_KEY = "WRIA";
        //public const string PARAM_SPECIES_KEY = "SpeciesName";
        //public const string PARAM_START_DATE_KEY = "StartDate";
        //public const string PARAM_END_DATE_KEY = "EndDate";
        //public const string PARAM_DATA_CHANGED_AFTER_DATE_KEY = "DataChangedAfterDate";

        //public static char SPECIES_TYPE_CODES_SEPARATOR = ';';

        //public static string NSX_FILE_PREFIX = "__";

        //public const int MIN_QUERY_YEAR = 1900;
        //public const int MAX_QUERY_YEAR = 2050;
    }
}
