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
using System.Data;
using System.Data.SqlClient;

namespace Windsor.Node2008.WNOSPlugin.PNWWQX
{
    /// <summary>
    /// Summary description for Data.
    /// </summary>
    public class PNWWQXData
    {
        public static DataSet GetData
            (
            int rowId,
            int maxRows,
            string providingOrganizationName,
            string projectOrganizationName,
            string projectName,
            Utility.MinMaxDate dateProject,
            string responsibleOrganizationName,
            Utility.LatLong ll,
            string locationDescriptorContext,
            string locationDescriptorName,
            string stationType,
            string stationName,
            string samplingOrganizationName,
            Utility.MinMaxDate dateFieldEvent,
            string sampledMedia,
            string analyteName,
            string sampledTaxon,
            Common.PNWWQDXIdentity identType
            )
        {
            SqlParameter[] arParms = new SqlParameter[23];

            arParms[0] = new SqlParameter("@rowId", SqlDbType.Int);
            arParms[0].Value = rowId;

            arParms[1] = new SqlParameter("@maxRows", SqlDbType.Int);
            arParms[1].Value = maxRows;

            arParms[2] = new SqlParameter("@providingOrganizationName", SqlDbType.VarChar, 80);
            arParms[2].Value = string.IsNullOrEmpty(providingOrganizationName) ? null : providingOrganizationName;

            arParms[3] = new SqlParameter("@projectOrganizationName", SqlDbType.VarChar, 80);
            arParms[3].Value = string.IsNullOrEmpty(projectOrganizationName) ? null : projectOrganizationName;

            arParms[4] = new SqlParameter("@projectName", SqlDbType.VarChar, 255);
            arParms[4].Value = string.IsNullOrEmpty(projectName) ? null : projectName;

            arParms[5] = new SqlParameter("@projectStartDate", SqlDbType.DateTime);
            arParms[5].Value = dateProject.minDate.HasValue ? (object)dateProject.minDate.Value : null;

            arParms[6] = new SqlParameter("@projectEndDate", SqlDbType.DateTime);
            arParms[6].Value = dateProject.maxDate.HasValue ? (object)dateProject.maxDate.Value : null;

            arParms[7] = new SqlParameter("@responsibleOrganizationName", SqlDbType.VarChar, 80);
            arParms[7].Value = string.IsNullOrEmpty(responsibleOrganizationName) ? null : responsibleOrganizationName;

            arParms[8] = new SqlParameter("@maximumLocationLatitude", SqlDbType.Decimal, 8);
            arParms[8].Value = ll.maxLat.HasValue ? (object)ll.maxLat.Value : null;

            arParms[9] = new SqlParameter("@maximumLocationLongitude", SqlDbType.Decimal, 8);
            arParms[9].Value = ll.maxLong.HasValue ? (object)ll.maxLong.Value : null;

            arParms[10] = new SqlParameter("@minimumLocationLatitude", SqlDbType.Decimal, 8);
            arParms[10].Value = ll.minLat.HasValue ? (object)ll.minLat.Value : null;

            arParms[11] = new SqlParameter("@minimumLocationLongitude", SqlDbType.Decimal, 8);
            arParms[11].Value = ll.minLong.HasValue ? (object)ll.minLong.Value : null;

            arParms[12] = new SqlParameter("@locationDescriptorContext", SqlDbType.VarChar, 100);
            arParms[12].Value = string.IsNullOrEmpty(locationDescriptorContext) ? null : locationDescriptorContext;

            arParms[13] = new SqlParameter("@locationDescriptorName", SqlDbType.VarChar, 100);
            arParms[13].Value = string.IsNullOrEmpty(locationDescriptorName) ? null : locationDescriptorName;

            arParms[14] = new SqlParameter("@stationType", SqlDbType.VarChar, 4000);
            arParms[14].Value = string.IsNullOrEmpty(stationType) ? null : stationType;

            arParms[15] = new SqlParameter("@stationName", SqlDbType.VarChar, 255);
            arParms[15].Value = string.IsNullOrEmpty(stationName) ? null : stationName;

            arParms[16] = new SqlParameter("@samplingOrganizationName", SqlDbType.VarChar, 80);
            arParms[16].Value = string.IsNullOrEmpty(samplingOrganizationName) ? null : samplingOrganizationName;

            arParms[17] = new SqlParameter("@fieldEventStartDate", SqlDbType.DateTime);
            arParms[17].Value = dateFieldEvent.minDate.HasValue ? (object)dateFieldEvent.minDate.Value : null;

            arParms[18] = new SqlParameter("@fieldEventEndDate", SqlDbType.DateTime);
            arParms[18].Value = dateFieldEvent.maxDate.HasValue ? (object)dateFieldEvent.maxDate.Value : null;

            arParms[19] = new SqlParameter("@sampledMedia", SqlDbType.VarChar, 4000);
            arParms[19].Value = string.IsNullOrEmpty(sampledMedia) ? null : sampledMedia;

            arParms[20] = new SqlParameter("@analyteName", SqlDbType.VarChar, 4000);
            arParms[20].Value = string.IsNullOrEmpty(analyteName) ? null : analyteName;

            arParms[21] = new SqlParameter("@sampledTaxon", SqlDbType.VarChar, 4000);
            arParms[21].Value = string.IsNullOrEmpty(sampledTaxon) ? null : sampledTaxon;

            arParms[22] = new SqlParameter("@Deliminator", SqlDbType.Char, 1);
            arParms[22].Value = Config.SQL_ARR_DELIMINATOR;

            switch (identType)
            {
                case Common.PNWWQDXIdentity.Measurements:
                    return SqlHelper.ExecuteDataset(
                        Config.connectionString,
                        CommandType.StoredProcedure,
                        "PNWWQX_GetMeasurementsData",
                        arParms);

                case Common.PNWWQDXIdentity.Project:
                    return SqlHelper.ExecuteDataset(
                        Config.connectionString,
                        CommandType.StoredProcedure,
                        "PNWWQX_GetProjectsData",
                        arParms);

                case Common.PNWWQDXIdentity.Station:
                    return SqlHelper.ExecuteDataset(
                        Config.connectionString,
                        CommandType.StoredProcedure,
                        "PNWWQX_GetStationsData",
                        arParms);

                default:
                    throw new Exception("methodName not found.");
            }
        }
    }
}
