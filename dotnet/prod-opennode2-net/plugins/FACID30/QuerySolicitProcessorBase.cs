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
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Spring.Data.Common;
using Spring.Transaction.Support;
using Spring.Data.Core;
using System.ComponentModel;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm;
using Wintellect.PowerCollections;
using System.Text.RegularExpressions;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.FACID30
{
    [Serializable]
    public abstract class QuerySolicitProcessorBase : FACIDPluginBase
    {
        protected enum QueryParameter
        {
            [Description("Standard Environmental Interest Type")]
            StandardEnvironmentalInterestType = 0,

            [Description("ZIP Code")]
            ZIPCode,

            [Description("Tribal Land Code")]
            TribalLandCode,

            [Description("Federal Facility")]
            FederalFacility,

            [Description("Facility Name")]
            FacilityName,

            [Description("Facility Status")]
            FacilityStatus,

            [Description("SIC Code")]
            SICCode,

            [Description("NAICS Code")]
            NAICSCode,

            [Description("City Name")]
            CityName,

            [Description("State")]
            State,

            [Description("County Name")]
            CountyName,

            [Description("N Bounding Latitude")]
            NBoundingLatitude,

            [Description("S Bounding Latitude")]
            SBoundingLatitude,

            [Description("E Bounding Longitude")]
            EBoundingLongitude,

            [Description("W Bounding Longitude")]
            WBoundingLongitude,

            [Description("Change Date")]
            ChangeDate,

            [Description("Facility Site Identifier")]
            FacilitySiteIdentifier,

            [Description("Originating Partner Name")]
            OriginatingPartnerName,

            [Description("Information System Acronym Name")]
            InformationSystemAcronymName,

            [Description("Deleted Date")]
            DeletedDate,
            //Standard Environmental Interest Type, FacilityDataType.EnvironmentalInterestList[].EnvironmentalInterestTypeText, FACID_ENVR_INTR.ENVR_INTR_TYPE_TEXT
            //ZIP Code, FacilityDataType.LocationAddress.AddressPostalCode.Value, FACID_FAC.ADDR_POST_CODE_VAL
            //ZIP Code, FacilityDataType.MailingAddress.AddressPostalCode.Value, FACID_FAC.MAIL_ADDR_ADDR_POST_CODE_VAL
            //Tribal Land Code, FacilityDataType.LocationAddress.TribalLandIndicator, FACID_FAC.TRIB_LAND_INDI
            //Federal Facility, FacilityDataType.FacilitySiteIdentity.FederalFacilityIndicator, FACID_FAC.FED_FAC_INDI
            //Facility Name, FacilityDataType.FacilitySiteIdentity.FacilitySiteName, FACID_FAC.FAC_SITE_NAME
            //Facility status
            //SIC Code, FacilityDataType.SICList[].SICCode, FACID_FAC_FAC_SIC.SIC_CODE
            //NAICS Code, FacilityDataType.NAICSList[].FacilityNAICSCode, FACID_FAC_FAC_NAICS.FAC_NAICS_CODE
            //City Name, FacilityDataType.LocationAddress.LocalityName, FACID_FAC.LOCA_NAME
            //State, FacilityDataType.LocationAddress.StateIdentity.StateCode, FACID_FAC.STA_CODE
            //County Name, FacilityDataType.LocationAddress.CountyIdentity.CountyName, FACID_FAC.CNTY_NAME
            //N Bounding Latitude, etc., FacilityDataType.FacilityPrimaryGeographicLocationDescription.Point.Item.Text, FACID_FAC_PRI_GEO_LOC_DESC.LATITUDE, etc.
            //Change Date, FacilityDataType.DataSource.LastUpdatedDate, FACID_FAC.LAST_UPDT_DATE
            //Facility Site Identifier, FacilityDataType.FacilitySiteIdentity.FacilitySiteIdentifier.Value, FACID_FAC.FAC_SITE_IDEN_VAL
            //Originating Partner Name, FacilityDataType.DataSource.OriginatingPartnerName, FACID_FAC.ORIG_PART_NAME
            //Information System Acronym Name, FacilityDataType.DataSource.InformationSystemAcronymName, FACID_FAC.INFO_SYS_ACRO_NAME
        }
        protected string _headerAuthor;
        protected string _headerOrganization;
        protected string _headerContactInfo;
        protected string _payloadOperation;
        protected bool _addHeader;
        protected bool _validateXml;

        protected IList<decimal> _nBoundingLatitudes;
        protected IList<decimal> _sBoundingLatitudes;
        protected IList<decimal> _eBoundingLongitudes;
        protected IList<decimal> _wBoundingLongitudes;

        protected IObjectsFromDatabase _objectsFromDatabase;
        protected IDataCache _dataCache;
        protected TimeSpan _resultCacheDuration = TimeSpan.FromSeconds(0);

        private const string CACHE_STRING_SEP = "|||";

        protected const string PARAM_VALIDATE_XML_KEY = "ValidateXml";

        public QuerySolicitProcessorBase()
        {
            ConfigurationArguments.Add(CONFIG_ADD_HEADER, null);
            ConfigurationArguments.Add(CONFIG_AUTHOR, null);
            ConfigurationArguments.Add(CONFIG_ORGANIZATION, null);
            ConfigurationArguments.Add(CONFIG_CONTACT_INFO, null);
            ConfigurationArguments.Add(CONFIG_PAYLOAD_OPERATION, null);
            ConfigurationArguments.Add(CONFIG_RESULT_CACHE_DURATION, null);
        }

        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _objectsFromDatabase);

            TryGetConfigParameter(CONFIG_ADD_HEADER, ref _addHeader);
            if (_addHeader)
            {
                _headerAuthor = ValidateNonEmptyConfigParameter(CONFIG_AUTHOR);
                _headerOrganization = ValidateNonEmptyConfigParameter(CONFIG_ORGANIZATION);
                _headerContactInfo = ValidateNonEmptyConfigParameter(CONFIG_CONTACT_INFO);
                _payloadOperation = ValidateNonEmptyConfigParameter(CONFIG_PAYLOAD_OPERATION);
            }
            TryGetConfigParameter(CONFIG_RESULT_CACHE_DURATION, ref _resultCacheDuration);
            if (_resultCacheDuration.TotalSeconds > 0)
            {
                GetServiceImplementation(out _dataCache);
            }
        }
        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);

            if (!CollectionUtils.IsNullOrEmpty(_dataRequest.Parameters))
            {
                TryGetParameter(_dataRequest, PARAM_VALIDATE_XML_KEY, _dataRequest.Parameters.Count - 1, ref _validateXml);
            }
        }
        protected virtual void SaveHeaderDocument(object objectToSerialize, string filePath)
        {
            string filePathXml = SaveHeaderDocument(objectToSerialize);
            FileUtils.SafeDeleteFile(filePath);
            File.Move(filePathXml, filePath);
        }
        protected byte[] GetCachedData(string queryHashString, bool doUncompressData)
        {
            if (_dataCache != null)
            {
                try
                {
                    string cacheValue = _dataCache.GetString(queryHashString);
                    if (cacheValue != null)
                    {
                        string[] values = cacheValue.Split(new string[] { CACHE_STRING_SEP }, StringSplitOptions.RemoveEmptyEntries);
                        if (values.Length == 3)
                        {
                            byte[] content;
                            if (doUncompressData)
                            {
                                content = _documentManager.GetUncompressedContent(values[0], values[1]);
                            }
                            else
                            {
                                content = _documentManager.GetContent(values[0], values[1]);
                            }
                            if (content != null)
                            {
                                AppendAuditLogEvent("Query results found in cache, returning cached data ...");
                                AppendAuditLogEvent(values[2]);
                                return content;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
            return null;
        }
        protected virtual byte[] SaveHeaderDocumentToTransactionAndReturnBytes(object objectToSerialize, string queryHashString,
                                                                               string auditLog)
        {
            string filePath = SaveHeaderDocumentToTransaction(objectToSerialize, queryHashString, auditLog);
            return File.ReadAllBytes(filePath);
        }
        protected virtual string SaveHeaderDocumentToTransaction(object objectToSerialize, string queryHashString,
                                                                 string auditLog)
        {
            string filePath = SaveHeaderDocument(objectToSerialize);
            string docId =
                    _documentManager.AddDocument(_dataRequest.TransactionId, CommonTransactionStatusCode.Completed,
                                                 null, filePath);
            if ((_dataCache != null) && _dataCache.IsExpired(queryHashString))
            {
                string cacheValue = string.Format("{0}{1}{2}{3}{4}", _dataRequest.TransactionId, CACHE_STRING_SEP,
                                                  docId, CACHE_STRING_SEP, auditLog);
                _dataCache.CacheString(cacheValue, queryHashString, _resultCacheDuration);
            }
            return filePath;
        }
        protected virtual string SaveHeaderDocument(object objectToSerialize)
        {
            string tempXmlFilePath = _settingsProvider.NewTempFilePath(".xml");
            string tempXmlFilePathHeader = _settingsProvider.NewTempFilePath(".xml");

            if (_addHeader)
            {
                IHeaderDocumentHelper headerDocumentHelper;
                GetServiceImplementation(out headerDocumentHelper);
                headerDocumentHelper.Configure(_headerAuthor, _headerOrganization,
                                                FACID30_FLOW_NAME, FACID30_FLOW_NAME, _headerContactInfo,
                                                null);

                try
                {
                    _serializationHelper.Serialize(objectToSerialize, tempXmlFilePath);

                    if (_validateXml)
                    {
                        ValidateXmlFileAndAttachErrorsAndFileToTransaction(tempXmlFilePath, "xml_schema.xml_schema.zip",
                                                                           null, _dataRequest.TransactionId);
                    }
                    XmlDocument doc = new XmlDocument();
                    doc.Load(tempXmlFilePath);

                    headerDocumentHelper.AddPayload(_payloadOperation, doc.DocumentElement);

                    headerDocumentHelper.Serialize(tempXmlFilePathHeader);
                    return tempXmlFilePathHeader;
                }
                finally
                {
                    FileUtils.SafeDeleteFile(tempXmlFilePath);
                }
            }
            else
            {
                if (_validateXml)
                {
                    _serializationHelper.Serialize(objectToSerialize, tempXmlFilePath);

                    ValidateXmlFileAndAttachErrorsAndFileToTransaction(tempXmlFilePath, "xml_schema.xml_schema.zip",
                                                                       null, _dataRequest.TransactionId);

                    return tempXmlFilePath;
                }
                else
                {
                    _serializationHelper.Serialize(objectToSerialize, tempXmlFilePath);
                    return tempXmlFilePath;
                }
            }
        }
        protected byte[] GetCachedDataAndSaveToTransaction(string queryHashString, bool doUncompressData)
        {
            byte[] cachedData = GetCachedData(queryHashString, doUncompressData);
            if (cachedData != null)
            {
                CommonContentType type =
                    _compressionHelper.IsCompressed(cachedData) ? CommonContentType.ZIP : CommonContentType.XML;
                _documentManager.AddDocument(_dataRequest.TransactionId, CommonTransactionStatusCode.Completed,
                                             null, new Document(null, type, cachedData));
            }
            return cachedData;
        }
        protected T GetCachedData<T>(string queryHashString) where T : class
        {
            byte[] cachedData = GetCachedData(queryHashString, true);
            if (cachedData != null)
            {
                try
                {
                    return _serializationHelper.Deserialize<T>(cachedData);
                }
                catch (Exception)
                {
                }
            }
            return null;
        }
        protected virtual byte[] DoFacilityIndexQuery(string requestId)
        {
            int rowCount;
            bool isLast;
            return DoFacilityIndexQuery(requestId, false, out rowCount, out isLast);
        }
        protected virtual byte[] DoFacilityIndexQuery(string requestId, out int rowCount, out bool isLast)
        {
            return DoFacilityIndexQuery(requestId, true, out rowCount, out isLast);
        }
        protected virtual byte[] DoFacilityIndexQuery(string requestId, bool doUncompressData,
                                                      out int rowCount, out bool isLast)
        {
            ProcessRequestInit(requestId);

            string queryHashString;
            MultiDictionary<QueryParameter, object> normalizedQueryParameters = GetNormalizedQueryParameters(out queryHashString);

            byte[] byteData = GetCachedDataAndSaveToTransaction(queryHashString, doUncompressData);
            if (byteData != null)
            {
                rowCount = 0;
                isLast = true;
            }
            else
            {

                Dictionary<string, DbAppendSelectWhereClause> selectClauses = CreateFacilityDetailsDbParameters(normalizedQueryParameters,
                                                                                                                false);

                List<FacilityDetailsDataType> list = _objectsFromDatabase.LoadFromDatabase<FacilityDetailsDataType>(_baseDao, selectClauses);

                FacilityDetailsDataType detailsData = FilterFacilityDetailsQueryResults(list, out rowCount, out isLast);

                FacilityIndexDataType data = ConvertFacilityDetailsToFacilityIndex(detailsData);

                string auditLog;

                if ((data == null) || CollectionUtils.IsNullOrEmpty(data.FacilitySummaryList))
                {
                    auditLog = "Did not find any facilities that matched the query.";
                }
                else
                {
                    auditLog = string.Format("Found {0} facilities that matched the query.",
                                             data.FacilitySummaryList.Length.ToString());
                }
                AppendAuditLogEvent(auditLog);
                byteData = SaveHeaderDocumentToTransactionAndReturnBytes(data, queryHashString, auditLog);
            }
            return byteData;
        }
        protected virtual byte[] DoFacilityDetailsQuery(string requestId)
        {
            int rowCount;
            bool isLast;
            return DoFacilityDetailsQuery(requestId, false, out rowCount, out isLast);
        }
        protected virtual byte[] DoFacilityDetailsQuery(string requestId, out int rowCount, out bool isLast)
        {
            return DoFacilityDetailsQuery(requestId, true, out rowCount, out isLast);
        }
        protected virtual byte[] DoFacilityDetailsQuery(string requestId, bool doUncompressData,
                                                        out int rowCount, out bool isLast)
        {
            ProcessRequestInit(requestId);

            string queryHashString;
            MultiDictionary<QueryParameter, object> normalizedQueryParameters = GetNormalizedQueryParameters(out queryHashString);

            byte[] byteData = GetCachedDataAndSaveToTransaction(queryHashString, doUncompressData);
            if (byteData != null)
            {
                rowCount = 0;
                isLast = true;
            }
            else
            {
                Dictionary<string, DbAppendSelectWhereClause> selectClauses = CreateFacilityDetailsDbParameters(normalizedQueryParameters,
                                                                                                                true);

                List<FacilityDetailsDataType> list = _objectsFromDatabase.LoadFromDatabase<FacilityDetailsDataType>(_baseDao, selectClauses);

                FacilityDetailsDataType data = FilterFacilityDetailsQueryResults(list, out rowCount, out isLast);

                string auditLog;

                if ((data == null) || CollectionUtils.IsNullOrEmpty(data.FacilityList))
                {
                    auditLog = "Did not find any facilities that matched the query.";
                }
                else
                {
                    int affiliateCount = CollectionUtils.IsNullOrEmpty(data.AffiliateList) ? 0 :
                        data.AffiliateList.Length;
                    auditLog = string.Format("Found {0} facilities and {1} affiliates that matched the query.",
                                             data.FacilityList.Length.ToString(), affiliateCount.ToString());
                }
                AppendAuditLogEvent(auditLog);
                byteData = SaveHeaderDocumentToTransactionAndReturnBytes(data, queryHashString, auditLog);
            }
            return byteData;
        }
        protected virtual byte[] DoFacilityInterestQuery(string requestId)
        {
            int rowCount;
            bool isLast;
            return DoFacilityInterestQuery(requestId, false, out rowCount, out isLast);
        }
        protected virtual byte[] DoFacilityInterestQuery(string requestId, out int rowCount, out bool isLast)
        {
            return DoFacilityInterestQuery(requestId, true, out rowCount, out isLast);
        }
        protected virtual byte[] DoFacilityInterestQuery(string requestId, bool doUncompressData,
                                                         out int rowCount, out bool isLast)
        {
            ProcessRequestInit(requestId);

            string queryHashString;
            MultiDictionary<QueryParameter, object> normalizedQueryParameters = GetNormalizedQueryParameters(out queryHashString);

            byte[] byteData = GetCachedDataAndSaveToTransaction(queryHashString, doUncompressData);
            if (byteData != null)
            {
                rowCount = 0;
                isLast = true;
            }
            else
            {
                Dictionary<string, DbAppendSelectWhereClause> selectClauses = CreateFacilityDetailsDbParameters(normalizedQueryParameters,
                                                                                                                false);

                List<FacilityDetailsDataType> list = _objectsFromDatabase.LoadFromDatabase<FacilityDetailsDataType>(_baseDao, selectClauses);

                FacilityDetailsDataType detailsData = FilterFacilityDetailsQueryResults(list, out rowCount, out isLast);

                FacilityInterestDataType data = ConvertFacilityDetailsToFacilityInterest(detailsData);

                string auditLog;
                if ((data == null) || CollectionUtils.IsNullOrEmpty(data.FacilityInterestSummaryList))
                {
                    auditLog = "Did not find any facilities that matched the query.";
                }
                else
                {
                    auditLog = string.Format("Found {0} facilities that matched the query.",
                                             data.FacilityInterestSummaryList.Length.ToString());
                }
                AppendAuditLogEvent(auditLog);
                byteData = SaveHeaderDocumentToTransactionAndReturnBytes(data, queryHashString, auditLog);
            }
            return byteData;
        }
        protected virtual byte[] DoFacilityCountQuery(string requestId)
        {
            int rowCount;
            bool isLast;
            return DoFacilityCountQuery(requestId, false, out rowCount, out isLast);
        }
        protected virtual byte[] DoFacilityCountQuery(string requestId, out int rowCount, out bool isLast)
        {
            return DoFacilityCountQuery(requestId, true, out rowCount, out isLast);
        }
        protected virtual byte[] DoFacilityCountQuery(string requestId, bool doUncompressData,
                                                      out int rowCount, out bool isLast)
        {
            ProcessRequestInit(requestId);

            rowCount = 0;
            isLast = true;

            string queryHashString;
            MultiDictionary<QueryParameter, object> normalizedQueryParameters = GetNormalizedQueryParameters(out queryHashString);

            byte[] byteData = GetCachedDataAndSaveToTransaction(queryHashString, doUncompressData);
            if (byteData != null)
            {
            }
            else
            {
                Dictionary<string, DbAppendSelectWhereClause> selectClauses = CreateFacilityDetailsDbParameters(normalizedQueryParameters,
                                                                                                                false);
                int count = 0;
                _baseDao.AdoTemplate.ClassicAdoTemplate.Execute(delegate(IDbCommand command)
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();
                    DbAppendSelectWhereClause facTableClause;
                    object rtnVal;
                    if ((selectClauses != null) && selectClauses.TryGetValue("FACID_FAC", out facTableClause))
                    {
                        command.CommandText = string.Format("SELECT COUNT(*) FROM FACID_FAC WHERE {0}", facTableClause.SelectWhereQuery);
                        if (facTableClause.SelectWhereParameters != null)
                        {
                            foreach (IDataParameter parameter in facTableClause.SelectWhereParameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }
                        rtnVal = command.ExecuteScalar();
                    }
                    else
                    {
                        command.CommandText = "SELECT COUNT(*) FROM FACID_FAC";
                        rtnVal = command.ExecuteScalar();
                    }
                    int rtnValInt = (int)Convert.ChangeType(rtnVal, typeof(int));
                    count = rtnValInt;
                    return null;
                });

                FacilityCountDataType data = new FacilityCountDataType();

                string auditLog;
                if (count == 0)
                {
                    data.FacilityCountMeasure = "0";
                    auditLog = "Did not find any facilities that matched the query.";
                }
                else
                {
                    data.FacilityCountMeasure = count.ToString();
                    auditLog = string.Format("Found {0} facilities that matched the query.",
                                             count.ToString());
                }
                AppendAuditLogEvent(auditLog);
                byteData = SaveHeaderDocumentToTransactionAndReturnBytes(data, queryHashString, auditLog);
            }
            return byteData;
        }
        protected virtual FacilityDetailsDataType FilterFacilityDetailsQueryResults(List<FacilityDetailsDataType> list,
                                                                                    out int rowCount, out bool isLast)
        {
            FacilityDetailsDataType facilityDetails = FacIdHelper.CombineFacilityDetailsQueryResults(list);
            isLast = true;
            rowCount = (facilityDetails.FacilityList != null) ? facilityDetails.FacilityList.Length : 0;
            return facilityDetails;
        }
        protected virtual FacilityIndexDataType ConvertFacilityDetailsToFacilityIndex(FacilityDetailsDataType facilityDetails)
        {
            FacilityIndexDataType facilityIndex = new FacilityIndexDataType();
            if (!CollectionUtils.IsNullOrEmpty(facilityDetails.FacilityList))
            {
                List<FacilitySummaryDataType> rtnList = new List<FacilitySummaryDataType>(facilityDetails.FacilityList.Length);
                foreach (FacilityDataType facility in facilityDetails.FacilityList)
                {
                    FacilitySummaryDataType facilitySummary = new FacilitySummaryDataType();
                    facilitySummary.DataSource = facility.DataSource;
                    facilitySummary.FacilityLocationAddress =
                        FacilityLocationAddressDataType.FromLocationAddress(facility.LocationAddress);
                    facilitySummary.FacilitySiteIdentifier = facility.FacilitySiteIdentity.FacilitySiteIdentifier;
                    facilitySummary.FacilitySiteName = facility.FacilitySiteIdentity.FacilitySiteName;
                    facilitySummary.FacilitySummaryGeographicLocation = (facility.FacilityPrimaryGeographicLocationDescription == null) ? null :
                        new FacilitySummaryGeographicLocationDataType(facility.FacilityPrimaryGeographicLocationDescription);
                    facilitySummary.FacilityURLText = facility.FacilityURLText;
                    rtnList.Add(facilitySummary);
                }
                facilityIndex.FacilitySummaryList = rtnList.ToArray();
            }
            return facilityIndex;
        }

        protected virtual FacilityInterestDataType ConvertFacilityDetailsToFacilityInterest(FacilityDetailsDataType facilityDetails)
        {
            FacilityInterestDataType facilityInterest = new FacilityInterestDataType();
            if (!CollectionUtils.IsNullOrEmpty(facilityDetails.FacilityList))
            {
                List<FacilityInterestSummaryDataType> rtnList = new List<FacilityInterestSummaryDataType>(facilityDetails.FacilityList.Length);
                foreach (FacilityDataType facility in facilityDetails.FacilityList)
                {
                    FacilityInterestSummaryDataType facilitySummary = new FacilityInterestSummaryDataType();
                    facilitySummary.DataSource = facility.DataSource;
                    facilitySummary.FacilityLocationAddress =
                        FacilityLocationAddressDataType.FromLocationAddress(facility.LocationAddress);
                    facilitySummary.FacilitySiteIdentifier = facility.FacilitySiteIdentity.FacilitySiteIdentifier;
                    facilitySummary.FacilitySiteName = facility.FacilitySiteIdentity.FacilitySiteName;
                    facilitySummary.FacilitySummaryGeographicLocation = (facility.FacilityPrimaryGeographicLocationDescription == null) ? null :
                        new FacilitySummaryGeographicLocationDataType(facility.FacilityPrimaryGeographicLocationDescription);
                    facilitySummary.FacilityURLText = facility.FacilityURLText;
                    if (!CollectionUtils.IsNullOrEmpty(facility.EnvironmentalInterestList))
                    {
                        List<EnvironmentalInterestSummaryDataType> envIntSummList = new List<EnvironmentalInterestSummaryDataType>(facility.EnvironmentalInterestList.Length);
                        foreach (EnvironmentalInterestDataType envInt in facility.EnvironmentalInterestList)
                        {
                            EnvironmentalInterestSummaryDataType envIntSumm = new EnvironmentalInterestSummaryDataType();
                            envIntSumm.DataSource = envInt.DataSource;
                            envIntSumm.EnvironmentalInterestIdentifier = envInt.EnvironmentalInterestIdentifier;
                            envIntSumm.EnvironmentalInterestTypeText = envInt.EnvironmentalInterestTypeText;
                            envIntSumm.EnvironmentalInterestURLText = envInt.EnvironmentalInterestURLText;
                            envIntSummList.Add(envIntSumm);
                        }
                        facilitySummary.EnvironmentalInterestSummaryList = envIntSummList.ToArray();
                    }
                    rtnList.Add(facilitySummary);
                }
                facilityInterest.FacilityInterestSummaryList = rtnList.ToArray();
            }
            return facilityInterest;
        }

        protected static string GetFacilityId(FacilityInterestSummaryDataType facility)
        {
            if ((facility != null) && (facility.FacilitySiteIdentifier != null) &&
                 !string.IsNullOrEmpty(facility.FacilitySiteIdentifier.Value))
            {
                return facility.FacilitySiteIdentifier.Value;
            }
            return null;
        }
        protected virtual string GetServiceNameFromDataRequest()
        {
            int index = _dataRequest.Service.PluginInfo.ImplementingClassName.LastIndexOf('.');
            string className = _dataRequest.Service.PluginInfo.ImplementingClassName.Substring(index + 1);
            return className.ToUpper() + "_V3.0";
        }
        protected MultiDictionary<QueryParameter, object> GetNormalizedQueryParameters(out string queryHashString)
        {
            string serviceNameUpper = GetServiceNameFromDataRequest();
            MultiDictionary<QueryParameter, object> rtnMap = null;
            if (!CollectionUtils.IsNullOrEmpty(_dataRequest.Parameters))
            {
                rtnMap = new MultiDictionary<QueryParameter, object>(true);
                if (_dataRequest.Parameters.IsByName)
                {
                    switch (serviceNameUpper)
                    {
                        case "GETFACILITYCOUNT_V3.0":
                        case "GETFACILITYLIST_V3.0":
                        case "GETFACILITY_V3.0":
                        case "GETFACILITYINTEREST_V3.0":
                            foreach (KeyValuePair<string, string> pair in _dataRequest.Parameters.NameValuePairs)
                            {
                                if (!string.Equals(pair.Key, PARAM_VALIDATE_XML_KEY, StringComparison.OrdinalIgnoreCase))
                                {
                                    QueryParameter paramEnum;
                                    if (!EnumUtils.FromDescription(pair.Key, out paramEnum))
                                    {
                                        throw new ArgumentException(string.Format("Unrecognized query parameter name specified: {0}", pair.Key));
                                    }
                                    if (!string.IsNullOrEmpty(pair.Value))
                                    {
                                        rtnMap.Add(paramEnum, pair.Value);
                                    }
                                }
                            }
                            break;
                        case "GETFACILITYBYID_V3.0":
                            {
                                string value;
                                GetNonEmptyStringParameterByName(_dataRequest,
                                                                 EnumUtils.ToDescription(QueryParameter.FacilitySiteIdentifier),
                                                                 out value);
                                rtnMap.Add(QueryParameter.FacilitySiteIdentifier, value);
                                GetNonEmptyStringParameterByName(_dataRequest,
                                                                 EnumUtils.ToDescription(QueryParameter.OriginatingPartnerName),
                                                                 out value);
                                rtnMap.Add(QueryParameter.OriginatingPartnerName, value);
                                GetNonEmptyStringParameterByName(_dataRequest,
                                                                 EnumUtils.ToDescription(QueryParameter.InformationSystemAcronymName),
                                                                 out value);
                                rtnMap.Add(QueryParameter.InformationSystemAcronymName, value);
                            }
                            break;
                        case "GETDELETEDFACILITYBYCHANGEDATE_V3.0":
                        case "GETFACILITYBYCHANGEDATE_V3.0":
                            {
                                string value;
                                GetNonEmptyStringParameterByName(_dataRequest,
                                                                 EnumUtils.ToDescription(QueryParameter.ChangeDate),
                                                                 out value);
                                if (serviceNameUpper == "GETDELETEDFACILITYBYCHANGEDATE_V3.0")
                                {
                                    rtnMap.Add(QueryParameter.DeletedDate, value);
                                }
                                else
                                {
                                    rtnMap.Add(QueryParameter.ChangeDate, value);
                                }
                                if (TryGetNonEmptyStringParameterByName(_dataRequest,
                                                                        EnumUtils.ToDescription(QueryParameter.OriginatingPartnerName),
                                                                        ref value))
                                {
                                    rtnMap.Add(QueryParameter.OriginatingPartnerName, value);
                                }
                                if (TryGetNonEmptyStringParameterByName(_dataRequest,
                                                                        EnumUtils.ToDescription(QueryParameter.InformationSystemAcronymName),
                                                                        ref value))
                                {
                                    rtnMap.Add(QueryParameter.InformationSystemAcronymName, value);
                                }
                            }
                            break;
                        default:
                            throw new ArgumentException(string.Format("Unrecognized data service name: {0}", _dataRequest.Service.Name));
                    }
                }
                else
                {
                    switch (serviceNameUpper)
                    {
                        case "GETFACILITYCOUNT_V3.0":
                        case "GETFACILITYLIST_V3.0":
                        case "GETFACILITY_V3.0":
                        case "GETFACILITYINTEREST_V3.0":
                            foreach (int i in Enum.GetValues(typeof(QueryParameter)))
                            {
                                if (i >= _dataRequest.Parameters.Count)
                                {
                                    break;
                                }
                                string value = null;
                                if (TryGetNonEmptyStringParameterByIndex(_dataRequest, i, ref value))
                                {
                                    rtnMap.Add((QueryParameter)i, value);
                                }
                            }
                            break;
                        case "GETFACILITYBYID_V3.0":
                            {
                                string value;
                                GetNonEmptyStringParameterByIndex(_dataRequest, 0, out value);
                                rtnMap.Add(QueryParameter.FacilitySiteIdentifier, value);
                                GetNonEmptyStringParameterByIndex(_dataRequest, 1, out value);
                                rtnMap.Add(QueryParameter.OriginatingPartnerName, value);
                                GetNonEmptyStringParameterByIndex(_dataRequest, 2, out value);
                                rtnMap.Add(QueryParameter.InformationSystemAcronymName, value);
                            }
                            break;
                        case "GETDELETEDFACILITYBYCHANGEDATE_V3.0":
                        case "GETFACILITYBYCHANGEDATE_V3.0":
                            {
                                string value;
                                GetNonEmptyStringParameterByIndex(_dataRequest, 0, out value);
                                if (serviceNameUpper == "GETDELETEDFACILITYBYCHANGEDATE_V3.0")
                                {
                                    rtnMap.Add(QueryParameter.DeletedDate, value);
                                }
                                else
                                {
                                    rtnMap.Add(QueryParameter.ChangeDate, value);
                                }
                                if (TryGetNonEmptyStringParameterByIndex(_dataRequest, 1, ref value))
                                {
                                    rtnMap.Add(QueryParameter.OriginatingPartnerName, value);
                                }
                                if (TryGetNonEmptyStringParameterByIndex(_dataRequest, 2, ref value))
                                {
                                    rtnMap.Add(QueryParameter.InformationSystemAcronymName, value);
                                }
                            }
                            break;
                        default:
                            throw new ArgumentException(string.Format("Unrecognized data service name: {0}", _dataRequest.Service.Name));
                    }
                }
                ValidateBoundingParams(rtnMap);
                ConvertDateParams(rtnMap, QueryParameter.ChangeDate);
                ConvertDateParams(rtnMap, QueryParameter.DeletedDate);
                SplitStringParams(rtnMap, QueryParameter.StandardEnvironmentalInterestType);
                SplitStringParams(rtnMap, QueryParameter.SICCode);
                SplitStringParams(rtnMap, QueryParameter.NAICSCode);
            }
            else
            {
                switch (serviceNameUpper)
                {
                    case "GETFACILITYBYID_V3.0":
                        throw new ArgumentException(string.Format("{0}, {1}, and {2} query parameters are required",
                                                                  EnumUtils.ToDescription(QueryParameter.FacilitySiteIdentifier),
                                                                  EnumUtils.ToDescription(QueryParameter.OriginatingPartnerName),
                                                                  EnumUtils.ToDescription(QueryParameter.InformationSystemAcronymName)));
                    case "GETDELETEDFACILITYBYCHANGEDATE_V3.0":
                    case "GETFACILITYBYCHANGEDATE_V3.0":
                        throw new ArgumentException(string.Format("{0} query parameter is required",
                                                                  EnumUtils.ToDescription(QueryParameter.ChangeDate)));
                }
            }
            string auditString;
            if (CollectionUtils.IsNullOrEmpty(rtnMap))
            {
                rtnMap = null;
                auditString = "Query parameters: NONE";
            }
            else
            {
                auditString = string.Format("Query parameters: {0}", rtnMap.ToString());
            }
            queryHashString = _dataRequest.Service.Name + "_" + Math.Abs(auditString.GetHashCode()).ToString();
            AppendAuditLogEvent(auditString);
            return rtnMap;
        }
        protected virtual Dictionary<string, DbAppendSelectWhereClause>
            CreateFacilityDetailsDbParameters(MultiDictionary<QueryParameter, object> normalizedQueryParameters,
                                              bool includeAffiliates)
        {
            TableQueryParamsInfoList tableParams = new TableQueryParamsInfoList();
            AppendDbQueryParam("FACID_FAC", "ADDR_POST_CODE_VAL LIKE CONCAT(?, '%')",
                               QueryParameter.ZIPCode, normalizedQueryParameters, tableParams);
            AppendDbQueryParam("FACID_FAC", "TRIB_LAND_INDI",
                               QueryParameter.TribalLandCode, normalizedQueryParameters, tableParams);
            AppendDbQueryParam("FACID_FAC", "FED_FAC_INDI",
                               QueryParameter.FederalFacility, normalizedQueryParameters, tableParams);
            AppendDbQueryLikeParam("FACID_FAC", "FAC_SITE_NAME",
                                   QueryParameter.FacilityName, normalizedQueryParameters, tableParams);
            AppendDbQueryParam("FACID_FAC", "FAC_ACTIVE_INDI",
                               QueryParameter.FacilityStatus, normalizedQueryParameters, tableParams);
            AppendDbQueryParam("FACID_FAC", "LOCA_NAME",
                               QueryParameter.CityName, normalizedQueryParameters, tableParams);
            AppendDbQueryParam("FACID_FAC", "STA_CODE",
                               QueryParameter.State, normalizedQueryParameters, tableParams);
            AppendDbQueryParam("FACID_FAC", "CNTY_NAME",
                               QueryParameter.CountyName, normalizedQueryParameters, tableParams);

            AppendDbQueryParam("FACID_FAC", "FAC_SITE_IDEN_VAL",
                               QueryParameter.FacilitySiteIdentifier, normalizedQueryParameters, tableParams);
            AppendDbQueryParam("FACID_FAC", "ORIG_PART_NAME",
                               QueryParameter.OriginatingPartnerName, normalizedQueryParameters, tableParams);
            AppendDbQueryParam("FACID_FAC", "INFO_SYS_ACRO_NAME",
                               QueryParameter.InformationSystemAcronymName, normalizedQueryParameters, tableParams);
            AppendDbQueryParam("FACID_FAC", "LAST_UPDT_DATE >= ?",
                               QueryParameter.ChangeDate, normalizedQueryParameters, tableParams);
            AppendDbQueryParam("FACID_FAC", "DELETED_ON_DATE >= ?",
                               QueryParameter.DeletedDate, normalizedQueryParameters, tableParams);
            if (_nBoundingLatitudes != null)
            {
                StringBuilder sb = new StringBuilder(TableQueryParamsInfoList.LITERAL_SQL_PREFIX +
                                                     "FAC_ID IN (SELECT FAC_ID FROM FACID_FAC_PRI_GEO_LOC_DESC WHERE ");
                for (int i = 0; i < _nBoundingLatitudes.Count; ++i)
                {
                    if (i > 0)
                    {
                        sb.Append(" OR ");
                    }
                    if (_nBoundingLatitudes.Count > 1)
                    {
                        sb.Append("(");
                    }
                    sb.AppendFormat("LATITUDE <= {0} AND LATITUDE >= {1} AND LONGITUDE <= {2} AND LONGITUDE >= {3}",
                                    _nBoundingLatitudes[i].ToString(), _sBoundingLatitudes[i].ToString(),
                                    _eBoundingLongitudes[i].ToString(), _wBoundingLongitudes[i].ToString());
                    if (_nBoundingLatitudes.Count > 1)
                    {
                        sb.Append(")");
                    }
                }
                sb.Append(")");
                tableParams.Add("FACID_FAC", sb.ToString(), null);
            }
            ICollection<object> values;
            if (Contains(normalizedQueryParameters, QueryParameter.SICCode, out values))
            {
                StringBuilder sb1 = new StringBuilder("(FAC_ID IN (SELECT FAC_ID FROM FACID_FAC_FAC_SIC WHERE ");
                StringBuilder sb2 = new StringBuilder("(FAC_ID IN (SELECT FAC_ID FROM FACID_ENVR_INTR WHERE ENVR_INTR_ID IN (SELECT ENVR_INTR_ID FROM FACID_ENVR_INTR_FAC_SIC WHERE ");
                int i = 0;
                foreach (string value in values)
                {
                    if (i++ > 0)
                    {
                        sb1.Append(" OR ");
                        sb2.Append(" OR ");
                    }
                    if (values.Count > 1)
                    {
                        sb1.Append("(");
                        sb2.Append("(");
                    }
                    SpringBaseDao.ValidateAgainstSqlInjection(value);
                    sb1.AppendFormat("SIC_CODE LIKE '{0}%'", value);
                    sb2.AppendFormat("SIC_CODE LIKE '{0}%'", value);
                    if (values.Count > 1)
                    {
                        sb1.Append(")");
                        sb2.Append(")");
                    }
                }
                sb1.Append("))");
                sb2.Append(")))");
                tableParams.Add("FACID_FAC", TableQueryParamsInfoList.LITERAL_SQL_PREFIX +
                                sb1.ToString() + " OR " + sb2.ToString(), null);
            }
            if (Contains(normalizedQueryParameters, QueryParameter.NAICSCode, out values))
            {
                StringBuilder sb1 = new StringBuilder("(FAC_ID IN (SELECT FAC_ID FROM FACID_FAC_FAC_NAICS WHERE ");
                StringBuilder sb2 = new StringBuilder("(FAC_ID IN (SELECT FAC_ID FROM FACID_ENVR_INTR WHERE ENVR_INTR_ID IN (SELECT ENVR_INTR_ID FROM FACID_ENVR_INTR_FAC_NAICS WHERE ");
                int i = 0;
                foreach (string value in values)
                {
                    if (i++ > 0)
                    {
                        sb1.Append(" OR ");
                        sb2.Append(" OR ");
                    }
                    if (values.Count > 1)
                    {
                        sb1.Append("(");
                        sb2.Append("(");
                    }
                    SpringBaseDao.ValidateAgainstSqlInjection(value);
                    sb1.AppendFormat("FAC_NAICS_CODE LIKE '{0}%'", value);
                    sb2.AppendFormat("FAC_NAICS_CODE LIKE '{0}%'", value);
                    if (values.Count > 1)
                    {
                        sb1.Append(")");
                        sb2.Append(")");
                    }
                }
                sb1.Append("))");
                sb2.Append(")))");
                tableParams.Add("FACID_FAC", TableQueryParamsInfoList.LITERAL_SQL_PREFIX +
                                sb1.ToString() + " OR " + sb2.ToString(), null);
            }
            if (Contains(normalizedQueryParameters, QueryParameter.StandardEnvironmentalInterestType, out values))
            {
                StringBuilder sb = new StringBuilder("(FAC_ID IN (SELECT FAC_ID FROM FACID_ENVR_INTR WHERE ");
                int i = 0;
                foreach (string value in values)
                {
                    if (i++ > 0)
                    {
                        sb.Append(" OR ");
                    }
                    if (values.Count > 1)
                    {
                        sb.Append("(");
                    }
                    SpringBaseDao.ValidateAgainstSqlInjection(value);
                    sb.AppendFormat("ENVR_INTR_TYPE_TEXT = '{0}'", value);
                    if (values.Count > 1)
                    {
                        sb.Append(")");
                    }
                }
                sb.Append("))");
                tableParams.Add("FACID_FAC", TableQueryParamsInfoList.LITERAL_SQL_PREFIX + sb.ToString(), null);
            }
            Dictionary<string, DbAppendSelectWhereClause> selectClauses = tableParams.GetSelectWhereClauseList(_baseDao);
            if (includeAffiliates)
            {
                if (selectClauses != null)
                {
                    DbAppendSelectWhereClause facTableClause;
                    if (selectClauses.TryGetValue("FACID_FAC", out facTableClause))
                    {
                        string affiliateTableClause = string.Format("AFFL_IDEN IN (SELECT AFFL_IDEN FROM FACID_FAC_FAC_AFFL WHERE FAC_ID IN (SELECT FAC_ID FROM FACID_FAC WHERE {0}) UNION " +
                                                                                  "SELECT AFFL_IDEN FROM FACID_ENVR_INTR_FAC_AFFL WHERE ENVR_INTR_ID IN (SELECT ENVR_INTR_ID FROM FACID_ENVR_INTR WHERE FAC_ID IN (SELECT FAC_ID FROM FACID_FAC WHERE {0})))",
                                                                    facTableClause.SelectWhereQuery);

                        //string affiliateTableClause = string.Format("(AFFL_IDEN IN (SELECT AFFL_IDEN FROM FACID_FAC_FAC_AFFL WHERE FAC_ID IN (SELECT FAC_ID FROM FACID_FAC WHERE {0}))) OR " +
                        //                                            "(AFFL_IDEN IN (SELECT AFFL_IDEN FROM FACID_ENVR_INTR_FAC_AFFL WHERE ENVR_INTR_ID IN (SELECT ENVR_INTR_ID FROM FACID_ENVR_INTR WHERE FAC_ID IN (SELECT FAC_ID FROM FACID_FAC WHERE {0}))))",
                        //                                            facTableClause.SelectWhereQuery);
                        selectClauses.Add("FACID_AFFL", new DbAppendSelectWhereClause(affiliateTableClause, facTableClause.SelectWhereParameters));
                    }
                }
            }
            else
            {
                if (selectClauses == null)
                {
                    selectClauses = new Dictionary<string, DbAppendSelectWhereClause>();
                }
                selectClauses.Add("FACID_AFFL", new DbAppendSelectWhereClause("0 = 1", null));
            }
            return selectClauses;
        }
        protected virtual Dictionary<string, DbAppendSelectWhereClause>
            CreateFacilityInterestDbParameters(MultiDictionary<QueryParameter, object> normalizedQueryParameters)
        {
            TableQueryParamsInfoList tableParams = new TableQueryParamsInfoList();
            AppendDbQueryParam("FACID_FAC_INTR_SUMM", "FAC_SITE_IDEN_VAL",
                               QueryParameter.FacilitySiteIdentifier, normalizedQueryParameters, tableParams);
            AppendDbQueryParam("FACID_FAC_INTR_SUMM", "ORIG_PART_NAME",
                               QueryParameter.OriginatingPartnerName, normalizedQueryParameters, tableParams);
            AppendDbQueryParam("FACID_FAC_INTR_SUMM", "INFO_SYS_ACRO_NAME",
                               QueryParameter.InformationSystemAcronymName, normalizedQueryParameters, tableParams);
            return tableParams.GetSelectWhereClauseList(_baseDao);
        }
        private void AppendDbQueryParam(string tableName, string sqlQuery, QueryParameter queryParam,
                                          MultiDictionary<QueryParameter, object> normalizedQueryParameters,
                                          TableQueryParamsInfoList tableParams)
        {
            ICollection<object> values;
            if (Contains(normalizedQueryParameters, queryParam, out values))
            {
                foreach (object value in values)
                {
                    tableParams.Add(tableName, sqlQuery, value);
                }
            }
        }
        private void AppendDbQueryLikeParam(string tableName, string sqlQuery, QueryParameter queryParam,
                                              MultiDictionary<QueryParameter, object> normalizedQueryParameters,
                                              TableQueryParamsInfoList tableParams)
        {
            ICollection<object> values;
            if (Contains(normalizedQueryParameters, queryParam, out values))
            {
                foreach (string value in values)
                {
                    SpringBaseDao.ValidateAgainstSqlInjection(value);
                    tableParams.Add(tableName, TableQueryParamsInfoList.LIKE_SQL_PREFIX + sqlQuery, value);
                }
            }
        }
        private class TableQueryParamsInfoList : Dictionary<string, Dictionary<string, List<object>>>
        {
            public const string LIKE_SQL_PREFIX = "@!#1";
            public const string LITERAL_SQL_PREFIX = "@!#2";

            public TableQueryParamsInfoList()
                : base()
            {
            }

            public void Add(string tableName, string columnName, object columnValue)
            {
                Dictionary<string, List<object>> tableParams;
                if (!this.TryGetValue(tableName, out tableParams))
                {
                    tableParams = new Dictionary<string, List<object>>();
                    this[tableName] = tableParams;
                }
                List<object> columnValues;
                if (!tableParams.TryGetValue(columnName, out columnValues))
                {
                    columnValues = new List<object>();
                    tableParams[columnName] = columnValues;
                }
                columnValues.Add(columnValue);
            }
            public Dictionary<string, DbAppendSelectWhereClause> GetSelectWhereClauseList(SpringBaseDao baseDao)
            {
                Dictionary<string, DbAppendSelectWhereClause> whereClauses = null;
                foreach (KeyValuePair<string, Dictionary<string, List<object>>> tablePair in this)
                {
                    StringBuilder sb = new StringBuilder();
                    List<object> values = new List<object>();
                    foreach (KeyValuePair<string, List<object>> columnPair in tablePair.Value)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" AND ");
                        }
                        if (tablePair.Value.Count > 1)
                        {
                            sb.Append("(");
                        }
                        bool addedFirstValue = false;
                        foreach (object colValue in columnPair.Value)
                        {
                            bool addValueParam = true;
                            if (addedFirstValue)
                            {
                                sb.Append(" OR ");
                            }
                            if (columnPair.Value.Count > 1)
                            {
                                sb.Append("(");
                            }
                            if (columnPair.Key.Contains("?"))
                            {
                                sb.Append(columnPair.Key);
                            }
                            else if (columnPair.Key.StartsWith(LIKE_SQL_PREFIX))
                            {
                                sb.AppendFormat("UPPER({0}) LIKE UPPER('{1}')", columnPair.Key.Substring(LIKE_SQL_PREFIX.Length),
                                                colValue.ToString());
                                addValueParam = false;
                            }
                            else if (columnPair.Key.StartsWith(LITERAL_SQL_PREFIX))
                            {
                                sb.Append(columnPair.Key.Substring(LITERAL_SQL_PREFIX.Length));
                                addValueParam = false;
                            }
                            else
                            {
                                if (colValue is string)
                                {
                                    sb.AppendFormat("UPPER({0}) = UPPER(?)", columnPair.Key);
                                }
                                else
                                {
                                    sb.Append(columnPair.Key + " = ?");
                                }
                            }
                            if (columnPair.Value.Count > 1)
                            {
                                sb.Append(")");
                            }
                            if (addValueParam)
                            {
                                values.Add(colValue);
                            }
                            addedFirstValue = true;
                        }
                        if (tablePair.Value.Count > 1)
                        {
                            sb.Append(")");
                        }
                    }
                    IList<IDataParameter> whereParameters;
                    string whereClause = baseDao.LoadGenericParametersFromValueList(sb.ToString(), out whereParameters, values);
                    DbAppendSelectWhereClause whereQuery = new DbAppendSelectWhereClause(whereClause, whereParameters);
                    CollectionUtils.Add(tablePair.Key, whereQuery, ref whereClauses);
                }
                return whereClauses;
            }
        }
        protected static bool Contains(MultiDictionary<QueryParameter, object> map, QueryParameter param, out ICollection<object> values)
        {
            if (map == null)
            {
                values = null;
                return false;
            }
            if (map.ContainsKey(param))
            {
                values = map[param];
                if ((values == null) || (values.Count < 1))
                {
                    values = null;
                    return false;
                }
                return true;
            }
            values = null;
            return false;
        }
        protected void ValidateBoundingParams(MultiDictionary<QueryParameter, object> map)
        {
            ICollection<object> nBoundingLatitudes;
            ICollection<object> sBoundingLatitudes;
            ICollection<object> eBoundingLongitudes;
            ICollection<object> wBoundingLongitudes;
            Contains(map, QueryParameter.NBoundingLatitude, out nBoundingLatitudes);
            Contains(map, QueryParameter.SBoundingLatitude, out sBoundingLatitudes);
            Contains(map, QueryParameter.EBoundingLongitude, out eBoundingLongitudes);
            Contains(map, QueryParameter.WBoundingLongitude, out wBoundingLongitudes);
            if (!CollectionUtils.HaveSameLengths(nBoundingLatitudes, sBoundingLatitudes,
                                                 eBoundingLongitudes, wBoundingLongitudes))
            {
                throw new ArgumentException("One or more bounding query parameters are missing.  If any bounding parameters are specified, they must all be specified.");
            }
            if (nBoundingLatitudes == null)
            {
                return;
            }
            _nBoundingLatitudes = ConvertToDecimalList(nBoundingLatitudes);
            _sBoundingLatitudes = ConvertToDecimalList(sBoundingLatitudes);
            _eBoundingLongitudes = ConvertToDecimalList(eBoundingLongitudes);
            _wBoundingLongitudes = ConvertToDecimalList(wBoundingLongitudes);
        }
        protected List<decimal> ConvertToDecimalList(ICollection<object> values)
        {
            List<decimal> decimals = new List<decimal>(values.Count);
            foreach (object value in values)
            {
                decimals.Add(decimal.Parse(value.ToString()));
            }
            return decimals;
        }
        protected static void ConvertDateParams(MultiDictionary<QueryParameter, object> map,
                                                QueryParameter param)
        {
            ICollection<object> values;
            if (Contains(map, param, out values))
            {
                List<object> dates = new List<object>(values.Count);
                foreach (string value in values)
                {
                    dates.Add(DateTime.Parse(value));
                }
                map.ReplaceMany(param, dates);
            }
        }
        protected static void ConvertSqlWildcardParams(MultiDictionary<QueryParameter, object> map,
                                                       QueryParameter param)
        {
            ICollection<object> values;
            if (Contains(map, param, out values))
            {
                List<object> newValues = new List<object>(values.Count);
                foreach (string value in values)
                {
                    if ((value.IndexOf('%') >= 0) || (value.IndexOf('_') >= 0))
                    {
                        string regExPattern = "^" + value.Replace(".", "\\.").Replace("%", ".*").Replace("_", ".") + "$";
                        Regex regex = new Regex(regExPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
                        newValues.Add(regex);
                    }
                    else
                    {
                        newValues.Add(value);
                    }
                }
                map.ReplaceMany(param, newValues);
            }
        }
        protected static void SplitStringParams(MultiDictionary<QueryParameter, object> map,
                                                QueryParameter param)
        {
            ICollection<object> values;
            if (Contains(map, param, out values))
            {
                List<object> strings = new List<object>(values.Count);
                foreach (string value in values)
                {
                    string[] splitStrings = value.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string splitString in splitStrings)
                    {
                        string trimmedString = splitString.Trim();
                        if (!string.IsNullOrEmpty(trimmedString))
                        {
                            strings.Add(trimmedString);
                        }
                    }
                }
                map.ReplaceMany(param, strings);
            }
        }
    }
}
