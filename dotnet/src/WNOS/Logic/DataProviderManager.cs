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
using System.Reflection;

using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOS.Data;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOS.Logic
{
    public class DataProviderManager : LogicAuditBaseManager, IDataProviderManager, IDataSourceService
    {
        private IDataProviderDao _dataProviderDao;

        #region Init

        new public void Init()
        {
			base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _dataProviderDao);
		}

        #endregion

        public IDictionary<string, SimpleListDisplayInfo> GetListInfo(params string[] args)
        {
            Dictionary<string, SimpleListDisplayInfo> dict = new Dictionary<string, SimpleListDisplayInfo>();

            ICollection<DataProviderInfo> dataProviders = _dataProviderDao.Get();
            if (!CollectionUtils.IsNullOrEmpty(dataProviders))
            {
                foreach (DataProviderInfo dataProvider in dataProviders)
                {
                    dict.Add(dataProvider.Name, new SimpleListDisplayInfo(dataProvider.Name, 
                                                                          dataProvider.ConnectionString));
                }
            }

            return dict;
        }

        public DataProviderInfo Save(DataProviderInfo instance, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);

            if ((instance == null) || string.IsNullOrEmpty(instance.ConnectionString) || 
                string.IsNullOrEmpty(instance.ProviderType))
            {
                throw new ArgumentException("Input values are null.");
            }

            instance.ModifiedById = visit.Account.Id;
            TransactionTemplate.Execute(delegate
            {
                _dataProviderDao.Save(instance);
                ActivityManager.LogAudit(NodeMethod.None, null, visit, "{0} saved data source: {1}.",
                                         visit.Account.NaasAccount, instance.ToString());
                return null;
            });
            return instance;
        }

        public DataProviderInfo GetById(string id)
        {
            return _dataProviderDao.GetById(id);
        }

        public DataProviderInfo GetByName(string code)
        {
            return _dataProviderDao.GetByName(code);
        }

        public ICollection<DataProviderInfo> Get()
        {
            return _dataProviderDao.Get();
        }

        public Exception CheckConnection(string providerType, string connectionString)
        {
            try
            {
                Spring.Data.Common.IDbProvider dbProvider = Spring.Data.Common.DbProviderFactory.GetDbProvider(providerType);
                dbProvider.ConnectionString = connectionString;
                using (System.Data.IDbConnection connection = dbProvider.CreateConnection())
                {
                    connection.Open();
                }
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        public ICollection<string> GetAllDataSourceNames()
        {
            return _dataProviderDao.GetAllDataSourceNames();
        }
        public void Delete(DataProviderInfo instance, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);
            TransactionTemplate.Execute(delegate
            {
                _dataProviderDao.Delete(instance);
                ActivityManager.LogAudit(NodeMethod.None, null, visit, "{0} deleted data source: {1}.",
                                         visit.Account.NaasAccount, instance.ToString());
                return null;
            });
        }
        #region Properties
        public IDataProviderDao DataProviderDao
        {
            get { return _dataProviderDao; }
            set { _dataProviderDao = value; }
        }
		#endregion
    }
}
