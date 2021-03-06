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
//#define BYPASS_LOGIN

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using System.Threading;

using Common.Logging;

using Windsor.Node2008.WNOSConnector;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSConnector.Service;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.Admin
{
    public partial class Login : AnonPage
    {

        #region Members

        private ISecurityService _securityService;
        private IAccountService _accountService;
        private IVisitProvider _visitProvider;
        private IFlowService _flowService;

        private string _messageOnSignOut = "Secure session successfully terminated";


        #endregion

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            FieldNotInitializedException.ThrowIfNull(this, ref _securityService);
            FieldNotInitializedException.ThrowIfNull(this, ref _accountService);
            FieldNotInitializedException.ThrowIfNull(this, ref _visitProvider);
            FieldNotInitializedException.ThrowIfNull(this, ref _flowService);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CheckToBypassLogin())
            {
                return;
            }

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["a"] != null)
                {
                    switch (Request.QueryString["a"])
                    {
                        case "out":
                            FormsAuthentication.SignOut();
                            Session.Abandon();
                            divPageError.Visible = true;
                            divPageError.InnerText = _messageOnSignOut;
                            break;

                        default:
                            break;
                    }
                }
                username.Focus();
            }
        }

        protected bool CheckToBypassLogin()
        {
#if BYPASS_LOGIN
            if (Debugger.IsAttached)
            {
                UserAccount userAccount = null;
                long endTicks = DateTime.Now.Ticks + TimeSpan.FromSeconds(30).Ticks;
                Exception ex = null;
                do
                {
                    try
                    {
                        userAccount = _accountService.Get("ted@windsorsolutions.com", null);
                        //userAccount = _accountService.Get("tedm@windsorsolutions.com", null);
                        //userAccount = _accountService.Get("tedm2@windsorsolutions.com", null); 
                        break;
                    }
                    catch (Exception e)
                    {
                        ex = e;
                        Thread.Sleep(250);
                    }
                } while (endTicks > DateTime.Now.Ticks);
                if (userAccount == null)
                {
                    throw ex;
                }
                IDictionary<string, string> flowsIdToNameMap = FlowService.GetAllFlowsIdToNameMap();
                NodeVisit visit = new NodeVisit(userAccount, _visitProvider.GetRequestorIP(),
                                                flowsIdToNameMap);

                Session[Constants.AUTH_SESSION_NAME] = visit;

                FormsAuthentication.RedirectFromLoginPage(userAccount.NaasAccount, false);
                return true;
            }
#endif // BYPASS_LOGIN
            return false;
        }
        protected void DoLogin(object sender, EventArgs e)
        {
            try
            {
                string usernameText = username.Value.Trim(), passwordText = password.Value.Trim();
                NodeVisit visit = _securityService.AuthenticateAdmin(
                    new AuthenticationCredentials(usernameText, passwordText),
                    _visitProvider.GetRequestorIP());

                _accountService.ValidateUserMinimumRole(visit, SystemRoleType.Program);

                Session[Constants.AUTH_SESSION_NAME] = visit;

                FormsAuthentication.RedirectFromLoginPage(usernameText, false);

            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = UIUtility.ParseException(ex);
            }

        }


        #region Properties

        public ISecurityService SecurityService
        {
            set
            {
                _securityService = value;
            }
        }

        public string MessageOnSignOut
        {
            set
            {
                _messageOnSignOut = value;
            }
        }

        public IAccountService AccountService
        {
            get
            {
                return _accountService;
            }
            set
            {
                _accountService = value;
            }
        }

        public IVisitProvider VisitProvider
        {
            get
            {
                return _visitProvider;
            }
            set
            {
                _visitProvider = value;
            }
        }
        public IFlowService FlowService
        {
            get
            {
                return _flowService;
            }
            set
            {
                _flowService = value;
            }
        }
        #endregion
    }
}
