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
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Common.Logging;

using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.Admin.Controls;
using Windsor.Commons.Core;

namespace Windsor.Node2008.Admin
{
    public abstract class SecurePage : AnonPage
    {
        #region Members 

        private AdminMaster _SecureMasterPage;
        private SideTabItem[] _sideTabs;
        private int _selectedTabIndex;
        private string _sectionTitle;
        private HtmlContainerControl _divPageError;

        #endregion

        /* Lifecycle
        OnInit() -> { 
         *              if ( !Postback ) InitializeModel(); 
         *              OnInitializeControls();
         *          }

        if ( Postback ) UnbindFormData()

        Page_Load()

        BindFormData()
        */
        protected override void OnInit(EventArgs e)
        {
            VisitHelper.CheckVisit();

            _SecureMasterPage = (AdminMaster)Page.Master;

            base.OnInit(e);
        }
        protected override void OnInitializeControls(EventArgs e)
        {
            base.OnInitializeControls(e);

            if (!IsPostBack)
            {
                SecureMasterPage.SetupPage(SideTabs, SelectedTabIndex);
            }
        }

        protected override void UnbindFormData()
        {
            try
            {
                ClearDivPageError();

                base.UnbindFormData();
            }
            catch (Exception ex)
            {
                SetDivPageError(ex);
            }
        }
        protected virtual void ClearDivPageError()
        {
            HtmlContainerControl pageErrorDiv = PageErrorDiv;
            if (pageErrorDiv != null)
            {
                pageErrorDiv.Visible = false;
                pageErrorDiv.InnerText = string.Empty;
            }
        }
        protected void AppendDivPageError(Exception ex)
        {
            AppendDivPageError(UIUtility.ParseException(ex), false, null);
        }
        protected void AppendDivPageError(string errorMessage, params string[] args)
        {
            AppendDivPageError(errorMessage, true, args);
        }
        protected void AppendDivPageError(string errorMessage, bool addBullet, params string[] args)
        {
            AppendDivPageError(null, errorMessage, addBullet, args);
        }
        protected void AppendDivPageError(HtmlContainerControl pageErrorDiv, string errorMessage, bool addBullet, 
                                          params string[] args)
        {
            if (pageErrorDiv != null)
            {
                if (!CollectionUtils.IsNullOrEmpty(args))
                {
                    errorMessage = string.Format(errorMessage, args);
                }
                string prefix = addBullet ? "<p>* " : "<p>";
                pageErrorDiv.InnerHtml += string.Format("{0}{1}</p>", prefix, HttpUtility.HtmlEncode(errorMessage));
                pageErrorDiv.Visible = true;
            }
        }
        protected void SetDivPageError(HtmlContainerControl pageErrorDiv, Exception ex)
        {
            SetDivPageError(pageErrorDiv, UIUtility.ParseException(ex), null);
        }
        protected void SetDivPageError(Exception ex)
        {
            SetDivPageError(UIUtility.ParseException(ex), null);
        }
        protected void SetDivPageError(string errorMessage, params string[] args)
        {
            SetDivPageError(null, errorMessage, args);
        }
        protected void SetDivPageError(HtmlContainerControl pageErrorDiv, string errorMessage, params string[] args)
        {
            if (pageErrorDiv == null)
            {
                pageErrorDiv = PageErrorDiv;
            }
            if (pageErrorDiv != null)
            {
                if (!CollectionUtils.IsNullOrEmpty(args))
                {
                    errorMessage = string.Format(errorMessage, args);
                }
                pageErrorDiv.InnerHtml = string.Format("<p>{0}</p>", HttpUtility.HtmlEncode(errorMessage));
                pageErrorDiv.Visible = true;
            }
        }
        protected HtmlContainerControl PageErrorDiv
        {
            get {
                if (_divPageError == null)
                {
                    _divPageError = AspNetUtils.FindDeepControl<HtmlContainerControl>(this, "divPageError");
                }
                return _divPageError;
            }
        }
        #region Properties

        public AdminMaster SecureMasterPage
        {
            get { return _SecureMasterPage; }
        }

        public SideTabItem[] SideTabs
        {
            get { return _sideTabs; }
            set { _sideTabs = value; }
        }

        public string SectionTitle
        {
            get { return _sectionTitle; }
            set { _sectionTitle = value; }
        }



        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set { _selectedTabIndex = value; }
        }

        #endregion

    }
}
