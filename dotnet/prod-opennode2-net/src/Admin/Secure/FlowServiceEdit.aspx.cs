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
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.Caching;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Common.Logging;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.Admin.Controls;
using Windsor.Node2008.WNOSUtility;
using Spring.DataBinding;
using Windsor.Node2008.WNOSConnector.Server;
using Windsor.Commons.Core;
using Wintellect.PowerCollections;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class FlowServiceEdit : SecurePage
    {
        #region Members

        private class DataModel
        {
            public DataService DataService { get; set; }
            public string FlowId { get; set; }
            public bool IsNewService { get; set; }
            public ICollection<string> GlobalArgs { get; set; }
            public ICollection<string> DataSources { get; set; }
        }
        private class KeyInitialValueModel : IComparable<KeyInitialValueModel>
        {
            public KeyInitialValueModel(string key, string initialValue)
            {
                Key = key;
                InitialValue = initialValue;
            }
            public int CompareTo(KeyInitialValueModel other)
            {
                return string.Compare(Key, other.Key);
            }
            public string Key { get; set; }
            public string InitialValue { get; set; }
        }
        private DataModel Model { get; set; }
        private bool _disableRepeaterEditing;
        public IFlowService FlowService { get; set; }

        private readonly string SERVICE_TYPE_NONE = ServiceType.None.ToString();

        #endregion

        protected ICollection<SimpleDataService> GetDataServiceImplementersForFlow(string flowId)
        {
            try
            {
                return FlowService.GetDataServiceImplementersForFlow(flowId);
            }
            catch (Exception)
            {
                return null;
            }
        }
        protected SimpleDataService GetDataServiceImplementer(string pluginInfoImplementerString)
        {
            if (pluginInfoImplementerString == NOT_SELECTED_TEXT)
            {
                return null;
            }
            ICollection<SimpleDataService> implementers = GetDataServiceImplementersForFlow(Model.FlowId);
            if (!CollectionUtils.IsNullOrEmpty(implementers))
            {
                foreach (SimpleDataService implementer in implementers)
                {
                    if (implementer.PluginInfoImplementerString == pluginInfoImplementerString)
                    {
                        return implementer;
                    }
                }
            }
            return null;
        }
        protected void SyncControlsToCurrentImplementer()
        {
            if (implementerDropDownList.Items.Count > 1)
            {
                SimpleDataService implementer = GetDataServiceImplementer(implementerDropDownList.SelectedValue);
                if (implementer != null)
                {
                    if (implementer.Type == ServiceType.None)
                    {
                        typeDropDownList.Items.Clear();
                        typeDropDownList.Items.Add(SERVICE_TYPE_NONE);
                        typeDropDownList.SelectedValue = SERVICE_TYPE_NONE;
                        typeDropDownList.Enabled = false;
                    }
                    else
                    {
                        typeDropDownList.DataSource = EnumUtils.GetAllDescriptions(implementer.Type);
                        typeDropDownList.DataBind();
                        typeDropDownList.Enabled = true;
                    }
                    argsRepeater.DataSource = CreateArgumentModelList(implementer.Args);
                    argsRepeater.DataBind();
                    argumentsTableRow.Visible = (argsRepeater.DataSource != null);
                    dataSourcesRepeater.DataSource = CreateDataSourcesModelList(implementer.DataSources);
                    dataSourcesRepeater.DataBind();
                    dataSourcesTableRow.Visible = (dataSourcesRepeater.DataSource != null);
                }
                else
                {
                    typeDropDownList.Items.Clear();
                    typeDropDownList.Items.Add(SERVICE_TYPE_NONE);
                    typeDropDownList.SelectedValue = SERVICE_TYPE_NONE;
                    typeDropDownList.Enabled = false;
                    argsRepeater.DataSource = null;
                    argsRepeater.DataBind();
                    argumentsTableRow.Visible = false;
                    dataSourcesRepeater.DataSource = null;
                    dataSourcesRepeater.DataBind();
                    dataSourcesTableRow.Visible = false;
                }
            }
            else
            {
            }
        }

        private IEnumerable<KeyInitialValueModel> CreateArgumentModelList(IEnumerable<string> argKeys)
        {
            if (argKeys == null)
            {
                return null;
            }
            OrderedSet<KeyInitialValueModel> list = new OrderedSet<KeyInitialValueModel>();
            foreach (string key in argKeys)
            {
                string initialValue = string.Empty;
                if (Model.DataService.Args != null)
                {
                    Model.DataService.Args.TryGetValue(key, out initialValue);
                }
                list.Add(new KeyInitialValueModel(key, initialValue));
            }
            return list;
        }
        private IEnumerable<KeyInitialValueModel> CreateDataSourcesModelList(IEnumerable<string> dataSourceKeys)
        {
            if (dataSourceKeys == null)
            {
                return null;
            }
            OrderedSet<KeyInitialValueModel> list = new OrderedSet<KeyInitialValueModel>();
            foreach (string key in dataSourceKeys)
            {
                string initialValue = string.Empty;
                if (Model.DataService.DataSources != null)
                {
                    DataProviderInfo dataProviderInfo;
                    if (Model.DataService.DataSources.TryGetValue(key, out dataProviderInfo))
                    {
                        initialValue = dataProviderInfo.Name;
                    }
                }
                list.Add(new KeyInitialValueModel(key, initialValue));
            }
            return list;
        }

        #region Spring Biding Stuff

        protected override void OnInit(EventArgs e)
        {
            if (FlowService == null)
            {
                throw new ArgumentNullException("Missing FlowService");
            }
            base.OnInit(e);
        }

        protected void LoadModel()
        {
            try
            {
                NodeVisit visit = VisitHelper.GetVisit();
                string serviceId = Request["serviceid"];
                string flowId = Request["flowid"];
                if (string.IsNullOrEmpty(flowId))
                {
                    throw new ArgumentException("Missing flow id");
                }
                if (!CanViewFlowById(flowId))
                {
                    ResponseRedirect("~/Secure/Flow.aspx");
                    return;
                }
                string flowName = FlowService.GetFlowNameFromId(flowId, visit);
                if (string.IsNullOrEmpty(flowName))
                {
                    throw new ArgumentException("Flow not found");
                }
                flowNameLabel.Text = flowName;
                Model = new DataModel();
                Model.FlowId = flowId;
                Model.GlobalArgs = FlowService.GetGlobalArgs();
                Model.DataSources = FlowService.GetDataSourceNames();
                if (!string.IsNullOrEmpty(serviceId))
                {
                    Model.DataService = FlowService.GetService(serviceId, visit);
                    if (Model.DataService == null)
                    {
                        throw new ArgumentNullException("Model.DataService");
                    }
                }
                else
                {
                    Model.DataService = new DataService();
                    Model.DataService.FlowId = flowId;
                    Model.DataService.IsActive = true;
                    Model.IsNewService = true;
                }
            }
            catch (Exception ex)
            {
                Model = null;
                SetDivPageError("Failed to load data for flow service: ", ex);
            }
        }
        protected void ControlsToModel()
        {
            Model.DataService.Name = nameEdit.Text.Trim();
            Model.DataService.PluginInfo = PluginInfoBinder;
            Model.DataService.IsActive = activeCheckBox.Checked;
            Model.DataService.Type = ServiceTypeBinder;
            Model.DataService.PublishFlags = DataServicePublishFlags.PublishToEndpointVersion11And20;
            Model.DataService.Args = GetServiceArguments();
            Model.DataService.DataSources = GetServiceDataSources();
        }
        protected override void OnInitializeControls(EventArgs e)
        {
            LoadModel();

            if (Response.IsRequestBeingRedirected)
            {
                return;
            }

            base.OnInitializeControls(e);

            bool disableEditing = (Model == null);

            if (!disableEditing && !this.IsPostBack)
            {
                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();

                _disableRepeaterEditing = disableEditing = !CanEditFlowById(Model.FlowId);

                ICollection<SimpleDataService> implementers = GetDataServiceImplementersForFlow(Model.FlowId);
                if (!CollectionUtils.IsNullOrEmpty(implementers))
                {
                    implementerDropDownList.DataSource = implementers;
                    implementerDropDownList.DataTextField = "PluginInfoDisplayString";
                    implementerDropDownList.DataValueField = "PluginInfoImplementerString";
                    implementerDropDownList.DataBind();
                    implementerDropDownList.Items.Insert(0, NOT_SELECTED_TEXT);
                    implementerDropDownList.SelectedIndex = 0;
                    if (Model.DataService.PluginInfo != null)
                    {
                        implementerDropDownList.SelectedValue = Model.DataService.PluginInfo.ImplementerString;
                    }
                }
                else
                {
                    implementerDropDownList.Items.Clear();
                    implementerDropDownList.Enabled = false;
                    typeDropDownList.Items.Clear();
                    typeDropDownList.Enabled = false;
                }
                if (Model.IsNewService)
                {
                    deleteBtn.Visible = false;
                    activeCheckBox.Checked = true;
                }
                else
                {
                    nameEdit.Text = Model.DataService.Name;
                    PluginInfoBinder = Model.DataService.PluginInfo;
                    activeCheckBox.Checked = Model.DataService.IsActive;
                    ServiceTypeBinder = Model.DataService.Type;
                }

                SyncControlsToCurrentImplementer();
            }
            if (disableEditing)
            {
                nameEdit.Enabled = implementerDropDownList.Enabled = typeDropDownList.Enabled =
                    activeCheckBox.Enabled = false;
                deleteBtn.Visible = saveBtn.Visible = false;
                CustomValidator7.Visible = false;
                flowNameLabel.Enabled = false;
                cancelBtn.Text = "Back";
            }
            _disableRepeaterEditing = !nameEdit.Enabled;
            if (nameEdit.Enabled)
            {
                AspNetUtils.SetFocus(this, nameEdit, true);
            }
        }
        #endregion

        protected ExecutableInfo PluginInfoBinder
        {
            get
            {
                if (implementerDropDownList.Enabled)
                {
                    if (implementerDropDownList.SelectedValue == NOT_SELECTED_TEXT)
                    {
                        return null;
                    }
                    else
                    {
                        return new ExecutableInfo(implementerDropDownList.SelectedValue);
                    }
                }
                else
                {
                    return Model.DataService.PluginInfo;
                }
            }
            set
            {
                if (value != null)
                {
                    implementerDropDownList.SelectedValue = value.ImplementerString;
                }
                else
                {
                    implementerDropDownList.SelectedIndex = 0;
                }
            }
        }
        protected ServiceType ServiceTypeBinder
        {
            get
            {
                if (typeDropDownList.SelectedValue == SERVICE_TYPE_NONE)
                {
                    return ServiceType.None;
                }
                else
                {
                    return EnumUtils.FromDescription<ServiceType>(typeDropDownList.SelectedValue);
                }
            }
            set
            {
                if (value == ServiceType.None)
                {
                    typeDropDownList.SelectedValue = SERVICE_TYPE_NONE;
                }
                else
                {
                    typeDropDownList.SelectedValue = EnumUtils.ToDescription(value);
                }
            }
        }
        protected Dictionary<string, string> GetServiceArguments()
        {
            Repeater repeater = argsRepeater;
            Dictionary<string, string> args = null;
            foreach (RepeaterItem item in repeater.Items)
            {
                DropDownList argGlobalValueDropDownList = item.FindControl("argGlobalValueDropDownList") as DropDownList;
                TextBox argValueEdit = item.FindControl("argValueEdit") as TextBox;
                Label argKeyLabel = item.FindControl("keyValueLabel") as Label;
                string key = argKeyLabel.Text;
                string value = null;
                if ((argGlobalValueDropDownList != null) && argGlobalValueDropDownList.Visible)
                {
                    if (argGlobalValueDropDownList.SelectedValue == NOT_SELECTED_TEXT)
                    {
                        throw new ArgumentException(string.Format("Value not selected for argument: {0}", key));
                    }
                    value = ConfigItem.GLOBAL_ARG_INDICATOR + argGlobalValueDropDownList.SelectedValue;
                }
                else if ((argValueEdit != null) && argValueEdit.Visible)
                {
                    value = argValueEdit.Text;
                }
                if (value == null)
                {
                    throw new ArgumentNullException(string.Format("Could not find argument value for key: {0}", key));
                }
                if (args == null)
                {
                    args = new Dictionary<string, string>();
                }
                args.Add(key, value);
            }
            return args;
        }
        protected Dictionary<string, DataProviderInfo> GetServiceDataSources()
        {
            Repeater repeater = dataSourcesRepeater;
            Dictionary<string, DataProviderInfo> sources = null;
            foreach (RepeaterItem item in repeater.Items)
            {
                Label dsKeyLabel = item.FindControl("dsKeyValueLabel") as Label;
                string key = dsKeyLabel.Text;
                DropDownList dataSourcesDropDownList = item.FindControl("dataSourcesDropDownList") as DropDownList;
                if ( dataSourcesDropDownList == null )
                {
                    throw new ArgumentNullException(string.Format("Could not find dataSourcesDropDownList for key: {0}", key));
                }
                if (dataSourcesDropDownList.SelectedValue == NOT_SELECTED_TEXT)
                {
                    throw new ArgumentException(string.Format("Data source not selected for key: {0}", key));
                }
                string dsName = dataSourcesDropDownList.SelectedValue;
                DataProviderInfo provider = FlowService.GetDataSourceByName(dsName);
                if (provider == null)
                {
                    throw new ArgumentNullException(string.Format("Could not find data source: {0}", dsName));
                }
                if (sources == null)
                {
                    sources = new Dictionary<string, DataProviderInfo>();
                }
                sources.Add(key, provider);
            }
            return sources;
        }
        protected void CancelItem(object sender, EventArgs e)
        {
            ResponseRedirect("../Secure/Flow.aspx");
        }
        protected void SaveDataItem(object sender, EventArgs e)
        {
            if (divPageError.Visible || !Page.IsValid)
            {
                // Error on page, get out of here
                return;
            }
            try
            {
                ControlsToModel();

                Model.DataService = FlowService.SaveService(Model.DataService, VisitHelper.GetVisit());

                ResponseRedirect("../Secure/Flow.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                SetDivPageError(ex);
            }
        }

        protected void DeleteDataItem(object sender, EventArgs e)
        {
            try
            {
                FlowService.DeleteService(Model.DataService, VisitHelper.GetVisit());

                ResponseRedirect("../Secure/Flow.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                SetDivPageError(ex);
            }
        }

        protected void implementerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SyncControlsToCurrentImplementer();
        }
        protected void OnGlobalValueCheckBoxChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                DropDownList argGlobalValueDropDownList = checkBox.Parent.FindControl("argGlobalValueDropDownList") as DropDownList;
                TextBox argValueEdit = checkBox.Parent.FindControl("argValueEdit") as TextBox;
                if (argGlobalValueDropDownList != null) argGlobalValueDropDownList.Visible = checkBox.Checked;
                if (argValueEdit != null) argValueEdit.Visible = !checkBox.Checked;
            }
        }
        protected void argsRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DropDownList argGlobalValueDropDownList = e.Item.FindControl("argGlobalValueDropDownList") as DropDownList;
            if (argGlobalValueDropDownList != null)
            {
                argGlobalValueDropDownList.DataSource = Model.GlobalArgs;
                argGlobalValueDropDownList.DataBind();
                argGlobalValueDropDownList.Items.Insert(0, NOT_SELECTED_TEXT);
                argGlobalValueDropDownList.SelectedIndex = 0;
            }
            TextBox argValueEdit = e.Item.FindControl("argValueEdit") as TextBox;
            KeyInitialValueModel argumentModel = (KeyInitialValueModel)e.Item.DataItem;
            CheckBox checkBox = e.Item.FindControl("globalValueCheckBox") as CheckBox;
            bool isGlobalArg =
                ((argumentModel.InitialValue != null) && argumentModel.InitialValue.StartsWith(ConfigItem.GLOBAL_ARG_INDICATOR));
            if (isGlobalArg)
            {
                if (checkBox != null) checkBox.Checked = true;
                if (argValueEdit != null) argValueEdit.Visible = false;
                if (argGlobalValueDropDownList != null)
                {
                    argGlobalValueDropDownList.Visible = true;
                    string globalArg = argumentModel.InitialValue.Substring(1);
                    argGlobalValueDropDownList.SelectedValue = globalArg;
                    if (argGlobalValueDropDownList.SelectedValue == globalArg)
                    {
                        argGlobalValueDropDownList.Items.RemoveAt(0);
                    }
                }
            }
            else
            {
                if (checkBox != null) checkBox.Checked = false;
                if (argValueEdit != null)
                {
                    argValueEdit.Visible = true;
                    if (argumentModel.InitialValue != null)
                    {
                        argValueEdit.Text = argumentModel.InitialValue;
                    }
                }
                if (argGlobalValueDropDownList != null) argGlobalValueDropDownList.Visible = false;
            }
            if (_disableRepeaterEditing)
            {
                argGlobalValueDropDownList.Enabled = false;
                argValueEdit.Enabled = false;
                checkBox.Enabled = false;
            }
        }
        protected bool DisableRepeaterEditing()
        {
            return _disableRepeaterEditing;
        }
        protected void dataSources_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DropDownList dataSourcesDropDownList = e.Item.FindControl("dataSourcesDropDownList") as DropDownList;
            if (dataSourcesDropDownList != null)
            {
                KeyInitialValueModel argumentModel = (KeyInitialValueModel)e.Item.DataItem;
                dataSourcesDropDownList.DataSource = Model.DataSources;
                dataSourcesDropDownList.DataBind();
                bool didSet = false;
                if (argumentModel.InitialValue != null)
                {
                    dataSourcesDropDownList.SelectedValue = argumentModel.InitialValue;
                    didSet = (dataSourcesDropDownList.SelectedValue == argumentModel.InitialValue);
                }
                if (!didSet)
                {
                    dataSourcesDropDownList.Items.Insert(0, NOT_SELECTED_TEXT);
                    dataSourcesDropDownList.SelectedIndex = 0;
                }
                if (_disableRepeaterEditing)
                {
                    dataSourcesDropDownList.Enabled = false;
                }
            }
        }
        protected void ServerValidateDataSource(Object source, ServerValidateEventArgs e)
        {
            CustomValidator validator = (CustomValidator)source;
            Control control = AspNetUtils.FindDeepControl(validator.Parent, validator.ControlToValidate);
            e.IsValid = true;
            if (control != null)
            {
                DropDownList list = control as DropDownList;
                if (list != null)
                {
                    e.IsValid = (list.SelectedValue != NOT_SELECTED_TEXT);
                }
            }
        }
        protected void ServerValidateGlobalValue(Object source, ServerValidateEventArgs e)
        {
            CustomValidator validator = (CustomValidator)source;
            Control control = AspNetUtils.FindDeepControl(validator.Parent, validator.ControlToValidate);
            e.IsValid = true;
            if (control != null)
            {
                DropDownList list = control as DropDownList;
                if ((list != null) && list.Visible)
                {
                    e.IsValid = (list.SelectedValue != NOT_SELECTED_TEXT);
                }
            }
        }
    }
}
