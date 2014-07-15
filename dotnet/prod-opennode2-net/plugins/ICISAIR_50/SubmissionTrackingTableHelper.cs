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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.ICISAIR_50
{
    public static class SubmissionTrackingTableHelper
    {
        private static string TABLE_NAME = "ICS_SUBM_TRACK";
        private static string LOAD_COLUMNS = "ETL_CMPL_DATE_TIME;DET_CHANGE_CMPL_DATE_TIME;SUBM_DATE_TIME;SUBM_TRANSACTION_ID;SUBM_TRANSACTION_STAT;SUBM_STAT_DATE_TIME;RSPN_PARSE_DATE_TIME;WORKFLOW_STAT;WORKFLOW_STAT_MESSAGE";
        private static string UPDATE_COLUMNS = "SUBM_DATE_TIME;SUBM_TRANSACTION_ID;SUBM_TRANSACTION_STAT;SUBM_STAT_DATE_TIME;RSPN_PARSE_DATE_TIME;WORKFLOW_STAT;WORKFLOW_STAT_MESSAGE";
        private static string PK_COLUMN = "ICS_SUBM_TRACK_ID";
        private static readonly string FINISHED_STATUS_IN_CLAUSE;

        static SubmissionTrackingTableHelper()
        {
            FINISHED_STATUS_IN_CLAUSE = string.Format("IN ('{0}','{1}')", TransactionStatusCode.Completed.ToString(), TransactionStatusCode.Failed.ToString());
        }
        public static SubmissionTrackingDataType GetActiveSubmissionTrackingElement(SpringBaseDao baseDao, out string submissionTrackingDataTypePK)
        {
            IList<string> pks = GetActiveSubmissionTrackingElementPKs(baseDao);

            if (CollectionUtils.IsNullOrEmpty(pks))
            {
                submissionTrackingDataTypePK = null;
                return null;
            }
            if (pks.Count != 1)
            {
                throw new ArgException("There is more than one active row in the {0} table: {1}", TABLE_NAME,
                                       StringUtils.JoinCommaEnglish(pks));
            }
            submissionTrackingDataTypePK = pks[0];
            SubmissionTrackingDataType submissionTrackingDataType = GetActiveSubmissionTrackingElement(baseDao, submissionTrackingDataTypePK);
            if (submissionTrackingDataType.WorkflowStatus != TransactionStatusCode.Pending)
            {
                throw new ArgException("The workflow status in the {0} table for row \"{1}\" is invalid: \"{2}\"", TABLE_NAME,
                                       submissionTrackingDataTypePK, submissionTrackingDataType.WorkflowStatus.ToString());
            }
            return submissionTrackingDataType;
        }
        public static void Update(SpringBaseDao baseDao, string submissionTrackingDataTypePK, SubmissionTrackingDataType data)
        {
            const int MAX_STATUS_MESSAGE_LENGTH = 4000;
            if (!string.IsNullOrEmpty(data.WorkflowStatusMessage) && (data.WorkflowStatusMessage.Length > MAX_STATUS_MESSAGE_LENGTH))
            {
                data.WorkflowStatusMessage = data.WorkflowStatusMessage.Substring(0, MAX_STATUS_MESSAGE_LENGTH);
            }
            baseDao.DoSimpleUpdate(TABLE_NAME, PK_COLUMN, submissionTrackingDataTypePK, UPDATE_COLUMNS, 1,
                                   data.SubmissionDateTimeSpecified ? (object)data.SubmissionDateTime : null,
                                   data.SubmissionTransactionId,
                                   data.SubmissionTransactionStatusSpecified ? (object)data.SubmissionTransactionStatus.ToString() : null,
                                   data.SubmissionStatusDateTimeSpecified ? (object)data.SubmissionStatusDateTime : null,
                                   data.ResponseParseDateTimeSpecified ? (object)data.ResponseParseDateTime : null,
                                   data.WorkflowStatus.ToString(), data.WorkflowStatusMessage);
        }
        public static SubmissionTrackingDataType GetActiveSubmissionTrackingElement(SpringBaseDao baseDao, string pk)
        {
            SubmissionTrackingDataType data = null;
            baseDao.DoSimpleQueryWithRowCallbackDelegate(TABLE_NAME, PK_COLUMN, pk, LOAD_COLUMNS, delegate(IDataReader reader)
            {
                int index = 0;
                data = new SubmissionTrackingDataType();

                data.ETLCompletionDateTime = GetNullableDateTime(reader, ref index, out data.ETLCompletionDateTimeSpecified);
                data.DETChangeCompletionDateTime = GetNullableDateTime(reader, ref index, out data.DETChangeCompletionDateTimeSpecified);
                data.SubmissionDateTime = GetNullableDateTime(reader, ref index, out data.SubmissionDateTimeSpecified);
                data.SubmissionTransactionId = GetNullableString(reader, ref index);
                data.SubmissionTransactionStatus = GetNullableEnum<TransactionStatusCode>(reader, ref index, out data.SubmissionTransactionStatusSpecified);
                data.SubmissionStatusDateTime = GetNullableDateTime(reader, ref index, out data.SubmissionStatusDateTimeSpecified);
                data.ResponseParseDateTime = GetNullableDateTime(reader, ref index, out data.ResponseParseDateTimeSpecified);
                data.WorkflowStatus = GetEnum<TransactionStatusCode>(reader, ref index);
                data.WorkflowStatusMessage = GetNullableString(reader, ref index);
            });
            if (data == null)
            {
                throw new ArgException("Could not find data in the {0} table with PK {1}", TABLE_NAME, pk);
            }
            return data;
        }
        public static IList<string> GetActiveSubmissionTrackingElementPKs(SpringBaseDao baseDao)
        {
            List<string> pks = null;
            baseDao.DoSimpleQueryWithRowCallbackDelegate(TABLE_NAME, "WORKFLOW_STAT NOT " + FINISHED_STATUS_IN_CLAUSE, null, null, PK_COLUMN, delegate(IDataReader reader)
            {
                string pk = reader.GetString(0);
                CollectionUtils.Add(pk, ref pks);
            });
            return pks;
        }
        private static T GetNullableEnum<T>(IDataReader reader, ref int index, out bool isSpecified) where T : struct, IConvertible
        {
            string valueStr = GetNullableString(reader, ref index);
            if (valueStr == null)
            {
                isSpecified = false;
                return default(T);
            }
            isSpecified = true;
            return EnumUtils.ParseEnum<T>(valueStr, true);
        }
        private static T GetEnum<T>(IDataReader reader, ref int index) where T : struct, IConvertible
        {
            bool isSpecified;
            T enumValue = GetNullableEnum<T>(reader, ref index, out isSpecified);
            if (!isSpecified)
            {
                throw new ArgException("The column {0} is NULL", reader.GetName(index - 1));
            }
            return enumValue;
        }
        private static DateTime GetNullableDateTime(IDataReader reader, ref int index, out bool isSpecified)
        {
            isSpecified = !reader.IsDBNull(index);
            DateTime dateTime = DateTime.MinValue;
            if (isSpecified)
            {
                dateTime = reader.GetDateTime(index);
            }
            ++index;
            return dateTime;
        }
        private static string GetNullableString(IDataReader reader, ref int index)
        {
            string rtnVal = reader.IsDBNull(index) ? null : reader.GetString(index);
            ++index;
            return rtnVal;
        }
    }
}
