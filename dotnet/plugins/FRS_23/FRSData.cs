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
using Windsor.Commons.Logging;

namespace Windsor.Node2008.WNOSPlugin.FRS23
{
    internal class FRSData : IDisposable
    {


        private const string FRS_FAC_BY_NAME = "SELECT * FROM FRS_FAC WHERE ST_CD = {0} AND FAC_SITENM LIKE {1}";
        private const string FRS_FAC_BY_DATE = "SELECT * FROM FRS_FAC WHERE ST_CD = {0} AND REPORTED_DATE >= {1}";

        private const string SQL_IN_BY_NAME = "SELECT ST_FAC_IND FROM FRS_FAC WHERE ST_CD = {0} AND FAC_SITENM LIKE {1}";
        private const string SQL_IN_BY_DATE = "SELECT ST_FAC_IND FROM FRS_FAC WHERE ST_CD = {0} AND REPORTED_DATE >= {1}";

        private const string FRS_FAC_IND = "SELECT * FROM FRS_FAC_IND WHERE ST_FAC_IND IN ({0})";
        private const string FRS_FAC_NAICS= "SELECT * FROM FRS_FAC_NAICS WHERE ST_FAC_IND IN ({0})";
        private const string FRS_FAC_ORG= "SELECT * FROM FRS_FAC_ORG WHERE ST_FAC_IND IN ({0})";
        private const string FRS_FAC_SIC= "SELECT * FROM FRS_FAC_SIC WHERE ST_FAC_IND IN ({0})";
        private const string FRS_ADD= "SELECT * FROM FRS_ADD WHERE ST_FAC_IND IN ({0})";
        private const string FRS_ALT_NM= "SELECT * FROM FRS_ALT_NM WHERE ST_FAC_IND IN ({0})";
        private const string FRS_GEO= "SELECT * FROM FRS_GEO WHERE ST_FAC_IND IN ({0})";
        private const string FRS_EI= "SELECT * FROM FRS_EI WHERE ST_FAC_IND IN ({0})";

        private const string FRS_EI_IND = "SELECT * FROM FRS_EI_IND WHERE ST_EI_IND IN (SELECT ST_EI_IND FROM FRS_EI WHERE ST_FAC_IND IN ({0}))";
        private const string FRS_EI_NAICS = "SELECT * FROM FRS_EI_NAICS WHERE ST_EI_IND IN (SELECT ST_EI_IND FROM FRS_EI WHERE ST_FAC_IND IN ({0}))";
        private const string FRS_EI_ORG = "SELECT * FROM FRS_EI_ORG WHERE ST_EI_IND IN (SELECT ST_EI_IND FROM FRS_EI WHERE ST_FAC_IND IN ({0}))";
        private const string FRS_EI_SIC = "SELECT * FROM FRS_EI_SIC WHERE ST_EI_IND IN (SELECT ST_EI_IND FROM FRS_EI WHERE ST_FAC_IND IN ({0}))";


        private readonly IDbCommand _cmd;
        private readonly IDbDataParameter _param1;
        private readonly IDbDataParameter _param2;

        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private readonly Dictionary<FRSTableType, string> _queries = new Dictionary<FRSTableType, string>();

        private enum FRSTableType 
        {
            FRS_FAC,
            FRS_FAC_IND,
            FRS_FAC_NAICS,
            FRS_FAC_ORG,
            FRS_FAC_SIC,
            FRS_ADD,
            FRS_ALT_NM,
            FRS_GEO,
            FRS_EI,
            FRS_EI_IND,
            FRS_EI_NAICS,
            FRS_EI_ORG,
            FRS_EI_SIC
        }


        public FRSData(IDbProvider dbProvider, FRSServiceCriteria criteria)
        {

            LOG.Debug("Creating Command...");
            _cmd = dbProvider.CreateCommand();
            _cmd.Connection = dbProvider.CreateConnection();
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandTimeout = 300000;

            _param1 = _cmd.CreateParameter();
            _param1.DbType = DbType.String;
            _param1.ParameterName = dbProvider.CreateParameterName("p1");
            _param1.Value = criteria.USPSCode;

            _param2 = _cmd.CreateParameter();
            _param2.DbType = DbType.String;
            _param2.ParameterName = dbProvider.CreateParameterName("p2");

            string sqlIn = null;

            if (criteria.Type == FRSServiceCriteria.FRSServiceType.GetFacilityByName)
            {
                _param2.Value = criteria.FacilityName;
                sqlIn = string.Format(SQL_IN_BY_NAME, _param1.ParameterName, _param2.ParameterName);
                _queries.Add(FRSTableType.FRS_FAC, string.Format(FRS_FAC_BY_NAME, _param1.ParameterName, _param2.ParameterName));
            }
            else
            {
                _param2.Value = criteria.ChangeDateXml;
                sqlIn = string.Format(SQL_IN_BY_DATE, _param1.ParameterName, _param2.ParameterName);
                _queries.Add(FRSTableType.FRS_FAC, string.Format(FRS_FAC_BY_DATE, _param1.ParameterName, _param2.ParameterName));
            }

            _queries.Add(FRSTableType.FRS_FAC_IND, string.Format(FRS_FAC_IND, sqlIn));
            _queries.Add(FRSTableType.FRS_FAC_NAICS, string.Format(FRS_FAC_NAICS, sqlIn));
            _queries.Add(FRSTableType.FRS_FAC_ORG, string.Format(FRS_FAC_ORG, sqlIn));
            _queries.Add(FRSTableType.FRS_FAC_SIC, string.Format(FRS_FAC_SIC, sqlIn));
            _queries.Add(FRSTableType.FRS_ADD, string.Format(FRS_ADD, sqlIn));
            _queries.Add(FRSTableType.FRS_ALT_NM, string.Format(FRS_ALT_NM, sqlIn));
            _queries.Add(FRSTableType.FRS_GEO, string.Format(FRS_GEO, sqlIn));
            _queries.Add(FRSTableType.FRS_EI, string.Format(FRS_EI, sqlIn));
            _queries.Add(FRSTableType.FRS_EI_IND, string.Format(FRS_EI_IND, sqlIn));
            _queries.Add(FRSTableType.FRS_EI_NAICS, string.Format(FRS_EI_NAICS, sqlIn));
            _queries.Add(FRSTableType.FRS_EI_ORG, string.Format(FRS_EI_ORG, sqlIn));
            _queries.Add(FRSTableType.FRS_EI_SIC, string.Format(FRS_EI_SIC, sqlIn));

            _cmd.Parameters.Add(_param1);
            _cmd.Parameters.Add(_param2);

            LOG.Debug("Opening Command Connection...");
            _cmd.Connection.Open();
        }



