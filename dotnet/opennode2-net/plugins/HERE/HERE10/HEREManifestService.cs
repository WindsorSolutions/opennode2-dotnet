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
using Windsor.Node2008.WNOSProviders;
using System.Diagnostics;


namespace Windsor.Node2008.WNOSPlugin.HERE.HERE10
{

    internal class HEREManifestService
    {
        #region fields
        private readonly HERE10.HEREData _dbService;


        #endregion

        public HEREManifestService(HERE10.HEREData dataService)
        {

            _dbService = dataService;
        }

        internal byte[] Execute(ICollection<string> allFlowList, ICollection<string> protectedFlowList,
                                ICollection<string> userProtectedFlowList, DateTime changeDate, 
                                ISerializationHelper serializationHelper, HEREBaseService hereBaseService)
        {
            hereBaseService.AppendAuditLogEvent("Getting data.");

            HERE10.ManifestDataSet ds = _dbService.GetManifestData(changeDate);

            hereBaseService.AppendAuditLogEvent("Data retrieved. (Record Count = {0}).", ds.Manifest.Rows.Count);

            hereBaseService.AppendAuditLogEvent("Transforming results.");

            List<HERE10.HEREManifestItemDataType> manifestItems = new List<HERE10.HEREManifestItemDataType>();

            foreach (HERE10.ManifestDataSet.ManifestRow manifestRow in ds.Manifest.Rows)
            {

                string flowCode = manifestRow.DataExchangeName;

                if (ContainsFlowName(allFlowList, flowCode))
                {
                    if (ContainsFlowName(protectedFlowList, flowCode))
                    {
                        if (!ContainsFlowName(userProtectedFlowList, flowCode))
                        {
                            // User does not have access to this flow
                            continue;
                        }
                    }

                    HERE10.HEREManifestItemDataType item = new HERE10.HEREManifestItemDataType();

                    item.TransactionIdentifier = manifestRow.TransactionId;
                    item.CreatedDate = manifestRow.CreatedDate;
                    item.DataExchangeNameText = manifestRow.DataExchangeName;
                    item.EndpointURLIdentifier = manifestRow.EndpointURL;
                    item.FullReplaceIndicator = manifestRow.FullReplaceIndicator;
                    item.SourceInfo = new HERE10.SourceInfoDataType();
                    item.SourceInfo.IsFacilitySourceIndicator = manifestRow.IsFacilitySourceIndicator;
                    item.SourceInfo.SourceSystemName = manifestRow.SourceSystemName;
                    manifestItems.Add(item);
                }
            }

            HERE10.HEREManifestDataType manifest = new HERE10.HEREManifestDataType();
            manifest.HEREManifestDetails = manifestItems.ToArray();

            hereBaseService.AppendAuditLogEvent("Results transformed.");

            return serializationHelper.Serialize(manifest);
        }

        private bool ContainsFlowName(ICollection<string> collection, string flowName)
        {
            if ( collection != null ) {
                foreach (string itemName in collection)
                {
                    if (string.Equals(itemName, flowName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
