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

namespace Windsor.Node2008.WNOS.Logic
{
    public class PartnerManager : LogicAuditBaseManager, IPartnerManager, IPartnerService
    {
        private IPartnerDao _partnerDao;
        private INodeEndpointClientFactory _nodeEndpointClientFactory;

        #region Init

        new public void Init()
        {
			base.Init();

            FieldNotInitializedException.ThrowIfNull(this, ref _partnerDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _nodeEndpointClientFactory);
        }

        #endregion

        public IDictionary<string, SimpleListDisplayInfo> GetListInfo(params string[] args)
        {
            Dictionary<string, SimpleListDisplayInfo> dict = new Dictionary<string, SimpleListDisplayInfo>();

            IList<PartnerIdentity> partnerIdentities = _partnerDao.Get();
            if (!CollectionUtils.IsNullOrEmpty(partnerIdentities))
            {
                foreach (PartnerIdentity partnerIdentity in partnerIdentities)
                {
                    string description = string.Format("{0}, {1}", partnerIdentity.Url,
                                                       EnumUtils.ToDescription(partnerIdentity.Version));
                    dict.Add(partnerIdentity.Name, new SimpleListDisplayInfo(partnerIdentity.Name,
                                                                             description));
                }
            }

            return dict;
        }

        public PartnerIdentity Save(PartnerIdentity instance, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);

            if ((instance == null) || string.IsNullOrEmpty(instance.Url) || 
                string.IsNullOrEmpty(instance.Name))
            {
                throw new ArgumentException("Input values are null.");
            }

            instance.ModifiedById = visit.Account.Id;
            TransactionTemplate.Execute(delegate
            {
                _partnerDao.Save(instance);
                ActivityManager.LogAudit(NodeMethod.None, null, visit, "{0} saved partner identity: {1}.",
                                         visit.Account.NaasAccount, instance.ToString());
                return null;
            });
            return instance;
        }

        public Exception CheckConnection(PartnerIdentity instance)
        {
            try
            {
                using (INodeEndpointClient client =
                    _nodeEndpointClientFactory.Make(instance.Url, instance.Version))
                {
                    client.NodePing();
                }
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        public PartnerIdentity GetById(string id, AdminVisit visit)
        {
            // TODO: Validate visit (4.1 doesn't)?
            return _partnerDao.GetById(id);
        }

        public PartnerIdentity GetByName(string name, AdminVisit visit)
        {
            // TODO: Validate visit (4.1 doesn't)?
            return _partnerDao.GetByName(name);
        }

        public IList<PartnerIdentity> Get(AdminVisit visit)
        {
            // TODO: Validate visit (4.1 doesn't)?
            return _partnerDao.Get();
        }

        public PartnerIdentity GetById(string id)
        {
            return _partnerDao.GetById(id);
        }

        public PartnerIdentity GetByName(string name)
        {
            return _partnerDao.GetByName(name);
        }

        public IList<PartnerIdentity> Get()
        {
            return _partnerDao.Get();
        }

        public void Delete(PartnerIdentity instance, AdminVisit visit)
        {
            ValidateByRole(visit, SystemRoleType.Admin);
            TransactionTemplate.Execute(delegate
            {
                _partnerDao.Delete(instance);
                ActivityManager.LogAudit(NodeMethod.None, null, visit, "{0} deleted partner identity: {1}.",
                                         visit.Account.NaasAccount, instance.ToString());
                return null;
            });
        }
        /// <summary>
        /// GetAllPartnerNames
        /// </summary>
        public IDictionary<string, string> GetAllPartnerNames()
        {
            return _partnerDao.GetAllPartnerNames();
        }
        #region Properties
        public IPartnerDao PartnerDao
        {
            get { return _partnerDao; }
            set { _partnerDao = value; }
        }
        public INodeEndpointClientFactory NodeEndpointClientFactory
        {
            get { return _nodeEndpointClientFactory; }
            set { _nodeEndpointClientFactory = value; }
        }

        #endregion
    }
}