        private IDataReader GetFRSReader(FRSTableType listType)
        {
            LOG.Debug("Executing query for list: " + listType);
            _cmd.CommandText = _queries[listType];
            LOG.Debug("Cmd: " + _cmd);
            return _cmd.ExecuteReader();
        }


        /// <summary>
        /// Returns added/changed facilities
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public FRS GetFRSAddData()
        {

            FRS dsFRS = new FRS();

            //FAC
            dsFRS.FRS_FAC.Load(GetFRSReader(FRSTableType.FRS_FAC));
            LOG.Debug("FRS_FAC: " + dsFRS.FRS_FAC.Rows.Count);

            //FRS_FAC_IND
            dsFRS.FRS_FAC_IND.Load(GetFRSReader(FRSTableType.FRS_FAC_IND));
            LOG.Debug("FRS_FAC_IND: " + dsFRS.FRS_FAC_IND.Rows.Count);

            //FRS_FAC_NAICS
            dsFRS.FRS_FAC_NAICS.Load(GetFRSReader(FRSTableType.FRS_FAC_NAICS));
            LOG.Debug("FRS_FAC_NAICS: " + dsFRS.FRS_FAC_NAICS.Rows.Count);

            //FRS_FAC_ORG
            dsFRS.FRS_FAC_ORG.Load(GetFRSReader(FRSTableType.FRS_FAC_ORG));
            LOG.Debug("FRS_FAC_ORG: " + dsFRS.FRS_FAC_ORG.Rows.Count);

            //FRS_FAC_SIC
            dsFRS.FRS_FAC_SIC.Load(GetFRSReader(FRSTableType.FRS_FAC_SIC));
            LOG.Debug("FRS_FAC_SIC: " + dsFRS.FRS_FAC_SIC.Rows.Count);

            //FRS_ADD
            dsFRS.FRS_ADD.Load(GetFRSReader(FRSTableType.FRS_ADD));
            LOG.Debug("FRS_ADD: " + dsFRS.FRS_ADD.Rows.Count);

            //FRS_ALT_NM
            dsFRS.FRS_ALT_NM.Load(GetFRSReader(FRSTableType.FRS_ALT_NM));
            LOG.Debug("FRS_ALT_NM: " + dsFRS.FRS_ALT_NM.Rows.Count);

            //FRS_GEO
            dsFRS.FRS_GEO.Load(GetFRSReader(FRSTableType.FRS_GEO));
            LOG.Debug("FRS_GEO: " + dsFRS.FRS_GEO.Rows.Count);

            //FRS_EI
            dsFRS.FRS_EI.Load(GetFRSReader(FRSTableType.FRS_EI));
            LOG.Debug("FRS_EI: " + dsFRS.FRS_EI.Rows.Count);

            //FRS_EI_IND
            dsFRS.FRS_EI_IND.Load(GetFRSReader(FRSTableType.FRS_EI_IND));
            LOG.Debug("FRS_EI_IND: " + dsFRS.FRS_EI_IND.Rows.Count);

            //FRS_EI_NAICS
            dsFRS.FRS_EI_NAICS.Load(GetFRSReader(FRSTableType.FRS_EI_NAICS));
            LOG.Debug("FRS_EI_NAICS: " + dsFRS.FRS_EI_NAICS.Rows.Count);

            //FRS_EI_ORG
            dsFRS.FRS_EI_ORG.Load(GetFRSReader(FRSTableType.FRS_EI_ORG));
            LOG.Debug("FRS_EI_ORG: " + dsFRS.FRS_EI_ORG.Rows.Count);

            //FRS_EI_SIC
            dsFRS.FRS_EI_SIC.Load(GetFRSReader(FRSTableType.FRS_EI_SIC));
            LOG.Debug("FRS_EI_SIC: " + dsFRS.FRS_EI_SIC.Rows.Count);

            dsFRS.AcceptChanges();


            return dsFRS;
        }


        #region IDisposable Members

        public void Dispose()
        {
            if (_cmd != null && _cmd.Connection.State != ConnectionState.Closed)
            {
                _cmd.Connection.Close();
            }
        }

        #endregion
    }
}
