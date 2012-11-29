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
using Spring.Transaction.Support;
using Spring.Data.Core;
using System.ComponentModel;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.P2R
{
    [Serializable]
    public abstract class P2RPluginBase : BaseWNOSPlugin
    {
        protected enum Tables
        {
            P2R_ORG,
            P2R_PROGRAM_DETAILS,
            P2R_PROJECT_DETAILS,
            P2R_PROJECT_DETAILS_SECTOR,
            P2R_INVESTMENT,
            P2R_BEHAVIORAL_CHANGE,
            P2R_BEHAVIORAL_CHANGE_QNT_RSLT,
            P2R_OUTCOME_MEASURE,
            P2R_OUTCOME_MEASURE_RESULT,
            P2R_ACTIVITY_MEASURE,
            P2R_ACTIVITY_MEASURE_QNT_RSLT,
        }

        #region fields
        protected const string P2R_FLOW_NAME = " P2R_v1";
        protected const string SOURCE_PROVIDER_KEY = "Data Source";
        protected static readonly int MAX_YEAR = DateTime.Now.Year;
        protected const int MIN_YEAR = 1960;
        protected const string ORG_ID_PROP_NAME = "OrgID";
        protected const string FULL_REPLACE_OPERATION = "Full Replace";
        protected const string YEAR_OPERATION = "Year-";

        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected IDbProvider _dbProvider;
        protected IHeaderDocumentHelper _headerDocumentHelper;

        protected string _organizationIdentifier;
        protected int _year;
        protected SpringBaseDao _baseDao;

        protected string _projectDetailsWhereQuery;
        #endregion

        public P2RPluginBase()
        {
            DataProviders.Add(SOURCE_PROVIDER_KEY, null);
        }
        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing P2RPluginBase plugin ...");

            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _headerDocumentHelper);

            if (!DataProviders.TryGetValue(SOURCE_PROVIDER_KEY, out _dbProvider) ||
                (_dbProvider == null))
            {
                throw new ArgumentException(string.Format("Missing \"{0}\" data source specified for this service",
                                                          SOURCE_PROVIDER_KEY));
            }
            _baseDao = new SpringBaseDao(_dbProvider, typeof(NamedNullMappingDataReader));
        }
    }
}