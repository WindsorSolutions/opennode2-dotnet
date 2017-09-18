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

using Windsor.Node2008.WNOSPlugin.FACID30;

namespace Windsor.Node2008.WNOSPlugin.HERE.FACID30
{

    internal class FacId30Service
    {

        #region fields
        private SpringBaseDao _baseDao;

        #endregion

        public FacId30Service(SpringBaseDao baseDao)
        {
            _baseDao = baseDao;
        }

        internal string Execute(DateTime changeDate, string flowName, string targetXmlPath, 
                                ISerializationHelper serializationHelper, ICompressionHelper compressionHelper, 
                                IObjectsFromDatabase objectsFromDatabase,
                                IAppendAuditLogEvent appendAuditLogEvent)
        {
            appendAuditLogEvent.AppendAuditLogEvent("Querying FACID data ...");

            Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>();
            string facIdQuery = string.Format("SELECT ST_FAC_IND FROM CHANGED_FACILITIES WHERE IS_DELETED = 0 AND UPPER(FLOW_TYPE) = UPPER('{0}') AND UPDATE_DATE >= '{1}'",
                              flowName, changeDate.ToString("dd-MMM-yyyy").ToUpper());
            string whereQuery = string.Format("FAC_SITE_IDEN_VAL IN ({0})", facIdQuery);

            selectClauses.Add("FACID_FAC", new DbAppendSelectWhereClause(whereQuery, null));

            string affiliateTableClause = string.Format(
                "AFFL_IDEN IN (SELECT AFFL_IDEN FROM FACID_FAC_FAC_AFFL WHERE FAC_ID IN (SELECT FAC_ID FROM FACID_FAC WHERE {0}) UNION " +
                               "SELECT AFFL_IDEN FROM FACID_ENVR_INTR_FAC_AFFL WHERE ENVR_INTR_ID IN (SELECT ENVR_INTR_ID FROM FACID_ENVR_INTR WHERE FAC_ID IN (SELECT FAC_ID FROM FACID_FAC WHERE {0})))",
                               whereQuery);

            //string affiliateTableClause = string.Format("(AFFL_IDEN IN (SELECT AFFL_IDEN FROM FACID_FAC_FAC_AFFL WHERE FAC_ID IN (SELECT FAC_ID FROM FACID_FAC WHERE {0}))) OR " +
            //                                            "(AFFL_IDEN IN (SELECT AFFL_IDEN FROM FACID_ENVR_INTR_FAC_AFFL WHERE ENVR_INTR_ID IN (SELECT ENVR_INTR_ID FROM FACID_ENVR_INTR WHERE FAC_ID IN (SELECT FAC_ID FROM FACID_FAC WHERE {0}))))",
            //                                            whereQuery);
            //string affiliateTableClause = string.Format("(AFFL_IDEN IN (SELECT AFFL_IDEN FROM FACID_FAC_FAC_AFFL WHERE FAC_ID IN (SELECT FAC_ID FROM FACID_FAC WHERE {0})))",
            //                                            whereQuery);
            //string affiliateTableClause = string.Format("(AFFL_IDEN IN (SELECT AFFL_IDEN FROM FACID_ENVR_INTR_FAC_AFFL WHERE ENVR_INTR_ID IN (SELECT ENVR_INTR_ID FROM FACID_ENVR_INTR WHERE FAC_ID IN (SELECT FAC_ID FROM FACID_FAC WHERE {0}))))",
            //                                            whereQuery);

            //string affiliateTableClause = string.Format("(AFFL_IDEN IN (SELECT AFFL_IDEN FROM FACID_FAC_FAC_AFFL WHERE FAC_ID IN ({0}))) OR " +
            //                                            "(AFFL_IDEN IN (SELECT AFFL_IDEN FROM FACID_ENVR_INTR_FAC_AFFL WHERE ENVR_INTR_ID IN (SELECT ENVR_INTR_ID FROM FACID_ENVR_INTR WHERE FAC_ID IN ({0}))))",
            //                                            facIdQuery);
            selectClauses.Add("FACID_AFFL", new DbAppendSelectWhereClause(affiliateTableClause, null));
            List<FacilityDetailsDataType> dataList =
                objectsFromDatabase.LoadFromDatabase<FacilityDetailsDataType>(_baseDao, selectClauses);

            FacilityDetailsDataType data = FacIdHelper.CombineFacilityDetailsQueryResults(dataList);

#if DEBUG
            {
            }
#endif // DEBUG

            if (CollectionUtils.IsNullOrEmpty(data.FacilityList))
            {
                appendAuditLogEvent.AppendAuditLogEvent("Did not find any FACID data in database.");
                return null;
            }
            else
            {
                appendAuditLogEvent.AppendAuditLogEvent("Found {0} facilities and {1} affiliates.",
                                                        data.FacilityList.Length,
                                                        (data.AffiliateList != null) ? data.AffiliateList.Length : 0);
            }

            appendAuditLogEvent.AppendAuditLogEvent(
                    "Serializing transformed results to file (File = {0}).",
                    targetXmlPath);

            serializationHelper.Serialize(data, targetXmlPath);

            return compressionHelper.CompressFile(targetXmlPath);
        }
    }
}
