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
using System.Text.RegularExpressions;
using Windsor.Commons.NodeDomain;
using System.Linq;

namespace Windsor.Node2008.WNOSPlugin.BEACHES_22
{
    [Serializable]
    public class GetNotificationDetailsByParameters : QuerySolicitProcessorBase
    {
        protected enum QueryParameter
        {
            [Description("ActualStartDate")]
            ActualStartDate = 0,

            [Description("ActualStopDate")]
            ActualStopDate,

            [Description("BeachName")]
            BeachName,

            [Description("BeachIdentifier")]
            BeachIdentifier,

            [Description("MonitoringStationIdentifier")]
            MonitoringStationIdentifier,

            [Description("BeachAccessType")]
            BeachAccessType,

            [Description("ActivityIndicatorType")]
            ActivityIndicatorType,

            [Description("ActiveAdvisoryIndicator")]
            ActiveAdvisoryIndicator,
        }

        protected DateTime? _actualStartDate;
        protected DateTime? _actualStopDate;
        protected string _beachName;
        protected string _beachIdentifier;
        protected string _monitoringStationIdentifier;
        protected string _beachAccessType;
        protected string _activityIndicatorType;
        protected bool? _activeAdvisoryIndicator;

        public GetNotificationDetailsByParameters()
        {
        }

        protected override void LazyInit()
        {
            base.LazyInit();
        }
        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);

