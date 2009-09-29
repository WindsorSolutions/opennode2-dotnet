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
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.HERE.CAFO11
{
    internal class CAFOData
    {
        private SpringBaseDao _baseDao;

        public CAFOData(SpringBaseDao db)
        {
            _baseDao = db;

            if (_baseDao == null)
            {
                throw new ApplicationException("The DbHelper property has not been configured.");
            }
        }

        public CAFO GetCAFOAddData(DateTime changeDate)
        {
            CAFO dsCAFO = new CAFO();

            string columnNames = "ChangeDate;ListIndex";
            string procName = "CAFO_GetCAFOByChangeDate";

            DataTable[] tables = new DataTable[]
                { dsCAFO.CAFO_FAC, dsCAFO.CAFO_GEO, dsCAFO.CAFO_ANIMAL, dsCAFO.CAFO_ADD,
                  dsCAFO.CAFO_REG_DTLS, dsCAFO.CAFO_PERMIT };

            for (int i = 0; i < tables.Length; ++i)
            {
                _baseDao.FillTableFromStoredProc(tables[i], procName, columnNames, changeDate, i);
            }

            dsCAFO.AcceptChanges();

            return dsCAFO;
        }
    }
}
