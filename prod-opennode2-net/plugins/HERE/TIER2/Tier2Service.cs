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

namespace Windsor.Node2008.WNOSPlugin.HERE.TIER2
{

    internal class Tier2Service
    {

        #region fields
        private readonly Tier2Data _dbService;
        #endregion

        public Tier2Service(Tier2Data dataService)
        {

            _dbService = dataService;
        }


        internal string Execute(DateTime changeDate, string targetXmlPath, ISerializationHelper serializationHelper,
                                ICompressionHelper compressionHelper, HEREBaseService hereBaseService)
        {
            hereBaseService.AppendAuditLogEvent("Getting data.");

            Tier2DataSet ds = _dbService.GetTier2DataSet(changeDate);

            hereBaseService.AppendAuditLogEvent("Data retrieved. (Record Count = {0}).",
                ds.T2_SUBMISSION.Rows.Count);

            hereBaseService.AppendAuditLogEvent("Transforming results.");

            TierIIDataType facs = Tier2Transform.Transform(ds);

            if (facs == null || facs.Submission == null || facs.Submission.Length == 0)
            {
                return null;
            }
            else
            {

                hereBaseService.AppendAuditLogEvent("Results transformed. (Record Count = {0}).",
                    facs.Submission.Length);

                hereBaseService.AppendAuditLogEvent("Serializing transformed results to file (File = {0}).",
                        targetXmlPath);

                serializationHelper.Serialize(facs, targetXmlPath);

                hereBaseService.AppendAuditLogEvent("Transformed results Serialized.");

                if (compressionHelper != null)
                {
                    return compressionHelper.CompressFile(targetXmlPath);
                }
                else
                {
                    return targetXmlPath;
                }

            }
        }
    }
}
