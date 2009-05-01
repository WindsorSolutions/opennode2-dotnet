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
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Node2008.Admin.Controls;

namespace Windsor.Node2008.Admin
{

    public partial class AdminMaster : Spring.Web.UI.MasterPage
    {
        public ILog LOG;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            LOG = LogManager.GetLogger(Page.AppRelativeVirtualPath);
            LOG.Debug("Path: " + Page.AppRelativeVirtualPath);
        }

        /// <summary>
        /// Setup page content
        /// </summary>
        /// <param name="tabItems"></param>
        /// <param name="activeIndex"></param>
        public void SetupPage(SideTabItem[] tabItems, int activeIndex)
        {
            menuItems.DataSource = tabItems;
            menuItems.DataBind();

            if (menuItems.Items.Count > 0)
            {
                foreach (RepeaterItem item in menuItems.Items)
                {
                    HyperLink link = item.FindControl("linkButton") as HyperLink;

                    if (link != null)
                    {
                        link.Attributes.Clear();

                        if (item.ItemIndex == activeIndex)
                        {
                            link.Attributes.Add("class", "current");
                        }
                    }
                }
            }
            else
            {
//                menu.Visible = false;
                menuPanel.Visible = false;
            }
        }
        protected string GetTabClass(string path)
        {
            if (path == null || !(Page.AppRelativeVirtualPath.Trim().ToLower().Contains(path.Trim().ToLower())))
            {
                return string.Empty;
            } 
            else
            {
                return "current"; 
            }
        }


        protected string GetUserInfo()
        {
            AdminVisit visit = VisitHelper.GetVisit();
            if (visit == null || visit.Account == null)
            {
                return "Anonymous User";
            }
            else
            {
                return string.Format("{0}&nbsp;as&nbsp;{1}", visit.Account.NaasAccount, visit.Account.Role);
            }
        }

        protected void BulletedList1_DataBound(object sender, EventArgs e)
        {

        }
    }
}
