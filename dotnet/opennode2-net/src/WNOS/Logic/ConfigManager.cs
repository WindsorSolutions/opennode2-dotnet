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
using Windsor.Node2008.WNOS.Logic;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Commons.Core;
using Wintellect.PowerCollections;

namespace Windsor.Node2008.WNOS.Logic
{
    public class ConfigManager : LogicAuditBaseManager, IConfigService, IConfigManager
    {
        private IConfigDao _configDao;
        private ICryptographyProvider _cryptographyProvider;

        private Dictionary<string, ConfigItem> _configItems = new Dictionary<string, ConfigItem>();
        private object _lockObject = new object();

        #region Init

        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _configDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _cryptographyProvider);

            Load();
        }

        #endregion

        private void Load()
        {
            Dictionary<string, ConfigItem> configItems = new Dictionary<string, ConfigItem>();

            foreach (ConfigItem item in ConfigDao.GetConfigItems())
            {
                if (item.Id == "NodeDatabaseVersion")
                {
                }
                else
                {
                    item.Value = _cryptographyProvider.Decrypt(item.Value);
                }
                configItems.Add(item.Id.ToUpper(), item);
            }
            lock (_lockObject)
            {
                _configItems = configItems;
            }
        }

        #region IConfigService Members

        public ConfigItem Save(string curItemId, ConfigItem item, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);

            ParsingHelper.ValidateKey(item.Id);

            if (!item.IsEditable)
            {
                throw new InvalidOperationException("The item cannot be saved since it is not editable.");
            }

            ConfigItem saveItem = new ConfigItem(item);
            saveItem.ModifiedById = visit.Account.Id;
            saveItem.Value = _cryptographyProvider.Encrypt(item.Value);
            lock (_lockObject)
            {
                TransactionTemplate.Execute(delegate
                {
                    _configDao.Save(curItemId, saveItem);
                    lock (_lockObject)
                    {
                        if (!string.IsNullOrEmpty(curItemId))
                        {
                            if (_configItems.ContainsKey(curItemId.ToUpper()))
                            {
                                _configItems.Remove(curItemId.ToUpper());
                            }
                        }
                        _configItems[item.Id.ToUpper()] = item;
                    }
                    ActivityManager.LogAudit(NodeMethod.None, null, visit, "{0} updated configuration value: {1}.",
                                             visit.Account.NaasAccount, saveItem.ToString());
                    return null;
                });
                item.ModifiedById = saveItem.ModifiedById;
                item.ModifiedOn = saveItem.ModifiedOn;
            }
            return item;
        }

        public void Delete(ConfigItem item, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);

            if (!item.IsEditable)
            {
                throw new InvalidOperationException("The item cannot be saved since it is not editable.");
            }
            lock (_lockObject)
            {
                TransactionTemplate.Execute(delegate
                {
                    _configDao.Delete(item.Id);
                    lock (_lockObject)
                    {
                        if (_configItems.ContainsKey(item.Id.ToUpper()))
                        {
                            _configItems.Remove(item.Id.ToUpper());
                        }
                    }
                    ActivityManager.LogAudit(NodeMethod.None, null, visit, "{0} deleted configuration value: {1}.",
                                             visit.Account.NaasAccount, item.ToString());
                    return null;
                });
            }
        }

        public ICollection<ConfigItem> Get(ConfigurationType typesToReturn)
        {
            lock (_lockObject)
            {
                OrderedSet<ConfigItem> list = new OrderedSet<ConfigItem>();
                foreach (ConfigItem item in _configItems.Values)
                {
                    if (item.IsEditable)
                    {
                        if ((typesToReturn & ConfigurationType.Global) == ConfigurationType.Global)
                        {
                            list.Add(new ConfigItem(item));
                        }
                    }
                    else
                    {
                        if ((typesToReturn & ConfigurationType.System) == ConfigurationType.System)
                        {
                            list.Add(new ConfigItem(item));
                        }
                    }
                }
                return list;
            }
        }

        public ConfigItem Get(string id)
        {
            lock (_lockObject)
            {
                return new ConfigItem(_configItems[id.ToUpper()]);
            }
        }

        public IDictionary<string, SimpleListDisplayInfo> GetListInfo(params string[] args)
        {
            Dictionary<string, SimpleListDisplayInfo> dict = new Dictionary<string, SimpleListDisplayInfo>();

            lock (_lockObject)
            {
                foreach (ConfigItem item in _configItems.Values)
                {
                    if (item.IsEditable)
                    {
                        dict.Add(item.Id, new SimpleListDisplayInfo(item.Id, item.Value));
                    }
                }
            }
            return dict;
        }

        #endregion

        public IConfigDao ConfigDao
        {
            get
            {
                return _configDao;
            }
            set
            {
                _configDao = value;
            }
        }
        public ICryptographyProvider CryptographyProvider
        {
            get
            {
                return _cryptographyProvider;
            }
            set
            {
                _cryptographyProvider = value;
            }
        }
    }
}
