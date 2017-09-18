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
using System.Runtime.Serialization;
using System.Data.Common;
using System.Diagnostics;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.HERE.HERE10
{
    internal class HEREData
    {

        private SpringBaseDao _baseDao;

        public HEREData(SpringBaseDao db)
        {
            _baseDao = db;

            if (_baseDao == null)
            {
                throw new ApplicationException("The DbHelper property has not been configured.");
            }
        }

        public void SetResultData(string transactionId, string endpointUrl, string flowName,
                                  bool isFacilitySource, string sourceSystemName, bool isFullReplace)
        {
            _baseDao.DoStoredProc("Load_HERE_Manifest", "TransactionId;EndpointURL;DataExchangeName;IsFacilitySourceIndicator;SourceSystemName;FullReplaceIndicator",
                                  new object[] { transactionId, endpointUrl, flowName, isFacilitySource, 
                                                 sourceSystemName, isFullReplace });
        }

        public DomainDataSet GetDomainData(DateTime changeDate)
        {
            DomainDataSet domainSet = new DomainDataSet();

            string columnNames = "ChangeDate;ListIndex";
            string procName = "Get_HERE_DomainValuesData";

            _baseDao.FillTableFromStoredProc(domainSet.List, procName, columnNames,
                                             changeDate, (int)0);

            _baseDao.FillTableFromStoredProc(domainSet.ListItem, procName, columnNames,
                                             changeDate, (int)1);
            domainSet.AcceptChanges();

            return domainSet;

        }

        public ManifestDataSet GetManifestData(DateTime changeDate)
        {
            ManifestDataSet dsManifest = new ManifestDataSet();

            _baseDao.FillTableFromStoredProc(dsManifest.Manifest, "Get_HERE_ManifestData", "changeDate",
                                             changeDate);
            dsManifest.AcceptChanges();

            return dsManifest;

        }
    }
}
