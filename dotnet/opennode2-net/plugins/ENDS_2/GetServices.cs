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
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.ENDS_2
{
    [Serializable]
    public class GetServices : EndsPluginBase, IQueryProcessor
    {
        protected string _serviceCategory = "AllServices";
        protected ServiceType _returnServiceTypes;

        public GetServices()
        {
        }
        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);

            GetParameter(_dataRequest, "ServiceCategory", 0, out _serviceCategory);
            AppendAuditLogEvent("ServiceCategory = \"{0}\"", _serviceCategory);

            _returnServiceTypes = GetServiceTypes(_serviceCategory);
        }
        protected static ServiceType GetServiceTypes(string serviceCategory)
        {
            switch (serviceCategory.ToUpper()) {
                case "ALLSERVICES" :
                    return ServiceType.QueryOrSolicitOrExecute | ServiceType.Submit;
                case "QUERY":
                    return ServiceType.Query;
                case "SOLICIT":
                    return ServiceType.Solicit;
                case "EXECUTE":
                    return ServiceType.Execute;
                case "SUBMIT":
                    return ServiceType.Submit;
                default:
                    throw new ArgumentException(string.Format("Invalid service category specified: \"{0}\"", serviceCategory));
            }
        }
        public PaginatedContentResult ProcessQuery(string requestId)
        {
            ProcessRequestInit(requestId);

            int rowCount;
            byte[] content = GetServices(_returnServiceTypes, out rowCount);

            PaginatedContentResult result = new PaginatedContentResult();
            result.Paging = new PaginationIndicator(0, rowCount, true);
            result.Content = new SimpleContent(CommonContentType.XML, content);

            return result;
        }
        /// <summary>
        /// Return the Query, Solicit, or Execute data service parameters for specified data service.
        /// This method should NOT call GetServiceImplementation().
        /// </summary>
        public override IList<TypedParameter> GetDataServiceParameters(string serviceName, out DataServicePublishFlags publishFlags)
        {
            publishFlags = DataServicePublishFlags.PublishToEndpointVersion11And20;
            List<TypedParameter> list = new List<TypedParameter>(1);
            list.Add(new TypedParameter("Service Category", "The service category to return (AllServices, Solicit, Query, Execute or Submit)", true, typeof(string), true));
            return list;
        }
    }
}
