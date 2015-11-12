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

namespace Windsor.Node2008.WNOSPlugin.BEACHES_22
{
    [Serializable]
    public abstract class GetNotificationDetailsByParameters : QuerySolicitProcessorBase
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
        protected string _activeAdvisoryIndicator;

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
            TryGetParameterByName(_dataRequest, EnumUtils.ToDescription(QueryParameter.MonitoringStationIdentifier), ref _monitoringStationIdentifier);
            TryGetParameterByName(_dataRequest, EnumUtils.ToDescription(QueryParameter.BeachAccessType), ref _beachAccessType);
            TryGetParameterByName(_dataRequest, EnumUtils.ToDescription(QueryParameter.ActivityIndicatorType), ref _activityIndicatorType);
            TryGetParameterByName(_dataRequest, EnumUtils.ToDescription(QueryParameter.ActiveAdvisoryIndicator), ref _activeAdvisoryIndicator);
        }
    }
}
