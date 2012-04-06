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
using System.Diagnostics;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOSPlugin.HERE.TANKS10
{

    internal class TanksService
    {

        #region fields
        private SpringBaseDao _baseDao;

        #endregion

        public TanksService(SpringBaseDao baseDao)
        {
            _baseDao = baseDao;
        }

        internal string Execute(DateTime changeDate, string flowName, string targetXmlPath, 
                                ISerializationHelper serializationHelper, ICompressionHelper compressionHelper, 
                                IObjectsFromDatabase objectsFromDatabase,
                                IAppendAuditLogEvent appendAuditLogEvent)
        {
            appendAuditLogEvent.AppendAuditLogEvent("Querying TANKS data ...");

            string whereQuery =
                string.Format("FAC_SITE_IDEN IN (SELECT ST_FAC_IND FROM CHANGED_FACILITIES WHERE IS_DELETED = 0 AND UPPER(FLOW_TYPE) = UPPER('{0}') AND UPDATE_DATE >= '{1}')",
                              flowName, changeDate.ToString("dd-MMM-yyyy").ToUpper());

            Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>();
            selectClauses.Add("TANKS_FAC_SITE", new DbAppendSelectWhereClause(whereQuery, null));
            List<TanksSubmissionDataType> dataList =
                objectsFromDatabase.LoadFromDatabase<TanksSubmissionDataType>(_baseDao, selectClauses);

            TanksSubmissionDataType data;
            if (CollectionUtils.IsNullOrEmpty(dataList))
            {
                appendAuditLogEvent.AppendAuditLogEvent("Did not find any TANKS data in database.");
                return null;
            }
            else if (dataList.Count > 1)
            {
                throw new InvalidOperationException("More than one set of TANKS data was found in database.");
            }
            else
            {
                data = dataList[0];
                if (CollectionUtils.IsNullOrEmpty(data.TanksFacilitySite))
                {
                    appendAuditLogEvent.AppendAuditLogEvent("Did not find any tanks facilities.");
                    return null;
                }
                else
                {
                    appendAuditLogEvent.AppendAuditLogEvent("Found {0} facilities and {1} unique tanks.", 
                                                            data.TanksFacilitySite.Length,
                                                            GetUniqueTankCount(data));
                }
            }

            appendAuditLogEvent.AppendAuditLogEvent(
                    "Serializing transformed results to file (File = {0}).",
                    targetXmlPath);

            serializationHelper.Serialize(data, targetXmlPath);

            return compressionHelper.CompressFile(targetXmlPath);
        }
        private int GetUniqueTankCount(TanksSubmissionDataType data)
        {
            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (TanksFacilitySiteDataType facility in data.TanksFacilitySite)
            {
                if (!CollectionUtils.IsNullOrEmpty(facility.Tank))
                {
                    foreach (TankDataType tank in facility.Tank)
                    {
                        if (counts.ContainsKey(tank.TankIdentifierText))
                        {
                            counts[tank.TankIdentifierText] = counts[tank.TankIdentifierText] + 1;
                        }
                        else
                        {
                            counts[tank.TankIdentifierText] = 1;
                        }
                    }
                }
            }
            return counts.Count;
        }
    }
}
