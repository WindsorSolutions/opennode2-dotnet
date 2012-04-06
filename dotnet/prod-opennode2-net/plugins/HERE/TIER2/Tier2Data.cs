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
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Data.Common;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.HERE.TIER2
{
    internal class Tier2Data
    {

        private SpringBaseDao _baseDao;

        public Tier2Data(SpringBaseDao db)
        {
            _baseDao = db;

            if (_baseDao == null)
            {
                throw new ApplicationException("The DbHelper property has not been configured.");
            }
        }


        public void FillError(object sender, FillErrorEventArgs args)
        {
            Trace.TraceError(string.Format("Sender: {0}", sender));

            Trace.Write(args);

        }

        /// <summary>
        /// In case some special characters slipped through the data load
        /// </summary>
        /// <param name="ds"></param>
        private Tier2DataSet CheckForInvalidChars(Tier2DataSet ds)
        {
            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (dr[col] != DBNull.Value &&
                            dr[col] != null)
                        {
                            dr[col] = Regex.Replace(Convert.ToString(dr[col]), @"[^ -~]", ""); 
                        }
                            
                    }
                }
            }

            return (Tier2DataSet)ds;

        }

        public Tier2DataSet GetTier2DataSet(DateTime changeDate)
        {
            Tier2DataSet t2Ds = new Tier2DataSet();

            string columnNames = "ChangeDate;ListIndex";
            string procName = "Tier2_GetTier2ByChangeDate";

            DataTable[] tables = new DataTable[]
                {  t2Ds.T2_SUBMISSION, t2Ds.T2_REPORT, t2Ds.T2_FAC_SITE, t2Ds.T2_FAC_DUNDB_ID,
                   t2Ds.T2_FAC_GEO, t2Ds.T2_FAC_NAICS, t2Ds.T2_FAC_NPDES_ID, t2Ds.T2_FAC_RCRA_ID,
                   t2Ds.T2_FAC_SIC, t2Ds.T2_FAC_UIC_ID, t2Ds.T2_FAC_IND, t2Ds.T2_FAC_IND_EMAIL, 
                   t2Ds.T2_FAC_IND_PHONE, t2Ds.T2_FAC_IND_TYPE, t2Ds.T2_CHEM_INV, t2Ds.T2_CHEM_INV_DTLS, 
                   t2Ds.T2_CHEM_INV_HAZ, t2Ds.T2_CHEM_INV_HLTH, t2Ds.T2_CHEM_INV_PHYS, t2Ds.T2_CHEM_LOC,
                   t2Ds.T2_CHEM_MIX };
            
            for (int i = 0; i < tables.Length; ++i)
            {
                _baseDao.FillTableFromStoredProc(tables[i], procName, columnNames, changeDate, i);
            }

            t2Ds.AcceptChanges();

            return CheckForInvalidChars(t2Ds);
        }
    }
}
