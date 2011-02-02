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
using System.Collections;
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
using System.Runtime.InteropServices;
using System.ComponentModel;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm;
using Windsor.Node2008.WNOSPlugin.CERS_12;

namespace Windsor.Node2008.WNOSPlugin.EIS_11
{
    [Serializable]
    public abstract class EISGenerateSubmission : EISPluginBase, ISolicitProcessor
    {
        protected IRequestManager _requestManager;
        protected IObjectsFromDatabase _objectsFromDatabase;

        protected string _authorName;
        protected string _organizationName;
        protected string _senderContactInfo;
        protected string _attachmentFolderPath;
        protected bool _isProductionSubmission;
        protected int _emissionsYear;
        protected SpringBaseDao _baseDao;
        protected DataRequest _dataRequest;

        protected enum EISConfigParams
        {
            None,
            [Description("Author Name")]
            AuthorName,
            [Description("Attachment Folder Path")]
            AttachmentFolderPath,
            [Description("Organization Name")]
            OrganizationName,
            [Description("Sender Contact Info")]
            SenderContactInfo,
        }
        protected enum EISDataSourceParams
        {
            None,
            [Description("Data Source")]
            DataSource,
        }
        protected enum EISServiceParams
        {
            None,
            [Description("EmissionsYear")]
            EmissionsYear,
            [Description("SubmissionType")]
            SubmissionType,
        }
        protected abstract DataCategory DataCategory
        {
            get;
        }

        public EISGenerateSubmission()
        {
            AppendConfigArguments<EISConfigParams>();

            AppendDataProviders<EISDataSourceParams>();
        }

        /// <summary>
        /// ProcessSolicit
        /// </summary>
        public virtual void ProcessSolicit(string requestId)
        {
            ProcessSolicitInit(requestId);

            GenerateSubmissionFileAndAddToTransaction(DataCategory);
        }

        /// <summary>
        /// ProcessSolicit
        /// </summary>
        protected virtual void ProcessSolicitInit(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);
        }
        protected override void LazyInit()
        {
            base.LazyInit();

            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _objectsFromDatabase);

            GetConfigParameter(EnumUtils.ToDescription(EISConfigParams.AuthorName), out _authorName);
            GetConfigParameter(EnumUtils.ToDescription(EISConfigParams.OrganizationName), out _organizationName);
            TryGetConfigParameter(EnumUtils.ToDescription(EISConfigParams.SenderContactInfo), ref _senderContactInfo);
            TryGetConfigParameter(EnumUtils.ToDescription(EISConfigParams.AttachmentFolderPath), ref _attachmentFolderPath);

            AppendAuditLogEvent("Config params: {0} ({1}), {2} ({3}), {4} ({5}), {6} ({7})", 
                                EnumUtils.ToDescription(EISConfigParams.AuthorName), _authorName, 
                                EnumUtils.ToDescription(EISConfigParams.OrganizationName), _organizationName,
                                EnumUtils.ToDescription(EISConfigParams.SenderContactInfo), _senderContactInfo ?? string.Empty,
                                EnumUtils.ToDescription(EISConfigParams.AttachmentFolderPath), _attachmentFolderPath ?? string.Empty);

