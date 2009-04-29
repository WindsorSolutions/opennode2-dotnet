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
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.Admin.Controls;
using Spring.DataBinding;
using Windsor.Commons.Core;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class ProfileEditNotifications : SecurePage
    {

        #region Members

        private class DataModel
        {
            UserAccount _dataItem;
            Dictionary<string, string> _controlToFlowNameMap = new Dictionary<string, string>();

            public Dictionary<string, string> ControlToFlowNameMap
            {
                get { return _controlToFlowNameMap; }
                set { _controlToFlowNameMap = value; }
            }
            public UserAccount DataItem
            {
                get { return _dataItem; }
                set { _dataItem = value; }
            }
        }
        private INotificationService _dataItemService;
        private DataModel _dataModel;

        #endregion

        protected string GetCheckboxListFlowName(CheckBoxList checkBoxList)
        {
            string id = checkBoxList.ClientID + "flow";
            string flowName = null;
            _dataModel.ControlToFlowNameMap.TryGetValue(id, out flowName);
            return flowName ?? string.Empty;
        }
        protected void SetCheckboxListFlowName(CheckBoxList checkBoxList, string flowName)
        {
            string id = checkBoxList.ClientID + "flow";
            _dataModel.ControlToFlowNameMap.Add(id, flowName);
        }

        protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            KeyValuePair<string, SimpleListDisplayInfo> pair =
                (KeyValuePair<string, SimpleListDisplayInfo>) e.Item.DataItem;
            NotificationType notificationType = (NotificationType)pair.Value.Element;
            CheckBoxList checkBoxList = e.Item.FindControl("checkBoxList") as CheckBoxList;
            if (checkBoxList != null)
            {
                SetCheckboxListNotifications(checkBoxList, notificationType);
                SetCheckboxListFlowName(checkBoxList, pair.Key);
            }
        }
        protected void SetCheckboxListNotifications(CheckBoxList checkBoxList, NotificationType notificationType)
        {
            if (notificationType != NotificationType.None)
            {
                IList<NotificationType> setNotifications = EnumUtils.GetEnumFlagsArray<NotificationType>(notificationType);
                if (!CollectionUtils.IsNullOrEmpty(setNotifications))
                {
                    foreach (NotificationType notification in setNotifications)
                    {
                        ListItem checkItem = checkBoxList.Items.FindByValue(notification.ToString());
                        if (checkItem != null)
                        {
                            checkItem.Selected = true;
                        }
                    }
                }
            }
        }
        protected NotificationType GetCheckboxListNotifications(CheckBoxList checkBoxList)
        {
            NotificationType notificationType = NotificationType.None;
            foreach (ListItem checkItem in checkBoxList.Items)
            {
                if (checkItem.Selected)
                {
                    notificationType |= EnumUtils.ParseEnum<NotificationType>(checkItem.Value);
                }
            }
            return notificationType;
        }
        protected void ToggleCheckboxList(CheckBoxList checkBoxList)
        {
            foreach (ListItem checkItem in checkBoxList.Items)
            {
                checkItem.Selected = !checkItem.Selected;
            }
        }
        protected IList<SimpleFlowNotification> GetAllFlowNotifications()
        {
            List<SimpleFlowNotification> flowNotifications = new List<SimpleFlowNotification>();
            foreach (RepeaterItem item in repeaterList.Items)
            {
                CheckBoxList checkBoxList = item.FindControl("checkBoxList") as CheckBoxList;
                if (checkBoxList != null)
                {
                    string flowName = GetCheckboxListFlowName(checkBoxList);
                    if (!string.IsNullOrEmpty(flowName))
                    {
                        NotificationType notifications = GetCheckboxListNotifications(checkBoxList);
                        if (notifications != NotificationType.None)
                        {
                            flowNotifications.Add(new SimpleFlowNotification(flowName, null, notifications));
                        }
                    }
                }
            }
            return flowNotifications;
        }
        protected void OnToggleClick(object sender, EventArgs e)
        {
            CheckBoxList checkBoxList = ((Control)sender).Parent.FindControl("checkBoxList") as CheckBoxList;
            if (checkBoxList != null)
            {
                ToggleCheckboxList(checkBoxList);
            }
        }
        protected void OnSaveClick(object sender, EventArgs e)
        {
            if (divPageError.Visible || !Page.IsValid)
            {
                // Error on page, get out of here
                return;
            }
            try
            {
                IList<SimpleFlowNotification> notifications = GetAllFlowNotifications();
                _dataModel.DataItem = _dataItemService.Save(_dataModel.DataItem, notifications, VisitHelper.GetVisit());
                ResponseRedirect("../Secure/Profile.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = UIUtility.ParseException(ex);
            }
        }
        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();
            
            if (_dataItemService == null)
            {
                throw new ArgumentNullException("DataItemService");
            }
            _dataModel = new DataModel();
            _dataModel.DataItem = VisitHelper.GetVisit().Account;
        }
        protected override void OnInitializeControls(EventArgs e)
        {
            base.OnInitializeControls(e);

            if (!IsPostBack)
            {
                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();

                repeaterList.ItemDataBound += new RepeaterItemEventHandler(repeater_ItemDataBound);
                repeaterList.DataSource = UIUtility.GetSortedList(_dataItemService.GetListInfo(_dataModel.DataItem.NaasAccount));
                repeaterList.DataBind();
            }
        }
        protected override void LoadModel(object savedModel)
        {
            _dataModel = (DataModel)savedModel;
        }

        protected override object SaveModel()
        {
            return _dataModel;
        }

        protected override void InitializeDataBindings()
        {
            //BindingManager.AddBinding("nameValue.Text", "DataItem.NaasAccount", 
            //                          BindingDirection.TargetToSource);
        }
        protected override void BindFormData()
        {
            try
            {
                if (!this.IsPostBack)
                {
                    base.BindFormData();
                }
            }
            catch (Exception ex)
            {
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
            }
        }
        protected override void UnbindFormData()
        {
            try
            {
                divPageError.Visible = false;

                this.Validate();

                if (this.IsValid)
                {
                    base.UnbindFormData();
                }
            }
            catch (Exception ex)
            {
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
            }
        }

        #endregion

        #region Properties

        public INotificationService DataItemService
        {
            get { return _dataItemService; }
            set { _dataItemService = value; }
        }

        public UserAccount DataItem
        {
            get { return _dataModel.DataItem; }
            set { _dataModel.DataItem = value; }
        }

        #endregion
    }
}