            TryGetParameterByName(_dataRequest, EnumUtils.ToDescription(QueryParameter.ActualStartDate), ref _actualStartDate);
            TryGetParameterByName(_dataRequest, EnumUtils.ToDescription(QueryParameter.ActualStopDate), ref _actualStopDate);
            TryGetParameterByName(_dataRequest, EnumUtils.ToDescription(QueryParameter.BeachName), ref _beachName);
            TryGetParameterByName(_dataRequest, EnumUtils.ToDescription(QueryParameter.BeachIdentifier), ref _beachIdentifier);
            TryGetParameterByName(_dataRequest, EnumUtils.ToDescription(QueryParameter.MonitoringStationIdentifier), ref _monitoringStationIdentifier);
            TryGetParameterByName(_dataRequest, EnumUtils.ToDescription(QueryParameter.BeachAccessType), ref _beachAccessType);
            TryGetParameterByName(_dataRequest, EnumUtils.ToDescription(QueryParameter.ActivityIndicatorType), ref _activityIndicatorType);
            TryGetParameterByName(_dataRequest, EnumUtils.ToDescription(QueryParameter.ActiveAdvisoryIndicator), ref _activeAdvisoryIndicator);
        }
        protected override string DoProcessQuerySolicit(out CommonContentType contentType)
        {
            contentType = CommonContentType.ZIP;

            Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>();

            string beachActivityClause = null;
            List<object> beachActivityParams = null;
            string beachClause = null;
            List<object> beachParams = null;
            string beachActivityMonStationClause = null;
            List<object> beachActivityMonStationParams = null;
            string activityIndicatorClause = null;
            List<object> activityIndicatorParams = null;
            if (_actualStartDate.HasValue)
            {
                beachActivityClause = AppendToDbClause(beachActivityClause, "ACTUALSTARTDATE >= ?");
                beachActivityParams = CollectionUtils.Add(_actualStartDate.Value, beachActivityParams);
            }
            if (_actualStopDate.HasValue)
            {
                beachActivityClause = AppendToDbClause(beachActivityClause, "ACTUALSTOPDATE <= ?");
                beachActivityParams = CollectionUtils.Add(_actualStopDate.Value, beachActivityParams);
            }
            if (!string.IsNullOrEmpty(_beachName))
            {
                beachClause = AppendToDbClause(beachClause, "UPPER(BEACHNAME) LIKE " + _baseDao.SqlConcat("'%'", "UPPER(?)", "'%'"));
                beachParams = CollectionUtils.Add(_beachName, beachParams);
            }
            if (!string.IsNullOrEmpty(_beachIdentifier))
            {
                beachClause = AppendToDbClause(beachClause, "UPPER(BEACHIDENTIFIER) = UPPER(?)");
                beachParams = CollectionUtils.Add(_beachIdentifier, beachParams);
            }
            if (!string.IsNullOrEmpty(_monitoringStationIdentifier))
            {
                beachActivityMonStationClause = AppendToDbClause(beachActivityMonStationClause, "UPPER(MONITORINGSTATIONIDENTIFIER) = UPPER(?)");
                beachActivityMonStationParams = CollectionUtils.Add(_monitoringStationIdentifier, beachActivityMonStationParams);
            }
            if (!string.IsNullOrEmpty(_beachAccessType))
            {
                beachClause = AppendToDbClause(beachClause, "UPPER(BEACHACCESSTYPE) = UPPER(?)");
                beachParams = CollectionUtils.Add(_beachAccessType, beachParams);
            }
            if (!string.IsNullOrEmpty(_activityIndicatorType))
            {
                activityIndicatorClause = AppendToDbClause(activityIndicatorClause, "UPPER(INDICATORTYPE) = UPPER(?)");
                activityIndicatorParams = CollectionUtils.Add(_activityIndicatorType, activityIndicatorParams);
            }
            if (_activeAdvisoryIndicator.HasValue)
            {
                if (_activeAdvisoryIndicator.Value)
                {
                    beachActivityClause = AppendToDbClause(beachActivityClause, "ACTUALSTOPDATE IS NULL");
                }
            }
            if (beachActivityMonStationClause != null)
            {
                selectClauses.Add("NOTIF_BEACHACTIVITYMONSTATION", new DbAppendSelectWhereClause(_baseDao, beachActivityMonStationClause, beachActivityMonStationParams));
                beachActivityClause = AppendToDbClause(beachActivityClause, string.Format("ID IN (SELECT BAMS.ACTIVITY_ID FROM NOTIF_BEACHACTIVITYMONSTATION BAMS WHERE {0})", beachActivityMonStationClause));
                CollectionUtils.AddRange(beachActivityMonStationParams, ref beachActivityParams);
            }
            if (activityIndicatorClause != null)
            {
                selectClauses.Add("NOTIF_ACTIVITYINDICATOR", new DbAppendSelectWhereClause(_baseDao, activityIndicatorClause, activityIndicatorParams));
                beachActivityClause = AppendToDbClause(beachActivityClause, string.Format("ID IN (SELECT AI.ACTIVITY_ID FROM NOTIF_ACTIVITYINDICATOR AI WHERE {0})", activityIndicatorClause));
                CollectionUtils.AddRange(activityIndicatorParams, ref beachActivityParams);
            }
            if (beachActivityClause != null)
            {
                selectClauses.Add("NOTIF_BEACHACTIVITY", new DbAppendSelectWhereClause(_baseDao, beachActivityClause, beachActivityParams));
                beachClause = AppendToDbClause(beachClause, string.Format("ID IN (SELECT BA.BEACH_ID FROM NOTIF_BEACHACTIVITY BA WHERE {0})", beachActivityClause));
                CollectionUtils.AddRange(beachActivityParams, ref beachParams);
            }
            if (beachClause != null)
            {
                selectClauses.Add("NOTIF_BEACH", new DbAppendSelectWhereClause(_baseDao, beachClause, beachParams));
            }
           
            AppendAuditLogEvent("Querying database for BEACHES data ...");
            List<BeachDetailDataType> beachDetails = _objectsFromDatabase.LoadFromDatabase<BeachDetailDataType>(_baseDao, selectClauses);
            List<OrganizationDetailDataType> organizationDetails = null;
            if (!CollectionUtils.IsNullOrEmpty(beachDetails))
            {
                string organizationClause = 
                    string.Format("(ID IN (SELECT DISTINCT OBR.ORGANIZATION_ID FROM NOTIF_ORGANIZATIONBEACHROLE OBR WHERE BEACH_ID IN (SELECT B.ID FROM NOTIF_BEACH B WHERE {0})))", beachClause);
                selectClauses.Add("NOTIF_ORGANIZATION", new DbAppendSelectWhereClause(_baseDao, organizationClause, beachParams));
                organizationDetails = _objectsFromDatabase.LoadFromDatabase<OrganizationDetailDataType>(_baseDao, selectClauses);
            }

            BeachDataSubmissionDataType data = new BeachDataSubmissionDataType();
            data.BeachDetail = CollectionUtils.IsNullOrEmpty(beachDetails) ? null : beachDetails.ToArray();
            data.OrganizationDetail = CollectionUtils.IsNullOrEmpty(organizationDetails) ? null : organizationDetails.ToArray();

            AppendAuditLogEvent(GetQuerySolicitResultsString(data));
            data.AfterLoadFromDatabase();

            string submissionFile = GenerateQuerySolicitFileAndAddToTransaction(data);

            return submissionFile;
        }
        protected string AppendToDbClause(string clause, string valueToAppend)
        {
            valueToAppend = "(" + valueToAppend + ")";
            if (!string.IsNullOrEmpty(clause))
            {
                clause += " AND " + valueToAppend;
            }
            else
            {
                clause = valueToAppend;
            }
            return clause;
        }
    }
}
