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
            private DataService _dataService;

            public DataService DataService
            {
                get { return _dataService; }
                set { _dataService = value; }
            }
            private string _flowId;

            public string FlowId
            {
                get { return _flowId; }
                set { _flowId = value; }
            }
            private bool _isNewService;

            public bool IsNewService
            {
                get { return _isNewService; }
                set { _isNewService = value; }
            }
            private ICollection<string> _globalArgs;

            public ICollection<string> GlobalArgs
            {
                get { return _globalArgs; }
                set { _globalArgs = value; }
            }

            private ICollection<string> _dataSources;

            public ICollection<string> DataSources
            {
                get { return _dataSources; }
                set { _dataSources = value; }
            }
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

            private string _key;

            public string Key
            {
                get { return _key; }
                set { _key = value; }
            }
            private string _initialValue;

            public string InitialValue
            {
                get { return _initialValue; }
                set { _initialValue = value; }
            }
        }
        private DataModel _dataModel;
        private IFlowService _dataItemService;

        private readonly string SERVICE_TYPE_NONE = ServiceType.None.ToString();

        #endregion

        protected ICollection<SimpleDataService> GetDataServiceImplementersForFlow(string flowId)
        {
            try
            {
                return _dataItemService.GetDataServiceImplementersForFlow(flowId);
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
            ICollection<SimpleDataService> implementers = GetDataServiceImplementersForFlow(_dataModel.FlowId);
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
                    dataSourcesRepeater.DataSource = CreateDataSourcesModelList(implementer.DataSources);
                    dataSourcesRepeater.DataBind();
                }
                else
                {
                    typeDropDownList.Items.Clear();
                    typeDropDownList.Items.Add(SERVICE_TYPE_NONE);
                    typeDropDownList.SelectedValue = SERVICE_TYPE_NONE;
                    typeDropDownList.Enabled = false;
                    argsRepeater.DataSource = null;
                    argsRepeater.DataBind();
                    dataSourcesRepeater.DataSource = null;
                    dataSourcesRepeater.DataBind();
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
                if (_dataModel.DataService.Args != null)
                {
                    _dataModel.DataService.Args.TryGetValue(key, out initialValue);
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
                if (_dataModel.DataService.DataSources != null)
                {
                    DataProviderInfo dataProviderInfo;
                    if (_dataModel.DataService.DataSources.TryGetValue(key, out dataProviderInfo))
                    {
                        initialValue = dataProviderInfo.Name;
                    }
                }
                list.Add(new KeyInitialValueModel(key, initialValue));
            }
            return list;
        }

        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (_dataItemService == null)
            {
                throw new ArgumentNullException("_dataItemService");
            }
            AdminVisit visit = VisitHelper.GetVisit();
            string serviceId = Request["serviceid"];
            string flowId = Request["flowid"];
            if (string.IsNullOrEmpty(flowId))
            {
                throw new ArgumentException("Missing flow id");
            }
            string flowName = _dataItemService.GetFlowNameFromId(flowId, visit);
            if (string.IsNullOrEmpty(flowName))
            {
                throw new ArgumentException("Flow not found");
            }
            flowNameLabel.InnerText = flowName;
            _dataModel = new DataModel();
            _dataModel.FlowId = flowId;
            _dataModel.GlobalArgs = _dataItemService.GetGlobalArgs();
            _dataModel.DataSources = _dataItemService.GetDataSourceNames();
            if (!string.IsNullOrEmpty(serviceId))
            {
                _dataModel.DataService = _dataItemService.GetService(serviceId, visit);
                if (_dataModel.DataService == null)
                {
                    throw new ArgumentNullException("_dataModel.DataService");
                }
            }
            else
            {
                _dataModel.DataService = new DataService();
                _dataModel.DataService.FlowId = flowId;
                _dataModel.DataService.IsActive = true;
                _dataModel.IsNewService = true;
            }
            // Set this to the default for now
            _dataModel.DataService.MinAuthLevel = ServiceRequestAuthorizationType.Basic;
        }

        protected override void OnInitializeControls(EventArgs e)
        {
            base.OnInitializeControls(e);

            if (!IsPostBack)
            {
                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();

                publishDropDownList.DataSource = EnumUtils.GetAllDescriptions<DataServicePublishFlags>();
                publishDropDownList.DataBind();
                publishDropDownList.SelectedIndex = publishDropDownList.Items.Count - 1;

                ICollection<SimpleDataService> implementers = GetDataServiceImplementersForFlow(_dataModel.FlowId);
                if (!CollectionUtils.IsNullOrEmpty(implementers))
                {
                    implementerDropDownList.DataSource = implementers;
                    implementerDropDownList.DataTextField = "PluginInfoDisplayString";
                    implementerDropDownList.DataValueField = "PluginInfoImplementerString";
                    implementerDropDownList.DataBind();
                    implementerDropDownList.Items.Insert(0, NOT_SELECTED_TEXT);
                    implementerDropDownList.SelectedIndex = 0;
                    if (_dataModel.DataService.PluginInfo != null)
                    {
                        implementerDropDownList.SelectedValue = _dataModel.DataService.PluginInfo.ImplementerString;
                    }
                }
                else
                {
                    implementerDropDownList.Items.Clear();
                    implementerDropDownList.Enabled = false;
                    typeDropDownList.Items.Clear();
                    typeDropDownList.Enabled = false;
                }
                if (_dataModel.IsNewService)
                {
                    deleteBtn.Visible = false;
                }

                SyncControlsToCurrentImplementer();

                AspNetUtils.SetFocus(this, nameEdit, true);
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
            BindingManager.AddBinding("nameEdit.Text", "DataService.Name");
            BindingManager.AddBinding("PluginInfoBinder", "DataService.PluginInfo");
            BindingManager.AddBinding("activeCheckBox.Checked", "DataService.IsActive");
            BindingManager.AddBinding("ServiceTypeBinder", "DataService.Type");
            BindingManager.AddBinding("PublishFlagsBinder", "DataService.PublishFlags");
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

                    DataService.Name = DataService.Name.Trim();
                }
            }
            catch (Exception ex)
            {
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
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
                    return _dataModel.DataService.PluginInfo;
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
        protected DataServicePublishFlags PublishFlagsBinder
        {
            get
            {
                return EnumUtils.FromDescription<DataServicePublishFlags>(publishDropDownList.SelectedValue);
            }
            set
            {
                publishDropDownList.SelectedValue = EnumUtils.ToDescription(value);
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
                DataProviderInfo provider = _dataItemService.GetDataSourceByName(dsName);
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
                _dataModel.DataService.Args = GetServiceArguments();
                _dataModel.DataService.DataSources = GetServiceDataSources();
                _dataModel.DataService = _dataItemService.SaveService(_dataModel.DataService, VisitHelper.GetVisit());

                ResponseRedirect("../Secure/Flow.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
            }
        }

        protected void DeleteDataItem(object sender, EventArgs e)
        {
            try
            {
                _dataItemService.DeleteService(_dataModel.DataService, VisitHelper.GetVisit());
                ResponseRedirect("../Secure/Flow.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
            }
        }

        #region Properties

        public IFlowService DataItemService
        {
            get { return _dataItemService; }
            set { _dataItemService = value; }
        }
        public DataService DataService
        {
            get { return _dataModel.DataService; }
            set { _dataModel.DataService = value; }
        }
        #endregion

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
                argGlobalValueDropDownList.DataSource = _dataModel.GlobalArgs;
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
        }
        protected void dataSources_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DropDownList dataSourcesDropDownList = e.Item.FindControl("dataSourcesDropDownList") as DropDownList;
            if (dataSourcesDropDownList != null)
            {
                KeyInitialValueModel argumentModel = (KeyInitialValueModel)e.Item.DataItem;
                dataSourcesDropDownList.DataSource = _dataModel.DataSources;
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
