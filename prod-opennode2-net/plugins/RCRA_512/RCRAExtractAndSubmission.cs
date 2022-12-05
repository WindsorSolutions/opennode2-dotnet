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

namespace Windsor.Node2008.WNOSPlugin.RCRA_512
{
    [Serializable]
    public abstract class RCRAExtractAndSubmission<T> : BasePerformRCRASubmission<T> where T : class
    {
        protected enum ConfigArgs
        {
            None,
            [Description("Extract Stored Procedure Name")]
            StoredProcedureName,
            [Description("Execute Timeout (in seconds)")]
            ExecuteTimeout,
        }
        #region fields
        protected string _storedProcName;
        protected int _commandTimeout = 300;
        #endregion

        public RCRAExtractAndSubmission()
        {
            AppendConfigArguments<ConfigArgs>();
        }
        protected override void LazyInit()
        {
            base.LazyInit();
            
            TryGetConfigParameter(EnumUtils.ToDescription(ConfigArgs.StoredProcedureName), ref _storedProcName);
            TryGetConfigParameter(EnumUtils.ToDescription(ConfigArgs.ExecuteTimeout), ref _commandTimeout);
        }
        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);
        }

        protected override void PrepareForSubmission()
        {
            if (!string.IsNullOrEmpty(_storedProcName))
            {
                _scheduleRunDate =
                    ExecuteRCRAExtract.DoExtract(this, _baseDao, _storedProcName, _commandTimeout);
            }
            else
            {
                _scheduleRunDate = DateTime.Now;
            }
        }
    }
    [Serializable]
    public class RCRAHandlerExtractAndSubmission : RCRAExtractAndSubmission<HazardousWasteHandlerSubmissionDataType>
    {
        public RCRAHandlerExtractAndSubmission()
        {
            _submissionHistorySubmissionType = "HD";
        }
        protected override List<HazardousWasteHandlerSubmissionDataType> GetSubmissionData()
        {
            return _objectsFromDatabase.LoadFromDatabase<HazardousWasteHandlerSubmissionDataType>(_baseDao, null);
        }
        protected override void AppendAuditLogCountsString(HazardousWasteHandlerSubmissionDataType data)
        {
            AppendAuditLogEvent("Found {0} Handler element(s) to submit ...", CollectionUtils.Count(data.FacilitySubmission));
        }
    }
    [Serializable]
    public class RCRACMEExtractAndSubmission : RCRAExtractAndSubmission<HazardousWasteCMESubmissionDataType>
    {
        public RCRACMEExtractAndSubmission()
        {
            _submissionHistorySubmissionType = "CE";
        }
        protected override List<HazardousWasteCMESubmissionDataType> GetSubmissionData()
        {
            return _objectsFromDatabase.LoadFromDatabase<HazardousWasteCMESubmissionDataType>(_baseDao, null);
        }
        protected override void AppendAuditLogCountsString(HazardousWasteCMESubmissionDataType data)
        {
            AppendAuditLogEvent("Found {0} CM&E element(s) to submit ...", CollectionUtils.Count(data.CMEFacilitySubmission));
        }
    }
    [Serializable]
    public class RCRACorrectiveActionExtractAndSubmission : RCRAExtractAndSubmission<HazardousWasteCorrectiveActionDataType>
    {
        public RCRACorrectiveActionExtractAndSubmission()
        {
            _submissionHistorySubmissionType = "CA";
        }
        protected override List<HazardousWasteCorrectiveActionDataType> GetSubmissionData()
        {
            return _objectsFromDatabase.LoadFromDatabase<HazardousWasteCorrectiveActionDataType>(_baseDao, null);
        }
        protected override void AppendAuditLogCountsString(HazardousWasteCorrectiveActionDataType data)
        {
            AppendAuditLogEvent("Found {0} Corrective Action element(s) to submit ...", CollectionUtils.Count(data.CorrectiveActionFacilitySubmission));
        }
    }
    [Serializable]
    public class RCRAPermitExtractAndSubmission : RCRAExtractAndSubmission<HazardousWastePermitDataType>
    {
        public RCRAPermitExtractAndSubmission()
        {
            _submissionHistorySubmissionType = "PM";
        }
        protected override List<HazardousWastePermitDataType> GetSubmissionData()
        {
            return _objectsFromDatabase.LoadFromDatabase<HazardousWastePermitDataType>(_baseDao, null);
        }
        protected override void AppendAuditLogCountsString(HazardousWastePermitDataType data)
        {
            AppendAuditLogEvent("Found {0} Permitting element(s) to submit ...", CollectionUtils.Count(data.PermitFacilitySubmission));
        }
    }
    [Serializable]
    public class RCRAFinancialAssuranceExtractAndSubmission : RCRAExtractAndSubmission<FinancialAssuranceSubmissionDataType>
    {
        public RCRAFinancialAssuranceExtractAndSubmission()
        {
            _submissionHistorySubmissionType = "FA";
        }
        protected override List<FinancialAssuranceSubmissionDataType> GetSubmissionData()
        {
            return _objectsFromDatabase.LoadFromDatabase<FinancialAssuranceSubmissionDataType>(_baseDao, null);
        }
        protected override void AppendAuditLogCountsString(FinancialAssuranceSubmissionDataType data)
        {
            AppendAuditLogEvent("Found {0} Financial Assurance element(s) to submit ...", CollectionUtils.Count(data.FinancialAssuranceFacilitySubmission));
        }
    }
    [Serializable]
    public class RCRAGeographicInformationExtractAndSubmission : RCRAExtractAndSubmission<GeographicInformationSubmissionDataType>
    {
        public RCRAGeographicInformationExtractAndSubmission()
        {
            _submissionHistorySubmissionType = "GS";
        }
        protected override List<GeographicInformationSubmissionDataType> GetSubmissionData()
        {
            return _objectsFromDatabase.LoadFromDatabase<GeographicInformationSubmissionDataType>(_baseDao, null);
        }
        protected override void AppendAuditLogCountsString(GeographicInformationSubmissionDataType data)
        {
            AppendAuditLogEvent("Found {0} GIS element(s) to submit ...", CollectionUtils.Count(data.GISFacilitySubmission));
        }
    }
}
