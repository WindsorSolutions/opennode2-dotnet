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
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class ScheduleEdit : SecurePage
    {
        #region Members

        private class DataModel
        {
            private bool _isNewSchedule;

            public bool IsNewSchedule
            {
                get { return _isNewSchedule; }
                set { _isNewSchedule = value; }
            }

            private ScheduledItem _scheduledItem;

            public ScheduledItem ScheduledItem
            {
                get { return _scheduledItem; }
                set { _scheduledItem = value; }
            }

            private IList<KeyValuePair<string, string>> _localServiceList;

            public IList<KeyValuePair<string, string>> LocalServiceList
            {
                get { return _localServiceList; }
                set { _localServiceList = value; }
            }

            private IList<string> _validSchematronFlowNames;

            public IList<string> ValidSchematronFlowNames
            {
              get { return _validSchematronFlowNames; }
              set { _validSchematronFlowNames = value; }
            }
            private IList<KeyValuePair<string, string>> _submitServiceList;

            public IList<KeyValuePair<string, string>> SubmitServiceList
            {
                get { return _submitServiceList; }
                set { _submitServiceList = value; }
            }

        }
        private DataModel _dataModel;
        private IScheduleService _dataItemService;
        private INodeProcessor _scheduleProcessor;
        private readonly DateTime MIN_VALID_DATE = new DateTime(1900, 1, 1);
        private readonly DateTime MAX_VALID_DATE = new DateTime(3000, 1, 1);

        #endregion

        protected void ShowHideDataSourceControls()
        {
            ScheduledItemSourceType selectedSource =
                EnumUtils.ParseEnum<ScheduledItemSourceType>(dataSourceRadioButtonList.SelectedValue);
            switch (selectedSource)
            {
                case ScheduledItemSourceType.LocalService:
                    sourceLocalServiceDropDownList.Visible = sourceLocalServiceDropDownListValidator.Visible = true;
                    sourcePartnerDropDownList.Visible = sourcePartnerDropDownListValidator.Visible = false;
                    additionalArgumentsPanel.Visible = true;
                    fileSourceTextBox.Visible = fileSourceTextBoxValidator.Visible = false;
                    sourceExchangeLabel.Visible = sourceExchangeTextBox.Visible = customValidatorSourceExchange.Visible = false;
                    sourceRequestLabel.Visible = sourceRequestTextBox.Visible = customValidatorSourceRequest.Visible = false;
                    byNameValueRadioButton.Enabled = byValueRadioButton.Enabled = true;
                    nameValueArgsPanel.Visible = byNameValueRadioButton.Checked;
                    valueArgsPanel.Visible = !byNameValueRadioButton.Checked;
                    break;
                case ScheduledItemSourceType.WebServiceQuery:
                case ScheduledItemSourceType.WebServiceSolicit:
                    sourceLocalServiceDropDownList.Visible = sourceLocalServiceDropDownListValidator.Visible = false;
                    sourcePartnerDropDownList.Visible = sourcePartnerDropDownListValidator.Visible = true;
                    additionalArgumentsPanel.Visible = true;
                    fileSourceTextBox.Visible = fileSourceTextBoxValidator.Visible = false;
                    bool is20Endpoint = (GetPartnerVersionFromSourcePartnerDropDownList() == EndpointVersionType.EN20);
                    sourceExchangeLabel.Visible = sourceExchangeTextBox.Visible = customValidatorSourceExchange.Visible =
                        is20Endpoint;
                    sourceRequestLabel.Visible = sourceRequestTextBox.Visible = customValidatorSourceRequest.Visible = true;
                    byNameValueRadioButton.Checked = is20Endpoint;
                    byValueRadioButton.Checked = !is20Endpoint;
                    byNameValueRadioButton.Enabled = byValueRadioButton.Enabled = false;
                    nameValueArgsPanel.Visible = is20Endpoint;
                    valueArgsPanel.Visible = !is20Endpoint;
                    break;
                case ScheduledItemSourceType.File:
                    sourceLocalServiceDropDownList.Visible = sourceLocalServiceDropDownListValidator.Visible = false;
                    sourcePartnerDropDownList.Visible = sourcePartnerDropDownListValidator.Visible = false;
                    additionalArgumentsPanel.Visible = false;
                    fileSourceTextBox.Visible = fileSourceTextBoxValidator.Visible = true;
                    sourceExchangeLabel.Visible = sourceExchangeTextBox.Visible = customValidatorSourceExchange.Visible = false;
                    sourceRequestLabel.Visible = sourceRequestTextBox.Visible = customValidatorSourceRequest.Visible = false;
                    break;
            }
        }
        protected void ShowHideDataTargetControls()
        {
            ScheduledItemSourceType selectedSource =
                EnumUtils.ParseEnum<ScheduledItemSourceType>(dataSourceRadioButtonList.SelectedValue);

            if (selectedSource == ScheduledItemSourceType.WebServiceSolicit)
            {
                resultProcessRadioButtonList.SelectedValue = ScheduledItemTargetType.None.ToString();
                resultProcessRadioButtonList.Enabled = false;
            }
            else
            {
                resultProcessRadioButtonList.Enabled = true;
            }
            ScheduledItemTargetType selectedTarget =
                EnumUtils.ParseEnum<ScheduledItemTargetType>(resultProcessRadioButtonList.SelectedValue);
            switch (selectedTarget)
            {
                case ScheduledItemTargetType.None:
                    toTargetLabel.Visible = false;
                    resultPartnerDropDownList.Visible = resultPartnerDropDownListValidator.Visible = false;
                    fileTargetTextBox.Visible = fileTargetTextBoxValidator.Visible = false;
                    emailTargetTextBox.Visible = emailTargetTextBoxValidator.Visible = false;
                    resultExchangeLabel.Visible = resultExchangeTextBox.Visible =
                        resultExchangeTextBoxValidator.Visible = false;
                    resultOperationLabel.Visible = resultOperationTextBox.Visible =
                        resultOperationTextBoxValidator.Visible = false;
                    destinationSubmitServiceDropDownList.Visible = destinationSubmitServiceValidator.Visible = false;
                    break;
                case ScheduledItemTargetType.Partner:
                    toTargetLabel.Visible = true;
                    resultPartnerDropDownList.Visible = resultPartnerDropDownListValidator.Visible = true;
                    fileTargetTextBox.Visible = fileTargetTextBoxValidator.Visible = false;
                    emailTargetTextBox.Visible = emailTargetTextBoxValidator.Visible = false;
                    resultExchangeLabel.Visible = resultExchangeTextBox.Visible =
                        resultExchangeTextBoxValidator.Visible = true;
                    resultOperationLabel.Visible = resultOperationTextBox.Visible =
                        resultOperationTextBoxValidator.Visible =
                        (GetPartnerVersionFromResultPartnerDropDownList() == EndpointVersionType.EN20);
                    destinationSubmitServiceDropDownList.Visible = destinationSubmitServiceValidator.Visible = false;
                    break;
                case ScheduledItemTargetType.Schematron:
                    toTargetLabel.Visible = false;
                    resultPartnerDropDownList.Visible = resultPartnerDropDownListValidator.Visible = false;
                    fileTargetTextBox.Visible = fileTargetTextBoxValidator.Visible = false;
                    emailTargetTextBox.Visible = emailTargetTextBoxValidator.Visible = false;
                    resultExchangeLabel.Visible = resultExchangeTextBox.Visible =
                        resultExchangeTextBoxValidator.Visible = false;
                    resultOperationLabel.Visible = resultOperationTextBox.Visible =
                        resultOperationTextBoxValidator.Visible = false;
                    destinationSubmitServiceDropDownList.Visible = destinationSubmitServiceValidator.Visible = false;
                    break;
                case ScheduledItemTargetType.File:
                    toTargetLabel.Visible = true;
                    resultPartnerDropDownList.Visible = resultPartnerDropDownListValidator.Visible = false;
                    fileTargetTextBox.Visible = fileTargetTextBoxValidator.Visible = true;
                    emailTargetTextBox.Visible = emailTargetTextBoxValidator.Visible = false;
                    resultExchangeLabel.Visible = resultExchangeTextBox.Visible =
                        resultExchangeTextBoxValidator.Visible = false;
                    resultOperationLabel.Visible = resultOperationTextBox.Visible =
                        resultOperationTextBoxValidator.Visible = false;
                    destinationSubmitServiceDropDownList.Visible = destinationSubmitServiceValidator.Visible = false;
                    break;
                case ScheduledItemTargetType.Email:
                    toTargetLabel.Visible = true;
                    resultPartnerDropDownList.Visible = resultPartnerDropDownListValidator.Visible = false;
                    fileTargetTextBox.Visible = fileTargetTextBoxValidator.Visible = false;
                    emailTargetTextBox.Visible = emailTargetTextBoxValidator.Visible = true;
                    resultExchangeLabel.Visible = resultExchangeTextBox.Visible =
                        resultExchangeTextBoxValidator.Visible = false;
                    resultOperationLabel.Visible = resultOperationTextBox.Visible =
                        resultOperationTextBoxValidator.Visible = false;
                    destinationSubmitServiceDropDownList.Visible = destinationSubmitServiceValidator.Visible = false;
                    break;
                case ScheduledItemTargetType.LocalService:
                    toTargetLabel.Visible = true;
                    resultPartnerDropDownList.Visible = resultPartnerDropDownListValidator.Visible = false;
                    fileTargetTextBox.Visible = fileTargetTextBoxValidator.Visible = false;
                    emailTargetTextBox.Visible = emailTargetTextBoxValidator.Visible = false;
                    resultExchangeLabel.Visible = resultExchangeTextBox.Visible =
                        resultExchangeTextBoxValidator.Visible = false;
                    resultOperationLabel.Visible = resultOperationTextBox.Visible =
                        resultOperationTextBoxValidator.Visible = false;
                    destinationSubmitServiceDropDownList.Visible = destinationSubmitServiceValidator.Visible = true;
                    break;
            }
        }
        protected void SyncControlsToCurrentState()
        {
            ShowHideDataSourceControls();
            ShowHideDataTargetControls();
            UpdateSourceLocalServiceList();
            UpdateDestinationSubmitServiceList();
            UpdateSchematronResultEnabled();
            if (string.IsNullOrEmpty(resultExchangeTextBox.Text))
            {
                resultExchangeTextBox.Text = GetExchangeNameFromSourceLocalServiceDropDownList();
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            iconAlert.Visible = false;
            base.OnLoad(e);
        }
        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (_dataItemService == null)
            {
                throw new ArgumentNullException("DataItemService");
            }
            if (_scheduleProcessor == null)
            {
                throw new ArgumentNullException("ScheduleProcessor");
            }
            _dataModel = new DataModel();
            string id = Request["id"];
            string username = string.Empty;
            if (!string.IsNullOrEmpty(id))
            {
                _dataModel.ScheduledItem = _dataItemService.Get(id, VisitHelper.GetVisit(), out username);
                if (_dataModel.ScheduledItem == null)
                {
                    ResponseRedirect("../Secure/Schedule.aspx");
                }
                _dataModel.IsNewSchedule = false;
            }
            else
            {
                _dataModel.ScheduledItem = new ScheduledItem();
                _dataModel.ScheduledItem.StartOn = DateTime.Now.Date;
                _dataModel.ScheduledItem.EndOn = _dataModel.ScheduledItem.StartOn.AddYears(1);
                _dataModel.ScheduledItem.FrequencyType = ScheduledFrequencyType.Month;
                _dataModel.ScheduledItem.Frequency = 1;
                _dataModel.ScheduledItem.IsActive = true;
                _dataModel.ScheduledItem.NextRunOn = _dataModel.ScheduledItem.StartOn;
                _dataModel.IsNewSchedule = true;
                deleteBtn.Enabled = false;
            }
            IDictionary<string, string> localServiceList = _dataItemService.GetDataServiceDisplayList(VisitHelper.GetVisit());
            _dataModel.LocalServiceList = UIUtility.GetSortedList(localServiceList);

            IDictionary<string, string> submitServiceList = _dataItemService.GetSubmitServiceDisplayList(VisitHelper.GetVisit());
            _dataModel.SubmitServiceList = UIUtility.GetSortedList(submitServiceList);

            _dataModel.ValidSchematronFlowNames = _dataItemService.GetValidFlowCodes();

            auditLabel.Text = string.Format("Last modified by {0} on {1}", username, _dataModel.ScheduledItem.ModifiedOn);
        }

        protected override void OnInitializeControls(EventArgs e)
        {
            base.OnInitializeControls(e);

            if (!IsPostBack)
            {
                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();
                IDictionary<string, string> exchangeList = _dataItemService.GetExchangeList();
                IList<KeyValuePair<string, string>> sortedExchangeList = UIUtility.GetSortedList(exchangeList);

                flowDropDownList.DataSource = sortedExchangeList;
                flowDropDownList.DataTextField = "Value";
                flowDropDownList.DataValueField = "Key";
                flowDropDownList.DataBind();
                flowDropDownList.Items.Insert(0, new ListItem(NOT_SELECTED_TEXT, string.Empty));
                flowDropDownList.SelectedIndex = 0;

                frequencyQualifier.DataSource = EnumUtils.GetAllDescriptions<ScheduledFrequencyType>();
                frequencyQualifier.DataBind();

                IDictionary<string, string> partnerList = _dataItemService.GetPartnerList();
                IList<KeyValuePair<string, string>> sortedPartnerList = UIUtility.GetSortedList(partnerList);
                sourcePartnerDropDownList.DataSource = sortedPartnerList;
                sourcePartnerDropDownList.DataTextField = "Value";
                sourcePartnerDropDownList.DataValueField = "Key";
                sourcePartnerDropDownList.DataBind();
                sourcePartnerDropDownList.Items.Insert(0, new ListItem(NOT_SELECTED_TEXT, string.Empty));
                sourcePartnerDropDownList.SelectedIndex = 0;

                resultPartnerDropDownList.DataSource = sortedPartnerList;
                resultPartnerDropDownList.DataTextField = "Value";
                resultPartnerDropDownList.DataValueField = "Key";
                resultPartnerDropDownList.DataBind();
                resultPartnerDropDownList.Items.Insert(0, new ListItem(NOT_SELECTED_TEXT, string.Empty));
                resultPartnerDropDownList.SelectedIndex = 0;

                // Bind these so that the header shows up properly
                valueArgsRepeaterList.DataSource = new ByIndexOrNameDictionary<string>(false);
                valueArgsRepeaterList.DataBind();
                nameValueArgsRepeaterList.DataSource = new ByIndexOrNameDictionary<string>(true).NameValuePairs;
                nameValueArgsRepeaterList.DataBind();

                bool byNameValueVisible = true;
                if (DataItem.SourceArgs != null)
                {
                    if (DataItem.SourceArgs.IsByName)
                    {
                        nameValueArgsRepeaterList.DataSource = DataItem.SourceArgs.NameValuePairs;
                        nameValueArgsRepeaterList.DataBind();
                    }
                    else
                    {
                        byNameValueVisible = false;
                        valueArgsRepeaterList.DataSource = DataItem.SourceArgs;
                        valueArgsRepeaterList.DataBind();
                    }
                }
                byNameValueRadioButton.Checked = byNameValueVisible;
                nameValueArgsPanel.Visible = byNameValueVisible;
                byValueRadioButton.Checked = !byNameValueVisible;
                valueArgsPanel.Visible = !byNameValueVisible;

                startDateCalendarExtender.SelectedDate = _dataModel.ScheduledItem.StartOn;
                endDateCalendarExtender.SelectedDate = _dataModel.ScheduledItem.EndOn;

                startDateImageButton.Text = _dataModel.ScheduledItem.StartOn.ToString("yyyy-MM-dd");
                endDateImageButton.Text = _dataModel.ScheduledItem.EndOn.ToString("yyyy-MM-dd");

                AspNetUtils.SetFocus(this, nameEdit, true);
            }
        }
        public override string UniqueDataModelKey
        {
            get { return Request["id"]; }
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
            BindingManager.AddBinding("nameEdit.Text", "DataItem.Name");
            BindingManager.AddBinding("activeCheckBox.Checked", "DataItem.IsActive");
            BindingManager.AddBinding("flowDropDownList.SelectedValue", "DataItem.FlowId");
            BindingManager.AddBinding("StartTimeBinder", "DataItem.StartOn");
            BindingManager.AddBinding("EndTimeBinder", "DataItem.EndOn");
            BindingManager.AddBinding("frequencyValue.Text", "DataItem.Frequency");
            BindingManager.AddBinding("frequencyQualifier.SelectedValue", "DataItem.FrequencyType");
            BindingManager.AddBinding("dataSourceRadioButtonList.SelectedValue", "DataItem.SourceType");
            BindingManager.AddBinding("SourceIdBinder", "DataItem.SourceId");
            BindingManager.AddBinding("sourceExchangeTextBox.Text", "DataItem.SourceFlow");
            BindingManager.AddBinding("sourceRequestTextBox.Text", "DataItem.SourceRequest");
            BindingManager.AddBinding("resultProcessRadioButtonList.SelectedValue", "DataItem.TargetType");
            BindingManager.AddBinding("TargetIdBinder", "DataItem.TargetId");
            BindingManager.AddBinding("resultExchangeTextBox.Text", "DataItem.TargetFlow");
            BindingManager.AddBinding("resultOperationTextBox.Text", "DataItem.TargetRequest");
            BindingManager.AddBinding("RunTimeBinder", "DataItem.StartOn");
        }
        protected override void BindFormData()
        {
            try
            {
                base.BindFormData();
                startDateCalendarExtender.SelectedDate = DataItem.StartOn;
                endDateCalendarExtender.SelectedDate = DataItem.EndOn;
                if (!this.IsPostBack)
                {
                    SyncControlsToCurrentState();
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
            UnbindFormDataPriv(false);
        }
        protected void UnbindFormDataPriv(bool doValidate)
        {
            try
            {
                divPageError.Visible = false;
                iconAlert.Visible = false;

                if (doValidate)
                {
                    this.Validate();
                }

                if (!doValidate || this.IsValid)
                {
                    base.UnbindFormData();
                    _dataModel.ScheduledItem.StartOn = GetStartOn();
                    _dataModel.ScheduledItem.NextRunOn =
                            ScheduledItem.CalcNextRunTime(_dataModel.ScheduledItem.StartOn, _dataModel.ScheduledItem.FrequencyType,
                                                          _dataModel.ScheduledItem.Frequency,
                                                          _dataModel.ScheduledItem.LastExecuteInfo != null);
                    ScheduledItemSourceType selectedSource =
                        EnumUtils.ParseEnum<ScheduledItemSourceType>(dataSourceRadioButtonList.SelectedValue);
                    switch (selectedSource)
                    {
                        case ScheduledItemSourceType.LocalService:
                        case ScheduledItemSourceType.WebServiceQuery:
                        case ScheduledItemSourceType.WebServiceSolicit:
                            {
                                DataItem.SourceArgs = GetSourceArgs();
                            }
                            break;
                        case ScheduledItemSourceType.File:
                        default:
                            DataItem.SourceArgs = null;
                            break;
                    }
                    DataItem.Name = DataItem.Name.Trim();
                    if ( !sourceExchangeTextBox.Visible ) {
                        _dataModel.ScheduledItem.SourceFlow = string.Empty;
                    }
                    if (!sourceRequestTextBox.Visible)
                    {
                        _dataModel.ScheduledItem.SourceRequest = string.Empty;
                    }
                    if (!resultExchangeTextBox.Visible)
                    {
                        _dataModel.ScheduledItem.TargetFlow = string.Empty;
                    }
                    if (!resultOperationTextBox.Visible)
                    {
                        _dataModel.ScheduledItem.TargetRequest = string.Empty;
                    }
                }
                else
                {
                    iconAlert.Visible = true;
                }
            }
            catch (Exception ex)
            {
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
            }
        }
        #endregion

        protected void UpdateSchematronResultEnabled()
        {
            bool isEnabled = false;
            if ((flowDropDownList.SelectedItem != null) &&
                 (flowDropDownList.SelectedItem.Text != NOT_SELECTED_TEXT))
            {
                isEnabled = _dataModel.ValidSchematronFlowNames.Contains(flowDropDownList.SelectedItem.Text);
            }
            if (!isEnabled)
            {
                ScheduledItemTargetType selectedTarget =
                    EnumUtils.ParseEnum<ScheduledItemTargetType>(resultProcessRadioButtonList.SelectedValue);
                if (selectedTarget == ScheduledItemTargetType.Schematron)
                {
                    resultProcessRadioButtonList.SelectedValue = ScheduledItemTargetType.None.ToString();
                }
            }
            resultProcessRadioButtonList.Items.FindByValue(ScheduledItemTargetType.Schematron.ToString()).Enabled = isEnabled;
            if (!IsPostBack && isEnabled && (_dataModel.ScheduledItem.TargetType == ScheduledItemTargetType.Schematron))
            {
                resultProcessRadioButtonList.SelectedValue = ScheduledItemTargetType.Schematron.ToString();
            }
        }
        protected void UpdateSourceLocalServiceList()
        {
            List<KeyValuePair<string, string>> services = null;
            if ((flowDropDownList.SelectedItem != null) &&
                 (flowDropDownList.SelectedItem.Text != NOT_SELECTED_TEXT))
            {
                string flowName = flowDropDownList.SelectedItem.Text;
                string flowNameTest = flowName + " - ";
                foreach (KeyValuePair<string, string> service in _dataModel.LocalServiceList)
                {
                    if (service.Value.StartsWith(flowNameTest, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (services == null)
                        {
                            services = new List<KeyValuePair<string, string>>();
                        }
                        services.Add(service);
                    }
                }
            }
            sourceLocalServiceDropDownList.SelectedValue = null;
            sourceLocalServiceDropDownList.DataSource = services;
            sourceLocalServiceDropDownList.DataTextField = "Value";
            sourceLocalServiceDropDownList.DataValueField = "Key";
            sourceLocalServiceDropDownList.DataBind();
            sourceLocalServiceDropDownList.Items.Insert(0, new ListItem(NOT_SELECTED_TEXT, string.Empty));
            sourceLocalServiceDropDownList.SelectedIndex = 0;
            sourceLocalServiceDropDownList.Enabled = (services != null);
            if (!IsPostBack && sourceLocalServiceDropDownList.Enabled)
            {
                if ( !_dataModel.IsNewSchedule && 
                     (_dataModel.ScheduledItem.SourceType == ScheduledItemSourceType.LocalService) ) {
                    sourceLocalServiceDropDownList.SelectedValue = _dataModel.ScheduledItem.SourceId;
                }
            }
        }
        protected void UpdateDestinationSubmitServiceList()
        {
            List<KeyValuePair<string, string>> services = null;
            if ((flowDropDownList.SelectedItem != null) &&
                 (flowDropDownList.SelectedItem.Text != NOT_SELECTED_TEXT))
            {
                string flowName = flowDropDownList.SelectedItem.Text;
                string flowNameTest = flowName + " - ";
                foreach (KeyValuePair<string, string> service in _dataModel.SubmitServiceList)
                {
                    if (service.Value.StartsWith(flowNameTest, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (services == null)
                        {
                            services = new List<KeyValuePair<string, string>>();
                        }
                        services.Add(service);
                    }
                }
            }
            destinationSubmitServiceDropDownList.SelectedValue = null;
            destinationSubmitServiceDropDownList.DataSource = services;
            destinationSubmitServiceDropDownList.DataTextField = "Value";
            destinationSubmitServiceDropDownList.DataValueField = "Key";
            destinationSubmitServiceDropDownList.DataBind();
            destinationSubmitServiceDropDownList.Items.Insert(0, new ListItem(NOT_SELECTED_TEXT, string.Empty));
            destinationSubmitServiceDropDownList.SelectedIndex = 0;
            destinationSubmitServiceDropDownList.Enabled = (services != null);
            if (!IsPostBack && destinationSubmitServiceDropDownList.Enabled)
            {
                if (!_dataModel.IsNewSchedule &&
                     (_dataModel.ScheduledItem.TargetType == ScheduledItemTargetType.LocalService))
                {
                    destinationSubmitServiceDropDownList.SelectedValue = _dataModel.ScheduledItem.TargetId;
                }
            }
        }
        protected DateTime GetStartOn()
        {
            DateTime runDate = DateTime.Parse(startDateImageButton.Text);
            DateTime runTime = DateTime.Parse(runTimeTextBox.Text);
            return new DateTime(runDate.Year, runDate.Month, runDate.Day,
                                runTime.Hour, runTime.Minute, 0);
        }
        protected string SourceIdBinder
        {
            get
            {
                ScheduledItemSourceType selectedSource =
                    EnumUtils.ParseEnum<ScheduledItemSourceType>(dataSourceRadioButtonList.SelectedValue);
                string rtnValue = null;
                switch (selectedSource)
                {
                    case ScheduledItemSourceType.LocalService:
                        rtnValue = sourceLocalServiceDropDownList.SelectedValue;
                        break;
                    case ScheduledItemSourceType.WebServiceQuery:
                    case ScheduledItemSourceType.WebServiceSolicit:
                        rtnValue = sourcePartnerDropDownList.SelectedValue;
                        break;
                    case ScheduledItemSourceType.File:
                        rtnValue = fileSourceTextBox.Text;
                        break;
                }
                return (rtnValue == null) ? string.Empty : rtnValue;
            }
            set
            {
                switch (_dataModel.ScheduledItem.SourceType)
                {
                    case ScheduledItemSourceType.LocalService:
                        sourceLocalServiceDropDownList.SelectedValue = _dataModel.ScheduledItem.SourceId;
                        break;
                    case ScheduledItemSourceType.WebServiceQuery:
                    case ScheduledItemSourceType.WebServiceSolicit:
                        sourcePartnerDropDownList.SelectedValue = _dataModel.ScheduledItem.SourceId;
                        break;
                    case ScheduledItemSourceType.File:
                        fileSourceTextBox.Text = _dataModel.ScheduledItem.SourceId;
                        break;
                }
            }
        }
        protected string TargetIdBinder
        {
            get
            {
                ScheduledItemTargetType selectedTarget =
                    EnumUtils.ParseEnum<ScheduledItemTargetType>(resultProcessRadioButtonList.SelectedValue);
                switch (selectedTarget)
                {
                    case ScheduledItemTargetType.None:
                        return string.Empty;
                    case ScheduledItemTargetType.Partner:
                        return resultPartnerDropDownList.SelectedValue;
                    case ScheduledItemTargetType.Schematron:
                        return string.Empty;
                    case ScheduledItemTargetType.File:
                        return fileTargetTextBox.Text;
                    case ScheduledItemTargetType.Email:
                        return emailTargetTextBox.Text;
                    case ScheduledItemTargetType.LocalService:
                        return destinationSubmitServiceDropDownList.SelectedValue;
                    default:
                        return string.Empty;
                }
            }
            set
            {
                switch (_dataModel.ScheduledItem.TargetType)
                {
                    case ScheduledItemTargetType.None:
                        break;
                    case ScheduledItemTargetType.Partner:
                        resultPartnerDropDownList.SelectedValue = DataItem.TargetId;
                        break;
                    case ScheduledItemTargetType.Schematron:
                        break;
                    case ScheduledItemTargetType.File:
                        fileTargetTextBox.Text = DataItem.TargetId;
                        break;
                    case ScheduledItemTargetType.Email:
                        emailTargetTextBox.Text = DataItem.TargetId;
                        break;
                    case ScheduledItemTargetType.LocalService:
                        destinationSubmitServiceDropDownList.SelectedValue = DataItem.TargetId;
                        break;
                    default:
                        break;
                }
            }
        }

        protected DateTime StartTimeBinder
        {
            get
            {
                if (startDateImageButton.Text.Length > 0)
                {
                    try
                    {
                        DateTime startTime = DateTime.Parse(startDateImageButton.Text);
                        DataItem.StartOn =
                            new DateTime(startTime.Year, startTime.Month, startTime.Day,
                                         DataItem.StartOn.Hour, DataItem.StartOn.Minute, 0);
                        return startTime;
                    }
                    catch (Exception)
                    {
                    }
                }
                return DateTime.MinValue;
            }
            set
            {
                startDateCalendarExtender.SelectedDate = DataItem.StartOn;
            }
        }
        protected DateTime EndTimeBinder
        {
            get
            {
                if (endDateImageButton.Text.Length > 0)
                {
                    try
                    {
                        DateTime endTime = DateTime.Parse(endDateImageButton.Text);
                        DataItem.EndOn =
                            new DateTime(endTime.Year, endTime.Month, endTime.Day,
                                         0, 0, 0);
                        return endTime;
                    }
                    catch (Exception)
                    {
                    }
                }
                return DateTime.MinValue;
            }
            set
            {
                endDateCalendarExtender.SelectedDate = DataItem.EndOn;
            }
        }
        protected DateTime RunTimeBinder
        {
            get
            {
                if (runTimeTextBox.Text.Length > 0)
                {
                    try
                    {
                        DateTime runTime = DateTime.Parse(runTimeTextBox.Text);
                        DataItem.StartOn = 
                            new DateTime(DataItem.StartOn.Year, DataItem.StartOn.Month, DataItem.StartOn.Day,
                                         runTime.Hour, runTime.Minute, 0);
                        return runTime;
                    }
                    catch (Exception)
                    {
                    }
                }
                return DateTime.MinValue;
            }
            set
            {
                runTimeTextBox.Text = DataItem.StartOn.ToString("hh:mm tt");
            }
        }
        protected void CancelItem(object sender, EventArgs e)
        {
            ResponseRedirect("../Secure/Schedule.aspx");
        }
        protected void SaveDataItem(object sender, EventArgs e)
        {
            UnbindFormDataPriv(true);
            if (divPageError.Visible || !Page.IsValid)
            {
                // Error on page, get out of here
                return;
            }
            try
            {
                _dataModel.ScheduledItem = _dataItemService.Save(_dataModel.ScheduledItem, VisitHelper.GetVisit());

                if (_scheduleProcessor != null)
                {
                    _scheduleProcessor.Wakeup();
                }

                ResponseRedirect("../Secure/Schedule.aspx");
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
                _dataItemService.Delete(_dataModel.ScheduledItem, VisitHelper.GetVisit());
                ResponseRedirect("../Secure/Schedule.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
            }
        }
        protected void RunNow(object sender, EventArgs e)
        {
            UnbindFormDataPriv(true);
            if (divPageError.Visible || !Page.IsValid)
            {
                // Error on page, get out of here
                return;
            }
            try
            {
                _dataModel.ScheduledItem =
                    _dataItemService.SaveAndRunNow(_dataModel.ScheduledItem, VisitHelper.GetVisit());
                if (_scheduleProcessor != null)
                {
                    _scheduleProcessor.Wakeup();
                }
                ResponseRedirect("../Secure/Schedule.aspx");
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
                divPageError.Visible = true;
                divPageError.InnerText = ExceptionUtils.GetDeepExceptionMessage(ex);
            }
        }

        #region Properties

        public IScheduleService DataItemService
        {
            get { return _dataItemService; }
            set { _dataItemService = value; }
        }

        public ScheduledItem DataItem
        {
            get { return _dataModel.ScheduledItem; }
            set { _dataModel.ScheduledItem = value; }
        }
        public INodeProcessor ScheduleProcessor
        {
            get { return _scheduleProcessor; }
            set { _scheduleProcessor = value; }
        }
        #endregion

        protected string GetExchangeNameFromSourceLocalServiceDropDownList()
        {
            string text = sourceLocalServiceDropDownList.SelectedItem.Text;
            int index = text.IndexOf('-');
            if (index > 0)
            {
                return text.Substring(0, index - 1).Trim();
            }
            return string.Empty;
        }
        protected EndpointVersionType GetPartnerVersionFromResultPartnerDropDownList()
        {
            return GetPartnerVersionFromDropDownList(resultPartnerDropDownList);
        }
        protected EndpointVersionType GetPartnerVersionFromSourcePartnerDropDownList()
        {
            return GetPartnerVersionFromDropDownList(sourcePartnerDropDownList);
        }
        static protected EndpointVersionType GetPartnerVersionFromDropDownList(DropDownList list)
        {
            string text = list.SelectedItem.Text;
            int index1 = text.LastIndexOf('(');
            if (index1 > 0)
            {
                int index2 = text.LastIndexOf(')');
                if (index2 > (index1 + 1))
                {
                    text = text.Substring(index1 + 1, index2 - index1 - 1).Trim();
                    EndpointVersionType version = EnumUtils.FromDescription<EndpointVersionType>(text);
                    return version;
                }
            }
            return EndpointVersionType.EN11;
        }
        protected void dataSourceRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                // Don't need to call this, called automatically as part of Spring data binding:
                ShowHideDataSourceControls();
                ShowHideDataTargetControls();
            }
        }
        protected void ServerValidateDate(Object source, ServerValidateEventArgs e)
        {
            DateTime result;
            e.IsValid = DateTime.TryParse(e.Value, out result);
            if (e.IsValid)
            {
                e.IsValid = (result >= MIN_VALID_DATE) && (result <= MAX_VALID_DATE);
            }
        }
        protected void ServerValidateRunTime(Object source, ServerValidateEventArgs e)
        {
            DateTime result;
            e.IsValid = DateTime.TryParse(e.Value, out result);
        }
        protected void ServerValidateStartEndDates(Object source, ServerValidateEventArgs e)
        {
            e.IsValid = false;

            DateTime startDate, endDate;
            
            if ( DateTime.TryParse(startDateImageButton.Text, out startDate) &&
                 DateTime.TryParse(startDateImageButton.Text, out endDate) ) {

                if ( startDate <= endDate ) {
                    e.IsValid = (startDate >= ActivitySearchParams.MIN_DATETIME) && (startDate <= ActivitySearchParams.MAX_DATETIME) &&
                                (endDate >= ActivitySearchParams.MIN_DATETIME) && (endDate <= ActivitySearchParams.MAX_DATETIME);
                }
            }
        }
        protected void ServerValidateSourceOperation(Object source, ServerValidateEventArgs e)
        {
            e.IsValid = true;
        }
        protected void resultProcessRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                // Don't need to call this, called automatically as part of Spring data binding:
                ShowHideDataTargetControls();
            }
        }
        protected ByIndexOrNameDictionary<string> GetSourceArgs()
        {
            ByIndexOrNameDictionary<string> sourceArgs;
            if (nameValueArgsPanel.Visible)
            {
                sourceArgs = new ByIndexOrNameDictionary<string>(true);
                Repeater repeater = nameValueArgsRepeaterList;
                foreach (RepeaterItem item in repeater.Items)
                {
                    string name = ((TextBox)item.FindControl("argName")).Text;
                    string value = ((TextBox)item.FindControl("argValue")).Text;
                    sourceArgs.Add(name, value);
                }
            }
            else
            {
                sourceArgs = new ByIndexOrNameDictionary<string>(false);
                Repeater repeater = valueArgsRepeaterList;
                foreach (RepeaterItem item in repeater.Items)
                {
                    string value = ((TextBox)item.FindControl("argValue")).Text;
                    sourceArgs.Add(value);
                }
            }
            return sourceArgs;
        }
        public void OnSourceArgsNameValueClick(object source, CommandEventArgs e)
        {
            try
            {
                ByIndexOrNameDictionary<string> args = GetSourceArgs();
                int index = int.Parse(e.CommandArgument.ToString());
                if (e.CommandName == "Add")
                {
                    if (args.IsByName)
                    {
                        string newName;
                        for (int i = 0; ; ++i)
                        {
                            if (i == 0)
                            {
                                newName = "Name";
                            }
                            else
                            {
                                newName = "Name " + i.ToString();
                            }
                            if (!args.ContainsKey(newName))
                            {
                                break;
                            }
                        }
                        args.Insert(index + 1, newName, string.Empty);
                    }
                    else
                    {
                        args.Insert(index + 1, string.Empty);
                    }
                }
                else if (e.CommandName == "Delete")
                {
                    args.RemoveAt(index);
                }
                if (args.IsByName)
                {
                    nameValueArgsRepeaterList.DataSource = args.NameValuePairs;
                    nameValueArgsRepeaterList.DataBind();
                }
                else
                {
                    valueArgsRepeaterList.DataSource = args;
                    valueArgsRepeaterList.DataBind();
                }
            }
            catch (Exception ex)
            {
                divPageError.Visible = true;
                divPageError.InnerText = UIUtility.ParseException(ex);
            }
        }
        protected void UpdateVisibleSourceArgsList()
        {
            if (byNameValueRadioButton.Checked)
            {
                if (!nameValueArgsPanel.Visible && valueArgsPanel.Visible)
                {
                    nameValueArgsPanel.Visible = true;
                    valueArgsPanel.Visible = false;
                    // Move values over

                }
                else
                {
                    if (!nameValueArgsPanel.Visible) nameValueArgsPanel.Visible = true;
                    if (valueArgsPanel.Visible) valueArgsPanel.Visible = false;
                }
            }
            else
            {
                if (nameValueArgsPanel.Visible) nameValueArgsPanel.Visible = false;
                if (!valueArgsPanel.Visible) valueArgsPanel.Visible = true;
            }
        }
        protected void byValueRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibleSourceArgsList();
        }

        protected void byIndexRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibleSourceArgsList();
        }

        protected void resultPartnerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                resultOperationLabel.Visible = resultOperationTextBox.Visible = 
                    (GetPartnerVersionFromResultPartnerDropDownList() == EndpointVersionType.EN20);
            }
        }

        protected void sourceLocalServiceDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                resultExchangeTextBox.Text = GetExchangeNameFromSourceLocalServiceDropDownList();
            }
        }

        protected void sourcePartnerDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ShowHideDataSourceControls();
            }
        }

        protected string FlowNameFromDropDown(DropDownList list)
        {
            return flowDropDownList.SelectedItem.Text;
        }
        protected void flowDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                UpdateSourceLocalServiceList();
                UpdateDestinationSubmitServiceList();
                UpdateSchematronResultEnabled();
                if (_dataModel.IsNewSchedule)
                {
                    if ( flowDropDownList.SelectedItem.Text != NOT_SELECTED_TEXT ) {
                        resultExchangeTextBox.Text = FlowNameFromDropDown(flowDropDownList);
                    }
                }
            }
        }
    }
}
