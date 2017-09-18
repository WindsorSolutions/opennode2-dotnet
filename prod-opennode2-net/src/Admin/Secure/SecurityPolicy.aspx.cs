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
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Common.Logging;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.Admin.Controls;
using Spring.DataBinding;
using Windsor.Commons.Core;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class SecurityPolicy : SecurePage
    {
        #region Members

        public class DataModel
        {
            public List<string> _userList;
        }
        private DataModel _dataModel;
        private IPolicyService _dataItemService;

        #endregion

        private void RefreshListBox()
        {
            try
            {
                string filter = textNaasUserFilter.Text;
                List<string> userList = new List<string>(50);
                if (!string.IsNullOrEmpty(filter) && (_dataModel != null) && (_dataModel._userList != null))
                {
                    foreach (string userName in _dataModel._userList)
                    {
                        if (userName.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase))
                        {
                            userList.Add(userName);
                        }
                    }
                }
                listNaasUsers.DataSource = userList;
                listNaasUsers.DataBind();
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = UIUtility.ParseException(ex);
            }
        }


        protected void RefreshList(object sender, EventArgs e)
        {
            try
            {
                _dataModel._userList = new List<string>(_dataItemService.GetNaasUsernameList(true, true, VisitHelper.GetVisit()));
                RefreshListBox();
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = UIUtility.ParseException(ex);
            }
        }


        #region Spring Biding Stuff
        protected override void OnInit(EventArgs e)
        {
            if (_dataItemService == null)
            {
                throw new ArgumentNullException("_dataItemService");
            }
            base.OnInit(e);

            if (_dataModel == null)
            {
                throw new ArgumentNullException("_dataModel");
            }
        }
        protected override void InitializeModel()
        {
            base.InitializeModel();

            _dataModel = new DataModel();
            try
            {
                _dataModel._userList = new List<string>(_dataItemService.GetNaasUsernameList(false, true, VisitHelper.GetVisit()));
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = UIUtility.ParseException(ex);
            }
        }

        protected override void OnInitializeControls(EventArgs e)
        {
            base.OnInitializeControls(e);

            if (!IsPostBack)
            {
                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();
            }

            AspNetUtils.SetFocus(this, textNaasUserFilter, true);
        }
        protected override void LoadModel(object savedModel)
        {
            _dataModel = (DataModel)savedModel;
        }

        protected override object SaveModel()
        {
            return _dataModel;
        }
        #endregion

        #region Properties

        public IPolicyService DataItemService
        {
            get { return _dataItemService; }
            set { _dataItemService = value; }
        }

        #endregion

        protected void textNaasUserFilter_TextChanged(object sender, EventArgs e)
        {
            RefreshListBox();
        }

        protected void selectBtn_Click(object sender, EventArgs e)
        {
            if (listNaasUsers.SelectedIndex > -1)
            {
                string username = listNaasUsers.SelectedItem.Value;
                int index = username.LastIndexOf('(');
                if (index > 0)
                {
                    username = username.Substring(0, index).Trim();
                }
                try
                {
                    UserAccount userAccount = _dataItemService.Get(username, VisitHelper.GetVisit());
                    ResponseRedirect("SecurityPolicyEdit.aspx?id=" + username);
                }
                catch (ArgumentException)
                {
                    ResponseRedirect("SecurityPolicyEdit.aspx?naas=" + HttpUtility.UrlEncode(username));
                }
            }
            else
            {
                divPageError.Visible = true;
                if (listNaasUsers.Items.Count < 1)
                {
                    divPageError.InnerText = "Please enter the first few characters of the NAAS account you would like to select.";
                }
                else
                {
                    divPageError.InnerText = "Please select a NAAS account from the list box.";
                }
            }
        }
    }
}
