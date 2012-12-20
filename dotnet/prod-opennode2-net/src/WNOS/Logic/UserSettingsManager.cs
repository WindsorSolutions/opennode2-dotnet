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
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Core;
using Windsor.Commons.NodeClient;

namespace Windsor.Node2008.WNOS.Logic
{
    public enum UserSettingsDataType
    {
        AdminSchedulePageExpandedScheduleIds,
        AdminFlowPageExpandedFlowIds,
    }
    public class UserSettingsManager : LogicAuditBaseManager, IUserSettingsManager
    {
        protected IObjectCacheDao ObjectCacheDao
        {
            get;
            set;
        }
        protected TimeSpan CacheDuration
        {
            get;
            set;
        }

        new public void Init()
        {
            base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ObjectCacheDao, "ObjectCacheDao");
        }

        public virtual IList<string> LoadAdminSchedulePageExpandedScheduleIds(string username)
        {
            return LoadData<IList<string>>(username, UserSettingsDataType.AdminSchedulePageExpandedScheduleIds);
        }
        public virtual bool SaveAdminSchedulePageExpandedScheduleIds(string username, IList<string> ids)
        {
            return SaveData(username, UserSettingsDataType.AdminSchedulePageExpandedScheduleIds, ids);
        }
        public virtual IList<string> LoadAdminFlowPageExpandedFlowIds(string username)
        {
            return LoadData<IList<string>>(username, UserSettingsDataType.AdminFlowPageExpandedFlowIds);
        }
        public virtual bool SaveAdminFlowPageExpandedFlowIds(string username, IList<string> ids)
        {
            return SaveData(username, UserSettingsDataType.AdminFlowPageExpandedFlowIds, ids);
        }
        public virtual T LoadData<T>(string username, UserSettingsDataType dataType)
        {
            T data;
            if (LoadData<T>(username, dataType, out data))
            {
                return data;
            }
            return default(T);
        }
        public virtual bool LoadData<T>(string username, UserSettingsDataType dataType, out T data)
        {
            if (string.IsNullOrEmpty(username))
            {
                data = default(T);
                return false;
            }
            bool success = ObjectCacheDao.GetObject<T>(GetDataStorageName(username, dataType), out data);
            //DebugUtils.AssertDebuggerBreak(success);
            return success;
        }
        public virtual bool SaveData<T>(string username, UserSettingsDataType dataType, T data)
        {
            bool success = ObjectCacheDao.CacheObject(data, GetDataStorageName(username, dataType), DateTime.Now + CacheDuration);
            DebugUtils.AssertDebuggerBreak(success);
            return success;
        }
        protected virtual string GetDataStorageName(string username, UserSettingsDataType dataType)
        {
            string usernameHash = StringUtils.HashCode64(username).ToString("D19");
            usernameHash = usernameHash.Replace('-', '1');
            return "Settings_" + usernameHash + "_" + dataType.ToString();
        }
    }
}
