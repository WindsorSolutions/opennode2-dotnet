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
using System.Reflection;
using Spring.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Logging;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.RCRA_52
{
    [Serializable]
    public class RCRAGetHazardousWasteCMEData : RCRABaseSolicitProcessor
	{
        protected override object GetObjectFromRequest(DataRequest request)
        {
            LOG.DebugEnter(MethodBase.GetCurrentMethod(), request);

            IObjectsFromDatabase objectsFromDatabase;
            GetServiceImplementation(out objectsFromDatabase);

            List<HazardousWasteCMESubmissionDataType> dataList = objectsFromDatabase.LoadFromDatabase<HazardousWasteCMESubmissionDataType>(_baseDao, null);

            if (CollectionUtils.IsNullOrEmpty(dataList))
            {
                throw new InvalidOperationException("The staging database does not contain any RCRA CM&E data.");
            }
            else if (dataList.Count > 1)
            {
                throw new InvalidOperationException(string.Format("The staging database contains more that one set of RCRA CM&E data ({0} sets).",
                                                                  dataList.Count));
            } 
            else 
            {
                HazardousWasteCMESubmissionDataType hazardousWasteCMESubmissionDataType = dataList[0];
                if (CollectionUtils.IsNullOrEmpty(hazardousWasteCMESubmissionDataType.CMEFacilitySubmission))
                {
                    throw new InvalidOperationException("The staging database does not contain any RCRA CM&E facility submission data.");
                }
                AppendAuditLogEvent("Found {0} RCRA CM&E facility submission(s)",
                                    hazardousWasteCMESubmissionDataType.CMEFacilitySubmission.Length);
                return hazardousWasteCMESubmissionDataType;
            }
		}
    }
}