            _baseDao = ValidateDBProvider(EnumUtils.ToDescription(EISDataSourceParams.DataSource), typeof(NamedNullMappingDataReader));
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            AppendAuditLogEvent("Validating request: {0}", _dataRequest);
            GetParameter(_dataRequest, EnumUtils.ToDescription(EISServiceParams.EmissionsYear), 0, out _emissionsYear);
            if ((_emissionsYear > DateTime.Now.Year) || (_emissionsYear < 1940))
            {
                throw new ArgumentException(string.Format("Out-of-range {0} specified: {1}", 
                                            EnumUtils.ToDescription(EISServiceParams.EmissionsYear),
                                            _emissionsYear));
            }
            string submissionType;
            GetParameter(_dataRequest, EnumUtils.ToDescription(EISServiceParams.SubmissionType), 1, out submissionType);
            if (string.Equals(submissionType, PRODUCTION_SUBMISSION_TYPE_NAME, StringComparison.InvariantCultureIgnoreCase))
            {
                _isProductionSubmission = true;
            }
            else if (string.Equals(submissionType, QA_SUBMISSION_TYPE_NAME, StringComparison.InvariantCultureIgnoreCase))
            {
                _isProductionSubmission = false;
            }
            else
            {
                throw new ArgumentException(string.Format("Invalid {0} specified: {1}, must be either \"{2}\" or \"{3}\"",
                                            EnumUtils.ToDescription(EISServiceParams.SubmissionType),
                                            submissionType, PRODUCTION_SUBMISSION_TYPE_NAME, QA_SUBMISSION_TYPE_NAME));
            }
            AppendAuditLogEvent("{0} ({1}), {2} ({3})", EnumUtils.ToDescription(EISServiceParams.EmissionsYear), _emissionsYear,
                                EnumUtils.ToDescription(EISServiceParams.SubmissionType), submissionType);
        }
        protected string GenerateSubmissionFileAndAddToTransaction(DataCategory dataCategory)
        {
            Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>();

            selectClauses.Add("CERS_CERS",
                new DbAppendSelectWhereClause(_baseDao, "DATA_CATEGORY = ? AND EMIS_YEAR = ?", dataCategory.ToString(),
                                              _emissionsYear));

            List<CERSDataType> dataList = _objectsFromDatabase.LoadFromDatabase<CERSDataType>(_baseDao, selectClauses);

            if (CollectionUtils.IsNullOrEmpty(dataList))
            {
                throw new ArgumentException(string.Format("No EIS data was found to submit for submission type \"{0}\"",
                                                          EnumUtils.ToDescription(dataCategory)));
            }
            else if (dataList.Count > 1)
            {
                throw new ArgumentException(string.Format("More than one set of EIS data was found for submission type \"{0}\"",
                                                          EnumUtils.ToDescription(dataCategory)));
            }
            else
            {
                CERSDataType data = dataList[0];
                AppendAuditLogEvent(GetSubmissionResultsString(data, dataCategory));
                return GenerateSubmissionFileAndAddToTransaction(data, _dataRequest.TransactionId, _authorName, _organizationName,
                                                                 _senderContactInfo, _isProductionSubmission,
                                                                 _attachmentFolderPath, _baseDao);
            }
        }
        protected string GetSubmissionResultsString(CERSDataType data, DataCategory dataCategory)
        {
            StringBuilder sb = new StringBuilder();
            if (data == null)
            {
                sb.AppendFormat("Did not find any EIS {0} submission data.", EnumUtils.ToDescription(dataCategory));
            }
            else
            {
                sb.AppendFormat("Found the following EIS {0} submission data: ", EnumUtils.ToDescription(dataCategory));
                int i = 0;
                AppendCountString("Facility Sites", data.FacilitySite, ++i == 1, sb);
                AppendCountString("Locations", data.Location, ++i == 1, sb);
                AppendCountString("Events", data.Event, ++i == 1, sb);
                AppendCountString("Quality Findings", data.QualityFinding, ++i == 1, sb);
            }
            return sb.ToString();
        }
        protected void AppendCountString(string collectionName, ICollection collection, bool isFirst,
                                         StringBuilder sb)
        {
            if (!isFirst)
            {
                sb.Append(", ");
            }
            int count = CollectionUtils.IsNullOrEmpty(collection) ? 0 : collection.Count;
            sb.AppendFormat("{0} {1}", count.ToString(), collectionName);
        }
    }
    [Serializable]
    public class EISGetFacilityInventory : EISGenerateSubmission
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.FacilityInventory;
            }
        }
    }
    [Serializable]
    public class EISGetEventEmissions : EISGenerateSubmission
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.Event;
            }
        }
    }
    [Serializable]
    public class EISGetOnroadEmissions : EISGenerateSubmission
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.Onroad;
            }
        }
    }
    [Serializable]
    public class EISGetNonroadEmissions : EISGenerateSubmission
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.Nonroad;
            }
        }
    }
    [Serializable]
    public class EISGetPointEmissions : EISGenerateSubmission
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.Point;
            }
        }
    }
    [Serializable]
    public class EISGetNonpointEmissions : EISGenerateSubmission
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.Nonpoint;
            }
        }
    }
    [Serializable]
    public class EISGetOnroadNonroadActivities : EISGenerateSubmission
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.OnroadNonroadActivity;
            }
        }
    }
}
